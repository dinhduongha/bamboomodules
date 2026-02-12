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
    [Module("StockLandedCosts", Category = "SupplyChain", Depends = new[] { "stock_account", "purchase_stock" })]
    public partial class StockLandedCostAppService : GenericAppService<StockLandedCost>, IStockLandedCostAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public StockLandedCostAppService(IRepository<StockLandedCost, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<StockLandedCost> ButtonCancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: button_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockLandedCost> ButtonValidateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: button_validate) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockLandedCost> ComputeLandedCostAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: compute_landed_cost) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockLandedCost> GetValuationLinesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: get_valuation_lines) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}