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
    public partial class StockScrapAppService
    {

        protected async Task<StockScrap> ComputeAllowedUomIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: _compute_allowed_uom_ids) ---
            */
            return default;
        }

        protected async Task<StockScrap> ComputeLocationIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_scrap.py, METHOD: _compute_location_id) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: _compute_location_id) ---
            */
            return default;
        }

        protected async Task<StockScrap> ComputeProductUomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: _compute_product_uom_id) ---
            */
            return default;
        }

        protected async Task<StockScrap> ComputeScrapLocationIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: _compute_scrap_location_id) ---
            */
            return default;
        }

        protected async Task<StockScrap> ComputeScrapQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_scrap.py, METHOD: _compute_scrap_qty) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: _compute_scrap_qty) ---
            */
            return default;
        }

        protected async Task<StockScrap> OnchangeProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_scrap.py, METHOD: _onchange_product_id) ---
            */
            return default;
        }

        protected async Task<StockScrap> OnchangeSerialNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_scrap.py, METHOD: _onchange_serial_number) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: _onchange_serial_number) ---
            */
            return default;
        }

        protected async Task<StockScrap> PrepareMoveValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_scrap.py, METHOD: _prepare_move_values) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: _prepare_move_values) ---
            */
            return default;
        }

        protected async Task<StockScrap> ShouldCheckAvailableQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_scrap.py, METHOD: _should_check_available_qty) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: _should_check_available_qty) ---
            */
            return default;
        }

        protected async Task<StockScrap> UnlinkExceptDoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: _unlink_except_done) ---
            */
            return default;
        }
    }
}