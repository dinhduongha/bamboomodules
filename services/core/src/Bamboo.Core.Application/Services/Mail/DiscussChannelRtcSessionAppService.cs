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
    public class DiscussChannelRtcSessionAppService : GenericApplicationService<DiscussChannelRtcSession>, IDiscussChannelRtcSessionAppService
    {
        private readonly IBusListenerMixinAppService _busListenerMixinAppService;
        public DiscussChannelRtcSessionAppService(IRepository<DiscussChannelRtcSession, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IBusListenerMixinAppService busListenerMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
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

        public async Task<DiscussChannelRtcSession> DisconnectAsync(Guid id)
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
            var entity = await Repository.GetAsync(id); return entity;
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

        protected async Task<DiscussChannelRtcSession> InactiveRtcSessionDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py) ---
            // def _inactive_rtc_session_domain(self):
            // return [('write_date', '<', fields.Datetime.now() - relativedelta(minutes=1))]
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

        protected async Task<DiscussChannelRtcSession> ToStoreInternalAsync(object store, object extra)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: discuss_channel_rtc_session.py) ---
            // def _to_store(self, store: Store, extra=False):
            // for rtc_session in self:
            //     data = rtc_session._read_format([], load=False)[0]
            //     data["channelMember"] = Store.one(
            //         rtc_session.channel_member_id,
            //         fields={"channel": [], "persona": ["name", "im_status"]},
            //     )
            //     if extra:
            //         data.update(
            //             {
            //                 "isCameraOn": rtc_session.is_camera_on,
            //                 "isDeaf": rtc_session.is_deaf,
            //                 "isSelfMuted": rtc_session.is_muted,
            //                 "isScreenSharingOn": rtc_session.is_screen_sharing_on,
            //             }
            //         )
            //     store.add(rtc_session, data)
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
            // store = Store(self, extra=True)
            // self.channel_id._bus_send(
            //     "discuss.channel.rtc.session/update_and_broadcast",
            //     {"data": store.get_result(), "channelId": self.channel_id.id},
            // )
            */
            return default;
        }
    }
}