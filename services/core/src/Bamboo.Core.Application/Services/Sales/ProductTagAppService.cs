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
    public partial class ProductTagAppService : GenericAppService<ProductTag>, IProductTagAppService
    {
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        protected readonly IWebsiteMultiMixinAppService _websiteMultiMixinAppService;
        public ProductTagAppService(IRepository<ProductTag, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IPosLoadMixinAppService posLoadMixinAppService, IWebsiteMultiMixinAppService websiteMultiMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
            _websiteMultiMixinAppService = websiteMultiMixinAppService;
        }

        public async Task<ProductTag> CopyDataAsync(ProductTagCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_tag.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<ProductTag> input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_tag.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}