
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
[ExposeServices(typeof(IMailResendPartnerAppService), typeof(MailResendPartnerClientProxy))]
public partial class MailResendPartnerClientProxy : ClientProxyBase<IMailResendPartnerAppService>, IMailResendPartnerAppService
{
    //public virtual async Task<ListResultDto<MailResendPartner>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<MailResendPartner>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<MailResendPartner>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<MailResendPartner>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<MailResendPartner> GetAsync(Guid id)
    {
        return await RequestAsync<MailResendPartner>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<MailResendPartner> CreateAsync(MailResendPartner input)
    {
        return await RequestAsync<MailResendPartner>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MailResendPartner), input }
        });
    }

    public virtual async Task<MailResendPartner> UpdateAsync(Guid id, MailResendPartner input)
    {
        return await RequestAsync<MailResendPartner>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(MailResendPartner), input }
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
