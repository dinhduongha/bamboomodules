
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
[ExposeServices(typeof(IHrApplicantCategoryAppService), typeof(HrApplicantCategoryClientProxy))]
public partial class HrApplicantCategoryClientProxy : ClientProxyBase<IHrApplicantCategoryAppService>, IHrApplicantCategoryAppService
{
    //public virtual async Task<ListResultDto<HrApplicantCategory>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<HrApplicantCategory>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<HrApplicantCategory>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<HrApplicantCategory>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<HrApplicantCategory> GetAsync(long id)
    {
        return await RequestAsync<HrApplicantCategory>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id }
        });
    }

    public virtual async Task<HrApplicantCategory> CreateAsync(HrApplicantCategory input)
    {
        return await RequestAsync<HrApplicantCategory>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(HrApplicantCategory), input }
        });
    }

    public virtual async Task<HrApplicantCategory> UpdateAsync(long id, HrApplicantCategory input)
    {
        return await RequestAsync<HrApplicantCategory>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id },
            { typeof(HrApplicantCategory), input }
        });
    }

    public virtual async Task DeleteAsync(long id)
    {
        await RequestAsync(nameof(DeleteAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id }
        });
    }
}
