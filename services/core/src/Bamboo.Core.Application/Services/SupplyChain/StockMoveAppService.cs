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
    public partial class StockMoveAppService : GenericAppService<StockMove>, IStockMoveAppService
    {

        public StockMoveAppService(IRepository<StockMove, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<StockMove> AddFromCatalogByproductAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: action_add_from_catalog_byproduct) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockMove> AddFromCatalogRawAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: action_add_from_catalog_raw) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockMove> AddFromCatalogRepairAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: action_add_from_catalog_repair) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockMove> AddPackagesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: action_add_packages) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockMove> AdjustValuationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: action_adjust_valuation) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockMove> CopyDataAsync(StockMoveCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<StockMove> CreateAsync(CreateRequestDto<StockMove> input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public override async Task<StockMove> DefaultGetAsync(DefaultGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: default_get) ---
            */
            return await base.DefaultGetAsync(input);
        }

        public async Task<StockMove> ExplodeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: action_explode) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<StockMove> GenerateLotLineValsAsync(StockMoveGenerateLotLineValsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: stock_move.py, METHOD: action_generate_lot_line_vals) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: action_generate_lot_line_vals) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockMove> OpenReferenceAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: action_open_reference) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: action_open_reference) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockMove> ProductForecastReportAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: action_product_forecast_report) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockMove> SearchRemainingQtyAsync(StockMoveSearchRemainingQtyRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move.py, METHOD: search_remaining_qty) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockMove> ShowDetailsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: action_show_details) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: action_show_details) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: action_show_details) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: action_show_details) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move.py, METHOD: action_show_details) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockMove> ShowSubcontractDetailsAsync(StockMoveShowSubcontractDetailsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: action_show_subcontract_details) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<StockMove> SplitLotsAsync(StockMoveSplitLotsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: split_lots) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<StockMove> input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: repair, FILE: stock_move.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}