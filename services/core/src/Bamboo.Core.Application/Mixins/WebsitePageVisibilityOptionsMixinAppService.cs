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
    public partial class WebsitePageVisibilityOptionsMixinAppService : ApplicationService, IWebsitePageVisibilityOptionsMixinAppService
    {

        public WebsitePageVisibilityOptionsMixinAppService() 
        {

        }

        public async Task<TEntity> ActionGenerateLeadsAsync<TEntity>(IEnumerable<TEntity> entities, object event_lead_rules) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_event.py, METHOD: action_generate_leads) ---
            */
            return default;
        }

        public async Task<TEntity> ActionInviteContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py, METHOD: action_invite_contacts) ---
            --- METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py, METHOD: action_invite_contacts) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMassMailingAttendeesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py, METHOD: action_mass_mailing_attendees) ---
            --- METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py, METHOD: action_mass_mailing_attendees) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMassMailingTrackSpeakersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event_track, FILE: event_event.py, METHOD: action_mass_mailing_track_speakers) ---
            --- METHOD SOURCE (MODULE: mass_mailing_event_track_sms, FILE: event.py, METHOD: action_mass_mailing_track_speakers) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenSlotCalendarAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: action_open_slot_calendar) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: action_set_done) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewLinkedOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_event.py, METHOD: action_view_linked_orders) ---
            */
            return default;
        }

        public async Task<TEntity> CheckClosingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_closing_date) ---
            */
            return default;
        }

        public async Task<TEntity> CheckEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_event_url) ---
            */
            return default;
        }

        public async Task<TEntity> CheckForPublicationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _check_for_publication) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSlotsDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_slots_dates) ---
            */
            return default;
        }

        public async Task<TEntity> CheckWebsiteIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _check_website_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressInlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_address_inline) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_address_search) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBoothMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py, METHOD: _compute_booth_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommunityMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_community_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_date_tz) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCategoryAvailableIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_category_available_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCategoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_category_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBoothIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_mail_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegisterUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_event_register_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_open) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsSoldOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_sold_out) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsStartedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_started) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventShareUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_event_share_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventSlotCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_slot_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventTicketIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_ticket_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExhibitorMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: _compute_exhibitor_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFieldIsOneDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_field_is_one_day) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_is_finished) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_is_ongoing) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsParticipatingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_is_participating) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsVisibleOnWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_is_visible_on_website) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeKanbanStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_kanban_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLeadCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_event.py, METHOD: _compute_lead_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_note) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_post_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_question_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSalePriceTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_event.py, METHOD: _compute_sale_price_total) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsLimitedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats_limited) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsMaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats_max) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSponsorCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: _compute_sponsor_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStartSaleDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_start_sale_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_tag_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_teaser) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTicketInstructionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_ticket_instructions) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTimeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_time_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_track_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTracksTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_tracks_tag_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUseBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_use_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteMenuDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_website_menu_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_website_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteTrackInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_website_track) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteTrackProposalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_website_track_proposal) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CopyEventMenusAsync<TEntity>(IEnumerable<TEntity> entities, object old_events) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: copy_event_menus) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateMenuInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sequence, object name, object url, Guid xml_id, object menu_type, object parent_menu_type) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _create_menu) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_content) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCoverPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _default_cover_properties) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_description) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_event_mail_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: default_get) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_question_ids) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultWebsiteMetaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_website_meta) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _default_website_meta) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FetchIsParticipatingEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _fetch_is_participating_events) ---
            */
            return default;
        }

        public async Task<TEntity> GcMarkEventsDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _gc_mark_events_done) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _get_access_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: get_backend_menu_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetBoothStatCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _get_booth_stat_count) ---
            */
            return default;
        }

        public async Task<TEntity> GetDateRangeStrInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object lang_code) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_date_range_str) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_default_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetEventResourceUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_event_resource_urls) ---
            */
            return default;
        }

        public async Task<TEntity> GetExternalDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_external_description) ---
            */
            return default;
        }

        public async Task<TEntity> GetExternalDescriptionUrlEncodedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_external_description_url_encoded) ---
            */
            return default;
        }

        public async Task<TEntity> GetIcsFileInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_ics_file) ---
            */
            return default;
        }

        public async Task<TEntity> GetKioskUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: get_kiosk_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetMenuTypeFieldMatchingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_menu_type_field_matching) ---
            */
            return default;
        }

        public async Task<TEntity> GetMenuUpdateFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_menu_update_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetMenusUpdateByFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object menus_state_by_field, object force_update) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_menus_update_by_field) ---
            */
            return default;
        }

        public async Task<TEntity> GetSeatsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot_tickets) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_seats_availability) ---
            */
            return default;
        }

        public async Task<TEntity> GetSlotTicketsAvailabilityPosAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> slot_ticket_ids) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_event.py, METHOD: get_slot_tickets_availability_pos) ---
            */
            return default;
        }

        public async Task<TEntity> GetTicketsAccessHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> registration_ids) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_tickets_access_hash) ---
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteMenuEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_website_menu_entries) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: google_map_link) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _google_map_link) ---
            */
            return default;
        }

        public async Task<TEntity> HasPublishedTrackInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _has_published_track) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _lang_get) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_event.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object config) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_event.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetOperationForMailMessageOperationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message_operation) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _mail_get_operation_for_mail_message_operation) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadByInboxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object msg_vals) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _notify_thread_by_inbox) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _onchange_event_url) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeSeatsMaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _onchange_seats_max) ---
            */
            return default;
        }

        public async Task<TEntity> SearchAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_address_search) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchBuildDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_build_dates) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_is_finished) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_is_ongoing) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsParticipatingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_is_participating) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsVisibleOnWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_is_visible_on_website) ---
            */
            return default;
        }

        public async Task<TEntity> SearchRenderResultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fetch_fields, object mapping, object icon, object limit) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_render_results) ---
            */
            return default;
        }

        public async Task<TEntity> SetPostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _set_post_date) ---
            */
            return default;
        }

        public async Task<TEntity> SetTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _set_teaser) ---
            */
            return default;
        }

        public async Task<TEntity> SetTzContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _set_tz_context) ---
            */
            return default;
        }

        public async Task<TEntity> SplitMenusStateByFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _split_menus_state_by_field) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleBoothMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py, METHOD: toggle_booth_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleExhibitorMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: toggle_exhibitor_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteMenuAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: toggle_website_menu) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteTrackAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: toggle_website_track) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleWebsiteTrackProposalAsync<TEntity>(IEnumerable<TEntity> entities, object val) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: toggle_website_track_proposal) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateWebsiteMenuEntryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname_bool, object fname_o2m, object fmenu_type) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _update_website_menu_entry) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateWebsiteMenusInternalAsync<TEntity>(IEnumerable<TEntity> entities, object menus_update_by_field) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _update_website_menus) ---
            */
            return default;
        }

        public async Task<TEntity> VerifySeatsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot_tickets) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _verify_seats_availability) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IWebsitePageVisibilityOptionsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: write) ---
            */
            return default;
        }
    }
}