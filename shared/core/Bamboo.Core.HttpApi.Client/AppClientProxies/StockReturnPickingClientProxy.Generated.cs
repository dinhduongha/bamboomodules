
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
[ExposeServices(typeof(IStockReturnPickingAppService), typeof(StockReturnPickingClientProxy))]
public partial class StockReturnPickingClientProxy : ClientProxyBase<IStockReturnPickingAppService>, IStockReturnPickingAppService
{
    //public virtual async Task<ListResultDto<StockReturnPicking>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<StockReturnPicking>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<StockReturnPicking>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<StockReturnPicking>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<StockReturnPicking> GetAsync(Guid id)
    {
        return await RequestAsync<StockReturnPicking>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<StockReturnPicking> CreateAsync(StockReturnPicking input)
    {
        return await RequestAsync<StockReturnPicking>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(StockReturnPicking), input }
        });
    }

    public virtual async Task<StockReturnPicking> UpdateAsync(Guid id, StockReturnPicking input)
    {
        return await RequestAsync<StockReturnPicking>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(StockReturnPicking), input }
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
