
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
[ExposeServices(typeof(IStockTraceabilityReportAppService), typeof(StockTraceabilityReportClientProxy))]
public partial class StockTraceabilityReportClientProxy : ClientProxyBase<IStockTraceabilityReportAppService>, IStockTraceabilityReportAppService
{
    //public virtual async Task<ListResultDto<StockTraceabilityReport>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<StockTraceabilityReport>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<StockTraceabilityReport>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<StockTraceabilityReport>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<StockTraceabilityReport> GetAsync(Guid id)
    {
        return await RequestAsync<StockTraceabilityReport>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<StockTraceabilityReport> CreateAsync(StockTraceabilityReport input)
    {
        return await RequestAsync<StockTraceabilityReport>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(StockTraceabilityReport), input }
        });
    }

    public virtual async Task<StockTraceabilityReport> UpdateAsync(Guid id, StockTraceabilityReport input)
    {
        return await RequestAsync<StockTraceabilityReport>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(StockTraceabilityReport), input }
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