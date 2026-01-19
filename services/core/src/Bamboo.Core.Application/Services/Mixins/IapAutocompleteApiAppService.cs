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
    [Module("partner_autocomplete", Category = "Misc", Depends = new[] { "iap_mail" })]
    public partial class IapAutocompleteApiAppService : ApplicationService, IIapAutocompleteApiAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IapAutocompleteApiAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ContactIapInternalAsync<TEntity>(IEnumerable<TEntity> entities, object local_endpoint, object action, object @params, object timeout) where TEntity : IEntity<Guid>, IIapAutocompleteApiable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: iap_autocomplete_api.py) ---
            // def _contact_iap(self, local_endpoint, action, params, timeout=15):
            // if modules.module.current_test:
            //     raise exceptions.ValidationError(_('Test mode'))
            // account = self.env['iap.account'].get('partner_autocomplete')
            // if not account.sudo().account_token:
            //     raise ValueError(_('No account token'))
            // params.update({
            //     'db_uuid': self.env['ir.config_parameter'].sudo().get_param('database.uuid'),
            //     'db_version': release.version,
            //     'db_lang': self.env.lang,
            //     'account_token': account.sudo().account_token,
            //     'country_code': self.env.company.country_id.code,
            //     'zip': self.env.company.zip,
            // })
            // base_url = self.env['ir.config_parameter'].sudo().get_param('iap.partner_autocomplete.endpoint', self._DEFAULT_ENDPOINT)
            // return iap_tools.iap_jsonrpc(base_url + local_endpoint + '/' + action, params=params, timeout=timeout)
            */
            return default;
        }

        public async Task<TEntity> RequestPartnerAutocompleteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object action, object @params, object timeout) where TEntity : IEntity<Guid>, IIapAutocompleteApiable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: iap_autocomplete_api.py) ---
            // def _request_partner_autocomplete(self, action, params, timeout=15):
            // """ Contact endpoint to get autocomplete data.
            // 
            // :returns: a 2-element tuple (results, error code)
            // :rtype: tuple[dict, Literal[False]] | tuple[Literal[False], str]
            // """
            // try:
            //     results = self._contact_iap('/api/dnb/1', action, params, timeout=timeout)
            // except exceptions.ValidationError:
            //     return False, 'Insufficient Credit'
            // except (ConnectionError, HTTPError, exceptions.AccessError, exceptions.UserError) as exception:
            //     _logger.warning('Autocomplete API error: %s', str(exception))
            //     return False, str(exception)
            // except iap_tools.InsufficientCreditError as exception:
            //     _logger.warning('Insufficient Credits for Autocomplete Service: %s', str(exception))
            //     return False, 'Insufficient Credit'
            // except ValueError:
            //     return False, 'No account token'
            // return results, False
            */
            return default;
        }
    }
}