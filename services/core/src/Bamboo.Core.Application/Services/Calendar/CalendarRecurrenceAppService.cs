using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("Calendar", Depends = new[] { "base", "mail" })]
    public class CalendarRecurrenceAppService : GenericApplicationService<CalendarRecurrence>, ICalendarRecurrenceAppService
    {
        private readonly IGoogleCalendarSyncAppService _googleCalendarSyncAppService;
        private readonly IMicrosoftCalendarSyncAppService _microsoftCalendarSyncAppService;
        public CalendarRecurrenceAppService(IRepository<CalendarRecurrence, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IGoogleCalendarSyncAppService googleCalendarSyncAppService, IMicrosoftCalendarSyncAppService microsoftCalendarSyncAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _googleCalendarSyncAppService = googleCalendarSyncAppService;
            _microsoftCalendarSyncAppService = microsoftCalendarSyncAppService;
        }

        protected async Task<CalendarRecurrence> ApplyRecurrenceInternalAsync(object specific_values_creation, object no_send_edit, object generic_values_creation)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _apply_recurrence(self, specific_values_creation=None, no_send_edit=False, generic_values_creation=None):
            // """Create missing events in the recurrence and detach events which no longer
            // follow the recurrence rules.
            // :return: detached events
            // """
            // event_vals = []
            // keep = self.env['calendar.event']
            // if specific_values_creation is None:
            //     specific_values_creation = {}
            // 
            // for recurrence in self.filtered('base_event_id'):
            //     recurrence.calendar_event_ids |= recurrence.base_event_id
            //     event = recurrence.base_event_id or recurrence._get_first_event(include_outliers=False)
            //     duration = event.stop - event.start
            //     if specific_values_creation:
            //         ranges = set([(x[1], x[2]) for x in specific_values_creation if x[0] == recurrence.id])
            //     else:
            //         ranges = recurrence._range_calculation(event, duration)
            // 
            //     events_to_keep, ranges = recurrence._reconcile_events(ranges)
            //     keep |= events_to_keep
            //     [base_values] = event.copy_data()
            //     values = []
            //     for start, stop in ranges:
            //         value = dict(base_values, start=start, stop=stop, recurrence_id=recurrence.id, follow_recurrence=True)
            //         if (recurrence.id, start, stop) in specific_values_creation:
            //             value.update(specific_values_creation[(recurrence.id, start, stop)])
            //         if generic_values_creation and recurrence.id in generic_values_creation:
            //             value.update(generic_values_creation[recurrence.id])
            //         values += [value]
            //     event_vals += values
            // 
            // events = self.calendar_event_ids - keep
            // detached_events = self._detach_events(events)
            // context = {
            //     **clean_context(self.env.context),
            //     **{'no_mail_to_attendees': True, 'mail_create_nolog': True},
            // }
            // self.env['calendar.event'].with_context(context).create(event_vals)
            // return detached_events
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _apply_recurrence(self, specific_values_creation=None, no_send_edit=False, generic_values_creation=None):
            // events = self.filtered('need_sync').calendar_event_ids
            // detached_events = super()._apply_recurrence(specific_values_creation, no_send_edit,
            //                                             generic_values_creation)
            // 
            // google_service = GoogleCalendarService(self.env['google.service'])
            // 
            // # If a synced event becomes a recurrence, the event needs to be deleted from
            // # Google since it's now the recurrence which is synced.
            // # Those events are kept in the database and their google_id is updated
            // # according to the recurrence google_id, therefore we need to keep an inactive copy
            // # of those events with the original google id. The next sync will then correctly
            // # delete those events from Google.
            // vals = []
            // for event in events.filtered('google_id'):
            //     if event.active and event.google_id != event.recurrence_id._get_event_google_id(event):
            //         vals += [{
            //             'name': event.name,
            //             'google_id': event.google_id,
            //             'start': event.start,
            //             'stop': event.stop,
            //             'active': False,
            //             'need_sync': True,
            //         }]
            //         event.with_user(event._get_event_user())._google_delete(google_service, event.google_id)
            //         event.google_id = False
            // self.env['calendar.event'].create(vals)
            // 
            // self.calendar_event_ids.need_sync = False
            // return detached_events
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _apply_recurrence(self, specific_values_creation=None, no_send_edit=False, generic_values_creation=None):
            // events = self.filtered('need_sync_m').calendar_event_ids
            // detached_events = super()._apply_recurrence(specific_values_creation, no_send_edit, generic_values_creation)
            // 
            // # If a synced event becomes a recurrence, the event needs to be deleted from
            // # Microsoft since it's now the recurrence which is synced.
            // vals = []
            // for event in events._get_synced_events():
            //     if event.active and event.ms_universal_event_id and not event.recurrence_id.ms_universal_event_id:
            //         vals += [{
            //             'name': event.name,
            //             'microsoft_id': event.microsoft_id,
            //             'ms_universal_event_id': event.ms_universal_event_id,
            //             'start': event.start,
            //             'stop': event.stop,
            //             'active': False,
            //             'need_sync_m': True,
            //         }]
            //         event._microsoft_delete(event.user_id, event.microsoft_id)
            //         event.ms_universal_event_id = False
            // self.env['calendar.event'].create(vals)
            // self.calendar_event_ids.need_sync_m = False
            // return detached_events
            */
            return default;
        }

        protected async Task<CalendarRecurrence> CancelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _cancel(self):
            // self.calendar_event_ids._cancel()
            // super()._cancel()
            */
            return default;
        }

        protected async Task<CalendarRecurrence> CancelMicrosoftInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _cancel_microsoft(self):
            // self.calendar_event_ids.with_context(dont_notify=True)._cancel_microsoft()
            // super()._cancel_microsoft()
            */
            return default;
        }

        protected async Task<CalendarRecurrence> ComputeDtstartInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _compute_dtstart(self):
            // groups = self.env['calendar.event']._read_group([('recurrence_id', 'in', self.ids)], ['recurrence_id'], ['start:min'])
            // start_mapping = {recurrence.id: start_min for recurrence, start_min in groups}
            // for recurrence in self:
            //     recurrence.dtstart = start_mapping.get(recurrence.id)
            */
            return default;
        }

        protected async Task<CalendarRecurrence> ComputeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _compute_name(self):
            // for recurrence in self:
            //     recurrence.name = recurrence.get_recurrence_name()
            */
            return default;
        }

        protected async Task<CalendarRecurrence> ComputeRruleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _compute_rrule(self):
            // for recurrence in self:
            //     current_rule = recurrence._rrule_serialize()
            //     if recurrence.rrule != current_rule:
            //         recurrence.write({'rrule': current_rule})
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _compute_rrule(self):
            // # Note: 'need_sync_m' is set to False to avoid syncing the updated recurrence with
            // # Outlook, as this update may already come from Outlook. If not, this modification will
            // # be already synced through the calendar.event.write()
            // for recurrence in self:
            //     if recurrence.rrule != recurrence._rrule_serialize():
            //         recurrence.write({'rrule': recurrence._rrule_serialize()})
            */
            return default;
        }

        protected async Task<CalendarRecurrence> CreateFromGoogleInternalAsync(object gevents, object vals_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _create_from_google(self, gevents, vals_list):
            // attendee_values = {}
            // for gevent, vals in zip(gevents, vals_list):
            //     base_values = dict(
            //         self.env['calendar.event']._odoo_values(gevent),  # FIXME default reminders
            //         need_sync=False,
            //     )
            //     # If we convert a single event into a recurrency on Google, we should reuse this event on Odoo
            //     # Google reuse the event google_id to identify the recurrence in that case
            //     base_event = self.env['calendar.event'].search([('google_id', '=', vals['google_id'])])
            //     if not base_event:
            //         base_event = self.env['calendar.event'].create(base_values)
            //     else:
            //         # We override the base_event values because they could have been changed in Google interface
            //         # The event google_id will be recalculated once the recurrence is created
            //         base_event.write(dict(base_values, google_id=False))
            //     vals['base_event_id'] = base_event.id
            //     vals['calendar_event_ids'] = [(4, base_event.id)]
            //     # event_tz is written on event in Google but on recurrence in Odoo
            //     vals['event_tz'] = gevent.start.get('timeZone')
            //     attendee_values[base_event.id] = {'attendee_ids': base_values.get('attendee_ids')}
            // 
            // recurrence = super(RecurrenceRule, self.with_context(dont_notify=True))._create_from_google(gevents, vals_list)
            // generic_values_creation = {
            //     rec.id: attendee_values[rec.base_event_id.id]
            //     for rec in recurrence if attendee_values.get(rec.base_event_id.id)
            // }
            // recurrence.with_context(dont_notify=True)._apply_recurrence(generic_values_creation=generic_values_creation)
            // return recurrence
            */
            return default;
        }

        protected async Task<CalendarRecurrence> DetachEventsInternalAsync(object events)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _detach_events(self, events):
            // events.with_context(dont_notify=True).write({
            //     'recurrence_id': False,
            //     'recurrency': True,
            // })
            // return events
            */
            return default;
        }

        protected async Task<CalendarRecurrence> EnsureAttendeesHaveEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _ensure_attendees_have_email(self):
            // self.calendar_event_ids.filtered(lambda e: e.active)._ensure_attendees_have_email()
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetDailyRecurrenceNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _get_daily_recurrence_name(self):
            // if self.end_type == 'count':
            //     return _("Every %(interval)s Days for %(count)s events", interval=self.interval, count=self.count)
            // if self.end_type == 'end_date':
            //     return _("Every %(interval)s Days until %(until)s", interval=self.interval, until=self.until)
            // return _("Every %(interval)s Days", interval=self.interval)
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetEventGoogleIdInternalAsync(object @event)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _get_event_google_id(self, event):
            // """Return the Google id of recurring event.
            // Google ids of recurrence instances are formatted as: {recurrence google_id}_{UTC starting time in compacted ISO8601}
            // """
            // if self.google_id:
            //     if event.allday:
            //         time_id = event.start_date.isoformat().replace('-', '')
            //     else:
            //         # '-' and ':' are optional in ISO8601
            //         start_compacted_iso8601 = event.start.isoformat().replace('-', '').replace(':', '')
            //         # Z at the end for UTC
            //         time_id = '%sZ' % start_compacted_iso8601
            //     return '%s_%s' % (self.google_id, time_id)
            // return False
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetEventUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _get_event_user(self):
            // self.ensure_one()
            // event = self._get_first_event()
            // if event:
            //     return event._get_event_user()
            // return self.env.user
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetEventUserMInternalAsync(Guid user_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _get_event_user_m(self, user_id=None):
            // """ Get the user who will send the request to Microsoft (organizer if synchronized and current user otherwise). """
            // self.ensure_one()
            // event = self._get_first_event()
            // if event:
            //     return event._get_event_user_m(user_id)
            // return self.env.user
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetEventsFromInternalAsync(object dtstart)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _get_events_from(self, dtstart):
            // return self.env['calendar.event'].search([
            //     ('id', 'in', self.calendar_event_ids.ids),
            //     ('start', '>=', dtstart)
            // ])
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetFirstEventInternalAsync(object include_outliers)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _get_first_event(self, include_outliers=False):
            // if not self.calendar_event_ids:
            //     return self.env['calendar.event']
            // events = self.calendar_event_ids.sorted('start')
            // if not include_outliers:
            //     events -= self._get_outliers()
            // return events[:1]
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetGoogleSyncedFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _get_google_synced_fields(self):
            // return {'rrule'}
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetLangWeekStartInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _get_lang_week_start(self):
            // lang = self.env['res.lang']._get_data(code=self.env.user.lang)
            // week_start = int(lang.week_start)  # lang.week_start ranges from '1' to '7'
            // return rrule.weekday(week_start - 1)
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetMicrosoftSyncDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _get_microsoft_sync_domain(self):
            // # Do not sync Odoo recurrences with Outlook Calendar anymore.
            // domain = expression.FALSE_DOMAIN
            // return self._extend_microsoft_domain(domain)
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetMicrosoftSyncedFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _get_microsoft_synced_fields(self):
            // return {'rrule'} | self.env['calendar.event']._get_microsoft_synced_fields()
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetMonthlyRecurrenceNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _get_monthly_recurrence_name(self):
            // if self.month_by == 'day':
            //     weekday_selection = dict(self._fields['weekday']._description_selection(self.env))
            //     byday_selection = dict(self._fields['byday']._description_selection(self.env))
            //     position_label = byday_selection[self.byday]
            //     weekday_label = weekday_selection[self.weekday]
            // 
            //     if self.end_type == 'count':
            //         return _("Every %(interval)s Months on the %(position)s %(weekday)s for %(count)s events", interval=self.interval, position=position_label, weekday=weekday_label, count=self.count)
            //     if self.end_type == 'end_date':
            //         return _("Every %(interval)s Months on the %(position)s %(weekday)s until %(until)s", interval=self.interval, position=position_label, weekday=weekday_label, until=self.until)
            //     return _("Every %(interval)s Months on the %(position)s %(weekday)s", interval=self.interval, position=position_label, weekday=weekday_label)
            // else:
            //     if self.end_type == 'count':
            //         return _("Every %(interval)s Months day %(day)s for %(count)s events", interval=self.interval, day=self.day, count=self.count)
            //     if self.end_type == 'end_date':
            //         return _("Every %(interval)s Months day %(day)s until %(until)s", interval=self.interval, day=self.day, until=self.until)
            //     return _("Every %(interval)s Months day %(day)s", interval=self.interval, day=self.day)
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetOccurrencesInternalAsync(object dtstart)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _get_occurrences(self, dtstart):
            // """
            // Get ocurrences of the rrule
            // :param dtstart: start of the recurrence
            // :return: iterable of datetimes
            // """
            // self.ensure_one()
            // dtstart = self._get_start_of_period(dtstart)
            // if self._is_allday():
            //     return self._get_rrule(dtstart=dtstart)
            // 
            // timezone = self._get_timezone()
            // # Localize the starting datetime to avoid missing the first occurrence
            // dtstart = pytz.utc.localize(dtstart).astimezone(timezone)
            // # dtstart is given as a naive datetime, but it actually represents a timezoned datetime
            // # (rrule package expects a naive datetime)
            // occurences = self._get_rrule(dtstart=dtstart.replace(tzinfo=None))
            // 
            // # Special timezoning is needed to handle DST (Daylight Saving Time) changes.
            // # Given the following recurrence:
            // #   - monthly
            // #   - 1st of each month
            // #   - timezone America/New_York (UTC−05:00)
            // #   - at 6am America/New_York = 11am UTC
            // #   - from 2019/02/01 to 2019/05/01.
            // # The naive way would be to store:
            // # 2019/02/01 11:00 - 2019/03/01 11:00 - 2019/04/01 11:00 - 2019/05/01 11:00 (UTC)
            // #
            // # But a DST change occurs on 2019/03/10 in America/New_York timezone. America/New_York is now UTC−04:00.
            // # From this point in time, 11am (UTC) is actually converted to 7am (America/New_York) instead of the expected 6am!
            // # What should be stored is:
            // # 2019/02/01 11:00 - 2019/03/01 11:00 - 2019/04/01 10:00 - 2019/05/01 10:00 (UTC)
            // #                                                  *****              *****
            // return (timezone.localize(occurrence, is_dst=False).astimezone(pytz.utc).replace(tzinfo=None) for occurrence in occurences)
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetOrganizerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _get_organizer(self):
            // return self.base_event_id.user_id
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetOutliersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _get_outliers(self):
            // synced_events = self.env['calendar.event']
            // for recurrence in self:
            //     if recurrence.calendar_event_ids:
            //         start = min(recurrence.calendar_event_ids.mapped('start'))
            //         starts = set(recurrence._get_occurrences(start))
            //         synced_events |= recurrence.calendar_event_ids.filtered(lambda e: e.start in starts)
            // return self.calendar_event_ids - synced_events
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetRangesInternalAsync(object start, object event_duration)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _get_ranges(self, start, event_duration):
            // starts = self._get_occurrences(start)
            // return ((start, start + event_duration) for start in starts)
            */
            return default;
        }

        public async Task<CalendarRecurrence> GetRecurrenceNameAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def get_recurrence_name(self):
            // if self.rrule_type == 'daily':
            //     return self._get_daily_recurrence_name()
            // if self.rrule_type == 'weekly':
            //     return self._get_weekly_recurrence_name()
            // if self.rrule_type == 'monthly':
            //     return self._get_monthly_recurrence_name()
            // if self.rrule_type == 'yearly':
            //     return self._get_yearly_recurrence_name()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CalendarRecurrence> GetRruleInternalAsync(object dtstart)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _get_rrule(self, dtstart=None):
            // self.ensure_one()
            // freq = self.rrule_type
            // rrule_params = dict(
            //     dtstart=dtstart,
            //     interval=self.interval,
            // )
            // if freq == 'monthly' and self.month_by == 'date':  # e.g. every 15th of the month
            //     rrule_params['bymonthday'] = self.day
            // elif freq == 'monthly' and self.month_by == 'day':  # e.g. every 2nd Monday in the month
            //     rrule_params['byweekday'] = getattr(rrule, RRULE_WEEKDAYS[self.weekday])(int(self.byday))  # e.g. MO(+2) for the second Monday of the month
            // elif freq == 'weekly':
            //     weekdays = self._get_week_days()
            //     if not weekdays:
            //         raise UserError(_("You have to choose at least one day in the week"))
            //     rrule_params['byweekday'] = weekdays
            //     rrule_params['wkst'] = self._get_lang_week_start()
            // 
            // if self.end_type == 'count':  # e.g. stop after X occurence
            //     rrule_params['count'] = min(self.count, MAX_RECURRENT_EVENT)
            // elif self.end_type == 'forever':
            //     rrule_params['count'] = MAX_RECURRENT_EVENT
            // elif self.end_type == 'end_date':  # e.g. stop after 12/10/2020
            //     rrule_params['until'] = datetime.combine(self.until, time.max)
            // return rrule.rrule(
            //     freq_to_rrule(freq), **rrule_params
            // )
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _get_rrule(self, dtstart=None):
            // if not dtstart and self.dtstart:
            //     dtstart = self.dtstart
            // return super()._get_rrule(dtstart)
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetStartOfPeriodInternalAsync(object dt)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _get_start_of_period(self, dt):
            // if self.rrule_type == 'weekly':
            //     week_start = self._get_lang_week_start()
            //     start = dt + relativedelta(weekday=week_start(-1))
            // elif self.rrule_type == 'monthly':
            //     start = dt + relativedelta(day=1)
            // else:
            //     start = dt
            // # Comparaison of DST (to manage the case of going too far back in time).
            // # If we detect a change in the DST between the creation date of an event
            // # and the date used for the occurrence period, we use the creation date of the event.
            // # This is a hack to avoid duplication of events (for example on google calendar).
            // if isinstance(dt, datetime):
            //     timezone = self._get_timezone()
            //     dst_dt = timezone.localize(dt).dst()
            //     dst_start = timezone.localize(start).dst()
            //     if dst_dt != dst_start:
            //         start = dt
            // return start
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetSyncDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _get_sync_domain(self):
            // # Empty rrule may exists in historical data. It is not a desired behavior but it could have been created with
            // # older versions of the module. When synced, these recurrency may come back from Google after database cleaning
            // # and trigger errors as the records are not properly populated.
            // # We also prevent sync of other user recurrent events.
            // return [('calendar_event_ids.user_id', '=', self.env.user.id), ('rrule', '!=', False)]
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetTimezoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _get_timezone(self):
            // return pytz.timezone(self.event_tz or self.env.context.get('tz') or 'UTC')
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetWeekDaysInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _get_week_days(self):
            // """
            // :return: tuple of rrule weekdays for this recurrence.
            // """
            // return tuple(
            //     rrule.weekday(weekday_index)
            //     for weekday_index, weekday in {
            //         rrule.MO.weekday: self.mon,
            //         rrule.TU.weekday: self.tue,
            //         rrule.WE.weekday: self.wed,
            //         rrule.TH.weekday: self.thu,
            //         rrule.FR.weekday: self.fri,
            //         rrule.SA.weekday: self.sat,
            //         rrule.SU.weekday: self.sun,
            //     }.items() if weekday
            // )
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetWeeklyRecurrenceNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _get_weekly_recurrence_name(self):
            // weekday_selection = dict(self._fields['weekday']._description_selection(self.env))
            // weekdays = self._get_week_days()
            // # Convert Weekday object
            // weekdays = [str(w) for w in weekdays]
            // # We need to get the day full name from its three first letters.
            // week_map = {v: k for k, v in RRULE_WEEKDAYS.items()}
            // weekday_short = [week_map[w] for w in weekdays]
            // day_strings = [weekday_selection[day] for day in weekday_short]
            // days = ", ".join(day_strings)
            // 
            // if self.end_type == 'count':
            //     return _("Every %(interval)s Weeks on %(days)s for %(count)s events", interval=self.interval, days=days, count=self.count)
            // if self.end_type == 'end_date':
            //     return _("Every %(interval)s Weeks on %(days)s until %(until)s", interval=self.interval, days=days, until=self.until)
            // return _("Every %(interval)s Weeks on %(days)s", interval=self.interval, days=days)
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GetYearlyRecurrenceNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _get_yearly_recurrence_name(self):
            // if self.end_type == 'count':
            //     return _("Every %(interval)s Years for %(count)s events", interval=self.interval, count=self.count)
            // if self.end_type == 'end_date':
            //     return _("Every %(interval)s Years until %(until)s", interval=self.interval, until=self.until)
            // return _("Every %(interval)s Years", interval=self.interval)
            */
            return default;
        }

        protected async Task<CalendarRecurrence> GoogleValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _google_values(self):
            // event = self._get_first_event()
            // if not event:
            //     return {}
            // values = event._google_values()
            // values['id'] = self.google_id
            // if not self._is_allday():
            //     values['start']['timeZone'] = self.event_tz or 'Etc/UTC'
            //     values['end']['timeZone'] = self.event_tz or 'Etc/UTC'
            // 
            // # DTSTART is not allowed by Google Calendar API.
            // # Event start and end times are specified in the start and end fields.
            // rrule = re.sub('DTSTART:[0-9]{8}T[0-9]{1,8}\\n', '', self.rrule)
            // # UNTIL must be in UTC (appending Z)
            // # We want to only add a 'Z' to non UTC UNTIL values and avoid adding a second.
            // # 'RRULE:FREQ=DAILY;UNTIL=20210224T235959;INTERVAL=3 --> match UNTIL=20210224T235959
            // # 'RRULE:FREQ=DAILY;UNTIL=20210224T235959 --> match
            // rrule = re.sub(r"(UNTIL=\d{8}T\d{6})($|;)", r"\1Z\2", rrule)
            // values['recurrence'] = ['RRULE:%s' % rrule] if 'RRULE:' not in rrule else [rrule]
            // property_location = 'shared' if event.user_id else 'private'
            // values['extendedProperties'] = {
            //     property_location: {
            //         '%s_odoo_id' % self.env.cr.dbname: self.id,
            //     },
            // }
            // return values
            */
            return default;
        }

        protected async Task<CalendarRecurrence> HasBaseEventTimeFieldsChangedInternalAsync(object @new)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _has_base_event_time_fields_changed(self, new):
            // """
            // Indicates if at least one time field of the base event has changed, based
            // on provided `new` values.
            // Note: for all day event comparison, hours/minutes are ignored.
            // """
            // def _convert(value, to_convert):
            //     return value.date() if to_convert else value
            // 
            // old = self.base_event_id and self.base_event_id.read(['start', 'stop', 'allday'])[0]
            // return old and (
            //     old['allday'] != new['allday']
            //     or any(
            //         _convert(new[f], new['allday']) != _convert(old[f], old['allday'])
            //         for f in ('start', 'stop')
            //     )
            // )
            */
            return default;
        }

        protected async Task<CalendarRecurrence> InverseRruleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _inverse_rrule(self):
            // for recurrence in self:
            //     if recurrence.rrule:
            //         values = self._rrule_parse(recurrence.rrule, recurrence.dtstart)
            //         recurrence.with_context(dont_notify=True).write(values)
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _inverse_rrule(self):
            // # Note: 'need_sync_m' is set to False to avoid syncing the updated recurrence with
            // # Outlook, as this update mainly comes from Outlook (the 'rrule' field is not directly
            // # modified in Odoo but computed from other fields).
            // for recurrence in self.filtered('rrule'):
            //     values = self._rrule_parse(recurrence.rrule, recurrence.dtstart)
            //     recurrence.with_context(dont_notify=True).write(dict(values, need_sync_m=False))
            */
            return default;
        }

        protected async Task<CalendarRecurrence> IsAlldayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _is_allday(self):
            // """Returns whether a majority of events are allday or not (there might be some outlier events)
            // """
            // score = sum(1 if e.allday else -1 for e in self.calendar_event_ids)
            // return score >= 0
            */
            return default;
        }

        protected async Task<CalendarRecurrence> IsEventOverInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _is_event_over(self):
            // """Check if all events in this recurrence are in the past.
            // :return: True if all events are over, False otherwise
            // """
            // self.ensure_one()
            // if not self.calendar_event_ids:
            //     return False
            // 
            // now = fields.Datetime.now()
            // today = fields.Date.today()
            // 
            // return all(
            //     (event.stop_date < today if event.allday else event.stop < now)
            //     for event in self.calendar_event_ids
            // )
            */
            return default;
        }

        protected async Task<CalendarRecurrence> IsGoogleInsertionBlockedInternalAsync(object sender_user)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _is_google_insertion_blocked(self, sender_user):
            // self.ensure_one()
            // has_base_event = self.base_event_id
            // has_different_owner = self.base_event_id.user_id and self.base_event_id.user_id != sender_user
            // return has_base_event and has_different_owner
            */
            return default;
        }

        protected async Task<CalendarRecurrence> IsMicrosoftInsertionBlockedInternalAsync(object sender_user)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _is_microsoft_insertion_blocked(self, sender_user):
            // self.ensure_one()
            // has_base_event = self.base_event_id
            // has_different_owner = self.base_event_id.user_id and self.base_event_id.user_id != sender_user
            // return has_base_event and has_different_owner
            */
            return default;
        }

        protected async Task<CalendarRecurrence> MicrosoftToOdooValuesInternalAsync(object microsoft_recurrence, object default_reminders, object default_values, List<Guid> with_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _microsoft_to_odoo_values(self, microsoft_recurrence, default_reminders=(), default_values=None, with_ids=False):
            // recurrence = microsoft_recurrence.get_recurrence()
            // 
            // if with_ids:
            //     recurrence = {
            //         **recurrence,
            //         'microsoft_id': microsoft_recurrence.id,
            //         'ms_universal_event_id': microsoft_recurrence.iCalUId,
            //     }
            // 
            // return recurrence
            */
            return default;
        }

        protected async Task<CalendarRecurrence> MicrosoftValuesInternalAsync(object fields_to_sync)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _microsoft_values(self, fields_to_sync):
            // """
            // Get values to update the whole Outlook event recurrence.
            // (done through the first event of the Outlook recurrence).
            // """
            // return self.base_event_id._microsoft_values(fields_to_sync, initial_values={'type': 'seriesMaster'})
            */
            return default;
        }

        protected async Task<CalendarRecurrence> OdooValuesInternalAsync(object google_recurrence, object default_reminders)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _odoo_values(self, google_recurrence, default_reminders=()):
            // return {
            //     'rrule': google_recurrence.rrule,
            //     'google_id': google_recurrence.id,
            // }
            */
            return default;
        }

        protected async Task<CalendarRecurrence> RangeCalculationInternalAsync(object @event, object duration)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _range_calculation(self, event, duration):
            // """ Calculate the range of recurrence when applying the recurrence
            // The following issues are taken into account:
            //     start of period is sometimes in the past (weekly or monthly rule).
            //     We can easily filter these range values but then the count value may be wrong...
            //     In that case, we just increase the count value, recompute the ranges and dismiss the useless values
            // """
            // self.ensure_one()
            // original_count = self.end_type == 'count' and self.count
            // ranges = set(self._get_ranges(event.start, duration))
            // future_events = set((x, y) for x, y in ranges if x.date() >= event.start.date() and y.date() >= event.start.date())
            // if original_count and len(future_events) < original_count:
            //     # Rise count number because some past values will be dismissed.
            //     self.count = (2*original_count) - len(future_events)
            //     ranges = set(self._get_ranges(event.start, duration))
            //     # We set back the occurrence number to its original value
            //     self.count = original_count
            // # Remove ranges of events occurring in the past
            // ranges = set((x, y) for x, y in ranges if x.date() >= event.start.date() and y.date() >= event.start.date())
            // return ranges
            */
            return default;
        }

        protected async Task<CalendarRecurrence> ReconcileEventsInternalAsync(object ranges)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _reconcile_events(self, ranges):
            // """
            // :param ranges: iterable of tuples (datetime_start, datetime_stop)
            // :return: tuple (events of the recurrence already in sync with ranges,
            //          and ranges not covered by any events)
            // """
            // ranges = set(ranges)
            // 
            // synced_events = self.calendar_event_ids.filtered(lambda e: e._range() in ranges)
            // 
            // existing_ranges = set(event._range() for event in synced_events)
            // ranges_to_create = (event_range for event_range in ranges if event_range not in existing_ranges)
            // return synced_events, ranges_to_create
            */
            return default;
        }

        protected async Task<CalendarRecurrence> RestartGoogleSyncInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _restart_google_sync(self):
            // self.env['calendar.recurrence'].search(self._get_sync_domain()).write({
            //     'need_sync': True,
            // })
            */
            return default;
        }

        protected async Task<CalendarRecurrence> RestartMicrosoftSyncInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _restart_microsoft_sync(self):
            // self.env['calendar.recurrence'].search(self._get_microsoft_sync_domain()).write({
            //     'need_sync_m': True,
            // })
            */
            return default;
        }

        protected async Task<CalendarRecurrence> RruleParseInternalAsync(object rule_str, object date_start)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _rrule_parse(self, rule_str, date_start):
            // # LUL TODO clean this mess
            // data = {}
            // day_list = ['mon', 'tue', 'wed', 'thu', 'fri', 'sat', 'sun']
            // 
            // # Skip X-named RRULE extensions
            // # TODO Remove patch when dateutils contains the fix
            // # HACK https://github.com/dateutil/dateutil/pull/1374
            // # Optional parameters starts with X- and they can be placed anywhere in the RRULE string.
            // # RRULE:FREQ=MONTHLY;INTERVAL=3;X-RELATIVE=1
            // # RRULE;X-EVOLUTION-ENDDATE=20200120:FREQ=WEEKLY;COUNT=3;BYDAY=MO
            // # X-EVOLUTION-ENDDATE=20200120:FREQ=WEEKLY;COUNT=3;BYDAY=MO
            // rule_str = re.sub(r';?X-[-\w]+=[^;:]*', '', rule_str).replace(":;", ":").lstrip(":;")
            // 
            // if 'Z' in rule_str and date_start and not date_start.tzinfo:
            //     date_start = pytz.utc.localize(date_start)
            // rule = rrule.rrulestr(rule_str, dtstart=date_start)
            // 
            // data['rrule_type'] = freq_to_select(rule._freq)
            // data['count'] = rule._count
            // data['interval'] = rule._interval
            // data['until'] = rule._until
            // # Repeat weekly
            // if rule._byweekday:
            //     for weekday in day_list:
            //         data[weekday] = False  # reset
            //     for weekday_index in rule._byweekday:
            //         weekday = rrule.weekday(weekday_index)
            //         data[weekday_to_field(weekday.weekday)] = True
            //         data['rrule_type'] = 'weekly'
            // 
            // # Repeat monthly by nweekday ((weekday, weeknumber), )
            // if rule._bynweekday:
            //     data['weekday'] = day_list[list(rule._bynweekday)[0][0]].upper()
            //     data['byday'] = str(list(rule._bynweekday)[0][1])
            //     data['month_by'] = 'day'
            //     data['rrule_type'] = 'monthly'
            // 
            // if rule._bymonthday and data['rrule_type'] == 'monthly':
            //     data['day'] = list(rule._bymonthday)[0]
            //     data['month_by'] = 'date'
            // 
            // if data.get('until'):
            //     data['end_type'] = 'end_date'
            // elif data.get('count'):
            //     data['end_type'] = 'count'
            // else:
            //     data['end_type'] = 'forever'
            // return data
            */
            return default;
        }

        protected async Task<CalendarRecurrence> RruleSerializeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _rrule_serialize(self):
            // """
            // Compute rule string according to value type RECUR of iCalendar
            // :return: string containing recurring rule (empty if no rule)
            // """
            // if self.interval <= 0:
            //     raise UserError(_('The interval cannot be negative.'))
            // if self.end_type == 'count' and self.count <= 0:
            //     raise UserError(_('The number of repetitions cannot be negative.'))
            // 
            // return str(self._get_rrule()) if self.rrule_type else ''
            */
            return default;
        }

        protected async Task<CalendarRecurrence> SelectNewBaseEventInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _select_new_base_event(self):
            // """
            // when the base event is no more available (archived, deleted, etc.), a new one should be selected
            // """
            // for recurrence in self:
            //     recurrence.base_event_id = recurrence._get_first_event()
            */
            return default;
        }

        protected async Task<CalendarRecurrence> SetupAlarmsInternalAsync(object recurrence_update)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _setup_alarms(self, recurrence_update=False):
            // """ Schedule cron triggers for future events
            // Create one ir.cron.trigger per recurrence.
            // :param recurrence_update: boolean: if true, update all recurrences in self, else only the recurrences
            //        without trigger
            // """
            // now = self.env.context.get('date') or fields.Datetime.now()
            // # get next events
            // self.env['calendar.event'].flush_model(fnames=['recurrence_id', 'start'])
            // if not self.calendar_event_ids.ids:
            //     return
            // 
            // self.env.cr.execute("""
            //     SELECT DISTINCT ON (recurrence_id) id event_id, recurrence_id
            //             FROM calendar_event 
            //            WHERE start > %s
            //              AND id IN %s
            //         ORDER BY recurrence_id,start ASC;
            // """, (now, tuple(self.calendar_event_ids.ids)))
            // result = self.env.cr.dictfetchall()
            // if not result:
            //     return
            // events = self.env['calendar.event'].browse(value['event_id'] for value in result)
            // triggers_by_events = events._setup_alarms()
            // for vals in result:
            //     trigger_id = triggers_by_events.get(vals['event_id'])
            //     if not trigger_id:
            //         continue
            //     recurrence = self.env['calendar.recurrence'].browse(vals['recurrence_id'])
            //     recurrence.trigger_id = trigger_id
            */
            return default;
        }

        protected async Task<CalendarRecurrence> SplitFromInternalAsync(object @event, object recurrence_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _split_from(self, event, recurrence_values=None):
            // """Stops the current recurrence at the given event and creates a new one starting
            // with the event.
            // :param event: starting point of the new recurrence
            // :param recurrence_values: values applied to the new recurrence
            // :return: new recurrence
            // """
            // if recurrence_values is None:
            //     recurrence_values = {}
            // event.ensure_one()
            // if not self:
            //     return
            // [values] = self.copy_data()
            // detached_events = self._stop_at(event)
            // 
            // count = recurrence_values.get('count', 0) or len(detached_events)
            // return self.create({
            //     **values,
            //     **recurrence_values,
            //     'base_event_id': event.id,
            //     'calendar_event_ids': [(6, 0, detached_events.ids)],
            //     'count': max(count, 1),
            // })
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _split_from(self, event, recurrence_values=None):
            // """
            // When a recurrence is splitted, the base event of the new recurrence already
            // exist and may be already synced with Outlook.
            // In this case, we need to be removed this event on Outlook side to avoid duplicates while posting
            // the new recurrence.
            // """
            // new_recurrence = super()._split_from(event, recurrence_values)
            // if new_recurrence and new_recurrence.base_event_id.microsoft_id:
            //     new_recurrence.base_event_id._microsoft_delete(
            //         new_recurrence.base_event_id._get_organizer(),
            //         new_recurrence.base_event_id.microsoft_id
            //     )
            // 
            // return new_recurrence
            */
            return default;
        }

        protected async Task<CalendarRecurrence> StopAtInternalAsync(object @event)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _stop_at(self, event):
            // """Stops the recurrence at the given event. Detach the event and all following
            // events from the recurrence.
            // 
            // :return: detached events from the recurrence
            // """
            // self.ensure_one()
            // events = self._get_events_from(event.start)
            // detached_events = self._detach_events(events)
            // if not self.calendar_event_ids:
            //     self.with_context(archive_on_error=True).unlink()
            //     return detached_events
            // 
            // if event.allday:
            //     until = self._get_start_of_period(event.start_date)
            // else:
            //     until_datetime = self._get_start_of_period(event.start)
            //     until_timezoned = pytz.utc.localize(until_datetime).astimezone(self._get_timezone())
            //     until = until_timezoned.date()
            // self.write({
            //     'end_type': 'end_date',
            //     'until': until - relativedelta(days=1),
            // })
            // return detached_events
            */
            return default;
        }

        protected async Task<CalendarRecurrence> WriteEventsInternalAsync(object values, object dtstart)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _write_events(self, values, dtstart=None):
            // """
            // Write values on events in the recurrence.
            // :param values: event values
            // :param dstart: if provided, only write events starting from this point in time
            // """
            // events = self._get_events_from(dtstart) if dtstart else self.calendar_event_ids
            // return events.with_context(no_mail_to_attendees=True, dont_notify=True).write(dict(values, recurrence_update='self_only'))
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _write_events(self, values, dtstart=None):
            // values.pop('google_id', False)
            // # Events will be updated by patch requests, do not sync events for avoiding spam.
            // values['need_sync'] = False
            // return super()._write_events(values, dtstart=dtstart)
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _write_events(self, values, dtstart=None):
            // # If only some events are updated, sync those events.
            // # If all events are updated, sync the recurrence instead.
            // values['need_sync_m'] = bool(dtstart) or values.get("need_sync_m", True)
            // return super()._write_events(values, dtstart=dtstart)
            */
            return default;
        }

        protected async Task<CalendarRecurrence> WriteFromGoogleInternalAsync(object gevent, object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _write_from_google(self, gevent, vals):
            // current_rrule = self.rrule
            // current_parsed_rrule = self._rrule_parse(current_rrule, self.dtstart)
            // # event_tz is written on event in Google but on recurrence in Odoo
            // vals['event_tz'] = gevent.start.get('timeZone')
            // super()._write_from_google(gevent, vals)
            // 
            // base_event_time_fields = ['start', 'stop', 'allday']
            // new_event_values = self.env["calendar.event"]._odoo_values(gevent)
            // new_parsed_rrule = self._rrule_parse(self.rrule, self.dtstart)
            // # We update the attendee status for all events in the recurrence
            // google_attendees = gevent.attendees or []
            // emails = [a.get('email') for a in google_attendees]
            // partners = self._get_sync_partner(emails)
            // existing_attendees = self.calendar_event_ids.attendee_ids
            // for attendee in zip(emails, partners, google_attendees):
            //     email = attendee[0]
            //     if email in existing_attendees.mapped('email'):
            //         # Update existing attendees
            //         existing_attendees.filtered(lambda att: att.email == email).write({'state': attendee[2].get('responseStatus')})
            //     else:
            //         # Create new attendees
            //         if attendee[2].get('self'):
            //             partner = self.env.user.partner_id
            //         elif attendee[1]:
            //             partner = attendee[1]
            //         else:
            //             continue
            //         self.calendar_event_ids.write({'attendee_ids': [(0, 0, {'state': attendee[2].get('responseStatus'), 'partner_id': partner.id})]})
            //         if attendee[2].get('displayName') and not partner.name:
            //             partner.name = attendee[2].get('displayName')
            // 
            // organizers_partner_ids = [event.user_id.partner_id for event in self.calendar_event_ids if event.user_id]
            // for odoo_attendee_email in set(existing_attendees.mapped('email')):
            //     # Sometimes, several partners have the same email. Remove old attendees except organizer, otherwise the events will disappear.
            //     if email_normalize(odoo_attendee_email) not in emails:
            //         attendees = existing_attendees.exists().filtered(lambda att: att.email == email_normalize(odoo_attendee_email) and att.partner_id not in organizers_partner_ids)
            //         self.calendar_event_ids.write({'need_sync': False, 'partner_ids': [Command.unlink(att.partner_id.id) for att in attendees]})
            // 
            // old_event_values = self.base_event_id and self.base_event_id.read(base_event_time_fields)[0]
            // if old_event_values and any(new_event_values.get(key) and new_event_values[key] != old_event_values[key] for key in base_event_time_fields):
            //     # we need to recreate the recurrence, time_fields were modified.
            //     base_event_id = self.base_event_id
            //     non_equal_values = [
            //         (key, old_event_values[key] and old_event_values[key].strftime('%m/%d/%Y, %H:%M:%S'), '-->',
            //               new_event_values[key] and new_event_values[key].strftime('%m/%d/%Y, %H:%M:%S')
            //          ) for key in ['start', 'stop'] if new_event_values[key] != old_event_values[key]
            //     ]
            //     log_msg = f"Recurrence {self.id} {self.rrule} has all events ({len(self.calendar_event_ids.ids)})  deleted because of base event value change: {non_equal_values}"
            //     _logger.info(log_msg)
            //     # We archive the old events to recompute the recurrence. These events are already deleted on Google side.
            //     # We can't call _cancel because events without user_id would not be deleted
            //     (self.calendar_event_ids - base_event_id).google_id = False
            //     (self.calendar_event_ids - base_event_id).unlink()
            //     base_event_id.with_context(dont_notify=True).write(dict(new_event_values, google_id=False, need_sync=False))
            //     if new_parsed_rrule == current_parsed_rrule:
            //         # if the rrule has changed, it will be recalculated below
            //         # There is no detached event now
            //         self.with_context(dont_notify=True)._apply_recurrence()
            // else:
            //     time_fields = (
            //             self.env["calendar.event"]._get_time_fields()
            //             | self.env["calendar.event"]._get_recurrent_fields()
            //     )
            //     # We avoid to write time_fields because they are not shared between events.
            //     self._write_events(dict({
            //         field: value
            //         for field, value in new_event_values.items()
            //         if field not in time_fields
            //         }, need_sync=False)
            //     )
            // 
            // # We apply the rrule check after the time_field check because the google_id are generated according
            // # to base_event start datetime.
            // if new_parsed_rrule != current_parsed_rrule:
            //     detached_events = self._apply_recurrence()
            //     detached_events.google_id = False
            //     log_msg = f"Recurrence #{self.id} | current rule: {current_rrule} | new rule: {self.rrule} | remaining: {len(self.calendar_event_ids)} | removed: {len(detached_events)}"
            //     _logger.info(log_msg)
            //     detached_events.unlink()
            */
            return default;
        }

        protected async Task<CalendarRecurrence> WriteFromMicrosoftInternalAsync(object microsoft_event, object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _write_from_microsoft(self, microsoft_event, vals):
            // current_rrule = self.rrule
            // # event_tz is written on event in Microsoft but on recurrence in Odoo
            // vals['event_tz'] = microsoft_event.start.get('timeZone')
            // super()._write_from_microsoft(microsoft_event, vals)
            // new_event_values = self.env["calendar.event"]._microsoft_to_odoo_values(microsoft_event)
            // # Edge case:  if the base event was deleted manually in 'self_only' update, skip applying recurrence.
            // if self._has_base_event_time_fields_changed(new_event_values) and (new_event_values['start'] >= self.base_event_id.start):
            //     # we need to recreate the recurrence, time_fields were modified.
            //     base_event_id = self.base_event_id
            //     # We archive the old events to recompute the recurrence. These events are already deleted on Microsoft side.
            //     # We can't call _cancel because events without user_id would not be deleted
            //     (self.calendar_event_ids - base_event_id).microsoft_id = False
            //     (self.calendar_event_ids - base_event_id).ms_universal_event_id = False
            //     (self.calendar_event_ids - base_event_id).unlink()
            //     base_event_id.with_context(dont_notify=True).write(dict(
            //         new_event_values, microsoft_id=False, ms_universal_event_id=False, need_sync_m=False
            //     ))
            //     if self.rrule == current_rrule:
            //         # if the rrule has changed, it will be recalculated below
            //         # There is no detached event now
            //         self.with_context(dont_notify=True)._apply_recurrence()
            // else:
            //     time_fields = (
            //             self.env["calendar.event"]._get_time_fields()
            //             | self.env["calendar.event"]._get_recurrent_fields()
            //     )
            //     # We avoid to write time_fields because they are not shared between events.
            //     self.with_context(dont_notify=True)._write_events(dict({
            //         field: value
            //         for field, value in new_event_values.items()
            //         if field not in time_fields
            //         }, need_sync_m=False)
            //     )
            // # We apply the rrule check after the time_field check because the microsoft ids are generated according
            // # to base_event start datetime.
            // if self.rrule != current_rrule:
            //     detached_events = self._apply_recurrence()
            //     detached_events.ms_universal_event_id = False
            //     detached_events.unlink()
            */
            return default;
        }
    }
}