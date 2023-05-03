
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
[ExposeServices(typeof(IHrPlanActivityTypeAppService), typeof(HrPlanActivityTypeClientProxy))]
public partial class HrPlanActivityTypeClientProxy : ClientProxyBase<IHrPlanActivityTypeAppService>, IHrPlanActivityTypeAppService
{
    //public virtual async Task<ListResultDto<HrPlanActivityType>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<HrPlanActivityType>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<HrPlanActivityType>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<HrPlanActivityType>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<HrPlanActivityType> GetAsync(Guid id)
    {
        return await RequestAsync<HrPlanActivityType>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<HrPlanActivityType> CreateAsync(HrPlanActivityType input)
    {
        return await RequestAsync<HrPlanActivityType>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(HrPlanActivityType), input }
        });
    }

    public virtual async Task<HrPlanActivityType> UpdateAsync(Guid id, HrPlanActivityType input)
    {
        return await RequestAsync<HrPlanActivityType>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(HrPlanActivityType), input }
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
