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
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public partial class ResUsersSettingsVolumesAppService : GenericAppService<ResUsersSettingsVolumes>, IResUsersSettingsVolumesAppService
    {

        public ResUsersSettingsVolumesAppService(IRepository<ResUsersSettingsVolumes, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<ResUsersSettingsVolumes> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users_settings_volumes.py) ---
            // def _compute_display_name(self):
            // for rec in self:
            //     rec.display_name = f'{rec.user_setting_id.user_id.name} - {rec.partner_id.name or rec.guest_id.name}'
            */
            return default;
        }

        protected async Task<ResUsersSettingsVolumes> DiscussUsersSettingsVolumeFormatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users_settings_volumes.py) ---
            // def _discuss_users_settings_volume_format(self):
            // return [{
            //     'id': volume_setting.id,
            //     'volume': volume_setting.volume,
            //     'persona': {
            //         'id': volume_setting.partner_id.id if volume_setting.partner_id else volume_setting.guest_id.id,
            //         'name': volume_setting.partner_id.name if volume_setting.partner_id else volume_setting.guest_id.name,
            //         'type': "partner" if volume_setting.partner_id else "guest"
            //     },
            //     'user_setting_id': {
            //         'id': volume_setting.user_setting_id.id,
            //     },
            // } for volume_setting in self]
            */
            return default;
        }

        public async Task<ResUsersSettingsVolumes> InitAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users_settings_volumes.py) ---
            // def init(self):
            // self.env.cr.execute("CREATE UNIQUE INDEX IF NOT EXISTS res_users_settings_volumes_partner_unique ON %s (user_setting_id, partner_id) WHERE partner_id IS NOT NULL" % self._table)
            // self.env.cr.execute("CREATE UNIQUE INDEX IF NOT EXISTS res_users_settings_volumes_guest_unique ON %s (user_setting_id, guest_id) WHERE guest_id IS NOT NULL" % self._table)
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}