using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.DependencyInjection;

namespace Bamboo.Core.Application
{
    public interface IGenericModelService : ITransientDependency
    {
        Task<List<object>> ReadAsync(string modelName, List<Guid> ids, List<string> fields = null);
        Task<List<Guid>> SearchAsync(string modelName, string domain, long offset = 0, int limit = 100, string order = null);
        Task<List<object>> SearchReadAsync(string modelName, string domain, List<string> fields, long offset = 0, int limit = 100, string order = null);
        Task<object> CreateAsync(string modelName, object entity, List<string> fields);
        Task<List<object>> WriteAsync(string modelName, List<Guid> ids, object entity, List<string> fields);
        Task DeleteAsync(string modelName, List<Guid> id);
        Task<List<(Guid Id, string Name)>> NameGetAsync(string modelName, List<Guid> ids);
        Task<List<(Guid Id, string Name)>> NameSearchAsync(string modelName, string name, string domain = null, string @operator = "ilike", int limit = 100);
        Task<object> CopyAsync(string modelName, Guid id, List<string> fields, object defaultValues = null);
        Task<OnchangeResult> OnchangeAsync(string modelName, List<string> changedFields, object values, Dictionary<string, object> fieldInfo);
        Task<Dictionary<string, object>> DefaultGetAsync(string modelName, List<string> fields);
        Task<Dictionary<string, Dictionary<string, object>>> FieldsGetAsync(string modelName, List<string> fields = null, Dictionary<string, List<string>> attributes = null);
    }

}