using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections.Concurrent;
using System.Globalization;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Auditing;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

using Bamboo.Core.Models;
namespace Bamboo.Core.Application
{
    /*
        TODO: DONOT SEED COMPANY DATA FROM XML, TOO COMPLICATE.
    */
    public class DataSeedService : ApplicationService, IDataSeedService, ITransientDependency
    {
        private readonly IRepository<IrModelData, Guid> _irModelDataRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly ICurrentTenant _currentTenant;
        private readonly IServiceProvider _serviceProvider;
        private readonly IModelTypeRegistry _modelTypeRegistry;
        private readonly IJunctionTableService _junctionTableService;
        private readonly IGuidGenerator _guidGenerator;
        private readonly ConcurrentDictionary<Type, object> _repositoryCache = new();
        private readonly Dictionary<Type, object> _entityServiceCache = new Dictionary<Type, object>();
        private readonly Dictionary<string, Guid?> relateInserted = new Dictionary<string, Guid?>();

        public DataSeedService(
            IRepository<IrModelData, Guid> irModelDataRepository,
            IUnitOfWorkManager unitOfWorkManager,
            ICurrentTenant currentTenant,
            IServiceProvider serviceProvider,
            IModelTypeRegistry modelTypeRegistry,
            IGuidGenerator guidGenerator,
            IJunctionTableService junctionTableService)
        {
            _irModelDataRepository = irModelDataRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _currentTenant = currentTenant;
            _serviceProvider = serviceProvider;
            _modelTypeRegistry = modelTypeRegistry;
            _guidGenerator = guidGenerator;
            _junctionTableService = junctionTableService;
        }

        public async Task SeedDataAsync(List<string> paths, Guid? tenantId = null, bool includeDemoData = false)
        {
            foreach (var path in paths)
            {
                await SeedDataAsync(path, tenantId, includeDemoData);
            }
        }

        public async Task<ResCompany> SeedTenantDataAsync(Guid? tenantId = null, string name = "")
        {
            return null;
        }

        public async Task<ResUsers> SeedUserDataAsync(Guid? userId = null, string name = "")
        {
            var userRepository = LazyServiceProvider.LazyGetService<IRepository<ResUsers, Guid>>();
            return null;
        }

        private object GetOrAddRepository(Type entityType)
        {
            return _repositoryCache.GetOrAdd(entityType, type =>
            {
                var repoType = typeof(IRepository<,>).MakeGenericType(type, typeof(Guid));
                return _serviceProvider.GetRequiredService(repoType);
            });
        }

        [DisableAuditing]
        [UnitOfWork]
        public async Task SeedDataAsync(string path, Guid? tenantId = null, bool includeDemoData = false)
        {
            using (_currentTenant.Change(tenantId))
            {
                if (!Directory.Exists(path))
                {
                    throw new UserFriendlyException($"Folder {path} does not exist.");
                }

                var xmlFiles = Directory.GetFiles(path, "*.xml", SearchOption.AllDirectories);
                var pendingRelations = new List<PendingRelation>();

                // Xử lý batch theo từng file
                foreach (var xmlFile in xmlFiles)
                {
                    await InsertRecordsAsync(xmlFile, tenantId, pendingRelations, includeDemoData);
                }

                // Cập nhật quan hệ sau khi insert tất cả bản ghi
                await UpdateRelationsAsync(pendingRelations, tenantId);
            }
        }

        private async Task InsertRecordsAsync(string xmlFilePath, Guid? tenantId, List<PendingRelation> pendingRelations, bool includeDemoData)
        {
            try
            {
                Logger.LogInformation($"Start process XML file {xmlFilePath}");
                var xmlContent = await File.ReadAllTextAsync(xmlFilePath);
                var xmlDoc = XDocument.Parse(xmlContent);
                var moduleName = Path.GetFileNameWithoutExtension(xmlFilePath).Split('.').FirstOrDefault();

                // Gom nhóm bản ghi theo model để batch insert
                var recordsByModel = new Dictionary<string, List<(XElement Record, bool IsNoUpdate)>>();
                foreach (var dataElement in xmlDoc.Descendants("data"))
                {
                    var dataNoUpdate = dataElement.Attribute("noupdate")?.Value;
                    bool isDataNoUpdate = dataNoUpdate == "1";

                    foreach (var record in dataElement.Elements("record"))
                    {
                        var recordNoUpdate = record.Attribute("noupdate")?.Value;
                        var isNoUpdate = recordNoUpdate != null ? recordNoUpdate == "1" : isDataNoUpdate;

                        if (!includeDemoData && !isNoUpdate)
                        {
                            continue;
                        }

                        var model = record.Attribute("model")?.Value;
                        if (string.IsNullOrEmpty(model))
                        {
                            Logger.LogWarning($"Record with id {record.Attribute("id")?.Value} has no model specified.");
                            continue;
                        }

                        if (!recordsByModel.ContainsKey(model))
                        {
                            recordsByModel[model] = new List<(XElement, bool)>();
                        }
                        recordsByModel[model].Add((record, isNoUpdate));
                    }
                }

                // Batch insert theo model
                foreach (var modelGroup in recordsByModel)
                {
                    var model = modelGroup.Key;
                    var records = modelGroup.Value;

                    var entityType = _modelTypeRegistry.GetType(model);
                    if (entityType == null)
                    {
                        Logger.LogWarning($"Entity type for model {model} not found in IModelTypeRegistry.");
                        continue;
                    }

                    // if (!_entityServiceCache.TryGetValue(entityType, out var service))
                    // {
                    //     var serviceType = typeof(IRepositoryService<>).MakeGenericType(entityType);
                    //     service = _serviceProvider.GetService(serviceType);
                    //     if (service == null)
                    //     {
                    //         Logger.LogError($"IEntityService<{entityType.Name}> not found in DI container.");
                    //         continue;
                    //     }
                    //     _entityServiceCache[entityType] = service;
                    // }

                    // Kiểm tra bản ghi tồn tại
                    var xmlIds = records.Select(r => r.Record.Attribute("id")?.Value ?? _guidGenerator.Create().ToString()).ToList();
                    var existingRecords = (await _irModelDataRepository.GetQueryableAsync())
                        .Where(r => r.Model == model && r.Module == moduleName && xmlIds.Contains(r.Name))
                        .ToList();
                    foreach (var r in existingRecords)
                    {
                        relateInserted[$"{r.Module}.{r.Name}"] = r.ResId;
                    }
                    var existingXmlIds = existingRecords.Select(r => r.Name).ToHashSet();
                    var entitiesToInsert = new List<object>();
                    var irModelDataToInsert = new List<IrModelData>();

                    foreach (var (record, isNoUpdate) in records)
                    {
                        var xmlId = record.Attribute("id")?.Value ?? _guidGenerator.Create().ToString();
                        if (existingXmlIds.Contains(xmlId))
                        {
                            continue; // Bỏ qua bản ghi đã tồn tại
                        }

                        var entity = await ProcessRecordAsync(record, moduleName, tenantId, pendingRelations, isNoUpdate, entityType, xmlId);
                        if (entity != null)
                        {
                            entitiesToInsert.Add(entity);
                            irModelDataToInsert.Add(new IrModelData
                            {
                                Module = moduleName,
                                Model = model,
                                Name = xmlId,
                                ResId = (Guid)entityType.GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).GetValue(entity),
                                Noupdate = isNoUpdate,
                                CreationTime = DateTime.UtcNow,
                                CreatorId = CurrentUser.Id
                            });
                        }
                    }

                    if (entitiesToInsert.Any())
                    {
                        if (!_entityServiceCache.TryGetValue(entityType, out var service))
                        {
                            var serviceType = typeof(IRepositoryService<>).MakeGenericType(entityType);
                            service = _serviceProvider.GetService(serviceType);
                            if (service == null)
                            {
                                Logger.LogError($"IEntityService<{entityType.Name}> not found in DI container.");
                                continue;
                            }
                            _entityServiceCache[entityType] = service;
                        }

                        try
                        {
                            var insertMethod = service.GetType().GetMethod("InsertManyAsync");
                            if (insertMethod == null)
                            {
                                Logger.LogError($"InsertManyAsync method not found in IEntityService<{entityType.Name}>.");
                                continue;
                            }
                            // 1. Get the Enumerable.Cast<T>() method definition
                            var castMethod = typeof(Enumerable).GetMethod("Cast")
                                                            .MakeGenericMethod(entityType);

                            // 2. Invoke the Cast method on your list of objects
                            // The first argument 'null' is because Cast is a static extension method.
                            var typedEnumerable = castMethod.Invoke(null, new object[] { entitiesToInsert });

                            await (Task)insertMethod.Invoke(service, new object[] { typedEnumerable, false, default(CancellationToken) });
                            await _irModelDataRepository.InsertManyAsync(irModelDataToInsert.AsEnumerable(), autoSave: false);
                            foreach (var r in irModelDataToInsert)
                            {
                                relateInserted[$"{r.Module}.{r.Name}"] = r.ResId;
                            }
                            Logger.LogInformation($"Batch insert entities ({entitiesToInsert.Count}) for model {model}");
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError($"Failed to batch insert entities for model {model} ({entitiesToInsert.Count}): {ex.Message}");
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning($"Error processing XML file {xmlFilePath}: {ex.Message}");
            }
        }

        private async Task<object?> ProcessRecordAsync(XElement record, string moduleName, Guid? tenantId, List<PendingRelation> pendingRelations, bool isNoUpdate, Type entityType, string xmlId)
        {
            var entity = Activator.CreateInstance(entityType);
            if (entity == null)
            {
                Logger.LogError($"Failed to create instance of {entityType.Name}.");
                return null;
            }

            var recordId = _guidGenerator.Create();
            var idProperty = entityType.GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            if (idProperty != null && idProperty.CanWrite)
            {
                idProperty.SetValue(entity, recordId);
            }
            else
            {
                Logger.LogWarning($"Property 'Id' not found or not writable in {entityType.Name}.");
            }

            var tenantIdProperty = entityType.GetProperty("TenantId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            if (tenantIdProperty != null && tenantIdProperty.CanWrite)
            {
                tenantIdProperty.SetValue(entity, tenantId);
            }
            else
            {
                Logger.LogWarning($"Property 'TenantId' not found or not writable in {entityType.Name}.");
            }
            bool isRefRecord = false;
            PendingRelation? relation = null;
            foreach (var field in record.Elements("field"))
            {
                var fieldName = field.Attribute("name")?.Value;
                if (string.IsNullOrEmpty(fieldName))
                {
                    Logger.LogWarning($"Field in record {xmlId} (model {record.Attribute("model")?.Value}) has no name specified.");
                    continue;
                }

                var propertyName = ConvertFieldToPascalCase(fieldName);
                var property = entityType.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                if (property == null || !property.CanWrite)
                {
                    if (fieldName != "create_date")
                    {
                        Logger.LogWarning($"Property {propertyName} for field {fieldName} in model {record.Attribute("model")?.Value} not found or not writable.");
                    }
                    continue;
                }

                if (fieldName.Equals("company_id", StringComparison.OrdinalIgnoreCase))
                {
                    property.SetValue(entity, tenantId);
                    continue;
                }

                bool isMany2Many = await _junctionTableService.IsMany2ManyRelationAsync(record.Attribute("model")?.Value, fieldName);

                if (field.Elements("record").Any())
                {
                    var elementType = property.PropertyType.IsGenericType
                        ? property.PropertyType.GetGenericArguments()[0]
                        : property.PropertyType.GetElementType();
                    var relatedModel = GetModelFromEntityType(elementType);
                    var relatedRecords = new List<object>();

                    foreach (var inlineRecord in field.Elements("record"))
                    {
                        var inlineNoUpdate = inlineRecord.Attribute("noupdate")?.Value;
                        bool inlineIsNoUpdate = inlineNoUpdate != null ? inlineNoUpdate == "1" : isNoUpdate;
                        var relatedRecord = await ProcessRecordAsync(inlineRecord, moduleName, tenantId, pendingRelations, inlineIsNoUpdate, elementType, inlineRecord.Attribute("id")?.Value ?? Guid.NewGuid().ToString());
                        if (relatedRecord != null)
                        {
                            relatedRecords.Add(relatedRecord);
                        }
                    }

                    if (isMany2Many)
                    {
                        var relatedIds = relatedRecords.Select(r => (Guid)r.GetType().GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).GetValue(r)).ToList();
                        await _junctionTableService.InsertJunctionRecordsAsync(record.Attribute("model")?.Value, fieldName, recordId, relatedIds, tenantId);
                    }
                    else
                    {
                        var collectionType = typeof(List<>).MakeGenericType(elementType);
                        var collection = Activator.CreateInstance(collectionType);
                        var addMethod = collectionType.GetMethod("Add");

                        foreach (var recordRealate in relatedRecords)
                        {
                            addMethod.Invoke(collection, new[] { recordRealate });
                        }

                        property.SetValue(entity, collection);
                    }
                    continue;
                }

                if (field.Attribute("ref") != null || field.Attribute("eval") != null)
                {
                    if (relation == null)
                    {
                        relation = new PendingRelation
                        {
                            Module = moduleName,
                            Model = record.Attribute("model")?.Value,
                            IsNoUpdate = isNoUpdate,
                            Entity = entity,
                            XmlId = xmlId,
                            Fields = new List<PendingRelationField>(),
                        };
                    }
                    var relationField = new PendingRelationField
                    {
                        Property = property,
                        FieldElement = field,
                        IsMany2Many = isMany2Many
                    };
                    if (field.Attribute("ref") != null)
                    {
                        relationField.RefXmlId = field.Attribute("ref")?.Value;
                    }
                    relation.Fields.Add(relationField);
                    isRefRecord = true;
                    continue;
                }

                try
                {
                    var fieldValue = field.Value;
                    if (field.Attribute("type")?.Value == "json" || property.PropertyType == typeof(Dictionary<string, object>))
                    {
                        var jsonValue = JsonSerializer.Deserialize(fieldValue, property.PropertyType);
                        property.SetValue(entity, jsonValue);
                    }
                    else if (property.PropertyType == typeof(StringDictionary))
                    {
                        var value = new StringDictionary
                        {
                            { "en_US", fieldValue }
                        };
                        property.SetValue(entity, value);

                    }
                    else
                    {
                        var convertedValue = ChangeTypeSafe(fieldValue, property.PropertyType);
                        property.SetValue(entity, convertedValue);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogWarning($"Failed to set property {propertyName} for field {fieldName} in model {record.Attribute("model")?.Value}: {ex.Message}");
                }
            }
            if (isRefRecord && relation != null)
            {
                relation.Entity = entity;
                pendingRelations.Add(relation);
                return null;
            }
            return entity;
        }

        private async Task UpdateRelationsAsync(List<PendingRelation> pendingRelations, Guid? tenantId)
        {
            bool progress = true;
            while (progress && pendingRelations.Any())
            {
                progress = false;
                var entitiesToUpdate = new List<object>();
                var irModelDataToInsert = new List<IrModelData>();
                int recorIdx = 0;
                foreach (var relation in pendingRelations)
                {
                    recorIdx++;
                    var model = relation.Model;
                    var entityType = _modelTypeRegistry.GetType(model);
                    if (entityType == null)
                    {
                        Logger.LogWarning($"Entity type for model {model} not found in IModelTypeRegistry.");
                        continue;
                    }
                    var entity = relation.Entity;
                    foreach (var fieldRelate in relation.Fields)
                    {
                        if (fieldRelate.IsResolved)
                            continue;

                        progress = true;
                        var property = fieldRelate.Property;
                        var field = fieldRelate.FieldElement;
                        var fieldName = field.Attribute("name")?.Value;
                        var recordId = (Guid)entityType.GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).GetValue(entity);
                        if (fieldName.Equals("company_id", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        if (field.Attribute("ref") != null)
                        {
                            var refValue = field.Attribute("ref")?.Value;
                            var relatedModel = field.Attribute("model")?.Value ?? GetModelFromEntityType(property.PropertyType);
                            if (relateInserted.ContainsKey($"{fieldRelate.RefXmlId}"))
                            {
                                property.SetValue(entity, relateInserted[$"{fieldRelate.RefXmlId}"]);
                                fieldRelate.IsResolved = true;
                                progress = true;
                                continue;
                            }
                            var relatedRecord = await GetRelatedRecordAsync(relatedModel, refValue, tenantId);
                            if (relatedRecord != null)
                            {
                                property.SetValue(entity, relatedRecord);
                                fieldRelate.IsResolved = true;
                                progress = true;
                                //entitiesToUpdate.Add(entity);
                            }
                            continue;
                        }
                        if (field.Attribute("eval") != null)
                        {
                            fieldRelate.IsResolved = true;
                            progress = true;
                            var evalValue = field.Value;

                            var elementType = property.PropertyType.IsGenericType
                                ? property.PropertyType.GetGenericArguments()[0]
                                : property.PropertyType.GetElementType();
                            //var relatedModel = GetModelFromEntityType(elementType);
                            var relatedModel = "";
                            var refIds = ParseEvalIds(evalValue);
                            var relatedRecords = new List<object>();

                            foreach (var refId in refIds)
                            {
                                if (relateInserted.ContainsKey($"{refId}"))
                                {
                                    // property.SetValue(entity, relateInserted[$"{fieldRelate.RefXmlId}"]);
                                    // fieldRelate.IsResolved = true;
                                    // progress = true;
                                    continue;
                                }
                                var relatedRecord = await GetRelatedRecordAsync(relatedModel, refId, tenantId);
                                if (relatedRecord != null)
                                {
                                    relatedRecords.Add(relatedRecord);
                                }
                            }

                            if (fieldRelate.IsMany2Many)
                            {
                                //var relatedIds = relatedRecords.Select(r => (Guid)r.GetType().GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).GetValue(r)).ToList();
                                //await _junctionTableService.InsertJunctionRecordsAsync(model, fieldName, recordId, relatedIds, tenantId);
                            }
                            else
                            {
                                if (relatedRecords.Any())
                                {
                                    try
                                    {
                                        var collectionType = typeof(List<>).MakeGenericType(elementType);
                                        var collection = Activator.CreateInstance(collectionType);
                                        var addMethod = collectionType.GetMethod("Add");

                                        foreach (var record in relatedRecords)
                                        {
                                            addMethod.Invoke(collection, new[] { record });
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Logger.LogInformation("Error process relate field");
                                        //throw;
                                    }
                                }
                                //property.SetValue(entity, collection);
                                fieldRelate.IsResolved = true;
                                progress = true;
                            }
                        }
                    }
                    relation.Fields.RemoveAll(f => f.IsResolved);
                    if (!relation.Fields.Any())
                    {
                        entitiesToUpdate.Add(relation.Entity);
                        irModelDataToInsert.Add(new IrModelData
                        {
                            Module = relation.Module,
                            Model = model,
                            Name = relation.XmlId,
                            ResId = (Guid)entityType.GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).GetValue(entity),
                            Noupdate = relation.IsNoUpdate,
                            CreationTime = DateTime.UtcNow,
                            CreatorId = CurrentUser.Id
                        });
                        relation.IsResolved = true;
                    }
                }
                if (entitiesToUpdate.Any())
                {
                    try
                    {
                        Logger.LogInformation($"Insert ref entities: {entitiesToUpdate.Count}");
                        for (int i = 0; i < entitiesToUpdate.Count; i++)
                        {
                            var entity = entitiesToUpdate[i];
                            var repos = GetOrAddRepository(entity.GetType());
                            await ((dynamic)repos).InsertAsync((dynamic)entity, false, CancellationToken.None);
                            await _irModelDataRepository.InsertAsync(irModelDataToInsert[i], autoSave: false);
                            relateInserted[$"{irModelDataToInsert[i].Module}.{irModelDataToInsert[i].Name}"] = irModelDataToInsert[i].ResId;
                            progress = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError($"Failed to insert ref entities {ex.Message}");
                        throw;
                    }
                }
                entitiesToUpdate.Clear();
                irModelDataToInsert.Clear();
                pendingRelations.RemoveAll(r => r.IsResolved);
            }
        }

        private async Task UpdateRelationsByGroupAsync(List<PendingRelation> pendingRelations, Guid? tenantId)
        {
            // Gom nhóm quan hệ theo model để batch update
            var relationsByModel = pendingRelations
                .GroupBy(r => r.Model)
                .ToDictionary(g => g.Key, g => g.ToList());

            foreach (var modelGroup in relationsByModel)
            {
                var model = modelGroup.Key;
                var relations = modelGroup.Value;

                var entityType = _modelTypeRegistry.GetType(model);
                if (entityType == null)
                {
                    Logger.LogWarning($"Entity type for model {model} not found in IModelTypeRegistry.");
                    continue;
                }

                var serviceType = typeof(IRepositoryService<>).MakeGenericType(entityType);
                var service = _serviceProvider.GetService(serviceType);
                if (service == null)
                {
                    Logger.LogError($"IEntityService<{entityType.Name}> not found in DI container.");
                    continue;
                }

                var entitiesToUpdate = new List<object>();


                foreach (var relation in relations)
                {
                    foreach (var fieldRelate in relation.Fields)
                    {
                        var relateId = GetRelatedRecordAsync(relation.Model, fieldRelate.RefXmlId, tenantId);
                        if (relateId == null)
                        {
                            continue;
                        }
                        var property = fieldRelate.Property;
                        var field = fieldRelate.FieldElement;
                        var fieldName = field.Attribute("name")?.Value;
                        var entity = relation.Entity;
                        var recordId = (Guid)entityType.GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).GetValue(entity);

                        if (fieldName.Equals("company_id", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }

                        if (field.Attribute("ref") != null)
                        {
                            var refValue = field.Attribute("ref")?.Value;
                            var relatedModel = field.Attribute("model")?.Value ?? GetModelFromEntityType(property.PropertyType);
                            var relatedRecord = await GetRelatedRecordAsync(relatedModel, refValue, tenantId);
                            if (relatedRecord != null)
                            {
                                property.SetValue(entity, relatedRecord);
                                entitiesToUpdate.Add(entity);
                            }
                            continue;
                        }

                        if (field.Attribute("eval") != null)
                        {
                            var evalValue = field.Value;
                            var elementType = property.PropertyType.IsGenericType
                                ? property.PropertyType.GetGenericArguments()[0]
                                : property.PropertyType.GetElementType();
                            var relatedModel = GetModelFromEntityType(elementType);

                            var refIds = ParseEvalIds(evalValue);
                            var relatedRecords = new List<object>();

                            foreach (var refId in refIds)
                            {
                                var relatedRecord = await GetRelatedRecordAsync(relatedModel, refId, tenantId);
                                if (relatedRecord != null)
                                {
                                    relatedRecords.Add(relatedRecord);
                                }
                            }

                            if (fieldRelate.IsMany2Many)
                            {
                                var relatedIds = relatedRecords.Select(r => (Guid)r.GetType().GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).GetValue(r)).ToList();
                                await _junctionTableService.InsertJunctionRecordsAsync(model, fieldName, recordId, relatedIds, tenantId);
                            }
                            else
                            {
                                var collectionType = typeof(List<>).MakeGenericType(elementType);
                                var collection = Activator.CreateInstance(collectionType);
                                var addMethod = collectionType.GetMethod("Add");

                                foreach (var record in relatedRecords)
                                {
                                    addMethod.Invoke(collection, new[] { record });
                                }

                                property.SetValue(entity, collection);
                                //entitiesToUpdate.Add(entity);
                            }
                        }
                    }
                    entitiesToUpdate.Add(relation.Entity);
                }

                if (entitiesToUpdate.Any())
                {
                    try
                    {
                        var updateMethod = serviceType.GetMethod("UpdateAsync");
                        if (updateMethod == null)
                        {
                            Logger.LogError($"UpdateAsync method not found in IEntityService<{entityType.Name}>.");
                            continue;
                        }

                        // Batch update
                        foreach (var entity in entitiesToUpdate)
                        {
                            await (Task)updateMethod.Invoke(service, new object[] { entity, false, default(CancellationToken) });
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError($"Failed to batch update entities for model {model}: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        private async Task<object> GetRelatedRecordAsync(string model, string xmlId, Guid? tenantId)
        {
            var parts = xmlId.Split(".");
            string moduleName = parts.Length == 2 ? parts[0] : "base";
            string name = parts.Length == 2 ? parts[1] : xmlId;
            var irModelDatum = await _irModelDataRepository
                .FirstOrDefaultAsync(r => r.Module == moduleName && r.Name == name);

            if (irModelDatum == null)
            {
                return null;
            }
            return irModelDatum.Id;

            // var entityType = _modelTypeRegistry.GetType(ConvertModelToPascalCase(model));
            // if (entityType == null)
            // {
            //     Logger.LogWarning($"Entity type for model {model} not found in IModelTypeRegistry.");
            //     return null;
            // }

            // var irModelDatum = await _irModelDataRepository
            //     .FirstOrDefaultAsync(r => r.Model == model && r.Name == xmlId && r.TenantId == tenantId);

            // if (irModelDatum == null)
            // {
            //     Logger.LogWarning($"No IrModelDatum found for model {model} with xmlId {xmlId}.");
            //     return null;
            // }

            // return await GetEntityByIdAsync(model, irModelDatum.ResId, tenantId);
        }

        private async Task<object> GetEntityByIdAsync(string model, Guid? recordId, Guid? tenantId)
        {
            if (!recordId.HasValue)
            {
                Logger.LogWarning($"RecordId is null for model {model}.");
                return null;
            }

            var entityType = _modelTypeRegistry.GetType(ConvertModelToPascalCase(model));
            if (entityType == null)
            {
                Logger.LogWarning($"Entity type for model {model} not found in IModelTypeRegistry.");
                return null;
            }

            var serviceType = typeof(IRepositoryService<>).MakeGenericType(entityType);
            var service = _serviceProvider.GetService(serviceType);
            if (service == null)
            {
                Logger.LogError($"IEntityService<{entityType.Name}> not found in DI container.");
                return null;
            }

            try
            {
                var getMethod = serviceType.GetMethod("GetAsync");
                if (getMethod == null)
                {
                    Logger.LogError($"GetAsync method not found in IEntityService<{entityType.Name}>.");
                    return null;
                }
                return await (Task<object>)getMethod.Invoke(service, new object[] { recordId.Value, default(CancellationToken) });
            }
            catch (Exception ex)
            {
                Logger.LogError($"Failed to get entity {entityType.Name} with id {recordId}: {ex.Message}");
                return null;
            }
        }

        private string GetModelFromEntityType(Type entityType)
        {
            return entityType.Name.Replace("_", ".").ToLower();
        }

        private List<string> ParseEvalIds(string evalValue)
        {
            if (string.IsNullOrEmpty(evalValue))
            {
                return new List<string>();
            }

            var ids = new List<string>();
            var cleanedValue = evalValue.Trim('[', ']').Replace("'", "");
            var idArray = cleanedValue.Split(',').Select(id => id.Trim('(', ')').Trim()).Where(id => !string.IsNullOrEmpty(id));
            ids.AddRange(idArray);
            return ids;
        }

        private string ConvertModelToPascalCase(string odooModel)
        {
            if (string.IsNullOrEmpty(odooModel))
            {
                return odooModel;
            }

            var parts = odooModel.Split('.');
            var result = new StringBuilder();
            foreach (var part in parts)
            {
                if (string.IsNullOrEmpty(part))
                {
                    continue;
                }
                result.Append(char.ToUpper(part[0]) + part.Substring(1).ToLower());
            }
            return result.ToString();
        }

        private string ConvertFieldToPascalCase(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                return fieldName;
            }

            var parts = fieldName.Split('_');
            var result = new StringBuilder();
            foreach (var part in parts)
            {
                if (string.IsNullOrEmpty(part))
                {
                    continue;
                }
                result.Append(char.ToUpper(part[0]) + part.Substring(1).ToLower());
            }
            return result.ToString();
        }

        private static object ChangeTypeSafe(string value, Type targetType)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                if (Nullable.GetUnderlyingType(targetType) != null || !targetType.IsValueType)
                    return null;
            }

            var underlyingType = Nullable.GetUnderlyingType(targetType) ?? targetType;

            if (underlyingType.IsEnum)
                return Enum.Parse(underlyingType, value, ignoreCase: true);

            if (underlyingType == typeof(Guid))
                return Guid.Parse(value);

            if (underlyingType == typeof(bool))
                return value == "1" || value.Equals("true", StringComparison.OrdinalIgnoreCase);

            if (underlyingType == typeof(DateTime))
                return DateTime.Parse(value, CultureInfo.InvariantCulture);

            if (underlyingType == typeof(int))
                return int.Parse(value, CultureInfo.InvariantCulture);

            if (underlyingType == typeof(decimal))
                return decimal.Parse(value, CultureInfo.InvariantCulture);

            if (underlyingType == typeof(double))
                return double.Parse(value, CultureInfo.InvariantCulture);

            return Convert.ChangeType(value, underlyingType, CultureInfo.InvariantCulture);
        }

        private class PendingRelation
        {
            public string Module { get; set; }
            public string Model { get; set; }
            public object Entity { get; set; }
            public string XmlId { get; set; }
            public bool IsNoUpdate { get; set; }
            public List<PendingRelationField> Fields { get; set; } = [];
            public bool IsResolved { get; set; } = false;
        }
        private class PendingRelationField
        {
            public PropertyInfo Property { get; set; }
            public string RefXmlId { get; set; }
            public XElement FieldElement { get; set; }
            public bool IsMany2Many { get; set; }
            public bool IsResolved { get; set; } = false;
        }
    }

}