
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
[ExposeServices(typeof(IHrRecruitmentDegreeAppService), typeof(HrRecruitmentDegreeClientProxy))]
public partial class HrRecruitmentDegreeClientProxy : ClientProxyBase<IHrRecruitmentDegreeAppService>, IHrRecruitmentDegreeAppService
{
    //public virtual async Task<ListResultDto<HrRecruitmentDegree>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<HrRecruitmentDegree>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<HrRecruitmentDegree>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<HrRecruitmentDegree>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<HrRecruitmentDegree> GetAsync(long id)
    {
        return await RequestAsync<HrRecruitmentDegree>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id }
        });
    }

    public virtual async Task<HrRecruitmentDegree> CreateAsync(HrRecruitmentDegree input)
    {
        return await RequestAsync<HrRecruitmentDegree>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(HrRecruitmentDegree), input }
        });
    }

    public virtual async Task<HrRecruitmentDegree> UpdateAsync(long id, HrRecruitmentDegree input)
    {
        return await RequestAsync<HrRecruitmentDegree>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id },
            { typeof(HrRecruitmentDegree), input }
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
