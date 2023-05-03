
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
[ExposeServices(typeof(IFetchmailServerAppService), typeof(FetchmailServerClientProxy))]
public partial class FetchmailServerClientProxy : ClientProxyBase<IFetchmailServerAppService>, IFetchmailServerAppService
{
    //public virtual async Task<ListResultDto<FetchmailServer>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<FetchmailServer>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<FetchmailServer>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<FetchmailServer>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<FetchmailServer> GetAsync(Guid id)
    {
        return await RequestAsync<FetchmailServer>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<FetchmailServer> CreateAsync(FetchmailServer input)
    {
        return await RequestAsync<FetchmailServer>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(FetchmailServer), input }
        });
    }

    public virtual async Task<FetchmailServer> UpdateAsync(Guid id, FetchmailServer input)
    {
        return await RequestAsync<FetchmailServer>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(FetchmailServer), input }
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
