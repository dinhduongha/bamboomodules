
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
[ExposeServices(typeof(IRepairOrderMakeInvoiceAppService), typeof(RepairOrderMakeInvoiceClientProxy))]
public partial class RepairOrderMakeInvoiceClientProxy : ClientProxyBase<IRepairOrderMakeInvoiceAppService>, IRepairOrderMakeInvoiceAppService
{
    //public virtual async Task<ListResultDto<RepairOrderMakeInvoice>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<RepairOrderMakeInvoice>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<RepairOrderMakeInvoice>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<RepairOrderMakeInvoice>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<RepairOrderMakeInvoice> GetAsync(Guid id)
    {
        return await RequestAsync<RepairOrderMakeInvoice>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<RepairOrderMakeInvoice> CreateAsync(RepairOrderMakeInvoice input)
    {
        return await RequestAsync<RepairOrderMakeInvoice>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(RepairOrderMakeInvoice), input }
        });
    }

    public virtual async Task<RepairOrderMakeInvoice> UpdateAsync(Guid id, RepairOrderMakeInvoice input)
    {
        return await RequestAsync<RepairOrderMakeInvoice>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(RepairOrderMakeInvoice), input }
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
