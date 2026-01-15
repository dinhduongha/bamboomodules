using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.Application
{
    public class GenericModelService : IGenericModelService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IModelTypeRegistry _modelTypeRegistry;

        private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };

        public GenericModelService(
            IServiceProvider serviceProvider,
            IModelTypeRegistry modelTypeRegistry)
        {
            _serviceProvider = serviceProvider;
            _modelTypeRegistry = modelTypeRegistry;
        }

        public async Task<List<JsonElement>> ReadAsync(string modelName, List<Guid> ids, List<string> fields)
        {
            var service = GetGenericService(modelName);
            var results = await CallServiceMethodAsync<List<object>>(service, "ReadAsync", ids, fields);
            List<JsonElement> jsonElementList = results
                .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions))
                .ToList();
            return jsonElementList;
        }

        public async Task<List<Guid>> SearchAsync(string modelName, string domain, long offset = 0, int limit = 100, string order = null)
        {
            var service = GetGenericService(modelName);
            return await CallServiceMethodAsync<List<Guid>>(service, "SearchAsync", domain, offset, limit, order);
        }

        public async Task<List<JsonElement>> SearchReadAsync(string modelName, string domain, List<string> fields, long offset = 0, int limit = 100, string order = null)
        {
            var service = GetGenericService(modelName);
            var results = await CallServiceMethodAsync<List<object>>(service, "SearchReadAsync", domain, fields ?? [], offset, limit, order);
            List<JsonElement> jsonElementList = results
                .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions))
                .ToList();
            return jsonElementList;
        }

        public async Task<JsonElement> CreateAsync(string modelName, object entity, List<string> fields)
        {
            var service = GetGenericService(modelName);
            var entityType = _modelTypeRegistry.GetType(modelName);
            var jsonElement = (entity is JsonElement element)
                ? element
                : JsonSerializer.SerializeToElement(entity);
            var typedEntity = JsonSerializer.Deserialize(jsonElement, entityType);
            var result = await CallServiceMethodAsync<object>(service, "CreateAsync", typedEntity, fields);
            return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
        }

        public async Task<List<JsonElement>> WriteAsync(string modelName, List<Guid> ids, object entity, List<string> fields)
        {
            var service = GetGenericService(modelName);
            var entityType = _modelTypeRegistry.GetType(modelName);
            var jsonElement = (entity is JsonElement element)
    ? element
    : JsonSerializer.SerializeToElement(entity);
            var typedEntity = JsonSerializer.Deserialize(jsonElement, entityType);
            var results = await CallServiceMethodAsync<List<object>>(service, "WriteAsync", ids, typedEntity, fields);
            List<JsonElement> jsonElementList = results
                .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions))
                .ToList();
            return jsonElementList;
        }

        public async Task DeleteAsync(string modelName, List<Guid> ids)
        {
            var service = GetGenericService(modelName);
            await CallServiceMethodAsync<object>(service, "DeleteAsync", ids);
        }

        public async Task<JsonElement> NameCreateAsync(string modelName, string name)
        {
            var service = GetGenericService(modelName);
            var result = await CallServiceMethodAsync<object>(service, "NameCreateAsync", modelName, name);
            return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
        }

        public async Task<List<(Guid Id, string Name)>> NameGetAsync(string modelName, List<Guid> ids)
        {
            var service = GetGenericService(modelName);
            return await CallServiceMethodAsync<List<(Guid Id, string Name)>>(service, "NameGetAsync", ids);
        }

        public async Task<List<(Guid Id, string Name)>> NameSearchAsync(string modelName, string name, string domain = null, string @operator = "ilike", int limit = 100)
        {
            var service = GetGenericService(modelName);
            return await CallServiceMethodAsync<List<(Guid Id, string Name)>>(service, "NameSearchAsync", name, domain, @operator, limit);
        }

        public async Task<JsonElement> CopyAsync(string modelName, Guid id, List<string> fields, object defaultValues = null)
        {
            var service = GetGenericService(modelName);
            var entityType = _modelTypeRegistry.GetType(modelName);
            var typedDefaultValues = defaultValues != null ? Convert.ChangeType(defaultValues, entityType) : null;
            var result = await CallServiceMethodAsync<object>(service, "CopyAsync", id, fields, typedDefaultValues);
            return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
        }

        public async Task<JsonElement> OnchangeAsync(string modelName, List<string> changedFields, object values, Dictionary<string, object> fieldInfo)
        {
            var service = GetGenericService(modelName);
            var entityType = _modelTypeRegistry.GetType(modelName);
            var typedValues = Convert.ChangeType(values, entityType);
            return await CallServiceMethodAsync<JsonElement>(service, "OnchangeAsync", changedFields, typedValues, fieldInfo);
        }

        public async Task<JsonElement> DefaultGetAsync(string modelName, List<string> fields)
        {
            var service = GetGenericService(modelName);
            var result = await CallServiceMethodAsync<Dictionary<string, object>>(service, "DefaultGetAsync", fields);
            return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
        }

        public async Task<Dictionary<string, Dictionary<string, object>>> FieldsGetAsync(string modelName, List<string> fields = null, Dictionary<string, List<string>> attributes = null)
        {
            var service = GetGenericService(modelName);
            return await CallServiceMethodAsync<Dictionary<string, Dictionary<string, object>>>(service, "FieldsGetAsync", fields, attributes);
        }

        public async Task<object> CallServiceAsync(string modelName, string methodName, params object[] args)
        {
            var service = GetGenericService(modelName);
            return await CallServiceMethodAsync<object>(service, methodName, args);
        }

        private object GetGenericService(string modelName)
        {
            var entityType = _modelTypeRegistry.GetType(modelName);
            var serviceType = _modelTypeRegistry.GetServiceInterfaceType(modelName);
            if (serviceType == null)
            {
                serviceType = typeof(IGenericApplicationService<>).MakeGenericType(entityType);
            }
            return _serviceProvider.GetService(serviceType)
                ?? throw new UserFriendlyException($"Service for {modelName} not found");
        }

        private async Task<TResult> CallServiceMethodAsync<TResult>(object service, string methodName, params object[] args)
        {
            var method = service.GetType().GetMethod(methodName, System.Reflection.BindingFlags.Public);
            if (method == null)
                throw new UserFriendlyException($"Method {methodName} not found");

            var result = method.Invoke(service, args);
            if (result is Task<TResult> task)
                return await task;
            return (TResult)result;
        }
    }
}