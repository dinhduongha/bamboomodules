
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
[ExposeServices(typeof(IHrSkillTypeAppService), typeof(HrSkillTypeClientProxy))]
public partial class HrSkillTypeClientProxy : ClientProxyBase<IHrSkillTypeAppService>, IHrSkillTypeAppService
{
    //public virtual async Task<ListResultDto<HrSkillType>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<HrSkillType>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<HrSkillType>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<HrSkillType>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<HrSkillType> GetAsync(long id)
    {
        return await RequestAsync<HrSkillType>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id }
        });
    }

    public virtual async Task<HrSkillType> CreateAsync(HrSkillType input)
    {
        return await RequestAsync<HrSkillType>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(HrSkillType), input }
        });
    }

    public virtual async Task<HrSkillType> UpdateAsync(long id, HrSkillType input)
    {
        return await RequestAsync<HrSkillType>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id },
            { typeof(HrSkillType), input }
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
