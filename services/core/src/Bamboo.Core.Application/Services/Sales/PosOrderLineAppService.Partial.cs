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
    public partial class PosOrderLineAppService
    {

        protected async Task<PosOrderLine> ComputeAmountLineAllInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_amount_line_all) ---
            */
            return default;
        }

        protected async Task<PosOrderLine> ComputeMarginInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_margin) ---
            */
            return default;
        }

        protected async Task<PosOrderLine> ComputeQtyDeliveredInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py, METHOD: _compute_qty_delivered) ---
            */
            return default;
        }

        protected async Task<PosOrderLine> ComputeRefundQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_refund_qty) ---
            */
            return default;
        }

        protected async Task<PosOrderLine> ComputeTotalCostInternalAsync(object stock_moves)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_total_cost) ---
            */
            return default;
        }

        protected async Task<PosOrderLine> GetDiscountAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_discount_amount) ---
            */
            return default;
        }

        protected async Task<PosOrderLine> GetStockMovesToConsiderInternalAsync(object stock_moves, object product)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_stock_moves_to_consider) ---
            --- METHOD SOURCE (MODULE: pos_mrp, FILE: pos_order.py, METHOD: _get_stock_moves_to_consider) ---
            */
            return default;
        }

        protected async Task<PosOrderLine> GetTaxIdsAfterFiscalPositionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_tax_ids_after_fiscal_position) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosOrderLine> IsFieldAcceptedInternalAsync(object field)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _is_field_accepted) ---
            */
            return default;
        }

        protected async Task<PosOrderLine> IsProductStorableFifoAvcoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _is_product_storable_fifo_avco) ---
            */
            return default;
        }

        protected async Task<PosOrderLine> LaunchStockRuleFromPosOrderLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _launch_stock_rule_from_pos_order_lines) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py, METHOD: _launch_stock_rule_from_pos_order_lines) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosOrderLine> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosOrderLine> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_event, FILE: pos_order_line.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_order_line.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_order_line.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<PosOrderLine> OnchangeAmountLineAllInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _onchange_amount_line_all) ---
            */
            return default;
        }

        protected async Task<PosOrderLine> OnchangeProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _onchange_product_id) ---
            */
            return default;
        }

        protected async Task<PosOrderLine> OnchangeQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _onchange_qty) ---
            */
            return default;
        }

        protected async Task<PosOrderLine> PrepareBaseLineForTaxesComputationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_base_line_for_taxes_computation) ---
            */
            return default;
        }

        protected async Task<PosOrderLine> PrepareProcurementValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_procurement_values) ---
            */
            return default;
        }

        protected async Task<PosOrderLine> PrepareReferenceValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_reference_vals) ---
            */
            return default;
        }

        protected async Task<PosOrderLine> PrepareRefundDataInternalAsync(object refund_order, object PosPackOperationLot)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_refund_data) ---
            */
            return default;
        }

        protected async Task<PosOrderLine> PrepareTaxBaseLineValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_tax_base_line_values) ---
            */
            return default;
        }

        protected async Task<PosOrderLine> UnlinkExceptOrderStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _unlink_except_order_state) ---
            */
            return default;
        }
    }
}