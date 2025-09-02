using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("bus", Depends = new[] { "base", "web" })]
    public class IrWebsocketAppService : ApplicationService, IIrWebsocketAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IrWebsocketAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        protected async Task<object> AuthenticateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: ir_websocket.py) ---
            // def _authenticate(cls):
            // if wsrequest.session.uid is not None:
            //     if not security.check_session(wsrequest.session, wsrequest.env, wsrequest):
            //         wsrequest.session.logout(keep_db=True)
            //         raise SessionExpiredException()
            // else:
            //     public_user = wsrequest.env.ref('base.public_user')
            //     wsrequest.update_env(user=public_user.id)
            */
            return default;
        }

        public async Task<TEntity> BuildBusChannelListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object channels) where TEntity : IEntity<Guid>, IIrWebsocketable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: ir_websocket.py) ---
            // def _build_bus_channel_list(self, channels):
            // """
            //     Return the list of channels to subscribe to. Override this
            //     method to add channels in addition to the ones the client
            //     sent.
            // 
            //     :param channels: The channel list sent by the client.
            // """
            // req = request or wsrequest
            // channels.append('broadcast')
            // channels.extend(self.env.user.groups_id)
            // if req.session.uid:
            //     channels.append(self.env.user.partner_id)
            // return channels
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_websocket.py) ---
            // def _build_bus_channel_list(self, channels):
            // channels = list(channels)  # do not alter original list
            // discuss_channel_ids = list()
            // for channel in list(channels):
            //     if isinstance(channel, str) and channel.startswith("mail.guest_"):
            //         channels.remove(channel)
            //         guest = self.env["mail.guest"]._get_guest_from_token(channel.split("_")[1])
            //         if guest:
            //             self = self.with_context(guest=guest)
            //     if isinstance(channel, str):
            //         match = re.findall(r'discuss\.channel_(\d+)', channel)
            //         if match:
            //             channels.remove(channel)
            //             discuss_channel_ids.append(int(match[0]))
            // guest = self.env["mail.guest"]._get_guest_from_context()
            // if guest:
            //     channels.append(guest)
            // domain = ["|", ("is_member", "=", True), ("id", "in", discuss_channel_ids)]
            // all_user_channels = self.env["discuss.channel"].search(domain)
            // member_specific_channels = [(c, "members") for c in all_user_channels if c.id not in discuss_channel_ids]
            // channels.extend([*all_user_channels, *member_specific_channels])
            // return super()._build_bus_channel_list(channels)
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_websocket.py) ---
            // def _build_bus_channel_list(self, channels):
            // if self.env.uid:
            //     # Do not alter original list.
            //     channels = list(channels)
            //     for channel in channels:
            //         if isinstance(channel, str):
            //             match = re.match(r'editor_collaboration:(\w+(?:\.\w+)*):(\w+):(\d+)', channel)
            //             if match:
            //                 model_name = match[1]
            //                 field_name = match[2]
            //                 res_id = int(match[3])
            // 
            //                 # Verify access to the edition channel.
            //                 if self.env.user._is_public():
            //                     raise AccessDenied()
            // 
            //                 document = self.env[model_name].browse([res_id])
            //                 if not document.exists():
            //                     continue
            // 
            //                 document.check_access('read')
            //                 document.check_field_access_rights('read', [field_name])
            //                 document.check_access('write')
            //                 document.check_field_access_rights('write', [field_name])
            // 
            //                 channels.append((self.env.registry.db_name, 'editor_collaboration', model_name, field_name, res_id))
            // return super()._build_bus_channel_list(channels)
            */
            return default;
        }

        public async Task<TEntity> BuildPresenceChannelListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object presences) where TEntity : IEntity<Guid>, IIrWebsocketable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: ir_websocket.py) ---
            // def _build_presence_channel_list(self, presences):
            // """
            // Return the list of presences to subscribe to.
            // 
            // :param typing.List[typing.Tuple[str, int]] presences: The presence
            //     list sent by the client where the first element is the model
            //     name and the second is the record id.
            // """
            // channels = []
            // if self.env.user and self.env.user._is_internal():
            //     channels.extend(
            //         (partner, "presence")
            //         for partner in self.env["res.partner"]
            //         .with_context(active_test=False)
            //         .search([("id", "in", [int(p[1]) for p in presences if p[0] == "res.partner"])])
            //     )
            // return channels
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_websocket.py) ---
            // def _build_presence_channel_list(self, presences):
            // channels = super()._build_presence_channel_list(presences)
            // guest_ids = [int(p[1]) for p in presences if p[0] == "mail.guest"]
            // if self.env.user and self.env.user._is_internal():
            //     channels.extend(
            //         (guest, "presence")
            //         for guest in self.env["mail.guest"].search([("id", "in", guest_ids)])
            //     )
            //     # Partners already handled in super call (bus)
            //     return channels
            // self_discuss_channels = self.env["discuss.channel"]
            // if self.env.user and not self.env.user._is_public():
            //     self_discuss_channels = self.env.user.partner_id.channel_ids
            // elif guest := self.env["mail.guest"]._get_guest_from_context():
            //     # sudo - mail.guest: guest can access their own channels.
            //     self_discuss_channels = guest.sudo().channel_ids
            // partner_domain = [
            //     ("id", "in", [int(p[1]) for p in presences if p[0] == "res.partner"]),
            //     ("channel_ids", "in", self_discuss_channels.ids),
            // ]
            // # sudo - res.partner: allow access when sharing a common channel.
            // channels.extend(
            //     (partner, "presence")
            //     for partner in self.env["res.partner"].sudo().search(partner_domain)
            // )
            // guest_domain = [("id", "in", guest_ids), ("channel_ids", "in", self_discuss_channels.ids)]
            // # sudo - mail.guest: allow access when sharing a common channel.
            // channels.extend(
            //     (guest, "presence") for guest in self.env["mail.guest"].sudo().search(guest_domain)
            // )
            // return channels
            */
            return default;
        }

        public async Task<TEntity> GetMissedPresencesBusTargetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrWebsocketable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: ir_websocket.py) ---
            // def _get_missed_presences_bus_target(self):
            // return (
            //     self.env.user.partner_id if self.env.user and not self.env.user._is_public() else None
            // )
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_websocket.py) ---
            // def _get_missed_presences_bus_target(self):
            // if self.env.user and not self.env.user._is_public():
            //     return super()._get_missed_presences_bus_target()
            // if guest := self.env["mail.guest"]._get_guest_from_context():
            //     return guest
            // return None
            */
            return default;
        }

        public async Task<TEntity> GetMissedPresencesIdentityDomainsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object presence_channels) where TEntity : IEntity<Guid>, IIrWebsocketable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: ir_websocket.py) ---
            // def _get_missed_presences_identity_domains(self, presence_channels):
            // """
            // Return a list of domains that will be combined with `expression.OR` to
            // find presences related to `presence_channels`. This is used to find
            // missed presences when subscribing to presence channels.
            // 
            // :param typing.List[typing.Tuple[recordset, str]] presence_channels: The
            //     presence channels the user subscribed to.
            // """
            // partners = self.env["res.partner"].browse(
            //     [p.id for p, _ in presence_channels if isinstance(p, self.pool["res.partner"])]
            // )
            // # sudo: res.partner - can acess users of partner channels to find
            // # their presences as those channels were already verified during
            // # `_build_bus_channel_list`.
            // return [[("user_id", "in", partners.with_context(active_test=False).sudo().user_ids.ids)]]
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_websocket.py) ---
            // def _get_missed_presences_identity_domains(self, presence_channels):
            // identity_domain = super()._get_missed_presences_identity_domains(presence_channels)
            // if guest_ids := [
            //     g.id for g, _ in presence_channels if isinstance(g, self.pool["mail.guest"])
            // ]:
            //     identity_domain.append([("guest_id", "in", guest_ids)])
            // return identity_domain
            */
            return default;
        }

        public async Task<TEntity> OnWebsocketClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cookies) where TEntity : IEntity<Guid>, IIrWebsocketable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: ir_websocket.py) ---
            // def _on_websocket_closed(self, cookies):
            // if self.env.user and not self.env.user._is_public():
            //     self.env["bus.presence"].search([("user_id", "=", self.env.uid)]).status = "offline"
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_websocket.py) ---
            // def _on_websocket_closed(self, cookies):
            // super()._on_websocket_closed(cookies)
            // if self.env.user and not self.env.user._is_public():
            //     return
            // token = cookies.get(self.env["mail.guest"]._cookie_name, "")
            // if guest := self.env["mail.guest"]._get_guest_from_token(token):
            //     # sudo - bus.presence: guests can write their own presence
            //     self.env["bus.presence"].sudo().search([("guest_id", "=", guest.id)]).status = "offline"
            */
            return default;
        }

        public async Task<TEntity> PrepareSubscribeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object channels, object last) where TEntity : IEntity<Guid>, IIrWebsocketable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: ir_websocket.py) ---
            // def _prepare_subscribe_data(self, channels, last):
            // """
            // Parse the data sent by the client and return the list of channels,
            // missed presences and the last known notification id. This will be used
            // both by the websocket controller and the websocket request class when
            // the `subscribe` event is received.
            // 
            // :param typing.List[str] channels: List of channels to subscribe to sent
            //     by the client.
            // :param int last: Last known notification sent by the client.
            // 
            // :return:
            //     A dict containing the following keys:
            //     - channels (set of str): The list of channels to subscribe to.
            //     - last (int): The last known notification id.
            //     - missed_presences (odoo.models.Recordset): The missed presences.
            // 
            // :raise ValueError: If the list of channels is not a list of strings.
            // """
            // if not all(isinstance(c, str) for c in channels):
            //     raise ValueError("bus.Bus only string channels are allowed.")
            // # sudo - bus.bus: reading non-sensitive last bus id.
            // last = 0 if last > self.env["bus.bus"].sudo()._bus_last_id() else last
            // str_presence_channels = {
            //     c for c in channels if isinstance(c, str) and c.startswith("odoo-presence-")
            // }
            // presence_channels = self._build_presence_channel_list(
            //     [tuple(c.replace("odoo-presence-", "").split("_")) for c in str_presence_channels]
            // )
            // # There is a gap between a subscription client side (which is debounced)
            // # and the actual subcription thus presences can be missed. Send a
            // # notification to avoid missing presences during a subscription.
            // domain = expression.AND(
            //     [
            //         [("last_poll", ">", datetime.now() - timedelta(seconds=2))],
            //         expression.OR(self._get_missed_presences_identity_domains(presence_channels)),
            //     ]
            // )
            // # sudo: bus.presence: can access presences linked to presence channels.
            // missed_presences = self.env["bus.presence"].sudo().search(domain)
            // all_channels = OrderedSet(presence_channels)
            // all_channels.update(
            //     self._build_bus_channel_list([c for c in channels if c not in str_presence_channels])
            // )
            // return {"channels": all_channels, "last": last, "missed_presences": missed_presences}
            */
            return default;
        }

        public async Task<TEntity> SubscribeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object og_data) where TEntity : IEntity<Guid>, IIrWebsocketable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: ir_websocket.py) ---
            // def _subscribe(self, og_data):
            // data = self._prepare_subscribe_data(og_data["channels"], og_data["last"])
            // dispatch.subscribe(data["channels"], data["last"], self.env.registry.db_name, wsrequest.ws)
            // if bus_target := self._get_missed_presences_bus_target():
            //     data["missed_presences"]._send_presence(bus_target=bus_target)
            */
            return default;
        }

        public async Task<TEntity> UpdateBusPresenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object inactivity_period, object im_status_ids_by_model) where TEntity : IEntity<Guid>, IIrWebsocketable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: ir_websocket.py) ---
            // def _update_bus_presence(self, inactivity_period, im_status_ids_by_model):
            // if self.env.user and not self.env.user._is_public():
            //     self.env['bus.presence'].update_presence(
            //         inactivity_period,
            //         identity_field='user_id',
            //         identity_value=self.env.uid
            //     )
            --- ODOO METHOD SOURCE (MODULE: hr_presence, FILE: ir_websocket.py) ---
            // def _update_bus_presence(self, inactivity_period, im_status_ids_by_model):
            // super()._update_bus_presence(inactivity_period, im_status_ids_by_model)
            // #  This method can either be called due to an http or a
            // #  websocket request. The request itself is necessary to
            // #  retrieve the current guest. Let's retrieve the proper
            // #  request.
            // req = request or wsrequest
            // if req.env.user._is_internal():
            //     ip_address = req.httprequest.remote_addr
            //     users_log = req.env['res.users.log'].sudo().search_count([
            //         ('create_uid', '=', req.env.user.id),
            //         ('ip', '=', ip_address),
            //         ('create_date', '>=', Datetime.to_string(Datetime.now().replace(hour=0, minute=0, second=0, microsecond=0)))])
            //     if not users_log:
            //         with Registry(req.env.cr.dbname).cursor() as cr:
            //             env = Environment(cr, req.env.user.id, {})
            //             env['res.users.log'].sudo().create({'ip': ip_address})
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_websocket.py) ---
            // def _update_bus_presence(self, inactivity_period, im_status_ids_by_model):
            // super()._update_bus_presence(inactivity_period, im_status_ids_by_model)
            // if not self.env.user or self.env.user._is_public():
            //     guest = self.env["mail.guest"]._get_guest_from_context()
            //     if not guest:
            //         return
            //     # sudo: bus.presence - guests currently need sudo to write their own presence
            //     self.env["bus.presence"].sudo().update_presence(
            //         inactivity_period,
            //         identity_field="guest_id",
            //         identity_value=guest.id,
            //     )
            */
            return default;
        }
    }
}