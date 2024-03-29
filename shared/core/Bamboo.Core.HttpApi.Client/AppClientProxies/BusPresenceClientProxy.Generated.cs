
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
[ExposeServices(typeof(IBusPresenceAppService), typeof(BusPresenceClientProxy))]
public partial class BusPresenceClientProxy : ClientProxyBase<IBusPresenceAppService>, IBusPresenceAppService
{
    //public virtual async Task<ListResultDto<BusPresence>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<BusPresence>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<BusPresence>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<BusPresence>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<BusPresence> GetAsync(long id)
    {
        return await RequestAsync<BusPresence>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id }
        });
    }

    public virtual async Task<BusPresence> CreateAsync(BusPresence input)
    {
        return await RequestAsync<BusPresence>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(BusPresence), input }
        });
    }

    public virtual async Task<BusPresence> UpdateAsync(long id, BusPresence input)
    {
        return await RequestAsync<BusPresence>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id },
            { typeof(BusPresence), input }
        });
    }

    public virtual async Task DeleteAsync(long id)
    {
        await RequestAsync(nameof(DeleteAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id }
        });
    }
}
