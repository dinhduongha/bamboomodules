
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
[ExposeServices(typeof(IPosConfigAppService), typeof(PosConfigClientProxy))]
public partial class PosConfigClientProxy : ClientProxyBase<IPosConfigAppService>, IPosConfigAppService
{
    //public virtual async Task<ListResultDto<PosConfig>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<PosConfig>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<PosConfig>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<PosConfig>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<PosConfig> GetAsync(Guid id)
    {
        return await RequestAsync<PosConfig>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<PosConfig> CreateAsync(PosConfig input)
    {
        return await RequestAsync<PosConfig>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PosConfig), input }
        });
    }

    public virtual async Task<PosConfig> UpdateAsync(Guid id, PosConfig input)
    {
        return await RequestAsync<PosConfig>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(PosConfig), input }
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
