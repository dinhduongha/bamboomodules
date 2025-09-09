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
    public class DiscussChannelAppService : GenericApplicationService<DiscussChannel>, IDiscussChannelAppService
    {
        private readonly IBusListenerMixinAppService _busListenerMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IRatingMixinAppService _ratingMixinAppService;
        public DiscussChannelAppService(IRepository<DiscussChannel, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IBusListenerMixinAppService busListenerMixinAppService, IMailThreadAppService mailThreadAppService, IRatingMixinAppService ratingMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _busListenerMixinAppService = busListenerMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _ratingMixinAppService = ratingMixinAppService;
        }

        protected async Task<DiscussChannel> ActionUnfollowInternalAsync(object partner, object guest)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _action_unfollow(self, partner=None, guest=None):
            // self.ensure_one()
            // self.message_unsubscribe(partner.ids)
            // custom_store = Store(self, {"is_pinned": False, "isLocallyPinned": False})
            // member = self.env["discuss.channel.member"].search(
            //     [
            //         ("channel_id", "=", self.id),
            //         ("partner_id", "=", partner.id) if partner else ("guest_id", "=", guest.id),
            //     ]
            // )
            // if not member:
            //     target = partner or guest
            //     target._bus_send_store(custom_store, notification_type="discuss.channel/leave")
            //     return
            // notification = Markup('<div class="o_mail_notification">%s</div>') % _(
            //     "left the channel"
            // )
            // # sudo: mail.message - post as sudo since the user just unsubscribed from the channel
            // member.channel_id.sudo().message_post(
            //     body=notification, subtype_xmlid="mail.mt_comment", author_id=partner.id
            // )
            // # send custom store after message_post to avoid is_pinned reset to True
            // member._bus_send_store(custom_store, notification_type="discuss.channel/leave")
            // member.unlink()
            // self._bus_send_store(
            //     self,
            //     {
            //         "channelMembers": Store.many(member, "DELETE", only_id=True),
            //         "memberCount": self.member_count,
            //     },
            // )
            */
            return default;
        }

        public async Task<DiscussChannel> AddMembersAsync(Guid id, DiscussChannelAddMembersRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def add_members(self, partner_ids=None, guest_ids=None, invite_to_rtc_call=False, open_chat_window=False, post_joined_message=True):
            // """ Adds the given partner_ids and guest_ids as member of self channels. """
            // return self._add_members(
            //     partners=self.env["res.partner"].browse(partner_ids or []).exists(),
            //     guests=self.env["mail.guest"].browse(guest_ids or []).exists(),
            //     invite_to_rtc_call=invite_to_rtc_call,
            //     open_chat_window=open_chat_window,
            //     post_joined_message=post_joined_message,
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<DiscussChannel> AddMembersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _add_members(
            //     self,
            //     *,
            //     guests=None,
            //     partners=None,
            //     users=None,
            //     invite_to_rtc_call=False,
            //     open_chat_window=False,
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
            //         existing_members = self.env['discuss.channel.member'].search(expression.AND([
            //             [('channel_id', '=', channel.id)],
            //             expression.OR([
            //                 [('partner_id', 'in', partners.ids)],
            //                 [('guest_id', 'in', guests.ids)]
            //             ])
            //         ]))
            //         members_to_create += [{
            //             'partner_id': partner.id,
            //             'channel_id': channel.id,
            //         } for partner in partners - existing_members.partner_id]
            //         members_to_create += [{
            //             'guest_id': guest.id,
            //             'channel_id': channel.id,
            //         } for guest in guests - existing_members.guest_id]
            //         new_members = self.env['discuss.channel.member'].create(members_to_create)
            //         all_new_members += new_members
            //         for member in new_members:
            //             payload = {
            //                 "channel": {
            //                     **member.channel_id._channel_basic_info(),
            //                     "model": "discuss.channel",
            //                     "is_pinned": True,
            //                 },
            //                 "open_chat_window": open_chat_window,
            //             }
            //             if not member.is_self and not self.env.user._is_public():
            //                 payload["invited_by_user_id"] = self.env.user.id
            //             member._bus_send("discuss.channel/joined", payload)
            //             if post_joined_message:
            //                 notification = (
            //                     _("joined the channel")
            //                     if member.is_self
            //                     else _("invited %s to the channel", member._get_html_link(for_persona=True))
            //                 )
            //                 member.channel_id.message_post(
            //                     author_id=inviting_partner.id or None,
            //                     body=Markup('<div class="o_mail_notification">%s</div>') % notification,
            //                     message_type="notification",
            //                     subtype_xmlid="mail.mt_comment",
            //                 )
            //         if new_members:
            //             channel._bus_send_store(
            //                 Store(channel, {"memberCount": channel.member_count}).add(new_members)
            //             )
            //         if existing_members and (current_partner or current_guest):
            //             # If the current user invited these members but they are already present, notify the current user about their existence as well.
            //             # In particular this fixes issues where the current user is not aware of its own member in the following case:
            //             # create channel from form view, and then join from discuss without refreshing the page.
            //             (current_partner or current_guest)._bus_send_store(
            //                 Store(channel, {"memberCount": channel.member_count}).add(existing_members)
            //             )
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

        protected async Task<DiscussChannel> BroadcastInternalAsync(List<Guid> partner_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _broadcast(self, partner_ids):
            // """ Broadcast the current channel header to the given partner ids
            //     :param partner_ids : the partner to notify
            // """
            // for partner in self.env['res.partner'].browse(partner_ids):
            //     user_id = partner.user_ids and partner.user_ids[0] or False
            //     if user_id:
            //         user_channels = self.with_user(user_id).with_context(
            //             # sudo: res.company - context is required by ir.rules
            //             allowed_company_ids=user_id.sudo().company_ids.ids
            //         )
            //         partner._bus_send_store(user_channels)
            */
            return default;
        }

        protected async Task<DiscussChannel> ChannelBasicInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _channel_basic_info(self):
            // self.ensure_one()
            // data = self._read_format(
            //     [
            //         "allow_public_upload",
            //         "channel_type",
            //         "create_uid",
            //         "description",
            //         "last_interest_dt",
            //         "name",
            //         "uuid",
            //     ],
            //     load=False,
            // )[0]
            // data["authorizedGroupFullName"] = self.group_public_id.full_name
            // data["avatarCacheKey"] = self.avatar_cache_key
            // data["defaultDisplayMode"] = self.default_display_mode
            // data["group_based_subscription"] = bool(self.group_ids)
            // data["memberCount"] = self.member_count
            // return data
            */
            return default;
        }

        public async Task<DiscussChannel> ChannelChangeDescriptionAsync(Guid id, DiscussChannelChannelChangeDescriptionRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def channel_change_description(self, description):
            // self.ensure_one()
            // self.write({'description': description})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DiscussChannel> ChannelCreateAsync(Guid id, DiscussChannelChannelCreateRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def channel_create(self, name, group_id):
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
            // self.env.user._bus_send_store(new_channel)
            // return new_channel
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DiscussChannel> ChannelFetchedAsync(Guid id)
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DiscussChannel> ChannelGetAsync(Guid id, DiscussChannelChannelGetRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def channel_get(self, partners_to, pin=True, force_open=False):
            // """ Get the canonical private channel between some partners, create it if needed.
            //     To reuse an old channel (conversation), this one must be private, and contains
            //     only the given partners.
            //     :param partners_to : list of res.partner ids to add to the conversation
            //     :param pin : True if getting the channel should pin it for the current user
            //     :param force_open : True if getting the channel should open it for the current user
            //     :returns: channel_info of the created or existing channel
            //     :rtype: dict
            // """
            // if self.env.user.partner_id.id not in partners_to:
            //     partners_to.append(self.env.user.partner_id.id)
            // if len(partners_to) > 2:
            //     raise UserError(_("A chat should not be created with more than 2 persons. Create a group instead."))
            // # determine type according to the number of partner in the channel
            // self.flush_model()
            // self.env['discuss.channel.member'].flush_model()
            // self.env.cr.execute("""
            //     SELECT M.channel_id
            //     FROM discuss_channel C, discuss_channel_member M
            //     WHERE M.channel_id = C.id
            //         AND M.partner_id IN %s
            //         AND C.channel_type LIKE 'chat'
            //         AND NOT EXISTS (
            //             SELECT 1
            //             FROM discuss_channel_member M2
            //             WHERE M2.channel_id = C.id
            //                 AND M2.partner_id NOT IN %s
            //         )
            //     GROUP BY M.channel_id
            //     HAVING ARRAY_AGG(DISTINCT M.partner_id ORDER BY M.partner_id) = %s
            //     LIMIT 1
            // """, (tuple(partners_to), tuple(partners_to), sorted(list(partners_to)),))
            // result = self.env.cr.dictfetchall()
            // if result:
            //     # get the existing channel between the given partners
            //     channel = self.browse(result[0].get('channel_id'))
            //     # pin or open the channel for the current partner
            //     if pin or force_open:
            //         member = self.env['discuss.channel.member'].search([('partner_id', '=', self.env.user.partner_id.id), ('channel_id', '=', channel.id)])
            //         vals = {'last_interest_dt': fields.Datetime.now()}
            //         if pin:
            //             vals['unpin_dt'] = False
            //         if force_open:
            //             vals['fold_state'] = "open"
            //         member.write(vals)
            //     channel._broadcast(self.env.user.partner_id.ids)
            // else:
            //     # create a new one
            //     channel = self.create({
            //         'channel_member_ids': [
            //             Command.create({
            //                 'partner_id': partner_id,
            //                 # only pin for the current user, so the chat does not show up for the correspondent until a message has been sent
            //                 # manually set the last_interest_dt to make sure that it works well with the default last_interest_dt (datetime.now())
            //                 'unpin_dt': False if partner_id == self.env.user.partner_id.id else fields.Datetime.now(),
            //                 'last_interest_dt': fields.Datetime.now() if partner_id == self.env.user.partner_id.id else fields.Datetime.now() - timedelta(seconds=30),
            //             }) for partner_id in partners_to
            //         ],
            //         'channel_type': 'chat',
            //         'name': ', '.join(self.env['res.partner'].browse(partners_to).mapped('name')),
            //     })
            //     channel._broadcast(partners_to)
            // return channel
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DiscussChannel> ChannelJoinAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def channel_join(self):
            // """Shortcut to add the current user as member of self channels.
            // Prefer calling add_members() directly when possible.
            // """
            // self.add_members(self.env.user.partner_id.ids)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DiscussChannel> ChannelPinAsync(Guid id, DiscussChannelChannelPinRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def channel_pin(self, pinned=False):
            // self.ensure_one()
            // member = self.env['discuss.channel.member'].search(
            //     [('partner_id', '=', self.env.user.partner_id.id), ('channel_id', '=', self.id), ('is_pinned', '!=', pinned)])
            // if member:
            //     member.write({'unpin_dt': False if pinned else fields.Datetime.now()})
            // if not pinned:
            //     self.env.user._bus_send("discuss.channel/unpin", {"id": self.id})
            // else:
            //     self.env.user._bus_send_store(self)
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
            // if self.livechat_active and not self.message_ids:
            //     self.sudo().unlink()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DiscussChannel> ChannelRenameAsync(Guid id, DiscussChannelChannelRenameRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def channel_rename(self, name):
            // self.ensure_one()
            // self.write({'name': name})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DiscussChannel> ChannelSetCustomNameAsync(Guid id, DiscussChannelChannelSetCustomNameRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def channel_set_custom_name(self, name):
            // self.ensure_one()
            // member = self.env['discuss.channel.member'].search([('partner_id', '=', self.env.user.partner_id.id), ('channel_id', '=', self.id)])
            // member.write({'custom_channel_name': name})
            // member._bus_send_store(self, {"custom_channel_name": name})
            */
            var entity = await Repository.GetAsync(id); return entity;
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
            // return self.with_context(mail_create_nosubscribe=True).sudo().message_post(
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
            // self.sudo().livechat_active = True
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
            // """ We don't call super in this override as we want to ignore the
            // mail.thread behavior completely """
            // if not message.message_type == 'comment':
            //     raise UserError(_("Only messages type comment can have their content updated on model 'discuss.channel'"))
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
            // if self.livechat_active:
            //     member = self.channel_member_ids.filtered(lambda m: m.is_self)
            //     if member:
            //         member.fold_state = "closed"
            //         # sudo: discuss.channel.rtc.session - member of current user can leave call
            //         member.sudo()._rtc_leave_call()
            //     # sudo: discuss.channel - visitor left the conversation, state must be updated
            //     self.sudo().livechat_active = False
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

        protected async Task<DiscussChannel> ComputeDurationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _compute_duration(self):
            // for record in self:
            //     start = record.message_ids[-1].date if record.message_ids else record.create_date
            //     end = record.message_ids[0].date if record.message_ids else fields.Datetime.now()
            //     record.duration = (end - start).total_seconds() / 3600
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeGroupPublicIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _compute_group_public_id(self):
            // channels = self.filtered(lambda channel: channel.channel_type == 'channel')
            // channels.filtered(
            //     lambda channel: not channel.parent_channel_id and not channel.group_public_id
            // ).group_public_id = self.env.ref("base.group_user")
            // (self - channels).group_public_id = None
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
            // if not self:
            //     return
            // members = self.env['discuss.channel.member'].search([('channel_id', 'in', self.ids), ('is_self', '=', True)])
            // is_member_channels = members.channel_id
            // for channel in self:
            //     channel.is_member = channel in is_member_channels
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

        protected async Task<DiscussChannel> ConstraintFromMessageIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _constraint_from_message_id(self):
            // # sudo: discuss.channel - skipping ACL for constraint, more performant and no sensitive information is leaked
            // if failing_channels := self.sudo().filtered(
            //     lambda c: c.from_message_id
            //     and (
            //         c.from_message_id.res_id != c.parent_channel_id.id
            //         or c.from_message_id.model != "discuss.channel"
            //     )
            // ):
            //     raise ValidationError(
            //         _(
            //             "Cannot create %(channels)s: initial message should belong to parent channel.",
            //             channels=format_list(self.env, failing_channels.mapped("name")),
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
            //         or c.parent_channel_id.channel_type != "channel"
            //     )
            // ):
            //     raise ValidationError(
            //         _(
            //             "Cannot create %(channels)s: parent should not be a sub-channel and should be of type 'channel'.",
            //             channels=format_list(self.env, failing_channels.mapped("name")),
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

        public async Task<DiscussChannel> CreateGroupAsync(Guid id, DiscussChannelCreateGroupRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def create_group(self, partners_to, default_display_mode=False, name=''):
            // """ Creates a group channel.
            // 
            //     :param partners_to : list of res.partner ids to add to the conversation
            //     :param str default_display_mode: how the channel will be displayed by default
            //     :param str name: group name. default name is computed client side from the list of members if no name is set
            //     :returns: channel_info of the created channel
            //     :rtype: dict
            // """
            // partners_to = set(partners_to)
            // channel = self.create({
            //     'channel_member_ids': [Command.create({'partner_id': partner_id}) for partner_id in partners_to],
            //     'channel_type': 'group',
            //     'default_display_mode': default_display_mode,
            //     'name': name,
            // })
            // channel._broadcast(channel.channel_member_ids.partner_id.ids)
            // return channel
            */
            var entity = await Repository.GetAsync(id); return entity;
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
            // sub_channel = self.create(
            //     {
            //         "channel_type": "channel",
            //         "from_message_id": message.id,
            //         "name": name or (message.body.striptags()[:30] if message.body else _("New Thread")),
            //         "parent_channel_id": self.id,
            //     }
            // )
            // sub_channel.add_members(partner_ids=(self.env.user.partner_id | message.author_id).ids, post_joined_message=False)
            // notification = (
            //     Markup('<div class="o_mail_notification">%s</div>')
            //     % _(
            //         "%(user)s started a thread: %(goto)s%(thread_name)s%(goto_end)s. %(goto_all)sSee all threads%(goto_all_end)s."
            //     )
            // ) % {
            //     "user": self.env.user.display_name,
            //     "goto": Markup(
            //         "<a href='#' class='o_channel_redirect' data-oe-id='%s' data-oe-model='discuss.channel'>"
            //     )
            //     % sub_channel.id,
            //     "goto_end": Markup("</a>"),
            //     "goto_all": Markup("<a href='#' data-oe-type='sub-channels-menu'>"),
            //     "goto_all_end": Markup("</a>"),
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
            // render_context = {
            //     "company": company,
            //     "channel": self,
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

        public async Task<DiscussChannel> ExecuteCommandHelpAsync(Guid id)
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
            var entity = await Repository.GetAsync(id); return entity;
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
            //     "%(new_line)sType %(bold_start)s:shortcut%(bold_end)s to insert a canned response in your message.",
            //     bold_start=Markup("<b>"),
            //     bold_end=Markup("</b>"),
            //     new_line=Markup("<br>"),
            // )
            // return msg
            */
            return default;
        }

        public async Task<DiscussChannel> ExecuteCommandHistoryAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def execute_command_history(self, **kwargs):
            // self._bus_send("im_livechat.history_command", {"id": self.id})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DiscussChannel> ExecuteCommandLeadAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_livechat, FILE: discuss_channel.py) ---
            // def execute_command_lead(self, **kwargs):
            // key = kwargs['body']
            // lead_command = "/lead"
            // if key.strip() == lead_command:
            //     msg = _(
            //         "Create a new lead: "
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DiscussChannel> ExecuteCommandLeaveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def execute_command_leave(self, **kwargs):
            // if self.channel_type in ('channel', 'group'):
            //     self.action_unfollow()
            // else:
            //     self.channel_pin(False)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<DiscussChannel> ExecuteCommandWhoAsync(Guid id)
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
            var entity = await Repository.GetAsync(id); return entity;
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
            //     return self.add_members(partner_ids=self.env.user.partner_id.ids)
            // guest = self.env["mail.guest"]._get_guest_from_context()
            // if guest:
            //     return self.add_members(guest_ids=guest.ids)
            // return self.env["discuss.channel.member"]
            */
            return default;
        }

        protected async Task<DiscussChannel> FindOrCreatePersonaForChannelInternalAsync(object guest_name, object timezone, object country_code, object post_joined_message)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _find_or_create_persona_for_channel(self, guest_name, timezone, country_code, post_joined_message=True):
            // """
            // :param channel: channel to add the persona to
            // :param guest_name: name of the persona
            // :param post_joined_message: whether to post a message to the channel
            //     to notify that the persona joined
            // :return tuple(partner, guest):
            // """
            // self.ensure_one()
            // guest = self.env["mail.guest"]
            // member = self.env["discuss.channel.member"].search([("channel_id", "=", self.id), ("is_self", "=", True)])
            // if member:
            //     return member.partner_id, member.guest_id
            // if not self.env.user._is_public():
            //     self.add_members([self.env.user.partner_id.id], post_joined_message=post_joined_message)
            // else:
            //     guest = self.env["mail.guest"]._get_guest_from_context()
            //     if not guest:
            //         guest = self.env["mail.guest"].create(
            //             {
            //                 "country_id": self.env["res.country"].search([("code", "=", country_code)]).id,
            //                 "lang": get_lang(self.env).code,
            //                 "name": guest_name,
            //                 "timezone": timezone,
            //             }
            //         ).sudo(False)
            //         guest._set_auth_cookie()
            //         self = self.with_context(guest=guest)
            //     self.add_members(guest_ids=guest.ids, post_joined_message=post_joined_message)
            // return self.env.user.partner_id if not guest else self.env["res.partner"], guest
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

        protected async Task<DiscussChannel> GetAllowedMessagePostParamsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_allowed_message_post_params(self):
            // return super()._get_allowed_message_post_params() | {"special_mentions", "parent_id"}
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
            // return Markup('').join(
            //     Markup('%s: %s<br/>') % (message.author_id.name or self.anonymous_name, html2plaintext(message.body))
            //     for message in self.message_ids.sorted('id')
            // )
            */
            return default;
        }

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

        protected async Task<DiscussChannel> GetLastMessagesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _get_last_messages(self):
            // """ Return the last message for each of the given channels."""
            // if not self:
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

        public async Task<DiscussChannel> GetMentionSuggestionsAsync(Guid id, DiscussChannelGetMentionSuggestionsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def get_mention_suggestions(self, search, limit=8):
            // """ Return 'limit'-first channels' id, name, channel_type and authorizedGroupFullName fields such that the
            //     name matches a 'search' string. Exclude channels of type chat (DM) and group.
            // """
            // domain = expression.AND([
            //                 [('name', 'ilike', search)],
            //                 [('channel_type', '=', 'channel')],
            //                 [('channel_partner_ids', 'in', [self.env.user.partner_id.id])]
            //             ])
            // channels = self.search(domain, limit=limit)
            // return [{
            //     'authorizedGroupFullName': channel.group_public_id.full_name,
            //     'channel_type': channel.channel_type,
            //     'model': "discuss.channel",
            //     'id': channel.id,
            //     'name': channel.name,
            //     'parent_channel_id': {
            //         'id': channel.parent_channel_id.id,
            //         'model': 'discuss.channel'
            //     } if channel.parent_channel_id else False,
            // } for channel in channels]
            */
            var entity = await Repository.GetAsync(id); return entity;
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

        protected async Task<DiscussChannel> GetVisitorHistoryInternalAsync(object visitor)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: discuss_channel.py) ---
            // def _get_visitor_history(self, visitor):
            // """
            // Prepare history string to render it in the visitor info div on discuss livechat channel view.
            // :param visitor: website.visitor of the channel
            // :return: arrow separated string containing navigation history information
            // """
            // recent_history = self.env['website.track'].search([('page_id', '!=', False), ('visitor_id', '=', visitor.id)], limit=3)
            // return ' → '.join(visit.page_id.name + ' (' + visit.visit_datetime.strftime('%H:%M') + ')' for visit in reversed(recent_history))
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

        public async Task<DiscussChannel> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def init(self):
            // self._cr.execute('SELECT indexname FROM pg_indexes WHERE indexname = %s', ('discuss_channel_member_seen_message_id_idx',))
            // if not self._cr.fetchone():
            //     self._cr.execute('CREATE INDEX discuss_channel_member_seen_message_id_idx ON discuss_channel_member (channel_id,partner_id,seen_message_id)')
            */
            var entity = await Repository.GetAsync(id); return entity;
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

        protected async Task<DiscussChannel> LoadMoreMembersInternalAsync(List<Guid> known_member_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _load_more_members(self, known_member_ids):
            // self.ensure_one()
            // unknown_members = self.env['discuss.channel.member'].search(
            //     domain=[('id', 'not in', known_member_ids), ('channel_id', '=', self.id)],
            //     limit=100
            // )
            // count = self.env['discuss.channel.member'].search_count(
            //     domain=[('channel_id', '=', self.id)],
            // )
            // return Store(unknown_members).add(self, {"memberCount": count}).get_result()
            */
            return default;
        }

        protected async Task<DiscussChannel> MessageComputeAuthorInternalAsync(Guid author_id, object email_from, object raise_on_email)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _message_compute_author(self, author_id=None, email_from=None, raise_on_email=True):
            // return super()._message_compute_author(author_id=author_id, email_from=email_from, raise_on_email=False)
            */
            return default;
        }

        protected async Task<DiscussChannel> MessageComputeParentIdInternalAsync(Guid parent_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _message_compute_parent_id(self, parent_id):
            // # super() unravels the chain of parents to set parent_id as the first
            // # ancestor. We don't want that in channel.
            // if not parent_id:
            //     return parent_id
            // return self.env['mail.message'].search(
            //     [('id', '=', parent_id),
            //      ('model', '=', self._name),
            //      ('res_id', '=', self.id)
            //     ]).id
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
            // if self.chatbot_current_step_id:
            //     selected_answer = (
            //         self.env["chatbot.script.answer"]
            //         .browse(self.env.context.get("selected_answer_id"))
            //         .exists()
            //     )
            //     if selected_answer in self.chatbot_current_step_id.answer_ids:
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
            //         if store := self.env.context.get("message_post_store"):
            //             store.add(message, for_current_user=True).add(question_msg.mail_message_id)
            // 
            //     self.env["chatbot.message"].sudo().create(
            //         {
            //             "mail_message_id": message.id,
            //             "discuss_channel_id": self.id,
            //             "script_step_id": self.chatbot_current_step_id.id,
            //         }
            //     )
            // 
            // return super()._message_post_after_hook(message, msg_vals)
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // """
            // Automatically set the message posted by the current user as seen for themselves.
            // """
            // if (current_channel_member := self.env["discuss.channel.member"].search([
            //     ("channel_id", "=", self.id), ("is_self", "=", True)
            // ])) and message.is_current_user_or_guest_author:
            //     current_channel_member._set_last_seen_message(message, notify=False)
            //     current_channel_member._set_new_message_separator(message.id + 1, sync=True)
            // return super()._message_post_after_hook(message, msg_vals)
            --- ODOO METHOD SOURCE (MODULE: mail_bot, FILE: discuss_channel.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // self.env["mail.bot"]._apply_logic(self, msg_vals)
            // return super()._message_post_after_hook(message, msg_vals)
            */
            return default;
        }

        public async Task<DiscussChannel> MessagePostAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def message_post(self, *, message_type='notification', **kwargs):
            // if (not self.env.user or self.env.user._is_public()) and self.is_member:
            //     # sudo: discuss.channel - guests don't have access for creating mail.message
            //     self = self.sudo()
            // # sudo: discuss.channel - write to discuss.channel is not accessible for most users
            // self.sudo().last_interest_dt = fields.Datetime.now()
            // if "everyone" in kwargs.pop("special_mentions", []):
            //     kwargs["partner_ids"] = list(
            //         set(kwargs["partner_ids"] + self.channel_member_ids.partner_id.ids)
            //     )
            // # mail_post_autofollow=False is necessary to prevent adding followers
            // # when using mentions in channels. Followers should not be added to
            // # channels, and especially not automatically (because channel membership
            // # should be managed with discuss.channel.member instead).
            // # The current client code might be setting the key to True on sending
            // # message but it is only useful when targeting customers in chatter.
            // # This value should simply be set to False in channels no matter what.
            // return super(Channel, self.with_context(mail_create_nosubscribe=True, mail_post_autofollow=False)).message_post(message_type=message_type, **kwargs)
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<DiscussChannel> MessageReceiveBounceInternalAsync(object email, object partner)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _message_receive_bounce(self, email, partner):
            // """ Override bounce management to unsubscribe bouncing addresses """
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
            // """ Do not allow follower subscription on channels. Only members are
            // considered. """
            // raise UserError(_('Adding followers on channels is not possible. Consider adding members instead.'))
            */
            return default;
        }

        protected async Task<DiscussChannel> NotifyByWebPushPreparePayloadInternalAsync(object message, object msg_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _notify_by_web_push_prepare_payload(self, message, msg_vals=False):
            // payload = super()._notify_by_web_push_prepare_payload(message, msg_vals=msg_vals)
            // msg_vals = msg_vals or {}
            // payload['options']['data']['action'] = 'mail.action_discuss'
            // record_name = msg_vals.get('record_name') if msg_vals and 'record_name' in msg_vals else message.record_name
            // author_id = [msg_vals["author_id"]] if msg_vals and msg_vals.get("author_id") else message.author_id.ids
            // author = self.env["res.partner"].browse(author_id) or self.env["mail.guest"].browse(
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
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // """ All recipients of a message on a channel are considered as partners.
            // This means they will receive a minimal email, without a link to access
            // in the backend. Mailing lists should indeed send minimal emails to avoid
            // the noise. """
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
            // def _notify_get_recipients(self, message, msg_vals, **kwargs):
            // """ Override recipients computation as channel is not a standard
            // mail.thread document. Indeed there are no followers on a channel.
            // Instead of followers it has members that should be notified.
            // 
            // :param message: see ``MailThread._notify_get_recipients()``;
            // :param msg_vals: see ``MailThread._notify_get_recipients()``;
            // :param kwargs: see ``MailThread._notify_get_recipients()``;
            // 
            // :return recipients: structured data holding recipients data. See
            //   ``MailThread._notify_thread()`` for more details about its content
            //   and use;
            // """
            // # get values from msg_vals or from message if msg_vals doen't exists
            // message_type = msg_vals.get('message_type', 'comment') if msg_vals else message.message_type
            // pids = msg_vals.get('partner_ids', []) if msg_vals else message.partner_ids.ids
            // 
            // # notify only user input (comment, whatsapp messages or incoming / outgoing emails)
            // if message_type not in ('comment', 'email', 'email_outgoing', 'whatsapp_message'):
            //     return []
            // 
            // recipients_data = []
            // author_id = msg_vals.get("author_id") or message.author_id.id
            // if pids:
            //     email_from = tools.email_normalize(msg_vals.get('email_from') or message.email_from)
            //     self.env['res.partner'].flush_model(['active', 'email', 'partner_share'])
            //     self.env['res.users'].flush_model(['notification_type', 'partner_id'])
            //     sql_query = """
            //         SELECT DISTINCT ON (partner.id) partner.id,
            //                partner.lang,
            //                partner.partner_share,
            //                users.id as uid,
            //                COALESCE(users.notification_type, 'email') as notif,
            //                COALESCE(users.share, FALSE) as ushare
            //           FROM res_partner partner
            //      LEFT JOIN res_users users on partner.id = users.partner_id
            //          WHERE partner.active IS TRUE
            //                AND partner.email != %s
            //                AND partner.id = ANY(%s) AND partner.id != ANY(%s)"""
            //     self.env.cr.execute(
            //         sql_query,
            //         (email_from or '', list(pids), [author_id] if author_id else [], )
            //     )
            //     for partner_id, lang, partner_share, uid, notif, ushare in self._cr.fetchall():
            //         # ocn_client: will add partners to recipient recipient_data. more ocn notifications. We neeed to filter them maybe
            //         recipients_data.append({
            //             'active': True,
            //             'id': partner_id,
            //             'is_follower': False,
            //             'groups': [],
            //             'lang': lang,
            //             'notif': notif,
            //             'share': partner_share,
            //             'type': 'user' if not partner_share and notif else 'customer',
            //             'uid': uid,
            //             'ushare': ushare,
            //         })
            // 
            // domain = expression.AND([
            //     [("channel_id", "=", self.id)],
            //     [("partner_id", "!=", author_id)],
            //     [("partner_id.active", "=", True)],
            //     [("mute_until_dt", "=", False)],
            //     [("partner_id.user_ids.res_users_settings_ids.mute_until_dt", "=", False)],
            //     expression.OR([
            //         [("channel_id.channel_type", "!=", "channel")],
            //         expression.AND([
            //             [("channel_id.channel_type", "=", "channel")],
            //             expression.OR([
            //                 [("custom_notifications", "=", "all")],
            //                 expression.AND([
            //                     [("custom_notifications", "=", False)],
            //                     [("partner_id.user_ids.res_users_settings_ids.channel_notifications", "=", "all")],
            //                 ]),
            //                 expression.AND([
            //                     [("custom_notifications", "=", "mentions")],
            //                     [("partner_id", "in", pids)],
            //                 ]),
            //                 expression.AND([
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
            // payload = {"data": Store(message).get_result(), "id": self.id}
            // if temporary_id := self.env.context.get("temporary_id"):
            //     payload["temporary_id"] = temporary_id
            // if kwargs.get("silent"):
            //     payload["silent"] = True
            // self._bus_send_store(self, {"is_pinned": True}, subchannel="members")
            // self._bus_send("discuss.channel/new_message", payload)
            // return rdata
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
            // channel_member_domain = [
            //     ('channel_id', '=', self.id),
            //     ('rtc_inviting_session_id', '!=', False),
            // ]
            // if member_ids:
            //     channel_member_domain = expression.AND([channel_member_domain, [('id', 'in', member_ids)]])
            // members = self.env['discuss.channel.member'].search(channel_member_domain)
            // members.rtc_inviting_session_id = False
            // members._bus_send_store(self, {"rtcInvitingSession": False})
            // if members:
            //     self._bus_send_store(
            //         self,
            //         {
            //             "invitedMembers": Store.many(
            //                 members,
            //                 "DELETE",
            //                 fields={"channel": [], "persona": ["name", "im_status"]},
            //             ),
            //         },
            //     )
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
            // is_in = (operator == '=' and operand) or (operator == '!=' and not operand)
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
            // return [('id', "in" if is_in else "not in", channels.ids)]
            */
            return default;
        }

        public async Task<DiscussChannel> SetMessagePinAsync(Guid id, DiscussChannelSetMessagePinRequestDto input)
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
            // self._bus_send_store(message_to_update, {"pinned_at": message_to_update.pinned_at})
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
            //             _('%(user_name)s pinned a message to this channel.', user_name=self.env.user.display_name),
            //         ),
            //         'see_all_pins': _('See all pinned messages.'),
            //     }
            //     self.message_post(body=notification, message_type="notification", subtype_xmlid="mail.mt_comment")
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<DiscussChannel> SubscribeUsersAutomaticallyGetMembersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: discuss_channel.py) ---
            // def _subscribe_users_automatically_get_members(self):
            // """ Auto-subscribe members of a department to a channel """
            // new_members = super(Channel, self)._subscribe_users_automatically_get_members()
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
            //      ((channel.group_ids.users.partner_id.filtered(lambda p: p.active) - channel.channel_partner_ids).ids))
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
            // new_members = self._subscribe_users_automatically_get_members()
            // if new_members:
            //     to_create = [
            //         {'channel_id': channel_id, 'partner_id': partner_id}
            //         for channel_id in new_members
            //         for partner_id in new_members[channel_id]
            //     ]
            //     # sudo: discuss.channel.member - adding member of other users based on channel auto-subscribe
            //     self.env['discuss.channel.member'].sudo().create(to_create)
            // for channel in self:
            //     channel.group_ids._bus_send_store(
            //         channel, {**channel._channel_basic_info(), "is_pinned": True}
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannel> ToStoreInternalAsync(object store)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py) ---
            // def _to_store(self, store: Store):
            // """Extends the channel header by adding the livechat operator and the 'anonymous' profile"""
            // super()._to_store(store)
            // chatbot_lang = self.env["chatbot.script"]._get_chatbot_language()
            // for channel in self:
            //     channel_info = {}
            //     if channel.chatbot_current_step_id:
            //         # sudo: chatbot.script.step - returning the current script/step of the channel
            //         current_step_sudo = channel.chatbot_current_step_id.sudo().with_context(lang=chatbot_lang)
            //         chatbot_script = current_step_sudo.chatbot_script_id
            //         # sudo: channel - accessing chatbot messages to get the current step message
            //         step_message = next((
            //             m.mail_message_id for m in channel.sudo().chatbot_message_ids
            //             if m.script_step_id == current_step_sudo
            //             and m.mail_message_id.author_id == chatbot_script.operator_partner_id
            //         ), None) if channel.chatbot_current_step_id.sudo().step_type != 'forward_operator' else None
            //         current_step = {
            //             'scriptStep': current_step_sudo._format_for_frontend(),
            //             "message": Store.one_id(step_message),
            //             'operatorFound': current_step_sudo.step_type == 'forward_operator' and len(channel.channel_member_ids) > 2,
            //         }
            //         channel_info["chatbot"] = {
            //             'script': chatbot_script._format_for_frontend(),
            //             'steps': [current_step],
            //             'currentStep': current_step,
            //         }
            //     channel_info['anonymous_name'] = channel.anonymous_name
            //     channel_info['anonymous_country'] = {
            //         'code': channel.country_id.code,
            //         'id': channel.country_id.id,
            //         'name': channel.country_id.name,
            //     } if channel.country_id else False
            //     if channel.channel_type == "livechat":
            //         channel_info["operator"] = Store.one(
            //             channel.livechat_operator_id, fields=["avatar_128", "user_livechat_username"]
            //         )
            //     if channel.channel_type == "livechat":
            //         channel_info["livechat_active"] = channel.livechat_active
            //         if self.env.user._is_internal():
            //             channel_info["livechatChannel"] = Store.one(
            //                 channel.livechat_channel_id, fields=["name"]
            //             )
            //     store.add(channel, channel_info)
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def _to_store(self, store: Store):
            // """Adds channel data to the given store."""
            // if not self:
            //     return []
            // # sudo: bus.bus: reading non-sensitive last id
            // bus_last_id = self.env["bus.bus"].sudo()._bus_last_id()
            // current_partner, current_guest = self.env["res.partner"]._get_current_persona()
            // self.env['discuss.channel'].flush_model()
            // self.env['discuss.channel.member'].flush_model()
            // # Query instead of ORM for performance reasons: "LEFT JOIN" is more
            // # efficient than "id IN" for the cross-table condition between channel
            // # (for channel_type) and member (for other fields).
            // self.env.cr.execute("""
            //          SELECT discuss_channel_member.id
            //            FROM discuss_channel_member
            //       LEFT JOIN discuss_channel
            //              ON discuss_channel.id = discuss_channel_member.channel_id
            //             AND discuss_channel.channel_type != 'channel'
            //           WHERE discuss_channel_member.channel_id in %(channel_ids)s
            //             AND (
            //                 discuss_channel.id IS NOT NULL
            //              OR discuss_channel_member.rtc_inviting_session_id IS NOT NULL
            //              OR discuss_channel_member.partner_id = %(current_partner_id)s
            //              OR discuss_channel_member.guest_id = %(current_guest_id)s
            //             )
            //        ORDER BY discuss_channel_member.id ASC
            // """, {'channel_ids': tuple(self.ids), 'current_partner_id': current_partner.id or None, 'current_guest_id': current_guest.id or None})
            // all_needed_members = self.env['discuss.channel.member'].browse([m['id'] for m in self.env.cr.dictfetchall()])
            // Store(all_needed_members)  # prefetch in batch
            // members_by_channel = defaultdict(lambda: self.env['discuss.channel.member'])
            // invited_members_by_channel = defaultdict(lambda: self.env['discuss.channel.member'])
            // member_of_current_user_by_channel = defaultdict(lambda: self.env['discuss.channel.member'])
            // for member in all_needed_members:
            //     members_by_channel[member.channel_id] += member
            //     if member.rtc_inviting_session_id:
            //         invited_members_by_channel[member.channel_id] += member
            //     if (current_partner and member.partner_id == current_partner) or (current_guest and member.guest_id == current_guest):
            //         member_of_current_user_by_channel[member.channel_id] = member
            // for channel in self:
            //     member = member_of_current_user_by_channel.get(channel, self.env['discuss.channel.member']).with_prefetch([m.id for m in member_of_current_user_by_channel.values()])
            //     info = channel._channel_basic_info()
            //     info["is_editable"] = channel.is_editable
            //     info["fetchChannelInfoState"] = "fetched"
            //     info["parent_channel_id"] = Store.one(channel.parent_channel_id)
            //     info["from_message_id"] = Store.one(channel.from_message_id)
            //     info["group_public_id"] = channel.group_public_id.id or False
            //     # find the channel member state
            //     if current_partner or current_guest:
            //         info['message_needaction_counter'] = channel.message_needaction_counter
            //         info["message_needaction_counter_bus_id"] = bus_last_id
            //         if member:
            //             store.add(
            //                 member,
            //                 extra_fields={
            //                     "last_interest_dt": True,
            //                     "message_unread_counter": True,
            //                     "message_unread_counter_bus_id": bus_last_id,
            //                     "new_message_separator": True
            //                 },
            //             )
            //             info['state'] = member.fold_state or 'closed'
            //             info['custom_notifications'] = member.custom_notifications
            //             info['mute_until_dt'] = fields.Datetime.to_string(member.mute_until_dt)
            //             info['custom_channel_name'] = member.custom_channel_name
            //             info['is_pinned'] = member.is_pinned
            //             if member.rtc_inviting_session_id:
            //                 # sudo: discuss.channel.rtc.session - reading sessions of accessible channel is acceptable
            //                 info["rtcInvitingSession"] = Store.one(member.rtc_inviting_session_id.sudo())
            //     # add members info
            //     if channel.channel_type != 'channel':
            //         # avoid sending potentially a lot of members for big channels
            //         # exclude chat and other small channels from this optimization because they are
            //         # assumed to be smaller and it's important to know the member list for them
            //         store.add(members_by_channel[channel] - member)
            //     # add RTC sessions info
            //     invited_members = invited_members_by_channel[channel]
            //     info["invitedMembers"] = Store.many(
            //         invited_members, "ADD", fields={"channel": [], "persona": ["name", "im_status"]}
            //     )
            //     # sudo: discuss.channel.rtc.session - reading sessions of accessible channel is acceptable
            //     info["rtcSessions"] = Store.many(channel.sudo().rtc_session_ids, "ADD", extra=True)
            //     store.add(channel, info)
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: discuss_channel.py) ---
            // def _to_store(self, store: Store):
            // """
            // Override to add visitor information on the mail channel infos.
            // This will be used to display a banner with visitor informations
            // at the top of the livechat channel discussion view in discuss module.
            // """
            // super()._to_store(store)
            // for channel in self.filtered('livechat_visitor_id'):
            //     channel_info = {
            //         "requested_by_operator": channel.create_uid in channel.livechat_operator_id.user_ids
            //     }
            //     visitor = channel.livechat_visitor_id
            //     try:
            //         country_id = visitor.partner_id.country_id or visitor.country_id
            //         channel_info['visitor'] = {
            //             'name': visitor.partner_id.name or visitor.partner_id.display_name or visitor.display_name or _("Visitor #%(id)d.", id=visitor.id),
            //             'country': {'id': country_id.id, 'code': country_id.code.lower()} if country_id else False,
            //             'id': visitor.id,
            //             'is_connected': visitor.is_connected,
            //             'history': self.sudo()._get_visitor_history(visitor),
            //             'website_name': visitor.website_id.name,
            //             'lang_name': visitor.lang_id.name,
            //             'partner_id': visitor.partner_id.id,
            //             'type': "visitor",
            //         }
            //     except AccessError:
            //         pass
            //     store.add(channel, channel_info)
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

        public async Task<DiscussChannel> UnfollowAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py) ---
            // def action_unfollow(self):
            // self._action_unfollow(self.env.user.partner_id)
            */
            var entity = await Repository.GetAsync(id); return entity;
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

        public override async Task<List<object>> WriteAsync(List<Guid> ids, DiscussChannel entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: discuss_channel.py) ---
            // def write(self, vals):
            // res = super(Channel, self).write(vals)
            // if vals.get('subscription_department_ids'):
            //     self._subscribe_users_automatically()
            // return res
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
            //             channels=format_list(self.env, self.mapped("name")),
            //         )
            //     )
            // old_vals = {channel: channel._channel_basic_info() for channel in self}
            // result = super().write(vals)
            // for channel in self:
            //     info = channel._channel_basic_info()
            //     diff = {}
            //     for key, value in info.items():
            //         if value != old_vals[channel][key]:
            //             diff[key] = value
            //     if diff:
            //         channel._bus_send_store(channel, diff)
            // if vals.get('group_ids'):
            //     self._subscribe_users_automatically()
            // return result
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}