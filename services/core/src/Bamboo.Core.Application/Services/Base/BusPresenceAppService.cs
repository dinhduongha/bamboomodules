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
    [Module("Bus", Category = "Base", Depends = new[] { "base", "web" })]
    public partial class BusPresenceAppService : GenericApplicationService<BusPresence>, IBusPresenceAppService
    {

        public BusPresenceAppService(IRepository<BusPresence, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<BusPresence> GcBusPresenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: bus_presence.py) ---
            // def _gc_bus_presence(self):
            // self.search(
            //     [("last_poll", "<", fields.Datetime.now() - timedelta(seconds=PRESENCE_OUTDATED_TIMER))]
            // ).unlink()
            */
            return default;
        }

        protected async Task<BusPresence> GetBusTargetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: bus_presence.py) ---
            // def _get_bus_target(self):
            // self.ensure_one()
            // return self.user_id.partner_id if self.user_id else None
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: bus_presence.py) ---
            // def _get_bus_target(self):
            // return self.guest_id or super()._get_bus_target()
            */
            return default;
        }

        protected async Task<BusPresence> GetIdentityDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: bus_presence.py) ---
            // def _get_identity_data(self):
            // self.ensure_one()
            // return {"partner_id": self.user_id.partner_id.id} if self.user_id else None
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: bus_presence.py) ---
            // def _get_identity_data(self):
            // self.ensure_one()
            // return {"guest_id": self.guest_id.id} if self.guest_id else super()._get_identity_data()
            */
            return default;
        }

        protected async Task<BusPresence> GetIdentityFieldNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: bus_presence.py) ---
            // def _get_identity_field_name(self):
            // self.ensure_one()
            // return "user_id" if self.user_id else None
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: bus_presence.py) ---
            // def _get_identity_field_name(self):
            // return "guest_id" if self.guest_id else super()._get_identity_field_name()
            */
            return default;
        }

        public async Task<BusPresence> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: bus_presence.py) ---
            // def init(self):
            // self.env.cr.execute("CREATE UNIQUE INDEX IF NOT EXISTS bus_presence_user_unique ON %s (user_id) WHERE user_id IS NOT NULL" % self._table)
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: bus_presence.py) ---
            // def init(self):
            // self.env.cr.execute("CREATE UNIQUE INDEX IF NOT EXISTS bus_presence_guest_unique ON %s (guest_id) WHERE guest_id IS NOT NULL" % self._table)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<BusPresence> InvalidateImStatusInternalAsync(object fnames, object flush)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: bus_presence.py) ---
            // def _invalidate_im_status(self):
            // self.user_id.invalidate_recordset(["im_status"])
            // self.user_id.partner_id.invalidate_recordset(["im_status"])
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: bus_presence.py) ---
            // def _invalidate_im_status(self, fnames=None, flush=True):
            // super()._invalidate_im_status()
            // self.guest_id.invalidate_recordset(["im_status"])
            */
            return default;
        }

        protected async Task<BusPresence> SendPresenceInternalAsync(object im_status, object bus_target)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: bus_presence.py) ---
            // def _send_presence(self, im_status=None, bus_target=None):
            // """Send notification related to bus presence update.
            // 
            // :param im_status: 'online', 'away' or 'offline'
            // """
            // for presence in self:
            //     identity_data = presence._get_identity_data()
            //     target = presence._get_bus_target()
            //     target = bus_target or (target and (target, "presence"))
            //     if identity_data and target:
            //         self.env["bus.bus"]._sendone(
            //             target,
            //             "bus.bus/im_status_updated",
            //             {
            //                 "presence_status": im_status or presence.status,
            //                 "im_status": presence._get_bus_target().im_status,
            //                 **identity_data
            //             },
            //         )
            */
            return default;
        }

        public async Task<BusPresence> UpdatePresenceAsync(Guid id, BusPresenceUpdatePresenceRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: bus_presence.py) ---
            // def update_presence(self, inactivity_period, identity_field, identity_value):
            // """ Updates the last_poll and last_presence of the current user
            //     :param inactivity_period: duration in milliseconds
            // """
            // # This method is called in method _poll() and cursor is closed right
            // # after; see bus/controllers/main.py.
            // try:
            //     # Hide transaction serialization errors, which can be ignored, the presence update is not essential
            //     # The errors are supposed from presence.write(...) call only
            //     with tools.mute_logger('odoo.sql_db'):
            //         self._update_presence(inactivity_period=inactivity_period, identity_field=identity_field, identity_value=identity_value)
            //         # commit on success
            //         self.env.cr.commit()
            // except PG_CONCURRENCY_EXCEPTIONS_TO_RETRY:
            //     # ignore concurrency error
            //     return self.env.cr.rollback()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<BusPresence> UpdatePresenceInternalAsync(object inactivity_period, object identity_field, object identity_value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: bus_presence.py) ---
            // def _update_presence(self, inactivity_period, identity_field, identity_value):
            // presence = self.search([(identity_field, "=", identity_value)])
            // values = {
            //     "last_poll": fields.Datetime.now(),
            //     "last_presence": fields.Datetime.now() - timedelta(milliseconds=inactivity_period),
            //     "status": "away" if inactivity_period > AWAY_TIMER * 1000 else "online",
            // }
            // if not presence:
            //     values[identity_field] = identity_value
            //     presence = self.create(values)
            // else:
            //     presence.write(values)
            */
            return default;
        }
    }
}