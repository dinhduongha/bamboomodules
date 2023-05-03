
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
[ExposeServices(typeof(IStockWarnInsufficientQtyUnbuildAppService), typeof(StockWarnInsufficientQtyUnbuildClientProxy))]
public partial class StockWarnInsufficientQtyUnbuildClientProxy : ClientProxyBase<IStockWarnInsufficientQtyUnbuildAppService>, IStockWarnInsufficientQtyUnbuildAppService
{
    //public virtual async Task<ListResultDto<StockWarnInsufficientQtyUnbuild>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<StockWarnInsufficientQtyUnbuild>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<StockWarnInsufficientQtyUnbuild>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<StockWarnInsufficientQtyUnbuild>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<StockWarnInsufficientQtyUnbuild> GetAsync(Guid id)
    {
        return await RequestAsync<StockWarnInsufficientQtyUnbuild>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<StockWarnInsufficientQtyUnbuild> CreateAsync(StockWarnInsufficientQtyUnbuild input)
    {
        return await RequestAsync<StockWarnInsufficientQtyUnbuild>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(StockWarnInsufficientQtyUnbuild), input }
        });
    }

    public virtual async Task<StockWarnInsufficientQtyUnbuild> UpdateAsync(Guid id, StockWarnInsufficientQtyUnbuild input)
    {
        return await RequestAsync<StockWarnInsufficientQtyUnbuild>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(StockWarnInsufficientQtyUnbuild), input }
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
