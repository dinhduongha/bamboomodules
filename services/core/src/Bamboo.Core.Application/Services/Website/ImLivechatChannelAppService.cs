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
    [Module("ImLivechat", Category = "Website", Depends = new[] { "mail", "rating", "digest", "utm" })]
    public partial class ImLivechatChannelAppService : GenericApplicationService<ImLivechatChannel>, IImLivechatChannelAppService
    {
        private readonly IRatingParentMixinAppService _ratingParentMixinAppService;
        public ImLivechatChannelAppService(IRepository<ImLivechatChannel, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IRatingParentMixinAppService ratingParentMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _ratingParentMixinAppService = ratingParentMixinAppService;
        }

        protected async Task<ImLivechatChannel> AreYouInsideInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _are_you_inside(self):
            // for channel in self:
            //     channel.are_you_inside = self.env.user in channel.user_ids
            */
            return default;
        }

        protected async Task<ImLivechatChannel> CheckReviewLinkInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _check_review_link(self):
            // for record in self.filtered("review_link"):
            //     url = urlparse(record.review_link)
            //     if url.scheme not in ("http", "https") or not url.netloc:
            //         raise ValidationError(
            //             self.env._("Invalid URL '%s'. The Review Link must start with 'http://' or 'https://'.") % record.review_link
            //         )
            */
            return default;
        }

        protected async Task<ImLivechatChannel> ComputeAvailableOperatorIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_available_operator_ids(self):
            // operators_by_livechat_channel = self._get_available_operators_by_livechat_channel()
            // for livechat_channel in self:
            //     livechat_channel.available_operator_ids = operators_by_livechat_channel[livechat_channel]
            */
            return default;
        }

        protected async Task<ImLivechatChannel> ComputeChatbotScriptCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_chatbot_script_count(self):
            // data = self.env['im_livechat.channel.rule']._read_group(
            //     [('channel_id', 'in', self.ids)], ['channel_id'], ['chatbot_script_id:count_distinct'])
            // mapped_data = {channel.id: count_distinct for channel, count_distinct in data}
            // for channel in self:
            //     channel.chatbot_script_count = mapped_data.get(channel.id, 0)
            */
            return default;
        }

        protected async Task<ImLivechatChannel> ComputeNbrChannelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_nbr_channel(self):
            // data = self.env['discuss.channel']._read_group([
            //     ('livechat_channel_id', 'in', self.ids),
            // ], ['livechat_channel_id'], ['__count'])
            // channel_count = {livechat_channel.id: count for livechat_channel, count in data}
            // for record in self:
            //     record.nbr_channel = channel_count.get(record.id, 0)
            */
            return default;
        }

        protected async Task<ImLivechatChannel> ComputeOngoingSessionsCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_ongoing_sessions_count(self):
            // count_by_channel = defaultdict(int)
            // for key, count in self._get_ongoing_session_count_by_agent_livechat_channel().items():
            //     count_by_channel[key[1]] += count
            // for channel in self:
            //     channel.ongoing_session_count = count_by_channel.get(channel, 0)
            */
            return default;
        }

        protected async Task<ImLivechatChannel> ComputeRemainingSessionCapacityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_remaining_session_capacity(self):
            // count = self._get_ongoing_session_count_by_agent_livechat_channel()
            // for channel in self:
            //     users = channel.user_ids
            //     if channel.block_assignment_during_call:
            //         users = users.filtered(lambda u: not u.livechat_is_in_call)
            //     total_capacity = channel.max_sessions * len(users)
            //     capacity = total_capacity - sum(
            //         count.get((user.partner_id, channel), 0) for user in users
            //     )
            //     channel.remaining_session_capacity = max(capacity, 0)
            */
            return default;
        }

        protected async Task<ImLivechatChannel> ComputeScriptExternalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_script_external(self):
            // values = {
            //     "dbname": self.env.cr.dbname,
            // }
            // for record in self:
            //     values["channel_id"] = record.id
            //     values["url"] = record.get_base_url()
            //     record.script_external = self.env['ir.qweb']._render('im_livechat.external_loader', values) if record.id else False
            */
            return default;
        }

        protected async Task<ImLivechatChannel> ComputeWebPageLinkInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_web_page_link(self):
            // for record in self:
            //     record.web_page = "%s/im_livechat/support/%i" % (record.get_base_url(), record.id) if record.id else False
            */
            return default;
        }

        public override async Task<ImLivechatChannel> CreateAsync(ImLivechatChannel entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: im_livechat_channel.py) ---
            // def create(self, vals_list):
            // channels = super().create(vals_list)
            // if self.env.context.get("create_from_website"):
            //     website = self.env['website'].get_current_website()
            //     bot = self.env.ref("im_livechat.chatbot_script_welcome_bot", raise_if_not_found=False)
            //     website.channel_id = channels[0].id
            //     channel_rule_vals = []
            //     for channel in channels:
            //         if bot:
            //             channel_rule_vals.append({
            //                 'channel_id': channel.id,
            //                 'action': 'display_button',
            //                 'chatbot_script_id': bot.id,
            //                 'chatbot_enabled_condition': 'always',
            //             })
            //         self.env.user._bus_send(
            //             "simple_notification",
            //             {
            //                 "type": "success",
            //                 "message": self.env._("Channel created: %(name)s", name=channel.name),
            //             },
            //         )
            //     if channel_rule_vals:
            //         self.env["im_livechat.channel.rule"].create(channel_rule_vals)
            // return channels
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<ImLivechatChannel> DefaultButtonTextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _default_button_text(self):
            // return _('Need help? Chat with us.')
            */
            return default;
        }

        protected async Task<ImLivechatChannel> DefaultDefaultMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _default_default_message(self):
            // return _('How may I help you?')
            */
            return default;
        }

        protected async Task<ImLivechatChannel> DefaultUserIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _default_user_ids(self):
            // return [(6, 0, [self.env.uid])]
            */
            return default;
        }

        protected async Task<ImLivechatChannel> GetAgentMemberValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_agent_member_vals(self, /, *, last_interest_dt, now, chatbot_script, operator_partner, operator_model, **kwargs):
            // return {
            //     "chatbot_script_id": chatbot_script.id if operator_model == 'chatbot.script' else False,
            //     "last_interest_dt": last_interest_dt,
            //     "livechat_member_type": "agent" if operator_model == 'res.users' else "bot",
            //     "partner_id": operator_partner.id,
            //     "unpin_dt": now,
            // }
            */
            return default;
        }

        protected async Task<ImLivechatChannel> GetAvailableOperatorsByLivechatChannelInternalAsync(object users)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_available_operators_by_livechat_channel(self, users=None):
            // """Return a dictionary mapping each livechat channel in ``self`` to the users that are
            // available for that livechat channel, according to the user status and the optional
            // limit of concurrent sessions of the livechat channel.
            // 
            // When ``users`` are provided, each user is attempted to be mapped for each livechat
            // channel. Otherwise, only the users of each respective livechat channel are considered.
            // 
            // :param users: Optional list of users to consider. Every agent in ``self`` will be
            //  considered if omitted.
            // 
            // """
            // counts = {}
            // if livechat_channels := self.filtered(lambda c: c.max_sessions_mode == "limited"):
            //     counts = livechat_channels._get_ongoing_session_count_by_agent_livechat_channel(
            //         users, filter_online=True
            //     )
            // 
            // def is_available(user, channel):
            //     return (
            //         #  sudo - res.users: can access agent presence to determine if they are available.
            //         user.sudo().presence_ids.status == "online"
            //         and (
            //             channel.max_sessions_mode == "unlimited"
            //             or counts.get((user.partner_id, channel), 0) < channel.max_sessions
            //         )
            //         # sudo: res.users - it's acceptable to check if the user is in call
            //         and (not channel.block_assignment_during_call or not user.sudo().is_in_call)
            //     )
            // 
            // operators_by_livechat_channel = {}
            // for livechat_channel in self:
            //     possible_users = users if users is not None else livechat_channel.user_ids
            //     operators_by_livechat_channel[livechat_channel] = possible_users.filtered(
            //         lambda user, livechat_channel=livechat_channel: is_available(user, livechat_channel)
            //     )
            // return operators_by_livechat_channel
            */
            return default;
        }

        protected async Task<ImLivechatChannel> GetChannelInfosInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_channel_infos(self):
            // self.ensure_one()
            // 
            // return {
            //     'header_background_color': self.header_background_color,
            //     'button_background_color': self.button_background_color,
            //     'title_color': self.title_color,
            //     'button_text_color': self.button_text_color,
            //     'button_text': self.button_text,
            //     'default_message': self.default_message,
            //     "channel_name": self.name,
            //     "channel_id": self.id,
            //     "review_link": self.review_link,
            // }
            */
            return default;
        }

        protected async Task<ImLivechatChannel> GetChannelNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_channel_name(self, /, *, visitor_user=None, guest=None, agent, chatbot_script, operator_model, **kwargs):
            // if operator_model == 'chatbot.script':
            //     channel_name = chatbot_script.title
            // else:
            //     channel_name = ' '.join([
            //         visitor_user.display_name if visitor_user else guest.name,
            //         agent.livechat_username or agent.name
            //     ])
            // return channel_name
            */
            return default;
        }

        protected async Task<ImLivechatChannel> GetLessActiveOperatorInternalAsync(object operator_statuses, object operators)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_less_active_operator(self, operator_statuses, operators):
            // """ Retrieve the most available operator based on the following criteria:
            // - Lowest number of active chats.
            // - Not in  a call.
            // - If an operator is in a call and has two or more active chats, don't
            //   give priority over an operator with more conversations who is not in a
            //   call.
            // 
            // :param operator_statuses: list of dictionaries containing the operator's
            //     id, the number of active chats and a boolean indicating if the
            //     operator is in a call. The list is ordered by the number of active
            //     chats (ascending) and whether the operator is in a call
            //     (descending).
            // :param operators: recordset of :class:`ResUsers` operators to choose from.
            // :return: the :class:`ResUsers` record for the chosen operator
            // """
            // if not operators:
            //     return False
            // 
            // # 1) only consider operators in the list to choose from
            // operator_statuses = [
            //     s for s in operator_statuses if s['partner_id'] in set(operators.partner_id.ids)
            // ]
            // 
            // # 2) try to select an inactive op, i.e. one w/ no active status (no recent chat)
            // active_op_partner_ids = {s['partner_id'] for s in operator_statuses}
            // candidates = operators.filtered(lambda o: o.partner_id.id not in active_op_partner_ids)
            // if candidates:
            //     return random.choice(candidates)
            // 
            // # 3) otherwise select least active ops, based on status ordering (count + in_call)
            // best_status = operator_statuses[0]
            // best_status_op_partner_ids = {
            //     s['partner_id']
            //     for s in operator_statuses
            //     if (s['count'], s['in_call']) == (best_status['count'], best_status['in_call'])
            // }
            // candidates = operators.filtered(lambda o: o.partner_id.id in best_status_op_partner_ids)
            // return random.choice(candidates)
            */
            return default;
        }

        protected async Task<ImLivechatChannel> GetLivechatDiscussChannelValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_livechat_discuss_channel_vals(self, /, *, chatbot_script=None, agent=None, operator_partner, operator_model, **kwargs):
            // # use the same "now" in the whole function to ensure unpin_dt > last_interest_dt
            // now = fields.Datetime.now()
            // last_interest_dt = now - timedelta(seconds=1)
            // members_to_add = [Command.create(self._get_agent_member_vals(
            //     last_interest_dt=last_interest_dt, now=now,
            //     chatbot_script=chatbot_script,
            //     operator_partner=operator_partner,
            //     operator_model=operator_model,
            //     **kwargs
            // ))]
            // guest = self.env["mail.guest"]._get_guest_from_context()
            // if guest and self.env.user._is_public():
            //     members_to_add.append(
            //         Command.create({"livechat_member_type": "visitor", "guest_id": guest.id})
            //     )
            // visitor_user = self.env["res.users"]
            // if not self.env.user._is_public():
            //     visitor_user = self.env.user
            //     if visitor_user and visitor_user != agent:
            //         members_to_add.append(
            //             Command.create(
            //                 {
            //                     "livechat_member_type": "visitor",
            //                     "partner_id": visitor_user.partner_id.id,
            //                 }
            //             )
            //         )
            // 
            // channel_name = self._get_channel_name(
            //     visitor_user=visitor_user,
            //     guest=guest,
            //     agent=agent,
            //     chatbot_script=chatbot_script,
            //     operator_model=operator_model,
            //     **kwargs
            // )
            // is_chatbot_script = operator_model == 'chatbot.script'
            // is_agent = operator_model == 'res.users'
            // return {
            //     'channel_member_ids': members_to_add,
            //     "last_interest_dt": last_interest_dt,
            //     'livechat_operator_id': operator_partner.id,
            //     'livechat_channel_id': self.id,
            //     "livechat_failure": "no_answer" if is_agent else "no_failure",
            //     "livechat_status": "in_progress",
            //     'chatbot_current_step_id': chatbot_script._get_welcome_steps()[-1].id if is_chatbot_script else False,
            //     'channel_type': 'livechat',
            //     'name': channel_name,
            // }
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: im_livechat_channel.py) ---
            // def _get_livechat_discuss_channel_vals(self, /, *, chatbot_script=None, agent=None, operator_partner, operator_model, **kwargs):
            // discuss_channel_vals = super()._get_livechat_discuss_channel_vals(
            //     agent=agent,
            //     chatbot_script=chatbot_script,
            //     operator_partner=operator_partner,
            //     operator_model=operator_model,
            //     **kwargs
            // )
            // if not discuss_channel_vals:
            //     return False
            // visitor_sudo = self.env['website.visitor']._get_visitor_from_request()
            // if visitor_sudo:
            //     discuss_channel_vals['livechat_visitor_id'] = visitor_sudo.id
            //     # As chat requested by the visitor, delete the chat requested by an operator if any to avoid conflicts between two flows
            //     # TODO DBE : Move this into the proper method (open or init mail channel)
            //     pending_chats_domain = [
            //         ("is_pending_chat_request", "=", True),
            //         ("livechat_visitor_id", "=", visitor_sudo.id),
            //         ("livechat_end_dt", "=", False),
            //     ]
            //     for discuss_channel in self.env["discuss.channel"].sudo().search(pending_chats_domain):
            //         operator = discuss_channel.livechat_operator_id
            //         operator_name = operator.user_livechat_username or operator.name
            //         discuss_channel._close_livechat_session(cancel=True, operator=operator_name)
            //         discuss_channel.is_pending_chat_request = False
            // 
            // return discuss_channel_vals
            */
            return default;
        }

        public async Task<ImLivechatChannel> GetLivechatInfoAsync(Guid id, ImLivechatChannelGetLivechatInfoRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def get_livechat_info(self, username=None):
            // self.ensure_one()
            // 
            // if username is None:
            //     username = _('Visitor')
            // info = {}
            // info['available'] = self._is_livechat_available()
            // info['server_url'] = self.get_base_url()
            // info["websocket_worker_version"] = WebsocketConnectionHandler._VERSION
            // if info['available']:
            //     info['options'] = self._get_channel_infos()
            //     info['options']["default_username"] = username
            // return info
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ImLivechatChannel> GetOngoingSessionCountByAgentLivechatChannelInternalAsync(object users, object filter_online)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_ongoing_session_count_by_agent_livechat_channel(self, users=None, filter_online=False):
            // """Return a dictionary mapping each ``(user, livechat_channel)`` pair to the number of
            // ongoing livechat sessions.
            // 
            // :param users: List of users to consider for the session count.
            // :param filter_online: If ``True``, only online agents will be considered.
            // :type filter_online: bool
            // :returns: A dictionary mapping ``(partner_id, livechat_channel_id)`` to the session count.
            // :rtype: dict
            // 
            // """
            // user_domain = Domain(False)
            // for channel in self:
            //     active_users = users if users is not None else channel.user_ids
            //     if filter_online:
            //         # sudo - res.users: can access agent presence to determine if they are available.
            //         active_users = active_users.filtered(lambda u: u.sudo().presence_ids.status == "online")
            //     user_domain |= Domain(
            //         [
            //             ("partner_id", "in", active_users.partner_id.ids),
            //             ("channel_id.livechat_channel_id", "in", channel.ids),
            //         ]
            //     )
            // counts = self.env["discuss.channel.member"]._read_group(
            //     Domain("channel_id.livechat_end_dt", "=", False)
            //     & Domain("channel_id.last_interest_dt", ">=", "-15M")
            //     & user_domain,
            //     groupby=["partner_id", "channel_id.livechat_channel_id"],
            //     aggregates=["__count"],
            // )
            // return {(partner, channel): count for (partner, channel, count) in counts}
            */
            return default;
        }

        protected async Task<ImLivechatChannel> GetOperatorInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_operator_info(self, /, *, lang, country_id, previous_operator_id=None, chatbot_script_id=None, **kwargs):
            // agent = self.env['res.users']
            // chatbot_script = self.env['chatbot.script']
            // operator_partner = self.env['res.partner']
            // # The operator_model establishes the priority among potential operators (e.g., chatbot_script or ai_agent) for a live chat channel.
            // # It dictates which operator model is selected when multiple are configured.
            // operator_model = ''
            // 
            // if chatbot_script_id and chatbot_script_id in self.rule_ids.chatbot_script_id.ids:
            //     chatbot_script = (
            //         self.env["chatbot.script"]
            //         .sudo()
            //         .with_context(lang=self.env["chatbot.script"]._get_chatbot_language())
            //         .search([("id", "=", chatbot_script_id)])
            //     )
            //     operator_partner = chatbot_script.operator_partner_id
            //     operator_model = 'chatbot.script'
            // 
            // if not operator_model:
            //     agent = self._get_operator(
            //         previous_operator_id=previous_operator_id,
            //         lang=lang,
            //         country_id=country_id,
            //     )
            //     operator_partner = agent.partner_id
            //     operator_model = 'res.users'
            // 
            // return {'agent': agent, 'chatbot_script': chatbot_script, 'operator_partner': operator_partner, 'operator_model': operator_model}
            */
            return default;
        }

        protected async Task<ImLivechatChannel> GetOperatorInternalAsync(Guid previous_operator_id, object lang, Guid country_id, object expertises, object users)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_operator(
            //     self, previous_operator_id=None, lang=None, country_id=None, expertises=None, users=None
            // ):
            //     """ Return an operator for a livechat. Try to return the previous
            //     operator if available. If not, one of the most available operators be
            //     returned.
            // 
            //     A livechat is considered 'active' if it has at least one message within
            //     the 30 minutes. This method will try to match the given lang, expertises
            //     and country_id.
            // 
            //     (Some annoying conversions have to be made on the fly because this model
            //     holds 'res.users' as available operators and the discuss_channel model
            //     stores the partner_id of the randomly selected operator)
            // 
            //     :param previous_operator_id: partner id of the previous operator with
            //         whom the visitor was chatting.
            //     :param lang: code of the preferred lang of the visitor.
            //     :param country_id: id of the country of the visitor.
            //     :param expertises: preferred expertises for filtering operators.
            //     :param users: recordset of available users to use as candidates instead
            //         of the users of the livechat channel.
            //     :return : user
            //     :rtype : res.users
            //     """
            //     self.ensure_one()
            //     # FIXME: remove inactive call sessions so operators no longer in call are available
            //     # sudo: required to use garbage collecting function.
            //     self.env["discuss.channel.rtc.session"].sudo()._gc_inactive_sessions()
            //     users = users if users is not None else self.available_operator_ids
            //     if not users:
            //         return self.env["res.users"]
            //     if expertises is None:
            //         expertises = self.env["im_livechat.expertise"]
            //     self.env.cr.execute(
            //         """
            //             WITH operator_rtc_session AS (
            //                 SELECT COUNT(DISTINCT s.id) as nbr, member.partner_id as partner_id
            //                   FROM discuss_channel_rtc_session s
            //                   JOIN discuss_channel_member member ON (member.id = s.channel_member_id)
            //               GROUP BY member.partner_id
            //             )
            //            SELECT COUNT(DISTINCT h.channel_id), COALESCE(rtc.nbr, 0) > 0 as in_call, h.partner_id
            //              FROM im_livechat_channel_member_history h
            //              JOIN discuss_channel c ON h.channel_id = c.id
            //   LEFT OUTER JOIN operator_rtc_session rtc ON rtc.partner_id = h.partner_id
            //             WHERE c.livechat_end_dt IS NULL
            //               AND c.last_interest_dt > ((now() at time zone 'UTC') - interval '30 minutes')
            //               AND h.partner_id in %s
            //          GROUP BY h.partner_id, rtc.nbr
            //          ORDER BY COUNT(DISTINCT h.channel_id) < 2 OR rtc.nbr IS NULL DESC,
            //                   COUNT(DISTINCT h.channel_id) ASC,
            //                   rtc.nbr IS NULL DESC
            //         """,
            //         (tuple(users.partner_id.ids),),
            //     )
            //     operator_statuses = self.env.cr.dictfetchall()
            //     # Try to match the previous operator
            //     if previous_operator_id in users.partner_id.ids:
            //         previous_operator_status = next(
            //             (
            //                 status
            //                 for status in operator_statuses
            //                 if status['partner_id'] == previous_operator_id
            //             ),
            //             None,
            //         )
            //         if not previous_operator_status or previous_operator_status['count'] < 2 or not previous_operator_status['in_call']:
            //             previous_operator_user = next(
            //                 available_user
            //                 for available_user in users
            //                 if available_user.partner_id.id == previous_operator_id
            //             )
            //             return previous_operator_user
            // 
            //     agents_failing_buffer = {
            //             group[0]
            //             for group in self.env["im_livechat.channel.member.history"]._read_group(
            //                 [
            //                     ("livechat_member_type", "=", "agent"),
            //                     ("partner_id", "in", users.partner_id.ids),
            //                     ("channel_id.livechat_end_dt", "=", False),
            //                     (
            //                         "create_date",
            //                         ">",
            //                         fields.Datetime.now() - timedelta(seconds=BUFFER_TIME),
            //                     ),
            //                 ],
            //                 groupby=["partner_id"],
            //             )
            //         }
            // 
            //     def same_language(operator):
            //         return operator.partner_id.lang == lang or lang in operator.livechat_lang_ids.mapped("code")
            // 
            //     def all_expertises(operator):
            //         return operator.livechat_expertise_ids >= expertises
            // 
            //     def one_expertise(operator):
            //         return operator.livechat_expertise_ids & expertises
            // 
            //     def same_country(operator):
            //         return operator.partner_id.country_id.id == country_id
            // 
            //     # List from most important to least important. Order on each line is irrelevant, all
            //     # elements of a line must be satisfied together or the next line is checked.
            //     preferences_list = [
            //         [same_language, all_expertises],
            //         [same_language, one_expertise],
            //         [same_language],
            //         [same_country, all_expertises],
            //         [same_country, one_expertise],
            //         [same_country],
            //         [all_expertises],
            //         [one_expertise],
            //     ]
            //     for preferences in preferences_list:
            //         operators = users
            //         for preference in preferences:
            //             operators = operators.filtered(preference)
            //         if operators:
            //             if agents_respecting_buffer := operators.filtered(
            //                 lambda op: op.partner_id not in agents_failing_buffer
            //             ):
            //                 operators = agents_respecting_buffer
            //             return self._get_less_active_operator(operator_statuses, operators)
            //     return self._get_less_active_operator(operator_statuses, users)
            */
            return default;
        }

        protected async Task<ImLivechatChannel> IsLivechatAvailableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _is_livechat_available(self):
            // return self.chatbot_script_count or len(self.available_operator_ids) > 0
            */
            return default;
        }

        public async Task<ImLivechatChannel> JoinAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def action_join(self):
            // self.ensure_one()
            // if not self.env.user.has_group("im_livechat.im_livechat_group_user"):
            //     raise AccessError(_("Only Live Chat operators can join Live Chat channels"))
            // # sudo: im_livechat.channel - operators can join channels
            // self.sudo().user_ids = [Command.link(self.env.user.id)]
            // Store(bus_channel=self.env.user).add(self, ["are_you_inside", "name"]).bus_send()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ImLivechatChannel> QuitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def action_quit(self):
            // self.ensure_one()
            // # sudo: im_livechat.channel - users can leave channels
            // self.sudo().user_ids = [Command.unlink(self.env.user.id)]
            // Store(bus_channel=self.env.user).add(self.sudo(), ["are_you_inside", "name"]).bus_send()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ImLivechatChannel> ViewChatbotScriptsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def action_view_chatbot_scripts(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('im_livechat.chatbot_script_action')
            // chatbot_script_ids = self.env['im_livechat.channel.rule'].search(
            //     [('channel_id', 'in', self.ids)]).mapped('chatbot_script_id')
            // if len(chatbot_script_ids) == 1:
            //     action['res_id'] = chatbot_script_ids.id
            //     action['view_mode'] = 'form'
            //     action['views'] = [(False, 'form')]
            // else:
            //     action['domain'] = [('id', 'in', chatbot_script_ids.ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ImLivechatChannel> ViewRatingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def action_view_rating(self):
            // """ Action to display the rating relative to the channel, so all rating of the
            //     sessions of the current channel
            //     :returns : the ir.action 'action_view_rating' with the correct context
            // """
            // self.ensure_one()
            // action = self.env["ir.actions.act_window"]._for_xml_id(
            //     "im_livechat.discuss_channel_action_from_livechat_channel"
            // )
            // action["context"] = {
            //     "search_default_parent_res_name": self.name,
            //     "search_default_fiter_session_rated": "1"
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<List<Dictionary<string, object>>> WebReadAsync(Guid id, ImLivechatChannelWebReadRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def web_read(self, specification: dict[str, dict]) -> list[dict]:
            // user_context = specification.get("user_ids", {}).get("context", {})
            // if len(self) == 1 and user_context.pop("add_livechat_channel_ctx", None):
            //     user_context["im_livechat_channel_id"] = self.id
            // return super().web_read(specification)
            */
            var entity = await Repository.GetAsync(id); return default;
        }
    }
}
