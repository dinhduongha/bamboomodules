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
    [Module("Utm", Depends = new[] { "base", "web" })]
    public class UtmMediumAppService : GenericApplicationService<UtmMedium>, IUtmMediumAppService
    {

        public UtmMediumAppService(IRepository<UtmMedium, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<UtmMedium> FetchOrCreateUtmMediumInternalAsync(object name, object module)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: utm, FILE: utm_medium.py) ---
            // def _fetch_or_create_utm_medium(self, name, module='utm'):
            // try:
            //     return self.env.ref(f'{module}.utm_medium_{name}')
            // except ValueError:
            //     utm_medium = self.sudo().env['utm.medium'].create({
            //         'name': self.SELF_REQUIRED_UTM_MEDIUMS_REF.get(f'{module}.utm_medium_{name}', name)
            //     })
            //     self.sudo().env['ir.model.data'].create({
            //         'name': f'utm_medium_{name}',
            //         'module': module,
            //         'res_id': utm_medium.id,
            //         'model': 'utm.medium',
            //     })
            //     return utm_medium
            */
            return default;
        }

        public async Task<UtmMedium> SELFREQUIREDUTMMEDIUMSREFAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: utm.py) ---
            // def SELF_REQUIRED_UTM_MEDIUMS_REF(self):
            // return super().SELF_REQUIRED_UTM_MEDIUMS_REF | {"mass_mailing_sms.utm_medium_sms": "SMS"}
            --- ODOO METHOD SOURCE (MODULE: utm, FILE: utm_medium.py) ---
            // def SELF_REQUIRED_UTM_MEDIUMS_REF(self):
            // return {
            //     'utm.utm_medium_email': 'Email',
            //     'utm.utm_medium_direct': 'Direct',
            //     'utm.utm_medium_website': 'Website',
            //     'utm.utm_medium_twitter': 'X',
            //     'utm.utm_medium_facebook': 'Facebook',
            //     'utm.utm_medium_linkedin': 'LinkedIn'
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<UtmMedium> UnlinkExceptLinkedMailingsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: utm_medium.py) ---
            // def _unlink_except_linked_mailings(self):
            // """ Already handled by ondelete='restrict', but let's show a nice error message """
            // linked_mailings = self.env['mailing.mailing'].sudo().search([
            //     ('medium_id', 'in', self.ids)
            // ])
            // 
            // if linked_mailings:
            //     raise UserError(_(
            //         "You cannot delete these UTM Mediums as they are linked to the following mailings in "
            //         "Mass Mailing:\n%(mailing_names)s",
            //         mailing_names=', '.join(['"%s"' % subject for subject in linked_mailings.mapped('subject')])))
            */
            return default;
        }

        protected async Task<UtmMedium> UnlinkExceptUtmMediumRecordInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: utm, FILE: utm_medium.py) ---
            // def _unlink_except_utm_medium_record(self):
            // for medium in self.SELF_REQUIRED_UTM_MEDIUMS_REF:
            //     utm_medium = self.env.ref(medium, raise_if_not_found=False)
            //     if utm_medium and utm_medium in self:
            //         raise UserError(_(
            //             "Oops, you can't delete the Medium '%s'.\n"
            //             "Doing so would be like tearing down a load-bearing wall \u2014 not the best idea.",
            //             utm_medium.name
            //         ))
            */
            return default;
        }

        protected async Task<UtmMedium> UnlinkExceptUtmMediumSmsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: utm.py) ---
            // def _unlink_except_utm_medium_sms(self):
            // utm_medium_sms = self.env.ref('mass_mailing_sms.utm_medium_sms', raise_if_not_found=False)
            // if utm_medium_sms and utm_medium_sms in self:
            //     raise UserError(_(
            //         "The UTM medium '%s' cannot be deleted as it is used in some main "
            //         "functional flows, such as the SMS Marketing.",
            //         utm_medium_sms.name
            //     ))
            */
            return default;
        }
    }
}