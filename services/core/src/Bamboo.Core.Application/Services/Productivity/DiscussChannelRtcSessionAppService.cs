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
    public partial class DiscussChannelRtcSessionAppService : GenericAppService<DiscussChannelRtcSession>, IDiscussChannelRtcSessionAppService
    {
        private readonly IBusListenerMixinAppService _busListenerMixinAppService;
        public DiscussChannelRtcSessionAppService(IRepository<DiscussChannelRtcSession, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IBusListenerMixinAppService busListenerMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _busListenerMixinAppService = busListenerMixinAppService;
        }

        protected async Task<DiscussChannelRtcSession> BusChannelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py) ---
            // def _bus_channel(self):
            // return self.channel_member_id._bus_channel()
            */
            return default;
        }

        public override async Task<DiscussChannelRtcSession> CreateAsync(CreateRequestDto<DiscussChannelRtcSession> input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_rtc_session.py) ---
            // def create(self, vals_list):
            // rtc_sessions = super().create(vals_list)
            // for livechat_session in rtc_sessions.filtered(
            //     lambda s: s.channel_member_id.livechat_member_type in ("agent", "visitor")
            // ):
            //     call_history = livechat_session.channel_id.call_history_ids.sorted(
            //         lambda c: (c.create_date, c.id)
            //     )[-1]
            //     call_history.livechat_participant_history_ids |= (
            //         livechat_session.channel_member_id.livechat_member_history_ids
            //     )
            // return rtc_sessions
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py) ---
            // def create(self, vals_list):
            // rtc_sessions = super().create(vals_list)
            // rtc_sessions_by_channel = defaultdict(lambda: self.env["discuss.channel.rtc.session"])
            // for rtc_session in rtc_sessions:
            //     rtc_sessions_by_channel[rtc_session.channel_id] += rtc_session
            // for channel, rtc_sessions in rtc_sessions_by_channel.items():
            //     Store(bus_channel=channel).add(
            //         channel,
            //         {"rtc_session_ids": Store.Many(rtc_sessions, mode="ADD")},
            //     ).bus_send()
            // for channel in rtc_sessions.channel_id.filtered(lambda c: len(c.rtc_session_ids) == 1):
            //     body = Markup('<div data-oe-type="call" class="o_mail_notification"></div>')
            //     message = channel.message_post(body=body, message_type="notification")
            //     # sudo - discuss.call.history: can create call history when call is created.
            //     self.env["discuss.call.history"].sudo().create(
            //         {
            //             "channel_id": channel.id,
            //             "start_dt": fields.Datetime.now(),
            //             "start_call_message_id": message.id,
            //         },
            //     )
            //     Store(bus_channel=channel).add(message, [Store.Many("call_history_ids", [])]).bus_send()
            // return rtc_sessions
            */
            return await base.CreateAsync(input);
        }

        protected async Task<DiscussChannelRtcSession> DeleteInactiveRtcSessionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py) ---
            // def _delete_inactive_rtc_sessions(self):
            // """Deletes the inactive sessions from self."""
            // self.filtered_domain(self._inactive_rtc_session_domain()).unlink()
            */
            return default;
        }

        public async Task<DiscussChannelRtcSession> DisconnectAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py) ---
            // def action_disconnect(self):
            // session_ids_by_channel_by_url = defaultdict(lambda: defaultdict(list))
            // for rtc_session in self:
            //     sfu_channel_uuid = rtc_session.channel_id.sfu_channel_uuid
            //     url = rtc_session.channel_id.sfu_server_url
            //     if sfu_channel_uuid and url:
            //         session_ids_by_channel_by_url[url][sfu_channel_uuid].append(rtc_session.id)
            // key = discuss.get_sfu_key(self.env)
            // if key:
            //     with requests.Session() as requests_session:
            //         for url, session_ids_by_channel in session_ids_by_channel_by_url.items():
            //             try:
            //                 requests_session.post(
            //                     url + '/v1/disconnect',
            //                     data=jwt.sign({'sessionIdsByChannel': session_ids_by_channel}, key=key, ttl=20, algorithm=jwt.Algorithm.HS256),
            //                     timeout=3
            //                 ).raise_for_status()
            //             except requests.exceptions.RequestException as error:
            //                 _logger.warning("Could not disconnect sessions at sfu server %s: %s", url, error)
            // self.unlink()
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<DiscussChannelRtcSession> GcInactiveSessionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py) ---
            // def _gc_inactive_sessions(self):
            // """ Garbage collect sessions that aren't active anymore,
            //     this can happen when the server or the user's browser crash
            //     or when the user's odoo session ends.
            // """
            // self.search(self._inactive_rtc_session_domain()).unlink()
            */
            return default;
        }

        protected async Task<DiscussChannelRtcSession> GetStoreExtraFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py) ---
            // def _get_store_extra_fields(self):
            // return ["is_camera_on", "is_deaf", "is_muted", "is_screen_sharing_on"]
            */
            return default;
        }

        [ApiModel]
        protected async Task<DiscussChannelRtcSession> InactiveRtcSessionDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py) ---
            // def _inactive_rtc_session_domain(self):
            // return [('write_date', '<', fields.Datetime.now() - relativedelta(minutes=1, seconds=15))]
            */
            return default;
        }

        protected async Task<DiscussChannelRtcSession> NotifyPeersInternalAsync(object notifications)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py) ---
            // def _notify_peers(self, notifications):
            // """ Used for peer-to-peer communication,
            //     guarantees that the sender is the current guest or partner.
            // 
            //     :param notifications: list of tuple with the following elements:
            //         - target_session_ids: a list of discuss.channel.rtc.session ids
            //         - content: a string with the content to be sent to the targets
            // """
            // self.ensure_one()
            // payload_by_target = defaultdict(lambda: {'sender': self.id, 'notifications': []})
            // for target_session_ids, content in notifications:
            //     for target_session in self.env['discuss.channel.rtc.session'].browse(target_session_ids).exists():
            //         payload_by_target[target_session]['notifications'].append(content)
            // for target, payload in payload_by_target.items():
            //     target._bus_send("discuss.channel.rtc.session/peer_notification", payload)
            */
            return default;
        }

        protected async Task<DiscussChannelRtcSession> ToStoreDefaultsInternalAsync(object target)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py) ---
            // def _to_store_defaults(self, target):
            // return Store.One(
            //     "channel_member_id",
            //     [
            //         Store.One("channel_id", [], as_thread=True),
            //         *self.env["discuss.channel.member"]._to_store_persona("avatar_card"),
            //     ],
            // )
            */
            return default;
        }

        protected async Task<DiscussChannelRtcSession> UpdateAndBroadcastInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py) ---
            // def _update_and_broadcast(self, values):
            // """ Updates the session and notifies all members of the channel
            //     of the change.
            // """
            // valid_values = {'is_screen_sharing_on', 'is_camera_on', 'is_muted', 'is_deaf'}
            // self.write({key: values[key] for key in valid_values if key in values})
            // store = Store().add(self, extra_fields=self._get_store_extra_fields())
            // self.channel_id._bus_send(
            //     "discuss.channel.rtc.session/update_and_broadcast",
            //     {"data": store.get_result(), "channelId": self.channel_id.id},
            // )
            */
            return default;
        }
    }
}