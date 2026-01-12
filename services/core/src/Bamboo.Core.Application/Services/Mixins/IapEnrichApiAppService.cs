using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("iap", Category = "Misc", Depends = new[] { "web", "base_setup" })]
    public class IapEnrichApiAppService : ApplicationService, IIapEnrichApiAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IapEnrichApiAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ContactIapInternalAsync<TEntity>(IEnumerable<TEntity> entities, object local_endpoint, object @params) where TEntity : IEntity<Guid>, IIapEnrichApiable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: iap, FILE: iap_enrich_api.py) ---
            // def _contact_iap(self, local_endpoint, params):
            // account = self.env['iap.account'].get('reveal')
            // dbuuid = self.env['ir.config_parameter'].sudo().get_param('database.uuid')
            // params['account_token'] = account.sudo().account_token
            // params['dbuuid'] = dbuuid
            // base_url = self.env['ir.config_parameter'].sudo().get_param('enrich.endpoint', self._DEFAULT_ENDPOINT)
            // return iap_tools.iap_jsonrpc(base_url + local_endpoint, params=params, timeout=300)
            */
            return default;
        }

        public async Task<TEntity> RequestEnrichInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lead_emails) where TEntity : IEntity<Guid>, IIapEnrichApiable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: iap, FILE: iap_enrich_api.py) ---
            // def _request_enrich(self, lead_emails):
            // """ Contact endpoint to get enrichment data.
            // 
            // :param lead_emails: dict{lead_id: email}
            // :return: dict{lead_id: company data or False}
            // :raise: several errors, notably
            //   * InsufficientCreditError: {
            //     "credit": 4.0,
            //     "service_name": "reveal",
            //     "base_url": "https://iap.odoo.com/iap/1/credit",
            //     "message": "You don't have enough credits on your account to use this service."
            //     }
            // """
            // params = {
            //     'domains': lead_emails,
            // }
            // return self._contact_iap('/iap/clearbit/1/lead_enrichment_email', params=params)
            */
            return default;
        }
    }
}