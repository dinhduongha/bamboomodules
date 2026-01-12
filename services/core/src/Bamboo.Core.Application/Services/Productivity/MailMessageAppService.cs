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
    [Module("Mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public class MailMessageAppService : GenericApplicationService<MailMessage>, IMailMessageAppService
    {
        private readonly IBusListenerMixinAppService _busListenerMixinAppService;
        public MailMessageAppService(IRepository<MailMessage, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IBusListenerMixinAppService busListenerMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _busListenerMixinAppService = busListenerMixinAppService;
        }

        protected async Task<MailMessage> BusChannelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _bus_channel(self):
            // self.ensure_one()
            // if self.channel_id:
            //     return self.channel_id
            // guest = self.env["mail.guest"]._get_guest_from_context()
            // if self.env.user._is_public() and guest:
            //     return guest
            // return super()._bus_channel()
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _bus_channel(self):
            // return self.env.user
            */
            return default;
        }

        protected async Task<MailMessage> BusSendReactionGroupInternalAsync(object content)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _bus_send_reaction_group(self, content):
            // store = Store(bus_channel=self._bus_channel())
            // self._reaction_group_to_store(store, content)
            // store.bus_send()
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

        protected async Task<MailMessage> ComputeAccountAuditLogAccountIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _compute_account_audit_log_account_id(self):
            // self._compute_audit_log_related_record_id('account.account', 'account_audit_log_account_id')
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
            // audit_messages = self.filtered(lambda m: m.message_type == 'notification')
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
            //             'old_value': fmt_vals['oldValue'],
            //             'new_value': fmt_vals['newValue'],
            //             'field': fmt_vals['fieldInfo']['changedField'],
            //         }
            //         for fmt_vals in tracking_value_ids._tracking_value_format()
            //     )
            //     message.account_audit_log_preview = audit_log_preview
            */
            return default;
        }

        protected async Task<MailMessage> ComputeAccountAuditLogRestrictedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _compute_account_audit_log_restricted(self):
            // self.account_audit_log_restricted = False
            // if potentially_restricted := self.filtered(lambda r: r.model in DOMAINS):
            //     restricted = self.search(Domain('id', 'in', potentially_restricted.ids) + self._search_account_audit_log_restricted('in', [True]))
            //     restricted.account_audit_log_restricted = True
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
            // for message in messages_of_related:
            //     message[fname] = message.res_id
            */
            return default;
        }

        protected async Task<MailMessage> ComputeChannelIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _compute_channel_id(self):
            // for message in self:
            //     if message.model == "discuss.channel" and message.res_id:
            //         message.channel_id = self.env["discuss.channel"].browse(message.res_id)
            //     else:
            //         message.channel_id = False
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
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: mail_message.py) ---
            // def _compute_is_current_user_or_guest_author(self):
            // super()._compute_is_current_user_or_guest_author()
            // portal_data = self.env.context.get("portal_data", {})
            // portal_partner = portal_data.get("portal_partner")
            // portal_thread = portal_data.get("portal_thread")
            // if (
            //     not portal_partner
            //     or not portal_thread
            //     or not isinstance(portal_partner, self.pool["res.partner"])
            //     or not isinstance(portal_thread, self.pool["mail.thread"])
            // ):
            //     return
            // for message in self:
            //     if (
            //         message.author_id == portal_partner
            //         and message.model == portal_thread._name
            //         and message.res_id == portal_thread.id
            //     ):
            //         message.is_current_user_or_guest_author = True
            */
            return default;
        }

        protected async Task<MailMessage> ComputeLinkedMessageIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _compute_linked_message_ids(self):
            // """ Compute the linked messages from the body of the message."""
            // message_ids_by_message = defaultdict(list)
            // for message in self:
            //     if tools.is_html_empty(message.body):
            //         continue
            //     str_ids = html.fromstring(message.body).xpath(
            //         "//a[contains(@class, 'o_message_redirect') and @data-oe-model='mail.message']/@data-oe-id",
            //     )
            //     for str_id in str_ids:
            //         with contextlib.suppress(ValueError, TypeError):
            //             message_ids_by_message[message].append(int(str_id))
            // mids = [mid for mids in message_ids_by_message.values() for mid in mids]
            // if not mids:
            //     self.linked_message_ids = self.env["mail.message"]
            //     return
            // # Remove any potential sudo from the env as linked messages are user input, returning them
            // # as sudo could lead to users being able to read any arbitrary message through this feature.
            // # Only allowed messages for the current user are acceptable.
            // linked_messages = self.sudo(False).search(Domain("id", "in", mids))
            // for message in self:
            //     message.linked_message_ids = linked_messages.filtered(
            //         lambda m, message=message: m.id in message_ids_by_message[message],
            //     )
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

        protected async Task<MailMessage> ComputeRecordNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _compute_record_name(self):
            // free = self.filtered(lambda m: not m.model or not m.res_id or m.model not in self.env)
            // free.record_name = False
            // # sudo here, as it behaves like a m2o -> can read message, can read name_get
            // for message, record in (self - free)._record_by_message().items():
            //     try:
            //         message.record_name = record.sudo().display_name
            //     except MissingError:
            //         message.record_name = False
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
            // for message in self:
            //     if message.account_audit_log_move_id and not message.account_audit_log_move_id.posted_before:
            //         continue
            //     if message.account_audit_log_restricted:
            //         raise UserError(self.env._("You cannot remove parts of a restricted audit trail. Archive the record instead."))
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
            // return super().export_data(fields_to_export)
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
            //     store.add(
            //         self.sudo().filtered(lambda message: message.channel_id),
            //         Store.One("parent_id", format_reply=False),
            //     )
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
            // def fetch(self, field_names=None):
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

        protected async Task<MailMessage> FieldStoreReprInternalAsync(object field_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _field_store_repr(self, field_name):
            // """Return the default Store representation of the given field name, which can be passed as
            // param to the various Store methods."""
            // if field_name == "message_link_preview_ids":
            //     return [
            //         Store.Many(
            //             "message_link_preview_ids",
            //             value=lambda m: m.sudo()
            //             .message_link_preview_ids.filtered(
            //                 lambda message_link_preview: not message_link_preview.is_hidden
            //             )
            //             .sorted(
            //                 lambda message_link_preview: (
            //                     message_link_preview.sequence,
            //                     message_link_preview.id,
            //                 )
            //             ),
            //         )
            //     ]
            // return [field_name]
            */
            return default;
        }

        protected async Task<MailMessage> FilterEmptyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _filter_empty(self):
            // """ Return subset of "void" messages """
            // return self.filtered(lambda message: message._is_empty())
            */
            return default;
        }

        protected async Task<MailMessage> FindAllowedDocIdsInternalAsync(List<Guid> model_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _find_allowed_doc_ids(self, model_ids):
            // """ Filter out message user cannot read due to missing document access.
            // 
            // :param dict model_ids: dictionary like {
            //     'document_model_name': {
            //         'document_id_1': set(message IDs),
            //         'document_id_2': set(message IDs),
            //     },
            //     [...]
            // }
            // 
            // :return: set of allowed message IDs to read, based on document check
            // :rtype: set
            // """
            // IrModelAccess = self.env['ir.model.access']
            // allowed_ids = set()
            // for doc_model, doc_dict in model_ids.items():
            //     if not IrModelAccess.check(doc_model, 'read', False):
            //         continue
            //     records_all = self.env[doc_model].with_context(active_test=False).search([('id', 'in', list(doc_dict))])
            //     allowed_documents = self.env[doc_model]
            //     # _mail_group_by_operation_for_mail_message_operation set prefetch to records_all.ids
            //     # hence should be good, no need to force it again
            //     operation_res_ids = records_all._mail_group_by_operation_for_mail_message_operation('read')
            //     # filter for each operation
            //     for record_operation, records in operation_res_ids.items():
            //         if record_operation == "read":  # already implied by 'search'
            //             allowed_documents += records
            //         else:
            //             allowed_documents += records._filtered_access(record_operation)
            //     allowed_ids |= {
            //         msg_id for document_id in allowed_documents.ids for msg_id in doc_dict[document_id]
            //     }
            // return allowed_ids
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
            //         if not self._is_thread_message_visible(vals=message):
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
            //     # group documents per operation to check, based on mail.message access
            //     # note that some ids may be filtered out if (e.g. group limitation, ...)
            //     operation_res_ids = documents._mail_group_by_operation_for_mail_message_operation(operation)
            //     for record_operation, records in operation_res_ids.items():
            //         check_result = records._check_access(record_operation)
            //         forbidden_doc_ids = set(check_result[0]._ids) if check_result else set()
            //         for res_id in (r.id for r in records if r.id not in forbidden_doc_ids):
            //             for mid in docid_msgids[res_id]:
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
            // elif self._is_thread_message(vals=values):
            //     message_id = tools.mail.generate_tracking_message_id('%(res_id)s-%(model)s' % values)
            // else:
            //     message_id = tools.mail.generate_tracking_message_id('private')
            // return message_id
            */
            return default;
        }

        protected async Task<MailMessage> GetReplyToInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _get_reply_to(self, values):
            // """ Return a specific reply_to for the document """
            // author_id = values.get('author_id')
            // model = values.get('model', self.env.context.get('default_model'))
            // res_id = values.get('res_id', self.env.context.get('default_res_id')) or False
            // email_from = values.get('email_from')
            // message_type = values.get('message_type')
            // records = None
            // if self._is_thread_message(vals={'model': model, 'res_id': res_id, 'message_type': message_type}):
            //     records = self.env[model].browse([res_id])
            // else:
            //     records = self.env[model] if model else self.env['mail.thread']
            // return records.sudo()._notify_get_reply_to(default=email_from, author_id=author_id)[res_id]
            */
            return default;
        }

        protected async Task<MailMessage> GetSearchDomainShareInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _get_search_domain_share(self):
            // return Domain(['&', '&', ('is_internal', '=', False), ('subtype_id', '!=', False), ('subtype_id.internal', '=', False)])
            */
            return default;
        }

        protected async Task<MailMessage> GetStoreAttachmentFieldsInternalAsync(object target)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _get_store_attachment_fields(self, target):
            // self.ensure_one()
            // if target.is_current_user(self.env) and self.is_current_user_or_guest_author:
            //     return self.env["ir.attachment"]._get_store_ownership_fields()
            // return []
            */
            return default;
        }

        protected async Task<MailMessage> GetStoreLinkedMessagesFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _get_store_linked_messages_fields(self):
            // """Add the messages that are referenced by the current message's body to the given store.
            // This method should only return message data that are not sensitive to be broadcasted to
            // other users, as it doesn't check store.target by simplicity and the target might not
            // necessarily have permission to read the linked messages."""
            // record_by_message = self.linked_message_ids._record_by_message()
            // return [
            //     Store.Many(
            //         "linked_message_ids",
            //         [
            //             "model",
            //             "res_id",
            //             Store.Attr(
            //                 "thread",
            //                 lambda m: Store.One(
            //                     record_by_message.get(m),
            //                     # sudo: mail.thread - reading record name of accessible message is acceptable
            //                     [Store.Attr("display_name", sudo=True)],
            //                     as_thread=True,
            //                 ),
            //             ),
            //         ],
            //         only_data=True,
            //     ),
            // ]
            */
            return default;
        }

        protected async Task<MailMessage> GetStorePartnerNameFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: mail_message.py) ---
            // def _get_store_partner_name_fields(self):
            // if self.channel_id.channel_type == "livechat":
            //     return self.env["res.partner"]._get_store_livechat_username_fields()
            // return super()._get_store_partner_name_fields()
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _get_store_partner_name_fields(self):
            // self.ensure_one()
            // return ["name"]
            */
            return default;
        }

        protected async Task<MailMessage> GetTrackingValuesDomainInternalAsync(object search_term)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _get_tracking_values_domain(self, search_term):
            // """Get the domain to search for tracking values."""
            // numeric_term = None
            // # try to convert the search term to a number
            // with contextlib.suppress(ValueError, TypeError):
            //     numeric_term = float(search_term)
            // domain = Domain.OR(
            //     Domain(field_name, "ilike", search_term)
            //     for field_name in (
            //         "old_value_char",
            //         "new_value_char",
            //         "old_value_text",
            //         "new_value_text",
            //         "old_value_datetime",
            //         "new_value_datetime",
            //         "field_id.name",
            //         "field_id.field_description",
            //     )
            // )
            // if numeric_term:
            //     epsilon = 1e-9  # small epsilon to allow for floating point precision
            //     domain |= Domain.OR(
            //         Domain(field_name, ">=", numeric_term - epsilon)
            //         & Domain(field_name, "<=", numeric_term + epsilon)
            //         for field_name in ("old_value_float", "new_value_float")
            //     )
            //     if numeric_term.is_integer():
            //         domain |= Domain.OR(
            //             Domain(field_name, "=", int(numeric_term))
            //             for field_name in ("old_value_integer", "new_value_integer")
            //         )
            // return domain
            */
            return default;
        }

        protected async Task<MailMessage> GetWithAccessInternalAsync(Guid message_id, object mode)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _get_with_access(self, message_id, mode="read", **kwargs):
            // message = self.browse(message_id).exists()
            // if not message:
            //     return message
            // 
            // # sanity check on kwargs
            // allowed_params = self.env[message.sudo().model or 'mail.thread']._get_allowed_access_params()
            // if invalid := (set((kwargs or {}).keys()) - allowed_params):
            //     _logger.warning("Invalid parameters to _get_with_access: %s", invalid)
            // 
            // if self.env.user._is_public() and self.env["mail.guest"]._get_guest_from_context():
            //     # Don't check_access_rights for public user with a guest, as the rules are
            //     # incorrect due to historically having no reason to allow operations on messages to
            //     # public user before the introduction of guests. Even with ignoring the rights,
            //     # check_access_rule and its sub methods are already covering all the cases properly.
            //     if not message.sudo(False)._get_forbidden_access(mode):
            //         return message
            // else:
            //     if message.sudo(False).has_access(mode):
            //         return message
            // 
            // if message.model and message.res_id:
            //     thread_su = self.env[message.model].browse(message.res_id).sudo()
            //     access_mode = thread_su._mail_get_operation_for_mail_message_operation(mode)[thread_su]
            //     if access_mode and self.env[message.model]._get_thread_with_access(message.res_id, mode=access_mode, **kwargs):
            //         return message
            // 
            // return self.browse()
            */
            return default;
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

        protected async Task<MailMessage> IsEmptyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _is_empty(self):
            // self.ensure_one()
            // return (
            //     (not self.body or tools.is_html_empty(self.body))
            //     and (not self.subtype_id or not self.subtype_id.description)
            //     and not self.attachment_ids
            //     and not (
            //         self._has_field_access(self._fields["tracking_value_ids"], "read")
            //         and self.tracking_value_ids
            //     )
            // )
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: mail_message.py) ---
            // def _is_empty(self):
            // return super()._is_empty() and not self.rating_id
            */
            return default;
        }

        protected async Task<MailMessage> IsThreadMessageInternalAsync(object vals, object thread)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _is_thread_message(self, vals=False, thread=None):
            // """ Tool method to compute thread validity in notification methods. """
            // vals = vals or {}
            // res_model = vals['model'] if 'model' in vals else thread._name if thread else self.model
            // res_id = vals['res_id'] if 'res_id' in vals else thread.ids[0] if thread and thread.ids else self.res_id
            // return bool(res_id) if (res_model and res_model != 'mail.thread') else False
            */
            return default;
        }

        protected async Task<MailMessage> IsThreadMessageVisibleInternalAsync(object vals, object thread)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _is_thread_message_visible(self, vals=False, thread=None):
            // """ In addition to being a thread message, it should not be a user specific
            // notification that is recipient-specific. Used mainly for ACL purpose. """
            // is_thread = self._is_thread_message(vals=vals, thread=thread)
            // if is_thread:
            //     message_type = (vals or {}).get('message_type') or self.message_type
            //     return is_thread and message_type != 'user_notification'
            // return is_thread
            */
            return default;
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

        protected async Task<MailMessage> MessageFetchInternalAsync(object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _message_fetch(self, domain, *, thread=None, search_term=None, is_notification=None, before=None, after=None, around=None, limit=30):
            // res = {}
            // domain = Domain(True if domain is None else domain)
            // if thread:
            //     domain &= (
            //         Domain("res_id", "=", thread.id)
            //         & Domain("model", "=", thread._name)
            //         & Domain("message_type", "!=", "user_notification")
            //     )
            // if is_notification is True:
            //     domain &= Domain("message_type", "=", "notification")
            // elif is_notification is False:
            //     domain &= Domain("message_type", "!=", "notification")
            // if search_term:
            //     # we replace every space by a % to avoid hard spacing matching
            //     search_term = search_term.replace(" ", "%")
            //     message_domain = Domain.OR([
            //         # sudo: access to attachment is allowed if you have access to the parent model
            //         [("attachment_ids", "in", self.env["ir.attachment"].sudo()._search([("name", "ilike", search_term)]))],
            //         [("body", "ilike", search_term)],
            //         [("subject", "ilike", search_term)],
            //         [("subtype_id.description", "ilike", search_term)],
            //     ])
            //     if thread and is_notification is not False:
            //         tracking_value_domain = (
            //             Domain("mail_message_id.res_id", "=", thread.id)
            //             & Domain("mail_message_id.model", "=", thread._name)
            //             & self._get_tracking_values_domain(search_term)
            //         )
            //         # sudo: mail.tracking.value - searching allowed tracking values for acessible records
            //         tracking_values = self.env["mail.tracking.value"].sudo().search(tracking_value_domain)
            //         accessible_tracking_value_ids = tracking_values._filter_has_field_access(self.env)
            //         message_domain |= Domain("id", "in", accessible_tracking_value_ids.mail_message_id.ids)
            //     domain &= message_domain
            //     res["count"] = self.search_count(domain)
            // if around is not None:
            //     messages_before = self.search(domain & Domain('id', '<=', around), limit=limit // 2, order="id DESC")
            //     messages_after = self.search(domain & Domain('id', '>', around), limit=limit // 2, order='id ASC')
            //     return {**res, "messages": (messages_after + messages_before).sorted('id', reverse=True)}
            // if before:
            //     domain &= Domain('id', '<', before)
            // if after:
            //     domain &= Domain('id', '>', after)
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
            // store.add(
            //     self,
            //     [
            //         Store.One("author_id", []),
            //         Store.One("author_guest_id", []),
            //         "body",
            //         "date",
            //         "message_type",
            //         Store.Many(
            //             "notification_ids",
            //             value=lambda m: m.notification_ids._filtered_for_web_client(),
            //         ),
            //         Store.One(
            //             "thread",
            //             [
            //                 Store.Attr(
            //                     "modelName",
            //                     lambda thread: self.env["ir.model"]._get(thread._name).display_name,
            //                 ),
            //                 "display_name",
            //             ],
            //             as_thread=True,
            //         ),
            //     ],
            // )
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
            //     if user := partner.main_user_id:
            //         store = Store(bus_channel=user)
            //         messages.with_user(user)._message_notifications_to_store(store)
            //         store.bus_send()
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
            // :returns: fields or properties derived from fields
            // :rtype: set
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
            // :returns: list of dict, one per message in self. Each dict contains
            //   values for either fields, either properties derived from fields.
            // :rtype: list[dict]
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
            // :returns: updated attachment_values
            // :rtype: dict
            // """
            // safari = request and request.httprequest.user_agent and request.httprequest.user_agent.browser == 'safari'
            // attachment_values['filename'] = attachment_values['name']
            // attachment_values['mimetype'] = (
            //     'application/octet-stream' if safari and
            //     'video' in (attachment_values["mimetype"] or "")
            //     else attachment_values["mimetype"])
            // attachment = self.env['ir.attachment'].browse(attachment_values['id'])
            // attachment_values["raw_access_token"] = attachment._get_raw_access_token()
            // if self.is_current_user_or_guest_author:
            //     attachment_values["ownership_token"] = attachment._get_ownership_token()
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
            // :returns: list of dict, one per message in self. Each dict contains
            //   values for either fields, either properties derived from fields.
            // :rtype: list[dict]
            // """
            // message_to_attachments = {}
            // if 'attachment_ids' in properties_names:
            //     properties_names.remove('attachment_ids')
            //     attachments_sudo = self.sudo().attachment_ids
            //     related_attachments = {
            //         att_read_values['id']: att_read_values
            //         for att_read_values in attachments_sudo.read(
            //             ["checksum", "id", "mimetype", "name", "res_id", "res_model"]
            //         )
            //     }
            //     message_to_attachments = {
            //         message.id: [
            //             message._portal_message_format_attachments(related_attachments[att_id])
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
            //     values["body"] = ["markup", values["body"]]
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
            //                 "guests": [
            //                     {"id": guest.id, "name": guest.name}
            //                     for guest in reactions.guest_id
            //                 ],
            //                 "message": message.id,
            //                 "partners": [
            //                     # sudo: res.partner - reading partners of reaction on accessible message is allowed
            //                     {"id": partner.id, "name": partner.name}
            //                     for partner in reactions.partner_id.sudo()
            //                 ],
            //             },
            //         )
            //     values.update(
            //         {
            //             "reactions": reaction_groups,
            //             "author_id": {
            //                 "id": message.author_id.id,
            //                 "name": message.author_id.name,
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
            //     values["rating_id"] = message_to_rating.get(message.id, {})
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
            // :returns: updated rating_values
            // :rtype: dict
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
            //     Store.Many(reactions, mode="ADD")
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
            //     message: self.env[message.model].browse(message.res_id)
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
            //     model_name: self.env[model_name].browse(ids)
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

        protected async Task<MailMessage> SearchAccountAuditLogPreviewInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _search_account_audit_log_preview(self, operator, value):
            // if operator not in ['=', 'like', '=like', 'ilike'] or not isinstance(value, str):
            //     return NotImplemented
            // 
            // return Domain('message_type', '=', 'notification') & Domain.OR([
            //     [('tracking_value_ids.old_value_char', operator, value)],
            //     [('tracking_value_ids.new_value_char', operator, value)],
            //     [('tracking_value_ids.old_value_text', operator, value)],
            //     [('tracking_value_ids.new_value_text', operator, value)],
            // ])
            */
            return default;
        }

        protected async Task<MailMessage> SearchAccountAuditLogRestrictedInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: mail_message.py) ---
            // def _search_account_audit_log_restricted(self, operator, value):
            // if operator not in ('in', 'not in'):
            //     return NotImplemented
            // 
            // return Domain('message_type', '=', 'notification') & Domain.OR(
            //     [('model', '=', model), ('res_id', 'in', self.env[model]._search(domain_factory(self, operator, value)))]
            //     for model, domain_factory in DOMAINS.items()
            // )
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
            // if (
            //     operator in ('like', 'ilike', 'not ilike', 'not like') and isinstance(value, str)
            // ) or (
            //     operator in ('in', 'not in') and any(isinstance(v, str) for v in value)
            // ):
            //     res_id_domain = [('res_id', 'in', self.env[model]._search([('display_name', operator, value)]))]
            // elif operator in ('any', 'not any', 'any!', 'not any!'):
            //     if isinstance(value, Domain):
            //         query = self.env[model]._search(value)
            //     else:
            //         query = value
            //     res_id_domain = [('res_id', 'in' if operator in ('any', 'any!') else 'not in', query)]
            // elif operator in ('in', 'not in'):
            //     res_id_domain = [('res_id', operator, value)]
            // else:
            //     return NotImplemented
            // return [('model', '=', model)] + res_id_domain
            */
            return default;
        }

        protected async Task<MailMessage> SearchHasErrorInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _search_has_error(self, operator, operand):
            // if operator != 'in':
            //     return NotImplemented
            // return [('notification_ids.notification_status', 'in', ('bounce', 'exception'))]
            */
            return default;
        }

        protected async Task<MailMessage> SearchHasSmsErrorInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: mail_message.py) ---
            // def _search_has_sms_error(self, operator, operand):
            // if operator != 'in':
            //     return NotImplemented
            // return [('notification_ids', 'any', [
            //     ('notification_status', '=', 'exception'),
            //     ('notification_type', '=', 'sms'),
            // ])]
            */
            return default;
        }

        protected async Task<MailMessage> SearchInternalAsync(object domain, object offset, object limit, object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _search(self, domain, offset=0, limit=None, order=None, *, bypass_access=False, **kwargs):
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
            // if self.env.is_superuser() or bypass_access:
            //     return super()._search(domain, offset, limit, order, bypass_access=True, **kwargs)
            // 
            // # Non-employee see only messages with a subtype and not internal
            // if not self.env.user._is_internal():
            //     domain = self._get_search_domain_share() & Domain(domain)
            // 
            // # make the search query with the default rules
            // query = super()._search(domain, offset, limit, order, **kwargs)
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
            // if operator not in ('in', 'not in'):
            //     return NotImplemented
            // is_read = operator == 'not in'
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
            // if operator in Domain.NEGATIVE_OPERATORS:
            //     return NotImplemented
            // ratings = self.env['rating.rating'].sudo()._search([
            //     ('rating', operator, operand),
            //     ('message_id', '!=', False),
            //     ('consumed', '=', True),
            // ])
            // domain = Domain("id", "in", ratings.subselect("message_id"))
            // if operator == "in" and 0 in operand:
            //     return domain | Domain("rating_ids", "=", False)
            // return domain
            */
            return default;
        }

        protected async Task<MailMessage> SearchSnailmailErrorInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: snailmail, FILE: mail_message.py) ---
            // def _search_snailmail_error(self, operator, operand):
            // if operator != 'in':
            //     return NotImplemented
            // return ['&', ('letter_ids.state', '=', 'error'), ('letter_ids.user_id', '=', self.env.user.id)]
            */
            return default;
        }

        protected async Task<MailMessage> SearchStarredInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _search_starred(self, operator, operand):
            // if operator != 'in':
            //     return NotImplemented
            // return [('starred_partner_ids', 'in', self.env.user.partner_id.ids)]
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

        protected async Task<MailMessage> ToStoreDefaultsInternalAsync(object target)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: mail_message.py) ---
            // def _to_store_defaults(self, target):
            // return super()._to_store_defaults(target) + ["chatbot_current_step"]
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _to_store_defaults(self, target):
            // return super()._to_store_defaults(target) + [
            //     Store.Many(
            //         "call_history_ids",
            //         ["duration_hour", "end_dt"],
            //         predicate=lambda m: m.body and 'data-oe-type="call"' in m.body,
            //     ),
            // ]
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _to_store_defaults(self, target: Store.Target):
            // field_names = [
            //     # sudo: mail.message - reading attachments on accessible message is allowed
            //     Store.Many(
            //         "attachment_ids",
            //         sort="id",
            //         dynamic_fields=lambda m: m._get_store_attachment_fields(target),
            //         sudo=True,
            //     ),
            //     # sudo: mail.message: access to author_guest_id is allowed
            //     Store.One("author_guest_id", ["avatar_128", "name"], sudo=True),
            //     # sudo: mail.message: access to author_id is allowed
            //     Store.One(
            //         "author_id",
            //         ["avatar_128", "is_company", Store.One("main_user_id", "share")],
            //         dynamic_fields=lambda m: m._get_store_partner_name_fields(),
            //         sudo=True,
            //     ),
            //     "body",
            //     "create_date",
            //     "date",
            //     Store.Attr(
            //         "email_from",
            //         predicate=lambda m: target.is_internal(self.env)
            //         or (not m.author_id and not m.author_guest_id),
            //     ),
            //     "incoming_email_cc",
            //     "incoming_email_to",
            //     # sudo: mail.message - reading link preview on accessible message is allowed
            //     "message_format",
            //     "message_link_preview_ids",
            //     "message_type",
            //     "model",  # keep for iOS app
            //     # sudo: res.partner: reading limited data of recipients is acceptable
            //     Store.Many(
            //         "partner_ids",
            //         "avatar_128",
            //         dynamic_fields=lambda m: m._get_store_partner_name_fields(),
            //         sort="id",
            //         sudo=True,
            //     ),
            //     "pinned_at",
            //     # sudo: mail.message - reading reactions on accessible message is allowed
            //     Store.Attr("reactions", value=lambda m: Store.Many(m.sudo().reaction_ids)),
            //     "record_name",  # keep for iOS app
            //     "res_id",  # keep for iOS app
            //     "subject",
            //     # sudo: mail.message.subtype - reading subtype on accessible message is allowed
            //     Store.One("subtype_id", ["description"], sudo=True),
            //     "write_date",
            //     *self._get_store_linked_messages_fields(),
            // ]
            // if target.is_internal(self.env):
            //     # sudo - mail.notification: internal users can access notifications.
            //     field_names.append(
            //         Store.Many(
            //             "notification_ids",
            //             value=lambda m: m.sudo().notification_ids._filtered_for_web_client(),
            //         ),
            //     )
            // return field_names
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: mail_message.py) ---
            // def _to_store_defaults(self, target):
            // # sudo: mail.message - guest and portal user can receive rating of accessible message
            // return super()._to_store_defaults(target) + [
            //     Store.One("rating_id", sudo=True),
            //     "record_rating",
            // ]
            */
            return default;
        }

        protected async Task<MailMessage> ToStoreInternalAsync(object store, object fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: mail_message.py) ---
            // def _to_store(self, store: Store, fields, **kwargs):
            // """If we are currently running a chatbot.script, we include the information about
            // the chatbot.message related to this mail.message.
            // This allows the frontend display to include the additional features
            // (e.g: Show additional buttons with the available answers for this step)."""
            // super()._to_store(store, [f for f in fields if f != "chatbot_current_step"], **kwargs)
            // if "chatbot_current_step" not in fields:
            //     return
            // channel_messages = self.filtered(lambda message: message.channel_id)
            // channel_by_message = channel_messages._record_by_message()
            // for message in channel_messages.filtered(
            //     lambda message: channel_by_message[message].channel_type == "livechat"
            // ):
            //     channel = channel_by_message[message]
            //     # sudo: chatbot.script.step - checking whether the current message is from chatbot
            //     chatbot = channel.chatbot_current_step_id.sudo().chatbot_script_id.operator_partner_id
            //     if channel.chatbot_current_step_id and message.author_id == chatbot:
            //         chatbot_message = (
            //             self.env["chatbot.message"]
            //             .sudo()
            //             .search([("mail_message_id", "=", message.id)], limit=1)
            //         )
            //         if step := chatbot_message.script_step_id:
            //             step_data = {
            //                 "id": (step.id, message.id),
            //                 "message": message.id,
            //                 "scriptStep": Store.One(step, ["id", "message", "step_type"]),
            //                 "operatorFound": step.is_forward_operator
            //                 and channel.livechat_operator_id != chatbot,
            //             }
            //             if answer := chatbot_message.user_script_answer_id:
            //                 step_data["selectedAnswer"] = {
            //                     "id": answer.id,
            //                     "label": answer.name,
            //                 }
            //             if step.step_type in [
            //                 "free_input_multi",
            //                 "free_input_single",
            //                 "question_email",
            //                 "question_phone",
            //             ]:
            //                 # sudo: chatbot.message - checking the user answer to the step is allowed
            //                 user_answer_message = (
            //                     self.env["chatbot.message"]
            //                     .sudo()
            //                     .search(
            //                         [
            //                             ("script_step_id", "=", step.id),
            //                             ("id", "!=", chatbot_message.id),
            //                             ("discuss_channel_id", "=", channel.id),
            //                         ],
            //                         limit=1,
            //                     )
            //                 )
            //                 step_data["rawAnswer"] = [
            //                     "markup",
            //                     user_answer_message.user_raw_answer,
            //                 ]
            //             store.add_model_values("ChatbotStep", step_data)
            //             store.add(
            //                 message, {"chatbotStep": {"scriptStep": step.id, "message": message.id}}
            //             )
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def _to_store(self, store: Store, fields, *, format_reply=True, msg_vals=False, add_followers=False, followers=None):
            // """Add the messages to the given store.
            // 
            // :param format_reply: if True, also get data about the parent message if it exists.
            //     Only makes sense for discuss channel.
            // 
            // :param msg_vals: dictionary of values used to create the message. If
            //   given it may be used to access values related to ``message`` without
            //   accessing it directly. It lessens query count in some optimized use
            //   cases by avoiding access message content in db;
            // 
            // :param add_followers: if True, also add followers of the current target for each thread of
            //     each message. Only applicable if ``store.target`` is a specific user.
            // 
            // :param followers: if given, use this pre-computed list of followers instead of fetching
            //     them. It lessen query count in some optimized use cases.
            //     Only applicable if ``add_followers`` is True.
            // """
            // if "message_format" not in fields:
            //     store.add_records_fields(self, fields)
            //     return
            // fields.remove("message_format")
            // # fetch scheduled notifications once, only if msg_vals is not given to
            // # avoid useless queries when notifying Inbox right after a message_post
            // scheduled_dt_by_msg_id = {}
            // if msg_vals:
            //     scheduled_dt_by_msg_id = {msg.id: msg_vals.get("scheduled_date", False) for msg in self}
            // elif self:
            //     schedulers = (
            //         self.env["mail.message.schedule"]
            //         .sudo()
            //         .search([("mail_message_id", "in", self.ids)])
            //     )
            //     for scheduler in schedulers:
            //         scheduled_dt_by_msg_id[scheduler.mail_message_id.id] = scheduler.scheduled_datetime
            // record_by_message = self._record_by_message()
            // records = record_by_message.values()
            // non_channel_records = filter(lambda record: record._name != "discuss.channel", records)
            // target_user = store.target.get_user(self.env)
            // if target_user and add_followers and non_channel_records:
            //     if followers is None:
            //         domain = Domain.OR(
            //             [("res_model", "=", model), ("res_id", "in", [r.id for r in records])]
            //             for model, records in groupby(non_channel_records, key=lambda r: r._name)
            //         )
            //         domain &= Domain("partner_id", "=", target_user.partner_id.id)
            //         # sudo: mail.followers - reading followers of current partner
            //         followers = self.env["mail.followers"].sudo().search(domain)
            //     follower_by_record_and_partner = {
            //         (
            //             self.env[follower.res_model].browse(follower.res_id),
            //             follower.partner_id,
            //         ): follower
            //         for follower in followers
            //     }
            // record_fields = [
            //     # sudo: mail.thread - if mentionned in a non accessible thread, name is allowed
            //     Store.Attr("display_name", sudo=True),
            //     Store.Attr(
            //         "module_icon",
            //         lambda record: modules.module.get_module_icon(self.env[record._name]._original_module),
            //         predicate=lambda record: self.env[record._name]._original_module,
            //     ),
            // ]
            // if target_user and add_followers and non_channel_records:
            //     record_fields.append(
            //         Store.One(
            //             "selfFollower",
            //             ["is_active", Store.One("partner_id", [])],
            //             value=lambda r: follower_by_record_and_partner.get((r, target_user.partner_id)),
            //         ),
            //     )
            // for record in records:
            //     store.add(record, record_fields, as_thread=True)
            // if store.target.is_current_user(self.env):
            //     fields.append("starred")
            // store.add(self, fields)
            // for message in self:
            //     record = record_by_message.get(message)
            //     if record:
            //         if hasattr(record, "_message_compute_subject"):
            //             # sudo: if mentionned in a non accessible thread, user should be able to see the subject
            //             default_subject = record.sudo()._message_compute_subject()
            //         else:
            //             default_subject = message.record_name
            //     else:
            //         default_subject = False
            //     data = {
            //         "default_subject": default_subject,
            //         "scheduledDatetime": scheduled_dt_by_msg_id.get(message.id, False),
            //         "thread": Store.One(record, [], as_thread=True),
            //     }
            // 
            //     if message.incoming_email_cc:
            //         data["incoming_email_cc"] = tools.mail.email_split_tuples(message.incoming_email_cc)
            //     if message.incoming_email_to:
            //         data["incoming_email_to"] = tools.mail.email_split_tuples(message.incoming_email_to)
            //     if store.target.is_current_user(self.env):
            //         # sudo: mail.message - filtering allowed tracking values
            //         displayed_tracking_ids = message.sudo().tracking_value_ids._filter_has_field_access(
            //             self.env
            //         )
            //         if record and hasattr(record, "_track_filter_for_display"):
            //             displayed_tracking_ids = record._track_filter_for_display(
            //                 displayed_tracking_ids
            //             )
            //         # sudo: mail.message - checking whether there is a notification for the current user is acceptable
            //         notifications_partners = message.sudo().notification_ids.filtered(
            //             lambda n: not n.is_read
            //         ).res_partner_id
            //         data["needaction"] = (
            //             not self.env.user._is_public()
            //             and self.env.user.partner_id in notifications_partners
            //         )
            //         data["trackingValues"] = displayed_tracking_ids._tracking_value_format()
            //     store.add(message, data)
            // # Add extras at the end to guarantee order in result. In particular, the parent message
            // # needs to be after the current message (client code assuming the first received message is
            // # the one just posted for example, and not the message being replied to).
            // self._extras_to_store(store, format_reply=format_reply)
            --- ODOO METHOD SOURCE (MODULE: rating, FILE: mail_message.py) ---
            // def _to_store(self, store: Store, fields, **kwargs):
            // super()._to_store(store, [f for f in fields if f != "record_rating"], **kwargs)
            // if "record_rating" in fields:
            //     for records in self._records_by_model_name().values():
            //         if (
            //             issubclass(self.pool[records._name], self.pool["rating.mixin"])
            //             and records._has_field_access(records._fields["rating_avg"], 'read')
            //         ):
            //             all_stats = {}
            //             if records._allow_publish_rating_stats():
            //                 all_stats = records._rating_get_stats_per_record()
            //             record_fields = [
            //                 "rating_avg",
            //                 "rating_count",
            //                 Store.Attr(
            //                     "rating_stats",
            //                     lambda record, all_stats=all_stats: all_stats.get(record.id),
            //                     predicate=lambda record: record._allow_publish_rating_stats(),
            //                 ),
            //             ]
            //             store.add(records, record_fields, as_thread=True)
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
            // if starred:
            //     self.starred_partner_ids = [Command.link(self.env.user.partner_id.id)]
            // else:
            //     self.starred_partner_ids = [Command.unlink(self.env.user.partner_id.id)]
            // self.env.user._bus_send(
            //     "mail.message/toggle_star", {"message_ids": [self.id], "starred": starred}
            // )
            // return Store().add(self, {"starred": self.starred}).get_result()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailMessage> UnstarAllAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_message.py) ---
            // def unstar_all(self):
            // """ Unstar messages for the current partner. """
            // starred_messages = self.search([("starred_partner_ids", "in", self.env.user.partner_id.id)])
            // starred_messages.starred_partner_ids = [Command.unlink(self.env.user.partner_id.id)]
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
            // if not (self.env.su or self.env.user.has_group('base.group_user')):
            //     vals.pop('author_id', None)
            //     vals.pop('email_from', None)
            // record_changed = 'model' in vals or 'res_id' in vals
            // if record_changed and not self.env.is_system():
            //     raise AccessError(_("Only administrators can modify 'model' and 'res_id' fields."))
            // if record_changed or 'message_type' in vals:
            //     self._invalidate_documents()
            // res = super().write(vals)
            // if vals.get('attachment_ids'):
            //     self.attachment_ids.check_access('read')
            // if 'notification_ids' in vals or record_changed:
            //     self._invalidate_documents()
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}