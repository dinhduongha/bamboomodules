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
    public partial class WebsiteSnippetFilterAppService
    {

        protected async Task<WebsiteSnippetFilter> CheckDataSourceIsProvidedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _check_data_source_is_provided) ---
            */
            return default;
        }

        protected async Task<WebsiteSnippetFilter> CheckFieldNamesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _check_field_names) ---
            */
            return default;
        }

        protected async Task<WebsiteSnippetFilter> CheckLimitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _check_limit) ---
            */
            return default;
        }

        protected async Task<WebsiteSnippetFilter> ComputeModelNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _compute_model_name) ---
            */
            return default;
        }

        protected async Task<WebsiteSnippetFilter> FillSampleInternalAsync(object model, object sample, object index)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _fill_sample) ---
            */
            return default;
        }

        protected async Task<WebsiteSnippetFilter> FilterRecordsToValuesInternalAsync(object records)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _filter_records_to_values) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: website_snippet_filter.py, METHOD: _filter_records_to_values) ---
            */
            return default;
        }

        protected async Task<WebsiteSnippetFilter> GetFieldNameAndTypeInternalAsync(object model, object field_name)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _get_field_name_and_type) ---
            */
            return default;
        }

        protected async Task<WebsiteSnippetFilter> GetFilterMetaDataInternalAsync(object model)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _get_filter_meta_data) ---
            */
            return default;
        }

        protected async Task<WebsiteSnippetFilter> GetHardcodedSampleInternalAsync(object model)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _get_hardcoded_sample) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_snippet_filter.py, METHOD: _get_hardcoded_sample) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: website_snippet_filter.py, METHOD: _get_hardcoded_sample) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: website_snippet_filter.py, METHOD: _get_hardcoded_sample) ---
            */
            return default;
        }

        protected async Task<WebsiteSnippetFilter> GetProductsAccessoriesInternalAsync(object website, object limit, object domain, Guid product_template_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website_snippet_filter.py, METHOD: _get_products_accessories) ---
            */
            return default;
        }

        protected async Task<WebsiteSnippetFilter> GetProductsAlternativeProductsInternalAsync(object website, object limit, object domain, Guid product_template_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website_snippet_filter.py, METHOD: _get_products_alternative_products) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<WebsiteSnippetFilter> GetProductsInternalAsync(object mode)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website_snippet_filter.py, METHOD: _get_products) ---
            */
            return default;
        }

        protected async Task<WebsiteSnippetFilter> GetProductsLatestSoldInternalAsync(object website, object limit, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website_snippet_filter.py, METHOD: _get_products_latest_sold) ---
            */
            return default;
        }

        protected async Task<WebsiteSnippetFilter> GetProductsLatestViewedInternalAsync(object website, object limit, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website_snippet_filter.py, METHOD: _get_products_latest_viewed) ---
            */
            return default;
        }

        protected async Task<WebsiteSnippetFilter> GetProductsRecentlySoldWithInternalAsync(object website, object limit, object domain, Guid product_template_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website_snippet_filter.py, METHOD: _get_products_recently_sold_with) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<WebsiteSnippetFilter> GetWebsiteCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _get_website_currency) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: website_snippet_filter.py, METHOD: _get_website_currency) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<WebsiteSnippetFilter> PrepareCategoryListDataInternalAsync(Guid parent_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website_snippet_filter.py, METHOD: _prepare_category_list_data) ---
            */
            return default;
        }

        protected async Task<WebsiteSnippetFilter> PrepareSampleInternalAsync(object length)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _prepare_sample) ---
            */
            return default;
        }

        protected async Task<WebsiteSnippetFilter> PrepareSampleRecordsInternalAsync(object length)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _prepare_sample_records) ---
            */
            return default;
        }

        protected async Task<WebsiteSnippetFilter> PrepareValuesInternalAsync(object limit, object search_domain)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _prepare_values) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: website_snippet_filter.py, METHOD: _prepare_values) ---
            */
            return default;
        }

        protected async Task<WebsiteSnippetFilter> RenderInternalAsync(object template_key, object limit, object search_domain, object with_sample, object res_model, Guid res_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _render) ---
            */
            return default;
        }
    }
}