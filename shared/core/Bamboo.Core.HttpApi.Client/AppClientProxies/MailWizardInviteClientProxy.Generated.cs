
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
[ExposeServices(typeof(IMailWizardInviteAppService), typeof(MailWizardInviteClientProxy))]
public partial class MailWizardInviteClientProxy : ClientProxyBase<IMailWizardInviteAppService>, IMailWizardInviteAppService
{
    //public virtual async Task<ListResultDto<MailWizardInvite>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<MailWizardInvite>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<MailWizardInvite>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<MailWizardInvite>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<MailWizardInvite> GetAsync(Guid id)
    {
        return await RequestAsync<MailWizardInvite>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<MailWizardInvite> CreateAsync(MailWizardInvite input)
    {
        return await RequestAsync<MailWizardInvite>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MailWizardInvite), input }
        });
    }

    public virtual async Task<MailWizardInvite> UpdateAsync(Guid id, MailWizardInvite input)
    {
        return await RequestAsync<MailWizardInvite>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(MailWizardInvite), input }
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