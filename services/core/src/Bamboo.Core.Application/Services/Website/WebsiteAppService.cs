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
    [Module("WebsiteModule", Category = "Website", Depends = new[] { "digest", "web", "html_editor", "http_routing", "portal", "social_media", "auth_signup", "mail", "google_recaptcha", "utm", "html_builder" })]
    public partial class WebsiteAppService : GenericAppService<Website>, IWebsiteAppService
    {

        public WebsiteAppService(IRepository<Website, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<Website> ButtonGoWebsiteAsync(WebsiteButtonGoWebsiteRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: button_go_website) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> CheckExistingPageAsync(WebsiteCheckExistingPageRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: check_existing_page) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> ConfiguratorAddonsApplyAsync(WebsiteConfiguratorAddonsApplyRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: configurator_addons_apply) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: configurator_addons_apply) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<Website> ConfiguratorApplyAsync(Guid[] ids)
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: configurator_apply) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: configurator_apply) ---
            #endif
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> ConfiguratorGetFooterLinksAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: configurator_get_footer_links) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: website.py, METHOD: configurator_get_footer_links) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<Website> ConfiguratorInitAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: configurator_init) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<Website> ConfiguratorMissingIndustryAsync(WebsiteConfiguratorMissingIndustryRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: configurator_missing_industry) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<Website> ConfiguratorRecommendedThemesAsync(WebsiteConfiguratorRecommendedThemesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: configurator_recommended_themes) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> ConfiguratorSetMenuLinksAsync(WebsiteConfiguratorSetMenuLinksRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: configurator_set_menu_links) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website.py, METHOD: configurator_set_menu_links) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: website.py, METHOD: configurator_set_menu_links) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<Website> ConfiguratorSkipAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: configurator_skip) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> CopyMenuHierarchyAsync(WebsiteCopyMenuHierarchyRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: copy_menu_hierarchy) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> CreateAndRedirectConfiguratorAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: create_and_redirect_configurator) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<Website> CreateAsync(CreateRequestDto<Website> input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: website.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public async Task<Website> DashboardRedirectAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: action_dashboard_redirect) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: action_dashboard_redirect) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> GetCdnUrlAsync(WebsiteGetCdnUrlRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: get_cdn_url) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> GetClientActionAsync(WebsiteGetClientActionRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: get_client_action) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> GetClientUrlAsync(WebsiteGetClientUrlRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: get_client_action_url) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<Website> GetConfiguratorProductPageStylesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: get_configurator_product_page_styles) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<Website> GetConfiguratorShopPageStylesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: get_configurator_shop_page_styles) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> GetCtaDataAsync(WebsiteGetCtaDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: get_cta_data) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: website.py, METHOD: get_cta_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<Website> GetCurrentWebsiteAsync(WebsiteGetCurrentWebsiteRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: get_current_website) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> GetPricelistAvailableAsync(WebsiteGetPricelistAvailableRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: get_pricelist_available) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> GetSuggestedControllersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: get_suggested_controllers) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website.py, METHOD: get_suggested_controllers) ---
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: website.py, METHOD: get_suggested_controllers) ---
            --- METHOD SOURCE (MODULE: website_customer, FILE: website.py, METHOD: get_suggested_controllers) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: website.py, METHOD: get_suggested_controllers) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: website.py, METHOD: get_suggested_controllers) ---
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: website.py, METHOD: get_suggested_controllers) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: get_suggested_controllers) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: website.py, METHOD: get_suggested_controllers) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<Website> GetTemplateAsync(WebsiteGetTemplateRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: get_template) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<Website> GetThemeConfiguratorSnippetsAsync(WebsiteGetThemeConfiguratorSnippetsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: get_theme_configurator_snippets) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> GetUniqueKeyAsync(WebsiteGetUniqueKeyRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: get_unique_key) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> GetUniquePathAsync(WebsiteGetUniquePathRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: get_unique_path) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> GetWebsitePageIdsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: get_website_page_ids) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> HasEcommerceAccessAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: has_ecommerce_access) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> HasGooglePlacesApiKeyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_autocomplete, FILE: website.py, METHOD: has_google_places_api_key) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<Website> ImageUrlAsync(WebsiteImageUrlRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: image_url) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> IsMenuCacheDisabledAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: is_menu_cache_disabled) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> IsPricelistAvailableAsync(WebsiteIsPricelistAvailableRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: is_pricelist_available) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<Website> IsPublicUserAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: is_public_user) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<Website> IsViewActiveAsync(WebsiteIsViewActiveRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: is_view_active) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<Website> NewPageAsync(WebsiteNewPageRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: new_page) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: website.py, METHOD: new_page) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<Website> PagerAsync(WebsitePagerRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: pager) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> RuleIsEnumerableAsync(WebsiteRuleIsEnumerableRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: rule_is_enumerable) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> SaleProductDomainAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: sale_product_domain) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> SaleResetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: sale_reset) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> SearchPagesAsync(WebsiteSearchPagesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: search_pages) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<Website> SearchUrlDependenciesAsync(WebsiteSearchUrlDependenciesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: search_url_dependencies) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<Website> ViewrefAsync(WebsiteViewrefRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: viewref) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<Website> WebsiteDomainAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: website_domain) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}