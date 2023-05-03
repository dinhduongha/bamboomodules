
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
[ExposeServices(typeof(IMailBlacklistAppService), typeof(MailBlacklistClientProxy))]
public partial class MailBlacklistClientProxy : ClientProxyBase<IMailBlacklistAppService>, IMailBlacklistAppService
{
    //public virtual async Task<ListResultDto<MailBlacklist>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<MailBlacklist>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<MailBlacklist>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<MailBlacklist>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<MailBlacklist> GetAsync(Guid id)
    {
        return await RequestAsync<MailBlacklist>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<MailBlacklist> CreateAsync(MailBlacklist input)
    {
        return await RequestAsync<MailBlacklist>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MailBlacklist), input }
        });
    }

    public virtual async Task<MailBlacklist> UpdateAsync(Guid id, MailBlacklist input)
    {
        return await RequestAsync<MailBlacklist>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(MailBlacklist), input }
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