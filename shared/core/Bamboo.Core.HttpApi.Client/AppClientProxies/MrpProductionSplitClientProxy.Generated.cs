
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
[ExposeServices(typeof(IMrpProductionSplitAppService), typeof(MrpProductionSplitClientProxy))]
public partial class MrpProductionSplitClientProxy : ClientProxyBase<IMrpProductionSplitAppService>, IMrpProductionSplitAppService
{
    //public virtual async Task<ListResultDto<MrpProductionSplit>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<MrpProductionSplit>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<MrpProductionSplit>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<MrpProductionSplit>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<MrpProductionSplit> GetAsync(Guid id)
    {
        return await RequestAsync<MrpProductionSplit>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<MrpProductionSplit> CreateAsync(MrpProductionSplit input)
    {
        return await RequestAsync<MrpProductionSplit>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MrpProductionSplit), input }
        });
    }

    public virtual async Task<MrpProductionSplit> UpdateAsync(Guid id, MrpProductionSplit input)
    {
        return await RequestAsync<MrpProductionSplit>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(MrpProductionSplit), input }
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
