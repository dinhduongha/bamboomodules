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
    public partial class StockValuationLayerAppService
    {

        protected async Task<StockValuationLayer> CandidateSortKeyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: stock_valuation_layer.py, METHOD: _candidate_sort_key) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py, METHOD: _candidate_sort_key) ---
            */
            return default;
        }

        protected async Task<StockValuationLayer> ChangeStandartPriceAccountingEntriesInternalAsync(object new_price)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py, METHOD: _change_standart_price_accounting_entries) ---
            */
            return default;
        }

        protected async Task<StockValuationLayer> ComputeWarehouseIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py, METHOD: _compute_warehouse_id) ---
            */
            return default;
        }

        protected async Task<StockValuationLayer> ConsumeAllInternalAsync(object qty_valued, object valued, object qty_to_value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py, METHOD: _consume_all) ---
            */
            return default;
        }

        protected async Task<StockValuationLayer> ConsumeSpecificQtyInternalAsync(object qty_valued, object qty_to_value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py, METHOD: _consume_specific_qty) ---
            */
            return default;
        }

        protected async Task<StockValuationLayer> GetLayerPriceUnitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: stock_valuation_layer.py, METHOD: _get_layer_price_unit) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_valuation_layer.py, METHOD: _get_layer_price_unit) ---
            */
            return default;
        }

        protected async Task<StockValuationLayer> SearchWarehouseIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py, METHOD: _search_warehouse_id) ---
            */
            return default;
        }

        protected async Task<StockValuationLayer> ShouldImpactPriceUnitReceiptValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py, METHOD: _should_impact_price_unit_receipt_value) ---
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_valuation_layer.py, METHOD: _should_impact_price_unit_receipt_value) ---
            */
            return default;
        }

        protected async Task<StockValuationLayer> ValidateAccountingEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py, METHOD: _validate_accounting_entries) ---
            */
            return default;
        }

        protected async Task<StockValuationLayer> ValidateAnalyticAccountingEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py, METHOD: _validate_analytic_accounting_entries) ---
            */
            return default;
        }
    }
}