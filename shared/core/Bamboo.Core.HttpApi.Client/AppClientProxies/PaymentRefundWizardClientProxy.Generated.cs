
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
[ExposeServices(typeof(IPaymentRefundWizardAppService), typeof(PaymentRefundWizardClientProxy))]
public partial class PaymentRefundWizardClientProxy : ClientProxyBase<IPaymentRefundWizardAppService>, IPaymentRefundWizardAppService
{
    //public virtual async Task<ListResultDto<PaymentRefundWizard>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<PaymentRefundWizard>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<PaymentRefundWizard>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<PaymentRefundWizard>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<PaymentRefundWizard> GetAsync(Guid id)
    {
        return await RequestAsync<PaymentRefundWizard>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<PaymentRefundWizard> CreateAsync(PaymentRefundWizard input)
    {
        return await RequestAsync<PaymentRefundWizard>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PaymentRefundWizard), input }
        });
    }

    public virtual async Task<PaymentRefundWizard> UpdateAsync(Guid id, PaymentRefundWizard input)
    {
        return await RequestAsync<PaymentRefundWizard>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(PaymentRefundWizard), input }
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