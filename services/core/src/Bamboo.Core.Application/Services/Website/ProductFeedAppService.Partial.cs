using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
    public partial class ProductFeedAppService
    {

        protected async Task<ProductFeed> CheckProductLimitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _check_product_limit) ---
            */
            return default;
        }

        protected async Task<ProductFeed> ComputeFeedCacheInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _compute_feed_cache) ---
            */
            return default;
        }

        protected async Task<ProductFeed> ComputeLangIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _compute_lang_id) ---
            */
            return default;
        }

        protected async Task<ProductFeed> ComputeUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _compute_url) ---
            */
            return default;
        }

        protected async Task<ProductFeed> GetFeedProductDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _get_feed_product_domain) ---
            */
            return default;
        }

        protected async Task<ProductFeed> GetFeedProductsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _get_feed_products) ---
            */
            return default;
        }

        protected async Task<ProductFeed> NotifyWebsiteManagerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _notify_website_manager) ---
            */
            return default;
        }

        protected async Task<ProductFeed> PrepareGmcAdditionalInfoInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _prepare_gmc_additional_info) ---
            */
            return default;
        }

        protected async Task<ProductFeed> PrepareGmcIdentifierInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _prepare_gmc_identifier) ---
            */
            return default;
        }

        protected async Task<ProductFeed> PrepareGmcImageLinksInternalAsync(object product, object base_url)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _prepare_gmc_image_links) ---
            */
            return default;
        }

        protected async Task<ProductFeed> PrepareGmcItemsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _prepare_gmc_items) ---
            */
            return default;
        }

        protected async Task<ProductFeed> PrepareGmcPriceInfoInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _prepare_gmc_price_info) ---
            */
            return default;
        }

        protected async Task<ProductFeed> PrepareGmcStockInfoInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _prepare_gmc_stock_info) ---
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: product_feed.py, METHOD: _prepare_gmc_stock_info) ---
            */
            return default;
        }

        protected async Task<ProductFeed> RenderAndCacheCompressedGmcFeedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _render_and_cache_compressed_gmc_feed) ---
            */
            return default;
        }

        protected async Task<ProductFeed> RenderGmcFeedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _render_gmc_feed) ---
            */
            return default;
        }
    }
}