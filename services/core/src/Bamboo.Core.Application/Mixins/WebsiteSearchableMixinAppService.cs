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
    public partial class WebsiteSearchableMixinAppService : ApplicationService, IWebsiteSearchableMixinAppService
    {

        public WebsiteSearchableMixinAppService() 
        {

        }

        public async Task<TEntity> ActionAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partners, object member_status, object raise_on_access) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_add_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: action_archive) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionBomCostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: product.py, METHOD: action_bom_cost) ---
            */
            return default;
        }

        public async Task<TEntity> ActionChannelEnrollAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_channel_enroll) ---
            */
            return default;
        }

        public async Task<TEntity> ActionChannelInviteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_channel_invite) ---
            */
            return default;
        }

        public async Task<TEntity> ActionChannelOpenInviteWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template, object enroll_mode) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_channel_open_invite_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateProductVariantsFromGelatoTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py, METHOD: action_create_product_variants_from_gelato_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDislikeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_dislike) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGenerateLeadsAsync<TEntity>(IEnumerable<TEntity> entities, object event_lead_rules) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_event.py, METHOD: action_generate_leads) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGrantAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_grant_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionInviteContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py, METHOD: action_invite_contacts) ---
            --- METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py, METHOD: action_invite_contacts) ---
            */
            return default;
        }

        public async Task<TEntity> ActionLikeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_like) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ActionLoadRecruitmentScenarioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _action_load_recruitment_scenario) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMarkCompletedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_mark_completed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMarkCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_mark_completed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMarkUncompletedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_mark_uncompleted) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMassMailingAttendeesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py, METHOD: action_mass_mailing_attendees) ---
            --- METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py, METHOD: action_mass_mailing_attendees) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMassMailingTrackSpeakersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event_track, FILE: event_event.py, METHOD: action_mass_mailing_track_speakers) ---
            --- METHOD SOURCE (MODULE: mass_mailing_event_track_sms, FILE: event.py, METHOD: action_mass_mailing_track_speakers) ---
            */
            return default;
        }

        public async Task<TEntity> ActionNewSurveyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_job.py, METHOD: action_new_survey) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenActivitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: action_open_activities) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: action_open_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenDocumentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: action_open_documents) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenEmployeesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: action_open_employees) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenLabelLayoutAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: action_open_label_layout) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenProductLotAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_open_product_lot) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenQuantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_open_quants) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenRoutesDiagramAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_open_routes_diagram) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenSlotCalendarAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: action_open_slot_calendar) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPageDebugViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: action_page_debug_view) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProductTmplForecastReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_product_tmpl_forecast_report) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToCompletedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_completed_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToEngagedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_engaged_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToInvitedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_invited_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToMembersAsync<TEntity>(IEnumerable<TEntity> entities, object status_filter) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRefuseAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_refuse_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRequestAccessAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_request_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRequestAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_request_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSearchMatchingApplicantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_job.py, METHOD: action_search_matching_applicants) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: action_set_done) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetQuizDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object completed) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_set_quiz_done) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetViewedAsync<TEntity>(IEnumerable<TEntity> entities, object quiz_attempts_inc) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_set_viewed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetViewedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partner, object quiz_attempts_inc) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_set_viewed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSyncGelatoTemplateInfoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: action_sync_gelato_template_info) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTestSurveyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_job.py, METHOD: action_test_survey) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnarchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_unarchive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUsedInBomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: action_used_in_bom) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewEmbedsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_view_embeds) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewLinkedOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_event.py, METHOD: action_view_linked_orders) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewMosAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: action_view_mos) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewOrderpointsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_orderpoints) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewPoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: action_view_po) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRatingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_view_ratings) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRelatedPutawayRulesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_related_putaway_rules) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewSalesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: action_view_sales) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewSlidesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_view_slides) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewStockMoveLinesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_stock_move_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewStorageCategoryCapacityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_storage_category_capacity) ---
            */
            return default;
        }

        public async Task<TEntity> ActionVoteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object upvote) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_vote) ---
            */
            return default;
        }

        public async Task<TEntity> AddArchivedCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _add_archived_combinations) ---
            */
            return default;
        }

        public async Task<TEntity> AddGroupsMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _add_groups_members) ---
            */
            return default;
        }

        public async Task<TEntity> AddressIdDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _address_id_domain) ---
            */
            return default;
        }

        public async Task<TEntity> AliasGetCreationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _alias_get_creation_values) ---
            */
            return default;
        }

        public async Task<TEntity> AllTagsAsync<TEntity>(IEnumerable<TEntity> entities, object @join, object min_limit) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: all_tags) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AllowCacheInsertionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object layout) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _allow_cache_insertion) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AllowPublishRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _allow_publish_rating_stats) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _allow_publish_rating_stats) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AllowToUseCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _allow_to_use_cache) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ApplyTaxesToPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price, object currency, object product_taxes, object taxes, object product_or_template, object website) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _apply_taxes_to_price) ---
            */
            return default;
        }

        public async Task<TEntity> AutoInitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _auto_init) ---
            */
            return default;
        }

        public async Task<TEntity> BaseDomainItemIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _base_domain_item_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonBomCostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: product.py, METHOD: button_bom_cost) ---
            */
            return default;
        }

        public async Task<TEntity> CanBeAddedToCartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _can_be_added_to_cart) ---
            */
            return default;
        }

        public async Task<TEntity> CanReturnContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object access_token) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _can_return_content) ---
            */
            return default;
        }

        public async Task<TEntity> CartesianProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_template_attribute_values_per_line, object parent_combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _cartesian_product) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUniquenessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_barcode_uniqueness) ---
            */
            return default;
        }

        public async Task<TEntity> CheckClosingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_closing_date) ---
            */
            return default;
        }

        public async Task<TEntity> CheckComboIdsNotEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_combo_ids_not_empty) ---
            */
            return default;
        }

        public async Task<TEntity> CheckComboInclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _check_combo_inclusions) ---
            */
            return default;
        }

        public async Task<TEntity> CheckEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_event_url) ---
            */
            return default;
        }

        public async Task<TEntity> CheckForPublicationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _check_for_publication) ---
            */
            return default;
        }

        public async Task<TEntity> CheckIncompatibleTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _check_incompatible_types) ---
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: check_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _check_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPrintImagesAreSetBeforePublishingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py, METHOD: _check_print_images_are_set_before_publishing) ---
            */
            return default;
        }

        public async Task<TEntity> CheckProjectAndTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _check_project_and_template) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSaleComboIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_sale_combo_ids) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSaleProductCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _check_sale_product_company) ---
            */
            return default;
        }

        public async Task<TEntity> CheckServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py, METHOD: _check_service_to_purchase) ---
            */
            return default;
        }

        public async Task<TEntity> CheckServiceTrackingForEventBoothsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py, METHOD: _check_service_tracking_for_event_booths) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSlotsDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_slots_dates) ---
            */
            return default;
        }

        public async Task<TEntity> CheckUomNotInInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _check_uom_not_in_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> CheckUserHasModelAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _check_user_has_model_access) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVendorForServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sellers) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py, METHOD: _check_vendor_for_service_to_purchase) ---
            */
            return default;
        }

        public async Task<TEntity> CheckWebsiteIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _check_website_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ClonePageAsync<TEntity>(IEnumerable<TEntity> entities, Guid page_id, object page_name, object clone_menu) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: clone_page) ---
            */
            return default;
        }

        public async Task<TEntity> CloseAsync<TEntity>(IEnumerable<TEntity> entities, Guid reason_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: close) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CompleteInverseExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object exclusions) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _complete_inverse_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActionRightsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_action_rights) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActivitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_activities) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressInlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_address_inline) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_address_search) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_all_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowCommentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_allow_comment) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowedUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_job.py, METHOD: _compute_allowed_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicantHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_applicant_hired) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicantMatchingScoreInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_job.py, METHOD: _compute_applicant_matching_score) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_price) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBlogPostCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_blog_post_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBomCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_bom_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBoothMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py, METHOD: _compute_booth_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanBeExpensedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py, METHOD: _compute_can_be_expensed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanImage1024BeZoomedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_can_image_1024_be_zoomed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanModerateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_can_moderate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanPublishInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_can_publish) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_can_publish) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_can_publish) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanUploadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_can_upload) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryAndSlideIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_category_and_slide_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_category_completed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryCompletionTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_category_completion_time) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_category_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeChildCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_child_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _compute_color) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommentsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_comments_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommunityMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_community_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_contact_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_contact_phone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCostCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_cost_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCostMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _compute_cost_method) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountFlaggedPostsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_count_flagged_posts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountPostsWaitingValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_count_posts_waiting_validation) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountryFlagUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_country_flag_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCtaTimeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_cta_time_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentJobSkillIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_job.py, METHOD: _compute_current_job_skill_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_date_tz) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDocumentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_document_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmbedCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_embed_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmbedCountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_embed_counts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeeCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_employee_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_job.py, METHOD: _compute_employees) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEndDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_end_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEnrollInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_enroll) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCategoryAvailableIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_category_available_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCategoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_category_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_mail_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegisterUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_event_register_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_open) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsSoldOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_sold_out) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsStartedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_started) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventShareUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_event_share_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventSlotCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_slot_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventTicketIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_ticket_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExhibitorMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: _compute_exhibitor_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExpensePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py, METHOD: _compute_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: product_template.py, METHOD: _compute_expense_policy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExpensePolicyTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py, METHOD: _compute_expense_policy_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExtendedInterviewerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_extended_interviewer_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFavoriteCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_favorite_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFieldIsOneDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_field_is_one_day) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalCountryCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _compute_fiscal_country_codes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeForumStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_forum_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFullUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _compute_full_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGelatoMissingImagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _compute_gelato_missing_images) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGelatoProductUidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _compute_gelato_product_uid) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGoogleDriveIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_google_drive_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasAvailableRouteIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_has_available_route_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasConfigurableAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_has_configurable_attributes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasPendingPostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_has_pending_post) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasPublishedProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _compute_has_published_products) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ComputeHasRequestedAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_has_requested_access) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasValidatedAnswerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_has_validated_answer) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImage1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_image_1920) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImage512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_image_512) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_invoice_policy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsDynamicallyCreatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_is_dynamically_created) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_is_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_is_finished) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsHomepageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_is_homepage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInOpeningHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_is_in_opening_hours) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsKitsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_is_kits) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsNewSlideInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_is_new_slide) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_is_ongoing) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsParticipatingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_is_participating) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_is_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsReminderOnInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_is_reminder_on) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsStorableAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: compute_is_storable) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_is_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsVisibleOnWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_is_visible_on_website) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeKanbanStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_kanban_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeKanbanStateLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_kanban_state_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLastPostIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_last_post_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLeadCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_event.py, METHOD: _compute_lead_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLikeInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_like_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLotValuatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _compute_lot_valuated) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMarkCompleteActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_mark_complete_actions) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMembersCountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_members_counts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMembershipValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_membership_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMrpProductQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_mrp_product_qty) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _compute_name) ---
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNameSlugifiedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _compute_name_slugified) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNbrMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_nbr_moves) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNbrReorderingRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_nbr_reordering_rules) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNewApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_new_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNextSerialInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_next_serial) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNoOfHiredEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_no_of_hired_employee) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_note) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOldApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_old_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOpenApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_open_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeParentsAndSelfInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _compute_parents_and_self) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerBiographyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_biography) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerCompanyNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_company_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerFunctionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_function) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerHasNewContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_partner_has_new_content) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerImageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_image) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_phone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerTagLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_tag_line) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_partners) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_phone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePlainContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_plain_content) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_post_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePostKarmaRightsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_post_karma_rights) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePostsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_tag.py, METHOD: _compute_posts_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePrerequisiteUserHasCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_prerequisite_user_has_completed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductDocumentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_document_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_tooltip) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_product_tooltip) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _compute_product_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductVariantCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_variant_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_variant_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePublishDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_publish_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePublishedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _compute_published_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _compute_purchase_method) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseOkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py, METHOD: _compute_purchase_ok) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_purchase_ok) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchasedProductQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _compute_purchased_product_qty) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuantitiesDictInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_quantities_dict) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuantitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_quantities) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_question_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuestionsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_questions_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuizInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partner, object quiz_done) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_quiz_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_rating_stats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRelevancyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_relevancy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSalePriceTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_event.py, METHOD: _compute_sale_price_total) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSalesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_sales_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsLimitedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats_limited) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsMaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats_max) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSelfOrderVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _compute_self_order_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSelfReplyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_self_reply) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSerialPrefixFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_serial_prefix_format) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _compute_service_policy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_service_tracking) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_service_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_service_type) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: product_template.py, METHOD: _compute_service_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceUpsellThresholdRatioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _compute_service_upsell_threshold_ratio) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowQtyStatusButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_show_qty_status_button) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_show_qty_status_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowQtyUpdateButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_show_qty_update_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSkillIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_job.py, METHOD: _compute_skill_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideIconClassInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slide_icon_class) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideLastUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_slide_last_update) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slide_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideViewsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slide_views) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlidesStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_slides_statistics) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slides_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSponsorCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: _compute_sponsor_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStartSaleDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_start_sale_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_tag_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTagIdsUsageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_tag_ids_usage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _compute_task_template) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxStringInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _compute_tax_string) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_teaser) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTemplateFieldFromVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object @default) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_template_field_from_variant_field) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTicketInstructionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_ticket_instructions) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTimeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_time_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_total) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_track_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackTimeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_track_time_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTracksTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_tracks_tag_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUidHasAnsweredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_uid_has_answered) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUrlDemoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _compute_url_demo) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUseBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_use_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUsedInBomCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_used_in_bom_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserFavouriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_user_favourite) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserMembershipIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_user_membership_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_user_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserVoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_user_vote) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeValidProductTemplateAttributeLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_valid_product_template_attribute_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeValuationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _compute_valuation) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVariantsDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_variants_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVideoSourceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_video_source_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVimeoIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_vimeo_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVisibleExpensePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_visible_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py, METHOD: _compute_visible_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _compute_visible_expense_policy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_volume) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_volume_uom_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVoteCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_vote_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteAbsoluteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_website_absolute_url) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_absolute_url) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_website_absolute_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteDefaultBackgroundImageUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_default_background_image_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_website_description) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteImageUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_website_image_url) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_website_image_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteMenuDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_website_menu_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_website_menu) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_website_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteShareUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_website_share_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteTrackInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_website_track) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteTrackProposalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_website_track_proposal) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_tag.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_weight) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWeightUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_weight_uom_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWishlistVisitorIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_wishlist_visitor_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeYoutubeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_youtube_id) ---
            */
            return default;
        }

        public async Task<TEntity> ConstructTaxStringInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _construct_tax_string) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertAnswerToCommentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: convert_answer_to_comment) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ConvertCommentToAnswerAsync<TEntity>(IEnumerable<TEntity> entities, Guid message_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: convert_comment_to_answer) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CopyEventMenusAsync<TEntity>(IEnumerable<TEntity> entities, object old_events) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: copy_event_menus) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_tag.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAttributesFromGelatoInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_info) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _create_attributes_from_gelato_info) ---
            --- METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py, METHOD: _create_attributes_from_gelato_info) ---
            */
            return default;
        }

        public async Task<TEntity> CreateFirstProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object log_warning) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_first_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> CreateMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sequence, object name, object url, Guid xml_id, object menu_type, object parent_menu_type) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _create_menu) ---
            */
            return default;
        }

        public async Task<TEntity> CreatePrintImagesFromGelatoInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_info) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _create_print_images_from_gelato_info) ---
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> product_template_attribute_value_ids) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: create_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantFromPosAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attribute_value_ids, Guid config_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: create_product_variant_from_pos) ---
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object log_warning) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> CreateVariantIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_variant_ids) ---
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _creation_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _default_access_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultAddressIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _default_address_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_content) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCoverPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _default_cover_properties) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _default_cover_properties) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_description) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_event_mail_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: default_get) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultIsPublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _default_is_published) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultPosSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _default_pos_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_question_ids) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultResponsibleIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _default_responsible_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_sequence) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _default_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultSponsorTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _default_sponsor_type_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultWebsiteMetaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_website_meta) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _default_website_meta) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _default_website_meta) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _default_website_meta) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _default_website_meta) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultWebsiteSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _default_website_sequence) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DemoConfigureVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _demo_configure_variants) ---
            */
            return default;
        }

        public async Task<TEntity> DomainPricelistRuleIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _domain_pricelist_rule_ids) ---
            */
            return default;
        }

        public async Task<TEntity> EmbedIncrementInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _embed_increment) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureUnusedInPosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _ensure_unused_in_pos) ---
            */
            return default;
        }

        public async Task<TEntity> FetchExternalMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_external_metadata) ---
            */
            return default;
        }

        public async Task<TEntity> FetchGoogleDriveMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_google_drive_metadata) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FetchIsParticipatingEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _fetch_is_participating_events) ---
            */
            return default;
        }

        public async Task<TEntity> FetchVimeoMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_vimeo_metadata) ---
            */
            return default;
        }

        public async Task<TEntity> FetchYoutubeMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_youtube_metadata) ---
            */
            return default;
        }

        public async Task<TEntity> FilterAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object raise_on_access) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _filter_add_members) ---
            */
            return default;
        }

        public async Task<TEntity> FilterCombinationsImpossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination_tuples, object ignore_no_variant) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _filter_combinations_impossible_by_config) ---
            */
            return default;
        }

        public async Task<TEntity> FlagInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _flag) ---
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultPurchaseTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _force_default_purchase_tax) ---
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultSaleTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _force_default_sale_tax) ---
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _force_default_tax) ---
            */
            return default;
        }

        public async Task<TEntity> GcMarkEventsDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _gc_mark_events_done) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _get_access_action) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _get_access_action) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_access_action) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_access_action) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_access_action) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetActionViewRelatedPutawayRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _get_action_view_related_putaway_rules) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAdditionalConfiguratorDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_additional_configurator_data) ---
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py, METHOD: _get_additional_configurator_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetAdditionnalCombinationInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object uom, object date, object website) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_additionnal_combination_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAlternativeProductFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_alternative_product_filter) ---
            */
            return default;
        }

        public async Task<TEntity> GetAssetAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: product.py, METHOD: _get_asset_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object parent_name, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_attribute_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttributeValueDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attribute_value_dict) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_attribute_value_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttributesExtraPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_attributes_extra_price) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAvailableCategoryDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid website_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _get_available_category_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAvailableSnippetCategoriesAsync<TEntity>(IEnumerable<TEntity> entities, Guid website_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: get_available_snippet_categories) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvailableUomsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_available_uoms) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: get_backend_menu_id) ---
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: get_backend_menu_id) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: get_backend_menu_id) ---
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: get_backend_menu_id) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: get_backend_menu_id) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: get_backend_menu_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackendRootMenuIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _get_backend_root_menu_ids) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _get_backend_root_menu_ids) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_backend_root_menu_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetBaseUnitPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_base_unit_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetBaseUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: get_base_url) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: get_base_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetBoothStatCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _get_booth_stat_count) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_cache_key) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCanPublishErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_can_publish_error_message) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_can_publish_error_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetCategorizedSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_domain, object order, object force_void, object limit, object offset) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_categorized_slides) ---
            */
            return default;
        }

        public async Task<TEntity> GetClosestPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_closest_possible_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetClosestPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_closest_possible_combinations) ---
            */
            return default;
        }

        public async Task<TEntity> GetCombinationInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, Guid product_id, object add_qty, Guid uom_id, object only_template) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_combination_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompletionTimePdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data_bytes) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_completion_time_pdf) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetConfiguratorDisplayPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_configurator_display_price) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetConfiguratorPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_configurator_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetContextualPriceAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_contextual_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetContextualPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_contextual_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetContextualPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_contextual_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> GetDateRangeStrInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object lang_code) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_date_range_str) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultEnrollMsgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_default_enroll_msg) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultFavoriteUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _get_default_favorite_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultJobDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _get_default_job_details) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_default_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_default_uom_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultWebsiteDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _get_default_website_description) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultWelcomeMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _get_default_welcome_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetEarnedKarmaInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_earned_karma) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_empty_list_help) ---
            */
            return default;
        }

        public async Task<TEntity> GetEventResourceUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_event_resource_urls) ---
            */
            return default;
        }

        public async Task<TEntity> GetEventTrackVisitorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_create) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_event_track_visitors) ---
            */
            return default;
        }

        public async Task<TEntity> GetExternalDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_external_description) ---
            */
            return default;
        }

        public async Task<TEntity> GetExternalDescriptionUrlEncodedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_external_description_url_encoded) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_first_possible_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstPossibleVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_first_possible_variant_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstStageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _get_first_stage) ---
            */
            return default;
        }

        public async Task<TEntity> GetGeneralToServiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_policy, object service_type) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_general_to_service) ---
            */
            return default;
        }

        public async Task<TEntity> GetGeneralToServiceMapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_general_to_service_map) ---
            */
            return default;
        }

        public async Task<TEntity> GetGoogleAnalyticsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, object combination_info) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_google_analytics_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetIcsFileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_ics_file) ---
            */
            return default;
        }

        public async Task<TEntity> GetImageHolderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_image_holder) ---
            */
            return default;
        }

        public async Task<TEntity> GetImagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_images) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetIncompatibleTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_incompatible_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetKioskUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: get_kiosk_url) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetLengthUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_length_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetLengthUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_length_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        public async Task<TEntity> GetListPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _get_list_price) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_list_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetMappedAttributeNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_mapped_attribute_names) ---
            */
            return default;
        }

        public async Task<TEntity> GetMenuTypeFieldMatchingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_menu_type_field_matching) ---
            */
            return default;
        }

        public async Task<TEntity> GetMenuUpdateFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_menu_update_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetMenusUpdateByFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object menus_state_by_field, object force_update) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_menus_update_by_field) ---
            */
            return default;
        }

        public async Task<TEntity> GetMicrodataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _get_microdata) ---
            */
            return default;
        }

        public async Task<TEntity> GetMostSpecificPagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_most_specific_pages) ---
            */
            return default;
        }

        public async Task<TEntity> GetNextCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_next_category) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOnchangeServicePolicyUpdatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service_tracking, object service_policy, Guid project_id, Guid project_template_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _get_onchange_service_policy_updates) ---
            */
            return default;
        }

        public async Task<TEntity> GetOwnAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_own_attribute_exclusions) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPageInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_page_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetParentAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_parent_attribute_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> GetPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_placeholder_filename) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_placeholder_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_possible_combinations) ---
            */
            return default;
        }

        public async Task<TEntity> GetPossibleVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_possible_variants) ---
            */
            return default;
        }

        public async Task<TEntity> GetPossibleVariantsSortedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_possible_variants_sorted) ---
            */
            return default;
        }

        public async Task<TEntity> GetPreviewedAttributeValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object product_query_params) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_previewed_attribute_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductAccountsAsync<TEntity>(IEnumerable<TEntity> entities, object fiscal_pos) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: get_product_accounts) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: get_product_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _get_product_accounts) ---
            --- METHOD SOURCE (MODULE: mrp_account, FILE: product.py, METHOD: _get_product_accounts) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _get_product_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductDocumentDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_document_domain) ---
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _get_product_document_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductInfoPosAsync<TEntity>(IEnumerable<TEntity> entities, object price, object quantity, Guid pos_config_id, Guid product_variant_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: get_product_info_pos) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_placeholder_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_price_context) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetProductTypesAllowZeroPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_product_types_allow_zero_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object query_params, object grouped_attributes_values) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_product_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetRelatedFieldsVariantTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_related_fields_variant_template) ---
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _get_related_fields_variant_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetRelatedPostsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object limit) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _get_related_posts) ---
            */
            return default;
        }

        public async Task<TEntity> GetResponseCachedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_response_cached) ---
            */
            return default;
        }

        public async Task<TEntity> GetResponseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_response) ---
            */
            return default;
        }

        public async Task<TEntity> GetResponseRawInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_response_raw) ---
            */
            return default;
        }

        public async Task<TEntity> GetRibbonInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price_vals, object auto_assign_ribbons, object variant) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_ribbon) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSaleableTrackingTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partnership, FILE: product_template.py, METHOD: _get_saleable_tracking_types) ---
            --- METHOD SOURCE (MODULE: repair, FILE: product.py, METHOD: _get_saleable_tracking_types) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_saleable_tracking_types) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_saleable_tracking_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetSalesPricesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_sales_prices) ---
            */
            return default;
        }

        public async Task<TEntity> GetSeatsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot_tickets) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_seats_availability) ---
            */
            return default;
        }

        public async Task<TEntity> GetServiceToGeneralInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service_policy) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_service_to_general) ---
            */
            return default;
        }

        public async Task<TEntity> GetServiceToGeneralMapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_service_to_general_map) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _get_service_to_general_map) ---
            */
            return default;
        }

        public async Task<TEntity> GetSingleProductVariantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_single_product_variant) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: get_single_product_variant) ---
            --- METHOD SOURCE (MODULE: sale_product_matrix, FILE: product_template.py, METHOD: get_single_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> GetSlotTicketsAvailabilityPosAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> slot_ticket_ids) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_event.py, METHOD: get_slot_tickets_availability_pos) ---
            */
            return default;
        }

        public async Task<TEntity> GetStructuredDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object post_type) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _get_structured_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetSuitableImageSizeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object columns, object x_size, object y_size) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_suitable_image_size) ---
            */
            return default;
        }

        public async Task<TEntity> GetTagsFirstCharInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tags) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _get_tags_first_char) ---
            */
            return default;
        }

        public async Task<TEntity> GetTemplateMatrixInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product_matrix, FILE: product_template.py, METHOD: _get_template_matrix) ---
            */
            return default;
        }

        public async Task<TEntity> GetTicketsAccessHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> registration_ids) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_tickets_access_hash) ---
            */
            return default;
        }

        public async Task<TEntity> GetTrackCalendarDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_calendar_description) ---
            */
            return default;
        }

        public async Task<TEntity> GetTrackCalendarReminderDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_calendar_reminder_dates) ---
            */
            return default;
        }

        public async Task<TEntity> GetTrackCalendarReminderTimesWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_calendar_reminder_times_warning) ---
            */
            return default;
        }

        public async Task<TEntity> GetTrackCalendarUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_calendar_urls) ---
            */
            return default;
        }

        public async Task<TEntity> GetTrackSuggestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object restrict_domain, object limit) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_suggestions) ---
            */
            return default;
        }

        public async Task<TEntity> GetVariantForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_variant_for_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetVariantIdForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filtered_combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_variant_id_for_combination) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetVolumeUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_volume_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetVolumeUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_volume_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteAccessoryProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_website_accessory_product) ---
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteAlternativeProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_website_alternative_product) ---
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteMenuEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_website_menu_entries) ---
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteMetaAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: get_website_meta) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWeightUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_weight_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWeightUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_weight_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        public async Task<TEntity> GoToWebsiteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: go_to_website) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: go_to_website) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: google_map_link) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _google_map_link) ---
            */
            return default;
        }

        public async Task<TEntity> HasDynamicAttributesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: has_dynamic_attributes) ---
            */
            return default;
        }

        public async Task<TEntity> HasIsCustomValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _has_is_custom_values) ---
            */
            return default;
        }

        public async Task<bool> HasMultipleUomsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _has_multiple_uoms) ---
            */
            return default;
        }

        public async Task<TEntity> HasNoVariantAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _has_no_variant_attributes) ---
            */
            return default;
        }

        public async Task<TEntity> HasPublishedTrackInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _has_published_track) ---
            */
            return default;
        }

        public async Task<TEntity> InitColumnInternalAsync<TEntity>(IEnumerable<TEntity> entities, object column_name) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _init_column) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _init_column) ---
            */
            return default;
        }

        public async Task<TEntity> InverseDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _inverse_date) ---
            */
            return default;
        }

        public async Task<TEntity> InverseEndDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _inverse_end_date) ---
            */
            return default;
        }

        public async Task<TEntity> InverseGelatoProductUidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _inverse_gelato_product_uid) ---
            */
            return default;
        }

        public async Task<TEntity> InverseIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _inverse_is_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> InverseNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _inverse_name) ---
            */
            return default;
        }

        public async Task<TEntity> InverseNameSlugifiedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _inverse_name_slugified) ---
            */
            return default;
        }

        public async Task<TEntity> InverseQtyAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _inverse_qty_available) ---
            */
            return default;
        }

        public async Task<TEntity> InverseSerialPrefixFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _inverse_serial_prefix_format) ---
            */
            return default;
        }

        public async Task<TEntity> InverseServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _inverse_service_policy) ---
            */
            return default;
        }

        public async Task<TEntity> IsAddToCartPossibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _is_add_to_cart_possible) ---
            */
            return default;
        }

        public async Task<TEntity> IsCombinationPossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _is_combination_possible_by_config) ---
            */
            return default;
        }

        public async Task<TEntity> IsCombinationPossibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object parent_combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _is_combination_possible) ---
            */
            return default;
        }

        public async Task<TEntity> IsInWishlistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_wishlist, FILE: product_wishlist.py, METHOD: _is_in_wishlist) ---
            */
            return default;
        }

        public async Task<TEntity> IsSoldOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py, METHOD: _is_sold_out) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _lang_get) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_event.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object config) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_event.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object config) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _load_pos_data_read) ---
            --- METHOD SOURCE (MODULE: pos_discount, FILE: product_template.py, METHOD: _load_pos_data_read) ---
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataSearchReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _load_pos_data_search_read) ---
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: product_template.py, METHOD: _load_pos_data_search_read) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosSelfDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _load_pos_self_data_domain) ---
            */
            return default;
        }

        public async Task<TEntity> LoadPosSelfDataReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _load_pos_self_data_read) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadProductFromPosAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id, object domain, object offset, object limit) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: load_product_from_pos) ---
            */
            return default;
        }

        public async Task<TEntity> LoadProductWithDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object load_archived, object offset, object limit) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _load_product_with_domain) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetOperationForMailMessageOperationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message_operation) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _mail_get_operation_for_mail_message_operation) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _mail_get_partner_fields) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _mail_get_partner_fields) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _mail_get_timezone) ---
            */
            return default;
        }

        public async Task<TEntity> MarkAsOffensiveBatchAsync<TEntity>(IEnumerable<TEntity> entities, object key, object values) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: mark_as_offensive_batch) ---
            */
            return default;
        }

        public async Task<TEntity> MarkAsOffensiveInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid reason_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _mark_as_offensive) ---
            */
            return default;
        }

        public async Task<TEntity> MessageAddDefaultRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _message_add_default_recipients) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _message_post_after_hook) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: message_post) ---
            */
            return default;
        }

        public async Task<TEntity> MoveCategorySlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object new_category) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _move_category_slides) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameSearchAsync<TEntity>(IEnumerable<TEntity> entities, object name, object domain, object @operator, object limit) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: name_search) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyStateUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _notify_state_update) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadByInboxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object msg_vals) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _notify_thread_by_inbox) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _notify_thread_by_inbox) ---
            */
            return default;
        }

        public async Task<TEntity> OnChangeAvailableInPosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _on_change_available_in_pos) ---
            */
            return default;
        }

        public async Task<TEntity> OnChangeDocumentBinaryContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _on_change_document_binary_content) ---
            */
            return default;
        }

        public async Task<TEntity> OnChangeSlideCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _on_change_slide_category) ---
            */
            return default;
        }

        public async Task<TEntity> OnChangeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _on_change_url) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAvailableInPosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _onchange_available_in_pos) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeBuyRouteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: product.py, METHOD: _onchange_buy_route) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _onchange_event_url) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeSaleOkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _onchange_sale_ok) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeSeatsMaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _onchange_seats_max) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _onchange_service_fields) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _onchange_service_policy) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py, METHOD: _onchange_service_to_purchase) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _onchange_service_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _onchange_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeEventBoothInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py, METHOD: _onchange_type_event_booth) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeEventInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: product_template.py, METHOD: _onchange_type_event) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _onchange_type) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_type) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _onchange_type) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _onchange_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_uom_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _onchange_website_published) ---
            */
            return default;
        }

        public async Task<TEntity> OpenTrackSpeakersListAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: open_track_speakers_list) ---
            */
            return default;
        }

        public async Task<TEntity> OpenWebsiteUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: open_website_url) ---
            */
            return default;
        }

        public async Task<TEntity> OrderFieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @alias, object field_name, object direction, object nulls, object query) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _order_field_to_sql) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PostProcessResponseFromCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request, object response) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _post_process_response_from_cache) ---
            */
            return default;
        }

        public async Task<TEntity> PostPublicationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _post_publication) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoicingTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _prepare_invoicing_tooltip) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _prepare_invoicing_tooltip) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _prepare_invoicing_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareServiceTrackingTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py, METHOD: _prepare_service_tracking_tooltip) ---
            --- METHOD SOURCE (MODULE: event_sale, FILE: product_template.py, METHOD: _prepare_service_tracking_tooltip) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _prepare_service_tracking_tooltip) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _prepare_service_tracking_tooltip) ---
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: product_template.py, METHOD: _prepare_service_tracking_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _prepare_tooltip) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _prepare_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareVariantValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _prepare_variant_values) ---
            */
            return default;
        }

        public async Task<TEntity> PriceComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price_type, object uom, object currency, object company, object date) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _price_compute) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessPosSelfUiProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _process_pos_self_ui_products) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessPosUiProductProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products, Guid config_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _process_pos_ui_product_product) ---
            */
            return default;
        }

        public async Task<TEntity> RatingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _rating_domain) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _rating_domain) ---
            */
            return default;
        }

        public async Task<TEntity> ReadGroupCategIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object categories, object domain) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _read_group_categ_id) ---
            */
            return default;
        }

        public async Task<TEntity> RefuseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _refuse) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveMembershipInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _remove_membership) ---
            */
            return default;
        }

        public async Task<TEntity> ReopenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: reopen) ---
            */
            return default;
        }

        public async Task<TEntity> ResequenceSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slide, object force_category) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _resequence_slides) ---
            */
            return default;
        }

        public async Task<TEntity> SearchAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_address_search) ---
            */
            return default;
        }

        public async Task<TEntity> SearchBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_barcode) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchBuildDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_build_dates) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchBuildDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain_list, object search, object fields, object extra) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: mixins.py, METHOD: _search_build_domain) ---
            */
            return default;
        }

        public async Task<TEntity> SearchCanViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _search_can_view) ---
            */
            return default;
        }

        public async Task<TEntity> SearchCurrentJobSkillIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_job.py, METHOD: _search_current_job_skill_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_display_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchFetchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object search_detail, object search, object limit, object order) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: mixins.py, METHOD: _search_fetch) ---
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _search_fetch) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: mixins.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_tag.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchHasPublishedProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _search_has_published_products) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIncomingQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_incoming_qty) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_is_finished) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsKitsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _search_is_kits) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberChannelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invited) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member_channel_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberInvitedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member_invited) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_is_ongoing) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsParticipatingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_is_participating) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_visible) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsVisibleOnWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_is_visible_on_website) ---
            */
            return default;
        }

        public async Task<TEntity> SearchOutgoingQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_outgoing_qty) ---
            */
            return default;
        }

        public async Task<TEntity> SearchPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchQtyAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_qty_available) ---
            */
            return default;
        }

        public async Task<TEntity> SearchRenderResultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fetch_fields, object mapping, object icon, object limit) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: mixins.py, METHOD: _search_render_results) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _search_render_results) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_render_results) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _search_render_results) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _search_render_results) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _search_render_results) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _search_render_results) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _search_render_results) ---
            */
            return default;
        }

        public async Task<TEntity> SearchRenderResultsPricesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mapping, object combination_info) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _search_render_results_prices) ---
            */
            return default;
        }

        public async Task<TEntity> SearchStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> SearchValuationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _search_valuation) ---
            */
            return default;
        }

        public async Task<TEntity> SearchVirtualAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_virtual_available) ---
            */
            return default;
        }

        public async Task<TEntity> SearchWishlistVisitorIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _search_wishlist_visitor_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SelectionServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _selection_service_policy) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _selection_service_policy) ---
            */
            return default;
        }

        public async Task<TEntity> SendShareEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object fullscreen) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _send_share_email) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _send_share_email) ---
            */
            return default;
        }

        public async Task<TEntity> ServiceTrackingBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            --- METHOD SOURCE (MODULE: event_product, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            */
            return default;
        }

        public async Task<TEntity> SetBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> SetBaseUnitCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _set_base_unit_count) ---
            */
            return default;
        }

        public async Task<TEntity> SetBaseUnitIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _set_base_unit_id) ---
            */
            return default;
        }

        public async Task<TEntity> SetDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> SetDefaultFaqInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _set_default_faq) ---
            */
            return default;
        }

        public async Task<TEntity> SetOpenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: set_open) ---
            */
            return default;
        }

        public async Task<TEntity> SetPostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _set_post_date) ---
            */
            return default;
        }

        public async Task<TEntity> SetProductVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_product_variant_field) ---
            */
            return default;
        }

        public async Task<TEntity> SetSequenceBottomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_bottom) ---
            */
            return default;
        }

        public async Task<TEntity> SetSequenceDownAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_down) ---
            */
            return default;
        }

        public async Task<TEntity> SetSequenceTopAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_top) ---
            */
            return default;
        }

        public async Task<TEntity> SetSequenceUpAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_up) ---
            */
            return default;
        }

        public async Task<TEntity> SetStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> SetTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _set_teaser) ---
            */
            return default;
        }

        public async Task<TEntity> SetTzContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _set_tz_context) ---
            */
            return default;
        }

        public async Task<TEntity> SetViewedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _set_viewed) ---
            */
            return default;
        }

        public async Task<TEntity> SetVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_volume) ---
            */
            return default;
        }

        public async Task<TEntity> SetWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_weight) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldOpenProductQuantsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _should_open_product_quants) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _should_open_product_quants) ---
            */
            return default;
        }

        public async Task<TEntity> SplitMenusStateByFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _split_menus_state_by_field) ---
            */
            return default;
        }

        public async Task<TEntity> SynchronizeWithPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _synchronize_with_partner) ---
            */
            return default;
        }

        public async Task<TEntity> SynchronizeWithStageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stage) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _synchronize_with_stage) ---
            */
            return default;
        }

        public async Task<TEntity> TagToWriteValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tags) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _tag_to_write_vals) ---
            */
            return default;
        }

        public async Task<TEntity> ToMarkupDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _to_markup_data) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleBoothMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py, METHOD: toggle_booth_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleExhibitorMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: toggle_exhibitor_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: toggle_website_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteTrackAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: toggle_website_track) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteTrackProposalAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: toggle_website_track_proposal) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _track_template) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkCommentAsync<TEntity>(IEnumerable<TEntity> entities, Guid message_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: unlink_comment) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptLoyaltyProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: product_template.py, METHOD: _unlink_except_loyalty_products) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptMasterDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _unlink_except_master_data) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptOpenSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _unlink_except_open_session) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfEnoughKarmaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _unlink_if_enough_karma) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object content, Guid forum_id) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _update_content) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateLastActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _update_last_activity) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateWebsiteMenuEntryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname_bool, object fname_o2m, object fmenu_type) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _update_website_menu_entry) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateWebsiteMenusInternalAsync<TEntity>(IEnumerable<TEntity> entities, object menus_update_by_field) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _update_website_menus) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: validate) ---
            */
            return default;
        }

        public async Task<TEntity> VerifySeatsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot_tickets) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _verify_seats_availability) ---
            */
            return default;
        }

        public async Task<TEntity> VoteAsync<TEntity>(IEnumerable<TEntity> entities, object upvote) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: vote) ---
            */
            return default;
        }

        public async Task<TEntity> WebsiteShowQuickAddInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _website_show_quick_add) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsiteSearchableMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: write) ---
            */
            return default;
        }
    }
}