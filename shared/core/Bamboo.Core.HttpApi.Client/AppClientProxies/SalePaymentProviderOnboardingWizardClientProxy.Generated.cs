
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
[ExposeServices(typeof(ISalePaymentProviderOnboardingWizardAppService), typeof(SalePaymentProviderOnboardingWizardClientProxy))]
public partial class SalePaymentProviderOnboardingWizardClientProxy : ClientProxyBase<ISalePaymentProviderOnboardingWizardAppService>, ISalePaymentProviderOnboardingWizardAppService
{
    //public virtual async Task<ListResultDto<SalePaymentProviderOnboardingWizard>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<SalePaymentProviderOnboardingWizard>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<SalePaymentProviderOnboardingWizard>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<SalePaymentProviderOnboardingWizard>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<SalePaymentProviderOnboardingWizard> GetAsync(Guid id)
    {
        return await RequestAsync<SalePaymentProviderOnboardingWizard>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<SalePaymentProviderOnboardingWizard> CreateAsync(SalePaymentProviderOnboardingWizard input)
    {
        return await RequestAsync<SalePaymentProviderOnboardingWizard>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(SalePaymentProviderOnboardingWizard), input }
        });
    }

    public virtual async Task<SalePaymentProviderOnboardingWizard> UpdateAsync(Guid id, SalePaymentProviderOnboardingWizard input)
    {
        return await RequestAsync<SalePaymentProviderOnboardingWizard>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(SalePaymentProviderOnboardingWizard), input }
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
