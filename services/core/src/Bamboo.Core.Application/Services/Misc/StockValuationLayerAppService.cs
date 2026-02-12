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
    [Module("StockAccount", Category = "Misc", Depends = new[] { "stock", "account" })]
    public partial class StockValuationLayerAppService : GenericAppService<StockValuationLayer>, IStockValuationLayerAppService
    {

        public StockValuationLayerAppService(IRepository<StockValuationLayer, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<StockValuationLayer> InitAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py, METHOD: init) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockValuationLayer> OpenJournalEntryAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py, METHOD: action_open_journal_entry) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockValuationLayer> OpenReferenceAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py, METHOD: action_open_reference) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockValuationLayer> ValuationAtDateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: stock_valuation_layer.py, METHOD: action_valuation_at_date) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}