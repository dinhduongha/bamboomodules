using Volo.Abp.ObjectMapping;
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
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("StockLandedCosts", Category = "SupplyChain", Depends = new[] { "stock_account", "purchase_stock" })]
    public partial class StockLandedCostLinesAppService : GenericAppService<StockLandedCostLines>, IStockLandedCostLinesAppService
    {

        public StockLandedCostLinesAppService(IRepository<StockLandedCostLines, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        public async Task<StockLandedCostLines> OnchangeProductIdAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py) ---
            // def onchange_product_id(self):
            // self.name = self.product_id.name or ''
            // self.split_method = self.product_id.product_tmpl_id.split_method_landed_cost or self.split_method or 'equal'
            // self.price_unit = self.product_id.standard_price or 0.0
            // accounts_data = self.product_id.product_tmpl_id.get_product_accounts()
            // self.account_id = accounts_data['expense']
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}