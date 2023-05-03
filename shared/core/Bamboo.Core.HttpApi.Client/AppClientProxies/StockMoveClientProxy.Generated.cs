
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
[ExposeServices(typeof(IStockMoveAppService), typeof(StockMoveClientProxy))]
public partial class StockMoveClientProxy : ClientProxyBase<IStockMoveAppService>, IStockMoveAppService
{
    //public virtual async Task<ListResultDto<StockMove>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<StockMove>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<StockMove>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<StockMove>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<StockMove> GetAsync(Guid id)
    {
        return await RequestAsync<StockMove>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<StockMove> CreateAsync(StockMove input)
    {
        return await RequestAsync<StockMove>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(StockMove), input }
        });
    }

    public virtual async Task<StockMove> UpdateAsync(Guid id, StockMove input)
    {
        return await RequestAsync<StockMove>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(StockMove), input }
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
