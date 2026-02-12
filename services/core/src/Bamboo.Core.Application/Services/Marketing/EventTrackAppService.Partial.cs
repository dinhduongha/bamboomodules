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
    public partial class EventTrackAppService
    {

        protected async Task<EventTrack> ComputeContactEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_contact_email) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputeContactPhoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_contact_phone) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputeCtaTimeDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_cta_time_data) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputeDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_date) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputeEndDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_end_date) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputeFieldIsOneDayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_field_is_one_day) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputeIsReminderOnInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_is_reminder_on) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputeIsYoutubeChatAvailableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track_live, FILE: event_track.py, METHOD: _compute_is_youtube_chat_available) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputeKanbanStateLabelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_kanban_state_label) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputePartnerBiographyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_biography) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputePartnerCompanyNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_company_name) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputePartnerEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_email) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputePartnerFunctionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_function) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputePartnerImageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_image) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputePartnerNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_name) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputePartnerPhoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_phone) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputePartnerTagLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_tag_line) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputeQuizDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track_quiz, FILE: event_track.py, METHOD: _compute_quiz_data) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputeQuizIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track_quiz, FILE: event_track.py, METHOD: _compute_quiz_id) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputeQuizQuestionsCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track_quiz, FILE: event_track.py, METHOD: _compute_quiz_questions_count) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputeTrackTimeDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_track_time_data) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputeWebsiteImageUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_website_image_url) ---
            --- METHOD SOURCE (MODULE: website_event_track_live, FILE: event_track.py, METHOD: _compute_website_image_url) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputeWebsiteUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputeWishlistVisitorIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_wishlist_visitor_ids) ---
            */
            return default;
        }

        protected async Task<EventTrack> ComputeYoutubeVideoIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track_live, FILE: event_track.py, METHOD: _compute_youtube_video_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventTrack> GetDefaultStageIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_default_stage_id) ---
            */
            return default;
        }

        protected async Task<EventTrack> GetEventTrackVisitorsInternalAsync(object force_create)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_event_track_visitors) ---
            */
            return default;
        }

        protected async Task<EventTrack> GetIcsFileInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_ics_file) ---
            */
            return default;
        }

        protected async Task<EventTrack> GetTrackCalendarDescriptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_calendar_description) ---
            */
            return default;
        }

        protected async Task<EventTrack> GetTrackCalendarReminderDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_calendar_reminder_dates) ---
            */
            return default;
        }

        protected async Task<EventTrack> GetTrackCalendarReminderTimesWarningInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_calendar_reminder_times_warning) ---
            */
            return default;
        }

        protected async Task<EventTrack> GetTrackCalendarUrlsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_calendar_urls) ---
            */
            return default;
        }

        protected async Task<EventTrack> GetTrackSuggestionsInternalAsync(object restrict_domain, object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_suggestions) ---
            */
            return default;
        }

        protected async Task<EventTrack> InverseDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _inverse_date) ---
            */
            return default;
        }

        protected async Task<EventTrack> InverseEndDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _inverse_end_date) ---
            */
            return default;
        }

        protected async Task<EventTrack> MailGetTimezoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _mail_get_timezone) ---
            */
            return default;
        }

        protected async Task<EventTrack> MailingGetDefaultDomainInternalAsync(object mailing)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_event_track, FILE: event_track.py, METHOD: _mailing_get_default_domain) ---
            */
            return default;
        }

        protected async Task<EventTrack> MessageAddDefaultRecipientsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _message_add_default_recipients) ---
            */
            return default;
        }

        protected async Task<EventTrack> MessagePostAfterHookInternalAsync(object message, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _message_post_after_hook) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<EventTrack> SearchGetDetailInternalAsync(object website, object order, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        protected async Task<EventTrack> SearchWishlistVisitorIdsInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _search_wishlist_visitor_ids) ---
            */
            return default;
        }

        protected async Task<EventTrack> SynchronizeWithStageInternalAsync(object stage)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _synchronize_with_stage) ---
            */
            return default;
        }

        protected async Task<EventTrack> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        protected async Task<EventTrack> TrackTemplateInternalAsync(object changes)
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _track_template) ---
            */
            return default;
        }
    }
}