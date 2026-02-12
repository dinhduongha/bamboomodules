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
    public partial class CalendarRecurrenceAppService
    {

        protected async Task<CalendarRecurrence> ApplyRecurrenceInternalAsync(object specific_values_creation, object no_send_edit, object generic_values_creation)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _apply_recurrence) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py, METHOD: _apply_recurrence) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _apply_recurrence) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> CancelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py, METHOD: _cancel) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> CancelMicrosoftInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _cancel_microsoft) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> ComputeDtstartInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _compute_dtstart) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _compute_name) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> ComputeRruleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _compute_rrule) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _compute_rrule) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> CreateFromGoogleInternalAsync(object gevents, object vals_list)
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py, METHOD: _create_from_google) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarRecurrence> DetachEventsInternalAsync(object events)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _detach_events) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> EnsureAttendeesHaveEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _ensure_attendees_have_email) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetDailyRecurrenceNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_daily_recurrence_name) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetEventGoogleIdInternalAsync(object @event)
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py, METHOD: _get_event_google_id) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetEventUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py, METHOD: _get_event_user) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetEventUserMInternalAsync(Guid user_id)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _get_event_user_m) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetEventsFromInternalAsync(object dtstart)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_events_from) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetFirstEventInternalAsync(object include_outliers)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_first_event) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetGoogleSyncedFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py, METHOD: _get_google_synced_fields) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetLangWeekStartInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_lang_week_start) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetMicrosoftSyncDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _get_microsoft_sync_domain) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetMicrosoftSyncedFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _get_microsoft_synced_fields) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetMonthlyRecurrenceNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_monthly_recurrence_name) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetOccurrencesInternalAsync(object dtstart)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_occurrences) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetOrganizerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _get_organizer) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetOutliersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_outliers) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetRangesInternalAsync(object start, object event_duration)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_ranges) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetRruleInternalAsync(object dtstart)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_rrule) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _get_rrule) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetStartOfPeriodInternalAsync(object dt)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_start_of_period) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetSyncDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py, METHOD: _get_sync_domain) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetTimezoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_timezone) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetWeekDaysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_week_days) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetWeeklyRecurrenceNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_weekly_recurrence_name) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetYearlyRecurrenceNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _get_yearly_recurrence_name) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GoogleValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py, METHOD: _google_values) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> HasBaseEventTimeFieldsChangedInternalAsync(object @new)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _has_base_event_time_fields_changed) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> InverseRruleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _inverse_rrule) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _inverse_rrule) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> IsAlldayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _is_allday) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> IsEventOverInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _is_event_over) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> IsGoogleInsertionBlockedInternalAsync(object sender_user)
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py, METHOD: _is_google_insertion_blocked) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> IsMicrosoftInsertionBlockedInternalAsync(object sender_user)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _is_microsoft_insertion_blocked) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarRecurrence> MicrosoftToOdooValuesInternalAsync(object microsoft_recurrence, object default_reminders, object default_values, List<Guid> with_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _microsoft_to_odoo_values) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> MicrosoftValuesInternalAsync(object fields_to_sync, object initial_values)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _microsoft_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarRecurrence> OdooValuesInternalAsync(object google_recurrence, object default_reminders)
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py, METHOD: _odoo_values) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> RangeCalculationInternalAsync(object @event, object duration)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _range_calculation) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> ReconcileEventsInternalAsync(object ranges)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _reconcile_events) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarRecurrence> RestartGoogleSyncInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py, METHOD: _restart_google_sync) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarRecurrence> RestartMicrosoftSyncInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _restart_microsoft_sync) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarRecurrence> RruleParseInternalAsync(object rule_str, object date_start)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _rrule_parse) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> RruleSerializeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _rrule_serialize) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> SelectNewBaseEventInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _select_new_base_event) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> SetupAlarmsInternalAsync(object recurrence_update)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _setup_alarms) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> SplitFromInternalAsync(object @event, object recurrence_values)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _split_from) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _split_from) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> StopAtInternalAsync(object @event)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _stop_at) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> WriteEventsInternalAsync(object values, object dtstart)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py, METHOD: _write_events) ---
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py, METHOD: _write_events) ---
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _write_events) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> WriteFromGoogleInternalAsync(object gevent, object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py, METHOD: _write_from_google) ---
            */
            return default;
        }

        protected async Task<CalendarRecurrence> WriteFromMicrosoftInternalAsync(object microsoft_event, object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py, METHOD: _write_from_microsoft) ---
            */
            return default;
        }
    }
}