
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
[ExposeServices(typeof(IAccountFiscalPositionTaxAppService), typeof(AccountFiscalPositionTaxClientProxy))]
public partial class AccountFiscalPositionTaxClientProxy : ClientProxyBase<IAccountFiscalPositionTaxAppService>, IAccountFiscalPositionTaxAppService
{
    //public virtual async Task<ListResultDto<AccountFiscalPositionTax>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AccountFiscalPositionTax>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AccountFiscalPositionTax>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AccountFiscalPositionTax>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AccountFiscalPositionTax> GetAsync(Guid id)
    {
        return await RequestAsync<AccountFiscalPositionTax>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AccountFiscalPositionTax> CreateAsync(AccountFiscalPositionTax input)
    {
        return await RequestAsync<AccountFiscalPositionTax>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AccountFiscalPositionTax), input }
        });
    }

    public virtual async Task<AccountFiscalPositionTax> UpdateAsync(Guid id, AccountFiscalPositionTax input)
    {
        return await RequestAsync<AccountFiscalPositionTax>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AccountFiscalPositionTax), input }
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
