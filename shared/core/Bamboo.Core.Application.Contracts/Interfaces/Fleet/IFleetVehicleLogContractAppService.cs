using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IFleetVehicleLogContractAppService : IGenericApplicationService<FleetVehicleLogContract>
    {
        Task<FleetVehicleLogContract> CloseAsync(Guid id);
        Task<FleetVehicleLogContract> ComputeNextYearDateAsync(Guid id, FleetVehicleLogContractComputeNextYearDateRequestDto input);
        Task<FleetVehicleLogContract> DraftAsync(Guid id);
        Task<FleetVehicleLogContract> ExpireAsync(Guid id);
        Task<FleetVehicleLogContract> OpenAsync(Guid id);
        Task<FleetVehicleLogContract> OpenEmployeeAsync(Guid id);
        Task<FleetVehicleLogContract> RunSchedulerAsync(Guid id);
        Task<FleetVehicleLogContract> SchedulerManageContractExpirationAsync(Guid id);
    }
}