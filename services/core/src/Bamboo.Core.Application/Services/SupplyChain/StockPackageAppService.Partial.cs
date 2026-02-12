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
    public partial class StockPackageAppService
    {

        protected async Task<StockPackage> ApplyDestToPackageInternalAsync(List<Guid> processed_package_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _apply_dest_to_package) ---
            */
            return default;
        }

        protected async Task<StockPackage> ApplyPackageDestForEntirePacksInternalAsync(List<Guid> allowed_package_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _apply_package_dest_for_entire_packs) ---
            */
            return default;
        }

        protected async Task<StockPackage> CheckMoveLinesMapQuantInternalAsync(object move_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _check_move_lines_map_quant) ---
            */
            return default;
        }

        protected async Task<StockPackage> ComputeAllChildrenPackageIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _compute_all_children_package_ids) ---
            */
            return default;
        }

        protected async Task<StockPackage> ComputeCompleteNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _compute_complete_name) ---
            */
            return default;
        }

        protected async Task<StockPackage> ComputeContainedQuantIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _compute_contained_quant_ids) ---
            */
            return default;
        }

        protected async Task<StockPackage> ComputeContentDescriptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _compute_content_description) ---
            */
            return default;
        }

        protected async Task<StockPackage> ComputeDestCompleteNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _compute_dest_complete_name) ---
            */
            return default;
        }

        protected async Task<StockPackage> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<StockPackage> ComputeJsonPopoverInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _compute_json_popover) ---
            */
            return default;
        }

        protected async Task<StockPackage> ComputeLocationDestIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _compute_location_dest_id) ---
            */
            return default;
        }

        protected async Task<StockPackage> ComputeMoveLineIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _compute_move_line_ids) ---
            */
            return default;
        }

        protected async Task<StockPackage> ComputeOutermostPackageIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _compute_outermost_package_id) ---
            */
            return default;
        }

        protected async Task<StockPackage> ComputeOwnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _compute_owner_id) ---
            */
            return default;
        }

        protected async Task<StockPackage> ComputePackageInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _compute_package_info) ---
            */
            return default;
        }

        protected async Task<StockPackage> ComputePickingIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _compute_picking_ids) ---
            */
            return default;
        }

        protected async Task<StockPackage> ComputeValidSsccInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _compute_valid_sscc) ---
            */
            return default;
        }

        protected async Task<StockPackage> ComputeWeightInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_package.py, METHOD: _compute_weight) ---
            */
            return default;
        }

        protected async Task<StockPackage> ComputeWeightIsKgInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_package.py, METHOD: _compute_weight_is_kg) ---
            */
            return default;
        }

        protected async Task<StockPackage> ComputeWeightUomNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_package.py, METHOD: _compute_weight_uom_name) ---
            */
            return default;
        }

        protected async Task<StockPackage> GetAllChildrenPackageDestIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _get_all_children_package_dest_ids) ---
            */
            return default;
        }

        protected async Task<StockPackage> GetAllPackageDestIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _get_all_package_dest_ids) ---
            */
            return default;
        }

        protected async Task<StockPackage> GetDefaultWeightUomInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_package.py, METHOD: _get_default_weight_uom) ---
            */
            return default;
        }

        protected async Task<StockPackage> GetWeightInternalAsync(Guid picking_id)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _get_weight) ---
            */
            return default;
        }

        protected async Task<StockPackage> HasIssuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _has_issues) ---
            */
            return default;
        }

        protected async Task<StockPackage> PostPutInPackHookInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _post_put_in_pack_hook) ---
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_package.py, METHOD: _post_put_in_pack_hook) ---
            */
            return default;
        }

        protected async Task<StockPackage> PrePutInPackHookInternalAsync(Guid package_id, Guid package_type_id, object package_name, object from_package_wizard)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _pre_put_in_pack_hook) ---
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: stock_package.py, METHOD: _pre_put_in_pack_hook) ---
            */
            return default;
        }

        protected async Task<StockPackage> SearchAllChildrenPackageIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _search_all_children_package_ids) ---
            */
            return default;
        }

        protected async Task<StockPackage> SearchContainedQuantIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _search_contained_quant_ids) ---
            */
            return default;
        }

        protected async Task<StockPackage> SearchLocationDestIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _search_location_dest_id) ---
            */
            return default;
        }

        protected async Task<StockPackage> SearchMoveLineIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _search_move_line_ids) ---
            */
            return default;
        }

        protected async Task<StockPackage> SearchOutermostPackageIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _search_outermost_package_id) ---
            */
            return default;
        }

        protected async Task<StockPackage> SearchOwnerInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _search_owner) ---
            */
            return default;
        }

        protected async Task<StockPackage> SearchPickingIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_package.py, METHOD: _search_picking_ids) ---
            */
            return default;
        }
    }
}