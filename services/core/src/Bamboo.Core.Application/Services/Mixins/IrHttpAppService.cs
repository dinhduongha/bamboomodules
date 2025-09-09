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
    [Module("base")]
    public class IrHttpAppService : ApplicationService, IIrHttpAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IrHttpAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> AddPublicKeyToSessionInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session_info) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_recaptcha, FILE: ir_http.py) ---
            // def _add_public_key_to_session_info(self, session_info):
            // """Add the ReCaptcha public key to the given session_info object"""
            // public_key = self.env['ir.config_parameter'].sudo().get_param('recaptcha_public_key')
            // if public_key:
            //     session_info['recaptcha_public_key'] = public_key
            // return session_info
            */
            return default;
        }

        protected async Task<object> AuthMethodBearerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _auth_method_bearer(cls):
            // headers = request.httprequest.headers
            // 
            // def get_http_authorization_bearer_token():
            //     # werkzeug<2.3 doesn't expose `authorization.token` (for bearer authentication)
            //     # check header directly
            //     header = headers.get("Authorization")
            //     if header and (m := re.match(r"^bearer\s+(.+)$", header, re.IGNORECASE)):
            //         return m.group(1)
            //     return None
            // 
            // def check_sec_headers():
            //     """Protection against CSRF attacks.
            //     Modern browsers automatically add Sec- headers that we can check to protect against CSRF.
            //     https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Sec-Fetch-User
            //     """
            //     return (
            //         headers.get("Sec-Fetch-Dest") == "document"
            //         and headers.get("Sec-Fetch-Mode") == "navigate"
            //         and headers.get("Sec-Fetch-Site") in ('none', 'same-origin')
            //         and headers.get("Sec-Fetch-User") == "?1"
            //     )
            // 
            // if token := get_http_authorization_bearer_token():
            //     # 'rpc' scope does not really exist, we basically require a global key (scope NULL)
            //     uid = request.env['res.users.apikeys']._check_credentials(scope='rpc', key=token)
            //     if not uid:
            //         raise werkzeug.exceptions.Unauthorized(
            //             "Invalid apikey",
            //             www_authenticate=werkzeug.datastructures.WWWAuthenticate('bearer'))
            //     if request.env.uid and request.env.uid != uid:
            //         raise AccessDenied("Session user does not match the used apikey")
            //     request.update_env(user=uid)
            // elif not request.env.uid:
            //     raise werkzeug.exceptions.Unauthorized(
            //         'User not authenticated, use the "Authorization" header',
            //         www_authenticate=werkzeug.datastructures.WWWAuthenticate('bearer'))
            // elif not check_sec_headers():
            //     raise AccessDenied("Missing \"Authorization\" or Sec-headers for interactive usage")
            // cls._auth_method_user()
            */
            return default;
        }

        protected async Task<object> AuthMethodCalendarInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: ir_http.py) ---
            // def _auth_method_calendar(cls):
            // token = request.httprequest.args.get('token', '')
            // 
            // error_message = False
            // 
            // attendee = request.env['calendar.attendee'].sudo().search([('access_token', '=', token)], limit=1)
            // if not attendee:
            //     error_message = """Invalid Invitation Token."""
            // elif request.session.uid and request.session.login != 'anonymous':
            //     # if valid session but user is not match
            //     user = request.env['res.users'].sudo().browse(request.session.uid)
            //     if attendee.partner_id != user.partner_id:
            //         error_message = """Invitation cannot be forwarded via email. This event/meeting belongs to %s and you are logged in as %s. Please ask organizer to add you.""" % (attendee.email, user.email)
            // if error_message:
            //     raise BadRequest(error_message)
            // 
            // cls._auth_method_public()
            */
            return default;
        }

        protected async Task<object> AuthMethodNoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _auth_method_none(cls):
            // request.env = api.Environment(request.env.cr, None, request.env.context)
            */
            return default;
        }

        protected async Task<object> AuthMethodOutlookInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_plugin, FILE: ir_http.py) ---
            // def _auth_method_outlook(cls):
            // access_token = request.httprequest.headers.get('Authorization')
            // if not access_token:
            //     raise BadRequest('Access token missing')
            // 
            // if access_token.startswith('Bearer '):
            //     access_token = access_token[7:]
            // 
            // user_id = request.env["res.users.apikeys"]._check_credentials(scope='odoo.plugin.outlook', key=access_token)
            // if not user_id:
            //     raise BadRequest('Access token invalid')
            // 
            // # take the identity of the API key user
            // request.update_env(user=user_id)
            // 
            // # switch to the user context
            // request.update_context(**request.env.user.context_get())
            */
            return default;
        }

        protected async Task<object> AuthMethodPublicInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _auth_method_public(cls):
            // """ If no user logged, set the public user of current website, or default
            //     public user as request uid.
            // """
            // if not request.session.uid:
            //     website = request.env(user=SUPERUSER_ID)['website'].with_context(lang='en_US').get_current_website()  # sudo
            //     if website:
            //         request.update_env(user=website._get_cached('user_id'))
            // 
            // if not request.uid:
            //     super()._auth_method_public()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _auth_method_public(cls):
            // if request.env.uid is None:
            //     public_user = request.env.ref('base.public_user')
            //     request.update_env(user=public_user.id)
            */
            return default;
        }

        protected async Task<object> AuthMethodUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _auth_method_user(cls):
            // if request.env.uid in [None] + cls._get_public_users():
            //     raise http.SessionExpiredException("Session expired")
            */
            return default;
        }

        protected async Task<object> AuthenticateExplicitInternalAsync(object auth)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _authenticate_explicit(cls, auth):
            // try:
            //     if request.session.uid is not None:
            //         if not security.check_session(request.session, request.env, request):
            //             request.session.logout(keep_db=True)
            //             request.env = api.Environment(request.env.cr, None, request.session.context)
            //     getattr(cls, f'_auth_method_{auth}')()
            // except (AccessDenied, http.SessionExpiredException, werkzeug.exceptions.HTTPException):
            //     raise
            // except Exception:
            //     _logger.info("Exception during request Authentication.", exc_info=True)
            //     raise AccessDenied()
            */
            return default;
        }

        protected async Task<object> AuthenticateInternalAsync(object endpoint)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _authenticate(cls, endpoint):
            // auth = 'none' if http.is_cors_preflight(request, endpoint) else endpoint.routing['auth']
            // cls._authenticate_explicit(auth)
            */
            return default;
        }

        protected async Task<object> DispatchInternalAsync(object endpoint)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _dispatch(cls, endpoint):
            // result = endpoint(**request.params)
            // if isinstance(result, Response) and result.is_qweb:
            //     result.flatten()
            // return result
            */
            return default;
        }

        protected async Task<object> FrontendPreDispatchInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def _frontend_pre_dispatch(cls):
            // request.update_context(lang=request.lang.code)
            // if request.cookies.get('frontend_lang') != request.lang.code:
            //     request.future_response.set_cookie('frontend_lang', request.lang.code)
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _frontend_pre_dispatch(cls):
            // super()._frontend_pre_dispatch()
            // 
            // if not request.context.get('tz'):
            //     with contextlib.suppress(pytz.UnknownTimeZoneError):
            //         request.update_context(tz=pytz.timezone(request.geoip.location.time_zone).zone)
            // 
            // website = request.env['website'].get_current_website()
            // user = request.env.user
            // 
            // # This is mainly to avoid access errors in website controllers
            // # where there is no context (eg: /shop), and it's not going to
            // # propagate to the global context of the tab. If the company of
            // # the website is not in the allowed companies of the user, set
            // # the main company of the user.
            // website_company_id = website._get_cached('company_id')
            // if user.id == website._get_cached('user_id'):
            //     # avoid a read on res_company_user_rel in case of public user
            //     allowed_company_ids = [website_company_id]
            // elif website_company_id in user._get_company_ids():
            //     allowed_company_ids = [website_company_id]
            // else:
            //     allowed_company_ids = user.company_id.ids
            // 
            // request.update_context(
            //     allowed_company_ids=allowed_company_ids,
            //     website_id=website.id,
            //     **cls._get_web_editor_context(),
            // )
            // 
            // request.website = website.with_context(request.context)
            */
            return default;
        }

        public async Task<TEntity> GcSessionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _gc_sessions(self):
            // if os.getenv("ODOO_SKIP_GC_SESSIONS"):
            //     return
            // http.root.session_store.vacuum(max_lifetime=http.get_session_max_inactivity(self.env))
            */
            return default;
        }

        public async Task<TEntity> GenerateRoutingRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object modules, object converters) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _generate_routing_rules(self, modules, converters):
            // if not request:
            //     yield from super()._generate_routing_rules(modules, converters)
            //     return
            // website_id = request.website_routing
            // logger.debug("_generate_routing_rules for website: %s", website_id)
            // rewrites = self._get_rewrites(website_id)
            // self._rewrite_len.__cache__.add_value(self, website_id, cache_value=len(rewrites))
            // 
            // for url, endpoint in super()._generate_routing_rules(modules, converters):
            //     if url in rewrites:
            //         rewrite = rewrites[url]
            //         url_to = rewrite.url_to
            //         if rewrite.redirect_type == '308':
            //             logger.debug('Add rule %s for %s' % (url_to, website_id))
            //             yield url_to, endpoint  # yield new url
            // 
            //             if url != url_to:
            //                 logger.debug('Redirect from %s to %s for website %s' % (url, url_to, website_id))
            //                 # duplicate the endpoint to only register the redirect_to for this specific url
            //                 redirect_endpoint = functools.partial(endpoint)
            //                 functools.update_wrapper(redirect_endpoint, endpoint)
            //                 _slug_matching = functools.partial(self._slug_matching, endpoint=endpoint)
            //                 redirect_endpoint.routing = dict(endpoint.routing, redirect_to=_slug_matching)
            //                 yield url, redirect_endpoint  # yield original redirected to new url
            //         elif rewrite.redirect_type == '404':
            //             logger.debug('Return 404 for %s for website %s' % (url, website_id))
            //             continue
            //     else:
            //         yield url, endpoint
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _generate_routing_rules(self, modules, converters):
            // return http._generate_routing_rules(modules, False, converters)
            */
            return default;
        }

        protected async Task<object> GeoipResolveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _geoip_resolve(cls):
            // return request._geoip_resolve()
            */
            return default;
        }

        protected async Task<object> GetConvertersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def _get_converters(cls) -> dict[str, type]:
            // """ Get the converters list for custom url pattern werkzeug need to
            //     match Rule. This override adds the website ones.
            // """
            // return dict(
            //     super(IrHttp, cls)._get_converters(),
            //     model=ModelConverter,
            // )
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _get_converters(cls) -> dict[str, type]:
            // """ Get the converters list for custom url pattern werkzeug need to
            //     match Rule. This override adds the website ones.
            // """
            // return dict(
            //     super()._get_converters(),
            //     model=ModelConverter,
            // )
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _get_converters(cls) -> dict[str, type]:
            // return {'model': ModelConverter, 'models': ModelsConverter, 'int': SignedIntConverter}
            */
            return default;
        }

        public async Task<TEntity> GetCurrenciesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_http.py) ---
            // def get_currencies(self):
            // Currency = self.env['res.currency']
            // currencies = Currency.search_fetch([], ['symbol', 'position', 'decimal_places'])
            // return {
            //     c.id: {'symbol': c.symbol, 'position': c.position, 'digits': [69, c.decimal_places]}
            //     for c in currencies
            // }
            */
            return default;
        }

        protected async Task<object> GetDefaultLangInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def _get_default_lang(cls) -> LangData:
            // lang_code = request.env['ir.default'].sudo()._get('res.partner', 'lang')
            // if lang_code:
            //     return request.env['res.lang']._get_data(code=lang_code)
            // return next(iter(request.env['res.lang']._get_active_by('code').values()))
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _get_default_lang(cls):
            // if getattr(request, 'is_frontend', True):
            //     website = request.env['website'].sudo().get_current_website()
            //     return request.env['res.lang']._get_data(id=website._get_cached('default_lang_id'))
            // return super()._get_default_lang()
            */
            return default;
        }

        protected async Task<object> GetErrorHtmlInternalAsync(object env, object code, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def _get_error_html(cls, env, code, values):
            // return code, env['ir.ui.view']._render_template('http_routing.%s' % code, values)
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _get_error_html(cls, env, code, values):
            // if code in ('page_404', 'protected_403'):
            //     return code.split('_')[1], env['ir.ui.view']._render_template('website.%s' % code, values)
            // return super()._get_error_html(env, code, values)
            */
            return default;
        }

        protected async Task<object> GetExceptionCodeValuesInternalAsync(object exception)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def _get_exception_code_values(cls, exception):
            // """ Return a tuple with the error code following by the values matching the exception"""
            // code = 500  # default code
            // values = dict(
            //     exception=exception,
            //     traceback=traceback.format_exc(),
            // )
            // if isinstance(exception, exceptions.AccessDenied):
            //     code = 403
            // elif isinstance(exception, exceptions.UserError):
            //     values['error_message'] = exception.args[0]
            //     code = 400
            //     if isinstance(exception, exceptions.AccessError):
            //         code = 403
            // 
            // elif isinstance(exception, QWebException):
            //     values.update(qweb_exception=exception)
            // 
            //     if isinstance(exception.__context__, exceptions.UserError):
            //         code = 400
            //         values['error_message'] = exception.__context__.args[0]
            //         if isinstance(exception.__context__, exceptions.AccessError):
            //             code = 403
            // 
            // elif isinstance(exception, werkzeug.exceptions.HTTPException):
            //     code = exception.code
            // 
            // values.update(
            //     status_message=werkzeug.http.HTTP_STATUS_CODES.get(code, ''),
            //     status_code=code,
            // )
            // 
            // return (code, values)
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _get_exception_code_values(cls, exception):
            // code, values = super()._get_exception_code_values(exception)
            // if isinstance(exception, werkzeug.exceptions.NotFound) and request.env.user.has_group('website.group_website_designer'):
            //     code = 'page_404'
            //     values['path'] = request.httprequest.path[1:]
            // if isinstance(exception, werkzeug.exceptions.Forbidden) and \
            //    exception.description == "website_visibility_password_required":
            //     code = 'protected_403'
            //     values['path'] = request.httprequest.path
            // return (code, values)
            */
            return default;
        }

        public async Task<TEntity> GetFrontendSessionInfoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: ir_http.py) ---
            // def get_frontend_session_info(self):
            // session_info = super().get_frontend_session_info()
            // session_info["websocket_worker_version"] = WebsocketConnectionHandler._VERSION
            // return session_info
            --- ODOO METHOD SOURCE (MODULE: google_recaptcha, FILE: ir_http.py) ---
            // def get_frontend_session_info(self):
            // frontend_session_info = super().get_frontend_session_info()
            // return self._add_public_key_to_session_info(frontend_session_info)
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def get_frontend_session_info(self) -> dict:
            // session_info = super(IrHttp, self).get_frontend_session_info()
            // 
            // IrHttpModel = request.env['ir.http'].sudo()
            // modules = IrHttpModel.get_translation_frontend_modules()
            // user_context = request.session.context if request.session.uid else {}
            // lang = user_context.get('lang')
            // translation_hash = request.env['ir.http'].get_web_translations_hash(modules, lang)
            // 
            // session_info.update({
            //     'translationURL': '/website/translations',
            //     'cache_hashes': {
            //         'translations': translation_hash,
            //     },
            // })
            // return session_info
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_http.py) ---
            // def get_frontend_session_info(self):
            // user = self.env.user
            // session_uid = request.session.uid
            // session_info = {
            //     'is_admin': user._is_admin() if session_uid else False,
            //     'is_system': user._is_system() if session_uid else False,
            //     'is_public': user._is_public(),
            //     "is_internal_user": user._is_internal(),
            //     'is_website_user': user._is_public() if session_uid else False,
            //     'uid': session_uid,
            //     'is_frontend': True,
            //     'profile_session': request.session.profile_session,
            //     'profile_collectors': request.session.profile_collectors,
            //     'profile_params': request.session.profile_params,
            //     'show_effect': bool(request.env['ir.config_parameter'].sudo().get_param('base_setup.show_effect')),
            //     'currencies': self.get_currencies(),
            //     'quick_login': str2bool(request.env['ir.config_parameter'].sudo().get_param('web.quick_login', default=True), True),
            //     'bundle_params': {
            //         'lang': request.session.context['lang'],
            //     },
            //     'test_mode': bool(config['test_enable'] or config['test_file']),
            // }
            // if request.session.debug:
            //     session_info['bundle_params']['debug'] = request.session.debug
            // if session_uid:
            //     version_info = odoo.service.common.exp_version()
            //     session_info.update({
            //         'server_version': version_info.get('server_version'),
            //         'server_version_info': version_info.get('server_version_info')
            //     })
            // return session_info
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def get_frontend_session_info(self):
            // session_info = super(Http, self).get_frontend_session_info()
            // geoip_country_code = request.geoip.country_code
            // geoip_phone_code = request.env['res.country']._phone_code_for(geoip_country_code) if geoip_country_code else None
            // session_info.update({
            //     'is_website_user': request.env.user.id == request.website.user_id.id,
            //     'geoip_country_code': geoip_country_code,
            //     'geoip_phone_code': geoip_phone_code,
            //     'lang_url_code': request.lang.url_code,
            // })
            // if request.env.user.has_group('website.group_website_restricted_editor'):
            //     session_info.update({
            //         'website_id': request.website.id,
            //         'website_company_id': request.website._get_cached('company_id'),
            //     })
            // session_info['bundle_params']['website_id'] = request.website.id
            // return session_info
            --- ODOO METHOD SOURCE (MODULE: website_cf_turnstile, FILE: ir_http.py) ---
            // def get_frontend_session_info(self):
            // """Add the Turnstile public key to the given session_info object"""
            // session = super().get_frontend_session_info()
            // 
            // site_key = self.env['ir.config_parameter'].sudo().get_param('cf.turnstile_site_key')
            // if site_key:
            //     session['turnstile_site_key'] = site_key
            // 
            // return session
            */
            return default;
        }

        public async Task<TEntity> GetNearestLangAsync<TEntity>(IEnumerable<TEntity> entities, object lang_code) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def get_nearest_lang(self, lang_code: str) -> str:
            // """ Try to find a similar lang. Eg: fr_BE and fr_FR
            //     :param lang_code: the lang `code` (en_US)
            // """
            // if not lang_code:
            //     return None
            // 
            // frontend_langs = self.env['res.lang']._get_frontend()
            // if lang_code in frontend_langs:
            //     return lang_code
            // 
            // short = lang_code.partition('_')[0]
            // if not short:
            //     return None
            // return next((code for code in frontend_langs if code.startswith(short)), None)
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: ir_http.py) ---
            // def get_nearest_lang(self, lang_code: str) -> str:
            // if not lang_code:
            //     return super().get_nearest_lang(lang_code)
            // 
            // referer_url = request.httprequest.headers.get('Referer', '')
            // path = request.httprequest.path
            // 
            // if '/pos-self/' in path:
            //     path_with_config = path
            // elif '/website/translations' in path and '/pos-self/' in referer_url:
            //     path_with_config = referer_url
            // else:
            //     path_with_config = None
            // 
            // if path_with_config:
            //     config_id_match = re.search(r'/pos-self(?:/data)?/(\d+)', path_with_config)
            //     if config_id_match:
            //         pos_config = request.env['pos.config'].sudo().browse(int(config_id_match[1]))
            //         if pos_config.self_ordering_available_language_ids:
            //             self_order_langs = pos_config.self_ordering_available_language_ids.mapped('code')
            //             if lang_code in self_order_langs:
            //                 return lang_code
            //             short_code = lang_code.partition('_')[0]
            //             matched_code = next((code for code in self_order_langs if code.startswith(short_code)), None)
            //             if matched_code:
            //                 return matched_code
            // 
            // return super().get_nearest_lang(lang_code)
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def get_nearest_lang(self, lang_code):
            // # get_nearest_lang() is used by @http_routing:IrHttp._match
            // # where is_frontend is not yet set and when no backend endpoint
            // # matched. We have to assume we are going to match a frontend
            // # route, hence the default True. Elsewhere, request.is_frontend
            // # is set.
            // website_id = False
            // if getattr(request, 'is_frontend', True):
            //     website_id = self.env.get('website_id', request.website_routing)
            // return super(Http, self.with_context(website_id=website_id)).get_nearest_lang(lang_code)
            */
            return default;
        }

        protected async Task<object> GetPublicUsersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _get_public_users(cls):
            // public_users = super()._get_public_users()
            // website = request.env(user=SUPERUSER_ID)['website'].with_context(lang='en_US').get_current_website()  # sudo
            // if website:
            //     public_users.append(website._get_cached('user_id'))
            // return public_users
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _get_public_users(cls):
            // return [request.env['ir.model.data']._xmlid_to_res_model_res_id('base.public_user')[1]]
            */
            return default;
        }

        public async Task<TEntity> GetRewritesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid website_id) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _get_rewrites(self, website_id):
            // domain = [('redirect_type', 'in', ('308', '404')), '|', ('website_id', '=', False), ('website_id', '=', website_id)]
            // return  {x.url_from: x for x in self.env['website.rewrite'].sudo().search(domain)}
            */
            return default;
        }

        public async Task<TEntity> GetTimesheetUomsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: ir_http.py) ---
            // def get_timesheet_uoms(self):
            // company_ids = self.env.user.company_ids
            // uom_ids = company_ids.mapped('timesheet_encode_uom_id') | \
            //           company_ids.mapped('project_time_mode_id')
            // return {
            //     uom.id:
            //         {
            //             'id': uom.id,
            //             'name': uom.name,
            //             'rounding': uom.rounding,
            //             'timesheet_widget': uom.timesheet_widget,
            //         } for uom in uom_ids
            // }
            */
            return default;
        }

        public async Task<List<string>> GetTranslationFrontendModulesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def get_translation_frontend_modules(self) -> list[str]:
            // Modules = request.env['ir.module.module'].sudo()
            // extra_modules_domain = self._get_translation_frontend_modules_domain()
            // extra_modules_name = self._get_translation_frontend_modules_name()
            // if extra_modules_domain:
            //     new = Modules.search(
            //         expression.AND([extra_modules_domain, [('state', '=', 'installed')]])
            //     ).mapped('name')
            //     extra_modules_name += new
            // return extra_modules_name
            */
            return default;
        }

        protected async Task<List<object>> GetTranslationFrontendModulesDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def _get_translation_frontend_modules_domain(cls) -> list[tuple[str, str, typing.Any]]:
            // """ Return a domain to list the domain adding web-translations and
            //     dynamic resources that may be used frontend views
            // """
            // return []
            */
            return default;
        }

        protected async Task<object> GetTranslationFrontendModulesNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_password_policy_portal, FILE: ir_http.py) ---
            // def _get_translation_frontend_modules_name(cls):
            // mods = super()._get_translation_frontend_modules_name()
            // return mods + ['auth_password_policy']
            --- ODOO METHOD SOURCE (MODULE: auth_password_policy_signup, FILE: ir_http.py) ---
            // def _get_translation_frontend_modules_name(cls):
            // mods = super()._get_translation_frontend_modules_name()
            // return mods + ['auth_password_policy']
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def _get_translation_frontend_modules_name(cls) -> list[str]:
            // """ Return a list of module name where web-translations and
            //     dynamic resources may be used in frontend views
            // """
            // return ['web']
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: ir_http.py) ---
            // def _get_translation_frontend_modules_name(cls):
            // mods = super()._get_translation_frontend_modules_name()
            // return mods + ["mass_mailing"]
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: ir_http.py) ---
            // def _get_translation_frontend_modules_name(cls):
            // mods = super(IrHttp, cls)._get_translation_frontend_modules_name()
            // return mods + ['payment']
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: ir_http.py) ---
            // def _get_translation_frontend_modules_name(cls):
            // mods = super()._get_translation_frontend_modules_name()
            // return mods + ['point_of_sale']
            --- ODOO METHOD SOURCE (MODULE: portal, FILE: ir_http.py) ---
            // def _get_translation_frontend_modules_name(cls):
            // mods = super(IrHttp, cls)._get_translation_frontend_modules_name()
            // return mods + ['portal']
            --- ODOO METHOD SOURCE (MODULE: portal_rating, FILE: ir_http.py) ---
            // def _get_translation_frontend_modules_name(cls):
            // mods = super(IrHttp, cls)._get_translation_frontend_modules_name()
            // return mods + ['portal_rating']
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: ir_http.py) ---
            // def _get_translation_frontend_modules_name(cls):
            // mods = super()._get_translation_frontend_modules_name()
            // return mods + ["pos_self_order"]
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: ir_http.py) ---
            // def _get_translation_frontend_modules_name(cls):
            // modules = super()._get_translation_frontend_modules_name()
            // return modules + ["survey"]
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_http.py) ---
            // def _get_translation_frontend_modules_name(cls):
            // mods = super(IrHttp, cls)._get_translation_frontend_modules_name()
            // return mods + ['web_editor']
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _get_translation_frontend_modules_name(cls):
            // mods = super()._get_translation_frontend_modules_name()
            // installed = request.registry._init_modules.union(odoo.conf.server_wide_modules)
            // return mods + [mod for mod in installed if mod.startswith('website')]
            --- ODOO METHOD SOURCE (MODULE: website_livechat, FILE: ir_http.py) ---
            // def _get_translation_frontend_modules_name(cls):
            // mods = super(IrHttp, cls)._get_translation_frontend_modules_name()
            // return mods + ['im_livechat']
            --- ODOO METHOD SOURCE (MODULE: website_mail, FILE: ir_http.py) ---
            // def _get_translation_frontend_modules_name(cls):
            // mods = super()._get_translation_frontend_modules_name()
            // return mods + ['mail']
            */
            return default;
        }

        public async Task<TEntity> GetTranslationsForWebclientAsync<TEntity>(IEnumerable<TEntity> entities, object modules, object lang) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def get_translations_for_webclient(self, modules, lang):
            // if not modules:
            //     modules = self.pool._init_modules
            // if not lang:
            //     lang = self._context.get("lang")
            // lang_data = self.env['res.lang']._get_data(code=lang)
            // lang_params = {
            //     "name": lang_data.name,
            //     "code": lang_data.code,
            //     "direction": lang_data.direction,
            //     "date_format": lang_data.date_format,
            //     "time_format": lang_data.time_format,
            //     "short_time_format": lang_data.short_time_format,
            //     "grouping": lang_data.grouping,
            //     "decimal_point": lang_data.decimal_point,
            //     "thousands_sep": lang_data.thousands_sep,
            //     "week_start": int(lang_data.week_start),
            // } if lang_data else None
            // 
            // # Regional languages (ll_CC) must inherit/override their parent lang (ll), but this is
            // # done server-side when the language is loaded, so we only need to load the user's lang.
            // translations_per_module = {}
            // for module in modules:
            //     translations_per_module[module] = code_translations.get_web_translations(module, lang)
            // 
            // return translations_per_module, lang_params
            */
            return default;
        }

        public async Task<object> GetUtmDomainCookiesAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: utm, FILE: ir_http.py) ---
            // def get_utm_domain_cookies(cls):
            // return request.httprequest.host
            */
            return default;
        }

        protected async Task<object> GetValues500ErrorInternalAsync(object env, object values, object exception)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def _get_values_500_error(cls, env, values, exception):
            // values['view'] = env["ir.ui.view"]
            // return values
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _get_values_500_error(cls, env, values, exception):
            // View = env["ir.ui.view"]
            // values = super()._get_values_500_error(env, values, exception)
            // if 'qweb_exception' in values:
            //     try:
            //         # exception.name might be int, string
            //         exception_template = int(exception.name)
            //     except ValueError:
            //         exception_template = exception.name
            //     view = View._view_obj(exception_template)
            //     if exception.html and exception.html in view.arch:
            //         values['view'] = view
            //     else:
            //         # There might be 2 cases where the exception code can't be found
            //         # in the view, either the error is in a child view or the code
            //         # contains branding (<div t-att-data="request.browse('ok')"/>).
            //         et = view.with_context(inherit_branding=False)._get_combined_arch()
            //         node = et.xpath(exception.path) if exception.path else et
            //         line = node is not None and len(node) > 0 and etree.tostring(node[0], encoding='unicode')
            //         if line:
            //             values['view'] = View._views_get(exception_template).filtered(
            //                 lambda v: line in v.arch
            //             )
            //             values['view'] = values['view'] and values['view'][0]
            // # Needed to show reset template on translated pages (`_prepare_environment` will set it for main lang)
            // values['editable'] = request.uid and request.env.user.has_group('website.group_website_designer')
            // return values
            */
            return default;
        }

        protected async Task<object> GetWebEditorContextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_http.py) ---
            // def _get_web_editor_context(cls):
            // """ Check for ?editable and stuff in the query-string """
            // return {
            //     key: True
            //     for key in CONTEXT_KEYS
            //     if key in request.httprequest.args and key not in request.env.context
            // }
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _get_web_editor_context(cls):
            // ctx = super()._get_web_editor_context()
            // if request.is_frontend_multilang and request.lang == cls._get_default_lang():
            //     ctx['edit_translations'] = False
            // return ctx
            */
            return default;
        }

        public async Task<TEntity> GetWebTranslationsHashAsync<TEntity>(IEnumerable<TEntity> entities, object modules, object lang) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def get_web_translations_hash(self, modules, lang):
            // translations, lang_params = self.get_translations_for_webclient(modules, lang)
            // translation_cache = {
            //     'lang_parameters': lang_params,
            //     'modules': translations,
            //     'lang': lang,
            //     'multi_lang': len(self.env['res.lang'].sudo().get_installed()) > 1,
            // }
            // return hashlib.sha1(json.dumps(translation_cache, sort_keys=True, default=json_default).encode()).hexdigest()
            */
            return default;
        }

        protected async Task<object> HandleDebugInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_http.py) ---
            // def _handle_debug(cls):
            // debug = request.httprequest.args.get('debug')
            // if debug is not None:
            //     request.session.debug = ','.join(
            //              mode if mode in ALLOWED_DEBUG_MODES
            //         else '1' if str2bool(mode, mode)
            //         else ''
            //         for mode in (debug or '').split(',')
            //     )
            */
            return default;
        }

        protected async Task<object> HandleErrorInternalAsync(object exception)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def _handle_error(cls, exception):
            // response = super()._handle_error(exception)
            // 
            // is_frontend_request = bool(getattr(request, 'is_frontend', False))
            // if not is_frontend_request or not isinstance(response, HTTPException):
            //     # neither handle backend requests nor plain responses
            //     return response
            // 
            // # minimal setup to serve frontend pages
            // if not request.uid:
            //     cls._auth_method_public()
            // cls._handle_debug()
            // cls._frontend_pre_dispatch()
            // request.params = request.get_http_params()
            // 
            // code, values = cls._get_exception_code_values(exception)
            // 
            // request.cr.rollback()
            // if code in (404, 403):
            //     try:
            //         response = cls._serve_fallback()
            //         if response:
            //             cls._post_dispatch(response)
            //             return response
            //     except werkzeug.exceptions.Forbidden:
            //         # Rendering does raise a Forbidden if target is not visible.
            //         pass # Use default error page handling.
            // elif code == 500:
            //     values = cls._get_values_500_error(request.env, values, exception)
            // try:
            //     code, html = cls._get_error_html(request.env, code, values)
            // except Exception:
            //     code, html = 418, request.env['ir.ui.view']._render_template('http_routing.http_error', values)
            // 
            // response = Response(html, status=code, content_type='text/html;charset=utf-8')
            // cls._post_dispatch(response)
            // return response
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _handle_error(cls, exception):
            // return request.dispatcher.handle_error(exception)
            */
            return default;
        }

        public async Task<object> IsABotAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_http.py) ---
            // def is_a_bot(cls):
            // user_agent = request.httprequest.user_agent.string.lower()
            // # We don't use regexp and ustr voluntarily
            // # timeit has been done to check the optimum method
            // return any(bot in user_agent for bot in cls.bots)
            */
            return default;
        }

        protected async Task<object> IsAllowedCookieInternalAsync(object cookie_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _is_allowed_cookie(cls, cookie_type):
            // result = super()._is_allowed_cookie(cookie_type)
            // if result and cookie_type == 'optional':
            //     if not request.env['website'].get_current_website().cookies_bar:
            //         # Cookies bar is disabled on this website
            //         return True
            //     accepted_cookie_types = json_scriptsafe.loads(request.cookies.get('website_cookies_bar', '{}'))
            // 
            //     # pre-16.0 compatibility, `website_cookies_bar` was `"true"`.
            //     # In that case we delete that cookie and let the user choose again.
            //     if not isinstance(accepted_cookie_types, dict):
            //         request.future_response.set_cookie('website_cookies_bar', max_age=0)
            //         return False
            // 
            //     if 'optional' in accepted_cookie_types:
            //         return accepted_cookie_types['optional']
            //     return False
            // 
            // # Pass-through if already forbidden for another reason or a type that
            // # is not restricted by the website module.
            // return result
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _is_allowed_cookie(cls, cookie_type):
            // return True if cookie_type == 'required' else bool(request.env.user)
            */
            return default;
        }

        protected async Task<bool> IsMultilangUrlInternalAsync(string local_url, object lang_url_codes)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def _is_multilang_url(cls, local_url: str, lang_url_codes: list[str] | None = None) -> bool:
            // ''' Check if the given URL content is supposed to be translated.
            //     To be considered as translatable, the URL should either:
            //     1. Match a POST (non-GET actually) controller that is `website=True` and
            //     either `multilang` specified to True or if not specified, with `type='http'`.
            //     2. If not matching 1., everything not under /static/ or /web/ will be translatable
            // '''
            // if not lang_url_codes:
            //     lang_url_codes = [lg.url_code for lg in request.env['res.lang']._get_frontend().values()]
            // spath = local_url.split('/')
            // # if a language is already in the path, remove it
            // if spath[1] in lang_url_codes:
            //     spath.pop(1)
            //     local_url = '/'.join(spath)
            // 
            // url = local_url.partition('#')[0].split('?')
            // path = url[0]
            // 
            // # Consider /static/ and /web/ files as non-multilang
            // if '/static/' in path or path.startswith('/web/'):
            //     return False
            // 
            // query_string = url[1] if len(url) > 1 else None
            // 
            // # Try to match an endpoint in werkzeug's routing table
            // try:
            //     _, func = request.env['ir.http'].url_rewrite(path, query_args=query_string)
            // 
            //     # /page/xxx has no endpoint/func but is multilang
            //     return (not func or (
            //         func.routing.get('website', False)
            //         and func.routing.get('multilang', func.routing['type'] == 'http')
            //     ))
            // except Exception as exception:  # noqa: BLE001
            //     _logger.warning(exception)
            //     return False
            */
            return default;
        }

        protected async Task<object> MatchInternalAsync(object path_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def _match(cls, path):
            // """
            // Grant multilang support to URL matching by using http 3xx
            // redirections and URL rewrite. This method also grants various
            // attributes such as ``lang`` and ``is_frontend`` on the current
            // ``request`` object.
            // 
            // 1/ Use the URL as-is when it matches a non-multilang compatible
            //    endpoint.
            // 
            // 2/ Use the URL as-is when the lang is not present in the URL and
            //    that the default lang has been requested.
            // 
            // 3/ Use the URL as-is saving the requested lang when the user is
            //    a bot and that the lang is missing from the URL.
            // 
            // 4) Use the url as-is when the lang is missing from the URL, that
            //    another lang than the default one has been requested but that
            //    it is forbidden to redirect (e.g. POST)
            // 
            // 5/ Redirect the browser when the lang is missing from the URL
            //    but another lang than the default one has been requested. The
            //    requested lang is injected before the original path.
            // 
            // 6/ Redirect the browser when the lang is present in the URL but
            //    it is the default lang. The lang is removed from the original
            //    URL.
            // 
            // 7/ Redirect the browser when the lang present in the URL is an
            //    alias of the preferred lang url code (e.g. fr_FR -> fr)
            // 
            // 8/ Redirect the browser when the requested page is the homepage
            //    but that there is a trailing slash.
            // 
            // 9/ Rewrite the URL when the lang is present in the URL, that it
            //    matches and that this lang is not the default one. The URL is
            //    rewritten to remove the lang.
            // 
            // Note: The "requested lang" is (in order) either (1) the lang in
            //       the URL or (2) the lang in the ``frontend_lang`` request
            //       cookie or (3) the lang in the context or (4) the default
            //       lang of the website.
            // """
            // 
            // # The URL has been rewritten already
            // if hasattr(request, 'is_frontend'):
            //     return super()._match(path)
            // 
            // # See /1, match a non website endpoint
            // try:
            //     rule, args = super()._match(path)
            //     routing = rule.endpoint.routing
            //     request.is_frontend = routing.get('website', False)
            //     request.is_frontend_multilang = request.is_frontend and routing.get('multilang', routing['type'] == 'http')
            //     if not request.is_frontend:
            //         return rule, args
            // except NotFound:
            //     _, url_lang_str, *rest = path.split('/', 2)
            //     path_no_lang = '/' + (rest[0] if rest else '')
            // else:
            //     url_lang_str = ''
            //     path_no_lang = path
            // 
            // allow_redirect = (
            //     request.httprequest.method != 'POST'
            //     and getattr(request, 'is_frontend_multilang', True)
            // )
            // 
            // # Some URLs in website are concatenated, first url ends with /,
            // # second url starts with /, resulting url contains two following
            // # slashes that must be merged.
            // if allow_redirect and '//' in path:
            //     new_url = path.replace('//', '/')
            //     werkzeug.exceptions.abort(request.redirect(new_url, code=301, local=True))
            // 
            // # There is no user on the environment yet but the following code
            // # requires one to set the lang on the request. Temporary grant
            // # the public user. Don't try it at home!
            // real_env = request.env
            // try:
            //     request.registry['ir.http']._auth_method_public()  # it calls update_env
            //     nearest_url_lang = request.env['ir.http'].get_nearest_lang(request.env['res.lang']._get_data(url_code=url_lang_str).code or url_lang_str)
            //     cookie_lang = request.env['ir.http'].get_nearest_lang(request.cookies.get('frontend_lang'))
            //     context_lang = request.env['ir.http'].get_nearest_lang(real_env.context.get('lang'))
            //     default_lang = cls._get_default_lang()
            //     request.lang = request.env['res.lang']._get_data(code=(
            //         nearest_url_lang or cookie_lang or context_lang or default_lang.code
            //     ))
            //     request_url_code = request.lang.url_code
            // finally:
            //     request.env = real_env
            // 
            // if not nearest_url_lang:
            //     url_lang_str = None
            // 
            // # See /2, no lang in url and default website
            // if not url_lang_str and request.lang == default_lang:
            //     _logger.debug("%r (lang: %r) no lang in url and default website, continue", path, request_url_code)
            // 
            // # See /3, missing lang in url but user-agent is a bot
            // elif not url_lang_str and request.env['ir.http'].is_a_bot():
            //     _logger.debug("%r (lang: %r) missing lang in url but user-agent is a bot, continue", path, request_url_code)
            //     request.lang = default_lang
            // 
            // # See /4, no lang in url and should not redirect (e.g. POST), continue
            // elif not url_lang_str and not allow_redirect:
            //     _logger.debug("%r (lang: %r) no lang in url and should not redirect (e.g. POST), continue", path, request_url_code)
            // 
            // # See /5, missing lang in url, /home -> /fr/home
            // elif not url_lang_str:
            //     _logger.debug("%r (lang: %r) missing lang in url, redirect", path, request_url_code)
            //     redirect = request.redirect_query(f'/{request_url_code}{path}', request.httprequest.args)
            //     redirect.set_cookie('frontend_lang', request.lang.code)
            //     werkzeug.exceptions.abort(redirect)
            // 
            // # See /6, default lang in url, /en/home -> /home
            // elif url_lang_str == default_lang.url_code and allow_redirect:
            //     _logger.debug("%r (lang: %r) default lang in url, redirect", path, request_url_code)
            //     redirect = request.redirect_query(path_no_lang, request.httprequest.args)
            //     redirect.set_cookie('frontend_lang', default_lang.code)
            //     werkzeug.exceptions.abort(redirect)
            // 
            // # See /7, lang alias in url, /fr_FR/home -> /fr/home
            // elif url_lang_str != request_url_code and allow_redirect:
            //     _logger.debug("%r (lang: %r) lang alias in url, redirect", path, request_url_code)
            //     redirect = request.redirect_query(f'/{request_url_code}{path_no_lang}', request.httprequest.args, code=301)
            //     redirect.set_cookie('frontend_lang', request.lang.code)
            //     werkzeug.exceptions.abort(redirect)
            // 
            // # See /8, homepage with trailing slash. /fr_BE/ -> /fr_BE
            // elif path == f'/{url_lang_str}/' and allow_redirect:
            //     _logger.debug("%r (lang: %r) homepage with trailing slash, redirect", path, request_url_code)
            //     redirect = request.redirect_query(path[:-1], request.httprequest.args, code=301)
            //     redirect.set_cookie('frontend_lang', default_lang.code)
            //     werkzeug.exceptions.abort(redirect)
            // 
            // # See /9, valid lang in url
            // elif url_lang_str == request_url_code:
            //     # Rewrite the URL to remove the lang
            //     _logger.debug("%r (lang: %r) valid lang in url, rewrite url and continue", path, request_url_code)
            //     request.reroute(path_no_lang)
            //     path = path_no_lang
            // 
            // else:
            //     _logger.warning("%r (lang: %r) couldn't not correctly route this frontend request, url used as-is.", path, request_url_code)
            // 
            // # Re-match using rewritten route and really raise for 404 errors
            // try:
            //     rule, args = super()._match(path)
            //     routing = rule.endpoint.routing
            //     request.is_frontend = routing.get('website', False)
            //     request.is_frontend_multilang = request.is_frontend and routing.get('multilang', routing['type'] == 'http')
            //     return rule, args
            // except NotFound:
            //     # Use website to render a nice 404 Not Found html page
            //     request.is_frontend = True
            //     request.is_frontend_multilang = True
            //     raise
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _match(cls, path):
            // if not hasattr(request, 'website_routing'):
            //     website = request.env['website'].with_context(lang=None).get_current_website()
            //     request.website_routing = website.id
            // 
            // return super()._match(path)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _match(cls, path_info):
            // rule, args = request.env['ir.http'].routing_map().bind_to_environ(request.httprequest.environ).match(path_info=path_info, return_rule=True)
            // return rule, args
            */
            return default;
        }

        protected async Task<object> PostDispatchInternalAsync(object response)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: utm, FILE: ir_http.py) ---
            // def _post_dispatch(cls, response):
            // cls._set_utm(response)
            // super()._post_dispatch(response)
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _post_dispatch(cls, response):
            // super()._post_dispatch(response)
            // cls._register_website_track(response)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _post_dispatch(cls, response):
            // request.dispatcher.post_dispatch(response)
            */
            return default;
        }

        protected async Task<object> PostLogoutInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_http.py) ---
            // def _post_logout(cls):
            // super()._post_logout()
            // request.future_response.set_cookie('cids', max_age=0)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _post_logout(cls):
            // pass
            */
            return default;
        }

        protected async Task<object> PreDispatchInternalAsync(object rule, object args)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: ir_http.py) ---
            // def _pre_dispatch(cls, rule, args):
            // super()._pre_dispatch(rule, args)
            // 
            // # add signup token or login to the session if given
            // for key in ('auth_signup_token', 'auth_login'):
            //     val = request.httprequest.args.get(key)
            //     if val is not None:
            //         request.session[key] = val
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def _pre_dispatch(cls, rule, args):
            // super()._pre_dispatch(rule, args)
            // 
            // if request.is_frontend:
            //     cls._frontend_pre_dispatch()
            // 
            //     # update the context of "<model(...):...>" args
            //     for key, val in list(args.items()):
            //         if isinstance(val, models.BaseModel):
            //             args[key] = val.with_context(request.context)
            // 
            // if request.is_frontend_multilang:
            //     # A product with id 1 and named 'egg' is accessible via a
            //     # frontend multilang enpoint 'foo' at the URL '/foo/1'.
            //     # The preferred URL to access the product (and to generate
            //     # URLs pointing it) should instead be the sluggified URL
            //     # '/foo/egg-1'. This code is responsible of redirecting the
            //     # browser from '/foo/1' to '/foo/egg-1', or '/fr/foo/1' to
            //     # '/fr/foo/oeuf-1'. While it is nice (for humans) to have a
            //     # pretty URL, the real reason of this redirection is SEO.
            //     if request.httprequest.method in ('GET', 'HEAD'):
            //         try:
            //             _, path = rule.build(args)
            //         except odoo.exceptions.MissingError:
            //             raise werkzeug.exceptions.NotFound()
            //         assert path is not None
            //         generated_path = werkzeug.urls.url_unquote_plus(path)
            //         current_path = werkzeug.urls.url_unquote_plus(request.httprequest.path)
            //         if generated_path != current_path:
            //             if request.lang != cls._get_default_lang():
            //                 path = f'/{request.lang.url_code}{path}'
            //             redirect = request.redirect_query(path, request.httprequest.args, code=301)
            //             werkzeug.exceptions.abort(redirect)
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_http.py) ---
            // def _pre_dispatch(cls, rule, args):
            // super()._pre_dispatch(rule, args)
            // cls._handle_debug()
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_http.py) ---
            // def _pre_dispatch(cls, rule, args):
            // super()._pre_dispatch(rule, args)
            // ctx = cls._get_web_editor_context()
            // request.update_context(**ctx)
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _pre_dispatch(cls, rule, arguments):
            // super()._pre_dispatch(rule, arguments)
            // 
            // for record in arguments.values():
            //     if isinstance(record, models.BaseModel) and hasattr(record, 'can_access_from_current_website'):
            //         try:
            //             if not record.can_access_from_current_website():
            //                 raise werkzeug.exceptions.NotFound()
            //         except AccessError:
            //             # record.website_id might not be readable as
            //             # unpublished `event.event` due to ir.rule, return
            //             # 403 instead of using `sudo()` for perfs as this is
            //             # low level.
            //             raise werkzeug.exceptions.Forbidden()
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: ir_http.py) ---
            // def _pre_dispatch(cls, rule, args):
            // super()._pre_dispatch(rule, args)
            // affiliate_id = request.httprequest.args.get('affiliate_id')
            // if affiliate_id:
            //     request.session['affiliate_id'] = int(affiliate_id)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _pre_dispatch(cls, rule, args):
            // ICP = request.env['ir.config_parameter'].with_user(SUPERUSER_ID)
            // 
            // # Change the default database-wide 128MiB upload limit on the
            // # ICP value. Do it before calling http's generic pre_dispatch
            // # so that the per-route limit @route(..., max_content_length=x)
            // # takes over.
            // try:
            //     key = 'web.max_file_upload_size'
            //     if (value := ICP.get_param(key, None)) is not None:
            //         request.httprequest.max_content_length = int(value)
            // except ValueError:  # better not crash on ALL requests
            //     _logger.error("invalid %s: %r, using %s instead",
            //         key, value, request.httprequest.max_content_length,
            //     )
            // 
            // request.dispatcher.pre_dispatch(rule, args)
            // 
            // # verify the default language set in the context is valid,
            // # otherwise fallback on the company lang, english or the first
            // # lang installed
            // env = request.env if request.env.uid else request.env['base'].with_user(SUPERUSER_ID).env
            // request.update_context(lang=get_lang(env).code)
            // 
            // for key, val in list(args.items()):
            //     if not isinstance(val, models.BaseModel):
            //         continue
            // 
            //     # Replace uid and lang placeholder by the current request.env.uid and request.env.lang
            //     args[key] = val.with_env(request.env)
            // 
            //     try:
            //         # explicitly crash now, instead of crashing later
            //         args[key].check_access('read')
            //     except (odoo.exceptions.AccessError, odoo.exceptions.MissingError) as e:
            //         # custom behavior in case a record is not accessible / has been removed
            //         if handle_error := rule.endpoint.routing.get('handle_params_access_error'):
            //             if response := handle_error(e):
            //                 werkzeug.exceptions.abort(response)
            //         if isinstance(e, odoo.exceptions.MissingError):
            //             raise werkzeug.exceptions.NotFound() from e
            //         raise
            */
            return default;
        }

        protected async Task<object> RedirectInternalAsync(object location, object code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _redirect(cls, location, code=303):
            // return werkzeug.utils.redirect(location, code=code, Response=Response)
            */
            return default;
        }

        protected async Task<object> RegisterWebsiteTrackInternalAsync(object response)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _register_website_track(cls, response):
            // if request.env['ir.http'].is_a_bot():
            //     return False
            // if getattr(response, 'status_code', 0) != 200 or request.httprequest.headers.get('X-Disable-Tracking') == '1':
            //     return False
            // template = False
            // if hasattr(response, '_cached_page'):
            //     website_page, template = response._cached_page, response._cached_template
            // elif hasattr(response, 'qcontext'):  # classic response
            //     main_object = response.qcontext.get('main_object')
            //     website_page = getattr(main_object, '_name', False) == 'website.page' and main_object
            //     template = response.qcontext.get('response_template')
            // 
            // view = template and request.env['website'].get_template(template)
            // if not request.env.cr.readonly and view and view.track:
            //     request.env['website.visitor']._handle_webpage_dispatch(website_page)
            // 
            // return False
            */
            return default;
        }

        public async Task<int> RewriteLenInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid website_id) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _rewrite_len(self, website_id: int) -> int:
            // rewrites = self._get_rewrites(website_id)
            // return len(rewrites)
            */
            return default;
        }

        public async Task<TEntity> RoutingMapAsync<TEntity>(IEnumerable<TEntity> entities, object key) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def routing_map(self, key=None):
            // if not key and request:
            //     key = request.website_routing
            // return super().routing_map(key=key)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def routing_map(self, key=None):
            // _logger.info("Generating routing map for key %s", str(key))
            // registry = Registry(threading.current_thread().dbname)
            // installed = registry._init_modules.union(odoo.conf.server_wide_modules)
            // mods = sorted(installed)
            // # Note : when routing map is generated, we put it on the class `cls`
            // # to make it available for all instance. Since `env` create an new instance
            // # of the model, each instance will regenared its own routing map and thus
            // # regenerate its EndPoint. The routing map should be static.
            // routing_map = werkzeug.routing.Map(strict_slashes=False, converters=self._get_converters())
            // for url, endpoint in self._generate_routing_rules(mods, converters=self._get_converters()):
            //     routing = submap(endpoint.routing, ROUTING_KEYS)
            //     if routing['methods'] is not None and 'OPTIONS' not in routing['methods']:
            //         routing['methods'] = [*routing['methods'], 'OPTIONS']
            //     rule = FasterRule(url, endpoint=endpoint, **routing)
            //     rule.merge_slashes = False
            //     routing_map.add(rule)
            // return routing_map
            */
            return default;
        }

        protected async Task<object> SanitizeCookiesInternalAsync(object cookies)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_http.py) ---
            // def _sanitize_cookies(cls, cookies):
            // super()._sanitize_cookies(cookies)
            // if cids := cookies.get('cids'):
            //     cookies['cids'] = '-'.join(cids.split(','))
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _sanitize_cookies(cls, cookies):
            // pass
            */
            return default;
        }

        protected async Task<object> ServeFallbackInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _serve_fallback(cls):
            // # serve attachment before
            // parent = super()._serve_fallback()
            // if parent:  # attachment
            //     return parent
            // 
            // # minimal setup to serve frontend pages
            // if not request.uid:
            //     cls._auth_method_public()
            // cls._frontend_pre_dispatch()
            // cls._handle_debug()
            // 
            // website_page = cls._serve_page()
            // if website_page:
            //     website_page.flatten()
            //     return website_page
            // 
            // redirect = cls._serve_redirect()
            // if redirect:
            //     return request.redirect(
            //         _build_url_w_params(redirect.url_to, request.params),
            //         code=redirect.redirect_type,
            //         local=False)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _serve_fallback(cls):
            // model = request.env['ir.attachment']
            // attach = model.sudo()._get_serve_attachment(request.httprequest.path)
            // if attach and (attach.store_fname or attach.db_datas):
            //     return attach._to_http_stream().get_response()
            */
            return default;
        }

        protected async Task<object> ServePageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _serve_page(cls):
            // req_page = request.httprequest.path
            // 
            // def _search_page(comparator='='):
            //     page_domain = [('url', comparator, req_page)] + request.website.website_domain()
            //     return request.env['website.page'].sudo().search(page_domain, order='website_id asc', limit=1)
            // 
            // # specific page first
            // page = _search_page()
            // 
            // # case insensitive search
            // if not page:
            //     page = _search_page('=ilike')
            //     if page:
            //         logger.info("Page %r not found, redirecting to existing page %r", req_page, page.url)
            //         return request.redirect(page.url)
            // 
            // # redirect without trailing /
            // if not page and req_page != "/" and req_page.endswith("/"):
            //     # mimick `_postprocess_args()` redirect
            //     path = request.httprequest.path[:-1]
            //     if request.lang != cls._get_default_lang():
            //         path = '/' + request.lang.url_code + path
            //     if request.httprequest.query_string:
            //         path += '?' + request.httprequest.query_string.decode('utf-8')
            //     return request.redirect(path, code=301)
            // 
            // if (
            //     page
            //     and (request.env.user.has_group('website.group_website_designer') or page.is_visible)
            //     and (
            //         # If a generic page (niche case) has been COWed and that COWed
            //         # page received a URL change, it should not let you access the
            //         # generic page anymore, despite having a different URL.
            //         page.website_id
            //         or not page.view_id._get_specific_views().filtered(lambda view: view.website_id == request.website)
            //     )
            // ):
            //     _, ext = os.path.splitext(req_page)
            //     response = request.render(page.view_id.id, {
            //         'main_object': page,
            //     }, mimetype=EXTENSION_TO_WEB_MIMETYPES.get(ext, 'text/html'))
            //     return response
            // return False
            --- ODOO METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: ir_http.py) ---
            // def _serve_page(cls):
            // response = super(IrHttp, cls)._serve_page()
            // if response and getattr(response, 'status_code', 0) == 200 and request.env.user._is_public():
            //     visitor_sudo = request.env['website.visitor']._get_visitor_from_request()
            //     # We are avoiding to create a reveal_view if a lead is already
            //     # created from another module, e.g. website_form
            //     if not (visitor_sudo and visitor_sudo.lead_ids):
            //         country_code = request.geoip.country_code
            //         state_code = request.geoip.subdivisions[0].iso_code if request.geoip.subdivisions else None
            //         if country_code:
            //             try:
            //                 url = request.httprequest.url
            //                 ip_address = request.httprequest.remote_addr
            //                 if not ip_address:
            //                     return response
            //                 website_id = request.website.id
            //                 rules_excluded = (request.cookies.get('rule_ids') or '').split(',')
            //                 before = time.time()
            //                 new_rules_excluded = request.env['crm.reveal.view'].sudo()._create_reveal_view(website_id, url, ip_address, country_code, state_code, rules_excluded)
            //                 # even when we match, no view may have been created if this is a duplicate
            //                 _logger.info('Reveal process time: [%s], match rule: [%s?], country code: [%s], ip: [%s]',
            //                              time.time() - before, new_rules_excluded == rules_excluded, country_code,
            //                              ip_address)
            //                 if new_rules_excluded:
            //                     response.set_cookie('rule_ids', ','.join(new_rules_excluded), expires=None, cookie_type='optional')
            //             except Exception:
            //                 # just in case - we never want to crash a page view
            //                 _logger.exception("Failed to process reveal rules")
            // return response
            */
            return default;
        }

        protected async Task<object> ServeRedirectInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _serve_redirect(cls):
            // req_page = request.httprequest.path
            // req_page_with_qs = request.httprequest.environ['REQUEST_URI']
            // domain = [
            //     ('redirect_type', 'in', ('301', '302')),
            //     # trailing / could have been removed by server_page
            //     ('url_from', 'in', [req_page_with_qs, req_page.rstrip('/'), req_page + '/'])
            // ]
            // domain += request.website.website_domain()
            // return request.env['website.rewrite'].sudo().search(domain, order='url_from DESC', limit=1)
            */
            return default;
        }

        public async Task<TEntity> SessionInfoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: barcodes, FILE: ir_http.py) ---
            // def session_info(self):
            // res = super(IrHttp, self).session_info()
            // if self.env.user._is_internal():
            //     res['max_time_between_keys_in_ms'] = int(
            //         self.env['ir.config_parameter'].sudo().get_param('barcode.max_time_between_keys_in_ms', default='150'))
            // return res
            --- ODOO METHOD SOURCE (MODULE: barcodes_gs1_nomenclature, FILE: ir_http.py) ---
            // def session_info(self):
            // res = super().session_info()
            // nomenclature = self.env.company.sudo().nomenclature_id
            // if not nomenclature.is_gs1_nomenclature:
            //     return res
            // res['gs1_group_separator_encodings'] = nomenclature.gs1_separator_fnc1
            // return res
            --- ODOO METHOD SOURCE (MODULE: base_setup, FILE: ir_http.py) ---
            // def session_info(self):
            // result = super(IrHttp, self).session_info()
            // if self.env.user._is_internal():
            //     result['show_effect'] = bool(self.env['ir.config_parameter'].sudo().get_param('base_setup.show_effect'))
            // return result
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: ir_http.py) ---
            // def session_info(self):
            // session_info = super().session_info()
            // session_info["websocket_worker_version"] = WebsocketConnectionHandler._VERSION
            // return session_info
            --- ODOO METHOD SOURCE (MODULE: cloud_storage, FILE: ir_http.py) ---
            // def session_info(self):
            // res = super().session_info()
            // ICP = self.env['ir.config_parameter'].sudo()
            // if ICP.get_param('cloud_storage_provider'):
            //     res['cloud_storage_min_file_size'] = ICP.get_param('cloud_storage_min_file_size', DEFAULT_CLOUD_STORAGE_MIN_FILE_SIZE)
            // return res
            --- ODOO METHOD SOURCE (MODULE: google_recaptcha, FILE: ir_http.py) ---
            // def session_info(self):
            // session_info = super().session_info()
            // return self._add_public_key_to_session_info(session_info)
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: ir_http.py) ---
            // def session_info(self):
            // """ The widget 'timesheet_uom' needs to know which UoM conversion factor and which javascript
            //     widget to apply, depending on the current company.
            // """
            // result = super(Http, self).session_info()
            // if self.env.user._is_internal():
            //     company_ids = self.env.user.company_ids
            // 
            //     for company in company_ids:
            //         result["user_companies"]["allowed_companies"][company.id].update({
            //             "timesheet_uom_id": company.timesheet_encode_uom_id.id,
            //             "timesheet_uom_factor": company.project_time_mode_id._compute_quantity(
            //                 1.0,
            //                 company.timesheet_encode_uom_id,
            //                 round=False
            //             ),
            //         })
            //     result["uom_ids"] = self.get_timesheet_uoms()
            // return result
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_http.py) ---
            // def session_info(self):
            // """Override to add the current user data (partner or guest) if applicable."""
            // result = super().session_info()
            // store = Store()
            // ResUsers = self.env["res.users"]
            // if cids := request.cookies.get("cids", False):
            //     allowed_company_ids = []
            //     for company_id in [int(cid) for cid in cids.split("-")]:
            //         if company_id in self.env.user.company_ids.ids:
            //             allowed_company_ids.append(company_id)
            //     ResUsers = self.with_context(allowed_company_ids=allowed_company_ids).env["res.users"]
            // ResUsers._init_store_data(store)
            // result["storeData"] = store.get_result()
            // guest = self.env['mail.guest']._get_guest_from_context()
            // if not request.session.uid and guest:
            //     user_context = {'lang': guest.lang}
            //     mods = odoo.conf.server_wide_modules or []
            //     lang = user_context.get("lang")
            //     translation_hash = self.env['ir.http'].sudo().get_web_translations_hash(mods, lang)
            //     result['cache_hashes']['translations'] = translation_hash
            //     result["user_context"] = user_context
            // return result
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: ir_http.py) ---
            // def session_info(self):
            // """ Add information about iap enrich to perform """
            // session_info = super(Http, self).session_info()
            // if session_info.get('is_admin'):
            //     session_info['iap_company_enrich'] = not self.env.user.company_id.iap_enrich_auto_done
            // return session_info
            --- ODOO METHOD SOURCE (MODULE: spreadsheet, FILE: ir_http.py) ---
            // def session_info(self):
            // """
            // Override this method to enable the 'Insert in spreadsheet' button in the
            // web client.
            // """
            // res = super().session_info()
            // res["can_insert_in_spreadsheet"] = False
            // return res
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_http.py) ---
            // def session_info(self):
            // user = self.env.user
            // session_uid = request.session.uid
            // version_info = odoo.service.common.exp_version()
            // 
            // if session_uid:
            //     user_context = dict(self.env['res.users'].context_get())
            //     if user_context != request.session.context:
            //         request.session.context = user_context
            // else:
            //     user_context = {}
            // 
            // IrConfigSudo = self.env['ir.config_parameter'].sudo()
            // max_file_upload_size = int(IrConfigSudo.get_param(
            //     'web.max_file_upload_size',
            //     default=DEFAULT_MAX_CONTENT_LENGTH,
            // ))
            // mods = odoo.conf.server_wide_modules or []
            // if request.db:
            //     mods = list(request.registry._init_modules) + mods
            // is_internal_user = user._is_internal()
            // session_info = {
            //     "uid": session_uid,
            //     "is_system": user._is_system() if session_uid else False,
            //     "is_admin": user._is_admin() if session_uid else False,
            //     "is_public": user._is_public(),
            //     "is_internal_user": is_internal_user,
            //     "user_context": user_context,
            //     "db": self.env.cr.dbname,
            //     "user_settings": self.env['res.users.settings']._find_or_create_for_user(user)._res_users_settings_format(),
            //     "server_version": version_info.get('server_version'),
            //     "server_version_info": version_info.get('server_version_info'),
            //     "support_url": "https://www.odoo.com/buy",
            //     "name": user.name,
            //     "username": user.login,
            //     "quick_login": str2bool(IrConfigSudo.get_param('web.quick_login', default=True), True),
            //     "partner_write_date": fields.Datetime.to_string(user.partner_id.write_date),
            //     "partner_display_name": user.partner_id.display_name,
            //     "partner_id": user.partner_id.id if session_uid and user.partner_id else None,
            //     "web.base.url": IrConfigSudo.get_param('web.base.url', default=''),
            //     "active_ids_limit": int(IrConfigSudo.get_param('web.active_ids_limit', default='20000')),
            //     'profile_session': request.session.profile_session,
            //     'profile_collectors': request.session.profile_collectors,
            //     'profile_params': request.session.profile_params,
            //     "max_file_upload_size": max_file_upload_size,
            //     "home_action_id": user.action_id.id,
            //     "cache_hashes": {
            //         "translations": self.env['ir.http'].sudo().get_web_translations_hash(
            //             mods, request.session.context['lang']
            //         ) if session_uid else None,
            //     },
            //     "currencies": self.sudo().get_currencies(),
            //     'bundle_params': {
            //         'lang': request.session.context['lang'],
            //     },
            //     'test_mode': bool(config['test_enable'] or config['test_file']),
            //     'view_info': self.env['ir.ui.view'].get_view_info(),
            // }
            // if request.session.debug:
            //     session_info['bundle_params']['debug'] = request.session.debug
            // if is_internal_user:
            //     # the following is only useful in the context of a webclient bootstrapping
            //     # but is still included in some other calls (e.g. '/web/session/authenticate')
            //     # to avoid access errors and unnecessary information, it is only included for users
            //     # with access to the backend ('internal'-type users)
            //     menus = self.env['ir.ui.menu'].with_context(lang=request.session.context['lang']).load_menus(request.session.debug)
            //     ordered_menus = {str(k): v for k, v in menus.items()}
            //     menu_json_utf8 = json.dumps(ordered_menus, sort_keys=True).encode()
            //     session_info['cache_hashes'].update({
            //         "load_menus": hashlib.sha512(menu_json_utf8).hexdigest()[:64], # sha512/256
            //     })
            //     # We need sudo since a user may not have access to ancestor companies
            //     disallowed_ancestor_companies_sudo = user.company_ids.sudo().parent_ids - user.company_ids
            //     all_companies_in_hierarchy_sudo = disallowed_ancestor_companies_sudo + user.company_ids
            //     session_info.update({
            //         # current_company should be default_company
            //         "user_companies": {
            //             'current_company': user.company_id.id,
            //             'allowed_companies': {
            //                 comp.id: {
            //                     'id': comp.id,
            //                     'name': comp.name,
            //                     'sequence': comp.sequence,
            //                     'child_ids': (comp.child_ids & user.company_ids).ids,
            //                     'parent_id': comp.parent_id.id,
            //                 } for comp in user.company_ids
            //             },
            //             'disallowed_ancestor_companies': {
            //                 comp.id: {
            //                     'id': comp.id,
            //                     'name': comp.name,
            //                     'sequence': comp.sequence,
            //                     'child_ids': (comp.child_ids & all_companies_in_hierarchy_sudo).ids,
            //                     'parent_id': comp.parent_id.id,
            //                 } for comp in disallowed_ancestor_companies_sudo
            //             },
            //         },
            //         "show_effect": True,
            //         "display_switch_company_menu": user.has_group('base.group_multi_company') and len(user.company_ids) > 1,
            //     })
            // return session_info
            --- ODOO METHOD SOURCE (MODULE: web_tour, FILE: ir_http.py) ---
            // def session_info(self):
            // result = super().session_info()
            // result["tour_enabled"] = self.env.user.tour_enabled
            // result['current_tour'] = self.env["web_tour.tour"].get_current_tour()
            // return result
            */
            return default;
        }

        protected async Task<object> SetUtmInternalAsync(object response)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: utm, FILE: ir_http.py) ---
            // def _set_utm(cls, response):
            // # Make sure response is an odoo Response.
            // response = Response.load(response)
            // domain = cls.get_utm_domain_cookies()
            // for url_parameter, __, cookie_name in request.env['utm.mixin'].tracking_fields():
            //     if url_parameter in request.params and request.cookies.get(cookie_name) != request.params[url_parameter]:
            //         response.set_cookie(cookie_name, request.params[url_parameter], max_age=31 * 24 * 3600, domain=domain, cookie_type='optional')
            */
            return default;
        }

        protected async Task<string> SlugInternalAsync(object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def _slug(cls, value: models.BaseModel | tuple[int, str]) -> str:
            // try:
            //     identifier, name = value.id, value.display_name
            // except AttributeError:
            //     # assume name_search result tuple
            //     identifier, name = value
            // if not identifier:
            //     raise ValueError("Cannot slug non-existent record %s" % value)
            // slugname = cls._slugify(name or '')
            // if not slugname:
            //     return str(identifier)
            // return f"{slugname}-{identifier}"
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _slug(cls, value: models.BaseModel | tuple[int, str]) -> str:
            // try:
            //     if value.id and value.seo_name:
            //         return super()._slug((value.id, value.seo_name))
            // except AttributeError:
            //     pass
            // return super()._slug(value)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _slug(cls, value: models.BaseModel | tuple[int, str]) -> str:
            // if isinstance(value, tuple):
            //     return str(value[0])
            // return str(value.id)
            */
            return default;
        }

        protected async Task<object> SlugMatchingInternalAsync(object adapter, object endpoint)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _slug_matching(cls, adapter, endpoint, **kw):
            // for arg in kw:
            //     if isinstance(kw[arg], models.BaseModel):
            //         kw[arg] = kw[arg].with_context(slug_matching=True)
            // qs = request.httprequest.query_string.decode('utf-8')
            // return adapter.build(endpoint, kw) + (qs and '?%s' % qs or '')
            */
            return default;
        }

        protected async Task<string> SlugifyInternalAsync(string @value, int max_length, bool path)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _slugify(cls, value: str, max_length: int = 0, path: bool = False) -> str:
            // if not path:
            //     return cls._slugify_one(value, max_length=max_length)
            // else:
            //     res = []
            //     for u in value.split('/'):
            //         s = cls._slugify_one(u, max_length=max_length)
            //         if s:
            //             res.append(s)
            //     # check if supported extension
            //     path_no_ext, ext = os.path.splitext(value)
            //     if ext in EXTENSION_TO_WEB_MIMETYPES:
            //         res[-1] = cls._slugify_one(path_no_ext) + ext
            //     return '/'.join(res)
            */
            return default;
        }

        protected async Task<string> SlugifyOneInternalAsync(string @value, int max_length)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _slugify_one(cls, value: str, max_length: int = 0) -> str:
            // """ Transform a string to a slug that can be used in a url path.
            //     This method will first try to do the job with python-slugify if present.
            //     Otherwise it will process string by stripping leading and ending spaces,
            //     converting unicode chars to ascii, lowering all chars and replacing spaces
            //     and underscore with hyphen "-".
            // """
            // if slugify_lib:
            //     # There are 2 different libraries only python-slugify is supported
            //     try:
            //         return slugify_lib.slugify(value, max_length=max_length)
            //     except TypeError:
            //         pass
            // uni = unicodedata.normalize('NFKD', value).encode('ascii', 'ignore').decode('ascii')
            // slug_str = re.sub(r'[\W_]+', '-', uni).strip('-').lower()
            // return slug_str[:max_length] if max_length > 0 else slug_str
            */
            return default;
        }

        protected async Task<object> UnslugInternalAsync(string @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def _unslug(cls, value: str) -> tuple[str | None, int] | tuple[None, None]:
            // """ Extract slug and id from a string.
            //     Always return a 2-tuple (str|None, int|None)
            // """
            // m = _UNSLUG_RE.match(value)
            // if not m:
            //     return None, None
            // return m.group(1), int(m.group(2))
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _unslug(cls, value: str) -> tuple[str | None, int] | tuple[None, None]:
            // try:
            //     return None, int(value)
            // except ValueError:
            //     return None, None
            */
            return default;
        }

        protected async Task<string> UnslugUrlInternalAsync(string @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def _unslug_url(cls, value: str) -> str:
            // """ From /blog/my-super-blog-1" to "blog/1" """
            // parts = value.split('/')
            // if parts:
            //     unslug_val = cls._unslug(parts[-1])
            //     if unslug_val[1]:
            //         parts[-1] = str(unslug_val[1])
            //         return '/'.join(parts)
            // return value
            */
            return default;
        }

        protected async Task<string> UrlForInternalAsync(string url_from, object lang_code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def _url_for(cls, url_from: str, lang_code: str | None = None) -> str:
            // ''' Return the url with the rewriting applied.
            //     Nothing will be done for absolute URL, invalid URL, or short URL from 1 char.
            // 
            //     :param url_from: The URL to convert.
            //     :param lang_code: Must be the lang `code`. It could also be something
            //                       else, such as `'[lang]'` (used for url_return).
            // '''
            // return cls._url_lang(url_from, lang_code=lang_code)
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_http.py) ---
            // def _url_for(cls, url_from: str, lang_code: str | None = None) -> str:
            // ''' Return the url with the rewriting applied.
            //     Nothing will be done for absolute URL, invalid URL, or short URL from 1 char.
            // 
            //     :param url_from: The URL to convert.
            //     :param lang_code: Must be the lang `code`. It could also be something
            //                       else, such as `'[lang]'` (used for url_return).
            // '''
            // path, sep, qs = (url_from or '').partition('?')
            // 
            // if not qs:
            //     path, sep, qs = (url_from or '').partition('#')
            // 
            // if (
            //     path
            //     # don't try to match route if we know that no rewrite has been loaded.
            //     and request.env['ir.http']._rewrite_len(request.website_routing)
            //     and (
            //         len(path) > 1
            //         and path.startswith('/')
            //         and '/static/' not in path
            //         and not path.startswith('/web/')
            //     )
            // ):
            //     url_from, _ = request.env['ir.http'].url_rewrite(path)
            //     url_from = url_from if not qs else f"{url_from}{sep}{qs}"
            // 
            // return super()._url_for(url_from, lang_code)
            */
            return default;
        }

        protected async Task<string> UrlLangInternalAsync(string path_or_uri, object lang_code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def _url_lang(cls, path_or_uri: str, lang_code: str | None = None) -> str:
            // ''' Given a relative URL, make it absolute and add the required lang or
            //     remove useless lang.
            //     Nothing will be done for absolute or invalid URL.
            //     If there is only one language installed, the lang will not be handled
            //     unless forced with `lang` parameter.
            // 
            //     :param lang_code: Must be the lang `code`. It could also be something
            //                       else, such as `'[lang]'` (used for url_return).
            // '''
            // Lang = request.env['res.lang']
            // location = path_or_uri.strip()
            // force_lang = lang_code is not None
            // try:
            //     url = urllib.parse.urlparse(location)
            // except ValueError:
            //     # e.g. Invalid IPv6 URL, `urllib.parse.urlparse('http://]')`
            //     url = False
            // # relative URL with either a path or a force_lang
            // if url and not url.netloc and not url.scheme and (url.path or force_lang):
            //     location = werkzeug.urls.url_join(request.httprequest.path, location)
            //     lang_url_codes = [info.url_code for info in Lang._get_frontend().values()]
            //     lang_code = lang_code or request.context['lang']
            //     lang_url_code = Lang._get_data(code=lang_code).url_code
            //     lang_url_code = lang_url_code if lang_url_code in lang_url_codes else lang_code
            //     if (len(lang_url_codes) > 1 or force_lang) and cls._is_multilang_url(location, lang_url_codes):
            //         loc, sep, qs = location.partition('?')
            //         ps = loc.split('/')
            //         default_lg = request.env['ir.http']._get_default_lang()
            //         if ps[1] in lang_url_codes:
            //             # Replace the language only if we explicitly provide a language to url_for
            //             if force_lang:
            //                 ps[1] = lang_url_code
            //             # Remove the default language unless it's explicitly provided
            //             elif ps[1] == default_lg.url_code:
            //                 ps.pop(1)
            //         # Insert the context language or the provided language
            //         elif lang_url_code != default_lg.url_code or force_lang:
            //             ps.insert(1, lang_url_code)
            //             # Remove the last empty string to avoid trailing / after joining
            //             if not ps[-1]:
            //                 ps.pop(-1)
            // 
            //         location = '/'.join(ps) + sep + qs
            // return location
            */
            return default;
        }

        protected async Task<string> UrlLocalizedInternalAsync(object url, object lang_code, object canonical_domain, bool prefetch_langs, bool force_default_lang)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def _url_localized(cls,
            //     url: str | None = None,
            //     lang_code: str | None = None,
            //     canonical_domain: str | tuple[str, str, str, str, str] | None = None,
            //     prefetch_langs: bool = False, force_default_lang: bool = False) -> str:
            // """ Returns the given URL adapted for the given lang, meaning that:
            // 1. It will have the lang suffixed to it
            // 2. The model converter parts will be translated
            // 
            // If it is not possible to rebuild a path, use the current one instead.
            // `url_quote_plus` is applied on the returned path.
            // 
            // It will also force the canonical domain is requested.
            // Eg:
            // - `_get_url_localized(lang_fr, '/shop/my-phone-14')` will return
            //     `/fr/shop/mon-telephone-14`
            // - `_get_url_localized(lang_fr, '/shop/my-phone-14', True)` will return
            //     `<base_url>/fr/shop/mon-telephone-14`
            // """
            // if not lang_code:
            //     lang = request.lang
            // else:
            //     lang = request.env['res.lang']._get_data(code=lang_code)
            // 
            // if not url:
            //     qs = keep_query()
            //     url = request.httprequest.path + ('?%s' % qs if qs else '')
            // 
            // # '/shop/furn-0269-chaise-de-bureau-noire-17?' to
            // # '/shop/furn-0269-chaise-de-bureau-noire-17', otherwise -> 404
            // url, sep, qs = url.partition('?')
            // 
            // try:
            //     # Re-match the controller where the request path routes.
            //     rule, args = request.env['ir.http']._match(url)
            //     for key, val in list(args.items()):
            //         if isinstance(val, models.BaseModel):
            //             if isinstance(val._uid, RequestUID):
            //                 args[key] = val = val.with_user(request.uid)
            //             if val.env.context.get('lang') != lang.code:
            //                 args[key] = val = val.with_context(lang=lang.code)
            //             if prefetch_langs:
            //                 args[key] = val = val.with_context(prefetch_langs=True)
            //     router = http.root.get_db_router(request.db).bind('')
            //     path = router.build(rule.endpoint, args)
            // except (NotFound, AccessError, MissingError):
            //     # The build method returns a quoted URL so convert in this case for consistency.
            //     path = werkzeug.urls.url_quote_plus(url, safe='/')
            // if force_default_lang or lang != request.env['ir.http']._get_default_lang():
            //     path = f'/{lang.url_code}{path if path != "/" else ""}'
            // 
            // if canonical_domain:
            //     # canonical URLs should not have qs
            //     return werkzeug.urls.url_join(canonical_domain, path)
            // 
            // return path + sep + qs
            */
            return default;
        }

        public async Task<TEntity> UrlRewriteAsync<TEntity>(IEnumerable<TEntity> entities, object path, object query_args) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: http_routing, FILE: ir_http.py) ---
            // def url_rewrite(self, path, query_args=None):
            // new_url = False
            // router = http.root.get_db_router(request.db).bind('')
            // endpoint = False
            // try:
            //     try:
            //         endpoint = router.match(path, method='POST', query_args=query_args)
            //     except werkzeug.exceptions.MethodNotAllowed:
            //         endpoint = router.match(path, method='GET', query_args=query_args)
            // except werkzeug.routing.RequestRedirect as e:
            //     new_url = e.new_url.split('?')[0][7:]  # remove scheme
            //     _, endpoint = self.url_rewrite(new_url, query_args)
            //     endpoint = endpoint and [endpoint]
            // except werkzeug.exceptions.NotFound:
            //     new_url = path
            // return new_url or path, endpoint and endpoint[0]
            */
            return default;
        }

        public async Task<TEntity> VerifyRecaptchaTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ip_addr, object token, object action) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_recaptcha, FILE: ir_http.py) ---
            // def _verify_recaptcha_token(self, ip_addr, token, action=False):
            // """
            //     Verify a recaptchaV3 token and returns the result as a string.
            //     RecaptchaV3 verify DOC: https://developers.google.com/recaptcha/docs/verify
            // 
            //     :return: The result of the call to the google API:
            //              is_human: The token is valid and the user trustworthy.
            //              is_bot: The user is not trustworthy and most likely a bot.
            //              no_secret: No reCaptcha secret set in settings.
            //              wrong_action: the action performed to obtain the token does not match the one we are verifying.
            //              wrong_token: The token provided is invalid or empty.
            //              wrong_secret: The private key provided in settings is invalid.
            //              timeout: The request has timout or the token provided is too old.
            //              bad_request: The request is invalid or malformed.
            //     :rtype: str
            // """
            // private_key = request.env['ir.config_parameter'].sudo().get_param('recaptcha_private_key')
            // if not private_key:
            //     return 'no_secret'
            // min_score = request.env['ir.config_parameter'].sudo().get_param('recaptcha_min_score')
            // try:
            //     r = requests.post('https://www.recaptcha.net/recaptcha/api/siteverify', {
            //         'secret': private_key,
            //         'response': token,
            //         'remoteip': ip_addr,
            //     }, timeout=2)  # it takes ~50ms to retrieve the response
            //     result = r.json()
            //     res_success = result['success']
            //     res_action = res_success and action and result['action']
            // except requests.exceptions.Timeout:
            //     logger.error("Trial captcha verification timeout for ip address %s", ip_addr)
            //     return 'timeout'
            // except Exception:
            //     logger.error("Trial captcha verification bad request response")
            //     return 'bad_request'
            // 
            // if res_success:
            //     score = result.get('score', False)
            //     if score < float(min_score):
            //         logger.warning("Trial captcha verification for ip address %s failed with score %f.", ip_addr, score)
            //         return 'is_bot'
            //     if res_action and res_action != action:
            //         logger.warning("Trial captcha verification for ip address %s failed with action %f, expected: %s.", ip_addr, score, action)
            //         return 'wrong_action'
            //     logger.info("Trial captcha verification for ip address %s succeeded with score %f.", ip_addr, score)
            //     return 'is_human'
            // errors = result.get('error-codes', [])
            // logger.warning("Trial captcha verification for ip address %s failed error codes %r. token was: [%s]", ip_addr, errors, token)
            // for error in errors:
            //     if error in ['missing-input-secret', 'invalid-input-secret']:
            //         return 'wrong_secret'
            //     if error in ['missing-input-response', 'invalid-input-response']:
            //         return 'wrong_token'
            //     if error == 'timeout-or-duplicate':
            //         return 'timeout'
            //     if error == 'bad-request':
            //         return 'bad_request'
            // return 'is_bot'
            */
            return default;
        }

        public async Task<TEntity> VerifyRequestRecaptchaTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object action) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_recaptcha, FILE: ir_http.py) ---
            // def _verify_request_recaptcha_token(self, action):
            // """ Verify the recaptcha token for the current request.
            //     If no recaptcha private key is set the recaptcha verification
            //     is considered inactive and this method will return True.
            // """
            // ip_addr = request.httprequest.remote_addr
            // token = request.params.pop('recaptcha_token_response', False)
            // recaptcha_result = request.env['ir.http']._verify_recaptcha_token(ip_addr, token, action)
            // if recaptcha_result in ['is_human', 'no_secret']:
            //     return True
            // if recaptcha_result == 'wrong_secret':
            //     raise ValidationError(_("The reCaptcha private key is invalid."))
            // elif recaptcha_result == 'wrong_token':
            //     raise ValidationError(_("The reCaptcha token is invalid."))
            // elif recaptcha_result == 'timeout':
            //     raise UserError(_("Your request has timed out, please retry."))
            // elif recaptcha_result == 'bad_request':
            //     raise UserError(_("The request is invalid or malformed."))
            // else:
            //     return False
            --- ODOO METHOD SOURCE (MODULE: website_cf_turnstile, FILE: ir_http.py) ---
            // def _verify_request_recaptcha_token(self, action):
            // """ Verify the recaptcha token for the current request.
            //     If no recaptcha private key is set the recaptcha verification
            //     is considered inactive and this method will return True.
            // """
            // res = super()._verify_request_recaptcha_token(action)
            // 
            // if not res:  # check result of google_recaptcha
            //     return res
            // 
            // ip_addr = request.httprequest.remote_addr
            // token = request.params.pop('turnstile_captcha', False)
            // turnstile_result = request.env['ir.http']._verify_turnstile_token(ip_addr, token, action)
            // if turnstile_result in ['is_human', 'no_secret']:
            //     return True
            // if turnstile_result == 'wrong_secret':
            //     raise ValidationError(_("The Cloudflare turnstile private key is invalid."))
            // elif turnstile_result == 'wrong_token':
            //     raise ValidationError(_("The CloudFlare human validation failed."))
            // elif turnstile_result == 'timeout':
            //     raise UserError(_("Your request has timed out, please retry."))
            // elif turnstile_result == 'bad_request':
            //     raise UserError(_("The request is invalid or malformed."))
            // else:  # wrong_action e.g.
            //     return False
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_http.py) ---
            // def _verify_request_recaptcha_token(self, action):
            // return True
            */
            return default;
        }

        public async Task<TEntity> VerifyTurnstileTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ip_addr, object token, object action) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_cf_turnstile, FILE: ir_http.py) ---
            // def _verify_turnstile_token(self, ip_addr, token, action=False):
            // """
            //     Verify a turnstile token and returns the result as a string.
            //     Turnstile verify DOC: https://developers.cloudflare.com/turnstile/get-started/server-side-validation/
            // 
            //     :return: The result of the call to the cloudflare API:
            //              is_human: The token is valid and the user trustworthy.
            //              is_bot: The user is not trustworthy and most likely a bot.
            //              no_secret: No private key in settings.
            //              wrong_action: the action performed to obtain the token does not match the one we are verifying.
            //              wrong_token: The token provided is invalid or empty.
            //              wrong_secret: The private key provided in settings is invalid.
            //              timeout: The request has timout or the token provided is too old.
            //              bad_request: The request is invalid or malformed.
            //              internal-error: The request failed.
            //     :rtype: str
            // """
            // private_key = request.env['ir.config_parameter'].sudo().get_param('cf.turnstile_secret_key')
            // if not private_key:
            //     return 'no_secret'
            // try:
            //     r = requests.post('https://challenges.cloudflare.com/turnstile/v0/siteverify', {
            //         'secret': private_key,
            //         'response': token,
            //         'remoteip': ip_addr,
            //     }, timeout=3.05)
            //     result = r.json()
            //     res_success = result['success']
            //     res_action = res_success and action and result['action']
            // except requests.exceptions.Timeout:
            //     logger.error("Turnstile verification timeout for ip address %s", ip_addr)
            //     return 'timeout'
            // except Exception:
            //     logger.error("Turnstile verification bad request response")
            //     return 'bad_request'
            // 
            // if res_success:
            //     if res_action and res_action != action:
            //         logger.warning("Turnstile verification for ip address %s failed with action %f, expected: %s.", ip_addr, res_action, action)
            //         return 'wrong_action'
            //     logger.info("Turnstile verification for ip address %s succeeded", ip_addr)
            //     return 'is_human'
            // errors = result.get('error-codes', [])
            // logger.warning("Turnstile verification for ip address %s failed error codes %r. token was: [%s]", ip_addr, errors, token)
            // for error in errors:
            //     if error in ['missing-input-secret', 'invalid-input-secret']:
            //         return 'wrong_secret'
            //     if error in ['missing-input-response', 'invalid-input-response']:
            //         return 'wrong_token'
            //     if error in ('timeout-or-duplicate', 'internal-error'):
            //         return 'timeout'
            //     if error == 'bad-request':
            //         return 'bad_request'
            // return 'is_bot'
            */
            return default;
        }

        public async Task<TEntity> WebclientRenderingContextAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrHttpable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_http.py) ---
            // def webclient_rendering_context(self):
            // return {
            //     'menu_data': request.env['ir.ui.menu'].load_menus(request.session.debug),
            //     'session_info': self.session_info(),
            // }
            */
            return default;
        }
    }
}