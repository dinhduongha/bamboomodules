
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
[ExposeServices(typeof(IAccountFinancialReportAppService), typeof(AccountFinancialReportClientProxy))]
public partial class AccountFinancialReportClientProxy : ClientProxyBase<IAccountFinancialReportAppService>, IAccountFinancialReportAppService
{
    //public virtual async Task<ListResultDto<AccountFinancialReport>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AccountFinancialReport>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AccountFinancialReport>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AccountFinancialReport>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AccountFinancialReport> GetAsync(Guid id)
    {
        return await RequestAsync<AccountFinancialReport>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AccountFinancialReport> CreateAsync(AccountFinancialReport input)
    {
        return await RequestAsync<AccountFinancialReport>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AccountFinancialReport), input }
        });
    }

    public virtual async Task<AccountFinancialReport> UpdateAsync(Guid id, AccountFinancialReport input)
    {
        return await RequestAsync<AccountFinancialReport>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AccountFinancialReport), input }
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