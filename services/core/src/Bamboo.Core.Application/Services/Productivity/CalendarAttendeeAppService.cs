using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Calendar", Category = "Productivity", Depends = new[] { "base", "mail" })]
    public partial class CalendarAttendeeAppService : GenericApplicationService<CalendarAttendee>, ICalendarAttendeeAppService
    {

        public CalendarAttendeeAppService(IRepository<CalendarAttendee, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<CalendarAttendee> ComputeCommonNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py) ---
            // def _compute_common_name(self):
            // for attendee in self:
            //     attendee.common_name = attendee.partner_id.name or attendee.email
            */
            return default;
        }

        protected async Task<CalendarAttendee> ComputeMailTzInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py) ---
            // def _compute_mail_tz(self):
            // for attendee in self:
            //     attendee.mail_tz = attendee.partner_id.tz
            */
            return default;
        }

        protected async Task<CalendarAttendee> DefaultAccessTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py) ---
            // def _default_access_token(self):
            // return uuid.uuid4().hex
            */
            return default;
        }

        public async Task<CalendarAttendee> DoAcceptAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py) ---
            // def do_accept(self):
            // """ Marks event invitation as Accepted. """
            // for attendee in self:
            //     attendee.event_id.message_post(
            //         author_id=attendee.partner_id.id,
            //         body=_("%s has accepted the invitation", attendee.common_name),
            //         subtype_xmlid="calendar.subtype_invitation",
            //     )
            // return self.write({'state': 'accepted'})
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar_attendee.py) ---
            // def do_accept(self):
            // # Synchronize event after state change
            // res = super().do_accept()
            // self._sync_event()
            // return res
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_attendee.py) ---
            // def do_accept(self):
            // # Synchronize event after state change
            // res = super().do_accept()
            // self._microsoft_sync_event('accept')
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CalendarAttendee> DoDeclineAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py) ---
            // def do_decline(self):
            // """ Marks event invitation as Declined. """
            // for attendee in self:
            //     attendee.event_id.message_post(
            //         author_id=attendee.partner_id.id,
            //         body=_("%s has declined the invitation", attendee.common_name),
            //         subtype_xmlid="calendar.subtype_invitation",
            //     )
            // return self.write({'state': 'declined'})
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar_attendee.py) ---
            // def do_decline(self):
            // # Synchronize event after state change
            // res = super().do_decline()
            // self._sync_event()
            // return res
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_attendee.py) ---
            // def do_decline(self):
            // # Synchronize event after state change
            // res = super().do_decline()
            // self._microsoft_sync_event('decline')
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CalendarAttendee> DoTentativeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py) ---
            // def do_tentative(self):
            // """ Makes event invitation as Tentative. """
            // return self.write({'state': 'tentative'})
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar_attendee.py) ---
            // def do_tentative(self):
            // # Synchronize event after state change
            // res = super().do_tentative()
            // self._sync_event()
            // return res
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_attendee.py) ---
            // def do_tentative(self):
            // # Synchronize event after state change
            // res = super().do_tentative()
            // self._microsoft_sync_event('tentativelyAccept')
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CalendarAttendee> MailTemplateDefaultValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py) ---
            // def _mail_template_default_values(self):
            // return {
            //     "email_from": "{{ (object.event_id.user_id.email_formatted or user.email_formatted or '') }}",
            //     "email_to": False,
            //     "partner_to": False,
            //     "lang": "{{ object.partner_id.lang }}",
            //     "use_default_to": True,
            // }
            */
            return default;
        }

        protected async Task<CalendarAttendee> MessageAddDefaultRecipientsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py) ---
            // def _message_add_default_recipients(self):
            // # override: partner_id being the only stored field, we can currently
            // # simplify computation, we have no other choice than relying on it
            // return {
            //     attendee.id: {
            //         'partners': attendee.partner_id,
            //         'email_to_lst': [],
            //         'email_cc_lst': [],
            //     } for attendee in self
            // }
            */
            return default;
        }

        protected async Task<CalendarAttendee> MicrosoftSyncEventInternalAsync(object answer)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_attendee.py) ---
            // def _microsoft_sync_event(self, answer):
            // params = {"comment": "", "sendResponse": True}
            // # Microsoft prevent user to answer the meeting when they are the organizer
            // linked_events = self.event_id._get_synced_events()
            // for event in linked_events:
            //     if event._check_microsoft_sync_status() and self.env.user != event.user_id and self.env.user.partner_id in event.partner_ids:
            //         if event.recurrency:
            //             event._forbid_recurrence_update()
            //         event._microsoft_attendee_answer(answer, params)
            */
            return default;
        }

        protected async Task<CalendarAttendee> NotifyAttendeesInternalAsync(object mail_template, object notify_author, object force_send)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py) ---
            // def _notify_attendees(self, mail_template, notify_author=False, force_send=False):
            // """ Notify attendees about event main changes (invite, cancel, ...) based
            // on template.
            // 
            // :param mail_template: a mail.template record
            // :param force_send: if set to True, the mail(s) will be sent immediately (instead of the next queue processing)
            // """
            // # TDE FIXME: check this
            // if force_send:
            //     force_send_limit = int(self.env['ir.config_parameter'].sudo().get_param('mail.mail_force_send_limit', 100))
            // notified_attendees_ids = set(self.ids)
            // for event, attendees in self.grouped('event_id').items():
            //     if event._skip_send_mail_status_update():
            //         notified_attendees_ids -= set(attendees.ids)
            // notified_attendees = self.browse(notified_attendees_ids)
            // if isinstance(mail_template, str):
            //     raise ValueError('Template should be a template record, not an XML ID anymore.')
            // if self.env['ir.config_parameter'].sudo().get_param('calendar.block_mail') or self.env.context.get("no_mail_to_attendees"):
            //     return False
            // if not mail_template:
            //     _logger.warning("No template passed to %s notification process. Skipped.", self)
            //     return False
            // 
            // # get ics file for all meetings
            // ics_files = notified_attendees.event_id._get_ics_file()
            // 
            // # If the mail template has attachments, prepare copies for each attendee (to be added to each attendee's mail)
            // if mail_template.attachment_ids:
            // 
            //     # Setting res_model to ensure attachments are linked to the msg (otherwise only internal users are allowed link attachments)
            //     attachments_values = [a.copy_data({'res_id': 0, 'res_model': 'mail.compose.message'})[0] for a in mail_template.attachment_ids]
            //     attachments_values *= len(self)
            //     attendee_attachment_ids = self.env['ir.attachment'].create(attachments_values).ids
            // 
            //     # Map attendees to their respective attachments
            //     template_attachment_count = len(mail_template.attachment_ids)
            //     attendee_id_attachment_id_map = dict(zip(self.ids, split_every(template_attachment_count, attendee_attachment_ids, list)))
            // 
            // mail_messages = self.env['mail.message']
            // for attendee in notified_attendees:
            //     if attendee.email and attendee._should_notify_attendee(notify_author=notify_author):
            //         event_id = attendee.event_id.id
            //         ics_file = ics_files.get(event_id)
            // 
            //         # Add template attachments copies to the attendee's email, if available
            //         attachment_ids = attendee_id_attachment_id_map[attendee.id] if mail_template.attachment_ids else []
            // 
            //         if ics_file:
            //             context = {
            //                 **clean_context(self.env.context),
            //                 'no_document': True,  # An ICS file must not create a document
            //             }
            //             attachment_ids += self.env['ir.attachment'].with_context(context).create({
            //                 'datas': base64.b64encode(ics_file),
            //                 'description': 'invitation.ics',
            //                 'mimetype': 'text/calendar',
            //                 'res_id': 0,
            //                 'res_model': 'mail.compose.message',
            //                 'name': 'invitation.ics',
            //             }).ids
            // 
            //         body = mail_template._render_field(
            //             'body_html',
            //             attendee.ids,
            //             compute_lang=True)[attendee.id]
            //         subject = mail_template._render_field(
            //             'subject',
            //             attendee.ids,
            //             compute_lang=True)[attendee.id]
            //         email_from = mail_template._render_field(
            //             'email_from',
            //             attendee.ids)[attendee.id]
            //         mail_messages += attendee.event_id.with_context(no_document=True).sudo().message_notify(
            //             email_from=email_from or None,  # use None to trigger fallback sender
            //             author_id=attendee.event_id.user_id.partner_id.id or self.env.user.partner_id.id,
            //             body=body,
            //             subject=subject,
            //             notify_author=notify_author,
            //             partner_ids=attendee.partner_id.ids,
            //             email_layout_xmlid='mail.mail_notification_light',
            //             attachment_ids=attachment_ids,
            //             force_send=False,
            //         )
            // # batch sending at the end
            // if force_send and len(notified_attendees) < force_send_limit:
            //     mail_messages.sudo().mail_ids.send_after_commit()
            */
            return default;
        }

        protected async Task<CalendarAttendee> SendInvitationEmailsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py) ---
            // def _send_invitation_emails(self):
            // """ Hook to be able to override the invitation email sending process.
            //  Notably inside appointment to use a different mail template from the appointment type. """
            // self._notify_attendees(
            //     self.env.ref('calendar.calendar_template_meeting_invitation', raise_if_not_found=False),
            //     force_send=True,
            // )
            */
            return default;
        }

        protected async Task<CalendarAttendee> ShouldNotifyAttendeeInternalAsync(object notify_author)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py) ---
            // def _should_notify_attendee(self, notify_author=False):
            // """ Utility method that determines if the attendee should be notified.
            //     By default, we do not want to notify (aka no message and no mail) the current user
            //     if he is part of the attendees. But for reminders, mail_notify_author could be forced
            //     (Override in appointment to ignore that rule and notify all attendees if it's an appointment)
            // """
            // self.ensure_one()
            // partner_not_sender = self.partner_id != self.env.user.partner_id
            // return partner_not_sender or notify_author
            */
            return default;
        }

        protected async Task<CalendarAttendee> SyncEventInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: calendar_attendee.py) ---
            // def _sync_event(self):
            // # For weird reasons, we can't sync status when we are not the responsible
            // # We can't adapt google_value to only keep ['id', 'summary', 'attendees', 'start', 'end', 'reminders']
            // # and send that. We get a Forbidden for non-organizer error even if we only send start, end that are mandatory !
            // all_events = self.mapped('event_id').filtered(lambda e: e.google_id)
            // other_events = all_events.filtered(lambda e: e.user_id and e.user_id.id != self.env.user.id)
            // for user in other_events.mapped('user_id'):
            //     service = GoogleCalendarService(self.env['google.service'].with_user(user))
            //     other_events.filtered(lambda ev: ev.user_id.id == user.id).with_user(user)._sync_odoo2google(service)
            // google_service = GoogleCalendarService(self.env['google.service'])
            // (all_events - other_events)._sync_odoo2google(google_service)
            */
            return default;
        }

        protected async Task<CalendarAttendee> UnsubscribePartnerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py) ---
            // def _unsubscribe_partner(self):
            // for event in self.event_id:
            //     partners = (event.attendee_ids & self).partner_id & event.message_partner_ids
            //     event.message_unsubscribe(partner_ids=partners.ids)
            */
            return default;
        }
    }
}