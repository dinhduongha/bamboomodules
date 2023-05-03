
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
[ExposeServices(typeof(IHrResumeLineTypeAppService), typeof(HrResumeLineTypeClientProxy))]
public partial class HrResumeLineTypeClientProxy : ClientProxyBase<IHrResumeLineTypeAppService>, IHrResumeLineTypeAppService
{
    //public virtual async Task<ListResultDto<HrResumeLineType>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<HrResumeLineType>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<HrResumeLineType>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<HrResumeLineType>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<HrResumeLineType> GetAsync(long id)
    {
        return await RequestAsync<HrResumeLineType>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id }
        });
    }

    public virtual async Task<HrResumeLineType> CreateAsync(HrResumeLineType input)
    {
        return await RequestAsync<HrResumeLineType>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(HrResumeLineType), input }
        });
    }

    public virtual async Task<HrResumeLineType> UpdateAsync(long id, HrResumeLineType input)
    {
        return await RequestAsync<HrResumeLineType>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(long), id },
            { typeof(HrResumeLineType), input }
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
