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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Stock", Category = "SupplyChain", Depends = new[] { "product", "barcodes_gs1_nomenclature", "digest" })]
    public partial class StockRouteAppService : GenericApplicationService<StockRoute>, IStockRouteAppService
    {

        public StockRouteAppService(IRepository<StockRoute, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<StockRoute> CheckCompanyConsistencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _check_company_consistency(self):
            // for route in self:
            //     if not route.company_id:
            //         continue
            // 
            //     for rule in route.rule_ids:
            //         if route.company_id.id != rule.company_id.id:
            //             raise ValidationError(_(
            //                 "Rule %(rule)s belongs to %(rule_company)s while the route belongs to %(route_company)s.",
            //                 rule=rule.display_name,
            //                 rule_company=rule.company_id.display_name,
            //                 route_company=route.company_id.display_name,
            //             ))
            */
            return default;
        }

        protected async Task<StockRoute> ComputeWarehousesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _compute_warehouses(self):
            // for loc in self:
            //     domain = [('company_id', '=', loc.company_id.id)] if loc.company_id else []
            //     loc.warehouse_domain_ids = self.env['stock.warehouse'].search(domain)
            */
            return default;
        }

        public async Task<StockRoute> CopyDataAsync(Guid id, StockRouteCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // if 'name' not in default:
            //     for route, vals in zip(self, vals_list):
            //         vals['name'] = _("%s (copy)", route.name)
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockRoute> IsValidResupplyRouteForProductInternalAsync(object product)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py) ---
            // def _is_valid_resupply_route_for_product(self, product):
            // if any(rule.action == 'manufacture' for rule in self.rule_ids):
            //     return any(bom.type == 'normal' for bom in product.bom_ids)
            // return super()._is_valid_resupply_route_for_product(product)
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_rule.py) ---
            // def _is_valid_resupply_route_for_product(self, product):
            // if any(rule.action == 'buy' for rule in self.rule_ids):
            //     return bool(product.seller_ids)
            // return super()._is_valid_resupply_route_for_product(product)
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _is_valid_resupply_route_for_product(self, product):
            // return False
            */
            return default;
        }

        protected async Task<StockRoute> OnchangeCompanyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _onchange_company(self):
            // if self.company_id:
            //     self.warehouse_ids = self.warehouse_ids.filtered(lambda w: w.company_id == self.company_id)
            */
            return default;
        }

        protected async Task<StockRoute> OnchangeWarehouseSelectableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def _onchange_warehouse_selectable(self):
            // if not self.warehouse_selectable:
            //     self.warehouse_ids = [(5, 0, 0)]
            */
            return default;
        }
    }
}