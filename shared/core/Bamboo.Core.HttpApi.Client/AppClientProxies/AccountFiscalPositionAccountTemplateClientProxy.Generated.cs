
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
[ExposeServices(typeof(IAccountFiscalPositionAccountTemplateAppService), typeof(AccountFiscalPositionAccountTemplateClientProxy))]
public partial class AccountFiscalPositionAccountTemplateClientProxy : ClientProxyBase<IAccountFiscalPositionAccountTemplateAppService>, IAccountFiscalPositionAccountTemplateAppService
{
    //public virtual async Task<ListResultDto<AccountFiscalPositionAccountTemplate>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AccountFiscalPositionAccountTemplate>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AccountFiscalPositionAccountTemplate>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AccountFiscalPositionAccountTemplate>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AccountFiscalPositionAccountTemplate> GetAsync(Guid id)
    {
        return await RequestAsync<AccountFiscalPositionAccountTemplate>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AccountFiscalPositionAccountTemplate> CreateAsync(AccountFiscalPositionAccountTemplate input)
    {
        return await RequestAsync<AccountFiscalPositionAccountTemplate>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AccountFiscalPositionAccountTemplate), input }
        });
    }

    public virtual async Task<AccountFiscalPositionAccountTemplate> UpdateAsync(Guid id, AccountFiscalPositionAccountTemplate input)
    {
        return await RequestAsync<AccountFiscalPositionAccountTemplate>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AccountFiscalPositionAccountTemplate), input }
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
