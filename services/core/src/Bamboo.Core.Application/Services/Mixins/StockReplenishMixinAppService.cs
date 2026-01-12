using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("stock", Category = "SupplyChain", Depends = new[] { "product", "barcodes_gs1_nomenclature", "digest" })]
    public class StockReplenishMixinAppService : ApplicationService, IStockReplenishMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public StockReplenishMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ComputeAllowedRouteIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IStockReplenishMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_replenish_mixin.py) ---
            // def _compute_allowed_route_ids(self):
            // domain = self._get_allowed_route_domain()
            // route_ids = self.env['stock.route'].search(domain)
            // self.allowed_route_ids = route_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeShowBomInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IStockReplenishMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_replenish_mixin.py) ---
            // def _compute_show_bom(self):
            // for rec in self:
            //     rec.show_bom = rec._get_show_bom(rec.route_id)
            */
            return default;
        }

        public async Task<TEntity> ComputeShowVendorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IStockReplenishMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_replenish_mixin.py) ---
            // def _compute_show_vendor(self):
            // for rec in self:
            //     rec.show_vendor = rec._get_show_vendor(rec.route_id)
            */
            return default;
        }

        public async Task<TEntity> GetAllowedRouteDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IStockReplenishMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_replenish_mixin.py) ---
            // def _get_allowed_route_domain(self):
            // domains = super()._get_allowed_route_domain()
            // route_id = self.env['stock.warehouse']._find_or_create_global_route('mrp_subcontracting.route_resupply_subcontractor_mto', _('Resupply Subcontractor on Order')).id
            // return expression.AND([domains, [('id', '!=', route_id)]])
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_replenish_mixin.py) ---
            // def _get_allowed_route_domain(self):
            // domains = super()._get_allowed_route_domain()
            // return expression.AND([domains, [('id', '!=', self.env.ref('mrp_subcontracting_dropshipping.route_subcontracting_dropshipping', raise_if_not_found=False).id)]])
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_replenish_mixin.py) ---
            // def _get_allowed_route_domain(self):
            // stock_location_inter_company_id = self.env.ref('stock.stock_location_inter_company').id
            // return [
            //     ('product_selectable', '=', True),
            //     ('rule_ids.location_src_id', '!=', stock_location_inter_company_id),
            //     ('rule_ids.location_dest_id', '!=', stock_location_inter_company_id)
            // ]
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock_replenish_mixin.py) ---
            // def _get_allowed_route_domain(self):
            // domains = super()._get_allowed_route_domain()
            // return expression.AND([domains, [('id', '!=', self.env.ref('stock_dropshipping.route_drop_shipping', raise_if_not_found=False).id)]])
            */
            return default;
        }

        public async Task<TEntity> GetShowBomInternalAsync<TEntity>(IEnumerable<TEntity> entities, object route) where TEntity : IEntity<Guid>, IStockReplenishMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: stock_replenish_mixin.py) ---
            // def _get_show_bom(self, route):
            // return any(r.action == 'manufacture' for r in route.rule_ids)
            */
            return default;
        }

        public async Task<TEntity> GetShowVendorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object route) where TEntity : IEntity<Guid>, IStockReplenishMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: purchase_stock, FILE: stock_replenish_mixin.py) ---
            // def _get_show_vendor(self, route):
            // return any(r.action == 'buy' for r in route.rule_ids)
            */
            return default;
        }
    }
}