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
    public partial class WebsiteSeoMetadataAppService : ApplicationService, IWebsiteSeoMetadataAppService
    {

        public WebsiteSeoMetadataAppService() 
        {

        }

        public async Task<TEntity> ActionAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partners, object member_status, object raise_on_access) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_add_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: action_archive) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionBomCostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: product.py, METHOD: action_bom_cost) ---
            */
            return default;
        }

        public async Task<TEntity> ActionChannelEnrollAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_channel_enroll) ---
            */
            return default;
        }

        public async Task<TEntity> ActionChannelInviteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_channel_invite) ---
            */
            return default;
        }

        public async Task<TEntity> ActionChannelOpenInviteWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template, object enroll_mode) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_channel_open_invite_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateProductVariantsFromGelatoTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py, METHOD: action_create_product_variants_from_gelato_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDislikeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_dislike) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: action_done) ---
            */
            return default;
        }

        public async Task<TEntity> ActionEventViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: action_event_view) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGenerateLeadsAsync<TEntity>(IEnumerable<TEntity> entities, object event_lead_rules) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_event.py, METHOD: action_generate_leads) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGrantAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_grant_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionInviteContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py, METHOD: action_invite_contacts) ---
            --- METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py, METHOD: action_invite_contacts) ---
            */
            return default;
        }

        public async Task<TEntity> ActionLikeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_like) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ActionLoadRecruitmentScenarioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _action_load_recruitment_scenario) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMarkCompletedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_mark_completed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMarkCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_mark_completed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMarkUncompletedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_mark_uncompleted) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMassMailingAttendeesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py, METHOD: action_mass_mailing_attendees) ---
            --- METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py, METHOD: action_mass_mailing_attendees) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMassMailingTrackSpeakersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event_track, FILE: event_event.py, METHOD: action_mass_mailing_track_speakers) ---
            --- METHOD SOURCE (MODULE: mass_mailing_event_track_sms, FILE: event.py, METHOD: action_mass_mailing_track_speakers) ---
            */
            return default;
        }

        public async Task<TEntity> ActionNewSurveyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_job.py, METHOD: action_new_survey) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenActivitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: action_open_activities) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: action_open_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenBusinessDocAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: action_open_business_doc) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenDocumentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: action_open_documents) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenEmployeesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: action_open_employees) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenLabelLayoutAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: action_open_label_layout) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenProductLotAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_open_product_lot) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenQuantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_open_quants) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenRoutesDiagramAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_open_routes_diagram) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenSlotCalendarAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: action_open_slot_calendar) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPrivacyLookupAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: privacy_lookup, FILE: res_partner.py, METHOD: action_privacy_lookup) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProductTmplForecastReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_product_tmpl_forecast_report) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToCompletedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_completed_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToEngagedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_engaged_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToInvitedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_invited_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToMembersAsync<TEntity>(IEnumerable<TEntity> entities, object status_filter) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRefuseAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_refuse_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRequestAccessAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_request_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRequestAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_request_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSearchMatchingApplicantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_job.py, METHOD: action_search_matching_applicants) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: action_set_done) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetQuizDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object completed) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_set_quiz_done) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetViewedAsync<TEntity>(IEnumerable<TEntity> entities, object quiz_attempts_inc) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_set_viewed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetViewedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partner, object quiz_attempts_inc) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_set_viewed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _action_show) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSignupPrepareAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: action_signup_prepare) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSyncGelatoTemplateInfoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: action_sync_gelato_template_info) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTestSurveyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_job.py, METHOD: action_test_survey) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnarchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_unarchive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUsedInBomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: action_used_in_bom) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewCertificationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: res_partner.py, METHOD: action_view_certifications) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewCoursesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: action_view_courses) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewEmbedsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_view_embeds) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewLinkedOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_event.py, METHOD: action_view_linked_orders) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewLivechatSessionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: action_view_livechat_sessions) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewLoyaltyCardsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: res_partner.py, METHOD: action_view_loyalty_cards) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewMosAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: action_view_mos) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewOpportunityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: action_view_opportunity) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewOrderpointsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_orderpoints) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewPartnerInvoicesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: action_view_partner_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewPoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: action_view_po) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewPosOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: action_view_pos_order) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRatingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_view_ratings) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRelatedPutawayRulesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_related_putaway_rules) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewSalesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: action_view_sales) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewSlidesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_view_slides) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewStockMoveLinesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_stock_move_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewStockSerialAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_partner.py, METHOD: action_view_stock_serial) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewStorageCategoryCapacityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: action_view_storage_category_capacity) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: action_view_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionVoteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object upvote) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_vote) ---
            */
            return default;
        }

        public async Task<TEntity> AddArchivedCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _add_archived_combinations) ---
            */
            return default;
        }

        public async Task<TEntity> AddGroupsMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _add_groups_members) ---
            */
            return default;
        }

        public async Task<TEntity> AddMissingFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _add_missing_fields) ---
            */
            return default;
        }

        public async Task<TEntity> AddValidationFlagInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combined_arch, object view, object arch) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _add_validation_flag) ---
            #endif
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _address_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _address_fields) ---
            */
            return default;
        }

        public async Task<TEntity> AddressGetAsync<TEntity>(IEnumerable<TEntity> entities, object adr_pref) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: address_get) ---
            */
            return default;
        }

        public async Task<TEntity> AddressIdDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _address_id_domain) ---
            */
            return default;
        }

        public async Task<TEntity> AliasGetCreationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _alias_get_creation_values) ---
            */
            return default;
        }

        public async Task<TEntity> AllTagsAsync<TEntity>(IEnumerable<TEntity> entities, object @join, object min_limit) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: all_tags) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AllowPublishRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _allow_publish_rating_stats) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _allow_publish_rating_stats) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ApplyInheritanceSpecsAsync<TEntity>(IEnumerable<TEntity> entities, object source, object specs_tree, object pre_locate) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: apply_inheritance_specs) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ApplyTaxesToPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price, object currency, object product_taxes, object taxes, object product_or_template, object website) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _apply_taxes_to_price) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AreArchsEqualInternalAsync<TEntity>(IEnumerable<TEntity> entities, object arch1, object arch2) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: _are_archs_equal) ---
            */
            return default;
        }

        public async Task<TEntity> AssetDifferenceSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object account_type, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _asset_difference_search) ---
            */
            return default;
        }

        public async Task<TEntity> AutoInitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _auto_init) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AutocompleteByNameAsync<TEntity>(IEnumerable<TEntity> entities, object query, Guid query_country_id, object timeout) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: autocomplete_by_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AutocompleteByVatAsync<TEntity>(IEnumerable<TEntity> entities, object vat, Guid query_country_id, object timeout) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: autocomplete_by_vat) ---
            */
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderPathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py, METHOD: _avatar_get_placeholder_path) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _avatar_get_placeholder_path) ---
            */
            return default;
        }

        public async Task<TEntity> BaseDomainItemIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _base_domain_item_ids) ---
            */
            return default;
        }

        public async Task<TEntity> BuildErrorPeppolEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eas, object endpoint) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _build_error_peppol_endpoint) ---
            */
            return default;
        }

        public async Task<TEntity> BuildHierarchyDatastructureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _build_hierarchy_datastructure) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> BuildVatErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object wrong_vat, object record_label) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _build_vat_error_message) ---
            */
            return default;
        }

        public async Task<TEntity> BuildVcardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: res_partner.py, METHOD: _build_vcard) ---
            */
            return default;
        }

        public async Task<TEntity> BusSendHistoryMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object channel, object page_history) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _bus_send_history_message) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonAccountPeppolCheckPartnerEndpointAsync<TEntity>(IEnumerable<TEntity> entities, object company) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: button_account_peppol_check_partner_endpoint) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonBomCostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: product.py, METHOD: button_bom_cost) ---
            */
            return default;
        }

        public async Task<TEntity> CanBeAddedToCartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _can_be_added_to_cart) ---
            */
            return default;
        }

        public async Task<TEntity> CanBeEditedByCurrentCustomerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py, METHOD: _can_be_edited_by_current_customer) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _can_be_edited_by_current_customer) ---
            */
            return default;
        }

        public async Task<TEntity> CanEditCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _can_edit_country) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _can_edit_country) ---
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _can_edit_country) ---
            */
            return default;
        }

        public async Task<TEntity> CanEditVatAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: can_edit_vat) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: can_edit_vat) ---
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: can_edit_vat) ---
            */
            return default;
        }

        public async Task<TEntity> CanReturnContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object access_token) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _can_return_content) ---
            */
            return default;
        }

        public async Task<TEntity> CartesianProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_template_attribute_values_per_line, object parent_combination) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _cartesian_product) ---
            */
            return default;
        }

        public async Task<TEntity> Check000InheritanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _check_000_inheritance) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUnicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_barcode_unicity) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUniquenessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_barcode_uniqueness) ---
            */
            return default;
        }

        public async Task<TEntity> CheckClosingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_closing_date) ---
            */
            return default;
        }

        public async Task<TEntity> CheckComboIdsNotEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_combo_ids_not_empty) ---
            */
            return default;
        }

        public async Task<TEntity> CheckComboInclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _check_combo_inclusions) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDocumentTypeSupportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object participant_info, object ubl_cii_format, object process_type) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _check_document_type_support) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDropdownMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _check_dropdown_menu) ---
            */
            return default;
        }

        public async Task<TEntity> CheckEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_event_url) ---
            */
            return default;
        }

        public async Task<TEntity> CheckFieldPathsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object field_paths, object model_name, object use) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _check_field_paths) ---
            */
            return default;
        }

        public async Task<TEntity> CheckForPublicationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _check_for_publication) ---
            */
            return default;
        }

        public async Task<TEntity> CheckGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _check_groups) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckImportConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_import_consistency) ---
            */
            return default;
        }

        public async Task<TEntity> CheckIncompatibleTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _check_incompatible_types) ---
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: check_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _check_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPartnerCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_partner_company) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPeppolFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _check_peppol_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckPeppolParticipantExistsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object participant_info, object edi_identification) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _check_peppol_participant_exists) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPrintImagesAreSetBeforePublishingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py, METHOD: _check_print_images_are_set_before_publishing) ---
            */
            return default;
        }

        public async Task<TEntity> CheckProgressBarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _check_progress_bar) ---
            */
            return default;
        }

        public async Task<TEntity> CheckProjectAndTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _check_project_and_template) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSaleComboIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_sale_combo_ids) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSaleProductCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _check_sale_product_company) ---
            */
            return default;
        }

        public async Task<TEntity> CheckServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py, METHOD: _check_service_to_purchase) ---
            */
            return default;
        }

        public async Task<TEntity> CheckServiceTrackingForEventBoothsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py, METHOD: _check_service_tracking_for_event_booths) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSlotsDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_slots_dates) ---
            */
            return default;
        }

        public async Task<TEntity> CheckUomNotInInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _check_uom_not_in_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatAlAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_al) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatBrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_br) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatChAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ch) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatCrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_cr) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatDeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_de) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatDoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_do) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatEcAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ec) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatGrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_gr) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatGtAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_gt) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatHuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_hu) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatIdAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatIeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ie) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatIlAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_il) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatInAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_in) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object validation) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _check_vat) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatJpAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_jp) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatMaAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ma) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatMxAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_mx) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatNoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_no) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckVatNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object vat_number) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _check_vat_number) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatPeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_pe) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatPhAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ph) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatRoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ro) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatRsAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_rs) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatRuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ru) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatSaAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_sa) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatThAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_th) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatTrAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_tr) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatTwAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_tw) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatUaAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ua) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatUyAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_uy) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatVeAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_ve) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVatVnAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: check_vat_vn) ---
            */
            return default;
        }

        public async Task<TEntity> CheckVendorForServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sellers) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py, METHOD: _check_vendor_for_service_to_purchase) ---
            */
            return default;
        }

        public async Task<TEntity> CheckViewAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _check_view_access) ---
            */
            return default;
        }

        public async Task<TEntity> CheckWebsiteIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _check_website_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckXmlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _check_xml) ---
            #endif
            return default;
        }

        public async Task<TEntity> ChildrenSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _children_sync) ---
            */
            return default;
        }

        public async Task<TEntity> CleanWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _clean_website) ---
            */
            return default;
        }

        public async Task<TEntity> ClearPreloadViewsCacheIfNeededInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _clear_preload_views_cache_if_needed) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ClearRemovedEdiFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _clear_removed_edi_formats) ---
            */
            return default;
        }

        public async Task<TEntity> CloseAsync<TEntity>(IEnumerable<TEntity> entities, Guid reason_id) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: close) ---
            */
            return default;
        }

        public async Task<TEntity> CombineInternalAsync<TEntity>(IEnumerable<TEntity> entities, Dictionary<string, object> hierarchy) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _combine) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _commercial_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncFromCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_sync_from_company) ---
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncToDescendantsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_sync) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_sync_to_descendants) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CompanyDependentCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _company_dependent_commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CompanyDependentCommercialSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _company_dependent_commercial_sync) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CompleteInverseExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object exclusions) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _complete_inverse_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountMoveCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_account_move_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActionRightsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_action_rights) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActiveLangCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_active_lang_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActivitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_activities) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressInlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_address_inline) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_address_search) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_all_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowCommentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_allow_comment) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowedUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_job.py, METHOD: _compute_allowed_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicantHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_applicant_hired) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicantMatchingScoreInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_job.py, METHOD: _compute_applicant_matching_score) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatisticsHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
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

        public async Task<TEntity> ComputeApplicationStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_application_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeArchBaseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _compute_arch_base) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeArchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _compute_arch) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailableInvoiceTemplatePdfReportIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_available_invoice_template_pdf_report_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePeppolEasInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_available_peppol_eas) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _compute_available_peppol_eas) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePeppolEdiFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _compute_available_peppol_edi_formats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePeppolSendingMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _compute_available_peppol_sending_methods) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_1024) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_128) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_1920) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_256) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_512) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBankCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_bank_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBaseUnitPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_base_unit_price) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBlogPostCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_blog_post_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBomCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_bom_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBomIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_bom_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBoothMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py, METHOD: _compute_booth_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanBeExpensedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py, METHOD: _compute_can_be_expensed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanImage1024BeZoomedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_can_image_1024_be_zoomed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanModerateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_can_moderate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanPublishInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_can_publish) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_can_publish) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanUploadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_can_upload) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryAndSlideIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_category_and_slide_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_category_completed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryCompletionTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_category_completion_time) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_category_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCertificationsCompanyCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: res_partner.py, METHOD: _compute_certifications_company_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCertificationsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: res_partner.py, METHOD: _compute_certifications_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeChildCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_child_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _compute_color) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommentsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_comments_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialCompanyNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_commercial_company_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_commercial_partner) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommunityMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_community_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_complete_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactAddressInlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _compute_contact_address_inline) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_contact_address) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_contact_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_contact_phone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCostCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_cost_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCostMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _compute_cost_method) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountActiveCardsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: res_partner.py, METHOD: _compute_count_active_cards) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountFlaggedPostsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_count_flagged_posts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountPostsWaitingValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_count_posts_waiting_validation) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCreditToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_credit_to_invoice) ---
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _compute_credit_to_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCtaTimeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_cta_time_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentJobSkillIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_job.py, METHOD: _compute_current_job_skill_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_date_tz) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDaysSalesOutstandingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_days_sales_outstanding) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDefaultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _compute_defaults) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDocumentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_document_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFormattedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_email_formatted) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmbedCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_embed_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmbedCountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_embed_counts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeeCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_employee_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _compute_employee) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _compute_employees_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_job.py, METHOD: _compute_employees) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEndDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_end_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEnrollInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_enroll) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCategoryAvailableIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_category_available_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCategoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_category_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _compute_event_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_mail_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegisterUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_event_register_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_open) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsSoldOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_sold_out) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsStartedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_started) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventShareUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_event_share_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventSlotCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_slot_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventTicketIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_ticket_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExhibitorMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: _compute_exhibitor_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExpensePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py, METHOD: _compute_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: product_template.py, METHOD: _compute_expense_policy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExpensePolicyTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py, METHOD: _compute_expense_policy_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExtendedInterviewerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_extended_interviewer_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFavoriteCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_favorite_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFieldIsOneDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_field_is_one_day) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFirstPageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _compute_first_page_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalCountryCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _compute_fiscal_country_codes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalCountryGroupCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_fiscal_country_group_codes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalPositionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_fiscal_position_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeForumStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_forum_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFullUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _compute_full_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGelatoMissingImagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _compute_gelato_missing_images) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGelatoProductUidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _compute_gelato_product_uid) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGetIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_get_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGoogleDriveIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_google_drive_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasAvailableRouteIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_has_available_route_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasConfigurableAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_has_configurable_attributes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasPendingPostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_has_pending_post) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasPublishedProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _compute_has_published_products) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ComputeHasRequestedAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_has_requested_access) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasValidatedAnswerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_has_validated_answer) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py, METHOD: _compute_im_status) ---
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: res_partner.py, METHOD: _compute_im_status) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _compute_im_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImage1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_image_1920) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImplementedPartnerCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _compute_implemented_partner_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvalidLocatorsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _compute_invalid_locators) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_invoice_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_invoice_emails) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_invoice_policy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsDynamicallyCreatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_is_dynamically_created) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_is_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_is_finished) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInCallInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _compute_is_in_call) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsKitsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_is_kits) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMondialrelayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py, METHOD: _compute_is_mondialrelay) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsNewSlideInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_is_new_slide) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_is_ongoing) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsParticipatingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_is_participating) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPeppolEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_is_peppol_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_is_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPublicInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_is_public) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsReminderOnInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_is_reminder_on) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsSeoOptimizedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: mixins.py, METHOD: _compute_is_seo_optimized) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsStorableAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: compute_is_storable) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsSubcontractorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_is_subcontractor) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsUblFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_is_ubl_format) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_is_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsVisibleOnWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_is_visible_on_website) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeKanbanStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_kanban_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeKanbanStateLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_kanban_state_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_lang) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLastPostIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_last_post_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLeadCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_event.py, METHOD: _compute_lead_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLeaveDateToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py, METHOD: _compute_leave_date_to) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLikeInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_like_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatChannelCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _compute_livechat_channel_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLotValuatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _compute_lot_valuated) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMainUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_main_user_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMarkCompleteActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_mark_complete_actions) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _compute_meeting_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _compute_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMembersCountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_members_counts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMembershipValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_membership_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeModelDataIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _compute_model_data_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeModelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _compute_model_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMrpProductQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_mrp_product_qty) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNbrMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_nbr_moves) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNbrReorderingRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_nbr_reordering_rules) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNewApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_new_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNextSerialInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_next_serial) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNoOfHiredEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_no_of_hired_employee) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_note) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOldApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_old_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOnTimeRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: res_partner.py, METHOD: _compute_on_time_rate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOpenApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_open_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOpportunityCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: _compute_opportunity_count) ---
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _compute_opportunity_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeParentsAndSelfInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _compute_parents_and_self) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerBiographyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_biography) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerCompanyNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_company_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerCompanyRegistryPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_partner_company_registry_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerFunctionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_function) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerHasNewContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_partner_has_new_content) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerIapInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_plugin, FILE: res_partner.py, METHOD: _compute_partner_iap_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerImageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_image) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_phone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShareInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_partner_share) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerTagLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_tag_line) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerVatPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_partner_vat_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _compute_partner_weight) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_partners) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentTokenCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: res_partner.py, METHOD: _compute_payment_token_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePeppolEasInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_peppol_eas) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePeppolEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_peppol_endpoint) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePerformViesValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _compute_perform_vies_validation) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePickingIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_picking_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePlainContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_plain_content) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePosContactAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_pos_contact_address) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePosOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_pos_order) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_post_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePostKarmaRightsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_post_karma_rights) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePostsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_tag.py, METHOD: _compute_posts_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePrerequisiteUserHasCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_prerequisite_user_has_completed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductDocumentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_document_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_partner.py, METHOD: _compute_product_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_tooltip) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_product_tooltip) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _compute_product_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductVariantCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_variant_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_variant_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_production_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePublishDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_publish_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePublishedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _compute_published_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _compute_purchase_method) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseOkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: product_template.py, METHOD: _compute_purchase_ok) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_purchase_ok) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: res_partner.py, METHOD: _compute_purchase_order_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchasedProductQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _compute_purchased_product_qty) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuantitiesDictInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_quantities_dict) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuantitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_quantities) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_question_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuestionsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_questions_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuizInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partner, object quiz_done) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_quiz_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_rating_stats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRelevancyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_relevancy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSaleOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _compute_sale_order_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSalePriceTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_event.py, METHOD: _compute_sale_price_total) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSalesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_sales_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSameVatPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_same_vat_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsLimitedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats_limited) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsMaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats_max) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSelfOrderVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _compute_self_order_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSelfReplyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_self_reply) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSerialPrefixFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_serial_prefix_format) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _compute_service_policy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_service_tracking) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_service_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_service_type) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: product_template.py, METHOD: _compute_service_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceUpsellThresholdRatioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _compute_service_upsell_threshold_ratio) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowCreditLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_show_credit_limit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowQtyStatusButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_show_qty_status_button) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_show_qty_status_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowQtyUpdateButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_show_qty_update_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSkillIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_job.py, METHOD: _compute_skill_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideChannelCompanyCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _compute_slide_channel_company_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideChannelValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _compute_slide_channel_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideIconClassInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slide_icon_class) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideLastUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_slide_last_update) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slide_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideViewsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slide_views) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlidesStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_slides_statistics) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slides_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSponsorCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: _compute_sponsor_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStartSaleDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_start_sale_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStaticMapUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _compute_static_map_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStaticMapUrlIsValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _compute_static_map_url_is_valid) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStreetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _compute_street_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSupplierInvoiceCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_supplier_invoice_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_tag_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTagIdsUsageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_tag_ids_usage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _compute_task_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _compute_task_template) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxStringInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _compute_tax_string) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_teaser) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTemplateFieldFromVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object @default) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_template_field_from_variant_field) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTicketInstructionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_ticket_instructions) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTimeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_time_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_total) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_track_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackTimeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_track_time_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _compute_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTracksTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_tracks_tag_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTypeAddressLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_type_address_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTzOffsetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_tz_offset) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUidHasAnsweredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_uid_has_answered) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUseBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_use_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUsePartnerCreditLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_use_partner_credit_limit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUsedInBomCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _compute_used_in_bom_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserFavouriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_user_favourite) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_user_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserLivechatUsernameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _compute_user_livechat_username) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserMembershipIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_user_membership_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_user_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserVoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_user_vote) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeValidProductTemplateAttributeLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_valid_product_template_attribute_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeValuationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _compute_valuation) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVariantsDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_variants_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVatLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_vat_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVideoSourceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_video_source_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeViesValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _compute_vies_valid) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVimeoIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_vimeo_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVisibleExpensePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _compute_visible_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: product_template.py, METHOD: _compute_visible_expense_policy) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _compute_visible_expense_policy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_volume) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_volume_uom_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVoteCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_vote_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWarningInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _compute_warning_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteAbsoluteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_absolute_url) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_website_absolute_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteDefaultBackgroundImageUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_default_background_image_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteImageUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_website_image_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteMenuDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_website_menu_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_website_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteShareUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_website_share_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteTrackInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_website_track) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteTrackProposalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_website_track_proposal) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_tag.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_partner, FILE: res_partner.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_weight) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWeightUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_weight_uom_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWishlistVisitorIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_wishlist_visitor_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeXmlIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _compute_xml_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeYoutubeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_youtube_id) ---
            */
            return default;
        }

        public async Task<TEntity> ConstructTaxStringInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _construct_tax_string) ---
            */
            return default;
        }

        public async Task<TEntity> ContainsBrandedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _contains_branded) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertAnswerToCommentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: convert_answer_to_comment) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ConvertCommentToAnswerAsync<TEntity>(IEnumerable<TEntity> entities, Guid message_id) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: convert_comment_to_answer) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertFieldsToValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _convert_fields_to_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ConvertHuLocalToEuVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object local_vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _convert_hu_local_to_eu_vat) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: copy) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: website_event_menu.py, METHOD: copy) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CopyChildrenViewsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_view, object children_views, Guid website_id) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: website_event_menu.py, METHOD: _copy_children_views) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CopyCustomSnippetTranslationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object html_field) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: _copy_custom_snippet_translations) ---
            #endif
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CopyEventMenusAsync<TEntity>(IEnumerable<TEntity> entities, object old_events) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: copy_event_menus) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CopyFieldTermsTranslationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records_from, object name_field_from, object record_to, object name_field_to) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: _copy_field_terms_translations) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAllSpecificViewsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object processed_modules) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _create_all_specific_views) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: create) ---
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

        public async Task<TEntity> CreateAttributesFromGelatoInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _create_attributes_from_gelato_info) ---
            --- METHOD SOURCE (MODULE: website_sale_gelato, FILE: product_template.py, METHOD: _create_attributes_from_gelato_info) ---
            */
            return default;
        }

        public async Task<TEntity> CreateCompanyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: create_company) ---
            */
            return default;
        }

        public async Task<TEntity> CreateContactParentCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _create_contact_parent_company) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _create_contact_parent_company) ---
            */
            return default;
        }

        public async Task<TEntity> CreateFirstProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object log_warning) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_first_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> CreateMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sequence, object name, object url, Guid xml_id, object menu_type, object parent_menu_type) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _create_menu) ---
            */
            return default;
        }

        public async Task<TEntity> CreatePortalUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _create_portal_users) ---
            */
            return default;
        }

        public async Task<TEntity> CreatePrintImagesFromGelatoInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _create_print_images_from_gelato_info) ---
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> product_template_attribute_value_ids) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: create_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantFromPosAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attribute_value_ids, Guid config_id) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: create_product_variant_from_pos) ---
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object log_warning) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> CreateVariantIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_variant_ids) ---
            */
            return default;
        }

        public async Task<TEntity> CreateWebsiteSpecificPagesForViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_view, object website) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _create_website_specific_pages_for_view) ---
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _creation_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> CreditDebitGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _credit_debit_get) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreditSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _credit_search) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DebitSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _debit_search) ---
            */
            return default;
        }

        public async Task<TEntity> DeduceCountryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _deduce_country_code) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _default_access_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultAddressIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _default_address_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _default_category) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_content) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCoverPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _default_cover_properties) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _default_cover_properties) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_description) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultDisplayInvoiceTemplatePdfReportIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _default_display_invoice_template_pdf_report_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_event_mail_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: default_get) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultPosSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _default_pos_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_question_ids) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultResponsibleIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _default_responsible_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_sequence) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _default_sequence) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultViewAsync<TEntity>(IEnumerable<TEntity> entities, object model, object view_type) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: default_view) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultWebsiteMetaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: mixins.py, METHOD: _default_website_meta) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_website_meta) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _default_website_meta) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _default_website_meta) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _default_website_meta) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _default_website_meta) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultWebsiteSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _default_website_sequence) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DeleteSnippetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object template_key) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: delete_snippet) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DemoConfigureVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _demo_configure_variants) ---
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _display_address_depends) ---
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _display_address) ---
            */
            return default;
        }

        public async Task<TEntity> DistributeBrandingAsync<TEntity>(IEnumerable<TEntity> entities, object e, object branding, object parent_xpath, object index_map) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: distribute_branding) ---
            */
            return default;
        }

        public async Task<TEntity> DoButtonPrintAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_button_print) ---
            */
            return default;
        }

        public async Task<TEntity> DoPartnerMailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_mail) ---
            */
            return default;
        }

        public async Task<TEntity> DoPartnerManualActionAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_manual_action) ---
            */
            return default;
        }

        public async Task<TEntity> DoPartnerManualActionDermanordAsync<TEntity>(IEnumerable<TEntity> entities, object followup_line) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_manual_action_dermanord) ---
            */
            return default;
        }

        public async Task<TEntity> DoPartnerPrintAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> wizard_partner_ids, object data) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: do_partner_print) ---
            */
            return default;
        }

        public async Task<TEntity> DomainPricelistRuleIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _domain_pricelist_rule_ids) ---
            */
            return default;
        }

        public async Task<TEntity> EditableNodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _editable_node) ---
            */
            return default;
        }

        public async Task<TEntity> EditableTagFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _editable_tag_field) ---
            */
            return default;
        }

        public async Task<TEntity> EditableTagFormInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _editable_tag_form) ---
            */
            return default;
        }

        public async Task<TEntity> EditableTagListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _editable_tag_list) ---
            */
            return default;
        }

        public async Task<TEntity> EmbedIncrementInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _embed_increment) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EnrichByDomainAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object timeout) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: enrich_by_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EnrichByDunsAsync<TEntity>(IEnumerable<TEntity> entities, object duns, object timeout) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: enrich_by_duns) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EnrichByGstAsync<TEntity>(IEnumerable<TEntity> entities, object gst, object timeout) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: enrich_by_gst) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureSameCompanyThanProjectsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _ensure_same_company_than_projects) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureSameCompanyThanTasksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _ensure_same_company_than_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureUnusedInPosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _ensure_unused_in_pos) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ExtractEmbeddedFieldsAsync<TEntity>(IEnumerable<TEntity> entities, object arch) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: extract_embedded_fields) ---
            #endif
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ExtractOeStructuresAsync<TEntity>(IEnumerable<TEntity> entities, object arch) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: extract_oe_structures) ---
            #endif
            return default;
        }

        public async Task<TEntity> FetchChildrenPartnersForHierarchyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: _fetch_children_partners_for_hierarchy) ---
            */
            return default;
        }

        public async Task<TEntity> FetchExternalMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_external_metadata) ---
            */
            return default;
        }

        public async Task<TEntity> FetchGoogleDriveMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_google_drive_metadata) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FetchIsParticipatingEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _fetch_is_participating_events) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FetchTemplateViewsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ids_or_xmlids) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _fetch_template_views) ---
            */
            return default;
        }

        public async Task<TEntity> FetchVimeoMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_vimeo_metadata) ---
            */
            return default;
        }

        public async Task<TEntity> FetchYoutubeMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_youtube_metadata) ---
            */
            return default;
        }

        public async Task<TEntity> FieldStoreReprInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _field_store_repr) ---
            */
            return default;
        }

        public async Task<TEntity> FieldsSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _fields_sync) ---
            */
            return default;
        }

        public async Task<TEntity> FieldsViewGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type, object toolbar, object submenu) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: fields_view_get) ---
            */
            return default;
        }

        public async Task<TEntity> FilterAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object raise_on_access) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _filter_add_members) ---
            */
            return default;
        }

        public async Task<TEntity> FilterCombinationsImpossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination_tuples, object ignore_no_variant) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _filter_combinations_impossible_by_config) ---
            */
            return default;
        }

        public async Task<TEntity> FilterDuplicateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: filter_duplicate) ---
            */
            return default;
        }

        public async Task<TEntity> FilterLoadedViewsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> check_view_ids) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _filter_loaded_views) ---
            */
            return default;
        }

        public async Task<TEntity> FindAccountingPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _find_accounting_partner) ---
            */
            return default;
        }

        public async Task<TEntity> FindAvailableNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object used_names) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: _find_available_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FindOrCreateAsync<TEntity>(IEnumerable<TEntity> entities, object email, object assert_valid_email) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: find_or_create) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: find_or_create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FindOrCreateFromEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails, object ban_emails, object filter_found, object additional_values, object no_create, object sort_key, object sort_reverse) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _find_or_create_from_emails) ---
            */
            return default;
        }

        public async Task<TEntity> FlagInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _flag) ---
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultPurchaseTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _force_default_purchase_tax) ---
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultSaleTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _force_default_sale_tax) ---
            */
            return default;
        }

        public async Task<TEntity> ForceDefaultTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _force_default_tax) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormatDataCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _format_data_company) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatChAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_ch) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatClAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_cl) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatCoAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_co) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatEuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_eu) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatHuAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_hu) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormatVatNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _format_vat_number) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatSmAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_sm) ---
            */
            return default;
        }

        public async Task<TEntity> FormatVatVnAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: format_vat_vn) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormattingAddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _formatting_address_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GcMarkEventsDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _gc_mark_events_done) ---
            */
            return default;
        }

        public async Task<TEntity> GelatoPrepareAddressPayloadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: res_partner.py, METHOD: _gelato_prepare_address_payload) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateSignupTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expiration) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _generate_signup_token) ---
            */
            return default;
        }

        public async Task<TEntity> GeoLocalizeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: res_partner.py, METHOD: geo_localize) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GeoLocalizeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object street, object zip, object city, object state, object country) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: res_partner.py, METHOD: _geo_localize) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
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

        public async Task<TEntity> GetAccountStatisticsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_account_statistics_count) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetActionViewRelatedPutawayRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _get_action_view_related_putaway_rules) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAdditionalConfiguratorDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_additional_configurator_data) ---
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py, METHOD: _get_additional_configurator_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetAdditionnalCombinationInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object uom, object date, object website) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_additionnal_combination_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: res_partner.py, METHOD: _get_address_format) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_address_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetAddressValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_address_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllAddrInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _get_all_addr) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_all_addr) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAllowedRootAttrsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_allowed_root_attrs) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAlternativeProductFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_alternative_product_filter) ---
            */
            return default;
        }

        public async Task<TEntity> GetAmountsAndDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_amounts_and_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetAssetAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: product.py, METHOD: _get_asset_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttendeeDetailAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> meeting_ids) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: get_attendee_detail) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object parent_name, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_attribute_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttributeValueDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attribute_value_dict) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_attribute_value_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttributesExtraPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_attributes_extra_price) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAvailableCategoryDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid website_id) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _get_available_category_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAvailableSnippetCategoriesAsync<TEntity>(IEnumerable<TEntity> entities, Guid website_id) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: get_available_snippet_categories) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvailableUomsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_available_uoms) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: get_backend_menu_id) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: get_backend_menu_id) ---
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: get_backend_menu_id) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: get_backend_menu_id) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: get_backend_menu_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackendRootMenuIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _get_backend_root_menu_ids) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: _get_backend_root_menu_ids) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_backend_root_menu_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetBaseLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_base_lang) ---
            */
            return default;
        }

        public async Task<TEntity> GetBaseUnitPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_base_unit_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetBaseUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: get_base_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetBoothStatCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _get_booth_stat_count) ---
            */
            return default;
        }

        public async Task<TEntity> GetBusyCalendarEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object end_datetime) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _get_busy_calendar_events) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCachedTemplateInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object id_or_xmlid, object _view) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_cached_template_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCachedTemplatePrefetchedKeysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_cached_template_prefetched_keys) ---
            */
            return default;
        }

        public async Task<TEntity> GetCachedVisibilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_cached_visibility) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCanPublishErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_can_publish_error_message) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_can_publish_error_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetCategorizedSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_domain, object order, object force_void, object limit, object offset) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_categorized_slides) ---
            */
            return default;
        }

        public async Task<TEntity> GetCleanedNonEditingAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attributes) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: _get_cleaned_non_editing_attributes) ---
            */
            return default;
        }

        public async Task<TEntity> GetClosestPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_closest_possible_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetClosestPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_closest_possible_combinations) ---
            */
            return default;
        }

        public async Task<TEntity> GetCombinationInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, Guid product_id, object add_qty, Guid uom_id, object only_template) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_combination_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetCombinedArchAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: get_combined_arch) ---
            */
            return default;
        }

        public async Task<TEntity> GetCombinedArchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_combined_arch) ---
            */
            return default;
        }

        public async Task<TEntity> GetCombinedArchsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_combined_archs) ---
            */
            return default;
        }

        public async Task<TEntity> GetCommercialValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_commercial_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_company_currency) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyRegistryLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_company_registry_labels) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_complete_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompletionTimePdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data_bytes) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_completion_time_pdf) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetConfiguratorDisplayPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_configurator_display_price) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetConfiguratorPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_or_template, object quantity, object date, object currency, object pricelist) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_configurator_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetContactOpportunitiesDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: _get_contact_opportunities_domain) ---
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _get_contact_opportunities_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetContextualPriceAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_contextual_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetContextualPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_contextual_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetContextualPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_contextual_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> GetCountryNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: res_partner.py, METHOD: _get_country_name) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_country_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetCurrentPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _get_current_partner) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py, METHOD: _get_current_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCurrentPersonaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_current_persona) ---
            */
            return default;
        }

        public async Task<TEntity> GetDateRangeStrInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object lang_code) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_date_range_str) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_default_address_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultEnrollMsgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_default_enroll_msg) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultFavoriteUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _get_default_favorite_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultJobDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _get_default_job_details) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultLangCodeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: get_default_lang_code) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_default_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_default_uom_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultViewDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object view_type) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_default_view_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultWebsiteDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _get_default_website_description) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultWelcomeMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _get_default_welcome_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetDeliveryAddressDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: res_partner.py, METHOD: _get_delivery_address_domain) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _get_delivery_address_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetEarnedKarmaInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_earned_karma) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEdiBuilderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_edi_format) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_edi_builder) ---
            */
            return default;
        }

        public async Task<TEntity> GetEmployeesFromAttendeesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object everybody) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: _get_employees_from_attendees) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_empty_list_help) ---
            */
            return default;
        }

        public async Task<TEntity> GetEventResourceUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_event_resource_urls) ---
            */
            return default;
        }

        public async Task<TEntity> GetEventTrackVisitorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_create) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_event_track_visitors) ---
            */
            return default;
        }

        public async Task<TEntity> GetExternalDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_external_description) ---
            */
            return default;
        }

        public async Task<TEntity> GetExternalDescriptionUrlEncodedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_external_description_url_encoded) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetFilterXmlidQueryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_filter_xmlid_query) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_first_possible_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstPossibleVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_first_possible_variant_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstStageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _get_first_stage) ---
            */
            return default;
        }

        public async Task<TEntity> GetFollowupOverdueQueryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object args, object overdue_only) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_followup_overdue_query) ---
            */
            return default;
        }

        public async Task<TEntity> GetFollowupTableHtmlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: get_followup_table_html) ---
            */
            return default;
        }

        public async Task<TEntity> GetFrontendWritableFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_frontend_writable_fields) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _get_frontend_writable_fields) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _get_frontend_writable_fields) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py, METHOD: _get_frontend_writable_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetGeneralToServiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_policy, object service_type) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_general_to_service) ---
            */
            return default;
        }

        public async Task<TEntity> GetGeneralToServiceMapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_general_to_service_map) ---
            */
            return default;
        }

        public async Task<TEntity> GetGoogleAnalyticsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, object combination_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_google_analytics_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetIcsFileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_ics_file) ---
            */
            return default;
        }

        public async Task<TEntity> GetImStatusAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_im_status_access_token) ---
            */
            return default;
        }

        public async Task<TEntity> GetImageHolderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_image_holder) ---
            */
            return default;
        }

        public async Task<TEntity> GetImagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_images) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: product.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetIncompatibleTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_incompatible_types) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInheritingViewsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_inheriting_views_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInheritingViewsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_inheriting_views) ---
            */
            return default;
        }

        public async Task<TEntity> GetKioskUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: get_kiosk_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetLatestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_latest) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetLengthUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_length_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetLengthUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_length_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        public async Task<TEntity> GetListPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _get_list_price) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_list_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetLoginDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_login_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetMappedAttributeNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_mapped_attribute_names) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMentionSuggestionsAsync<TEntity>(IEnumerable<TEntity> entities, object search, object limit) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: get_mention_suggestions) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMentionSuggestionsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object search) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_mention_suggestions_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMentionSuggestionsFromChannelAsync<TEntity>(IEnumerable<TEntity> entities, Guid channel_id, object search, object limit) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: get_mention_suggestions_from_channel) ---
            */
            return default;
        }

        public async Task<TEntity> GetMentionTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_mention_token) ---
            */
            return default;
        }

        public async Task<TEntity> GetMenuTypeFieldMatchingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_menu_type_field_matching) ---
            */
            return default;
        }

        public async Task<TEntity> GetMenuUpdateFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_menu_update_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetMenusUpdateByFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object menus_state_by_field, object force_update) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_menus_update_by_field) ---
            */
            return default;
        }

        public async Task<TEntity> GetMicrodataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _get_microdata) ---
            */
            return default;
        }

        public async Task<TEntity> GetNeedactionCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_needaction_count) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNewPartnerAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id, object domain, object offset) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: get_new_partner) ---
            */
            return default;
        }

        public async Task<TEntity> GetNextCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_next_category) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOnLeaveIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py, METHOD: _get_on_leave_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOnchangeServicePolicyUpdatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service_tracking, object service_policy, Guid project_id, Guid project_template_id) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _get_onchange_service_policy_updates) ---
            */
            return default;
        }

        public async Task<TEntity> GetOwnAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_own_attribute_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> GetParentAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_parent_attribute_exclusions) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetParticipantInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object edi_identification) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _get_participant_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPartnerFromTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_partner_from_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPartnerLocalisationFieldsRequiredToInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, Guid country_id) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: get_partner_localisation_fields_required_to_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_partners) ---
            */
            return default;
        }

        public async Task<TEntity> GetPeppolEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_peppol_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetPeppolEndpointValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country_code, object field, object eas) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_peppol_endpoint_value) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPeppolFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_peppol_formats) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPeppolVerificationStateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object peppol_endpoint, object peppol_eas, object invoice_edi_format, object process_type) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _get_peppol_verification_state) ---
            */
            return default;
        }

        public async Task<TEntity> GetPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_placeholder_filename) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_placeholder_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_possible_combinations) ---
            */
            return default;
        }

        public async Task<TEntity> GetPossibleVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_possible_variants) ---
            */
            return default;
        }

        public async Task<TEntity> GetPossibleVariantsSortedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_possible_variants_sorted) ---
            */
            return default;
        }

        public async Task<TEntity> GetPreviewedAttributeValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object product_query_params) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_previewed_attribute_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductAccountsAsync<TEntity>(IEnumerable<TEntity> entities, object fiscal_pos) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: get_product_accounts) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: get_product_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _get_product_accounts) ---
            --- METHOD SOURCE (MODULE: mrp_account, FILE: product.py, METHOD: _get_product_accounts) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _get_product_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductDocumentDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_document_domain) ---
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _get_product_document_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductInfoPosAsync<TEntity>(IEnumerable<TEntity> entities, object price, object quantity, Guid pos_config_id, Guid product_variant_id) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: get_product_info_pos) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_placeholder_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_price_context) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetProductTypesAllowZeroPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_product_types_allow_zero_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object query_params, object grouped_attributes_values) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_product_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetPwdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_pwd) ---
            */
            return default;
        }

        public async Task<TEntity> GetRelatedFieldsVariantTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_related_fields_variant_template) ---
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _get_related_fields_variant_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetRelatedPostsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object limit) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _get_related_posts) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRelatedViewsAsync<TEntity>(IEnumerable<TEntity> entities, object key, object bundles) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: get_related_views) ---
            */
            return default;
        }

        public async Task<TEntity> GetRibbonInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price_vals, object auto_assign_ribbons, object variant) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_ribbon) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSaleOrderDomainCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _get_sale_order_domain_count) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSaleableTrackingTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: partnership, FILE: product_template.py, METHOD: _get_saleable_tracking_types) ---
            --- METHOD SOURCE (MODULE: repair, FILE: product.py, METHOD: _get_saleable_tracking_types) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _get_saleable_tracking_types) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_saleable_tracking_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetSalesPricesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_sales_prices) ---
            */
            return default;
        }

        public async Task<TEntity> GetScheduleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_period, object stop_period, object everybody, object merge) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: _get_schedule) ---
            */
            return default;
        }

        public async Task<TEntity> GetSeatsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot_tickets) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_seats_availability) ---
            */
            return default;
        }

        public async Task<TEntity> GetServiceToGeneralInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service_policy) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_service_to_general) ---
            */
            return default;
        }

        public async Task<TEntity> GetServiceToGeneralMapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _get_service_to_general_map) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _get_service_to_general_map) ---
            */
            return default;
        }

        public async Task<TEntity> GetSignupUrlForActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url, object action, object view_type, Guid menu_id, Guid res_id, object model) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_signup_url_for_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetSignupUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_signup_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetSingleProductVariantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_single_product_variant) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: get_single_product_variant) ---
            --- METHOD SOURCE (MODULE: sale_product_matrix, FILE: product_template.py, METHOD: get_single_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> GetSlotTicketsAvailabilityPosAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> slot_ticket_ids) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_event.py, METHOD: get_slot_tickets_availability_pos) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSnippetAdditionViewKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_key, object key) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: _get_snippet_addition_view_key) ---
            */
            return default;
        }

        public async Task<TEntity> GetSpecificViewsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_specific_views) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreAvatarCardFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _get_store_avatar_card_fields) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_store_avatar_card_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreLivechatUsernameFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _get_store_livechat_username_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreMentionFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_store_mention_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStreetSplitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _get_street_split) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_street_split) ---
            */
            return default;
        }

        public async Task<TEntity> GetStructuredDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object post_type) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _get_structured_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetSuggestedInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_suggested_invoice_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetSuggestedPeppolEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_suggested_peppol_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetSuggestedUblCiiEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_suggested_ubl_cii_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> GetSuitableImageSizeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object columns, object x_size, object y_size) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_suitable_image_size) ---
            */
            return default;
        }

        public async Task<TEntity> GetSyncedCommercialValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_synced_commercial_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetTagsFirstCharInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tags) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _get_tags_first_char) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object xmlids) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_template_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetTemplateMatrixInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product_matrix, FILE: product_template.py, METHOD: _get_template_matrix) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateMinimalCacheKeysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_template_minimal_cache_keys) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _get_template_order) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object id_or_xmlid, object raise_if_not_found) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_template_view) ---
            */
            return default;
        }

        public async Task<TEntity> GetTicketsAccessHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> registration_ids) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_tickets_access_hash) ---
            */
            return default;
        }

        public async Task<TEntity> GetTrackCalendarDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_calendar_description) ---
            */
            return default;
        }

        public async Task<TEntity> GetTrackCalendarReminderDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_calendar_reminder_dates) ---
            */
            return default;
        }

        public async Task<TEntity> GetTrackCalendarReminderTimesWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_calendar_reminder_times_warning) ---
            */
            return default;
        }

        public async Task<TEntity> GetTrackCalendarUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_calendar_urls) ---
            */
            return default;
        }

        public async Task<TEntity> GetTrackSuggestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object restrict_domain, object limit) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_suggestions) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUblCiiFormatsByCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_ubl_cii_formats_by_country) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUblCiiFormatsInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_ubl_cii_formats_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUblCiiFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_ubl_cii_formats) ---
            */
            return default;
        }

        public async Task<TEntity> GetVariantForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_variant_for_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetVariantIdForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filtered_combination) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_variant_id_for_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetVatRequiredValidInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_vat_required_valid) ---
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _get_vat_required_valid) ---
            */
            return default;
        }

        public async Task<TEntity> GetVcardFileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: res_partner.py, METHOD: _get_vcard_file) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_view_cache_key) ---
            */
            return default;
        }

        public async Task<TEntity> GetViewEtreesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_view_etrees) ---
            */
            return default;
        }

        public async Task<TEntity> GetViewHierarchyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: get_view_hierarchy) ---
            */
            return default;
        }

        public async Task<TEntity> GetViewInfoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: ir_ui_view.py, METHOD: get_view_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetViewInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_ui_view.py, METHOD: _get_view_info) ---
            --- METHOD SOURCE (MODULE: web, FILE: ir_ui_view.py, METHOD: _get_view_info) ---
            --- METHOD SOURCE (MODULE: web_hierarchy, FILE: ir_ui_view.py, METHOD: _get_view_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _get_view) ---
            */
            return default;
        }

        public async Task<TEntity> GetViewRefsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_view_refs) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetVolumeUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_volume_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetVolumeUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_volume_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteAccessoryProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_website_accessory_product) ---
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteAlternativeProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _get_website_alternative_product) ---
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteMenuEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_website_menu_entries) ---
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteMetaAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: mixins.py, METHOD: get_website_meta) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWeightUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_weight_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWeightUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_weight_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWorkingHoursForAllAttendeesAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attendee_ids, object date_from, object date_to, object everybody) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: get_working_hours_for_all_attendees) ---
            */
            return default;
        }

        public async Task<TEntity> GetWorklocationAsync<TEntity>(IEnumerable<TEntity> entities, object start_date, object end_date) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_homeworking_calendar, FILE: res_partner.py, METHOD: get_worklocation) ---
            */
            return default;
        }

        public async Task<TEntity> GetX2manyMissingViewArchsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object field_node, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _get_x2many_missing_view_archs) ---
            #endif
            return default;
        }

        public async Task<TEntity> GoToWebsiteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: go_to_website) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: go_to_website) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapImgAsync<TEntity>(IEnumerable<TEntity> entities, object zoom, object width, object height) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_partner.py, METHOD: google_map_img) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: google_map_link) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _google_map_link) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapSignedImgInternalAsync<TEntity>(IEnumerable<TEntity> entities, object zoom, object width, object height) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _google_map_signed_img) ---
            */
            return default;
        }

        public async Task<TEntity> HandleFirstContactCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _handle_first_contact_creation) ---
            */
            return default;
        }

        public async Task<TEntity> HandleVisibilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object do_raise) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _handle_visibility) ---
            */
            return default;
        }

        public async Task<TEntity> HasDynamicAttributesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: has_dynamic_attributes) ---
            */
            return default;
        }

        public async Task<TEntity> HasInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_domain) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _has_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> HasIsCustomValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _has_is_custom_values) ---
            */
            return default;
        }

        public async Task<bool> HasMultipleUomsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _has_multiple_uoms) ---
            */
            return default;
        }

        public async Task<TEntity> HasNoVariantAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _has_no_variant_attributes) ---
            */
            return default;
        }

        public async Task<TEntity> HasOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_domain) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _has_order) ---
            */
            return default;
        }

        public async Task<TEntity> HasPublishedTrackInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _has_published_track) ---
            */
            return default;
        }

        public async Task<TEntity> IapPartnerAutocompleteGetTagIdsAsync<TEntity>(IEnumerable<TEntity> entities, object unspsc_codes) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: iap_partner_autocomplete_get_tag_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IapReplaceIndustryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _iap_replace_industry_code) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IapReplaceLanguageCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _iap_replace_language_codes) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IapReplaceLocationCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _iap_replace_location_codes) ---
            */
            return default;
        }

        public async Task<TEntity> IeCheckCharInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _ie_check_char) ---
            */
            return default;
        }

        public async Task<TEntity> IncreaseRankInternalAsync<TEntity>(IEnumerable<TEntity> entities, string field, int n) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _increase_rank) ---
            */
            return default;
        }

        public async Task<TEntity> InheritBrandingAsync<TEntity>(IEnumerable<TEntity> entities, object specs_tree) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: inherit_branding) ---
            */
            return default;
        }

        public async Task<TEntity> InitColumnInternalAsync<TEntity>(IEnumerable<TEntity> entities, object column_name) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _init_column) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _init_column) ---
            */
            return default;
        }

        public async Task<TEntity> IntervalToBusinessHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities, object working_intervals) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: _interval_to_business_hours) ---
            */
            return default;
        }

        public async Task<TEntity> InverseArchBaseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _inverse_arch_base) ---
            */
            return default;
        }

        public async Task<TEntity> InverseArchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _inverse_arch) ---
            */
            return default;
        }

        public async Task<TEntity> InverseComputeModelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _inverse_compute_model_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _inverse_date) ---
            */
            return default;
        }

        public async Task<TEntity> InverseEndDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _inverse_end_date) ---
            */
            return default;
        }

        public async Task<TEntity> InverseGelatoProductUidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: product_template.py, METHOD: _inverse_gelato_product_uid) ---
            */
            return default;
        }

        public async Task<TEntity> InverseInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _inverse_invoice_edi_format) ---
            */
            return default;
        }

        public async Task<TEntity> InverseIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _inverse_is_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> InverseProductPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_partner.py, METHOD: _inverse_product_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> InverseQtyAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _inverse_qty_available) ---
            */
            return default;
        }

        public async Task<TEntity> InverseSerialPrefixFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _inverse_serial_prefix_format) ---
            */
            return default;
        }

        public async Task<TEntity> InverseServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _inverse_service_policy) ---
            */
            return default;
        }

        public async Task<TEntity> InverseStreetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _inverse_street_data) ---
            */
            return default;
        }

        public async Task<TEntity> InverseUsePartnerCreditLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _inverse_use_partner_credit_limit) ---
            */
            return default;
        }

        public async Task<TEntity> InverseVatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _inverse_vat) ---
            */
            return default;
        }

        public async Task<TEntity> InvoiceTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _invoice_total) ---
            */
            return default;
        }

        public async Task<TEntity> IsAddToCartPossibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _is_add_to_cart_possible) ---
            */
            return default;
        }

        public async Task<TEntity> IsCombinationPossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _is_combination_possible_by_config) ---
            */
            return default;
        }

        public async Task<TEntity> IsCombinationPossibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object parent_combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _is_combination_possible) ---
            */
            return default;
        }

        public async Task<TEntity> IsInWishlistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_wishlist, FILE: product_wishlist.py, METHOD: _is_in_wishlist) ---
            */
            return default;
        }

        public async Task<TEntity> IsNodeBrandedAsync<TEntity>(IEnumerable<TEntity> entities, object node) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: is_node_branded) ---
            */
            return default;
        }

        public async Task<TEntity> IsQwebBasedViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_type) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_ui_view.py, METHOD: _is_qweb_based_view) ---
            --- METHOD SOURCE (MODULE: web_hierarchy, FILE: ir_ui_view.py, METHOD: _is_qweb_based_view) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _is_qweb_based_view) ---
            */
            return default;
        }

        public async Task<TEntity> IsSoldOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_stock, FILE: product_template.py, METHOD: _is_sold_out) ---
            */
            return default;
        }

        public async Task<TEntity> IsValidRucEcAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: is_valid_ruc_ec) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _lang_get) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_event.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object config) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_event.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object config) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _load_pos_data_read) ---
            --- METHOD SOURCE (MODULE: pos_discount, FILE: product_template.py, METHOD: _load_pos_data_read) ---
            */
            return default;
        }

        public async Task<TEntity> LoadPosDataSearchReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _load_pos_data_search_read) ---
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: product_template.py, METHOD: _load_pos_data_search_read) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosSelfDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _load_pos_self_data_domain) ---
            */
            return default;
        }

        public async Task<TEntity> LoadPosSelfDataReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _load_pos_self_data_read) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadProductFromPosAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id, object domain, object offset, object limit) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: load_product_from_pos) ---
            */
            return default;
        }

        public async Task<TEntity> LoadProductWithDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object load_archived, object offset, object limit) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _load_product_with_domain) ---
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _load_records_create) ---
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _load_records_write) ---
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsWriteOnCowInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cow_view, Guid inherit_id, object values) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _load_records_write_on_cow) ---
            */
            return default;
        }

        public async Task<TEntity> LocateNodeAsync<TEntity>(IEnumerable<TEntity> entities, object arch, object spec) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: locate_node) ---
            */
            return default;
        }

        public async Task<TEntity> LogVerificationStateUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object old_value, object new_value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _log_verification_state_update) ---
            */
            return default;
        }

        public async Task<TEntity> LogViewWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object node) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _log_view_warning) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetOperationForMailMessageOperationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message_operation) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _mail_get_operation_for_mail_message_operation) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _mail_get_partner_fields) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _mail_get_partner_fields) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _mail_get_partners) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _mail_get_timezone) ---
            */
            return default;
        }

        public async Task<TEntity> MarkAsOffensiveBatchAsync<TEntity>(IEnumerable<TEntity> entities, object key, object values) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: mark_as_offensive_batch) ---
            */
            return default;
        }

        public async Task<TEntity> MarkAsOffensiveInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid reason_id) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _mark_as_offensive) ---
            */
            return default;
        }

        public async Task<TEntity> MergeMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object destination, object source) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _merge_method) ---
            */
            return default;
        }

        public async Task<TEntity> MessageAddDefaultRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _message_add_default_recipients) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _message_post_after_hook) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: message_post) ---
            */
            return default;
        }

        public async Task<TEntity> ModifiersFromModelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _modifiers_from_model) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MondialrelaySearchOrCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py, METHOD: _mondialrelay_search_or_create) ---
            */
            return default;
        }

        public async Task<TEntity> MoveCategorySlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object new_category) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _move_category_slides) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: name_create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameSearchAsync<TEntity>(IEnumerable<TEntity> entities, object name, object domain, object @operator, object limit) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: name_search) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyStateUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _notify_state_update) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadByInboxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object msg_vals) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _notify_thread_by_inbox) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _notify_thread_by_inbox) ---
            */
            return default;
        }

        public async Task<TEntity> OnChangeAvailableInPosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _on_change_available_in_pos) ---
            */
            return default;
        }

        public async Task<TEntity> OnChangeDocumentBinaryContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _on_change_document_binary_content) ---
            */
            return default;
        }

        public async Task<TEntity> OnChangeSlideCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _on_change_slide_category) ---
            */
            return default;
        }

        public async Task<TEntity> OnChangeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _on_change_url) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAbleViewFormInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _onchange_able_view_form) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAbleViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _onchange_able_view) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAbleViewKanbanInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _onchange_able_view_kanban) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAbleViewListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _onchange_able_view_list) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAvailableInPosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _onchange_available_in_pos) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeBuyRouteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: product.py, METHOD: _onchange_buy_route) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCityIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _onchange_city_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: onchange_company_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _onchange_country_id) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_country_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _onchange_event_url) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: onchange_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePhoneValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: res_partner.py, METHOD: _onchange_phone_validation) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePropertyProductPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py, METHOD: _onchange_property_product_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeSaleOkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _onchange_sale_ok) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeSeatsMaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _onchange_seats_max) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _onchange_service_fields) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _onchange_service_policy) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceToPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: product_template.py, METHOD: _onchange_service_to_purchase) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeServiceTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _onchange_service_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_state) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _onchange_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeEventBoothInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py, METHOD: _onchange_type_event_booth) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeEventInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: product_template.py, METHOD: _onchange_type_event) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: product.py, METHOD: _onchange_type) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_type) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _onchange_type) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _onchange_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_uom_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeVatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _onchange_vat) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeVerifyPeppolStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _onchange_verify_peppol_status) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _onchange_website_published) ---
            */
            return default;
        }

        public async Task<TEntity> OpenCommercialEntityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: open_commercial_entity) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: open_commercial_entity) ---
            */
            return default;
        }

        public async Task<TEntity> OpenTrackSpeakersListAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: open_track_speakers_list) ---
            */
            return default;
        }

        public async Task<TEntity> OrderFieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @alias, object field_name, object direction, object nulls, object query) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _order_field_to_sql) ---
            */
            return default;
        }

        public async Task<TEntity> OrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _order) ---
            */
            return default;
        }

        public async Task<TEntity> PaymentDueSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _payment_due_search) ---
            */
            return default;
        }

        public async Task<TEntity> PaymentEarliestDateSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _payment_earliest_date_search) ---
            */
            return default;
        }

        public async Task<TEntity> PaymentOverdueSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _payment_overdue_search) ---
            */
            return default;
        }

        public async Task<TEntity> PeppolEasEndpointDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _peppol_eas_endpoint_depends) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PeppolLookupParticipantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object edi_identification) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _peppol_lookup_participant) ---
            */
            return default;
        }

        public async Task<TEntity> PopViewBrandingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object element) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _pop_view_branding) ---
            */
            return default;
        }

        public async Task<TEntity> PostPublicationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _post_publication) ---
            */
            return default;
        }

        public async Task<TEntity> PostprocessAccessRightsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_access_rights) ---
            #endif
            return default;
        }

        public async Task<TEntity> PostprocessAndFieldsAsync<TEntity>(IEnumerable<TEntity> entities, object node, object model) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: postprocess_and_fields) ---
            */
            return default;
        }

        public async Task<TEntity> PostprocessAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_attributes) ---
            */
            return default;
        }

        public async Task<TEntity> PostprocessDebugInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_debug) ---
            #endif
            return default;
        }

        public async Task<TEntity> PostprocessDebugToCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tree) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_debug_to_cache) ---
            #endif
            return default;
        }

        public async Task<TEntity> PostprocessOnChangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object arch, object model) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_on_change) ---
            */
            return default;
        }

        public async Task<TEntity> PostprocessTagCalendarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_tag_calendar) ---
            */
            return default;
        }

        public async Task<TEntity> PostprocessTagFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_tag_field) ---
            */
            return default;
        }

        public async Task<TEntity> PostprocessTagFormInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_tag_form) ---
            */
            return default;
        }

        public async Task<TEntity> PostprocessTagGroupbyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_tag_groupby) ---
            */
            return default;
        }

        public async Task<TEntity> PostprocessTagLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_tag_label) ---
            */
            return default;
        }

        public async Task<TEntity> PostprocessTagListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_tag_list) ---
            */
            return default;
        }

        public async Task<TEntity> PostprocessTagSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_tag_search) ---
            */
            return default;
        }

        public async Task<TEntity> PostprocessViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object model_name, object editable, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _postprocess_view) ---
            */
            return default;
        }

        public async Task<TEntity> PreloadViewsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object refs) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _preload_views) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareDisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _prepare_display_address) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoicingTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _prepare_invoicing_tooltip) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _prepare_invoicing_tooltip) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _prepare_invoicing_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareServiceTrackingTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
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

        public async Task<TEntity> PrepareTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _prepare_tooltip) ---
            --- METHOD SOURCE (MODULE: sale, FILE: product_template.py, METHOD: _prepare_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareVariantValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _prepare_variant_values) ---
            */
            return default;
        }

        public async Task<TEntity> PriceComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price_type, object uom, object currency, object company, object date) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _price_compute) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ProcessEnrichedResponseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object response, object error) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _process_enriched_response) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessPosSelfUiProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: product_product.py, METHOD: _process_pos_self_ui_products) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessPosUiProductProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products, Guid config_id) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _process_pos_ui_product_product) ---
            */
            return default;
        }

        public async Task<TEntity> RaiseViewErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object node) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _raise_view_error) ---
            */
            return default;
        }

        public async Task<TEntity> RatingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _rating_domain) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _rating_domain) ---
            */
            return default;
        }

        public async Task<TEntity> ReadGroupCategIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object categories, object domain) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _read_group_categ_id) ---
            */
            return default;
        }

        public async Task<TEntity> ReadTemplateKeysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _read_template_keys) ---
            */
            return default;
        }

        public async Task<TEntity> RefuseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _refuse) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveMembershipInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _remove_membership) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RenameSnippetAsync<TEntity>(IEnumerable<TEntity> entities, object name, Guid view_id, object template_key) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: rename_snippet) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RenderPublicAssetAsync<TEntity>(IEnumerable<TEntity> entities, object template, object values) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: render_public_asset) ---
            */
            return default;
        }

        public async Task<TEntity> RenderTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template, object values) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _render_template) ---
            */
            return default;
        }

        public async Task<TEntity> ReopenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: reopen) ---
            */
            return default;
        }

        public async Task<TEntity> ReplaceArchSectionAsync<TEntity>(IEnumerable<TEntity> entities, object section_xpath, object replacement, object replace_tail) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: replace_arch_section) ---
            */
            return default;
        }

        public async Task<TEntity> ResequenceSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slide, object force_category) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _resequence_slides) ---
            */
            return default;
        }

        public async Task<TEntity> ResetArchAsync<TEntity>(IEnumerable<TEntity> entities, object mode) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: reset_arch) ---
            */
            return default;
        }

        public async Task<TEntity> RetrievePartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object phone, object email, object vat, object domain, object company) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrievePartnerWithNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object extra_domain) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner_with_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrievePartnerWithPhoneEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object phone, object email, object extra_domain) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner_with_phone_email) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrievePartnerWithVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat, object extra_domain) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner_with_vat) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RunVatChecksInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country, object vat, object partner_name, object validation) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _run_vat_checks) ---
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _run_vat_checks) ---
            */
            return default;
        }

        public async Task<TEntity> SaveAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object xpath) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: save) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SaveEmbeddedFieldAsync<TEntity>(IEnumerable<TEntity> entities, object el) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: save_embedded_field) ---
            */
            return default;
        }

        public async Task<TEntity> SaveOeStructureAsync<TEntity>(IEnumerable<TEntity> entities, object el) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: save_oe_structure) ---
            #endif
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SaveOeStructureHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _save_oe_structure_hook) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SaveSnippetAsync<TEntity>(IEnumerable<TEntity> entities, object name, object arch, object template_key, object snippet_key, object thumbnail_url) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: save_snippet) ---
            */
            return default;
        }

        public async Task<TEntity> ScheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: schedule_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> SearchAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_address_search) ---
            */
            return default;
        }

        public async Task<TEntity> SearchBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_barcode) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchBuildDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_build_dates) ---
            */
            return default;
        }

        public async Task<TEntity> SearchCanViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _search_can_view) ---
            */
            return default;
        }

        public async Task<TEntity> SearchCurrentJobSkillIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_job.py, METHOD: _search_current_job_skill_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_display_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchForChannelInviteAsync<TEntity>(IEnumerable<TEntity> entities, object search_term, Guid channel_id, object limit) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: search_for_channel_invite) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchForChannelInviteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object search_term, Guid channel_id, object limit) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _search_for_channel_invite) ---
            */
            return default;
        }

        public async Task<TEntity> SearchForChannelInviteToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object channel) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _search_for_channel_invite_to_store) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _search_for_channel_invite_to_store) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_get_detail) ---
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
        public async Task<TEntity> SearchHasPublishedProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _search_has_published_products) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIncomingQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_incoming_qty) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_is_finished) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsKitsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _search_is_kits) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberChannelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invited) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member_channel_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberInvitedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member_invited) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_is_ongoing) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsParticipatingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_is_participating) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsSubcontractorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _search_is_subcontractor) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_visible) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsVisibleOnWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_is_visible_on_website) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchMentionSuggestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object limit, object extra_domain) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _search_mention_suggestions) ---
            */
            return default;
        }

        public async Task<TEntity> SearchModelDataIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _search_model_data_id) ---
            */
            return default;
        }

        public async Task<TEntity> SearchOutgoingQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_outgoing_qty) ---
            */
            return default;
        }

        public async Task<TEntity> SearchPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchQtyAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_qty_available) ---
            */
            return default;
        }

        public async Task<TEntity> SearchRenderResultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fetch_fields, object mapping, object icon, object limit) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
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

        public async Task<TEntity> SearchRenderResultsPricesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mapping, object combination_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _search_render_results_prices) ---
            */
            return default;
        }

        public async Task<TEntity> SearchSlideChannelCompletedIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _search_slide_channel_completed_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchSlideChannelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _search_slide_channel_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> SearchValuationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: product.py, METHOD: _search_valuation) ---
            */
            return default;
        }

        public async Task<TEntity> SearchVirtualAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _search_virtual_available) ---
            */
            return default;
        }

        public async Task<TEntity> SearchWishlistVisitorIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _search_wishlist_visitor_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SelectionServicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: product_template.py, METHOD: _selection_service_policy) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _selection_service_policy) ---
            */
            return default;
        }

        public async Task<TEntity> SendShareEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object fullscreen) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _send_share_email) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _send_share_email) ---
            */
            return default;
        }

        public async Task<TEntity> ServiceTrackingBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            --- METHOD SOURCE (MODULE: event_product, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            */
            return default;
        }

        public async Task<TEntity> SetBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> SetBaseUnitCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _set_base_unit_count) ---
            */
            return default;
        }

        public async Task<TEntity> SetBaseUnitIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _set_base_unit_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SetCalendarLastNotifAckInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _set_calendar_last_notif_ack) ---
            */
            return default;
        }

        public async Task<TEntity> SetDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> SetDefaultFaqInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _set_default_faq) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SetNoupdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _set_noupdate) ---
            */
            return default;
        }

        public async Task<TEntity> SetOpenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: set_open) ---
            */
            return default;
        }

        public async Task<TEntity> SetPostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _set_post_date) ---
            */
            return default;
        }

        public async Task<TEntity> SetProductVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_product_variant_field) ---
            */
            return default;
        }

        public async Task<TEntity> SetPwdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _set_pwd) ---
            */
            return default;
        }

        public async Task<TEntity> SetSequenceBottomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_bottom) ---
            */
            return default;
        }

        public async Task<TEntity> SetSequenceDownAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_down) ---
            */
            return default;
        }

        public async Task<TEntity> SetSequenceTopAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_top) ---
            */
            return default;
        }

        public async Task<TEntity> SetSequenceUpAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: set_sequence_up) ---
            */
            return default;
        }

        public async Task<TEntity> SetStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> SetTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _set_teaser) ---
            */
            return default;
        }

        public async Task<TEntity> SetTzContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _set_tz_context) ---
            */
            return default;
        }

        public async Task<TEntity> SetViewedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _set_viewed) ---
            */
            return default;
        }

        public async Task<TEntity> SetVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_volume) ---
            */
            return default;
        }

        public async Task<TEntity> SetWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_weight) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldOpenProductQuantsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: product.py, METHOD: _should_open_product_quants) ---
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: _should_open_product_quants) ---
            */
            return default;
        }

        public async Task<TEntity> SignupCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: signup_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> SignupGetAuthParamAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: signup_get_auth_param) ---
            */
            return default;
        }

        public async Task<TEntity> SignupPrepareAsync<TEntity>(IEnumerable<TEntity> entities, object signup_type) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: signup_prepare) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SignupRetrieveInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _signup_retrieve_info) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SignupRetrievePartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token, object check_validity, object raise_exception) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _signup_retrieve_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SnippetSaveViewValuesHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _snippet_save_view_values_hook) ---
            */
            return default;
        }

        public async Task<TEntity> SplitMenusStateByFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _split_menus_state_by_field) ---
            */
            return default;
        }

        public async Task<TEntity> SplitVatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vat) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _split_vat) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SyncedCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_partner.py, METHOD: _synced_commercial_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _synced_commercial_fields) ---
            */
            return default;
        }

        public async Task<TEntity> SynchronizeWithStageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stage) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _synchronize_with_stage) ---
            */
            return default;
        }

        public async Task<TEntity> TagToWriteValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tags) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _tag_to_write_vals) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ToEmptyOeStructureAsync<TEntity>(IEnumerable<TEntity> entities, object el) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: to_empty_oe_structure) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ToFieldRefAsync<TEntity>(IEnumerable<TEntity> entities, object el) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: to_field_ref) ---
            */
            return default;
        }

        public async Task<TEntity> ToMarkupDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _to_markup_data) ---
            */
            return default;
        }

        public async Task<TEntity> ToStoreDefaultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py, METHOD: _to_store_defaults) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleBoothMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py, METHOD: toggle_booth_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleExhibitorMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: toggle_exhibitor_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: toggle_website_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteTrackAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: toggle_website_track) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteTrackProposalAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: toggle_website_track_proposal) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: website_partner, FILE: res_partner.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _track_template) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: website_event_menu.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkCommentAsync<TEntity>(IEnumerable<TEntity> entities, Guid message_id) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: unlink_comment) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkContactRelEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _unlink_contact_rel_employee) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptLoyaltyProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: product_template.py, METHOD: _unlink_except_loyalty_products) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptMasterDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: product_template.py, METHOD: _unlink_except_master_data) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptOpenSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: product_template.py, METHOD: _unlink_except_open_session) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _unlink_except_user) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfEnoughKarmaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _unlink_if_enough_karma) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfPartnerInAccountMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _unlink_if_partner_in_account_move) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfPosNoOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _unlink_if_pos_no_orders) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _update_address) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object content, Guid forum_id) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _update_content) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateFieldTranslationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object translations, object digest, object source_lang) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _update_field_translations) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateLastActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _update_last_activity) ---
            */
            return default;
        }

        public async Task<TEntity> UpdatePeppolStatePerCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _update_peppol_state_per_company) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateWebsiteMenuEntryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname_bool, object fname_o2m, object fmenu_type) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _update_website_menu_entry) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateWebsiteMenusInternalAsync<TEntity>(IEnumerable<TEntity> entities, object menus_update_by_field) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _update_website_menus) ---
            */
            return default;
        }

        public async Task<TEntity> ValidInheritanceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object arch) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _valid_inheritance) ---
            #endif
            return default;
        }

        public async Task<TEntity> ValidateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: validate) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_attributes) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateClassesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object expr) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_classes) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ValidateCustomViewsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: ir_ui_view.py, METHOD: _validate_custom_views) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_custom_views) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateDomainIdentifiersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object domain, object use, object target_model, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_domain_identifiers) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateExpressionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object py_expression, object use, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_expression) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateFaClassAccessibilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object description) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_fa_class_accessibility) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ValidateModuleViewsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object module) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_module_views) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateQwebDirectiveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object directive, object view_type) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_qweb_directive) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTagAInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_a) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTagButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_button) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTagCalendarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_calendar) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTagDivInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_div) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTagFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_field) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTagFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_filter) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTagFormInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_form) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTagGraphInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_graph) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTagGroupbyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_groupby) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTagHierarchyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: web_hierarchy, FILE: ir_ui_view.py, METHOD: _validate_tag_hierarchy) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTagImgInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_img) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTagLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_label) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTagListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_list) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTagPageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_page) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTagSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_search) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTagSearchpanelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_searchpanel) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTagUlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object name_manager, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_tag_ul) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object node, object model_name, object view_type, object editable, object node_info) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_view) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateXmlEncodingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object text) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py, METHOD: _validate_xml_encoding) ---
            */
            return default;
        }

        public async Task<TEntity> VerifySeatsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot_tickets) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _verify_seats_availability) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ViewGetInheritedChildrenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: _view_get_inherited_children) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ViewHeaderGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: view_header_get) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ViewsGetInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object get_children, object bundles, object root, object visited) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: ir_ui_view.py, METHOD: _views_get) ---
            */
            return default;
        }

        public async Task<TEntity> VoteAsync<TEntity>(IEnumerable<TEntity> entities, object upvote) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: vote) ---
            */
            return default;
        }

        public async Task<TEntity> WebsiteShowQuickAddInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_template.py, METHOD: _website_show_quick_add) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_ui_view.py, METHOD: write) ---
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

        public async Task<TEntity> WriteCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteSeoMetadataable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _write_company_type) ---
            */
            return default;
        }
    }
}