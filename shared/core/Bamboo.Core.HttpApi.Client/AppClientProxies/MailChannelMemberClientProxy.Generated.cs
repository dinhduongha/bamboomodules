
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
[ExposeServices(typeof(IMailChannelMemberAppService), typeof(MailChannelMemberClientProxy))]
public partial class MailChannelMemberClientProxy : ClientProxyBase<IMailChannelMemberAppService>, IMailChannelMemberAppService
{
    //public virtual async Task<ListResultDto<MailChannelMember>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<MailChannelMember>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<MailChannelMember>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<MailChannelMember>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<MailChannelMember> GetAsync(Guid id)
    {
        return await RequestAsync<MailChannelMember>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<MailChannelMember> CreateAsync(MailChannelMember input)
    {
        return await RequestAsync<MailChannelMember>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MailChannelMember), input }
        });
    }

    public virtual async Task<MailChannelMember> UpdateAsync(Guid id, MailChannelMember input)
    {
        return await RequestAsync<MailChannelMember>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(MailChannelMember), input }
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