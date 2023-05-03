
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
[ExposeServices(typeof(IAccountPaymentTermAppService), typeof(AccountPaymentTermClientProxy))]
public partial class AccountPaymentTermClientProxy : ClientProxyBase<IAccountPaymentTermAppService>, IAccountPaymentTermAppService
{
    //public virtual async Task<ListResultDto<AccountPaymentTerm>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AccountPaymentTerm>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AccountPaymentTerm>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AccountPaymentTerm>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AccountPaymentTerm> GetAsync(Guid id)
    {
        return await RequestAsync<AccountPaymentTerm>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AccountPaymentTerm> CreateAsync(AccountPaymentTerm input)
    {
        return await RequestAsync<AccountPaymentTerm>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AccountPaymentTerm), input }
        });
    }

    public virtual async Task<AccountPaymentTerm> UpdateAsync(Guid id, AccountPaymentTerm input)
    {
        return await RequestAsync<AccountPaymentTerm>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AccountPaymentTerm), input }
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
