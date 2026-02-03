using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IFleetVehicleLogContractAppService : IGenericApplicationService<FleetVehicleLogContract>
    {
        Task<FleetVehicleLogContract> CloseAsync(Guid[] ids);
        Task<FleetVehicleLogContract> ComputeNextYearDateAsync(FleetVehicleLogContractComputeNextYearDateRequestDto input);
        Task<FleetVehicleLogContract> DraftAsync(Guid[] ids);
        Task<FleetVehicleLogContract> ExpireAsync(Guid[] ids);
        Task<FleetVehicleLogContract> OpenAsync(Guid[] ids);
        Task<FleetVehicleLogContract> OpenEmployeeAsync(Guid[] ids);
        Task<FleetVehicleLogContract> RunSchedulerAsync(Guid[] ids);
        Task<FleetVehicleLogContract> SchedulerManageContractExpirationAsync(Guid[] ids);
    }
}