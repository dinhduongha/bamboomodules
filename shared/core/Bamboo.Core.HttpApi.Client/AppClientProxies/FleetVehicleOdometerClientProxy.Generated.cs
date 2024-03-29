
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
[ExposeServices(typeof(IFleetVehicleOdometerAppService), typeof(FleetVehicleOdometerClientProxy))]
public partial class FleetVehicleOdometerClientProxy : ClientProxyBase<IFleetVehicleOdometerAppService>, IFleetVehicleOdometerAppService
{
    //public virtual async Task<ListResultDto<FleetVehicleOdometer>> GetAllListAsync()
    //{
    //    return await RequestAsync<ListResultDto<FleetVehicleOdometer>>(nameof(GetAllListAsync));
    //}

    public virtual async Task<PagedResultDto<FleetVehicleOdometer>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        return await RequestAsync<PagedResultDto<FleetVehicleOdometer>>(nameof(GetListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(PagedAndSortedResultRequestDto), input }
        });
    }

    public virtual async Task<FleetVehicleOdometer> GetAsync(Guid id)
    {
        return await RequestAsync<FleetVehicleOdometer>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id }
        });
    }

    public virtual async Task<FleetVehicleOdometer> CreateAsync(FleetVehicleOdometer input)
    {
        return await RequestAsync<FleetVehicleOdometer>(nameof(CreateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(FleetVehicleOdometer), input }
        });
    }

    public virtual async Task<FleetVehicleOdometer> UpdateAsync(Guid id, FleetVehicleOdometer input)
    {
        return await RequestAsync<FleetVehicleOdometer>(nameof(UpdateAsync), new ClientProxyRequestTypeValue
        {
            { typeof(Guid), id },
            { typeof(FleetVehicleOdometer), input }
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
