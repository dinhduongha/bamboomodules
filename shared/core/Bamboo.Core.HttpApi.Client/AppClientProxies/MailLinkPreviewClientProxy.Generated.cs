
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
[ExposeServices(typeof(IMailLinkPreviewAppService), typeof(MailLinkPreviewClientProxy))]
public partial class MailLinkPreviewClientProxy : ClientProxyBase<IMailLinkPreviewAppService>, IMailLinkPreviewAppService
{
    //public virtual async Task<ListResultDto<MailLinkPreview>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<MailLinkPreview>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<MailLinkPreview>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<MailLinkPreview>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<MailLinkPreview> GetAsync(Guid id)
    {
        return await RequestAsync<MailLinkPreview>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<MailLinkPreview> CreateAsync(MailLinkPreview input)
    {
        return await RequestAsync<MailLinkPreview>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MailLinkPreview), input }
        });
    }

    public virtual async Task<MailLinkPreview> UpdateAsync(Guid id, MailLinkPreview input)
    {
        return await RequestAsync<MailLinkPreview>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(MailLinkPreview), input }
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
