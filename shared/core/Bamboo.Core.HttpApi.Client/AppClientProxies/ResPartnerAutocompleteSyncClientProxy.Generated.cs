
// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client.ClientProxying;

using Bamboo.Core.Models;
using Bamboo.Core.Services;

// ReSharper disable once CheckNamespace
namespace Bamboo.Core.ClientProxies;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IResPartnerAutocompleteSyncAppService), typeof(ResPartnerAutocompleteSyncClientProxy))]
public partial class ResPartnerAutocompleteSyncClientProxy : ClientProxyBase<IResPartnerAutocompleteSyncAppService>, IResPartnerAutocompleteSyncAppService
{
    //public virtual async Task<ListResultDto<ResPartnerAutocompleteSync>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<ResPartnerAutocompleteSync>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<ResPartnerAutocompleteSync>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<ResPartnerAutocompleteSync>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<ResPartnerAutocompleteSync> GetAsync(Guid id)
    {
        return await RequestAsync<ResPartnerAutocompleteSync>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<ResPartnerAutocompleteSync> CreateAsync(ResPartnerAutocompleteSync input)
    {
        return await RequestAsync<ResPartnerAutocompleteSync>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(ResPartnerAutocompleteSync), input }
        });
    }

    public virtual async Task<ResPartnerAutocompleteSync> UpdateAsync(Guid id, ResPartnerAutocompleteSync input)
    {
        return await RequestAsync<ResPartnerAutocompleteSync>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(ResPartnerAutocompleteSync), input }
        });
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await RequestAsync(nameof(DeleteAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }
}