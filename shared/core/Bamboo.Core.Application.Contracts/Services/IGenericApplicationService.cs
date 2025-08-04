using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

//namespace Bamboo.Core.Application
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IGenericApplicationService<TEntity> : IApplicationService
        where TEntity : class, IEntity<Guid>
    {
        Task<List<object>> ReadAsync(List<Guid> ids, List<string> fields);
        Task<List<Guid>> SearchAsync(string domain, long offset, int limit, string order);
        Task<List<object>> SearchReadAsync(string domain, List<string> fields, long offset, int limit, string order);
        Task<object> CreateAsync(TEntity entity, List<string> fields);
        Task<List<object>> WriteAsync(List<Guid> ids, TEntity entity, List<string> fields);
        Task DeleteAsync(List<Guid> ids);
        Task<object> NameCreateAsync(string name);
        Task<List<(Guid Id, string Name)>> NameGetAsync(List<Guid> ids);
        Task<List<(Guid Id, string Name)>> NameSearchAsync(string name, string domain = null, string @operator = "ilike", int limit = 100);
        Task<object> CopyAsync(Guid id, List<string> fields, TEntity defaultValues = null);
        Task<Dictionary<string, object>> DefaultGetAsync(List<string> fields);
        Task<Dictionary<string, Dictionary<string, object>>> FieldsGetAsync(List<string> fields = null, Dictionary<string, List<string>> attributes = null);
        Task<OnchangeResult> OnchangeAsync(List<string> changedFields, TEntity values, Dictionary<string, object> fieldInfo);
    }
 
    public class OnchangeResult
    {
        public Dictionary<string, object> Value { get; set; }
        public Dictionary<string, string> Warning { get; set; }
    }

}