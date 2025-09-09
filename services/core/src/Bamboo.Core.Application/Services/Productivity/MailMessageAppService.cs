using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;

namespace Bamboo.Core.Application.Services
{
    [Module("Mail", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public class MailMessageAppService : GenericApplicationService<MailMessage>, IMailMessageAppService
    {
        private readonly IBusListenerMixinAppService _busListenerMixinAppService;
        public MailMessageAppService(IRepository<MailMessage, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IBusListenerMixinAppService busListenerMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _busListenerMixinAppService = busListenerMixinAppService;
        }

        protected async Task<MailMessage> AuthorToStoreInternalAsync(object store)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: mail_message.py) ---
            // def _author_to_store(self, store: Store):
            // messages_w_author_channel = self.filtered(
            //     lambda message: message.author_id
            //     and message.model == "discuss.channel"
            //     and message.res_id
            // )
            // channel_by_message = messages_w_author_channel._record_by_message()
            // messages_w_author_livechat = messages_w_author_channel.filtered(
            //     lambda message: channel_by_message[message].channel_type == "livechat"
            // )
            // super(MailMessage, self - messages_w_author_livechat)._author_to_store(store)
            // for message in messages_w_author_livechat:
            //     store.add(
            //         message,
            //         {
            //             "author": Store.one(
            //                 message.author_id,
            //                 fields=["avatar_128", "is_company", "user_livechat_username", "user"],
            //             ),
            //         },
            //     )
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _author_to_store(self, store: Store):
            // for message in self:
            //     data = {
            //         "author": False,
            //         "email_from": message.email_from,
            //     }
            //     # sudo: mail.message: access to author is allowed
            //     if guest_author := message.sudo().author_guest_id:
            //         data["author"] = Store.one(guest_author, fields=["avatar_128", "name"])
            //     # sudo: mail.message: access to author is allowed
            //     elif author := message.sudo().author_id:
            //         data["author"] = Store.one(
            //             author, fields=["avatar_128", "is_company", "name", "user"]
            //         )
            //     store.add(message, data)
            */
            return default;
        }

        protected async Task<MailMessage> BusChannelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _bus_channel(self):
            // self.ensure_one()
            // if self.model == "discuss.channel" and self.res_id:
            //     return self.env["discuss.channel"].browse(self.res_id)._bus_channel()
            // guest = self.env["mail.guest"]._get_guest_from_context()
            // if self.env.user._is_public() and guest:
            //     return guest._bus_channel()
            // return super()._bus_channel()
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _bus_channel(self):
            // return self.env.user._bus_channel()
            */
            return default;
        }

        protected async Task<MailMessage> BusSendReactionGroupInternalAsync(object content)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _bus_send_reaction_group(self, content):
            // store = Store()
            // self._reaction_group_to_store(store, content)
            // self._bus_send_store(store)
            */
            return default;
        }

        public async Task<MailMessage> CancelLetterAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: snailmail, FILE: mail_message.py) ---
            // def cancel_letter(self):
            // self.letter_ids.cancel()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailMessage> CheckAccessInternalAsync(string operation)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _check_access(self, operation: str) -> tuple | None:
            // """ Access rules of mail.message:
            //     - read: if
            //         - author_id == pid, uid is the author OR
            //         - create_uid == uid, uid is the creator OR
            //         - uid is in the recipients (partner_ids) OR
            //         - uid has been notified (needaction) OR
            //         - uid have read access to the related document if model, res_id
            //         - otherwise: raise
            //     - create: if
            //         - no model, no res_id (private message) OR
            //         - pid in message_follower_ids if model, res_id OR
            //         - uid can read the parent OR
            //         - uid have write or create access on the related document if model, res_id, OR
            //         - otherwise: raise
            //     - write: if
            //         - author_id == pid, uid is the author, OR
            //         - uid is in the recipients (partner_ids) OR
            //         - uid has write or create access on the related document if model, res_id
            //         - otherwise: raise
            //     - unlink: if
            //         - uid has write or create access on the related document
            //         - otherwise: raise
            // 
            // Specific case: non employee users see only messages with subtype (aka do
            // not see internal logs).
            // """
            // result = super()._check_access(operation)
            // if not self:
            //     return result
            // 
            // # discard forbidden records, and check remaining ones
            // messages = self - result[0] if result else self
            // if messages and (forbidden := messages._get_forbidden_access(operation)):
            //     if result:
            //         result = (result[0] + forbidden, result[1])
            //     else:
            //         result = (forbidden, lambda: forbidden._make_access_error(operation))
            // return result
            */
            return default;
        }

        protected async Task<MailMessage> CleanupSideRecordsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _cleanup_side_records(self):
            // """ Clean related data: notifications, stars, ... to avoid lingering
            // notifications / unreachable counters with void messages notably. """
            // outdated_starred_partners = self.starred_partner_ids.sorted("id")
            // self.write({
            //     'starred_partner_ids': [(5, 0, 0)],
            //     'notification_ids': [(5, 0, 0)],
            // })
            // if outdated_starred_partners:
            //     # sudo: bus.bus: reading non-sensitive last id
            //     bus_last_id = self.env["bus.bus"].sudo()._bus_last_id()
            //     self.env.cr.execute("""
            //         SELECT res_partner_id, count(*)
            //           FROM mail_message_res_partner_starred_rel
            //          WHERE res_partner_id IN %s
            //       GROUP BY res_partner_id
            //       ORDER BY res_partner_id
            //     """, [tuple(outdated_starred_partners.ids)])
            //     star_count_by_partner_id = dict(self.env.cr.fetchall())
            //     for partner in outdated_starred_partners:
            //         partner._bus_send_store(
            //             "mail.thread",
            //             {
            //                 "counter": star_count_by_partner_id.get(partner.id, 0),
            //                 "counter_bus_id": bus_last_id,
            //                 "id": "starred",
            //                 "messages": Store.many(self, "DELETE", only_id=True),
            //                 "model": "mail.box",
            //             },
            //         )
            */
            return default;
        }

        protected async Task<MailMessage> ComputeAccountAuditLogAccountIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _compute_account_audit_log_account_id(self):
            // self._compute_audit_log_related_record_id('account.account', 'account_audit_log_account_id')
            */
            return default;
        }

        protected async Task<MailMessage> ComputeAccountAuditLogActivatedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _compute_account_audit_log_activated(self):
            // for message in self:
            //     message.account_audit_log_activated = message.message_type == 'notification' and (
            //         message.account_audit_log_move_id
            //         or message.account_audit_log_account_id
            //         or message.account_audit_log_tax_id
            //         or message.account_audit_log_partner_id
            //         or message.account_audit_log_company_id
            //     )
            */
            return default;
        }

        protected async Task<MailMessage> ComputeAccountAuditLogCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _compute_account_audit_log_company_id(self):
            // self._compute_audit_log_related_record_id('res.company', 'account_audit_log_company_id')
            */
            return default;
        }

        protected async Task<MailMessage> ComputeAccountAuditLogMoveIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _compute_account_audit_log_move_id(self):
            // self._compute_audit_log_related_record_id('account.move', 'account_audit_log_move_id')
            */
            return default;
        }

        protected async Task<MailMessage> ComputeAccountAuditLogPartnerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _compute_account_audit_log_partner_id(self):
            // self._compute_audit_log_related_record_id('res.partner', 'account_audit_log_partner_id')
            */
            return default;
        }

        protected async Task<MailMessage> ComputeAccountAuditLogPreviewInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _compute_account_audit_log_preview(self):
            // audit_messages = self.filtered('account_audit_log_activated')
            // (self - audit_messages).account_audit_log_preview = False
            // for message in audit_messages:
            //     title = message.subject or message.preview
            //     tracking_value_ids = message.sudo().tracking_value_ids._filter_has_field_access(self.env)
            //     if not title and tracking_value_ids:
            //         title = self.env._("Updated")
            //     if not title and message.subtype_id and not message.subtype_id.internal:
            //         title = message.subtype_id.display_name
            //     audit_log_preview = (title or '') + '\n'
            //     audit_log_preview += "\n".join(
            //         "%(old_value)s ⇨ %(new_value)s (%(field)s)" % {
            //             'old_value': fmt_vals['oldValue']['value'],
            //             'new_value': fmt_vals['newValue']['value'],
            //             'field': fmt_vals['changedField'],
            //         }
            //         for fmt_vals in tracking_value_ids._tracking_value_format()
            //     )
            //     message.account_audit_log_preview = audit_log_preview
            */
            return default;
        }

        protected async Task<MailMessage> ComputeAccountAuditLogTaxIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _compute_account_audit_log_tax_id(self):
            // self._compute_audit_log_related_record_id('account.tax', 'account_audit_log_tax_id')
            */
            return default;
        }

        protected async Task<MailMessage> ComputeAuditLogRelatedRecordIdInternalAsync(object model, object fname)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _compute_audit_log_related_record_id(self, model, fname):
            // messages_of_related = self.filtered(lambda m: m.model == model and m.res_id)
            // (self - messages_of_related)[fname] = False
            // if messages_of_related:
            //     domain = DOMAINS[model](operator='=', value=True)
            //     related_recs = self.env[model].sudo().search([('id', 'in', messages_of_related.mapped('res_id'))] + domain)
            //     recs_by_id = {record.id: record for record in related_recs}
            //     for message in messages_of_related:
            //         message[fname] = recs_by_id.get(message.res_id, False)
            */
            return default;
        }

        protected async Task<MailMessage> ComputeHasErrorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _compute_has_error(self):
            // error_from_notification = self.env['mail.notification'].sudo().search([
            //     ('mail_message_id', 'in', self.ids),
            //     ('notification_status', 'in', ('bounce', 'exception'))]).mapped('mail_message_id')
            // for message in self:
            //     message.has_error = message in error_from_notification
            */
            return default;
        }

        protected async Task<MailMessage> ComputeHasSmsErrorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: mail_message.py) ---
            // def _compute_has_sms_error(self):
            // sms_error_from_notification = self.env['mail.notification'].sudo().search([
            //     ('notification_type', '=', 'sms'),
            //     ('mail_message_id', 'in', self.ids),
            //     ('notification_status', '=', 'exception')]).mapped('mail_message_id')
            // for message in self:
            //     message.has_sms_error = message in sms_error_from_notification
            */
            return default;
        }

        protected async Task<MailMessage> ComputeIsCurrentUserOrGuestAuthorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _compute_is_current_user_or_guest_author(self):
            // user = self.env.user
            // guest = self.env['mail.guest']._get_guest_from_context()
            // for message in self:
            //     if not user._is_public() and (message.author_id and message.author_id == user.partner_id):
            //         message.is_current_user_or_guest_author = True
            //     elif message.author_guest_id and message.author_guest_id == guest:
            //         message.is_current_user_or_guest_author = True
            //     else:
            //         message.is_current_user_or_guest_author = False
            */
            return default;
        }

        protected async Task<MailMessage> ComputeNeedactionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _compute_needaction(self):
            // """ Need action on a mail.message = notified on my channel """
            // my_messages = self.env['mail.notification'].sudo().search([
            //     ('mail_message_id', 'in', self.ids),
            //     ('res_partner_id', '=', self.env.user.partner_id.id),
            //     ('is_read', '=', False)]).mapped('mail_message_id')
            // for message in self:
            //     message.needaction = message in my_messages
            */
            return default;
        }

        protected async Task<MailMessage> ComputeParentAuthorNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: mail_message.py) ---
            // def _compute_parent_author_name(self):
            // for message in self:
            //     author = message.parent_id.author_id or message.parent_id.author_guest_id
            //     message.parent_author_name = author.name if author else False
            */
            return default;
        }

        protected async Task<MailMessage> ComputeParentBodyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: mail_message.py) ---
            // def _compute_parent_body(self):
            // for message in self:
            //     message.parent_body = message.parent_id.body if message.parent_id else False
            */
            return default;
        }

        protected async Task<MailMessage> ComputePreviewInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _compute_preview(self):
            // """ Returns an un-formatted version of the message body. Output is capped
            // at 100 chars with a ' [...]' suffix if applicable. It is the longest
            // known mail client preview length (Outlook 2013)."""
            // for message in self:
            //     plaintext_ct = tools.mail.html_to_inner_content(message.body)
            //     message.preview = textwrap.shorten(plaintext_ct, 190)
            */
            return default;
        }

        protected async Task<MailMessage> ComputeRatingIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: mail_message.py) ---
            // def _compute_rating_id(self):
            // for message in self:
            //     message.rating_id = message.rating_ids.filtered(lambda rating: rating.consumed).sorted(
            //         "create_date", reverse=True
            //     )[:1]
            */
            return default;
        }

        protected async Task<MailMessage> ComputeRatingValueInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: mail_message.py) ---
            // def _compute_rating_value(self):
            // for message in self:
            //     message.rating_value = message.rating_id.rating if message.rating_id else 0.0
            */
            return default;
        }

        protected async Task<MailMessage> ComputeSnailmailErrorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: snailmail, FILE: mail_message.py) ---
            // def _compute_snailmail_error(self):
            // self.snailmail_error = False
            // for message in self.filtered(lambda msg: msg.message_type == 'snailmail' and msg.letter_ids):
            //     message.snailmail_error = message.letter_ids[0].state == 'error'
            */
            return default;
        }

        protected async Task<MailMessage> ComputeStarredInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _compute_starred(self):
            // """ Compute if the message is starred by the current user. """
            // # TDE FIXME: use SQL
            // starred = self.sudo().filtered(lambda msg: self.env.user.partner_id in msg.starred_partner_ids)
            // for message in self:
            //     message.starred = message in starred
            */
            return default;
        }

        protected async Task<MailMessage> ExceptAuditLogInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _except_audit_log(self):
            // if self.env.context.get('bypass_audit') is bypass_token:
            //     return
            // to_check = self
            // partner_message = self.filtered(lambda m: m.account_audit_log_partner_id)
            // if partner_message:
            //     # The audit trail uses the cheaper check on `customer_rank`, but that field could be set
            //     # without actually having an invoice linked (i.e. creation of the contact through the
            //     # Invoicing/Customers menu)
            //     has_related_move = self.env['account.move'].sudo().search_count([
            //         ('partner_id', 'in', partner_message.account_audit_log_partner_id.ids),
            //         ('company_id.check_account_audit_trail', '=', True),
            //     ], limit=1)
            //     if not has_related_move:
            //         to_check -= partner_message
            // for message in to_check:
            //     if message.account_audit_log_activated and not (
            //         message.account_audit_log_move_id
            //         and not message.account_audit_log_move_id.posted_before
            //     ):
            //         raise UserError(self.env._("You cannot remove parts of the audit trail."))
            */
            return default;
        }

        public async Task<MailMessage> ExportDataAsync(Guid id, MailMessageExportDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def export_data(self, fields_to_export):
            // if not self.env.is_admin():
            //     raise AccessError(_("Only administrators are allowed to export mail message"))
            // 
            // return super(Message, self).export_data(fields_to_export)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailMessage> ExtrasToStoreInternalAsync(object store, object format_reply)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _extras_to_store(self, store: Store, format_reply):
            // super()._extras_to_store(store, format_reply=format_reply)
            // if format_reply:
            //     # sudo: mail.message: access to parent is allowed
            //     for message in self.sudo().filtered(lambda message: message.model == "discuss.channel"):
            //         store.add(
            //             message, {"parentMessage": Store.one(message.parent_id, format_reply=False)}
            //         )
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _extras_to_store(self, store: Store, format_reply):
            // pass
            */
            return default;
        }

        public async Task<MailMessage> FetchAsync(Guid id, MailMessageFetchRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def fetch(self, field_names):
            // # This freaky hack is aimed at reading data without the overhead of
            // # checking that "self" is accessible, which is already done above in
            // # methods read() and _search(). It reproduces the existing behavior
            // # before the introduction of method fetch(), where the low-lever
            // # reading method _read() did not enforce any actual permission.
            // self = self.sudo()
            // return super().fetch(field_names)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailMessage> FilterEmptyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _filter_empty(self):
            // """ Return subset of "void" messages """
            // return self.filtered(
            //     lambda msg:
            //         (not msg.body or tools.is_html_empty(msg.body)) and
            //         (not msg.subtype_id or not msg.subtype_id.description) and
            //         not msg.attachment_ids and
            //         not msg.tracking_value_ids
            // )
            */
            return default;
        }

        protected async Task<MailMessage> FindAllowedDocIdsInternalAsync(List<Guid> model_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _find_allowed_doc_ids(self, model_ids):
            // IrModelAccess = self.env['ir.model.access']
            // allowed_ids = set()
            // for doc_model, doc_dict in model_ids.items():
            //     if not IrModelAccess.check(doc_model, 'read', False):
            //         continue
            //     allowed_ids |= self._find_allowed_model_wise(doc_model, doc_dict)
            // return allowed_ids
            */
            return default;
        }

        protected async Task<MailMessage> FindAllowedModelWiseInternalAsync(object doc_model, object doc_dict)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _find_allowed_model_wise(self, doc_model, doc_dict):
            // doc_ids = list(doc_dict)
            // allowed_doc_ids = self.env[doc_model].with_context(active_test=False).search([('id', 'in', doc_ids)]).ids
            // return set([message_id for allowed_doc_id in allowed_doc_ids for message_id in doc_dict[allowed_doc_id]])
            */
            return default;
        }

        protected async Task<MailMessage> GetForbiddenAccessInternalAsync(string operation)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _get_forbidden_access(self, operation: str) -> api.Self:
            // """ Return the subset of ``self`` that does not satisfy the specific
            // conditions for messages.
            // """
            // forbidden = self.browse()
            // 
            // # Non employees see only messages with a subtype (aka, not internal logs)
            // if not self.env.user._is_internal():
            //     rows = self.env.execute_query(SQL(
            //         ''' SELECT message.id
            //             FROM "mail_message" AS message
            //             LEFT JOIN "mail_message_subtype" as subtype ON message.subtype_id = subtype.id
            //             WHERE message.id = ANY (%s)
            //                 AND message.message_type = 'comment'
            //                 AND (message.is_internal IS TRUE OR message.subtype_id IS NULL OR subtype.internal IS TRUE)
            //         ''',
            //         self.ids,
            //     ))
            //     if rows:
            //         internal = self.browse(id_ for [id_] in rows)
            //         forbidden += internal
            //         self -= internal  # noqa: PLW0642
            //     if not self:
            //         return forbidden
            // 
            // # Read the value of messages in order to determine their accessibility.
            // # The values are put in 'messages_to_check', and entries are popped
            // # once we know they are accessible. At the end, the remaining entries
            // # are the invalid ones.
            // self.flush_recordset(['model', 'res_id', 'author_id', 'create_uid', 'parent_id', 'message_type', 'partner_ids'])
            // self.env['mail.notification'].flush_model(['mail_message_id', 'res_partner_id'])
            // 
            // if operation in ('read', 'write'):
            //     query = SQL(
            //         """ SELECT m.id, m.model, m.res_id, m.author_id, m.create_uid, m.parent_id,
            //                 bool_or(partner_rel.res_partner_id IS NOT NULL OR needaction_rel.res_partner_id IS NOT NULL) AS notified,
            //                 m.message_type
            //             FROM "mail_message" m
            //             LEFT JOIN "mail_message_res_partner_rel" partner_rel
            //                 ON partner_rel.mail_message_id = m.id AND partner_rel.res_partner_id = %(pid)s
            //             LEFT JOIN "mail_notification" needaction_rel
            //                 ON needaction_rel.mail_message_id = m.id AND needaction_rel.res_partner_id = %(pid)s
            //             WHERE m.id = ANY(%(ids)s)
            //             GROUP BY m.id
            //         """,
            //         pid=self.env.user.partner_id.id, ids=self.ids,
            //     )
            // elif operation in ('create', 'unlink'):
            //     query = SQL(
            //         """ SELECT id, model, res_id, author_id, parent_id, message_type
            //             FROM "mail_message"
            //             WHERE id = ANY(%s)
            //         """, self.ids,
            //     )
            // else:
            //     raise ValueError(_('Wrong operation name (%s)', operation))
            // 
            // # trick: messages_to_check doesn't contain missing records from messages
            // messages_to_check = {
            //     values['id']: values
            //     for values in self.env.execute_query_dict(query)
            // }
            // 
            // # Author condition (READ, WRITE, CREATE (private))
            // partner_id = self.env.user.partner_id.id
            // if operation == 'read':
            //     for mid, message in list(messages_to_check.items()):
            //         if (message.get('author_id') == partner_id
            //                 or message.get('create_uid') == self.env.uid):
            //             messages_to_check.pop(mid)
            // elif operation == 'write':
            //     for mid, message in list(messages_to_check.items()):
            //         if message.get('author_id') == partner_id:
            //             messages_to_check.pop(mid)
            // elif operation == 'create':
            //     for mid, message in list(messages_to_check.items()):
            //         if not self.is_thread_message(message):
            //             messages_to_check.pop(mid)
            // 
            // if not messages_to_check:
            //     return forbidden
            // 
            // # Recipients condition, for read and write (partner_ids)
            // # keep on top, usefull for systray notifications
            // if operation in ('read', 'write'):
            //     for mid, message in list(messages_to_check.items()):
            //         if message.get('notified'):
            //             messages_to_check.pop(mid)
            //     if not messages_to_check:
            //         return forbidden
            // 
            // # CRUD: Access rights related to the document
            // # {document_model_name: {document_id: message_ids}}
            // model_docid_msgids = defaultdict(lambda: defaultdict(list))
            // for mid, message in messages_to_check.items():
            //     if (message.get('model') and message.get('res_id') and
            //             message.get('message_type') != 'user_notification'):
            //         model_docid_msgids[message['model']][message['res_id']].append(mid)
            // 
            // for model, docid_msgids in model_docid_msgids.items():
            //     documents = self.env[model].browse(docid_msgids)
            //     if hasattr(documents, '_get_mail_message_access'):
            //         doc_operation = documents._get_mail_message_access(docid_msgids, operation)  # why not giving model here?
            //     else:
            //         doc_operation = self.env['mail.thread']._get_mail_message_access(docid_msgids, operation, model_name=model)
            //     doc_result = documents._check_access(doc_operation)
            //     forbidden_doc_ids = set(doc_result[0]._ids) if doc_result else set()
            //     for doc_id, msg_ids in docid_msgids.items():
            //         if doc_id not in forbidden_doc_ids:
            //             for mid in msg_ids:
            //                 messages_to_check.pop(mid)
            // 
            // if not messages_to_check:
            //     return forbidden
            // 
            // # Parent condition, for create (check for received notifications for the created message parent)
            // if operation == 'create':
            //     parent_ids_msg_ids = defaultdict(list)
            //     for mid, message in messages_to_check.items():
            //         if message.get('parent_id'):
            //             parent_ids_msg_ids[message['parent_id']].append(mid)
            //     if parent_ids_msg_ids:
            //         query = SQL(
            //             """ SELECT m.id
            //                 FROM "mail_message" m
            //                 JOIN "mail_message_res_partner_rel" partner_rel
            //                     ON partner_rel.mail_message_id = m.id AND partner_rel.res_partner_id = %s
            //                 WHERE m.id = ANY(%s) """,
            //             self.env.user.partner_id.id, list(parent_ids_msg_ids),
            //         )
            //         for [parent_id] in self.env.execute_query(query):
            //             for mid in parent_ids_msg_ids[parent_id]:
            //                 messages_to_check.pop(mid)
            // 
            //     if not messages_to_check:
            //         return forbidden
            // 
            //     # Recipients condition for create (message_follower_ids)
            //     for model, docid_msgids in model_docid_msgids.items():
            //         domain = [
            //             ('res_model', '=', model),
            //             ('res_id', 'in', list(docid_msgids)),
            //             ('partner_id', '=', self.env.user.partner_id.id),
            //         ]
            //         followers = self.env['mail.followers'].sudo().search_fetch(domain, ['res_id'])
            //         for follower in followers:
            //             for mid in docid_msgids[follower.res_id]:
            //                 messages_to_check.pop(mid)
            // 
            //     if not messages_to_check:
            //         return forbidden
            // 
            // forbidden += self.browse(messages_to_check)
            // return forbidden
            */
            return default;
        }

        protected async Task<MailMessage> GetMessageIdInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _get_message_id(self, values):
            // if values.get('reply_to_force_new', False) is True:
            //     message_id = tools.mail.generate_tracking_message_id('reply_to')
            // elif self.is_thread_message(values):
            //     message_id = tools.mail.generate_tracking_message_id('%(res_id)s-%(model)s' % values)
            // else:
            //     message_id = tools.mail.generate_tracking_message_id('private')
            // return message_id
            */
            return default;
        }

        protected async Task<MailMessage> GetRecordNameInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _get_record_name(self, values):
            // """ Return the related document name, using display_name. It is done using
            //     SUPERUSER_ID, to be sure to have the record name correctly stored. """
            // model = values.get('model', self.env.context.get('default_model'))
            // res_id = values.get('res_id', self.env.context.get('default_res_id'))
            // if not model or not res_id or model not in self.env:
            //     return False
            // return self.env[model].sudo().browse(res_id).display_name
            */
            return default;
        }

        protected async Task<MailMessage> GetReplyToInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _get_reply_to(self, values):
            // """ Return a specific reply_to for the document """
            // model = values.get('model', self._context.get('default_model'))
            // res_id = values.get('res_id', self._context.get('default_res_id')) or False
            // email_from = values.get('email_from')
            // message_type = values.get('message_type')
            // records = None
            // if self.is_thread_message({'model': model, 'res_id': res_id, 'message_type': message_type}):
            //     records = self.env[model].browse([res_id])
            // else:
            //     records = self.env[model] if model else self.env['mail.thread']
            // return records.sudo()._notify_get_reply_to(default=email_from)[res_id]
            */
            return default;
        }

        protected async Task<MailMessage> GetSearchDomainShareInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _get_search_domain_share(self):
            // return ['&', '&', ('is_internal', '=', False), ('subtype_id', '!=', False), ('subtype_id.internal', '=', False)]
            */
            return default;
        }

        protected async Task<MailMessage> GetWithAccessInternalAsync(Guid message_id, object operation)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _get_with_access(self, message_id, operation, **kwargs):
            // """Return the message with the given id if it exists and if the current
            // user can access it for the given operation."""
            // message = self.browse(message_id).exists()
            // if not message:
            //     return message
            // 
            // if self.env.user._is_public() and self.env["mail.guest"]._get_guest_from_context():
            //     # Don't check_access_rights for public user with a guest, as the rules are
            //     # incorrect due to historically having no reason to allow operations on messages to
            //     # public user before the introduction of guests. Even with ignoring the rights,
            //     # check_access_rule and its sub methods are already covering all the cases properly.
            //     if not message.sudo(False)._get_forbidden_access(operation):
            //         return message
            // else:
            //     if message.sudo(False).has_access(operation):
            //         return message
            // 
            // if message.model and message.res_id:
            //     mode = self.env[message.model]._get_mail_message_access([message.res_id], operation)
            //     if self.env[message.model]._get_thread_with_access(message.res_id, mode, **kwargs):
            //         return message
            // 
            // return self.browse()
            */
            return default;
        }

        public async Task<MailMessage> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def init(self):
            // self._cr.execute("""SELECT indexname FROM pg_indexes WHERE indexname = 'mail_message_model_res_id_idx'""")
            // if not self._cr.fetchone():
            //     self._cr.execute("""CREATE INDEX mail_message_model_res_id_idx ON mail_message (model, res_id)""")
            // self._cr.execute("""CREATE INDEX IF NOT EXISTS mail_message_model_res_id_id_idx ON mail_message (model, res_id, id)""")
            --- ODOO METHOD SOURCE (MODULE: project, FILE: mail_message.py) ---
            // def init(self):
            // super().init()
            // create_index(
            //     self._cr,
            //     'mail_message_date_res_id_id_for_burndown_chart',
            //     self._table,
            //     ['date', 'res_id', 'id'],
            //     where="model='project.task' AND message_type='notification'"
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailMessage> InvalidateDocumentsInternalAsync(object model, Guid res_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _invalidate_documents(self, model=None, res_id=None):
            // """ Invalidate the cache of the documents followed by ``self``. """
            // fnames = ['message_ids', 'message_needaction', 'message_needaction_counter']
            // self.flush_recordset(['model', 'res_id'])
            // for record in self:
            //     model = model or record.model
            //     res_id = res_id or record.res_id
            //     if model in self.pool and issubclass(self.pool[model], self.pool['mail.thread']):
            //         self.env[model].browse(res_id).invalidate_recordset(fnames)
            */
            return default;
        }

        protected async Task<MailMessage> IsEditableInPortalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: mail_message.py) ---
            // def _is_editable_in_portal(self, **kwargs):
            // self.ensure_one()
            // if self.model and self.res_id and self.env.user._is_public():
            //     thread = request.env[self.model].browse(self.res_id)
            //     partner = get_portal_partner(
            //         thread, kwargs.get("hash"), kwargs.get("pid"), kwargs.get("token")
            //     )
            //     if partner and self.author_id == partner:
            //         return True
            // return False
            */
            return default;
        }

        public async Task<MailMessage> IsThreadMessageAsync(Guid id, MailMessageIsThreadMessageRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def is_thread_message(self, vals=None):
            // if vals:
            //     res_id = vals.get('res_id')
            //     model = vals.get('model')
            //     message_type = vals.get('message_type')
            // else:
            //     self.ensure_one()
            //     res_id = self.res_id
            //     model = self.model
            //     message_type = self.message_type
            // return res_id and model and message_type != 'user_notification'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<object> MakeAccessErrorInternalAsync(string operation)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _make_access_error(self, operation: str) -> AccessError:
            // return AccessError(_(
            //     "The requested operation cannot be completed due to security restrictions. "
            //     "Please contact your system administrator.\n\n"
            //     "(Document type: %(type)s, Operation: %(operation)s)\n\n"
            //     "Records: %(records)s, User: %(user)s",
            //     type=self._description,
            //     operation=operation,
            //     records=self.ids[:6],
            //     user=self.env.uid,
            // ))
            */
            return default;
        }

        public async Task<MailMessage> MarkAllAsReadAsync(Guid id, MailMessageMarkAllAsReadRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def mark_all_as_read(self, domain=None):
            // # not really efficient method: it does one db request for the
            // # search, and one for each message in the result set is_read to True in the
            // # current notifications from the relation.
            // notif_domain = [
            //     ('res_partner_id', '=', self.env.user.partner_id.id),
            //     ('is_read', '=', False)]
            // if domain:
            //     messages = self.search(domain)
            //     messages.set_message_done()
            //     return messages.ids
            // 
            // notifications = self.env['mail.notification'].sudo().search_fetch(notif_domain, ['mail_message_id'])
            // notifications.write({'is_read': True})
            // 
            // self.env.user._bus_send(
            //     "mail.message/mark_as_read",
            //     {
            //         "message_ids": notifications.mail_message_id.ids,
            //         "needaction_inbox_counter": self.env.user.partner_id._get_needaction_count(),
            //     },
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailMessage> MessageFetchInternalAsync(object domain, object search_term, object before, object after, object around, object limit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _message_fetch(self, domain, search_term=None, before=None, after=None, around=None, limit=30):
            // res = {}
            // if search_term:
            //     # we replace every space by a % to avoid hard spacing matching
            //     search_term = search_term.replace(" ", "%")
            //     domain = expression.AND([domain, expression.OR([
            //         # sudo: access to attachment is allowed if you have access to the parent model
            //         [("attachment_ids", "in", self.env["ir.attachment"].sudo()._search([("name", "ilike", search_term)]))],
            //         [("body", "ilike", search_term)],
            //         [("subject", "ilike", search_term)],
            //         [("subtype_id.description", "ilike", search_term)],
            //     ])])
            //     res["count"] = self.search_count(domain)
            // if around is not None:
            //     messages_before = self.search(domain=[*domain, ('id', '<=', around)], limit=limit // 2, order="id DESC")
            //     messages_after = self.search(domain=[*domain, ('id', '>', around)], limit=limit // 2, order='id ASC')
            //     return {**res, "messages": (messages_after + messages_before).sorted('id', reverse=True)}
            // if before:
            //     domain = expression.AND([domain, [('id', '<', before)]])
            // if after:
            //     domain = expression.AND([domain, [('id', '>', after)]])
            // res["messages"] = self.search(domain, limit=limit, order='id ASC' if after else 'id DESC')
            // if after:
            //     res["messages"] = res["messages"].sorted('id', reverse=True)
            // return res
            */
            return default;
        }

        protected async Task<MailMessage> MessageNotificationsToStoreInternalAsync(object store)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _message_notifications_to_store(self, store: Store):
            // """Returns the current messages and their corresponding notifications in
            // the format expected by the web client.
            // 
            // Notifications hold the information about each recipient of a message: if
            // the message was successfully sent or if an exception or bounce occurred.
            // """
            // for message in self:
            //     message_data = {
            //         "author": Store.one(message.author_id, only_id=True),
            //         "date": message.date,
            //         "message_type": message.message_type,
            //         "body": message.body,
            //         "notifications": Store.many(message.notification_ids._filtered_for_web_client()),
            //         "thread": (
            //             Store.one(
            //                 self.env[message.model].browse(message.res_id) if message.model else False,
            //                 as_thread=True,
            //                 fields=["modelName", "name" if message.model == "discuss.channel" else "display_name"],
            //             )
            //         ),
            //     }
            //     store.add(message, message_data)
            */
            return default;
        }

        protected async Task<MailMessage> MessageReactionInternalAsync(object content, object action, object partner, object guest, object store)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _message_reaction(self, content, action, partner, guest, store: Store = None):
            // self.ensure_one()
            // # search for existing reaction
            // domain = [
            //     ("message_id", "=", self.id),
            //     ("partner_id", "=", partner.id),
            //     ("guest_id", "=", guest.id),
            //     ("content", "=", content),
            // ]
            // reaction = self.env["mail.message.reaction"].search(domain)
            // # create/unlink reaction if necessary
            // if action == "add" and not reaction:
            //     create_values = {
            //         "message_id": self.id,
            //         "content": content,
            //         "partner_id": partner.id,
            //         "guest_id": guest.id,
            //     }
            //     self.env["mail.message.reaction"].create(create_values)
            // if action == "remove" and reaction:
            //     reaction.unlink()
            // if store:
            //     # fill the store to use for non logged in portal users in mail_message_reaction()
            //     self._reaction_group_to_store(store, content)
            // # send the reaction group to bus for logged in users
            // self._bus_send_reaction_group(content)
            */
            return default;
        }

        protected async Task<MailMessage> NotifyMessageNotificationUpdateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _notify_message_notification_update(self):
            // """Send bus notifications to update status of notifications in the web
            // client. Purpose is to send the updated status per author."""
            // messages = self.env['mail.message']
            // record_by_message = self._record_by_message()
            // for message in self:
            //     # Check if user has access to the record before displaying a notification about it.
            //     # In case the user switches from one company to another, it might happen that they don't
            //     # have access to the record related to the notification. In this case, we skip it.
            //     # YTI FIXME: check allowed_company_ids if necessary
            //     if record := record_by_message.get(message):
            //         if record.has_access('read'):
            //             messages += message
            // messages_per_partner = defaultdict(lambda: self.env['mail.message'])
            // for message in messages:
            //     if not self.env.user._is_public():
            //         messages_per_partner[self.env.user.partner_id] |= message
            //     if message.author_id and not any(user._is_public() for user in message.author_id.with_context(active_test=False).user_ids):
            //         messages_per_partner[message.author_id] |= message
            // for partner, messages in messages_per_partner.items():
            //     store = Store()
            //     messages._message_notifications_to_store(store)
            //     partner._bus_send_store(store)
            */
            return default;
        }

        public async Task<MailMessage> OpenDocumentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def action_open_document(self):
            // """ Opens the related record based on the model and ID """
            // self.ensure_one()
            // return {
            //     'res_id': self.res_id,
            //     'res_model': self.model,
            //     'target': 'current',
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailMessage> PortalGetDefaultFormatPropertiesNamesInternalAsync(object options)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: mail_message.py) ---
            // def _portal_get_default_format_properties_names(self, options=None):
            // """ Fields and values to compute for portal format.
            // 
            // :param dict options: options, used notably for inheritance and adding
            //   specific fields or properties to compute;
            // 
            // :return set: fields or properties derived from fields
            // """
            // return {
            //     'attachment_ids',
            //     'author_avatar_url',
            //     'author_id',
            //     'author_guest_id',
            //     'body',
            //     'date',
            //     'id',
            //     'is_internal',
            //     'is_message_subtype_note',
            //     'message_type',
            //     'model',
            //     'published_date_str',
            //     'res_id',
            //     'starred',
            //     'subtype_id',
            // }
            --- ODOO METHOD SOURCE (MODULE: portal_rating, FILE: mail_message.py) ---
            // def _portal_get_default_format_properties_names(self, options=None):
            // """ Add request for rating information
            // 
            // :param dict options: supports 'rating_include' option allowing to
            //   conditionally include rating information;
            // """
            // properties_names = super()._portal_get_default_format_properties_names()
            // if options and options.get('rating_include'):
            //     properties_names |= {
            //         'rating',
            //         'rating_value',
            //     }
            // return properties_names
            */
            return default;
        }

        public async Task<MailMessage> PortalMessageFormatAsync(Guid id, MailMessagePortalMessageFormatRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: mail_message.py) ---
            // def portal_message_format(self, options=None):
            // """ Simpler and portal-oriented version of 'message_format'. Purpose
            // is to prepare, organize and format values required by frontend widget
            // (frontend Chatter).
            // 
            // This public API asks for read access on messages before doing the
            // actual computation in the private implementation.
            // 
            // :param dict options: options, used notably for inheritance and adding
            //   specific fields or properties to compute;
            // 
            // :return list: list of dict, one per message in self. Each dict contains
            //   values for either fields, either properties derived from fields.
            // """
            // self.check_access('read')
            // return self._portal_message_format(
            //     self._portal_get_default_format_properties_names(options=options),
            //     options=options,
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailMessage> PortalMessageFormatAttachmentsInternalAsync(object attachment_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: mail_message.py) ---
            // def _portal_message_format_attachments(self, attachment_values):
            // """ From 'attachment_values' get an updated version formatted for
            // frontend display.
            // 
            // :param dict attachment_values: values coming from reading attachments
            //   in database;
            // 
            // :return dict: updated attachment_values
            // """
            // safari = request and request.httprequest.user_agent and request.httprequest.user_agent.browser == 'safari'
            // attachment_values['filename'] = attachment_values['name']
            // attachment_values['mimetype'] = (
            //     'application/octet-stream' if safari and
            //     'video' in (attachment_values["mimetype"] or "")
            //     else attachment_values["mimetype"])
            // return attachment_values
            */
            return default;
        }

        protected async Task<MailMessage> PortalMessageFormatInternalAsync(object properties_names, object options)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: mail_message.py) ---
            // def _portal_message_format(self, properties_names, options=None):
            // """ Format messages for portal frontend. This private implementation
            // does not check for access that should be checked beforehand.
            // 
            // Notes:
            //   * when asking for attachments: ensure an access token is present then
            //     access them (using sudo);
            // 
            // :param set properties_names: fields or properties derived from fields
            //   for which we are going to compute values;
            // 
            // :return list: list of dict, one per message in self. Each dict contains
            //   values for either fields, either properties derived from fields.
            // """
            // message_to_attachments = {}
            // if 'attachment_ids' in properties_names:
            //     properties_names.remove('attachment_ids')
            //     attachments_sudo = self.sudo().attachment_ids
            //     attachments_sudo.generate_access_token()
            //     related_attachments = {
            //         att_read_values['id']: att_read_values
            //         for att_read_values in attachments_sudo.read(
            //             ["access_token", "checksum", "id", "mimetype", "name", "res_id", "res_model"]
            //         )
            //     }
            //     message_to_attachments = {
            //         message.id: [
            //             self._portal_message_format_attachments(related_attachments[att_id])
            //             for att_id in message.attachment_ids.ids
            //         ]
            //         for message in self.sudo()
            //     }
            // 
            // fnames = {
            //     property_name for property_name in properties_names
            //     if property_name in self._fields
            // }
            // vals_list = self._read_format(fnames)
            // 
            // note_id = self.env['ir.model.data']._xmlid_to_res_id('mail.mt_note')
            // for message, values in zip(self, vals_list):
            //     if message_to_attachments:
            //         values['attachment_ids'] = message_to_attachments.get(message.id, {})
            //     if 'author_avatar_url' in properties_names:
            //         if options and options.get("token"):
            //             values['author_avatar_url'] = f'/mail/avatar/mail.message/{message.id}/author_avatar/50x50?access_token={options["token"]}'
            //         elif options and options.get("hash") and options.get("pid"):
            //             values['author_avatar_url'] = f'/mail/avatar/mail.message/{message.id}/author_avatar/50x50?_hash={options["hash"]}&pid={options["pid"]}'
            //         else:
            //             values['author_avatar_url'] = f'/web/image/mail.message/{message.id}/author_avatar/50x50'
            //     if 'is_message_subtype_note' in properties_names:
            //         values['is_message_subtype_note'] = (values.get('subtype_id') or [False, ''])[0] == note_id
            //     if 'published_date_str' in properties_names:
            //         values['published_date_str'] = format_datetime(self.env, values['date']) if values.get('date') else ''
            //     reaction_groups = []
            //     for content, reactions in groupby(message.sudo().reaction_ids, lambda r: r.content):
            //         reactions = self.env["mail.message.reaction"].union(*reactions)
            //         reaction_groups.append(
            //             {
            //                 "content": content,
            //                 "count": len(reactions),
            //                 "personas": [
            //                                 {"id": guest.id, "name": guest.name, "type": "guest"}
            //                                 for guest in reactions.guest_id
            //                             ]
            //                             + [
            //                                 # sudo: res.partner - reading partners of reaction on accessible message is allowed
            //                                 {"id": partner.id, "name": partner.name, "type": "partner"}
            //                                 for partner in reactions.partner_id.sudo()
            //                             ],
            //                 "message": message.id,
            //             }
            //         )
            //     values.update(
            //         {
            //             "reactions": reaction_groups,
            //             "author": {
            //                 "id": message.author_id.id,
            //                 "name": message.author_id.name,
            //                 "type": "partner",
            //             },
            //             "thread": {"model": values["model"], "id": values["res_id"]},
            //         }
            //     )
            // return vals_list
            --- ODOO METHOD SOURCE (MODULE: portal_rating, FILE: mail_message.py) ---
            // def _portal_message_format(self, properties_names, options=None):
            // """ If requested, add rating information to returned formatted values.
            // 
            // Note: rating information combine both statistics (see 'rating_get_stats'
            // if available on model) and rating / publication information. """
            // vals_list = super()._portal_message_format(properties_names, options=options)
            // if not 'rating' in properties_names:
            //     return vals_list
            // 
            // related_rating = self.env['rating.rating'].sudo().search_read(
            //     [('message_id', 'in', self.ids)],
            //     ["id", "publisher_comment", "publisher_id", "publisher_datetime", "message_id"]
            // )
            // message_to_rating = {
            //     rating['message_id'][0]: self._portal_message_format_rating(rating)
            //     for rating in related_rating
            // }
            // 
            // for message, values in zip(self, vals_list):
            //     values["rating"] = message_to_rating.get(message.id, {})
            // 
            //     record = self.env[message.model].browse(message.res_id)
            //     if hasattr(record, 'rating_get_stats'):
            //         values['rating_stats'] = record.sudo().rating_get_stats()
            // 
            // return vals_list
            */
            return default;
        }

        protected async Task<MailMessage> PortalMessageFormatRatingInternalAsync(object rating_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: portal_rating, FILE: mail_message.py) ---
            // def _portal_message_format_rating(self, rating_values):
            // """ From 'rating_values' get an updated version formatted for frontend
            // display.
            // 
            // :param dict rating_values: values coming from reading ratings
            //   in database;
            // 
            // :return dict: updated rating_values
            // """
            // publisher_id, publisher_name = rating_values['publisher_id'] or [False, '']
            // rating_values['publisher_avatar'] = f'/web/image/res.partner/{publisher_id}/avatar_128/50x50' if publisher_id else ''
            // rating_values['publisher_comment'] = rating_values['publisher_comment'] or ''
            // rating_values['publisher_datetime'] = format_datetime(self.env, rating_values['publisher_datetime'])
            // rating_values['publisher_id'] = publisher_id
            // rating_values['publisher_name'] = publisher_name
            // return rating_values
            */
            return default;
        }

        protected async Task<MailMessage> ReactionGroupToStoreInternalAsync(object store, object content)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _reaction_group_to_store(self, store: Store, content):
            // group_domain = [("message_id", "=", self.id), ("content", "=", content)]
            // reactions = self.env["mail.message.reaction"].search(group_domain)
            // reaction_group = (
            //     Store.many(reactions, "ADD")
            //     if reactions
            //     else [("DELETE", {"message": self.id, "content": content})]
            // )
            // store.add(self, {"reactions": reaction_group})
            */
            return default;
        }

        protected async Task<MailMessage> RecordByMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _record_by_message(self):
            // records_by_model_name = self._records_by_model_name()
            // return {
            //     message: self.env[message.model]
            //     .browse(message.res_id)
            //     .with_prefetch(records_by_model_name[message.model]._prefetch_ids)
            //     for message in self.filtered(lambda m: m.model and m.res_id)
            // }
            */
            return default;
        }

        protected async Task<MailMessage> RecordsByModelNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _records_by_model_name(self):
            // ids_by_model = defaultdict(OrderedSet)
            // prefetch_ids_by_model = defaultdict(OrderedSet)
            // prefetch_messages = self | self.browse(self._prefetch_ids)
            // for message in prefetch_messages.filtered(lambda m: m.model and m.res_id):
            //     target = ids_by_model if message in self else prefetch_ids_by_model
            //     target[message.model].add(message.res_id)
            // return {
            //     model_name: self.env[model_name]
            //     .browse(ids)
            //     .with_prefetch(tuple(ids_by_model[model_name] | prefetch_ids_by_model[model_name]))
            //     for model_name, ids in ids_by_model.items()
            // }
            */
            return default;
        }

        protected async Task<MailMessage> SearchAccountAuditLogAccountIdInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _search_account_audit_log_account_id(self, operator, value):
            // return self._search_audit_log_related_record_id('account.account', operator, value)
            */
            return default;
        }

        protected async Task<MailMessage> SearchAccountAuditLogActivatedInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _search_account_audit_log_activated(self, operator, value):
            // if operator not in ['=', '!='] or not isinstance(value, bool):
            //     raise UserError(self.env._('Operation not supported'))
            // return [('message_type', '=', 'notification')] + OR([
            //     [('model', '=', model), ('res_id', 'in', self.env[model]._search(DOMAINS[model](operator, value)))]
            //     for model in DOMAINS
            // ])
            */
            return default;
        }

        protected async Task<MailMessage> SearchAccountAuditLogCompanyIdInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _search_account_audit_log_company_id(self, operator, value):
            // return self._search_audit_log_related_record_id('res.company', operator, value)
            */
            return default;
        }

        protected async Task<MailMessage> SearchAccountAuditLogMoveIdInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _search_account_audit_log_move_id(self, operator, value):
            // return self._search_audit_log_related_record_id('account.move', operator, value)
            */
            return default;
        }

        protected async Task<MailMessage> SearchAccountAuditLogPartnerIdInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _search_account_audit_log_partner_id(self, operator, value):
            // return self._search_audit_log_related_record_id('res.partner', operator, value)
            */
            return default;
        }

        protected async Task<MailMessage> SearchAccountAuditLogTaxIdInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _search_account_audit_log_tax_id(self, operator, value):
            // return self._search_audit_log_related_record_id('account.tax', operator, value)
            */
            return default;
        }

        protected async Task<MailMessage> SearchAuditLogRelatedRecordIdInternalAsync(object model, object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _search_audit_log_related_record_id(self, model, operator, value):
            // if operator in ['=', 'like', 'ilike', '!=', 'not ilike', 'not like'] and isinstance(value, str):
            //     res_id_domain = [('res_id', 'in', self.env[model]._search([('display_name', operator, value)]))]
            // elif operator in ['=', 'in', '!=', 'not in']:
            //     res_id_domain = [('res_id', operator, value)]
            // else:
            //     raise UserError(self.env._('Operation not supported'))
            // return [('model', '=', model)] + res_id_domain
            */
            return default;
        }

        protected async Task<MailMessage> SearchHasErrorInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _search_has_error(self, operator, operand):
            // if operator == '=' and operand:
            //     return [('notification_ids.notification_status', 'in', ('bounce', 'exception'))]
            // return ['!', ('notification_ids.notification_status', 'in', ('bounce', 'exception'))]
            */
            return default;
        }

        protected async Task<MailMessage> SearchHasSmsErrorInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: mail_message.py) ---
            // def _search_has_sms_error(self, operator, operand):
            // if operator == '=' and operand:
            //     return ['&', ('notification_ids.notification_status', '=', 'exception'), ('notification_ids.notification_type', '=', 'sms')]
            // raise NotImplementedError()
            */
            return default;
        }

        protected async Task<MailMessage> SearchInternalAsync(object domain, object offset, object limit, object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _search(self, domain, offset=0, limit=None, order=None):
            // """ Override that adds specific access rights of mail.message, to remove
            // ids uid could not see according to our custom rules. Please refer to
            // _check_access() for more details about those rules.
            // 
            // Non employees users see only message with subtype (aka do not see
            // internal logs).
            // 
            // After having received ids of a classic search, keep only:
            // - if author_id == pid, uid is the author, OR
            // - uid belongs to a notified channel, OR
            // - uid is in the specified recipients, OR
            // - uid has a notification on the message
            // - otherwise: remove the id
            // """
            // # Rules do not apply to administrator
            // if self.env.is_superuser():
            //     return super()._search(domain, offset, limit, order)
            // 
            // # Non-employee see only messages with a subtype and not internal
            // if not self.env.user._is_internal():
            //     domain = self._get_search_domain_share() + domain
            // 
            // # make the search query with the default rules
            // query = super()._search(domain, offset, limit, order)
            // 
            // # retrieve matching records and determine which ones are truly accessible
            // self.flush_model(['model', 'res_id', 'author_id', 'message_type', 'partner_ids'])
            // self.env['mail.notification'].flush_model(['mail_message_id', 'res_partner_id'])
            // 
            // pid = self.env.user.partner_id.id
            // ids = []
            // allowed_ids = set()
            // model_ids = defaultdict(lambda: defaultdict(set))
            // 
            // rel_alias = query.make_alias(self._table, 'partner_ids')
            // query.add_join("LEFT JOIN", rel_alias, 'mail_message_res_partner_rel', SQL(
            //     "%s = %s AND %s = %s",
            //     SQL.identifier(self._table, 'id'),
            //     SQL.identifier(rel_alias, 'mail_message_id'),
            //     SQL.identifier(rel_alias, 'res_partner_id'),
            //     pid,
            // ))
            // notif_alias = query.make_alias(self._table, 'notification_ids')
            // query.add_join("LEFT JOIN", notif_alias, 'mail_notification', SQL(
            //     "%s = %s AND %s = %s",
            //     SQL.identifier(self._table, 'id'),
            //     SQL.identifier(notif_alias, 'mail_message_id'),
            //     SQL.identifier(notif_alias, 'res_partner_id'),
            //     pid,
            // ))
            // self.env.cr.execute(query.select(
            //     SQL.identifier(self._table, 'id'),
            //     SQL.identifier(self._table, 'model'),
            //     SQL.identifier(self._table, 'res_id'),
            //     SQL.identifier(self._table, 'author_id'),
            //     SQL.identifier(self._table, 'message_type'),
            //     SQL(
            //         "COALESCE(%s, %s)",
            //         SQL.identifier(rel_alias, 'res_partner_id'),
            //         SQL.identifier(notif_alias, 'res_partner_id'),
            //     ),
            // ))
            // for id_, model, res_id, author_id, message_type, partner_id in self.env.cr.fetchall():
            //     ids.append(id_)
            //     if author_id == pid:
            //         allowed_ids.add(id_)
            //     elif partner_id == pid:
            //         allowed_ids.add(id_)
            //     elif model and res_id and message_type != 'user_notification':
            //         model_ids[model][res_id].add(id_)
            // 
            // allowed_ids.update(self._find_allowed_doc_ids(model_ids))
            // allowed = self.browse(id_ for id_ in ids if id_ in allowed_ids)
            // return allowed._as_query(order)
            */
            return default;
        }

        protected async Task<MailMessage> SearchNeedactionInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _search_needaction(self, operator, operand):
            // is_read = False if operator == '=' and operand else True
            // notification_ids = self.env['mail.notification']._search([('res_partner_id', '=', self.env.user.partner_id.id), ('is_read', '=', is_read)])
            // return [('notification_ids', 'in', notification_ids)]
            */
            return default;
        }

        protected async Task<MailMessage> SearchRatingValueInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: mail_message.py) ---
            // def _search_rating_value(self, operator, operand):
            // ratings = self.env['rating.rating'].sudo().search([
            //     ('rating', operator, operand),
            //     ('message_id', '!=', False),
            //     ("consumed", "=", True),
            // ])
            // return [('id', 'in', ratings.mapped('message_id').ids)]
            */
            return default;
        }

        protected async Task<MailMessage> SearchSnailmailErrorInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: snailmail, FILE: mail_message.py) ---
            // def _search_snailmail_error(self, operator, operand):
            // if operator == '=' and operand:
            //     return ['&', ('letter_ids.state', '=', 'error'), ('letter_ids.user_id', '=', self.env.user.id)]
            // return ['!', '&', ('letter_ids.state', '=', 'error'), ('letter_ids.user_id', '=', self.env.user.id)]
            */
            return default;
        }

        protected async Task<MailMessage> SearchStarredInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _search_starred(self, operator, operand):
            // if operator == '=' and operand:
            //     return [('starred_partner_ids', 'in', [self.env.user.partner_id.id])]
            // return [('starred_partner_ids', 'not in', [self.env.user.partner_id.id])]
            */
            return default;
        }

        public async Task<MailMessage> SendLetterAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: snailmail, FILE: mail_message.py) ---
            // def send_letter(self):
            // self.letter_ids._snailmail_print()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailMessage> SetMessageDoneAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def set_message_done(self):
            // """ Remove the needaction from messages for the current partner. """
            // partner_id = self.env.user.partner_id
            // notifications = self.env['mail.notification'].sudo().search_fetch([
            //     ('mail_message_id', 'in', self.ids),
            //     ('res_partner_id', '=', partner_id.id),
            //     ('is_read', '=', False),
            // ], ['mail_message_id'])
            // if not notifications:
            //     return
            // notifications.write({'is_read': True})
            // # notifies changes in messages through the bus.
            // self.env.user._bus_send(
            //     "mail.message/mark_as_read",
            //     {
            //         "message_ids": notifications.mail_message_id.ids,
            //         "needaction_inbox_counter": self.env.user.partner_id._get_needaction_count(),
            //     },
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailMessage> ToStoreInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: mail_message.py) ---
            // def _to_store(self, store: Store, **kwargs):
            // """If we are currently running a chatbot.script, we include the information about
            // the chatbot.message related to this mail.message.
            // This allows the frontend display to include the additional features
            // (e.g: Show additional buttons with the available answers for this step)."""
            // super()._to_store(store, **kwargs)
            // channel_messages = self.filtered(lambda message: message.model == "discuss.channel")
            // channel_by_message = channel_messages._record_by_message()
            // for message in channel_messages.filtered(
            //     lambda message: channel_by_message[message].channel_type == "livechat"
            // ):
            //     channel = channel_by_message[message]
            //     # sudo: chatbot.script.step - checking whether the current message is from chatbot
            //     chatbot = channel.chatbot_current_step_id.sudo().chatbot_script_id.operator_partner_id
            //     if (channel.chatbot_current_step_id and message.author_id == chatbot):
            //         chatbot_message = (
            //             self.env["chatbot.message"]
            //             .sudo()
            //             .search([("mail_message_id", "=", message.id)], limit=1)
            //         )
            //         if step := chatbot_message.script_step_id:
            //             step_data = {
            //                 "id": (step.id, message.id),
            //                 "message": Store.one(message, only_id=True),
            //                 "scriptStep": Store.one(step, only_id=True),
            //                 "operatorFound": step.step_type == "forward_operator"
            //                 and len(channel.channel_member_ids) > 2,
            //             }
            //             if answer := chatbot_message.user_script_answer_id:
            //                 step_data["selectedAnswer"] = Store.one(answer, only_id=True)
            //             store.add("ChatbotStep", step_data)
            //             store.add(
            //                 message,
            //                 {"chatbotStep": {"scriptStep": step.id, "message": message.id}},
            //             )
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _to_store(
            //     self,
            //     store: Store,
            //     /,
            //     *,
            //     fields=None,
            //     format_reply=True,
            //     msg_vals=None,
            //     for_current_user=False,
            //     add_followers=False,
            //     followers=None,
            // ):
            //     """Add the messages to the given store.
            // 
            //     :param format_reply: if True, also get data about the parent message if it exists.
            //         Only makes sense for discuss channel.
            // 
            //     :param msg_vals: dictionary of values used to create the message. If
            //       given it may be used to access values related to ``message`` without
            //       accessing it directly. It lessens query count in some optimized use
            //       cases by avoiding access message content in db;
            // 
            //     :param for_current_user: if True, get extra fields only relevant to the current user.
            //         When this param is set, the result should not be broadcasted to other users!
            // 
            //     :param add_followers: if True, also add followers of the current user for each thread of
            //         each message. Only applicable if ``for_current_user`` is also True.
            // 
            //     :param followers: if given, use this pre-computed list of followers instead of fetching
            //         them. It lessen query count in some optimized use cases.
            //         Only applicable if ``add_followers`` is True.
            //     """
            //     if fields is None:
            //         fields = [
            //             "body",
            //             "create_date",
            //             "date",
            //             "message_type",
            //             "model",  # keep for iOS app
            //             "pinned_at",
            //             "res_id",  # keep for iOS app
            //             "subject",
            //             "write_date",
            //         ]
            //     com_id = self.env["ir.model.data"]._xmlid_to_res_id("mail.mt_comment")
            //     note_id = self.env["ir.model.data"]._xmlid_to_res_id("mail.mt_note")
            //     # fetch scheduled notifications once, only if msg_vals is not given to
            //     # avoid useless queries when notifying Inbox right after a message_post
            //     scheduled_dt_by_msg_id = {}
            //     if msg_vals:
            //         scheduled_dt_by_msg_id = {msg.id: msg_vals.get("scheduled_date", False) for msg in self}
            //     elif self:
            //         schedulers = (
            //             self.env["mail.message.schedule"]
            //             .sudo()
            //             .search([("mail_message_id", "in", self.ids)])
            //         )
            //         for scheduler in schedulers:
            //             scheduled_dt_by_msg_id[scheduler.mail_message_id.id] = scheduler.scheduled_datetime
            //     record_by_message = self._record_by_message()
            //     records = record_by_message.values()
            //     non_channel_records = filter(lambda record: record._name != "discuss.channel", records)
            //     if for_current_user and add_followers and non_channel_records:
            //         if followers is None:
            //             domain = expression.OR(
            //                 [("res_model", "=", model), ("res_id", "in", [r.id for r in records])]
            //                 for model, records in groupby(non_channel_records, key=lambda r: r._name)
            //             )
            //             domain = expression.AND(
            //                 [domain, [("partner_id", "=", self.env.user.partner_id.id)]]
            //             )
            //             # sudo: mail.followers - reading followers of current partner
            //             followers = self.env["mail.followers"].sudo().search(domain)
            //         follower_by_record_and_partner = {
            //             (
            //                 self.env[follower.res_model].browse(follower.res_id),
            //                 follower.partner_id,
            //             ): follower
            //             for follower in followers
            //         }
            //     for record in records:
            //         thread_data = {}
            //         if record._name != "discuss.channel":
            //             try:
            //                 # sudo: mail.thread - if mentionned in a non accessible thread, name is allowed
            //                 thread_data["name"] = record.sudo().display_name
            //             except MissingError:
            //                 continue  # related non mail.thread document deleted, still show message in history
            //         if self.env[record._name]._original_module:
            //             thread_data["module_icon"] = modules.module.get_module_icon(
            //                 self.env[record._name]._original_module
            //             )
            //         if for_current_user and add_followers:
            //             thread_data["selfFollower"] = Store.one(
            //                 follower_by_record_and_partner.get((record, self.env.user.partner_id)),
            //                 fields={"is_active": True, "partner": []},
            //             )
            //         store.add(record, thread_data, as_thread=True)
            //     for message in self:
            //         # model, res_id, record_name need to be kept for mobile app as iOS app cannot be updated
            //         data = message._read_format(fields, load=False)[0]
            //         record = record_by_message.get(message)
            //         record_name = False
            //         default_subject = False
            //         if record:
            //             with contextlib.suppress(MissingError):
            //                 # sudo: if mentionned in a non accessible thread, user should be able to see the name
            //                 record_name = record.sudo().display_name
            //             if record_name:
            //                 default_subject = record_name
            //                 if hasattr(record, "_message_compute_subject"):
            //                     # sudo: if mentionned in a non accessible thread, user should be able to see the subject
            //                     default_subject = record.sudo()._message_compute_subject()
            //         data["default_subject"] = default_subject
            //         vals = {
            //             # sudo: mail.message - reading attachments on accessible message is allowed
            //             "attachment_ids": Store.many(message.sudo().attachment_ids.sorted("id")),
            //             # sudo: mail.message - reading link preview on accessible message is allowed
            //             "linkPreviews": Store.many(
            //                 message.sudo().link_preview_ids.filtered(lambda l: not l.is_hidden)
            //             ),
            //             # sudo: mail.message - reading reactions on accessible message is allowed
            //             "reactions": Store.many(message.sudo().reaction_ids),
            //             "record_name": record_name,  # keep for iOS app
            //             "is_note": message.subtype_id.id == note_id,
            //             "is_discussion": message.subtype_id.id == com_id,
            //             # sudo: mail.message.subtype - reading description on accessible message is allowed
            //             "subtype_description": message.subtype_id.sudo().description,
            //             # sudo: res.partner: reading limited data of recipients is acceptable
            //             "recipients": Store.many(message.sudo().partner_ids, fields=["avatar_128", "name"]),
            //             "scheduledDatetime": scheduled_dt_by_msg_id.get(message.id, False),
            //             "thread": Store.one(record, as_thread=True, only_id=True),
            //         }
            //         if self.env.user._is_internal():
            //             vals["notifications"] = Store.many(message.notification_ids._filtered_for_web_client())
            //         if for_current_user:
            //             # sudo: mail.message - filtering allowed tracking values
            //             displayed_tracking_ids = message.sudo().tracking_value_ids._filter_has_field_access(
            //                 self.env
            //             )
            //             if record and hasattr(record, "_track_filter_for_display"):
            //                 displayed_tracking_ids = record._track_filter_for_display(
            //                     displayed_tracking_ids
            //                 )
            //             # sudo: mail.message - checking whether there is a notification for the current user is acceptable
            //             notifications_partners = message.sudo().notification_ids.filtered(
            //                 lambda n: not n.is_read
            //             ).res_partner_id
            //             vals["needaction"] = (
            //                 not self.env.user._is_public()
            //                 and self.env.user.partner_id in notifications_partners
            //             )
            //             vals["starred"] = message.starred
            //             vals["trackingValues"] = displayed_tracking_ids._tracking_value_format()
            //         data.update(vals)
            //         store.add(message, data)
            //     # sudo: mail.message: access to author is allowed
            //     self.sudo()._author_to_store(store)
            //     # Add extras at the end to guarantee order in result. In particular, the parent message
            //     # needs to be after the current message (client code assuming the first received message is
            //     # the one just posted for example, and not the message being replied to).
            //     self._extras_to_store(store, format_reply=format_reply)
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: mail_message.py) ---
            // def _to_store(self, store: Store, /, *, fields=None, **kwargs):
            // super()._to_store(store, fields=fields, **kwargs)
            // if fields is None:
            //     fields = ["rating_id", "record_rating"]
            // if "rating_id" in fields:
            //     for message in self:
            //         # sudo: mail.message - guest and portal user can receive rating of accessible message
            //         store.add(message, {"rating_id": Store.one(message.sudo().rating_id)})
            // if "record_rating" in fields:
            //     for records in self._records_by_model_name().values():
            //         if issubclass(self.pool[records._name], self.pool["rating.mixin"]):
            //             store.add(records, fields=["rating_avg", "rating_count"], as_thread=True)
            */
            return default;
        }

        public async Task<MailMessage> ToggleMessageStarredAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def toggle_message_starred(self):
            // """ Toggle messages as (un)starred. Technically, the notifications related
            //     to uid are set to (un)starred.
            // """
            // self.ensure_one()
            // # a user should always be able to star a message they can read
            // self.check_access('read')
            // starred = not self.starred
            // partner = self.env.user.partner_id
            // if starred:
            //     partner.starred_message_ids |= self
            // else:
            //     partner.starred_message_ids -= self
            // self.env.user._bus_send(
            //     "mail.message/toggle_star", {"message_ids": [self.id], "starred": starred}
            // )
            // return Store(self, {"starred": self.starred}).get_result()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailMessage> UnstarAllAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def unstar_all(self):
            // """ Unstar messages for the current partner. """
            // partner = self.env.user.partner_id
            // starred_messages = self.search([('starred_partner_ids', 'in', partner.id)])
            // partner.starred_message_ids -= starred_messages
            // self.env.user._bus_send(
            //     "mail.message/toggle_star", {"message_ids": starred_messages.ids, "starred": False}
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, MailMessage entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def write(self, vals):
            // # We allow any whitespace modifications in the subject
            // normalized_subject = ' '.join(vals['subject'].split()) if vals.get('subject') else None
            // if (
            //     vals.keys() & {'res_id', 'res_model', 'message_type', 'subtype_id'}
            //     or ('subject' in vals and any(' '.join(s.subject.split()) != normalized_subject for s in self if s.subject))
            //     or ('body' in vals and any(self.mapped('body')))
            // ):
            //     self._except_audit_log()
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def write(self, vals):
            // record_changed = 'model' in vals or 'res_id' in vals
            // if record_changed and not self.env.is_system():
            //     raise AccessError(_("Only administrators can modify 'model' and 'res_id' fields."))
            // if record_changed or 'message_type' in vals:
            //     self._invalidate_documents()
            // res = super(Message, self).write(vals)
            // if vals.get('attachment_ids'):
            //     for mail in self:
            //         mail.attachment_ids.check(mode='read')
            // if 'notification_ids' in vals or record_changed:
            //     self._invalidate_documents()
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}