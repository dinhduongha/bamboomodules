
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
[ExposeServices(typeof(IAccountPaymentRegisterAppService), typeof(AccountPaymentRegisterClientProxy))]
public partial class AccountPaymentRegisterClientProxy : ClientProxyBase<IAccountPaymentRegisterAppService>, IAccountPaymentRegisterAppService
{
    //public virtual async Task<ListResultDto<AccountPaymentRegister>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AccountPaymentRegister>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AccountPaymentRegister>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AccountPaymentRegister>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AccountPaymentRegister> GetAsync(Guid id)
    {
        return await RequestAsync<AccountPaymentRegister>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AccountPaymentRegister> CreateAsync(AccountPaymentRegister input)
    {
        return await RequestAsync<AccountPaymentRegister>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AccountPaymentRegister), input }
        });
    }

    public virtual async Task<AccountPaymentRegister> UpdateAsync(Guid id, AccountPaymentRegister input)
    {
        return await RequestAsync<AccountPaymentRegister>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AccountPaymentRegister), input }
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
