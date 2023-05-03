
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
[ExposeServices(typeof(IMailTemplatePreviewAppService), typeof(MailTemplatePreviewClientProxy))]
public partial class MailTemplatePreviewClientProxy : ClientProxyBase<IMailTemplatePreviewAppService>, IMailTemplatePreviewAppService
{
    //public virtual async Task<ListResultDto<MailTemplatePreview>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<MailTemplatePreview>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<MailTemplatePreview>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<MailTemplatePreview>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<MailTemplatePreview> GetAsync(Guid id)
    {
        return await RequestAsync<MailTemplatePreview>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<MailTemplatePreview> CreateAsync(MailTemplatePreview input)
    {
        return await RequestAsync<MailTemplatePreview>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MailTemplatePreview), input }
        });
    }

    public virtual async Task<MailTemplatePreview> UpdateAsync(Guid id, MailTemplatePreview input)
    {
        return await RequestAsync<MailTemplatePreview>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(MailTemplatePreview), input }
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
