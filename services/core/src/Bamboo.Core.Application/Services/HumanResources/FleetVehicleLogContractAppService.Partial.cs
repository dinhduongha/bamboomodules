using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
    public partial class FleetVehicleLogContractAppService
    {

        protected async Task<FleetVehicleLogContract> ComputeContractNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: _compute_contract_name) ---
            */
            return default;
        }

        protected async Task<FleetVehicleLogContract> ComputeDaysLeftInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: _compute_days_left) ---
            */
            return default;
        }

        protected async Task<FleetVehicleLogContract> ComputeHasOpenContractInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: _compute_has_open_contract) ---
            */
            return default;
        }
    }
}