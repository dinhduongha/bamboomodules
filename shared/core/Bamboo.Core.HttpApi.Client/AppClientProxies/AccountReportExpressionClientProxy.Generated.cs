
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
[ExposeServices(typeof(IAccountReportExpressionAppService), typeof(AccountReportExpressionClientProxy))]
public partial class AccountReportExpressionClientProxy : ClientProxyBase<IAccountReportExpressionAppService>, IAccountReportExpressionAppService
{
    //public virtual async Task<ListResultDto<AccountReportExpression>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AccountReportExpression>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AccountReportExpression>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AccountReportExpression>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AccountReportExpression> GetAsync(Guid id)
    {
        return await RequestAsync<AccountReportExpression>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AccountReportExpression> CreateAsync(AccountReportExpression input)
    {
        return await RequestAsync<AccountReportExpression>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AccountReportExpression), input }
        });
    }

    public virtual async Task<AccountReportExpression> UpdateAsync(Guid id, AccountReportExpression input)
    {
        return await RequestAsync<AccountReportExpression>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AccountReportExpression), input }
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