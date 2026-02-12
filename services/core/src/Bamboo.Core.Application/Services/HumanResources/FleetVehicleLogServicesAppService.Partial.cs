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
    public partial class FleetVehicleLogServicesAppService
    {

        protected async Task<FleetVehicleLogServices> ComputeAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_fleet, FILE: fleet_vehicle_log_services.py, METHOD: _compute_amount) ---
            */
            return default;
        }

        protected async Task<FleetVehicleLogServices> ComputePurchaserEmployeeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle_log_services.py, METHOD: _compute_purchaser_employee_id) ---
            */
            return default;
        }

        protected async Task<FleetVehicleLogServices> ComputePurchaserIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_services.py, METHOD: _compute_purchaser_id) ---
            --- METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle_log_services.py, METHOD: _compute_purchaser_id) ---
            */
            return default;
        }

        protected async Task<FleetVehicleLogServices> ComputeVehicleIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_fleet, FILE: fleet_vehicle_log_services.py, METHOD: _compute_vehicle_id) ---
            */
            return default;
        }

        protected async Task<FleetVehicleLogServices> GetOdometerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_services.py, METHOD: _get_odometer) ---
            */
            return default;
        }

        protected async Task<FleetVehicleLogServices> InverseAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_fleet, FILE: fleet_vehicle_log_services.py, METHOD: _inverse_amount) ---
            */
            return default;
        }

        protected async Task<FleetVehicleLogServices> SetOdometerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_services.py, METHOD: _set_odometer) ---
            */
            return default;
        }

        protected async Task<FleetVehicleLogServices> UnlinkIfNoLinkedBillInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_fleet, FILE: fleet_vehicle_log_services.py, METHOD: _unlink_if_no_linked_bill) ---
            */
            return default;
        }
    }
}