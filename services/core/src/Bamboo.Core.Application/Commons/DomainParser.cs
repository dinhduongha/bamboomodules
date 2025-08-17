using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Memory;

using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;
using Volo.Abp.Users;

using Bamboo.Core.Models;

namespace Bamboo.Core.Application.Services.Commons
{
    public class DomainParser : ITransientDependency
    {
        private readonly ICurrentUser _currentUser;
        private readonly ICurrentTenant _currentTenant;
        private readonly IRepository<ResUsers, Guid> _resUserRepository;
        private readonly IRepository<ResGroups, Guid> _resGroupRepository;
        private readonly IRepository<IrModel, Guid> _modelRepository;
        private readonly IRepository<IrModelFields, Guid> _fieldRepository;
        private readonly IMemoryCache _memoryCache;

        private readonly IModelTypeRegistry _modelTypeRegistry;

        public DomainParser(
            ICurrentUser currentUser,
            ICurrentTenant currentTenant,
            IRepository<ResUsers, Guid> resUserRepository,
            IRepository<ResGroups, Guid> resGroupRepository,
            IRepository<IrModel, Guid> modelRepository,
            IRepository<IrModelFields, Guid> fieldRepository,
            IMemoryCache memoryCache,
            IModelTypeRegistry modelTypeRegistry)
        {
            _currentUser = currentUser;
            _currentTenant = currentTenant;
            _resUserRepository = resUserRepository;
            _resGroupRepository = resGroupRepository;
            _modelRepository = modelRepository;
            _fieldRepository = fieldRepository;
            _memoryCache = memoryCache;
            _modelTypeRegistry = modelTypeRegistry;
        }

        public IQueryable<TEntity> ApplyDomain<TEntity>(IQueryable<TEntity> query, string domainJson)
            where TEntity : class, IEntity<Guid>
        {
            if (string.IsNullOrEmpty(domainJson))
                return query;
            return query;
            var domain = JsonSerializer.Deserialize<List<object>>(domainJson, new JsonSerializerOptions
            {
                Converters = { new ObjectToInferredTypeConverter() }
            });
            //var jsonFields = GetJsonFields<TEntity>();
            var jsonFields = GetJsonFieldsAsync<TEntity>().Result;
            var relationFields = GetRelationFields<TEntity>();
            var (predicate, parameters) = ParseDomain(domain, jsonFields, relationFields);
            return query.Where(predicate, parameters.ToArray());
        }

        private List<string> GetJsonFields<TEntity>()
        {
            return typeof(TEntity)
                .GetProperties()
                .Where(p => p.GetCustomAttribute<JsonbFieldAttribute>() != null)
                .Select(p => p.Name)
                .ToList();
        }
        private async Task<List<string>> GetJsonFieldsAsync<TEntity>()
        {
            var modelName = typeof(TEntity).Name;
            var cacheKey = $"JsonFields_{modelName}";
            if (!_memoryCache.TryGetValue(cacheKey, out List<string> jsonFields))
            {
                // Ưu tiên ir_model_fields
                var model = (await _modelRepository.GetQueryableAsync())
                    .Where(m => m.Model == modelName)
                    .FirstOrDefault();
                if (model != null)
                {
                    jsonFields = (await _fieldRepository.GetQueryableAsync())
                        .Where(f => f.ModelId == model.Id && f.Ttype == "jsonb")
                        .Select(f => f.Name)
                        .ToList();
                }
                else
                {
                    jsonFields = new List<string>();
                }

                // Fallback: Kiểm tra JsonbFieldAttribute nếu không tìm thấy trong ir_model_fields
                if (!jsonFields.Any())
                {
                    jsonFields = typeof(TEntity)
                        .GetProperties()
                        .Where(p => p.GetCustomAttribute<JsonbFieldAttribute>() != null)
                        .Select(p => p.Name)
                        .ToList();
                }

                _memoryCache.Set(cacheKey, jsonFields, TimeSpan.FromHours(1));
            }
            return jsonFields;
        }

        private Dictionary<string, string> GetRelationFields<TEntity>()
        {
            var relationFields = new Dictionary<string, string>();
            foreach (var prop in typeof(TEntity).GetProperties())
            {
                var attr = prop.GetCustomAttribute<RelationFieldAttribute>();
                if (attr != null)
                    relationFields[prop.Name] = attr.Model;
            }
            return relationFields;
        }

        private (string Predicate, List<object> Parameters) ParseDomain(List<object> domain, List<string> jsonFields, Dictionary<string, string> relationFields)
        {
            var expressions = new List<string>();
            var stack = new Stack<string>();
            var parameters = new List<object>();
            var paramIndex = 0;

            foreach (var item in domain)
            {
                if (item is string operatorToken)
                {
                    if (operatorToken == "&" || operatorToken == "|")
                        stack.Push(operatorToken);
                    else if (operatorToken == "!")
                    {
                        var lastExpression = expressions.LastOrDefault();
                        if (!string.IsNullOrEmpty(lastExpression))
                        {
                            expressions.RemoveAt(expressions.Count - 1);
                            expressions.Add($"!({lastExpression})");
                        }
                    }
                }
                else if (item is List<object> condition)
                {
                    var conditionExpression = ParseCondition(condition, jsonFields, relationFields, parameters, ref paramIndex);
                    expressions.Add(conditionExpression);
                }
            }

            return (CombineExpressions(expressions, stack), parameters);
        }

        private string ParseCondition(List<object> condition, List<string> jsonFields, Dictionary<string, string> relationFields, List<object> parameters, ref int paramIndex)
        {
            if (condition.Count != 3)
                throw new UserFriendlyException("Invalid domain condition format.");

            var field = condition[0].ToString();
            var op = condition[1].ToString();
            var value = ResolveValue(condition[2]);

            bool isJsonField = jsonFields.Any(f => field.StartsWith($"{f}."));
            if (isJsonField)
            {
                var parts = field.Split('.');
                if (parts.Length < 2)
                    throw new UserFriendlyException($"Invalid JSON field format: {field}");

                var jsonFieldName = parts[0];
                var jsonPath = string.Join(".", parts.Skip(1));
                return ParseJsonCondition(jsonFieldName, jsonPath, op, value, parameters, ref paramIndex);
            }

            bool isRelationField = relationFields.ContainsKey(field);
            if (isRelationField)
            {
                return ParseRelationCondition(field, op, value, relationFields[field], parameters, ref paramIndex);
            }

            parameters.Add(value);
            switch (op)
            {
                case "=": return $"{field} == @{paramIndex++}";
                case "!=": return $"{field} != @{paramIndex++}";
                case "in": return $"@{paramIndex++}.Contains({field})";
                case "not in": return $"!@{paramIndex++}.Contains({field})";
                case "<": return $"{field} < @{paramIndex++}";
                case ">": return $"{field} > @{paramIndex++}";
                case "<=": return $"{field} <= @{paramIndex++}";
                case ">=": return $"{field} >= @{paramIndex++}";
                case "like": return $"{field}.Contains(@{paramIndex++})";
                case "ilike": return $"{field}.ToLower().Contains(@{paramIndex++}.ToLower())";
                default: throw new UserFriendlyException($"Unsupported operator: {op}");
            }
        }

        private string ParseJsonCondition(string jsonFieldName, string jsonPath, string op, object value, List<object> parameters, ref int paramIndex)
        {
            parameters.Add(value);
            switch (op)
            {
                case "=": return $"{jsonFieldName}[\"{jsonPath}\"] == @{paramIndex++}";
                case "!=": return $"{jsonFieldName}[\"{jsonPath}\"] != @{paramIndex++}";
                case "in": return $"@{paramIndex++}.Contains({jsonFieldName}[\"{jsonPath}\"])";
                case "not in": return $"!@{paramIndex++}.Contains({jsonFieldName}[\"{jsonPath}\"])";
                case "like": return $"{jsonFieldName}[\"{jsonPath}\"].Contains(@{paramIndex++})";
                case "ilike": return $"{jsonFieldName}[\"{jsonPath}\"].ToLower().Contains(@{paramIndex++}.ToLower())";
                case "@>": return $"{jsonFieldName}.Contains(@{paramIndex++})";
                case "?": return $"{jsonFieldName}.ContainsKey(@{paramIndex++})";
                default: throw new UserFriendlyException($"Unsupported operator for JSON field: {op}");
            }
        }

        private string ParseRelationCondition(string field, string op, object value, string relatedModel, List<object> parameters, ref int paramIndex)
        {
            if (op == "=" || op == "!=")
            {
                if (value is List<object> relValue && relValue.Count == 2 && relValue[0].ToString() == relatedModel)
                {
                    parameters.Add(Guid.Parse(relValue[1].ToString()));
                    return op == "=" ? $"{field} == @{paramIndex++}" : $"{field} != @{paramIndex++}";
                }
            }
            else if (op == "in" || op == "not in")
            {
                if (value is List<object> ids)
                {
                    parameters.Add(ids.Select(id => Guid.Parse(id.ToString())).ToList());
                    return op == "in" ? $"@{paramIndex++}.Contains({field})" : $"!@{paramIndex++}.Contains({field})";
                }
            }
            throw new UserFriendlyException($"Unsupported operator for relation field: {op}");
        }

        private object ResolveValue(object value)
        {
            if (value is string stringValue)
            {
                if (stringValue == "user.id")
                    return _currentUser.Id;
                if (stringValue == "company_id")
                    return _currentTenant.Id;
            }
            else if (value is List<object> listValue)
            {
                return listValue.Select(v => ResolveValue(v)).ToList();
            }
            return value;
        }

        private string CombineExpressions(List<string> expressions, Stack<string> operators)
        {
            if (!expressions.Any())
                return "true";

            var result = expressions[0];
            for (int i = 1; i < expressions.Count; i++)
            {
                var op = operators.Any() ? operators.Pop() : "&";
                result = $"({result}) {op} ({expressions[i]})";
            }
            return result;
        }
    }

    // public class ObjectToInferredTypeConverter : JsonConverter<object>
    // {
    //     public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //     {
    //         switch (reader.TokenType)
    //         {
    //             case JsonTokenType.True:
    //                 return true;
    //             case JsonTokenType.False:
    //                 return false;
    //             case JsonTokenType.Number:
    //                 if (reader.TryGetInt64(out long l))
    //                     return l;
    //                 return reader.GetDouble();
    //             case JsonTokenType.String:
    //                 return reader.GetString();
    //             case JsonTokenType.StartArray:
    //                 return JsonSerializer.Deserialize<List<object>>(ref reader, options);
    //             case JsonTokenType.StartObject:
    //                 return JsonSerializer.Deserialize<Dictionary<string, object>>(ref reader, options);
    //             default:
    //                 return null;
    //         }
    //     }

    //     public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    //     {
    //         JsonSerializer.Serialize(writer, value, value?.GetType() ?? typeof(object), options);
    //     }
    // }

    [AttributeUsage(AttributeTargets.Property)]
    public class JsonbFieldAttribute : Attribute { }

    // [AttributeUsage(AttributeTargets.Property)]
    // public class RelationFieldAttribute : Attribute
    // {
    //     public string RelatedModel { get; }
    //     public string RelationType { get; }

    //     public RelationFieldAttribute(string relatedModel, string relationType)
    //     {
    //         RelatedModel = relatedModel;
    //         RelationType = relationType;
    //     }
    // }
}
/* OLD
namespace Bamboo.Core.Application
{
    public class OdooDomainParser : ITransientDependency
    {
        private readonly ICurrentUser _currentUser;
        private readonly ICurrentTenant _currentTenant;
        private readonly IRepository<ResUser, Guid> _resUserRepository;
        private readonly IRepository<ResGroup, Guid> _resGroupRepository;
        private readonly IModelTypeRegistry _modelTypeRegistry;

        public OdooDomainParser(
            ICurrentUser currentUser,
            ICurrentTenant currentTenant,
            IRepository<ResUser, Guid> resUserRepository,
            IRepository<ResGroup, Guid> resGroupRepository,
            IModelTypeRegistry modelTypeRegistry)
        {
            _currentUser = currentUser;
            _currentTenant = currentTenant;
            _resUserRepository = resUserRepository;
            _resGroupRepository = resGroupRepository;
            _modelTypeRegistry = modelTypeRegistry;
        }

        public IQueryable<TEntity> ApplyDomain<TEntity>(IQueryable<TEntity> query, string domainJson)
        {
            if (string.IsNullOrEmpty(domainJson))
                return query;

            var domain = JsonSerializer.Deserialize<List<object>>(domainJson, new JsonSerializerOptions
            {
                Converters = { new ObjectToInferredTypeConverter() }
            });
            var jsonFields = GetJsonFields<TEntity>();
            var relationFields = GetRelationFields<TEntity>();
            var predicate = ParseDomain(domain, jsonFields, relationFields);
            return query.Where(predicate);
        }

        private List<string> GetJsonFields<TEntity>()
        {
            return typeof(TEntity)
                .GetProperties()
                .Where(p => p.GetCustomAttribute<JsonbFieldAttribute>() != null)
                .Select(p => p.Name)
                .ToList();
        }

        private Dictionary<string, string> GetRelationFields<TEntity>()
        {
            var relationFields = new Dictionary<string, string>();
            foreach (var prop in typeof(TEntity).GetProperties())
            {
                var attr = prop.GetCustomAttribute<RelationFieldAttribute>();
                if (attr != null)
                    relationFields[prop.Name] = attr.RelatedModel;
            }
            return relationFields;
        }

        private string ParseDomain(List<object> domain, List<string> jsonFields, Dictionary<string, string> relationFields)
        {
            var expressions = new List<string>();
            var stack = new Stack<string>();
            var parameters = new List<object>();
            var paramIndex = 0;

            foreach (var item in domain)
            {
                if (item is string operatorToken)
                {
                    if (operatorToken == "&" || operatorToken == "|")
                        stack.Push(operatorToken);
                    else if (operatorToken == "!")
                    {
                        var lastExpression = expressions.LastOrDefault();
                        if (!string.IsNullOrEmpty(lastExpression))
                        {
                            expressions.RemoveAt(expressions.Count - 1);
                            expressions.Add($"!({lastExpression})");
                        }
                    }
                }
                else if (item is List<object> condition)
                {
                    var conditionExpression = ParseCondition(condition, jsonFields, relationFields, parameters, ref paramIndex);
                    expressions.Add(conditionExpression);
                }
            }

            return CombineExpressions(expressions, stack, parameters);
        }

        private string ParseCondition(List<object> condition, List<string> jsonFields, Dictionary<string, string> relationFields, List<object> parameters, ref int paramIndex)
        {
            if (condition.Count != 3)
                throw new UserFriendlyException("Invalid domain condition format.");

            var field = condition[0].ToString();
            var op = condition[1].ToString();
            var value = ResolveValue(condition[2]);

            bool isJsonField = jsonFields.Any(f => field.StartsWith($"{f}."));
            if (isJsonField)
            {
                var parts = field.Split('.');
                if (parts.Length < 2)
                    throw new UserFriendlyException($"Invalid JSON field format: {field}");

                var jsonFieldName = parts[0];
                var jsonPath = string.Join(".", parts.Skip(1));
                return ParseJsonCondition(jsonFieldName, jsonPath, op, value, parameters, ref paramIndex);
            }

            bool isRelationField = relationFields.ContainsKey(field);
            if (isRelationField)
            {
                return ParseRelationCondition(field, op, value, relationFields[field], parameters, ref paramIndex);
            }

            parameters.Add(value);
            switch (op)
            {
                case "=": return $"{field} == @{paramIndex++}";
                case "!=": return $"{field} != @{paramIndex++}";
                case "in": return $"@{paramIndex++}.Contains({field})";
                case "not in": return $"!@{paramIndex++}.Contains({field})";
                case "<": return $"{field} < @{paramIndex++}";
                case ">": return $"{field} > @{paramIndex++}";
                case "<=": return $"{field} <= @{paramIndex++}";
                case ">=": return $"{field} >= @{paramIndex++}";
                case "like": return $"{field}.Contains(@{paramIndex++})";
                case "ilike": return $"{field}.ToLower().Contains(@{paramIndex++}.ToLower())";
                default: throw new UserFriendlyException($"Unsupported operator: {op}");
            }
        }

        private string ParseJsonCondition(string jsonFieldName, string jsonPath, string op, object value, List<object> parameters, ref int paramIndex)
        {
            parameters.Add(jsonPath);
            parameters.Add(value.ToString());
            switch (op)
            {
                case "=": return $"{jsonFieldName} ->> @{paramIndex++} = @{paramIndex++}";
                case "!=": return $"{jsonFieldName} ->> @{paramIndex++} != @{paramIndex++}";
                case "in": return $"{jsonFieldName} ->> @{paramIndex++} = ANY(@{paramIndex++})";
                case "not in": return $"{jsonFieldName} ->> @{paramIndex++} != ANY(@{paramIndex++})";
                case "like": return $"{jsonFieldName} ->> @{paramIndex++} LIKE @{paramIndex++}";
                case "ilike": return $"{jsonFieldName} ->> @{paramIndex++} ILIKE @{paramIndex++}";
                case "@>": return $"{jsonFieldName} @> @{paramIndex++}::jsonb";
                case "?":
                    parameters.RemoveAt(parameters.Count - 1);
                    return $"{jsonFieldName} ? @{paramIndex++}";
                default: throw new UserFriendlyException($"Unsupported operator for JSON field: {op}");
            }
        }

        private string ParseRelationCondition(string field, string op, object value, string relatedModel, List<object> parameters, ref int paramIndex)
        {
            if (op == "=" || op == "!=")
            {
                if (value is List<object> relValue && relValue.Count == 2 && relValue[0].ToString() == relatedModel)
                {
                    parameters.Add(Guid.Parse(relValue[1].ToString()));
                    return op == "=" ? $"{field} == @{paramIndex++}" : $"{field} != @{paramIndex++}";
                }
            }
            else if (op == "in" || op == "not in")
            {
                if (value is List<object> ids)
                {
                    parameters.Add(ids.Select(id => Guid.Parse(id.ToString())).ToList());
                    return op == "in" ? $"@{paramIndex++}.Contains({field})" : $"!@{paramIndex++}.Contains({field})";
                }
            }
            throw new UserFriendlyException($"Unsupported operator for relation field: {op}");
        }

        private object ResolveValue(object value)
        {
            if (value is string stringValue)
            {
                if (stringValue == "user.id")
                    return _currentUser.Id;
                if (stringValue == "company_id")
                    return _currentTenant.Id;
            }
            else if (value is List<object> listValue)
            {
                return listValue.Select(v => ResolveValue(v)).ToList();
            }
            return value;
        }

        private string CombineExpressions(List<string> expressions, Stack<string> operators, List<object> parameters)
        {
            if (!expressions.Any())
                return "true";

            var result = expressions[0];
            for (int i = 1; i < expressions.Count; i++)
            {
                var op = operators.Any() ? operators.Pop() : "&";
                result = $"({result}) {op} ({expressions[i]})";
            }
            return result;
        }
    }


    [AttributeUsage(AttributeTargets.Property)]
    public class JsonbFieldAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property)]
    public class RelationFieldAttribute : Attribute
    {
        public string RelatedModel { get; }
        public string RelationType { get; } // "many2one", "one2many", "many2many"

        public RelationFieldAttribute(string relatedModel, string relationType)
        {
            RelatedModel = relatedModel;
            RelationType = relationType;
        }
    }
}
*/