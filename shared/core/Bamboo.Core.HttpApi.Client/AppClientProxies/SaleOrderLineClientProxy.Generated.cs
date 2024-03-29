
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
[ExposeServices(typeof(ISaleOrderLineAppService), typeof(SaleOrderLineClientProxy))]
public partial class SaleOrderLineClientProxy : ClientProxyBase<ISaleOrderLineAppService>, ISaleOrderLineAppService
{
    //public virtual async Task<ListResultDto<SaleOrderLine>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<SaleOrderLine>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<SaleOrderLine>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<SaleOrderLine>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<SaleOrderLine> GetAsync(Guid id)
    {
        return await RequestAsync<SaleOrderLine>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<SaleOrderLine> CreateAsync(SaleOrderLine input)
    {
        return await RequestAsync<SaleOrderLine>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(SaleOrderLine), input }
        });
    }

    public virtual async Task<SaleOrderLine> UpdateAsync(Guid id, SaleOrderLine input)
    {
        return await RequestAsync<SaleOrderLine>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(SaleOrderLine), input }
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
