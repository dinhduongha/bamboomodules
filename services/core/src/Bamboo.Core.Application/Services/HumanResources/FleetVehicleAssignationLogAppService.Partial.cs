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
    public partial class FleetVehicleAssignationLogAppService
    {

        protected async Task<FleetVehicleAssignationLog> ComputeAttachmentNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle_assignation_log.py, METHOD: _compute_attachment_number) ---
            */
            return default;
        }

        protected async Task<FleetVehicleAssignationLog> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_assignation_log.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<FleetVehicleAssignationLog> ComputeDriverEmployeeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_fleet, FILE: fleet_vehicle_assignation_log.py, METHOD: _compute_driver_employee_id) ---
            */
            return default;
        }
    }
}