
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
[ExposeServices(typeof(IAccountFiscalPositionAppService), typeof(AccountFiscalPositionClientProxy))]
public partial class AccountFiscalPositionClientProxy : ClientProxyBase<IAccountFiscalPositionAppService>, IAccountFiscalPositionAppService
{
    //public virtual async Task<ListResultDto<AccountFiscalPosition>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AccountFiscalPosition>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AccountFiscalPosition>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AccountFiscalPosition>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AccountFiscalPosition> GetAsync(Guid id)
    {
        return await RequestAsync<AccountFiscalPosition>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AccountFiscalPosition> CreateAsync(AccountFiscalPosition input)
    {
        return await RequestAsync<AccountFiscalPosition>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AccountFiscalPosition), input }
        });
    }

    public virtual async Task<AccountFiscalPosition> UpdateAsync(Guid id, AccountFiscalPosition input)
    {
        return await RequestAsync<AccountFiscalPosition>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AccountFiscalPosition), input }
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
