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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("website", Category = "Website", Depends = new[] { "digest", "web", "html_editor", "http_routing", "portal", "social_media", "auth_signup", "mail", "google_recaptcha", "utm", "html_builder" })]
    public partial class WebsiteMultiMixinAppService : ApplicationService, IWebsiteMultiMixinAppService
    {

        public WebsiteMultiMixinAppService() 
        {

        }

        public async Task<TEntity> ActionOpenLoyaltyCardsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: action_open_loyalty_cards) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProgramShareAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: loyalty_program.py, METHOD: action_program_share) ---
            */
            return default;
        }

        public async Task<TEntity> AllTagsAsync<TEntity>(IEnumerable<TEntity> entities, object @join, object min_limit) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: all_tags) ---
            */
            return default;
        }

        public async Task<TEntity> CanAccessFromCurrentWebsiteAsync<TEntity>(IEnumerable<TEntity> entities, Guid website_id) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: mixins.py, METHOD: can_access_from_current_website) ---
            */
            return default;
        }

        public async Task<TEntity> CanReturnContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object access_token) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_tag.py, METHOD: _can_return_content) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDateFromDateToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _check_date_from_date_to) ---
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: check_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPricelistCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _check_pricelist_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBlogPostCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_blog_post_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanModerateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_can_moderate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountFlaggedPostsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_count_flagged_posts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountPostsWaitingValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_count_posts_waiting_validation) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCouponCountDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_coupon_count_display) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCouponCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_coupon_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeForumStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_forum_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFromProgramTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_from_program_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasImageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_tag.py, METHOD: _compute_has_image) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasPendingPostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_has_pending_post) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasPublishedProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _compute_has_published_products) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsNominativeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_is_nominative) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPaymentProgramInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_is_payment_program) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLastPostIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_last_post_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_mail_template_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_program.py, METHOD: _compute_order_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeParentsAndSelfInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _compute_parents_and_self) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentProgramDiscountProductIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_payment_program_discount_product_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePortalPointNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_portal_point_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePosConfigIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py, METHOD: _compute_pos_config_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePosOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py, METHOD: _compute_pos_order_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePosReportPrintIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py, METHOD: _compute_pos_report_print_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_tag.py, METHOD: _compute_product_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowNonPublishedProductWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: loyalty_program.py, METHOD: _compute_show_non_published_product_warning) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTagIdsUsageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_tag_ids_usage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _compute_total_order_count) ---
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py, METHOD: _compute_total_order_count) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_program.py, METHOD: _compute_total_order_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: mixins.py, METHOD: _compute_website_published) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        public async Task<TEntity> ConstrainsRewardIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _constrains_reward_ids) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_tag.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateFromTemplateAsync<TEntity>(IEnumerable<TEntity> entities, Guid template_id) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: create_from_template) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: default_get) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_sequence) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _default_sequence) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAvailableCategoryDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid website_id) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _get_available_category_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAvailableSnippetCategoriesAsync<TEntity>(IEnumerable<TEntity> entities, Guid website_id) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: get_available_snippet_categories) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_tag.py, METHOD: _get_default_template_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_tag.py, METHOD: _get_default_variant_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultWelcomeMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _get_default_welcome_message) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetProgramTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: get_program_templates) ---
            --- METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: loyalty_program.py, METHOD: get_program_templates) ---
            */
            return default;
        }

        public async Task<TEntity> GetTagsFirstCharInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tags) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _get_tags_first_char) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _get_template_values) ---
            --- METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: loyalty_program.py, METHOD: _get_template_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetValidProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _get_valid_products) ---
            */
            return default;
        }

        public async Task<TEntity> GoToWebsiteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: go_to_website) ---
            */
            return default;
        }

        public async Task<TEntity> InverseMailTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _inverse_mail_template_id) ---
            */
            return default;
        }

        public async Task<TEntity> InversePosReportPrintIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py, METHOD: _inverse_pos_report_print_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: mixins.py, METHOD: _inverse_website_published) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object config) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_tag.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object config) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py, METHOD: _load_pos_data_read) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosSelfDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_tag.py, METHOD: _load_pos_self_data_domain) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: message_post) ---
            */
            return default;
        }

        public async Task<TEntity> OpenWebsiteUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: mixins.py, METHOD: open_website_url) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ProgramItemsNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _program_items_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ProgramTypeDefaultValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _program_type_default_values) ---
            --- METHOD SOURCE (MODULE: sale_loyalty_delivery, FILE: loyalty_program.py, METHOD: _program_type_default_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchHasPublishedProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _search_has_published_products) ---
            */
            return default;
        }

        public async Task<TEntity> SearchProductIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_tag.py, METHOD: _search_product_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchRenderResultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fetch_fields, object mapping, object icon, object limit) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _search_render_results) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _search_render_results) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _search_render_results) ---
            */
            return default;
        }

        public async Task<TEntity> SearchWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: mixins.py, METHOD: _search_website_published) ---
            */
            return default;
        }

        public async Task<TEntity> SetDefaultFaqInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _set_default_faq) ---
            */
            return default;
        }

        public async Task<TEntity> TagToWriteValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tags) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _tag_to_write_vals) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptActiveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_program.py, METHOD: _unlink_except_active) ---
            */
            return default;
        }

        public async Task<TEntity> UnrelevantRecordsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object config) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_program.py, METHOD: _unrelevant_records) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsiteMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: write) ---
            */
            return default;
        }
    }
}