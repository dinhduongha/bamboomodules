using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("StockLandedCosts", Depends = new[] { "stock_account", "purchase_stock" })]
    public class StockLandedCostLinesAppService : GenericApplicationService<StockLandedCostLines>, IStockLandedCostLinesAppService
    {

        public StockLandedCostLinesAppService(IRepository<StockLandedCostLines, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<StockLandedCostLines> OnchangeProductIdAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py) ---
            // def onchange_product_id(self):
            // self.name = self.product_id.name or ''
            // self.split_method = self.product_id.product_tmpl_id.split_method_landed_cost or self.split_method or 'equal'
            // self.price_unit = self.product_id.standard_price or 0.0
            // accounts_data = self.product_id.product_tmpl_id.get_product_accounts()
            // self.account_id = accounts_data['stock_input']
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}