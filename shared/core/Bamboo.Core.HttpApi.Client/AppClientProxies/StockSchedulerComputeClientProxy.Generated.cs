
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
[ExposeServices(typeof(IStockSchedulerComputeAppService), typeof(StockSchedulerComputeClientProxy))]
public partial class StockSchedulerComputeClientProxy : ClientProxyBase<IStockSchedulerComputeAppService>, IStockSchedulerComputeAppService
{
    //public virtual async Task<ListResultDto<StockSchedulerCompute>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<StockSchedulerCompute>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<StockSchedulerCompute>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<StockSchedulerCompute>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<StockSchedulerCompute> GetAsync(Guid id)
    {
        return await RequestAsync<StockSchedulerCompute>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<StockSchedulerCompute> CreateAsync(StockSchedulerCompute input)
    {
        return await RequestAsync<StockSchedulerCompute>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(StockSchedulerCompute), input }
        });
    }

    public virtual async Task<StockSchedulerCompute> UpdateAsync(Guid id, StockSchedulerCompute input)
    {
        return await RequestAsync<StockSchedulerCompute>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(StockSchedulerCompute), input }
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