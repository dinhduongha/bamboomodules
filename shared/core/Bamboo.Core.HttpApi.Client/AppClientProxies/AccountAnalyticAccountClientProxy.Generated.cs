
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
[ExposeServices(typeof(IAccountAnalyticAccountAppService), typeof(AccountAnalyticAccountClientProxy))]
public partial class AccountAnalyticAccountClientProxy : ClientProxyBase<IAccountAnalyticAccountAppService>, IAccountAnalyticAccountAppService
{
    //public virtual async Task<ListResultDto<AccountAnalyticAccount>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AccountAnalyticAccount>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AccountAnalyticAccount>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AccountAnalyticAccount>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AccountAnalyticAccount> GetAsync(Guid id)
    {
        return await RequestAsync<AccountAnalyticAccount>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AccountAnalyticAccount> CreateAsync(AccountAnalyticAccount input)
    {
        return await RequestAsync<AccountAnalyticAccount>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AccountAnalyticAccount), input }
        });
    }

    public virtual async Task<AccountAnalyticAccount> UpdateAsync(Guid id, AccountAnalyticAccount input)
    {
        return await RequestAsync<AccountAnalyticAccount>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AccountAnalyticAccount), input }
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
