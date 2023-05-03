
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
[ExposeServices(typeof(IPosOrderAppService), typeof(PosOrderClientProxy))]
public partial class PosOrderClientProxy : ClientProxyBase<IPosOrderAppService>, IPosOrderAppService
{
    //public virtual async Task<ListResultDto<PosOrder>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<PosOrder>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<PosOrder>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<PosOrder>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<PosOrder> GetAsync(Guid id)
    {
        return await RequestAsync<PosOrder>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<PosOrder> CreateAsync(PosOrder input)
    {
        return await RequestAsync<PosOrder>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PosOrder), input }
        });
    }

    public virtual async Task<PosOrder> UpdateAsync(Guid id, PosOrder input)
    {
        return await RequestAsync<PosOrder>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(PosOrder), input }
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