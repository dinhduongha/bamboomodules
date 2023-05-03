
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
[ExposeServices(typeof(IMrpWorkcenterCapacityAppService), typeof(MrpWorkcenterCapacityClientProxy))]
public partial class MrpWorkcenterCapacityClientProxy : ClientProxyBase<IMrpWorkcenterCapacityAppService>, IMrpWorkcenterCapacityAppService
{
    //public virtual async Task<ListResultDto<MrpWorkcenterCapacity>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<MrpWorkcenterCapacity>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<MrpWorkcenterCapacity>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<MrpWorkcenterCapacity>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<MrpWorkcenterCapacity> GetAsync(Guid id)
    {
        return await RequestAsync<MrpWorkcenterCapacity>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<MrpWorkcenterCapacity> CreateAsync(MrpWorkcenterCapacity input)
    {
        return await RequestAsync<MrpWorkcenterCapacity>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MrpWorkcenterCapacity), input }
        });
    }

    public virtual async Task<MrpWorkcenterCapacity> UpdateAsync(Guid id, MrpWorkcenterCapacity input)
    {
        return await RequestAsync<MrpWorkcenterCapacity>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(MrpWorkcenterCapacity), input }
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