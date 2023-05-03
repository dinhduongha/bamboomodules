
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
[ExposeServices(typeof(IAccountGroupAppService), typeof(AccountGroupClientProxy))]
public partial class AccountGroupClientProxy : ClientProxyBase<IAccountGroupAppService>, IAccountGroupAppService
{
    //public virtual async Task<ListResultDto<AccountGroup>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AccountGroup>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AccountGroup>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AccountGroup>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AccountGroup> GetAsync(Guid id)
    {
        return await RequestAsync<AccountGroup>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AccountGroup> CreateAsync(AccountGroup input)
    {
        return await RequestAsync<AccountGroup>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AccountGroup), input }
        });
    }

    public virtual async Task<AccountGroup> UpdateAsync(Guid id, AccountGroup input)
    {
        return await RequestAsync<AccountGroup>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AccountGroup), input }
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
