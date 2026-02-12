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
    public partial class StockRuleAppService
    {

        protected async Task<StockRule> CheckCompanyConsistencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _check_company_consistency) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> CheckIntercompLocationInternalAsync(object locations)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _check_intercomp_location) ---
            */
            return default;
        }

        protected async Task<StockRule> ComputeActionMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _compute_action_message) ---
            */
            return default;
        }

        protected async Task<StockRule> ComputePickingTypeCodeDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py, METHOD: _compute_picking_type_code_domain) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py, METHOD: _compute_picking_type_code_domain) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _compute_picking_type_code_domain) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py, METHOD: _compute_picking_type_code_domain) ---
            */
            return default;
        }

        protected async Task<StockRule> FilterWarehouseRoutesInternalAsync(object product, object warehouses, object route)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py, METHOD: _filter_warehouse_routes) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py, METHOD: _filter_warehouse_routes) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _filter_warehouse_routes) ---
            */
            return default;
        }

        protected async Task<StockRule> GetCustomMoveFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py, METHOD: _get_custom_move_fields) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _get_custom_move_fields) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _get_custom_move_fields) ---
            */
            return default;
        }

        protected async Task<StockRule> GetDatePlannedInternalAsync(Guid bom_id, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py, METHOD: _get_date_planned) ---
            */
            return default;
        }

        protected async Task<StockRule> GetLeadDaysInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py, METHOD: _get_lead_days) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: stock_rule.py, METHOD: _get_lead_days) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py, METHOD: _get_lead_days) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _get_lead_days) ---
            */
            return default;
        }

        protected async Task<StockRule> GetMatchingBomInternalAsync(Guid product_id, Guid company_id, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py, METHOD: _get_matching_bom) ---
            */
            return default;
        }

        protected async Task<StockRule> GetMatchingSupplierInternalAsync(Guid product_id, object product_qty, object product_uom, Guid company_id, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py, METHOD: _get_matching_supplier) ---
            */
            return default;
        }

        protected async Task<StockRule> GetMessageDictInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py, METHOD: _get_message_dict) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py, METHOD: _get_message_dict) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _get_message_dict) ---
            */
            return default;
        }

        protected async Task<StockRule> GetMessageValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _get_message_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> GetMovesToAssignDomainInternalAsync(Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py, METHOD: _get_moves_to_assign_domain) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _get_moves_to_assign_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> GetOrderpointDomainInternalAsync(Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _get_orderpoint_domain) ---
            */
            return default;
        }

        protected async Task<StockRule> GetPartnerIdInternalAsync(object values, object rule)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py, METHOD: _get_partner_id) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py, METHOD: _get_partner_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> GetProcurementsToMergeGroupbyInternalAsync(object procurement)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py, METHOD: _get_procurements_to_merge_groupby) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py, METHOD: _get_procurements_to_merge_groupby) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> GetProcurementsToMergeInternalAsync(object procurements)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py, METHOD: _get_procurements_to_merge) ---
            */
            return default;
        }

        protected async Task<StockRule> GetPushNewDateInternalAsync(object move)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _get_push_new_date) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> GetPushRuleInternalAsync(Guid product_id, Guid location_dest_id, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _get_push_rule) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> GetRuleDomainInternalAsync(object location, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _get_rule_domain) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py, METHOD: _get_rule_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> GetRuleInternalAsync(Guid product_id, Guid location_id, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _get_rule) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> GetSchedulerTasksToDoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_scheduler_tasks_to_do) ---
            --- METHOD SOURCE (MODULE: product_expiry, FILE: stock_rule.py, METHOD: _get_scheduler_tasks_to_do) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _get_scheduler_tasks_to_do) ---
            */
            return default;
        }

        protected async Task<StockRule> GetStockMoveValuesInternalAsync(Guid product_id, object product_qty, object product_uom, Guid location_dest_id, object name, object origin, Guid company_id, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py, METHOD: _get_stock_move_values) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_rule.py, METHOD: _get_stock_move_values) ---
            --- METHOD SOURCE (MODULE: sale_mrp, FILE: stock_rule.py, METHOD: _get_stock_move_values) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _get_stock_move_values) ---
            */
            return default;
        }

        protected async Task<StockRule> MakeMoGetDomainInternalAsync(object procurement, object bom)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py, METHOD: _make_mo_get_domain) ---
            */
            return default;
        }

        protected async Task<StockRule> MakePoGetDomainInternalAsync(Guid company_id, object values, object partner)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_rule.py, METHOD: _make_po_get_domain) ---
            --- METHOD SOURCE (MODULE: project_purchase_stock, FILE: stock_rule.py, METHOD: _make_po_get_domain) ---
            --- METHOD SOURCE (MODULE: purchase_requisition_stock, FILE: stock.py, METHOD: _make_po_get_domain) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py, METHOD: _make_po_get_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> MergeProcurementsInternalAsync(object procurements_to_merge)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py, METHOD: _merge_procurements) ---
            */
            return default;
        }

        protected async Task<StockRule> NotifyResponsibleInternalAsync(object procurement)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: stock_rule.py, METHOD: _notify_responsible) ---
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: stock_rule.py, METHOD: _notify_responsible) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py, METHOD: _notify_responsible) ---
            --- METHOD SOURCE (MODULE: sale_purchase_stock, FILE: stock_rule.py, METHOD: _notify_responsible) ---
            */
            return default;
        }

        protected async Task<StockRule> OnchangeActionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py, METHOD: _onchange_action) ---
            */
            return default;
        }

        protected async Task<StockRule> OnchangePickingTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _onchange_picking_type) ---
            */
            return default;
        }

        protected async Task<StockRule> OnchangeRouteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _onchange_route) ---
            */
            return default;
        }

        protected async Task<StockRule> PostVendorNotificationInternalAsync(object records_to_notify, object users_to_notify, object product)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py, METHOD: _post_vendor_notification) ---
            */
            return default;
        }

        protected async Task<StockRule> PrepareMoValsInternalAsync(Guid product_id, object product_qty, object product_uom, Guid location_dest_id, object name, object origin, Guid company_id, object values, object bom)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py, METHOD: _prepare_mo_vals) ---
            --- METHOD SOURCE (MODULE: project_mrp, FILE: stock.py, METHOD: _prepare_mo_vals) ---
            --- METHOD SOURCE (MODULE: project_mrp_account, FILE: stock_rule.py, METHOD: _prepare_mo_vals) ---
            --- METHOD SOURCE (MODULE: sale_mrp, FILE: stock_rule.py, METHOD: _prepare_mo_vals) ---
            */
            return default;
        }

        protected async Task<StockRule> PreparePurchaseOrderInternalAsync(Guid company_id, object origins, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_rule.py, METHOD: _prepare_purchase_order) ---
            --- METHOD SOURCE (MODULE: project_purchase_stock, FILE: stock_rule.py, METHOD: _prepare_purchase_order) ---
            --- METHOD SOURCE (MODULE: purchase_requisition_stock, FILE: stock.py, METHOD: _prepare_purchase_order) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py, METHOD: _prepare_purchase_order) ---
            */
            return default;
        }

        protected async Task<StockRule> PushPrepareMoveCopyValuesInternalAsync(object move_to_copy, object new_date)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py, METHOD: _push_prepare_move_copy_values) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_rule.py, METHOD: _push_prepare_move_copy_values) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py, METHOD: _push_prepare_move_copy_values) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _push_prepare_move_copy_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> RunBuyInternalAsync(object procurements)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py, METHOD: _run_buy) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> RunManufactureInternalAsync(object procurements)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py, METHOD: _run_manufacture) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> RunPullInternalAsync(object procurements)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _run_pull) ---
            */
            return default;
        }

        protected async Task<StockRule> RunPushInternalAsync(object move)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _run_push) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> RunSchedulerTasksInternalAsync(object use_new_cursor, Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _run_scheduler_tasks) ---
            --- METHOD SOURCE (MODULE: product_expiry, FILE: stock_rule.py, METHOD: _run_scheduler_tasks) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _run_scheduler_tasks) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> SearchRuleForWarehousesInternalAsync(List<Guid> route_ids, Guid packaging_uom_id, Guid product_id, List<Guid> warehouse_ids, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _search_rule_for_warehouses) ---
            */
            return default;
        }

        protected async Task<StockRule> SearchRuleInternalAsync(List<Guid> route_ids, Guid packaging_uom_id, Guid product_id, Guid warehouse_id, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _search_rule) ---
            */
            return default;
        }

        protected async Task<StockRule> SerializeProcurementValuesInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _serialize_procurement_values) ---
            */
            return default;
        }

        protected async Task<StockRule> ShouldAutoConfirmProcurementMoInternalAsync(object p)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py, METHOD: _should_auto_confirm_procurement_mo) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockRule> SkipProcurementInternalAsync(object procurement)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: _skip_procurement) ---
            */
            return default;
        }

        protected async Task<StockRule> UpdatePurchaseOrderLineInternalAsync(Guid product_id, object product_qty, object product_uom, Guid company_id, object values, object line)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py, METHOD: _update_purchase_order_line) ---
            */
            return default;
        }
    }
}