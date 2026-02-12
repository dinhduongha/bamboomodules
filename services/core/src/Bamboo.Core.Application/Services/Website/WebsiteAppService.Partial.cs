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
    public partial class WebsiteAppService
    {

        protected async Task<Website> ActiveLanguagesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _active_languages) ---
            */
            return default;
        }

        protected async Task<Website> AllConsentsGrantedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _allConsentsGranted) ---
            */
            return default;
        }

        protected async Task<Website> ApiRpcInternalAsync(object route, object @params, object endpoint_param_name, object default_endpoint)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _api_rpc) ---
            */
            return default;
        }

        protected async Task<Website> BasicEnumerateWordsInternalAsync(object search_details, object search, object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _basic_enumerate_words) ---
            */
            return default;
        }

        protected async Task<Website> BootstrapHomepageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _bootstrap_homepage) ---
            */
            return default;
        }

        protected async Task<Website> CheckDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _check_domain) ---
            */
            return default;
        }

        protected async Task<Website> CheckEventsAppNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: website.py, METHOD: _check_events_app_name) ---
            */
            return default;
        }

        protected async Task<Website> CheckHomepageUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _check_homepage_url) ---
            */
            return default;
        }

        protected async Task<Website> CheckSnippetUsedInternalAsync(object snippet_occurences, object asset_type, object asset_version)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _check_snippet_used) ---
            */
            return default;
        }

        protected async Task<Website> CheckUserCanModifyInternalAsync(object record)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _check_user_can_modify) ---
            */
            return default;
        }

        protected async Task<Website> ComputeAppIconInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: website.py, METHOD: _compute_app_icon) ---
            */
            return default;
        }

        protected async Task<Website> ComputeBlockedThirdPartyDomainsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _compute_blocked_third_party_domains) ---
            */
            return default;
        }

        protected async Task<Website> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        protected async Task<Website> ComputeDomainPunycodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _compute_domain_punycode) ---
            */
            return default;
        }

        protected async Task<Website> ComputeEventsAppNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: website.py, METHOD: _compute_events_app_name) ---
            */
            return default;
        }

        protected async Task<Website> ComputeHasSocialDefaultImageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _compute_has_social_default_image) ---
            */
            return default;
        }

        protected async Task<Website> ComputeInStoreDmIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: website.py, METHOD: _compute_in_store_dm_id) ---
            */
            return default;
        }

        protected async Task<Website> ComputeLanguageCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _compute_language_count) ---
            */
            return default;
        }

        protected async Task<Website> ComputeMenuInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _compute_menu) ---
            */
            return default;
        }

        protected async Task<Website> ComputePricelistIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _compute_pricelist_ids) ---
            */
            return default;
        }

        protected async Task<Website> ComputeSendAbandonedCartEmailActivationTimeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _compute_send_abandoned_cart_email_activation_time) ---
            */
            return default;
        }

        protected async Task<Website> ComputeShowLineSubtotalsTaxSelectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _compute_show_line_subtotals_tax_selection) ---
            */
            return default;
        }

        protected async Task<Website> CreateCartInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _create_cart) ---
            */
            return default;
        }

        protected async Task<Website> CreateCheckoutStepsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _create_checkout_steps) ---
            */
            return default;
        }

        protected async Task<Website> DefaultConfirmationEmailTemplateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _default_confirmation_email_template) ---
            */
            return default;
        }

        protected async Task<Website> DefaultFaviconInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _default_favicon) ---
            */
            return default;
        }

        protected async Task<Website> DefaultFeedIsValidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _default_feed_is_valid) ---
            */
            return default;
        }

        protected async Task<Website> DefaultLanguageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _default_language) ---
            */
            return default;
        }

        protected async Task<Website> DefaultLogoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _default_logo) ---
            */
            return default;
        }

        protected async Task<Website> DefaultRecoveryMailTemplateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _default_recovery_mail_template) ---
            */
            return default;
        }

        protected async Task<Website> DefaultSalesteamIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _default_salesteam_id) ---
            */
            return default;
        }

        protected async Task<Website> DefaultSocialDiscordInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _default_social_discord) ---
            */
            return default;
        }

        protected async Task<Website> DefaultSocialFacebookInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _default_social_facebook) ---
            */
            return default;
        }

        protected async Task<Website> DefaultSocialGithubInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _default_social_github) ---
            */
            return default;
        }

        protected async Task<Website> DefaultSocialInstagramInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _default_social_instagram) ---
            */
            return default;
        }

        protected async Task<Website> DefaultSocialLinkedinInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _default_social_linkedin) ---
            */
            return default;
        }

        protected async Task<Website> DefaultSocialTiktokInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _default_social_tiktok) ---
            */
            return default;
        }

        protected async Task<Website> DefaultSocialTwitterInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _default_social_twitter) ---
            */
            return default;
        }

        protected async Task<Website> DefaultSocialYoutubeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _default_social_youtube) ---
            */
            return default;
        }

        protected async Task<Website> DisableUnusedSnippetsAssetsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _disable_unused_snippets_assets) ---
            */
            return default;
        }

        protected async Task<Website> EnumeratePagesInternalAsync(object query_string, object force)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _enumerate_pages) ---
            */
            return default;
        }

        protected async Task<Website> ForceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _force) ---
            */
            return default;
        }

        protected async Task<Website> ForceWebsiteInternalAsync(Guid website_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _force_website) ---
            */
            return default;
        }

        protected async Task<Website> GetAllowedStepsDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _get_allowed_steps_domain) ---
            */
            return default;
        }

        protected async Task<Website> GetAndCacheCurrentCartInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _get_and_cache_current_cart) ---
            */
            return default;
        }

        protected async Task<Website> GetAndCacheCurrentFiscalPositionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _get_and_cache_current_fiscal_position) ---
            */
            return default;
        }

        protected async Task<Website> GetAndCacheCurrentPricelistInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _get_and_cache_current_pricelist) ---
            */
            return default;
        }

        protected async Task<Website> GetBasicFeedProductDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _get_basic_feed_product_domain) ---
            */
            return default;
        }

        protected async Task<Website> GetBlockedIframeContainersClassesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _get_blocked_iframe_containers_classes) ---
            */
            return default;
        }

        protected async Task<Website> GetBlockedThirdPartyDomainsListInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _get_blocked_third_party_domains_list) ---
            */
            return default;
        }

        protected async Task<Website> GetCachedInternalAsync(object field)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _get_cached) ---
            */
            return default;
        }

        protected async Task<Website> GetCachedValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _get_cached_values) ---
            */
            return default;
        }

        protected async Task<Website> GetCanonicalUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _get_canonical_url) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _get_canonical_url) ---
            */
            return default;
        }

        protected async Task<Website> GetCheckoutStepInternalAsync(object href)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _get_checkout_step) ---
            */
            return default;
        }

        protected async Task<Website> GetCheckoutStepValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _get_checkout_step_values) ---
            */
            return default;
        }

        protected async Task<Website> GetCheckoutStepsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _get_checkout_steps) ---
            */
            return default;
        }

        protected async Task<Website> GetCrmDefaultTeamDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm, FILE: website.py, METHOD: _get_crm_default_team_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<Website> GetCurrentWebsiteIdInternalAsync(object domain_name, object fallback)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _get_current_website_id) ---
            */
            return default;
        }

        protected async Task<Website> GetGeoipCountryCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _get_geoip_country_code) ---
            */
            return default;
        }

        protected async Task<Website> GetHtmlFieldsBlacklistInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _get_html_fields_blacklist) ---
            */
            return default;
        }

        protected async Task<Website> GetHtmlFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _get_html_fields) ---
            */
            return default;
        }

        protected async Task<Website> GetLivechatChannelInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_livechat, FILE: website.py, METHOD: _get_livechat_channel_info) ---
            */
            return default;
        }

        protected async Task<Website> GetMaxInStoreProductAvailableQtyInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: website.py, METHOD: _get_max_in_store_product_available_qty) ---
            */
            return default;
        }

        protected async Task<Website> GetPlPartnerOrderInternalAsync(object country_code, object show_visible, Guid current_pl_id, List<Guid> website_pricelist_ids, Guid partner_pl_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _get_pl_partner_order) ---
            */
            return default;
        }

        protected async Task<Website> GetPlausibleScriptUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _get_plausible_script_url) ---
            */
            return default;
        }

        protected async Task<Website> GetPlausibleServerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _get_plausible_server) ---
            */
            return default;
        }

        protected async Task<Website> GetPlausibleShareUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _get_plausible_share_url) ---
            */
            return default;
        }

        protected async Task<Website> GetProductAvailableQtyInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: website.py, METHOD: _get_product_available_qty) ---
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: website.py, METHOD: _get_product_available_qty) ---
            */
            return default;
        }

        protected async Task<Website> GetProductImageRatioHeightInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _get_product_image_ratio_height) ---
            */
            return default;
        }

        protected async Task<Website> GetProductImageRatioInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _get_product_image_ratio) ---
            */
            return default;
        }

        protected async Task<Website> GetProductPageContainerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _get_product_page_container) ---
            */
            return default;
        }

        protected async Task<Website> GetProductPageGridImageRoundedClassesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _get_product_page_grid_image_rounded_classes) ---
            */
            return default;
        }

        protected async Task<Website> GetProductPageGridImageSpacingClassesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _get_product_page_grid_image_spacing_classes) ---
            */
            return default;
        }

        protected async Task<Website> GetProductPageProportionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _get_product_page_proportions) ---
            */
            return default;
        }

        protected async Task<Website> GetProductSortMappingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _get_product_sort_mapping) ---
            */
            return default;
        }

        protected async Task<Website> GetSnippetDefaultsInternalAsync(object snippet)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _get_snippet_defaults) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _get_snippet_defaults) ---
            */
            return default;
        }

        protected async Task<Website> GetSnippetViewKeyInternalAsync(object snippet, object page_code)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _get_snippet_view_key) ---
            */
            return default;
        }

        protected async Task<Website> GetWebsitePagesInternalAsync(object domain, object order, object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _get_website_pages) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<Website> HandleCreateWriteInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _handle_create_write) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<Website> HandleDomainInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _handle_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<Website> HandleFaviconInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _handle_favicon) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<Website> HandleHomepageUrlInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _handle_homepage_url) ---
            */
            return default;
        }

        protected async Task<Website> IdnaUrlInternalAsync(object url)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _idna_url) ---
            */
            return default;
        }

        protected async Task<Website> IsCanonicalUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _is_canonical_url) ---
            */
            return default;
        }

        protected async Task<Website> IsIndexableUrlInternalAsync(object url)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _is_indexable_url) ---
            */
            return default;
        }

        protected async Task<Website> IsSnippetUsedInternalAsync(object snippet_module, Guid snippet_id, object asset_version, object asset_type, object html_fields)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _is_snippet_used) ---
            */
            return default;
        }

        protected async Task<Website> NormalizeDomainUrlInternalAsync(object url)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _normalize_domain_url) ---
            */
            return default;
        }

        protected async Task<Website> OLGApiRpcInternalAsync(object route, object @params)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _OLG_api_rpc) ---
            */
            return default;
        }

        protected async Task<Website> OnchangeLanguageIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _onchange_language_ids) ---
            */
            return default;
        }

        protected async Task<Website> PopulateProductFeedsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _populate_product_feeds) ---
            */
            return default;
        }

        protected async Task<Website> PreconfigureSnippetInternalAsync(object snippet, object el, object customizations)
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _preconfigure_snippet) ---
            #endif
            return default;
        }

        protected async Task<Website> PrepareSaleOrderValuesInternalAsync(object partner_sudo)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _prepare_sale_order_values) ---
            */
            return default;
        }

        protected async Task<Website> ProductDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _product_domain) ---
            */
            return default;
        }

        protected async Task<Website> RemoveAttachmentsOnWebsiteUnlinkInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _remove_attachments_on_website_unlink) ---
            */
            return default;
        }

        protected async Task<Website> SearchBuildDomainInternalAsync(object domain_list, object search, object fields, object extra)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _search_build_domain) ---
            */
            return default;
        }

        protected async Task<Website> SearchExactInternalAsync(object search_details, object search, object limit, object order)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _search_exact) ---
            */
            return default;
        }

        protected async Task<Website> SearchFindFuzzyTermInternalAsync(object search_details, object search, object limit, object word_list)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _search_find_fuzzy_term) ---
            */
            return default;
        }

        protected async Task<Website> SearchGetDetailsInternalAsync(object search_type, object order, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _search_get_details) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website.py, METHOD: _search_get_details) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: website.py, METHOD: _search_get_details) ---
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: website.py, METHOD: _search_get_details) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: website.py, METHOD: _search_get_details) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: website.py, METHOD: _search_get_details) ---
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: website.py, METHOD: _search_get_details) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _search_get_details) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: website.py, METHOD: _search_get_details) ---
            */
            return default;
        }

        protected async Task<Website> SearchGetIndirectFieldsInternalAsync(object fields, object model)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _search_get_indirect_fields) ---
            */
            return default;
        }

        protected async Task<Website> SearchRenderResultsInternalAsync(object search_details, object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _search_render_results) ---
            */
            return default;
        }

        protected async Task<Website> SearchTextFromHtmlInternalAsync(object html_fragment)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _search_text_from_html) ---
            */
            return default;
        }

        protected async Task<Website> SearchWithFuzzyInternalAsync(object search_type, object search, object limit, object order, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _search_with_fuzzy) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<Website> SendAbandonedCartEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website.py, METHOD: _send_abandoned_cart_email) ---
            */
            return default;
        }

        protected async Task<Website> SetBackgroundOptionsInternalAsync(object el, object background_options)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _set_background_options) ---
            */
            return default;
        }

        protected async Task<Website> TrigramEnumerateWordsInternalAsync(object search_details, object search, object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _trigram_enumerate_words) ---
            */
            return default;
        }

        protected async Task<Website> UnlinkExceptDefaultWebsiteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _unlink_except_default_website) ---
            */
            return default;
        }

        protected async Task<Website> UpdateForumCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: website.py, METHOD: _update_forum_count) ---
            */
            return default;
        }

        protected async Task<Website> WebsiteApiRpcInternalAsync(object route, object @params)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website.py, METHOD: _website_api_rpc) ---
            */
            return default;
        }

        protected async Task<Website> WebsiteFormLastRecordInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_form.py, METHOD: _website_form_last_record) ---
            */
            return default;
        }
    }
}