
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
[ExposeServices(typeof(IHrJobAppService), typeof(HrJobClientProxy))]
public partial class HrJobClientProxy : ClientProxyBase<IHrJobAppService>, IHrJobAppService
{
    //public virtual async Task<ListResultDto<HrJob>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<HrJob>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<HrJob>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<HrJob>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<HrJob> GetAsync(Guid id)
    {
        return await RequestAsync<HrJob>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<HrJob> CreateAsync(HrJob input)
    {
        return await RequestAsync<HrJob>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(HrJob), input }
        });
    }

    public virtual async Task<HrJob> UpdateAsync(Guid id, HrJob input)
    {
        return await RequestAsync<HrJob>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(HrJob), input }
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
