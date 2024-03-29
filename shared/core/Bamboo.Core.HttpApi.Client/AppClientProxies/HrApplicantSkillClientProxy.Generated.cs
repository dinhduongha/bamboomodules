
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
[ExposeServices(typeof(IHrApplicantSkillAppService), typeof(HrApplicantSkillClientProxy))]
public partial class HrApplicantSkillClientProxy : ClientProxyBase<IHrApplicantSkillAppService>, IHrApplicantSkillAppService
{
    //public virtual async Task<ListResultDto<HrApplicantSkill>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<HrApplicantSkill>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<HrApplicantSkill>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<HrApplicantSkill>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<HrApplicantSkill> GetAsync(Guid id)
    {
        return await RequestAsync<HrApplicantSkill>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<HrApplicantSkill> CreateAsync(HrApplicantSkill input)
    {
        return await RequestAsync<HrApplicantSkill>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(HrApplicantSkill), input }
        });
    }

    public virtual async Task<HrApplicantSkill> UpdateAsync(Guid id, HrApplicantSkill input)
    {
        return await RequestAsync<HrApplicantSkill>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(HrApplicantSkill), input }
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
