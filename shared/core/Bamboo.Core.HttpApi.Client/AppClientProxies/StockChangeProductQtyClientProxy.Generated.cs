
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
[ExposeServices(typeof(IStockChangeProductQtyAppService), typeof(StockChangeProductQtyClientProxy))]
public partial class StockChangeProductQtyClientProxy : ClientProxyBase<IStockChangeProductQtyAppService>, IStockChangeProductQtyAppService
{
    //public virtual async Task<ListResultDto<StockChangeProductQty>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<StockChangeProductQty>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<StockChangeProductQty>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<StockChangeProductQty>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<StockChangeProductQty> GetAsync(Guid id)
    {
        return await RequestAsync<StockChangeProductQty>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<StockChangeProductQty> CreateAsync(StockChangeProductQty input)
    {
        return await RequestAsync<StockChangeProductQty>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(StockChangeProductQty), input }
        });
    }

    public virtual async Task<StockChangeProductQty> UpdateAsync(Guid id, StockChangeProductQty input)
    {
        return await RequestAsync<StockChangeProductQty>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(StockChangeProductQty), input }
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