
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
[ExposeServices(typeof(IPosMakePaymentAppService), typeof(PosMakePaymentClientProxy))]
public partial class PosMakePaymentClientProxy : ClientProxyBase<IPosMakePaymentAppService>, IPosMakePaymentAppService
{
    //public virtual async Task<ListResultDto<PosMakePayment>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<PosMakePayment>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<PosMakePayment>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<PosMakePayment>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<PosMakePayment> GetAsync(Guid id)
    {
        return await RequestAsync<PosMakePayment>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<PosMakePayment> CreateAsync(PosMakePayment input)
    {
        return await RequestAsync<PosMakePayment>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PosMakePayment), input }
        });
    }

    public virtual async Task<PosMakePayment> UpdateAsync(Guid id, PosMakePayment input)
    {
        return await RequestAsync<PosMakePayment>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(PosMakePayment), input }
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
