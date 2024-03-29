
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
[ExposeServices(typeof(IAccountTaxGroupAppService), typeof(AccountTaxGroupClientProxy))]
public partial class AccountTaxGroupClientProxy : ClientProxyBase<IAccountTaxGroupAppService>, IAccountTaxGroupAppService
{
    //public virtual async Task<ListResultDto<AccountTaxGroup>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AccountTaxGroup>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AccountTaxGroup>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AccountTaxGroup>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AccountTaxGroup> GetAsync(Guid id)
    {
        return await RequestAsync<AccountTaxGroup>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AccountTaxGroup> CreateAsync(AccountTaxGroup input)
    {
        return await RequestAsync<AccountTaxGroup>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AccountTaxGroup), input }
        });
    }

    public virtual async Task<AccountTaxGroup> UpdateAsync(Guid id, AccountTaxGroup input)
    {
        return await RequestAsync<AccountTaxGroup>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AccountTaxGroup), input }
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
