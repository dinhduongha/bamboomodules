
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
[ExposeServices(typeof(IMailNotificationAppService), typeof(MailNotificationClientProxy))]
public partial class MailNotificationClientProxy : ClientProxyBase<IMailNotificationAppService>, IMailNotificationAppService
{
    //public virtual async Task<ListResultDto<MailNotification>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<MailNotification>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<MailNotification>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<MailNotification>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<MailNotification> GetAsync(Guid id)
    {
        return await RequestAsync<MailNotification>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<MailNotification> CreateAsync(MailNotification input)
    {
        return await RequestAsync<MailNotification>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MailNotification), input }
        });
    }

    public virtual async Task<MailNotification> UpdateAsync(Guid id, MailNotification input)
    {
        return await RequestAsync<MailNotification>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(MailNotification), input }
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
