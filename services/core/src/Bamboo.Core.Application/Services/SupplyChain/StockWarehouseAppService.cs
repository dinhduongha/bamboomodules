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
    public partial class StockWarehouseAppService : GenericAppService<StockWarehouse>, IStockWarehouseAppService
    {

        public StockWarehouseAppService(IRepository<StockWarehouse, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<StockWarehouse> CopyDataAsync(StockWarehouseCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<StockWarehouse> CreateAsync(CreateRequestDto<StockWarehouse> input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_warehouse.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<StockWarehouse> CreateResupplyRoutesAsync(StockWarehouseCreateResupplyRoutesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: create_resupply_routes) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockWarehouse> GetCurrentWarehousesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: get_current_warehouses) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockWarehouse> GetRulesDictAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py, METHOD: get_rules_dict) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py, METHOD: get_rules_dict) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: get_rules_dict) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: get_rules_dict) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockWarehouse> UpdateGlobalRouteDropshipSubcontractorAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_warehouse.py, METHOD: update_global_route_dropship_subcontractor) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<StockWarehouse> ViewAllRoutesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: action_view_all_routes) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<StockWarehouse> input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_warehouse.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: stock_warehouse.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: stock_warehouse.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_warehouse.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}