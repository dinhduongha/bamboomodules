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
    public partial class StockPickingTypeAppService : GenericAppService<StockPickingType>, IStockPickingTypeAppService
    {
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public StockPickingTypeAppService(IRepository<StockPickingType, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<StockPickingType> BatchAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: action_batch) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingType> CopyDataAsync(StockPickingTypeCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingType> GetMrpStockPickingPickingTypeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_picking.py, METHOD: get_mrp_stock_picking_action_picking_type) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingType> GetPickingTreeBackorderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: get_action_picking_tree_backorder) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingType> GetPickingTreeLateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: get_action_picking_tree_late) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingType> GetPickingTreeReadyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: get_action_picking_tree_ready) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingType> GetPickingTreeWaitingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: get_action_picking_tree_waiting) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingType> GetPickingTypeMovesAnalysisAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: get_action_picking_type_moves_analysis) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingType> GetPickingTypeReadyMovesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: get_action_picking_type_ready_moves) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingType> GetRepairStockPickingPickingTypeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_picking.py, METHOD: get_repair_stock_picking_action_picking_type) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingType> GetStockPickingPickingTypeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: get_stock_picking_action_picking_type) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<StockPickingType> RedirectToBarcodeInstallationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_redirect_to_barcode_installation) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockPickingType> WaveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking.py, METHOD: action_wave) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}