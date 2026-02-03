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
    public interface IFleetVehicleAppService : IGenericApplicationService<FleetVehicle>
    {
        Task<FleetVehicle> AcceptDriverChangeAsync(Guid[] ids);
        Task<FleetVehicle> ActShowLogCostAsync(Guid[] ids);
        Task<FleetVehicle> CreateDriverHistoryAsync(FleetVehicleCreateDriverHistoryRequestDto input);
        Task<FleetVehicle> OpenAssignationLogsAsync(Guid[] ids);
        Task<FleetVehicle> OpenEmployeeAsync(Guid[] ids);
        Task<FleetVehicle> OpenOdometerReportAsync(Guid[] ids);
        Task<FleetVehicle> ReturnToOpenAsync(Guid[] ids);
        Task<FleetVehicle> SendEmailAsync(Guid[] ids);
        Task<FleetVehicle> ViewBillsAsync(Guid[] ids);
    }
}