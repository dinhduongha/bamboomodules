
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
[ExposeServices(typeof(ISaleAdvancePaymentInvAppService), typeof(SaleAdvancePaymentInvClientProxy))]
public partial class SaleAdvancePaymentInvClientProxy : ClientProxyBase<ISaleAdvancePaymentInvAppService>, ISaleAdvancePaymentInvAppService
{
    //public virtual async Task<ListResultDto<SaleAdvancePaymentInv>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<SaleAdvancePaymentInv>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<SaleAdvancePaymentInv>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<SaleAdvancePaymentInv>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<SaleAdvancePaymentInv> GetAsync(Guid id)
    {
        return await RequestAsync<SaleAdvancePaymentInv>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<SaleAdvancePaymentInv> CreateAsync(SaleAdvancePaymentInv input)
    {
        return await RequestAsync<SaleAdvancePaymentInv>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(SaleAdvancePaymentInv), input }
        });
    }

    public virtual async Task<SaleAdvancePaymentInv> UpdateAsync(Guid id, SaleAdvancePaymentInv input)
    {
        return await RequestAsync<SaleAdvancePaymentInv>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(SaleAdvancePaymentInv), input }
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
