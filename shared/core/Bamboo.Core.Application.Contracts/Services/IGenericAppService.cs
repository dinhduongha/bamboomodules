using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

using Bamboo.Core.Application.Dtos;
using Bamboo.Core.Application.Contracts.DTOs;


//namespace Bamboo.Core.Application
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IGenericAppService<TEntity> : ICrudAppService<TEntity, Guid>
        where TEntity : class, IEntity<Guid>
    {
        Task<List<object>> ReadAsync(ReadRequestDto input);
        Task<List<Guid>> SearchAsync(SearchRequestDto input);
        Task<List<object>> SearchReadAsync(SearchReadRequestDto input);
        Task<long> SearchCountAsync(SearchCountRequestDto input);

        // Task<TEntity> CreateAsync(TEntity entity, List<string> fields);
        // Task<List<object>> WriteAsync(List<Guid> ids, TEntity entity, List<string> fields);
        // Task DeleteAsync(List<Guid> ids);
        // Task<object> UnlinkAsync(List<Guid> ids);
        // Task<TEntity> CopyAsync(Guid[] ids, List<string> fields, TEntity defaultValues = null);
        //Task<object> UpdateJsonAsync(List<Guid> ids, string jsonField, Dictionary<string, object> jsonValue, string action = "update");

        Task<TEntity> CreateAsync(CreateRequestDto<TEntity> input);
        Task<TEntity> CopyAsync(CopyRequestDto<TEntity> input);
        Task<List<object>> WriteAsync(UpdateRequestDto<TEntity> input);

        Task<object> UpdateJsonAsync(UpdateJsonRequestDto input);

        Task<object> UnlinkAsync(List<Guid> ids);
        Task DeleteAsync(List<Guid> ids);

        Task<TEntity> DefaultGetAsync(DefaultGetRequestDto input);
        Task<Dictionary<string, Dictionary<string, object>>> FieldsGetAsync(FieldsGetRequestDto input);
        Task<List<(Guid Id, string Name)>> NameGetAsync(NameGetRequestDto input);
        Task<List<(Guid Id, string Name)>> NameSearchAsync(NameSearchRequestDto input);
        Task<TEntity> NameCreateAsync(NameCreateRequestDto input);
        //Task<Dictionary<string, object>> DefaultGetAsync(List<string> fields);

        Task<object> OnChangeAsync(OnChangeRequestDto<TEntity> input);
        //Task<object> OnDeleteAsync(object values, object field_names, object fields_spec);

        // Security / Access
        // check_access_rights
        // check_access_rule

        // Environment / Context
        // sudo with_context with_company with_user
        // mapped / filtered / sorted
    }

    public class OnchangeResult
    {
        public Dictionary<string, object> Value { get; set; }
        public Dictionary<string, string> Warning { get; set; }
    }

}