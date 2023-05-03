
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
[ExposeServices(typeof(IAccountAutomaticEntryWizardAppService), typeof(AccountAutomaticEntryWizardClientProxy))]
public partial class AccountAutomaticEntryWizardClientProxy : ClientProxyBase<IAccountAutomaticEntryWizardAppService>, IAccountAutomaticEntryWizardAppService
{
    //public virtual async Task<ListResultDto<AccountAutomaticEntryWizard>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AccountAutomaticEntryWizard>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AccountAutomaticEntryWizard>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AccountAutomaticEntryWizard>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AccountAutomaticEntryWizard> GetAsync(Guid id)
    {
        return await RequestAsync<AccountAutomaticEntryWizard>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AccountAutomaticEntryWizard> CreateAsync(AccountAutomaticEntryWizard input)
    {
        return await RequestAsync<AccountAutomaticEntryWizard>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AccountAutomaticEntryWizard), input }
        });
    }

    public virtual async Task<AccountAutomaticEntryWizard> UpdateAsync(Guid id, AccountAutomaticEntryWizard input)
    {
        return await RequestAsync<AccountAutomaticEntryWizard>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AccountAutomaticEntryWizard), input }
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
