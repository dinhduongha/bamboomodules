
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
[ExposeServices(typeof(IPurchaseOrderLineAppService), typeof(PurchaseOrderLineClientProxy))]
public partial class PurchaseOrderLineClientProxy : ClientProxyBase<IPurchaseOrderLineAppService>, IPurchaseOrderLineAppService
{
    //public virtual async Task<ListResultDto<PurchaseOrderLine>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<PurchaseOrderLine>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<PurchaseOrderLine>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<PurchaseOrderLine>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<PurchaseOrderLine> GetAsync(Guid id)
    {
        return await RequestAsync<PurchaseOrderLine>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<PurchaseOrderLine> CreateAsync(PurchaseOrderLine input)
    {
        return await RequestAsync<PurchaseOrderLine>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PurchaseOrderLine), input }
        });
    }

    public virtual async Task<PurchaseOrderLine> UpdateAsync(Guid id, PurchaseOrderLine input)
    {
        return await RequestAsync<PurchaseOrderLine>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(PurchaseOrderLine), input }
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
