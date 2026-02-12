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
    public partial class FleetVehicleModelAppService
    {

        protected async Task<FleetVehicleModel> ComputeCo2EmissionUnitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: _compute_co2_emission_unit) ---
            */
            return default;
        }

        protected async Task<FleetVehicleModel> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<FleetVehicleModel> ComputeVehicleCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: _compute_vehicle_count) ---
            */
            return default;
        }

        protected async Task<FleetVehicleModel> GetYearSelectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: _get_year_selection) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<FleetVehicleModel> SearchDisplayNameInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: _search_display_name) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<FleetVehicleModel> SearchVehicleCountInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: _search_vehicle_count) ---
            */
            return default;
        }
    }
}