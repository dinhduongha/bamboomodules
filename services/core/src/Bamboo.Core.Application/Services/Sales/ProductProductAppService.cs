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
    public partial class ProductProductAppService : GenericAppService<ProductProduct>, IProductProductAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ProductProductAppService(IRepository<ProductProduct, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<ProductProduct> ArchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: action_archive) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_product.py, METHOD: action_archive) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: action_archive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> BomCostAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: product.py, METHOD: action_bom_cost) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> ButtonBomCostAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: product.py, METHOD: button_bom_cost) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<ProductProduct> CreateAsync(CreateRequestDto<ProductProduct> input)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public override async Task<Dictionary<string, Dictionary<string, object>>> FieldsGetAsync(FieldsGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: fields_get) ---
            */
            return await base.FieldsGetAsync(input);
        }

        public async Task<ProductProduct> FilterHasRoutesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: filter_has_routes) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> GetComponentsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: get_components) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: get_components) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> GetContextualPriceAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: get_contextual_price) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ProductProduct> GetEmptyListHelpAsync(ProductProductGetEmptyListHelpRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: get_empty_list_help) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> GetProductMultilineDescriptionSaleAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: get_product_multiline_description_sale) ---
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: product_product.py, METHOD: get_product_multiline_description_sale) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> GetTotalRoutesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: get_total_routes) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: product.py, METHOD: get_total_routes) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: get_total_routes) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> OpenDocumentsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: action_open_documents) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> OpenLabelLayoutAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: action_open_label_layout) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> OpenProductLotAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_open_product_lot) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> OpenProductTemplateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: open_product_template) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> OpenQuantsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: action_open_quants) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_open_quants) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> OpenWebsiteUrlAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_product.py, METHOD: open_website_url) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> ProductForecastReportAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_product_forecast_report) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> UnarchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: action_unarchive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> UsedInBomAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: action_used_in_bom) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> ViewBomAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: action_view_bom) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ProductProduct> ViewHeaderGetAsync(ProductProductViewHeaderGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: view_header_get) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: view_header_get) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> ViewMosAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: action_view_mos) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> ViewOrderpointsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_orderpoints) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> ViewPoAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: action_view_po) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> ViewRelatedPutawayRulesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_related_putaway_rules) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> ViewRoutesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_routes) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> ViewSalesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_product.py, METHOD: action_view_sales) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> ViewStockMoveLinesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_stock_move_lines) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> ViewStorageCategoryCapacityAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_storage_category_capacity) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProductProduct> WebsitePublishButtonAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_product.py, METHOD: website_publish_button) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<ProductProduct> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: product_product.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: loyalty, FILE: product_product.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_product.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_product.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_product.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}