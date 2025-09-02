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
    [Module("WebsiteCrmIapReveal", Depends = new[] { "iap_crm", "iap_mail", "crm_iap_mine", "website_crm" })]
    public class CrmRevealViewAppService : GenericApplicationService<CrmRevealView>, ICrmRevealViewAppService
    {

        public CrmRevealViewAppService(IRepository<CrmRevealView, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<CrmRevealView> CleanRevealViewsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_view.py) ---
            // def _clean_reveal_views(self):
            // """ Remove old views (> 1 month) """
            // weeks_valid = self.env['ir.config_parameter'].sudo().get_param('reveal.view_weeks_valid', DEFAULT_REVEAL_VIEW_WEEKS_VALID)
            // try:
            //     weeks_valid = int(weeks_valid)
            // except ValueError:
            //     weeks_valid = DEFAULT_REVEAL_VIEW_WEEKS_VALID
            // domain = []
            // domain.append(('reveal_state', '=', 'not_found'))
            // domain.append(('create_date', '<', fields.Datetime.to_string(datetime.date.today() - relativedelta(weeks=weeks_valid))))
            // self.search(domain).unlink()
            */
            return default;
        }

        protected async Task<CrmRevealView> CreateRevealViewInternalAsync(Guid website_id, object url, object ip_address, object country_code, object state_code, object rules_excluded)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_view.py) ---
            // def _create_reveal_view(self, website_id, url, ip_address, country_code, state_code, rules_excluded):
            // # we are avoiding reveal if reveal_view already created for this IP
            // rules = self.env['crm.reveal.rule']._match_url(website_id, url, country_code, state_code, rules_excluded)
            // if rules:
            //     query = """
            //             INSERT INTO crm_reveal_view (reveal_ip, reveal_rule_id, reveal_state, create_date)
            //             VALUES (%s, %s, 'to_process', now() at time zone 'UTC')
            //             ON CONFLICT DO NOTHING;
            //             """ * len(rules)
            //     params = []
            //     for rule in rules:
            //         params += [ip_address, rule['id']]
            //         rules_excluded.append(str(rule['id']))
            //     self.env.cr.execute(query, params)
            //     return rules_excluded
            // return False
            */
            return default;
        }

        public async Task<CrmRevealView> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_reveal_view.py) ---
            // def init(self):
            // self._cr.execute('SELECT indexname FROM pg_indexes WHERE indexname = %s', ('crm_reveal_view_ip_rule_id',))
            // if not self._cr.fetchone():
            //     self._cr.execute('CREATE UNIQUE INDEX crm_reveal_view_ip_rule_id ON crm_reveal_view (reveal_rule_id,reveal_ip)')
            // self._cr.execute('SELECT indexname FROM pg_indexes WHERE indexname = %s', ('crm_reveal_view_state_create_date',))
            // if not self._cr.fetchone():
            //     self._cr.execute('CREATE INDEX crm_reveal_view_state_create_date ON crm_reveal_view (reveal_state,create_date)')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}