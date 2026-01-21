using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;

using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.DependencyInjection;

namespace Bamboo.Core.Application
{
    public interface IGenericModelService : ITransientDependency
    {
        Task<List<JsonElement>> ReadAsync(string modelName, List<Guid> ids, List<string>? fields = null);
        Task<List<Guid>> SearchAsync(string modelName, JsonElement? domain = null, long offset = 0, int limit = 100, string? order = null);
        Task<List<JsonElement>> SearchReadAsync(string modelName, JsonElement? domain = null, List<string>? fields = null, long offset = 0, int limit = 100, string order = null);
        Task<JsonElement> CreateAsync(string modelName, object entity, List<string> fields);
        Task<List<JsonElement>> WriteAsync(string modelName, List<Guid> ids, object entity, List<string> fields);
        Task DeleteAsync(string modelName, List<Guid> id);
        Task<JsonElement> NameCreateAsync(string modelName, string name);
        Task<List<(Guid Id, string Name)>> NameGetAsync(string modelName, List<Guid> ids);
        Task<List<(Guid Id, string Name)>> NameSearchAsync(string modelName, string name, JsonElement? domain = null, string @operator = "ilike", int limit = 100);
        Task<JsonElement> CopyAsync(string modelName, Guid id, List<string> fields, object defaultValues = null);
        Task<JsonElement> OnchangeAsync(string modelName, List<string> changedFields, object values, Dictionary<string, object> fieldInfo);
        Task<JsonElement> DefaultGetAsync(string modelName, List<string> fields);
        Task<Dictionary<string, Dictionary<string, object>>> FieldsGetAsync(string modelName, List<string> fields = null, Dictionary<string, List<string>> attributes = null);
        Task<object> CallServiceAsync(string modelName, string methodName, params object[] args);
    }

}