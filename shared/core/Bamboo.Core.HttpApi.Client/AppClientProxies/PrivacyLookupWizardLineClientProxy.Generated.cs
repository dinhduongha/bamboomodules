
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
[ExposeServices(typeof(IPrivacyLookupWizardLineAppService), typeof(PrivacyLookupWizardLineClientProxy))]
public partial class PrivacyLookupWizardLineClientProxy : ClientProxyBase<IPrivacyLookupWizardLineAppService>, IPrivacyLookupWizardLineAppService
{
    //public virtual async Task<ListResultDto<PrivacyLookupWizardLine>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<PrivacyLookupWizardLine>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<PrivacyLookupWizardLine>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<PrivacyLookupWizardLine>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<PrivacyLookupWizardLine> GetAsync(Guid id)
    {
        return await RequestAsync<PrivacyLookupWizardLine>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<PrivacyLookupWizardLine> CreateAsync(PrivacyLookupWizardLine input)
    {
        return await RequestAsync<PrivacyLookupWizardLine>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PrivacyLookupWizardLine), input }
        });
    }

    public virtual async Task<PrivacyLookupWizardLine> UpdateAsync(Guid id, PrivacyLookupWizardLine input)
    {
        return await RequestAsync<PrivacyLookupWizardLine>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(PrivacyLookupWizardLine), input }
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
