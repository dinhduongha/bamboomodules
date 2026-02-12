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
    public partial class WebsitePublishedMultiMixinAppService : ApplicationService, IWebsitePublishedMultiMixinAppService
    {

        public WebsitePublishedMultiMixinAppService() 
        {

        }

        public async Task<TEntity> ActionAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partners, object member_status, object raise_on_access) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_add_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: action_archive) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionBomCostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: product.py, METHOD: action_bom_cost) ---
            */
            return default;
        }

        public async Task<TEntity> ActionChannelEnrollAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_channel_enroll) ---
            */
            return default;
        }

        public async Task<TEntity> ActionChannelInviteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_channel_invite) ---
            */
            return default;
        }

        public async Task<TEntity> ActionChannelOpenInviteWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template, object enroll_mode) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_channel_open_invite_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateProductVariantsFromGelatoTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py, METHOD: action_create_product_variants_from_gelato_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: action_done) ---
            */
            return default;
        }

        public async Task<TEntity> ActionEventViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: action_event_view) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGenerateLeadsAsync<TEntity>(IEnumerable<TEntity> entities, object event_lead_rules) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_event.py, METHOD: action_generate_leads) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGrantAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_grant_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionInviteContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py, METHOD: action_invite_contacts) ---
            --- METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py, METHOD: action_invite_contacts) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ActionLoadRecruitmentScenarioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _action_load_recruitment_scenario) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMassMailingAttendeesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py, METHOD: action_mass_mailing_attendees) ---
            --- METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py, METHOD: action_mass_mailing_attendees) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMassMailingTrackSpeakersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event_track, FILE: event_event.py, METHOD: action_mass_mailing_track_speakers) ---
            --- METHOD SOURCE (MODULE: mass_mailing_event_track_sms, FILE: event.py, METHOD: action_mass_mailing_track_speakers) ---
            */
            return default;
        }

        public async Task<TEntity> ActionNewSurveyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_job.py, METHOD: action_new_survey) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenActivitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: action_open_activities) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: action_open_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenBusinessDocAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: action_open_business_doc) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenDocumentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: action_open_documents) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenEmployeesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: action_open_employees) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenLabelLayoutAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: action_open_label_layout) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenProductLotAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_open_product_lot) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenQuantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_open_quants) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenRoutesDiagramAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_open_routes_diagram) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenSlotCalendarAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: action_open_slot_calendar) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPageDebugViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: action_page_debug_view) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPrivacyLookupAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: privacy_lookup, FILE: res_partner.py, METHOD: action_privacy_lookup) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProductTmplForecastReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_product_tmpl_forecast_report) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToCompletedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_completed_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToEngagedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_engaged_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToInvitedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_invited_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToMembersAsync<TEntity>(IEnumerable<TEntity> entities, object status_filter) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRefuseAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_refuse_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRequestAccessAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_request_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRequestAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_request_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSearchMatchingApplicantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_job.py, METHOD: action_search_matching_applicants) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: action_set_done) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _action_show) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSignupPrepareAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: action_signup_prepare) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSyncGelatoTemplateInfoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: action_sync_gelato_template_info) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTestSurveyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_job.py, METHOD: action_test_survey) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnarchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_unarchive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUsedInBomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: action_used_in_bom) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewCertificationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: res_partner.py, METHOD: action_view_certifications) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewCoursesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: action_view_courses) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewLinkedOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_event.py, METHOD: action_view_linked_orders) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewLivechatSessionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: action_view_livechat_sessions) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewLoyaltyCardsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: res_partner.py, METHOD: action_view_loyalty_cards) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewMosAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: action_view_mos) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewOpportunityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: action_view_opportunity) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewOrderpointsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_orderpoints) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewPartnerInvoicesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: action_view_partner_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewPoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: action_view_po) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewPosOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: action_view_pos_order) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRatingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_view_ratings) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRelatedPutawayRulesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_related_putaway_rules) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewSalesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: action_view_sales) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewSlidesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_view_slides) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewStockMoveLinesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_stock_move_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewStockSerialAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_partner.py, METHOD: action_view_stock_serial) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewStorageCategoryCapacityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_storage_category_capacity) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: action_view_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> AddArchivedCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _add_archived_combinations) ---
            */
            return default;
        }

        public async Task<TEntity> AddGroupsMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _add_groups_members) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _address_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _address_fields) ---
            */
            return default;
        }

        public async Task<TEntity> AddressGetAsync<TEntity>(IEnumerable<TEntity> entities, object adr_pref) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: address_get) ---
            */
            return default;
        }

        public async Task<TEntity> AddressIdDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _address_id_domain) ---
            */
            return default;
        }

        public async Task<TEntity> AliasGetCreationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _alias_get_creation_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AllowCacheInsertionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object layout) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _allow_cache_insertion) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AllowPublishRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _allow_publish_rating_stats) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _allow_publish_rating_stats) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AllowToUseCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _allow_to_use_cache) ---
            */
            return default;
        }

        public async Task<TEntity> ApplyMarginsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _apply_margins) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ApplyTaxesToPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price, object currency, object product_taxes, object taxes, object product_or_template, object website) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _apply_taxes_to_price) ---
            */
            return default;
        }

        public async Task<TEntity> AssetDifferenceSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object account_type, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _asset_difference_search) ---
            */
            return default;
        }

        public async Task<TEntity> AutoInitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _auto_init) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AutocompleteByNameAsync<TEntity>(IEnumerable<TEntity> entities, object query, Guid query_country_id, object timeout) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: autocomplete_by_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AutocompleteByVatAsync<TEntity>(IEnumerable<TEntity> entities, object vat, Guid query_country_id, object timeout) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: autocomplete_by_vat) ---
            */
            return default;
        }

        public async Task<TEntity> AvailableCarriersAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object source) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: available_carriers) ---
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: delivery_carrier.py, METHOD: available_carriers) ---
            */
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderPathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py, METHOD: _avatar_get_placeholder_path) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _avatar_get_placeholder_path) ---
            */
            return default;
        }

        public async Task<TEntity> BaseDomainItemIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _base_domain_item_ids) ---
            */
            return default;
        }

        public async Task<TEntity> BaseOnRuleCancelShipmentAsync<TEntity>(IEnumerable<TEntity> entities, object pickings) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: base_on_rule_cancel_shipment) ---
            */
            return default;
        }

        public async Task<TEntity> BaseOnRuleGetTrackingLinkAsync<TEntity>(IEnumerable<TEntity> entities, object picking) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: delivery_carrier.py, METHOD: base_on_rule_get_tracking_link) ---
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: base_on_rule_get_tracking_link) ---
            */
            return default;
        }

        public async Task<TEntity> BaseOnRuleRateShipmentAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: base_on_rule_rate_shipment) ---
            */
            return default;
        }

        public async Task<TEntity> BaseOnRuleSendShippingAsync<TEntity>(IEnumerable<TEntity> entities, object pickings) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: base_on_rule_send_shipping) ---
            */
            return default;
        }

        public async Task<TEntity> BuildErrorPeppolEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eas, object endpoint) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _build_error_peppol_endpoint) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> BuildVatErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object wrong_vat, object record_label) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _build_vat_error_message) ---
            */
            return default;
        }

        public async Task<TEntity> BuildVcardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: res_partner.py, METHOD: _build_vcard) ---
            */
            return default;
        }

        public async Task<TEntity> BusSendHistoryMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object channel, object page_history) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _bus_send_history_message) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonAccountPeppolCheckPartnerEndpointAsync<TEntity>(IEnumerable<TEntity> entities, object company) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: button_account_peppol_check_partner_endpoint) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonBomCostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: product.py, METHOD: button_bom_cost) ---
            */
            return default;
        }

        public async Task<TEntity> CanBeAddedToCartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _can_be_added_to_cart) ---
            */
            return default;
        }

        public async Task<TEntity> CanBeEditedByCurrentCustomerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py, METHOD: _can_be_edited_by_current_customer) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _can_be_edited_by_current_customer) ---
            */
            return default;
        }

        public async Task<TEntity> CanEditCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _can_edit_country) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _can_edit_country) ---
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _can_edit_country) ---
            */
            return default;
        }

        public async Task<TEntity> CanEditVatAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: can_edit_vat) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: can_edit_vat) ---
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: can_edit_vat) ---
            */
            return default;
        }

        public async Task<TEntity> CanReturnContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object access_token) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _can_return_content) ---
            */
            return default;
        }

        public async Task<TEntity> CancelShipmentAsync<TEntity>(IEnumerable<TEntity> entities, object pickings) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: cancel_shipment) ---
            */
            return default;
        }

        public async Task<TEntity> CartesianProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_template_attribute_values_per_line, object parent_combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _cartesian_product) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUnicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_barcode_unicity) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUniquenessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_barcode_uniqueness) ---
            */
            return default;
        }

        public async Task<TEntity> CheckClosingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_closing_date) ---
            */
            return default;
        }

        public async Task<TEntity> CheckComboIdsNotEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_combo_ids_not_empty) ---
            */
            return default;
        }

        public async Task<TEntity> CheckComboInclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _check_combo_inclusions) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDataSourceIsProvidedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _check_data_source_is_provided) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDocumentTypeSupportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object participant_info, object ubl_cii_format, object process_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _check_document_type_support) ---
            */
            return default;
        }

        public async Task<TEntity> CheckEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_event_url) ---
            */
            return default;
        }

        public async Task<TEntity> CheckFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _check_field_names) ---
            */
            return default;
        }

        public async Task<TEntity> CheckForPublicationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _check_for_publication) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckImportConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_import_consistency) ---
            */
            return default;
        }

        public async Task<TEntity> CheckInStoreDmHasWarehousesWhenPublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py, METHOD: _check_in_store_dm_has_warehouses_when_published) ---
            */
            return default;
        }

        public async Task<TEntity> CheckIncompatibleTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _check_incompatible_types) ---
            */
            return default;
        }

        public async Task<TEntity> CheckLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _check_limit) ---
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPartnerCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_partner_company) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPeppolFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _check_peppol_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckPeppolParticipantExistsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object participant_info, object edi_identification) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _check_peppol_participant_exists) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPrintImagesAreSetBeforePublishingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py, METHOD: _check_print_images_are_set_before_publishing) ---
            */
            return default;
        }

        public async Task<TEntity> CheckProjectAndTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _check_project_and_template) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSaleComboIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_sale_combo_ids) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSaleProductCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _check_sale_product_company) ---
            */
            return default;
        }

        public async Task<TEntity> CheckServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py, METHOD: _check_service_to_purchase) ---
            */
            return default;
        }

        public async Task<TEntity> CheckServiceTrackingForEventBoothsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py, METHOD: _check_service_tracking_for_event_booths) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSlotsDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_slots_dates) ---
            */
            return default;
        }

        public async Task<TEntity> CheckTagsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _check_tags) ---
            */
            return default;
        }

        public async Task<TEntity> CheckUomNotInInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _check_uom_not_in_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> CheckUserHasModelAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _check_user_has_model_access) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatAlAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_al) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatBrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_br) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatChAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ch) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatCrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_cr) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatDeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_de) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatDoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_do) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatEcAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ec) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatGrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_gr) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatGtAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_gt) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatHuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_hu) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatIdAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatIeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ie) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatIlAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_il) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatInAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_in) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object validation) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _check_vat) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatJpAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_jp) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatMaAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ma) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatMxAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_mx) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatNoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_no) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckVatNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object vat_number) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _check_vat_number) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatPeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_pe) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatPhAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ph) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatRoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ro) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatRsAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_rs) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatRuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ru) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatSaAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_sa) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatThAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_th) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatTrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_tr) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatTwAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_tw) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatUaAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ua) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatUyAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_uy) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatVeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ve) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatVnAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_vn) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVendorForServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sellers) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py, METHOD: _check_vendor_for_service_to_purchase) ---
            */
            return default;
        }

        public async Task<TEntity> CheckWarehousesHaveSameCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py, METHOD: _check_warehouses_have_same_company) ---
            */
            return default;
        }

        public async Task<TEntity> CheckWebsiteIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _check_website_id) ---
            */
            return default;
        }

        public async Task<TEntity> ChildrenSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _children_sync) ---
            */
            return default;
        }

        public async Task<TEntity> CleanWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _clean_website) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ClearRemovedEdiFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _clear_removed_edi_formats) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ClonePageAsync<TEntity>(IEnumerable<TEntity> entities, Guid page_id, object page_name, object clone_menu) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: clone_page) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _commercial_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncFromCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_sync_from_company) ---
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncToDescendantsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_sync) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_sync_to_descendants) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CompanyDependentCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _company_dependent_commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CompanyDependentCommercialSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _company_dependent_commercial_sync) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CompleteInverseExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object exclusions) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _complete_inverse_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountMoveCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_account_move_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActionRightsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_action_rights) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActiveLangCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_active_lang_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActivitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_activities) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressInlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_address_inline) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_address_search) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_all_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowCommentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_allow_comment) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowedUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_job.py, METHOD: _compute_allowed_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicantHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_applicant_hired) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicantMatchingScoreInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_job.py, METHOD: _compute_applicant_matching_score) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatisticsHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_application_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailableInvoiceTemplatePdfReportIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_available_invoice_template_pdf_report_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePeppolEasInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_available_peppol_eas) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _compute_available_peppol_eas) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePeppolEdiFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _compute_available_peppol_edi_formats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePeppolSendingMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _compute_available_peppol_sending_methods) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_1024) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_128) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_1920) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_256) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_512) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBankCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_bank_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_price) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBomCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_bom_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBomIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_bom_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBoothMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py, METHOD: _compute_booth_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanBeExpensedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py, METHOD: _compute_can_be_expensed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanGenerateReturnInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _compute_can_generate_return) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanImage1024BeZoomedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_can_image_1024_be_zoomed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanPublishInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_can_publish) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_can_publish) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanUploadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_can_upload) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryAndSlideIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_category_and_slide_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCertificationsCompanyCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: res_partner.py, METHOD: _compute_certifications_company_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCertificationsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: res_partner.py, METHOD: _compute_certifications_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _compute_color) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialCompanyNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_commercial_company_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_commercial_partner) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommunityMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_community_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_complete_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactAddressInlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _compute_contact_address_inline) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_contact_address) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCostCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_cost_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCostMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _compute_cost_method) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountActiveCardsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: res_partner.py, METHOD: _compute_count_active_cards) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCreditToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_credit_to_invoice) ---
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _compute_credit_to_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object price, object conversion) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _compute_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentJobSkillIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_job.py, METHOD: _compute_current_job_skill_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_date_tz) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDaysSalesOutstandingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_days_sales_outstanding) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_partner.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDocumentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_document_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFormattedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_email_formatted) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeeCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_employee_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _compute_employee) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _compute_employees_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_job.py, METHOD: _compute_employees) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEnrollInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_enroll) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCategoryAvailableIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_category_available_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCategoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_category_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _compute_event_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_mail_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegisterUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_event_register_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_open) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsSoldOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_sold_out) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsStartedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_started) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventShareUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_event_share_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventSlotCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_slot_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventTicketIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_ticket_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExhibitorMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: _compute_exhibitor_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExpensePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py, METHOD: _compute_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: product_template.py, METHOD: _compute_expense_policy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExpensePolicyTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py, METHOD: _compute_expense_policy_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExtendedInterviewerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_extended_interviewer_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFieldIsOneDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_field_is_one_day) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalCountryCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _compute_fiscal_country_codes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalCountryGroupCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_fiscal_country_group_codes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalPositionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_fiscal_position_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFixedPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _compute_fixed_price) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFullUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _compute_full_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGelatoMissingImagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _compute_gelato_missing_images) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGelatoProductUidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _compute_gelato_product_uid) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGetIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_get_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasAvailableRouteIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_has_available_route_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasConfigurableAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_has_configurable_attributes) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ComputeHasRequestedAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_has_requested_access) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py, METHOD: _compute_im_status) ---
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: res_partner.py, METHOD: _compute_im_status) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _compute_im_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImplementedPartnerCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _compute_implemented_partner_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_invoice_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_invoice_emails) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_invoice_policy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsDynamicallyCreatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_is_dynamically_created) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_is_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_is_finished) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsHomepageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_is_homepage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInCallInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _compute_is_in_call) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsKitsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_is_kits) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMondialrelayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: delivery_carrier.py, METHOD: _compute_is_mondialrelay) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_is_ongoing) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsParticipatingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_is_participating) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPeppolEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_is_peppol_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_is_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPublicInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_is_public) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsStorableAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: compute_is_storable) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsSubcontractorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_is_subcontractor) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsUblFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_is_ubl_format) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_is_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsVisibleOnWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_is_visible_on_website) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeKanbanStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_kanban_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_lang) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLeadCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_event.py, METHOD: _compute_lead_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLeaveDateToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py, METHOD: _compute_leave_date_to) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatChannelCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _compute_livechat_channel_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLotValuatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _compute_lot_valuated) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMainUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_main_user_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _compute_meeting_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _compute_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMembersCountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_members_counts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMembershipValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_membership_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeModelNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _compute_model_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMrpProductQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_mrp_product_qty) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _compute_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNameSlugifiedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _compute_name_slugified) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNbrMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_nbr_moves) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNbrReorderingRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_nbr_reordering_rules) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNewApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_new_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNextSerialInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_next_serial) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNoOfHiredEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_no_of_hired_employee) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_note) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOldApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_old_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOnTimeRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: res_partner.py, METHOD: _compute_on_time_rate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOpenApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_open_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOpportunityCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: _compute_opportunity_count) ---
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _compute_opportunity_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerCompanyRegistryPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_partner_company_registry_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerHasNewContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_partner_has_new_content) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerIapInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_plugin, FILE: res_partner.py, METHOD: _compute_partner_iap_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShareInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_partner_share) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerVatPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_partner_vat_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _compute_partner_weight) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_partners) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentTokenCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: res_partner.py, METHOD: _compute_payment_token_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePeppolEasInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_peppol_eas) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePeppolEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_peppol_endpoint) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePerformViesValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _compute_perform_vies_validation) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePickingIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_picking_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePosContactAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_pos_contact_address) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePosOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_pos_order) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_post_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePrerequisiteUserHasCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_prerequisite_user_has_completed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductDocumentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_document_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_partner.py, METHOD: _compute_product_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_tooltip) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_product_tooltip) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _compute_product_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductVariantCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_variant_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_variant_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_production_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePublishDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_publish_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePublishedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _compute_published_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _compute_purchase_method) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseOkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py, METHOD: _compute_purchase_ok) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_purchase_ok) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: res_partner.py, METHOD: _compute_purchase_order_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchasedProductQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _compute_purchased_product_qty) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuantitiesDictInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_quantities_dict) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuantitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_quantities) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_question_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_rating_stats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSaleOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _compute_sale_order_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSalePriceTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_event.py, METHOD: _compute_sale_price_total) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSalesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_sales_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSameVatPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_same_vat_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsLimitedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats_limited) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsMaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats_max) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSelfOrderVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _compute_self_order_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSerialPrefixFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_serial_prefix_format) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _compute_service_policy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_service_tracking) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_service_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_service_type) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: product_template.py, METHOD: _compute_service_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceUpsellThresholdRatioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _compute_service_upsell_threshold_ratio) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowCreditLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_show_credit_limit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowQtyStatusButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_show_qty_status_button) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_show_qty_status_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowQtyUpdateButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_show_qty_update_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSkillIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_job.py, METHOD: _compute_skill_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideChannelCompanyCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _compute_slide_channel_company_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideChannelValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _compute_slide_channel_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideLastUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_slide_last_update) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlidesStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_slides_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSponsorCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: _compute_sponsor_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStartSaleDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_start_sale_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStaticMapUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _compute_static_map_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStaticMapUrlIsValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _compute_static_map_url_is_valid) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStreetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _compute_street_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSupplierInvoiceCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_supplier_invoice_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSupportsShippingInsuranceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _compute_supports_shipping_insurance) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_tag_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _compute_task_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _compute_task_template) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxStringInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _compute_tax_string) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_teaser) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTemplateFieldFromVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object @default) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_template_field_from_variant_field) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTicketInstructionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_ticket_instructions) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTimeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_time_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_track_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTracksTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_tracks_tag_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTypeAddressLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_type_address_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTzOffsetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_tz_offset) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUrlDemoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _compute_url_demo) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUseBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_use_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUsePartnerCreditLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_use_partner_credit_limit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUsedInBomCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_used_in_bom_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_user_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserLivechatUsernameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _compute_user_livechat_username) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_user_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeValidProductTemplateAttributeLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_valid_product_template_attribute_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeValuationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _compute_valuation) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVariantsDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_variants_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVatLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_vat_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeViesValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _compute_vies_valid) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVisibleExpensePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_visible_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py, METHOD: _compute_visible_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _compute_visible_expense_policy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_volume) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _compute_volume_uom_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteAbsoluteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_absolute_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteDefaultBackgroundImageUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_default_background_image_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteMenuDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_website_menu_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_website_menu) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_website_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: mixins.py, METHOD: _compute_website_published) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteTrackInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_website_track) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteTrackProposalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_website_track_proposal) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_weight) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWeightUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _compute_weight_uom_name) ---
            */
            return default;
        }

        public async Task<TEntity> ConstructTaxStringInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _construct_tax_string) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertFieldsToValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _convert_fields_to_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ConvertHuLocalToEuVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object local_vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _convert_hu_local_to_eu_vat) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CopyEventMenusAsync<TEntity>(IEnumerable<TEntity> entities, object old_events) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: copy_event_menus) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAttributesFromGelatoInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_info) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _create_attributes_from_gelato_info) ---
            --- METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py, METHOD: _create_attributes_from_gelato_info) ---
            */
            return default;
        }

        public async Task<TEntity> CreateCompanyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: create_company) ---
            */
            return default;
        }

        public async Task<TEntity> CreateContactParentCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _create_contact_parent_company) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _create_contact_parent_company) ---
            */
            return default;
        }

        public async Task<TEntity> CreateFirstProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object log_warning) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_first_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> CreateMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sequence, object name, object url, Guid xml_id, object menu_type, object parent_menu_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _create_menu) ---
            */
            return default;
        }

        public async Task<TEntity> CreatePortalUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _create_portal_users) ---
            */
            return default;
        }

        public async Task<TEntity> CreatePrintImagesFromGelatoInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_info) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _create_print_images_from_gelato_info) ---
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> product_template_attribute_value_ids) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: create_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantFromPosAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attribute_value_ids, Guid config_id) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: create_product_variant_from_pos) ---
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object log_warning) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> CreateVariantIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_variant_ids) ---
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _creation_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> CreditDebitGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _credit_debit_get) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreditSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _credit_search) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DebitSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _debit_search) ---
            */
            return default;
        }

        public async Task<TEntity> DeduceCountryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _deduce_country_code) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _default_access_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultAddressIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _default_address_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _default_category) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_tag.py, METHOD: _default_color) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_content) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCoverPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _default_cover_properties) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _default_cover_properties) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_description) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultDisplayInvoiceTemplatePdfReportIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _default_display_invoice_template_pdf_report_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_event_mail_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_tag.py, METHOD: default_get) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultIsPublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _default_is_published) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_tag_category.py, METHOD: _default_is_published) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultPosSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _default_pos_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_question_ids) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultResponsibleIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _default_responsible_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_tag.py, METHOD: _default_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultWebsiteMetaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_website_meta) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _default_website_meta) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _default_website_meta) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultWebsiteSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _default_website_sequence) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DemoConfigureVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _demo_configure_variants) ---
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _display_address_depends) ---
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _display_address) ---
            */
            return default;
        }

        public async Task<TEntity> DoButtonPrintAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_button_print) ---
            */
            return default;
        }

        public async Task<TEntity> DoPartnerMailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_mail) ---
            */
            return default;
        }

        public async Task<TEntity> DoPartnerManualActionAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_manual_action) ---
            */
            return default;
        }

        public async Task<TEntity> DoPartnerManualActionDermanordAsync<TEntity>(IEnumerable<TEntity> entities, object followup_line) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_manual_action_dermanord) ---
            */
            return default;
        }

        public async Task<TEntity> DoPartnerPrintAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> wizard_partner_ids, object data) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_print) ---
            */
            return default;
        }

        public async Task<TEntity> DomainPricelistRuleIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _domain_pricelist_rule_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EnrichByDomainAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object timeout) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: enrich_by_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EnrichByDunsAsync<TEntity>(IEnumerable<TEntity> entities, object duns, object timeout) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: enrich_by_duns) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EnrichByGstAsync<TEntity>(IEnumerable<TEntity> entities, object gst, object timeout) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: enrich_by_gst) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureSameCompanyThanProjectsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _ensure_same_company_than_projects) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureSameCompanyThanTasksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _ensure_same_company_than_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureUnusedInPosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _ensure_unused_in_pos) ---
            */
            return default;
        }

        public async Task<TEntity> FetchChildrenPartnersForHierarchyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: _fetch_children_partners_for_hierarchy) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FetchIsParticipatingEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _fetch_is_participating_events) ---
            */
            return default;
        }

        public async Task<TEntity> FieldStoreReprInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _field_store_repr) ---
            */
            return default;
        }

        public async Task<TEntity> FieldsSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _fields_sync) ---
            */
            return default;
        }

        public async Task<TEntity> FieldsViewGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type, object toolbar, object submenu) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: fields_view_get) ---
            */
            return default;
        }

        public async Task<TEntity> FillSampleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object sample, object index) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _fill_sample) ---
            */
            return default;
        }

        public async Task<TEntity> FilterAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object raise_on_access) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _filter_add_members) ---
            */
            return default;
        }

        public async Task<TEntity> FilterCombinationsImpossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination_tuples, object ignore_no_variant) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _filter_combinations_impossible_by_config) ---
            */
            return default;
        }

        public async Task<TEntity> FilterRecordsToValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _filter_records_to_values) ---
            */
            return default;
        }

        public async Task<TEntity> FindAccountingPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _find_accounting_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FindOrCreateAsync<TEntity>(IEnumerable<TEntity> entities, object email, object assert_valid_email) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: find_or_create) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: find_or_create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FindOrCreateFromEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails, object ban_emails, object filter_found, object additional_values, object no_create, object sort_key, object sort_reverse) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _find_or_create_from_emails) ---
            */
            return default;
        }

        public async Task<TEntity> FixedCancelShipmentAsync<TEntity>(IEnumerable<TEntity> entities, object pickings) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: fixed_cancel_shipment) ---
            */
            return default;
        }

        public async Task<TEntity> FixedGetTrackingLinkAsync<TEntity>(IEnumerable<TEntity> entities, object picking) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: delivery_carrier.py, METHOD: fixed_get_tracking_link) ---
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: fixed_get_tracking_link) ---
            */
            return default;
        }

        public async Task<TEntity> FixedRateShipmentAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: fixed_rate_shipment) ---
            */
            return default;
        }

        public async Task<TEntity> FixedSendShippingAsync<TEntity>(IEnumerable<TEntity> entities, object pickings) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: fixed_send_shipping) ---
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultPurchaseTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _force_default_purchase_tax) ---
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultSaleTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _force_default_sale_tax) ---
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _force_default_tax) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormatDataCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _format_data_company) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatChAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_ch) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatClAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_cl) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatCoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_co) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatEuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_eu) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatHuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_hu) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormatVatNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _format_vat_number) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatSmAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_sm) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatVnAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_vn) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormattingAddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _formatting_address_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GcMarkEventsDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _gc_mark_events_done) ---
            */
            return default;
        }

        public async Task<TEntity> GelatoPrepareAddressPayloadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: res_partner.py, METHOD: _gelato_prepare_address_payload) ---
            */
            return default;
        }

        public async Task<TEntity> GelatoRateShipmentAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: delivery_carrier.py, METHOD: gelato_rate_shipment) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateSignupTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expiration) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _generate_signup_token) ---
            */
            return default;
        }

        public async Task<TEntity> GeoLocalizeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: res_partner.py, METHOD: geo_localize) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GeoLocalizeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object street, object zip, object city, object state, object country) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: res_partner.py, METHOD: _geo_localize) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _get_access_action) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_access_action) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_access_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountStatisticsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_account_statistics_count) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetActionViewRelatedPutawayRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _get_action_view_related_putaway_rules) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAdditionalConfiguratorDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_additional_configurator_data) ---
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py, METHOD: _get_additional_configurator_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetAdditionnalCombinationInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object uom, object date, object website) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_additionnal_combination_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: res_partner.py, METHOD: _get_address_format) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_address_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetAddressValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_address_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllAddrInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _get_all_addr) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_all_addr) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAlternativeProductFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_alternative_product_filter) ---
            */
            return default;
        }

        public async Task<TEntity> GetAmountsAndDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_amounts_and_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetAssetAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: product.py, METHOD: _get_asset_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttendeeDetailAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> meeting_ids) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: get_attendee_detail) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object parent_name, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_attribute_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttributeValueDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attribute_value_dict) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_attribute_value_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttributesExtraPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_attributes_extra_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvailableUomsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_available_uoms) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: get_backend_menu_id) ---
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: get_backend_menu_id) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: get_backend_menu_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackendRootMenuIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _get_backend_root_menu_ids) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _get_backend_root_menu_ids) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_backend_root_menu_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetBaseUnitPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_base_unit_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetBoothStatCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _get_booth_stat_count) ---
            */
            return default;
        }

        public async Task<TEntity> GetBusyCalendarEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object end_datetime) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _get_busy_calendar_events) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_cache_key) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCanPublishErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_can_publish_error_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetCategorizedSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_domain, object order, object force_void, object limit, object offset) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_categorized_slides) ---
            */
            return default;
        }

        public async Task<TEntity> GetClosestPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_closest_possible_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetClosestPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_closest_possible_combinations) ---
            */
            return default;
        }

        public async Task<TEntity> GetCombinationInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, Guid product_id, object add_qty, Guid uom_id, object only_template) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_combination_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetCommercialValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_commercial_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetCommoditiesFromOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: _get_commodities_from_order) ---
            */
            return default;
        }

        public async Task<TEntity> GetCommoditiesFromStockMoveLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_lines) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: _get_commodities_from_stock_move_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_company_currency) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyRegistryLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_company_registry_labels) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_complete_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetConfiguratorDisplayPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_configurator_display_price) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetConfiguratorPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_configurator_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetContactOpportunitiesDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: _get_contact_opportunities_domain) ---
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _get_contact_opportunities_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetContextualPriceAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_contextual_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetContextualPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_contextual_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetContextualPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_contextual_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> GetConversionCurrenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object conversion) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _get_conversion_currencies) ---
            */
            return default;
        }

        public async Task<TEntity> GetCountryNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: res_partner.py, METHOD: _get_country_name) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_country_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetCurrentPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _get_current_partner) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py, METHOD: _get_current_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCurrentPersonaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_current_persona) ---
            */
            return default;
        }

        public async Task<TEntity> GetDateRangeStrInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object lang_code) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_date_range_str) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_default_address_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultCustomPackageCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: _get_default_custom_package_code) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultEnrollMsgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_default_enroll_msg) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultFavoriteUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _get_default_favorite_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultJobDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _get_default_job_details) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_default_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_default_uom_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultWebsiteDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _get_default_website_description) ---
            */
            return default;
        }

        public async Task<TEntity> GetDeliveryAddressDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: res_partner.py, METHOD: _get_delivery_address_domain) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _get_delivery_address_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetDeliveryDocPrefixInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: _get_delivery_doc_prefix) ---
            */
            return default;
        }

        public async Task<TEntity> GetDeliveryLabelPrefixInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: _get_delivery_label_prefix) ---
            */
            return default;
        }

        public async Task<TEntity> GetDeliveryTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _get_delivery_type) ---
            */
            return default;
        }

        public async Task<TEntity> GetEarnedKarmaInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_earned_karma) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEdiBuilderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_edi_format) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_edi_builder) ---
            */
            return default;
        }

        public async Task<TEntity> GetEmployeesFromAttendeesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object everybody) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: _get_employees_from_attendees) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_empty_list_help) ---
            */
            return default;
        }

        public async Task<TEntity> GetEventResourceUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_event_resource_urls) ---
            */
            return default;
        }

        public async Task<TEntity> GetExternalDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_external_description) ---
            */
            return default;
        }

        public async Task<TEntity> GetExternalDescriptionUrlEncodedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_external_description_url_encoded) ---
            */
            return default;
        }

        public async Task<TEntity> GetFieldNameAndTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field_name) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _get_field_name_and_type) ---
            */
            return default;
        }

        public async Task<TEntity> GetFilterMetaDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _get_filter_meta_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_first_possible_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstPossibleVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_first_possible_variant_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstStageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _get_first_stage) ---
            */
            return default;
        }

        public async Task<TEntity> GetFollowupOverdueQueryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object args, object overdue_only) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_followup_overdue_query) ---
            */
            return default;
        }

        public async Task<TEntity> GetFollowupTableHtmlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: get_followup_table_html) ---
            */
            return default;
        }

        public async Task<TEntity> GetFrontendWritableFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_frontend_writable_fields) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _get_frontend_writable_fields) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _get_frontend_writable_fields) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py, METHOD: _get_frontend_writable_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetGeneralToServiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_policy, object service_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_general_to_service) ---
            */
            return default;
        }

        public async Task<TEntity> GetGeneralToServiceMapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_general_to_service_map) ---
            */
            return default;
        }

        public async Task<TEntity> GetGoogleAnalyticsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, object combination_info) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_google_analytics_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetHardcodedSampleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _get_hardcoded_sample) ---
            */
            return default;
        }

        public async Task<TEntity> GetIcsFileInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_ics_file) ---
            */
            return default;
        }

        public async Task<TEntity> GetImStatusAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_im_status_access_token) ---
            */
            return default;
        }

        public async Task<TEntity> GetImageHolderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_image_holder) ---
            */
            return default;
        }

        public async Task<TEntity> GetImagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_images) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetIncompatibleTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_incompatible_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetKioskUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: get_kiosk_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetLatestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_latest) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetLengthUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_length_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetLengthUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_length_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        public async Task<TEntity> GetListPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _get_list_price) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_list_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetLoginDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_login_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetMappedAttributeNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_mapped_attribute_names) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMentionSuggestionsAsync<TEntity>(IEnumerable<TEntity> entities, object search, object limit) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: get_mention_suggestions) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMentionSuggestionsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object search) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_mention_suggestions_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMentionSuggestionsFromChannelAsync<TEntity>(IEnumerable<TEntity> entities, Guid channel_id, object search, object limit) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: get_mention_suggestions_from_channel) ---
            */
            return default;
        }

        public async Task<TEntity> GetMentionTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_mention_token) ---
            */
            return default;
        }

        public async Task<TEntity> GetMenuTypeFieldMatchingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_menu_type_field_matching) ---
            */
            return default;
        }

        public async Task<TEntity> GetMenuUpdateFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_menu_update_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetMenusUpdateByFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object menus_state_by_field, object force_update) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_menus_update_by_field) ---
            */
            return default;
        }

        public async Task<TEntity> GetMostSpecificPagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_most_specific_pages) ---
            */
            return default;
        }

        public async Task<TEntity> GetNeedactionCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_needaction_count) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNewPartnerAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id, object domain, object offset) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: get_new_partner) ---
            */
            return default;
        }

        public async Task<TEntity> GetNextCheckoutStepInternalAsync<TEntity>(IEnumerable<TEntity> entities, object allowed_steps_domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website_checkout_step.py, METHOD: _get_next_checkout_step) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOnLeaveIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py, METHOD: _get_on_leave_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOnchangeServicePolicyUpdatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service_tracking, object service_policy, Guid project_id, Guid project_template_id) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _get_onchange_service_policy_updates) ---
            */
            return default;
        }

        public async Task<TEntity> GetOwnAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_own_attribute_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> GetPackagesFromOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object default_package_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: _get_packages_from_order) ---
            */
            return default;
        }

        public async Task<TEntity> GetPackagesFromPickingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object picking, object default_package_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: _get_packages_from_picking) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPageInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_page_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetParentAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_parent_attribute_exclusions) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetParticipantInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object edi_identification) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _get_participant_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPartnerFromTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_partner_from_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPartnerLocalisationFieldsRequiredToInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, Guid country_id) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: get_partner_localisation_fields_required_to_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_partners) ---
            */
            return default;
        }

        public async Task<TEntity> GetPeppolEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_peppol_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetPeppolEndpointValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object field, object eas) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_peppol_endpoint_value) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPeppolFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_peppol_formats) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPeppolVerificationStateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object peppol_endpoint, object peppol_eas, object invoice_edi_format, object process_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _get_peppol_verification_state) ---
            */
            return default;
        }

        public async Task<TEntity> GetPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_placeholder_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_possible_combinations) ---
            */
            return default;
        }

        public async Task<TEntity> GetPossibleVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_possible_variants) ---
            */
            return default;
        }

        public async Task<TEntity> GetPossibleVariantsSortedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_possible_variants_sorted) ---
            */
            return default;
        }

        public async Task<TEntity> GetPreviewedAttributeValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object product_query_params) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_previewed_attribute_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetPreviousCheckoutStepInternalAsync<TEntity>(IEnumerable<TEntity> entities, object allowed_steps_domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: website_checkout_step.py, METHOD: _get_previous_checkout_step) ---
            */
            return default;
        }

        public async Task<TEntity> GetPriceAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _get_price_available) ---
            */
            return default;
        }

        public async Task<TEntity> GetPriceDictInternalAsync<TEntity>(IEnumerable<TEntity> entities, object total, object weight, object volume, object quantity, object wv) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _get_price_dict) ---
            */
            return default;
        }

        public async Task<TEntity> GetPriceFromPickingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object total, object weight, object volume, object quantity, object wv) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _get_price_from_picking) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductAccountsAsync<TEntity>(IEnumerable<TEntity> entities, object fiscal_pos) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: get_product_accounts) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: get_product_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _get_product_accounts) ---
            --- METHOD SOURCE (MODULE: mrp_account, FILE: product.py, METHOD: _get_product_accounts) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _get_product_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductDocumentDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_document_domain) ---
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _get_product_document_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductInfoPosAsync<TEntity>(IEnumerable<TEntity> entities, object price, object quantity, Guid pos_config_id, Guid product_variant_id) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: get_product_info_pos) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_placeholder_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_price_context) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetProductTypesAllowZeroPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_product_types_allow_zero_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object query_params, object grouped_attributes_values) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_product_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetRelatedFieldsVariantTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_related_fields_variant_template) ---
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _get_related_fields_variant_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetResponseCachedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_response_cached) ---
            */
            return default;
        }

        public async Task<TEntity> GetResponseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_response) ---
            */
            return default;
        }

        public async Task<TEntity> GetResponseRawInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _get_response_raw) ---
            */
            return default;
        }

        public async Task<TEntity> GetReturnLabelAsync<TEntity>(IEnumerable<TEntity> entities, object pickings, object tracking_number, object origin_date) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: get_return_label) ---
            */
            return default;
        }

        public async Task<TEntity> GetReturnLabelPrefixAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: get_return_label_prefix) ---
            */
            return default;
        }

        public async Task<TEntity> GetRibbonInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price_vals, object auto_assign_ribbons, object variant) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_ribbon) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSaleOrderDomainCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _get_sale_order_domain_count) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSaleableTrackingTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partnership, FILE: product_template.py, METHOD: _get_saleable_tracking_types) ---
            --- METHOD SOURCE (MODULE: repair, FILE: product.py, METHOD: _get_saleable_tracking_types) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_saleable_tracking_types) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_saleable_tracking_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetSalesPricesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_sales_prices) ---
            */
            return default;
        }

        public async Task<TEntity> GetScheduleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_period, object stop_period, object everybody, object merge) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: _get_schedule) ---
            */
            return default;
        }

        public async Task<TEntity> GetSeatsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot_tickets) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_seats_availability) ---
            */
            return default;
        }

        public async Task<TEntity> GetServiceToGeneralInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service_policy) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_service_to_general) ---
            */
            return default;
        }

        public async Task<TEntity> GetServiceToGeneralMapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_service_to_general_map) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _get_service_to_general_map) ---
            */
            return default;
        }

        public async Task<TEntity> GetSignupUrlForActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url, object action, object view_type, Guid menu_id, Guid res_id, object model) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_signup_url_for_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetSignupUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_signup_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetSingleProductVariantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_single_product_variant) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: get_single_product_variant) ---
            --- METHOD SOURCE (MODULE: sale_product_matrix, FILE: product_template.py, METHOD: get_single_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> GetSlotTicketsAvailabilityPosAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> slot_ticket_ids) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_event.py, METHOD: get_slot_tickets_availability_pos) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreAvatarCardFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _get_store_avatar_card_fields) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_store_avatar_card_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreLivechatUsernameFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _get_store_livechat_username_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreMentionFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_store_mention_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStreetSplitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _get_street_split) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_street_split) ---
            */
            return default;
        }

        public async Task<TEntity> GetSuggestedInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_suggested_invoice_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetSuggestedPeppolEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_suggested_peppol_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetSuggestedUblCiiEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_suggested_ubl_cii_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetSuitableImageSizeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object columns, object x_size, object y_size) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_suitable_image_size) ---
            */
            return default;
        }

        public async Task<TEntity> GetSyncedCommercialValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_synced_commercial_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetTemplateMatrixInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product_matrix, FILE: product_template.py, METHOD: _get_template_matrix) ---
            */
            return default;
        }

        public async Task<TEntity> GetTicketsAccessHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> registration_ids) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_tickets_access_hash) ---
            */
            return default;
        }

        public async Task<TEntity> GetTrackingLinkAsync<TEntity>(IEnumerable<TEntity> entities, object picking) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: get_tracking_link) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUblCiiFormatsByCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_ubl_cii_formats_by_country) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUblCiiFormatsInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_ubl_cii_formats_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUblCiiFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_ubl_cii_formats) ---
            */
            return default;
        }

        public async Task<TEntity> GetVariantForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_variant_for_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetVariantIdForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filtered_combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_variant_id_for_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetVatRequiredValidInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_vat_required_valid) ---
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _get_vat_required_valid) ---
            */
            return default;
        }

        public async Task<TEntity> GetVcardFileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: res_partner.py, METHOD: _get_vcard_file) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_view_cache_key) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _get_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetVolumeUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_volume_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetVolumeUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_volume_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteAccessoryProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_website_accessory_product) ---
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteAlternativeProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_website_alternative_product) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWebsiteCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _get_website_currency) ---
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteMenuEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_website_menu_entries) ---
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteMetaAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: get_website_meta) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWeightUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_weight_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWeightUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_weight_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWorkingHoursForAllAttendeesAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attendee_ids, object date_from, object date_to, object everybody) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: get_working_hours_for_all_attendees) ---
            */
            return default;
        }

        public async Task<TEntity> GetWorklocationAsync<TEntity>(IEnumerable<TEntity> entities, object start_date, object end_date) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_homeworking_calendar, FILE: res_partner.py, METHOD: get_worklocation) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapImgAsync<TEntity>(IEnumerable<TEntity> entities, object zoom, object width, object height) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_partner.py, METHOD: google_map_img) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_partner.py, METHOD: google_map_link) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: google_map_link) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _google_map_link) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapSignedImgInternalAsync<TEntity>(IEnumerable<TEntity> entities, object zoom, object width, object height) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _google_map_signed_img) ---
            */
            return default;
        }

        public async Task<TEntity> HandleFirstContactCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _handle_first_contact_creation) ---
            */
            return default;
        }

        public async Task<TEntity> HasDynamicAttributesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: has_dynamic_attributes) ---
            */
            return default;
        }

        public async Task<TEntity> HasInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _has_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> HasIsCustomValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _has_is_custom_values) ---
            */
            return default;
        }

        public async Task<bool> HasMultipleUomsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _has_multiple_uoms) ---
            */
            return default;
        }

        public async Task<TEntity> HasNoVariantAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _has_no_variant_attributes) ---
            */
            return default;
        }

        public async Task<TEntity> HasOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _has_order) ---
            */
            return default;
        }

        public async Task<TEntity> HasPublishedTrackInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _has_published_track) ---
            */
            return default;
        }

        public async Task<TEntity> IapPartnerAutocompleteGetTagIdsAsync<TEntity>(IEnumerable<TEntity> entities, object unspsc_codes) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: iap_partner_autocomplete_get_tag_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IapReplaceIndustryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _iap_replace_industry_code) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IapReplaceLanguageCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _iap_replace_language_codes) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IapReplaceLocationCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _iap_replace_location_codes) ---
            */
            return default;
        }

        public async Task<TEntity> IeCheckCharInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _ie_check_char) ---
            */
            return default;
        }

        public async Task<TEntity> InStoreGetCloseLocationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_address, Guid product_id) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py, METHOD: _in_store_get_close_locations) ---
            */
            return default;
        }

        public async Task<TEntity> InStoreRateShipmentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_collect, FILE: delivery_carrier.py, METHOD: in_store_rate_shipment) ---
            */
            return default;
        }

        public async Task<TEntity> IncreaseRankInternalAsync<TEntity>(IEnumerable<TEntity> entities, string field, int n) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _increase_rank) ---
            */
            return default;
        }

        public async Task<TEntity> InitColumnInternalAsync<TEntity>(IEnumerable<TEntity> entities, object column_name) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _init_column) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _init_column) ---
            */
            return default;
        }

        public async Task<TEntity> InstallMoreProviderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: install_more_provider) ---
            */
            return default;
        }

        public async Task<TEntity> IntervalToBusinessHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities, object working_intervals) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: _interval_to_business_hours) ---
            */
            return default;
        }

        public async Task<TEntity> InverseGelatoProductUidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _inverse_gelato_product_uid) ---
            */
            return default;
        }

        public async Task<TEntity> InverseInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _inverse_invoice_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> InverseIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _inverse_is_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> InverseNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _inverse_name) ---
            */
            return default;
        }

        public async Task<TEntity> InverseNameSlugifiedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: _inverse_name_slugified) ---
            */
            return default;
        }

        public async Task<TEntity> InverseProductPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_partner.py, METHOD: _inverse_product_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> InverseQtyAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _inverse_qty_available) ---
            */
            return default;
        }

        public async Task<TEntity> InverseSerialPrefixFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _inverse_serial_prefix_format) ---
            */
            return default;
        }

        public async Task<TEntity> InverseServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _inverse_service_policy) ---
            */
            return default;
        }

        public async Task<TEntity> InverseStreetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _inverse_street_data) ---
            */
            return default;
        }

        public async Task<TEntity> InverseUsePartnerCreditLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _inverse_use_partner_credit_limit) ---
            */
            return default;
        }

        public async Task<TEntity> InverseVatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _inverse_vat) ---
            */
            return default;
        }

        public async Task<TEntity> InverseWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: mixins.py, METHOD: _inverse_website_published) ---
            */
            return default;
        }

        public async Task<TEntity> InvoiceTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _invoice_total) ---
            */
            return default;
        }

        public async Task<TEntity> IsAddToCartPossibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _is_add_to_cart_possible) ---
            */
            return default;
        }

        public async Task<TEntity> IsAvailableForOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _is_available_for_order) ---
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: delivery_carrier.py, METHOD: _is_available_for_order) ---
            */
            return default;
        }

        public async Task<TEntity> IsCombinationPossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _is_combination_possible_by_config) ---
            */
            return default;
        }

        public async Task<TEntity> IsCombinationPossibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object parent_combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _is_combination_possible) ---
            */
            return default;
        }

        public async Task<TEntity> IsInWishlistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_wishlist, FILE: product_wishlist.py, METHOD: _is_in_wishlist) ---
            */
            return default;
        }

        public async Task<TEntity> IsSoldOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py, METHOD: _is_sold_out) ---
            */
            return default;
        }

        public async Task<TEntity> IsValidRucEcAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: is_valid_ruc_ec) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _lang_get) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_event.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object config) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_event.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object config) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _load_pos_data_read) ---
            --- METHOD SOURCE (MODULE: pos_discount, FILE: product_template.py, METHOD: _load_pos_data_read) ---
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataSearchReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _load_pos_data_search_read) ---
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: product_template.py, METHOD: _load_pos_data_search_read) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosSelfDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _load_pos_self_data_domain) ---
            */
            return default;
        }

        public async Task<TEntity> LoadPosSelfDataReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _load_pos_self_data_read) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadProductFromPosAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id, object domain, object offset, object limit) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: load_product_from_pos) ---
            */
            return default;
        }

        public async Task<TEntity> LoadProductWithDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object load_archived, object offset, object limit) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _load_product_with_domain) ---
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _load_records_create) ---
            */
            return default;
        }

        public async Task<TEntity> LogVerificationStateUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object old_value, object new_value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _log_verification_state_update) ---
            */
            return default;
        }

        public async Task<TEntity> LogXmlAsync<TEntity>(IEnumerable<TEntity> entities, object xml_string, object func) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: log_xml) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetOperationForMailMessageOperationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message_operation) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _mail_get_operation_for_mail_message_operation) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _mail_get_partner_fields) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _mail_get_partners) ---
            */
            return default;
        }

        public async Task<TEntity> MatchAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _match_address) ---
            */
            return default;
        }

        public async Task<TEntity> MatchExcludedTagsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object source) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _match_excluded_tags) ---
            */
            return default;
        }

        public async Task<TEntity> MatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object source) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _match) ---
            */
            return default;
        }

        public async Task<TEntity> MatchMustHaveTagsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object source) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _match_must_have_tags) ---
            */
            return default;
        }

        public async Task<TEntity> MatchVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object source) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _match_volume) ---
            */
            return default;
        }

        public async Task<TEntity> MatchWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities, object source) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _match_weight) ---
            */
            return default;
        }

        public async Task<TEntity> MergeMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object destination, object source) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _merge_method) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: message_post) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MondialrelaySearchOrCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py, METHOD: _mondialrelay_search_or_create) ---
            */
            return default;
        }

        public async Task<TEntity> MoveCategorySlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object new_category) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _move_category_slides) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: name_create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameSearchAsync<TEntity>(IEnumerable<TEntity> entities, object name, object domain, object @operator, object limit) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: name_search) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadByInboxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object msg_vals) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _notify_thread_by_inbox) ---
            */
            return default;
        }

        public async Task<TEntity> OnChangeAvailableInPosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _on_change_available_in_pos) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAvailableInPosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _onchange_available_in_pos) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeBuyRouteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: product.py, METHOD: _onchange_buy_route) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCanGenerateReturnInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _onchange_can_generate_return) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCityIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _onchange_city_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: onchange_company_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _onchange_country_id) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_country_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCountryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _onchange_country_ids) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _onchange_event_url) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeIntegrationLevelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _onchange_integration_level) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: onchange_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePhoneValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: res_partner.py, METHOD: _onchange_phone_validation) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePropertyProductPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py, METHOD: _onchange_property_product_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeReturnLabelOnDeliveryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _onchange_return_label_on_delivery) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeSaleOkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _onchange_sale_ok) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeSeatsMaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _onchange_seats_max) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _onchange_service_fields) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _onchange_service_policy) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py, METHOD: _onchange_service_to_purchase) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _onchange_service_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_state) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _onchange_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeEventBoothInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py, METHOD: _onchange_type_event_booth) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeEventInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: product_template.py, METHOD: _onchange_type_event) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _onchange_type) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_type) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _onchange_type) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _onchange_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_uom_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeVatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _onchange_vat) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeVerifyPeppolStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _onchange_verify_peppol_status) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _onchange_website_published) ---
            */
            return default;
        }

        public async Task<TEntity> OpenCommercialEntityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: open_commercial_entity) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: open_commercial_entity) ---
            */
            return default;
        }

        public async Task<TEntity> OpenWebsiteUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: mixins.py, METHOD: open_website_url) ---
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: open_website_url) ---
            */
            return default;
        }

        public async Task<TEntity> OrderFieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @alias, object field_name, object direction, object nulls, object query) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _order_field_to_sql) ---
            */
            return default;
        }

        public async Task<TEntity> OrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _order) ---
            */
            return default;
        }

        public async Task<TEntity> PaymentDueSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _payment_due_search) ---
            */
            return default;
        }

        public async Task<TEntity> PaymentEarliestDateSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _payment_earliest_date_search) ---
            */
            return default;
        }

        public async Task<TEntity> PaymentOverdueSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _payment_overdue_search) ---
            */
            return default;
        }

        public async Task<TEntity> PeppolEasEndpointDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _peppol_eas_endpoint_depends) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PeppolLookupParticipantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object edi_identification) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _peppol_lookup_participant) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PostProcessResponseFromCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request, object response) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _post_process_response_from_cache) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareDisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _prepare_display_address) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoicingTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _prepare_invoicing_tooltip) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _prepare_invoicing_tooltip) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _prepare_invoicing_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareSampleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object length) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _prepare_sample) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareSampleRecordsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object length) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _prepare_sample_records) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareServiceTrackingTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
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

        public async Task<TEntity> PrepareTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _prepare_tooltip) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _prepare_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object limit, object search_domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _prepare_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareVariantValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _prepare_variant_values) ---
            */
            return default;
        }

        public async Task<TEntity> PriceComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price_type, object uom, object currency, object company, object date) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _price_compute) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ProcessEnrichedResponseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object response, object error) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _process_enriched_response) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessPosSelfUiProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _process_pos_self_ui_products) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessPosUiProductProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products, Guid config_id) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _process_pos_ui_product_product) ---
            */
            return default;
        }

        public async Task<TEntity> ProductPriceToCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object quantity, object product, object company) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: _product_price_to_company_currency) ---
            */
            return default;
        }

        public async Task<TEntity> RateShipmentAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: rate_shipment) ---
            */
            return default;
        }

        public async Task<TEntity> RatingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _rating_domain) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _rating_domain) ---
            */
            return default;
        }

        public async Task<TEntity> ReadGroupCategIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object categories, object domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _read_group_categ_id) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveMembershipInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _remove_membership) ---
            */
            return default;
        }

        public async Task<TEntity> RenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_key, object limit, object search_domain, object with_sample, object res_model, Guid res_id) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_snippet_filter.py, METHOD: _render) ---
            */
            return default;
        }

        public async Task<TEntity> ResequenceSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slide, object force_category) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _resequence_slides) ---
            */
            return default;
        }

        public async Task<TEntity> RetrievePartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object phone, object email, object vat, object domain, object company) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrievePartnerWithNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object extra_domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner_with_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrievePartnerWithPhoneEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object phone, object email, object extra_domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner_with_phone_email) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrievePartnerWithVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat, object extra_domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner_with_vat) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RunVatChecksInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country, object vat, object partner_name, object validation) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _run_vat_checks) ---
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _run_vat_checks) ---
            */
            return default;
        }

        public async Task<TEntity> ScheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: schedule_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> SearchAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_address_search) ---
            */
            return default;
        }

        public async Task<TEntity> SearchBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_barcode) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchBuildDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_build_dates) ---
            */
            return default;
        }

        public async Task<TEntity> SearchCurrentJobSkillIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_job.py, METHOD: _search_current_job_skill_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_display_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchFetchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object search_detail, object search, object limit, object order) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _search_fetch) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchForChannelInviteAsync<TEntity>(IEnumerable<TEntity> entities, object search_term, Guid channel_id, object limit) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: search_for_channel_invite) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchForChannelInviteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object search_term, Guid channel_id, object limit) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _search_for_channel_invite) ---
            */
            return default;
        }

        public async Task<TEntity> SearchForChannelInviteToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object channel) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _search_for_channel_invite_to_store) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _search_for_channel_invite_to_store) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIncomingQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_incoming_qty) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_is_finished) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsKitsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _search_is_kits) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberChannelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invited) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member_channel_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberInvitedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member_invited) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMondialrelayInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: delivery_carrier.py, METHOD: _search_is_mondialrelay) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_is_ongoing) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsParticipatingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_is_participating) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsSubcontractorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _search_is_subcontractor) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_visible) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsVisibleOnWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_is_visible_on_website) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchMentionSuggestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object limit, object extra_domain) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _search_mention_suggestions) ---
            */
            return default;
        }

        public async Task<TEntity> SearchOutgoingQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_outgoing_qty) ---
            */
            return default;
        }

        public async Task<TEntity> SearchPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchQtyAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_qty_available) ---
            */
            return default;
        }

        public async Task<TEntity> SearchRenderResultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fetch_fields, object mapping, object icon, object limit) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_render_results) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _search_render_results) ---
            */
            return default;
        }

        public async Task<TEntity> SearchRenderResultsPricesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mapping, object combination_info) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _search_render_results_prices) ---
            */
            return default;
        }

        public async Task<TEntity> SearchSlideChannelCompletedIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _search_slide_channel_completed_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchSlideChannelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _search_slide_channel_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> SearchValuationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _search_valuation) ---
            */
            return default;
        }

        public async Task<TEntity> SearchVirtualAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_virtual_available) ---
            */
            return default;
        }

        public async Task<TEntity> SearchWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: mixins.py, METHOD: _search_website_published) ---
            */
            return default;
        }

        public async Task<TEntity> SelectionServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _selection_service_policy) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _selection_service_policy) ---
            */
            return default;
        }

        public async Task<TEntity> SendShareEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _send_share_email) ---
            */
            return default;
        }

        public async Task<TEntity> SendShippingAsync<TEntity>(IEnumerable<TEntity> entities, object pickings) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: delivery_carrier.py, METHOD: send_shipping) ---
            */
            return default;
        }

        public async Task<TEntity> ServiceTrackingBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            --- METHOD SOURCE (MODULE: event_product, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            */
            return default;
        }

        public async Task<TEntity> SetBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> SetBaseUnitCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _set_base_unit_count) ---
            */
            return default;
        }

        public async Task<TEntity> SetBaseUnitIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _set_base_unit_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SetCalendarLastNotifAckInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _set_calendar_last_notif_ack) ---
            */
            return default;
        }

        public async Task<TEntity> SetDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> SetOpenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: set_open) ---
            */
            return default;
        }

        public async Task<TEntity> SetPostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _set_post_date) ---
            */
            return default;
        }

        public async Task<TEntity> SetProductFixedPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: _set_product_fixed_price) ---
            */
            return default;
        }

        public async Task<TEntity> SetProductVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_product_variant_field) ---
            */
            return default;
        }

        public async Task<TEntity> SetSequenceBottomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_bottom) ---
            */
            return default;
        }

        public async Task<TEntity> SetSequenceDownAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_down) ---
            */
            return default;
        }

        public async Task<TEntity> SetSequenceTopAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_top) ---
            */
            return default;
        }

        public async Task<TEntity> SetSequenceUpAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_up) ---
            */
            return default;
        }

        public async Task<TEntity> SetStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> SetTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _set_teaser) ---
            */
            return default;
        }

        public async Task<TEntity> SetTzContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _set_tz_context) ---
            */
            return default;
        }

        public async Task<TEntity> SetVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_volume) ---
            */
            return default;
        }

        public async Task<TEntity> SetWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_weight) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldOpenProductQuantsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _should_open_product_quants) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _should_open_product_quants) ---
            */
            return default;
        }

        public async Task<TEntity> SignupCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: signup_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> SignupGetAuthParamAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: signup_get_auth_param) ---
            */
            return default;
        }

        public async Task<TEntity> SignupPrepareAsync<TEntity>(IEnumerable<TEntity> entities, object signup_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: signup_prepare) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SignupRetrieveInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _signup_retrieve_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SignupRetrievePartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token, object check_validity, object raise_exception) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _signup_retrieve_partner) ---
            */
            return default;
        }

        public async Task<TEntity> SplitMenusStateByFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _split_menus_state_by_field) ---
            */
            return default;
        }

        public async Task<TEntity> SplitVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _split_vat) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SyncedCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_partner.py, METHOD: _synced_commercial_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _synced_commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> ToMarkupDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _to_markup_data) ---
            */
            return default;
        }

        public async Task<TEntity> ToStoreDefaultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py, METHOD: _to_store_defaults) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleBoothMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py, METHOD: toggle_booth_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleDebugAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: toggle_debug) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleExhibitorMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: toggle_exhibitor_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleProdEnvironmentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: delivery_carrier.py, METHOD: toggle_prod_environment) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: toggle_website_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteTrackAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: toggle_website_track) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteTrackProposalAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: toggle_website_track_proposal) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkContactRelEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _unlink_contact_rel_employee) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptLoyaltyProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: product_template.py, METHOD: _unlink_except_loyalty_products) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptMasterDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _unlink_except_master_data) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptOpenSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _unlink_except_open_session) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _unlink_except_user) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfPartnerInAccountMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _unlink_if_partner_in_account_move) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfPosNoOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _unlink_if_pos_no_orders) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _update_address) ---
            */
            return default;
        }

        public async Task<TEntity> UpdatePeppolStatePerCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _update_peppol_state_per_company) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateWebsiteMenuEntryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname_bool, object fname_o2m, object fmenu_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _update_website_menu_entry) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateWebsiteMenusInternalAsync<TEntity>(IEnumerable<TEntity> entities, object menus_update_by_field) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _update_website_menus) ---
            */
            return default;
        }

        public async Task<TEntity> VerifySeatsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot_tickets) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _verify_seats_availability) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ViewHeaderGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: view_header_get) ---
            */
            return default;
        }

        public async Task<TEntity> WebsiteShowQuickAddInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _website_show_quick_add) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: website_controller_page.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website, FILE: website_page.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: write) ---
            */
            return default;
        }

        public async Task<TEntity> WriteCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePublishedMultiMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _write_company_type) ---
            */
            return default;
        }
    }
}