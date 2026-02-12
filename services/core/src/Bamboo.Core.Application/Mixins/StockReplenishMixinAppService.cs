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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("stock", Category = "SupplyChain", Depends = new[] { "product", "barcodes_gs1_nomenclature", "digest" })]
    public partial class StockReplenishMixinAppService : ApplicationService, IStockReplenishMixinAppService
    {

        public StockReplenishMixinAppService() 
        {

        }

        public async Task<TEntity> ComputeAllowedRouteIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IStockReplenishMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_replenish_mixin.py, METHOD: _compute_allowed_route_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowBomInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IStockReplenishMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_replenish_mixin.py, METHOD: _compute_show_bom) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowVendorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IStockReplenishMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_replenish_mixin.py, METHOD: _compute_show_vendor) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllowedRouteDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IStockReplenishMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_replenish_mixin.py, METHOD: _get_allowed_route_domain) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_replenish_mixin.py, METHOD: _get_allowed_route_domain) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: stock_replenish_mixin.py, METHOD: _get_allowed_route_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetShowBomInternalAsync<TEntity>(IEnumerable<TEntity> entities, object route) where TEntity : IEntity<Guid>, IStockReplenishMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_replenish_mixin.py, METHOD: _get_show_bom) ---
            */
            return default;
        }

        public async Task<TEntity> GetShowVendorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object route) where TEntity : IEntity<Guid>, IStockReplenishMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock_replenish_mixin.py, METHOD: _get_show_vendor) ---
            */
            return default;
        }
    }
}