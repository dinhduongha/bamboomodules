
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
[ExposeServices(typeof(IAccountReportAppService), typeof(AccountReportClientProxy))]
public partial class AccountReportClientProxy : ClientProxyBase<IAccountReportAppService>, IAccountReportAppService
{
    //public virtual async Task<ListResultDto<AccountReport>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AccountReport>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AccountReport>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AccountReport>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AccountReport> GetAsync(Guid id)
    {
        return await RequestAsync<AccountReport>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AccountReport> CreateAsync(AccountReport input)
    {
        return await RequestAsync<AccountReport>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AccountReport), input }
        });
    }

    public virtual async Task<AccountReport> UpdateAsync(Guid id, AccountReport input)
    {
        return await RequestAsync<AccountReport>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AccountReport), input }
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
