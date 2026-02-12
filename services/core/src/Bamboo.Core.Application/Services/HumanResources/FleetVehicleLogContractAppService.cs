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
    public partial class FleetVehicleLogContractAppService : GenericAppService<FleetVehicleLogContract>, IFleetVehicleLogContractAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public FleetVehicleLogContractAppService(IRepository<FleetVehicleLogContract, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<FleetVehicleLogContract> CloseAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: action_close) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<FleetVehicleLogContract> ComputeNextYearDateAsync(FleetVehicleLogContractComputeNextYearDateRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: compute_next_year_date) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<FleetVehicleLogContract> DraftAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: action_draft) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<FleetVehicleLogContract> ExpireAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: action_expire) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<FleetVehicleLogContract> OpenAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: action_open) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<FleetVehicleLogContract> OpenEmployeeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle_log_contract.py, METHOD: action_open_employee) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<FleetVehicleLogContract> RunSchedulerAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: run_scheduler) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<FleetVehicleLogContract> SchedulerManageContractExpirationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: scheduler_manage_contract_expiration) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}