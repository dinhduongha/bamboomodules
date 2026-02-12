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
    public partial class StockMoveLineAppService : GenericAppService<StockMoveLine>, IStockMoveLineAppService
    {

        public StockMoveLineAppService(IRepository<StockMoveLine, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public override async Task<StockMoveLine> CreateAsync(CreateRequestDto<StockMoveLine> input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move_line.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move_line.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move_line.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<StockMoveLine> GetMoveLineQuantMatchAsync(StockMoveLineGetMoveLineQuantMatchRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: get_move_line_quant_match) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockMoveLine> OpenAddToWaveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_move_line.py, METHOD: action_open_add_to_wave) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockMoveLine> OpenReferenceAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: action_open_reference) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockMoveLine> PutInPackAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: action_put_in_pack) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockMoveLine> RevertInventoryAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: action_revert_inventory) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move_line.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<StockMoveLine> input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_move_line.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_move_line.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_move_line.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_move_line.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}