using Bamboo.Core.Application.Contracts.DTOs;
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
    [Module("MailGroupModule", Depends = new[] { "mail", "portal" })]
    public class MailGroupMessageAppService : GenericApplicationService<MailGroupMessage>, IMailGroupMessageAppService
    {

        public MailGroupMessageAppService(IRepository<MailGroupMessage, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<MailGroupMessage> AssertModerableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py) ---
            // def _assert_moderable(self):
            // """Raise an error if one of the current message can not be moderated.
            // 
            // A <mail.group.message> can only be moderated
            // if it's moderation status is "pending_moderation".
            // """
            // non_moderable_messages = self.filtered_domain([
            //     ('moderation_status', '!=', 'pending_moderation'),
            // ])
            // if non_moderable_messages:
            //     if len(self) == 1:
            //         raise UserError(_('This message can not be moderated'))
            //     raise UserError(_(
            //         'Those messages can not be moderated: %s.',
            //         ', '.join(non_moderable_messages.mapped('subject')),
            //     ))
            */
            return default;
        }

        protected async Task<MailGroupMessage> ComputeAuthorModerationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py) ---
            // def _compute_author_moderation(self):
            // moderations = self.env['mail.group.moderation'].search([
            //     ('mail_group_id', 'in', self.mail_group_id.ids),
            // ])
            // all_emails = set(self.mapped('email_from_normalized'))
            // moderations = {
            //     (moderation.mail_group_id, moderation.email): moderation.status
            //     for moderation in moderations
            //     if moderation.email in all_emails
            // }
            // for message in self:
            //     message.author_moderation = moderations.get((message.mail_group_id, message.email_from_normalized), False)
            */
            return default;
        }

        protected async Task<MailGroupMessage> ComputeEmailFromNormalizedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py) ---
            // def _compute_email_from_normalized(self):
            // for message in self:
            //     message.email_from_normalized = email_normalize(message.email_from)
            */
            return default;
        }

        protected async Task<MailGroupMessage> ConstrainsMailMessageIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py) ---
            // def _constrains_mail_message_id(self):
            // for message in self:
            //     if message.mail_message_id.model != 'mail.group':
            //         raise AccessError(_(
            //             'Group message can only be linked to mail group. Current model is %s.',
            //             message.mail_message_id.model,
            //         ))
            //     if message.mail_message_id.res_id != message.mail_group_id.id:
            //         raise AccessError(_('The record of the message should be the group.'))
            */
            return default;
        }

        public async Task<MailGroupMessage> CopyDataAsync(Guid id, MailGroupMessageCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default)
            // for message, vals in zip(self, vals_list):
            //     vals['mail_message_id'] = message.mail_message_id.copy().id
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailGroupMessage> CreateModerationRuleInternalAsync(object status)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py) ---
            // def _create_moderation_rule(self, status):
            // """Create a moderation rule <mail.group.moderation> with the given status.
            // 
            // Update existing moderation rule for the same email address if found,
            // otherwise create a new rule.
            // """
            // if status not in ('ban', 'allow'):
            //     raise ValueError(_('Wrong status (%s)', status))
            // 
            // for message in self:
            //     if not email_normalize(message.email_from):
            //         raise UserError(_('The email "%s" is not valid.', message.email_from))
            // 
            // existing_moderation = self.env['mail.group.moderation'].search(
            //     expression.OR([
            //         [
            //             ('email', '=', email_normalize(message.email_from)),
            //             ('mail_group_id', '=', message.mail_group_id.id)
            //         ] for message in self
            //     ])
            // )
            // existing_moderation.status = status
            // 
            // # Add the value in a set to create only 1 moderation rule per (email_normalized, group)
            // moderation_to_create = {
            //     (email_normalize(message.email_from), message.mail_group_id.id)
            //     for message in self
            //     if email_normalize(message.email_from) not in existing_moderation.mapped('email')
            // }
            // 
            // self.env['mail.group.moderation'].create([
            //     {
            //         'email': email,
            //         'mail_group_id': mail_group_id,
            //         'status': status,
            //     } for email, mail_group_id in moderation_to_create])
            */
            return default;
        }

        protected async Task<MailGroupMessage> GetPendingSameAuthorSameGroupInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py) ---
            // def _get_pending_same_author_same_group(self):
            // """Return the pending messages of the same authors in the same groups."""
            // return self.search(
            //     expression.AND([
            //         expression.OR([
            //             [
            //                 ('mail_group_id', '=', message.mail_group_id.id),
            //                 ('email_from_normalized', '=', message.email_from_normalized),
            //             ] for message in self
            //         ]),
            //         [('moderation_status', '=', 'pending_moderation')],
            //     ])
            // )
            */
            return default;
        }

        public async Task<MailGroupMessage> ModerateAcceptAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py) ---
            // def action_moderate_accept(self):
            // """Accept the incoming email.
            // 
            // Will send the incoming email to all members of the group.
            // """
            // self._assert_moderable()
            // self.write({
            //     'moderation_status': 'accepted',
            //     'moderator_id': self.env.uid,
            // })
            // 
            // # Send the email to the members of the group
            // for message in self:
            //     message.mail_group_id._notify_members(message)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailGroupMessage> ModerateAllowAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py) ---
            // def action_moderate_allow(self):
            // self._create_moderation_rule('allow')
            // 
            // # Accept all emails of the same authors
            // same_author = self._get_pending_same_author_same_group()
            // same_author.action_moderate_accept()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailGroupMessage> ModerateBanAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py) ---
            // def action_moderate_ban(self):
            // self._create_moderation_rule('ban')
            // 
            // # Reject all emails of the same author
            // same_author = self._get_pending_same_author_same_group()
            // same_author.action_moderate_reject()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailGroupMessage> ModerateBanWithCommentAsync(Guid id, MailGroupMessageModerateBanWithCommentRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py) ---
            // def action_moderate_ban_with_comment(self, ban_subject, ban_comment):
            // self._create_moderation_rule('ban')
            // 
            // if ban_subject or ban_comment:
            //     self._moderate_send_reject_email(ban_subject, ban_comment)
            // 
            // # Reject all emails of the same author
            // same_author = self._get_pending_same_author_same_group()
            // same_author.action_moderate_reject()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailGroupMessage> ModerateRejectAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py) ---
            // def action_moderate_reject(self):
            // self._assert_moderable()
            // self.write({
            //     'moderation_status': 'rejected',
            //     'moderator_id': self.env.uid,
            // })
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailGroupMessage> ModerateRejectWithCommentAsync(Guid id, MailGroupMessageModerateRejectWithCommentRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py) ---
            // def action_moderate_reject_with_comment(self, reject_subject, reject_comment):
            // self._assert_moderable()
            // if reject_subject or reject_comment:
            //     self._moderate_send_reject_email(reject_subject, reject_comment)
            // self.action_moderate_reject()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailGroupMessage> ModerateSendRejectEmailInternalAsync(object subject, object comment)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group_message.py) ---
            // def _moderate_send_reject_email(self, subject, comment):
            // for message in self:
            //     if not message.email_from:
            //         continue
            // 
            //     body_html = append_content_to_html(Markup('<div>%s</div>') % comment, message.body, plaintext=False)
            //     body_html = self.env['mail.render.mixin']._replace_local_links(body_html)
            //     self.env['mail.mail'].sudo().create({
            //         'author_id': self.env.user.partner_id.id,
            //         'auto_delete': True,
            //         'body_html': body_html,
            //         'email_from': self.env.user.email_formatted or self.env.company.catchall_formatted,
            //         'email_to': message.email_from,
            //         'references': message.mail_message_id.message_id,
            //         'subject': subject,
            //         'state': 'outgoing',
            //     })
            */
            return default;
        }
    }
}