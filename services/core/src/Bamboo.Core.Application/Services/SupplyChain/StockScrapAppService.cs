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
    public partial class StockScrapAppService : GenericAppService<StockScrap>, IStockScrapAppService
    {
        protected readonly IMailThreadAppService _mailThreadAppService;
        public StockScrapAppService(IRepository<StockScrap, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<StockScrap> CheckAvailableQtyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: check_available_qty) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockScrap> DoReplenishAsync(StockScrapDoReplenishRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_scrap.py, METHOD: do_replenish) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: do_replenish) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockScrap> DoScrapAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: do_scrap) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockScrap> GetStockMoveLinesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: action_get_stock_move_lines) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockScrap> GetStockPickingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: action_get_stock_picking) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockScrap> ValidateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: action_validate) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}