
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
[ExposeServices(typeof(IAccountCommonAccountReportAppService), typeof(AccountCommonAccountReportClientProxy))]
public partial class AccountCommonAccountReportClientProxy : ClientProxyBase<IAccountCommonAccountReportAppService>, IAccountCommonAccountReportAppService
{
    //public virtual async Task<ListResultDto<AccountCommonAccountReport>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AccountCommonAccountReport>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AccountCommonAccountReport>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AccountCommonAccountReport>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AccountCommonAccountReport> GetAsync(Guid id)
    {
        return await RequestAsync<AccountCommonAccountReport>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AccountCommonAccountReport> CreateAsync(AccountCommonAccountReport input)
    {
        return await RequestAsync<AccountCommonAccountReport>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AccountCommonAccountReport), input }
        });
    }

    public virtual async Task<AccountCommonAccountReport> UpdateAsync(Guid id, AccountCommonAccountReport input)
    {
        return await RequestAsync<AccountCommonAccountReport>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AccountCommonAccountReport), input }
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
