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
    public partial class StockLotAppService : GenericAppService<StockLot>, IStockLotAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public StockLotAppService(IRepository<StockLot, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<StockLot> CopyDataAsync(StockLotCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<StockLot> CreateAsync(CreateRequestDto<StockLot> input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_lot.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public async Task<StockLot> GenerateLotNamesAsync(StockLotGenerateLotNamesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: generate_lot_names) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockLot> LotOpenQuantsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: action_lot_open_quants) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockLot> LotOpenRepairsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_lot.py, METHOD: action_lot_open_repairs) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockLot> LotOpenTransfersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: action_lot_open_transfers) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockLot> ViewPoAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: action_view_po) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockLot> ViewRoAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: stock_lot.py, METHOD: action_view_ro) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockLot> ViewSoAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: stock.py, METHOD: action_view_so) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<StockLot> input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_lot.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}