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
    public partial class StockWarehouseOrderpointAppService
    {

        protected async Task<StockWarehouseOrderpoint> CheckMinMaxQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _check_min_max_qty) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeAllowedLocationIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _compute_allowed_location_ids) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeAllowedReplenishmentUomIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py, METHOD: _compute_allowed_replenishment_uom_ids) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _compute_allowed_replenishment_uom_ids) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeBomIdPlaceholderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py, METHOD: _compute_bom_id_placeholder) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeDaysToOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py, METHOD: _compute_days_to_order) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _compute_days_to_order) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _compute_days_to_order) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeDeadlineDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py, METHOD: _compute_deadline_date) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _compute_deadline_date) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _compute_deadline_date) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeEffectiveBomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py, METHOD: _compute_effective_bom_id) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeEffectiveRouteIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _compute_effective_route_id) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeEffectiveVendorIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _compute_effective_vendor_id) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeLeadDaysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _compute_lead_days) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _compute_lead_days) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeLocationIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _compute_location_id) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeProductMaxQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _compute_product_max_qty) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _compute_qty) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeQtyToOrderComputedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py, METHOD: _compute_qty_to_order_computed) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _compute_qty_to_order_computed) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _compute_qty_to_order_computed) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeQtyToOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _compute_qty_to_order) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeReplenishmentUomIdPlaceholderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _compute_replenishment_uom_id_placeholder) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeRouteIdPlaceholderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _compute_route_id_placeholder) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeRulesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _compute_rules) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeShowBomInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py, METHOD: _compute_show_bom) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeShowSupplierInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _compute_show_supplier) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeShowSupplyWarningInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py, METHOD: _compute_show_supply_warning) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _compute_show_supply_warning) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _compute_show_supply_warning) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeSupplierIdPlaceholderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _compute_supplier_id_placeholder) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeUnwantedReplenishInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _compute_unwanted_replenish) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ComputeWarehouseIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _compute_warehouse_id) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetDefaultBomInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py, METHOD: _get_default_bom) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetDefaultRouteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py, METHOD: _get_default_route) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _get_default_route) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _get_default_route) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetDefaultRuleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _get_default_rule) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetDefaultSupplierInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _get_default_supplier) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetLeadDaysValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py, METHOD: _get_lead_days_values) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _get_lead_days_values) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _get_lead_days_values) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetMultipleRoundedQtyInternalAsync(object qty_to_order)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _get_multiple_rounded_qty) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetOrderpointActionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _get_orderpoint_action) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetOrderpointLocationsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _get_orderpoint_locations) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetOrderpointProcurementDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _get_orderpoint_procurement_date) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetOrderpointProductsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py, METHOD: _get_orderpoint_products) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _get_orderpoint_products) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockWarehouseOrderpoint> GetOrderpointValuesInternalAsync(object product, object location)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _get_orderpoint_values) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetProductContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _get_product_context) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetQtyToOrderInternalAsync(object qty_in_progress_by_orderpoint)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _get_qty_to_order) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetReplenishmentMultipleAlternativeInternalAsync(object qty_to_order)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py, METHOD: _get_replenishment_multiple_alternative) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _get_replenishment_multiple_alternative) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _get_replenishment_multiple_alternative) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> GetReplenishmentOrderNotificationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py, METHOD: _get_replenishment_order_notification) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _get_replenishment_order_notification) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _get_replenishment_order_notification) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> InverseBomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py, METHOD: _inverse_bom_id) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> InverseQtyToOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _inverse_qty_to_order) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> InverseRouteIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py, METHOD: _inverse_route_id) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _inverse_route_id) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _inverse_route_id) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> InverseSupplierIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _inverse_supplier_id) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> OnchangeProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _onchange_product_id) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> PostProcessSchedulerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py, METHOD: _post_process_scheduler) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _post_process_scheduler) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> PrepareProcurementValuesInternalAsync(object date)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py, METHOD: _prepare_procurement_values) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_orderpoint.py, METHOD: _prepare_procurement_values) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _prepare_procurement_values) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _prepare_procurement_values) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> ProcureOrderpointConfirmInternalAsync(object use_new_cursor, Guid company_id, object raise_user_error)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _procure_orderpoint_confirm) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> QuantityInProgressInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py, METHOD: _quantity_in_progress) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _quantity_in_progress) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _quantity_in_progress) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> SearchAvailableVendorInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _search_available_vendor) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> SearchEffectiveBomIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_orderpoint.py, METHOD: _search_effective_bom_id) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> SearchEffectiveRouteIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _search_effective_route_id) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> SearchEffectiveVendorIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _search_effective_vendor_id) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> SearchQtyToOrderInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _search_qty_to_order) ---
            */
            return default;
        }

        protected async Task<StockWarehouseOrderpoint> UnlinkProcessedOrderpointsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_orderpoint.py, METHOD: _unlink_processed_orderpoints) ---
            */
            return default;
        }
    }
}