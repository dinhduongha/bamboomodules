
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
[ExposeServices(typeof(IStockImmediateTransferLineAppService), typeof(StockImmediateTransferLineClientProxy))]
public partial class StockImmediateTransferLineClientProxy : ClientProxyBase<IStockImmediateTransferLineAppService>, IStockImmediateTransferLineAppService
{
    //public virtual async Task<ListResultDto<StockImmediateTransferLine>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<StockImmediateTransferLine>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<StockImmediateTransferLine>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<StockImmediateTransferLine>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<StockImmediateTransferLine> GetAsync(Guid id)
    {
        return await RequestAsync<StockImmediateTransferLine>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<StockImmediateTransferLine> CreateAsync(StockImmediateTransferLine input)
    {
        return await RequestAsync<StockImmediateTransferLine>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(StockImmediateTransferLine), input }
        });
    }

    public virtual async Task<StockImmediateTransferLine> UpdateAsync(Guid id, StockImmediateTransferLine input)
    {
        return await RequestAsync<StockImmediateTransferLine>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(StockImmediateTransferLine), input }
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