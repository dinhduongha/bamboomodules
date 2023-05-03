
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
[ExposeServices(typeof(ILunchAlertAppService), typeof(LunchAlertClientProxy))]
public partial class LunchAlertClientProxy : ClientProxyBase<ILunchAlertAppService>, ILunchAlertAppService
{
    //public virtual async Task<ListResultDto<LunchAlert>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<LunchAlert>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<LunchAlert>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<LunchAlert>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<LunchAlert> GetAsync(Guid id)
    {
        return await RequestAsync<LunchAlert>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<LunchAlert> CreateAsync(LunchAlert input)
    {
        return await RequestAsync<LunchAlert>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(LunchAlert), input }
        });
    }

    public virtual async Task<LunchAlert> UpdateAsync(Guid id, LunchAlert input)
    {
        return await RequestAsync<LunchAlert>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(LunchAlert), input }
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
