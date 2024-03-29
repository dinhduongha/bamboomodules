
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
[ExposeServices(typeof(IPaymentProviderOnboardingWizardAppService), typeof(PaymentProviderOnboardingWizardClientProxy))]
public partial class PaymentProviderOnboardingWizardClientProxy : ClientProxyBase<IPaymentProviderOnboardingWizardAppService>, IPaymentProviderOnboardingWizardAppService
{
    //public virtual async Task<ListResultDto<PaymentProviderOnboardingWizard>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<PaymentProviderOnboardingWizard>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<PaymentProviderOnboardingWizard>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<PaymentProviderOnboardingWizard>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<PaymentProviderOnboardingWizard> GetAsync(Guid id)
    {
        return await RequestAsync<PaymentProviderOnboardingWizard>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<PaymentProviderOnboardingWizard> CreateAsync(PaymentProviderOnboardingWizard input)
    {
        return await RequestAsync<PaymentProviderOnboardingWizard>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PaymentProviderOnboardingWizard), input }
        });
    }

    public virtual async Task<PaymentProviderOnboardingWizard> UpdateAsync(Guid id, PaymentProviderOnboardingWizard input)
    {
        return await RequestAsync<PaymentProviderOnboardingWizard>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(PaymentProviderOnboardingWizard), input }
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
