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
    public partial class PurchaseOrderLineAppService
    {

        protected async Task<PurchaseOrderLine> CheckOrderpointPickingTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _check_orderpoint_picking_type) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeAllowedUomIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_allowed_uom_ids) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_amount) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeAmountToInvoiceAtDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_amount_to_invoice_at_date) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeAnalyticDistributionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_purchase, FILE: purchase_order_line.py, METHOD: _compute_analytic_distribution) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_analytic_distribution) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeForecastedIssueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _compute_forecasted_issue) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeParentIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_parent_id) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputePriceTotalCcInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py, METHOD: _compute_price_total_cc) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputePriceUnitAndDatePlannedAndNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_price_unit_and_date_planned_and_name) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py, METHOD: _compute_price_unit_and_date_planned_and_name) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputePriceUnitDiscountedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_price_unit_discounted) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputePriceUnitProductUomInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_price_unit_product_uom) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeProductUomQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_product_uom_qty) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputePurchaseLineWarnMsgInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_purchase_line_warn_msg) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeQtyInvoicedAtDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_qty_invoiced_at_date) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeQtyInvoicedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_qty_invoiced) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeQtyReceivedAtDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_qty_received_at_date) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeQtyReceivedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_qty_received) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _compute_qty_received) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeQtyReceivedMethodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_qty_received_method) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _compute_qty_received_method) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeSelectedSellerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_selected_seller_id) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ComputeTaxIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_tax_id) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ConvertToMiddleOfDayInternalAsync(object date)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _convert_to_middle_of_day) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> CreateOrUpdatePickingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _create_or_update_picking) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> CreateStockMovesInternalAsync(object picking)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _create_stock_moves) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PurchaseOrderLine> DateInThePastInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _date_in_the_past) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> FindCandidateInternalAsync(Guid product_id, object product_qty, object product_uom, Guid location_id, object name, object origin, Guid company_id, object values)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _find_candidate) ---
            --- METHOD SOURCE (MODULE: sale_purchase_stock, FILE: purchase_order.py, METHOD: _find_candidate) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PurchaseOrderLine> GetDatePlannedInternalAsync(object seller, object po)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _get_date_planned) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetGrossPriceUnitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _get_gross_price_unit) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetInvoiceLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _get_invoice_lines) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetMoveDestsInitialDemandInternalAsync(object move_dests)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: purchase.py, METHOD: _get_move_dests_initial_demand) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _get_move_dests_initial_demand) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetOutgoingIncomingMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _get_outgoing_incoming_moves) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetPoLineMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _get_po_line_moves) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetProductCatalogLinesDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _get_product_catalog_lines_data) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetProductPurchaseDescriptionInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _get_product_purchase_description) ---
            --- METHOD SOURCE (MODULE: purchase_product_matrix, FILE: purchase.py, METHOD: _get_product_purchase_description) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetQtyProcurementInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: purchase.py, METHOD: _get_qty_procurement) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _get_qty_procurement) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetSaleOrderLineProductInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: purchase.py, METHOD: _get_sale_order_line_product) ---
            --- METHOD SOURCE (MODULE: sale_purchase_stock, FILE: purchase_order.py, METHOD: _get_sale_order_line_product) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetSelectSellersParamsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _get_select_sellers_params) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetStockMovePriceUnitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _get_stock_move_price_unit) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> GetUpstreamDocumentsAndResponsiblesInternalAsync(object visited)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: purchase.py, METHOD: _get_upstream_documents_and_responsibles) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> InverseQtyReceivedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _inverse_qty_received) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> IsDropshippedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: purchase.py, METHOD: _is_dropshipped) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> MergePoLineInternalAsync(object rfq_line)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _merge_po_line) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _merge_po_line) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> OndeleteStockMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _ondelete_stock_moves) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> PrepareAccountMoveLineInternalAsync(object move)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _prepare_account_move_line) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _prepare_account_move_line) ---
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: purchase.py, METHOD: _prepare_account_move_line) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PurchaseOrderLine> PrepareAddMissingFieldsInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _prepare_add_missing_fields) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> PrepareBaseLineForTaxesComputationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _prepare_base_line_for_taxes_computation) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PurchaseOrderLine> PreparePurchaseOrderLineFromProcurementInternalAsync(Guid product_id, object product_qty, object product_uom, Guid location_dest_id, object name, object origin, Guid company_id, object values, object po)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _prepare_purchase_order_line_from_procurement) ---
            --- METHOD SOURCE (MODULE: sale_purchase_stock, FILE: purchase_order.py, METHOD: _prepare_purchase_order_line_from_procurement) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PurchaseOrderLine> PreparePurchaseOrderLineInternalAsync(Guid product_id, object product_qty, object product_uom, Guid company_id, Guid partner_id, object po)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _prepare_purchase_order_line) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> PrepareQtyInvoicedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _prepare_qty_invoiced) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> PrepareQtyReceivedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _prepare_qty_received) ---
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: purchase.py, METHOD: _prepare_qty_received) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _prepare_qty_received) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> PrepareStockMoveValsInternalAsync(object picking, object price_unit, object product_uom_qty, object product_uom)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _prepare_stock_move_vals) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> PrepareStockMovesInternalAsync(object picking)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: purchase.py, METHOD: _prepare_stock_moves) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _prepare_stock_moves) ---
            --- METHOD SOURCE (MODULE: sale_purchase_stock, FILE: purchase_order.py, METHOD: _prepare_stock_moves) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ProductIdChangeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _product_id_change) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> SuggestQuantityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _suggest_quantity) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> TrackQtyReceivedInternalAsync(object new_qty)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _track_qty_received) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> UnlinkExceptPurchaseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _unlink_except_purchase) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> UpdateDatePlannedInternalAsync(object updated_date)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _update_date_planned) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _update_date_planned) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> UpdateMoveDateDeadlineInternalAsync(object new_date)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _update_move_date_deadline) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PurchaseOrderLine> UpdateQtyReceivedMethodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order_line.py, METHOD: _update_qty_received_method) ---
            */
            return default;
        }

        protected async Task<PurchaseOrderLine> ValidateAnalyticDistributionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _validate_analytic_distribution) ---
            */
            return default;
        }
    }
}