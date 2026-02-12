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
    [Module("Product", Category = "Sales", Depends = new[] { "base", "mail", "uom" })]
    public partial class ProductAttributeAppService : GenericAppService<ProductAttribute>, IProductAttributeAppService
    {
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ProductAttributeAppService(IRepository<ProductAttribute, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<ProductAttribute> ArchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_attribute.py, METHOD: action_archive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductAttribute> OpenProductTemplateAttributeLinesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_attribute.py, METHOD: action_open_product_template_attribute_lines) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}