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
    public partial class ProductTemplateAppService : GenericAppService<ProductTemplate>, IProductTemplateAppService
    {
        protected readonly IImageMixinAppService _imageMixinAppService;
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        protected readonly IRatingMixinAppService _ratingMixinAppService;
        protected readonly IWebsitePublishedMultiMixinAppService _websitePublishedMultiMixinAppService;
        protected readonly IWebsiteSearchableMixinAppService _websiteSearchableMixinAppService;
        protected readonly IWebsiteSeoMetadataAppService _websiteSeoMetadataAppService;
        public ProductTemplateAppService(IRepository<ProductTemplate, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IImageMixinAppService imageMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IPosLoadMixinAppService posLoadMixinAppService, IRatingMixinAppService ratingMixinAppService, IWebsitePublishedMultiMixinAppService websitePublishedMultiMixinAppService, IWebsiteSearchableMixinAppService websiteSearchableMixinAppService, IWebsiteSeoMetadataAppService websiteSeoMetadataAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _imageMixinAppService = imageMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
            _ratingMixinAppService = ratingMixinAppService;
            _websitePublishedMultiMixinAppService = websitePublishedMultiMixinAppService;
            _websiteSearchableMixinAppService = websiteSearchableMixinAppService;
            _websiteSeoMetadataAppService = websiteSeoMetadataAppService;
        }

        public async Task<ProductTemplate> ArchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: action_archive) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: action_archive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> BomCostAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: product.py, METHOD: action_bom_cost) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> ButtonBomCostAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: product.py, METHOD: button_bom_cost) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> ComputeIsStorableAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: compute_is_storable) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<ProductTemplate> CopyAsync(CopyRequestDto<ProductTemplate> input)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: copy) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: copy) ---
            */
            return await base.CopyAsync(input);
        }

        public async Task<ProductTemplate> CopyDataAsync(ProductTemplateCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<ProductTemplate> CreateAsync(CreateRequestDto<ProductTemplate> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: loyalty, FILE: product_template.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<ProductTemplate> CreateProductVariantAsync(ProductTemplateCreateProductVariantRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: create_product_variant) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> CreateProductVariantFromPosAsync(ProductTemplateCreateProductVariantFromPosRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: create_product_variant_from_pos) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> CreateProductVariantsFromGelatoTemplateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py, METHOD: action_create_product_variants_from_gelato_template) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public override async Task<ProductTemplate> DefaultGetAsync(DefaultGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: default_get) ---
            */
            return await base.DefaultGetAsync(input);
        }

        public async Task<ProductTemplate> GetContextualPriceAsync(ProductTemplateGetContextualPriceRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_contextual_price) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ProductTemplate> GetEmptyListHelpAsync(ProductTemplateGetEmptyListHelpRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_empty_list_help) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ProductTemplate> GetImportTemplatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: get_import_templates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> GetProductAccountsAsync(ProductTemplateGetProductAccountsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: get_product_accounts) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: get_product_accounts) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> GetProductInfoPosAsync(ProductTemplateGetProductInfoPosRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: get_product_info_pos) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> GetSingleProductVariantAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_single_product_variant) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: get_single_product_variant) ---
            --- METHOD SOURCE (MODULE: sale_product_matrix, FILE: product_template.py, METHOD: get_single_product_variant) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> HasDynamicAttributesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: has_dynamic_attributes) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ProductTemplate> LoadProductFromPosAsync(ProductTemplateLoadProductFromPosRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: load_product_from_pos) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> OpenDocumentsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: action_open_documents) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> OpenLabelLayoutAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: action_open_label_layout) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> OpenProductLotAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_open_product_lot) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> OpenQuantsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_open_quants) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> OpenRoutesDiagramAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_open_routes_diagram) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> ProductTmplForecastReportAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_product_tmpl_forecast_report) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> SetSequenceBottomAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_bottom) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> SetSequenceDownAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_down) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> SetSequenceTopAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_top) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> SetSequenceUpAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_up) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> SyncGelatoTemplateInfoAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: action_sync_gelato_template_info) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> UsedInBomAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: action_used_in_bom) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> ViewMosAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: action_view_mos) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> ViewOrderpointsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_orderpoints) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> ViewPoAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: action_view_po) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> ViewRelatedPutawayRulesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_related_putaway_rules) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> ViewSalesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: action_view_sales) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> ViewStockMoveLinesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_stock_move_lines) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductTemplate> ViewStorageCategoryCapacityAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_storage_category_capacity) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<ProductTemplate> input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: product.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}