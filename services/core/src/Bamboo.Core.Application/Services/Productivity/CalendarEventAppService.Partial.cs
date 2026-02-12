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
    public partial class CalendarEventAppService
    {

        protected async Task<CalendarEvent> ApplyRecurrenceValuesInternalAsync(object values, object future)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _apply_recurrence_values) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> AttendeesValuesInternalAsync(object partner_commands)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _attendees_values) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> BreakRecurrenceInternalAsync(object future)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _break_recurrence) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> CancelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _cancel) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> CancelMicrosoftInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _cancel_microsoft) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> CheckCalendarPrivacyWritePermissionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _check_calendar_privacy_write_permissions) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> CheckClosingDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _check_closing_date) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> CheckEmployeesAvailabilityForEventInternalAsync(object schedule_by_partner, object event_interval)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: calendar_event.py, METHOD: _check_employees_availability_for_event) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> CheckMicrosoftSyncStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _check_microsoft_sync_status) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> CheckModifyEventPermissionInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _check_modify_event_permission) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> CheckOrganizerValidationConditionsInternalAsync(object vals_list)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _check_organizer_validation_conditions) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> CheckOrganizerValidationInternalAsync(object sender_user, object partner_included)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _check_organizer_validation) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> CheckPrivateEventConditionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _check_private_event_conditions) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> CheckRecurrenceOverlappingInternalAsync(object new_start)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _check_recurrence_overlapping) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> CheckValuesToSyncInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _check_values_to_sync) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _check_values_to_sync) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeAttendeesCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_attendees_count) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeCurrentAttendeeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_current_attendee) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_dates) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeDisplayDescriptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_display_description) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeDisplayTimeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_display_time) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeDurationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_duration) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeEffectivePrivacyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_effective_privacy) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeFieldValueInternalAsync(object field)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_field_value) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeGoogleIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _compute_google_id) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeInvalidEmailPartnerIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_invalid_email_partner_ids) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeIsHighlightedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_is_highlighted) ---
            --- METHOD SOURCE (MODULE: crm, FILE: calendar.py, METHOD: _compute_is_highlighted) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: calendar.py, METHOD: _compute_is_highlighted) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeIsOrganizerAloneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_is_organizer_alone) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeRecurrenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_recurrence) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeRruleTypeUiInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_rrule_type_ui) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeShouldShowStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_should_show_status) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeStopInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_stop) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeUnavailablePartnerIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_unavailable_partner_ids) ---
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: calendar_event.py, METHOD: _compute_unavailable_partner_ids) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeUserCanEditInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_user_can_edit) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeVideocallLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_videocall_location) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeVideocallSourceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_videocall_source) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _compute_videocall_source) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> CreateVideocallChannelIdInternalAsync(object name, List<Guid> partner_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _create_videocall_channel_id) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> CreateVideocallChannelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _create_videocall_channel) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> DefaultPartnersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _default_partners) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> DefaultStartInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _default_start) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> DefaultStopInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _default_stop) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> DoSmsReminderInternalAsync(object alarms)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar_sms, FILE: calendar_event.py, METHOD: _do_sms_reminder) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> EnsureAttendeesHaveEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _ensure_attendees_have_email) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> FetchQueryInternalAsync(object query, object fields)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _fetch_query) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ForbidRecurrenceCreationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _forbid_recurrence_creation) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ForbidRecurrenceUpdateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _forbid_recurrence_update) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> GetActivityDeadlineFromStartInternalAsync(object start, object allday)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_activity_deadline_from_start) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> GetActivityExcludedModelsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_activity_excluded_models) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> GetArchiveValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_archive_values) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _get_archive_values) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> GetAttendeeStatusO2mInternalAsync(object attendee)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _get_attendee_status_o2m) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> GetContactDetailsDescriptionInternalAsync(object organizer, object partners)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_contact_details_description) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> GetCustomFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_custom_fields) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> GetCustomerDescriptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_customer_description) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> GetCustomerSummaryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_customer_summary) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> GetDateFormatsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_date_formats) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> GetDefaultPrivacyDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_default_privacy_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> GetDisplayTimeInternalAsync(object start, object stop, object zduration, object zallday)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_display_time) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> GetDurationInternalAsync(object start, object stop)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_duration) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> GetEventUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _get_event_user) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> GetEventUserMInternalAsync(Guid user_id)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _get_event_user_m) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> GetEventsIntervalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: calendar_event.py, METHOD: _get_events_interval) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> GetGoogleSyncedFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _get_google_synced_fields) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> GetIcsFileInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_ics_file) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> GetMailTzInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_mail_tz) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> GetMicrosoftSyncDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _get_microsoft_sync_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> GetMicrosoftSyncedFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _get_microsoft_synced_fields) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> GetOrganizerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _get_organizer) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> GetOrganizerUserChangeInfoInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _get_organizer_user_change_info) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> GetPublicFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_public_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> GetRecurrenceParamsByDateInternalAsync(object event_date)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_recurrence_params_by_date) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> GetRecurrenceParamsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_recurrence_params) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> GetRecurrentFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_recurrent_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> GetRemoveSyncIdValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_remove_sync_id_values) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _get_remove_sync_id_values) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> GetStartDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_start_date) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> GetSyncDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _get_sync_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> GetTimeFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_time_fields) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> GetTimeUpdateDictInternalAsync(object base_event, object time_values)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_time_update_dict) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> GetTriggerAlarmTypesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_trigger_alarm_types) ---
            --- METHOD SOURCE (MODULE: calendar_sms, FILE: calendar_event.py, METHOD: _get_trigger_alarm_types) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> GetUpdateFutureEventsValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_update_future_events_values) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _get_update_future_events_values) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> GetUpdatedRecurrenceValuesInternalAsync(object new_start_date)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_updated_recurrence_values) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> GoogleValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _google_values) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> InverseDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _inverse_dates) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> IsCrmLeadInternalAsync(object defaults, object ctx)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: calendar.py, METHOD: _is_crm_lead) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> IsEventOverInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _is_event_over) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> IsGoogleInsertionBlockedInternalAsync(object sender_user)
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _is_google_insertion_blocked) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> IsMatchingTimeslotInternalAsync(object start, object stop, object allday)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _is_matching_timeslot) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> IsMicrosoftInsertionBlockedInternalAsync(object sender_user)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _is_microsoft_insertion_blocked) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> IsPartnerUnavailableInternalAsync(object partner, object partner_events)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _is_partner_unavailable) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> MailGetOperationForMailMessageOperationInternalAsync(object message_operation)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _mail_get_operation_for_mail_message_operation) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> MicrosoftToOdooRecurrenceValuesInternalAsync(object microsoft_event, object default_values)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _microsoft_to_odoo_recurrence_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> MicrosoftToOdooValuesInternalAsync(object microsoft_event, object default_reminders, object default_values, List<Guid> with_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _microsoft_to_odoo_values) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> MicrosoftValuesInternalAsync(object fields_to_sync, object initial_values)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _microsoft_values) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> MicrosoftValuesOccurenceInternalAsync(object initial_values)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _microsoft_values_occurence) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> NeedVideoCallInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: calendar_event.py, METHOD: _need_video_call) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> OdooAttendeeCommandsInternalAsync(object google_event)
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _odoo_attendee_commands) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> OdooAttendeeCommandsMInternalAsync(object microsoft_event)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _odoo_attendee_commands_m) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> OdooRemindersCommandsInternalAsync(object reminders)
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _odoo_reminders_commands) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> OdooRemindersCommandsMInternalAsync(object microsoft_event)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _odoo_reminders_commands_m) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> OdooValuesInternalAsync(object google_event, object default_reminders)
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _odoo_values) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> OnchangeDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _onchange_date) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> PreparePartnerContactDetailsHtmlInternalAsync(object section_title, object partner)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _prepare_partner_contact_details_html) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> RangeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _range) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<List<object>> ReadGroupInternalAsync(object domain, object groupby, object aggregates, object having, object offset, object limit, object order)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _read_group) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<List<object>> ReadGroupingSetsInternalAsync(object domain, object grouping_sets, object aggregates, object order)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _read_grouping_sets) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> RecreateEventDifferentOrganizerInternalAsync(object values, object sender_user)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _recreate_event_different_organizer) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> ResetAttendeesStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _reset_attendees_status) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> RestartGoogleSyncInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _restart_google_sync) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> RestartMicrosoftSyncInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _restart_microsoft_sync) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> RewriteRecurrenceInternalAsync(object values, object time_values, object recurrence_values)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _rewrite_recurrence) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> SearchCurrentAttendeeInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _search_current_attendee) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> SetDiscussVideocallLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _set_discuss_videocall_location) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarEvent> SetVideocallLocationInternalAsync(object vals_list)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _set_videocall_location) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> SetupAlarmsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _setup_alarms) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> SetupEventRecurrentAlarmsInternalAsync(object events_by_alarm)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _setup_event_recurrent_alarms) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> SkipSendMailStatusUpdateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _skip_send_mail_status_update) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _skip_send_mail_status_update) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _skip_send_mail_status_update) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> SyncActivitiesInternalAsync(object fields)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _sync_activities) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> UpdateAttendeeStatusInternalAsync(List<Guid> attendee_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _update_attendee_status) ---
            */
            return default;
        }

        protected async Task<CalendarEvent> UpdateFutureEventsInternalAsync(object values, object time_values, object recurrence_values)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _update_future_events) ---
            */
            return default;
        }
    }
}