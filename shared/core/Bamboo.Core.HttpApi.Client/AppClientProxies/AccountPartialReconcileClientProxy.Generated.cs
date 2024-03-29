
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
[ExposeServices(typeof(IAccountPartialReconcileAppService), typeof(AccountPartialReconcileClientProxy))]
public partial class AccountPartialReconcileClientProxy : ClientProxyBase<IAccountPartialReconcileAppService>, IAccountPartialReconcileAppService
{
    //public virtual async Task<ListResultDto<AccountPartialReconcile>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AccountPartialReconcile>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AccountPartialReconcile>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AccountPartialReconcile>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AccountPartialReconcile> GetAsync(Guid id)
    {
        return await RequestAsync<AccountPartialReconcile>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AccountPartialReconcile> CreateAsync(AccountPartialReconcile input)
    {
        return await RequestAsync<AccountPartialReconcile>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AccountPartialReconcile), input }
        });
    }

    public virtual async Task<AccountPartialReconcile> UpdateAsync(Guid id, AccountPartialReconcile input)
    {
        return await RequestAsync<AccountPartialReconcile>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AccountPartialReconcile), input }
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
