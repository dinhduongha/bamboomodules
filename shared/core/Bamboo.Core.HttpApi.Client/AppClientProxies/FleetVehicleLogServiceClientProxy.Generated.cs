
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
[ExposeServices(typeof(IFleetVehicleLogServiceAppService), typeof(FleetVehicleLogServiceClientProxy))]
public partial class FleetVehicleLogServiceClientProxy : ClientProxyBase<IFleetVehicleLogServiceAppService>, IFleetVehicleLogServiceAppService
{
    //public virtual async Task<ListResultDto<FleetVehicleLogService>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<FleetVehicleLogService>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<FleetVehicleLogService>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<FleetVehicleLogService>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<FleetVehicleLogService> GetAsync(Guid id)
    {
        return await RequestAsync<FleetVehicleLogService>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<FleetVehicleLogService> CreateAsync(FleetVehicleLogService input)
    {
        return await RequestAsync<FleetVehicleLogService>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(FleetVehicleLogService), input }
        });
    }

    public virtual async Task<FleetVehicleLogService> UpdateAsync(Guid id, FleetVehicleLogService input)
    {
        return await RequestAsync<FleetVehicleLogService>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(FleetVehicleLogService), input }
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
