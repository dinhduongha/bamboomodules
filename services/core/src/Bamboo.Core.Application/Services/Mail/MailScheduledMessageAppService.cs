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
    [Module("Mail", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public class MailScheduledMessageAppService : GenericApplicationService<MailScheduledMessage>, IMailScheduledMessageAppService
    {

        public MailScheduledMessageAppService(IRepository<MailScheduledMessage, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<MailScheduledMessage> CheckInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_scheduled_message.py) ---
            // def _check(self, values=None):
            // """ Restrict the access to a scheduled message.
            //     Access is based on the record on which the scheduled message will be posted to.
            //     :param values: dict with model and res_id on which to perform the check
            // """
            // if self.env.is_superuser():
            //     return True
            // 
            // model_ids = defaultdict(set)
            // # sudo as anyways we check access on the related records
            // for scheduled_message in self.sudo():
            //     model_ids[scheduled_message.model].add(scheduled_message.res_id)
            // if values:
            //     model_ids[values['model']].add(values['res_id'])
            // 
            // for model, res_ids in model_ids.items():
            //     records = self.env[model].browse(res_ids)
            //     operation = getattr(records, '_mail_post_access', 'write')
            //     records.check_access(operation)
            */
            return default;
        }

        protected async Task<MailScheduledMessage> CheckModelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_scheduled_message.py) ---
            // def _check_model(self):
            // if not all(model in self.pool and issubclass(self.pool[model], self.pool['mail.thread']) for model in self.mapped("model")):
            //     raise ValidationError(_("A message cannot be scheduled on a model that does not have a mail thread."))
            */
            return default;
        }

        protected async Task<MailScheduledMessage> CheckScheduledDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_scheduled_message.py) ---
            // def _check_scheduled_date(self):
            // if any(scheduled_message.scheduled_date < fields.Datetime().now() for scheduled_message in self):
            //     raise ValidationError(_("A Scheduled Message cannot be scheduled in the past"))
            */
            return default;
        }

        protected async Task<MailScheduledMessage> NotificationParametersWhitelistInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_scheduled_message.py) ---
            // def _notification_parameters_whitelist(self):
            // """ Parameters that can be used when posting the scheduled messages.
            // """
            // return {
            //     'email_add_signature',
            //     'email_from',
            //     'email_layout_xmlid',
            //     'force_email_lang',
            //     'mail_activity_type_id',
            //     'mail_auto_delete',
            //     'mail_server_id',
            //     'message_type',
            //     'model_description',
            //     'reply_to',
            //     'reply_to_force_new',
            //     'subtype_id',
            // }
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: mail_scheduled_message.py) ---
            // def _notification_parameters_whitelist(self):
            // return super()._notification_parameters_whitelist() | {'mark_so_as_sent'}
            */
            return default;
        }

        public async Task<MailScheduledMessage> OpenEditFormAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_scheduled_message.py) ---
            // def open_edit_form(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _("Edit Scheduled Note") if self.is_note else _("Edit Scheduled Message"),
            //     'res_model': self._name,
            //     'view_mode': 'form',
            //     'views': [[False, 'form']],
            //     'target': 'new',
            //     'res_id': self.id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailScheduledMessage> PostMessageAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_scheduled_message.py) ---
            // def post_message(self):
            // self.ensure_one()
            // if self.env.is_admin() or self.create_uid.id == self.env.uid:
            //     self._post_message()
            // else:
            //     raise UserError(_("You are not allowed to send this scheduled message"))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailScheduledMessage> PostMessageInternalAsync(object raise_exception)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_scheduled_message.py) ---
            // def _post_message(self, raise_exception=True):
            // """ Post the scheduled messages.
            //     They are posted using their creator as user so that one can check that the creator has
            //     still post permission on the related record, and to allow for the attachments to be
            //     transferred to the messages (see _process_attachments_for_post in mail.thread)
            //     if raise_exception is set to False, the method will skip the posting of a message
            //     instead of raising an error, and send a notification to the author about the failure.
            //     This is useful when scheduled messages are sent from the _post_messages_cron.
            // """
            // notification_parameters_whitelist = self._notification_parameters_whitelist()
            // auto_commit = not getattr(threading.current_thread(), 'testing', False)
            // for scheduled_message in self:
            //     message_creator = scheduled_message.create_uid
            //     try:
            //         scheduled_message.with_user(message_creator)._check()
            //         self.env[scheduled_message.model].browse(scheduled_message.res_id).with_user(message_creator).message_post(
            //             attachment_ids=list(scheduled_message.attachment_ids.ids),
            //             author_id=scheduled_message.author_id.id,
            //             subject=scheduled_message.subject,
            //             body=scheduled_message.body,
            //             partner_ids=list(scheduled_message.partner_ids.ids),
            //             subtype_xmlid='mail.mt_note' if scheduled_message.is_note else 'mail.mt_comment',
            //             **{k: v for k, v in json.loads(scheduled_message.notification_parameters or '{}').items() if k in notification_parameters_whitelist},
            //         )
            //         if auto_commit:
            //             self.env.cr.commit()
            //     except Exception:
            //         if raise_exception:
            //             raise
            //         _logger.info("Posting of scheduled message with ID %s failed", scheduled_message.id, exc_info=True)
            //         # notify user about the failure (send content as user might have lost access to the record)
            //         if auto_commit:
            //             self.env.cr.rollback()
            //         try:
            //             self.env['mail.thread'].message_notify(
            //                 partner_ids=[message_creator.partner_id.id],
            //                 subject=_("A scheduled message could not be sent"),
            //                 body=_("The message scheduled on %(model)s(%(id)s) with the following content could not be sent:%(original_message)s",
            //                     model=scheduled_message.model,
            //                     id=scheduled_message.res_id,
            //                     original_message=Markup("<br>-----<br>%s<br>-----<br>") % scheduled_message.body,
            //                 )
            //             )
            //             if auto_commit:
            //                 self.env.cr.commit()
            //         except Exception:
            //             # in case even message_notify fails, make sure the failing scheduled message
            //             # will be deleted
            //             _logger.exception("The notification about the failed scheduled message could not be sent")
            //             if auto_commit:
            //                 self.env.cr.rollback()
            // self.unlink()
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: mail_scheduled_message.py) ---
            // def _post_message(self, raise_exception=True):
            // order_messages = self.env['mail.scheduled.message'].with_context(mark_so_as_sent=True)
            // for scheduled_message in self:
            //     notification_parameters = json.loads(scheduled_message.notification_parameters or '{}')
            //     if 'mark_so_as_sent' not in notification_parameters:
            //         continue
            //     if notification_parameters.pop('mark_so_as_sent'):
            //         order_messages += scheduled_message
            //     scheduled_message.notification_parameters = json.dumps(notification_parameters)
            // if order_messages:
            //     super(ScheduledMessage, order_messages)._post_message(raise_exception=raise_exception)
            // if remaining := self - order_messages:
            //     super(ScheduledMessage, remaining)._post_message(raise_exception=raise_exception)
            */
            return default;
        }

        protected async Task<MailScheduledMessage> PostMessagesCronInternalAsync(object limit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_scheduled_message.py) ---
            // def _post_messages_cron(self, limit=50):
            // """ Posts past-due scheduled messages.
            // """
            // domain = [('scheduled_date', '<=', fields.Datetime.now())]
            // messages_to_post = self.search(domain, limit=limit)
            // _logger.info("Posting %s scheduled messages", len(messages_to_post))
            // messages_to_post.with_context(mail_notify_force_send=True)._post_message(raise_exception=False)
            // 
            // # restart cron if needed
            // if self.search_count(domain, limit=1):
            //     self.env.ref('mail.ir_cron_post_scheduled_message')._trigger()
            */
            return default;
        }

        protected async Task<MailScheduledMessage> SearchInternalAsync(object domain, object offset, object limit, object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_scheduled_message.py) ---
            // def _search(self, domain, offset=0, limit=None, order=None):
            // """ Override that add specific access rights to only get the ids of the messages
            // that are scheduled on the records on which the user has mail_post (or read) access
            // """
            // if self.env.is_superuser():
            //     return super()._search(domain, offset, limit, order)
            // 
            // # don't use the ORM to avoid cache pollution
            // query = super()._search(domain, offset, limit, order)
            // fnames_to_read = ['id', 'model', 'res_id']
            // rows = self.env.execute_query(query.select(
            //     *[self._field_to_sql(self._table, fname) for fname in fnames_to_read],
            // ))
            // 
            // # group res_ids by model and determine accessible records
            // model_ids = defaultdict(set)
            // for __, model, res_id in rows:
            //     model_ids[model].add(res_id)
            // 
            // allowed_ids = defaultdict(set)
            // for model, res_ids in model_ids.items():
            //     records = self.env[model].browse(res_ids)
            //     operation = getattr(records, '_mail_post_access', 'write')
            //     if records.has_access(operation):
            //         allowed_ids[model] = set(records._filtered_access(operation)._ids)
            // 
            // scheduled_messages = self.browse(
            //     msg_id
            //     for msg_id, res_model, res_id in rows
            //     if res_id in allowed_ids[res_model]
            // )
            // 
            // return scheduled_messages._as_query(order)
            */
            return default;
        }

        protected async Task<MailScheduledMessage> ToStoreInternalAsync(object store)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_scheduled_message.py) ---
            // def _to_store(self, store: Store):
            // for scheduled_message in self:
            //     data = scheduled_message._read_format(['body', 'is_note', 'scheduled_date', 'subject'])[0]
            //     data['attachment_ids'] = Store.many(scheduled_message.attachment_ids)
            //     data['author'] = Store.one(scheduled_message.author_id)
            //     store.add(scheduled_message, data)
            */
            return default;
        }
    }
}