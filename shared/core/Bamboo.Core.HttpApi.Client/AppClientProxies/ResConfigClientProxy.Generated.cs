
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
[ExposeServices(typeof(IResConfigAppService), typeof(ResConfigClientProxy))]
public partial class ResConfigClientProxy : ClientProxyBase<IResConfigAppService>, IResConfigAppService
{
    //public virtual async Task<ListResultDto<ResConfig>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<ResConfig>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<ResConfig>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<ResConfig>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<ResConfig> GetAsync(Guid id)
    {
        return await RequestAsync<ResConfig>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<ResConfig> CreateAsync(ResConfig input)
    {
        return await RequestAsync<ResConfig>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(ResConfig), input }
        });
    }

    public virtual async Task<ResConfig> UpdateAsync(Guid id, ResConfig input)
    {
        return await RequestAsync<ResConfig>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(ResConfig), input }
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
