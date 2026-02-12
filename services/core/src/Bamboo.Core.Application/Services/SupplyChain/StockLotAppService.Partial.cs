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
    public partial class StockLotAppService
    {

        [ApiModel]
        protected async Task<StockLot> AlertDateExceededInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: production_lot.py, METHOD: _alert_date_exceeded) ---
            */
            return default;
        }

        protected async Task<StockLot> ChangeStandardPriceInternalAsync(object old_price)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_lot.py, METHOD: _change_standard_price) ---
            */
            return default;
        }

        protected async Task<StockLot> CheckCreateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_lot.py, METHOD: _check_create) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_lot.py, METHOD: _check_create) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _check_create) ---
            */
            return default;
        }

        protected async Task<StockLot> CheckUniqueLotInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _check_unique_lot) ---
            */
            return default;
        }

        protected async Task<StockLot> ComputeAvgCostInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_lot.py, METHOD: _compute_avg_cost) ---
            */
            return default;
        }

        protected async Task<StockLot> ComputeCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        protected async Task<StockLot> ComputeDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: production_lot.py, METHOD: _compute_dates) ---
            */
            return default;
        }

        protected async Task<StockLot> ComputeDeliveryIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _compute_delivery_ids) ---
            */
            return default;
        }

        protected async Task<StockLot> ComputeDisplayCompleteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _compute_display_complete) ---
            */
            return default;
        }

        protected async Task<StockLot> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: production_lot.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<StockLot> ComputeExpirationDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: production_lot.py, METHOD: _compute_expiration_date) ---
            */
            return default;
        }

        protected async Task<StockLot> ComputeInRepairCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_lot.py, METHOD: _compute_in_repair_count) ---
            */
            return default;
        }

        protected async Task<StockLot> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _compute_name) ---
            */
            return default;
        }

        protected async Task<StockLot> ComputePartnerIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _compute_partner_ids) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py, METHOD: _compute_partner_ids) ---
            */
            return default;
        }

        protected async Task<StockLot> ComputeProductExpiryAlertInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: production_lot.py, METHOD: _compute_product_expiry_alert) ---
            */
            return default;
        }

        protected async Task<StockLot> ComputePurchaseOrderIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: _compute_purchase_order_ids) ---
            */
            return default;
        }

        protected async Task<StockLot> ComputeRepairLineIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_lot.py, METHOD: _compute_repair_line_ids) ---
            */
            return default;
        }

        protected async Task<StockLot> ComputeRepairedCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_lot.py, METHOD: _compute_repaired_count) ---
            */
            return default;
        }

        protected async Task<StockLot> ComputeSaleOrderIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: _compute_sale_order_ids) ---
            */
            return default;
        }

        protected async Task<StockLot> ComputeSingleLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _compute_single_location) ---
            */
            return default;
        }

        protected async Task<StockLot> ComputeValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_lot.py, METHOD: _compute_value) ---
            */
            return default;
        }

        protected async Task<StockLot> FindDeliveryIdsByLotInternalAsync(object lot_path, object delivery_by_lot)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _find_delivery_ids_by_lot) ---
            */
            return default;
        }

        protected async Task<StockLot> FindDeliveryIdsByLotIterativeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _find_delivery_ids_by_lot_iterative) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<StockLot> GetNextSerialInternalAsync(object company, object product)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _get_next_serial) ---
            */
            return default;
        }

        protected async Task<StockLot> GetOutgoingDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _get_outgoing_domain) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock.py, METHOD: _get_outgoing_domain) ---
            */
            return default;
        }

        protected async Task<StockLot> ProductQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _product_qty) ---
            */
            return default;
        }

        protected async Task<StockLot> ReadGroupLocationIdInternalAsync(object locations, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _read_group_location_id) ---
            */
            return default;
        }

        protected async Task<StockLot> SearchPartnerIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _search_partner_ids) ---
            */
            return default;
        }

        protected async Task<StockLot> SearchProductQtyInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _search_product_qty) ---
            */
            return default;
        }

        protected async Task<StockLot> SetSingleLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _set_single_location) ---
            */
            return default;
        }

        protected async Task<StockLot> UpdateStandardPriceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_lot.py, METHOD: _update_standard_price) ---
            */
            return default;
        }
    }
}