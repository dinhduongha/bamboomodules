
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
[ExposeServices(typeof(ILunchLocationAppService), typeof(LunchLocationClientProxy))]
public partial class LunchLocationClientProxy : ClientProxyBase<ILunchLocationAppService>, ILunchLocationAppService
{
    //public virtual async Task<ListResultDto<LunchLocation>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<LunchLocation>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<LunchLocation>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<LunchLocation>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<LunchLocation> GetAsync(Guid id)
    {
        return await RequestAsync<LunchLocation>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<LunchLocation> CreateAsync(LunchLocation input)
    {
        return await RequestAsync<LunchLocation>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(LunchLocation), input }
        });
    }

    public virtual async Task<LunchLocation> UpdateAsync(Guid id, LunchLocation input)
    {
        return await RequestAsync<LunchLocation>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(LunchLocation), input }
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
