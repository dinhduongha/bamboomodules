using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;

using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.DependencyInjection;

using Bamboo.Core.Application.Dtos;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application
{
    public interface IRpcDispatcherAppService : ITransientDependency
    {
        Task<List<JsonElement>> ReadAsync(string modelName, ReadRequestDto input);
        Task<List<Guid>> SearchAsync(string modelName, SearchRequestDto input);
        Task<List<JsonElement>> SearchReadAsync(string modelName, SearchReadRequestDto input);
        Task<object> SearchCountAsync(string modelName, SearchCountRequestDto input);
        Task<JsonElement> CreateAsync(string modelName, CreateRequestDto input);
        Task<List<JsonElement>> WriteAsync(string modelName, UpdateRequestDto input);
        Task<List<JsonElement>> UpdateJsonAsync(string modelName, UpdateJsonRequestDto input);
        Task DeleteAsync(string modelName, List<Guid> ids);

        Task<JsonElement> CopyAsync(string modelName, CopyRequestDto input);
        Task<JsonElement> DefaultGetAsync(string modelName, DefaultGetRequestDto input);

        Task<JsonElement> NameCreateAsync(string modelName, NameCreateRequestDto input);
        Task<List<(Guid Id, string Name)>> NameGetAsync(string modelName, NameGetRequestDto input);
        Task<List<(Guid Id, string Name)>> NameSearchAsync(string modelName, NameSearchRequestDto input);

        Task<JsonElement> OnChangeAsync(string modelName, OnChangeRequestDto input);
        Task<Dictionary<string, Dictionary<string, object>>> FieldsGetAsync(string modelName, FieldsGetRequestDto input);
        Task<object> CallServiceAsync(string modelName, string methodName, params object[] args);
    }

}