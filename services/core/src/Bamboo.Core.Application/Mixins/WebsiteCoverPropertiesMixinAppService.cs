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
    public partial class WebsiteCoverPropertiesMixinAppService : ApplicationService, IWebsiteCoverPropertiesMixinAppService
    {

        public WebsiteCoverPropertiesMixinAppService() 
        {

        }

        public async Task<TEntity> ActionAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partners, object member_status, object raise_on_access) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_add_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionChannelEnrollAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_channel_enroll) ---
            */
            return default;
        }

        public async Task<TEntity> ActionChannelInviteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_channel_invite) ---
            */
            return default;
        }

        public async Task<TEntity> ActionChannelOpenInviteWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template, object enroll_mode) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_channel_open_invite_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGenerateLeadsAsync<TEntity>(IEnumerable<TEntity> entities, object event_lead_rules) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_event.py, METHOD: action_generate_leads) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGrantAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_grant_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionInviteContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py, METHOD: action_invite_contacts) ---
            --- METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py, METHOD: action_invite_contacts) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMassMailingAttendeesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py, METHOD: action_mass_mailing_attendees) ---
            --- METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py, METHOD: action_mass_mailing_attendees) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMassMailingTrackSpeakersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event_track, FILE: event_event.py, METHOD: action_mass_mailing_track_speakers) ---
            --- METHOD SOURCE (MODULE: mass_mailing_event_track_sms, FILE: event.py, METHOD: action_mass_mailing_track_speakers) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenSlotCalendarAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: action_open_slot_calendar) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToCompletedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_completed_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToEngagedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_engaged_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToInvitedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_invited_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToMembersAsync<TEntity>(IEnumerable<TEntity> entities, object status_filter) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRefuseAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_refuse_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRequestAccessAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_request_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRequestAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_request_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: action_set_done) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnarchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_unarchive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewLinkedOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_event.py, METHOD: action_view_linked_orders) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRatingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_view_ratings) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewSlidesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_view_slides) ---
            */
            return default;
        }

        public async Task<TEntity> AddGroupsMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _add_groups_members) ---
            */
            return default;
        }

        public async Task<TEntity> AllTagsAsync<TEntity>(IEnumerable<TEntity> entities, object @join, object min_limit) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: all_tags) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AllowPublishRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _allow_publish_rating_stats) ---
            */
            return default;
        }

        public async Task<TEntity> CheckClosingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_closing_date) ---
            */
            return default;
        }

        public async Task<TEntity> CheckEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_event_url) ---
            */
            return default;
        }

        public async Task<TEntity> CheckForPublicationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _check_for_publication) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSlotsDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_slots_dates) ---
            */
            return default;
        }

        public async Task<TEntity> CheckWebsiteIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _check_website_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActionRightsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_action_rights) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressInlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_address_inline) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_address_search) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowCommentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_allow_comment) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBlogPostCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_blog_post_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBoothMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py, METHOD: _compute_booth_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanPublishInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_can_publish) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanUploadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_can_upload) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryAndSlideIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_category_and_slide_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommunityMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_community_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_date_tz) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEnrollInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_enroll) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCategoryAvailableIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_category_available_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCategoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_category_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_mail_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegisterUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_event_register_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_open) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsSoldOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_sold_out) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsStartedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_started) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventShareUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_event_share_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventSlotCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_slot_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventTicketIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_ticket_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExhibitorMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: _compute_exhibitor_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFieldIsOneDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_field_is_one_day) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ComputeHasRequestedAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_has_requested_access) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_is_finished) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_is_ongoing) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsParticipatingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_is_participating) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_is_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsVisibleOnWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_is_visible_on_website) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeKanbanStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_kanban_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLeadCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_event.py, METHOD: _compute_lead_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMembersCountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_members_counts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMembershipValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_membership_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_note) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerHasNewContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_partner_has_new_content) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_partners) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_post_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePrerequisiteUserHasCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_prerequisite_user_has_completed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_question_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_rating_stats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSalePriceTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_event.py, METHOD: _compute_sale_price_total) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsLimitedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats_limited) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsMaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats_max) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideLastUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_slide_last_update) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlidesStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_slides_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSponsorCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: _compute_sponsor_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStartSaleDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_start_sale_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_tag_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_teaser) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTicketInstructionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_ticket_instructions) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTimeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_time_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_track_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTracksTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_tracks_tag_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUseBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_use_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_user_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteAbsoluteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_absolute_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteDefaultBackgroundImageUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_default_background_image_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteMenuDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_website_menu_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_website_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteTrackInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_website_track) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteTrackProposalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_website_track_proposal) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CopyEventMenusAsync<TEntity>(IEnumerable<TEntity> entities, object old_events) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: copy_event_menus) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sequence, object name, object url, Guid xml_id, object menu_type, object parent_menu_type) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _create_menu) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _default_access_token) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_content) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCoverPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: mixins.py, METHOD: _default_cover_properties) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _default_cover_properties) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _default_cover_properties) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_description) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_event_mail_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: default_get) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_question_ids) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultWebsiteMetaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_website_meta) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _default_website_meta) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FetchIsParticipatingEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _fetch_is_participating_events) ---
            */
            return default;
        }

        public async Task<TEntity> FilterAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object raise_on_access) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _filter_add_members) ---
            */
            return default;
        }

        public async Task<TEntity> GcMarkEventsDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _gc_mark_events_done) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _get_access_action) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_access_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: get_backend_menu_id) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: get_backend_menu_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackgroundInternalAsync<TEntity>(IEnumerable<TEntity> entities, object height, object width) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: mixins.py, METHOD: _get_background) ---
            */
            return default;
        }

        public async Task<TEntity> GetBoothStatCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _get_booth_stat_count) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCanPublishErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_can_publish_error_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetCategorizedSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_domain, object order, object force_void, object limit, object offset) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_categorized_slides) ---
            */
            return default;
        }

        public async Task<TEntity> GetDateRangeStrInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object lang_code) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_date_range_str) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultEnrollMsgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_default_enroll_msg) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_default_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetEarnedKarmaInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_earned_karma) ---
            */
            return default;
        }

        public async Task<TEntity> GetEventResourceUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_event_resource_urls) ---
            */
            return default;
        }

        public async Task<TEntity> GetExternalDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_external_description) ---
            */
            return default;
        }

        public async Task<TEntity> GetExternalDescriptionUrlEncodedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_external_description_url_encoded) ---
            */
            return default;
        }

        public async Task<TEntity> GetIcsFileInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_ics_file) ---
            */
            return default;
        }

        public async Task<TEntity> GetKioskUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: get_kiosk_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetMenuTypeFieldMatchingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_menu_type_field_matching) ---
            */
            return default;
        }

        public async Task<TEntity> GetMenuUpdateFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_menu_update_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetMenusUpdateByFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object menus_state_by_field, object force_update) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_menus_update_by_field) ---
            */
            return default;
        }

        public async Task<TEntity> GetPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_placeholder_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetSeatsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot_tickets) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_seats_availability) ---
            */
            return default;
        }

        public async Task<TEntity> GetSlotTicketsAvailabilityPosAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> slot_ticket_ids) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_event.py, METHOD: get_slot_tickets_availability_pos) ---
            */
            return default;
        }

        public async Task<TEntity> GetTicketsAccessHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> registration_ids) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_tickets_access_hash) ---
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteMenuEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_website_menu_entries) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: google_map_link) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _google_map_link) ---
            */
            return default;
        }

        public async Task<TEntity> HasPublishedTrackInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _has_published_track) ---
            */
            return default;
        }

        public async Task<TEntity> InitColumnInternalAsync<TEntity>(IEnumerable<TEntity> entities, object column_name) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _init_column) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _lang_get) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_event.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object config) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_event.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetOperationForMailMessageOperationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message_operation) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _mail_get_operation_for_mail_message_operation) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _mail_get_partner_fields) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: message_post) ---
            */
            return default;
        }

        public async Task<TEntity> MoveCategorySlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object new_category) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _move_category_slides) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadByInboxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object msg_vals) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _notify_thread_by_inbox) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _onchange_event_url) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeSeatsMaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _onchange_seats_max) ---
            */
            return default;
        }

        public async Task<TEntity> RatingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _rating_domain) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveMembershipInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _remove_membership) ---
            */
            return default;
        }

        public async Task<TEntity> ResequenceSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slide, object force_category) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _resequence_slides) ---
            */
            return default;
        }

        public async Task<TEntity> SearchAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_address_search) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchBuildDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_build_dates) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_is_finished) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberChannelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invited) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member_channel_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberInvitedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member_invited) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_is_ongoing) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsParticipatingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_is_participating) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_visible) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsVisibleOnWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_is_visible_on_website) ---
            */
            return default;
        }

        public async Task<TEntity> SearchPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchRenderResultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fetch_fields, object mapping, object icon, object limit) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _search_render_results) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_render_results) ---
            */
            return default;
        }

        public async Task<TEntity> SendShareEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _send_share_email) ---
            */
            return default;
        }

        public async Task<TEntity> SetPostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _set_post_date) ---
            */
            return default;
        }

        public async Task<TEntity> SetTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _set_teaser) ---
            */
            return default;
        }

        public async Task<TEntity> SetTzContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _set_tz_context) ---
            */
            return default;
        }

        public async Task<TEntity> SplitMenusStateByFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _split_menus_state_by_field) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleBoothMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py, METHOD: toggle_booth_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleExhibitorMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: toggle_exhibitor_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: toggle_website_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteTrackAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: toggle_website_track) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteTrackProposalAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: toggle_website_track_proposal) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateWebsiteMenuEntryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname_bool, object fname_o2m, object fmenu_type) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _update_website_menu_entry) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateWebsiteMenusInternalAsync<TEntity>(IEnumerable<TEntity> entities, object menus_update_by_field) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _update_website_menus) ---
            */
            return default;
        }

        public async Task<TEntity> VerifySeatsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot_tickets) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _verify_seats_availability) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsiteCoverPropertiesMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: mixins.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: write) ---
            */
            return default;
        }
    }
}