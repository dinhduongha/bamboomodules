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
    [Module("microsoft_calendar", Category = "Productivity", Depends = new[] { "microsoft_account", "calendar" })]
    public partial class MicrosoftCalendarSyncAppService : ApplicationService, IMicrosoftCalendarSyncAppService
    {

        public MicrosoftCalendarSyncAppService() 
        {

        }

        public async Task<TEntity> ActionJoinMeetingAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_join_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> ActionJoinVideoCallAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_join_video_call) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMassArchiveAsync<TEntity>(IEnumerable<TEntity> entities, object recurrence_update_setting) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: action_mass_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMassDeletionAsync<TEntity>(IEnumerable<TEntity> entities, object recurrence_update_setting) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_mass_deletion) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenCalendarEventAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_open_calendar_event) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenComposerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_open_composer) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendSmsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar_sms, FILE: calendar_event.py, METHOD: action_send_sms) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_sendmail) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnlinkEventAsync<TEntity>(IEnumerable<TEntity> entities, Guid attendee_id, object recurrence) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_unlink_event) ---
            */
            return default;
        }

        public async Task<TEntity> ApplyRecurrenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object specific_values_creation, object no_send_edit, object generic_values_creation) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _apply_recurrence) ---
            */
            return default;
        }

        public async Task<TEntity> ApplyRecurrenceValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values, object future) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _apply_recurrence_values) ---
            */
            return default;
        }

        public async Task<TEntity> AttendeesValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_commands) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _attendees_values) ---
            */
            return default;
        }

        public async Task<TEntity> BreakRecurrenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object future) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _break_recurrence) ---
            */
            return default;
        }

        public async Task<TEntity> CancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _cancel) ---
            */
            return default;
        }

        public async Task<TEntity> CancelMicrosoftInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _cancel_microsoft) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _cancel_microsoft) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _cancel_microsoft) ---
            */
            return default;
        }

        public async Task<TEntity> ChangeAttendeeStatusAsync<TEntity>(IEnumerable<TEntity> entities, object status, object recurrence_update_setting) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: change_attendee_status) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCalendarPrivacyWritePermissionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _check_calendar_privacy_write_permissions) ---
            */
            return default;
        }

        public async Task<TEntity> CheckClosingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _check_closing_date) ---
            */
            return default;
        }

        public async Task<TEntity> CheckEmployeesAvailabilityForEventInternalAsync<TEntity>(IEnumerable<TEntity> entities, object schedule_by_partner, object event_interval) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: calendar_event.py, METHOD: _check_employees_availability_for_event) ---
            */
            return default;
        }

        public async Task<TEntity> CheckMicrosoftSyncStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _check_microsoft_sync_status) ---
            */
            return default;
        }

        public async Task<TEntity> CheckModifyEventPermissionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _check_modify_event_permission) ---
            */
            return default;
        }

        public async Task<TEntity> CheckOldEventUpdateRequiredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lower_bound_day_range, object update_time_diff) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _check_old_event_update_required) ---
            */
            return default;
        }

        public async Task<TEntity> CheckOrganizerValidationConditionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _check_organizer_validation_conditions) ---
            */
            return default;
        }

        public async Task<TEntity> CheckOrganizerValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sender_user, object partner_included) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _check_organizer_validation) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPrivateEventConditionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _check_private_event_conditions) ---
            */
            return default;
        }

        public async Task<TEntity> CheckRecurrenceOverlappingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_start) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _check_recurrence_overlapping) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckValuesToSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _check_values_to_sync) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _check_values_to_sync) ---
            */
            return default;
        }

        public async Task<TEntity> ClearVideocallLocationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: clear_videocall_location) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAttendeesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_attendees_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentAttendeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_current_attendee) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_dates) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_display_description) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_display_time) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDtstartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _compute_dtstart) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDurationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_duration) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEffectivePrivacyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_effective_privacy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFieldValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_field_value) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGoogleIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _compute_google_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvalidEmailPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_invalid_email_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsHighlightedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_is_highlighted) ---
            --- METHOD SOURCE (MODULE: crm, FILE: calendar.py, METHOD: _compute_is_highlighted) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: calendar.py, METHOD: _compute_is_highlighted) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsOrganizerAloneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_is_organizer_alone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _compute_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurrenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_recurrence) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRruleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _compute_rrule) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRruleTypeUiInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_rrule_type_ui) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShouldShowStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_should_show_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStopInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_stop) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUnavailablePartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_unavailable_partner_ids) ---
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: calendar_event.py, METHOD: _compute_unavailable_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserCanEditInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_user_can_edit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVideocallLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_videocall_location) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVideocallSourceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_videocall_source) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _compute_videocall_source) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateFromGoogleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object gevents, object vals_list) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py, METHOD: _create_from_google) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateFromMicrosoftInternalAsync<TEntity>(IEnumerable<TEntity> entities, object microsoft_event, object vals_list) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _create_from_microsoft) ---
            */
            return default;
        }

        public async Task<TEntity> CreateVideocallChannelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _create_videocall_channel_id) ---
            */
            return default;
        }

        public async Task<TEntity> CreateVideocallChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _create_videocall_channel) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: crm, FILE: calendar.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: calendar.py, METHOD: default_get) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _default_partners) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultStartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _default_start) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultStopInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _default_stop) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DetachEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object events) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _detach_events) ---
            */
            return default;
        }

        public async Task<TEntity> DoSmsReminderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object alarms) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar_sms, FILE: calendar_event.py, METHOD: _do_sms_reminder) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureAttendeesHaveEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _ensure_attendees_have_email) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _ensure_attendees_have_email) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _ensure_attendees_have_email) ---
            */
            return default;
        }

        public async Task<TEntity> ExtendMicrosoftDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _extend_microsoft_domain) ---
            */
            return default;
        }

        public async Task<TEntity> FetchQueryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object query, object fields) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _fetch_query) ---
            */
            return default;
        }

        public async Task<TEntity> FindPartnerCustomerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: find_partner_customer) ---
            */
            return default;
        }

        public async Task<TEntity> ForbidRecurrenceCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _forbid_recurrence_creation) ---
            */
            return default;
        }

        public async Task<TEntity> ForbidRecurrenceUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _forbid_recurrence_update) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetActivityDeadlineFromStartInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object allday) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_activity_deadline_from_start) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetActivityExcludedModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_activity_excluded_models) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetArchiveValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_archive_values) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _get_archive_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttendeeStatusO2mInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attendee) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _get_attendee_status_o2m) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetContactDetailsDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object organizer, object partners) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_contact_details_description) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCustomFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_custom_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetCustomerDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_customer_description) ---
            */
            return default;
        }

        public async Task<TEntity> GetCustomerSummaryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_customer_summary) ---
            */
            return default;
        }

        public async Task<TEntity> GetDailyRecurrenceNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_daily_recurrence_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDateFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_date_formats) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultDurationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: get_default_duration) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultPrivacyDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_default_privacy_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDiscussVideocallLocationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: get_discuss_videocall_location) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDisplayTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object zduration, object zallday) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_display_time) ---
            */
            return default;
        }

        public async Task<TEntity> GetDisplayTimeTzAsync<TEntity>(IEnumerable<TEntity> entities, object tz) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: get_display_time_tz) ---
            */
            return default;
        }

        public async Task<TEntity> GetDurationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_duration) ---
            */
            return default;
        }

        public async Task<TEntity> GetEventGoogleIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @event) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py, METHOD: _get_event_google_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetEventUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _get_event_user) ---
            */
            return default;
        }

        public async Task<TEntity> GetEventUserMInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _get_event_user_m) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _get_event_user_m) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _get_event_user_m) ---
            */
            return default;
        }

        public async Task<TEntity> GetEventsFromInternalAsync<TEntity>(IEnumerable<TEntity> entities, object dtstart) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_events_from) ---
            */
            return default;
        }

        public async Task<TEntity> GetEventsIntervalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: calendar_event.py, METHOD: _get_events_interval) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstEventInternalAsync<TEntity>(IEnumerable<TEntity> entities, object include_outliers) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_first_event) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetGoogleSyncedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _get_google_synced_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetIcsFileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_ics_file) ---
            */
            return default;
        }

        public async Task<TEntity> GetLangWeekStartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_lang_week_start) ---
            */
            return default;
        }

        public async Task<TEntity> GetMailTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_mail_tz) ---
            */
            return default;
        }

        public async Task<TEntity> GetMicrosoftRecordsToSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object full_sync) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _get_microsoft_records_to_sync) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMicrosoftServiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _get_microsoft_service) ---
            */
            return default;
        }

        public async Task<TEntity> GetMicrosoftSyncDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _get_microsoft_sync_domain) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _get_microsoft_sync_domain) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _get_microsoft_sync_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetMicrosoftSyncedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _get_microsoft_synced_fields) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _get_microsoft_synced_fields) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _get_microsoft_synced_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetMonthlyRecurrenceNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_monthly_recurrence_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetNextAlarmDateAsync<TEntity>(IEnumerable<TEntity> entities, object events_by_alarm) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: get_next_alarm_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetOccurrencesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object dtstart) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_occurrences) ---
            */
            return default;
        }

        public async Task<TEntity> GetOrganizerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _get_organizer) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _get_organizer) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOrganizerUserChangeInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _get_organizer_user_change_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetOutliersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_outliers) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPublicFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_public_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetRangesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object event_duration) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_ranges) ---
            */
            return default;
        }

        public async Task<TEntity> GetRecurrenceNameAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: get_recurrence_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRecurrenceParamsByDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object event_date) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_recurrence_params_by_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetRecurrenceParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_recurrence_params) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRecurrentFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_recurrent_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRemoveSyncIdValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_remove_sync_id_values) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _get_remove_sync_id_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetRruleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object dtstart) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _get_rrule) ---
            */
            return default;
        }

        public async Task<TEntity> GetStartDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_start_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetStartOfPeriodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object dt) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_start_of_period) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetStateSelectionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: get_state_selections) ---
            */
            return default;
        }

        public async Task<TEntity> GetSyncDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _get_sync_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetSyncedEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _get_synced_events) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTimeFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_time_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetTimeUpdateDictInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_event, object time_values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_time_update_dict) ---
            */
            return default;
        }

        public async Task<TEntity> GetTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_timezone) ---
            */
            return default;
        }

        public async Task<TEntity> GetTriggerAlarmTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_trigger_alarm_types) ---
            --- METHOD SOURCE (MODULE: calendar_sms, FILE: calendar_event.py, METHOD: _get_trigger_alarm_types) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUnusualDaysAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: calendar_event.py, METHOD: get_unusual_days) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUpdateFutureEventsValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_update_future_events_values) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _get_update_future_events_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetUpdatedRecurrenceValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_start_date) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_updated_recurrence_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetWeekDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_week_days) ---
            */
            return default;
        }

        public async Task<TEntity> GetWeeklyRecurrenceNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_weekly_recurrence_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetYearlyRecurrenceNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_yearly_recurrence_name) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _google_values) ---
            */
            return default;
        }

        public async Task<TEntity> HasBaseEventTimeFieldsChangedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @new) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _has_base_event_time_fields_changed) ---
            */
            return default;
        }

        public async Task<TEntity> InverseDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _inverse_dates) ---
            */
            return default;
        }

        public async Task<TEntity> InverseRruleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _inverse_rrule) ---
            */
            return default;
        }

        public async Task<TEntity> IsAlldayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _is_allday) ---
            */
            return default;
        }

        public async Task<TEntity> IsCrmLeadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object defaults, object ctx) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: calendar.py, METHOD: _is_crm_lead) ---
            */
            return default;
        }

        public async Task<TEntity> IsEventOverInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _is_event_over) ---
            */
            return default;
        }

        public async Task<TEntity> IsGoogleInsertionBlockedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sender_user) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _is_google_insertion_blocked) ---
            */
            return default;
        }

        public async Task<TEntity> IsMatchingTimeslotInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object allday) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _is_matching_timeslot) ---
            */
            return default;
        }

        public async Task<TEntity> IsMicrosoftInsertionBlockedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sender_user) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _is_microsoft_insertion_blocked) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _is_microsoft_insertion_blocked) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _is_microsoft_insertion_blocked) ---
            */
            return default;
        }

        public async Task<TEntity> IsPartnerUnavailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object partner_events) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _is_partner_unavailable) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetOperationForMailMessageOperationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message_operation) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _mail_get_operation_for_mail_message_operation) ---
            */
            return default;
        }

        public async Task<TEntity> MicrosoftAttendeeAnswerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object answer, object @params, object timeout) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _microsoft_attendee_answer) ---
            */
            return default;
        }

        public async Task<TEntity> MicrosoftDeleteInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, Guid event_id, object timeout) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _microsoft_delete) ---
            */
            return default;
        }

        public async Task<TEntity> MicrosoftInsertInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values, object timeout) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _microsoft_insert) ---
            */
            return default;
        }

        public async Task<TEntity> MicrosoftPatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, Guid event_id, object values, object timeout) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _microsoft_patch) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MicrosoftToOdooRecurrenceValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object microsoft_event, object default_values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _microsoft_to_odoo_recurrence_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MicrosoftToOdooValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object microsoft_event, object default_reminders, object default_values, List<Guid> with_ids) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _microsoft_to_odoo_values) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _microsoft_to_odoo_values) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _microsoft_to_odoo_values) ---
            */
            return default;
        }

        public async Task<TEntity> MicrosoftValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_sync, object initial_values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _microsoft_values) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _microsoft_values) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _microsoft_values) ---
            */
            return default;
        }

        public async Task<TEntity> MicrosoftValuesOccurenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object initial_values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _microsoft_values_occurence) ---
            */
            return default;
        }

        public async Task<TEntity> NeedVideoCallInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _need_video_call) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> OdooAttendeeCommandsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object google_event) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _odoo_attendee_commands) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> OdooAttendeeCommandsMInternalAsync<TEntity>(IEnumerable<TEntity> entities, object microsoft_event) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _odoo_attendee_commands_m) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> OdooRemindersCommandsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reminders) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _odoo_reminders_commands) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> OdooRemindersCommandsMInternalAsync<TEntity>(IEnumerable<TEntity> entities, object microsoft_event) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _odoo_reminders_commands_m) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> OdooValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object google_event, object default_reminders) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _odoo_values) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _onchange_date) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PreparePartnerContactDetailsHtmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object section_title, object partner) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _prepare_partner_contact_details_html) ---
            */
            return default;
        }

        public async Task<TEntity> RangeCalculationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @event, object duration) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _range_calculation) ---
            */
            return default;
        }

        public async Task<TEntity> RangeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _range) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<List<object>> ReadGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object groupby, object aggregates, object having, object offset, object limit, object order) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _read_group) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<List<object>> ReadGroupingSetsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object grouping_sets, object aggregates, object order) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _read_grouping_sets) ---
            */
            return default;
        }

        public async Task<TEntity> ReconcileEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ranges) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _reconcile_events) ---
            */
            return default;
        }

        public async Task<TEntity> RecreateEventDifferentOrganizerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values, object sender_user) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _recreate_event_different_organizer) ---
            */
            return default;
        }

        public async Task<TEntity> ResetAttendeesStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _reset_attendees_status) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RestartGoogleSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py, METHOD: _restart_google_sync) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RestartMicrosoftSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _restart_microsoft_sync) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _restart_microsoft_sync) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _restart_microsoft_sync) ---
            */
            return default;
        }

        public async Task<TEntity> RewriteRecurrenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values, object time_values, object recurrence_values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _rewrite_recurrence) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RruleParseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rule_str, object date_start) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _rrule_parse) ---
            */
            return default;
        }

        public async Task<TEntity> RruleSerializeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _rrule_serialize) ---
            */
            return default;
        }

        public async Task<TEntity> SearchCurrentAttendeeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _search_current_attendee) ---
            */
            return default;
        }

        public async Task<TEntity> SelectNewBaseEventInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _select_new_base_event) ---
            */
            return default;
        }

        public async Task<TEntity> SetDiscussVideocallLocationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: set_discuss_videocall_location) ---
            */
            return default;
        }

        public async Task<TEntity> SetDiscussVideocallLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _set_discuss_videocall_location) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SetVideocallLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _set_videocall_location) ---
            */
            return default;
        }

        public async Task<TEntity> SetupAlarmsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _setup_alarms) ---
            */
            return default;
        }

        public async Task<TEntity> SetupEventRecurrentAlarmsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object events_by_alarm) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _setup_event_recurrent_alarms) ---
            */
            return default;
        }

        public async Task<TEntity> SkipSendMailStatusUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _skip_send_mail_status_update) ---
            */
            return default;
        }

        public async Task<TEntity> SplitFromInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @event, object recurrence_values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _split_from) ---
            */
            return default;
        }

        public async Task<TEntity> StopAtInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @event) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _stop_at) ---
            */
            return default;
        }

        public async Task<TEntity> SyncActivitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _sync_activities) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SyncMicrosoft2odooInternalAsync<TEntity>(IEnumerable<TEntity> entities, object microsoft_events) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _sync_microsoft2odoo) ---
            */
            return default;
        }

        public async Task<TEntity> SyncOdoo2microsoftInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _sync_odoo2microsoft) ---
            */
            return default;
        }

        public async Task<TEntity> SyncRecurrenceMicrosoft2odooInternalAsync<TEntity>(IEnumerable<TEntity> entities, object microsoft_events, object new_events) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _sync_recurrence_microsoft2odoo) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateAttendeeStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attendee_ids) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: _update_attendee_status) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateFutureEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values, object time_values, object recurrence_values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _update_future_events) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateMicrosoftRecurrenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object recurrence, object events) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _update_microsoft_recurrence) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: write) ---
            */
            return default;
        }

        public async Task<TEntity> WriteEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values, object dtstart) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _write_events) ---
            */
            return default;
        }

        public async Task<TEntity> WriteFromGoogleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object gevent, object vals) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py, METHOD: _write_from_google) ---
            */
            return default;
        }

        public async Task<TEntity> WriteFromMicrosoftInternalAsync<TEntity>(IEnumerable<TEntity> entities, object microsoft_event, object vals) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _write_from_microsoft) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py, METHOD: _write_from_microsoft) ---
            */
            return default;
        }
    }
}