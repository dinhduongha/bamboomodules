using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("google_account", Depends = new[] { "base_setup" })]
    public class GoogleServiceAppService : ApplicationService, IGoogleServiceAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public GoogleServiceAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> DoRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities, object uri, object @params, object headers, object method, object preuri, object timeout) where TEntity : IEntity<Guid>, IGoogleServiceable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_account, FILE: google_service.py) ---
            // def _do_request(self, uri, params=None, headers=None, method='POST', preuri=GOOGLE_API_BASE_URL, timeout=TIMEOUT):
            // """ Execute the request to Google API. Return a tuple ('HTTP_CODE', 'HTTP_RESPONSE')
            //     :param uri : the url to contact
            //     :param params : dict or already encoded parameters for the request to make
            //     :param headers : headers of request
            //     :param method : the method to use to make the request
            //     :param preuri : pre url to prepend to param uri.
            // """
            // if params is None:
            //     params = {}
            // if headers is None:
            //     headers = {}
            // 
            // assert urls.url_parse(preuri + uri).host in [
            //     urls.url_parse(url).host for url in (GOOGLE_TOKEN_ENDPOINT, GOOGLE_API_BASE_URL)
            // ]
            // 
            // # Remove client_secret key from logs
            // if isinstance(params, str):
            //     _log_params = json.loads(params) or {}
            // else:
            //     _log_params = (params or {}).copy()
            // if _log_params.get('client_secret'):
            //     _log_params['client_secret'] = str(_log_params['client_secret'])[0:4] + 'x' * 12
            // 
            // _logger.debug("Uri: %s - Type : %s - Headers: %s - Params : %s!", uri, method, headers, _log_params)
            // 
            // ask_time = fields.Datetime.now()
            // try:
            //     if method.upper() in ('GET', 'DELETE'):
            //         res = requests.request(method.lower(), preuri + uri, params=params, timeout=timeout)
            //     elif method.upper() in ('POST', 'PATCH', 'PUT'):
            //         res = requests.request(method.lower(), preuri + uri, data=params, headers=headers, timeout=timeout)
            //     else:
            //         raise Exception(_('Method not supported [%s] not in [GET, POST, PUT, PATCH or DELETE]!', method))
            //     res.raise_for_status()
            //     status = res.status_code
            // 
            //     if int(status) == 204:  # Page not found, no response
            //         response = False
            //     else:
            //         response = res.json()
            // 
            //     try:
            //         ask_time = datetime.strptime(res.headers.get('date', ''), "%a, %d %b %Y %H:%M:%S %Z")
            //     except ValueError:
            //         pass
            // except requests.HTTPError as error:
            //     if error.response.status_code in (204, 404):
            //         status = error.response.status_code
            //         response = ""
            //     else:
            //         _logger.exception("Bad google request : %s!", error.response.content)
            //         raise error
            // return (status, response, ask_time)
            */
            return default;
        }

        public async Task<TEntity> GetAuthorizeUriInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service, object scope, object redirect_uri, object state, object approval_prompt, object access_type) where TEntity : IEntity<Guid>, IGoogleServiceable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_account, FILE: google_service.py) ---
            // def _get_authorize_uri(self, service, scope, redirect_uri, state=None, approval_prompt=None, access_type=None):
            // """ This method return the url needed to allow this instance of Odoo to access to the scope
            //     of gmail specified as parameters
            // """
            // params = {
            //     'response_type': 'code',
            //     'client_id': self._get_client_id(service),
            //     'scope': scope,
            //     'redirect_uri': redirect_uri,
            // }
            // 
            // if state:
            //     params['state'] = state
            // 
            // if approval_prompt:
            //     params['approval_prompt'] = approval_prompt
            // 
            // if access_type:
            //     params['access_type'] = access_type
            // 
            // 
            // encoded_params = urls.url_encode(params)
            // return "%s?%s" % (GOOGLE_AUTH_ENDPOINT, encoded_params)
            */
            return default;
        }

        public async Task<TEntity> GetClientIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service) where TEntity : IEntity<Guid>, IGoogleServiceable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_account, FILE: google_service.py) ---
            // def _get_client_id(self, service):
            // # client id is not a secret, and can be leaked without risk. e.g. in clear in authorize uri.
            // ICP = self.env['ir.config_parameter'].sudo()
            // return ICP.get_param('google_%s_client_id' % service)
            */
            return default;
        }

        public async Task<TEntity> GetGoogleTokensInternalAsync<TEntity>(IEnumerable<TEntity> entities, object authorize_code, object service, object redirect_uri) where TEntity : IEntity<Guid>, IGoogleServiceable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_account, FILE: google_service.py) ---
            // def _get_google_tokens(self, authorize_code, service, redirect_uri):
            // """ Call Google API to exchange authorization code against token, with POST request, to
            //     not be redirected.
            // """
            // ICP = self.env['ir.config_parameter'].sudo()
            // 
            // headers = {"content-type": "application/x-www-form-urlencoded"}
            // data = {
            //     'code': authorize_code,
            //     'client_id': self._get_client_id(service),
            //     'client_secret': _get_client_secret(ICP, service),
            //     'grant_type': 'authorization_code',
            //     'redirect_uri': redirect_uri
            // }
            // try:
            //     dummy, response, dummy = self._do_request(GOOGLE_TOKEN_ENDPOINT, params=data, headers=headers, method='POST', preuri='')
            //     return response.get('access_token'), response.get('refresh_token'), response.get('expires_in')
            // except requests.HTTPError as e:
            //     _logger.error(e)
            //     error_msg = _("Something went wrong during your token generation. Maybe your Authorization Code is invalid or already expired")
            //     raise self.env['res.config.settings'].get_config_warning(error_msg)
            */
            return default;
        }

        public async Task<TEntity> RefreshGoogleTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service, object rtoken) where TEntity : IEntity<Guid>, IGoogleServiceable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_account, FILE: google_service.py) ---
            // def _refresh_google_token(self, service, rtoken):
            // ICP = self.env['ir.config_parameter'].sudo()
            // 
            // headers = {"content-type": "application/x-www-form-urlencoded"}
            // data = {
            //     'refresh_token': rtoken,
            //     'client_id': self._get_client_id(service),
            //     'client_secret': _get_client_secret(ICP, service),
            //     'grant_type': 'refresh_token',
            // }
            // dummy, response, dummy = self._do_request(GOOGLE_TOKEN_ENDPOINT, params=data, headers=headers, method='POST', preuri='')
            // return response.get('access_token'), response.get('expires_in')
            */
            return default;
        }
    }
}