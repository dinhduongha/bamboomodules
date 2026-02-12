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
    public partial class ProductPricelistAppService
    {

        protected async Task<ProductPricelist> BaseDomainItemIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _base_domain_item_ids) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> CheckWebsitesInCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py, METHOD: _check_websites_in_company) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> ComputePartnersCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: partnership, FILE: product_pricelist.py, METHOD: _compute_partners_count) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> ComputePriceRuleInternalAsync(object products, object quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _compute_price_rule) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> ComputePriceRuleMultiInternalAsync(object products, object quantity, object uom, object date)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _compute_price_rule_multi) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> DefaultCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _default_currency_id) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> DefaultWebsiteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py, METHOD: _default_website) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> DomainItemIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _domain_item_ids) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> GetApplicableRulesDomainInternalAsync(object products, object date)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _get_applicable_rules_domain) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> GetApplicableRulesInternalAsync(object products, object date)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _get_applicable_rules) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> GetPartnerPricelistMultiFilterHookInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _get_partner_pricelist_multi_filter_hook) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py, METHOD: _get_partner_pricelist_multi_filter_hook) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductPricelist> GetPartnerPricelistMultiInternalAsync(List<Guid> partner_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _get_partner_pricelist_multi) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> GetPartnerPricelistMultiSearchDomainHookInternalAsync(Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _get_partner_pricelist_multi_search_domain_hook) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py, METHOD: _get_partner_pricelist_multi_search_domain_hook) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> GetProductPriceInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _get_product_price) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> GetProductPriceRuleInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _get_product_price_rule) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> GetProductRuleInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _get_product_rule) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> GetProductsPriceInternalAsync(object products)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _get_products_price) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> GetWebsitePricelistsDomainInternalAsync(object website)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py, METHOD: _get_website_pricelists_domain) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> IsAvailableInCountryInternalAsync(object country_code)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py, METHOD: _is_available_in_country) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> IsAvailableOnWebsiteInternalAsync(object website)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_pricelist.py, METHOD: _is_available_on_website) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductPricelist> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_pricelist.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProductPricelist> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_pricelist.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> PriceGetInternalAsync(object product, object quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _price_get) ---
            */
            return default;
        }

        protected async Task<ProductPricelist> UnlinkExceptUsedAsRuleBaseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _unlink_except_used_as_rule_base) ---
            */
            return default;
        }
    }
}