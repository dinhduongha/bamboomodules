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
    [Module("Stock", Category = "SupplyChain", Depends = new[] { "product", "barcodes_gs1_nomenclature", "digest" })]
    public partial class StockQuantAppService : GenericAppService<StockQuant>, IStockQuantAppService
    {

        public StockQuantAppService(IRepository<StockQuant, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<StockQuant> ApplyAllAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: action_apply_all) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockQuant> ApplyInventoryAsync(StockQuantApplyInventoryRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: action_apply_inventory) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockQuant> CheckLocationIdAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: check_location_id) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockQuant> CheckLotIdAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: check_lot_id) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockQuant> CheckProductIdAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: check_product_id) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockQuant> CheckQuantityAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: check_quantity) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockQuant> ClearInventoryQuantityAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: action_clear_inventory_quantity) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockQuant> GetAggregateBarcodesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: get_aggregate_barcodes) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<StockQuant> GetImportTemplatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: get_import_templates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockQuant> InventoryHistoryAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: action_inventory_history) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockQuant> MoveQuantsAsync(StockQuantMoveQuantsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: move_quants) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockQuant> ResetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: action_reset) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockQuant> SetInventoryQuantityAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: action_set_inventory_quantity) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockQuant> SetInventoryQuantityZeroAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: action_set_inventory_quantity_zero) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockQuant> StockQuantRelocateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: action_stock_quant_relocate) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<StockQuant> ViewInventoryAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: action_view_inventory) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockQuant> ViewOrderpointsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: action_view_orderpoints) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<StockQuant> ViewQuantsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: action_view_quants) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockQuant> ViewStockMovesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_quant.py, METHOD: action_view_stock_moves) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}