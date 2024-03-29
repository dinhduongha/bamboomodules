
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
[ExposeServices(typeof(IAccountReconcileModelAppService), typeof(AccountReconcileModelClientProxy))]
public partial class AccountReconcileModelClientProxy : ClientProxyBase<IAccountReconcileModelAppService>, IAccountReconcileModelAppService
{
    //public virtual async Task<ListResultDto<AccountReconcileModel>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AccountReconcileModel>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AccountReconcileModel>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AccountReconcileModel>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AccountReconcileModel> GetAsync(Guid id)
    {
        return await RequestAsync<AccountReconcileModel>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AccountReconcileModel> CreateAsync(AccountReconcileModel input)
    {
        return await RequestAsync<AccountReconcileModel>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AccountReconcileModel), input }
        });
    }

    public virtual async Task<AccountReconcileModel> UpdateAsync(Guid id, AccountReconcileModel input)
    {
        return await RequestAsync<AccountReconcileModel>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AccountReconcileModel), input }
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
