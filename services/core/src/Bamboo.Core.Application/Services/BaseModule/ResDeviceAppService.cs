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
    [Module("BaseModule")]
    public class ResDeviceAppService : GenericApplicationService<ResDevice>, IResDeviceAppService
    {

        public ResDeviceAppService(IRepository<ResDevice, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<ResDevice> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_device.py) ---
            // def _compute_display_name(self):
            // for device in self:
            //     platform = device.platform or _("Unknown")
            //     browser = device.browser or _("Unknown")
            //     device.display_name = f"{platform.capitalize()} {browser.capitalize()}"
            */
            return default;
        }

        protected async Task<ResDevice> ComputeIsCurrentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_device.py) ---
            // def _compute_is_current(self):
            // for device in self:
            //     device.is_current = request and request.session.sid.startswith(device.session_identifier)
            */
            return default;
        }

        protected async Task<ResDevice> ComputeLinkedIpAddressesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_device.py) ---
            // def _compute_linked_ip_addresses(self):
            // device_group_map = {}
            // for *device_info, ip_array in self.env['res.device.log']._read_group(
            //     domain=[('session_identifier', 'in', self.mapped('session_identifier'))],
            //     groupby=['session_identifier', 'platform', 'browser'],
            //     aggregates=['ip_address:array_agg']
            // ):
            //     device_group_map[tuple(device_info)] = ip_array
            // for device in self:
            //     device.linked_ip_addresses = '\n'.join(
            //         OrderedSet(device_group_map.get(
            //             (device.session_identifier, device.platform, device.browser), []
            //         ))
            //     )
            */
            return default;
        }

        protected async Task<ResDevice> FromInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_device.py) ---
            // def _from(self):
            // return "FROM res_device_log D"
            */
            return default;
        }

        protected async Task<ResDevice> GcDeviceLogInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_device.py) ---
            // def _gc_device_log(self):
            // # Keep the last device log
            // # (even if the session file no longer exists on the filesystem)
            // self.env.cr.execute("""
            //     DELETE FROM res_device_log log1
            //     WHERE EXISTS (
            //         SELECT 1 FROM res_device_log log2
            //         WHERE
            //             log1.session_identifier = log2.session_identifier
            //             AND log1.platform = log2.platform
            //             AND log1.browser = log2.browser
            //             AND log1.ip_address = log2.ip_address
            //             AND log1.last_activity < log2.last_activity
            //     )
            // """)
            // _logger.info("GC device logs delete %d entries", self.env.cr.rowcount)
            */
            return default;
        }

        public async Task<ResDevice> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_device.py) ---
            // def init(self):
            // tools.drop_view_if_exists(self.env.cr, self._table)
            // self.env.cr.execute(SQL("""
            //     CREATE or REPLACE VIEW %s as (%s)
            // """,
            //     SQL.identifier(self._table),
            //     SQL(self._query)
            // ))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResDevice> IsMobileInternalAsync(object platform)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_device.py) ---
            // def _is_mobile(self, platform):
            // if not platform:
            //     return False
            // mobile_platform = ['android', 'iphone', 'ipad', 'ipod', 'blackberry', 'windows phone', 'webos']
            // return platform.lower() in mobile_platform
            */
            return default;
        }

        protected async Task<ResDevice> OrderFieldToSqlInternalAsync(object @alias, object field_name, object direction, object nulls, object query)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_device.py) ---
            // def _order_field_to_sql(self, alias, field_name, direction, nulls, query):
            // if field_name == 'is_current' and request:
            //     return SQL("session_identifier = %s DESC", request.session.sid[:42])
            // return super()._order_field_to_sql(alias, field_name, direction, nulls, query)
            */
            return default;
        }

        protected async Task<ResDevice> QueryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_device.py) ---
            // def _query(self):
            // return "%s %s %s" % (self._select(), self._from(), self._where())
            */
            return default;
        }

        public async Task<ResDevice> RevokeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_device.py) ---
            // def revoke(self):
            // return self._revoke()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResDevice> RevokeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_device.py) ---
            // def _revoke(self):
            // ResDeviceLog = self.env['res.device.log']
            // session_identifiers = list(unique(device.session_identifier for device in self))
            // root.session_store.delete_from_identifiers(session_identifiers)
            // revoked_devices = ResDeviceLog.sudo().search([('session_identifier', 'in', session_identifiers)])
            // revoked_devices.write({'revoked': True})
            // _logger.info("User %d revokes devices (%s)", self.env.uid, ', '.join(session_identifiers))
            // 
            // must_logout = bool(self.filtered('is_current'))
            // if must_logout:
            //     request.session.logout()
            */
            return default;
        }

        protected async Task<ResDevice> SelectInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_device.py) ---
            // def _select(self):
            // return "SELECT D.*"
            */
            return default;
        }

        protected async Task<ResDevice> UpdateDeviceInternalAsync(object request)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_device.py) ---
            // def _update_device(self, request):
            // """
            //     Must be called when we want to update the device for the current request.
            //     Passage through this method must leave a "trace" in the session.
            // 
            //     :param request: Request or WebsocketRequest object
            // """
            // trace = request.session.update_trace(request)
            // if not trace:
            //     return
            // 
            // geoip = GeoIP(trace['ip_address'])
            // user_id = request.session.uid
            // session_identifier = request.session.sid[:42]
            // 
            // if self.env.cr.readonly:
            //     self.env.cr.rollback()
            //     cursor = self.env.registry.cursor(readonly=False)
            // else:
            //     cursor = nullcontext(self.env.cr)
            // with cursor as cr:
            //     cr.execute(SQL("""
            //         INSERT INTO res_device_log (session_identifier, platform, browser, ip_address, country, city, device_type, user_id, first_activity, last_activity, revoked)
            //         VALUES (%(session_identifier)s, %(platform)s, %(browser)s, %(ip_address)s, %(country)s, %(city)s, %(device_type)s, %(user_id)s, %(first_activity)s, %(last_activity)s, %(revoked)s)
            //     """,
            //         session_identifier=session_identifier,
            //         platform=trace['platform'],
            //         browser=trace['browser'],
            //         ip_address=trace['ip_address'],
            //         country=geoip.get('country_name'),
            //         city=geoip.get('city'),
            //         device_type='mobile' if self._is_mobile(trace['platform']) else 'computer',
            //         user_id=user_id,
            //         first_activity=datetime.fromtimestamp(trace['first_activity']),
            //         last_activity=datetime.fromtimestamp(trace['last_activity']),
            //         revoked=False,
            //     ))
            // _logger.info("User %d inserts device log (%s)", user_id, session_identifier)
            */
            return default;
        }

        protected async Task<ResDevice> WhereInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_device.py) ---
            // def _where(self):
            // return """
            //     WHERE
            //         NOT EXISTS (
            //             SELECT 1
            //             FROM res_device_log D2
            //             WHERE
            //                 D2.user_id = D.user_id
            //                 AND D2.session_identifier = D.session_identifier
            //                 AND D2.platform IS NOT DISTINCT FROM D.platform
            //                 AND D2.browser IS NOT DISTINCT FROM D.browser
            //                 AND (
            //                     D2.last_activity > D.last_activity
            //                     OR (D2.last_activity = D.last_activity AND D2.id > D.id)
            //                 )
            //                 AND D2.revoked = False
            //         )
            //         AND D.revoked = False
            // """
            */
            return default;
        }
    }
}