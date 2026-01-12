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
            // return self.partner_id.main_user_id or self.guest_id
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

        protected async Task<DiscussChannelMember> ComputeAgentExpertiseIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py) ---
            // def _compute_agent_expertise_ids(self):
            // for member in self:
            //     member.agent_expertise_ids = member.livechat_member_history_ids.agent_expertise_ids
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ComputeChatbotScriptIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py) ---
            // def _compute_chatbot_script_id(self):
            // for member in self:
            //     member.chatbot_script_id = member.livechat_member_history_ids.chatbot_script_id
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

        protected async Task<DiscussChannelMember> ComputeLivechatMemberTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py) ---
            // def _compute_livechat_member_type(self):
            // for member in self:
            //     member.livechat_member_type = member.livechat_member_history_ids.livechat_member_type
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

        public override async Task<DiscussChannelMember> CreateAsync(DiscussChannelMember entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py) ---
            // def create(self, vals_list):
            // members = super().create(vals_list)
            // guest = self.env["mail.guest"]._get_guest_from_context()
            // for member in members.filtered(
            //     lambda m: m.channel_id.channel_type == "livechat" and not m.livechat_member_type
            // ):
            //     # After login, the guest cookie is still available, allowing us to
            //     # reconcile the user with their previous guest member.
            //     if (
            //         guest
            //         and member.is_self
            //         and guest in member.channel_id.livechat_customer_guest_ids
            //     ):
            //         # sudo - discuss.channel.member: setting livechat member type
            //         # after member creation is allowed.
            //         member.sudo().livechat_member_type = "visitor"
            //         continue
            //     member.sudo().livechat_member_type = "agent"
            // return members
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def create(self, vals_list):
            // if self.env.context.get("mail_create_bypass_create_check") is self._bypass_create_check:
            //     self = self.sudo()
            // for vals in vals_list:
            //     if "channel_id" not in vals:
            //         raise UserError(
            //             _(
            //                 "It appears you're trying to create a channel member, but it seems like you forgot to specify the related channel. "
            //                 "To move forward, please make sure to provide the necessary channel information."
            //             )
            //         )
            //     channel = self.env["discuss.channel"].browse(vals["channel_id"])
            //     if channel.channel_type == "chat" and len(channel.channel_member_ids) > 0:
            //         raise UserError(
            //             _("Adding more members to this chat isn't possible; it's designed for just two people.")
            //         )
            // name_members_by_channel = {
            //     channel: channel.channel_name_member_ids
            //     for channel in self.env["discuss.channel"].browse(
            //         {vals["channel_id"] for vals in vals_list}
            //     )
            // }
            // res = super().create(vals_list)
            // # help the ORM to detect changes
            // res.partner_id.invalidate_recordset(["channel_ids"])
            // res.guest_id.invalidate_recordset(["channel_ids"])
            // # Always link members to parent channels as well. Member list should be
            // # kept in sync.
            // for member in res:
            //     if parent := member.channel_id.parent_channel_id:
            //         parent._add_members(partners=member.partner_id, guests=member.guest_id)
            // for channel, members in name_members_by_channel.items():
            //     if channel.channel_name_member_ids != members:
            //         Store(bus_channel=channel).add(
            //             channel,
            //             Store.Many("channel_name_member_ids", sort="id"),
            //         ).bus_send()
            // return res
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<DiscussChannelMember> CreateOrUpdateHistoryInternalAsync(object values_by_member)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py) ---
            // def _create_or_update_history(self, values_by_member):
            // members_without_history = self.filtered(lambda m: not m.livechat_member_history_ids)
            // history_domain = Domain.OR(
            //     [
            //         [
            //             ("channel_id", "=", member.channel_id.id),
            //             ("partner_id", "=", member.partner_id.id)
            //             if member.partner_id
            //             else ("guest_id", "=", member.guest_id.id),
            //         ]
            //         for member in members_without_history
            //     ]
            // )
            // history_by_channel_persona = {}
            // for history in self.env["im_livechat.channel.member.history"].search_fetch(
            //     history_domain, ["channel_id", "guest_id", "member_id", "partner_id"]
            // ):
            //     persona = history.partner_id or history.guest_id
            //     history_by_channel_persona[history.channel_id, persona] = history
            // to_create = members_without_history.filtered(
            //     lambda m: (m.channel_id, m.partner_id or m.guest_id) not in history_by_channel_persona
            // )
            // self.env["im_livechat.channel.member.history"].create(
            //     [{"member_id": member.id, **values_by_member[member]} for member in to_create]
            // )
            // for member in self - to_create:
            //     persona = member.partner_id or member.guest_id
            //     history = (
            //         member.livechat_member_history_ids
            //         or history_by_channel_persona[member.channel_id, persona]
            //     )
            //     if history.member_id != member:
            //         values_by_member[member]["member_id"] = member.id
            //     if member in values_by_member:
            //         history.write(values_by_member[member])
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
            // sessions_to_be_unpinned.channel_id.livechat_end_dt = fields.Datetime.now()
            // for member in sessions_to_be_unpinned:
            //     Store(bus_channel=member._bus_channel()).add(
            //         member.channel_id,
            //         {"close_chat_window": True, "livechat_end_dt": fields.Datetime.now()},
            //     ).bus_send()
            */
            return default;
        }

        protected async Task<DiscussChannelMember> GcUnpinOutdatedSubChannelsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _gc_unpin_outdated_sub_channels(self):
            // outdated_dt = fields.Datetime.now() - timedelta(days=2)
            // self.env["discuss.channel"].flush_model()
            // self.env["discuss.channel.member"].flush_model()
            // self.env["mail.message"].flush_model()
            // self.env.cr.execute(
            //     """
            //     SELECT member.id
            //       FROM discuss_channel_member member
            //       JOIN discuss_channel channel
            //         ON channel.id = member.channel_id
            //        AND channel.parent_channel_id IS NOT NULL
            //      WHERE (
            //                member.unpin_dt IS NULL
            //             OR member.last_interest_dt >= member.unpin_dt
            //             OR channel.last_interest_dt >= member.unpin_dt
            //        )
            //        AND COALESCE(member.last_interest_dt, member.create_date) < %(outdated_dt)s
            //        AND COALESCE(channel.last_interest_dt, channel.create_date) < %(outdated_dt)s
            //        AND NOT EXISTS (
            //            SELECT 1
            //              FROM mail_message
            //             WHERE mail_message.res_id = channel.id
            //               AND mail_message.model = 'discuss.channel'
            //               AND mail_message.id >= member.new_message_separator
            //               AND mail_message.message_type NOT IN ('notification', 'user_notification')
            //        )
            //     """,
            //     {"outdated_dt": outdated_dt},
            // )
            // members = self.env["discuss.channel.member"].search(
            //     [("id", "in", [row[0] for row in self.env.cr.fetchall()])],
            // )
            // members.unpin_dt = fields.Datetime.now()
            // for member in members:
            //     Store(bus_channel=member._bus_channel()).add(
            //         member.channel_id, {"close_chat_window": True}
            //     ).bus_send()
            */
            return default;
        }

        protected async Task<DiscussChannelMember> GetExcludedRtcMembersPartnerIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py) ---
            // def _get_excluded_rtc_members_partner_ids(self):
            // chatbot = self.channel_id.chatbot_current_step_id.chatbot_script_id
            // excluded_partner_ids = [chatbot.operator_partner_id.id] if chatbot else []
            // return excluded_partner_ids
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
            //     return self.partner_id._get_html_link(title=f"@{self._get_html_link_title()}")
            // return Markup("<strong>%s</strong>") % self.guest_id.name
            */
            return default;
        }

        protected async Task<DiscussChannelMember> GetHtmlLinkTitleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py) ---
            // def _get_html_link_title(self):
            // if self.channel_id.channel_type == "livechat" and self.partner_id.user_livechat_username:
            //     return self.partner_id.user_livechat_username
            // return super()._get_html_link_title()
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _get_html_link_title(self):
            // return self.partner_id.name if self.partner_id else self.guest_id.name
            */
            return default;
        }

        protected async Task<DiscussChannelMember> GetRtcInviteMembersDomainInternalAsync(List<Guid> member_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py) ---
            // def _get_rtc_invite_members_domain(self, *a, **kw):
            // domain = super()._get_rtc_invite_members_domain(*a, **kw)
            // if self.channel_id.channel_type == "livechat":
            //     domain &= Domain("partner_id", "not in", self._get_excluded_rtc_members_partner_ids())
            // return domain
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _get_rtc_invite_members_domain(self, member_ids=None):
            // """ Get the domain used to get the members to invite to and RTC call on
            // the member's channel.
            // 
            // :param list member_ids: List of the partner ids to invite.
            // """
            // self.ensure_one()
            // domain = Domain.AND([
            //     [('channel_id', '=', self.channel_id.id)],
            //     [('rtc_inviting_session_id', '=', False)],
            //     [('rtc_session_ids', '=', False)],
            //     Domain.OR([
            //         [("partner_id", "=", False)],
            //         [("partner_id.user_ids.manual_im_status", "!=", "busy")],
            //     ]),
            //     Domain("guest_id", "=", False) | Domain("guest_id.presence_ids.last_poll", ">", "-12H"),
            // ])
            // if member_ids:
            //     domain &= Domain('id', 'in', member_ids)
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

        protected async Task<DiscussChannelMember> GetStoreGuestFieldsInternalAsync(object fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py) ---
            // def _get_store_guest_fields(self, fields):
            // self.ensure_one()
            // if self.channel_id.channel_type == 'livechat':
            //     return [
            //         "avatar_128",
            //         Store.One("country_id", ["code", "name"]),
            //         "im_status",
            //         "name",
            //         "offline_since",
            //     ]
            // return super()._get_store_guest_fields(fields)
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _get_store_guest_fields(self, fields):
            // self.ensure_one()
            // return fields
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
            //     new_fields = [
            //         "active",
            //         "avatar_128",
            //         Store.One("country_id", ["code", "name"]),
            //         "im_status",
            //         "is_public",
            //         *self.env["res.partner"]._get_store_livechat_username_fields(),
            //     ]
            //     if self.livechat_member_type == "visitor":
            //         new_fields += ["offline_since", "email"]
            //     return new_fields
            // return super()._get_store_partner_fields(fields)
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _get_store_partner_fields(self, fields):
            // self.ensure_one()
            // return fields
            */
            return default;
        }

        protected async Task<DiscussChannelMember> InverseAgentExpertiseIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py) ---
            // def _inverse_agent_expertise_ids(self):
            // # sudo - im_livechat.channel.member.history: creating/udpating history following
            // # "agent_expetise_ids" modification is acceptable.
            // self.sudo()._create_or_update_history(
            //     {member: {"agent_expertise_ids": member.agent_expertise_ids.ids} for member in self}
            // )
            */
            return default;
        }

        protected async Task<DiscussChannelMember> InverseChatbotScriptIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py) ---
            // def _inverse_chatbot_script_id(self):
            // # sudo - im_livechat.channel.member: creating/updating history following
            // # "chatbot_script_id" modification is acceptable.
            // self.sudo()._create_or_update_history(
            //     {member: {"chatbot_script_id": member.chatbot_script_id.id} for member in self}
            // )
            */
            return default;
        }

        protected async Task<DiscussChannelMember> InverseLivechatMemberTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py) ---
            // def _inverse_livechat_member_type(self):
            // # sudo - im_livechat.channel.member: creating/updating history following
            // # "livechat_member_type" modification is acceptable.
            // self.sudo()._create_or_update_history(
            //     {member: {"livechat_member_type": member.livechat_member_type} for member in self},
            // )
            */
            return default;
        }

        protected async Task<DiscussChannelMember> JoinSfuInternalAsync(object ice_servers, object force)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _join_sfu(self, ice_servers=None, force=False):
            // if len(self.channel_id.rtc_session_ids) < SFU_MODE_THRESHOLD and not force:
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

        protected async Task<DiscussChannelMember> MarkAsReadInternalAsync(Guid last_message_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _mark_as_read(self, last_message_id):
            // """
            // Mark channel as read by updating the seen message id of the current
            // member as well as its new message separator.
            // 
            // :param last_message_id: the id of the message to be marked as read.
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
            // self._set_new_message_separator(last_message.id + 1)
            */
            return default;
        }

        protected async Task<DiscussChannelMember> NotifyMuteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _notify_mute(self):
            // for member in self:
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
            //     Store(bus_channel=member.channel_id).add(
            //         member,
            //         extra_fields={"isTyping": is_typing, "is_typing_dt": fields.Datetime.now()},
            //     ).bus_send()
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
            // if members:
            //     members.rtc_inviting_session_id = self.rtc_session_ids.id
            //     Store(bus_channel=self.channel_id).add(
            //         self.channel_id,
            //         {
            //             "invited_member_ids": Store.Many(
            //                 members,
            //                 [
            //                     Store.One("channel_id", [], as_thread=True),
            //                     *self.env["discuss.channel.member"]._to_store_persona("avatar_card"),
            //                 ],
            //                 mode="ADD",
            //             ),
            //         },
            //     ).bus_send()
            //     devices, private_key, public_key = self.channel_id._web_push_get_partners_parameters(members.partner_id.ids)
            //     if devices:
            //         if self.channel_id.channel_type != 'chat':
            //             icon = f"/web/image/discuss.channel/{self.channel_id.id}/avatar_128"
            //         elif guest := self.env["mail.guest"]._get_guest_from_context():
            //             icon = f"/web/image/mail.guest/{guest.id}/avatar_128"
            //         elif partner := self.env.user.partner_id:
            //             icon = f"/web/image/res.partner/{partner.id}/avatar_128"
            //         languages = [partner.lang for partner in devices.partner_id]
            //         payload_by_lang = {}
            //         for lang in languages:
            //             env_lang = self.with_context(lang=lang).env
            //             payload_by_lang[lang] = {
            //                 "title": env_lang._("Incoming call"),
            //                 "options": {
            //                     "body": env_lang._("Conference: %s", self.channel_id.display_name),
            //                     "icon": icon,
            //                     "vibrate": [100, 50, 100],
            //                     "requireInteraction": True,
            //                     "tag": self.channel_id._get_call_notification_tag(),
            //                     "data": {
            //                         "type": PUSH_NOTIFICATION_TYPE.CALL,
            //                         "model": "discuss.channel",
            //                         "action": "mail.action_discuss",
            //                         "res_id": self.channel_id.id,
            //                     },
            //                     "actions": [
            //                         {
            //                             "action": PUSH_NOTIFICATION_ACTION.DECLINE,
            //                             "type": "button",
            //                             "title": env_lang._("Decline"),
            //                         },
            //                         {
            //                             "action": PUSH_NOTIFICATION_ACTION.ACCEPT,
            //                             "type": "button",
            //                             "title": env_lang._("Accept"),
            //                         },
            //                     ]
            //                 }
            //             }
            //         self.channel_id._web_push_send_notification(devices, private_key, public_key, payload_by_lang=payload_by_lang)
            // return members
            */
            return default;
        }

        protected async Task<DiscussChannelMember> RtcJoinCallInternalAsync(object store, List<Guid> check_rtc_session_ids, object camera)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _rtc_join_call(self, store: Store = None, check_rtc_session_ids=None, camera=False):
            // self.ensure_one()
            // session_domain = []
            // if self.partner_id:
            //     session_domain = [("partner_id", "=", self.partner_id.id)]
            // elif self.guest_id:
            //     session_domain = [("guest_id", "=", self.guest_id.id)]
            // user_sessions = self.search(session_domain).rtc_session_ids
            // check_rtc_session_ids = (check_rtc_session_ids or []) + user_sessions.ids
            // self.channel_id._rtc_cancel_invitations(member_ids=self.ids)
            // user_sessions.unlink()
            // rtc_session = self.env['discuss.channel.rtc.session'].create({'channel_member_id': self.id, 'is_camera_on': camera})
            // current_rtc_sessions, outdated_rtc_sessions = self._rtc_sync_sessions(check_rtc_session_ids=check_rtc_session_ids)
            // ice_servers = self.env["mail.ice.server"]._get_ice_servers()
            // self._join_sfu(ice_servers)
            // if store:
            //     store.add(
            //         self.channel_id, {"rtc_session_ids": Store.Many(current_rtc_sessions, mode="ADD")}
            //     )
            //     store.add(
            //         self.channel_id,
            //         {"rtc_session_ids": Store.Many(outdated_rtc_sessions, [], mode="DELETE")},
            //     )
            //     store.add_singleton_values(
            //         "Rtc",
            //         {
            //             "iceServers": ice_servers or False,
            //             "localSession": Store.One(rtc_session),
            //             "serverInfo": self._get_rtc_server_info(rtc_session, ice_servers),
            //         },
            //     )
            // if self.channel_id._should_invite_members_to_join_call():
            //     self._rtc_invite_members()
            */
            return default;
        }

        protected async Task<DiscussChannelMember> RtcLeaveCallInternalAsync(Guid session_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _rtc_leave_call(self, session_id=None):
            // self.ensure_one()
            // if self.rtc_session_ids:
            //     if session_id:
            //         self.rtc_session_ids.filtered(lambda rec: rec.id == session_id).unlink()
            //         return
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
            // 
            //     :param list check_rtc_session_ids: list of the ids of the sessions to check
            //     :returns: (current_rtc_sessions, outdated_rtc_sessions)
            //     :rtype: tuple
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
            // if operator != 'in':
            //     return NotImplemented
            // 
            // def custom_pinned(model: models.BaseModel, alias, query):
            //     channel_model = model.browse().channel_id
            //     channel_alias = query.make_alias(alias, 'channel_id')
            //     query.add_join("LEFT JOIN", channel_alias, channel_model._table, SQL(
            //         "%s = %s",
            //         model._field_to_sql(alias, 'channel_id'),
            //         channel_model._field_to_sql(channel_alias, 'id'),
            //     ))
            //     return SQL(
            //         """(%(unpin)s IS NULL
            //             OR %(last_interest)s >= %(unpin)s
            //             OR %(channel_last_interest)s >= %(unpin)s
            //         )""",
            //         unpin=model._field_to_sql(alias, "unpin_dt", query),
            //         last_interest=model._field_to_sql(alias, "last_interest_dt", query),
            //         channel_last_interest=channel_model._field_to_sql(channel_alias, "last_interest_dt", query),
            //     )
            // 
            // return Domain.custom(to_sql=custom_pinned)
            */
            return default;
        }

        protected async Task<DiscussChannelMember> SearchIsSelfInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _search_is_self(self, operator, operand):
            // if operator != 'in':
            //     return NotImplemented
            // current_partner, current_guest = self.env["res.partner"]._get_current_persona()
            // domain_partner = Domain("partner_id", "=", current_partner.id) if current_partner else Domain.FALSE
            // domain_guest = Domain("guest_id", "=", current_guest.id) if current_guest else Domain.FALSE
            // return domain_partner | domain_guest
            */
            return default;
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
            // bus_channel = self._bus_channel()
            // if self.seen_message_id.id < message.id:
            //     self.write({
            //         "fetched_message_id": max(self.fetched_message_id.id, message.id),
            //         "seen_message_id": message.id,
            //         "last_seen_dt": fields.Datetime.now(),
            //     })
            //     if self.channel_id.channel_type in self.channel_id._types_allowing_seen_infos():
            //         bus_channel = self.channel_id
            // if not notify:
            //     return
            // Store(bus_channel=bus_channel).add(
            //     self,
            //     [
            //         Store.One("channel_id", [], as_thread=True),
            //         *self.env["discuss.channel.member"]._to_store_persona("avatar_card"),
            //         "seen_message_id",
            //     ],
            // ).bus_send()
            */
            return default;
        }

        protected async Task<DiscussChannelMember> SetNewMessageSeparatorInternalAsync(Guid message_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _set_new_message_separator(self, message_id):
            // """
            // :param message_id: id of the message above which the new message
            //     separator should be displayed.
            // """
            // self.ensure_one()
            // if message_id == self.new_message_separator:
            //     bus_last_id = self.env["bus.bus"].sudo()._bus_last_id()
            //     Store(bus_channel=self._bus_channel()).add(
            //         self,
            //         [
            //             Store.One("channel_id", [], as_thread=True),
            //             "message_unread_counter",
            //             {"message_unread_counter_bus_id": bus_last_id},
            //             "new_message_separator",
            //             *self.env["discuss.channel.member"]._to_store_persona([]),
            //         ],
            //     ).bus_send()
            //     return
            // self.new_message_separator = message_id
            */
            return default;
        }

        protected async Task<DiscussChannelMember> SyncFieldNamesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _sync_field_names(self):
            // return [
            //     "custom_channel_name",
            //     "custom_notifications",
            //     "last_interest_dt",
            //     "message_unread_counter",
            //     "mute_until_dt",
            //     "new_message_separator",
            //     # sudo: discuss.channel.rtc.session - each member can see who is inviting them
            //     Store.One(
            //         "rtc_inviting_session_id",
            //         extra_fields=self.rtc_inviting_session_id._get_store_extra_fields(),
            //         sudo=True,
            //     ),
            //     "unpin_dt",
            // ]
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ToStoreDefaultsInternalAsync(object target)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py) ---
            // def _to_store_defaults(self, target):
            // return super()._to_store_defaults(target) + [
            //     Store.Attr(
            //         "livechat_member_type",
            //         predicate=lambda member: member.channel_id.channel_type == "livechat",
            //     )
            // ]
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _to_store_defaults(self, target):
            // return [
            //     Store.One("channel_id", [], as_thread=True),
            //     "create_date",
            //     "fetched_message_id",
            //     "last_seen_dt",
            //     "seen_message_id",
            //     *self.env["discuss.channel.member"]._to_store_persona(),
            // ]
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ToStorePersonaInternalAsync(object fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py) ---
            // def _to_store_persona(self, fields=None):
            // if fields == "avatar_card":
            //     fields = ["avatar_128", "im_status", "name"]
            // return [
            //     # sudo: res.partner - reading partner related to a member is considered acceptable
            //     Store.Attr(
            //         "partner_id",
            //         lambda m: Store.One(
            //             m.partner_id.sudo(),
            //             (p_fields := m._get_store_partner_fields(fields)),
            //             extra_fields=self.env["res.partner"]._get_store_mention_fields()
            //             if p_fields or p_fields is None
            //             else None,
            //         ),
            //         predicate=lambda m: m.partner_id,
            //     ),
            //     # sudo: mail.guest - reading guest related to a member is considered acceptable
            //     Store.Attr(
            //         "guest_id",
            //         lambda m: Store.One(m.guest_id.sudo(), m._get_store_guest_fields(fields)),
            //         predicate=lambda m: m.guest_id,
            //     ),
            // ]
            */
            return default;
        }
    }
}