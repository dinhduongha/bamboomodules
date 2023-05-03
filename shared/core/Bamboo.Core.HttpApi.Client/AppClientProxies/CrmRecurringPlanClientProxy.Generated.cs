
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
[ExposeServices(typeof(ICrmRecurringPlanAppService), typeof(CrmRecurringPlanClientProxy))]
public partial class CrmRecurringPlanClientProxy : ClientProxyBase<ICrmRecurringPlanAppService>, ICrmRecurringPlanAppService
{
    //public virtual async Task<ListResultDto<CrmRecurringPlan>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<CrmRecurringPlan>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<CrmRecurringPlan>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<CrmRecurringPlan>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<CrmRecurringPlan> GetAsync(Guid id)
    {
        return await RequestAsync<CrmRecurringPlan>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<CrmRecurringPlan> CreateAsync(CrmRecurringPlan input)
    {
        return await RequestAsync<CrmRecurringPlan>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(CrmRecurringPlan), input }
        });
    }

    public virtual async Task<CrmRecurringPlan> UpdateAsync(Guid id, CrmRecurringPlan input)
    {
        return await RequestAsync<CrmRecurringPlan>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(CrmRecurringPlan), input }
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
