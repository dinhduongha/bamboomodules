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
    public class ResUsersApikeysDescriptionAppService : GenericApplicationService<ResUsersApikeysDescription>, IResUsersApikeysDescriptionAppService
    {

        public ResUsersApikeysDescriptionAppService(IRepository<ResUsersApikeysDescription, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<ResUsersApikeysDescription> CheckAccessMakeKeyAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: res_users_apikeys_description.py) ---
            // def check_access_make_key(self):
            // try:
            //     return super().check_access_make_key()
            // except AccessError:
            //     if self.env['ir.config_parameter'].sudo().get_param('portal.allow_api_keys'):
            //         if self.env.user._is_portal():
            //             return
            //         else:
            //             raise AccessError(_("Only internal and portal users can create API keys"))
            //     raise
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def check_access_make_key(self):
            // if not self.env.user._is_internal():
            //     raise AccessError(_("Only internal users can create API keys"))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsersApikeysDescription> ComputeExpirationDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _compute_expiration_date(self):
            // for record in self:
            //     duration = int(record.duration)
            //     if duration >= 0:
            //         record.expiration_date = (
            //             fields.Date.today() + datetime.timedelta(days=duration)
            //             if int(record.duration)
            //             else None
            //         )
            */
            return default;
        }

        public async Task<ResUsersApikeysDescription> MakeKeyAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def make_key(self):
            // # only create keys for users who can delete their keys
            // self.check_access_make_key()
            // 
            // description = self.sudo()
            // k = self.env['res.users.apikeys']._generate(None, description.name, self.expiration_date)
            // description.unlink()
            // 
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'res.users.apikeys.show',
            //     'name': _('API Key Ready'),
            //     'views': [(False, 'form')],
            //     'target': 'new',
            //     'context': {
            //         'default_key': k,
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsersApikeysDescription> OnchangeExpirationDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _onchange_expiration_date(self):
            // try:
            //     self.env['res.users.apikeys']._check_expiration_date(self.expiration_date)
            // except UserError as error:
            //     warning = {
            //         'type': 'notification',
            //         'title': _('The API key duration is not correct.'),
            //         'message': error.args[0]
            //     }
            //     return {'warning': warning}
            */
            return default;
        }

        protected async Task<ResUsersApikeysDescription> SelectionDurationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _selection_duration(self):
            // # duration value is a string representing the number of days.
            // durations = [
            //     ('1', '1 Day'),
            //     ('7', '1 Week'),
            //     ('30', '1 Month'),
            //     ('90', '3 Months'),
            //     ('180', '6 Months'),
            //     ('365', '1 Year'),
            // ]
            // persistent_duration = ('0', 'Persistent Key')  # Magic value to detect an infinite duration
            // custom_duration = ('-1', 'Custom Date')  # Will force the user to enter a date manually
            // if self.env.is_system():
            //     return durations + [persistent_duration, custom_duration]
            // max_duration = max(group.api_key_duration for group in self.env.user.groups_id) or 1.0
            // return list(filter(
            //     lambda duration: int(duration[0]) <= max_duration, durations
            // )) + [custom_duration]
            */
            return default;
        }
    }
}