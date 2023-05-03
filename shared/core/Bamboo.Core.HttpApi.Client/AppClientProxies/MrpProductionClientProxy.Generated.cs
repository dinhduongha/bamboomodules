
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
[ExposeServices(typeof(IMrpProductionAppService), typeof(MrpProductionClientProxy))]
public partial class MrpProductionClientProxy : ClientProxyBase<IMrpProductionAppService>, IMrpProductionAppService
{
    //public virtual async Task<ListResultDto<MrpProduction>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<MrpProduction>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<MrpProduction>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<MrpProduction>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<MrpProduction> GetAsync(Guid id)
    {
        return await RequestAsync<MrpProduction>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<MrpProduction> CreateAsync(MrpProduction input)
    {
        return await RequestAsync<MrpProduction>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(MrpProduction), input }
        });
    }

    public virtual async Task<MrpProduction> UpdateAsync(Guid id, MrpProduction input)
    {
        return await RequestAsync<MrpProduction>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(MrpProduction), input }
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
