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
    public partial class MaintenanceEquipmentAppService
    {

        protected async Task<MaintenanceEquipment> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<MaintenanceEquipment> ComputeEquipmentAssignInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py, METHOD: _compute_equipment_assign) ---
            */
            return default;
        }

        protected async Task<MaintenanceEquipment> ComputeMatchSerialInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_maintenance, FILE: maintenance.py, METHOD: _compute_match_serial) ---
            */
            return default;
        }

        protected async Task<MaintenanceEquipment> ComputeOwnerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py, METHOD: _compute_owner) ---
            */
            return default;
        }

        protected async Task<MaintenanceEquipment> OnchangeCategoryIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _onchange_category_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MaintenanceEquipment> ReadGroupCategoryIdsInternalAsync(object categories, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _read_group_category_ids) ---
            */
            return default;
        }

        protected async Task<MaintenanceEquipment> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _track_subtype) ---
            */
            return default;
        }
    }
}