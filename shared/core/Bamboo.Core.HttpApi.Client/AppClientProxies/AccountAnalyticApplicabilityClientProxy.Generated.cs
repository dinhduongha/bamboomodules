
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
[ExposeServices(typeof(IAccountAnalyticApplicabilityAppService), typeof(AccountAnalyticApplicabilityClientProxy))]
public partial class AccountAnalyticApplicabilityClientProxy : ClientProxyBase<IAccountAnalyticApplicabilityAppService>, IAccountAnalyticApplicabilityAppService
{
    //public virtual async Task<ListResultDto<AccountAnalyticApplicability>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<AccountAnalyticApplicability>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<AccountAnalyticApplicability>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<AccountAnalyticApplicability>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<AccountAnalyticApplicability> GetAsync(Guid id)
    {
        return await RequestAsync<AccountAnalyticApplicability>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<AccountAnalyticApplicability> CreateAsync(AccountAnalyticApplicability input)
    {
        return await RequestAsync<AccountAnalyticApplicability>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(AccountAnalyticApplicability), input }
        });
    }

    public virtual async Task<AccountAnalyticApplicability> UpdateAsync(Guid id, AccountAnalyticApplicability input)
    {
        return await RequestAsync<AccountAnalyticApplicability>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(AccountAnalyticApplicability), input }
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
