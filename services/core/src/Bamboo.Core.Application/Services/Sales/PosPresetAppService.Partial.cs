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
    public partial class PosPresetAppService
    {

        protected async Task<PosPreset> CanReturnContentInternalAsync(object field_name, object access_token)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_preset.py, METHOD: _can_return_content) ---
            */
            return default;
        }

        protected async Task<PosPreset> CheckSlotsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_preset.py, METHOD: _check_slots) ---
            */
            return default;
        }

        protected async Task<PosPreset> ComputeCountLinkedConfigInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_preset.py, METHOD: _compute_count_linked_config) ---
            */
            return default;
        }

        protected async Task<PosPreset> ComputeCountLinkedOrdersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_preset.py, METHOD: _compute_count_linked_orders) ---
            */
            return default;
        }

        protected async Task<PosPreset> ComputeHasImageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_preset.py, METHOD: _compute_has_image) ---
            */
            return default;
        }

        protected async Task<PosPreset> ComputeSlotsUsageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_preset.py, METHOD: _compute_slots_usage) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosPreset> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_preset.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosPreset> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_preset.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_preset.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_preset.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosPreset> LoadPosSelfDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_preset.py, METHOD: _load_pos_self_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosPreset> LoadPosSelfDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_preset.py, METHOD: _load_pos_self_data_fields) ---
            */
            return default;
        }

        protected async Task<PosPreset> UnlinkExceptMasterPresetsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_preset.py, METHOD: _unlink_except_master_presets) ---
            */
            return default;
        }

        protected async Task<PosPreset> UnlinkExceptUsedPresetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_preset.py, METHOD: _unlink_except_used_preset) ---
            */
            return default;
        }
    }
}