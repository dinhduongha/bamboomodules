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
    public partial class ProductPricelistAppService : GenericAppService<ProductPricelist>, IProductPricelistAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ProductPricelistAppService(IRepository<ProductPricelist, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<ProductPricelist> ArchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: product_pricelist.py, METHOD: action_archive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductPricelist> CopyDataAsync(ProductPricelistCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<ProductPricelist> CreateAsync(CreateRequestDto<ProductPricelist> input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public async Task<ProductPricelist> GetImportTemplatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: get_import_templates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductPricelist> OpenPricelistReportAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: action_open_pricelist_report) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<ProductPricelist> input)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}