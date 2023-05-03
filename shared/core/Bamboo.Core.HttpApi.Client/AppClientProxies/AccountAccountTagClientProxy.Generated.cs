
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
[ExposeServices(typeof(IAccountAccountTagAppService), typeof(AccountAccountTagClientProxy))]
public partial class AccountAccountTagClientProxy : ClientProxyBase<IAccountAccountTagAppService>, IAccountAccountTagAppService
{
    //public virtual async Task<ListResultDto<AccountAccountTag>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AccountAccountTag>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AccountAccountTag>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AccountAccountTag>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AccountAccountTag> GetAsync(long id)
    {
        return await RequestAsync<AccountAccountTag>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id }
        });
    }

    public virtual async Task<AccountAccountTag> CreateAsync(AccountAccountTag input)
    {
        return await RequestAsync<AccountAccountTag>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AccountAccountTag), input }
        });
    }

    public virtual async Task<AccountAccountTag> UpdateAsync(long id, AccountAccountTag input)
    {
        return await RequestAsync<AccountAccountTag>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id },
            { typeof(AccountAccountTag), input }
        });
    }

    public virtual async Task DeleteAsync(long id)
    {
        await RequestAsync(nameof(DeleteAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id }
        });
    }
}
