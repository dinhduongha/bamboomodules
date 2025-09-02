using Bamboo.Core.Application.Contracts.DTOs;
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
    [Module("CrmIapMine", Depends = new[] { "iap_crm", "iap_mail" })]
    public class CrmIapLeadHelpersAppService : GenericApplicationService<CrmIapLeadHelpers>, ICrmIapLeadHelpersAppService
    {

        public CrmIapLeadHelpersAppService(IRepository<CrmIapLeadHelpers, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<CrmIapLeadHelpers> FindStateIdInternalAsync(object state_code, Guid country_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_helpers.py) ---
            // def _find_state_id(self, state_code, country_id):
            // state_id = self.env['res.country.state'].search([('code', '=', state_code), ('country_id', '=', country_id)])
            // if state_id:
            //     return state_id.id
            // return False
            */
            return default;
        }

        public async Task<CrmIapLeadHelpers> LeadValsFromResponseAsync(Guid id, CrmIapLeadHelpersLeadValsFromResponseRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_helpers.py) ---
            // def lead_vals_from_response(self, lead_type, team_id, tag_ids, user_id, company_data, people_data):
            // country_id = self.env['res.country'].search([('code', '=', company_data['country_code'])]).id
            // website_url = 'https://www.%s' % company_data['domain'] if company_data['domain'] else False
            // lead_vals = {
            //     # Lead vals from record itself
            //     'type': lead_type,
            //     'team_id': team_id,
            //     'tag_ids': [(6, 0, tag_ids)],
            //     'user_id': user_id,
            //     'reveal_id': company_data['clearbit_id'],
            //     # Lead vals from data
            //     'name': company_data['name'] or company_data['domain'],
            //     'partner_name': company_data['legal_name'] or company_data['name'],
            //     'email_from': next(iter(company_data.get('email', [])), ''),
            //     'phone': company_data['phone'] or (company_data['phone_numbers'] and company_data['phone_numbers'][0]) or '',
            //     'website': website_url,
            //     'street': company_data['location'],
            //     'city': company_data['city'],
            //     'zip': company_data['postal_code'],
            //     'country_id': country_id,
            //     'state_id': self._find_state_id(company_data['state_code'], country_id),
            // }
            // 
            // # If type is people then add first contact in lead data
            // if people_data:
            //     lead_vals.update({
            //         'contact_name': people_data[0]['full_name'],
            //         'email_from': people_data[0]['email'],
            //         'function': people_data[0]['title'],
            //     })
            // return lead_vals
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmIapLeadHelpers> NotifyNoMoreCreditAsync(Guid id, CrmIapLeadHelpersNotifyNoMoreCreditRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_helpers.py) ---
            // def notify_no_more_credit(self, service_name, model_name, notification_parameter):
            // """
            // Notify about the number of credit.
            // In order to avoid to spam people each hour, an ir.config_parameter is set
            // """
            // already_notified = self.env['ir.config_parameter'].sudo().get_param(notification_parameter, False)
            // if already_notified:
            //     return
            // mail_template = self.env.ref('crm_iap_mine.lead_generation_no_credits')
            // iap_account = self.env['iap.account'].search([('service_name', '=', service_name)], limit=1)
            // # Get the email address of the creators of the records
            // res = self.env[model_name].search_read([], ['create_uid'])
            // uids = set(r['create_uid'][0] for r in res if r.get('create_uid'))
            // res = self.env['res.users'].search_read([('id', 'in', list(uids))], ['email'])
            // emails = set(r['email'] for r in res if r.get('email'))
            // 
            // email_values = {
            //     'email_to': ','.join(emails)
            // }
            // mail_template.send_mail(iap_account.id, force_send=True, email_values=email_values)
            // self.env['ir.config_parameter'].sudo().set_param(notification_parameter, True)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}