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
    [Module("Event", Depends = new[] { "barcodes", "base_setup", "mail", "phone_validation", "portal", "utm" })]
    public class EventMailAppService : GenericApplicationService<EventMail>, IEventMailAppService
    {

        public EventMailAppService(IRepository<EventMail, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<EventMail> ComputeMailStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail.py) ---
            // def _compute_mail_state(self):
            // for scheduler in self:
            //     # registrations based
            //     if scheduler.interval_type == 'after_sub':
            //         scheduler.mail_state = 'running'
            //     # global event based
            //     elif scheduler.mail_done:
            //         scheduler.mail_state = 'sent'
            //     else:
            //         scheduler.mail_state = 'scheduled'
            */
            return default;
        }

        protected async Task<EventMail> ComputeNotificationTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail.py) ---
            // def _compute_notification_type(self):
            // """Assigns the type of template in use, if any is set."""
            // self.notification_type = 'mail'
            --- ODOO METHOD SOURCE (MODULE: event_sms, FILE: event_mail.py) ---
            // def _compute_notification_type(self):
            // super()._compute_notification_type()
            // sms_schedulers = self.filtered(lambda scheduler: scheduler.template_ref and scheduler.template_ref._name == 'sms.template')
            // sms_schedulers.notification_type = 'sms'
            */
            return default;
        }

        protected async Task<EventMail> ComputeScheduledDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail.py) ---
            // def _compute_scheduled_date(self):
            // for scheduler in self:
            //     if scheduler.interval_type == 'after_sub':
            //         date, sign = scheduler.event_id.create_date, 1
            //     elif scheduler.interval_type == 'before_event':
            //         date, sign = scheduler.event_id.date_begin, -1
            //     else:
            //         date, sign = scheduler.event_id.date_end, 1
            // 
            //     scheduler.scheduled_date = date.replace(microsecond=0) + _INTERVALS[scheduler.interval_unit](sign * scheduler.interval_nbr) if date else False
            */
            return default;
        }

        protected async Task<EventMail> CreateMissingMailRegistrationsInternalAsync(object registrations)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail.py) ---
            // def _create_missing_mail_registrations(self, registrations):
            // new = self.env["event.mail.registration"]
            // for scheduler in self:
            //     for chunk in tools.split_every(500, registrations.ids, self.env["event.registration"].browse):
            //         new += self.env['event.mail.registration'].create([{
            //             'registration_id': registration.id,
            //             'scheduler_id': scheduler.id,
            //         } for registration in registrations])
            // return new
            */
            return default;
        }

        public async Task<EventMail> ExecuteAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail.py) ---
            // def execute(self):
            // now = fields.Datetime.now()
            // for scheduler in self._filter_template_ref():
            //     if scheduler.interval_type == 'after_sub':
            //         scheduler._execute_attendee_based()
            //     else:
            //         # before or after event -> one shot communication, once done skip
            //         if scheduler.mail_done:
            //             continue
            //         # do not send emails if the mailing was scheduled before the event but the event is over
            //         if scheduler.scheduled_date <= now and (scheduler.interval_type != 'before_event' or scheduler.event_id.date_end > now):
            //             scheduler._execute_event_based()
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<EventMail> ExecuteAttendeeBasedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail.py) ---
            // def _execute_attendee_based(self):
            // """ Main scheduler method when running in attendee-based mode aka
            // 'after_sub'. This relies on a sub model allowing to know which
            // registrations have been contacted.
            // 
            // It currently does two main things
            //   * generate missing 'event.mail.registrations' which are scheduled
            //     communication linked to registrations;
            //   * launch registration-based communication, splitting in batches as
            //     it may imply a lot of computation. When having more than given
            //     limit to handle, schedule another call of cron to avoid having to
            //     wait another cron interval check;
            // """
            // self.ensure_one()
            // context_registrations = self.env.context.get('event_mail_registration_ids')
            // 
            // auto_commit = not getattr(threading.current_thread(), 'testing', False)
            // batch_size = int(
            //     self.env['ir.config_parameter'].sudo().get_param('mail.batch_size')
            // ) or 50  # be sure to not have 0, as otherwise no iteration is done
            // cron_limit = int(
            //     self.env['ir.config_parameter'].sudo().get_param('mail.render.cron.limit')
            // ) or 1000  # be sure to not have 0, as otherwise we will loop
            // 
            // # fillup on subscription lines (generate more than to render creating
            // # mail.registration is less costly than rendering emails)
            // # note: original 2many domain was
            // #   ("id", "not in", self.env["event.registration"]._search([
            // #       ("mail_registration_ids.scheduler_id", "in", self.ids),
            // #   ]))
            // # but it gives less optimized sql
            // new_attendee_domain = [
            //     ('event_id', '=', self.event_id.id),
            //     ("state", "not in", ("cancel", "draft")),
            //     ("mail_registration_ids", "not in", self.env["event.mail.registration"]._search(
            //         [('scheduler_id', 'in', self.ids)]
            //     )),
            // ]
            // if context_registrations:
            //     new_attendee_domain += [
            //         ('id', 'in', context_registrations),
            //     ]
            // self.env["event.mail.registration"].flush_model(["registration_id", "scheduler_id"])
            // new_attendees = self.env["event.registration"].search(new_attendee_domain, limit=cron_limit * 2, order="id ASC")
            // new_attendee_mails = self._create_missing_mail_registrations(new_attendees)
            // 
            // # fetch attendee schedulers to run (or use the one given in context)
            // mail_domain = self.env["event.mail.registration"]._get_skip_domain() + [("scheduler_id", "=", self.id)]
            // if context_registrations:
            //     new_attendee_mails = new_attendee_mails.filtered_domain(mail_domain)
            // else:
            //     new_attendee_mails = self.env["event.mail.registration"].search(
            //         mail_domain,
            //         limit=(cron_limit + 1), order="id ASC"
            //     )
            // 
            // # there are more than planned for the cron -> reschedule
            // if len(new_attendee_mails) > cron_limit:
            //     new_attendee_mails = new_attendee_mails[:cron_limit]
            //     self.env.ref('event.event_mail_scheduler')._trigger()
            // 
            // for chunk in tools.split_every(batch_size, new_attendee_mails.ids, self.env["event.mail.registration"].browse):
            //     # filter out canceled / draft, and compare to seats_taken (same heuristic)
            //     valid_chunk = chunk.filtered(lambda m: m.registration_id.state not in ("draft", "cancel"))
            //     # scheduled mails for draft / cancel should be removed as they won't be sent
            //     (chunk - valid_chunk).unlink()
            // 
            //     # send communications, then update only when being in cron mode (aka no
            //     # context registrations) to avoid concurrent updates on scheduler
            //     valid_chunk._execute_on_registrations()
            //     # if not context_registrations:
            //     self._refresh_mail_count_done()
            //     if auto_commit:
            //         self.env.cr.commit()
            //         # invalidate cache, no need to keep previous content in memory
            //         self.env.invalidate_all()
            */
            return default;
        }

        protected async Task<EventMail> ExecuteEventBasedForRegistrationsInternalAsync(object registrations)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail.py) ---
            // def _execute_event_based_for_registrations(self, registrations):
            // """ Method doing notification and recipients specific implementation
            // of contacting attendees globally.
            // 
            // :param registrations: a recordset of registrations to contact
            // """
            // self.ensure_one()
            // if self.notification_type == "mail":
            //     self._send_mail(registrations)
            // return True
            --- ODOO METHOD SOURCE (MODULE: event_sms, FILE: event_mail.py) ---
            // def _execute_event_based_for_registrations(self, registrations):
            // if self.notification_type == "sms":
            //     self._send_sms(registrations)
            // return super()._execute_event_based_for_registrations(registrations)
            */
            return default;
        }

        protected async Task<EventMail> ExecuteEventBasedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail.py) ---
            // def _execute_event_based(self):
            // """ Main scheduler method when running in event-based mode aka
            // 'after_event' or 'before_event'. This is a global communication done
            // once i.e. we do not track each registration individually. """
            // auto_commit = not getattr(threading.current_thread(), 'testing', False)
            // batch_size = int(
            //     self.env['ir.config_parameter'].sudo().get_param('mail.batch_size')
            // ) or 50  # be sure to not have 0, as otherwise no iteration is done
            // cron_limit = int(
            //     self.env['ir.config_parameter'].sudo().get_param('mail.render.cron.limit')
            // ) or 1000  # be sure to not have 0, as otherwise we will loop
            // 
            // # fetch registrations to contact
            // registration_domain = [
            //     ('event_id', '=', self.event_id.id),
            //     ('state', 'not in', ["draft", "cancel"]),
            // ]
            // if self.last_registration_id:
            //     registration_domain += [('id', '>', self.last_registration_id.id)]
            // registrations = self.env["event.registration"].search(registration_domain, limit=(cron_limit + 1), order="id ASC")
            // 
            // # no registrations -> done
            // if not registrations:
            //     self.mail_done = True
            //     return
            // 
            // # there are more than planned for the cron -> reschedule
            // if len(registrations) > cron_limit:
            //     registrations = registrations[:cron_limit]
            //     self.env.ref('event.event_mail_scheduler')._trigger()
            // 
            // for registrations_chunk in tools.split_every(batch_size, registrations.ids, self.env["event.registration"].browse):
            //     self._execute_event_based_for_registrations(registrations_chunk)
            //     self.last_registration_id = registrations_chunk[-1]
            // 
            //     self._refresh_mail_count_done()
            //     if auto_commit:
            //         self.env.cr.commit()
            //         # invalidate cache, no need to keep previous content in memory
            //         self.env.invalidate_all()
            */
            return default;
        }

        protected async Task<EventMail> FilterTemplateRefInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail.py) ---
            // def _filter_template_ref(self):
            // """ Check for valid template reference: existing, working template """
            // type_info = self._template_model_by_notification_type()
            // 
            // if not self:
            //     return self.browse()
            // 
            // invalid = self.browse()
            // missing = self.browse()
            // for scheduler in self:
            //     tpl_model = type_info[scheduler.notification_type]
            //     if scheduler.template_ref._name != tpl_model:
            //         invalid += scheduler
            //     else:
            //         template = self.env[tpl_model].browse(scheduler.template_ref.id).exists()
            //         if not template:
            //             missing += scheduler
            // for scheduler in missing:
            //     _logger.warning(
            //         "Cannot process scheduler %s (event %s - ID %s) as it refers to non-existent %s (ID %s)",
            //         scheduler.id, scheduler.event_id.name, scheduler.event_id.id,
            //         tpl_model, scheduler.template_ref.id
            //     )
            // for scheduler in invalid:
            //     _logger.warning(
            //         "Cannot process scheduler %s (event %s - ID %s) as it refers to invalid template %s (ID %s) (%s instead of %s)",
            //         scheduler.id, scheduler.event_id.name, scheduler.event_id.id,
            //         scheduler.template_ref.name, scheduler.template_ref.id,
            //         scheduler.template_ref._name, tpl_model)
            // return self - missing - invalid
            */
            return default;
        }

        protected async Task<EventMail> PrepareEventMailValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail.py) ---
            // def _prepare_event_mail_values(self):
            // self.ensure_one()
            // return {
            //     'interval_nbr': self.interval_nbr,
            //     'interval_unit': self.interval_unit,
            //     'interval_type': self.interval_type,
            //     'template_ref': '%s,%i' % (self.template_ref._name, self.template_ref.id),
            // }
            */
            return default;
        }

        protected async Task<EventMail> RefreshMailCountDoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail.py) ---
            // def _refresh_mail_count_done(self):
            // for scheduler in self:
            //     if scheduler.interval_type == "after_sub":
            //         total_sent = self.env["event.mail.registration"].search_count([
            //             ("scheduler_id", "=", self.id),
            //             ("mail_sent", "=", True),
            //         ])
            //         scheduler.mail_count_done = total_sent
            //     elif scheduler.last_registration_id:
            //         total_sent = self.env["event.registration"].search_count([
            //             ("id", "<=", self.last_registration_id.id),
            //             ("event_id", "=", self.event_id.id),
            //             ("state", "not in", ["draft", "cancel"]),
            //         ])
            //         scheduler.mail_count_done = total_sent
            //         scheduler.mail_done = total_sent >= self.event_id.seats_taken
            //     else:
            //         scheduler.mail_count_done = 0
            //         scheduler.mail_done = False
            */
            return default;
        }

        public async Task<EventMail> RunAsync(Guid id, EventMailRunRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail.py) ---
            // def run(self, autocommit=False):
            // """ Backward compatible method, notably if crons are not updated when
            // migrating for some reason. """
            // return self.schedule_communications(autocommit=autocommit)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<EventMail> ScheduleCommunicationsAsync(Guid id, EventMailScheduleCommunicationsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail.py) ---
            // def schedule_communications(self, autocommit=False):
            // schedulers = self.search([
            //     # skip archived events
            //     ('event_id.active', '=', True),
            //     # scheduled
            //     ('scheduled_date', '<=', fields.Datetime.now()),
            //     # event-based: todo / attendee-based: running until event is not done
            //     '|',
            //     ('mail_done', '=', False),
            //     '&', ('interval_type', '=', 'after_sub'), ('event_id.date_end', '>', self.env.cr.now()),
            // ])
            // 
            // for scheduler in schedulers:
            //     try:
            //         # Prevent a mega prefetch of the registration ids of all the events of all the schedulers
            //         self.browse(scheduler.id).execute()
            //     except Exception as e:
            //         _logger.exception(e)
            //         self.env.invalidate_all()
            //         self._warn_template_error(scheduler, e)
            //     else:
            //         if autocommit and not getattr(threading.current_thread(), 'testing', False):
            //             self.env.cr.commit()
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<EventMail> SendMailInternalAsync(object registrations)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail.py) ---
            // def _send_mail(self, registrations):
            // """ Mail action: send mail to attendees """
            // if self.event_id.organizer_id.email:
            //     author = self.event_id.organizer_id
            // elif self.env.company.email:
            //     author = self.env.company.partner_id
            // elif self.env.user.email:
            //     author = self.env.user.partner_id
            // else:
            //     author = self.env.ref('base.user_root').partner_id
            // 
            // composer_values = {
            //     'composition_mode': 'mass_mail',
            //     'force_send': False,
            //     'model': registrations._name,
            //     'record_name': False,
            //     'res_ids': registrations.ids,
            //     'template_id': self.template_ref.id,
            // }
            // # force author, as mailing mode does not try to find the author matching
            // # email_from (done only when posting on chatter); give email_from if not
            // # configured on template
            // composer_values['author_id'] = author.id
            // composer_values['email_from'] = self.template_ref.email_from or author.email_formatted
            // composer = self.env['mail.compose.message'].create(composer_values)
            // # backward compatible behavior: event mail scheduler does not force partner
            // # creation, email_cc / email_to is kept on outgoing emails
            // composer.with_context(mail_composer_force_partners=False)._action_send_mail()
            */
            return default;
        }

        protected async Task<EventMail> SendSmsInternalAsync(object registrations)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sms, FILE: event_mail.py) ---
            // def _send_sms(self, registrations):
            // """ SMS action: send SMS to attendees """
            // registrations._message_sms_schedule_mass(
            //     template=self.template_ref,
            //     mass_keep_log=True
            // )
            */
            return default;
        }

        protected async Task<EventMail> TemplateModelByNotificationTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail.py) ---
            // def _template_model_by_notification_type(self):
            // return {
            //     "mail": "mail.template",
            // }
            --- ODOO METHOD SOURCE (MODULE: event_sms, FILE: event_mail.py) ---
            // def _template_model_by_notification_type(self):
            // info = super()._template_model_by_notification_type()
            // info["sms"] = "sms.template"
            // return info
            */
            return default;
        }

        protected async Task<EventMail> WarnTemplateErrorInternalAsync(object scheduler, object exception)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_mail.py) ---
            // def _warn_template_error(self, scheduler, exception):
            //         # We warn ~ once by hour ~ instead of every 10 min if the interval unit is more than 'hours'.
            //         if random.random() < 0.1666 or scheduler.interval_unit in ('now', 'hours'):
            //             ex_s = exception_to_unicode(exception)
            //             try:
            //                 event, template = scheduler.event_id, scheduler.template_ref
            //                 emails = list(set([event.organizer_id.email, event.user_id.email, template.write_uid.email]))
            //                 subject = _("WARNING: Event Scheduler Error for event: %s", event.name)
            //                 body = _("""Event Scheduler for:
            //   - Event: %(event_name)s (%(event_id)s)
            //   - Scheduled: %(date)s
            //   - Template: %(template_name)s (%(template_id)s)
            // 
            // Failed with error:
            //   - %(error)s
            // 
            // You receive this email because you are:
            //   - the organizer of the event,
            //   - or the responsible of the event,
            //   - or the last writer of the template.
            // """,
            //                          event_name=event.name,
            //                          event_id=event.id,
            //                          date=scheduler.scheduled_date,
            //                          template_name=template.name,
            //                          template_id=template.id,
            //                          error=ex_s)
            //                 email = self.env['ir.mail_server'].build_email(
            //                     email_from=self.env.user.email,
            //                     email_to=emails,
            //                     subject=subject, body=body,
            //                 )
            //                 self.env['ir.mail_server'].send_email(email)
            //             except Exception as e:
            //                 _logger.error("Exception while sending traceback by email: %s.\n Original Traceback:\n%s", e, exception)
            //                 pass
            */
            return default;
        }
    }
}