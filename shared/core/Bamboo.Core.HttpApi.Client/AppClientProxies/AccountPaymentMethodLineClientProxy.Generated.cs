
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
[ExposeServices(typeof(IAccountPaymentMethodLineAppService), typeof(AccountPaymentMethodLineClientProxy))]
public partial class AccountPaymentMethodLineClientProxy : ClientProxyBase<IAccountPaymentMethodLineAppService>, IAccountPaymentMethodLineAppService
{
    //public virtual async Task<ListResultDto<AccountPaymentMethodLine>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AccountPaymentMethodLine>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AccountPaymentMethodLine>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AccountPaymentMethodLine>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AccountPaymentMethodLine> GetAsync(Guid id)
    {
        return await RequestAsync<AccountPaymentMethodLine>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AccountPaymentMethodLine> CreateAsync(AccountPaymentMethodLine input)
    {
        return await RequestAsync<AccountPaymentMethodLine>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AccountPaymentMethodLine), input }
        });
    }

    public virtual async Task<AccountPaymentMethodLine> UpdateAsync(Guid id, AccountPaymentMethodLine input)
    {
        return await RequestAsync<AccountPaymentMethodLine>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AccountPaymentMethodLine), input }
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