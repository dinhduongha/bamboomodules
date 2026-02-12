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
    public partial class EventEventAppService
    {

        protected async Task<EventEvent> CheckClosingDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_closing_date) ---
            */
            return default;
        }

        protected async Task<EventEvent> CheckEventUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_event_url) ---
            */
            return default;
        }

        protected async Task<EventEvent> CheckSlotsDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_slots_dates) ---
            */
            return default;
        }

        protected async Task<EventEvent> CheckWebsiteIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _check_website_id) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeAddressInlineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_address_inline) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeAddressSearchInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_address_search) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeBoothMenuInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py, METHOD: _compute_booth_menu) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeCommunityMenuInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_community_menu) ---
            --- METHOD SOURCE (MODULE: website_event_track_quiz, FILE: event_event.py, METHOD: _compute_community_menu) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeDateTzInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_date_tz) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventBoothCategoryAvailableIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_category_available_ids) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventBoothCategoryIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_category_ids) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventBoothCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_count) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventBoothIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _compute_event_booth_ids) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventMailIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_mail_ids) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventRegisterUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_event_register_url) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventRegistrationsOpenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_open) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventRegistrationsSoldOutInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_sold_out) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventRegistrationsStartedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_started) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventShareUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_share_url) ---
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_event_share_url) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventSlotCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_slot_count) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventTicketIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_ticket_ids) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_url) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeExhibitorMenuInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: _compute_exhibitor_menu) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeFieldIsOneDayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_field_is_one_day) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeIsFinishedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_is_finished) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeIsOngoingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_is_ongoing) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeIsParticipatingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_is_participating) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeIsVisibleOnWebsiteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_is_visible_on_website) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeKanbanStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_kanban_state) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeLeadCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_crm, FILE: event_event.py, METHOD: _compute_lead_count) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeNoteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_note) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeQuestionIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_question_ids) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeSalePriceTotalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: event_event.py, METHOD: _compute_sale_price_total) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeSeatsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeSeatsLimitedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats_limited) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeSeatsMaxInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats_max) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeSponsorCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: _compute_sponsor_count) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeStartSaleDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_start_sale_date) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeTagIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_tag_ids) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeTicketInstructionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_ticket_instructions) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeTimeDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_time_data) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeTrackCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_track_count) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeTracksTagIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_tracks_tag_ids) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeUseBarcodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_use_barcode) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeWebsiteMenuDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_website_menu_data) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeWebsiteMenuInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_website_menu) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeWebsiteTrackInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_website_track) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeWebsiteTrackProposalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _compute_website_track_proposal) ---
            */
            return default;
        }

        protected async Task<EventEvent> ComputeWebsiteUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        protected async Task<EventEvent> CreateMenuInternalAsync(object sequence, object name, object url, Guid xml_id, object menu_type, object parent_menu_type)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _create_menu) ---
            */
            return default;
        }

        protected async Task<EventEvent> DefaultCoverPropertiesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _default_cover_properties) ---
            */
            return default;
        }

        protected async Task<EventEvent> DefaultDescriptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_description) ---
            */
            return default;
        }

        protected async Task<EventEvent> DefaultEventMailIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_event_mail_ids) ---
            */
            return default;
        }

        protected async Task<EventEvent> DefaultQuestionIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_question_ids) ---
            */
            return default;
        }

        protected async Task<EventEvent> DefaultWebsiteMetaInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _default_website_meta) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventEvent> FetchIsParticipatingEventsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _fetch_is_participating_events) ---
            */
            return default;
        }

        protected async Task<EventEvent> GcMarkEventsDoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _gc_mark_events_done) ---
            */
            return default;
        }

        protected async Task<EventEvent> GetBoothStatCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_event.py, METHOD: _get_booth_stat_count) ---
            */
            return default;
        }

        protected async Task<EventEvent> GetDateRangeStrInternalAsync(object start_datetime, object lang_code)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_date_range_str) ---
            */
            return default;
        }

        protected async Task<EventEvent> GetDefaultStageIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_default_stage_id) ---
            */
            return default;
        }

        protected async Task<EventEvent> GetEventResourceUrlsInternalAsync(object slot)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_event_resource_urls) ---
            */
            return default;
        }

        protected async Task<EventEvent> GetExternalDescriptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_external_description) ---
            */
            return default;
        }

        protected async Task<EventEvent> GetExternalDescriptionUrlEncodedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_external_description_url_encoded) ---
            */
            return default;
        }

        protected async Task<EventEvent> GetIcsFileInternalAsync(object slot)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_ics_file) ---
            */
            return default;
        }

        protected async Task<EventEvent> GetMenuTypeFieldMatchingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_menu_type_field_matching) ---
            --- METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py, METHOD: _get_menu_type_field_matching) ---
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: _get_menu_type_field_matching) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _get_menu_type_field_matching) ---
            */
            return default;
        }

        protected async Task<EventEvent> GetMenuUpdateFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_menu_update_fields) ---
            --- METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py, METHOD: _get_menu_update_fields) ---
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: _get_menu_update_fields) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _get_menu_update_fields) ---
            */
            return default;
        }

        protected async Task<EventEvent> GetMenusUpdateByFieldInternalAsync(object menus_state_by_field, object force_update)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_menus_update_by_field) ---
            */
            return default;
        }

        protected async Task<EventEvent> GetSeatsAvailabilityInternalAsync(object slot_tickets)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_seats_availability) ---
            */
            return default;
        }

        protected async Task<EventEvent> GetTicketsAccessHashInternalAsync(List<Guid> registration_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_tickets_access_hash) ---
            */
            return default;
        }

        protected async Task<EventEvent> GetWebsiteMenuEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _get_website_menu_entries) ---
            --- METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py, METHOD: _get_website_menu_entries) ---
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: _get_website_menu_entries) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _get_website_menu_entries) ---
            */
            return default;
        }

        protected async Task<EventEvent> GoogleMapLinkInternalAsync(object zoom)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _google_map_link) ---
            */
            return default;
        }

        protected async Task<EventEvent> HasPublishedTrackInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _has_published_track) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventEvent> LangGetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _lang_get) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventEvent> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_event.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventEvent> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: event_event.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<EventEvent> MailGetOperationForMailMessageOperationInternalAsync(object message_operation)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _mail_get_operation_for_mail_message_operation) ---
            */
            return default;
        }

        protected async Task<EventEvent> OnchangeEventUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _onchange_event_url) ---
            */
            return default;
        }

        protected async Task<EventEvent> OnchangeSeatsMaxInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _onchange_seats_max) ---
            */
            return default;
        }

        protected async Task<EventEvent> SearchAddressSearchInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_address_search) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventEvent> SearchBuildDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_build_dates) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventEvent> SearchGetDetailInternalAsync(object website, object order, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        protected async Task<EventEvent> SearchIsFinishedInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_is_finished) ---
            */
            return default;
        }

        protected async Task<EventEvent> SearchIsOngoingInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_is_ongoing) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventEvent> SearchIsParticipatingInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_is_participating) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventEvent> SearchIsVisibleOnWebsiteInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_is_visible_on_website) ---
            */
            return default;
        }

        protected async Task<EventEvent> SearchRenderResultsInternalAsync(object fetch_fields, object mapping, object icon, object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _search_render_results) ---
            */
            return default;
        }

        protected async Task<EventEvent> SetTzContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _set_tz_context) ---
            */
            return default;
        }

        protected async Task<EventEvent> SplitMenusStateByFieldInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _split_menus_state_by_field) ---
            */
            return default;
        }

        protected async Task<EventEvent> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        protected async Task<EventEvent> UpdateWebsiteMenuEntryInternalAsync(object fname_bool, object fname_o2m, object fmenu_type)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _update_website_menu_entry) ---
            */
            return default;
        }

        protected async Task<EventEvent> UpdateWebsiteMenusInternalAsync(object menus_update_by_field)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event, FILE: event_event.py, METHOD: _update_website_menus) ---
            --- METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py, METHOD: _update_website_menus) ---
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py, METHOD: _update_website_menus) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py, METHOD: _update_website_menus) ---
            */
            return default;
        }

        protected async Task<EventEvent> VerifySeatsAvailabilityInternalAsync(object slot_tickets)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _verify_seats_availability) ---
            */
            return default;
        }
    }
}