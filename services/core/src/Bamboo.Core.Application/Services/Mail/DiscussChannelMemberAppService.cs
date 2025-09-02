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
    public class DiscussChannelMemberAppService : GenericApplicationService<DiscussChannelMember>, IDiscussChannelMemberAppService
    {
        private readonly IBusListenerMixinAppService _busListenerMixinAppService;
        public DiscussChannelMemberAppService(IRepository<DiscussChannelMember, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IBusListenerMixinAppService busListenerMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _busListenerMixinAppService = busListenerMixinAppService;
        }

        protected async Task<DiscussChannelMember> BusChannelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _bus_channel(self):
            // return (self.partner_id or self.guest_id)._bus_channel()
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ChannelFoldInternalAsync(object state, object state_count)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _channel_fold(self, state, state_count):
            // """Update the fold_state of the given member. The change will be
            // broadcasted to the member channel.
            // 
            // :param state: the new status of the session for the current member.
            // """
            // self.ensure_one()
            // if self.fold_state == state:
            //     return
            // self.fold_state = state
            // self._bus_send(
            //     "discuss.Thread/fold_state",
            //     {
            //         "fold_state": self.fold_state,
            //         "foldStateCount": state_count,
            //         "id": self.channel_id.id,
            //         "model": "discuss.channel",
            //     },
            // )
            */
            return default;
        }

        protected async Task<DiscussChannelMember> CleanupExpiredMutesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _cleanup_expired_mutes(self):
            // """
            // Cron job for cleanup expired unmute by resetting mute_until_dt and sending bus notifications.
            // """
            // members = self.search([("mute_until_dt", "<=", fields.Datetime.now())])
            // members.write({"mute_until_dt": False})
            // members._notify_mute()
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _compute_display_name(self):
            // for member in self:
            //     member.display_name = _(
            //         "“%(member_name)s” in “%(channel_name)s”",
            //         member_name=member.partner_id.name or member.guest_id.name,
            //         channel_name=member.channel_id.display_name,
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ComputeIsPinnedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _compute_is_pinned(self):
            // for member in self:
            //     member.is_pinned = (
            //         not member.unpin_dt
            //         or (
            //             member.last_interest_dt
            //             and member.last_interest_dt >= member.unpin_dt
            //         )
            //         or (
            //             member.channel_id.last_interest_dt
            //             and member.channel_id.last_interest_dt >= member.unpin_dt
            //         )
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ComputeIsSelfInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _compute_is_self(self):
            // if not self:
            //     return
            // current_partner, current_guest = self.env["res.partner"]._get_current_persona()
            // self.is_self = False
            // for member in self:
            //     if current_partner and member.partner_id == current_partner:
            //         member.is_self = True
            //     if current_guest and member.guest_id == current_guest:
            //         member.is_self = True
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ComputeMessageUnreadInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _compute_message_unread(self):
            // if self.ids:
            //     self.env['mail.message'].flush_model()
            //     self.flush_recordset(['channel_id', 'new_message_separator'])
            //     self.env.cr.execute("""
            //              SELECT count(mail_message.id) AS count,
            //                     discuss_channel_member.id
            //                FROM mail_message
            //          INNER JOIN discuss_channel_member
            //                  ON discuss_channel_member.channel_id = mail_message.res_id
            //               WHERE mail_message.model = 'discuss.channel'
            //                 AND mail_message.message_type NOT IN ('notification', 'user_notification')
            //                 AND mail_message.id >= discuss_channel_member.new_message_separator
            //                 AND discuss_channel_member.id IN %(ids)s
            //            GROUP BY discuss_channel_member.id
            //     """, {'ids': tuple(self.ids)})
            //     unread_counter_by_member = {res['id']: res['count'] for res in self.env.cr.dictfetchall()}
            //     for member in self:
            //         member.message_unread_counter = unread_counter_by_member.get(member.id)
            // else:
            //     self.message_unread_counter = 0
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ContrainsNoPublicMemberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _contrains_no_public_member(self):
            // for member in self:
            //     if any(user._is_public() for user in member.partner_id.user_ids):
            //         raise ValidationError(_("Channel members cannot include public users."))
            */
            return default;
        }

        protected async Task<DiscussChannelMember> GcUnpinLivechatSessionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py) ---
            // def _gc_unpin_livechat_sessions(self):
            // """ Unpin read livechat sessions with no activity for at least one day to
            //     clean the operator's interface """
            // members = self.env['discuss.channel.member'].search([
            //     ('is_pinned', '=', True),
            //     ('last_seen_dt', '<=', datetime.now() - timedelta(days=1)),
            //     ('channel_id.channel_type', '=', 'livechat'),
            // ])
            // sessions_to_be_unpinned = members.filtered(lambda m: m.message_unread_counter == 0)
            // sessions_to_be_unpinned.write({'unpin_dt': fields.Datetime.now()})
            // for member in sessions_to_be_unpinned:
            //     member._bus_send("discuss.channel/unpin", {"id": member.channel_id.id})
            */
            return default;
        }

        protected async Task<DiscussChannelMember> GcUnpinOutdatedSubChannelsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _gc_unpin_outdated_sub_channels(self):
            // outdated_dt = fields.Datetime.now() - timedelta(days=2)
            // domain = expression.AND(
            //     [
            //         [
            //             ("channel_id.parent_channel_id", "!=", False),
            //             ("last_interest_dt", "<", outdated_dt),
            //         ],
            //         expression.OR(
            //             [
            //                 [("channel_id.last_interest_dt", "=", False)],
            //                 [("channel_id.last_interest_dt", "<", outdated_dt)],
            //             ]
            //         ),
            //     ]
            // )
            // members = self.env["discuss.channel.member"].search(domain)
            // members.unpin_dt = fields.Datetime.now()
            // for member in members:
            //     member._bus_send("discuss.channel/unpin", {"id": member.channel_id.id})
            */
            return default;
        }

        protected async Task<DiscussChannelMember> GetHtmlLinkInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _get_html_link(self, *args, for_persona=False, **kwargs):
            // if not for_persona:
            //     return self._get_html_link(*args, **kwargs)
            // if self.partner_id:
            //     return self.partner_id._get_html_link(title=f"@{self.partner_id.name}")
            // return Markup("<strong>%s</strong>") % self.guest_id.name
            */
            return default;
        }

        protected async Task<DiscussChannelMember> GetRtcInviteMembersDomainInternalAsync(List<Guid> member_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py) ---
            // def _get_rtc_invite_members_domain(self, *a, **kw):
            // domain = super()._get_rtc_invite_members_domain(*a, **kw)
            // chatbot = self.channel_id.chatbot_current_step_id.chatbot_script_id
            // if self.channel_id.channel_type == "livechat" and chatbot:
            //     domain = expression.AND(
            //         [
            //             domain,
            //             [("partner_id", "!=", chatbot.operator_partner_id.id)],
            //         ]
            //     )
            // return domain
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _get_rtc_invite_members_domain(self, member_ids=None):
            // """ Get the domain used to get the members to invite to and RTC call on
            // the member's channel.
            // 
            // :param list member_ids: List of the partner ids to invite.
            // """
            // self.ensure_one()
            // domain = [
            //     ('channel_id', '=', self.channel_id.id),
            //     ('rtc_inviting_session_id', '=', False),
            //     ('rtc_session_ids', '=', False),
            // ]
            // if member_ids:
            //     domain = expression.AND([domain, [('id', 'in', member_ids)]])
            // return domain
            */
            return default;
        }

        protected async Task<DiscussChannelMember> GetRtcServerInfoInternalAsync(object rtc_session, object ice_servers, object key)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _get_rtc_server_info(self, rtc_session, ice_servers=None, key=None):
            // sfu_channel_uuid = self.channel_id.sfu_channel_uuid
            // sfu_server_url = self.channel_id.sfu_server_url
            // if not sfu_channel_uuid or not sfu_server_url:
            //     return None
            // if not key:
            //     key = self.env["ir.config_parameter"].sudo().get_param("mail.sfu_local_key")
            // claims = {
            //     "session_id": rtc_session.id,
            //     "ice_servers": ice_servers,
            // }
            // json_web_token = jwt.sign(claims, key=key, ttl=60 * 60 * 8, algorithm=jwt.Algorithm.HS256)  # 8 hours
            // return {"url": sfu_server_url, "channelUUID": sfu_channel_uuid, "jsonWebToken": json_web_token}
            */
            return default;
        }

        protected async Task<DiscussChannelMember> GetStorePartnerFieldsInternalAsync(object fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py) ---
            // def _get_store_partner_fields(self, fields):
            // self.ensure_one()
            // if self.channel_id.channel_type == 'livechat':
            //     return ["active", "avatar_128", "country", "is_public", "user_livechat_username"]
            // return super()._get_store_partner_fields(fields)
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _get_store_partner_fields(self, fields):
            // self.ensure_one()
            // return fields
            */
            return default;
        }

        public async Task<DiscussChannelMember> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def init(self):
            // self.env.cr.execute("CREATE UNIQUE INDEX IF NOT EXISTS discuss_channel_member_partner_unique ON %s (channel_id, partner_id) WHERE partner_id IS NOT NULL" % self._table)
            // self.env.cr.execute("CREATE UNIQUE INDEX IF NOT EXISTS discuss_channel_member_guest_unique ON %s (channel_id, guest_id) WHERE guest_id IS NOT NULL" % self._table)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<DiscussChannelMember> JoinSfuInternalAsync(object ice_servers)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _join_sfu(self, ice_servers=None):
            // if len(self.channel_id.rtc_session_ids) < SFU_MODE_THRESHOLD:
            //     if self.channel_id.sfu_channel_uuid:
            //         self.channel_id.sfu_channel_uuid = None
            //         self.channel_id.sfu_server_url = None
            //     return
            // elif self.channel_id.sfu_channel_uuid and self.channel_id.sfu_server_url:
            //     return
            // sfu_server_url = discuss.get_sfu_url(self.env)
            // if not sfu_server_url:
            //     return
            // sfu_local_key = self.env["ir.config_parameter"].sudo().get_param("mail.sfu_local_key")
            // if not sfu_local_key:
            //     sfu_local_key = str(uuid.uuid4())
            //     self.env["ir.config_parameter"].sudo().set_param("mail.sfu_local_key", sfu_local_key)
            // json_web_token = jwt.sign(
            //     {"iss": f"{self.get_base_url()}:channel:{self.channel_id.id}", "key": sfu_local_key},
            //     key=discuss.get_sfu_key(self.env),
            //     ttl=30,
            //     algorithm=jwt.Algorithm.HS256,
            // )
            // try:
            //     response = requests.get(
            //         sfu_server_url + "/v1/channel",
            //         headers={"Authorization": "jwt " + json_web_token},
            //         timeout=3,
            //     )
            //     response.raise_for_status()
            // except requests.exceptions.RequestException as error:
            //     _logger.warning("Failed to obtain a channel from the SFU server, user will stay in p2p: %s", error)
            //     return
            // response_dict = response.json()
            // self.channel_id.sfu_channel_uuid = response_dict["uuid"]
            // self.channel_id.sfu_server_url = response_dict["url"]
            // for session in self.channel_id.rtc_session_ids:
            //     session._bus_send(
            //         "discuss.channel.rtc.session/sfu_hot_swap",
            //         {"serverInfo": self._get_rtc_server_info(session, ice_servers, key=sfu_local_key)},
            //     )
            */
            return default;
        }

        protected async Task<DiscussChannelMember> MarkAsReadInternalAsync(Guid last_message_id, object sync)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _mark_as_read(self, last_message_id, sync=False):
            // """
            // Mark channel as read by updating the seen message id of the current
            // member as well as its new message separator.
            // 
            // :param last_message_id: the id of the message to be marked as read.
            // :param sync: wether the new message separator and the unread counter in
            //     the UX will sync to their server values.
            // """
            // self.ensure_one()
            // domain = [
            //     ("model", "=", "discuss.channel"),
            //     ("res_id", "=", self.channel_id.id),
            //     ("id", "<=", last_message_id),
            // ]
            // last_message = self.env['mail.message'].search(domain, order="id DESC", limit=1)
            // if not last_message:
            //     return
            // self._set_last_seen_message(last_message)
            // self._set_new_message_separator(last_message.id + 1, sync=sync)
            */
            return default;
        }

        protected async Task<DiscussChannelMember> NotifyMuteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _notify_mute(self):
            // for member in self:
            //     member._bus_send_store(member.channel_id, {"mute_until_dt": member.mute_until_dt})
            //     if member.mute_until_dt and member.mute_until_dt != -1:
            //         self.env.ref("mail.ir_cron_discuss_channel_member_unmute")._trigger(member.mute_until_dt)
            */
            return default;
        }

        protected async Task<DiscussChannelMember> NotifyTypingInternalAsync(object is_typing)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _notify_typing(self, is_typing):
            // """ Broadcast the typing notification to channel members
            //     :param is_typing: (boolean) tells whether the members are typing or not
            // """
            // for member in self:
            //     member.channel_id._bus_send_store(Store(member).add(member, {"isTyping": is_typing, "is_typing_dt": fields.Datetime.now()}))
            */
            return default;
        }

        protected async Task<DiscussChannelMember> RtcInviteMembersInternalAsync(List<Guid> member_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _rtc_invite_members(self, member_ids=None):
            // """ Sends invitations to join the RTC call to all connected members of the thread who are not already invited,
            //     if member_ids is set, only the specified ids will be invited.
            // 
            //     :param list member_ids: list of the partner ids to invite
            // """
            // self.ensure_one()
            // members = self.env["discuss.channel.member"].search(
            //     self._get_rtc_invite_members_domain(member_ids)
            // )
            // for member in members:
            //     member.rtc_inviting_session_id = self.rtc_session_ids.id
            //     member._bus_send_store(
            //         self.channel_id, {"rtcInvitingSession": Store.one(member.rtc_inviting_session_id, extra=True)}
            //     )
            // if members:
            //     self.channel_id._bus_send_store(
            //         self.channel_id,
            //         {
            //             "invitedMembers": Store.many(
            //                 members, "ADD", fields={"channel": [], "persona": ["name", "im_status"]}
            //             ),
            //         },
            //     )
            // return members
            */
            return default;
        }

        protected async Task<DiscussChannelMember> RtcJoinCallInternalAsync(object store, List<Guid> check_rtc_session_ids, object camera)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _rtc_join_call(self, store=None, check_rtc_session_ids=None, camera=False):
            // self.ensure_one()
            // check_rtc_session_ids = (check_rtc_session_ids or []) + self.rtc_session_ids.ids
            // self.channel_id._rtc_cancel_invitations(member_ids=self.ids)
            // self.rtc_session_ids.unlink()
            // rtc_session = self.env['discuss.channel.rtc.session'].create({'channel_member_id': self.id, 'is_camera_on': camera})
            // current_rtc_sessions, outdated_rtc_sessions = self._rtc_sync_sessions(check_rtc_session_ids=check_rtc_session_ids)
            // ice_servers = self.env["mail.ice.server"]._get_ice_servers()
            // self._join_sfu(ice_servers)
            // if store:
            //     store.add(self.channel_id, {"rtcSessions": Store.many(current_rtc_sessions, "ADD")})
            //     store.add(
            //         self.channel_id,
            //         {"rtcSessions": Store.many(outdated_rtc_sessions, "DELETE", only_id=True)},
            //     )
            //     store.add(
            //         "Rtc",
            //         {
            //             "iceServers": ice_servers or False,
            //             "selfSession": Store.one(rtc_session),
            //             "serverInfo": self._get_rtc_server_info(rtc_session, ice_servers),
            //         },
            //     )
            // if len(self.channel_id.rtc_session_ids) == 1 and self.channel_id.channel_type != "channel":
            //     self.channel_id.message_post(body=_("%s started a live conference", self.partner_id.name or self.guest_id.name), message_type='notification')
            //     self._rtc_invite_members()
            */
            return default;
        }

        protected async Task<DiscussChannelMember> RtcLeaveCallInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _rtc_leave_call(self):
            // self.ensure_one()
            // if self.rtc_session_ids:
            //     self.rtc_session_ids.unlink()
            // else:
            //     self.channel_id._rtc_cancel_invitations(member_ids=self.ids)
            */
            return default;
        }

        protected async Task<DiscussChannelMember> RtcSyncSessionsInternalAsync(List<Guid> check_rtc_session_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _rtc_sync_sessions(self, check_rtc_session_ids=None):
            // """Synchronize the RTC sessions for self channel member.
            //     - Inactive sessions of the channel are deleted.
            //     - Current sessions are returned.
            //     - Sessions given in check_rtc_session_ids that no longer exists
            //       are returned as non-existing.
            //     :param list check_rtc_session_ids: list of the ids of the sessions to check
            //     :returns tuple: (current_rtc_sessions, outdated_rtc_sessions)
            // """
            // self.ensure_one()
            // self.channel_id.rtc_session_ids._delete_inactive_rtc_sessions()
            // check_rtc_sessions = self.env['discuss.channel.rtc.session'].browse([int(check_rtc_session_id) for check_rtc_session_id in (check_rtc_session_ids or [])])
            // return self.channel_id.rtc_session_ids, check_rtc_sessions - self.channel_id.rtc_session_ids
            */
            return default;
        }

        protected async Task<DiscussChannelMember> SearchIsPinnedInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _search_is_pinned(self, operator, operand):
            // if (operator == "=" and operand) or (operator == "!=" and not operand):
            //     return expression.OR([
            //         [("unpin_dt", "=", False)],
            //         [("last_interest_dt", ">=", self._field_to_sql(self._table, "unpin_dt"))],
            //         [("channel_id.last_interest_dt", ">=", self._field_to_sql(self._table, "unpin_dt"))],
            //     ])
            // else:
            //     return [
            //         ("unpin_dt", "!=", False),
            //         ("last_interest_dt", "<", self._field_to_sql(self._table, "unpin_dt")),
            //         ("channel_id.last_interest_dt", "<", self._field_to_sql(self._table, "unpin_dt")),
            //     ]
            */
            return default;
        }

        protected async Task<DiscussChannelMember> SearchIsSelfInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _search_is_self(self, operator, operand):
            // is_in = (operator == "=" and operand) or (operator == "!=" and not operand)
            // current_partner, current_guest = self.env["res.partner"]._get_current_persona()
            // if is_in:
            //     return [
            //         '|',
            //         ("partner_id", "=", current_partner.id) if current_partner else expression.FALSE_LEAF,
            //         ("guest_id", "=", current_guest.id) if current_guest else expression.FALSE_LEAF,
            //     ]
            // else:
            //     return [
            //         ("partner_id", "!=", current_partner.id) if current_partner else expression.TRUE_LEAF,
            //         ("guest_id", "!=", current_guest.id) if current_guest else expression.TRUE_LEAF,
            //     ]
            */
            return default;
        }

        public async Task<DiscussChannelMember> SetCustomNotificationsAsync(Guid id, DiscussChannelMemberSetCustomNotificationsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def set_custom_notifications(self, custom_notifications):
            // self.ensure_one()
            // self.custom_notifications = custom_notifications
            // self._bus_send_store(self.channel_id, {"custom_notifications": self.custom_notifications})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<DiscussChannelMember> SetLastSeenMessageInternalAsync(object message, object notify)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _set_last_seen_message(self, message, notify=True):
            // """
            // Set the last seen message of the current member.
            // 
            // :param message: the message to set as last seen message.
            // :param notify: whether to send a bus notification relative to the new
            //     last seen message.
            // """
            // self.ensure_one()
            // if self.seen_message_id.id >= message.id:
            //     return
            // self.fetched_message_id = max(self.fetched_message_id.id, message.id)
            // self.seen_message_id = message.id
            // self.last_seen_dt = fields.Datetime.now()
            // if not notify:
            //     return
            // target = self
            // if self.channel_id.channel_type in self.channel_id._types_allowing_seen_infos():
            //     target = self.channel_id
            // target._bus_send_store(
            //     self, fields={"channel": [], "persona": ["name"], "seen_message_id": True}
            // )
            */
            return default;
        }

        protected async Task<DiscussChannelMember> SetNewMessageSeparatorInternalAsync(Guid message_id, object sync)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _set_new_message_separator(self, message_id, sync=False):
            // """
            // :param message_id: id of the message above which the new message
            //     separator should be displayed.
            // :param sync: whether the new message separator and the unread counter
            //     in the UX will sync to their server values.
            // 
            // """
            // self.ensure_one()
            // if message_id == self.new_message_separator:
            //     return
            // self.new_message_separator = message_id
            // self._bus_send_store(
            //     Store(
            //         self,
            //         fields={
            //             "channel": [],
            //             "message_unread_counter": True,
            //             "new_message_separator": True,
            //             "persona": ["name"],
            //         },
            //     ).add(self, {"syncUnread": sync})
            // )
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ToStoreInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py) ---
            // def _to_store(self, store: Store, **kwargs):
            // super()._to_store(store, **kwargs)
            // for member in self.filtered(lambda m: m.channel_id.channel_type == "livechat"):
            //     # sudo: discuss.channel - reading livechat channel to check whether current member is a bot is allowed
            //     store.add(
            //         member,
            //         {
            //             "is_bot": member.partner_id
            //             in member.channel_id.sudo().livechat_channel_id.rule_ids.chatbot_script_id.operator_partner_id,
            //         },
            //     )
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _to_store(self, store: Store, /, *, fields=None, extra_fields=None):
            // if fields is None:
            //     fields = {
            //         "channel": [],
            //         "create_date": True,
            //         "fetched_message_id": True,
            //         "persona": None,
            //         "seen_message_id": True,
            //         "last_seen_dt": True,
            //     }
            // if extra_fields:
            //     fields.update(extra_fields)
            // bus_last_id = fields.pop("message_unread_counter_bus_id", None)
            // if "message_unread_counter" in fields and bus_last_id is None:
            //     # sudo: bus.bus: reading non-sensitive last id
            //     bus_last_id = self.env["bus.bus"].sudo()._bus_last_id()
            // for member in self:
            //     data = member._read_format(
            //         [
            //             field
            //             for field in fields
            //             if field not in ["channel", "fetched_message_id", "seen_message_id", "persona"]
            //         ],
            //         load=False,
            //     )[0]
            //     if "channel" in fields:
            //         data["thread"] = Store.one(member.channel_id, as_thread=True, only_id=True)
            //     if "persona" in fields:
            //         if member.partner_id:
            //             # sudo: res.partner - reading partner related to a member is considered acceptable
            //             data["persona"] = Store.one(
            //                 member.partner_id.sudo(),
            //                 fields=member._get_store_partner_fields(fields["persona"]),
            //             )
            //         if member.guest_id:
            //             # sudo: mail.guest - reading guest related to a member is considered acceptable
            //             data["persona"] = Store.one(member.guest_id.sudo(), fields=fields["persona"])
            //     if "fetched_message_id" in fields:
            //         data["fetched_message_id"] = Store.one(member.fetched_message_id, only_id=True)
            //     if "seen_message_id" in fields:
            //         data["seen_message_id"] = Store.one(member.seen_message_id, only_id=True)
            //     if "message_unread_counter" in fields:
            //         data["message_unread_counter_bus_id"] = bus_last_id
            //     store.add(member, data)
            */
            return default;
        }
    }
}