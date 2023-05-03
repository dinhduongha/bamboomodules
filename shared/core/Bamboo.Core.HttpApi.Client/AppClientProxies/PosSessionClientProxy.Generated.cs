
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
[ExposeServices(typeof(IPosSessionAppService), typeof(PosSessionClientProxy))]
public partial class PosSessionClientProxy : ClientProxyBase<IPosSessionAppService>, IPosSessionAppService
{
    //public virtual async Task<ListResultDto<PosSession>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<PosSession>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<PosSession>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<PosSession>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<PosSession> GetAsync(Guid id)
    {
        return await RequestAsync<PosSession>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<PosSession> CreateAsync(PosSession input)
    {
        return await RequestAsync<PosSession>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PosSession), input }
        });
    }

    public virtual async Task<PosSession> UpdateAsync(Guid id, PosSession input)
    {
        return await RequestAsync<PosSession>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(PosSession), input }
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