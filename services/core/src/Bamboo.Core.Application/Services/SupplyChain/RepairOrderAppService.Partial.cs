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
    public partial class RepairOrderAppService
    {

        protected async Task<RepairOrder> ActionRepairConfirmInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _action_repair_confirm) ---
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeAllowedLotIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_allowed_lot_ids) ---
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeAllowedUomIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_allowed_uom_ids) ---
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeAvailabilityBooleanInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_availability_boolean) ---
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeHasUncompleteMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_has_uncomplete_moves) ---
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeLocationIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_location_id) ---
            */
            return default;
        }

        protected async Task<RepairOrder> ComputePartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_partner_id) ---
            */
            return default;
        }

        protected async Task<RepairOrder> ComputePartsAvailabilityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_parts_availability) ---
            */
            return default;
        }

        protected async Task<RepairOrder> ComputePickingProductIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_picking_product_ids) ---
            */
            return default;
        }

        protected async Task<RepairOrder> ComputePickingTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_picking_type_id) ---
            */
            return default;
        }

        protected async Task<RepairOrder> ComputePickingTypeVisibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_picking_type_visible) ---
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeProductLocationDestIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_product_location_dest_id) ---
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeProductLocationSrcIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_product_location_src_id) ---
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeProductQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_product_qty) ---
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeProductionCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_repair, FILE: repair.py, METHOD: _compute_production_count) ---
            */
            return default;
        }

        protected async Task<RepairOrder> ComputePurchaseCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_repair, FILE: repair_order.py, METHOD: _compute_purchase_count) ---
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeRecycleLocationIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_recycle_location_id) ---
            */
            return default;
        }

        protected async Task<RepairOrder> ComputeUnreserveVisibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_unreserve_visible) ---
            */
            return default;
        }

        protected async Task<RepairOrder> DefaultOrderLineValuesInternalAsync(object child_field)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _default_order_line_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<RepairOrder> DefaultPickingTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _default_picking_type_id) ---
            */
            return default;
        }

        protected async Task<RepairOrder> GetActionAddFromCatalogExtraContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_repair, FILE: repair.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            */
            return default;
        }

        protected async Task<RepairOrder> GetLocationInternalAsync(object field)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _get_location) ---
            */
            return default;
        }

        protected async Task<RepairOrder> GetPickingTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _get_picking_type) ---
            */
            return default;
        }

        protected async Task<RepairOrder> GetProductCatalogDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _get_product_catalog_domain) ---
            */
            return default;
        }

        protected async Task<RepairOrder> GetProductCatalogOrderDataInternalAsync(object products)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _get_product_catalog_order_data) ---
            */
            return default;
        }

        protected async Task<RepairOrder> GetProductCatalogRecordLinesInternalAsync(List<Guid> product_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _get_product_catalog_record_lines) ---
            */
            return default;
        }

        protected async Task<RepairOrder> GetProductPriceAndDataInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _get_product_price_and_data) ---
            */
            return default;
        }

        protected async Task<RepairOrder> IsDisplayStockInCatalogInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _is_display_stock_in_catalog) ---
            */
            return default;
        }

        protected async Task<RepairOrder> OnchangeLocationPickingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _onchange_location_picking) ---
            */
            return default;
        }

        protected async Task<RepairOrder> SearchDateCategoryInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _search_date_category) ---
            */
            return default;
        }

        protected async Task<RepairOrder> UnlinkExceptConfirmedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _unlink_except_confirmed) ---
            */
            return default;
        }

        protected async Task<RepairOrder> UpdateOrderLineInfoInternalAsync(Guid product_id, object quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _update_order_line_info) ---
            */
            return default;
        }

        protected async Task<RepairOrder> UpdateSaleOrderLinePriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _update_sale_order_line_price) ---
            */
            return default;
        }
    }
}