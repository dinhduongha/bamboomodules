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
        Task<FleetVehicle> AcceptDriverChangeAsync(Guid id);
        Task<FleetVehicle> ActShowLogCostAsync(Guid id);
        Task<FleetVehicle> CreateDriverHistoryAsync(Guid id, FleetVehicleCreateDriverHistoryRequestDto input);
        Task<FleetVehicle> OpenAssignationLogsAsync(Guid id);
        Task<FleetVehicle> OpenEmployeeAsync(Guid id);
        Task<FleetVehicle> OpenOdometerReportAsync(Guid id);
        Task<FleetVehicle> ReturnToOpenAsync(Guid id);
        Task<FleetVehicle> SendEmailAsync(Guid id);
        Task<FleetVehicle> ViewBillsAsync(Guid id);
    }
}