using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;

namespace Bamboo.Core.Application.Services
{
    [Module("Stock", Depends = new[] { "product", "barcodes_gs1_nomenclature", "digest" })]
    public class StockRouteAppService : GenericApplicationService<StockRoute>, IStockRouteAppService
    {

        public StockRouteAppService(IRepository<StockRoute, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
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

        public async Task<StockRoute> ToggleActiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_location.py) ---
            // def toggle_active(self):
            // for route in self:
            //     route.with_context(active_test=False).rule_ids.sudo().filtered(lambda ru: ru.location_dest_id.active and ru.active == route.active).toggle_active()
            // super().toggle_active()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}