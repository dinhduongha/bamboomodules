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
    [Module("ImLivechat", Depends = new[] { "mail", "rating", "digest", "utm" })]
    public class ImLivechatChannelAppService : GenericApplicationService<ImLivechatChannel>, IImLivechatChannelAppService
    {
        private readonly IRatingParentMixinAppService _ratingParentMixinAppService;
        private readonly IWebsitePublishedMixinAppService _websitePublishedMixinAppService;
        public ImLivechatChannelAppService(IRepository<ImLivechatChannel, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IRatingParentMixinAppService ratingParentMixinAppService, IWebsitePublishedMixinAppService websitePublishedMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _ratingParentMixinAppService = ratingParentMixinAppService;
            _websitePublishedMixinAppService = websitePublishedMixinAppService;
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

        protected async Task<ImLivechatChannel> ComputeAvailableOperatorIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_available_operator_ids(self):
            // for record in self:
            //     record.available_operator_ids = record.user_ids.filtered(lambda user: user._is_user_available())
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

        protected async Task<ImLivechatChannel> ComputeScriptExternalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _compute_script_external(self):
            // values = {
            //     "dbname": self._cr.dbname,
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

        protected async Task<ImLivechatChannel> ComputeWebsiteUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: im_livechat.py) ---
            // def _compute_website_url(self):
            // super(ImLivechatChannel, self)._compute_website_url()
            // for channel in self:
            //     channel.website_url = "/livechat/channel/%s" % (self.env['ir.http']._slug(channel),)
            */
            return default;
        }

        protected async Task<ImLivechatChannel> DefaultButtonTextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _default_button_text(self):
            // return _('Have a Question? Chat with us.')
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
            // return [(6, 0, [self._uid])]
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
            //     'input_placeholder': self.input_placeholder,
            //     'default_message': self.default_message,
            //     "channel_name": self.name,
            //     "channel_id": self.id,
            // }
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
            //     s for s in operator_statuses if s['livechat_operator_id'] in set(operators.partner_id.ids)
            // ]
            // 
            // # 2) try to select an inactive op, i.e. one w/ no active status (no recent chat)
            // active_op_partner_ids = {s['livechat_operator_id'] for s in operator_statuses}
            // candidates = operators.filtered(lambda o: o.partner_id.id not in active_op_partner_ids)
            // if candidates:
            //     return random.choice(candidates)
            // 
            // # 3) otherwise select least active ops, based on status ordering (count + in_call)
            // best_status = operator_statuses[0]
            // best_status_op_partner_ids = {
            //     s['livechat_operator_id']
            //     for s in operator_statuses
            //     if (s['count'], s['in_call']) == (best_status['count'], best_status['in_call'])
            // }
            // candidates = operators.filtered(lambda o: o.partner_id.id in best_status_op_partner_ids)
            // return random.choice(candidates)
            */
            return default;
        }

        protected async Task<ImLivechatChannel> GetLivechatDiscussChannelValsInternalAsync(object anonymous_name, Guid previous_operator_id, object chatbot_script, Guid user_id, Guid country_id, object lang)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_livechat_discuss_channel_vals(
            //     self, anonymous_name, previous_operator_id=None, chatbot_script=None, user_id=None, country_id=None, lang=None
            // ):
            //     user_operator = False
            //     if chatbot_script:
            //         if chatbot_script.id not in self.browse(self.ids).mapped('rule_ids.chatbot_script_id.id'):
            //             return False
            //     else:
            //         user_operator = self._get_operator(previous_operator_id=previous_operator_id, lang=lang, country_id=country_id)
            //         if not user_operator:
            //             # no one available
            //             return False
            //     # partner to add to the discuss.channel
            //     operator_partner_id = user_operator.partner_id.id if user_operator else chatbot_script.operator_partner_id.id
            //     members_to_add = [
            //         Command.create({
            //             # making sure the unpin_dt is always later than the last_interest_dt
            //             # so that the channel is always unpinned at first
            //             'last_interest_dt': fields.Datetime.now() - timedelta(seconds=30),
            //             'partner_id': operator_partner_id,
            //             'unpin_dt': fields.Datetime.now(),
            //         })
            //     ]
            //     visitor_user = False
            //     if user_id:
            //         visitor_user = self.env['res.users'].browse(user_id)
            //         if visitor_user and visitor_user.active and user_operator and visitor_user != user_operator:  # valid session user (not public)
            //             members_to_add.append(Command.create({'partner_id': visitor_user.partner_id.id}))
            // 
            //     if chatbot_script:
            //         name = chatbot_script.title
            //     else:
            //         name = ' '.join([
            //             visitor_user.display_name if visitor_user else anonymous_name,
            //             user_operator.livechat_username or user_operator.name
            //         ])
            // 
            //     return {
            //         'channel_member_ids': members_to_add,
            //         'livechat_active': True,
            //         'livechat_operator_id': operator_partner_id,
            //         'livechat_channel_id': self.id,
            //         'chatbot_current_step_id': chatbot_script._get_welcome_steps()[-1].id if chatbot_script else False,
            //         'anonymous_name': False if user_id else anonymous_name,
            //         'country_id': country_id,
            //         'channel_type': 'livechat',
            //         'name': name,
            //     }
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: im_livechat_channel.py) ---
            // def _get_livechat_discuss_channel_vals(self, anonymous_name, previous_operator_id=None, chatbot_script=None, user_id=None, country_id=None, lang=None):
            // discuss_channel_vals = super(ImLivechatChannel, self)._get_livechat_discuss_channel_vals(
            //     anonymous_name, previous_operator_id, chatbot_script, user_id=user_id, country_id=country_id, lang=lang
            // )
            // if not discuss_channel_vals:
            //     return False
            // visitor_sudo = self.env['website.visitor']._get_visitor_from_request()
            // if visitor_sudo:
            //     discuss_channel_vals['livechat_visitor_id'] = visitor_sudo.id
            //     # As chat requested by the visitor, delete the chat requested by an operator if any to avoid conflicts between two flows
            //     # TODO DBE : Move this into the proper method (open or init mail channel)
            //     chat_request_channel = self.env['discuss.channel'].sudo().search([('livechat_visitor_id', '=', visitor_sudo.id), ('livechat_active', '=', True)])
            //     for discuss_channel in chat_request_channel:
            //         operator = discuss_channel.livechat_operator_id
            //         operator_name = operator.user_livechat_username or operator.name
            //         discuss_channel._close_livechat_session(cancel=True, operator=operator_name)
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
            // info['available'] = self.chatbot_script_count or len(self.available_operator_ids) > 0
            // info['server_url'] = self.get_base_url()
            // info["websocket_worker_version"] = WebsocketConnectionHandler._VERSION
            // if info['available']:
            //     info['options'] = self._get_channel_infos()
            //     info['options']["default_username"] = username
            // return info
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ImLivechatChannel> GetOperatorInternalAsync(Guid previous_operator_id, object lang, Guid country_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _get_operator(self, previous_operator_id=None, lang=None, country_id=None):
            // """ Return an operator for a livechat. Try to return the previous
            // operator if available. If not, one of the most available operators be
            // returned.
            // 
            // A livechat is considered 'active' if it has at least one message within
            // the 30 minutes. This method will try to match the given lang and
            // country_id.
            // 
            // (Some annoying conversions have to be made on the fly because this model
            // holds 'res.users' as available operators and the discuss_channel model
            // stores the partner_id of the randomly selected operator)
            // 
            // :param previous_operator_id: id of the previous operator with whom the
            //     visitor was chatting.
            // :param lang: code of the preferred lang of the visitor.
            // :param country_id: id of the country of the visitor.
            // :return : user
            // :rtype : res.users
            // """
            // if not self.available_operator_ids:
            //     return False
            // # FIXME: remove inactive call sessions so operators no longer in call are available
            // # sudo: required to use garbage collecting function.
            // self.env["discuss.channel.rtc.session"].sudo()._gc_inactive_sessions()
            // self.env.cr.execute("""
            //     WITH operator_rtc_session AS (
            //         SELECT COUNT(DISTINCT s.id) as nbr, member.partner_id as partner_id
            //           FROM discuss_channel_rtc_session s
            //           JOIN discuss_channel_member member ON (member.id = s.channel_member_id)
            //           GROUP BY member.partner_id
            //     )
            //     SELECT COUNT(DISTINCT c.id), COALESCE(rtc.nbr, 0) > 0 as in_call, c.livechat_operator_id
            //     FROM discuss_channel c
            //     LEFT OUTER JOIN mail_message m ON c.id = m.res_id AND m.model = 'discuss.channel'
            //     LEFT OUTER JOIN operator_rtc_session rtc ON rtc.partner_id = c.livechat_operator_id
            //     WHERE c.channel_type = 'livechat' AND c.create_date > ((now() at time zone 'UTC') - interval '24 hours')
            //     AND (
            //         c.livechat_active IS TRUE
            //         OR m.create_date > ((now() at time zone 'UTC') - interval '30 minutes')
            //     )
            //     AND c.livechat_operator_id in %s
            //     GROUP BY c.livechat_operator_id, rtc.nbr
            //     ORDER BY COUNT(DISTINCT c.id) < 2 OR rtc.nbr IS NULL DESC, COUNT(DISTINCT c.id) ASC, rtc.nbr IS NULL DESC""",
            //     (tuple(self.available_operator_ids.partner_id.ids),)
            // )
            // operator_statuses = self.env.cr.dictfetchall()
            // operator = None
            // # Try to match the previous operator
            // if previous_operator_id in self.available_operator_ids.partner_id.ids:
            //     previous_operator_status = next(
            //         (status for status in operator_statuses if status['livechat_operator_id'] == previous_operator_id),
            //         None
            //     )
            //     if not previous_operator_status or previous_operator_status['count'] < 2 or not previous_operator_status['in_call']:
            //         previous_operator_user = next(
            //             available_user
            //             for available_user in self.available_operator_ids
            //             if available_user.partner_id.id == previous_operator_id
            //         )
            //         return previous_operator_user
            // # Try to match an operator with the same main lang as the visitor
            // # If no operator with the same lang, try to match an operator with the addition lang
            // if lang:
            //     same_lang_operator_ids = self.available_operator_ids.filtered(lambda operator: operator.partner_id.lang == lang)
            //     if same_lang_operator_ids:
            //         operator = self._get_less_active_operator(operator_statuses, same_lang_operator_ids)
            //     else:
            //         addition_lang_operator_ids = self.available_operator_ids.filtered(lambda operator: lang in operator.res_users_settings_id.livechat_lang_ids.mapped('code'))
            //         if addition_lang_operator_ids:
            //             operator = self._get_less_active_operator(operator_statuses, addition_lang_operator_ids)
            // # Try to match an operator with the same country as the visitor
            // if country_id and not operator:
            //     same_country_operator_ids = self.available_operator_ids.filtered(lambda operator: operator.partner_id.country_id.id == country_id)
            //     if same_country_operator_ids:
            //         operator = self._get_less_active_operator(operator_statuses, same_country_operator_ids)
            // # Try to get a random operator, regardless of the lang or the country
            // if not operator:
            //     operator = self._get_less_active_operator(operator_statuses, self.available_operator_ids)
            // return operator
            */
            return default;
        }

        public async Task<ImLivechatChannel> JoinAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def action_join(self):
            // self.ensure_one()
            // self.user_ids = [Command.link(self.env.user.id)]
            // self.env.user._bus_send_store(self, fields=["are_you_inside", "name"])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ImLivechatChannel> QuitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def action_quit(self):
            // self.ensure_one()
            // self.user_ids = [Command.unlink(self.env.user.id)]
            // self.env.user._bus_send_store(self, fields=["are_you_inside", "name"])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ImLivechatChannel> ToStoreInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py) ---
            // def _to_store(self, store: Store, /, *, fields=None):
            // if fields is None:
            //     fields = []
            // store.add(self._name, self._read_format(fields))
            */
            return default;
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
            // action = self.env['ir.actions.act_window']._for_xml_id('im_livechat.rating_rating_action_livechat')
            // action['context'] = {'search_default_parent_res_name': self.name}
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}