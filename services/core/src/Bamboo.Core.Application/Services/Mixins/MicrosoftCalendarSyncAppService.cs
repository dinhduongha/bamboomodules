using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("microsoft_calendar", Depends = new[] { "microsoft_account", "calendar" })]
    public class MicrosoftCalendarSyncAppService : ApplicationService, IMicrosoftCalendarSyncAppService
    {

        public MicrosoftCalendarSyncAppService() 
        {

        }

        public async Task<TEntity> ApplyRecurrenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object specific_values_creation, object no_send_edit, object generic_values_creation) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
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

        public async Task<TEntity> ApplyRecurrenceValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values, object future) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> AttendeesValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_commands) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> BreakRecurrenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object future) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> CancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _cancel(self):
            // self.calendar_event_ids._cancel()
            // super()._cancel()
            */
            return default;
        }

        public async Task<TEntity> CancelMicrosoftInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _cancel_microsoft(self):
            // self.calendar_event_ids.with_context(dont_notify=True)._cancel_microsoft()
            // super()._cancel_microsoft()
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _cancel_microsoft(self):
            // self.microsoft_id = False
            // self.ms_universal_event_id = False
            // self.unlink()
            */
            return default;
        }

        public async Task<TEntity> ChangeAttendeeStatusAsync<TEntity>(IEnumerable<TEntity> entities, object status, object recurrence_update_setting) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            return default;
        }

        public async Task<TEntity> CheckCalendarPrivacyWritePermissionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> CheckClosingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> CheckEmployeesAvailabilityForEventInternalAsync<TEntity>(IEnumerable<TEntity> entities, object schedule_by_partner, object event_interval) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> CheckMicrosoftSyncStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> CheckModifyEventPermissionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> CheckOldEventUpdateRequiredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lower_bound_day_range, object update_time_diff) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _check_old_event_update_required(self, lower_bound_day_range, update_time_diff):
            // """
            // Checks if an old event in Odoo should be updated locally. This verification is necessary because
            // sometimes events in Odoo have the same state in Microsoft and even so they trigger updates locally
            // due to a second or less of update time difference, thus spamming unwanted emails on Microsoft side.
            // """
            // # Event can be updated locally if its stop date is bigger than lower bound and the update time difference is reasonable (1 hour).
            // # For recurrences, if any of the occurrences surpass the lower bound range, we update the recurrence.
            // lower_bound = fields.Datetime.subtract(fields.Datetime.now(), days=lower_bound_day_range)
            // stop_date_condition = True
            // if self._name == 'calendar.event':
            //     stop_date_condition = self.stop >= lower_bound
            // elif self._name == 'calendar.recurrence':
            //     stop_date_condition = any(event.stop >= lower_bound for event in self.calendar_event_ids)
            // return stop_date_condition or update_time_diff >= timedelta(hours=1)
            */
            return default;
        }

        public async Task<TEntity> CheckOrganizerValidationConditionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> CheckOrganizerValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sender_user, object partner_included) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> CheckPrivateEventConditionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> CheckRecurrenceOverlappingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_start) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> CheckValuesToSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ClearVideocallLocationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def clear_videocall_location(self):
            // return True
            */
            return default;
        }

        public async Task<TEntity> ComputeAttendeesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ComputeCandidateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ComputeCurrentAttendeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ComputeDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ComputeDisplayDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_display_description(self):
            // for event in self:
            //     event.display_description = not is_html_empty(event.description)
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ComputeDisplayTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_display_time(self):
            // for meeting in self:
            //     meeting.display_time = self._get_display_time(meeting.start, meeting.stop, meeting.duration, meeting.allday)
            */
            return default;
        }

        public async Task<TEntity> ComputeDtstartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ComputeDurationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_duration(self):
            // for event in self:
            //     event.duration = self._get_duration(event.start, event.stop)
            */
            return default;
        }

        public async Task<TEntity> ComputeFieldValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ComputeGoogleIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ComputeInvalidEmailPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ComputeIsHighlightedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ComputeIsOrganizerAloneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _compute_name(self):
            // for recurrence in self:
            //     recurrence.name = recurrence.get_recurrence_name()
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurrenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ComputeRruleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
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

        public async Task<TEntity> ComputeRruleTypeUiInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ComputeShouldShowStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _compute_should_show_status(self):
            // for event in self:
            //     event.should_show_status = event.current_attendee and any(attendee.partner_id != self.env.user.partner_id for attendee in event.attendee_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeStopInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ComputeUnavailablePartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ComputeUserCanEditInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ComputeVideocallLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ComputeVideocallSourceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def copy(self, default=None):
            // """When an event is copied, the attendees should be recreated to avoid sharing the same attendee records
            //  between copies
            //  """
            // default = dict(default or {})
            // # We need to make sure that the attendee_ids are recreated with new ids to avoid sharing attendees between events
            // # The copy should not have the same attendee status than the original event
            // default.update(partner_ids=[Command.set([])], attendee_ids=[Command.set([])])
            // new_events = super().copy(default)
            // for old_event, new_event in zip(self, new_events):
            //     new_event.write({'partner_ids': [(Command.set(old_event.partner_ids.ids))]})
            // return new_events
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
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
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def create(self, vals_list):
            // if self.env.user.microsoft_synchronization_stopped:
            //     for vals in vals_list:
            //         vals.update({'need_sync_m': False})
            // records = super().create(vals_list)
            // 
            // if self.env.user._get_microsoft_sync_status() != "sync_paused":
            //     for record in records:
            //         if record.need_sync_m and record.active:
            //             record._microsoft_insert(record._microsoft_values(self._get_microsoft_synced_fields()), timeout=3)
            // return records
            */
            return default;
        }

        public async Task<TEntity> CreateFromGoogleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object gevents, object vals_list) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> CreateFromMicrosoftInternalAsync<TEntity>(IEnumerable<TEntity> entities, object microsoft_event, object vals_list) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _create_from_microsoft(self, microsoft_event, vals_list):
            // return self.with_context(dont_notify=True).create(vals_list)
            */
            return default;
        }

        public async Task<TEntity> CreateVideocallChannelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> CreateVideocallChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            return default;
        }

        public async Task<TEntity> DefaultPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> DefaultStartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _default_start(self):
            // now = fields.Datetime.now()
            // return now + (datetime.min - now) % timedelta(minutes=30)
            */
            return default;
        }

        public async Task<TEntity> DefaultStopInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> DetachEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object events) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> DoSmsReminderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object alarms) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> EnsureAttendeesHaveEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _ensure_attendees_have_email(self):
            // self.calendar_event_ids.filtered(lambda e: e.active)._ensure_attendees_have_email()
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _ensure_attendees_have_email(self):
            // raise NotImplementedError()
            */
            return default;
        }

        public async Task<TEntity> ExtendMicrosoftDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _extend_microsoft_domain(self, domain):
            // """ Extends the sync domain based on the full_sync_m context parameter.
            // In case of full sync it shouldn't include already synced events.
            // """
            // if self._context.get('full_sync_m', True):
            //     domain = expression.AND([domain, [('ms_universal_event_id', '=', False)]])
            // else:
            //     is_active_clause = (self._active_name, '=', True) if self._active_name else expression.TRUE_LEAF
            //     domain = expression.AND([domain, [
            //         '|',
            //         '&', ('ms_universal_event_id', '=', False), is_active_clause,
            //         ('need_sync_m', '=', True),
            //     ]])
            // # Sync only events created/updated after last sync date (with 5 min of time acceptance).
            // if self.env.user.microsoft_last_sync_date:
            //     time_offset = timedelta(minutes=5)
            //     domain = expression.AND([domain, [('write_date', '>=', self.env.user.microsoft_last_sync_date - time_offset)]])
            // return domain
            */
            return default;
        }

        public async Task<TEntity> FetchQueryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object query, object fields) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> FindPartnerCustomerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            return default;
        }

        public async Task<TEntity> ForbidRecurrenceCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ForbidRecurrenceUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetActivityDeadlineFromStartInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object allday) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetActivityExcludedModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetArchiveValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetAttendeeEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetAttendeeStatusO2mInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attendee) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetCustomFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_custom_fields(self):
            // all_fields = self.fields_get(attributes=['manual'])
            // return {fname for fname in all_fields if all_fields[fname]['manual']}
            */
            return default;
        }

        public async Task<TEntity> GetCustomerDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_customer_description(self):
            // """:return (html): Sanitized HTML description for customer to include in calendar exports"""
            // return html_sanitize(self.description) if not is_html_empty(self.description) else ''
            */
            return default;
        }

        public async Task<TEntity> GetCustomerSummaryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_customer_summary(self):
            // """:return (str): The summary to include in calendar exports"""
            // return self.name or ''
            */
            return default;
        }

        public async Task<TEntity> GetDailyRecurrenceNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetDateFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetDefaultDurationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            return default;
        }

        public async Task<TEntity> GetDefaultPrivacyDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetDiscussVideocallLocationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def get_discuss_videocall_location(self):
            // access_token = uuid.uuid4().hex
            // return f"{self.get_base_url()}/{self.DISCUSS_ROUTE}/{access_token}"
            */
            return default;
        }

        public async Task<TEntity> GetDisplayTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object zduration, object zallday) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetDisplayTimeTzAsync<TEntity>(IEnumerable<TEntity> entities, object tz) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            return default;
        }

        public async Task<TEntity> GetDurationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetEventGoogleIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @event) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetEventUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetEventUserMInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _get_event_user_m(self, user_id=None):
            // """ Get the user who will send the request to Microsoft (organizer if synchronized and current user otherwise). """
            // self.ensure_one()
            // event = self._get_first_event()
            // if event:
            //     return event._get_event_user_m(user_id)
            // return self.env.user
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _get_event_user_m(self, user_id=None):
            // """ Return the correct user to send the request to Microsoft.
            // It's possible that a user creates an event and sets another user as the organizer. Using self.env.user will
            // cause some issues, and it might not be possible to use this user for sending the request, so this method gets
            // the appropriate user accordingly.
            // """
            // raise NotImplementedError()
            */
            return default;
        }

        public async Task<TEntity> GetEventsFromInternalAsync<TEntity>(IEnumerable<TEntity> entities, object dtstart) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetEventsIntervalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetFirstEventInternalAsync<TEntity>(IEnumerable<TEntity> entities, object include_outliers) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetGoogleSyncedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _get_google_synced_fields(self):
            // return {'rrule'}
            */
            return default;
        }

        public async Task<TEntity> GetIcsFileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetLangWeekStartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetMailMessageAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object operation, object model_name) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetMailTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_mail_tz(self):
            // self.ensure_one()
            // return self.event_tz or self.env.user.tz
            */
            return default;
        }

        public async Task<TEntity> GetMicrosoftRecordsToSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object full_sync) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _get_microsoft_records_to_sync(self, full_sync=False):
            // """
            // Return records that should be synced from Odoo to Microsoft
            // :param full_sync: If True, all events attended by the user are returned
            // :return: events
            // """
            // domain = self.with_context(full_sync_m=full_sync)._get_microsoft_sync_domain()
            // return self.with_context(active_test=False).search(domain)
            */
            return default;
        }

        public async Task<TEntity> GetMicrosoftServiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _get_microsoft_service(self):
            // return MicrosoftCalendarService(self.env['microsoft.service'])
            */
            return default;
        }

        public async Task<TEntity> GetMicrosoftSyncDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _get_microsoft_sync_domain(self):
            // # Do not sync Odoo recurrences with Outlook Calendar anymore.
            // domain = expression.FALSE_DOMAIN
            // return self._extend_microsoft_domain(domain)
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _get_microsoft_sync_domain(self):
            // """
            // Return a domain used to search records to synchronize.
            // e.g. return a domain to synchronize records owned by the current user.
            // """
            // raise NotImplementedError()
            */
            return default;
        }

        public async Task<TEntity> GetMicrosoftSyncedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _get_microsoft_synced_fields(self):
            // return {'name', 'description', 'allday', 'start', 'date_end', 'stop',
            //         'user_id', 'privacy',
            //         'attendee_ids', 'alarm_ids', 'location', 'show_as', 'active', 'videocall_location'}
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _get_microsoft_synced_fields(self):
            // return {'rrule'} | self.env['calendar.event']._get_microsoft_synced_fields()
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _get_microsoft_synced_fields(self):
            // """
            // Return a set of field names. Changing one of these fields
            // marks the record to be re-synchronized.
            // """
            // raise NotImplementedError()
            */
            return default;
        }

        public async Task<TEntity> GetMonthlyRecurrenceNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetNextAlarmDateAsync<TEntity>(IEnumerable<TEntity> entities, object events_by_alarm) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            return default;
        }

        public async Task<TEntity> GetOccurrencesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object dtstart) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetOrganizerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _get_organizer(self):
            // return self.user_id
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _get_organizer(self):
            // return self.base_event_id.user_id
            */
            return default;
        }

        public async Task<TEntity> GetOrganizerUserChangeInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetOutliersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetPublicFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetRangesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object event_duration) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _get_ranges(self, start, event_duration):
            // starts = self._get_occurrences(start)
            // return ((start, start + event_duration) for start in starts)
            */
            return default;
        }

        public async Task<TEntity> GetRecurrenceNameAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            return default;
        }

        public async Task<TEntity> GetRecurrenceParamsByDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object event_date) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetRecurrenceParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetRecurrentFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetRemoveSyncIdValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetRruleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object dtstart) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _get_rrule(self, dtstart=None):
            // if not dtstart and self.dtstart:
            //     dtstart = self.dtstart
            // return super()._get_rrule(dtstart)
            */
            return default;
        }

        public async Task<TEntity> GetStartDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetStartOfPeriodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object dt) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetStateSelectionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def get_state_selections(self):
            // return Attendee.STATE_SELECTION
            */
            return default;
        }

        public async Task<TEntity> GetSyncDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetSyncedEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _get_synced_events(self):
            // """
            // Get events already synced with Microsoft Outlook.
            // """
            // return self.filtered(lambda e: e.ms_universal_event_id)
            */
            return default;
        }

        public async Task<TEntity> GetTimeFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _get_time_fields(self):
            // return {'start', 'stop', 'start_date', 'stop_date'}
            */
            return default;
        }

        public async Task<TEntity> GetTimeUpdateDictInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_event, object time_values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_recurrence.py) ---
            // def _get_timezone(self):
            // return pytz.timezone(self.event_tz or self.env.context.get('tz') or 'UTC')
            */
            return default;
        }

        public async Task<TEntity> GetTriggerAlarmTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetUnusualDaysAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_calendar, FILE: calendar_event.py) ---
            // def get_unusual_days(self, date_from, date_to=None):
            // return self.env.user.employee_id._get_unusual_days(date_from, date_to)
            */
            return default;
        }

        public async Task<TEntity> GetUpdateFutureEventsValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetUpdatedRecurrenceValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_start_date) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetWeekDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetWeeklyRecurrenceNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GetYearlyRecurrenceNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> GoogleValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> HasBaseEventTimeFieldsChangedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @new) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> InverseDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> InverseRruleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
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

        public async Task<TEntity> IsAlldayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> IsCrmLeadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object defaults, object ctx) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> IsEventOverInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> IsGoogleInsertionBlockedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sender_user) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> IsMatchingTimeslotInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object allday) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> IsMicrosoftInsertionBlockedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sender_user) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _is_microsoft_insertion_blocked(self, sender_user):
            // self.ensure_one()
            // has_different_owner = self.user_id and self.user_id != sender_user
            // return has_different_owner
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _is_microsoft_insertion_blocked(self, sender_user):
            // self.ensure_one()
            // has_base_event = self.base_event_id
            // has_different_owner = self.base_event_id.user_id and self.base_event_id.user_id != sender_user
            // return has_base_event and has_different_owner
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _is_microsoft_insertion_blocked(self, sender_user):
            // """
            // Returns True if the record insertion to Microsoft should be blocked.
            // This is a necessary step for ensuring data match between Odoo and Microsoft,
            // as it prevents attendees to synchronize new records on behalf of the owners,
            // otherwise the event ownership would be lost in Outlook and it would block the
            // future record synchronization for the original owner.
            // """
            // raise NotImplementedError()
            */
            return default;
        }

        public async Task<TEntity> JoinMeetingAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            return default;
        }

        public async Task<TEntity> JoinVideoCallAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            return default;
        }

        public async Task<TEntity> MassArchiveAsync<TEntity>(IEnumerable<TEntity> entities, object recurrence_update_setting) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def action_mass_archive(self, recurrence_update_setting):
            // # Do not allow archiving if recurrence is synced with Outlook. Suggest updating directly from Outlook.
            // self.ensure_one()
            // if self._check_microsoft_sync_status() and self.microsoft_id:
            //     self._forbid_recurrence_update()
            // super().action_mass_archive(recurrence_update_setting)
            */
            return default;
        }

        public async Task<TEntity> MassDeletionAsync<TEntity>(IEnumerable<TEntity> entities, object recurrence_update_setting) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            return default;
        }

        public async Task<TEntity> MicrosoftAttendeeAnswerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object answer, object @params, object timeout) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _microsoft_attendee_answer(self, answer, params, timeout=TIMEOUT):
            // if not answer:
            //     return
            // microsoft_service = self._get_microsoft_service()
            // with microsoft_calendar_token(self.env.user.sudo()) as token:
            //     if token:
            //         self._ensure_attendees_have_email()
            //         # Fetch the event's id (ms_organizer_event_id) using its iCalUId (ms_universal_event_id) since the
            //         # former differs for each attendee. This info is required for sending the event answer and Odoo currently
            //         # saves the event's id of the last user who synced the event (who might be or not the current user).
            //         status, event = microsoft_service._get_single_event(self.ms_universal_event_id, token=token)
            //         if status and event and event.get('value') and len(event.get('value')) == 1:
            //             # Send the attendee answer with its own ms_organizer_event_id.
            //             res = microsoft_service.answer(
            //                 event.get('value')[0].get('id'),
            //                 answer, params, token=token, timeout=timeout
            //             )
            //             self.need_sync_m = not res
            */
            return default;
        }

        public async Task<TEntity> MicrosoftDeleteInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, Guid event_id, object timeout) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _microsoft_delete(self, user_id, event_id, timeout=TIMEOUT):
            // """
            // Once the event has been really removed from the Odoo database, remove it from the Outlook calendar.
            // 
            // Note that all self attributes to use in this method must be provided as method parameters because
            // 'self' won't exist when this method will be really called due to @after_commit decorator.
            // """
            // microsoft_service = self._get_microsoft_service()
            // sender_user = self._get_event_user_m(user_id)
            // with microsoft_calendar_token(sender_user.sudo()) as token:
            //     if token and not sender_user.microsoft_synchronization_stopped:
            //         microsoft_service.delete(event_id, token=token, timeout=timeout)
            */
            return default;
        }

        public async Task<TEntity> MicrosoftInsertInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values, object timeout) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _microsoft_insert(self, values, timeout=TIMEOUT):
            // """
            // Once the event has been really added in the Odoo database, add it in the Outlook calendar.
            // 
            // Note that all self attributes to use in this method must be provided as method parameters because
            // 'self' may have been modified between the call of '_microsoft_insert' and its execution,
            // due to @after_commit decorator.
            // """
            // if not values:
            //     return
            // microsoft_service = self._get_microsoft_service()
            // sender_user = self._get_event_user_m()
            // with microsoft_calendar_token(sender_user.sudo()) as token:
            //     if token:
            //         self._ensure_attendees_have_email()
            //         event_id, uid = microsoft_service.insert(values, token=token, timeout=timeout)
            //         self.with_context(dont_notify=True).write({
            //             'microsoft_id': event_id,
            //             'ms_universal_event_id': uid,
            //             'need_sync_m': False,
            //         })
            */
            return default;
        }

        public async Task<TEntity> MicrosoftPatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, Guid event_id, object values, object timeout) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _microsoft_patch(self, user_id, event_id, values, timeout=TIMEOUT):
            // """
            // Once the event has been really modified in the Odoo database, modify it in the Outlook calendar.
            // 
            // Note that all self attributes to use in this method must be provided as method parameters because
            // 'self' may have been modified between the call of '_microsoft_patch' and its execution,
            // due to @after_commit decorator.
            // """
            // microsoft_service = self._get_microsoft_service()
            // sender_user = self._get_event_user_m(user_id)
            // with microsoft_calendar_token(sender_user.sudo()) as token:
            //     if token:
            //         self._ensure_attendees_have_email()
            //         res = microsoft_service.patch(event_id, values, token=token, timeout=timeout)
            //         self.with_context(dont_notify=True).write({
            //             'need_sync_m': not res,
            //         })
            */
            return default;
        }

        public async Task<TEntity> MicrosoftToOdooRecurrenceValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object microsoft_event, object default_values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> MicrosoftToOdooValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object microsoft_event, object default_reminders, object default_values, List<Guid> with_ids) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _microsoft_to_odoo_values(
            //     self, microsoft_event: MicrosoftEvent, default_reminders=(), default_values=None, with_ids=False
            // ):
            //     """
            //     Implements this method to return a dict of Odoo values corresponding
            //     to the Microsoft event given as parameter
            //     :return: dict of Odoo formatted values
            //     """
            //     raise NotImplementedError()
            */
            return default;
        }

        public async Task<TEntity> MicrosoftValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_sync) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _microsoft_values(self, fields_to_sync):
            // """
            // Get values to update the whole Outlook event recurrence.
            // (done through the first event of the Outlook recurrence).
            // """
            // return self.base_event_id._microsoft_values(fields_to_sync, initial_values={'type': 'seriesMaster'})
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _microsoft_values(self, fields_to_sync):
            // """
            // Implements this method to return a dict with values formatted
            // according to the Microsoft Calendar API
            // :return: dict of Microsoft formatted values
            // """
            // raise NotImplementedError()
            */
            return default;
        }

        public async Task<TEntity> MicrosoftValuesOccurenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object initial_values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> NeedVideoCallInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _need_video_call(self):
            // """
            // Implement this method to return True if the event needs a video call
            // :return: bool
            // """
            // self.ensure_one()
            // return True
            */
            return default;
        }

        public async Task<TEntity> OdooAttendeeCommandsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object google_event) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> OdooAttendeeCommandsMInternalAsync<TEntity>(IEnumerable<TEntity> entities, object microsoft_event) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> OdooRemindersCommandsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reminders) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> OdooRemindersCommandsMInternalAsync<TEntity>(IEnumerable<TEntity> entities, object microsoft_event) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> OdooValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object google_recurrence, object default_reminders) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> OnchangeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> OpenCalendarEventAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def action_open_calendar_event(self):
            // if self.res_model and self.res_id:
            //     return self.env[self.res_model].browse(self.res_id).get_formview_action()
            // return False
            */
            return default;
        }

        public async Task<TEntity> OpenComposerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            return default;
        }

        public async Task<TEntity> RangeCalculationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @event, object duration) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> RangeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _range(self):
            // self.ensure_one()
            // return (self.start, self.stop)
            */
            return default;
        }

        public async Task<TEntity> ReadGroupAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object fields, object groupby, object offset, object limit, object @orderby, object lazy) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def read_group(self, domain, fields, groupby, offset=0, limit=None, orderby=False, lazy=True):
            // groupby = [groupby] if isinstance(groupby, str) else groupby
            // fields_aggregates = [
            //     field_name for field_name in (fields or list(self._fields))
            //     if ':' in field_name or (field_name in self and self._fields[field_name].aggregator)
            // ]
            // grouped_fields = {group_field.split(':')[0] for group_field in groupby + fields_aggregates}
            // private_fields = grouped_fields - self._get_public_fields()
            // if not self.env.su and private_fields:
            //     domain = AND([domain, self._get_default_privacy_domain()])
            //     return super(Meeting, self).read_group(domain, fields, groupby, offset=offset, limit=limit, orderby=orderby, lazy=lazy)
            // return super(Meeting, self).read_group(domain, fields, groupby, offset=offset, limit=limit, orderby=orderby, lazy=lazy)
            */
            return default;
        }

        public async Task<TEntity> ReconcileEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ranges) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> RecreateEventDifferentOrganizerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values, object sender_user) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> ResetAttendeesStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> RestartGoogleSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> RestartMicrosoftSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar.py) ---
            // def _restart_microsoft_sync(self):
            // domain = self._get_microsoft_sync_domain()
            // 
            // self.env['calendar.event'].with_context(dont_notify=True).search(domain).write({
            //     'need_sync_m': True,
            // })
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _restart_microsoft_sync(self):
            // self.env['calendar.recurrence'].search(self._get_microsoft_sync_domain()).write({
            //     'need_sync_m': True,
            // })
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _restart_microsoft_sync(self):
            // """ Turns on the microsoft synchronization for all the events of
            // a given user.
            // """
            // raise NotImplementedError()
            */
            return default;
        }

        public async Task<TEntity> RewriteRecurrenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values, object time_values, object recurrence_values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> RruleParseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rule_str, object date_start) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> RruleSerializeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> SearchCurrentAttendeeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def _search_current_attendee(self, operator, value):
            // return [("id", operator, value)]
            */
            return default;
        }

        public async Task<TEntity> SelectNewBaseEventInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> SendSmsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            return default;
        }

        public async Task<TEntity> SendmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            return default;
        }

        public async Task<TEntity> SetDiscussVideocallLocationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py) ---
            // def set_discuss_videocall_location(self):
            // return True
            */
            return default;
        }

        public async Task<TEntity> SetDiscussVideocallLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> SetVideocallLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> SetupAlarmsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object recurrence_update) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> SkipSendMailStatusUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
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

        public async Task<TEntity> SplitFromInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @event, object recurrence_values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
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

        public async Task<TEntity> SplitRecurrenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object time_values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> StopAtInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @event) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> SyncActivitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> SyncMicrosoft2odooInternalAsync<TEntity>(IEnumerable<TEntity> entities, object microsoft_events) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _sync_microsoft2odoo(self, microsoft_events: MicrosoftEvent):
            // """
            // Synchronize Microsoft recurrences in Odoo.
            // Creates new recurrences, updates existing ones.
            // :return: synchronized odoo
            // """
            // existing = microsoft_events.match_with_odoo_events(self.env)
            // cancelled = microsoft_events.cancelled()
            // new = microsoft_events - existing - cancelled
            // new_recurrence = new.filter(lambda e: e.is_recurrent())
            // 
            // # create new events and reccurrences
            // odoo_values = [
            //     dict(self._microsoft_to_odoo_values(e, with_ids=True), need_sync_m=False)
            //     for e in (new - new_recurrence)
            // ]
            // synced_events = self.with_context(dont_notify=True)._create_from_microsoft(new, odoo_values)
            // synced_recurrences, updated_events = self._sync_recurrence_microsoft2odoo(existing, new_recurrence)
            // synced_events |= updated_events
            // 
            // # remove cancelled events and recurrences
            // cancelled_recurrences = self.env['calendar.recurrence'].search([
            //     '|',
            //     ('ms_universal_event_id', 'in', cancelled.uids),
            //     ('microsoft_id', 'in', cancelled.ids),
            // ])
            // cancelled_events = self.browse([
            //     e.odoo_id(self.env)
            //     for e in cancelled
            //     if e.id not in [r.microsoft_id for r in cancelled_recurrences]
            // ])
            // cancelled_recurrences._cancel_microsoft()
            // cancelled_events = cancelled_events.exists()
            // cancelled_events._cancel_microsoft()
            // 
            // synced_recurrences |= cancelled_recurrences
            // synced_events |= cancelled_events | cancelled_recurrences.calendar_event_ids
            // 
            // # Get sync lower bound days range for checking if old events must be updated in Odoo.
            // ICP = self.env['ir.config_parameter'].sudo()
            // lower_bound_day_range = ICP.get_param('microsoft_calendar.sync.lower_bound_range')
            // 
            // # update other events
            // for mevent in (existing - cancelled).filter(lambda e: e.lastModifiedDateTime):
            //     # Last updated wins.
            //     # This could be dangerous if microsoft server time and odoo server time are different
            //     if mevent.is_recurrence():
            //         odoo_event = self.env['calendar.recurrence'].browse(mevent.odoo_id(self.env)).exists()
            //     else:
            //         odoo_event = self.browse(mevent.odoo_id(self.env)).exists()
            // 
            //     if odoo_event:
            //         odoo_event_updated_time = pytz.utc.localize(odoo_event.write_date)
            //         ms_event_updated_time = parse(mevent.lastModifiedDateTime)
            // 
            //         # If the update comes from an old event/recurrence, check if time diff between updates is reasonable.
            //         old_event_update_condition = True
            //         if lower_bound_day_range:
            //             update_time_diff = ms_event_updated_time - odoo_event_updated_time
            //             old_event_update_condition = odoo_event._check_old_event_update_required(int(lower_bound_day_range), update_time_diff)
            // 
            //         if ms_event_updated_time >= odoo_event_updated_time and old_event_update_condition:
            //             vals = dict(odoo_event._microsoft_to_odoo_values(mevent), need_sync_m=False)
            //             odoo_event.with_context(dont_notify=True)._write_from_microsoft(mevent, vals)
            // 
            //             if odoo_event._name == 'calendar.recurrence':
            //                 update_events = odoo_event._update_microsoft_recurrence(mevent, microsoft_events)
            //                 synced_recurrences |= odoo_event
            //                 synced_events |= update_events
            //             else:
            //                 synced_events |= odoo_event
            // 
            // return synced_events, synced_recurrences
            */
            return default;
        }

        public async Task<TEntity> SyncOdoo2microsoftInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _sync_odoo2microsoft(self):
            // if not self:
            //     return
            // if self._active_name:
            //     records_to_sync = self.filtered(self._active_name)
            // else:
            //     records_to_sync = self
            // cancelled_records = self - records_to_sync
            // 
            // records_to_sync._ensure_attendees_have_email()
            // updated_records = records_to_sync._get_synced_events()
            // new_records = records_to_sync - updated_records
            // 
            // for record in cancelled_records._get_synced_events():
            //     record._microsoft_delete(record._get_organizer(), record.microsoft_id)
            // for record in new_records:
            //     values = record._microsoft_values(self._get_microsoft_synced_fields())
            //     sender_user = record._get_event_user_m()
            //     if record._is_microsoft_insertion_blocked(sender_user):
            //         continue
            //     if isinstance(values, dict):
            //         record._microsoft_insert(values)
            //     else:
            //         for value in values:
            //             record._microsoft_insert(value)
            // for record in updated_records.filtered('need_sync_m'):
            //     values = record._microsoft_values(self._get_microsoft_synced_fields())
            //     if not values:
            //         continue
            //     record._microsoft_patch(record._get_organizer(), record.microsoft_id, values)
            */
            return default;
        }

        public async Task<TEntity> SyncRecurrenceMicrosoft2odooInternalAsync<TEntity>(IEnumerable<TEntity> entities, object microsoft_events, object new_events) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _sync_recurrence_microsoft2odoo(self, microsoft_events, new_events=None):
            // recurrent_masters = new_events.filter(lambda e: e.is_recurrence()) if new_events else []
            // recurrents = new_events.filter(lambda e: e.is_recurrent_not_master()) if new_events else []
            // default_values = {'need_sync_m': False}
            // 
            // new_recurrence = self.env['calendar.recurrence']
            // updated_events = self.env['calendar.event']
            // 
            // # --- create new recurrences and associated events ---
            // for recurrent_master in recurrent_masters:
            //     new_calendar_recurrence = dict(
            //         self.env['calendar.recurrence']._microsoft_to_odoo_values(recurrent_master, default_values, with_ids=True),
            //         need_sync_m=False
            //     )
            //     to_create = recurrents.filter(
            //         lambda e: e.seriesMasterId == new_calendar_recurrence['microsoft_id']
            //     )
            //     recurrents -= to_create
            //     base_values = dict(
            //         self.env['calendar.event']._microsoft_to_odoo_values(recurrent_master, default_values, with_ids=True),
            //         need_sync_m=False
            //     )
            //     to_create_values = []
            //     if new_calendar_recurrence.get('end_type', False) in ['count', 'forever']:
            //         to_create = list(to_create)[:MAX_RECURRENT_EVENT]
            //     for recurrent_event in to_create:
            //         if recurrent_event.type == 'occurrence':
            //             value = self.env['calendar.event']._microsoft_to_odoo_recurrence_values(recurrent_event, base_values)
            //         else:
            //             value = self.env['calendar.event']._microsoft_to_odoo_values(recurrent_event, default_values)
            // 
            //         to_create_values += [dict(value, need_sync_m=False)]
            // 
            //     new_calendar_recurrence['calendar_event_ids'] = [(0, 0, to_create_value) for to_create_value in to_create_values]
            //     new_recurrence_odoo = self.env['calendar.recurrence'].with_context(dont_notify=True).create(new_calendar_recurrence)
            //     new_recurrence_odoo.base_event_id = new_recurrence_odoo.calendar_event_ids[0] if new_recurrence_odoo.calendar_event_ids else False
            //     new_recurrence |= new_recurrence_odoo
            // 
            // # --- update events in existing recurrences ---
            // # Important note:
            // # To map existing recurrences with events to update, we must use the universal id
            // # (also known as ICalUId in the Microsoft API), as 'seriesMasterId' attribute of events
            // # is specific to the Microsoft user calendar.
            // ms_recurrence_ids = list({x.seriesMasterId for x in recurrents})
            // ms_recurrence_uids = {r.id: r.iCalUId for r in microsoft_events if r.id in ms_recurrence_ids}
            // recurrences = self.env['calendar.recurrence'].search([('ms_universal_event_id', 'in', microsoft_events.uids)])
            // for recurrent_master_id in ms_recurrence_ids:
            //     recurrence_id = recurrences.filtered(
            //         lambda ev: ev.ms_universal_event_id == ms_recurrence_uids[recurrent_master_id]
            //     )
            //     to_update = recurrents.filter(lambda e: e.seriesMasterId == recurrent_master_id)
            //     for recurrent_event in to_update:
            //         if recurrent_event.type == 'occurrence':
            //             value = self.env['calendar.event']._microsoft_to_odoo_recurrence_values(
            //                 recurrent_event, {'need_sync_m': False}
            //             )
            //         else:
            //             value = self.env['calendar.event']._microsoft_to_odoo_values(recurrent_event, default_values)
            //         existing_event = recurrence_id.calendar_event_ids.filtered(
            //             lambda e: e._is_matching_timeslot(value['start'], value['stop'], recurrent_event.isAllDay)
            //         )
            //         if not existing_event:
            //             continue
            //         value.pop('start')
            //         value.pop('stop')
            //         existing_event._write_from_microsoft(recurrent_event, value)
            //         updated_events |= existing_event
            //     new_recurrence |= recurrence_id
            // return new_recurrence, updated_events
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
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
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def unlink(self):
            // synced = self._get_synced_events()
            // if self.env.user._get_microsoft_sync_status() != "sync_paused":
            //     for ev in synced:
            //         ev._microsoft_delete(ev._get_organizer(), ev.microsoft_id)
            // return super().unlink()
            */
            return default;
        }

        public async Task<TEntity> UpdateAttendeeStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attendee_ids) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> UpdateFutureEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values, object time_values, object recurrence_values) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> UpdateMicrosoftRecurrenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object recurrence, object events) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _update_microsoft_recurrence(self, recurrence, events):
            // """
            // Update Odoo events from Outlook recurrence and events.
            // """
            // # get the list of events to update ...
            // events_to_update = events.filter(lambda e: e.seriesMasterId == self.microsoft_id)
            // if self.end_type in ['count', 'forever']:
            //     events_to_update = list(events_to_update)[:MAX_RECURRENT_EVENT]
            // 
            // # ... and update them
            // rec_values = {}
            // update_events = self.env['calendar.event']
            // for e in events_to_update:
            //     if e.type == "exception":
            //         event_values = self.env['calendar.event']._microsoft_to_odoo_values(e)
            //     elif e.type == "occurrence":
            //         event_values = self.env['calendar.event']._microsoft_to_odoo_recurrence_values(e)
            //     else:
            //         event_values = None
            // 
            //     if event_values:
            //         # keep event values to update the recurrence later
            //         if any(f for f in ('start', 'stop') if f in event_values):
            //             rec_values[(self.id, event_values.get('start'), event_values.get('stop'))] = dict(
            //                 event_values, need_sync_m=False
            //             )
            // 
            //         odoo_event = self.env['calendar.event'].browse(e.odoo_id(self.env)).exists().with_context(
            //             no_mail_to_attendees=True, mail_create_nolog=True
            //         )
            //         odoo_event.with_context(dont_notify=True).write(dict(event_values, need_sync_m=False))
            //         update_events |= odoo_event
            // 
            // # update the recurrence
            // detached_events = self.with_context(dont_notify=True)._apply_recurrence(rec_values)
            // detached_events._cancel_microsoft()
            // 
            // return update_events
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
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
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def write(self, vals):
            // fields_to_sync = [x for x in vals if x in self._get_microsoft_synced_fields()]
            // if fields_to_sync and 'need_sync_m' not in vals and self.env.user._get_microsoft_sync_status() == "sync_active":
            //     vals['need_sync_m'] = True
            // 
            // result = super().write(vals)
            // 
            // if self.env.user._get_microsoft_sync_status() != "sync_paused":
            //     for record in self:
            //         if record.need_sync_m and record.microsoft_id:
            //             if not vals.get('active', True):
            //                 # We need to delete the event. Cancel is not sufficient. Errors may occur.
            //                 record._microsoft_delete(record._get_organizer(), record.microsoft_id, timeout=3)
            //             elif fields_to_sync:
            //                 values = record._microsoft_values(fields_to_sync)
            //                 if not values:
            //                     continue
            //                 record._microsoft_patch(record._get_organizer(), record.microsoft_id, values, timeout=3)
            // 
            // return result
            */
            return default;
        }

        public async Task<TEntity> WriteEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values, object dtstart) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_recurrence_rule.py) ---
            // def _write_events(self, values, dtstart=None):
            // # If only some events are updated, sync those events.
            // # If all events are updated, sync the recurrence instead.
            // values['need_sync_m'] = bool(dtstart) or values.get("need_sync_m", True)
            // return super()._write_events(values, dtstart=dtstart)
            */
            return default;
        }

        public async Task<TEntity> WriteFromGoogleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object gevent, object vals) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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

        public async Task<TEntity> WriteFromMicrosoftInternalAsync<TEntity>(IEnumerable<TEntity> entities, object microsoft_event, object vals) where TEntity : IEntity<Guid>, IMicrosoftCalendarSyncable
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
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: microsoft_sync.py) ---
            // def _write_from_microsoft(self, microsoft_event, vals):
            // self.with_context(dont_notify=True).write(vals)
            */
            return default;
        }
    }
}