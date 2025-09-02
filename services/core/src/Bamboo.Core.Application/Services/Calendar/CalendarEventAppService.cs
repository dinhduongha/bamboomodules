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
    public class CalendarEventAppService : GenericApplicationService<CalendarEvent>, ICalendarEventAppService
    {
        private readonly IGoogleCalendarSyncAppService _googleCalendarSyncAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IMicrosoftCalendarSyncAppService _microsoftCalendarSyncAppService;
        public CalendarEventAppService(IRepository<CalendarEvent, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IGoogleCalendarSyncAppService googleCalendarSyncAppService, IMailThreadAppService mailThreadAppService, IMicrosoftCalendarSyncAppService microsoftCalendarSyncAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _googleCalendarSyncAppService = googleCalendarSyncAppService;
            _mailThreadAppService = mailThreadAppService;
            _microsoftCalendarSyncAppService = microsoftCalendarSyncAppService;
        }

        protected async Task<CalendarEvent> ApplyRecurrenceValuesInternalAsync(object values, object future)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _apply_recurrence_values(self, values, future=True):
            // """Apply the new recurrence rules in `values`. Create a recurrence if it does not exist
            // and create all missing events according to the rrule.
            // If the changes are applied to future
            // events only, a new recurrence is created with the updated rrule.
            // 
            // :param values: new recurrence values to apply
            // :param future: rrule values are applied to future events only if True.
            //                Rrule changes are applied to all events in the recurrence otherwise.
            //                (ignored if no recurrence exists yet).
            // :return: events detached from the recurrence
            // """
            // if not values:
            //     return self.browse()
            // recurrence_vals = []
            // to_update = self.env['calendar.recurrence']
            // for event in self:
            //     if not event.recurrence_id:
            //         recurrence_vals += [dict(values, base_event_id=event.id, calendar_event_ids=[(4, event.id)])]
            //     elif future:
            //         to_update |= event.recurrence_id._split_from(event, values)
            // self.write({'recurrency': True, 'follow_recurrence': True})
            // to_update |= self.env['calendar.recurrence'].create(recurrence_vals)
            // return to_update._apply_recurrence()
            */
            return default;
        }

        protected async Task<CalendarEvent> AttendeesValuesInternalAsync(object partner_commands)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _attendees_values(self, partner_commands):
            // """
            // :param partner_commands: ORM commands for partner_id field (0 and 1 commands not supported)
            // :return: associated attendee_ids ORM commands
            // """
            // attendee_commands = []
            // 
            // removed_partner_ids = []
            // added_partner_ids = []
            // 
            // # if commands are just integers, assume they are ids with the intent to `Command.set`
            // if partner_commands and isinstance(partner_commands[0], int):
            //     partner_commands = [Command.set(partner_commands)]
            // 
            // for command in partner_commands:
            //     op = command[0]
            //     if op in (2, 3, Command.delete, Command.unlink):  # Remove partner
            //         removed_partner_ids += [command[1]]
            //     elif op in (6, Command.set):  # Replace all
            //         removed_partner_ids += set(self.partner_ids.ids) - set(command[2])  # Don't recreate attendee if partner already attend the event
            //         added_partner_ids += set(command[2]) - set(self.partner_ids.ids)
            //     elif op in (4, Command.link):
            //         added_partner_ids += [command[1]] if command[1] not in self.partner_ids.ids else []
            //     # commands 0 and 1 not supported
            // 
            // if not self:
            //     attendees_to_unlink = self.env['calendar.attendee']
            // else:
            //     attendees_to_unlink = self.env['calendar.attendee'].search([
            //         ('event_id', 'in', self.ids),
            //         ('partner_id', 'in', removed_partner_ids),
            //     ])
            // attendee_commands += [[2, attendee.id] for attendee in attendees_to_unlink]  # Removes and delete
            // 
            // attendee_commands += [
            //     [0, 0, dict(partner_id=partner_id)]
            //     for partner_id in added_partner_ids
            // ]
            // return attendee_commands
            */
            return default;
        }

        protected async Task<CalendarEvent> BreakRecurrenceInternalAsync(object future)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _break_recurrence(self, future=True):
            // """Breaks the event's recurrence.
            // Stop the recurrence at the current event if `future` is True, leaving past events in the recurrence.
            // If `future` is False, all events in the recurrence are detached and the recurrence itself is unlinked.
            // :return: detached events excluding the current events
            // """
            // recurrences_to_unlink = self.env['calendar.recurrence']
            // detached_events = self.env['calendar.event']
            // for event in self:
            //     recurrence = event.recurrence_id
            //     if future:
            //         detached_events |= recurrence._stop_at(event)
            //     else:
            //         detached_events |= recurrence.calendar_event_ids
            //         recurrence.calendar_event_ids.recurrence_id = False
            //         recurrences_to_unlink |= recurrence
            // recurrences_to_unlink.with_context(archive_on_error=True).unlink()
            // return detached_events - self
            */
            return default;
        }

        protected async Task<CalendarEvent> CancelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def _cancel(self):
            // # only owner can delete => others refuse the event
            // user = self.env.user
            // my_cancelled_records = self.filtered(lambda e: e.user_id == user)
            // for event in self:
            //     # remove the tracking data to avoid calling _track_template in the pre-commit phase
            //     self.env.cr.precommit.data.pop(f'mail.tracking.create.{event._name}.{event.id}', None)
            // super(Meeting, my_cancelled_records)._cancel()
            // attendees = (self - my_cancelled_records).attendee_ids.filtered(lambda a: a.partner_id == user.partner_id)
            // attendees.state = 'declined'
            */
            return default;
        }

        protected async Task<CalendarEvent> CancelMicrosoftInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _cancel_microsoft(self):
            // """
            // Cancel an Microsoft event.
            // There are 2 cases:
            //   1) the organizer is an Odoo user: he's the only one able to delete the Odoo event. Attendees can just decline.
            //   2) the organizer is NOT an Odoo user: any attendee should remove the Odoo event.
            // """
            // user = self.env.user
            // records = self.filtered(lambda e: not e.user_id or e.user_id == user or user.partner_id in e.partner_ids)
            // for event in records:
            //     # remove the tracking data to avoid calling _track_template in the pre-commit phase
            //     self.env.cr.precommit.data.pop(f'mail.tracking.create.{event._name}.{event.id}', None)
            // super(Meeting, records)._cancel_microsoft()
            // attendees = (self - records).attendee_ids.filtered(lambda a: a.partner_id == user.partner_id)
            // attendees.do_decline()
            */
            return default;
        }

        public async Task<CalendarEvent> ChangeAttendeeStatusAsync(Guid id, CalendarEventChangeAttendeeStatusRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def change_attendee_status(self, status, recurrence_update_setting):
            // self.ensure_one()
            // if recurrence_update_setting == 'all_events':
            //     events = self.recurrence_id.calendar_event_ids
            // elif recurrence_update_setting == 'future_events':
            //     events = self.recurrence_id.calendar_event_ids.filtered(lambda ev: ev.start >= self.start)
            // else:
            //     events = self
            // attendee = events.attendee_ids.filtered(lambda x: x.partner_id == self.env.user.partner_id)
            // if status == 'accepted':
            //     return attendee.do_accept()
            // if status == 'declined':
            //     return attendee.do_decline()
            // return attendee.do_tentative()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CalendarEvent> CheckCalendarPrivacyWritePermissionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _check_calendar_privacy_write_permissions(self):
            // """
            // Checks if current user can write on the events, raising UserError when the event is private.
            // We need to manually call the default Access Error because we can't add an access rule for checking
            // the calendar defaut privacy of an user from a 'calendar.event' record, since it is a res.users field.
            // Otherwise we would have to create a new computed field on that model, which we don't want.
            // """
            // if not self.env.su:
            //     for event in self:
            //         if event._check_private_event_conditions():
            //             raise self.env['ir.rule']._make_access_error("write", event)
            */
            return default;
        }

        protected async Task<CalendarEvent> CheckClosingDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _check_closing_date(self):
            // for meeting in self:
            //     if not meeting.allday and meeting.start and meeting.stop and meeting.stop < meeting.start:
            //         raise ValidationError(
            //             _(
            //                 "The ending date and time cannot be earlier than the starting date and time.\n"
            //                 "Meeting “%(name)s” starts at %(start_time)s and ends at %(end_time)s",
            //                 name=meeting.name,
            //                 start_time=meeting.start,
            //                 end_time=meeting.stop,
            //             ),
            //         )
            //     if meeting.allday and meeting.start_date and meeting.stop_date and meeting.stop_date < meeting.start_date:
            //         raise ValidationError(
            //             _(
            //                 "The ending date cannot be earlier than the starting date.\n"
            //                 "Meeting “%(name)s” starts on %(start_date)s and ends on %(end_date)s",
            //                 name=meeting.name,
            //                 start_date=meeting.start_date,
            //                 end_date=meeting.stop_date,
            //             ),
            //         )
            */
            return default;
        }

        protected async Task<CalendarEvent> CheckEmployeesAvailabilityForEventInternalAsync(object schedule_by_partner, object event_interval)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_calendar, FILE: calendar_event.py) ---
            // def _check_employees_availability_for_event(self, schedule_by_partner, event_interval):
            // unavailable_partners = []
            // for partner, schedule in schedule_by_partner.items():
            //     common_interval = schedule & event_interval
            //     if sum_intervals(common_interval) != sum_intervals(event_interval):
            //         unavailable_partners.append(partner.id)
            // return unavailable_partners
            */
            return default;
        }

        protected async Task<CalendarEvent> CheckMicrosoftSyncStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _check_microsoft_sync_status(self):
            // """
            // Returns True if synchronization with Outlook Calendar is active and False otherwise.
            // The 'microsoft_synchronization_stopped' variable needs to be 'False' and Outlook account must be connected.
            // """
            // outlook_connected = self.env.user._get_microsoft_calendar_token()
            // return outlook_connected and self.env.user.sudo().microsoft_synchronization_stopped is False
            */
            return default;
        }

        protected async Task<CalendarEvent> CheckModifyEventPermissionInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def _check_modify_event_permission(self, values):
            // # Check if event modification attempt by attendee is valid to avoid duplicate events creation.
            // for event in self:
            //     # Edge case: when restarting the synchronization, guests can write 'need_sync=True' on events.
            //     google_sync_restart = values.get('need_sync') and len(values)
            //     if not google_sync_restart and (event.guests_readonly and self.env.user.id != event.user_id.id):
            //         raise ValidationError(_("The following event can only be updated by the organizer "
            //                                 "according to the event permissions set on Google Calendar."))
            */
            return default;
        }

        protected async Task<CalendarEvent> CheckOrganizerValidationConditionsInternalAsync(object vals_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _check_organizer_validation_conditions(self, vals_list):
            // """ Method for check in the microsoft_calendar module that needs to be
            //     overridden in appointment.
            // """
            // return [True] * len(vals_list)
            */
            return default;
        }

        protected async Task<CalendarEvent> CheckOrganizerValidationInternalAsync(object sender_user, object partner_included)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _check_organizer_validation(self, sender_user, partner_included):
            // """ Check if the proposed event organizer can be set accordingly. """
            // # Edge case: events created or updated from Microsoft should not check organizer validation.
            // change_from_microsoft = self.env.context.get('dont_notify', False)
            // if sender_user and sender_user != self.env.user and not change_from_microsoft:
            //     current_sync_status = self._check_microsoft_sync_status()
            //     sender_sync_status = self.with_user(sender_user)._check_microsoft_sync_status()
            //     if not sender_sync_status and current_sync_status:
            //         raise ValidationError(
            //             _("For having a different organizer in your event, it is necessary that "
            //               "the organizer have its Odoo Calendar synced with Outlook Calendar."))
            //     elif sender_sync_status and not partner_included:
            //         raise ValidationError(
            //             _("It is necessary adding the proposed organizer as attendee before saving the event."))
            */
            return default;
        }

        protected async Task<CalendarEvent> CheckPrivateEventConditionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _check_private_event_conditions(self):
            // """ Checks if the event is private, returning True if the conditions match and False otherwise. """
            // self.ensure_one()
            // event_is_private = self.privacy == 'private'
            // calendar_is_private = not self.privacy and self.sudo().user_id.calendar_default_privacy == 'private'
            // user_is_not_partner = self.user_id.id != self.env.uid and self.env.user.partner_id not in self.partner_ids
            // return (event_is_private or calendar_is_private) and user_is_not_partner
            */
            return default;
        }

        protected async Task<CalendarEvent> CheckRecurrenceOverlappingInternalAsync(object new_start)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _check_recurrence_overlapping(self, new_start):
            // """
            // Outlook does not allow to modify time fields of an event if this event crosses
            // or overlaps the recurrence. In this case a 400 error with the Outlook code "ErrorOccurrenceCrossingBoundary"
            // is returned. That means that the update violates the following Outlook restriction on recurrence exceptions:
            // an occurrence cannot be moved to or before the day of the previous occurrence, and cannot be moved to or after
            // the day of the following occurrence.
            // For example: E1 E2 E3 E4 cannot becomes E1 E3 E2 E4
            // """
            // before_count = len(self.recurrence_id.calendar_event_ids.filtered(
            //     lambda e: e.start.date() < self.start.date() and e != self
            // ))
            // after_count = len(self.recurrence_id.calendar_event_ids.filtered(
            //     lambda e: e.start.date() < parse(new_start).date() and e != self
            // ))
            // if before_count != after_count:
            //     raise UserError(_(
            //         "Outlook limitation: in a recurrence, an event cannot be moved to or before the day of the "
            //         "previous event, and cannot be moved to or after the day of the following event."
            //     ))
            */
            return default;
        }

        protected async Task<CalendarEvent> CheckValuesToSyncInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _check_values_to_sync(self, values):
            // """ Method to be overriden: return candidate values to be synced within rewrite_recurrence function scope. """
            // return False
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def _check_values_to_sync(self, values):
            // """ Return True if values being updated intersects with Google synced values and False otherwise. """
            // synced_fields = self._get_google_synced_fields()
            // values_to_sync = any(key in synced_fields for key in values)
            // return values_to_sync
            */
            return default;
        }

        public async Task<CalendarEvent> ClearVideocallLocationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def clear_videocall_location(self):
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CalendarEvent> ComputeAttendeesCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_attendees_count(self):
            // for event in self:
            //     count_event = {}
            //     for attendee in event.attendee_ids:
            //         count_event[attendee.state] = count_event.get(attendee.state, 0) + 1
            // 
            //     accepted_count = count_event.get('accepted', 0)
            //     declined_count = count_event.get('declined', 0)
            //     tentative_count = count_event.get('tentative', 0)
            //     attendees_count = len(event.partner_ids)
            //     event.update({
            //         'accepted_count': accepted_count,
            //         'declined_count': declined_count,
            //         'tentative_count': tentative_count,
            //         'attendees_count': attendees_count,
            //         'awaiting_count': attendees_count - accepted_count - declined_count - tentative_count
            //     })
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeCandidateIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: calendar.py) ---
            // def _compute_candidate_id(self):
            // for event in self:
            //     if not event.applicant_id:
            //         continue
            //     event.candidate_id = event.applicant_id.candidate_id
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeCurrentAttendeeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_current_attendee(self):
            // for event in self:
            //     current_attendee = event.attendee_ids.filtered(lambda attendee: attendee.partner_id == self.env.user.partner_id)
            //     event.current_attendee = current_attendee and current_attendee[0]
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeDatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_dates(self):
            // """ Adapt the value of start_date(time)/stop_date(time)
            //     according to start/stop fields and allday. Also, compute
            //     the duration for not allday meeting ; otherwise the
            //     duration is set to zero, since the meeting last all the day.
            // """
            // for meeting in self:
            //     if meeting.allday and meeting.start and meeting.stop:
            //         meeting.start_date = meeting.start.date()
            //         meeting.stop_date = meeting.stop.date()
            //     else:
            //         meeting.start_date = False
            //         meeting.stop_date = False
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeDisplayDescriptionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_display_description(self):
            // for event in self:
            //     event.display_description = not is_html_empty(event.description)
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_display_name(self):
            // """ Hide private events' name for events which don't belong to the current user. """
            // hidden = self.filtered(lambda event: event._check_private_event_conditions())
            // hidden.display_name = _('Busy')
            // super(Meeting, self - hidden)._compute_display_name()
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeDisplayTimeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_display_time(self):
            // for meeting in self:
            //     meeting.display_time = self._get_display_time(meeting.start, meeting.stop, meeting.duration, meeting.allday)
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeDurationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_duration(self):
            // for event in self:
            //     event.duration = self._get_duration(event.start, event.stop)
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeFieldValueInternalAsync(object field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_field_value(self, field):
            // if field.compute_sudo:
            //     return super(Meeting, self.with_context(prefetch_fields=False))._compute_field_value(field)
            // return super()._compute_field_value(field)
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeGoogleIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def _compute_google_id(self):
            // # google ids of recurring events are built from the recurrence id and the
            // # original starting time in the recurrence.
            // # The `start` field does not appear in the dependencies on purpose!
            // # Event if the event is moved, the google_id remains the same.
            // for event in self:
            //     google_recurrence_id = event.recurrence_id._get_event_google_id(event)
            //     if not event.google_id and google_recurrence_id:
            //         event.google_id = google_recurrence_id
            //     elif not event.google_id:
            //         event.google_id = False
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeInvalidEmailPartnerIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_invalid_email_partner_ids(self):
            // for event in self:
            //     event.invalid_email_partner_ids = event.partner_ids.filtered(
            //         lambda a: not (a.email and single_email_re.match(a.email))
            //     )
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeIsHighlightedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_is_highlighted(self):
            // if self.env.context.get('active_model') == 'res.partner':
            //     partner_id = self.env.context.get('active_id')
            //     for event in self:
            //         if event.partner_ids.filtered(lambda s: s.id == partner_id):
            //             event.is_highlighted = True
            //         else:
            //             event.is_highlighted = False
            // else:
            //     for event in self:
            //         event.is_highlighted = False
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: calendar.py) ---
            // def _compute_is_highlighted(self):
            // super(CalendarEvent, self)._compute_is_highlighted()
            // if self.env.context.get('active_model') == 'crm.lead':
            //     opportunity_id = self.env.context.get('active_id')
            //     for event in self:
            //         if event.opportunity_id.id == opportunity_id:
            //             event.is_highlighted = True
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: calendar.py) ---
            // def _compute_is_highlighted(self):
            // super()._compute_is_highlighted()
            // applicant_id = self.env.context.get('active_id')
            // if self.env.context.get('active_model') == 'hr.applicant' and applicant_id:
            //     for event in self:
            //         if event.applicant_id.id == applicant_id:
            //             event.is_highlighted = True
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeIsOrganizerAloneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_is_organizer_alone(self):
            // """
            //     Check if the organizer of the event is the only one who has accepted the event.
            //     It does not apply if the organizer is the only attendee of the event because it
            //     would represent a personnal event.
            //     The goal of this field is to highlight to the user that the others attendees are
            //     not available for this event.
            // """
            // for event in self:
            //     organizer = event.attendee_ids.filtered(lambda a: a.partner_id == event.partner_id)
            //     all_declined = not any((event.attendee_ids - organizer).filtered(lambda a: a.state != 'declined'))
            //     event.is_organizer_alone = len(event.attendee_ids) > 1 and all_declined
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeRecurrenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_recurrence(self):
            // recurrence_fields = self._get_recurrent_fields()
            // false_values = {field: False for field in recurrence_fields}  # computes need to set a value
            // defaults = self.env['calendar.recurrence'].default_get(recurrence_fields)
            // default_rrule_values = self.recurrence_id.default_get(recurrence_fields)
            // for event in self:
            //     if event.recurrency:
            //         current_rrule = (event.rrule_type if event.rrule_type_ui == "custom" else event.rrule_type_ui)
            //         event.update(defaults)  # default recurrence values are needed to correctly compute the recurrence params
            //         event_values = event._get_recurrence_params()
            //         rrule_values = {
            //             field: event.recurrence_id[field]
            //             for field in recurrence_fields
            //             if event.recurrence_id[field]
            //         }
            //         rrule_values = rrule_values or default_rrule_values
            //         rrule_values['rrule_type'] = current_rrule or rrule_values.get('rrule_type') or defaults['rrule_type']
            //         event.update({**false_values, **defaults, **event_values, **rrule_values})
            //     else:
            //         event.update(false_values)
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeRruleTypeUiInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_rrule_type_ui(self):
            // defaults = self.env["calendar.recurrence"].default_get(["interval", "rrule_type"])
            // for event in self:
            //     if event.recurrency:
            //         if event.recurrence_id:
            //             event.rrule_type_ui = 'custom' if event.recurrence_id.interval != 1 else (event.recurrence_id.rrule_type)
            //         else:
            //             event.rrule_type_ui = defaults["rrule_type"]
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeShouldShowStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_should_show_status(self):
            // for event in self:
            //     event.should_show_status = event.current_attendee and any(attendee.partner_id != self.env.user.partner_id for attendee in event.attendee_ids)
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeStopInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_stop(self):
            // # stop and duration fields both depends on the start field.
            // # But they also depends on each other.
            // # When start is updated, we want to update the stop datetime based on
            // # the *current* duration. In other words, we want: change start => keep the duration fixed and
            // # recompute stop accordingly.
            // # However, while computing stop, duration is marked to be recomputed. Calling `event.duration` would trigger
            // # its recomputation. To avoid this we manually mark the field as computed.
            // duration_field = self._fields['duration']
            // self.env.remove_to_compute(duration_field, self)
            // for event in self:
            //     # Round the duration (in hours) to the minute to avoid weird situations where the event
            //     # stops at 4:19:59, later displayed as 4:19.
            //     event.stop = event.start and event.start + timedelta(minutes=round((event.duration or 1.0) * 60))
            //     if event.allday:
            //         event.stop -= timedelta(seconds=1)
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeUnavailablePartnerIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_calendar, FILE: calendar_event.py) ---
            // def _compute_unavailable_partner_ids(self):
            // complete_events = self.filtered(
            //     lambda event: event.start and event.stop and (event.stop > event.start or (event.stop >= event.start and event.allday)) and event.partner_ids)
            // incomplete_event = self - complete_events
            // incomplete_event.unavailable_partner_ids = []
            // if not complete_events:
            //     return
            // event_intervals = complete_events._get_events_interval()
            // for event, event_interval in event_intervals.items():
            //     # Event_interval is empty when an allday event contains at least one day where the company is closed
            //     if not event_interval:
            //         event.unavailable_partner_ids = event.partner_ids
            //         continue
            //     start = event_interval._items[0][0]
            //     stop = event_interval._items[-1][1]
            //     schedule_by_partner = event.partner_ids._get_schedule(start, stop, merge=False)
            //     event.unavailable_partner_ids = event._check_employees_availability_for_event(
            //         schedule_by_partner, event_interval)
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeUserCanEditInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_user_can_edit(self):
            // for event in self:
            //     # By default, only current attendees and the organizer can edit the event.
            //     editor_candidates = set(event.partner_ids.user_ids + event.user_id)
            //     # Right before saving the event, old partners must be able to save changes.
            //     if event._origin:
            //         editor_candidates |= set(event._origin.partner_ids.user_ids)
            //     # Non-private events must be editable by uninvited administrators.
            //     if self.env.user.has_group('base.group_system') and event.privacy != 'private':
            //         editor_candidates.add(self.env.user)
            //     event.user_can_edit = self.env.user in editor_candidates
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeVideocallLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_videocall_location(self):
            // for event in self:
            //     if event.videocall_source == 'discuss':
            //         event._set_discuss_videocall_location()
            */
            return default;
        }

        protected async Task<CalendarEvent> ComputeVideocallSourceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_videocall_source(self):
            // for event in self:
            //     if event.videocall_location and self.DISCUSS_ROUTE in event.videocall_location:
            //         event.videocall_source = 'discuss'
            //     else:
            //         event.videocall_source = 'custom'
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def _compute_videocall_source(self):
            // events_with_google_url = self.filtered(lambda event: self.MEET_ROUTE in (event.videocall_location or ''))
            // events_with_google_url.videocall_source = 'google_meet'
            // super(Meeting, self - events_with_google_url)._compute_videocall_source()
            */
            return default;
        }

        public override async Task<CalendarEvent> CreateAsync(CalendarEvent entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def create(self, vals_list):
            // # Prevent sending update notification when _inverse_dates is called
            // self = self.with_context(is_calendar_event_new=True)
            // defaults = self.default_get([
            //     'activity_ids', 'allday', 'description', 'name', 'partner_ids',
            //     'res_model_id', 'res_id', 'start', 'user_id',
            // ])
            // 
            // vals_list = [  # Else bug with quick_create when we are filter on an other user
            //     {
            //         **vals,
            //         'activity_ids': vals.get('activity_ids', defaults.get('activity_ids')),
            //         'allday': vals.get('allday', defaults.get('allday')),
            //         'description': vals.get('description', defaults.get('description')),
            //         'name': vals.get('name', defaults.get('name')),
            //         'res_id': vals.get('res_id', defaults.get('res_id')),
            //         'res_model': vals.get('res_model', defaults.get('res_model')),
            //         'res_model_id': vals.get('res_model_id', defaults.get('res_model_id')),
            //         'start': vals.get('start', defaults.get('start')),
            //         'user_id': vals.get('user_id', defaults.get('user_id', self.env.user.id)),
            //      } for vals in vals_list
            // ]
            // meeting_activity_types = self.env['mail.activity.type'].search([('category', '=', 'meeting')])
            // # get list of models ids and filter out None values directly
            // model_ids = list(filter(None, {values['res_model_id'] for values in vals_list}))
            // all_models = self.env['ir.model'].sudo().browse(model_ids)
            // # TDE FIXME: clean that method, be more values-based
            // excluded_models = self._get_activity_excluded_models()
            // 
            // # if user is creating an event for an activity that already has one, create a second activity
            // existing_event, existing_type = self.browse(), self.env['mail.activity.type']
            // orig_activity_ids = self.env['mail.activity'].browse(self._context.get('orig_activity_ids', []))
            // if len(orig_activity_ids) == 1:
            //     existing_event = orig_activity_ids.calendar_event_id
            //     if existing_event and orig_activity_ids.activity_type_id.category == 'meeting':
            //         existing_type = orig_activity_ids.activity_type_id
            // 
            // if meeting_activity_types:
            //     for values in vals_list:
            //         # created from calendar: try to create an activity on the related record
            //         if values['activity_ids'] and not existing_event:
            //             continue
            //         res_model = all_models.filtered(lambda m: m.id == values['res_model_id'])
            //         res_id = values['res_id']
            //         if not res_model or not res_id or res_model.model in excluded_models or not res_model.is_mail_activity:
            //             continue
            // 
            //         meeting_activity_type = self.env['mail.activity.type']
            //         if existing_type and existing_type.res_model in {False, res_model.model}:
            //             meeting_activity_type = existing_type
            //         if not meeting_activity_type:
            //             meeting_activity_type = meeting_activity_types.filtered(
            //                 lambda act: act.res_model in {False, res_model.model}
            //             )
            //         if not meeting_activity_type:
            //             continue
            // 
            //         activity_vals = {
            //             'res_model_id': values['res_model_id'],
            //             'res_id': res_id,
            //             'activity_type_id': meeting_activity_type[0].id,
            //         }
            //         if values['description']:
            //             activity_vals['note'] = values['description']
            //         if values['name']:
            //             activity_vals['summary'] = values['name']
            //         if values['start']:
            //             activity_vals['date_deadline'] = self._get_activity_deadline_from_start(fields.Datetime.from_string(values['start']), values['allday'])
            //         if values['user_id']:
            //             activity_vals['user_id'] = values['user_id']
            //         values['activity_ids'] = [(0, 0, activity_vals)]
            // 
            // self._set_videocall_location(vals_list)
            // 
            // # Add commands to create attendees from partners (if present) if no attendee command
            // # is already given (coming from Google event for example).
            // # Automatically add the current partner when creating an event if there is none (happens when we quickcreate an event)
            // default_partners_ids = defaults.get('partner_ids') or ([(4, self.env.user.partner_id.id)])
            // vals_list = [
            //     dict(vals, attendee_ids=self._attendees_values(vals.get('partner_ids', default_partners_ids)))
            //     if not vals.get('attendee_ids')
            //     else vals
            //     for vals in vals_list
            // ]
            // recurrence_fields = self._get_recurrent_fields()
            // recurring_vals = [vals for vals in vals_list if vals.get('recurrency')]
            // other_vals = [vals for vals in vals_list if not vals.get('recurrency')]
            // events = super().create(other_vals)
            // 
            // for vals in recurring_vals:
            //     vals['follow_recurrence'] = True
            // recurring_events = super().create(recurring_vals)
            // events += recurring_events
            // 
            // for event, vals in zip(recurring_events, recurring_vals):
            //     recurrence_values = {field: vals.pop(field) for field in recurrence_fields if field in vals}
            //     if vals.get('recurrency'):
            //         detached_events = event._apply_recurrence_values(recurrence_values)
            //         detached_events.active = False
            // 
            // events.filtered(lambda event: event.start > fields.Datetime.now()).attendee_ids._send_invitation_emails()
            // 
            // # update activities based on calendar event data, unless already prepared
            // # above manually. Heuristic: a new command (0, 0, vals) is considered as
            // # complete
            // to_sync_activities = self.browse()
            // for event, event_values in zip(events, vals_list):
            //     if any(command[0] != 0 for command in event_values.get('activity_ids') or []):
            //         to_sync_activities += event
            // to_sync_activities._sync_activities(fields={f for vals in vals_list for f in vals})
            // 
            // if not self.env.context.get('dont_notify'):
            //     alarm_events = self.env['calendar.event']
            //     for event, values in zip(events, vals_list):
            //         if values.get('allday'):
            //             # All day events will trigger the _inverse_date method which will create the trigger.
            //             continue
            //         alarm_events |= event
            //     recurring_events = alarm_events.filtered('recurrence_id')
            //     recurring_events.recurrence_id._setup_alarms()
            //     (alarm_events - recurring_events)._setup_alarms()
            // return events.with_context(is_calendar_event_new=False)
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: calendar.py) ---
            // def create(self, vals):
            // events = super(CalendarEvent, self).create(vals)
            // for event in events:
            //     if event.opportunity_id and not event.activity_ids:
            //         event.opportunity_id.log_meeting(event)
            // return events
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def create(self, vals_list):
            // notify_context = self.env.context.get('dont_notify', False)
            // return super(Meeting, self.with_context(dont_notify=notify_context)).create([
            //     dict(vals, need_sync=False) if vals.get('recurrence_id') or vals.get('recurrency') else vals
            //     for vals in vals_list
            // ])
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: calendar.py) ---
            // def create(self, vals_list):
            // events = super().create(vals_list)
            // if not self.env['hr.applicant'].has_access('read'):
            //     return events
            // 
            // attachments = False
            // if "default_applicant_id" in self.env.context:
            //     attachments = self.env['hr.applicant'].browse(self.env.context['default_applicant_id']).attachment_ids
            // elif "default_candidate_id" in self.env.context:
            //     attachments = self.env['hr.candidate'].browse(self.env.context['default_candidate_id']).attachment_ids
            // if attachments:
            //     self.env['ir.attachment'].create([{
            //         'name': att.name,
            //         'type': 'binary',
            //         'datas': att.datas,
            //         'res_model': event._name,
            //         'res_id': event.id
            //     } for event in events for att in attachments])
            // return events
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def create(self, vals_list):
            // notify_context = self.env.context.get('dont_notify', False)
            // 
            // # Forbid recurrence creation in Odoo, suggest its creation in Outlook due to the spam limitation.
            // recurrency_in_batch = any(vals.get('recurrency') for vals in vals_list)
            // if self._check_microsoft_sync_status() and not notify_context and recurrency_in_batch:
            //     self._forbid_recurrence_creation()
            // 
            // vals_check_organizer = self._check_organizer_validation_conditions(vals_list)
            // for vals in [vals for vals, check_organizer in zip(vals_list, vals_check_organizer) if check_organizer]:
            //     # If event has a different organizer, check its sync status and verify if the user is listed as attendee.
            //     sender_user, partner_ids = self._get_organizer_user_change_info(vals)
            //     partner_included = partner_ids and len(partner_ids) > 0 and sender_user.partner_id.id in partner_ids
            //     self._check_organizer_validation(sender_user, partner_included)
            // 
            // # for a recurrent event, we do not create events separately but we directly
            // # create the recurrency from the corresponding calendar.recurrence.
            // # That's why, events from a recurrency have their `need_sync_m` attribute set to False.
            // return super(Meeting, self.with_context(dont_notify=notify_context)).create([
            //     dict(vals, need_sync_m=False) if vals.get('recurrence_id') or vals.get('recurrency') else vals
            //     for vals in vals_list
            // ])
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<CalendarEvent> CreateVideocallChannelIdInternalAsync(object name, List<Guid> partner_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _create_videocall_channel_id(self, name, partner_ids):
            // videocall_channel = self.env['discuss.channel'].create_group(partner_ids, default_display_mode='video_full_screen', name=name)
            // # if recurrent event, set channel to all other records of the same recurrency
            // if self.recurrency:
            //     recurrent_events_without_channel = self.env['calendar.event'].search([
            //         ('recurrence_id', '=', self.recurrence_id.id), ('videocall_channel_id', '=', False)
            //     ])
            //     recurrent_events_without_channel.videocall_channel_id = videocall_channel
            // return videocall_channel
            */
            return default;
        }

        protected async Task<CalendarEvent> CreateVideocallChannelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _create_videocall_channel(self):
            // if self.recurrency:
            //     # check if any of the events have videocall_channel_id, if not create one
            //     event_with_channel = self.env['calendar.event'].search([
            //         ('recurrence_id', '=', self.recurrence_id.id),
            //         ('videocall_channel_id', '!=', False)
            //     ], limit=1)
            //     if event_with_channel:
            //         self.videocall_channel_id = event_with_channel.videocall_channel_id
            //         return
            // self.videocall_channel_id = self._create_videocall_channel_id(self.name, self.partner_ids.ids)
            // self.videocall_channel_id.channel_change_description(self.recurrence_id.name if self.recurrency else self.display_time)
            */
            return default;
        }

        public override async Task<CalendarEvent> DefaultGetAsync(List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def default_get(self, fields):
            // # super default_model='crm.lead' for easier use in addons
            // if self.env.context.get('default_res_model') and not self.env.context.get('default_res_model_id'):
            //     self = self.with_context(
            //         default_res_model_id=self.env['ir.model']._get_id(self.env.context['default_res_model'])
            //     )
            // 
            // defaults = super(Meeting, self).default_get(fields)
            // 
            // # support active_model / active_id as replacement of default_* if not already given
            // if 'res_model_id' not in defaults and 'res_model_id' in fields and \
            //         self.env.context.get('active_model') and self.env.context['active_model'] != 'calendar.event':
            //     defaults['res_model_id'] = self.env['ir.model']._get_id(self.env.context['active_model'])
            //     defaults['res_model'] = self.env.context.get('active_model')
            // if 'res_id' not in defaults and 'res_id' in fields and \
            //         defaults.get('res_model_id') and self.env.context.get('active_id'):
            //     defaults['res_id'] = self.env.context['active_id']
            // 
            // return defaults
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: calendar.py) ---
            // def default_get(self, fields):
            // if self.env.context.get('default_opportunity_id'):
            //     self = self.with_context(
            //         default_res_model_id=self.env.ref('crm.model_crm_lead').id,
            //         default_res_id=self.env.context['default_opportunity_id']
            //     )
            // defaults = super(CalendarEvent, self).default_get(fields)
            // 
            // # sync res_model / res_id to opportunity id (aka creating meeting from lead chatter)
            // if 'opportunity_id' not in defaults:
            //     if self._is_crm_lead(defaults, self.env.context):
            //         defaults['opportunity_id'] = defaults.get('res_id', False) or self.env.context.get('default_res_id', False)
            // 
            // return defaults
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: calendar.py) ---
            // def default_get(self, fields):
            // self_ctx = self
            // if self.env.context.get('default_applicant_id'):
            //     self_ctx = self.with_context(
            //         default_res_model='hr.applicant',  # res_model seems to be lost without this
            //         default_res_model_id=self.env.ref('hr_recruitment.model_hr_applicant').id,
            //         default_res_id=self.env.context.get('default_applicant_id'),
            //         default_partner_ids=self.env.context.get('default_partner_ids'),
            //         default_name=self.env.context.get('default_name')
            //     )
            // elif self.env.context.get('default_candidate_id'):
            //     self_ctx = self.with_context(
            //         default_res_model='hr.candidate',  # res_model seems to be lost without this
            //         default_res_model_id=self.env.ref('hr_recruitment.model_hr_candidate').id,
            //         default_res_id=self.env.context.get('default_candidate_id'),
            //         default_partner_ids=self.env.context.get('default_partner_ids'),
            //         default_name=self.env.context.get('default_name')
            //     )
            // 
            // defaults = super(CalendarEvent, self_ctx).default_get(fields)
            // 
            // # sync res_model / res_id to opportunity id (aka creating meeting from lead chatter)
            // if 'applicant_id' not in defaults:
            //     res_model = defaults.get('res_model', False) or self_ctx.env.context.get('default_res_model')
            //     res_model_id = defaults.get('res_model_id', False) or self_ctx.env.context.get('default_res_model_id')
            //     if (res_model and res_model == 'hr.applicant') or (res_model_id and self_ctx.env['ir.model'].sudo().browse(res_model_id).model == 'hr.applicant'):
            //         defaults['applicant_id'] = defaults.get('res_id', False) or self_ctx.env.context.get('default_res_id', False)
            // 
            // return defaults
            */
            return await base.DefaultGetAsync(fields);
        }

        protected async Task<CalendarEvent> DefaultPartnersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _default_partners(self):
            // """ When active_model is res.partner, the current partners should be attendees """
            // partners = self.env.user.partner_id
            // active_id = self._context.get('active_id')
            // if self._context.get('active_model') == 'res.partner' and active_id and active_id not in partners.ids:
            //     partners |= self.env['res.partner'].browse(active_id)
            // return partners
            */
            return default;
        }

        protected async Task<CalendarEvent> DefaultStartInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _default_start(self):
            // now = fields.Datetime.now()
            // return now + (datetime.min - now) % timedelta(minutes=30)
            */
            return default;
        }

        protected async Task<CalendarEvent> DefaultStopInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _default_stop(self):
            // now = fields.Datetime.now()
            // duration_hours = self.get_default_duration()
            // start = now + (datetime.min - now) % timedelta(minutes=30)
            // return start + timedelta(hours=duration_hours)
            */
            return default;
        }

        protected async Task<CalendarEvent> DoSmsReminderInternalAsync(object alarms)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar_sms, FILE: calendar_event.py) ---
            // def _do_sms_reminder(self, alarms):
            // """ Send an SMS text reminder to attendees that haven't declined the event """
            // for event in self:
            //     declined_partners = event.attendee_ids.filtered_domain([('state', '=', 'declined')]).partner_id
            //     for alarm in alarms:
            //         partners = event._mail_get_partners()[event.id].filtered(
            //             lambda partner: partner.phone_sanitized and partner not in declined_partners
            //         )
            //         if event.user_id and not alarm.sms_notify_responsible:
            //             partners -= event.user_id.partner_id
            //         event._message_sms_with_template(
            //             template=alarm.sms_template_id,
            //             template_fallback=_("Event reminder: %(name)s, %(time)s.", name=event.name, time=event.display_time),
            //             partner_ids=partners.ids,
            //             put_in_queue=False
            //         )
            */
            return default;
        }

        protected async Task<CalendarEvent> EnsureAttendeesHaveEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _ensure_attendees_have_email(self):
            // invalid_event_ids = self.env['calendar.event'].search_read(
            //     domain=[('id', 'in', self.ids), ('attendee_ids.partner_id.email', '=', False)],
            //     fields=['display_time', 'display_name'],
            //     order='start',
            // )
            // if invalid_event_ids:
            //     list_length_limit = 50
            //     total_invalid_events = len(invalid_event_ids)
            //     invalid_event_ids = invalid_event_ids[:list_length_limit]
            //     invalid_events = ['\t- %s: %s' % (event['display_time'], event['display_name'])
            //                       for event in invalid_event_ids]
            //     invalid_events = '\n'.join(invalid_events)
            //     details = "(%d/%d)" % (list_length_limit, total_invalid_events) if list_length_limit < total_invalid_events else "(%d)" % total_invalid_events
            //     raise ValidationError(_("For a correct synchronization between Odoo and Outlook Calendar, "
            //                             "all attendees must have an email address. However, some events do "
            //                             "not respect this condition. As long as the events are incorrect, "
            //                             "the calendars will not be synchronized."
            //                             "\nEither update the events/attendees or archive these events %(details)s:"
            //                             "\n%(invalid_events)s", details=details, invalid_events=invalid_events))
            */
            return default;
        }

        protected async Task<CalendarEvent> FetchQueryInternalAsync(object query, object fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _fetch_query(self, query, fields):
            // if self.env.su:
            //     return super()._fetch_query(query, fields)
            // 
            // public_fnames = self._get_public_fields()
            // private_fields = [field for field in fields if field.name not in public_fnames]
            // if not private_fields:
            //     return super()._fetch_query(query, fields)
            // 
            // fields_to_fetch = list(fields) + [self._fields[name] for name in ('privacy', 'user_id', 'partner_ids')]
            // events = super()._fetch_query(query, fields_to_fetch)
            // 
            // # determine private events to which the user does not participate
            // others_private_events = events.filtered(lambda ev: ev._check_private_event_conditions())
            // if not others_private_events:
            //     return events
            // 
            // private_fields.append(self._fields['partner_ids'])
            // for field in private_fields:
            //     replacement = field.convert_to_cache(
            //         _('Busy') if field.name == 'name' else False,
            //         others_private_events)
            //     self.env.cache.update(others_private_events, field, repeat(replacement))
            // 
            // return events
            */
            return default;
        }

        public async Task<CalendarEvent> FindPartnerCustomerAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def find_partner_customer(self):
            // self.ensure_one()
            // return next(
            //     (attendee.partner_id for attendee in self.attendee_ids.sorted('create_date')
            //      if attendee.partner_id != self.user_id.partner_id),
            //     self.env['calendar.attendee']
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CalendarEvent> ForbidRecurrenceCreationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _forbid_recurrence_creation(self):
            // """
            // Suggest user to update recurrences in Outlook due to the Outlook Calendar spam limitation.
            // """
            // raise UserError(_("Due to an Outlook Calendar limitation, recurrent events must be created directly in Outlook Calendar."))
            */
            return default;
        }

        protected async Task<CalendarEvent> ForbidRecurrenceUpdateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _forbid_recurrence_update(self):
            // """
            // Suggest user to update recurrences in Outlook due to the Outlook Calendar spam limitation.
            // """
            // error_msg = _("Due to an Outlook Calendar limitation, recurrence updates must be done directly in Outlook Calendar.")
            // if any(not record.ms_universal_event_id for record in self):
            //     # If any event is not synced, suggest deleting it in Odoo and recreating it in Outlook.
            //     error_msg = _(
            //         "Due to an Outlook Calendar limitation, recurrence updates must be done directly in Outlook Calendar.\n"
            //         "If this recurrence is not shown in Outlook Calendar, you must delete it in Odoo Calendar and recreate it in Outlook Calendar.")
            // 
            // raise UserError(error_msg)
            */
            return default;
        }

        protected async Task<CalendarEvent> GetActivityDeadlineFromStartInternalAsync(object start, object allday)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_activity_deadline_from_start(self, start, allday):
            // # self.start is a datetime UTC *only when the event is not allday*
            // # activty.date_deadline is a date (No TZ, but should represent the day in which the user's TZ is)
            // # See 72254129dbaeae58d0a2055cba4e4a82cde495b7 for the same issue, but elsewhere
            // deadline = start
            // user_tz = self.env.context.get('tz')
            // if user_tz and not allday:
            //     deadline = pytz.utc.localize(deadline)
            //     deadline = deadline.astimezone(pytz.timezone(user_tz))
            // return deadline.date()
            */
            return default;
        }

        protected async Task<CalendarEvent> GetActivityExcludedModelsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_activity_excluded_models(self):
            // """
            // For some models, we don't want to automatically create activities when a calendar.event is created.
            // (This is the case notably for appointment.types)
            // This hook method allows to specify those models.
            // See calendar.event create method for details.
            // """
            // return []
            */
            return default;
        }

        protected async Task<CalendarEvent> GetArchiveValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_archive_values(self):
            // """ Return parameters for archiving events in calendar module. """
            // return {'active': False}
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def _get_archive_values(self):
            // """ Return the parameters for archiving events. Do not synchronize events after archiving. """
            // archive_values = super()._get_archive_values()
            // return {**archive_values, 'need_sync': False}
            */
            return default;
        }

        protected async Task<CalendarEvent> GetAttendeeEmailsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_attendee_emails(self):
            // """ Get comma-separated attendee email addresses. """
            // self.ensure_one()
            // return ",".join([e for e in self.attendee_ids.mapped("email") if e])
            */
            return default;
        }

        protected async Task<CalendarEvent> GetAttendeeStatusO2mInternalAsync(object attendee)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _get_attendee_status_o2m(self, attendee):
            // if self.user_id and self.user_id == attendee.partner_id.user_id:
            //     return 'organizer'
            // return ATTENDEE_CONVERTER_O2M.get(attendee.state, 'None')
            */
            return default;
        }

        protected async Task<CalendarEvent> GetCustomFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_custom_fields(self):
            // all_fields = self.fields_get(attributes=['manual'])
            // return {fname for fname in all_fields if all_fields[fname]['manual']}
            */
            return default;
        }

        protected async Task<CalendarEvent> GetCustomerDescriptionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_customer_description(self):
            // """:return (html): Sanitized HTML description for customer to include in calendar exports"""
            // return html_sanitize(self.description) if not is_html_empty(self.description) else ''
            */
            return default;
        }

        protected async Task<CalendarEvent> GetCustomerSummaryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_customer_summary(self):
            // """:return (str): The summary to include in calendar exports"""
            // return self.name or ''
            */
            return default;
        }

        protected async Task<CalendarEvent> GetDateFormatsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_date_formats(self):
            // """ get current date and time format, according to the context lang
            //     :return: a tuple with (format date, format time)
            // """
            // lang = get_lang(self.env)
            // return (lang.date_format, lang.time_format)
            */
            return default;
        }

        public async Task<CalendarEvent> GetDefaultDurationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def get_default_duration(self):
            // ir_default_get = self.env['ir.default'].sudo()._get
            // res = ir_default_get('calendar.event', 'duration', user_id=True, company_id=True)
            // res = res or ir_default_get('calendar.event', 'duration', user_id=True)
            // res = res or ir_default_get('calendar.event', 'duration', company_id=True)
            // res = res or ir_default_get('calendar.event', 'duration')
            // return res or 1
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CalendarEvent> GetDefaultPrivacyDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_default_privacy_domain(self):
            // # search user settings from calendars that are not private ('public' and 'confidential').
            // public_users_settings_ids = self.env['res.users.settings'].sudo().search(
            //     [('calendar_default_privacy', '!=', 'private')]).ids
            // # display public, confidential events and events with default privacy when owner's default privacy is not private
            // return [
            //     '|', '|', '|', ('privacy', '=', 'public'), ('privacy', '=', 'confidential'), ('user_id', '=', self.env.user.id),
            //     '&', ('privacy', '=', False), ('user_id.res_users_settings_id', 'in', public_users_settings_ids)
            // ]
            */
            return default;
        }

        public async Task<CalendarEvent> GetDiscussVideocallLocationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def get_discuss_videocall_location(self):
            // access_token = uuid.uuid4().hex
            // return f"{self.get_base_url()}/{self.DISCUSS_ROUTE}/{access_token}"
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CalendarEvent> GetDisplayTimeInternalAsync(object start, object stop, object zduration, object zallday)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_display_time(self, start, stop, zduration, zallday):
            // """ Return date and time (from to from) based on duration with timezone in string. Eg :
            //         1) if user add duration for 2 hours, return : August-23-2013 at (04-30 To 06-30) (Europe/Brussels)
            //         2) if event all day ,return : AllDay, July-31-2013
            // """
            // timezone = self._context.get('tz') or self.env.user.partner_id.tz or 'UTC'
            // 
            // # get date/time format according to context
            // format_date, format_time = self._get_date_formats()
            // 
            // # convert date and time into user timezone
            // self_tz = self.with_context(tz=timezone)
            // date = fields.Datetime.context_timestamp(self_tz, fields.Datetime.from_string(start))
            // date_deadline = fields.Datetime.context_timestamp(self_tz, fields.Datetime.from_string(stop))
            // 
            // # convert into string the date and time, using user formats
            // date_str = date.strftime(format_date)
            // time_str = date.strftime(format_time)
            // 
            // if zallday:
            //     display_time = _("All Day, %(day)s", day=date_str)
            // elif zduration < 24:
            //     duration = date + timedelta(minutes=round(zduration*60))
            //     duration_time = duration.strftime(format_time)
            //     display_time = _(
            //         u"%(day)s at (%(start)s To %(end)s) (%(timezone)s)",
            //         day=date_str,
            //         start=time_str,
            //         end=duration_time,
            //         timezone=timezone,
            //     )
            // else:
            //     dd_date = date_deadline.strftime(format_date)
            //     dd_time = date_deadline.strftime(format_time)
            //     display_time = _(
            //         u"%(date_start)s at %(time_start)s To\n %(date_end)s at %(time_end)s (%(timezone)s)",
            //         date_start=date_str,
            //         time_start=time_str,
            //         date_end=dd_date,
            //         time_end=dd_time,
            //         timezone=timezone,
            //     )
            // return display_time
            */
            return default;
        }

        public async Task<CalendarEvent> GetDisplayTimeTzAsync(Guid id, CalendarEventGetDisplayTimeTzRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def get_display_time_tz(self, tz=False):
            // """ get the display_time of the meeting, forcing the timezone. This method is called from email template, to not use sudo(). """
            // self.ensure_one()
            // if tz:
            //     self = self.with_context(tz=tz)
            // return self._get_display_time(self.start, self.stop, self.duration, self.allday)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CalendarEvent> GetDurationInternalAsync(object start, object stop)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_duration(self, start, stop):
            // """ Get the duration value between the 2 given dates. """
            // if not start or not stop:
            //     return 0
            // duration = (stop - start).total_seconds() / 3600
            // return round(duration, 2)
            */
            return default;
        }

        protected async Task<CalendarEvent> GetEventUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def _get_event_user(self):
            // self.ensure_one()
            // if self.user_id and self.user_id.sudo().google_calendar_token:
            //     return self.user_id
            // return self.env.user
            */
            return default;
        }

        protected async Task<CalendarEvent> GetEventUserMInternalAsync(Guid user_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _get_event_user_m(self, user_id=None):
            // """ Get the user who will send the request to Microsoft (organizer if synchronized and current user otherwise). """
            // self.ensure_one()
            // # Current user must have access to token in order to access event properties (non-public user).
            // current_user_status = self.env.user._get_microsoft_calendar_token()
            // if user_id != self.env.user and current_user_status:
            //     if user_id is None:
            //         user_id = self.user_id
            //     if user_id and self.with_user(user_id).sudo()._check_microsoft_sync_status():
            //         return user_id
            // return self.env.user
            */
            return default;
        }

        protected async Task<CalendarEvent> GetEventsIntervalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_calendar, FILE: calendar_event.py) ---
            // def _get_events_interval(self):
            // """
            // This method will returned an Intervals object that represent the event's interval based of its parameters.
            // 
            // If an event is scheduled for the entire day, its interval will correspond to the work interval defined by the
            // company's calendar.
            // If an allday event is scheduled on a day when the company is closed, the interval of this event will be empty.
            // """
            // start = min(self.mapped('start')).replace(hour=0, minute=0, second=0, tzinfo=UTC)
            // stop = max(self.mapped('stop')).replace(hour=23, minute=59, second=59, tzinfo=UTC)
            // company_calendar = self.env.company.resource_calendar_id
            // global_interval = company_calendar._work_intervals_batch(start, stop)[False]
            // interval_by_event = {}
            // for event in self:
            //     if event.allday:
            //         # Avoid allday event with a duration of 0
            //         allday_event_interval = Intervals([(
            //             event.start.replace(hour=0, minute=0, second=0, tzinfo=UTC),
            //             event.stop.replace(hour=23, minute=59, second=59, tzinfo=UTC),
            //             self.env['resource.calendar']
            //         )])
            // 
            //         if any(not (Intervals([(
            //             event.start.replace(hour=0, minute=0, second=0, tzinfo=UTC) + relativedelta(days=i),
            //             event.start.replace(hour=23, minute=59, second=59, tzinfo=UTC) + relativedelta(days=i),
            //             self.env['resource.calendar']
            //         )]) & global_interval) for i in range(0, (event.stop_date - event.start_date).days + 1)):
            //             interval_by_event[event] = Intervals([])
            //         else:
            //             interval_by_event[event] = allday_event_interval & global_interval
            //     else:
            //         interval_by_event[event] = Intervals([(
            //             timezone_datetime(event.start),
            //             timezone_datetime(event.stop),
            //             self.env['resource.calendar']
            //         )])
            // return interval_by_event
            */
            return default;
        }

        protected async Task<CalendarEvent> GetGoogleSyncedFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def _get_google_synced_fields(self):
            // return {'name', 'description', 'allday', 'start', 'date_end', 'stop',
            //         'attendee_ids', 'alarm_ids', 'location', 'privacy', 'active', 'show_as'}
            */
            return default;
        }

        protected async Task<CalendarEvent> GetIcsFileInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_ics_file(self):
            // """ Returns iCalendar file for the event invitation.
            //     :returns a dict of .ics file content for each meeting
            // """
            // result = {}
            // 
            // def ics_datetime(idate, allday=False):
            //     if idate:
            //         if allday:
            //             return idate
            //         return idate.replace(tzinfo=pytz.timezone('UTC'))
            //     return False
            // 
            // if not vobject:
            //     return result
            // 
            // for meeting in self:
            //     cal = vobject.iCalendar()
            //     event = cal.add('vevent')
            // 
            //     if not meeting.start or not meeting.stop:
            //         raise UserError(_("First you have to specify the date of the invitation."))
            //     event.add('created').value = ics_datetime(fields.Datetime.now())
            //     event.add('dtstart').value = ics_datetime(meeting.start, meeting.allday)
            //     event.add('dtend').value = ics_datetime(meeting.stop, meeting.allday)
            //     event.add('summary').value = meeting._get_customer_summary()
            //     description = html2plaintext(meeting._get_customer_description())
            //     if description:
            //         event.add('description').value = description
            //     if meeting.location:
            //         event.add('location').value = meeting.location
            //     if meeting.rrule:
            //         event.add('rrule').value = meeting.rrule
            // 
            //     if meeting.alarm_ids:
            //         for alarm in meeting.alarm_ids:
            //             valarm = event.add('valarm')
            //             interval = alarm.interval
            //             duration = alarm.duration
            //             trigger = valarm.add('TRIGGER')
            //             trigger.params['related'] = ["START"]
            //             if interval == 'days':
            //                 delta = timedelta(days=duration)
            //             elif interval == 'hours':
            //                 delta = timedelta(hours=duration)
            //             elif interval == 'minutes':
            //                 delta = timedelta(minutes=duration)
            //             trigger.value = delta
            //             valarm.add('DESCRIPTION').value = alarm.name or u'Odoo'
            //     for attendee in meeting.attendee_ids:
            //         attendee_add = event.add('attendee')
            //         attendee_add.value = u'MAILTO:' + (attendee.email or u'')
            // 
            //     # Add "organizer" field if email available
            //     if meeting.partner_id.email:
            //         organizer = event.add('organizer')
            //         organizer.value = u'MAILTO:' + meeting.partner_id.email
            //         if meeting.partner_id.name:
            //             organizer.params['CN'] = [meeting.partner_id.display_name.replace('\"', '\'')]
            // 
            //     result[meeting.id] = cal.serialize().encode('utf-8')
            // 
            // return result
            */
            return default;
        }

        protected async Task<CalendarEvent> GetMailMessageAccessInternalAsync(List<Guid> res_ids, object operation, object model_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_mail_message_access(self, res_ids, operation, model_name=None):
            // if operation == 'read' and (not model_name or model_name == 'event.event'):
            //     for event in self.browse(res_ids):
            //         if event.privacy == "private" and self.env.user.partner_id not in event.attendee_ids.partner_id:
            //             return 'write'
            // return super()._get_mail_message_access(res_ids, operation, model_name=model_name)
            */
            return default;
        }

        protected async Task<CalendarEvent> GetMailTzInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_mail_tz(self):
            // self.ensure_one()
            // return self.event_tz or self.env.user.tz
            */
            return default;
        }

        protected async Task<CalendarEvent> GetMicrosoftSyncDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _get_microsoft_sync_domain(self):
            // # in case of full sync, limit to a range of 1y in past and 1y in the future by default
            // ICP = self.env['ir.config_parameter'].sudo()
            // day_range = int(ICP.get_param('microsoft_calendar.sync.range_days', default=365))
            // lower_bound = fields.Datetime.subtract(fields.Datetime.now(), days=day_range)
            // upper_bound = fields.Datetime.add(fields.Datetime.now(), days=day_range)
            // 
            // # Define 'custom_lower_bound_range' param for limiting old events updates in Odoo and avoid spam on Microsoft.
            // custom_lower_bound_range = ICP.get_param('microsoft_calendar.sync.lower_bound_range')
            // if custom_lower_bound_range:
            //     lower_bound = fields.Datetime.subtract(fields.Datetime.now(), days=int(custom_lower_bound_range))
            // domain = [
            //     ('partner_ids.user_ids', 'in', [self.env.user.id]),
            //     ('stop', '>', lower_bound),
            //     ('start', '<', upper_bound),
            //     '!', '&', '&', ('recurrency', '=', True), ('recurrence_id', '!=', False), ('follow_recurrence', '=', True)
            // ]
            // 
            // # Synchronize events that were created after the first synchronization date, when applicable.
            // first_synchronization_date = ICP.get_param('microsoft_calendar.sync.first_synchronization_date')
            // if first_synchronization_date:
            //     domain = expression.AND([domain, [('create_date', '>=', first_synchronization_date)]])
            // 
            // return self._extend_microsoft_domain(domain)
            */
            return default;
        }

        protected async Task<CalendarEvent> GetMicrosoftSyncedFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _get_microsoft_synced_fields(self):
            // return {'name', 'description', 'allday', 'start', 'date_end', 'stop',
            //         'user_id', 'privacy',
            //         'attendee_ids', 'alarm_ids', 'location', 'show_as', 'active', 'videocall_location'}
            */
            return default;
        }

        public async Task<CalendarEvent> GetNextAlarmDateAsync(Guid id, CalendarEventGetNextAlarmDateRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def get_next_alarm_date(self, events_by_alarm):
            // self.ensure_one()
            // now = fields.datetime.now()
            // sorted_alarms = self.alarm_ids.sorted("duration_minutes")
            // triggered_alarms = sorted_alarms.filtered(lambda alarm: alarm.id in events_by_alarm)[0]
            // event_has_future_alarms = sorted_alarms[0] != triggered_alarms
            // next_date = None
            // if self.recurrence_id.trigger_id and self.recurrence_id.trigger_id.call_at <= now:
            //     next_date = self.start - timedelta(minutes=sorted_alarms[0].duration_minutes) \
            //         if event_has_future_alarms \
            //         else self.start
            // # For recurrent events, when there is no next_date and no trigger in the recurence, set the next
            // # date as the date of the next event. This keeps the single alarm alive in the recurrence.
            // recurrence_has_no_trigger = self.recurrence_id and not self.recurrence_id.trigger_id
            // if recurrence_has_no_trigger and not next_date and len(sorted_alarms) > 0:
            //     future_recurrent_events = self.recurrence_id.calendar_event_ids.filtered(lambda ev: ev.start > self.start)
            //     if future_recurrent_events:
            //         # The next event (minus the alarm duration) will be the next date.
            //         next_recurrent_event = future_recurrent_events.sorted("start")[0]
            //         next_date = next_recurrent_event.start - timedelta(minutes=sorted_alarms[0].duration_minutes)
            // return next_date
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CalendarEvent> GetOrganizerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _get_organizer(self):
            // return self.user_id
            */
            return default;
        }

        protected async Task<CalendarEvent> GetOrganizerUserChangeInfoInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _get_organizer_user_change_info(self, values):
            // """ Return the sender user of the event and the partner ids listed on the event values. """
            // sender_user_id = values.get('user_id')
            // if not sender_user_id:
            //     sender_user_id = self.env.user.id
            // sender_user = self.env['res.users'].browse(sender_user_id)
            // attendee_values = self._attendees_values(values['partner_ids']) if 'partner_ids' in values else []
            // partner_ids = []
            // if attendee_values:
            //     for command in attendee_values:
            //         if len(command) == 3 and isinstance(command[2], dict):
            //             partner_ids.append(command[2].get('partner_id'))
            // return sender_user, partner_ids
            */
            return default;
        }

        protected async Task<CalendarEvent> GetPublicFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_public_fields(self):
            // return self._get_recurrent_fields() | self._get_time_fields() | self._get_custom_fields() | {
            //     'id', 'active', 'allday',
            //     'duration', 'user_id', 'interval', 'partner_id',
            //     'count', 'rrule', 'recurrence_id', 'show_as', 'privacy'}
            */
            return default;
        }

        protected async Task<CalendarEvent> GetRecurrenceParamsByDateInternalAsync(object event_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_recurrence_params_by_date(self, event_date):
            // """ Return the recurrence parameters from a date object. """
            // weekday_field_name = weekday_to_field(event_date.weekday())
            // return {
            //     weekday_field_name: True,
            //     'weekday': weekday_field_name.upper(),
            //     'byday': str(get_weekday_occurence(event_date)),
            //     'day': event_date.day,
            // }
            */
            return default;
        }

        protected async Task<CalendarEvent> GetRecurrenceParamsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_recurrence_params(self):
            // if not self:
            //     return {}
            // event_date = self._get_start_date()
            // weekday_field_name = weekday_to_field(event_date.weekday())
            // return {
            //     weekday_field_name: True,
            //     'weekday': weekday_field_name.upper(),
            //     'byday': str(get_weekday_occurence(event_date)),
            //     'day': event_date.day,
            // }
            */
            return default;
        }

        protected async Task<CalendarEvent> GetRecurrentFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_recurrent_fields(self):
            // return {'byday', 'until', 'rrule_type', 'month_by', 'event_tz', 'rrule',
            //         'interval', 'count', 'end_type', 'mon', 'tue', 'wed', 'thu', 'fri', 'sat',
            //         'sun', 'day', 'weekday'}
            */
            return default;
        }

        protected async Task<CalendarEvent> GetRemoveSyncIdValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_remove_sync_id_values(self):
            // """ Return parameters for removing event synchronization id within _update_future_events function scope. """
            // return {}
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def _get_remove_sync_id_values(self):
            // """ Add parameters for removing event synchronization while updating the events in super class. """
            // remove_sync_id_values = super()._get_remove_sync_id_values()
            // return {**remove_sync_id_values, 'google_id': False}
            */
            return default;
        }

        protected async Task<CalendarEvent> GetStartDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_start_date(self):
            // """Return the event starting date in the event's timezone.
            // If no starting time is assigned (yet), return today as default
            // :return: date
            // """
            // if not self.start:
            //     return fields.Date.today()
            // if self.recurrency and self.event_tz:
            //     tz = pytz.timezone(self.event_tz)
            //     # Ensure that all day events date are not calculated around midnight. TZ shift would potentially return bad date
            //     start = self.start if not self.allday else self.start.replace(hour=12)
            //     return pytz.utc.localize(start).astimezone(tz).date()
            // return self.start.date()
            */
            return default;
        }

        public async Task<CalendarEvent> GetStateSelectionsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def get_state_selections(self):
            // return Attendee.STATE_SELECTION
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CalendarEvent> GetSyncDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def _get_sync_domain(self):
            // # in case of full sync, limit to a range of 1y in past and 1y in the future by default
            // ICP = self.env['ir.config_parameter'].sudo()
            // day_range = int(ICP.get_param('google_calendar.sync.range_days', default=365))
            // lower_bound = fields.Datetime.subtract(fields.Datetime.now(), days=day_range)
            // upper_bound = fields.Datetime.add(fields.Datetime.now(), days=day_range)
            // return [
            //     ('partner_ids.user_ids', 'in', self.env.user.id),
            //     ('stop', '>', lower_bound),
            //     ('start', '<', upper_bound),
            //     # Do not sync events that follow the recurrence, they are already synced at recurrence creation
            //     '!', '&', '&', ('recurrency', '=', True), ('recurrence_id', '!=', False), ('follow_recurrence', '=', True)
            // ]
            */
            return default;
        }

        protected async Task<CalendarEvent> GetTimeFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_time_fields(self):
            // return {'start', 'stop', 'start_date', 'stop_date'}
            */
            return default;
        }

        protected async Task<CalendarEvent> GetTimeUpdateDictInternalAsync(object base_event, object time_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_time_update_dict(self, base_event, time_values):
            // """ Return the update dictionary for shifting the base_event's time to the new date. """
            // if not base_event:
            //     raise UserError(_("You can't update a recurrence without base event."))
            // [base_time_values] = base_event.read(['start', 'stop', 'allday'])
            // update_dict = {}
            // start_update = fields.Datetime.to_datetime(time_values.get('start'))
            // stop_update = fields.Datetime.to_datetime(time_values.get('stop'))
            // # Convert the base_event_id hours according to new values: time shift
            // if start_update or stop_update:
            //     if start_update:
            //         start = base_time_values['start'] + (start_update - self.start)
            //         stop = base_time_values['stop'] + (start_update - self.start)
            //         start_date = base_time_values['start'].date() + (start_update.date() - self.start.date())
            //         stop_date = base_time_values['stop'].date() + (start_update.date() - self.start.date())
            //         update_dict.update({'start': start, 'start_date': start_date, 'stop': stop, 'stop_date': stop_date})
            //     if stop_update:
            //         if not start_update:
            //             # Apply the same shift for start
            //             start = base_time_values['start'] + (stop_update - self.stop)
            //             start_date = base_time_values['start'].date() + (stop_update.date() - self.stop.date())
            //             update_dict.update({'start': start, 'start_date': start_date})
            //         stop = base_time_values['stop'] + (stop_update - self.stop)
            //         stop_date = base_time_values['stop'].date() + (stop_update.date() - self.stop.date())
            //         update_dict.update({'stop': stop, 'stop_date': stop_date})
            // return update_dict
            */
            return default;
        }

        protected async Task<CalendarEvent> GetTriggerAlarmTypesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_trigger_alarm_types(self):
            // return ['email']
            --- ODOO METHOD SOURCE (MODULE: calendar_sms, FILE: calendar_event.py) ---
            // def _get_trigger_alarm_types(self):
            // return super()._get_trigger_alarm_types() + ['sms']
            */
            return default;
        }

        public async Task<CalendarEvent> GetUnusualDaysAsync(Guid id, CalendarEventGetUnusualDaysRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_calendar, FILE: calendar_event.py) ---
            // def get_unusual_days(self, date_from, date_to=None):
            // return self.env.user.employee_id._get_unusual_days(date_from, date_to)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CalendarEvent> GetUpdateFutureEventsValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_update_future_events_values(self):
            // """ Return parameters for updating future events within _update_future_events function scope. """
            // return {}
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def _get_update_future_events_values(self):
            // """ Add parameters for updating events within the _update_future_events function scope. """
            // update_future_events_values = super()._get_update_future_events_values()
            // return {**update_future_events_values, 'need_sync': False}
            */
            return default;
        }

        protected async Task<CalendarEvent> GetUpdatedRecurrenceValuesInternalAsync(object new_start_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_updated_recurrence_values(self, new_start_date):
            // """ Copy values from current recurrence and update the start date weekday. """
            // [previous_recurrence_values] = self.recurrence_id.copy_data()
            // if self.start.weekday() != new_start_date.weekday():
            //     previous_recurrence_values.pop(weekday_to_field(self.start.weekday()), None)
            // return previous_recurrence_values
            */
            return default;
        }

        protected async Task<CalendarEvent> GoogleValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def _google_values(self):
            // # In Google API, all-day events must have their 'dateTime' information set
            // # as null and timed events must have their 'date' information set as null.
            // # This is mandatory for allowing changing timed events to all-day and vice versa.
            // start = {'date': None, 'dateTime': None}
            // end = {'date': None, 'dateTime': None}
            // if self.allday:
            //     # For all-day events, 'dateTime' must be set to None to indicate that it's an all-day event.
            //     # Otherwise, if both 'date' and 'dateTime' are set, Google may not recognize it as an all-day event.
            //     start['date'] = self.start_date.isoformat()
            //     end['date'] = (self.stop_date + relativedelta(days=1)).isoformat()
            // else:
            //     # For timed events, 'date' must be set to None to indicate that it's not an all-day event.
            //     # Otherwise, if both 'date' and 'dateTime' are set, Google may not recognize it as a timed event
            //     start['dateTime'] = pytz.utc.localize(self.start).isoformat()
            //     end['dateTime'] = pytz.utc.localize(self.stop).isoformat()
            // reminders = [{
            //     'method': "email" if alarm.alarm_type == "email" else "popup",
            //     'minutes': alarm.duration_minutes
            // } for alarm in self.alarm_ids]
            // 
            // attendees = self.attendee_ids
            // attendee_values = [{
            //     'email': attendee.partner_id.email_normalized,
            //     'responseStatus': attendee.state or 'needsAction',
            // } for attendee in attendees if attendee.partner_id.email_normalized]
            // # We sort the attendees to avoid undeterministic test fails. It's not mandatory for Google.
            // attendee_values.sort(key=lambda k: k['email'])
            // values = {
            //     'id': self.google_id,
            //     'start': start,
            //     'end': end,
            //     'summary': self.name,
            //     'description': self._get_customer_description(),
            //     'location': self.location or '',
            //     'guestsCanModify': not self.guests_readonly,
            //     'organizer': {'email': self.user_id.email, 'self': self.user_id == self.env.user},
            //     'attendees': attendee_values,
            //     'extendedProperties': {
            //         'shared': {
            //             '%s_odoo_id' % self.env.cr.dbname: self.id,
            //         },
            //     },
            //     'reminders': {
            //         'overrides': reminders,
            //         'useDefault': False,
            //     }
            // }
            // if not self.google_id and not self.videocall_location and not self.location:
            //     values['conferenceData'] = {'createRequest': {'requestId': uuid4().hex}}
            // if self.privacy:
            //     values['visibility'] = self.privacy
            // if self.show_as:
            //     values['transparency'] = 'opaque' if self.show_as == 'busy' else 'transparent'
            // if not self.active:
            //     values['status'] = 'cancelled'
            // if self.user_id and self.user_id != self.env.user and not bool(self.user_id.sudo().google_calendar_token):
            //     # The organizer is an Odoo user that do not sync his calendar
            //     values['extendedProperties']['shared']['%s_owner_id' % self.env.cr.dbname] = self.user_id.id
            // elif not self.user_id:
            //     # We can't store on the shared properties in that case without getting a 403. It can happen when
            //     # the owner is not an Odoo user: We don't store the real owner identity (mail)
            //     # If we are not the owner, we should change the post values to avoid errors because we don't have
            //     # write permissions
            //     # See https://developers.google.com/calendar/concepts/sharing
            //     keep_keys = ['id', 'summary', 'attendees', 'start', 'end', 'reminders']
            //     values = {key: val for key, val in values.items() if key in keep_keys}
            //     # values['extendedProperties']['private] should be used if the owner is not an odoo user
            //     values['extendedProperties'] = {
            //         'private': {
            //             '%s_odoo_id' % self.env.cr.dbname: self.id,
            //         },
            //     }
            // return values
            */
            return default;
        }

        protected async Task<CalendarEvent> InverseDatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _inverse_dates(self):
            // """ This method is used to set the start and stop values of all day events.
            //     The calendar view needs date_start and date_stop values to display correctly the allday events across
            //     several days. As the user edit the {start,stop}_date fields when allday is true,
            //     this inverse method is needed to update the  start/stop value and have a relevant calendar view.
            // """
            // for meeting in self:
            //     if meeting.allday:
            // 
            //         # Convention break:
            //         # stop and start are NOT in UTC in allday event
            //         # in this case, they actually represent a date
            //         # because fullcalendar just drops times for full day events.
            //         # i.e. Christmas is on 25/12 for everyone
            //         # even if people don't celebrate it simultaneously
            //         enddate = fields.Datetime.from_string(meeting.stop_date or meeting.stop)
            //         enddate = enddate.replace(hour=18)
            // 
            //         startdate = fields.Datetime.from_string(meeting.start_date or meeting.start)
            //         startdate = startdate.replace(hour=8)  # Set 8 AM
            // 
            //         if meeting.start_date and meeting.stop_date:
            //             # If start_date or stop_date is set, use start_date and stop_date;
            //             # otherwise, use start and stop.
            //             meeting.write({
            //                 'start': startdate.replace(tzinfo=None),
            //                 'stop': enddate.replace(tzinfo=None)
            //             })
            //         else:
            //             meeting.write({
            //                 'start_date': startdate.replace(tzinfo=None),
            //                 'stop_date': enddate.replace(tzinfo=None)
            //             })
            */
            return default;
        }

        protected async Task<CalendarEvent> IsCrmLeadInternalAsync(object defaults, object ctx)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: calendar.py) ---
            // def _is_crm_lead(self, defaults, ctx=None):
            // """
            //     This method checks if the concerned model is a CRM lead.
            //     The information is not always in the defaults values,
            //     this is why it is necessary to check the context too.
            // """
            // res_model = defaults.get('res_model', False) or ctx and ctx.get('default_res_model')
            // res_model_id = defaults.get('res_model_id', False) or ctx and ctx.get('default_res_model_id')
            // 
            // return res_model and res_model == 'crm.lead' or res_model_id and self.env['ir.model'].sudo().browse(res_model_id).model == 'crm.lead'
            */
            return default;
        }

        protected async Task<CalendarEvent> IsEventOverInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _is_event_over(self):
            // """Check if the event is over. This method is used to check if the event
            // should trigger invitations with Google Calendar.
            // :return: True if the event is over, False otherwise
            // """
            // self.ensure_one()
            // now = fields.Datetime.now()
            // today = fields.Date.today()
            // 
            // # For all-day events
            // if self.allday:
            //     return self.stop_date and self.stop_date < today
            // 
            // # For timed events
            // return self.stop and self.stop < now
            */
            return default;
        }

        protected async Task<CalendarEvent> IsGoogleInsertionBlockedInternalAsync(object sender_user)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def _is_google_insertion_blocked(self, sender_user):
            // self.ensure_one()
            // has_different_owner = self.user_id and self.user_id != sender_user
            // return has_different_owner
            */
            return default;
        }

        protected async Task<CalendarEvent> IsMatchingTimeslotInternalAsync(object start, object stop, object allday)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _is_matching_timeslot(self, start, stop, allday):
            // """
            // Check if an event matches with the provided timeslot
            // """
            // self.ensure_one()
            // 
            // event_start, event_stop = self._range()
            // if allday:
            //     event_start = datetime(event_start.year, event_start.month, event_start.day, 0, 0)
            //     event_stop = datetime(event_stop.year, event_stop.month, event_stop.day, 0, 0)
            // 
            // return (event_start, event_stop) == (start, stop)
            */
            return default;
        }

        protected async Task<CalendarEvent> IsMicrosoftInsertionBlockedInternalAsync(object sender_user)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _is_microsoft_insertion_blocked(self, sender_user):
            // self.ensure_one()
            // has_different_owner = self.user_id and self.user_id != sender_user
            // return has_different_owner
            */
            return default;
        }

        public async Task<CalendarEvent> JoinMeetingAsync(Guid id, CalendarEventJoinMeetingRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def action_join_meeting(self, partner_id):
            // """ Method used when an existing user wants to join
            // """
            // self.ensure_one()
            // partner = self.env['res.partner'].browse(partner_id)
            // if partner not in self.partner_ids:
            //     self.write({'partner_ids': [(4, partner.id)]})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CalendarEvent> JoinVideoCallAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def action_join_video_call(self):
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': self.videocall_location,
            //     'target': 'new'
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CalendarEvent> MassArchiveAsync(Guid id, CalendarEventMassArchiveRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def action_mass_archive(self, recurrence_update_setting):
            // """
            // The aim of this action purpose is to be called from sync calendar module when mass deletion is not possible.
            // """
            // self.ensure_one()
            // if recurrence_update_setting == 'all_events':
            //     self.recurrence_id.calendar_event_ids.write(self._get_archive_values())
            // elif recurrence_update_setting == 'future_events':
            //     detached_events = self.recurrence_id._stop_at(self)
            //     detached_events.write(self._get_archive_values())
            // elif recurrence_update_setting == 'self_only':
            //     self.write({
            //         'active': False,
            //         'recurrence_update': 'self_only'
            //     })
            //     if len(self.recurrence_id.calendar_event_ids) == 0:
            //         self.recurrence_id.unlink()
            //     elif self == self.recurrence_id.base_event_id:
            //         self.recurrence_id._select_new_base_event()
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def action_mass_archive(self, recurrence_update_setting):
            // """ Delete recurrence in Odoo if in 'all_events' or in 'future_events' edge case, triggering one mail. """
            // self.ensure_one()
            // google_service = GoogleCalendarService(self.env['google.service'])
            // archive_future_events = recurrence_update_setting == 'future_events' and self == self.recurrence_id.base_event_id
            // if recurrence_update_setting == 'all_events' or archive_future_events:
            //     self.recurrence_id.with_context(is_recurrence=True)._google_delete(google_service, self.recurrence_id.google_id)
            //     # Increase performance handling 'future_events' edge case as it was an 'all_events' update.
            //     if archive_future_events:
            //         recurrence_update_setting = 'all_events'
            // super(Meeting, self).action_mass_archive(recurrence_update_setting)
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def action_mass_archive(self, recurrence_update_setting):
            // # Do not allow archiving if recurrence is synced with Outlook. Suggest updating directly from Outlook.
            // self.ensure_one()
            // if self._check_microsoft_sync_status() and self.microsoft_id:
            //     self._forbid_recurrence_update()
            // super().action_mass_archive(recurrence_update_setting)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CalendarEvent> MassDeletionAsync(Guid id, CalendarEventMassDeletionRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def action_mass_deletion(self, recurrence_update_setting):
            // self.ensure_one()
            // if recurrence_update_setting == 'all_events':
            //     events = self.recurrence_id.calendar_event_ids
            //     self.recurrence_id.unlink()
            //     events.unlink()
            // elif recurrence_update_setting == 'future_events':
            //     future_events = self.recurrence_id.calendar_event_ids.filtered(lambda ev: ev.start >= self.start)
            //     future_events.unlink()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CalendarEvent> MicrosoftToOdooRecurrenceValuesInternalAsync(object microsoft_event, object default_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _microsoft_to_odoo_recurrence_values(self, microsoft_event, default_values=None):
            // timeZone_start = pytz.timezone(microsoft_event.start.get('timeZone'))
            // timeZone_stop = pytz.timezone(microsoft_event.end.get('timeZone'))
            // start = parse(microsoft_event.start.get('dateTime')).astimezone(timeZone_start).replace(tzinfo=None)
            // if microsoft_event.isAllDay:
            //     stop = parse(microsoft_event.end.get('dateTime')).astimezone(timeZone_stop).replace(tzinfo=None) - relativedelta(days=1)
            // else:
            //     stop = parse(microsoft_event.end.get('dateTime')).astimezone(timeZone_stop).replace(tzinfo=None)
            // values = default_values or {}
            // values.update({
            //     'microsoft_id': microsoft_event.id,
            //     'ms_universal_event_id': microsoft_event.iCalUId,
            //     'microsoft_recurrence_master_id': microsoft_event.seriesMasterId,
            //     'start': start,
            //     'stop': stop,
            // })
            // return values
            */
            return default;
        }

        protected async Task<CalendarEvent> MicrosoftToOdooValuesInternalAsync(object microsoft_event, object default_reminders, object default_values, List<Guid> with_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _microsoft_to_odoo_values(self, microsoft_event, default_reminders=(), default_values=None, with_ids=False):
            // if microsoft_event.is_cancelled():
            //     return {'active': False}
            // 
            // sensitivity_o2m = {
            //     'normal': 'public',
            //     'private': 'private',
            //     'confidential': 'confidential',
            // }
            // 
            // commands_attendee, commands_partner = self._odoo_attendee_commands_m(microsoft_event)
            // timeZone_start = pytz.timezone(microsoft_event.start.get('timeZone'))
            // timeZone_stop = pytz.timezone(microsoft_event.end.get('timeZone'))
            // start = parse(microsoft_event.start.get('dateTime')).astimezone(timeZone_start).replace(tzinfo=None)
            // if microsoft_event.isAllDay:
            //     stop = parse(microsoft_event.end.get('dateTime')).astimezone(timeZone_stop).replace(tzinfo=None) - relativedelta(days=1)
            // else:
            //     stop = parse(microsoft_event.end.get('dateTime')).astimezone(timeZone_stop).replace(tzinfo=None)
            // values = default_values or {}
            // values.update({
            //     'name': microsoft_event.subject or _("(No title)"),
            //     'description': microsoft_event.body and microsoft_event.body['content'],
            //     'location': microsoft_event.location and microsoft_event.location.get('displayName') or False,
            //     'user_id': microsoft_event.owner_id(self.env),
            //     'privacy': sensitivity_o2m.get(microsoft_event.sensitivity, False),
            //     'attendee_ids': commands_attendee,
            //     'allday': microsoft_event.isAllDay,
            //     'start': start,
            //     'stop': stop,
            //     'show_as': 'free' if microsoft_event.showAs == 'free' else 'busy',
            //     'recurrency': microsoft_event.is_recurrent()
            // })
            // if commands_partner:
            //     # Add partner_commands only if set from Microsoft. The write method on calendar_events will
            //     # override attendee commands if the partner_ids command is set but empty.
            //     values['partner_ids'] = commands_partner
            // 
            // if microsoft_event.is_recurrent() and not microsoft_event.is_recurrence():
            //     # Propagate the follow_recurrence according to the Outlook result
            //     values['follow_recurrence'] = not microsoft_event.is_recurrence_outlier()
            // 
            // # if a videocall URL is provided with the Outlook event, use it
            // if microsoft_event.isOnlineMeeting and microsoft_event.onlineMeeting.get("joinUrl"):
            //     values['videocall_location'] = microsoft_event.onlineMeeting["joinUrl"]
            // else:
            //     # if a location is a URL matching a specific pattern (i.e a URL to access to a videocall),
            //     # copy it in the 'videocall_location' instead
            //     if values['location'] and any(re.match(p, values['location']) for p in VIDEOCALL_URL_PATTERNS):
            //         values['videocall_location'] = values['location']
            //         values['location'] = False
            // 
            // if with_ids:
            //     values['microsoft_id'] = microsoft_event.id
            //     values['ms_universal_event_id'] = microsoft_event.iCalUId
            // 
            // 
            // if microsoft_event.is_recurrent():
            //     values['microsoft_recurrence_master_id'] = microsoft_event.seriesMasterId
            // 
            // alarm_commands = self._odoo_reminders_commands_m(microsoft_event)
            // if alarm_commands:
            //     values['alarm_ids'] = alarm_commands
            // 
            // return values
            */
            return default;
        }

        protected async Task<CalendarEvent> MicrosoftValuesInternalAsync(object fields_to_sync, object initial_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _microsoft_values(self, fields_to_sync, initial_values={}):
            // values = dict(initial_values)
            // if not fields_to_sync:
            //     return values
            // 
            // microsoft_guid = self.env['ir.config_parameter'].sudo().get_param('microsoft_calendar.microsoft_guid', False)
            // 
            // if self.microsoft_recurrence_master_id and 'type' not in values:
            //     values['seriesMasterId'] = self.microsoft_recurrence_master_id
            //     values['type'] = 'exception'
            // 
            // if 'name' in fields_to_sync:
            //     values['subject'] = self.name or ''
            // 
            // if 'description' in fields_to_sync:
            //     values['body'] = {
            //         'content': self._get_customer_description(),
            //         'contentType': "html",
            //     }
            // 
            // if any(x in fields_to_sync for x in ['allday', 'start', 'date_end', 'stop']):
            //     if self.allday:
            //         start = {'dateTime': self.start_date.isoformat(), 'timeZone': 'Europe/London'}
            //         end = {'dateTime': (self.stop_date + relativedelta(days=1)).isoformat(), 'timeZone': 'Europe/London'}
            //     else:
            //         start = {'dateTime': pytz.utc.localize(self.start).isoformat(), 'timeZone': 'Europe/London'}
            //         end = {'dateTime': pytz.utc.localize(self.stop).isoformat(), 'timeZone': 'Europe/London'}
            // 
            //     values['start'] = start
            //     values['end'] = end
            //     values['isAllDay'] = self.allday
            // 
            // if 'location' in fields_to_sync:
            //     values['location'] = {'displayName': self.location or ''}
            // 
            // if not self.location and 'videocall_location' in fields_to_sync and self._need_video_call():
            //     values['isOnlineMeeting'] = True
            //     values['onlineMeetingProvider'] = 'teamsForBusiness'
            // else:
            //     values['isOnlineMeeting'] = False
            // 
            // if 'alarm_ids' in fields_to_sync:
            //     alarm_id = self.alarm_ids.filtered(lambda a: a.alarm_type == 'notification')[:1]
            //     values['isReminderOn'] = bool(alarm_id)
            //     values['reminderMinutesBeforeStart'] = alarm_id.duration_minutes
            // 
            // if 'user_id' in fields_to_sync:
            //     values['organizer'] = {'emailAddress': {'address': self.user_id.email or '', 'name': self.user_id.display_name or ''}}
            //     values['isOrganizer'] = self.user_id == self.env.user
            // 
            // if 'attendee_ids' in fields_to_sync:
            //     attendees = self.attendee_ids.filtered(lambda att: att.partner_id not in self.user_id.partner_id)
            //     values['attendees'] = [
            //         {
            //             'emailAddress': {'address': attendee.email or '', 'name': attendee.display_name or ''},
            //             'status': {'response': self._get_attendee_status_o2m(attendee)}
            //         } for attendee in attendees]
            // 
            // if 'privacy' in fields_to_sync or 'show_as' in fields_to_sync:
            //     values['showAs'] = self.show_as
            //     sensitivity_o2m = {
            //         'public': 'normal',
            //         'private': 'private',
            //         'confidential': 'confidential',
            //     }
            //     # Set default privacy in event according to the organizer's calendar default privacy if defined.
            //     if self.user_id:
            //         sensitivity_o2m[False] = sensitivity_o2m.get(self.user_id.calendar_default_privacy)
            //     else:
            //         sensitivity_o2m[False] = 'normal'
            //     values['sensitivity'] = sensitivity_o2m.get(self.privacy)
            // 
            // if 'active' in fields_to_sync and not self.active:
            //     values['isCancelled'] = True
            // 
            // if values.get('type') == 'seriesMaster':
            //     recurrence = self.recurrence_id
            //     pattern = {
            //         'interval': recurrence.interval
            //     }
            //     if recurrence.rrule_type in ['daily', 'weekly']:
            //         pattern['type'] = recurrence.rrule_type
            //     else:
            //         prefix = 'absolute' if recurrence.month_by == 'date' else 'relative'
            //         pattern['type'] = recurrence.rrule_type and prefix + recurrence.rrule_type.capitalize()
            // 
            //     if recurrence.month_by == 'date':
            //         pattern['dayOfMonth'] = recurrence.day
            // 
            //     if recurrence.month_by == 'day' or recurrence.rrule_type == 'weekly':
            //         pattern['daysOfWeek'] = [
            //             weekday_name for weekday_name, weekday in {
            //                 'monday': recurrence.mon,
            //                 'tuesday': recurrence.tue,
            //                 'wednesday': recurrence.wed,
            //                 'thursday': recurrence.thu,
            //                 'friday': recurrence.fri,
            //                 'saturday': recurrence.sat,
            //                 'sunday': recurrence.sun,
            //             }.items() if weekday]
            //         pattern['firstDayOfWeek'] = 'sunday'
            // 
            //     if recurrence.rrule_type == 'monthly' and recurrence.month_by == 'day':
            //         byday_selection = {
            //             '1': 'first',
            //             '2': 'second',
            //             '3': 'third',
            //             '4': 'fourth',
            //             '-1': 'last',
            //         }
            //         pattern['index'] = byday_selection[recurrence.byday]
            // 
            //     dtstart = recurrence.dtstart or fields.Datetime.now()
            //     rule_range = {
            //         'startDate': (dtstart.date()).isoformat()
            //     }
            // 
            //     if recurrence.end_type == 'count':  # e.g. stop after X occurence
            //         rule_range['numberOfOccurrences'] = min(recurrence.count, MAX_RECURRENT_EVENT)
            //         rule_range['type'] = 'numbered'
            //     elif recurrence.end_type == 'forever':
            //         rule_range['numberOfOccurrences'] = MAX_RECURRENT_EVENT
            //         rule_range['type'] = 'numbered'
            //     elif recurrence.end_type == 'end_date':  # e.g. stop after 12/10/2020
            //         rule_range['endDate'] = recurrence.until.isoformat()
            //         rule_range['type'] = 'endDate'
            // 
            //     values['recurrence'] = {
            //         'pattern': pattern,
            //         'range': rule_range
            //     }
            // 
            // return values
            */
            return default;
        }

        protected async Task<CalendarEvent> MicrosoftValuesOccurenceInternalAsync(object initial_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _microsoft_values_occurence(self, initial_values={}):
            // values = initial_values
            // values['type'] = 'occurrence'
            // 
            // if self.allday:
            //     start = {'dateTime': self.start_date.isoformat(), 'timeZone': 'Europe/London'}
            //     end = {'dateTime': (self.stop_date + relativedelta(days=1)).isoformat(), 'timeZone': 'Europe/London'}
            // else:
            //     start = {'dateTime': pytz.utc.localize(self.start).isoformat(), 'timeZone': 'Europe/London'}
            //     end = {'dateTime': pytz.utc.localize(self.stop).isoformat(), 'timeZone': 'Europe/London'}
            // 
            // values['start'] = start
            // values['end'] = end
            // values['isAllDay'] = self.allday
            // 
            // return values
            */
            return default;
        }

        protected async Task<CalendarEvent> NeedVideoCallInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: calendar_event.py) ---
            // def _need_video_call(self):
            // """ Determine if the event needs a video call or not depending
            // on the model of the event.
            // 
            // This method, implemented and invoked in google_calendar, is necessary
            // due to the absence of a bridge module between google_calendar and hr_holidays.
            // """
            // self.ensure_one()
            // if self.res_model == 'hr.leave':
            //     return False
            // return super()._need_video_call()
            */
            return default;
        }

        protected async Task<CalendarEvent> OdooAttendeeCommandsInternalAsync(object google_event)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def _odoo_attendee_commands(self, google_event):
            // attendee_commands = []
            // partner_commands = []
            // google_attendees = google_event.attendees or []
            // if len(google_attendees) == 0 and google_event.organizer and google_event.organizer.get('self', False):
            //     user = google_event.owner(self.env)
            //     google_attendees += [{
            //         'email': user.partner_id.email,
            //         'responseStatus': 'accepted',
            //     }]
            // emails = [a.get('email') for a in google_attendees]
            // existing_attendees = self.env['calendar.attendee']
            // if google_event.exists(self.env):
            //     event = google_event.get_odoo_event(self.env)
            //     existing_attendees = event.attendee_ids
            // attendees_by_emails = {tools.email_normalize(a.email): a for a in existing_attendees}
            // partners = self._get_sync_partner(emails)
            // for attendee in zip(emails, partners, google_attendees):
            //     email = attendee[0]
            //     if email in attendees_by_emails:
            //         # Update existing attendees
            //         attendee_commands += [(1, attendees_by_emails[email].id, {'state': attendee[2].get('responseStatus')})]
            //     else:
            //         # Create new attendees
            //         if attendee[2].get('self'):
            //             partner = self.env.user.partner_id
            //         elif attendee[1]:
            //             partner = attendee[1]
            //         else:
            //             continue
            //         attendee_commands += [(0, 0, {'state': attendee[2].get('responseStatus'), 'partner_id': partner.id})]
            //         partner_commands += [(4, partner.id)]
            //         if attendee[2].get('displayName') and not partner.name:
            //             partner.name = attendee[2].get('displayName')
            // for odoo_attendee in attendees_by_emails.values():
            //     # Remove old attendees but only if it does not correspond to the current user.
            //     email = tools.email_normalize(odoo_attendee.email)
            //     if email not in emails and email != self.env.user.email:
            //         attendee_commands += [(2, odoo_attendee.id)]
            //         partner_commands += [(3, odoo_attendee.partner_id.id)]
            // return attendee_commands, partner_commands
            */
            return default;
        }

        protected async Task<CalendarEvent> OdooAttendeeCommandsMInternalAsync(object microsoft_event)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _odoo_attendee_commands_m(self, microsoft_event):
            // commands_attendee = []
            // commands_partner = []
            // 
            // microsoft_attendees = microsoft_event.attendees or []
            // emails = [
            //     a.get('emailAddress').get('address')
            //     for a in microsoft_attendees
            //     if email_normalize(a.get('emailAddress').get('address'))
            // ]
            // existing_attendees = self.env['calendar.attendee']
            // if microsoft_event.match_with_odoo_events(self.env):
            //     existing_attendees = self.env['calendar.attendee'].search([
            //         ('event_id', '=', microsoft_event.odoo_id(self.env)),
            //         ('email', 'in', emails)])
            // elif self.env.user.partner_id.email not in emails:
            //     commands_attendee += [(0, 0, {'state': 'accepted', 'partner_id': self.env.user.partner_id.id})]
            //     commands_partner += [(4, self.env.user.partner_id.id)]
            // partners = self.env['mail.thread']._mail_find_partner_from_emails(emails, records=self, force_create=True)
            // attendees_by_emails = {a.email: a for a in existing_attendees}
            // for email, partner, attendee_info in zip(emails, partners, microsoft_attendees):
            //     # Responses from external invitations are stored in the 'responseStatus' field.
            //     # This field only carries the current user's event status because Microsoft hides other user's status.
            //     if self.env.user.email == email and microsoft_event.responseStatus:
            //         attendee_microsoft_status = microsoft_event.responseStatus.get('response', 'none')
            //     else:
            //         attendee_microsoft_status = attendee_info.get('status').get('response')
            //     state = ATTENDEE_CONVERTER_M2O.get(attendee_microsoft_status, 'needsAction')
            // 
            //     if email in attendees_by_emails:
            //         # Update existing attendees
            //         commands_attendee += [(1, attendees_by_emails[email].id, {'state': state})]
            //     elif partner:
            //         # Create new attendees
            //         commands_attendee += [(0, 0, {'state': state, 'partner_id': partner.id})]
            //         commands_partner += [(4, partner.id)]
            //         if attendee_info.get('emailAddress').get('name') and not partner.name:
            //             partner.name = attendee_info.get('emailAddress').get('name')
            // for odoo_attendee in attendees_by_emails.values():
            //     # Remove old attendees
            //     if odoo_attendee.email not in emails:
            //         commands_attendee += [(2, odoo_attendee.id)]
            //         commands_partner += [(3, odoo_attendee.partner_id.id)]
            // return commands_attendee, commands_partner
            */
            return default;
        }

        protected async Task<CalendarEvent> OdooRemindersCommandsInternalAsync(object reminders)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def _odoo_reminders_commands(self, reminders=()):
            // commands = []
            // for reminder in reminders:
            //     alarm_type = 'email' if reminder.get('method') == 'email' else 'notification'
            //     alarm_type_label = _("Email") if alarm_type == 'email' else _("Notification")
            // 
            //     minutes = reminder.get('minutes', 0)
            //     alarm = self.env['calendar.alarm'].search([
            //         ('alarm_type', '=', alarm_type),
            //         ('duration_minutes', '=', minutes)
            //     ], limit=1)
            //     if alarm:
            //         commands += [(4, alarm.id)]
            //     else:
            //         if minutes % (60*24) == 0:
            //             interval = 'days'
            //             duration = minutes / 60 / 24
            //             name = _(
            //                 "%(reminder_type)s - %(duration)s Days",
            //                 reminder_type=alarm_type_label,
            //                 duration=duration,
            //             )
            //         elif minutes % 60 == 0:
            //             interval = 'hours'
            //             duration = minutes / 60
            //             name = _(
            //                 "%(reminder_type)s - %(duration)s Hours",
            //                 reminder_type=alarm_type_label,
            //                 duration=duration,
            //             )
            //         else:
            //             interval = 'minutes'
            //             duration = minutes
            //             name = _(
            //                 "%(reminder_type)s - %(duration)s Minutes",
            //                 reminder_type=alarm_type_label,
            //                 duration=duration,
            //             )
            //         commands += [(0, 0, {'duration': duration, 'interval': interval, 'name': name, 'alarm_type': alarm_type})]
            // return commands
            */
            return default;
        }

        protected async Task<CalendarEvent> OdooRemindersCommandsMInternalAsync(object microsoft_event)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _odoo_reminders_commands_m(self, microsoft_event):
            // reminders_commands = []
            // if microsoft_event.isReminderOn:
            //     event_id = self.browse(microsoft_event.odoo_id(self.env))
            //     alarm_type_label = _("Notification")
            // 
            //     minutes = microsoft_event.reminderMinutesBeforeStart or 0
            //     alarm = self.env['calendar.alarm'].search([
            //         ('alarm_type', '=', 'notification'),
            //         ('duration_minutes', '=', minutes)
            //     ], limit=1)
            //     if alarm and alarm not in event_id.alarm_ids:
            //         reminders_commands = [(4, alarm.id)]
            //     elif not alarm:
            //         if minutes == 0:
            //             interval = 'minutes'
            //             duration = minutes
            //             name = _("%s - At time of event", alarm_type_label)
            //         elif minutes % (60*24) == 0:
            //             interval = 'days'
            //             duration = minutes / 60 / 24
            //             name = _(
            //                 "%(reminder_type)s - %(duration)s Days",
            //                 reminder_type=alarm_type_label,
            //                 duration=duration,
            //             )
            //         elif minutes % 60 == 0:
            //             interval = 'hours'
            //             duration = minutes / 60
            //             name = _(
            //                 "%(reminder_type)s - %(duration)s Hours",
            //                 reminder_type=alarm_type_label,
            //                 duration=duration,
            //             )
            //         else:
            //             interval = 'minutes'
            //             duration = minutes
            //             name = _(
            //                 "%(reminder_type)s - %(duration)s Minutes",
            //                 reminder_type=alarm_type_label,
            //                 duration=duration,
            //             )
            //         reminders_commands = [(0, 0, {'duration': duration, 'interval': interval, 'name': name, 'alarm_type': 'notification'})]
            // 
            //     alarm_to_rm = event_id.alarm_ids.filtered(lambda a: a.alarm_type == 'notification' and a.id != alarm.id)
            //     if alarm_to_rm:
            //         reminders_commands += [(3, a.id) for a in alarm_to_rm]
            // 
            // else:
            //     event_id = self.browse(microsoft_event.odoo_id(self.env))
            //     alarm_to_rm = event_id.alarm_ids.filtered(lambda a: a.alarm_type == 'notification')
            //     if alarm_to_rm:
            //         reminders_commands = [(3, a.id) for a in alarm_to_rm]
            // return reminders_commands
            */
            return default;
        }

        protected async Task<CalendarEvent> OdooValuesInternalAsync(object google_event, object default_reminders)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def _odoo_values(self, google_event, default_reminders=()):
            // if google_event.is_cancelled():
            //     return {'active': False}
            // 
            // # default_reminders is never () it is set to google's default reminder (30 min before)
            // # we need to check 'useDefault' for the event to determine if we have to use google's
            // # default reminder or not
            // reminder_command = google_event.reminders.get('overrides')
            // if not reminder_command:
            //     reminder_command = google_event.reminders.get('useDefault') and default_reminders or ()
            // alarm_commands = self._odoo_reminders_commands(reminder_command)
            // attendee_commands, partner_commands = self._odoo_attendee_commands(google_event)
            // related_event = self.search([('google_id', '=', google_event.id)], limit=1)
            // name = google_event.summary or related_event and related_event.name or _("(No title)")
            // values = {
            //     'name': name,
            //     'description': google_event.description and tools.html_sanitize(google_event.description),
            //     'location': google_event.location,
            //     'user_id': google_event.owner(self.env).id,
            //     'privacy': google_event.visibility or False,
            //     'attendee_ids': attendee_commands,
            //     'alarm_ids': alarm_commands,
            //     'recurrency': google_event.is_recurrent(),
            //     'videocall_location': google_event.get_meeting_url(),
            //     'show_as': 'free' if google_event.is_available() else 'busy',
            //     'guests_readonly': not bool(google_event.guestsCanModify)
            // }
            // # Remove 'videocall_location' when not sent by Google, otherwise the local videocall will be discarded.
            // if not values.get('videocall_location'):
            //     values.pop('videocall_location', False)
            // if partner_commands:
            //     # Add partner_commands only if set from Google. The write method on calendar_events will
            //     # override attendee commands if the partner_ids command is set but empty.
            //     values['partner_ids'] = partner_commands
            // if not google_event.is_recurrence():
            //     values['google_id'] = google_event.id
            // if google_event.is_recurrent() and not google_event.is_recurrence():
            //     # Propagate the follow_recurrence according to the google result
            //     values['follow_recurrence'] = google_event.is_recurrence_follower()
            // if google_event.start.get('dateTime'):
            //     # starting from python3.7, use the new [datetime, date].fromisoformat method
            //     start = parse(google_event.start.get('dateTime')).astimezone(pytz.utc).replace(tzinfo=None)
            //     stop = parse(google_event.end.get('dateTime')).astimezone(pytz.utc).replace(tzinfo=None)
            //     values['allday'] = False
            // else:
            //     start = parse(google_event.start.get('date'))
            //     stop = parse(google_event.end.get('date')) - relativedelta(days=1)
            //     # Stop date should be exclusive as defined here https://developers.google.com/calendar/v3/reference/events#resource
            //     # but it seems that's not always the case for old event
            //     if stop < start:
            //         stop = parse(google_event.end.get('date'))
            //     values['allday'] = True
            // if related_event['start'] != start:
            //     values['start'] = start
            // if related_event['stop'] != stop:
            //     values['stop'] = stop
            // return values
            */
            return default;
        }

        protected async Task<CalendarEvent> OnchangeDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _onchange_date(self):
            // """ This onchange is required for cases where the stop/start is False and we set an allday event.
            //     The inverse method is not called in this case because start_date/stop_date are not used in any
            //     compute/related, so we need an onchange to set the start/stop values in the form view
            // """
            // for event in self:
            //     if event.stop_date and event.start_date:
            //         event.with_context(is_calendar_event_new=True).write({
            //             'start': fields.Datetime.from_string(event.start_date).replace(hour=8),
            //             'stop': fields.Datetime.from_string(event.stop_date).replace(hour=18),
            //         })
            */
            return default;
        }

        public async Task<CalendarEvent> OpenCalendarEventAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def action_open_calendar_event(self):
            // if self.res_model and self.res_id:
            //     return self.env[self.res_model].browse(self.res_id).get_formview_action()
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CalendarEvent> OpenComposerAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def action_open_composer(self):
            // if not self.partner_ids:
            //     raise UserError(_("There are no attendees on these events"))
            // template_id = self.env['ir.model.data']._xmlid_to_res_id('calendar.calendar_template_meeting_update', raise_if_not_found=False)
            // # The mail is sent with datetime corresponding to the sending user TZ
            // default_composition_mode = self.env.context.get('default_composition_mode', self.env.context.get('composition_mode', 'comment'))
            // compose_ctx = dict(
            //     default_composition_mode=default_composition_mode,
            //     default_model='calendar.event',
            //     default_res_ids=self.ids,
            //     default_template_id=template_id,
            //     default_partner_ids=self.partner_ids.ids,
            //     mail_tz=self.env.user.tz,
            // )
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Contact Attendees'),
            //     'view_mode': 'form',
            //     'res_model': 'mail.compose.message',
            //     'views': [(False, 'form')],
            //     'view_id': False,
            //     'target': 'new',
            //     'context': compose_ctx,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CalendarEvent> RangeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _range(self):
            // self.ensure_one()
            // return (self.start, self.stop)
            */
            return default;
        }

        protected async Task<CalendarEvent> RecreateEventDifferentOrganizerInternalAsync(object values, object sender_user)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _recreate_event_different_organizer(self, values, sender_user):
            // """ Copy current event values, delete it and recreate it with the new organizer user. """
            // self.ensure_one()
            // event_copy = {**self.copy_data()[0], 'microsoft_id': False}
            // self.env['calendar.event'].with_user(sender_user).create({**event_copy, **values})
            // if self.ms_universal_event_id:
            //     self._microsoft_delete(self._get_organizer(), self.microsoft_id)
            */
            return default;
        }

        protected async Task<CalendarEvent> ResetAttendeesStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _reset_attendees_status(self):
            // """ Reset attendees status to pending and accept event for current user. """
            // for attendee in self.attendee_ids:
            //     if attendee.partner_id == self.env.user.partner_id:
            //         attendee.state = 'accepted'
            //     else:
            //         attendee.state = 'needsAction'
            */
            return default;
        }

        protected async Task<CalendarEvent> RestartGoogleSyncInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def _restart_google_sync(self):
            // self.env['calendar.event'].search(self._get_sync_domain()).write({
            //     'need_sync': True,
            // })
            */
            return default;
        }

        protected async Task<CalendarEvent> RestartMicrosoftSyncInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _restart_microsoft_sync(self):
            // domain = self._get_microsoft_sync_domain()
            // 
            // self.env['calendar.event'].with_context(dont_notify=True).search(domain).write({
            //     'need_sync_m': True,
            // })
            */
            return default;
        }

        protected async Task<CalendarEvent> RewriteRecurrenceInternalAsync(object values, object time_values, object recurrence_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _rewrite_recurrence(self, values, time_values, recurrence_values):
            // """ Delete the current recurrence, reactivate base event and apply updated recurrence values. """
            // self.ensure_one()
            // base_event = self.recurrence_id.base_event_id or self.recurrence_id._get_first_event(include_outliers=False)
            // update_dict = self._get_time_update_dict(base_event, time_values)
            // time_values.update(update_dict)
            // 
            // if self._check_values_to_sync(values) or time_values or recurrence_values:
            //     # Get base values from the previous recurrence and update the start date weekday field.
            //     start_date = time_values['start'].date() if 'start' in time_values else self.start.date()
            //     old_recurrence_values = self._get_updated_recurrence_values(start_date)
            // 
            //     # Archive all events and delete recurrence, reactivate base event and apply updated values.
            //     base_event.action_mass_archive("all_events")
            //     base_event.recurrence_id.unlink()
            //     base_event.write({
            //         'active': True,
            //         'recurrence_id': False,
            //         **values, **time_values
            //     })
            // 
            //     if time_values:
            //         # Reset attendees state to pending and accept event for current user.
            //         base_event._reset_attendees_status()
            // 
            //     # Combine parameters from previous recurrence with the new recurrence parameters.
            //     new_values = {
            //         **old_recurrence_values,
            //         **base_event._get_recurrence_params(),
            //         **recurrence_values,
            //     }
            //     new_values.pop('rrule', None)
            // 
            //     # Patch base event with updated recurrence parameters: this will recreate the recurrence.
            //     detached_events = base_event._apply_recurrence_values(new_values)
            //     detached_events.write({'active': False})
            // else:
            //     # Write on all events. Carefull, it could trigger a lot of noise to Google/Microsoft...
            //     self.recurrence_id._write_events(values)
            */
            return default;
        }

        protected async Task<CalendarEvent> SearchCurrentAttendeeInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _search_current_attendee(self, operator, value):
            // return [("id", operator, value)]
            */
            return default;
        }

        public async Task<CalendarEvent> SendSmsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar_sms, FILE: calendar_event.py) ---
            // def action_send_sms(self):
            // if not self.partner_ids:
            //     raise UserError(_("There are no attendees on these events"))
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _("Send SMS"),
            //     'res_model': 'sms.composer',
            //     'view_mode': 'form',
            //     'target': 'new',
            //     'context': {
            //         'default_composition_mode': 'mass',
            //         'default_res_model': 'res.partner',
            //         'default_res_ids': self.partner_ids.ids,
            //         'default_mass_keep_log': True,
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CalendarEvent> SendmailAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def action_sendmail(self):
            // email = self.env.user.email
            // if email:
            //     self.attendee_ids._send_mail_to_attendees(
            //         self.env.ref('calendar.calendar_template_meeting_invitation', raise_if_not_found=False),
            //     )
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CalendarEvent> SetDiscussVideocallLocationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def set_discuss_videocall_location(self):
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CalendarEvent> SetDiscussVideocallLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _set_discuss_videocall_location(self):
            // """
            // This method sets the videocall_location to a discuss route.
            // If no access_token exists for this event, we create one.
            // Note that recurring events will have different access_tokens.
            // This is done by design to prevent users not being able to join a discuss meeting because the base event of the recurrency was deleted.
            // """
            // if not self.access_token:
            //     self.access_token = uuid.uuid4().hex
            // self.videocall_location = f"{self.get_base_url()}/{self.DISCUSS_ROUTE}/{self.access_token}"
            */
            return default;
        }

        protected async Task<CalendarEvent> SetVideocallLocationInternalAsync(object vals_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _set_videocall_location(self, vals_list):
            // for vals in vals_list:
            //     if not vals.get('videocall_location'):
            //         continue
            //     url = url_parse(vals['videocall_location'])
            //     if url.scheme in ('http', 'https'):
            //         continue
            //     # relative url to convert to absolute
            //     base = url_parse(self.get_base_url())
            //     vals['videocall_location'] = url.replace(scheme=base.scheme, netloc=base.netloc).to_url()
            */
            return default;
        }

        protected async Task<CalendarEvent> SetupAlarmsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _setup_alarms(self):
            // """ Schedule cron triggers for future events """
            // cron = self.env.ref('calendar.ir_cron_scheduler_alarm').sudo()
            // alarm_types = self._get_trigger_alarm_types()
            // events_to_notify = self.env['calendar.event']
            // triggers_by_events = {}
            // for event in self:
            //     existing_trigger = event.recurrence_id.trigger_id
            //     for alarm in (alarm for alarm in event.alarm_ids if alarm.alarm_type in alarm_types):
            //         at = event.start - timedelta(minutes=alarm.duration_minutes)
            //         create_trigger = not existing_trigger or existing_trigger and existing_trigger.call_at != at
            //         if create_trigger and (not cron.lastcall or at > cron.lastcall):
            //             # Don't trigger for past alarms, they would be skipped by design
            //             trigger = cron._trigger(at=at)
            //             triggers_by_events[event.id] = trigger.id
            //     if any(alarm.alarm_type == 'notification' for alarm in event.alarm_ids):
            //         # filter events before notifying attendees through calendar_alarm_manager
            //         events_to_notify |= event.filtered(lambda ev: ev.alarm_ids and ev.stop >= fields.Datetime.now())
            // if events_to_notify:
            //     self.env['calendar.alarm_manager']._notify_next_alarm(events_to_notify.partner_ids.ids)
            // return triggers_by_events
            */
            return default;
        }

        protected async Task<CalendarEvent> SkipSendMailStatusUpdateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _skip_send_mail_status_update(self):
            // """Overridable getter to identify whether to send invitation/cancelation emails."""
            // return False
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def _skip_send_mail_status_update(self):
            // """If a google calendar is not syncing with the user, don't send a mail."""
            // user_id = self._get_event_user()
            // if user_id.is_google_calendar_synced() and user_id.res_users_settings_id._is_google_calendar_valid():
            //     return True
            // return super()._skip_send_mail_status_update()
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _skip_send_mail_status_update(self):
            // """If microsoft calendar is not syncing, don't send a mail."""
            // user_id = self._get_event_user_m()
            // if self.with_user(user_id)._check_microsoft_sync_status() and user_id._get_microsoft_sync_status() == "sync_active":
            //     return self.microsoft_id or self.need_sync_m
            // return super()._skip_send_mail_status_update()
            */
            return default;
        }

        protected async Task<CalendarEvent> SplitRecurrenceInternalAsync(object time_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _split_recurrence(self, time_values):
            // """Apply time changes to events and update the recurrence accordingly.
            // 
            // :return: detached events
            // """
            // self.ensure_one()
            // if not time_values:
            //     return self.browse()
            // if self.follow_recurrence and self.recurrency:
            //     previous_week_day_field = weekday_to_field(self._get_start_date().weekday())
            // else:
            //     # When we try to change recurrence values of an event not following the recurrence, we get the parameters from
            //     # the base_event
            //     previous_week_day_field = weekday_to_field(self.recurrence_id.base_event_id._get_start_date().weekday())
            // self.write(time_values)
            // return self._apply_recurrence_values({
            //     previous_week_day_field: False,
            //     **self._get_recurrence_params(),
            // }, future=True)
            */
            return default;
        }

        protected async Task<CalendarEvent> SyncActivitiesInternalAsync(object fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _sync_activities(self, fields):
            // # update activities
            // for event in self:
            //     if event.activity_ids:
            //         activity_values = {}
            //         if 'name' in fields:
            //             activity_values['summary'] = event.name
            //         if 'description' in fields:
            //             activity_values['note'] = event.description
            //         if 'start' in fields:
            //             activity_values['date_deadline'] = self._get_activity_deadline_from_start(event.start, event.allday)
            //         if 'user_id' in fields:
            //             activity_values['user_id'] = event.user_id.id
            //         if activity_values.keys():
            //             event.activity_ids.write(activity_values)
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def unlink(self):
            // if not self:
            //     return super().unlink()
            // 
            // # Get concerned attendees to notify them if there is an alarm on the unlinked events,
            // # as it might have changed their next event notification
            // events = self.filtered_domain([('alarm_ids', '!=', False)])
            // partner_ids = events.mapped('partner_ids').ids
            // 
            // # don't forget to update recurrences if there are some base events in the set to unlink,
            // # but after having removed the events ;-)
            // recurrences = self.env["calendar.recurrence"].search([
            //     ('base_event_id', 'in', [e.id for e in self])
            // ])
            // 
            // result = super().unlink()
            // 
            // if recurrences:
            //     recurrences._select_new_base_event()
            // 
            // # Notify the concerned attendees (must be done after removing the events)
            // self.env['calendar.alarm_manager']._notify_next_alarm(partner_ids)
            // return result
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def unlink(self):
            // # Forbid recurrent events unlinking from calendar list view with sync active.
            // if self and self._check_microsoft_sync_status():
            //     synced_events = self._get_synced_events()
            //     change_from_microsoft = self.env.context.get('dont_notify', False)
            //     recurrence_deletion = any(ev.recurrency and ev.recurrence_id and ev.follow_recurrence for ev in synced_events)
            //     if not change_from_microsoft and recurrence_deletion:
            //         self._forbid_recurrence_update()
            // return super().unlink()
            */
            return await base.UnlinkAsync(ids);
        }

        protected async Task<CalendarEvent> UpdateAttendeeStatusInternalAsync(List<Guid> attendee_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _update_attendee_status(self, attendee_ids):
            // """ Merge current status from 'attendees_ids' with new attendees values for avoiding their info loss in write().
            // Create a dict getting the state of each attendee received from 'attendee_ids' variable and then update their state.
            // :param attendee_ids: List of attendee commands carrying a dict with 'partner_id' and 'state' keys in its third position.
            // """
            // state_by_partner = {}
            // for cmd in attendee_ids:
            //     if len(cmd) == 3 and isinstance(cmd[2], dict) and all(key in cmd[2] for key in ['partner_id', 'state']):
            //         state_by_partner[cmd[2]['partner_id']] = cmd[2]['state']
            // for attendee in self.attendee_ids:
            //     state_update = state_by_partner.get(attendee.partner_id.id)
            //     if state_update:
            //         attendee.state = state_update
            */
            return default;
        }

        protected async Task<CalendarEvent> UpdateFutureEventsInternalAsync(object values, object time_values, object recurrence_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _update_future_events(self, values, time_values, recurrence_values):
            // """
            //     Trim the current recurrence detaching the occurrences after current event,
            //     deactivate the detached events except for the updated event and apply recurrence values.
            // """
            // self.ensure_one()
            // base_event = self
            // update_dict = self._get_time_update_dict(base_event, time_values)
            // time_values.update(update_dict)
            // # Get base values from the previous recurrence and update the start date weekday field.
            // start_date = time_values['start'].date() if 'start' in time_values else self.start.date()
            // previous_recurrence_values = self._get_updated_recurrence_values(start_date)
            // 
            // # Trim previous recurrence at current event, deleting following events except for the updated event.
            // detached_events_split = self.recurrence_id._stop_at(self)
            // (detached_events_split - self).write({'active': False, **self._get_remove_sync_id_values()})
            // 
            // # Update the current event with the new recurrence information.
            // if values or time_values:
            //     self.write({
            //         **time_values, **values,
            //         **self._get_remove_sync_id_values(),
            //         **self._get_update_future_events_values()
            //     })
            //     if time_values:
            //         # Reset attendees state to pending and accept event for current user.
            //         self._reset_attendees_status()
            // 
            // # Combine parameters from previous recurrence with the new recurrence parameters.
            // new_values = {
            //     **previous_recurrence_values,
            //     **self._get_recurrence_params_by_date(start_date),
            //     **recurrence_values,
            //     'count': recurrence_values.get('count', 0) or len(detached_events_split)
            // }
            // new_values.pop('rrule', None)
            // 
            // # Generate the new recurrence by patching the updated event and return an empty list.
            // self._apply_recurrence_values(new_values)
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, CalendarEvent entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def write(self, values):
            // detached_events = self.env['calendar.event']
            // recurrence_update_setting = values.pop('recurrence_update', None)
            // update_recurrence = recurrence_update_setting in ('all_events', 'future_events') and len(self) == 1 and self.recurrence_id
            // break_recurrence = values.get('recurrency') is False
            // 
            // if any(vals in self._get_recurrent_fields() for vals in values) and not (update_recurrence or values.get('recurrency')):
            //     raise UserError(_('Unable to save the recurrence with "This Event"'))
            // 
            // # Check the privacy permissions of the events whose organizer is different from the current user.
            // self.filtered(lambda ev: ev.user_id and self.env.user != ev.user_id)._check_calendar_privacy_write_permissions()
            // 
            // update_alarms = False
            // update_time = False
            // self._set_videocall_location([values])
            // if 'partner_ids' in values:
            //     values['attendee_ids'] = self._attendees_values(values['partner_ids'])
            //     update_alarms = True
            //     if self.videocall_channel_id:
            //         new_partner_ids = []
            //         for command in values['partner_ids']:
            //             if command[0] == Command.LINK:
            //                 new_partner_ids.append(command[1])
            //             elif command[0] == Command.SET:
            //                 new_partner_ids.extend(command[2])
            //         self.videocall_channel_id.add_members(new_partner_ids)
            // 
            // time_fields = self.env['calendar.event']._get_time_fields()
            // if any([values.get(key) for key in time_fields]):
            //     update_alarms = True
            //     update_time = True
            // if 'alarm_ids' in values:
            //     update_alarms = True
            // 
            // if (not recurrence_update_setting or recurrence_update_setting == 'self_only' and len(self) == 1) and 'follow_recurrence' not in values:
            //     if any({field: values.get(field) for field in time_fields if field in values}):
            //         values['follow_recurrence'] = False
            // 
            // previous_attendees = self.attendee_ids
            // 
            // recurrence_values = {field: values.pop(field) for field in self._get_recurrent_fields() if field in values}
            // future_edge_case = recurrence_update_setting == 'future_events' and self == self.recurrence_id.base_event_id
            // if update_recurrence:
            //     if break_recurrence:
            //         # Update this event
            //         detached_events |= self._break_recurrence(future=recurrence_update_setting == 'future_events')
            //     else:
            //         time_values = {field: values.pop(field) for field in time_fields if field in values}
            //         if 'access_token' in values:
            //             values.pop('access_token')  # prevents copying access_token to other events in recurrency
            //         if recurrence_update_setting == 'all_events' or future_edge_case:
            //             # Update all events: we create a new reccurrence and dismiss the existing events
            //             self._rewrite_recurrence(values, time_values, recurrence_values)
            //         else:
            //             # Update future events: trim recurrence, delete remaining events except base event and recreate it
            //             # All the recurrent events processing is done within the following method
            //             self._update_future_events(values, time_values, recurrence_values)
            // else:
            //     super().write(values)
            //     self._sync_activities(fields=values.keys())
            // 
            // # We reapply recurrence for future events and when we add a rrule and 'recurrency' == True on the event
            // if recurrence_update_setting not in ['self_only', 'all_events'] and not future_edge_case and not break_recurrence:
            //     detached_events |= self._apply_recurrence_values(recurrence_values, future=recurrence_update_setting == 'future_events')
            // 
            // (detached_events & self).active = False
            // (detached_events - self).with_context(archive_on_error=True).unlink()
            // 
            // # Notify attendees if there is an alarm on the modified event, or if there was an alarm
            // # that has just been removed, as it might have changed their next event notification
            // if not self.env.context.get('dont_notify') and update_alarms:
            //     self.recurrence_id._setup_alarms(recurrence_update=True)
            //     if not self.recurrence_id:
            //         self._setup_alarms()
            // attendee_update_events = self.filtered(lambda ev: ev.user_id and ev.user_id != self.env.user)
            // if update_time and attendee_update_events:
            //     # Another user update the event time fields. It should not be auto accepted for the organizer.
            //     # This prevent weird behavior when a user modified future events time fields and
            //     # the base event of a recurrence is accepted by the organizer but not the following events
            //     attendee_update_events.attendee_ids.filtered(lambda att: self.user_id.partner_id == att.partner_id).write({'state': 'needsAction'})
            // 
            // current_attendees = self.filtered('active').attendee_ids
            // if 'partner_ids' in values:
            //     # we send to all partners and not only the new ones
            //     (current_attendees - previous_attendees)._send_mail_to_attendees(
            //         self.env.ref('calendar.calendar_template_meeting_invitation', raise_if_not_found=False),
            //         force_send=True,
            //     )
            // if not self.env.context.get('is_calendar_event_new') and 'start' in values:
            //     start_date = fields.Datetime.to_datetime(values.get('start'))
            //     # Only notify on future events
            //     if start_date and start_date >= fields.Datetime.now():
            //         (current_attendees & previous_attendees).with_context(
            //             calendar_template_ignore_recurrence=not update_recurrence
            //         )._send_mail_to_attendees(
            //             self.env.ref('calendar.calendar_template_meeting_changedate', raise_if_not_found=False),
            //             force_send=True,
            //         )
            // 
            // # Change base event when the main base event is archived. If it isn't done when trying to modify
            // # all events of the recurrence an error can be thrown or all the recurrence can be deleted.
            // if values.get("active") is False:
            //     recurrences = self.env["calendar.recurrence"].search([
            //         ('base_event_id', 'in', self.ids)
            //     ])
            //     recurrences._select_new_base_event()
            // 
            // return True
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar.py) ---
            // def write(self, values):
            // recurrence_update_setting = values.get('recurrence_update')
            // if recurrence_update_setting in ('all_events', 'future_events') and len(self) == 1:
            //     values = dict(values, need_sync=False)
            // notify_context = self.env.context.get('dont_notify', False)
            // if not notify_context and ([self.env.user.id != record.user_id.id for record in self]):
            //     self._check_modify_event_permission(values)
            // res = super(Meeting, self.with_context(dont_notify=notify_context)).write(values)
            // if recurrence_update_setting in ('all_events',) and len(self) == 1 and values.keys() & self._get_google_synced_fields():
            //     self.recurrence_id.need_sync = True
            // return res
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def write(self, values):
            // recurrence_update_setting = values.get('recurrence_update')
            // notify_context = self.env.context.get('dont_notify', False)
            // 
            // # Forbid recurrence updates through Odoo and suggest user to update it in Outlook.
            // if self._check_microsoft_sync_status():
            //     recurrency_in_batch = self.filtered(lambda ev: ev.recurrency)
            //     recurrence_update_attempt = recurrence_update_setting or 'recurrency' in values or recurrency_in_batch and len(recurrency_in_batch) > 0
            //     if not notify_context and recurrence_update_attempt and not 'active' in values:
            //         self._forbid_recurrence_update()
            // 
            // # When changing the organizer, check its sync status and verify if the user is listed as attendee.
            // # Updates from Microsoft must skip this check since changing the organizer on their side is not possible.
            // change_from_microsoft = self.env.context.get('dont_notify', False)
            // deactivated_events_ids = []
            // for event in self:
            //     if values.get('user_id') and event.user_id.id != values['user_id'] and not change_from_microsoft:
            //         sender_user, partner_ids = event._get_organizer_user_change_info(values)
            //         partner_included = sender_user.partner_id in event.attendee_ids.partner_id or sender_user.partner_id.id in partner_ids
            //         event._check_organizer_validation(sender_user, partner_included)
            //         if event.microsoft_id:
            //             event._recreate_event_different_organizer(values, sender_user)
            //             deactivated_events_ids.append(event.id)
            // 
            // # check a Outlook limitation in overlapping the actual recurrence
            // if recurrence_update_setting == 'self_only' and 'start' in values:
            //     self._check_recurrence_overlapping(values['start'])
            // 
            // # if a single event becomes the base event of a recurrency, it should be first
            // # removed from the Outlook calendar. Additionaly, checks if synchronization is not paused.
            // if self.env.user._get_microsoft_sync_status() != "sync_paused" and values.get('recurrency'):
            //     for event in self:
            //         if not event.recurrency and not event.recurrence_id:
            //             event._microsoft_delete(event._get_organizer(), event.microsoft_id, timeout=3)
            //             event.microsoft_id = False
            //             event.ms_universal_event_id = False
            // 
            // deactivated_events = self.browse(deactivated_events_ids)
            // # Update attendee status before 'values' variable is overridden in super.
            // attendee_ids = values.get('attendee_ids')
            // if attendee_ids and values.get('partner_ids'):
            //     (self - deactivated_events)._update_attendee_status(attendee_ids)
            // 
            // res = super(Meeting, (self - deactivated_events).with_context(dont_notify=notify_context)).write(values)
            // 
            // # Deactivate events that were recreated after changing organizer.
            // if deactivated_events:
            //     res |= super(Meeting, deactivated_events.with_context(dont_notify=notify_context)).write({**values, 'active': False})
            // 
            // if recurrence_update_setting in ('all_events',) and len(self) == 1 \
            //    and values.keys() & self._get_microsoft_synced_fields():
            //     self.recurrence_id.need_sync_m = True
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}