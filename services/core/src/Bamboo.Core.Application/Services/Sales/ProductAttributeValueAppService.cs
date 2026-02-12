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
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Product", Category = "Sales", Depends = new[] { "base", "mail", "uom" })]
    public partial class ProductAttributeValueAppService : GenericAppService<ProductAttributeValue>, IProductAttributeValueAppService
    {

        public ProductAttributeValueAppService(IRepository<ProductAttributeValue, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<ProductAttributeValue> AddToProductsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_attribute_value.py, METHOD: action_add_to_products) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductAttributeValue> CheckIsUsedOnProductsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_attribute_value.py, METHOD: check_is_used_on_products) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductAttributeValue> UpdatePricesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_attribute_value.py, METHOD: action_update_prices) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}