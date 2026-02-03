using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Bamboo.Core.Application
{
    public interface IGenericEntityAppService<TEntity> : IApplicationService where TEntity : class
    {
        Task<object> ReadAsync(Guid id);
        Task<List<object>> SearchAsync(string domain, int skipCount = 0, int maxResultCount = 10, string orderBy = null);
        Task<List<object>> SearchReadAsync(string domain, List<string> fields, int skipCount = 0, int maxResultCount = 10, string orderBy = null);
        Task<int> SearchCountAsync(string domain);

        Task<object> CreateAsync(TEntity input);
        Task<List<object>> UpdateAsync(List<Guid> ids, TEntity input);
        Task<object> UpdateJsonAsync(List<Guid> ids, string jsonField, Dictionary<string, object> jsonValue, string action = "update");
        Task DeleteAsync(List<Guid> ids);
        Task<object> CopyAsync(Guid id, object defaultValues = null);

        Task<List<object>> NameGetAsync(List<Guid> ids);
        Task<object> FieldsGetAsync();
        Task<object> DefaultGetAsync(List<string> fields);
        Task<List<object>> GetRelatedMany2ManyAsync(Guid id, string fieldName);
        Task UpdateRelatedMany2ManyAsync(Guid id, string fieldName, List<Guid> relatedIds);
    }
}