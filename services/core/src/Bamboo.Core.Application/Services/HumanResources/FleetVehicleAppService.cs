using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Fleet", Category = "HumanResources", Depends = new[] { "base", "mail" })]
    public partial class FleetVehicleAppService : GenericAppService<FleetVehicle>, IFleetVehicleAppService
    {
        protected readonly IAvatarMixinAppService _avatarMixinAppService;
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public FleetVehicleAppService(IRepository<FleetVehicle, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAvatarMixinAppService avatarMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _avatarMixinAppService = avatarMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<FleetVehicle> AcceptDriverChangeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: action_accept_driver_change) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<FleetVehicle> ActShowLogCostAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: act_show_log_cost) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<FleetVehicle> CreateAsync(CreateRequestDto<FleetVehicle> input)
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<FleetVehicle> CreateDriverHistoryAsync(FleetVehicleCreateDriverHistoryRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: create_driver_history) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<FleetVehicle> OpenAssignationLogsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: open_assignation_logs) ---
            --- METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle.py, METHOD: open_assignation_logs) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<FleetVehicle> OpenEmployeeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle.py, METHOD: action_open_employee) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<FleetVehicle> OpenOdometerReportAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: action_open_odometer_report) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<FleetVehicle> ReturnToOpenAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: return_action_to_open) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<FleetVehicle> SendEmailAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: action_send_email) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<FleetVehicle> ViewBillsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_fleet, FILE: fleet_vehicle.py, METHOD: action_view_bills) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<FleetVehicle> input)
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}