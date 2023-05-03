
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
[ExposeServices(typeof(IMailShortcodeAppService), typeof(MailShortcodeClientProxy))]
public partial class MailShortcodeClientProxy : ClientProxyBase<IMailShortcodeAppService>, IMailShortcodeAppService
{
    //public virtual async Task<ListResultDto<MailShortcode>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<MailShortcode>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<MailShortcode>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<MailShortcode>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<MailShortcode> GetAsync(Guid id)
    {
        return await RequestAsync<MailShortcode>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<MailShortcode> CreateAsync(MailShortcode input)
    {
        return await RequestAsync<MailShortcode>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MailShortcode), input }
        });
    }

    public virtual async Task<MailShortcode> UpdateAsync(Guid id, MailShortcode input)
    {
        return await RequestAsync<MailShortcode>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(MailShortcode), input }
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