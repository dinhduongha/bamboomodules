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
    [Module("Stock", Category = "SupplyChain", Depends = new[] { "product", "barcodes_gs1_nomenclature", "digest" })]
    public partial class StockStorageCategoryAppService : GenericApplicationService<StockStorageCategory>, IStockStorageCategoryAppService
    {

        public StockStorageCategoryAppService(IRepository<StockStorageCategory, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<StockStorageCategory> ComputeStorageCapacityIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_storage_category.py) ---
            // def _compute_storage_capacity_ids(self):
            // for storage_category in self:
            //     storage_category.product_capacity_ids = storage_category.capacity_ids.filtered(lambda c: c.product_id)
            //     storage_category.package_capacity_ids = storage_category.capacity_ids.filtered(lambda c: c.package_type_id)
            */
            return default;
        }

        protected async Task<StockStorageCategory> ComputeWeightUomNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_storage_category.py) ---
            // def _compute_weight_uom_name(self):
            // self.weight_uom_name = self.env['product.template']._get_weight_uom_name_from_ir_config_parameter()
            */
            return default;
        }

        public async Task<StockStorageCategory> CopyDataAsync(Guid id, StockStorageCategoryCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_storage_category.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", category.name)) for category, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<StockStorageCategory> SetStorageCapacityIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: stock_storage_category.py) ---
            // def _set_storage_capacity_ids(self):
            // for storage_category in self:
            //     storage_category.capacity_ids = storage_category.product_capacity_ids | storage_category.package_capacity_ids
            */
            return default;
        }
    }
}