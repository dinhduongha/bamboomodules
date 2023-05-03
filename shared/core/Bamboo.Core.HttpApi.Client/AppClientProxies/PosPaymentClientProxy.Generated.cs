
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
[ExposeServices(typeof(IPosPaymentAppService), typeof(PosPaymentClientProxy))]
public partial class PosPaymentClientProxy : ClientProxyBase<IPosPaymentAppService>, IPosPaymentAppService
{
    //public virtual async Task<ListResultDto<PosPayment>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<PosPayment>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<PosPayment>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<PosPayment>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<PosPayment> GetAsync(Guid id)
    {
        return await RequestAsync<PosPayment>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<PosPayment> CreateAsync(PosPayment input)
    {
        return await RequestAsync<PosPayment>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PosPayment), input }
        });
    }

    public virtual async Task<PosPayment> UpdateAsync(Guid id, PosPayment input)
    {
        return await RequestAsync<PosPayment>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(PosPayment), input }
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