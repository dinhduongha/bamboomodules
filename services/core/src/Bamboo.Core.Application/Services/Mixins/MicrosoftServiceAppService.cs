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
    [Module("microsoft_account", Category = "Misc", Depends = new[] { "base_setup" })]
    public class MicrosoftServiceAppService : ApplicationService, IMicrosoftServiceAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public MicrosoftServiceAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> DoRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities, object uri, object @params, object headers, object method, object preuri, object timeout) where TEntity : IEntity<Guid>, IMicrosoftServiceable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_account, FILE: microsoft_service.py) ---
            // def _do_request(self, uri, params=None, headers=None, method='POST', preuri=DEFAULT_MICROSOFT_GRAPH_ENDPOINT, timeout=TIMEOUT):
            // """ Execute the request to Microsoft API. Return a tuple ('HTTP_CODE', 'HTTP_RESPONSE')
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
            //     urls.url_parse(url).host for url in (DEFAULT_MICROSOFT_TOKEN_ENDPOINT, DEFAULT_MICROSOFT_GRAPH_ENDPOINT)
            // ]
            // 
            // _logger.debug("Uri: %s - Type : %s - Headers: %s - Params : %s !" % (uri, method, headers, params))
            // 
            // ask_time = fields.Datetime.now()
            // try:
            //     if method.upper() in ('GET', 'DELETE'):
            //         res = requests.request(method.lower(), preuri + uri, headers=headers, params=params, timeout=timeout)
            //     elif method.upper() in ('POST', 'PATCH', 'PUT'):
            //         res = requests.request(method.lower(), preuri + uri, data=params, headers=headers, timeout=timeout)
            //     else:
            //         raise Exception(_('Method not supported [%s] not in [GET, POST, PUT, PATCH or DELETE]!', method))
            //     res.raise_for_status()
            //     status = res.status_code
            // 
            //     if int(status) in RESOURCE_NOT_FOUND_STATUSES:
            //         response = {}
            //     else:
            //         # Some answers return empty content
            //         response = res.content and res.json() or {}
            // 
            //     try:
            //         ask_time = datetime.strptime(res.headers.get('date'), "%a, %d %b %Y %H:%M:%S %Z")
            //     except:
            //         pass
            // except requests.HTTPError as error:
            //     if error.response.status_code in RESOURCE_NOT_FOUND_STATUSES:
            //         status = error.response.status_code
            //         response = {}
            //     else:
            //         _logger.exception("Bad microsoft request: %s!", error.response.content)
            //         raise error
            // return (status, response, ask_time)
            */
            return default;
        }

        public async Task<TEntity> GenerateRefreshTokenAsync<TEntity>(IEnumerable<TEntity> entities, object service, object authorization_code) where TEntity : IEntity<Guid>, IMicrosoftServiceable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_account, FILE: microsoft_service.py) ---
            // def generate_refresh_token(self, service, authorization_code):
            // """ Call Microsoft API to refresh the token, with the given authorization code
            //     :param service : the name of the microsoft service to actualize
            //     :param authorization_code : the code to exchange against the new refresh token
            //     :returns the new refresh token
            // """
            // ICP_sudo = self.env['ir.config_parameter'].sudo()
            // scope = self._get_calendar_scope()
            // 
            // # Get the Refresh Token From Microsoft And store it in ir.config_parameter
            // headers = {"Content-type": "application/x-www-form-urlencoded"}
            // data = {
            //     'client_id': self._get_microsoft_client_id(service),
            //     'redirect_uri': ICP_sudo.get_param('microsoft_redirect_uri'),
            //     'client_secret': _get_microsoft_client_secret(ICP_sudo, service),
            //     'scope': scope,
            //     'grant_type': "refresh_token"
            // }
            // try:
            //     req = requests.post(self._get_token_endpoint(), data=data, headers=headers, timeout=TIMEOUT)
            //     req.raise_for_status()
            //     content = req.json()
            // except requests.exceptions.RequestException as exc:
            //     error_msg = _("Something went wrong during your token generation. Maybe your Authorization Code is invalid or already expired")
            //     raise self.env['res.config.settings'].get_config_warning(error_msg) from exc
            // 
            // return content.get('refresh_token')
            */
            return default;
        }

        public async Task<TEntity> GetAuthEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftServiceable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_account, FILE: microsoft_service.py) ---
            // def _get_auth_endpoint(self):
            // return self.env["ir.config_parameter"].sudo().get_param('microsoft_account.auth_endpoint', DEFAULT_MICROSOFT_AUTH_ENDPOINT)
            */
            return default;
        }

        public async Task<TEntity> GetAuthorizeUriInternalAsync<TEntity>(IEnumerable<TEntity> entities, object from_url, object service, object scope, object redirect_uri) where TEntity : IEntity<Guid>, IMicrosoftServiceable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_account, FILE: microsoft_service.py) ---
            // def _get_authorize_uri(self, from_url, service, scope, redirect_uri):
            // """ This method return the url needed to allow this instance of Odoo to access to the scope
            //     of gmail specified as parameters
            // """
            // state = {
            //     'd': self.env.cr.dbname,
            //     's': service,
            //     'f': from_url,
            //     'u': self.env['ir.config_parameter'].sudo().get_param('database.uuid'),
            // }
            // 
            // get_param = self.env['ir.config_parameter'].sudo().get_param
            // 
            // encoded_params = urls.url_encode({
            //     'response_type': 'code',
            //     'client_id': self._get_microsoft_client_id(service),
            //     'state': json.dumps(state),
            //     'scope': scope,
            //     'redirect_uri': redirect_uri,
            //     'access_type': 'offline'
            // })
            // return "%s?%s" % (self._get_auth_endpoint(), encoded_params)
            */
            return default;
        }

        public async Task<TEntity> GetCalendarScopeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftServiceable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_account, FILE: microsoft_service.py) ---
            // def _get_calendar_scope(self):
            // return 'offline_access openid Calendars.ReadWrite'
            */
            return default;
        }

        public async Task<TEntity> GetMicrosoftClientIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service) where TEntity : IEntity<Guid>, IMicrosoftServiceable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_account, FILE: microsoft_service.py) ---
            // def _get_microsoft_client_id(self, service):
            // # client id is not a secret, and can be leaked without risk. e.g. in clear in authorize uri.
            // ICP = self.env['ir.config_parameter'].sudo()
            // return ICP.get_param('microsoft_%s_client_id' % service)
            */
            return default;
        }

        public async Task<TEntity> GetMicrosoftTokensInternalAsync<TEntity>(IEnumerable<TEntity> entities, object authorize_code, object service, object redirect_uri) where TEntity : IEntity<Guid>, IMicrosoftServiceable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_account, FILE: microsoft_service.py) ---
            // def _get_microsoft_tokens(self, authorize_code, service, redirect_uri):
            // """ Call Microsoft API to exchange authorization code against token, with POST request, to
            //     not be redirected.
            // """
            // ICP_sudo = self.env['ir.config_parameter'].sudo()
            // scope = self._get_calendar_scope()
            // 
            // headers = {"content-type": "application/x-www-form-urlencoded"}
            // data = {
            //     'code': authorize_code,
            //     'client_id': self._get_microsoft_client_id(service),
            //     'client_secret': _get_microsoft_client_secret(ICP_sudo, service),
            //     'grant_type': 'authorization_code',
            //     'scope': scope,
            //     'redirect_uri': redirect_uri
            // }
            // try:
            //     dummy, response, dummy = self._do_request(self._get_token_endpoint(), params=data, headers=headers, method='POST', preuri='')
            //     access_token = response.get('access_token')
            //     refresh_token = response.get('refresh_token')
            //     ttl = response.get('expires_in')
            //     return access_token, refresh_token, ttl
            // except requests.HTTPError:
            //     error_msg = _("Something went wrong during your token generation. Maybe your Authorization Code is invalid")
            //     raise self.env['res.config.settings'].get_config_warning(error_msg)
            */
            return default;
        }

        public async Task<TEntity> GetTokenEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftServiceable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_account, FILE: microsoft_service.py) ---
            // def _get_token_endpoint(self):
            // return self.env["ir.config_parameter"].sudo().get_param('microsoft_account.token_endpoint', DEFAULT_MICROSOFT_TOKEN_ENDPOINT)
            */
            return default;
        }

        public async Task<TEntity> RefreshMicrosoftTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service, object rtoken) where TEntity : IEntity<Guid>, IMicrosoftServiceable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_account, FILE: microsoft_service.py) ---
            // def _refresh_microsoft_token(self, service, rtoken):
            // """ Call Microsoft API to refresh the token, with the given authorization code
            //     :param service : the name of the microsoft service to actualize
            //     :param rtoken : the code to exchange against the new refresh token
            //     :returns the new refresh token
            // """
            // ICP_sudo = self.env['ir.config_parameter'].sudo()
            // 
            // headers = {"Content-type": "application/x-www-form-urlencoded"}
            // data = {
            //     'client_id': self._get_microsoft_client_id(service),
            //     'client_secret': _get_microsoft_client_secret(ICP_sudo, service),
            //     'grant_type': 'refresh_token',
            //     'refresh_token': rtoken,
            // }
            // dummy, response, dummy = self._do_request(
            //     DEFAULT_MICROSOFT_TOKEN_ENDPOINT,
            //     params=data,
            //     headers=headers,
            //     method='POST',
            //     preuri=''
            // )
            // return response.get('access_token'), response.get('expires_in')
            */
            return default;
        }
    }
}