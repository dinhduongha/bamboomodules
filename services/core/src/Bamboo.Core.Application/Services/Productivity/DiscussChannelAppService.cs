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
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public partial class DiscussChannelAppService : GenericAppService<DiscussChannel>, IDiscussChannelAppService
    {
        private readonly IBusListenerMixinAppService _busListenerMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IRatingMixinAppService _ratingMixinAppService;
        public DiscussChannelAppService(IRepository<DiscussChannel, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IBusListenerMixinAppService busListenerMixinAppService, IMailThreadAppService mailThreadAppService, IRatingMixinAppService ratingMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _busListenerMixinAppService = busListenerMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _ratingMixinAppService = ratingMixinAppService;
        }

        protected async Task<DiscussChannel> ActionUnfollowInternalAsync(object partner, object guest, object post_leave_message)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _action_unfollow(self, partner=None, guest=None, post_leave_message=True):
            // super()._action_unfollow(partner, guest, post_leave_message)
            // # sudo - discuss.channel: user just left but we need to close the live
            // # chat if the last operator left.
            // channel_sudo = self.sudo()
            // if (
            //     channel_sudo.channel_type == "livechat"
            //     and not channel_sudo.livechat_end_dt
            //     and channel_sudo.member_count == 1
            // ):
            //     # sudo: discuss.channel - last operator left the conversation, state must be updated.
            //     channel_sudo.livechat_end_dt = fields.Datetime.now()
            //     Store(bus_channel=self).add(channel_sudo, "livechat_end_dt").bus_send()
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _action_unfollow(self, partner=None, guest=None, post_leave_message=True):
            // self.ensure_one()
            // if partner is None:
            //     partner = self.env["res.partner"]
            // if guest is None:
            //     guest = self.env["mail.guest"]
            // self.message_unsubscribe(partner.ids)
            // member = self.env["discuss.channel.member"].search(
            //     [
            //         ("channel_id", "=", self.id),
            //         ("partner_id", "=", partner.id) if partner else ("guest_id", "=", guest.id),
            //     ]
            // )
            // custom_store = Store(bus_channel=member._bus_channel() or partner.main_user_id or guest)
            // custom_store.add(self, {"close_chat_window": True, "isLocallyPinned": False}).bus_send()
            // if not member:
            //     return
            // if self.channel_type != "channel" and post_leave_message:
            //     notification = Markup('<div class="o_mail_notification" data-oe-type="channel-left">%s</div>') % _(
            //         "left the channel"
            //     )
            //     # sudo: mail.message - post as sudo since the user just unsubscribed from the channel
            //     member.channel_id.sudo().message_post(
            //         body=notification, subtype_xmlid="mail.mt_comment", author_id=partner.id
            //     )
            // member.unlink()
            // Store(bus_channel=self).add(
            //     self,
            //     [
            //         Store.Many("channel_member_ids", [], mode="DELETE", value=member),
            //         "member_count",
            //     ],
            // ).bus_send()
            */
            return default;
        }

        public async Task<DiscussChannel> AddMembersAsync(DiscussChannelAddMembersRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def add_members(
            //     self, partner_ids=None, guest_ids=None, invite_to_rtc_call=False, post_joined_message=True
            // ):
            //     """ Adds the given partner_ids and guest_ids as member of self channels. """
            //     return self._add_members(
            //         partners=self.env["res.partner"].browse(partner_ids or []).exists(),
            //         guests=self.env["mail.guest"].browse(guest_ids or []).exists(),
            //         invite_to_rtc_call=invite_to_rtc_call,
            //         post_joined_message=post_joined_message,
            //     )
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<DiscussChannel> AddMembersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _add_members(
            //     self,
            //     *,
            //     guests=None,
            //     partners=None,
            //     users=None,
            //     create_member_params=None,
            //     invite_to_rtc_call=False,
            //     post_joined_message=True,
            //     inviting_partner=None,
            // ):
            //     all_new_members = super()._add_members(
            //         guests=guests,
            //         partners=partners,
            //         users=users,
            //         create_member_params=create_member_params,
            //         invite_to_rtc_call=invite_to_rtc_call,
            //         post_joined_message=post_joined_message,
            //         inviting_partner=inviting_partner,
            //     )
            //     for channel in all_new_members.channel_id:
            //         # sudo: discuss.channel - accessing livechat_status in internal code is acceptable
            //         if channel.sudo().livechat_status == "need_help":
            //             # sudo: discuss.channel - writing livechat_status when a new operator joins is acceptable
            //             channel.sudo().livechat_status = "in_progress"
            //     return all_new_members
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _add_members(
            //     self,
            //     *,
            //     guests=None,
            //     partners=None,
            //     users=None,
            //     create_member_params=None,
            //     invite_to_rtc_call=False,
            //     post_joined_message=True,
            //     inviting_partner=None,
            // ):
            //     inviting_partner = inviting_partner or self.env["res.partner"]
            //     partners = partners or self.env["res.partner"]
            //     if users:
            //         partners |= users.partner_id
            //     guests = guests or self.env["mail.guest"]
            //     current_partner, current_guest = self.env["res.partner"]._get_current_persona()
            //     all_new_members = self.env["discuss.channel.member"]
            //     for channel in self:
            //         members_to_create = []
            //         existing_members = self.env['discuss.channel.member'].search(
            //             Domain('channel_id', '=', channel.id)
            //             & (Domain('partner_id', 'in', partners.ids) | Domain('guest_id', 'in', guests.ids))
            //         )
            //         members_to_create += [{
            //             **(create_member_params or {}),
            //             'partner_id': partner.id,
            //             'channel_id': channel.id,
            //         } for partner in partners - existing_members.partner_id]
            //         members_to_create += [{
            //             **(create_member_params or {}),
            //             'guest_id': guest.id,
            //             'channel_id': channel.id,
            //         } for guest in guests - existing_members.guest_id]
            //         if channel.parent_channel_id and channel.parent_channel_id.has_access("write"):
            //             new_members = self.env["discuss.channel.member"].sudo().create(members_to_create)
            //         else:
            //             new_members = self.env["discuss.channel.member"].create(members_to_create)
            //         all_new_members += new_members
            //         for member in new_members:
            //             payload = {
            //                 "channel_id": member.channel_id.id,
            //                 "invite_to_rtc_call": invite_to_rtc_call,
            //                 "data": Store(bus_channel=member._bus_channel())
            //                 .add(member.channel_id)
            //                 .add(member, "unpin_dt")
            //                 .get_result(),
            //             }
            //             if not member.is_self and not self.env.user._is_public():
            //                 payload["invited_by_user_id"] = self.env.user.id
            //             member._bus_send("discuss.channel/joined", payload)
            //             if channel.channel_type != "channel" and post_joined_message:
            //                 notification = (
            //                     _("joined the channel")
            //                     if member.is_self
            //                     else _("invited %s to the channel", member._get_html_link(for_persona=True))
            //                 )
            //                 member.channel_id.message_post(
            //                     author_id=inviting_partner.id or None,
            //                     body=Markup('<div class="o_mail_notification" data-oe-type="channel-joined">%s</div>') % notification,
            //                     message_type="notification",
            //                     subtype_xmlid="mail.mt_comment",
            //                 )
            //         if new_members:
            //             Store(bus_channel=channel).add(channel, "member_count").add(new_members).bus_send()
            //         if existing_members and (bus_channel := current_partner.main_user_id or current_guest):
            //             # If the current user invited these members but they are already present, notify the current user about their existence as well.
            //             # In particular this fixes issues where the current user is not aware of its own member in the following case:
            //             # create channel from form view, and then join from discuss without refreshing the page.
            //             Store(
            //                 bus_channel=bus_channel,
            //             ).add(channel, "member_count").add(existing_members).bus_send()
            //     if invite_to_rtc_call:
            //         for channel in self:
            //             current_channel_member = self.env['discuss.channel.member'].search([('channel_id', '=', channel.id), ('is_self', '=', True)])
            //             # sudo: discuss.channel.rtc.session - reading rtc sessions of current user
            //             if current_channel_member and current_channel_member.sudo().rtc_session_ids:
            //                 # sudo: discuss.channel.rtc.session - current user can invite new members in call
            //                 current_channel_member.sudo()._rtc_invite_members(member_ids=new_members.ids)
            //     return all_new_members
            */
            return default;
        }

        protected async Task<DiscussChannel> AddNewMembersToChannelInternalAsync(object create_member_params, object inviting_partner, object users, object partners)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _add_new_members_to_channel(self, create_member_params, inviting_partner, users=None, partners=None):
            // member_params = {
            //     'create_member_params': create_member_params,
            //     'inviting_partner': inviting_partner
            // }
            // if users:
            //     member_params['users'] = users
            // if partners:
            //     member_params['partners'] = partners
            // self._add_members(**member_params)
            */
            return default;
        }

        protected async Task<DiscussChannel> AddNextStepMessageToStoreInternalAsync(object chatbot_script_step)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _add_next_step_message_to_store(self, chatbot_script_step):
            // if chatbot_script_step:
            //     step_message = next((
            //         # sudo - chatbot.message.id: visitor can access chat bot messages.
            //         m.mail_message_id for m in self.sudo().chatbot_message_ids.sorted("id")
            //         if m.script_step_id == chatbot_script_step
            //         and m.mail_message_id.author_id == chatbot_script_step.chatbot_script_id.operator_partner_id
            //     ), self.env["mail.message"])
            //     Store(bus_channel=self).add_model_values(
            //         "ChatbotStep",
            //         {
            //             "id": (chatbot_script_step.id, step_message.id),
            //             "scriptStep": chatbot_script_step.id,
            //             "message": step_message.id,
            //             "operatorFound": True,
            //         },
            //     ).bus_send()
            */
            return default;
        }

        protected async Task<DiscussChannel> AllowInviteByEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _allow_invite_by_email(self):
            // return self.channel_type == "group" or (
            //     self.channel_type == "channel" and not self.group_public_id
            // )
            */
            return default;
        }

        protected async Task<DiscussChannel> AttachmentToHtmlInternalAsync(object attachment)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _attachment_to_html(self, attachment):
            // if attachment.mimetype.startswith("image/"):
            //     return Markup(
            //         "<img src='%s?access_token=%s' alt='%s' style='max-width: 75%%; height: auto; padding: 5px;'>",
            //     ) % (
            //         attachment.image_src,
            //         attachment.generate_access_token()[0],
            //         attachment.name,
            //     )
            // file_extension = get_extension(attachment.display_name)
            // attachment_data = {
            //     "id": attachment.id,
            //     "access_token": attachment.generate_access_token()[0],
            //     "checksum": attachment.checksum,
            //     "extension": file_extension.lstrip("."),
            //     "mimetype": attachment.mimetype,
            //     "filename": attachment.display_name,
            //     "url": attachment.url,
            // }
            // return Markup(
            //     "<div data-embedded='file' data-oe-protected='true' contenteditable='false' data-embedded-props='%s'/>",
            // ) % json.dumps({"fileData": attachment_data})
            */
            return default;
        }

        protected async Task<DiscussChannel> BroadcastInternalAsync(List<Guid> partner_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _broadcast(self, partner_ids):
            // """ Broadcast the current channel header to the given partner ids
            //     :param partner_ids : the partner to notify
            // """
            // for partner in self.env['res.partner'].browse(partner_ids):
            //     if user := partner.main_user_id:
            //         Store(bus_channel=user).add(
            //             self.with_user(user).with_context(allowed_company_ids=[]),
            //         ).bus_send()
            */
            return default;
        }

        public async Task<DiscussChannel> ChannelChangeDescriptionAsync(DiscussChannelChannelChangeDescriptionRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def channel_change_description(self, description):
            // self.ensure_one()
            // self.write({'description': description})
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> ChannelFetchedAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def channel_fetched(self):
            // """ Broadcast the channel_fetched notification to channel members
            // """
            // for channel in self:
            //     if not channel.message_ids.ids:
            //         continue
            //     # a bit not-modular but helps understanding code
            //     if channel.channel_type not in {'chat', 'whatsapp'}:
            //         continue
            //     last_message_id = channel.message_ids.ids[0] # zero is the index of the last message
            //     member = self.env['discuss.channel.member'].search([('channel_id', '=', channel.id), ('partner_id', '=', self.env.user.partner_id.id)], limit=1)
            //     if not member:
            //         # member not a part of the channel
            //         continue
            //     if member.fetched_message_id.id == last_message_id:
            //         # last message fetched by user is already up-to-date
            //         continue
            //     # Avoid serialization error when multiple tabs are opened.
            //     query = """
            //         UPDATE discuss_channel_member
            //         SET fetched_message_id = %s
            //         WHERE id IN (
            //             SELECT id FROM discuss_channel_member WHERE id = %s
            //             FOR NO KEY UPDATE SKIP LOCKED
            //         )
            //     """
            //     self.env.cr.execute(query, (last_message_id, member.id))
            //     channel._bus_send(
            //         "discuss.channel.member/fetched",
            //         {
            //             "channel_id": channel.id,
            //             "id": member.id,
            //             "last_message_id": last_message_id,
            //             "partner_id": self.env.user.partner_id.id,
            //         },
            //     )
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> ChannelJoinAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def channel_join(self):
            // """Shortcut to add the current user as member of self channels.
            // Prefer calling add_members() directly when possible.
            // """
            // self._add_members(users=self.env.user)
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> ChannelPinAsync(DiscussChannelChannelPinRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def channel_pin(self, pinned=False):
            // self.ensure_one()
            // member = self.env['discuss.channel.member'].search(
            //     [('partner_id', '=', self.env.user.partner_id.id), ('channel_id', '=', self.id), ('is_pinned', '!=', pinned)])
            // if member:
            //     member.write({'unpin_dt': False if pinned else fields.Datetime.now()})
            // store = Store(bus_channel=self.env.user)
            // if not pinned:
            //     store.add(self, {"close_chat_window": True})
            // else:
            //     store.add(self)
            // store.bus_send()
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: discuss_channel.py) ---
            // def channel_pin(self, pinned=False):
            // """ Override to clean an empty livechat channel.
            //  This is typically called when the operator send a chat request to a website.visitor
            //  but don't speak to them and closes the chatter.
            //  This allows operators to send the visitor a new chat request.
            //  If active empty livechat channel,
            //  delete discuss_channel as not useful to keep empty chat
            //  """
            // super().channel_pin(pinned=pinned)
            // if self.channel_type == "livechat" and not pinned and not self.message_ids:
            //     self.sudo().unlink()
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> ChannelRenameAsync(DiscussChannelChannelRenameRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def channel_rename(self, name):
            // self.ensure_one()
            // self.write({'name': name})
            // body = Markup('<div data-oe-type="channel_rename" class="o_mail_notification">%s</div>') % name
            // self.message_post(body=body, message_type="notification", subtype_xmlid="mail.mt_comment")
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> ChannelSetCustomNameAsync(DiscussChannelChannelSetCustomNameRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def channel_set_custom_name(self, name):
            // self.ensure_one()
            // self.self_member_id.custom_channel_name = name
            // Store(bus_channel=self.self_member_id._bus_channel()).add(
            //     self.self_member_id,
            //     "custom_channel_name",
            // ).bus_send()
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<DiscussChannel> ChatbotFindCustomerValuesInMessagesInternalAsync(object step_type_to_field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _chatbot_find_customer_values_in_messages(self, step_type_to_field):
            // """
            // Look for user's input in the channel's messages based on a dictionary
            // mapping the step_type to the field name of the model it will be used on.
            // 
            // :param dict step_type_to_field: a dict of step types to customer fields
            //     to fill, like : {'question_email': 'email_from', 'question_phone': 'mobile'}
            // """
            // values = {}
            // filtered_message_ids = self.chatbot_message_ids.filtered(
            //     # sudo: chatbot.script.step - getting the type of the current step
            //     lambda m: m.script_step_id.sudo().step_type in step_type_to_field
            // )
            // for message_id in filtered_message_ids:
            //     field_name = step_type_to_field[message_id.script_step_id.step_type]
            //     if not values.get(field_name):
            //         values[field_name] = html2plaintext(message_id.user_raw_answer or '')
            // 
            // return values
            */
            return default;
        }

        protected async Task<DiscussChannel> ChatbotPostMessageInternalAsync(object chatbot_script, object body)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _chatbot_post_message(self, chatbot_script, body):
            // """ Small helper to post a message as the chatbot operator
            // 
            // :param record chatbot_script
            // :param string body: message HTML body """
            // # sudo: mail.message - chat bot is allowed to post a message which
            // # requires reading its partner among other things.
            // return self.with_context(mail_post_autofollow_author_skip=True).sudo().message_post(
            //     author_id=chatbot_script.sudo().operator_partner_id.id,
            //     body=body,
            //     message_type='comment',
            //     subtype_xmlid='mail.mt_comment',
            // )
            */
            return default;
        }

        protected async Task<DiscussChannel> ChatbotRestartInternalAsync(object chatbot_script)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _chatbot_restart(self, chatbot_script):
            // # sudo: discuss.channel - visitor can clear current step to restart the script
            // self.sudo().chatbot_current_step_id = False
            // # sudo: discuss.channel - visitor can reactivate livechat
            // self.sudo().livechat_end_dt = False
            // # sudo: chatbot.message - visitor can clear chatbot messages to restart the script
            // self.sudo().chatbot_message_ids.unlink()
            // return self._chatbot_post_message(
            //     chatbot_script,
            //     Markup('<div class="o_mail_notification">%s</div>') % _('Restarting conversation...'),
            // )
            */
            return default;
        }

        protected async Task<DiscussChannel> ChatbotValidateEmailInternalAsync(object email_address, object chatbot_script)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _chatbot_validate_email(self, email_address, chatbot_script):
            // email_address = html2plaintext(email_address)
            // email_normalized = email_normalize(email_address)
            // 
            // posted_message = False
            // error_message = False
            // if not email_normalized:
            //     error_message = _(
            //         "'%(input_email)s' does not look like a valid email. Can you please try again?",
            //         input_email=email_address
            //     )
            //     posted_message = self._chatbot_post_message(chatbot_script, plaintext2html(error_message))
            // 
            // return {
            //     'success': bool(email_normalized),
            //     'posted_message': posted_message,
            //     'error_message': error_message,
            // }
            */
            return default;
        }

        protected async Task<DiscussChannel> CheckCanUpdateMessageContentInternalAsync(object message)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _check_can_update_message_content(self, message):
            // # Don't call super in this override as we want to ignore the mail.thread behavior completely
            // if not message.message_type == 'comment':
            //     raise UserError(_("Only messages type comment can have their content updated on model 'discuss.channel'"))
            */
            return default;
        }

        protected async Task<DiscussChannel> CleanEmptyMessageInternalAsync(object message)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _clean_empty_message(self, message):
            // super()._clean_empty_message(message)
            // message.parent_id = False
            */
            return default;
        }

        protected async Task<DiscussChannel> CloseLivechatSessionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _close_livechat_session(self, **kwargs):
            // """ Set deactivate the livechat channel and notify (the operator) the reason of closing the session."""
            // self.ensure_one()
            // if not self.livechat_end_dt:
            //     member = self.channel_member_ids.filtered(lambda m: m.is_self)
            //     if member:
            //         # sudo: discuss.channel.rtc.session - member of current user can leave call
            //         member.sudo()._rtc_leave_call()
            //     # sudo: discuss.channel - visitor left the conversation, state must be updated
            //     self.sudo().livechat_end_dt = fields.Datetime.now()
            //     Store(bus_channel=self).add(self, "livechat_end_dt").bus_send()
            //     # avoid useless notification if the channel is empty
            //     if not self.message_ids:
            //         return
            //     # Notify that the visitor has left the conversation
            //     # sudo: mail.message - posting visitor leave message is allowed
            //     self.sudo().message_post(
            //         author_id=self.env.ref('base.partner_root').id,
            //         body=Markup('<div class="o_mail_notification o_hide_author">%s</div>')
            //         % self._get_visitor_leave_message(**kwargs),
            //         message_type='notification',
            //         subtype_xmlid='mail.mt_comment'
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeAvatar128InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_avatar_128(self):
            // for record in self:
            //     record.avatar_128 = record.image_128 or record._generate_avatar()
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeAvatarCacheKeyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_avatar_cache_key(self):
            // for channel in self:
            //     if not channel.avatar_128:
            //         channel.avatar_cache_key = 'no-avatar'
            //     else:
            //         channel.avatar_cache_key = sha512(channel.avatar_128).hexdigest()
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeChannelNameMemberIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_channel_name_member_ids(self):
            //   to_compute = self.filtered(
            //       lambda c: c.channel_type in self._member_based_naming_channel_types()
            //   )
            //   (self - to_compute).channel_name_member_ids = False
            //   if not to_compute:
            //       return
            //   self.env.cr.execute("""
            //       SELECT channel.id, member.id
            //         FROM discuss_channel channel
            // JOIN LATERAL
            //           (
            //              SELECT id
            //                FROM discuss_channel_member M
            //               WHERE M.channel_id = channel.id
            //            ORDER BY id
            //               LIMIT 3
            //           ) as member ON TRUE
            //        WHERE channel.id IN %s
            //   """, (tuple(to_compute.ids),))
            //   channel_id_to_member_ids = defaultdict(list)
            //   for channel_id, member_id in self.env.cr.fetchall():
            //       channel_id_to_member_ids[channel_id].append(member_id)
            //   for channel in self:
            //       channel.channel_name_member_ids = channel_id_to_member_ids.get(channel.id)
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeChannelPartnerIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_channel_partner_ids(self):
            // for channel in self:
            //     channel.channel_partner_ids = channel.channel_member_ids.partner_id
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_display_name(self):
            // for channel in self:
            //     if channel.name:
            //         channel.display_name = channel.name
            //         continue
            //     parts = channel.channel_name_member_ids.mapped(
            //         lambda m: m.partner_id.name or m.guest_id.name
            //     )
            //     if channel.member_count > 3:
            //         remaining = channel.member_count - 3
            //         parts.append(
            //             self.env._("1 other") if remaining == 1 else self.env._("%s others", remaining)
            //         )
            //     channel.display_name = format_list(self.env, parts)
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeDurationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_duration(self):
            // for record in self:
            //     end = record.livechat_end_dt or fields.Datetime.now()
            //     start = record.create_date or fields.Datetime.now()
            //     record.duration = (end - start).total_seconds() / 3600
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeGroupPublicIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_group_public_id(self):
            // channels = self.filtered(lambda channel: channel.channel_type == "channel")
            // for channel in channels:
            //     if channel.parent_channel_id:
            //         channel.group_public_id = channel.parent_channel_id.group_public_id
            //     elif not channel.group_public_id:
            //         channel.group_public_id = self.env.ref("base.group_user")
            // (self - channels).group_public_id = None
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeHasCrmLeadInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_livechat, FILE: discuss_channel.py) ---
            // def _compute_has_crm_lead(self):
            // for channel in self:
            //     channel.has_crm_lead = bool(channel.lead_ids)
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeInvitationUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_invitation_url(self):
            // for channel in self:
            //     channel.invitation_url = f"/chat/{channel.id}/{channel.uuid}"
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeInvitedMemberIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_invited_member_ids(self):
            // members_by_channel = {
            //     channel: self.env["discuss.channel.member"].browse(member_ids)
            //     for channel, member_ids in self.env["discuss.channel.member"]._read_group(
            //         [("channel_id", "in", self.ids), ("rtc_inviting_session_id", "!=", False)],
            //         ["channel_id"],
            //         ["id:array_agg"],
            //     )
            // }
            // for channel in self:
            //     channel.invited_member_ids = members_by_channel.get(channel)
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeIsEditableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_is_editable(self):
            // for channel in self:
            //     channel.is_editable = channel.has_access("write")
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeIsMemberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_is_member(self):
            // for channel in self:
            //     channel.is_member = bool(channel.self_member_id)
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatAgentHistoryIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_agent_history_ids(self):
            // for channel in self:
            //     channel.livechat_agent_history_ids = (
            //         channel.livechat_channel_member_history_ids.filtered(
            //             lambda h: h.livechat_member_type == "agent",
            //         )
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatAgentPartnerIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_agent_partner_ids(self):
            // for channel in self:
            //     channel.livechat_agent_partner_ids = (
            //         channel.livechat_agent_history_ids.partner_id
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatAgentProvidingHelpHistoryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_agent_providing_help_history(self):
            // for channel in self:
            //     channel.livechat_agent_providing_help_history = (
            //         channel.livechat_agent_history_ids.sorted(
            //             lambda h: (h.create_date, h.id), reverse=True
            //         )[0]
            //         if channel.livechat_is_escalated
            //         else None
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatAgentRequestingHelpHistoryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_agent_requesting_help_history(self):
            // for channel in self:
            //     channel.livechat_agent_requesting_help_history = (
            //         channel.livechat_agent_history_ids.sorted(lambda h: (h.create_date, h.id))[0]
            //         if channel.livechat_is_escalated
            //         else None
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatBotHistoryIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_bot_history_ids(self):
            // for channel in self:
            //     channel.livechat_bot_history_ids = channel.livechat_channel_member_history_ids.filtered(
            //         lambda h: h.livechat_member_type == "bot",
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatBotPartnerIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_bot_partner_ids(self):
            // for channel in self:
            //     channel.livechat_bot_partner_ids = (
            //         channel.livechat_bot_history_ids.partner_id
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatCustomerGuestIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_customer_guest_ids(self):
            // for channel in self:
            //     channel.livechat_customer_guest_ids = (
            //         channel.livechat_customer_history_ids.guest_id
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatCustomerHistoryIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_customer_history_ids(self):
            // for channel in self:
            //     channel.livechat_customer_history_ids = (
            //         channel.livechat_channel_member_history_ids.filtered(
            //             lambda h: h.livechat_member_type == "visitor",
            //         )
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatCustomerPartnerIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_customer_partner_ids(self):
            // for channel in self:
            //     channel.livechat_customer_partner_ids = (
            //         channel.livechat_customer_history_ids.partner_id
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatIsEscalatedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_is_escalated(self):
            // for channel in self:
            //     channel.livechat_is_escalated = len(channel.livechat_agent_history_ids) > 1
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatMatchesSelfExpertiseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_matches_self_expertise(self):
            // for channel in self:
            //     channel.livechat_matches_self_expertise = bool(
            //         channel.livechat_expertise_ids & self.env.user.livechat_expertise_ids
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatMatchesSelfLangInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_matches_self_lang(self):
            // for channel in self:
            //     channel.livechat_matches_self_lang = (
            //         channel.livechat_lang_id in self.env.user.livechat_lang_ids
            //         or channel.livechat_lang_id.code == self.env.user.lang
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatOutcomeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_outcome(self):
            // for channel in self:
            //     self.livechat_outcome = (
            //         "escalated" if channel.livechat_is_escalated else channel.livechat_failure
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatStartHourInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_start_hour(self):
            // for channel in self:
            //     channel.livechat_start_hour = channel.create_date.hour
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_status(self):
            // for channel in self.filtered(lambda c: c.livechat_end_dt):
            //     channel.livechat_status = False
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatWeekDayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_livechat_week_day(self):
            // for channel in self:
            //     channel.livechat_week_day = str(channel.create_date.weekday())
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeMemberCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_member_count(self):
            // read_group_res = self.env['discuss.channel.member']._read_group(domain=[('channel_id', 'in', self.ids)], groupby=['channel_id'], aggregates=['__count'])
            // member_count_by_channel_id = {channel.id: count for channel, count in read_group_res}
            // for channel in self:
            //     channel.member_count = member_count_by_channel_id.get(channel.id, 0)
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeMessageCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_message_count(self):
            // read_group_res = self.env["mail.message"]._read_group(
            //     domain=[
            //         ("model", "=", "discuss.channel"),
            //         ("res_id", "in", self.ids),
            //         ("message_type", "not in", ["user_notification", "notification"])
            //     ], groupby=["res_id"], aggregates=["__count"]
            // )
            // message_count_by_channel_id = dict(read_group_res)
            // for channel in self:
            //     channel.message_count = message_count_by_channel_id.get(channel.id, 0)
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeSelfMemberIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_self_member_id(self):
            // member_by_channel = {
            //     channel: self.env["discuss.channel.member"].browse(member_id)
            //     for channel, member_id in self.env["discuss.channel.member"]._read_group(
            //         [("channel_id", "in", self.ids), ("is_self", "=", True)], ["channel_id"], ["id:max"]
            //     )
            // }
            // for channel in self:
            //     channel.self_member_id = member_by_channel.get(channel)
            */
            return default;
        }

        protected async Task<DiscussChannel> ConstraintFromMessageIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _constraint_from_message_id(self):
            // # sudo: discuss.channel - skipping ACL for constraint, more performant and no sensitive information is leaked
            // if failing_channels := self.sudo().filtered(
            //     lambda c: c.from_message_id
            //     and (
            //         c.from_message_id.res_id not in [c.parent_channel_id.id] + c.parent_channel_id.sub_channel_ids.ids
            //         or c.from_message_id.model != "discuss.channel"
            //     )
            // ):
            //     raise ValidationError(
            //         _(
            //             "Cannot create %(channels)s: initial message should belong to parent channel or one of its sub-channels.",
            //             channels=failing_channels.mapped("name"),
            //         )
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannel> ConstraintGroupIdChannelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _constraint_group_id_channel(self):
            // # sudo: discuss.channel - skipping ACL for constraint, more performant and no sensitive information is leaked
            // failing_channels = self.sudo().filtered(lambda channel: channel.channel_type != 'channel' and (channel.group_public_id or channel.group_ids))
            // if failing_channels:
            //     raise ValidationError(_("For %(channels)s, channel_type should be 'channel' to have the group-based authorization or group auto-subscription.", channels=', '.join([ch.name for ch in failing_channels])))
            */
            return default;
        }

        protected async Task<DiscussChannel> ConstraintParentChannelIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _constraint_parent_channel_id(self):
            // # sudo: discuss.channel - skipping ACL for constraint, more performant and no sensitive information is leaked
            // if failing_channels := self.sudo().filtered(
            //     lambda c: c.parent_channel_id
            //     and (
            //         c.parent_channel_id.parent_channel_id
            //         or c.parent_channel_id.channel_type not in ["channel", "group"]
            //         or c.parent_channel_id.channel_type != c.channel_type
            //     )
            // ):
            //     raise ValidationError(
            //         _(
            //             "Cannot create %(channels)s: parent should not be a sub-channel and should be of type 'channel' or 'group'. The sub-channel should have the same type as the parent.",
            //             channels=failing_channels.mapped("name"),
            //         ),
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannel> ConstraintPartnersChatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _constraint_partners_chat(self):
            // # sudo: discuss.channel - skipping ACL for constraint, more performant and no sensitive information is leaked
            // for ch in self.sudo().filtered(lambda ch: ch.channel_type == 'chat'):
            //     if len(ch.channel_member_ids) > 2:
            //         raise ValidationError(_("A channel of type 'chat' cannot have more than two users."))
            */
            return default;
        }

        protected async Task<DiscussChannel> ConstraintSubscriptionDepartmentIdsChannelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: discuss_channel.py) ---
            // def _constraint_subscription_department_ids_channel(self):
            // failing_channels = self.sudo().filtered(lambda channel: channel.channel_type != 'channel' and channel.subscription_department_ids)
            // if failing_channels:
            //     raise ValidationError(_("For %(channels)s, channel_type should be 'channel' to have the department auto-subscription.", channels=', '.join([ch.name for ch in failing_channels])))
            */
            return default;
        }

        protected async Task<DiscussChannel> ConvertVisitorToLeadInternalAsync(object partner, object key)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_livechat, FILE: discuss_channel.py) ---
            // def _convert_visitor_to_lead(self, partner, key):
            // """ Create a lead from channel /lead command
            // :param partner: internal user partner (operator) that created the lead;
            // :param key: operator input in chat ('/lead Lead about Product')
            // """
            // # if public user is part of the chat: consider lead to be linked to an
            // # anonymous user whatever the participants. Otherwise keep only share
            // # partners (no user or portal user) to link to the lead.
            // customers = self.env['res.partner']
            // for customer in self.with_context(active_test=False).channel_partner_ids.filtered(lambda p: p != partner and p.partner_share):
            //     if customer.is_public:
            //         customers = self.env['res.partner']
            //         break
            //     else:
            //         customers |= customer
            // 
            // utm_source = self.env.ref('crm_livechat.utm_source_livechat', raise_if_not_found=False)
            // return self.env['crm.lead'].create({
            //     "origin_channel_id": self.id,
            //     'name': html2plaintext(key[5:]),
            //     'partner_id': customers[0].id if customers else False,
            //     'user_id': False,
            //     'team_id': False,
            //     'description': self._get_channel_history(),
            //     'referred': partner.name,
            //     'source_id': utm_source and utm_source.id,
            // })
            --- ODOO METHOD SOURCE (MODULE: website_crm_livechat, FILE: discuss_channel.py) ---
            // def _convert_visitor_to_lead(self, partner, key):
            // """ When website is installed, we can link the created lead from /lead command
            //  to the current website_visitor. We do not use the lead name as it does not correspond
            //  to the lead contact name."""
            // lead = super()._convert_visitor_to_lead(partner, key)
            // visitor_sudo = self.livechat_visitor_id.sudo()
            // if visitor_sudo:
            //     visitor_sudo.write({'lead_ids': [(4, lead.id)]})
            //     lead.country_id = lead.country_id or visitor_sudo.country_id
            // return lead
            */
            return default;
        }

        protected async Task<DiscussChannel> CreateAttachmentsForPostInternalAsync(object values_list, object extra_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _create_attachments_for_post(self, values_list, extra_list):
            // # Create voice metadata from meta information
            // attachments = super()._create_attachments_for_post(values_list, extra_list)
            // voice = attachments.env['ir.attachment']  # keep env, notably for potential sudo
            // for attachment, (_cid, _name, _token, info) in zip(attachments, extra_list):
            //     if info.get('voice'):
            //         voice += attachment
            // if voice:
            //     voice._set_voice_metadata()
            // return attachments
            */
            return default;
        }

        [ApiModel]
        protected async Task<DiscussChannel> CreateChannelInternalAsync(object name, Guid group_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _create_channel(self, name, group_id):
            // """ Create a channel and add the current partner, broadcast it (to make the user directly
            //     listen to it when polling)
            //     :param name : the name of the channel to create
            //     :param group_id : the group allowed to join the channel.
            //     :return dict : channel header
            // """
            // # create the channel
            // vals = {
            //     'channel_type': 'channel',
            //     'name': name,
            // }
            // new_channel = self.create(vals)
            // group = self.env['res.groups'].search([('id', '=', group_id)]) if group_id else None
            // new_channel.group_public_id = group.id if group else None
            // notification = Markup('<div class="o_mail_notification">%s</div>') % _("created this channel.")
            // new_channel.message_post(body=notification, message_type="notification", subtype_xmlid="mail.mt_comment")
            // return new_channel
            */
            return default;
        }

        [ApiModel]
        protected async Task<DiscussChannel> CreateGroupInternalAsync(object partners_to, object default_display_mode, object name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _create_group(self, partners_to, default_display_mode=False, name=''):
            // """ Creates a group channel.
            // 
            //     :param partners_to : list of res.partner ids to add to the conversation
            //     :param str default_display_mode: how the channel will be displayed by default
            //     :param str name: group name. default name is computed client side from the list of members if no name is set
            //     :returns: channel_info of the created channel
            //     :rtype: dict
            // """
            // partners_to = OrderedSet(partners_to)
            // channel = self.create({
            //     'channel_member_ids': [Command.create({'partner_id': partner_id}) for partner_id in partners_to],
            //     'channel_type': 'group',
            //     'default_display_mode': default_display_mode,
            //     'name': name,
            // })
            // channel._broadcast(channel.channel_member_ids.partner_id.ids)
            // return channel
            */
            return default;
        }

        protected async Task<DiscussChannel> CreateSubChannelInternalAsync(Guid from_message_id, object name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _create_sub_channel(self, from_message_id=None, name=None):
            // self.ensure_one()
            // message = self.env["mail.message"]
            // if from_message_id:
            //     message = self.env["mail.message"].search([("id", "=", from_message_id)])
            // if not name:
            //     name = self.env._("New Thread")
            //     if message:
            //         if message._filter_empty():
            //             name = self.env._("This message has been removed")
            //         elif stripped := message.body and message.body.striptags():
            //             name = stripped[:30]
            // sub_channel = self.create(
            //     {
            //         "channel_type": self.channel_type,
            //         "from_message_id": message.id,
            //         "name": name,
            //         "parent_channel_id": self.id,
            //     }
            // )
            // sub_channel.add_members(partner_ids=(self.env.user.partner_id | message.author_id).ids, post_joined_message=False)
            // notification = (
            //     Markup('<div class="o_mail_notification">%s</div>')
            //     % _(
            //         "%(user)s started a thread: %(goto)s%(thread_name)s%(goto_end)s."
            //     )
            // ) % {
            //     "user": self.env.user.display_name,
            //     "goto": Markup(
            //         "<a href='#' class='o_channel_redirect' data-oe-id='%s' data-oe-model='discuss.channel'>"
            //     )
            //     % sub_channel.id,
            //     "goto_end": Markup("</a>"),
            //     "thread_name": sub_channel.name,
            // }
            // self.message_post(
            //     body=notification, message_type="notification", subtype_xmlid="mail.mt_comment"
            // )
            // return sub_channel
            */
            return default;
        }

        protected async Task<DiscussChannel> EmailLivechatTranscriptInternalAsync(object email)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _email_livechat_transcript(self, email):
            // company = self.env.user.company_id
            // tz = "UTC"
            // # sudo: discuss.channel - access partner's/guest's timezone
            // for customer in self.sudo().livechat_customer_history_ids:
            //     customer_tz = customer.partner_id.tz or customer.guest_id.timezone
            //     if customer_tz:
            //         tz = customer_tz
            //         break
            // render_context = {
            //     "company": company,
            //     "channel": self,
            //     "tz": timezone(tz),
            // }
            // mail_body = self.env['ir.qweb']._render('im_livechat.livechat_email_template', render_context, minimal_qcontext=True)
            // mail_body = self.env['mail.render.mixin']._replace_local_links(mail_body)
            // mail = self.env['mail.mail'].sudo().create({
            //     'subject': _('Conversation with %s', self.livechat_operator_id.user_livechat_username or self.livechat_operator_id.name),
            //     'email_from': company.catchall_formatted or company.email_formatted,
            //     'author_id': self.env.user.partner_id.id,
            //     'email_to': email_split(email)[0],
            //     'body_html': mail_body,
            // })
            // mail.send()
            */
            return default;
        }

        public async Task<DiscussChannel> ExecuteCommandHelpAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def execute_command_help(self, **kwargs):
            // self.ensure_one()
            // if self.channel_type == 'channel':
            //     msg = _(
            //         "You are in channel %(bold_start)s#%(channel_name)s%(bold_end)s.",
            //         bold_start=Markup("<b>"),
            //         bold_end=Markup("</b>"),
            //         channel_name=self.name,
            //     )
            // else:
            //     if members := self.channel_member_ids.filtered(lambda m: not m.is_self):
            //         member_names = html_escape(format_list(self.env, [f"%(member_{member.id})s" for member in members])) % {
            //             f"member_{member.id}": member._get_html_link(for_persona=True)
            //             for member in members
            //         }
            //         msg = _(
            //             "You are in a private conversation with %(member_names)s.",
            //             member_names=member_names,
            //         )
            //     else:
            //         msg = _("You are alone in a private conversation.")
            // msg += self._execute_command_help_message_extra()
            // self.env.user._bus_send_transient_message(self, msg)
            --- ODOO METHOD SOURCE (MODULE: mail_bot, FILE: discuss_channel.py) ---
            // def execute_command_help(self, **kwargs):
            // super().execute_command_help(**kwargs)
            // self.env['mail.bot']._apply_logic(self, kwargs, command="help")
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<DiscussChannel> ExecuteCommandHelpMessageExtraInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _execute_command_help_message_extra(self):
            // msg = _(
            //     "%(new_line)s"
            //     "%(new_line)sType %(bold_start)s@username%(bold_end)s to mention someone, and grab their attention."
            //     "%(new_line)sType %(bold_start)s#channel%(bold_end)s to mention a channel."
            //     "%(new_line)sType %(bold_start)s/command%(bold_end)s to execute a command."
            //     "%(new_line)sType %(bold_start)s::shortcut%(bold_end)s to insert a canned response in your message."
            //     "%(new_line)sType %(bold_start)s:emoji:%(bold_end)s to insert an emoji in your message.",
            //     bold_start=Markup("<b>"),
            //     bold_end=Markup("</b>"),
            //     new_line=Markup("<br>"),
            // )
            // return msg
            */
            return default;
        }

        public async Task<DiscussChannel> ExecuteCommandHistoryAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def execute_command_history(self, **kwargs):
            // self._bus_send(
            //     "im_livechat.history_command",
            //     {"id": self.id, "partner_id": self.env.user.partner_id.id},
            // )
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> ExecuteCommandLeadAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_livechat, FILE: discuss_channel.py) ---
            // def execute_command_lead(self, **kwargs):
            // key = kwargs['body']
            // lead_command = "/lead"
            // if key.strip() == lead_command:
            //     msg = _(
            //         "Create a new lead with: "
            //         "%(pre_start)s%(lead_command)s %(i_start)slead title%(i_end)s%(pre_end)s",
            //         lead_command=lead_command,
            //         pre_start=Markup("<pre>"),
            //         pre_end=Markup("</pre>"),
            //         i_start=Markup("<i>"),
            //         i_end=Markup("</i>"),
            //     )
            // else:
            //     lead = self._convert_visitor_to_lead(self.env.user.partner_id, key)
            //     msg = _("Created a new lead: %s", lead._get_html_link())
            // self.env.user._bus_send_transient_message(self, msg)
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> ExecuteCommandLeaveAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def execute_command_leave(self, **kwargs):
            // if self.channel_type in self._types_allowing_unfollow():
            //     self.action_unfollow()
            // else:
            //     self.channel_pin(False)
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<DiscussChannel> ExecuteCommandWhoAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def execute_command_who(self, **kwargs):
            // if all_other_members := self.channel_member_ids.filtered(lambda m: not m.is_self):
            //     members = all_other_members[:30]
            //     list_params = [f"%(member_{member.id})s" for member in members]
            //     if len(all_other_members) != len(members):
            //         list_params.append(_("more"))
            //     else:
            //         list_params.append(_("you"))
            //     member_names = html_escape(format_list(self.env, list_params)) % {
            //         f"member_{member.id}": member._get_html_link(for_persona=True)
            //         for member in members
            //     }
            //     msg = _(
            //         "Users in this channel: %(members)s.",
            //         members=member_names,
            //     )
            // else:
            //     msg = _("You are alone in this channel.")
            // self.env.user._bus_send_transient_message(self, msg)
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<DiscussChannel> FindOrCreateMemberForSelfInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _find_or_create_member_for_self(self):
            // self.ensure_one()
            // domain = [("channel_id", "=", self.id), ("is_self", "=", True)]
            // member = self.env["discuss.channel.member"].search(domain)
            // if member:
            //     return member
            // if not self.env.user._is_public():
            //     return self._add_members(users=self.env.user)
            // guest = self.env["mail.guest"]._get_guest_from_context()
            // if guest:
            //     return self._add_members(guests=guest)
            // return self.env["discuss.channel.member"]
            */
            return default;
        }

        protected async Task<DiscussChannel> FindOrCreatePersonaForChannelInternalAsync(object guest_name, object timezone, object country_code, object create_member_params, object post_joined_message)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _find_or_create_persona_for_channel(
            //     self,
            //     guest_name,
            //     timezone,
            //     country_code,
            //     create_member_params=None,
            //     post_joined_message=True,
            // ):
            //     """
            //     :param guest_name: name of the persona
            //     :param post_joined_message: whether to post a message to the channel
            //         to notify that the persona joined
            // 
            //     :param dict create_member_params: optional parameters to pass to the
            //         channel member create function.
            // 
            //     :rtype: tuple[partner, guest]
            //     """
            //     self.ensure_one()
            //     guest = self.env["mail.guest"]
            //     member = self.env["discuss.channel.member"].search([("channel_id", "=", self.id), ("is_self", "=", True)])
            //     if member:
            //         return member.partner_id, member.guest_id
            //     if not self.env.user._is_public():
            //         self._add_members(users=self.env.user, post_joined_message=post_joined_message)
            //     else:
            //         guest = guest._get_or_create_guest(
            //             guest_name=guest_name, country_code=country_code, timezone=timezone
            //         )
            //         self.with_context(guest=guest)._add_members(
            //             guests=guest,
            //             create_member_params=create_member_params,
            //             post_joined_message=post_joined_message,
            //         )
            //     return self.env.user.partner_id if not guest else self.env["res.partner"], guest
            */
            return default;
        }

        protected async Task<DiscussChannel> ForwardHumanOperatorInternalAsync(object chatbot_script_step, object users)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _forward_human_operator(self, chatbot_script_step=None, users=None):
            // """ Add a human operator to the conversation. The conversation with the chatbot (scripted chatbot or ai agent) is stopped
            // the visitor will continue the conversation with a real person.
            // 
            // In case we don't find any operator (e.g: no-one is available) we don't post any messages.
            // The chat with the chatbot will continue normally, which allows to add extra steps when it's the case
            // (e.g: ask for the visitor's email and create a lead).
            // 
            // :param chatbot_script_step: the forward to operator chatbot script step if the forwarding is done through
            // a scripted chatbot (not used if the forwarding is done through an AI Agent).
            // :param users: recordset of candidate operators, if not provided the currently available
            //     users of the livechat channel are used as candidates instead.
            // """
            // 
            // human_operator = False
            // posted_message = self.env['mail.message']
            // if chatbot_script_step is None:
            //     chatbot_script_step = self.env['chatbot.script.step']
            // 
            // if self.livechat_channel_id:
            //     human_operator = self._get_human_operator(users, chatbot_script_step)
            // 
            // # handle edge case where we found yourself as available operator -> don't do anything
            // # it will act as if no-one is available (which is fine)
            // if human_operator and human_operator != self.env.user:
            // 
            //     # first post the message of the step (if we have one)
            //     posted_message = self._post_current_chatbot_step_message(chatbot_script_step)
            // 
            //     # sudo - discuss.channel: let the chat bot proceed to the forward step (change channel operator, add human operator
            //     # as member, remove bot from channel, rename channel and finally broadcast the channel to the new operator).
            //     channel_sudo = self.sudo()
            //     bot_partner_id = channel_sudo.channel_member_ids.filtered(lambda m: m.livechat_member_type == "bot").partner_id
            // 
            //     # next, add the human_operator to the channel and post a "Operator invited to the channel" notification
            //     create_member_params = {'livechat_member_type': 'agent'}
            //     if chatbot_script_step.operator_expertise_ids:
            //         create_member_params['agent_expertise_ids'] = chatbot_script_step.operator_expertise_ids.ids
            //         channel_sudo.livechat_expertise_ids |= chatbot_script_step.operator_expertise_ids
            //     channel_sudo._add_new_members_to_channel(
            //         create_member_params=create_member_params,
            //         inviting_partner=bot_partner_id,
            //         users=human_operator,
            //     )
            //     channel_sudo._action_unfollow(partner=bot_partner_id, post_leave_message=False)
            // 
            //     # finally, rename the channel to include the operator's name
            //     channel_sudo._update_forwarded_channel_data(
            //         livechat_failure="no_answer",
            //         livechat_operator_id=human_operator.partner_id,
            //         operator_name=human_operator.livechat_username if human_operator.livechat_username else human_operator.name,
            //     )
            //     channel_sudo._add_next_step_message_to_store(chatbot_script_step)
            //     channel_sudo._broadcast(human_operator.partner_id.ids)
            //     self.channel_pin(pinned=True)
            // else:
            //     # sudo: discuss.channel - visitor tried getting operator, outcome must be updated
            //     self.sudo().livechat_failure = "no_agent"
            // 
            // return posted_message
            */
            return default;
        }

        protected async Task<DiscussChannel> GcBotOnlyOngoingSessionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _gc_bot_only_ongoing_sessions(self):
            // """Garbage collect bot-only livechat sessions with no activity for over 1 day."""
            // stale_sessions = self.search([
            //     ("channel_type", "=", "livechat"),
            //     ("livechat_end_dt", "=", False),
            //     ("last_interest_dt", "<=", "-1d"),
            //     ("livechat_agent_partner_ids", "=", False),
            // ])
            // stale_sessions.livechat_end_dt = fields.Datetime.now()
            */
            return default;
        }

        protected async Task<DiscussChannel> GcEmptyLivechatSessionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _gc_empty_livechat_sessions(self):
            // hours = 1  # never remove empty session created within the last hour
            // self.env.cr.execute("""
            //     SELECT id as id
            //     FROM discuss_channel C
            //     WHERE NOT EXISTS (
            //         SELECT 1
            //         FROM mail_message M
            //         WHERE M.res_id = C.id AND m.model = 'discuss.channel'
            //     ) AND C.channel_type = 'livechat' AND livechat_channel_id IS NOT NULL AND
            //         COALESCE(write_date, create_date, (now() at time zone 'UTC'))::timestamp
            //         < ((now() at time zone 'UTC') - interval %s)""", ("%s hours" % hours,))
            // empty_channel_ids = [item['id'] for item in self.env.cr.dictfetchall()]
            // self.browse(empty_channel_ids).unlink()
            */
            return default;
        }

        protected async Task<DiscussChannel> GenerateAvatarInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _generate_avatar(self):
            // if self.channel_type not in ('channel', 'group'):
            //     return False
            // avatar = group_avatar if self.channel_type == 'group' else channel_avatar
            // bgcolor = get_hsl_from_seed(self.uuid)
            // avatar = avatar.replace('fill="#875a7b"', f'fill="{bgcolor}"')
            // return base64.b64encode(avatar.encode())
            */
            return default;
        }

        [ApiModel]
        protected async Task<DiscussChannel> GenerateRandomTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _generate_random_token(self):
            // # Built to be shared on invitation link. It uses non-ambiguous characters and it is of a
            // # reasonable length: enough to avoid brute force, but short enough to be shareable easily.
            // # This token should not contain "mail.guest"._cookie_separator value.
            // return ''.join(choice('abcdefghijkmnopqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ23456789') for _i in range(10))
            */
            return default;
        }

        protected async Task<DiscussChannel> GetAccessActionInternalAsync(object access_uid, object force_website)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_access_action(self, access_uid=None, force_website=False):
            // """ Redirect to Discuss instead of form view. """
            // self.ensure_one()
            // if not self.env.user._is_internal() or force_website:
            //     return {
            //         "type": "ir.actions.act_url",
            //         "url": f"/discuss/channel/{self.id}",
            //         "target": "self",
            //         "target_type": "public",
            //     }
            // return {
            //     "type": "ir.actions.act_url",
            //     "url": f"/odoo/action-mail.action_discuss?active_id={self.id}",
            //     "target": "self",
            // }
            */
            return default;
        }

        [ApiModel]
        protected async Task<DiscussChannel> GetAllowedChannelMemberCreateParamsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _get_allowed_channel_member_create_params(self):
            // return super()._get_allowed_channel_member_create_params() + [
            //     "chatbot_script_id",
            //     "livechat_member_type",
            // ]
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_allowed_channel_member_create_params(self):
            // return ["partner_id", "guest_id", "unpin_dt", "last_interest_dt"]
            */
            return default;
        }

        protected async Task<DiscussChannel> GetAllowedMessageParamsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_allowed_message_params(self):
            // return super()._get_allowed_message_params() | {"special_mentions", "parent_id"}
            */
            return default;
        }

        protected async Task<DiscussChannel> GetAllowedMessagePartnerIdsInternalAsync(List<Guid> partner_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_allowed_message_partner_ids(self, partner_ids):
            // """Ensure only partners having access to the channel can be mentioned."""
            // partners = self.env["res.partner"].browse(partner_ids)
            // if self.channel_type == "channel":
            //     if self.group_public_id:
            //         partners = partners.filtered(
            //             lambda p: p.user_ids.all_group_ids & self.group_public_id,
            //         )
            // else:
            //     partners = (
            //         self.env["discuss.channel.member"]
            //         .search_fetch(
            //             [("channel_id", "=", self.id), ("partner_id", "in", partner_ids)],
            //             ["partner_id"],
            //         )
            //         .partner_id
            //     )
            // return partners.ids
            */
            return default;
        }

        protected async Task<DiscussChannel> GetCallNotificationTagInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_call_notification_tag(self):
            // self.ensure_one()
            // return f"call_{self.id}"
            */
            return default;
        }

        protected async Task<DiscussChannel> GetChannelHistoryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _get_channel_history(self):
            // """
            // Converting message body back to plaintext for correct data formatting in HTML field.
            // """
            // self.ensure_one()
            // parts = []
            // previous_message_author = None
            // # sudo - mail.message: getting empty messages to exclude them is allowed.
            // for message in (self.message_ids - self.message_ids.sudo()._filter_empty()).sorted("id"):
            //     # sudo - res.partner: accessing livechat username or name is allowed to visitor
            //     message_author = message.author_id.sudo() or message.author_guest_id
            //     if previous_message_author != message_author:
            //         parts.append(
            //             Markup("<br/><strong>%s:</strong><br/>")
            //             % (
            //                 (message_author.user_livechat_username if message_author._name == "res.partner" else None)
            //                 or message_author.name
            //             ),
            //         )
            //     if not tools.is_html_empty(message.body):
            //         parts.append(Markup("%s<br/>") % html2plaintext(message.body))
            //         previous_message_author = message_author
            //     for attachment in message.attachment_ids:
            //         previous_message_author = message_author
            //         # sudo - ir.attachment: public user can read attachment metadata
            //         parts.append(Markup("%s<br/>") % self._attachment_to_html(attachment.sudo()))
            // return Markup("").join(parts)
            */
            return default;
        }

        [ApiModel]
        protected async Task<DiscussChannel> GetChannelsAsMemberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_channels_as_member(self):
            // # 2 different queries because the 2 sub-queries together with OR are less efficient
            // member_domain = [("channel_type", "in", ("channel", "group")), ("is_member", "=", True)]
            // pinned_member_domain = [
            //         ("channel_type", "not in", ("channel", "group")),
            //         ("channel_member_ids", "any", [("is_self", "=", True), ("is_pinned", "=", True)]),
            //     ]
            // channels = self.env["discuss.channel"].search(member_domain)
            // channels += self.env["discuss.channel"].search(pinned_member_domain)
            // return channels
            */
            return default;
        }

        protected async Task<DiscussChannel> GetHumanOperatorInternalAsync(object users, object chatbot_script_step)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _get_human_operator(self, users, chatbot_script_step):
            // operator_params = {
            //     'lang': self.env.context.get("lang"),
            //     'country_id': self.country_id.id,
            //     'users': users
            // }
            // if chatbot_script_step:
            //     operator_params['expertises'] = chatbot_script_step.operator_expertise_ids
            // # sudo: res.users - visitor can access operator of their channel
            // human_operator = self.livechat_channel_id.sudo()._get_operator(**operator_params)
            // return human_operator
            */
            return default;
        }

        protected async Task<DiscussChannel> GetLastMessagesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_last_messages(self):
            // """ Return the last message for each of the given channels."""
            // if not self.ids:
            //     return self.env["mail.message"]
            // self.env['mail.message'].flush_model()
            // self.env.cr.execute(
            //     """
            //            SELECT last_message_id
            //              FROM discuss_channel
            // LEFT JOIN LATERAL (
            //                       SELECT id
            //                         FROM mail_message
            //                        WHERE mail_message.model = 'discuss.channel'
            //                          AND mail_message.res_id = discuss_channel.id
            //                     ORDER BY id DESC
            //                        LIMIT 1
            //                   ) AS t(last_message_id) ON TRUE
            //             WHERE discuss_channel.id IN %(ids)s
            //          GROUP BY discuss_channel.id, t.last_message_id
            //          ORDER BY discuss_channel.id
            //     """,
            //     {"ids": tuple(self.ids)},
            // )
            // return self.env["mail.message"].browse([mid for (mid,) in self.env.cr.fetchall() if mid])
            */
            return default;
        }

        protected async Task<DiscussChannel> GetLivechatSessionFieldsToStoreInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_livechat, FILE: discuss_channel.py) ---
            // def _get_livechat_session_fields_to_store(self):
            // fields_to_store = super()._get_livechat_session_fields_to_store()
            // if not self.env["crm.lead"].has_access("read"):
            //     return fields_to_store
            // fields_to_store.append(
            //     Store.Many(
            //         "livechat_customer_partner_ids",
            //         [Store.Many("opportunity_ids", ["id", "name"])],
            //         only_data=True,
            //     ),
            // )
            // return fields_to_store
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _get_livechat_session_fields_to_store(self):
            // return []
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: discuss_channel.py) ---
            // def _get_livechat_session_fields_to_store(self):
            // fields_to_store = super()._get_livechat_session_fields_to_store()
            // domain = [
            //     ("channel_type", "=", "livechat"),
            //     ("livechat_visitor_id", "=", self.livechat_visitor_id.id),
            //     (
            //         "create_date",
            //         ">=",
            //         fields.Datetime.to_string(datetime.now() - timedelta(days=7)),
            //     ),
            // ]
            // channels = self.env["discuss.channel"].search(domain, limit=5)
            // fields_to_store.append(
            //     Store.One(
            //         "livechat_visitor_id", [
            //             Store.Many(
            //                 "discuss_channel_ids",
            //                 value=channels,
            //             ),
            //         ],
            //         predicate=is_livechat_channel,
            //     ),
            // )
            // return fields_to_store
            */
            return default;
        }

        [ApiModel]
        public async Task<DiscussChannel> GetMentionSuggestionsAsync(DiscussChannelGetMentionSuggestionsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def get_mention_suggestions(self, search, limit=8):
            // """ Return 'limit'-first channels' name, channel_type and group_public_id fields such that the
            //     name matches a 'search' string. Exclude channels of type chat (DM) and group.
            // """
            // domain = [("name", "ilike", search), ("channel_type", "=", "channel")]
            // channels = self.search(domain, limit=limit)
            // channel_fields = [
            //     "name",
            //     "channel_type",
            //     Store.One("group_public_id", ["full_name"]),
            //     Store.One("parent_channel_id", [])
            // ]
            // store = Store().add(channels, channel_fields)
            // return store.get_result()
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<DiscussChannel> GetNotifyValidParametersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_notify_valid_parameters(self):
            // return super()._get_notify_valid_parameters() | {"silent"}
            */
            return default;
        }

        [ApiModel]
        protected async Task<DiscussChannel> GetOrCreateChatInternalAsync(object partners_to, object pin)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_or_create_chat(self, partners_to, pin=True):
            // """ Get the canonical private channel between some partners, create it if needed.
            //     To reuse an old channel (conversation), this one must be private, and contains
            //     only the given partners.
            //     :param partners_to : list of res.partner ids to add to the conversation
            //     :param pin : True if getting the channel should pin it for the current user
            //     :returns: channel_info of the created or existing channel
            //     :rtype: dict
            // """
            // partners = (
            //     self.env["res.partner"]
            //     .with_context(active_test=False)
            //     .search([("id", "in", partners_to)])
            // ) | self.env.user.partner_id
            // if len(partners) > 2:
            //     raise UserError(_("A chat should not be created with more than 2 persons. Create a group instead."))
            // # determine type according to the number of partner in the channel
            // self.flush_model()
            // self.env['discuss.channel.member'].flush_model()
            // self.env.cr.execute(
            //     SQL(
            //         """
            //     SELECT M.channel_id
            //     FROM discuss_channel C, discuss_channel_member M
            //     WHERE M.channel_id = C.id
            //         AND M.partner_id IN %(partner_ids)s
            //         AND C.channel_type LIKE 'chat'
            //         AND NOT EXISTS (
            //             SELECT 1
            //             FROM discuss_channel_member M2
            //             WHERE M2.channel_id = C.id
            //                 AND M2.partner_id NOT IN %(partner_ids)s
            //         )
            //     GROUP BY M.channel_id
            //     HAVING ARRAY_AGG(DISTINCT M.partner_id ORDER BY M.partner_id) = %(sorted_partner_ids)s
            //     LIMIT 1
            //         """,
            //         partner_ids=tuple(partners.ids),
            //         sorted_partner_ids=sorted(partners.ids),
            //     )
            // )
            // result = self.env.cr.dictfetchall()
            // # use the same "now" in the whole function to ensure unpin_dt > last_interest_dt
            // now = fields.Datetime.now()
            // last_interest_dt = now - timedelta(seconds=1)
            // if result:
            //     # get the existing channel between the given partners
            //     channel = self.browse(result[0].get('channel_id'))
            //     # pin or open the channel for the current partner
            //     if pin:
            //         channel.self_member_id.write(
            //             {"last_interest_dt": last_interest_dt, "unpin_dt": False}
            //         )
            //     channel._broadcast(self.env.user.partner_id.ids)
            // else:
            //     # create a new one
            //     channel = self.create(
            //         {
            //             "channel_member_ids": [
            //                 Command.create(
            //                     {
            //                         "last_interest_dt": last_interest_dt,
            //                         "partner_id": partner.id,
            //                         # only pin for the current user, so the chat does not show up for the correspondent until a message has been sent
            //                         "unpin_dt": False if partner == self.env.user.partner_id else now,
            //                     }
            //                 )
            //                 for partner in partners
            //             ],
            //             "channel_type": "chat",
            //             "last_interest_dt": last_interest_dt,
            //             "name": ", ".join(partners.mapped("name")),
            //         }
            //     )
            //     channel._broadcast(partners.ids)
            // return channel
            */
            return default;
        }

        protected async Task<DiscussChannel> GetStoreMessageUpdateExtraFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_store_message_update_extra_fields(self):
            // return super()._get_store_message_update_extra_fields() + [Store.One("parent_id")]
            */
            return default;
        }

        protected async Task<DiscussChannel> GetVisitorHistoryInternalAsync(object visitor)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: discuss_channel.py) ---
            // def _get_visitor_history(self, visitor):
            // return visitor._get_visitor_history()
            */
            return default;
        }

        protected async Task<DiscussChannel> GetVisitorLeaveMessageInternalAsync(object @operator, object cancel)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _get_visitor_leave_message(self, operator=False, cancel=False):
            // return _('Visitor left the conversation.')
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: discuss_channel.py) ---
            // def _get_visitor_leave_message(self, operator=False, cancel=False):
            // if not cancel:
            //     if self.livechat_visitor_id.id:
            //         return _("Visitor #%(id)d left the conversation.", id=self.livechat_visitor_id.id)
            //     return _("Visitor left the conversation.")
            // return _(
            //     "%(visitor)s started a conversation with %(operator)s.\nThe chat request has been cancelled",
            //     visitor=self.livechat_visitor_id.display_name or _("The visitor"),
            //     operator=operator or _("an operator"),
            // )
            */
            return default;
        }

        protected async Task<DiscussChannel> InverseChannelPartnerIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _inverse_channel_partner_ids(self):
            // new_members = []
            // outdated = self.env['discuss.channel.member']
            // for channel in self:
            //     current_members = channel.channel_member_ids
            //     partners = channel.channel_partner_ids
            //     partners_new = partners - current_members.partner_id
            // 
            //     new_members += [{
            //         'channel_id': channel.id,
            //         'partner_id': partner.id,
            //     } for partner in partners_new]
            //     outdated += current_members.filtered(lambda m: m.partner_id not in partners)
            // if new_members:
            //     self.env['discuss.channel.member'].create(new_members)
            // if outdated:
            //     outdated.unlink()
            */
            return default;
        }

        public async Task<DiscussChannel> InviteByEmailAsync(DiscussChannelInviteByEmailRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def invite_by_email(self, emails):
            // """
            // Send channel invitation emails to a list of email addresses. Existing members'
            // email addresses are ignored.
            // 
            // :param emails: List of email addresses to invite.
            // :type emails: list[str]
            // 
            // """
            // if not self.env.user._is_internal() or not self.has_access("read"):
            //     raise AccessError(self.env._("You don't have access to invite users to this channel."))
            // if not self._allow_invite_by_email():
            //     raise UserError(
            //         self.env._("Inviting by email is not allowed for this channel type (%s).")
            //         % self.channel_type
            //     )
            // eligible_emails = OrderedSet(norm for email in emails if email and (norm := email_normalize(email)))
            // # Removing emails linked to members of this channel.
            // member_domain = Domain("channel_id", "=", self.id) & Domain.OR(
            //     [
            //         [(field, "=ilike", email)]
            //         for email in eligible_emails
            //         for field in ("guest_id.email", "partner_id.email")
            //     ],
            // )
            // eligible_emails -= set(
            //     self.env["discuss.channel.member"]
            //     .search_fetch(member_domain, ["partner_id", "guest_id"])
            //     .mapped(lambda m: email_normalize(m.partner_id.email or m.guest_id.email))
            // )
            // mail_body = Markup("<p>%s</p>") % self.env._(
            //     "%(user_name)s has invited you to the %(strong_start)s%(channel_name)s%(strong_end)s channel."
            // ) % {
            //     "user_name": self.env.user.name,
            //     "channel_name": self.name,
            //     "strong_start": Markup("<strong>"),
            //     "strong_end": Markup("</strong>"),
            // }
            // to_create = []
            // for addr in eligible_emails:
            //     body = self.env["ir.qweb"]._render(
            //         "mail.discuss_channel_invitation_template",
            //         {
            //             "base_url": self.env["ir.config_parameter"].get_base_url(),
            //             "channel": self,
            //             "email_token": hash_sign(self.env(su=True), "mail.invite_email", addr),
            //             "mail_body": mail_body,
            //             "user": self.env.user,
            //         },
            //         minimal_qcontext=True,
            //     )
            //     to_create.append(
            //         {
            //             "body_html": body,
            //             "email_from": self.env.user.partner_id.email_formatted,
            //             "email_to": addr,
            //             "message_type": "user_notification",
            //             "model": "discuss.channel",
            //             "res_id": self.id,
            //             "subject": self.env._("%(author_name)s has invited you to a channel")
            //             % {"author_name": self.env.user.name},
            //         },
            //     )
            // if not to_create:
            //     return
            // try:
            //     # sudo - mail.mail: internal users having read access to the channel can invite others.
            //     self.env["mail.mail"].sudo().create(to_create).send(raise_exception=True)
            // except MailDeliveryException as mde:
            //     error_msg = self.env._(
            //         "There was an error when trying to deliver your Email, please check your configuration."
            //     )
            //     if len(mde.args) == 2 and isinstance(mde.args[1], ConnectionRefusedError):
            //         error_msg = self.env._(
            //             "Could not contact the mail server, please check your outgoing email server configuration."
            //         )
            //     raise UserError(error_msg) from mde
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<DiscussChannel> LazyLoadMembersChannelTypesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _lazy_load_members_channel_types(self):
            // """ Return the channel types that load members lazily. """
            // return ["channel", "group"]
            */
            return default;
        }

        public async Task<DiscussChannel> LivechatJoinChannelNeedingHelpAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def livechat_join_channel_needing_help(self):
            // """Join a live chat for which help was requested.
            // 
            // :returns: Whether the live chat was joined. False if the live chat could not
            //     be joined because another agent already joined the channel in the meantime.
            // :rtype: bool
            // """
            // self.ensure_one()
            // if self.livechat_status != "need_help":
            //     return False
            // self._add_members(users=self.env.user)
            // return True
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<DiscussChannel> MemberBasedNamingChannelTypesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _member_based_naming_channel_types(self):
            // """ Return the channel types that use member-based naming,
            //     specifically the `channel_name_member_ids` field.
            // """
            // return ["group"]
            */
            return default;
        }

        protected async Task<DiscussChannel> MessagePostAfterHookInternalAsync(object message, object msg_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // """
            // This method is called just before _notify_thread() method which is calling the _to_store()
            // method. We need a 'chatbot.message' record before it happens to correctly display the message.
            // It's created only if the mail channel is linked to a chatbot step. We also need to save the
            // user answer if the current step is a question selection.
            // """
            // if self.chatbot_current_step_id and not self.livechat_agent_history_ids:
            //     selected_answer = (
            //         self.env["chatbot.script.answer"]
            //         .browse(self.env.context.get("selected_answer_id"))
            //         .exists()
            //     )
            //     if selected_answer and selected_answer in self.chatbot_current_step_id.answer_ids:
            //         # sudo - chatbot.message: finding the question message to update the user answer is allowed.
            //         question_msg = (
            //             self.env["chatbot.message"]
            //             .sudo()
            //             .search(
            //                 [
            //                     ("discuss_channel_id", "=", self.id),
            //                     ("script_step_id", "=", self.chatbot_current_step_id.id),
            //                 ],
            //                 order="id DESC",
            //                 limit=1,
            //             )
            //         )
            //         question_msg.user_script_answer_id = selected_answer
            //         question_msg.user_raw_script_answer_id = selected_answer.id
            //         if store := self.env.context.get("message_post_store"):
            //             store.add(message).add(question_msg.mail_message_id)
            //         partner, guest = self.env["res.partner"]._get_current_persona()
            //         Store(bus_channel=partner or guest).add_model_values(
            //             "ChatbotStep",
            //             {
            //                 "id": (self.chatbot_current_step_id.id, question_msg.mail_message_id.id),
            //                 "scriptStep": self.chatbot_current_step_id.id,
            //                 "message": question_msg.mail_message_id.id,
            //                 "selectedAnswer": selected_answer.id,
            //             },
            //         ).bus_send()
            // 
            //     self.env["chatbot.message"].sudo().create(
            //         {
            //             "mail_message_id": message.id,
            //             "discuss_channel_id": self.id,
            //             "script_step_id": self.chatbot_current_step_id.id,
            //         }
            //     )
            // 
            // author_history = self.env["im_livechat.channel.member.history"]
            // # sudo - discuss.channel: accessing history to update its state is acceptable
            // if message.author_id or message.author_guest_id:
            //     author_history = self.sudo().livechat_channel_member_history_ids.filtered(
            //         lambda h: h.partner_id == message.author_id
            //         if message.author_id
            //         else h.guest_id == message.author_guest_id
            //     )
            // if author_history:
            //     if message.message_type not in ("notification", "user_notification"):
            //         author_history.message_count += 1
            // if author_history.livechat_member_type == "agent" and not author_history.response_time_hour:
            //     author_history.response_time_hour = (
            //         fields.Datetime.now() - author_history.create_date
            //     ).total_seconds() / 3600
            // if not self.livechat_end_dt and author_history.livechat_member_type == "agent":
            //     self.livechat_failure = "no_failure"
            // # sudo: discuss.channel - accessing livechat_status in internal code is acceptable
            // if (
            //     not self.livechat_end_dt
            //     and self.sudo().livechat_status == "waiting"
            //     and author_history.livechat_member_type == "visitor"
            // ):
            //     # sudo: discuss.channel - writing livechat_status when a message is posted is acceptable
            //     self.sudo().livechat_status = "in_progress"
            // return super()._message_post_after_hook(message, msg_vals)
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // # Automatically set the message posted by the current user as seen for themselves.
            // if self.self_member_id and message.is_current_user_or_guest_author:
            //     self.self_member_id._set_last_seen_message(message, notify=False)
            //     self.self_member_id._set_new_message_separator(message.id + 1)
            // return super()._message_post_after_hook(message, msg_vals)
            --- ODOO METHOD SOURCE (MODULE: mail_bot, FILE: discuss_channel.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // self.env["mail.bot"]._apply_logic(self, msg_vals)
            // return super()._message_post_after_hook(message, msg_vals)
            */
            return default;
        }

        public async Task<DiscussChannel> MessagePostAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def message_post(self, *, message_type="notification", partner_ids=None, **kwargs):
            // # sudo: discuss.channel - write to discuss.channel is not accessible for most users
            // self.sudo().last_interest_dt = fields.Datetime.now()
            // if "everyone" in kwargs.pop("special_mentions", []):
            //     partner_ids = list(OrderedSet((partner_ids or []) + self.channel_member_ids.partner_id.ids))
            // if partner_ids:
            //     kwargs["partner_ids"] = self._get_allowed_message_partner_ids(partner_ids)
            // # mail_post_autofollow=False is necessary to prevent adding followers
            // # when using mentions in channels. Followers should not be added to
            // # channels, and especially not automatically (because channel membership
            // # should be managed with discuss.channel.member instead).
            // # The current client code might be setting the key to True on sending
            // # message but it is only useful when targeting customers in chatter.
            // # This value should simply be set to False in channels no matter what.
            // return super(
            //     DiscussChannel,
            //     self.with_context(mail_post_autofollow_author_skip=True, mail_post_autofollow=False),
            // ).message_post(message_type=message_type, **kwargs)
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: discuss_channel.py) ---
            // def message_post(self, **kwargs):
            // """Override to mark the visitor as still connected.
            // If the message sent is not from the operator (so if it's the visitor or
            // odoobot sending closing chat notification, the visitor last action date is updated."""
            // message = super().message_post(**kwargs)
            // message_author_id = message.author_id
            // visitor = self.livechat_visitor_id
            // if len(self) == 1 and visitor and message_author_id != self.livechat_operator_id:
            //     # sudo: website.visitor: updating data of a specific visitor
            //     visitor.sudo()._update_visitor_last_visit()
            // return message
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<DiscussChannel> MessageReceiveBounceInternalAsync(object email, object partner)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _message_receive_bounce(self, email, partner):
            // # Override bounce management to unsubscribe bouncing addresses
            // for p in partner:
            //     if p.message_bounce >= self.MAX_BOUNCE_LIMIT:
            //         self._action_unfollow(p)
            // return super()._message_receive_bounce(email, partner)
            */
            return default;
        }

        protected async Task<DiscussChannel> MessageSubscribeInternalAsync(List<Guid> partner_ids, List<Guid> subtype_ids, List<Guid> customer_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _message_subscribe(self, partner_ids=None, subtype_ids=None, customer_ids=None):
            // # Do not allow follower subscription on channels. Only members are considered
            // raise UserError(_('Adding followers on channels is not possible. Consider adding members instead.'))
            */
            return default;
        }

        protected async Task<DiscussChannel> MessageUpdateContentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _message_update_content(self, message, /, *, partner_ids=None, **kwargs):
            // if partner_ids:
            //     kwargs["partner_ids"] = self._get_allowed_message_partner_ids(partner_ids)
            // super()._message_update_content(message, **kwargs)
            */
            return default;
        }

        protected async Task<DiscussChannel> NotifyByWebPushPreparePayloadInternalAsync(object message, object msg_vals, object force_record_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _notify_by_web_push_prepare_payload(self, message, msg_vals=False, force_record_name=False):
            // payload = super()._notify_by_web_push_prepare_payload(
            //     message, msg_vals=msg_vals, force_record_name=force_record_name,
            // )
            // msg_vals = msg_vals or {}
            // payload['options']['data']['action'] = 'mail.action_discuss'
            // record_name = force_record_name or message.record_name
            // author_ids = [msg_vals["author_id"]] if msg_vals.get("author_id") else message.author_id.ids
            // author = self.env["res.partner"].browse(author_ids) or self.env["mail.guest"].browse(
            //     msg_vals.get("author_guest_id", message.author_guest_id.id)
            // )
            // if self.channel_type == 'chat':
            //     payload['title'] = author.name
            // elif self.channel_type == 'channel':
            //     payload['title'] = "#%s - %s" % (record_name, author.name)
            // elif self.channel_type == 'group':
            //     if not record_name:
            //         member_names = self.channel_member_ids.mapped(lambda m: m.partner_id.name if m.partner_id else m.guest_id.name)
            //         record_name = f"{', '.join(member_names[:-1])} and {member_names[-1]}" if len(member_names) > 1 else member_names[0] if member_names else ""
            //     payload['title'] = "%s - %s" % (record_name, author.name)
            // else:
            //     payload['title'] = "#%s" % (record_name)
            // return payload
            */
            return default;
        }

        protected async Task<DiscussChannel> NotifyGetRecipientsGroupsInternalAsync(object message, object model_description, object msg_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=False):
            // # All recipients of a message on a channel are considered as partners.
            // # This means they will receive a minimal email, without a link to access
            // # in the backend. Mailing lists should indeed send minimal emails to avoid
            // # the noise.
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // for (index, (group_name, _group_func, group_data)) in enumerate(groups):
            //     if group_name != 'customer':
            //         groups[index] = (group_name, lambda partner: False, group_data)
            // return groups
            */
            return default;
        }

        protected async Task<DiscussChannel> NotifyGetRecipientsInternalAsync(object message, object msg_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _notify_get_recipients(self, message, msg_vals=False, **kwargs):
            // # Override recipients computation as channel is not a standard
            // # mail.thread document. Indeed there are no followers on a channel.
            // # Instead of followers it has members that should be notified.
            // msg_vals = msg_vals or {}
            // 
            // # notify only user input (comment, whatsapp messages or incoming / outgoing emails)
            // message_type = msg_vals['message_type'] if 'message_type' in msg_vals else message.message_type
            // if message_type not in ('comment', 'email', 'email_outgoing', 'whatsapp_message'):
            //     return []
            // 
            // recipients_data = []
            // author_id = msg_vals.get("author_id") or message.author_id.id
            // pids = msg_vals['partner_ids'] or [] if 'partner_ids' in msg_vals else message.partner_ids.ids
            // if pids:
            //     email_from = tools.email_normalize(msg_vals.get('email_from') or message.email_from)
            //     self.env['res.partner'].flush_model(['active', 'email', 'partner_share'])
            //     self.env['res.users'].flush_model(['notification_type', 'partner_id'])
            //     sql_query = SQL(
            //         """
            //         SELECT DISTINCT ON (partner.id) partner.id,
            //                partner.email_normalized,
            //                partner.lang,
            //                partner.name,
            //                partner.partner_share,
            //                users.id as uid,
            //                COALESCE(users.notification_type, 'email') as notif,
            //                COALESCE(users.share, FALSE) as ushare
            //           FROM res_partner partner
            //      LEFT JOIN res_users users on partner.id = users.partner_id
            //          WHERE partner.active IS TRUE
            //                AND partner.email != %(email)s
            //                AND partner.id IN %(partner_ids)s AND partner.id != %(author_id)s
            //         """,
            //         email=email_from or "",
            //         partner_ids=tuple(pids),
            //         author_id=author_id or 0,
            //     )
            //     self.env.cr.execute(sql_query)
            //     for partner_id, email_normalized, lang, name, partner_share, uid, notif, ushare in self.env.cr.fetchall():
            //         # ocn_client: will add partners to recipient recipient_data. more ocn notifications. We neeed to filter them maybe
            //         recipients_data.append({
            //             'active': True,
            //             'email_normalized': email_normalized,
            //             'id': partner_id,
            //             'is_follower': False,
            //             'groups': [],
            //             'lang': lang,
            //             'name': name,
            //             'notif': notif,
            //             'share': partner_share,
            //             'type': 'user' if not partner_share and notif else 'customer',
            //             'uid': uid,
            //             'ushare': ushare,
            //         })
            // 
            // domain = Domain.AND([
            //     [("channel_id", "=", self.id)],
            //     [("partner_id", "!=", author_id)],
            //     [("partner_id.active", "=", True)],
            //     [("mute_until_dt", "=", False)],
            //     [("partner_id.user_ids.manual_im_status", "!=", "busy")],
            //     Domain.OR([
            //         [("channel_id.channel_type", "!=", "channel")],
            //         Domain.AND([
            //             [("channel_id.channel_type", "=", "channel")],
            //             Domain.OR([
            //                 [("custom_notifications", "=", "all")],
            //                 Domain.AND([
            //                     [("custom_notifications", "=", False)],
            //                     [("partner_id.user_ids.res_users_settings_ids.channel_notifications", "=", "all")],
            //                 ]),
            //                 Domain.AND([
            //                     [("custom_notifications", "=", "mentions")],
            //                     [("partner_id", "in", pids)],
            //                 ]),
            //                 Domain.AND([
            //                     [("custom_notifications", "=", False)],
            //                     [("partner_id.user_ids.res_users_settings_ids.channel_notifications", "=", False)],
            //                     [("partner_id", "in", pids)],
            //                 ]),
            //             ]),
            //         ]),
            //     ]),
            // ])
            // # sudo: discuss.channel.member - read to get the members of the channel and res.users.settings of the partners
            // members = self.env["discuss.channel.member"].sudo().search(domain)
            // for member in members:
            //     recipients_data.append({
            //         "active": True,
            //         "id": member.partner_id.id,
            //         "is_follower": False,
            //         "groups": [],
            //         "lang": member.partner_id.lang,
            //         "notif": "web_push",
            //         "share": member.partner_id.partner_share,
            //         "type": "customer",
            //         "uid": False,
            //         "ushare": False,
            //     })
            // return recipients_data
            */
            return default;
        }

        protected async Task<DiscussChannel> NotifyThreadByWebPushInternalAsync(object message, object recipients_data, object msg_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _notify_thread_by_web_push(self, message, recipients_data, msg_vals=False, **kwargs):
            // # only notify "web_push" recipients in discuss channels.
            // # exclude "inbox" recipients in discuss channels as inbox and web push can be mutually exclusive.
            // # the user can turn off the web push but receive notifs via inbox if they want to.
            // super()._notify_thread_by_web_push(message, [r for r in recipients_data if r["notif"] == "web_push"], msg_vals=msg_vals, **kwargs)
            */
            return default;
        }

        protected async Task<DiscussChannel> NotifyThreadInternalAsync(object message, object msg_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _notify_thread(self, message, msg_vals=False, **kwargs):
            // # link message to channel
            // rdata = super()._notify_thread(message, msg_vals=msg_vals, **kwargs)
            // payload = {"data": Store(bus_channel=self).add(message).get_result(), "id": self.id}
            // if temporary_id := self.env.context.get("temporary_id"):
            //     payload["temporary_id"] = temporary_id
            // if kwargs.get("silent"):
            //     payload["silent"] = True
            // self._bus_send("discuss.channel/new_message", payload)
            // return rdata
            */
            return default;
        }

        protected async Task<DiscussChannel> PostCurrentChatbotStepMessageInternalAsync(object chatbot_script_step)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _post_current_chatbot_step_message(self, chatbot_script_step):
            // posted_message = self.env['mail.message']
            // if chatbot_script_step and chatbot_script_step.message:
            //     posted_message = self._chatbot_post_message(chatbot_script_step.chatbot_script_id, chatbot_script_step.message)
            // return posted_message
            */
            return default;
        }

        protected async Task<DiscussChannel> RatingGetParentFieldNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _rating_get_parent_field_name(self):
            // return 'livechat_channel_id'
            */
            return default;
        }

        protected async Task<DiscussChannel> RtcCancelInvitationsInternalAsync(List<Guid> member_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _rtc_cancel_invitations(self, member_ids=None):
            // """ Cancels the invitations of the RTC call from all invited members,
            //     if member_ids is provided, only the invitations of the specified members are canceled.
            // 
            //     :param list member_ids: list of the members ids from which the invitation has to be removed
            // """
            // self.ensure_one()
            // channel_member_domain = Domain([
            //     ('channel_id', '=', self.id),
            //     ('rtc_inviting_session_id', '!=', False),
            // ])
            // if member_ids:
            //     channel_member_domain &= Domain('id', 'in', member_ids)
            // members = self.env['discuss.channel.member'].search(channel_member_domain)
            // members.rtc_inviting_session_id = False
            // if members:
            //     Store(bus_channel=self).add(
            //         self,
            //         {
            //             "invited_member_ids": Store.Many(
            //                 members,
            //                 [
            //                     Store.One("channel_id", [], as_thread=True),
            //                     *self.env["discuss.channel.member"]._to_store_persona("avatar_card"),
            //                 ],
            //                 mode="DELETE",
            //             ),
            //         },
            //     ).bus_send()
            //     devices, private_key, public_key = self._web_push_get_partners_parameters(members.partner_id.ids)
            //     if devices:
            //         self._web_push_send_notification(devices, private_key, public_key, payload={
            //             "title": "",
            //             "options": {
            //                 "data": {
            //                     "type": PUSH_NOTIFICATION_TYPE.CANCEL
            //                 },
            //                 "tag": self._get_call_notification_tag(),
            //             }
            //         })
            */
            return default;
        }

        protected async Task<DiscussChannel> SearchChannelPartnerIdsInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _search_channel_partner_ids(self, operator, operand):
            // return [('channel_member_ids', 'any', [('partner_id', operator, operand)])]
            */
            return default;
        }

        protected async Task<DiscussChannel> SearchIsMemberInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _search_is_member(self, operator, operand):
            // if operator != 'in':
            //     return NotImplemented
            // # Separate query to fetch candidate channels because the sub-select that _search would
            // # generate leads psql query plan to take bad decisions. When candidate ids are explicitly
            // # given it doesn't need to make (incorrect) guess, at the cost of one extra but fast query.
            // # It is expected to return hundreds of channels, a thousand at most, which is acceptable.
            // # A "join" would be ideal, but the ORM is currently not able to generate it from the domain.
            // current_partner, current_guest = self.env["res.partner"]._get_current_persona()
            // if current_guest:
            //     # sudo: discuss.channel - sudo for performance, just checking existence
            //     channels = current_guest.sudo().channel_ids
            // elif current_partner:
            //     # sudo: discuss.channel - sudo for performance, just checking existence
            //     channels = current_partner.sudo().channel_ids
            // else:
            //     channels = self.env["discuss.channel"]
            // return [('id', 'in', channels.ids)]
            */
            return default;
        }

        protected async Task<DiscussChannel> SearchLivechatAgentHistoryIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _search_livechat_agent_history_ids(self, operator, value):
            // if operator not in ("any", "in"):
            //     return NotImplemented
            // if operator == "in" and len(value) == 1 and not next(iter(value)):
            //     return [
            //         (
            //             "id",
            //             "not in",
            //             self.env["im_livechat.channel.member.history"]
            //             ._search([("livechat_member_type", "=", "agent")])
            //             .subselect("channel_id"),
            //         ),
            //     ]
            // query = (
            //     self.env["im_livechat.channel.member.history"]._search(value)
            //     if isinstance(value, fields.Domain)
            //     else value
            // )
            // agent_history_query = self.env["im_livechat.channel.member.history"]._search(
            //     [
            //         ("livechat_member_type", "=", "agent"),
            //         ("id", "in", query),
            //     ],
            // )
            // return [("id", "in", agent_history_query.subselect("channel_id"))]
            */
            return default;
        }

        protected async Task<DiscussChannel> SearchLivechatBotHistoryIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _search_livechat_bot_history_ids(self, operator, value):
            // if operator != "in":
            //     return NotImplemented
            // bot_history_query = self.env["im_livechat.channel.member.history"]._search(
            //     [
            //         ("livechat_member_type", "=", "bot"),
            //         ("id", "in", value),
            //     ],
            // )
            // return [("id", "in", bot_history_query.subselect("channel_id"))]
            */
            return default;
        }

        protected async Task<DiscussChannel> SearchLivechatCustomerHistoryIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _search_livechat_customer_history_ids(self, operator, value):
            // if operator != "in":
            //     return NotImplemented
            // customer_history_query = self.env["im_livechat.channel.member.history"]._search(
            //     [
            //         ("livechat_member_type", "=", "visitor"),
            //         ("id", "in", value),
            //     ],
            // )
            // return [("id", "in", customer_history_query.subselect("channel_id"))]
            */
            return default;
        }

        protected async Task<DiscussChannel> SearchLivechatMatchesSelfExpertiseInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _search_livechat_matches_self_expertise(self, operator, value):
            // if operator != "in" or value not in ({True}, {False}):
            //     return NotImplemented
            // operator = "in" if value == {True} else "not in"
            // return [("livechat_expertise_ids", operator, self.env.user.livechat_expertise_ids.ids)]
            */
            return default;
        }

        protected async Task<DiscussChannel> SearchLivechatMatchesSelfLangInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _search_livechat_matches_self_lang(self, operator, value):
            // if operator != "in" or value not in ({True}, {False}):
            //     return NotImplemented
            // operator = "in" if value == {True} else "not in"
            // lang_codes = self.env.user.livechat_lang_ids.mapped("code")
            // lang_codes.append(self.env.user.lang)
            // return [("livechat_lang_id.code", operator, lang_codes)]
            */
            return default;
        }

        public async Task<DiscussChannel> SetMessagePinAsync(DiscussChannelSetMessagePinRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def set_message_pin(self, message_id, pinned):
            // """ (Un)pin a message on the channel and send a notification to the
            // members.
            // :param message_id: id of the message to be pinned.
            // :param pinned: whether the message should be pinned or unpinned.
            // """
            // self.ensure_one()
            // message_to_update = self.env['mail.message'].search([
            //     ['id', '=', message_id],
            //     ['model', '=', 'discuss.channel'],
            //     ['res_id', '=', self.id],
            //     ['pinned_at', '=' if pinned else '!=', False]
            // ])
            // if not message_to_update:
            //     return
            // message_to_update.flush_recordset(['pinned_at'])
            // # Use SQL because by calling write method, write_date is going to be updated, but we don't want pin/unpin
            // # a message changes the write_date
            // self.env.cr.execute("UPDATE mail_message SET pinned_at=%s WHERE id=%s",
            //                     (fields.Datetime.now() if pinned else None, message_to_update.id))
            // message_to_update.invalidate_recordset(['pinned_at'])
            // 
            // Store(bus_channel=self).add(message_to_update, "pinned_at").bus_send()
            // if pinned:
            //     notification_text = '''
            //         <div data-oe-type="pin" class="o_mail_notification">
            //             %(user_pinned_a_message_to_this_channel)s
            //             <a href="#" data-oe-type="pin-menu">%(see_all_pins)s</a>
            //         </div>
            //     '''
            //     notification = Markup(notification_text) % {
            //         'user_pinned_a_message_to_this_channel': Markup('<a href="#" data-oe-type="highlight" data-oe-id="%s">%s</a>') % (
            //             message_id,
            //             _('%(user_name)s pinned a message to this channel.', user_name=self.self_member_id._get_html_link_title()),
            //         ),
            //         'see_all_pins': _('See all pinned messages.'),
            //     }
            //     self.message_post(body=notification, message_type="notification", subtype_xmlid="mail.mt_comment")
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<DiscussChannel> ShouldInviteMembersToJoinCallInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: discuss_channel.py) ---
            // def _should_invite_members_to_join_call(self):
            // if self.calendar_event_ids:
            //     return False
            // return super()._should_invite_members_to_join_call()
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _should_invite_members_to_join_call(self):
            // self.ensure_one()
            // return len(self.rtc_session_ids) == 1 and self.channel_type != "channel"
            */
            return default;
        }

        protected async Task<DiscussChannel> StoreLivechatOperatorIdFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _store_livechat_operator_id_fields(self):
            // """Return the standard fields to include in Store for livechat_operator_id."""
            // return ["avatar_128", *self.env["res.partner"]._get_store_livechat_username_fields()]
            */
            return default;
        }

        protected async Task<DiscussChannel> SubscribeUsersAutomaticallyGetMembersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: discuss_channel.py) ---
            // def _subscribe_users_automatically_get_members(self):
            // """ Auto-subscribe members of a department to a channel """
            // new_members = super()._subscribe_users_automatically_get_members()
            // for channel in self:
            //     new_members[channel.id] = list(
            //         set(new_members[channel.id]) |
            //         set((channel.subscription_department_ids.member_ids.user_id.partner_id.filtered(lambda p: p.active) - channel.channel_partner_ids).ids)
            //     )
            // return new_members
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _subscribe_users_automatically_get_members(self):
            // """ Return new members per channel ID """
            // return dict(
            //     (channel.id,
            //      ((channel.group_ids.all_user_ids.partner_id.filtered(lambda p: p.active) - channel.channel_partner_ids).ids))
            //         for channel in self
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannel> SubscribeUsersAutomaticallyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _subscribe_users_automatically(self):
            // if not (new_members_to_create := self._subscribe_users_automatically_get_members()):
            //     return
            // to_create = [
            //     {"channel_id": channel_id, "partner_id": partner_id}
            //     for channel_id in new_members_to_create
            //     for partner_id in new_members_to_create[channel_id]
            // ]
            // # sudo: discuss.channel.member - adding member of other users based on channel auto-subscribe
            // new_members = self.env["discuss.channel.member"].sudo().create(to_create)
            // notifications = defaultdict(lambda: self.env["discuss.channel.member"])
            // for member in new_members:
            //     bus_channel = member._bus_channel()
            //     notifications[bus_channel] |= member
            // for bus_channel, members in notifications.items():
            //     members = members.with_prefetch(new_members.ids)
            //     Store(bus_channel=bus_channel).add(members.channel_id).add(
            //         members,
            //         [
            //             Store.One("channel_id", [], as_thread=True),
            //             *self.env["discuss.channel.member"]._to_store_persona(),
            //             "unpin_dt",
            //         ],
            //     ).bus_send()
            */
            return default;
        }

        protected async Task<DiscussChannel> SyncFieldNamesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _sync_field_names(self):
            // field_names = super()._sync_field_names()
            // field_names[None].append(
            //     Store.One(
            //         "livechat_operator_id",
            //         self.env["discuss.channel"]._store_livechat_operator_id_fields(),
            //         predicate=is_livechat_channel,
            //     ),
            // )
            // field_names["internal_users"].extend(
            //     [
            //         Store.Attr("description", predicate=is_livechat_channel),
            //         Store.Attr("livechat_note", predicate=is_livechat_channel),
            //         Store.Attr("livechat_status", predicate=is_livechat_channel),
            //         Store.Many("livechat_expertise_ids", ["name"], predicate=is_livechat_channel),
            //         # sudo: internal users having access to the channel can read its tags
            //         Store.Many(
            //             "livechat_conversation_tag_ids",
            //             ["name", "color"],
            //             predicate=is_livechat_channel,
            //             sudo=True,
            //         ),
            //     ],
            // )
            // return field_names
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _sync_field_names(self):
            // # keys are bus subchannel names, values are lists of field names to sync
            // res = defaultdict(list)
            // res[None] += [
            //     Store.Attr("avatar_cache_key", predicate=is_channel_or_group),
            //     "channel_type",
            //     "create_uid",
            //     "default_display_mode",
            //     Store.Attr("description", predicate=is_channel_or_group),
            //     Store.Many("group_ids", [], predicate=is_channel),
            //     Store.One("group_public_id", predicate=is_channel),
            //     "last_interest_dt",
            //     "member_count",
            //     "name",
            //     "uuid",
            // ]
            // return res
            */
            return default;
        }

        protected async Task<DiscussChannel> ToStoreDefaultsInternalAsync(object target)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _to_store_defaults(self, target: Store.Target):
            // fields = [
            //     "chatbot_current_step",
            //     Store.One("country_id", ["code", "name"], predicate=is_livechat_channel),
            //     Store.Attr("livechat_end_dt", predicate=is_livechat_channel),
            //     # sudo - res.partner: accessing livechat operator is allowed
            //     Store.One(
            //         "livechat_operator_id",
            //         self.env["discuss.channel"]._store_livechat_operator_id_fields(),
            //         predicate=is_livechat_channel,
            //         sudo=True,
            //     ),
            // ]
            // if target.is_internal(self.env):
            //     fields.append(
            //         Store.One(
            //             "livechat_channel_id", ["name"], predicate=is_livechat_channel, sudo=True
            //         )
            //     )
            //     fields.extend(
            //         [
            //             Store.Attr("description", predicate=is_livechat_channel),
            //             Store.Attr("livechat_note", predicate=is_livechat_channel),
            //             Store.Attr("livechat_outcome", predicate=is_livechat_channel),
            //             Store.Attr("livechat_status", predicate=is_livechat_channel),
            //             Store.Many("livechat_expertise_ids", ["name"], predicate=is_livechat_channel),
            //             # sudo: internal users having access to the channel can read its tags
            //             Store.Many(
            //                 "livechat_conversation_tag_ids",
            //                 ["name", "color"],
            //                 predicate=is_livechat_channel,
            //                 sudo=True,
            //             ),
            //         ],
            //     )
            // return super()._to_store_defaults(target) + fields
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _to_store_defaults(self, target: Store.Target):
            // # As the method uses partial recordsets with filtered (that lose the prefetch ids) it is
            // # best to prefetch these computed fields once to avoid doing partial queries multiple times,
            // # especially because these 2 fields are used in ACL too.
            // self.fetch(["is_member", "self_member_id"])
            // # Avoid sending potentially a lot of members for big channels: exclude chat and other small
            // # channels from this optimization because they are assumed to be smaller and it's important
            // # to know the member list for them.
            // channels_with_all_members = self.filtered(
            //     lambda channel: channel.channel_type not in self._lazy_load_members_channel_types(),
            // )
            // all_members = (
            //     self.self_member_id
            //     | self.invited_member_ids
            //     # sudo: discuss.channel - reading sessions of accessible channel is acceptable
            //     | self.sudo().rtc_session_ids.channel_member_id
            //     | channels_with_all_members.channel_member_ids
            //     | self.channel_name_member_ids
            // )
            // # Prefetch all members at once. The first field accessed on a member will be channel_id
            // # (in _to_store_defaults of livechat), but the field is known for some of the members
            // # (through inverse of channels_with_all_members.channel_member_ids), so the ORM will only
            // # prefetch all fields for members with unknown channel_id. The following line force a
            // # single fetch for all fields of all members.
            // all_members.mapped("create_date")  # any field in table will do except channel_id
            // # prefetch in batch, including nested relations (member, guest, ...)
            // Store(bus_channel=target.channel, bus_subchannel=target.subchannel).add(all_members)
            // # sudo: bus.bus: reading non-sensitive last id
            // bus_last_id = self.env["bus.bus"].sudo()._bus_last_id()
            // res = [
            //     Store.Attr("avatar_cache_key", predicate=is_channel_or_group),
            //     "channel_type",
            //     "create_uid",
            //     Store.Many(
            //         "channel_member_ids",
            //         only_data=True,
            //         sort="id",
            //         predicate=lambda channel: channel in channels_with_all_members,
            //     ),
            //     "default_display_mode",
            //     Store.Attr("description", predicate=is_channel_or_group),
            //     Store.One("from_message_id", predicate=is_channel_or_group),
            //     Store.Many("group_ids", [], predicate=is_channel, sudo=True),  # sudo: we are reading only the ids (comodel is inaccessible)
            //     Store.One("group_public_id", ["full_name"], predicate=is_channel),
            //     Store.Many(
            //         "invited_member_ids",
            //         [
            //             Store.One("channel_id", [], as_thread=True),
            //             *self.env["discuss.channel.member"]._to_store_persona("avatar_card"),
            //         ],
            //         mode="ADD",
            //     ),
            //     "last_interest_dt",
            //     "member_count",
            //     "name",
            //     Store.Many(
            //         "channel_name_member_ids",
            //         sort="id",
            //         predicate=lambda c: c.channel_type in self._member_based_naming_channel_types(),
            //     ),
            //     Store.One("parent_channel_id", predicate=is_channel_or_group),
            //     # sudo: discuss.channel: reading sessions of accessible channel is acceptable
            //     Store.Many(
            //         "rtc_session_ids",
            //         mode="ADD",
            //         extra_fields=self.sudo().rtc_session_ids._get_store_extra_fields(),
            //         sudo=True,
            //     ),
            //     "uuid",
            // ]
            // if target.is_current_user(self.env):
            //     res = res + [
            //         {"fetchChannelInfoState": "fetched"},
            //         "is_editable",
            //         "message_needaction_counter",
            //         {"message_needaction_counter_bus_id": bus_last_id},
            //         Store.One(
            //             "self_member_id",
            //             extra_fields=[
            //                 "custom_channel_name",
            //                 "custom_notifications",
            //                 "last_interest_dt",
            //                 "message_unread_counter",
            //                 {"message_unread_counter_bus_id": bus_last_id},
            //                 "mute_until_dt",
            //                 "new_message_separator",
            //                 # sudo: discuss.channel.rtc.session - each member can see who is inviting them
            //                 Store.One("rtc_inviting_session_id", sudo=True),
            //                 "unpin_dt",
            //             ],
            //             only_data=True,
            //         ),
            //     ]
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: discuss_channel.py) ---
            // def _to_store_defaults(self, target):
            // return super()._to_store_defaults(target) + [
            //     Store.One(
            //         "livechat_visitor_id",
            //         [
            //             Store.One("country_id", ["code"]),
            //             "display_name",
            //             "page_visit_history",
            //             Store.One("lang_id", ["name"]),
            //             Store.One("partner_id", [Store.One("country_id", ["code"])]),
            //             Store.One("website_id", ["name"]),
            //         ],
            //         predicate=lambda channel: channel.channel_type == "livechat"
            //         and self.livechat_visitor_id.has_access("read"),
            //     ),
            //     # sudo: discuss.channel - visitor can access to the channel member history of
            //     # an accessible channel when computing requested_by_operator
            //     Store.Attr(
            //         "requested_by_operator",
            //         lambda channel: channel.create_uid
            //         in channel.sudo().livechat_agent_history_ids.partner_id.user_ids,
            //         predicate=is_livechat_channel,
            //     ),
            // ]
            */
            return default;
        }

        protected async Task<DiscussChannel> ToStoreInternalAsync(object store, object fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _to_store(self, store: Store, fields):
            // """Extends the channel header by adding the livechat operator and the 'anonymous' profile"""
            // super()._to_store(store, [f for f in fields if f != "chatbot_current_step"])
            // if "chatbot_current_step" not in fields:
            //     return
            // lang = self.env["chatbot.script"]._get_chatbot_language()
            // for channel in self.filtered(lambda channel: channel.chatbot_current_step_id):
            //     # sudo: chatbot.script.step - returning the current script/step of the channel
            //     current_step_sudo = channel.chatbot_current_step_id.sudo().with_context(lang=lang)
            //     chatbot_script = current_step_sudo.chatbot_script_id
            //     step_message = self.env["chatbot.message"]
            //     if not current_step_sudo.is_forward_operator:
            //         step_message = channel.sudo().chatbot_message_ids.filtered(
            //             lambda m: m.script_step_id == current_step_sudo
            //             and m.mail_message_id.author_id == chatbot_script.operator_partner_id
            //         )[:1]
            //     current_step = {
            //         "scriptStep": current_step_sudo.id,
            //         "message": step_message.mail_message_id.id,
            //         "operatorFound": current_step_sudo.is_forward_operator
            //         and channel.livechat_operator_id != chatbot_script.operator_partner_id,
            //     }
            //     store.add(current_step_sudo)
            //     store.add(chatbot_script)
            //     chatbot_data = {
            //         "script": chatbot_script.id,
            //         "steps": [current_step],
            //         "currentStep": current_step,
            //     }
            //     store.add(channel, {"chatbot": chatbot_data})
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _to_store(self, store: Store, fields):
            // store.add_records_fields(self, fields)
            */
            return default;
        }

        protected async Task<DiscussChannel> TypesAllowingSeenInfosInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _types_allowing_seen_infos(self):
            // return super()._types_allowing_seen_infos() + ["livechat"]
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _types_allowing_seen_infos(self):
            // """ Return the channel types which allow sending seen infos notification
            // on the channel """
            // return ["chat", "group"]
            */
            return default;
        }

        protected async Task<DiscussChannel> TypesAllowingUnfollowInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _types_allowing_unfollow(self):
            // return super()._types_allowing_unfollow() + ["livechat"]
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _types_allowing_unfollow(self):
            // """ Return the channel types which allow leaving the channel, channel will be unpinned
            // otherwise """
            // return ["channel", "group"]
            */
            return default;
        }

        public async Task<DiscussChannel> UnfollowAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def action_unfollow(self):
            // self._action_unfollow(self.env.user.partner_id)
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<DiscussChannel> UnlinkExceptAllEmployeeChannelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _unlink_except_all_employee_channel(self):
            // # Delete discuss.channel
            // try:
            //     all_emp_group = self.env.ref('mail.channel_all_employees')
            // except ValueError:
            //     all_emp_group = None
            // if all_emp_group and all_emp_group in self:
            //     raise UserError(_('You cannot delete those groups, as the Whole Company group is required by other modules.'))
            // for channel in self:
            //     channel._bus_send("discuss.channel/delete", {"id": channel.id})
            */
            return default;
        }

        protected async Task<DiscussChannel> UpdateForwardedChannelDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _update_forwarded_channel_data(self, /, *, livechat_failure, livechat_operator_id, operator_name):
            // self.write(
            //     {
            //         "livechat_failure": livechat_failure,
            //         "livechat_operator_id": livechat_operator_id,
            //         "name": " ".join(
            //             [
            //                 self.env.user.display_name
            //                 if not self.env.user._is_public()
            //                 else self.sudo().self_member_id.guest_id.name,
            //                 operator_name
            //             ]
            //         )
            //     }
            // )
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<DiscussChannel> input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: discuss_channel.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // if vals.get('subscription_department_ids'):
            //     self._subscribe_users_automatically()
            // return res
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def write(self, vals):
            // if "livechat_status" not in vals and "livechat_expertise_ids" not in vals:
            //     return super().write(vals)
            // need_help_before = self.filtered(lambda c: c.livechat_status == "need_help")
            // result = super().write(vals)
            // need_help_after = self.filtered(lambda c: c.livechat_status == "need_help")
            // group_livechat_user = self.env.ref("im_livechat.im_livechat_group_user")
            // store = Store(bus_channel=group_livechat_user, bus_subchannel="LOOKING_FOR_HELP")
            // added_need_help = need_help_after - need_help_before
            // removed_need_help = need_help_before - need_help_after
            // store.add(added_need_help)
            // store.add(removed_need_help, ["livechat_status"])
            // if "livechat_expertise_ids" in vals:
            //     store.add(self, Store.Many("livechat_expertise_ids"))
            // if added_need_help or removed_need_help:
            //     group_livechat_user._bus_send(
            //         "im_livechat.looking_for_help/update",
            //         {
            //             "added_channel_ids": added_need_help.ids,
            //             "removed_channel_ids": removed_need_help.ids,
            //         },
            //         subchannel="LOOKING_FOR_HELP",
            //     )
            // store.bus_send()
            // return result
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def write(self, vals):
            // if 'channel_type' in vals:
            //     failing_channels = self.filtered(lambda channel: channel.channel_type != vals.get('channel_type'))
            //     if failing_channels:
            //         raise UserError(_('Cannot change the channel type of: %(channel_names)s', channel_names=', '.join(failing_channels.mapped('name'))))
            // if {"from_message_id", "parent_channel_id"} & set(vals):
            //     raise UserError(
            //         _(
            //             "Cannot change initial message nor parent channel of: %(channels)s.",
            //             channels=self.mapped("name"),
            //         )
            //     )
            // if "group_public_id" in vals:
            //     if failing_channels := self.filtered(lambda channel: channel.parent_channel_id):
            //         raise UserError(
            //             self.env._(
            //                 "Cannot change authorized group of sub-channel: %(channels)s.",
            //                 channels=failing_channels.mapped("name"),
            //             )
            //         )
            // 
            // def get_field_name(field_description):
            //     if isinstance(field_description, Store.Attr):
            //         return field_description.field_name
            //     return field_description
            // 
            // def get_field_value(channel, field_description):
            //     if isinstance(field_description, Store.Attr):
            //         if field_description.predicate and not field_description.predicate(channel):
            //             return None
            //     if isinstance(field_description, Store.Relation):
            //         return field_description._get_value(channel).records
            //     if isinstance(field_description, Store.Attr):
            //         return field_description._get_value(channel)
            //     return channel[field_description]
            // 
            // def get_vals(channel):
            //     return {
            //         subchannel: {
            //             get_field_name(field_description): (
            //                 get_field_value(channel, field_description),
            //                 field_description,
            //             )
            //             for field_description in field_descriptions
            //         }
            //         for subchannel, field_descriptions in self._sync_field_names().items()
            //     }
            // 
            // old_vals = {channel: get_vals(channel) for channel in self}
            // result = super().write(vals)
            // for channel in self:
            //     new_subchannel_vals = get_vals(channel)
            //     for subchannel, values in new_subchannel_vals.items():
            //         diff = []
            //         for field_name, (value, field_description) in values.items():
            //             if value != old_vals[channel][subchannel][field_name][0]:
            //                 diff.append(field_description)
            //         if diff:
            //             Store(
            //                 bus_channel=channel,
            //                 bus_subchannel=subchannel,
            //             ).add(channel, diff).bus_send()
            // if vals.get('group_ids'):
            //     self._subscribe_users_automatically()
            // return result
            */
            return await base.WriteAsync(input);
        }
    }
}