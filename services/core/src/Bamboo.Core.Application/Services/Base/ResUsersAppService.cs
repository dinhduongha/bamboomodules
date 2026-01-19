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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("BaseModule", Category = "Base")]
    public partial class ResUsersAppService : GenericApplicationService<ResUsers>, IResUsersAppService
    {
        private readonly IBusListenerMixinAppService _busListenerMixinAppService;
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ResUsersAppService(IRepository<ResUsers, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IBusListenerMixinAppService busListenerMixinAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _busListenerMixinAppService = busListenerMixinAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<ResUsers> ActionResetPasswordInternalAsync(object signup_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py) ---
            // def _action_reset_password(self, signup_type="reset"):
            // """ create signup token for each user, and send their signup url by email """
            // if self.env.context.get('install_mode') or self.env.context.get('import_file'):
            //     return
            // if self.filtered(lambda user: not user.active):
            //     raise UserError(_("You cannot perform this action on an archived user."))
            // # prepare reset password signup
            // create_mode = bool(self.env.context.get('create_user'))
            // 
            // self.mapped('partner_id').signup_prepare(signup_type=signup_type)
            // 
            // # send email to users with their signup url
            // internal_account_created_template = None
            // portal_account_created_template = None
            // if create_mode:
            //     if any(user._is_internal() for user in self):
            //         internal_account_created_template = self.env.ref('auth_signup.set_password_email', raise_if_not_found=False)
            //         if internal_account_created_template and internal_account_created_template._name != 'mail.template':
            //             _logger.error("Wrong set password template %r", internal_account_created_template)
            //             return
            // 
            //     if any(not user._is_internal() for user in self):
            //         portal_account_created_template = self.env.ref('auth_signup.portal_set_password_email', raise_if_not_found=False)
            //         if portal_account_created_template and portal_account_created_template._name != 'mail.template':
            //             _logger.error("Wrong set password template %r", portal_account_created_template)
            //             return
            // 
            // email_values = {
            //     'email_cc': False,
            //     'auto_delete': True,
            //     'message_type': 'user_notification',
            //     'recipient_ids': [],
            //     'partner_ids': [],
            //     'scheduled_date': False,
            // }
            // 
            // for user in self:
            //     if not user.email:
            //         raise UserError(_("Cannot send email: user %s has no email address.", user.name))
            //     email_values['email_to'] = user.email
            //     with contextlib.closing(self.env.cr.savepoint()):
            //         is_internal = user._is_internal()
            //         account_created_template = internal_account_created_template if is_internal else portal_account_created_template
            //         if account_created_template:
            //             account_created_template.send_mail(
            //                 user.id, force_send=True,
            //                 raise_exception=True, email_values=email_values)
            //         else:
            //             user_lang = user.lang or self.env.lang or 'en_US'
            //             body = self.env['mail.render.mixin'].with_context(lang=user_lang)._render_template(
            //                 self.env.ref('auth_signup.reset_password_email'),
            //                 model='res.users', res_ids=user.ids,
            //                 engine='qweb_view', options={'post_process': True})[user.id]
            //             mail = self.env['mail.mail'].sudo().create({
            //                 'subject': self.with_context(lang=user_lang).env._('Password reset'),
            //                 'email_from': user.company_id.email_formatted or user.email_formatted,
            //                 'body_html': body,
            //                 **email_values,
            //             })
            //             mail.send()
            //     if signup_type == 'reset':
            //         _logger.info("Password reset email sent for user <%s> to <%s>", user.login, user.email)
            //         message = _('A reset password link was sent by email')
            //     else:
            //         _logger.info("Signup email sent for user <%s> to <%s>", user.login, user.email)
            //         message = _('A signup link was sent by email')
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'title': 'Notification',
            //         'message': message,
            //         'sticky': False
            //     }
            // }
            */
            return default;
        }

        protected async Task<ResUsers> ActionRevokeAllDevicesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _action_revoke_all_devices(self):
            // devices = self.env["res.device"].search([("user_id", "=", self.id)])
            // devices.filtered(lambda d: not d.is_current)._revoke()
            // return {'type': 'ir.actions.client', 'tag': 'reload'}
            */
            return default;
        }

        protected async Task<ResUsers> ActionShowInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _action_show(self):
            // """If self is a singleton, directly access the form view. If it is a recordset, open a list view"""
            // view_id = self.env.ref('base.view_users_form').id
            // action = {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'res.users',
            //     'context': {'create': False},
            // }
            // if len(self) > 1:
            //     action.update({
            //         'name': _('Users'),
            //         'view_mode': 'list,form',
            //         'views': [[None, 'list'], [view_id, 'form']],
            //         'domain': [('id', 'in', self.ids)],
            //     })
            // else:
            //     action.update({
            //         'view_mode': 'form',
            //         'views': [[view_id, 'form']],
            //         'res_id': self.id,
            //     })
            // return action
            */
            return default;
        }

        protected async Task<ResUsers> AddKarmaBatchInternalAsync(object values_per_user)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: res_users.py) ---
            // def _add_karma_batch(self, values_per_user):
            // if not values_per_user:
            //     return
            // 
            // create_values = []
            // for user, values in values_per_user.items():
            //     origin = values.get('source') or self.env.user
            //     reason = values.get('reason') or _('Add Manually')
            //     origin_description = f'{origin.display_name} #{origin.id}'
            //     old_value = values.get('old_value', user.karma)
            // 
            //     create_values.append({
            //         'new_value': old_value + values['gain'],
            //         'old_value': old_value,
            //         'origin_ref': f'{origin._name},{origin.id}',
            //         'reason': f'{reason} ({origin_description})',
            //         'user_id': user.id,
            //     })
            // 
            // self.env['gamification.karma.tracking'].sudo().create(create_values)
            // return True
            */
            return default;
        }

        protected async Task<ResUsers> AddKarmaInternalAsync(object gain, object source, object reason)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: res_users.py) ---
            // def _add_karma(self, gain, source=None, reason=None):
            // self.ensure_one()
            // values = {'gain': gain, 'source': source, 'reason': reason}
            // return self._add_karma_batch({self: values})
            */
            return default;
        }

        public async Task<ResUsers> ApiKeyWizardAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def api_key_wizard(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'res.users.apikeys.description',
            //     'name': 'New API Key',
            //     'target': 'new',
            //     'views': [(False, 'form')],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> ArchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def action_archive(self):
            // activities_to_delete = self.env['mail.activity'].sudo().search([('user_id', 'in', self.ids)])
            // activities_to_delete.unlink()
            // return super().action_archive()
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: res_users.py) ---
            // def action_archive(self):
            // self.env['crm.team.member'].search([('user_id', 'in', self.ids)]).action_archive()
            // return super().action_archive()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> AssertCanAuthInternalAsync(object user)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _assert_can_auth(self, user=None):
            // """ Checks that the current environment even allows the current auth
            // request to happen.
            // 
            // The baseline implementation is a simple linear login cooldown: after
            // a number of failures trying to log-in, the user (by login) is put on
            // cooldown. During the cooldown period, login *attempts* are ignored
            // and logged.
            // 
            // :param user: user id or login, for logging purpose
            // 
            // .. warning::
            // 
            //     The login counter is not shared between workers and not
            //     specifically thread-safe, the feature exists mostly for
            //     rate-limiting on large number of login attempts (brute-forcing
            //     passwords) so that should not be much of an issue.
            // 
            //     For a more complex strategy (e.g. database or distribute storage)
            //     override this method. To simply change the cooldown criteria
            //     (configuration, ...) override _on_login_cooldown instead.
            // 
            // .. note::
            // 
            //     This is a *context manager* so it can be called around the login
            //     procedure without having to call it itself.
            // """
            // # needs request for remote address
            // if not request:
            //     yield
            //     return
            // 
            // reg = self.env.registry
            // failures_map = getattr(reg, '_login_failures', None)
            // if failures_map is None:
            //     failures_map = reg._login_failures = collections.defaultdict(lambda : (0, datetime.datetime.min))
            // 
            // source = request.httprequest.remote_addr
            // (failures, previous) = failures_map[source]
            // if self._on_login_cooldown(failures, previous):
            //     _logger.warning(
            //         "Login attempt ignored for %s (user %r) on %s: "
            //         "%d failures since last success, last failure at %s. "
            //         "You can configure the number of login failures before a "
            //         "user is put on cooldown as well as the duration in the "
            //         "System Parameters. Disable this feature by setting "
            //         "\"base.login_cooldown_after\" to 0.",
            //         source, user or "?", self.env.cr.dbname, failures, previous)
            //     if ipaddress.ip_address(source).is_private:
            //         _logger.warning(
            //             "The rate-limited IP address %s is classified as private "
            //             "and *might* be a proxy. If your Odoo is behind a proxy, "
            //             "it may be mis-configured. Check that you are running "
            //             "Odoo in Proxy Mode and that the proxy is properly configured, see "
            //             "https://www.odoo.com/documentation/latest/administration/install/deploy.html#https for details.",
            //             source
            //         )
            //     raise AccessDenied(_("Too many login failures, please wait a bit before trying again."))
            // 
            // try:
            //     yield
            // except AccessDenied:
            //     (failures, __) = reg._login_failures[source]
            //     reg._login_failures[source] = (failures + 1, datetime.datetime.now())
            //     raise
            // else:
            //     reg._login_failures.pop(source, None)
            */
            return default;
        }

        public async Task<ResUsers> AuthOauthAsync(Guid id, ResUsersAuthOauthRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py) ---
            // def auth_oauth(self, provider, params):
            // # Advice by Google (to avoid Confused Deputy Problem)
            // # if validation.audience != OUR_CLIENT_ID:
            // #   abort()
            // # else:
            // #   continue with the process
            // access_token = params.get('access_token')
            // validation = self._auth_oauth_validate(provider, access_token)
            // 
            // # retrieve and sign in user
            // login = self._auth_oauth_signin(provider, validation, params)
            // if not login:
            //     raise AccessDenied()
            // # return user credentials
            // return (self.env.cr.dbname, login, access_token)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> AuthOauthRpcInternalAsync(object endpoint, object access_token)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py) ---
            // def _auth_oauth_rpc(self, endpoint, access_token):
            // if self.env['ir.config_parameter'].sudo().get_param('auth_oauth.authorization_header'):
            //     response = requests.get(endpoint, headers={'Authorization': 'Bearer %s' % access_token}, timeout=10)
            // else:
            //     response = requests.get(endpoint, params={'access_token': access_token}, timeout=10)
            // 
            // if response.ok: # nb: could be a successful failure
            //     return response.json()
            // 
            // auth_challenge = parse_auth(response.headers.get("WWW-Authenticate"))
            // if auth_challenge and auth_challenge.type == 'bearer' and 'error' in auth_challenge:
            //     return dict(auth_challenge)
            // 
            // return {'error': 'invalid_request'}
            */
            return default;
        }

        protected async Task<ResUsers> AuthOauthSigninInternalAsync(object provider, object validation, object @params)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py) ---
            // def _auth_oauth_signin(self, provider, validation, params):
            // """ retrieve and sign in the user corresponding to provider and validated access token
            //     :param provider: oauth provider id (int)
            //     :param validation: result of validation of access token (dict)
            //     :param params: oauth parameters (dict)
            //     :return: user login (str)
            //     :raise: AccessDenied if signin failed
            // 
            //     This method can be overridden to add alternative signin methods.
            // """
            // oauth_uid = validation['user_id']
            // try:
            //     oauth_user = self.search([("oauth_uid", "=", oauth_uid), ('oauth_provider_id', '=', provider)])
            //     if not oauth_user:
            //         raise AccessDenied()
            //     assert len(oauth_user) == 1
            //     oauth_user.write({'oauth_access_token': params['access_token']})
            //     return oauth_user.login
            // except AccessDenied as access_denied_exception:
            //     if self.env.context.get('no_user_creation'):
            //         return None
            //     state = json.loads(params['state'])
            //     token = state.get('t')
            //     values = self._generate_signup_values(provider, validation, params)
            //     try:
            //         login, _ = self.signup(values, token)
            //         return login
            //     except (SignupError, UserError):
            //         raise access_denied_exception
            */
            return default;
        }

        protected async Task<ResUsers> AuthOauthValidateInternalAsync(object provider, object access_token)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py) ---
            // def _auth_oauth_validate(self, provider, access_token):
            // """ return the validation data corresponding to the access token """
            // oauth_provider = self.env['auth.oauth.provider'].browse(provider)
            // validation = self._auth_oauth_rpc(oauth_provider.validation_endpoint, access_token)
            // if validation.get("error"):
            //     raise Exception(validation['error'])
            // if oauth_provider.data_endpoint:
            //     data = self._auth_oauth_rpc(oauth_provider.data_endpoint, access_token)
            //     validation.update(data)
            // # unify subject key, pop all possible and get most sensible. When this
            // # is reworked, BC should be dropped and only the `sub` key should be
            // # used (here, in _generate_signup_values, and in _auth_oauth_signin)
            // subject = next(filter(None, [
            //     validation.pop(key, None)
            //     for key in [
            //         'sub', # standard
            //         'id', # google v1 userinfo, facebook opengraph
            //         'user_id', # google tokeninfo, odoo (tokeninfo)
            //     ]
            // ]), None)
            // if not subject:
            //     raise AccessDenied(self.env._('Missing subject identity'))
            // validation['user_id'] = subject
            // 
            // return validation
            */
            return default;
        }

        public async Task<ResUsers> AuthenticateAsync(Guid id, ResUsersAuthenticateRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py) ---
            // def authenticate(self, credential, user_agent_env):
            // """Send an alert on new connection.
            // 
            // - 2FA enabled -> only for new device
            // - Not enabled -> no alert
            // """
            // auth_info = super().authenticate(credential, user_agent_env)
            // self._notify_security_new_connection(auth_info)
            // return auth_info
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_users.py) ---
            // def authenticate(self, credential, user_agent_env):
            // """ Override to link the logged in user's res.partner to website.visitor.
            // If a visitor already exists for that user, assign it data from the
            // current anonymous visitor (if exists).
            // Purpose is to try to aggregate as much sub-records (tracked pages,
            // leads, ...) as possible. """
            // visitor_pre_authenticate_sudo = None
            // if request and request.env:
            //     visitor_pre_authenticate_sudo = request.env['website.visitor']._get_visitor_from_request()
            // auth_info = super().authenticate(credential, user_agent_env)
            // if auth_info.get('uid') and visitor_pre_authenticate_sudo:
            //     env = self.env(user=auth_info['uid'])
            //     user_partner = env.user.partner_id
            //     visitor_current_user_sudo = env['website.visitor'].sudo().search([
            //         ('partner_id', '=', user_partner.id)
            //     ], limit=1)
            //     if visitor_current_user_sudo:
            //         # A visitor exists for the logged in user, link public
            //         # visitor records to it.
            //         if visitor_pre_authenticate_sudo != visitor_current_user_sudo:
            //             visitor_pre_authenticate_sudo._merge_visitor(visitor_current_user_sudo)
            //         visitor_current_user_sudo._update_visitor_last_visit()
            //     else:
            //         visitor_pre_authenticate_sudo.access_token = user_partner.id
            //         visitor_pre_authenticate_sudo._update_visitor_last_visit()
            // return auth_info
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def authenticate(self, credential, user_agent_env):
            // """Verifies and returns the user ID corresponding to the given
            // ``credential``, or False if there was no matching user.
            // 
            // :param dict credential: a dictionary where the `type` key defines the authentication method and
            //     additional keys are passed as required per authentication method.
            //     For example:
            //     - { 'type': 'password', 'login': 'username', 'password': '123456' }
            //     - { 'type': 'webauthn', 'webauthn_response': '{json data}' }
            // :param dict user_agent_env: environment dictionary describing any
            //     relevant environment attributes
            // :return: auth_info
            // :rtype: dict
            // """
            // auth_info = self._login(credential, user_agent_env=user_agent_env)
            // if user_agent_env and user_agent_env.get('base_location'):
            //     env = self.env(user=auth_info['uid'])
            //     if env.user.has_group('base.group_system'):
            //         # Successfully logged in as system user!
            //         # Attempt to guess the web base url...
            //         try:
            //             base = user_agent_env['base_location']
            //             ICP = env['ir.config_parameter']
            //             if not ICP.get_param('web.base.url.freeze'):
            //                 ICP.set_param('web.base.url', base)
            //         except Exception:
            //             _logger.exception("Failed to update web.base.url configuration parameter")
            // return auth_info
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> BusChannelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: res_users.py) ---
            // def _bus_channel(self):
            // return self.partner_id
            */
            return default;
        }

        protected async Task<ResUsers> CanImportRemoteUrlsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import, FILE: base_import.py) ---
            // def _can_import_remote_urls(self):
            // """ Hook to decide whether the current user is allowed to import
            // images via URL (as such an import can DOS a worker). By default,
            // allows the administrator group.
            // 
            // :rtype: bool
            // """
            // self.ensure_one()
            // return self._is_admin()
            */
            return default;
        }

        protected async Task<ResUsers> CanManageUnsplashSettingsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_unsplash, FILE: res_users.py) ---
            // def _can_manage_unsplash_settings(self):
            // self.ensure_one()
            // # Website has no dependency to web_unsplash, we cannot warranty the order of the execution
            // # of the overwrite done in 5ef8300.
            // # So to avoid to create a new module bridge, with a lot of code, we prefer to make a check
            // # here for website's user.
            // return (self.sudo().has_group('base.group_erp_manager')
            //         or self.sudo().has_group('website.group_website_restricted_editor'))
            */
            return default;
        }

        public async Task<ResUsers> ChangePasswordAsync(Guid id, ResUsersChangePasswordRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_ldap, FILE: res_users.py) ---
            // def change_password(self, old_passwd, new_passwd):
            // if new_passwd:
            //     Ldap = self.env['res.company.ldap']
            //     for conf in Ldap._get_ldap_dicts():
            //         changed = Ldap._change_password(conf, self.env.user.login, old_passwd, new_passwd)
            //         if changed:
            //             self.env.user._set_empty_password()
            //             return True
            // return super().change_password(old_passwd, new_passwd)
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py) ---
            // def change_password(self, old_passwd, new_passwd):
            // self.env.user._revoke_all_devices()
            // return super().change_password(old_passwd, new_passwd)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def change_password(self, old_passwd, new_passwd):
            // """Change current user password. Old password must be provided explicitly
            // to prevent hijacking an existing user session, or for cases where the cleartext
            // password is not used to authenticate requests.
            // 
            // :return: True
            // :raise: odoo.exceptions.AccessDenied when old password is wrong
            // :raise: odoo.exceptions.UserError when new password is not set or empty
            // """
            // if not old_passwd:
            //     raise AccessDenied()
            // 
            // # alternatively: use identitycheck wizard?
            // credential = {'login': self.env.user.login, 'password': old_passwd, 'type': 'password'}
            // self._check_credentials(credential, {'interactive': True})
            // 
            // # use self.env.user here, because it has uid=SUPERUSER_ID
            // self.env.user._change_password(new_passwd)
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> ChangePasswordInternalAsync(object new_passwd)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _change_password(self, new_passwd):
            // new_passwd = new_passwd.strip()
            // if not new_passwd:
            //     raise UserError(_("Setting empty passwords is not allowed for security reasons!"))
            // 
            // ip = request.httprequest.environ['REMOTE_ADDR'] if request else 'n/a'
            // _logger.info(
            //     "Password change for %r (#%d) by %r (#%d) from %s",
            //      self.login, self.id,
            //      self.env.user.login, self.env.user.id,
            //      ip
            // )
            // 
            // self.password = new_passwd
            */
            return default;
        }

        public async Task<ResUsers> ChangePasswordWizardAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def action_change_password_wizard(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'target': 'new',
            //     'res_model': 'change.password.wizard',
            //     'view_mode': 'form',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> CheckActionIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _check_action_id(self):
            // action_open_website = self.env.ref('base.action_open_website', raise_if_not_found=False)
            // if action_open_website and any(user.action_id.id == action_open_website.id for user in self):
            //     raise ValidationError(_('The "App Switcher" action cannot be selected as home action.'))
            // # We use sudo() because  "Access rights" admins can't read action models
            // for user in self.sudo():
            //     if user.action_id.type == "ir.actions.client":
            //         # Prevent using reload actions.
            //         action = self.env["ir.actions.client"].browse(user.action_id.id)  # magic
            //         if action.tag == "reload":
            //             raise ValidationError(_('The "%s" action cannot be selected as home action.', action.name))
            // 
            //     elif user.action_id.type == "ir.actions.act_window":
            //         # Restrict actions that include 'active_id' in their context.
            //         action = self.env["ir.actions.act_window"].browse(user.action_id.id)  # magic
            //         if not action.context:
            //             continue
            //         if "active_id" in action.context:
            //             raise ValidationError(
            //                 _('The action "%s" cannot be set as the home action because it requires a record to be selected beforehand.', action.name)
            //             )
            */
            return default;
        }

        protected async Task<ResUsers> CheckAtLeastOneAdministratorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _check_at_least_one_administrator(self):
            // if not self.env.registry._init_modules:
            //     return  # ignore the constraint when updating the module 'base'
            // if not self.env.ref('base.group_system').user_ids:
            //     raise ValidationError(_("You must have at least an administrator user."))
            */
            return default;
        }

        public async Task<ResUsers> CheckCalendarCredentialsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_users.py) ---
            // def check_calendar_credentials(self):
            // return {}
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py) ---
            // def check_calendar_credentials(self):
            // res = super().check_calendar_credentials()
            // res['google_calendar'] = self._has_setup_credentials()
            // return res
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py) ---
            // def check_calendar_credentials(self):
            // res = super().check_calendar_credentials()
            // res['microsoft_calendar'] = self._has_setup_microsoft_credentials()
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> CheckCompanyDomainInternalAsync(object companies)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _check_company_domain(self, companies):
            // if not companies:
            //     return Domain.TRUE
            // company_ids = companies if isinstance(companies, str) else models.to_record_ids(companies)
            // return Domain('company_ids', 'in', company_ids)
            */
            return default;
        }

        protected async Task<ResUsers> CheckCredentialsInternalAsync(object credential, object env)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_ldap, FILE: res_users.py) ---
            // def _check_credentials(self, credential, env):
            // try:
            //     return super()._check_credentials(credential, env)
            // except AccessDenied:
            //     if not (credential['type'] == 'password' and credential.get('password')):
            //         raise
            //     passwd_allowed = env['interactive'] or not self.env.user._rpc_api_keys_only()
            //     if passwd_allowed and self.env.user.active:
            //         Ldap = self.env['res.company.ldap']
            //         for conf in Ldap._get_ldap_dicts():
            //             if Ldap._authenticate(conf, self.env.user.login, credential['password']):
            //                 return {
            //                     'uid': self.env.user.id,
            //                     'auth_method': 'ldap',
            //                     'mfa': 'default',
            //                 }
            //     raise
            --- ODOO METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py) ---
            // def _check_credentials(self, credential, env):
            // try:
            //     return super()._check_credentials(credential, env)
            // except AccessDenied:
            //     if not (credential['type'] == 'oauth_token' and credential['token']):
            //         raise
            //     passwd_allowed = env['interactive'] or not self.env.user._rpc_api_keys_only()
            //     if passwd_allowed and self.env.user.active:
            //         res = self.sudo().search([('id', '=', self.env.uid), ('oauth_access_token', '=', credential['token'])])
            //         if res:
            //             return {
            //                 'uid': self.env.user.id,
            //                 'auth_method': 'oauth',
            //                 'mfa': 'default',
            //             }
            //     raise
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: res_users.py) ---
            // def _check_credentials(self, credential, env):
            // if credential['type'] == 'webauthn':
            //     webauthn = json.loads(credential['webauthn_response'])
            //     passkey = self.env['auth.passkey.key'].sudo().search([
            //         ("create_uid", "=", self.env.user.id),
            //         ("credential_identifier", "=", webauthn['id']),
            //     ])
            //     if not passkey:
            //         raise AccessDenied(_('Unknown passkey'))
            //     try:
            //         new_sign_count = self.env['auth.passkey.key']._verify_auth(
            //             webauthn,
            //             passkey.public_key,
            //             passkey.sign_count,
            //         )
            //     except InvalidAuthenticationResponse as e:
            //         raise AccessDenied(e.args[0]) from None
            //     passkey.sign_count = new_sign_count
            //     return {
            //         'uid': self.env.user.id,
            //         'auth_method': 'passkey',
            //         'mfa': 'skip',
            //     }
            // else:
            //     return super()._check_credentials(credential, env)
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py) ---
            // def _check_credentials(self, credentials, env):
            // if credentials['type'] == 'totp':
            //     self._totp_rate_limit('code_check')
            //     sudo = self.sudo()
            //     key = base64.b32decode(sudo.totp_secret)
            //     match = TOTP(key).match(credentials['token'])
            //     if match is None:
            //         _logger.info("2FA check: FAIL for %s %r", self, sudo.login)
            //         raise AccessDenied(_("Verification failed, please double-check the 6-digit code"))
            // 
            //     if sudo.totp_last_counter and match <= sudo.totp_last_counter:
            //         _logger.warning("2FA check: REUSE for %s %r", self, sudo.login)
            //         raise AccessDenied(_("Verification failed, please use the latest 6-digit code"))
            // 
            //     sudo.totp_last_counter = match
            //     _logger.info("2FA check: SUCCESS for %s %r", self, sudo.login)
            //     self._totp_rate_limit_purge('code_check')
            //     return {
            //         'uid': self.env.user.id,
            //         'auth_method': 'totp',
            //         'mfa': 'default',
            //     }
            // return super()._check_credentials(credentials, env)
            --- ODOO METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py) ---
            // def _check_credentials(self, credentials, env):
            // if credentials['type'] == 'totp_mail':
            //     self._totp_rate_limit('code_check')
            //     user = self.sudo()
            //     key = user._get_totp_mail_key()
            //     match = TOTP(key).match(credentials['token'], window=3600, timestep=3600)
            //     if match is None:
            //         _logger.info("2FA check (mail): FAIL for %s %r", user, user.login)
            //         raise AccessDenied(_("Verification failed, please double-check the 6-digit code"))
            //     _logger.info("2FA check(mail): SUCCESS for %s %r", user, user.login)
            //     self._totp_rate_limit_purge('code_check')
            //     self._totp_rate_limit_purge('send_email')
            //     return {
            //         'uid': self.env.user.id,
            //         'auth_method': 'totp_mail',
            //         'mfa': 'default',
            //     }
            // else:
            //     return super()._check_credentials(credentials, env)
            --- ODOO METHOD SOURCE (MODULE: website_sale_wishlist, FILE: res_users.py) ---
            // def _check_credentials(self, credential, env):
            // """Make all wishlists from session belong to its owner user."""
            // result = super()._check_credentials(credential, env)
            // if request and request.session.get('wishlist_ids'):
            //     self.env["product.wishlist"]._check_wishlist_from_session()
            // return result
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _check_credentials(self, credential, env):
            // """ Validates the current user's password.
            // 
            // Override this method to plug additional authentication methods.
            // 
            // Overrides should:
            // 
            // * call ``super`` to delegate to parents for credentials-checking
            // * catch :class:`~odoo.exceptions.AccessDenied` and perform their
            //   own checking
            // * (re)raise :class:`~odoo.exceptions.AccessDenied` if the
            //   credentials are still invalid according to their own
            //   validation method
            // * return the ``auth_info``
            // 
            // When trying to check for credentials validity, call
            // :meth:`_check_credentials` instead.
            // 
            // Credentials are considered to be untrusted user input, for more
            // information please check :meth:`authenticate`
            // 
            // :returns: ``auth_info`` dictionary containing:
            // 
            //   - uid: the uid of the authenticated user
            //   - auth_method: which method was used during authentication
            //   - mfa: whether mfa should be skipped or not, possible values:
            // 
            //     - enforce: enforce mfa no matter what (not yet implemented)
            //     - default: delegate to auth_totp
            //     - skip: skip mfa no matter what
            // 
            //   Examples:
            // 
            //   - ``{ 'uid': 20, 'auth_method': 'password',      'mfa': 'default' }``
            //   - ``{ 'uid': 17, 'auth_method': 'impersonation', 'mfa': 'enforce' }``
            //   - ``{ 'uid': 32, 'auth_method': 'webauthn',      'mfa': 'skip'    }``
            // :rtype: dict
            // """
            // if not (credential['type'] == 'password' and credential.get('password')):
            //     raise AccessDenied()
            // 
            // env = env or {}
            // interactive = env.get('interactive', True)
            // 
            // if interactive or not self.env.user._rpc_api_keys_only():
            //     if 'interactive' not in env:
            //         _logger.warning(
            //             "_check_credentials without 'interactive' env key, assuming interactive login. \
            //             Check calls and overrides to ensure the 'interactive' key is properly set in \
            //             all _check_credentials environments"
            //         )
            // 
            //     self.env.cr.execute(
            //         "SELECT COALESCE(password, '') FROM res_users WHERE id=%s",
            //         [self.env.user.id]
            //     )
            //     [hashed] = self.env.cr.fetchone()
            //     valid, replacement = self._crypt_context()\
            //         .verify_and_update(credential['password'], hashed)
            //     if replacement is not None:
            //         self._set_encrypted_password(self.env.user.id, replacement)
            //         if request and self == self.env.user:
            //             self.env.flush_all()
            //             self.env.registry.clear_cache()
            //             # update session token so the user does not get logged out
            //             new_token = self.env.user._compute_session_token(request.session.sid)
            //             request.session.session_token = new_token
            // 
            //     if valid:
            //         return {
            //             'uid': self.env.user.id,
            //             'auth_method': 'password',
            //             'mfa': 'default',
            //         }
            // 
            // if not interactive:
            //     # 'rpc' scope does not really exist, we basically require a global key (scope NULL)
            //     if self.env['res.users.apikeys']._check_credentials(scope='rpc', key=credential['password']) == self.env.uid:
            //         return {
            //             'uid': self.env.user.id,
            //             'auth_method': 'apikey',
            //             'mfa': 'default',
            //         }
            // 
            //     if self.env.user._rpc_api_keys_only():
            //         _logger.info(
            //             "Invalid API key or password-based authentication attempted for a non-interactive (API) "
            //             "context that requires API key authentication only."
            //         )
            // 
            // raise AccessDenied()
            */
            return default;
        }

        protected async Task<ResUsers> CheckDisjointGroupsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_users.py) ---
            // def _check_disjoint_groups(self):
            // super()._check_disjoint_groups()
            // internal_users = self.env.ref('base.group_user').all_user_ids & self
            // if any(user.website_id for user in internal_users):
            //     raise ValidationError(_("Remove website on related partner before they become internal user."))
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _check_disjoint_groups(self):
            // """We check that no users are both portal and users (same with public).
            //    This could typically happen because of implied groups.
            // """
            // user_type_groups = self.env['res.groups']._get_user_type_groups()
            // for user in self:
            //     disjoint_groups = user.all_group_ids & user_type_groups
            //     if len(disjoint_groups) > 1:
            //         raise ValidationError(_(
            //             "User %(user)s cannot be at the same time in exclusive groups %(groups)s.",
            //             user=repr(user.name),
            //             groups=", ".join(repr(g.display_name) for g in disjoint_groups),
            //         ))
            */
            return default;
        }

        protected async Task<ResUsers> CheckLoginInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_users.py) ---
            // def _check_login(self):
            // """ Do not allow two users with the same login without website """
            // self.flush_model(['login', 'website_id'])
            // self.env.cr.execute(
            //     """SELECT login
            //          FROM res_users
            //         WHERE login IN (SELECT login FROM res_users WHERE id IN %s AND website_id IS NULL)
            //           AND website_id IS NULL
            //      GROUP BY login
            //        HAVING COUNT(*) > 1
            //     """,
            //     (tuple(self.ids),)
            // )
            // if self.env.cr.rowcount:
            //     raise ValidationError(_('You can not have two users with the same login!'))
            */
            return default;
        }

        protected async Task<ResUsers> CheckPasswordPolicyInternalAsync(object passwords)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_password_policy, FILE: res_users.py) ---
            // def _check_password_policy(self, passwords):
            // failures = []
            // params = self.env['ir.config_parameter'].sudo()
            // 
            // minlength = int(params.get_param('auth_password_policy.minlength', default=0))
            // for password in passwords:
            //     if not password:
            //         continue
            //     if len(password) < minlength:
            //         failures.append(_("Your password must contain at least %(minimal_length)d characters and only has %(current_count)d.", minimal_length=minlength, current_count=len(password)))
            // 
            // if failures:
            //     raise UserError(u'\n\n '.join(failures))
            */
            return default;
        }

        protected async Task<ResUsers> CheckPendingOdooRecordsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py) ---
            // def _check_pending_odoo_records(self):
            // """ Returns True if sync is active and there are records to be synchronized to Google. """
            // if self._get_google_sync_status() != "sync_active":
            //     return False
            // pending_events = self.env['calendar.event']._check_any_records_to_sync()
            // pending_recurrences = self.env['calendar.recurrence']._check_any_records_to_sync()
            // return pending_events or pending_recurrences
            */
            return default;
        }

        public async Task<ResUsers> CheckSynchronizationStatusAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_users.py) ---
            // def check_synchronization_status(self):
            // return {}
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py) ---
            // def check_synchronization_status(self):
            // res = super().check_synchronization_status()
            // credentials_status = self.check_calendar_credentials()
            // sync_status = 'missing_credentials'
            // if credentials_status.get('google_calendar'):
            //     sync_status = self._get_google_sync_status()
            //     if sync_status == 'sync_active' and not self.sudo().google_calendar_rtoken:
            //         sync_status = 'sync_stopped'
            // res['google_calendar'] = sync_status
            // return res
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py) ---
            // def check_synchronization_status(self):
            // res = super().check_synchronization_status()
            // credentials_status = self.check_calendar_credentials()
            // sync_status = 'missing_credentials'
            // if credentials_status.get('microsoft_calendar'):
            //     sync_status = self._get_microsoft_sync_status()
            //     if sync_status == 'sync_active' and not self.sudo().microsoft_calendar_token:
            //         sync_status = 'sync_stopped'
            // res['microsoft_calendar'] = sync_status
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> CheckUidPasswdInternalAsync(object uid, object passwd)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _check_uid_passwd(self, uid, passwd):
            // """Verifies that the given (uid, password) is authorized and
            //    raise an exception if it is not."""
            // if not passwd:
            //     # empty passwords disallowed for obvious security reasons
            //     raise AccessDenied()
            // 
            // with self._assert_can_auth(user=uid):
            //     user = self.with_user(uid).env.user
            //     if not user.active:
            //         raise AccessDenied()
            //     credential = {'login': user.login, 'password': passwd, 'type': 'password'}
            //     user._check_credentials(credential, {'interactive': False})
            */
            return default;
        }

        protected async Task<ResUsers> CheckUserCompanyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _check_user_company(self):
            // for user in self.filtered(lambda u: u.active):
            //     if user.company_id not in user.company_ids:
            //         raise ValidationError(
            //             _('Company %(company_name)s is not in the allowed companies for user %(user_name)s (%(company_allowed)s).',
            //               company_name=user.company_id.name,
            //               user_name=user.name,
            //               company_allowed=', '.join(user.mapped('company_ids.name')))
            //         )
            */
            return default;
        }

        protected async Task<ResUsers> CleanAttendanceOfficersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: res_users.py) ---
            // def _clean_attendance_officers(self):
            // attendance_officers = self.env['hr.employee'].search(
            //     [('attendance_manager_id', 'in', self.ids)]).attendance_manager_id
            // officers_to_remove_ids = self - attendance_officers
            // if officers_to_remove_ids:
            //     self.env.ref('hr_attendance.group_hr_attendance_officer').user_ids = [(3, user.id) for user in
            //                                                                        officers_to_remove_ids]
            */
            return default;
        }

        protected async Task<ResUsers> CleanLeaveResponsibleUsersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: res_users.py) ---
            // def _clean_leave_responsible_users(self):
            // # self = old bunch of leave responsibles
            // # This method compares the current leave managers
            // # and remove the access rights to those who don't
            // # need them anymore
            // approver_group = 'hr_holidays.group_hr_holidays_responsible'
            // if not any(u.has_group(approver_group) for u in self):
            //     return
            // 
            // res = self.env['hr.employee']._read_group(
            //     [('leave_manager_id', 'in', self.ids)],
            //     ['leave_manager_id'])
            // responsibles_to_remove_ids = set(self.ids) - {leave_manager.id for [leave_manager] in res}
            // if responsibles_to_remove_ids:
            //     self.browse(responsibles_to_remove_ids).write({
            //         'group_ids': [Command.unlink(self.env.ref(approver_group).id)],
            //     })
            */
            return default;
        }

        protected async Task<ResUsers> ComputeAccessesCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _compute_accesses_count(self):
            // for user in self:
            //     groups = user.all_group_ids
            //     user.accesses_count = len(groups.model_access)
            //     user.rules_count = len(groups.rule_groups)
            //     user.groups_count = len(groups)
            */
            return default;
        }

        protected async Task<ResUsers> ComputeAllGroupIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _compute_all_group_ids(self):
            // for user in self:
            //     user.all_group_ids = user.group_ids.all_implied_ids
            */
            return default;
        }

        protected async Task<ResUsers> ComputeCalendarDefaultPrivacyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_users.py) ---
            // def _compute_calendar_default_privacy(self):
            // """
            // Compute the calendar default privacy of the users, pointing to its ResUsersSettings.
            // When any user doesn't have its setting from ResUsersSettings defined, fallback to Default User Template's.
            // """
            // fallback_default_privacy = 'public'
            // # sudo: any user has access to other users calendar_default_privacy setting
            // if any(not user.sudo().res_users_settings_id.calendar_default_privacy for user in self):
            //     fallback_default_privacy = self._default_user_calendar_default_privacy()
            // 
            // for user in self:
            //     user.calendar_default_privacy = user.sudo().res_users_settings_id.calendar_default_privacy or fallback_default_privacy
            */
            return default;
        }

        protected async Task<ResUsers> ComputeCanEditRoleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _compute_can_edit_role(self):
            // self.can_edit_role = self.env["res.role"].sudo(False).has_access("write")
            */
            return default;
        }

        protected async Task<ResUsers> ComputeCompaniesCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _compute_companies_count(self):
            // self.companies_count = self.env['res.company'].sudo().search_count([])
            */
            return default;
        }

        protected async Task<ResUsers> ComputeCompanyEmployeeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def _compute_company_employee(self):
            // employee_per_user = {
            //     employee.user_id: employee
            //     for employee in self.env['hr.employee'].search([('user_id', 'in', self.ids), ('company_id', '=', self.env.company.id)])
            // }
            // for user in self:
            //     user.employee_id = employee_per_user.get(user)
            */
            return default;
        }

        protected async Task<ResUsers> ComputeCrmTeamIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: res_users.py) ---
            // def _compute_crm_team_ids(self):
            // for user in self:
            //     user.crm_team_ids = user.crm_team_member_ids.crm_team_id
            */
            return default;
        }

        protected async Task<ResUsers> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: res_users.py) ---
            // def _compute_display_name(self):
            // super()._compute_display_name()
            // formatted_display_name = self.env.context.get('formatted_display_name')
            // team_id = self.env.context.get('crm_formatted_display_name_team', 0)
            // if formatted_display_name and team_id:
            //     leader_id = self.env['crm.team'].browse(team_id).user_id
            //     for user in self.filtered(lambda u: u == leader_id):
            //         user.display_name += " --%s--" % _("(Team Leader)")
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: res_users.py) ---
            // def _compute_display_name(self):
            // super()._compute_display_name()
            // for user in self:
            //     if user.env.context.get("formatted_display_name") and user.leave_date_to:
            //         name = "%s \t ✈ --%s %s--" % (user.display_name or user.name, _("Back on"), format_date(self.env, user.leave_date_to, self.env.user.lang, "medium"))
            //         user.display_name = name.strip()
            */
            return default;
        }

        protected async Task<ResUsers> ComputeEmailDomainPlaceholderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _compute_email_domain_placeholder(self):
            // domain = email_domain_extract(self.env.user.email)
            // self.email_domain_placeholder = _('e.g. %(placeholder)s', placeholder=f'email@{domain}') if domain else _('Email')
            */
            return default;
        }

        protected async Task<ResUsers> ComputeEmployeeCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def _compute_employee_count(self):
            // for user in self.with_context(active_test=False):
            //     user.employee_count = len(user.employee_ids)
            */
            return default;
        }

        protected async Task<ResUsers> ComputeHasAccessLivechatInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py) ---
            // def _compute_has_access_livechat(self):
            // for user in self.sudo():
            //     user.has_access_livechat = user.has_group('im_livechat.im_livechat_group_user')
            */
            return default;
        }

        protected async Task<ResUsers> ComputeHasExternalMailServerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _compute_has_external_mail_server(self):
            // self.has_external_mail_server = self.env['ir.config_parameter'].sudo().get_param(
            //     'base_setup.default_external_email_server')
            */
            return default;
        }

        protected async Task<ResUsers> ComputeHasOauthAccessTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py) ---
            // def _compute_has_oauth_access_token(self):
            // for user in self:
            //     user.has_oauth_access_token = bool(user.sudo().oauth_access_token)
            */
            return default;
        }

        protected async Task<ResUsers> ComputeImStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: res_users.py) ---
            // def _compute_im_status(self):
            // super()._compute_im_status()
            // on_leave_user_ids = self._get_on_leave_ids()
            // for user in self:
            //     if user.id in on_leave_user_ids:
            //         if user.im_status == 'online':
            //             user.im_status = 'leave_online'
            //         elif user.im_status == 'away':
            //             user.im_status = 'leave_away'
            //         elif user.im_status == 'busy':
            //             user.im_status = 'leave_busy'
            //         elif user.im_status == 'offline':
            //             user.im_status = 'leave_offline'
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking, FILE: res_users.py) ---
            // def _compute_im_status(self):
            // super()._compute_im_status()
            // dayfield = self.env['hr.employee']._get_current_day_location_field()
            // for user in self:
            //     location_type = user[dayfield].location_type
            //     if not location_type:
            //         continue
            //     im_status = user.im_status
            //     if im_status in ["online", "away", "busy", "offline"]:
            //         user.im_status = "presence_" + location_type + "_" + im_status
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _compute_im_status(self):
            // for user in self:
            //     user.im_status = (
            //         "offline"
            //         if user.presence_ids.status in ["offline", False]
            //         else user.manual_im_status or user.presence_ids.status
            //     )
            */
            return default;
        }

        protected async Task<ResUsers> ComputeIsHrUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def _compute_is_hr_user(self):
            // is_hr_user = self.env.user.has_group('hr.group_hr_user')
            // for user in self:
            //     user.is_hr_user = is_hr_user
            */
            return default;
        }

        protected async Task<ResUsers> ComputeIsOutOfOfficeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _compute_is_out_of_office(self):
            // """ Out-of-office is considered as activated once out_of_office_from is
            // set in the past. "To" is not mandatory, as users could simply deactivate
            // it when coming back if the leave timerange is unknown. """
            // now = self.env.cr.now()
            // todo = self.filtered(lambda u: u.out_of_office_from and u._is_internal())
            // for user in todo:
            //     if user.out_of_office_to:
            //         user.is_out_of_office = (user.out_of_office_from <= now <= user.out_of_office_to)
            //     else:
            //         user.is_out_of_office = (user.out_of_office_from <= now)
            // (self - todo).is_out_of_office = False
            */
            return default;
        }

        protected async Task<ResUsers> ComputeIsSystemInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def _compute_is_system(self):
            // self.is_system = self.env.user._is_system()
            */
            return default;
        }

        protected async Task<ResUsers> ComputeKarmaInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: res_users.py) ---
            // def _compute_karma(self):
            // if self.env.context.get('skip_karma_computation'):
            //     # do not need to update the user karma
            //     # e.g. during the tracking consolidation
            //     return
            // 
            // self.env['gamification.karma.tracking'].flush_model()
            // 
            // select_query = """
            //     SELECT DISTINCT ON (user_id) user_id, new_value
            //       FROM gamification_karma_tracking
            //      WHERE user_id = ANY(%(user_ids)s)
            //   ORDER BY user_id, tracking_date DESC, id DESC
            // """
            // self.env.cr.execute(select_query, {'user_ids': self.ids})
            // 
            // user_karma_map = {
            //     values['user_id']: values['new_value']
            //     for values in self.env.cr.dictfetchall()
            // }
            // 
            // for user in self:
            //     user.karma = user_karma_map.get(user.id, 0)
            // 
            // self.sudo()._recompute_rank()
            */
            return default;
        }

        protected async Task<ResUsers> ComputeLivechatExpertiseIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py) ---
            // def _compute_livechat_expertise_ids(self):
            // for user in self:
            //     # sudo: livechat user can see the livechat expertise of any other user
            //     user.livechat_expertise_ids = user.sudo().res_users_settings_id.livechat_expertise_ids
            */
            return default;
        }

        protected async Task<ResUsers> ComputeLivechatIsInCallInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py) ---
            // def _compute_livechat_is_in_call(self):
            // for user in self:
            //     # sudo - res.users: checking if user is in call is allowed if the user is member of a live chat channel.
            //     user.livechat_is_in_call = user.sudo().is_in_call if user.livechat_channel_ids else None
            */
            return default;
        }

        protected async Task<ResUsers> ComputeLivechatLangIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py) ---
            // def _compute_livechat_lang_ids(self):
            // for user in self:
            //     # sudo: livechat user can see the livechat languages of any other user
            //     user.livechat_lang_ids = user.sudo().res_users_settings_id.livechat_lang_ids
            */
            return default;
        }

        protected async Task<ResUsers> ComputeLivechatOngoingSessionCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py) ---
            // def _compute_livechat_ongoing_session_count(self):
            // domain = [
            //     ("channel_id.livechat_end_dt", "=", False),
            //     ("member_id", "!=", False),
            //     ("partner_id", "in", self.partner_id.ids),
            //     ("channel_id.last_interest_dt", ">=", "-15M"),
            // ]
            // if channel_id := self.env.context.get('im_livechat_channel_id'):
            //     domain.append(("session_livechat_channel_id", "=", channel_id))
            // count_by_partner = dict(
            //     self.env["im_livechat.channel.member.history"]._read_group(
            //         domain, ["partner_id"], ["__count"],
            //     ),
            // )
            // for user in self:
            //     user.livechat_ongoing_session_count = count_by_partner.get(user.partner_id, 0)
            */
            return default;
        }

        protected async Task<ResUsers> ComputeLivechatUsernameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py) ---
            // def _compute_livechat_username(self):
            // for user in self:
            //     # sudo: livechat user can see the livechat username of any other user
            //     user.livechat_username = user.sudo().res_users_settings_id.livechat_username
            */
            return default;
        }

        protected async Task<ResUsers> ComputeNotificationTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _compute_notification_type(self):
            // # Because of the `group_ids` in the `api.depends`,
            // # this code will be called for any change of group on a user,
            // # even unrelated to the group_mail_notification_type_inbox or share flag.
            // # e.g. if you add HR > Manager to a user, this method will be called.
            // # It should therefore be written to be as performant as possible, and make the less change/write as possible
            // # when it's not `mail.group_mail_notification_type_inbox` or `share` that are being changed.
            // inbox_group_id = self.env['ir.model.data']._xmlid_to_res_id('mail.group_mail_notification_type_inbox')
            // 
            // self.filtered_domain([
            //     ('group_ids', 'in', inbox_group_id), ('notification_type', '!=', 'inbox')
            // ]).notification_type = 'inbox'
            // self.filtered_domain([
            //     ('group_ids', 'not in', inbox_group_id), ('notification_type', '=', 'inbox')
            // ]).notification_type = 'email'
            // 
            // # Special case: internal users with inbox notifications converted to portal must be converted to email users
            // new_portal_users = self.filtered_domain([('share', '=', True), ('notification_type', '=', 'inbox')])
            // new_portal_users.notification_type = 'email'
            // new_portal_users.write({"group_ids": [Command.unlink(inbox_group_id)]})
            */
            return default;
        }

        protected async Task<ResUsers> ComputeOutgoingMailServerIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _compute_outgoing_mail_server_id(self):
            // mail_servers = self.env['ir.mail_server'].sudo().search(fields.Domain.AND([
            //     [('from_filter', 'ilike', '_@_')],
            //     fields.Domain.OR([[
            //         ('from_filter', '=', user.email_normalized),
            //         ('smtp_user', '=', user.email),
            //         ('owner_user_id', '=', user._origin.id),
            //     ] for user in self]),
            // ]))
            // mail_servers = {m.owner_user_id: m for m in mail_servers}
            // for user in self:
            //     server = mail_servers.get(user) or self.env['ir.mail_server']
            //     user.outgoing_mail_server_id = server.id
            //     type_options = self._fields['outgoing_mail_server_type']._selection
            //     user.outgoing_mail_server_type = (
            //         server.smtp_authentication
            //         if server.smtp_authentication in type_options
            //         else 'default'
            //     )
            */
            return default;
        }

        protected async Task<ResUsers> ComputePasswordInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _compute_password(self):
            // for user in self:
            //     user.password = ''
            //     user.new_password = ''
            */
            return default;
        }

        protected async Task<ResUsers> ComputeResUsersSettingsIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _compute_res_users_settings_id(self):
            // for user in self:
            //     user.res_users_settings_id = user.res_users_settings_ids and user.res_users_settings_ids[0]
            */
            return default;
        }

        protected async Task<ResUsers> ComputeRoleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _compute_role(self):
            // for user in self:
            //     user.role = (
            //         'group_system' if user.has_group('base.group_system') else
            //         'group_user' if user.has_group('base.group_user') else
            //         False
            //     )
            */
            return default;
        }

        protected async Task<ResUsers> ComputeSaleTeamIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: res_users.py) ---
            // def _compute_sale_team_id(self):
            // for user in self:
            //     if not user.crm_team_member_ids.ids:
            //         user.sale_team_id = False
            //     else:
            //         sorted_memberships = user.crm_team_member_ids  # sorted by create date
            //         user.sale_team_id = sorted_memberships[0].crm_team_id if sorted_memberships else False
            */
            return default;
        }

        protected async Task<ResUsers> ComputeSessionTokenInternalAsync(object sid)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _compute_session_token(self, sid):
            // """ Compute a session token given a session id and a user id """
            // # retrieve the fields used to generate the session token
            // field_values = self._session_token_get_values()
            // return self._session_token_hash_compute(sid, field_values)
            */
            return default;
        }

        protected async Task<ResUsers> ComputeShareInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _compute_share(self):
            // user_group_id = self.env['ir.model.data']._xmlid_to_res_id('base.group_user')
            // internal_users = self.filtered_domain([('all_group_ids', 'in', [user_group_id])])
            // internal_users.share = False
            // (self - internal_users).share = True
            */
            return default;
        }

        protected async Task<ResUsers> ComputeSignatureInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _compute_signature(self):
            // for user in self.filtered(lambda user: user.name and is_html_empty(user.signature)):
            //     user.signature = Markup('<div>%s</div>') % user['name']
            */
            return default;
        }

        protected async Task<ResUsers> ComputeStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py) ---
            // def _compute_state(self):
            // for user in self:
            //     user.state = 'active' if user.login_date else 'new'
            */
            return default;
        }

        protected async Task<ResUsers> ComputeTotpEnabledInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py) ---
            // def _compute_totp_enabled(self):
            // for r, v in zip(self, self.sudo()):
            //     r.totp_enabled = bool(v.totp_secret)
            */
            return default;
        }

        protected async Task<ResUsers> ComputeTotpSecretInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py) ---
            // def _compute_totp_secret(self):
            // for user in self:
            //     if not user.id:
            //         user.totp_secret = user._origin.totp_secret
            //         continue
            //     self.env.cr.execute('SELECT totp_secret FROM res_users WHERE id=%s', (user.id,))
            //     user.totp_secret = self.env.cr.fetchone()[0]
            */
            return default;
        }

        protected async Task<ResUsers> ComputeTourEnabledInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_tour, FILE: res_users.py) ---
            // def _compute_tour_enabled(self):
            // demo_modules_count = self.env['ir.module.module'].sudo().search_count([('demo', '=', True)])
            // for user in self:
            //     user.tour_enabled = user._is_admin() and demo_modules_count == 0 and not modules.module.current_test
            */
            return default;
        }

        protected async Task<ResUsers> ComputeTzOffsetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _compute_tz_offset(self):
            // for user in self:
            //     user.tz_offset = datetime.datetime.now(pytz.timezone(user.tz or 'GMT')).strftime('%z')
            */
            return default;
        }

        public async Task<ResUsers> ContextGetAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def context_get(self):
            // # use read() to not read other fields: this must work while modifying
            // # the schema of models res.users or res.partner
            // try:
            //     context = self.env.user.read(['lang', 'tz'], load=False)[0]
            // except IndexError:
            //     # user not found, no context information
            //     return frozendict()
            // context.pop('id')
            // 
            // # ensure lang is set and available
            // # context > request > company > english > any lang installed
            // langs = [code for code, _ in self.env['res.lang'].get_installed()]
            // lang = context.get('lang')
            // if lang not in langs:
            //     lang = request.best_lang if request else None
            //     if lang not in langs:
            //         lang = self.env.user.with_context(prefetch_fields=False).company_id.partner_id.lang
            //         if lang not in langs:
            //             lang = DEFAULT_LANG
            //             if lang not in langs:
            //                 lang = langs[0] if langs else DEFAULT_LANG
            // context['lang'] = lang
            // 
            // # ensure uid is set
            // context['uid'] = self.env.uid
            // 
            // return frozendict(context)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<ResUsers> CopyAsync(Guid id, List<string> fields, ResUsers defaultValues = null)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py) ---
            // def copy(self, default=None):
            // if not default or not default.get('email'):
            //     # avoid sending email to the user we are duplicating
            //     self = self.with_context(no_reset_password=True)
            // return super().copy(default=default)
            */
            return await base.CopyAsync(id, fields, defaultValues);
        }

        public async Task<ResUsers> CopyDataAsync(Guid id, ResUsersCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // for user, vals in zip(self, vals_list):
            //     if ('name' not in default) and ('partner_id' not in default):
            //         vals['name'] = _("%s (copy)", user.name)
            //     if 'login' not in default:
            //         vals['login'] = _("%s (copy)", user.login)
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<ResUsers> CreateAsync(ResUsers entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py) ---
            // def create(self, vals_list):
            // # overridden to automatically invite user to sign up
            // users = super(ResUsers, self).create(vals_list)
            // if not self.env.context.get('no_reset_password'):
            //     users_with_email = users.filtered('email')
            //     if users_with_email:
            //         try:
            //             users_with_email.with_context(create_user=True)._action_reset_password(signup_type='signup')
            //         except MailDeliveryException:
            //             users_with_email.partner_id.with_context(create_user=True).signup_cancel()
            // return users
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_users.py) ---
            // def create(self, vals_list):
            // """ Set the calendar default privacy as the same as Default User Template when defined. """
            // default_privacy = self._default_user_calendar_default_privacy()
            // # Update the dictionaries in vals_list with the calendar default privacy.
            // for vals_dict in vals_list:
            //     if not vals_dict.get('calendar_default_privacy'):
            //         vals_dict.update(calendar_default_privacy=default_privacy)
            // 
            // res = super().create(vals_list)
            // return res
            --- ODOO METHOD SOURCE (MODULE: digest, FILE: res_users.py) ---
            // def create(self, vals_list):
            // """ Automatically subscribe employee users to default digest if activated """
            // users = super(ResUsers, self).create(vals_list)
            // default_digest_emails = self.env['ir.config_parameter'].sudo().get_param('digest.default_digest_emails')
            // default_digest_id = self.env['ir.config_parameter'].sudo().get_param('digest.default_digest_id')
            // users_to_subscribe = users.filtered_domain([('share', '=', False)])
            // if default_digest_emails and default_digest_id and users_to_subscribe:
            //     digest = self.env['digest.digest'].sudo().browse(int(default_digest_id)).exists()
            //     digest.user_ids |= users_to_subscribe
            // return users
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: res_users.py) ---
            // def create(self, vals_list):
            // res = super().create(vals_list)
            // 
            // self._add_karma_batch({
            //     user: {
            //         'gain': int(vals['karma']),
            //         'old_value': 0,
            //         'origin_ref': f'res.users,{self.env.uid}',
            //         'reason': _('User Creation'),
            //     }
            //     for user, vals in zip(res, vals_list)
            //     if vals.get('karma')
            // })
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def create(self, vals_list):
            // res = super().create(vals_list)
            // employee_create_vals = []
            // for user, vals in zip(res, vals_list):
            //     if not vals.get('create_employee') and not vals.get('create_employee_id'):
            //         continue
            //     if vals.get('create_employee_id'):
            //         self.env['hr.employee'].browse(vals.get('create_employee_id')).user_id = user
            //     else:
            //         employee_create_vals.append(dict(
            //             name=user.name,
            //             company_id=user.env.company.id,
            //             **self.env['hr.employee']._sync_user(user)
            //         ))
            // if employee_create_vals:
            //     self.env['hr.employee'].with_context(clean_context(self.env.context)).create(employee_create_vals)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: res_users.py) ---
            // def create(self, vals_list):
            // users = super().create(vals_list)
            // users.sudo()._clean_leave_responsible_users()
            // return users
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def create(self, vals_list):
            // users = super().create(vals_list)
            // self.env["discuss.channel"].search([("group_ids", "in", users.all_group_ids.ids)])._subscribe_users_automatically()
            // return users
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def create(self, vals_list):
            // 
            // users = super().create(vals_list)
            // 
            // # log a portal status change (manual tracking)
            // log_portal_access = not self.env.context.get('mail_create_nolog') and not self.env.context.get('mail_notrack')
            // if log_portal_access:
            //     for user in users:
            //         if user._is_portal():
            //             body = user._get_portal_access_update_body(True)
            //             user.partner_id.message_post(
            //                 body=body,
            //                 message_type='notification',
            //                 subtype_xmlid='mail.mt_note'
            //             )
            // return users
            --- ODOO METHOD SOURCE (MODULE: project, FILE: res_users.py) ---
            // def create(self, vals_list):
            // res = super().create(vals_list)
            // self._onboard_users_into_project(res)
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: res_users.py) ---
            // def create(self, vals_list):
            // """ Trigger automatic subscription based on user groups """
            // users = super().create(vals_list)
            // for user in users:
            //     self.env['slide.channel'].sudo().search([
            //         ('enroll_group_ids', 'in', user.all_group_ids.ids)
            //     ])._action_add_members(user.partner_id)
            // return users
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def create(self, vals_list):
            // users = super().create(vals_list)
            // setting_vals = []
            // for user in users:
            //     if not user.res_users_settings_ids and user._is_internal():
            //         setting_vals.append({'user_id': user.id})
            //     # if partner is global we keep it that way
            //     if user.partner_id.company_id:
            //         user.partner_id.company_id = user.company_id
            //     user.partner_id.active = user.active
            //     # Generate employee initals as avatar for internal users without image
            //     if not user.image_1920 and not user.share and user.name:
            //         user.image_1920 = user.partner_id._avatar_generate_svg()
            // if setting_vals:
            //     self.env['res.users.settings'].sudo().create(setting_vals)
            // return users
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def create(self, vals_list):
            // users = super().create(vals_list)
            // group_multi_company_id = self.env['ir.model.data']._xmlid_to_res_id(
            //     'base.group_multi_company', raise_if_not_found=False)
            // if group_multi_company_id:
            //     for user in users:
            //         if len(user.company_ids) <= 1 and group_multi_company_id in user.group_ids.ids:
            //             user.write({'group_ids': [Command.unlink(group_multi_company_id)]})
            //         elif len(user.company_ids) > 1 and group_multi_company_id not in user.group_ids.ids:
            //             user.write({'group_ids': [Command.link(group_multi_company_id)]})
            // return users
            */
            return await base.CreateAsync(entity, fields);
        }

        public async Task<ResUsers> CreateEmployeeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def action_create_employee(self):
            // self.ensure_one()
            // if self.env.company not in self.company_ids:
            //     raise AccessError(_("You are not allowed to create an employee because the user does not have access rights for %s", self.env.company.name))
            // self.env['hr.employee'].create(dict(
            //     name=self.name,
            //     company_id=self.env.company.id,
            //     **self.env['hr.employee']._sync_user(self)
            // ))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> CreatePasskeyAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: res_users.py) ---
            // def action_create_passkey(self):
            // return {
            //     'name': _('Create Passkey'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'auth.passkey.key.create',
            //     'view_mode': 'form',
            //     'target': 'new',
            //     'context': {
            //         'dialog_size': 'medium',
            //         'registration': self.env['auth.passkey.key']._start_registration(),
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> CreateRecruitmentInterviewersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: res_users.py) ---
            // def _create_recruitment_interviewers(self):
            // if not self:
            //     return
            // interviewer_group = self.env.ref('hr_recruitment.group_hr_recruitment_interviewer')
            // recruitment_group = self.env.ref('hr_recruitment.group_hr_recruitment_user')
            // 
            // interviewers = self - recruitment_group.all_user_ids
            // interviewers.sudo().write({
            //     'group_ids': [(4, interviewer_group.id)]
            // })
            */
            return default;
        }

        protected async Task<ResUsers> CreateUserFromTemplateInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py) ---
            // def _create_user_from_template(self, values):
            // template_user_id = literal_eval(self.env['ir.config_parameter'].sudo().get_param('base.template_portal_user_id', 'False'))
            // template_user = self.browse(template_user_id)
            // if not template_user.exists():
            //     raise ValueError(_('Signup: invalid template user'))
            // 
            // if not values.get('login'):
            //     raise ValueError(_('Signup: no login given for new user'))
            // if not values.get('partner_id') and not values.get('name'):
            //     raise ValueError(_('Signup: no name or partner given for new user'))
            // 
            // # create a copy of the template user (attached to a specific partner_id if given)
            // values['active'] = True
            // try:
            //     with self.env.cr.savepoint():
            //         return template_user.with_context(no_reset_password=True).copy(values)
            // except Exception as e:
            //     # copy may failed if asked login is not available.
            //     raise SignupError(str(e))
            */
            return default;
        }

        protected async Task<ResUsers> CryptContextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _crypt_context(self):
            // """ Passlib CryptContext instance used to encrypt and verify
            // passwords. Can be overridden if technical, legal or political matters
            // require different kdfs than the provided default.
            // 
            // The work factor of the default KDF can be configured using the
            // ``password.hashing.rounds`` ICP.
            // """
            // cfg = self.env['ir.config_parameter'].sudo()
            // return CryptContext(
            //     # kdf which can be verified by the context. The default encryption
            //     # kdf is the first of the list
            //     ['pbkdf2_sha512', 'plaintext'],
            //     # deprecated algorithms are still verified as usual, but
            //     # ``needs_update`` will indicate that the stored hash should be
            //     # replaced by a more recent algorithm.
            //     deprecated=['auto'],
            //     pbkdf2_sha512__rounds=max(MIN_ROUNDS, int(cfg.get_param('password.hashing.rounds', 0))),
            // )
            */
            return default;
        }

        protected async Task<ResUsers> DeactivatePortalUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _deactivate_portal_user(self, **post):
            // """Blacklist the email of the user after deleting it.
            // 
            // Log a note on the related partner so we know why it's archived.
            // """
            // current_user = self.env.user
            // for user in self:
            //     user.partner_id._message_log(
            //         body=_('Archived because %(user_name)s (#%(user_id)s) deleted the portal account',
            //                user_name=current_user.name, user_id=current_user.id)
            //     )
            // 
            // if post.get('request_blacklist'):
            //     users_to_blacklist = [(user, user.email) for user in self.filtered(
            //         lambda user: tools.email_normalize(user.email))]
            // else:
            //     users_to_blacklist = []
            // 
            // super()._deactivate_portal_user(**post)
            // 
            // for user, user_email in users_to_blacklist:
            //     self.env['mail.blacklist']._add(
            //         user_email,
            //         message=_('Blocked by deletion of portal account %(portal_user_name)s by %(user_name)s (#%(user_id)s)',
            //                   user_name=current_user.name, user_id=current_user.id,
            //                   portal_user_name=user.name)
            //     )
            --- ODOO METHOD SOURCE (MODULE: phone_validation, FILE: res_users.py) ---
            // def _deactivate_portal_user(self, **post):
            // """Blacklist the phone of the user after deleting it."""
            // numbers_to_blacklist = {}  # numbers to blacklist and the related user
            // if post.get('request_blacklist'):
            //     for user in self:
            //         for fname in self._phone_get_number_fields():
            //             number = user._phone_format(fname=fname)
            //             if number:
            //                 numbers_to_blacklist[number] = user
            // 
            // super()._deactivate_portal_user(**post)
            // 
            // if numbers_to_blacklist:
            //     current_user = self.env.user
            //     blacklists = self.env['phone.blacklist']._add(
            //         list(numbers_to_blacklist.keys()))
            //     for blacklist in blacklists:
            //         user = numbers_to_blacklist[blacklist.number]
            //         blacklist._message_log(
            //             body=_('Blocked by deletion of portal account %(portal_user_name)s by %(user_name)s (#%(user_id)s)',
            //                    user_name=current_user.name, user_id=current_user.id,
            //                    portal_user_name=user.name),
            //         )
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _deactivate_portal_user(self, **post):
            // """Try to remove the current portal user.
            // 
            // This is used to give the opportunity to portal users to de-activate their accounts.
            // Indeed, as the portal users can easily create accounts, they will sometimes wish
            // it removed because they don't use this Odoo portal anymore.
            // 
            // Before this feature, they would have to contact the website or the support to get
            // their account removed, which could be tedious.
            // """
            // non_portal_users = self.filtered(lambda user: not user.share)
            // if non_portal_users:
            //     raise AccessDenied(_(
            //         'Only the portal users can delete their accounts. '
            //         'The user(s) %s can not be deleted.',
            //         ', '.join(non_portal_users.mapped('name')),
            //     ))
            // 
            // ip = request.httprequest.environ['REMOTE_ADDR'] if request else 'n/a'
            // 
            // res_users_deletion_values = []
            // 
            // for user in self:
            //     _logger.info(
            //         'Account deletion asked for "%s" (#%i) from %s. '
            //         'Archive the user and remove login information.',
            //         user.login, user.id, ip,
            //     )
            // 
            //     user.write({
            //         'login': f'__deleted_user_{user.id}_{time.time()}',
            //         'password': '',
            //     })
            //     user.api_key_ids._remove()
            // 
            //     res_users_deletion_values.append({
            //         'user_id': user.id,
            //         'state': 'todo',
            //     })
            // 
            // # Here we try to archive the user / partner, and then add the user in a deletion
            // # queue, to remove it from the database. As the deletion might fail (if the
            // # partner is related to an invoice e.g.) it's important to archive it here.
            // try:
            //     # A user can not self-deactivate
            //     self.with_user(SUPERUSER_ID).action_archive()
            // except Exception:
            //     pass
            // try:
            //     self.partner_id.action_archive()
            // except Exception:
            //     pass
            // # Add users in the deletion queue
            // self.env['res.users.deletion'].create(res_users_deletion_values)
            */
            return default;
        }

        protected async Task<ResUsers> DefaultGroupsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _default_groups(self):
            // """Default groups for employees
            // 
            // All the groups of the Default User Group
            // """
            // groups = self.env.ref('base.group_user')
            // default_group = self.env.ref('base.default_user_group', raise_if_not_found=False)
            // if default_group:
            //     groups += default_group.implied_ids
            // return groups
            */
            return default;
        }

        protected async Task<ResUsers> DefaultUserCalendarDefaultPrivacyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_users.py) ---
            // def _default_user_calendar_default_privacy(self):
            // """ Get the calendar default privacy from the Default User Template, set public as default. """
            // return self.env['ir.config_parameter'].sudo().get_param('calendar.default_privacy', 'public')
            */
            return default;
        }

        protected async Task<ResUsers> DefaultViewGroupHierarchyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _default_view_group_hierarchy(self):
            // return self.env['res.groups']._get_view_group_hierarchy()
            */
            return default;
        }

        protected async Task<ResUsers> EmployeeIdsDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def _employee_ids_domain(self):
            // # employee_ids is considered a safe field and as such will be fetched as sudo.
            // # So try to enforce the security rules on the field to make sure we do not load employees outside of active companies
            // return [('company_id', 'in', self.env.company.ids + self.env.context.get('allowed_company_ids', []))]
            */
            return default;
        }

        protected async Task<ResUsers> GcPersonalMailServersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _gc_personal_mail_servers(self):
            // """In case the user change their email, we need to delete the old personal servers."""
            // self.env['ir.mail_server'].with_context(active_test=False) \
            //     .search([('owner_user_id', '!=', False)]) \
            //     .filtered(lambda s: s.owner_user_id.outgoing_mail_server_id != s or not s.active) \
            //     .unlink()
            */
            return default;
        }

        protected async Task<ResUsers> GenerateOnboardingTodoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_todo, FILE: res_users.py) ---
            // def _generate_onboarding_todo(self):
            // create_vals = []
            // for user in self:
            //     self_lang = self.with_context(lang=user.lang or self.env.user.lang)
            //     body = self_lang.env["ir.qweb"]._render(
            //         "project_todo.todo_user_onboarding",
            //         {"object": user},
            //         minimal_qcontext=True,
            //         raise_if_not_found=False
            //     )
            //     if not body:
            //         continue
            //     title = self_lang.env._("Welcome %s!", user.name)
            //     create_vals.append({
            //         "user_ids": user.ids,
            //         "description": body,
            //         "name": title,
            //     })
            // if create_vals:
            //     self.env["project.task"].with_user(SUPERUSER_ID).with_context({'mail_auto_subscribe_no_notify': True}).create(create_vals)
            */
            return default;
        }

        protected async Task<ResUsers> GenerateProfileTokenInternalAsync(Guid user_id, object email)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_profile, FILE: res_users.py) ---
            // def _generate_profile_token(self, user_id, email):
            // """Return a token for email validation. This token is valid for the day
            // and is a hash based on a (secret) uuid generated by the forum module,
            // the user_id, the email and currently the day (to be updated if necessary). """
            // profile_uuid = self.env['ir.config_parameter'].sudo().get_param('website_profile.uuid')
            // if not profile_uuid:
            //     profile_uuid = str(uuid.uuid4())
            //     self.env['ir.config_parameter'].sudo().set_param('website_profile.uuid', profile_uuid)
            // return hashlib.sha256((u'%s-%s-%s-%s' % (
            //     datetime.now().replace(hour=0, minute=0, second=0, microsecond=0),
            //     profile_uuid,
            //     user_id,
            //     email
            // )).encode('utf-8')).hexdigest()
            */
            return default;
        }

        protected async Task<ResUsers> GenerateSignupValuesInternalAsync(object provider, object validation, object @params)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py) ---
            // def _generate_signup_values(self, provider, validation, params):
            // oauth_uid = validation['user_id']
            // email = validation.get('email', 'provider_%s_user_%s' % (provider, oauth_uid))
            // name = validation.get('name', email)
            // return {
            //     'name': name,
            //     'login': email,
            //     'email': email,
            //     'oauth_provider_id': provider,
            //     'oauth_uid': oauth_uid,
            //     'oauth_access_token': params['access_token'],
            //     'active': True,
            // }
            */
            return default;
        }

        protected async Task<ResUsers> GetActivityGroupsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_users.py) ---
            // def _get_activity_groups(self):
            // res = super()._get_activity_groups()
            // EventModel = self.env['calendar.event']
            // meetings_lines = EventModel.search_read(
            //     self._systray_get_calendar_event_domain(),
            //     ['id', 'start', 'name', 'allday'],
            //     order='start')
            // if meetings_lines:
            //     meeting_label = _("Today's Meetings")
            //     meetings_systray = {
            //         'id': self.env['ir.model']._get('calendar.event').id,
            //         'type': 'meeting',
            //         'name': meeting_label,
            //         'model': 'calendar.event',
            //         'icon': modules.module.get_module_icon(EventModel._original_module),
            //         'domain': [('active', 'in', [True, False])],
            //         'meetings': meetings_lines,
            //         "view_type": EventModel._systray_view,
            //     }
            //     res.insert(0, meetings_systray)
            // return res
            --- ODOO METHOD SOURCE (MODULE: contacts, FILE: res_users.py) ---
            // def _get_activity_groups(self):
            // """ Update the systray icon of res.partner activities to use the
            // contact application one instead of base icon. """
            // activities = super()._get_activity_groups()
            // for activity in activities:
            //     if activity['model'] != 'res.partner':
            //         continue
            //     activity['icon'] = modules.module.Manifest.for_addon('contacts').icon
            // return activities
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _get_activity_groups(self):
            // search_limit = int(self.env['ir.config_parameter'].sudo().get_param('mail.activity.systray.limit', 1000))
            // activities = self.env["mail.activity"].search(
            //     [("user_id", "=", self.env.uid)],
            //     order='id desc', limit=search_limit,
            // )
            // 
            // user_company_ids = self.env.user.company_ids.ids
            // is_all_user_companies_allowed = set(user_company_ids) == set(self.env.context.get('allowed_company_ids') or [])
            // 
            // activities_model_groups = defaultdict(lambda: self.env["mail.activity"])
            // activities_rec_groups = defaultdict(lambda: defaultdict(lambda: self.env["mail.activity"]))
            // 
            // for activity in activities:
            //     if activity.res_model:
            //         activities_rec_groups[activity.res_model][activity.res_id] += activity
            //     else:
            //         activities_rec_groups["mail.activity"][activity.id] += activity
            // model_activity_states = {
            //     'mail.activity': {'overdue_count': 0, 'today_count': 0, 'planned_count': 0, 'total_count': 0}
            // }
            // for model_name, activities_by_record in activities_rec_groups.items():
            //     res_ids = activities_by_record.keys()
            //     Model = self.env[model_name]
            //     has_model_access_right = Model.has_access('read')
            //     if has_model_access_right:
            //         allowed_records = Model.browse(res_ids)._filtered_access('read')
            //     else:
            //         allowed_records = Model
            //     unallowed_records = Model.browse(res_ids) - allowed_records
            //     # We remove from not allowed records, records that the user has access to through others of his companies
            //     if has_model_access_right and unallowed_records and not is_all_user_companies_allowed:
            //         unallowed_records -= unallowed_records.with_context(
            //             allowed_company_ids=user_company_ids)._filtered_access('read')
            //     model_activity_states[model_name] = {'overdue_count': 0, 'today_count': 0, 'planned_count': 0, 'total_count': 0}
            //     for record_id, activities in activities_by_record.items():
            //         if record_id in unallowed_records.ids:
            //             model_key = 'mail.activity'
            //             activities_model_groups['mail.activity'] += activities
            //         elif record_id in allowed_records.ids:
            //             model_key = model_name
            //             activities_model_groups[model_name] += activities
            //         elif record_id:
            //             continue
            // 
            //         if 'overdue' in activities.mapped('state'):
            //             model_activity_states[model_key]['overdue_count'] += 1
            //             model_activity_states[model_key]['total_count'] += 1
            //         elif 'today' in activities.mapped('state'):
            //             model_activity_states[model_key]['today_count'] += 1
            //             model_activity_states[model_key]['total_count'] += 1
            //         else:
            //             model_activity_states[model_key]['planned_count'] += 1
            // 
            // model_ids = [self.env["ir.model"]._get_id(name) for name in activities_model_groups]
            // user_activities = {}
            // for model_name, activities in activities_model_groups.items():
            //     Model = self.env[model_name]
            //     module = Model._original_module
            //     icon = module and modules.module.get_module_icon(module)
            //     model = self.env["ir.model"]._get(model_name).with_prefetch(model_ids)
            //     user_activities[model_name] = {
            //         "id": model.id,
            //         "name": model.name if model_name != "mail.activity" else _("Other activities"),
            //         "model": model_name,
            //         "type": "activity",
            //         "icon": icon,
            //         # activity more important than archived status, active_test is too broad
            //         "domain": [('active', 'in', [True, False])] if model_name != "mail.activity" and "active" in Model else [],
            //         "total_count": model_activity_states[model_name]['total_count'],
            //         "today_count": model_activity_states[model_name]['today_count'],
            //         "overdue_count": model_activity_states[model_name]['overdue_count'],
            //         "planned_count": model_activity_states[model_name]['planned_count'],
            //         "view_type": getattr(Model, '_systray_view', 'list'),
            //     }
            //     if model_name == 'mail.activity':
            //         user_activities[model_name]['activity_ids'] = activities.ids
            // return list(user_activities.values())
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: res_users.py) ---
            // def _get_activity_groups(self):
            // """ Update systray name of mailing.mailing from "Mass Mailing"
            //     to "Email Marketing".
            // """
            // activities = super()._get_activity_groups()
            // for activity in activities:
            //     if activity.get('model') == 'mailing.mailing':
            //         activity['name'] = _('Email Marketing')
            //         break
            // return activities
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: res_users.py) ---
            // def _get_activity_groups(self):
            // """ Split mass_mailing and mass_mailing_sms activities in systray by 
            //     removing the single mailing.mailing activity represented and
            //     doing a new query to split them by mailing_type.
            // """
            // activities = super()._get_activity_groups()
            // view_type = self.env['mailing.mailing']._systray_view
            // for activity in activities:
            //     if activity.get('model') == 'mailing.mailing':
            //         activities.remove(activity)
            //         query = """
            //                 WITH mailing_states AS (
            //                     SELECT m.mailing_type, act.res_id,
            //                         CASE
            //                             WHEN %(today)s::date - MIN(act.date_deadline)::date = 0 Then 'today'
            //                             WHEN %(today)s::date - MIN(act.date_deadline)::date > 0 Then 'overdue'
            //                             WHEN %(today)s::date - MIN(act.date_deadline)::date < 0 Then 'planned'
            //                         END AS states
            //                     FROM mail_activity AS act
            //                     JOIN mailing_mailing AS m ON act.res_id = m.id
            //                     WHERE act.res_model = 'mailing.mailing' AND act.user_id = %(user_id)s AND act.active in (TRUE, %(active)s)
            //                     GROUP BY m.mailing_type, act.res_id
            //                 )
            //                 SELECT mailing_type, states, array_agg(res_id) AS res_ids, COUNT(res_id) AS count
            //                 FROM mailing_states
            //                 GROUP BY mailing_type, states
            //                 """
            //         self.env.cr.execute(query, {
            //             'today': fields.Date.context_today(self),
            //             'user_id': self.env.uid,
            //             'active': self.env.context.get('active_test', True),
            //         })
            //         activity_data = self.env.cr.dictfetchall()
            // 
            //         user_activities = {}
            //         for act in activity_data:
            //             if not user_activities.get(act['mailing_type']):
            //                 if act['mailing_type'] == 'sms':
            //                     module_name = 'mass_mailing_sms'
            //                     name = _('SMS Marketing')
            //                 else:
            //                     module_name = 'mass_mailing'
            //                     name = _('Email Marketing')
            //                 icon = modules.Manifest.for_addon(module_name).icon
            //                 res_ids = set()
            //                 user_activities[act['mailing_type']] = {
            //                     'id': self.env['ir.model']._get('mailing.mailing').id,
            //                     'name': name,
            //                     'model': 'mailing.mailing',
            //                     'type': 'activity',
            //                     'icon': icon,
            //                     'domain': [('active', 'in', [True, False])],
            //                     'total_count': 0, 'today_count': 0, 'overdue_count': 0, 'planned_count': 0,
            //                     'res_ids': res_ids,
            //                     "view_type": view_type,
            //                 }
            //             user_activities[act['mailing_type']]['res_ids'].update(act['res_ids'])
            //             user_activities[act['mailing_type']]['%s_count' % act['states']] += act['count']
            //             if act['states'] in ('today', 'overdue'):
            //                 user_activities[act['mailing_type']]['total_count'] += act['count']
            // 
            //         for mailing_type in user_activities.keys():
            //             user_activities[mailing_type].update({
            //                 'domain': json.dumps([
            //                     ['active', 'in', [True, False]],
            //                     ['activity_ids.res_id', 'in', list(user_activities[mailing_type]['res_ids'])],
            //                 ])
            //             })
            //         activities.extend(list(user_activities.values()))
            //         break
            // 
            // return activities
            --- ODOO METHOD SOURCE (MODULE: project_todo, FILE: res_users.py) ---
            // def _get_activity_groups(self):
            // """ Split To-do and Project activities in systray by removing
            //     the single project.task activity represented and doing a
            //     new query to split them between private/non-private tasks.
            // """
            // activity_groups = super()._get_activity_groups()
            // # 1. removing project.task activity group
            // to_remove = next((g for g in activity_groups if g.get('model') == 'project.task'), None)
            // if to_remove:
            //     activity_groups.remove(to_remove)
            // 
            // # 2. Splitting tasks in 'regular-task' (is_task=TRUE) and 'to-do' (is_task=False)
            // #    Counting max 1 activity per task
            // query = """
            //     WITH task_states AS (
            //         SELECT BOOL(t.project_id) AS is_task, act.res_id,
            //             CASE
            //                 WHEN %(date)s - MIN(act.date_deadline)::date = 0 THEN 'today'
            //                 WHEN %(date)s - MIN(act.date_deadline)::date > 0 THEN 'overdue'
            //                 WHEN %(date)s - MIN(act.date_deadline)::date < 0 THEN 'planned'
            //             END AS states
            //         FROM mail_activity AS act
            //         JOIN project_task AS t ON act.res_id = t.id
            //         WHERE act.res_model = 'project.task' AND act.user_id = %(user_id)s AND act.active in (TRUE, %(active)s)
            //         GROUP BY is_task, act.res_id
            //     )
            //     SELECT is_task, states, array_agg(res_id) AS res_ids, COUNT(res_id) AS count
            //     FROM task_states
            //     GROUP BY is_task, states
            // """
            // 
            // self.env.cr.execute(query, {
            //     'date': str(fields.Date.context_today(self)),
            //     'user_id': self.env.uid,
            //     'active': self.env.context.get('active_test', True),
            // })
            // activity_data = self.env.cr.dictfetchall()
            // view_type = self.env['project.task']._systray_view
            // 
            // user_activities = {}
            // for activity in activity_data:
            //     is_task = activity['is_task']
            //     if is_task not in user_activities:
            //         if not is_task:
            //             module_name = 'project_todo'
            //             name = _('To-Do')
            //         else:
            //             module_name = 'project'
            //             name = _('Task')
            //         icon = modules.Manifest.for_addon(module_name).icon
            //         user_activities[is_task] = {
            //             'id': self.env['ir.model']._get('project.task').id,
            //             'name': name,
            //             'is_todo': not is_task,
            //             'model': 'project.task',
            //             'type': 'activity',
            //             'icon': icon,
            //             'domain': [('active', 'in', [True, False])],
            //             'total_count': 0, 'today_count': 0, 'overdue_count': 0, 'planned_count': 0,
            //             'res_ids': set(),
            //             'view_type': view_type,
            //         }
            //     user_activities[is_task]['res_ids'].update(activity['res_ids'])
            //     user_activities[is_task][f"{activity['states']}_count"] += activity['count']
            //     if activity['states'] in ('today', 'overdue'):
            //         user_activities[is_task]['total_count'] += activity['count']
            // 
            // for group in user_activities.values():
            //     group.update({
            //         'domain': json.dumps([
            //             ['active', 'in', [True, False]],
            //             ['activity_ids.res_id', 'in', list(group['res_ids'])]
            //         ])
            //     })
            // activity_groups.extend(list(user_activities.values()))
            // 
            // return activity_groups
            */
            return default;
        }

        public async Task<ResUsers> GetAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def action_get(self):
            // if self.env.user.employee_id:
            //     action = self.env['ir.actions.act_window']._for_xml_id('hr.res_users_action_my')
            //     groups = {
            //         group_xml_id[0]: True
            //         for group_xml_id in self.env.user.all_group_ids._get_external_ids().values()
            //         if group_xml_id
            //     }
            //     action_context = ast.literal_eval(action['context']) if action['context'] else {}
            //     action_context.update(groups)
            //     action['context'] = str(action_context)
            //     return action
            // return super().action_get()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def action_get(self):
            // return self.sudo().env.ref('base.action_res_users_my').read()[0]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> GetAuthMethodsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_timeout, FILE: res_users.py) ---
            // def _get_auth_methods(self):
            // """
            // Return the list of authentication methods available to the user.
            // 
            // This includes passkeys (WebAuthn), TOTP (app or mail), and password,
            // depending on the user's configured credentials and MFA policy.
            // 
            // :return: A list of enabled authentication method types (e.g., ["webauthn", "totp", "password"]).
            // :rtype: list[str]
            // """
            // self.ensure_one()
            // auth_methods = []
            // if self.auth_passkey_key_ids:
            //     auth_methods.append("webauthn")
            // if mfa_type := self._mfa_type():
            //     auth_methods.append(mfa_type)
            // auth_methods.append("password")
            // return auth_methods
            */
            return default;
        }

        public async Task<ResUsers> GetCompanyCurrencyIdAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def get_company_currency_id(self):
            // return self.env.company.currency_id.id
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> GetCompanyIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _get_company_ids(self):
            // # use search() instead of `self.company_ids` to avoid extra query for `active_test`
            // domain = [('active', '=', True), ('user_ids', 'in', self.id)]
            // return self.env['res.company'].search(domain)._ids
            */
            return default;
        }

        protected async Task<ResUsers> GetDefaultWarehouseIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: res_users.py) ---
            // def _get_default_warehouse_id(self):
            // if self.property_warehouse_id:
            //     return self.property_warehouse_id
            // return super()._get_default_warehouse_id()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_users.py) ---
            // def _get_default_warehouse_id(self):
            // # !!! Any change to the following search domain should probably
            // # be also applied in sale_stock/models/sale_order.py/_init_column.
            // return self.env['stock.warehouse'].search([('company_id', '=', self.env.company.id)], limit=1)
            */
            return default;
        }

        protected async Task<ResUsers> GetEmailDomainInternalAsync(object email)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_users.py) ---
            // def _get_email_domain(self, email):
            // website = self.env['website'].get_current_website()
            // return super()._get_email_domain(email) & website.website_domain()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _get_email_domain(self, email):
            // return Domain('email', '=', email)
            */
            return default;
        }

        protected async Task<ResUsers> GetEmployeeFieldsToSyncInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def _get_employee_fields_to_sync(self):
            // """Get values to sync to the related employee when the User is changed.
            // """
            // return ['name', 'email', 'image_1920', 'tz']
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking, FILE: res_users.py) ---
            // def _get_employee_fields_to_sync(self):
            // return super()._get_employee_fields_to_sync() + DAYS
            */
            return default;
        }

        public async Task<ResUsers> GetFormviewActionAsync(Guid id, ResUsersGetFormviewActionRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def get_formview_action(self, access_uid=None):
            // """ Override this method in order to redirect many2one towards the full user form view
            // incase the user is ERP manager and the request coming from employee form."""
            // 
            // res = super().get_formview_action(access_uid=access_uid)
            // user = self.env.user
            // if access_uid:
            //     user = self.env['res.users'].browse(access_uid).sudo()
            // 
            // if self.env.context.get('default_create_employee_id') and user.has_group('base.group_erp_manager'):
            //     res['views'] = [(self.env.ref('base.view_users_form').id, 'form')]
            // 
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> GetGamificationRedirectionDataAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: res_users.py) ---
            // def get_gamification_redirection_data(self):
            // """
            // Hook for other modules to add redirect button(s) in new rank reached mail
            // Must return a list of dictionnary including url and label.
            // E.g. return [{'url': '/forum', label: 'Go to Forum'}]
            // """
            // self.ensure_one()
            // return []
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: res_users.py) ---
            // def get_gamification_redirection_data(self):
            // res = super().get_gamification_redirection_data()
            // res.append({
            //     'label': _('See our Forum'),
            //     'url': '/forum',
            // })
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: res_users.py) ---
            // def get_gamification_redirection_data(self):
            // res = super().get_gamification_redirection_data()
            // res.append({
            //     'url': '/slides',
            //     'label': _('See our eLearning')
            // })
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> GetGoogleCalendarTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py) ---
            // def _get_google_calendar_token(self):
            // self.ensure_one()
            // if self.res_users_settings_id.sudo().google_calendar_rtoken and not self.res_users_settings_id._is_google_calendar_valid():
            //     self.sudo().res_users_settings_id._refresh_google_calendar_token()
            // return self.res_users_settings_id.sudo().google_calendar_token
            */
            return default;
        }

        protected async Task<ResUsers> GetGoogleSyncStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py) ---
            // def _get_google_sync_status(self):
            // """ Returns the calendar synchronization status (active, paused or stopped). """
            // status = "sync_active"
            // if str2bool(self.env['ir.config_parameter'].sudo().get_param("google_calendar_sync_paused"), default=False):
            //     status = "sync_paused"
            // elif self.sudo().google_calendar_rtoken and not self.sudo().google_synchronization_stopped:
            //     status = "sync_active"
            // elif self.sudo().google_synchronization_stopped:
            //     status = "sync_stopped"
            // return status
            */
            return default;
        }

        protected async Task<ResUsers> GetGroupIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _get_group_ids(self):
            // """ Return ``self``'s group ids (as a tuple)."""
            // self.ensure_one()
            // # `with_context({})` because this method is decorated with `@ormcache('self._ids')`,
            // # it cannot depend on the context (e.g. `active_test`, `lang`, ...)
            // return self.with_context({}).all_group_ids._ids
            */
            return default;
        }

        protected async Task<ResUsers> GetInvalidationFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _get_invalidation_fields(self):
            // return {
            //     'group_ids', 'active', 'lang', 'tz', 'company_id', 'company_ids',
            //     *self._get_session_token_fields()
            // }
            */
            return default;
        }

        protected async Task<ResUsers> GetKarmaPositionInternalAsync(object user_domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: res_users.py) ---
            // def _get_karma_position(self, user_domain):
            //         """ Get absolute position in term of total karma for users. First a ranking
            //         of all users is done given a user_domain; then the position of each user
            //         belonging to the current record set is extracted.
            // 
            //         Example: in website profile, search users with name containing Norbert. Their
            //         positions should not be 1 to 4 (assuming 4 results), but their actual position
            //         in the total karma ranking (with example user_domain being karma > 1,
            //         website published True).
            // 
            //         :param user_domain: general domain (i.e. active, karma > 1, website, ...)
            //           to compute the absolute position of the current record set
            // 
            //         :rtype: list[dict]
            //         :return:
            // 
            //             ::
            // 
            //                 [{
            //                     'user_id': user_id (belonging to current record set),
            //                     'karma_position': integer, ranking position
            //                 }, {..}] ordered by karma_position desc
            //         """
            //         if not self:
            //             return {}
            // 
            //         where_query = self.env['res.users']._search(user_domain, bypass_access=True)
            // 
            //         # we search on every user in the DB to get the real positioning (not the one inside the subset)
            //         # then, we filter to get only the subset.
            //         sql = SQL("""
            // SELECT sub.user_id, sub.karma_position
            // FROM (
            //     SELECT "res_users"."id" as user_id, row_number() OVER (ORDER BY res_users.karma DESC) AS karma_position
            //     FROM %s
            //     WHERE %s
            // ) sub
            // WHERE sub.user_id IN %s""",
            //             where_query.from_clause,
            //             where_query.where_clause or SQL("TRUE"),
            //             tuple(self.ids),
            //         )
            //         self.env.cr.execute(sql)
            //         return self.env.cr.dictfetchall()
            */
            return default;
        }

        protected async Task<ResUsers> GetLockTimeoutInactivityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_timeout, FILE: res_users.py) ---
            // def _get_lock_timeout_inactivity(self):
            // """
            // Return the shortest applicable inactivity timeout for the user.
            // 
            // Extracts the first (i.e., shortest) timeout from the "lock_timeout_inactivity"
            // entry in the user's timeout configuration, if present.
            // 
            // :return: Inactivity timeout in seconds, or None if not configured.
            // :rtype: float or None
            // """
            // timeouts = self._get_lock_timeouts()
            // return timeouts.get("lock_timeout_inactivity")[0][0] if timeouts.get("lock_timeout_inactivity") else None
            */
            return default;
        }

        protected async Task<ResUsers> GetLockTimeoutsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_timeout, FILE: res_users.py) ---
            // def _get_lock_timeouts(self):
            // """
            // Return the user's configured session and inactivity timeouts.
            // 
            // Delegates to the group-level `_get_lock_timeouts`, using the user's group membership
            // to determine applicable timeout settings.
            // 
            // :return: A dictionary of timeout types and values, as defined by `_get_lock_timeouts` on groups.
            // :rtype: dict
            // """
            // self.ensure_one()
            // # Take advantage of the ormcache of `self._get_group_ids()` to get the user groups and avoid queries
            // return self.env["res.groups"].browse(self._get_group_ids())._get_lock_timeouts()
            */
            return default;
        }

        protected async Task<ResUsers> GetLoginDomainInternalAsync(object login)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_users.py) ---
            // def _get_login_domain(self, login):
            // website = self.env['website'].get_current_website()
            // return super()._get_login_domain(login) & website.website_domain()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _get_login_domain(self, login):
            // return Domain('login', '=', login)
            */
            return default;
        }

        protected async Task<ResUsers> GetLoginOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_users.py) ---
            // def _get_login_order(self):
            // return 'website_id, ' + super(ResUsers, self)._get_login_order()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _get_login_order(self):
            // return self._order
            */
            return default;
        }

        protected async Task<ResUsers> GetMailServerSetupEndActionInternalAsync(object smtp_server)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: res_users.py) ---
            // def _get_mail_server_setup_end_action(self, smtp_server):
            // if smtp_server.smtp_authentication == "gmail":
            //     return smtp_server.sudo().open_google_gmail_uri()
            // return super()._get_mail_server_setup_end_action(smtp_server)
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _get_mail_server_setup_end_action(self, smtp_server):
            // raise NotImplementedError()
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: res_users.py) ---
            // def _get_mail_server_setup_end_action(self, smtp_server):
            // if smtp_server.smtp_authentication == 'outlook':
            //     return smtp_server.sudo().open_microsoft_outlook_uri()
            // return super()._get_mail_server_setup_end_action(smtp_server)
            */
            return default;
        }

        protected async Task<ResUsers> GetMailServerValuesInternalAsync(object server_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: res_users.py) ---
            // def _get_mail_server_values(self, server_type):
            // values = super()._get_mail_server_values(server_type)
            // if server_type == "gmail":
            //     values |= {
            //         "smtp_host": "smtp.gmail.com",
            //         "smtp_authentication": "gmail",
            //     }
            // return values
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _get_mail_server_values(self, server_type):
            // return {}
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: res_users.py) ---
            // def _get_mail_server_values(self, server_type):
            // values = super()._get_mail_server_values(server_type)
            // if server_type == "outlook":
            //     values |= {
            //         "smtp_host": "smtp-mail.outlook.com",
            //         "smtp_authentication": "outlook",
            //     }
            // return values
            */
            return default;
        }

        protected async Task<ResUsers> GetMicrosoftCalendarTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py) ---
            // def _get_microsoft_calendar_token(self):
            // if not self:
            //     return None
            // 
            // self.ensure_one()
            // if self.sudo().microsoft_calendar_rtoken and not self._is_microsoft_calendar_valid():
            //     self._refresh_microsoft_calendar_token()
            // return self.sudo().microsoft_calendar_token
            */
            return default;
        }

        protected async Task<ResUsers> GetMicrosoftSyncStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py) ---
            // def _get_microsoft_sync_status(self):
            // """ Returns the calendar synchronization status (active, paused or stopped). """
            // status = "sync_active"
            // if str2bool(self.env['ir.config_parameter'].sudo().get_param("microsoft_calendar_sync_paused"), default=False):
            //     status = "sync_paused"
            // elif self.sudo().microsoft_calendar_token and not self.sudo().microsoft_synchronization_stopped:
            //     status = "sync_active"
            // elif self.sudo().microsoft_synchronization_stopped:
            //     status = "sync_stopped"
            // return status
            */
            return default;
        }

        protected async Task<ResUsers> GetNextRankInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: res_users.py) ---
            // def _get_next_rank(self):
            // """ For fresh users with 0 karma that don't have a rank_id and next_rank_id yet
            // this method returns the first karma rank (by karma ascending). This acts as a
            // default value in related views.
            // 
            // TDE FIXME in post-12.4: make next_rank_id a non-stored computed field correctly computed """
            // 
            // if self.next_rank_id:
            //     return self.next_rank_id
            // else:
            //     domain = [('karma_min', '>', self.rank_id.karma_min)] if self.rank_id else []
            //     return self.env['gamification.karma.rank'].search(domain, order="karma_min ASC", limit=1)
            */
            return default;
        }

        protected async Task<ResUsers> GetOnLeaveIdsInternalAsync(object partner)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: res_users.py) ---
            // def _get_on_leave_ids(self, partner=False):
            // now = fields.Datetime.now()
            // field = 'partner_id' if partner else 'id'
            // self.flush_model(['active'])
            // self.env['hr.leave'].flush_model(['user_id', 'state', 'date_from', 'date_to'])
            // self.env.cr.execute('''SELECT res_users.%s FROM res_users
            //                     JOIN hr_leave ON hr_leave.user_id = res_users.id
            //                     AND hr_leave.state = 'validate'
            //                     AND res_users.active = 't'
            //                     AND hr_leave.date_from <= %%s AND hr_leave.date_to >= %%s
            //                     RIGHT JOIN hr_leave_type ON hr_leave.holiday_status_id = hr_leave_type.id
            //                     AND hr_leave_type.time_type = 'leave';''' % field, (now, now))
            // return [r[0] for r in self.env.cr.fetchall()]
            */
            return default;
        }

        public async Task<ResUsers> GetPasswordPolicyAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_password_policy, FILE: res_users.py) ---
            // def get_password_policy(self):
            // params = self.env['ir.config_parameter'].sudo()
            // return {
            //     'minlength': int(params.get_param('auth_password_policy.minlength', default=0)),
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> GetPersonalInfoPartnerIdsToNotifyInternalAsync(object employee)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def _get_personal_info_partner_ids_to_notify(self, employee):
            // if employee.version_id.hr_responsible_id:
            //     return (
            //         _("You are receiving this message because you are the HR Responsible of this employee."),
            //         employee.version_id.hr_responsible_id.partner_id.ids,
            //     )
            // return ('', [])
            */
            return default;
        }

        protected async Task<ResUsers> GetPortalAccessUpdateBodyInternalAsync(object access_granted)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _get_portal_access_update_body(self, access_granted):
            // body = _('Portal Access Granted') if access_granted else _('Portal Access Revoked')
            // if self.partner_id.email:
            //     return '%s (%s)' % (body, self.partner_id.email)
            // return body
            */
            return default;
        }

        public async Task<ResUsers> GetSelectedCalendarsPartnerIdsAsync(Guid id, ResUsersGetSelectedCalendarsPartnerIdsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_users.py) ---
            // def get_selected_calendars_partner_ids(self, include_user=True):
            // """
            // Retrieves the partner IDs of the attendees selected in the calendar view.
            // 
            // :param bool include_user: Determines whether to include the current user's partner ID in the results.
            // :return: A list of integer IDs representing the partners selected in the calendar view.
            //          If 'include_user' is True, the list will also include the current user's partner ID.
            // :rtype: list
            // """
            // self.ensure_one()
            // partner_ids = self.env['calendar.filters'].search([
            //     ('user_id', '=', self.id),
            //     ('partner_checked', '=', True)
            // ]).partner_id.ids
            // 
            // if include_user:
            //     partner_ids += [self.env.user.partner_id.id]
            // return partner_ids
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> GetSessionTokenFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py) ---
            // def _get_session_token_fields(self):
            // return super()._get_session_token_fields() | {'oauth_access_token'}
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: res_users.py) ---
            // def _get_session_token_fields(self):
            // return super()._get_session_token_fields() | {'auth_passkey_key_ids'}
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py) ---
            // def _get_session_token_fields(self):
            // return super()._get_session_token_fields() | {'totp_secret'}
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _get_session_token_fields(self):
            // return {'id', 'login', 'password', 'active'}
            */
            return default;
        }

        protected async Task<ResUsers> GetSessionTokenQueryParamsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: res_users.py) ---
            // def _get_session_token_query_params(self):
            // params = super()._get_session_token_query_params()
            // params['select'] = SQL(
            //     "%s, ARRAY_AGG(key.id ORDER BY key.id DESC) FILTER (WHERE key.id IS NOT NULL) as auth_passkey_key_ids",
            //     params['select']
            // )
            // params['joins'] = SQL("%s LEFT JOIN auth_passkey_key key ON res_users.id = key.create_uid", params['joins'])
            // return params
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _get_session_token_query_params(self):
            // database_secret = SQL("SELECT value FROM ir_config_parameter WHERE key='database.secret'")
            // fields = SQL(", ").join(
            //     SQL.identifier(self._table, fname)
            //     for fname in sorted(self._get_session_token_fields())
            //     # To handle `auth_passkey_key_ids`,
            //     # which we want in the `_get_session_token_fields` list for the cache invalidation mechanism
            //     # but which we do not want here as it isn't an actual column in the res_users table.
            //     # Instead, the left join to that table is done with an override of `_get_session_token_query_params`.
            //     if not self._fields[fname].relational
            // )
            // return {
            //     "select": SQL("(%s) as database_secret, %s", database_secret, fields),
            //     "from": SQL("res_users"),
            //     "joins": SQL(""),
            //     "where": SQL("res_users.id = %s", self.id),
            //     "group_by": SQL("res_users.id"),
            // }
            */
            return default;
        }

        protected async Task<ResUsers> GetSignupInvitationScopeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py) ---
            // def _get_signup_invitation_scope(self):
            // return self.env['ir.config_parameter'].sudo().get_param('auth_signup.invitation_scope', 'b2b')
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_users.py) ---
            // def _get_signup_invitation_scope(self):
            // current_website = self.env['website'].sudo().get_current_website()
            // return current_website.auth_signup_uninvited or super(ResUsers, self)._get_signup_invitation_scope()
            */
            return default;
        }

        protected async Task<ResUsers> GetStoreAvatarCardFieldsInternalAsync(object target)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _get_store_avatar_card_fields(self, target):
            // return ["share", Store.One("partner_id", self.partner_id._get_store_avatar_card_fields(target))]
            */
            return default;
        }

        public async Task<ResUsers> GetTotpInviteUrlAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py) ---
            // def get_totp_invite_url(self):
            // return '/odoo/action-auth_totp_mail.action_activate_two_factor_authentication'
            --- ODOO METHOD SOURCE (MODULE: auth_totp_portal, FILE: res_users.py) ---
            // def get_totp_invite_url(self):
            // if not self._is_internal():
            //     return '/my/security'
            // else:
            //     return super().get_totp_invite_url()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> GetTotpMailCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py) ---
            // def _get_totp_mail_code(self):
            // self.ensure_one()
            // 
            // key = self._get_totp_mail_key()
            // 
            // now = datetime.now()
            // counter = int(datetime.timestamp(now) / 3600)
            // 
            // code = hotp(key, counter)
            // expiration = timedelta(seconds=3600)
            // lang = babel_locale_parse(self.env.context.get('lang') or self.lang)
            // expiration = babel.dates.format_timedelta(expiration, locale=lang)
            // 
            // return str(code).zfill(6), expiration
            */
            return default;
        }

        protected async Task<ResUsers> GetTotpMailKeyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py) ---
            // def _get_totp_mail_key(self):
            // self.ensure_one()
            // return hmac(self.env(su=True), 'auth_totp_mail-code', (self.id, self.login, self.login_date)).encode()
            */
            return default;
        }

        protected async Task<ResUsers> GetTrackingKarmaGainPositionInternalAsync(object user_domain, object from_date, object to_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: res_users.py) ---
            // def _get_tracking_karma_gain_position(self, user_domain, from_date=None, to_date=None):
            //         """ Get absolute position in term of gained karma for users. First a ranking
            //         of all users is done given a user_domain; then the position of each user
            //         belonging to the current record set is extracted.
            // 
            //         Example: in website profile, search users with name containing Norbert. Their
            //         positions should not be 1 to 4 (assuming 4 results), but their actual position
            //         in the karma gain ranking (with example user_domain being karma > 1,
            //         website published True).
            // 
            //         :param user_domain: general domain (i.e. active, karma > 1, website, ...)
            //           to compute the absolute position of the current record set
            //         :param from_date: compute karma gained after this date (included) or from
            //           beginning of time;
            //         :param to_date: compute karma gained before this date (included) or until
            //           end of time;
            // 
            //         :rtype: list[dict]
            //         :return:
            //           ::
            // 
            //             [{
            //                 'user_id': user_id (belonging to current record set),
            //                 'karma_gain_total': integer, karma gained in the given timeframe,
            //                 'karma_position': integer, ranking position
            //             }, {..}]
            // 
            //           ordered by descending karma position
            //         """
            //         if not self:
            //             return []
            // 
            //         where_query = self.env['res.users']._search(user_domain, bypass_access=True)
            // 
            //         sql = SQL("""
            // SELECT final.user_id, final.karma_gain_total, final.karma_position
            // FROM (
            //     SELECT intermediate.user_id, intermediate.karma_gain_total, row_number() OVER (ORDER BY intermediate.karma_gain_total DESC) AS karma_position
            //     FROM (
            //         SELECT "res_users".id as user_id, COALESCE(SUM("tracking".new_value - "tracking".old_value), 0) as karma_gain_total
            //         FROM %s
            //         LEFT JOIN "gamification_karma_tracking" as "tracking"
            //         ON "res_users".id = "tracking".user_id AND "res_users"."active" IS TRUE
            //         WHERE %s %s %s
            //         GROUP BY "res_users".id
            //         ORDER BY karma_gain_total DESC
            //     ) intermediate
            // ) final
            // WHERE final.user_id IN %s""",
            //             where_query.from_clause,
            //             where_query.where_clause or SQL("TRUE"),
            //             SQL("AND tracking.tracking_date::DATE >= %s::DATE", from_date) if from_date else SQL(),
            //             SQL("AND tracking.tracking_date::DATE <= %s::DATE", to_date) if to_date else SQL(),
            //             tuple(self.ids),
            //         )
            // 
            //         self.env.cr.execute(sql)
            //         return self.env.cr.dictfetchall()
            */
            return default;
        }

        protected async Task<ResUsers> GetUserBadgeLevelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: res_users.py) ---
            // def _get_user_badge_level(self):
            // """ Return total badge per level of users
            // TDE CLEANME: shouldn't check type is forum ? """
            // for user in self:
            //     user.gold_badge = 0
            //     user.silver_badge = 0
            //     user.bronze_badge = 0
            // 
            // self.env.cr.execute("""
            //     SELECT bu.user_id, b.level, count(1)
            //     FROM gamification_badge_user bu, gamification_badge b
            //     WHERE bu.user_id IN %s
            //       AND bu.badge_id = b.id
            //       AND b.level IS NOT NULL
            //     GROUP BY bu.user_id, b.level
            //     ORDER BY bu.user_id;
            // """, [tuple(self.ids)])
            // 
            // for (user_id, level, count) in self.env.cr.fetchall():
            //     # levels are gold, silver, bronze but fields have _badge postfix
            //     self.browse(user_id)['{}_badge'.format(level)] = count
            */
            return default;
        }

        protected async Task<List<string>> GetUserCalendarConfigurationFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_users.py) ---
            // def _get_user_calendar_configuration_fields(self) -> list[str]:
            // """ Return the list of configurable fields for the user related to the res.users.settings table. """
            // return ['calendar_default_privacy']
            */
            return default;
        }

        public async Task<ResUsers> GetViewAsync(Guid id, ResUsersGetViewRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def get_view(self, view_id=None, view_type='form', **options):
            // # When the front-end loads the views it gets the list of available fields
            // # for the user (according to its access rights). Later, when the front-end wants to
            // # populate the view with data, it only asks to read those available fields.
            // # However, in this case, we want the user to be able to read/write its own data,
            // # even if they are protected by groups.
            // # We make the front-end aware of those fields by sending all field definitions.
            // # Note: limit the `sudo` to the only action of "editing own preferences" action in order to
            // # avoid breaking `groups` mecanism on res.users form view.
            // preferences_view = self.env.ref("hr.res_users_view_form_preferences")
            // if preferences_view and view_id == preferences_view.id:
            //     self = self.with_user(SUPERUSER_ID)
            // result = super().get_view(view_id, view_type, **options)
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> GetViewPostprocessedInternalAsync(object view, object arch)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _get_view_postprocessed(self, view, arch, **options):
            // arch, models = super()._get_view_postprocessed(view, arch, **options)
            // if view == self.env.ref('base.view_users_form_simple_modif'):
            //     tree = etree.fromstring(arch)
            //     for node_field in tree.xpath('//field[@__groups_key__]'):
            //         if node_field.get('name') in self.SELF_READABLE_FIELDS:
            //             node_field.attrib.pop('__groups_key__')
            //     arch = etree.tostring(tree)
            // return arch, models
            */
            return default;
        }

        public async Task<ResUsers> GetViewsAsync(Guid id, ResUsersGetViewsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def get_views(self, views, options=None):
            // # Requests the My Preferences form view as last.
            // # Otherwise the fields of the 'search' view will take precedence
            // # and will omit the fields that are requested as SUPERUSER
            // # in `get_view()`.
            // preferences_view = self.env.ref("hr.res_users_view_form_preferences")
            // preferences_form = preferences_view and [preferences_view.id, 'form']
            // if preferences_form and preferences_form in views:
            //     views.remove(preferences_form)
            //     views.append(preferences_form)
            // result = super().get_views(views, options)
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> HasAnyActiveSynchronizationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_users.py) ---
            // def _has_any_active_synchronization(self):
            // """
            // Overridable method for checking if user has any synchronization active in inherited modules.
            // 
            // :return: boolean indicating if any synchronization is active.
            // """
            // return False
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py) ---
            // def _has_any_active_synchronization(self):
            // """
            // Check if synchronization is active for Google Calendar.
            // This function retrieves the synchronization status from the user's environment
            // and checks if the Google Calendar synchronization is active.
            // 
            // :return: Action to delete the event
            // """
            // sync_status = self.check_synchronization_status()
            // res = super()._has_any_active_synchronization()
            // if sync_status.get('google_calendar') == 'sync_active':
            //     return True
            // return res
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py) ---
            // def _has_any_active_synchronization(self):
            // """
            // Check if synchronization is active for Microsoft Calendar.
            // This function retrieves the synchronization status from the user's environment
            // and checks if the Microsoft Calendar synchronization is active.
            // 
            // :return: Action to delete the event
            // """
            // sync_status = self.check_synchronization_status()
            // res = super()._has_any_active_synchronization()
            // if sync_status.get('microsoft_calendar') == 'sync_active':
            //     return True
            // return res
            */
            return default;
        }

        protected async Task<ResUsers> HasFieldAccessInternalAsync(object field, object operation)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _has_field_access(self, field, operation):
            // return super()._has_field_access(field, operation) or (
            //     operation == 'read'
            //     and self._origin == self.env.user
            //     and field.name in self._self_accessible_fields()[0]
            // )
            */
            return default;
        }

        public async Task<bool> HasGroupAsync(Guid id, ResUsersHasGroupRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def has_group(self, group_ext_id: str) -> bool:
            // """ Return whether user ``self`` belongs to the given group (given by its
            // fully-qualified external ID).
            // 
            // Note that the group ``"base.group_no_one"`` is only effective in debug
            // mode: the method returns ``True`` if the user belongs to the group and
            // the current request is in debug mode.
            // """
            // self.ensure_one()
            // if not (self.env.su or self == self.env.user or self.env.user._has_group('base.group_user')):
            //     # this prevents RPC calls from non-internal users to retrieve
            //     # information about other users
            //     raise AccessError(_("You can ony call user.has_group() with your current user."))
            // 
            // result = self._has_group(group_ext_id)
            // if group_ext_id == 'base.group_no_one':
            //     result = result and bool(request and request.session.debug)
            // return result
            */
            var entity = await Repository.GetAsync(id); return default;
        }

        protected async Task<bool> HasGroupInternalAsync(Guid group_ext_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _has_group(self, group_ext_id: str) -> bool:
            // """ Return whether user ``self`` belongs to the given group.
            // 
            // :param str group_ext_id: external ID (XML ID) of the group.
            //    Must be provided in fully-qualified form (``module.ext_id``), as there
            //    is no implicit module to use..
            // :return: True if user ``self`` is a member of the group with the
            //    given external ID (XML ID), else False.
            // """
            // group_id = self.env['res.groups']._get_group_definitions().get_id(group_ext_id)
            // # for new record don't fill the ormcache
            // return group_id in (self._get_group_ids() if self.id else self.all_group_ids._origin._ids)
            */
            return default;
        }

        public async Task<bool> HasGroupsAsync(Guid id, ResUsersHasGroupsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def has_groups(self, group_spec: str) -> bool:
            // """ Return whether user ``self`` satisfies the given group restrictions
            // ``group_spec``, i.e., whether it is member of at least one of the groups,
            // and is not a member of any of the groups preceded by ``!``.
            // 
            // Note that the group ``"base.group_no_one"`` is only effective in debug
            // mode, just like method :meth:`~.has_group` does.
            // 
            // :param str group_spec: comma-separated list of fully-qualified group
            //     external IDs, optionally preceded by ``!``.
            //     Example:``"base.group_user,base.group_portal,!base.group_system"``.
            // """
            // if group_spec == '.':
            //     return False
            // 
            // positives = []
            // negatives = []
            // for group_ext_id in group_spec.split(','):
            //     group_ext_id = group_ext_id.strip()
            //     if group_ext_id.startswith('!'):
            //         negatives.append(group_ext_id[1:])
            //     else:
            //         positives.append(group_ext_id)
            // 
            // # for the sake of performance, check negatives first
            // if any(self.has_group(ext_id) for ext_id in negatives):
            //     return False
            // if any(self.has_group(ext_id) for ext_id in positives):
            //     return True
            // return not positives
            */
            var entity = await Repository.GetAsync(id); return default;
        }

        protected async Task<ResUsers> HasSetupCredentialsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py) ---
            // def _has_setup_credentials(self):
            // """ Checks if both Client ID and Client Secret are defined in the database. """
            // ICP_sudo = self.env['ir.config_parameter'].sudo()
            // client_id = self.env['google.service']._get_client_id('calendar')
            // client_secret = google_service._get_client_secret(ICP_sudo, 'calendar')
            // return bool(client_id and client_secret)
            */
            return default;
        }

        protected async Task<ResUsers> HasSetupMicrosoftCredentialsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py) ---
            // def _has_setup_microsoft_credentials(self):
            // """ Checks if both Client ID and Client Secret are defined in the database. """
            // ICP_sudo = self.env['ir.config_parameter'].sudo()
            // client_id = self.env['microsoft.service']._get_microsoft_client_id('calendar')
            // client_secret = microsoft_service._get_microsoft_client_secret(ICP_sudo, 'calendar')
            // return bool(client_id and client_secret)
            */
            return default;
        }

        public async Task<ResUsers> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py) ---
            // def init(self):
            // super().init()
            // if not sql.column_exists(self.env.cr, self._table, "totp_secret"):
            //     self.env.cr.execute("ALTER TABLE res_users ADD COLUMN totp_secret varchar")
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def init(self):
            // cr = self.env.cr
            // 
            // # allow setting plaintext passwords via SQL and have them
            // # automatically encrypted at startup: look for passwords which don't
            // # match the "extended" MCF and pass those through passlib.
            // # Alternative: iterate on *all* passwords and use CryptContext.identify
            // cr.execute(r"""
            // SELECT id, password FROM res_users
            // WHERE password IS NOT NULL
            //   AND password !~ '^\$[^$]+\$[^$]+\$.'
            // """)
            // if self.env.cr.rowcount:
            //     ResUsers = self.sudo()
            //     for uid, pw in cr.fetchall():
            //         ResUsers.browse(uid).password = pw
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> InitMessagingInternalAsync(object store)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _init_messaging(self, store: Store):
            // self = self.with_user(self)
            // channels = self.env["discuss.channel"]._get_channels_as_member()
            // domain = [("channel_id", "in", channels.ids), ("is_self", "=", True)]
            // members = self.env["discuss.channel.member"].search(domain)
            // members_with_unread = members.filtered(lambda member: member.message_unread_counter)
            // # fetch channels data before calling super to benefit from prefetching (channel info might
            // # prefetch a lot of data that super could use, about the current user in particular)
            // super()._init_messaging(store)
            // store.add_global_values(initChannelsUnreadCounter=len(members_with_unread))
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _init_messaging(self, store: Store):
            // self.ensure_one()
            // self = self.with_user(self)
            // # sudo: bus.bus: reading non-sensitive last id
            // bus_last_id = self.env["bus.bus"].sudo()._bus_last_id()
            // store.add_global_values(
            //     inbox={
            //         "counter": self.partner_id._get_needaction_count(),
            //         "counter_bus_id": bus_last_id,
            //         "id": "inbox",
            //         "model": "mail.box",
            //     },
            //     starred={
            //         "counter": self.env["mail.message"].search_count(
            //             [("starred_partner_ids", "in", self.partner_id.ids)]
            //         ),
            //         "counter_bus_id": bus_last_id,
            //         "id": "starred",
            //         "model": "mail.box",
            //     },
            // )
            */
            return default;
        }

        protected async Task<ResUsers> InitOdoobotInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_bot, FILE: res_users.py) ---
            // def _init_odoobot(self):
            // self.ensure_one()
            // odoobot_id = self.env['ir.model.data']._xmlid_to_res_id("base.partner_root")
            // channel = self.env['discuss.channel']._get_or_create_chat([odoobot_id, self.partner_id.id])
            // message = Markup("%s<br/>%s<br/><b>%s</b> <span class=\"o_odoobot_command\">:)</span>") % (
            //     _("Hello,"),
            //     _("Odoo's chat helps employees collaborate efficiently. I'm here to help you discover its features."),
            //     _("Try to send me an emoji")
            // )
            // channel.sudo().message_post(
            //     author_id=odoobot_id,
            //     body=message,
            //     message_type="comment",
            //     silent=True,
            //     subtype_xmlid="mail.mt_comment",
            // )
            // self.sudo().odoobot_state = 'onboarding_emoji'
            // return channel
            */
            return default;
        }

        protected async Task<ResUsers> InitStoreDataInternalAsync(object store)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_livechat, FILE: res_users.py) ---
            // def _init_store_data(self, store: Store):
            // super()._init_store_data(store)
            // store.add_global_values(has_access_create_lead=self.env.user.has_group("sales_team.group_sale_salesman"))
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py) ---
            // def _init_store_data(self, store: Store):
            // super()._init_store_data(store)
            // store.add_global_values(has_access_livechat=self.env.user.has_access_livechat)
            // if not self.env.user._is_public():
            //     store.add(
            //         self.env.user,
            //         Store.Attr(
            //             "is_livechat_manager",
            //             lambda u: u.has_group("im_livechat.im_livechat_group_manager"),
            //         ),
            //     )
            // if self.env.user.has_access_livechat:
            //     store.add(self.env.user, Store.Many("livechat_expertise_ids", ["name"]))
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _init_store_data(self, store: Store):
            // super()._init_store_data(store)
            // # sudo: ir.config_parameter - reading hard-coded keys to check their existence, safe to
            // # return whether the features are enabled
            // get_param = self.env["ir.config_parameter"].sudo().get_param
            // store.add_global_values(
            //     hasGifPickerFeature=bool(get_param("discuss.tenor_api_key")),
            //     hasMessageTranslationFeature=bool(get_param("mail.google_translate_api_key")),
            //     hasCannedResponses=bool(self.env["mail.canned.response"].sudo().search([
            //         "|",
            //         ("create_uid", "=", self.env.user.id),
            //         ("group_ids", "in", self.env.user.all_group_ids.ids),
            //     ], limit=1)) if self.env.user else False,
            //     channel_types_with_seen_infos=sorted(
            //         self.env["discuss.channel"]._types_allowing_seen_infos()
            //     ),
            // )
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _init_store_data(self, store: Store):
            // """Initialize the store of the user."""
            // xmlid_to_res_id = self.env["ir.model.data"]._xmlid_to_res_id
            // # sudo: res.partner - exposing OdooBot data is considered acceptable
            // odoobot = self.env.ref("base.partner_root").sudo()
            // if not self.env.user._is_public():
            //     odoobot = odoobot.with_prefetch((odoobot + self.env.user.partner_id).ids)
            // store.add_global_values(
            //     action_discuss_id=xmlid_to_res_id("mail.action_discuss"),
            //     hasLinkPreviewFeature=self.env["mail.link.preview"]._is_link_preview_enabled(),
            //     internalUserGroupId=self.env.ref("base.group_user").id,
            //     mt_comment=xmlid_to_res_id("mail.mt_comment"),
            //     mt_note=xmlid_to_res_id("mail.mt_note"),
            //     odoobot=Store.One(odoobot),
            // )
            // if not self.env.user._is_public():
            //     settings = self.env["res.users.settings"]._find_or_create_for_user(self.env.user)
            //     store.add_global_values(
            //         self_partner=Store.One(
            //             self.env.user.partner_id,
            //             [
            //                 "active",
            //                 "avatar_128",
            //                 "im_status",
            //                 Store.One(
            //                     "main_user_id",
            //                     [
            //                         Store.Attr("is_admin", lambda u: u._is_admin()),
            //                         "notification_type",
            //                         "share",
            //                         "signature",
            //                     ],
            //                 ),
            //                 "name",
            //             ],
            //         ),
            //         settings=settings._res_users_settings_format(),
            //     )
            // if guest := self.env["mail.guest"]._get_guest_from_context():
            //     # sudo() => adding current guest data is acceptable
            //     store.add_global_values(self_guest=Store.One(guest.sudo(), ["avatar_128", "name"]))
            */
            return default;
        }

        protected async Task<ResUsers> InverseCalendarResUsersSettingsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_users.py) ---
            // def _inverse_calendar_res_users_settings(self):
            // """
            // Updates the values of the calendar fields in 'res_users_settings_ids' to have the same values as their related
            // fields in 'res.users'. If there is no 'res.users.settings' record for the user, then the record is created.
            // """
            // for user in self.filtered(lambda user: user._is_internal()):
            //     settings = self.env["res.users.settings"].sudo()._find_or_create_for_user(user)
            //     configuration = {field: user[field] for field in self._get_user_calendar_configuration_fields()}
            //     settings.sudo().update(configuration)
            */
            return default;
        }

        protected async Task<ResUsers> InverseLivechatExpertiseIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py) ---
            // def _inverse_livechat_expertise_ids(self):
            // for user in self:
            //     settings = self.env["res.users.settings"]._find_or_create_for_user(user)
            //     settings.livechat_expertise_ids = user.livechat_expertise_ids
            */
            return default;
        }

        protected async Task<ResUsers> InverseLivechatLangIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py) ---
            // def _inverse_livechat_lang_ids(self):
            // for user in self:
            //     settings = self.env['res.users.settings']._find_or_create_for_user(user)
            //     settings.livechat_lang_ids = user.livechat_lang_ids
            */
            return default;
        }

        protected async Task<ResUsers> InverseLivechatUsernameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py) ---
            // def _inverse_livechat_username(self):
            // for user in self:
            //     settings = self.env['res.users.settings']._find_or_create_for_user(user)
            //     settings.livechat_username = user.livechat_username
            */
            return default;
        }

        protected async Task<ResUsers> InverseNotificationTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _inverse_notification_type(self):
            // inbox_group = self.env.ref('mail.group_mail_notification_type_inbox')
            // inbox_users = self.filtered(lambda user: user.notification_type == 'inbox')
            // inbox_users.write({"group_ids": [Command.link(inbox_group.id)]})
            // (self - inbox_users).write({"group_ids": [Command.unlink(inbox_group.id)]})
            */
            return default;
        }

        protected async Task<ResUsers> InverseTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py) ---
            // def _inverse_token(self):
            // self.sudo().totp_last_counter = False
            // for user in self:
            //     secret = user.totp_secret if user.totp_secret else None
            //     self.env.cr.execute('UPDATE res_users SET totp_secret = %s WHERE id=%s', (secret, user.id))
            */
            return default;
        }

        protected async Task<ResUsers> IsAdminInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _is_admin(self):
            // self.ensure_one()
            // return self._is_superuser() or self.sudo().has_group('base.group_erp_manager')
            */
            return default;
        }

        public async Task<ResUsers> IsGoogleCalendarSyncedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py) ---
            // def is_google_calendar_synced(self):
            // """ True if Google Calendar settings are filled (Client ID / Secret) and user calendar is synced
            // meaning we can make API calls, false otherwise."""
            // self.ensure_one()
            // return self.sudo().google_calendar_token and self._get_google_sync_status() == 'sync_active'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> IsInternalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _is_internal(self):
            // self.ensure_one()
            // return self.sudo().has_group('base.group_user')
            */
            return default;
        }

        protected async Task<ResUsers> IsMicrosoftCalendarValidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py) ---
            // def _is_microsoft_calendar_valid(self):
            // return self.sudo().microsoft_calendar_token_validity and self.sudo().microsoft_calendar_token_validity >= (fields.Datetime.now() + timedelta(minutes=1))
            */
            return default;
        }

        protected async Task<ResUsers> IsPortalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _is_portal(self):
            // self.ensure_one()
            // return self.sudo().has_group('base.group_portal')
            */
            return default;
        }

        protected async Task<ResUsers> IsPublicInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _is_public(self):
            // self.ensure_one()
            // return self.sudo().has_group('base.group_public')
            */
            return default;
        }

        protected async Task<ResUsers> IsSuperuserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _is_superuser(self):
            // self.ensure_one()
            // return self.id == SUPERUSER_ID
            */
            return default;
        }

        protected async Task<ResUsers> IsSystemInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _is_system(self):
            // self.ensure_one()
            // return self.sudo().has_group('base.group_system')
            */
            return default;
        }

        public async Task<ResUsers> KarmaReportAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: res_users.py) ---
            // def action_karma_report(self):
            // self.ensure_one()
            // 
            // return {
            //     'name': _('Karma Updates'),
            //     'res_model': 'gamification.karma.tracking',
            //     'target': 'current',
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'list',
            //     'context': {
            //         'default_user_id': self.id,
            //         'search_default_user_id': self.id,
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> LegacySessionTokenHashComputeInternalAsync(object sid)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _legacy_session_token_hash_compute(self, sid):
            // field_values = self._session_token_get_values()
            // if not field_values:
            //     return False
            // # generate hmac key
            // key = ('%s' % (tuple(f[1] for f in field_values),)).encode()
            // # hmac the session id
            // data = sid.encode()
            // h = hmac.new(key, data, sha256)
            // # keep in the cache the token
            // return h.hexdigest()
            */
            return default;
        }

        protected async Task<ResUsers> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: res_users.py) ---
            // def _load_pos_data_domain(self, data, config):
            // return [('id', '=', self.env.uid)]
            */
            return default;
        }

        protected async Task<ResUsers> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: res_users.py) ---
            // def _load_pos_data_fields(self, config):
            // return ['id', 'name', 'partner_id', 'all_group_ids']
            */
            return default;
        }

        protected async Task<ResUsers> LoadPosDataReadInternalAsync(object records, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: res_users.py) ---
            // def _load_pos_data_read(self, records, config):
            // read_records = super()._load_pos_data_read(records, config)
            // if read_records:
            //     read_records[0]['role'] = 'manager' if config.group_pos_manager_id.id in read_records[0]['all_group_ids'] else 'cashier'
            //     del read_records[0]['all_group_ids']
            // return read_records
            */
            return default;
        }

        protected async Task<ResUsers> LoginInternalAsync(object credential, object user_agent_env)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_ldap, FILE: res_users.py) ---
            // def _login(self, credential, user_agent_env):
            // try:
            //     return super()._login(credential, user_agent_env=user_agent_env)
            // except AccessDenied:
            //     login = credential['login']
            //     self.env.cr.execute("SELECT id FROM res_users WHERE lower(login)=%s", (login,))
            //     res = self.env.cr.fetchone()
            //     if res:
            //         raise
            // 
            //     Ldap = self.env['res.company.ldap'].sudo()
            //     for conf in Ldap._get_ldap_dicts():
            //         entry = Ldap._authenticate(conf, login, credential['password'])
            //         if entry:
            //             return {
            //                 'uid': Ldap._get_or_create_user(conf, login, entry),
            //                 'auth_method': 'ldap',
            //                 'mfa': 'default',
            //             }
            //     raise
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: res_users.py) ---
            // def _login(self, credential, user_agent_env):
            // if credential['type'] == 'webauthn':
            //     webauthn = json.loads(credential['webauthn_response'])
            //     self.env.cr.execute(SQL("""
            //         SELECT login
            //             FROM auth_passkey_key key
            //             JOIN res_users usr ON usr.id = key.create_uid
            //             WHERE credential_identifier=%s
            //     """, webauthn['id']))
            //     res = self.env.cr.fetchone()
            //     if not res:
            //         raise AccessDenied(_('Unknown passkey'))
            //     credential['login'] = res[0]
            // return super()._login(credential, user_agent_env=user_agent_env)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _login(self, credential, user_agent_env):
            // login = credential['login']
            // ip = request.httprequest.environ['REMOTE_ADDR'] if request else 'n/a'
            // try:
            //     with self._assert_can_auth(user=login):
            //         user = self.sudo().search(self._get_login_domain(login), order=self._get_login_order(), limit=1)
            //         if not user:
            //             # ruff: noqa: TRY301
            //             raise AccessDenied()
            //         user = user.with_user(user).sudo()
            //         auth_info = user._check_credentials(credential, user_agent_env)
            //         tz = request.cookies.get('tz') if request else None
            //         if tz in pytz.all_timezones and (not user.tz or not user.login_date):
            //             # first login or missing tz -> set tz to browser tz
            //             user.tz = tz
            //         user._update_last_login()
            // except AccessDenied:
            //     _logger.info("Login failed for login:%s from %s", login, ip)
            //     raise
            // 
            // _logger.info("Login successful for login:%s from %s", login, ip)
            // 
            // return auth_info
            */
            return default;
        }

        protected async Task<ResUsers> MfaTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py) ---
            // def _mfa_type(self):
            // r = super()._mfa_type()
            // if r is not None:
            //     return r
            // if self.totp_enabled:
            //     return 'totp'
            --- ODOO METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py) ---
            // def _mfa_type(self):
            // r = super()._mfa_type()
            // if r is not None:
            //     return r
            // ICP = self.env['ir.config_parameter'].sudo()
            // otp_required = False
            // if ICP.get_param('auth_totp.policy') == 'all_required' or \
            //         (ICP.get_param('auth_totp.policy') == 'employee_required' and self._is_internal()):
            //     otp_required = True
            // if otp_required:
            //     return 'totp_mail'
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _mfa_type(self):
            // """ If an MFA method is enabled, returns its type as a string. """
            // return
            */
            return default;
        }

        protected async Task<ResUsers> MfaUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py) ---
            // def _mfa_url(self):
            // r = super()._mfa_url()
            // if r is not None:
            //     return r
            // if self._mfa_type() == 'totp':
            //     return '/web/login/totp'
            --- ODOO METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py) ---
            // def _mfa_url(self):
            // r = super()._mfa_url()
            // if r is not None:
            //     return r
            // if self._mfa_type() == 'totp_mail':
            //     return '/web/login/totp'
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _mfa_url(self):
            // """ If an MFA method is enabled, returns the URL for its second step. """
            // return
            */
            return default;
        }

        protected async Task<ResUsers> MicrosoftCalendarAuthenticatedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py) ---
            // def _microsoft_calendar_authenticated(self):
            // return bool(self.sudo().microsoft_calendar_rtoken)
            */
            return default;
        }

        public override async Task<List<(Guid Id, string Name)>> NameSearchAsync(string name, string domain = null, string @operator = "ilike", int limit = 100)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: res_users.py) ---
            // def name_search(self, name='', domain=None, operator='ilike', limit=100):
            // # if we have a search with a limit, move current user as the first result
            // domain = Domain(domain or Domain.TRUE)
            // user_list = super().name_search(name, domain, operator, limit)
            // uid = self.env.uid
            // # index 0 is correct not Falsy in this case, use None to avoid ignoring it
            // if (index := next((i for i, (user_id, _name) in enumerate(user_list) if user_id == uid), None)) is not None:
            //     # move found user first
            //     user_tuple = user_list.pop(index)
            //     user_list.insert(0, user_tuple)
            // elif limit is not None and len(user_list) == limit:
            //     # user not found and limit reached, try to find the user again
            //     if user_tuple := super().name_search(name, domain & Domain('id', '=', uid), operator, limit=1):
            //         user_list = [user_tuple[0], *user_list[:-1]]
            // return user_list
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def name_search(self, name='', domain=None, operator='ilike', limit=100):
            // domain = Domain(domain or Domain.TRUE)
            // # first search only by login, then the normal search
            // if (
            //     name and not operator in Domain.NEGATIVE_OPERATORS
            //     and (user := self.search_fetch(Domain('login', '=', name) & domain, ['display_name']))
            // ):
            //     return [(user.id, user.display_name)]
            // return super().name_search(name, domain, operator, limit)
            */
            return await base.NameSearchAsync(name, domain, @operator, limit);
        }

        public async Task<ResUsers> NewAsync(Guid id, ResUsersNewRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def new(self, values=None, origin=None, ref=None):
            // if values is None:
            //     values = {}
            // user = super().new(values=values, origin=origin, ref=ref)
            // group_multi_company_id = self.env['ir.model.data']._xmlid_to_res_id(
            //     'base.group_multi_company', raise_if_not_found=False)
            // if group_multi_company_id:
            //     if len(user.company_ids) <= 1 and group_multi_company_id in user.group_ids.ids:
            //         user.update({'group_ids': [Command.unlink(group_multi_company_id)]})
            //     elif len(user.company_ids) > 1 and group_multi_company_id not in user.group_ids.ids:
            //         user.update({'group_ids': [Command.link(group_multi_company_id)]})
            // return user
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> NotifyInviterInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py) ---
            // def _notify_inviter(self):
            // for user in self:
            //     # notify invite user that new user is connected
            //     user.create_uid._bus_send(
            //         "res.users/connection", {"username": user.name, "partnerId": user.partner_id.id}
            //     )
            */
            return default;
        }

        protected async Task<ResUsers> NotifySecurityNewConnectionInternalAsync(object auth_info)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py) ---
            // def _notify_security_new_connection(self, auth_info):
            // user = self.env(user=auth_info['uid']).user
            // 
            // if request and user.email and user._mfa_type():
            //     # Check the `request` object to ensure that we will be able to get the
            //     # user information (like IP, user-agent, etc) and the cookie `td_id`.
            //     # (Can be unbounded if executed from a server action or a unit test.)
            // 
            //     key = request.cookies.get('td_id')
            //     if not key or not request.env['auth_totp.device']._check_credentials_for_uid(
            //             scope="browser", key=key, uid=user.id):
            //         # 2FA enabled but not a trusted device
            //         user._notify_security_setting_update(
            //             subject=_('New Connection to your Account'),
            //             content=_('A new device was used to sign in to your account.'),
            //         )
            //         _logger.info("New device alert email sent for user <%s> to <%s>", user.login, user.email)
            */
            return default;
        }

        protected async Task<ResUsers> NotifySecuritySettingUpdateInternalAsync(object subject, object content, object mail_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _notify_security_setting_update(self, subject, content, mail_values=None, **kwargs):
            // """ This method is meant to be called whenever a sensitive update is done on the user's account.
            // It will send an email to the concerned user warning him about this change and making some security suggestions.
            // 
            // :param str subject: The subject of the sent email (e.g: 'Security Update: Password Changed')
            // :param str content: The text to embed within the email template (e.g: 'Your password has been changed')
            // :param kwargs: 'suggest_password_reset' key:
            //     Whether or not to suggest the end-user to reset
            //     his password in the email sent.
            //     Defaults to True. """
            // 
            // mail_create_values = []
            // for user in self:
            //     body_html = self.env['mail.render.mixin']._render_template(
            //         'mail.account_security_alert',
            //         model='res.users',
            //         res_ids=user.ids,
            //         engine='qweb_view',
            //         options={'post_process': True},
            //         add_context=user._notify_security_setting_update_prepare_values(content, **kwargs),
            //     )[user.id]
            // 
            //     body_html = self.env['mail.render.mixin']._render_encapsulate(
            //         'mail.mail_notification_light',
            //         body_html,
            //         add_context={
            //             'model_description': _('Account'),
            //         },
            //         context_record=user,
            //     )
            // 
            //     vals = {
            //         'auto_delete': True,
            //         'body_html': body_html,
            //         'author_id': self.env.user.partner_id.id,
            //         'email_from': (
            //             user.company_id.partner_id.email_formatted or
            //             self.env.user.email_formatted or
            //             self.env.ref('base.user_root').email_formatted
            //         ),
            //         'email_to': kwargs.get('force_email') or user.email_formatted,
            //         'subject': subject,
            //     }
            // 
            //     if mail_values:
            //         vals.update(mail_values)
            // 
            //     mail_create_values.append(vals)
            // 
            // mails = self.env['mail.mail'].sudo().create(mail_create_values)
            // with contextlib.suppress(Exception):
            //     mails.send()
            // return mails
            */
            return default;
        }

        protected async Task<ResUsers> NotifySecuritySettingUpdatePrepareValuesInternalAsync(object content)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py) ---
            // def _notify_security_setting_update_prepare_values(self, content, *, suggest_2fa=True, **kwargs):
            // """" Prepare rendering values for the 'mail.account_security_alert' qweb template
            // 
            //   :param bool suggest_2fa:
            //     Whether or not to suggest the end-user to turn on 2FA authentication in the email sent.
            //     It will only suggest to turn on 2FA if not already turned on on the user's account. """
            // 
            // values = super()._notify_security_setting_update_prepare_values(content, **kwargs)
            // values['suggest_2fa'] = suggest_2fa and not self.totp_enabled
            // return values
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _notify_security_setting_update_prepare_values(self, content, **kwargs):
            // """"Prepare rendering values for the 'mail.account_security_alert' qweb template."""
            // reset_password_enabled = str2bool(self.env['ir.config_parameter'].sudo().get_param("auth_signup.reset_password", True))
            // 
            // values = {
            //     'browser': False,
            //     'content': content,
            //     'event_datetime': fields.Datetime.now(),
            //     'ip_address': False,
            //     'location_address': False,
            //     'suggest_password_reset': kwargs.get('suggest_password_reset', True) and reset_password_enabled,
            //     'user': self,
            //     'useros': False,
            // }
            // if not request:
            //     return values
            // 
            // city = request.geoip.get('city') or False
            // region = request.geoip.get('region_name') or False
            // country = request.geoip.get('country') or False
            // if country:
            //     if region and city:
            //         values['location_address'] = _("Near %(city)s, %(region)s, %(country)s", city=city, region=region, country=country)
            //     elif region:
            //         values['location_address'] = _("Near %(region)s, %(country)s", region=region, country=country)
            //     else:
            //         values['location_address'] = _("In %(country)s", country=country)
            // values['ip_address'] = request.httprequest.environ['REMOTE_ADDR']
            // if request.httprequest.user_agent:
            //     if request.httprequest.user_agent.browser:
            //         values['browser'] = request.httprequest.user_agent.browser.capitalize()
            //     if request.httprequest.user_agent.platform:
            //         values['useros'] = request.httprequest.user_agent.platform.capitalize()
            // return values
            */
            return default;
        }

        public async Task<ResUsers> OnChangeLoginAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def on_change_login(self):
            // if self.login and tools.single_email_re.match(self.login):
            //     self.email = self.login
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> OnLoginCooldownInternalAsync(object failures, object previous)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _on_login_cooldown(self, failures, previous):
            // """ Decides whether the user trying to log in is currently
            // "on cooldown" and not even allowed to attempt logging in.
            // 
            // The default cooldown function simply puts the user on cooldown for
            // <login_cooldown_duration> seconds after each failure following the
            // <login_cooldown_after>th (0 to disable).
            // 
            // Can be overridden to implement more complex backoff strategies, or
            // e.g. wind down or reset the cooldown period as the previous failure
            // recedes into the far past.
            // 
            // :param int failures: number of recorded failures (since last success)
            // :param previous: timestamp of previous failure
            // :type previous:  datetime.datetime
            // :returns: whether the user is currently in cooldown phase (true if cooldown, false if no cooldown and login can continue)
            // :rtype: bool
            // """
            // cfg = self.env['ir.config_parameter'].sudo()
            // min_failures = int(cfg.get_param('base.login_cooldown_after', 5))
            // if min_failures == 0:
            //     return False
            // 
            // delay = int(cfg.get_param('base.login_cooldown_duration', 60))
            // return failures >= min_failures and (datetime.datetime.now() - previous) < datetime.timedelta(seconds=delay)
            */
            return default;
        }

        protected async Task<ResUsers> OnWebclientBootstrapInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_bot, FILE: res_users.py) ---
            // def _on_webclient_bootstrap(self):
            // super()._on_webclient_bootstrap()
            // if self._is_internal() and self.odoobot_state in [False, "not_initialized"]:
            //     self._init_odoobot()
            --- ODOO METHOD SOURCE (MODULE: web, FILE: res_users.py) ---
            // def _on_webclient_bootstrap(self):
            // self.ensure_one()
            */
            return default;
        }

        protected async Task<ResUsers> OnboardUsersIntoProjectInternalAsync(object users)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: res_users.py) ---
            // def _onboard_users_into_project(self, users):
            // if (internal_users := users.filtered(lambda u: not u.share)):
            //     ProjectTaskTypeSudo = self.env["project.task.type"].sudo()
            //     create_vals = []
            //     for user in internal_users:
            //         vals = self.env["project.task"].with_context(lang=user.lang)._get_default_personal_stage_create_vals(user.id)
            //         create_vals.extend(vals)
            // 
            //     if create_vals:
            //         ProjectTaskTypeSudo.with_context(default_project_id=False).create(create_vals)
            // 
            //     return internal_users
            --- ODOO METHOD SOURCE (MODULE: project_todo, FILE: res_users.py) ---
            // def _onboard_users_into_project(self, users):
            // res = super()._onboard_users_into_project(users)
            // if res:
            //     res._generate_onboarding_todo()
            */
            return default;
        }

        public async Task<ResUsers> OnchangeParentIdAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def onchange_parent_id(self):
            // return self.partner_id.onchange_parent_id()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> OnchangePrivateStateIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def _onchange_private_state_id(self):
            // if self.private_state_id:
            //     self.private_country_id = self.private_state_id.country_id
            */
            return default;
        }

        protected async Task<ResUsers> OnchangeRoleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _onchange_role(self):
            // group_admin = self.env['res.groups'].new(origin=self.env.ref('base.group_system'))
            // group_user = self.env['res.groups'].new(origin=self.env.ref('base.group_user'))
            // for user in self:
            //     if user.role and user.has_group('base.group_user'):
            //         groups = user.group_ids - (group_admin + group_user)
            //         user.group_ids = groups + (group_admin if user.role == 'group_system' else group_user)
            */
            return default;
        }

        protected async Task<ResUsers> OndeleteSignupCancelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py) ---
            // def _ondelete_signup_cancel(self):
            // # Cancel pending partner signup when the user is deleted.
            // for user in self:
            //     if user.partner_id:
            //         user.partner_id.signup_cancel()
            */
            return default;
        }

        public async Task<ResUsers> OpenEmployeesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def action_open_employees(self):
            // self.ensure_one()
            // employees = self.employee_ids
            // model = 'hr.employee' if self.env.user.has_group('hr.group_hr_user') else 'hr.employee.public'
            // if len(employees) > 1:
            //     return {
            //         'name': _('Related Employees'),
            //         'type': 'ir.actions.act_window',
            //         'res_model': model,
            //         'view_mode': 'kanban,list,form',
            //         'domain': [('id', 'in', employees.ids)],
            //     }
            // return {
            //     'name': _('Employee'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': model,
            //     'res_id': employees.id,
            //     'view_mode': 'form',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> OpenMyAccountSettingsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py) ---
            // def action_open_my_account_settings(self):
            // action = {
            //     "name": _("Security"),
            //     "type": "ir.actions.act_window",
            //     "res_model": "res.users",
            //     "views": [[self.env.ref('auth_totp_mail.res_users_view_form').id, "form"]],
            //     "res_id": self.id,
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> OpenWebsiteUrlAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: res_users.py) ---
            // def open_website_url(self):
            // return self.mapped('partner_id').open_website_url()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> PauseGoogleSynchronizationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py) ---
            // def pause_google_synchronization(self):
            // self.env['ir.config_parameter'].sudo().set_param("google_calendar_sync_paused", True)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> PauseMicrosoftSynchronizationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py) ---
            // def pause_microsoft_synchronization(self):
            // self.env['ir.config_parameter'].sudo().set_param("microsoft_calendar_sync_paused", True)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> PreferenceChangePasswordAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def preference_change_password(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'target': 'new',
            //     'res_model': 'change.password.own',
            //     'view_mode': 'form',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> PreferenceSaveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def preference_save(self):
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'reload_context',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> ProcessProfileValidationTokenInternalAsync(object token, object email)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_profile, FILE: res_users.py) ---
            // def _process_profile_validation_token(self, token, email):
            // self.ensure_one()
            // validation_token = self._generate_profile_token(self.id, email)
            // if token == validation_token and self.karma == 0:
            //     return self.write({'karma': VALIDATION_KARMA_GAIN})
            // return False
            */
            return default;
        }

        protected async Task<ResUsers> RankChangedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: res_users.py) ---
            // def _rank_changed(self):
            // """
            //     Method that can be called on a batch of users with the same new rank
            // """
            // if self.env.context.get('install_mode', False):
            //     # avoid sending emails in install mode (prevents spamming users when creating data ranks)
            //     return
            // 
            // template = self.env.ref('gamification.mail_template_data_new_rank_reached', raise_if_not_found=False)
            // if template:
            //     for u in self:
            //         if u.rank_id.karma_min > 0:
            //             template.send_mail(u.id, force_send=False, email_layout_xmlid='mail.mail_notification_light')
            */
            return default;
        }

        protected async Task<ResUsers> RecomputeRankBulkInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: res_users.py) ---
            // def _recompute_rank_bulk(self):
            // """
            //     Compute rank of each user by rank.
            //     For each rank, check which users need to be ranked
            // 
            // """
            // ranks = [{'rank': rank, 'karma_min': rank.karma_min} for rank in
            //          self.env['gamification.karma.rank'].search([], order="karma_min DESC")]
            // 
            // users_todo = self
            // 
            // next_rank_id = False
            // # wtf, next_rank_id should be a related on rank_id.next_rank_id and life might get easier.
            // # And we only need to recompute next_rank_id on write with min_karma or in the create on rank model.
            // for r in ranks:
            //     rank_id = r['rank'].id
            //     dom = [
            //         ('karma', '>=', r['karma_min']),
            //         ('id', 'in', users_todo.ids),
            //         '|',  # noqa
            //             '|', ('rank_id', '!=', rank_id), ('rank_id', '=', False),
            //             '|', ('next_rank_id', '!=', next_rank_id), ('next_rank_id', '=', False if next_rank_id else -1),
            //     ]
            //     users = self.env['res.users'].search(dom)
            //     if users:
            //         users_to_notify = self.env['res.users'].search([
            //             ('karma', '>=', r['karma_min']),
            //             '|', ('rank_id', '!=', rank_id), ('rank_id', '=', False),
            //             ('id', 'in', users.ids),
            //         ])
            //         users.write({
            //             'rank_id': rank_id,
            //             'next_rank_id': next_rank_id,
            //         })
            //         users_to_notify._rank_changed()
            //         users_todo -= users
            // 
            //     nothing_to_do_users = self.env['res.users'].search([
            //         ('karma', '>=', r['karma_min']),
            //         '|', ('rank_id', '=', rank_id), ('next_rank_id', '=', next_rank_id),
            //         ('id', 'in', users_todo.ids),
            //     ])
            //     users_todo -= nothing_to_do_users
            //     next_rank_id = r['rank'].id
            // 
            // if ranks:
            //     lower_rank = ranks[-1]['rank']
            //     users = self.env['res.users'].search([
            //         ('karma', '>=', 0),
            //         ('karma', '<', lower_rank.karma_min),
            //         '|', ('rank_id', '!=', False), ('next_rank_id', '!=', lower_rank.id),
            //         ('id', 'in', users_todo.ids),
            //     ])
            //     if users:
            //         users.write({
            //             'rank_id': False,
            //             'next_rank_id': lower_rank.id,
            //         })
            */
            return default;
        }

        protected async Task<ResUsers> RecomputeRankInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: res_users.py) ---
            // def _recompute_rank(self):
            // """
            // The caller should filter the users on karma > 0 before calling this method
            // to avoid looping on every single users
            // 
            // Compute rank of each user by user.
            // For each user, check the rank of this user
            // """
            // 
            // ranks = [{'rank': rank, 'karma_min': rank.karma_min} for rank in
            //          self.env['gamification.karma.rank'].search([], order="karma_min DESC")]
            // 
            // # 3 is the number of search/requests used by rank in _recompute_rank_bulk()
            // if len(self) > len(ranks) * 3:
            //     self._recompute_rank_bulk()
            //     return
            // 
            // for user in self:
            //     old_rank = user.rank_id
            //     if user.karma == 0 and ranks:
            //         user.write({'next_rank_id': ranks[-1]['rank'].id})
            //     else:
            //         for i in range(0, len(ranks)):
            //             if user.karma >= ranks[i]['karma_min']:
            //                 user.write({
            //                     'rank_id': ranks[i]['rank'].id,
            //                     'next_rank_id': ranks[i - 1]['rank'].id if 0 < i else False
            //                 })
            //                 break
            //     if old_rank != user.rank_id:
            //         user._rank_changed()
            */
            return default;
        }

        protected async Task<ResUsers> RefreshMicrosoftCalendarTokenInternalAsync(object service)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py) ---
            // def _refresh_microsoft_calendar_token(self, service='calendar'):
            // self.ensure_one()
            // try:
            //     access_token, ttl = self.env['microsoft.service']._refresh_microsoft_token('calendar', self.sudo().microsoft_calendar_rtoken)
            //     self.sudo().write({
            //         'microsoft_calendar_token': access_token,
            //         'microsoft_calendar_token_validity': fields.Datetime.now() + timedelta(seconds=ttl),
            //     })
            // except requests.HTTPError as error:
            //     if error.response.status_code in (400, 401):  # invalid grant or invalid client
            //         # Delete refresh token and make sure it's commited
            //         self.env.cr.rollback()
            //         self.sudo().write({
            //             'microsoft_calendar_rtoken': False,
            //             'microsoft_calendar_token': False,
            //             'microsoft_calendar_token_validity': False,
            //         })
            //         self.res_users_settings_id.sudo().write({
            //             'microsoft_calendar_sync_token': False
            //         })
            //         self.env.cr.commit()
            //     error_key = error.response.json().get("error", "nc")
            //     error_msg = _(
            //         "An error occurred while generating the token. Your authorization code may be invalid or has already expired [%s]. "
            //         "You should check your Client ID and secret on the Microsoft Azure portal or try to stop and restart your calendar synchronisation.",
            //         error_key)
            //     raise UserError(error_msg)
            */
            return default;
        }

        protected async Task<ResUsers> RegisterHookInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _register_hook(self):
            // if hasattr(self, 'check_credentials'):
            //     _logger.warning("The check_credentials method of res.users has been renamed _check_credentials. One of your installed modules defines one, but it will not be called anymore.")
            */
            return default;
        }

        public async Task<ResUsers> RelatedContactAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def action_related_contact(self):
            // return {
            //     'name': _("Related Contact"),
            //     'res_id': self.partner_id.id,
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'res.partner',
            //     'view_mode': 'form',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> RemoveOauthAccessTokenAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py) ---
            // def remove_oauth_access_token(self):
            // user = self.env.user
            // if not (user.has_group('base.group_erp_manager') or self == user):
            //     raise AccessError(self.env._('You do not have permissions to remove the access token'))
            // self.sudo().oauth_access_token = False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> RemoveRecruitmentInterviewersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: res_users.py) ---
            // def _remove_recruitment_interviewers(self):
            // if not self:
            //     return
            // interviewer_group = self.env.ref('hr_recruitment.group_hr_recruitment_interviewer')
            // recruitment_group = self.env.ref('hr_recruitment.group_hr_recruitment_user')
            // 
            // job_interviewers = self.env['hr.job']._read_group([('interviewer_ids', 'in', self.ids)], ['interviewer_ids'])
            // user_ids = {interviewer.id for [interviewer] in job_interviewers}
            // 
            // application_interviewers = self.env['hr.applicant']._read_group([('interviewer_ids', 'in', self.ids)], ['interviewer_ids'])
            // user_ids |= {interviewer.id for [interviewer] in application_interviewers}
            // 
            // # Remove users that are no longer interviewers on at least a job or an application
            // users_to_remove = set(self.ids) - (user_ids | set(recruitment_group.all_user_ids.ids))
            // self.env['res.users'].browse(users_to_remove).sudo().write({
            //     'group_ids': [(3, interviewer_group.id)]
            // })
            */
            return default;
        }

        public async Task<ResUsers> ResetPasswordAsync(Guid id, ResUsersResetPasswordRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py) ---
            // def reset_password(self, login):
            // """ retrieve the user corresponding to login (login or email),
            //     and reset their password
            // """
            // users = self.search(self._get_login_domain(login))
            // if not users:
            //     users = self.search(self._get_email_domain(login))
            // if not users:
            //     raise Exception(_('No account found for this login'))
            // if len(users) > 1:
            //     raise Exception(_('Multiple accounts found for this login'))
            // return users.action_reset_password()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> ResetPasswordAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py) ---
            // def action_reset_password(self):
            // try:
            //     if self.env.context.get('create_user') == 1:
            //         return self._action_reset_password(signup_type="signup")
            //     else:
            //         return self._action_reset_password(signup_type="reset")
            // except MailDeliveryException as mde:
            //     if len(mde.args) == 2 and isinstance(mde.args[1], ConnectionRefusedError):
            //         raise UserError(_("Could not contact the mail server, please check your outgoing email server configuration")) from mde
            //     else:
            //         raise UserError(_("There was an error when trying to deliver your Email, please check your configuration")) from mde
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> RestartGoogleSynchronizationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py) ---
            // def restart_google_synchronization(self):
            // self.ensure_one()
            // self.sudo().google_synchronization_stopped = False
            // self.env['calendar.recurrence']._restart_google_sync()
            // self.env['calendar.event']._restart_google_sync()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> RestartMicrosoftSynchronizationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py) ---
            // def restart_microsoft_synchronization(self):
            // self.ensure_one()
            // self.sudo().microsoft_last_sync_date = datetime.now()
            // self.sudo().microsoft_synchronization_stopped = False
            // self.env['calendar.recurrence']._restart_microsoft_sync()
            // self.env['calendar.event']._restart_microsoft_sync()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> RevokeAllDevicesActionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py) ---
            // def revoke_all_devices(self):
            // self._revoke_all_devices()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> RevokeAllDevicesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def action_revoke_all_devices(self):
            // # self.env.user is sudo by default
            // # Need sudo to bypass access error for removing the devices of portal user
            // return (self.env.user if self.id == self.env.uid else self)._action_revoke_all_devices()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> RevokeAllDevicesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py) ---
            // def _revoke_all_devices(self):
            // self.totp_trusted_device_ids._remove()
            */
            return default;
        }

        protected async Task<ResUsers> RpcApiKeysOnlyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py) ---
            // def _rpc_api_keys_only(self):
            // # 2FA enabled means we can't allow password-based RPC
            // self.ensure_one()
            // return self.totp_enabled or super()._rpc_api_keys_only()
            --- ODOO METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py) ---
            // def _rpc_api_keys_only(self):
            // return self._mfa_type() == 'totp_mail' or super()._rpc_api_keys_only()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _rpc_api_keys_only(self):
            // """ To be overridden if RPC access needs to be restricted to API keys, e.g. for 2FA """
            // return False
            */
            return default;
        }

        public async Task<ResUsers> SELFREADABLEFIELDSAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_oauth, FILE: res_users.py) ---
            // def SELF_READABLE_FIELDS(self):
            // return super().SELF_READABLE_FIELDS + ['has_oauth_access_token']
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: res_users.py) ---
            // def SELF_READABLE_FIELDS(self):
            // return super().SELF_READABLE_FIELDS + ['auth_passkey_key_ids']
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py) ---
            // def SELF_READABLE_FIELDS(self):
            // return super().SELF_READABLE_FIELDS + ['totp_enabled', 'totp_trusted_device_ids']
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_users.py) ---
            // def SELF_READABLE_FIELDS(self):
            // return super().SELF_READABLE_FIELDS + ['calendar_default_privacy']
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def SELF_READABLE_FIELDS(self):
            // return super().SELF_READABLE_FIELDS + HR_READABLE_FIELDS + HR_WRITABLE_FIELDS
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: res_users.py) ---
            // def SELF_READABLE_FIELDS(self):
            // return super().SELF_READABLE_FIELDS + [
            //     'leave_date_to',
            // ]
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking, FILE: res_users.py) ---
            // def SELF_READABLE_FIELDS(self):
            // return super().SELF_READABLE_FIELDS + DAYS
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py) ---
            // def SELF_READABLE_FIELDS(self):
            // return super().SELF_READABLE_FIELDS + [
            //     "has_access_livechat",
            //     "livechat_expertise_ids",
            //     "livechat_lang_ids",
            //     "livechat_username",
            // ]
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def SELF_READABLE_FIELDS(self):
            // return super().SELF_READABLE_FIELDS + [
            //     "can_edit_role",
            //     "is_out_of_office",
            //     "notification_type",
            //     "out_of_office_from",
            //     "out_of_office_message",
            //     "out_of_office_to",
            //     "role_ids",
            //     "has_external_mail_server",
            //     "outgoing_mail_server_id",
            //     "outgoing_mail_server_type",
            // ]
            --- ODOO METHOD SOURCE (MODULE: mail_bot, FILE: res_users.py) ---
            // def SELF_READABLE_FIELDS(self):
            // return super().SELF_READABLE_FIELDS + ['odoobot_state']
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: res_users.py) ---
            // def SELF_READABLE_FIELDS(self):
            // return super().SELF_READABLE_FIELDS + ['property_warehouse_id']
            --- ODOO METHOD SOURCE (MODULE: website_profile, FILE: res_users.py) ---
            // def SELF_READABLE_FIELDS(self):
            // return super().SELF_READABLE_FIELDS + ['karma']
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def SELF_READABLE_FIELDS(self):
            // """ The list of fields a user can read on their own user record.
            // In order to add fields, please override this property on model extensions.
            // """
            // return [
            //     'signature', 'company_id', 'login', 'email', 'name', 'image_1920',
            //     'image_1024', 'image_512', 'image_256', 'image_128', 'lang', 'tz',
            //     'tz_offset', 'group_ids', 'partner_id', 'write_date', 'action_id',
            //     'avatar_1920', 'avatar_1024', 'avatar_512', 'avatar_256', 'avatar_128',
            //     'share', 'device_ids', 'api_key_ids', 'phone', 'display_name',
            // ]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> SELFWRITEABLEFIELDSAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_users.py) ---
            // def SELF_WRITEABLE_FIELDS(self):
            // return super().SELF_WRITEABLE_FIELDS + ['calendar_default_privacy']
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def SELF_WRITEABLE_FIELDS(self):
            // return super().SELF_WRITEABLE_FIELDS + HR_WRITABLE_FIELDS
            --- ODOO METHOD SOURCE (MODULE: hr_homeworking, FILE: res_users.py) ---
            // def SELF_WRITEABLE_FIELDS(self):
            // return super().SELF_WRITEABLE_FIELDS + DAYS
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py) ---
            // def SELF_WRITEABLE_FIELDS(self):
            // return super().SELF_WRITEABLE_FIELDS + [
            //     "livechat_expertise_ids",
            //     "livechat_lang_ids",
            //     "livechat_username",
            // ]
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def SELF_WRITEABLE_FIELDS(self):
            // return super().SELF_WRITEABLE_FIELDS + [
            //     "notification_type",
            //     "out_of_office_from",
            //     "out_of_office_message",
            //     "out_of_office_to",
            // ]
            --- ODOO METHOD SOURCE (MODULE: sale_stock, FILE: res_users.py) ---
            // def SELF_WRITEABLE_FIELDS(self):
            // return super().SELF_WRITEABLE_FIELDS + ['property_warehouse_id']
            --- ODOO METHOD SOURCE (MODULE: website_profile, FILE: res_users.py) ---
            // def SELF_WRITEABLE_FIELDS(self):
            // return super().SELF_WRITEABLE_FIELDS + [
            //     'country_id', 'city', 'website', 'website_description', 'website_published',
            // ]
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def SELF_WRITEABLE_FIELDS(self):
            // """ The list of fields a user can write on their own user record.
            // In order to add fields, please override this property on model extensions.
            // """
            // return ['signature', 'action_id', 'company_id', 'email', 'name', 'image_1920', 'lang', 'tz', 'api_key_ids', 'phone']
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> SearchAllGroupIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _search_all_group_ids(self, operator, value):
            // return [('group_ids.all_implied_ids', operator, value)]
            */
            return default;
        }

        protected async Task<ResUsers> SearchCompanyEmployeeInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def _search_company_employee(self, operator, value):
            // # Equivalent to `[('employee_ids', operator, value)]`,
            // # but we inline the ids directly to simplify final queries and improve performance,
            // # as it's part of a few ir.rules.
            // # If we're going to inject too many `ids`, we fall back on the default behavior
            // # to avoid a performance regression.
            // IN_MAX = 10_000
            // domain = Domain('employee_ids', operator, value)
            // user_ids = self.env['res.users'].with_context(active_test=False)._search(domain, limit=IN_MAX).get_result_ids()
            // if len(user_ids) < IN_MAX:
            //     return Domain('id', 'in', user_ids)
            // 
            // return domain
            */
            return default;
        }

        protected async Task<ResUsers> SearchCrmTeamIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: res_users.py) ---
            // def _search_crm_team_ids(self, operator, value):
            // # Equivalent to `[('crm_team_member_ids.crm_team_id', operator, value)]`,
            // # but we inline the ids directly to simplify final queries and improve performance,
            // # as it's part of a few ir.rules.
            // # If we're going to inject too many `ids`, we fall back on the default behavior
            // # to avoid a performance regression.
            // IN_MAX = 10_000
            // domain = [('crm_team_member_ids.crm_team_id', operator, value)]
            // user_ids = self.env['res.users'].with_context(active_test=False)._search(domain, limit=IN_MAX).get_result_ids()
            // if len(user_ids) < IN_MAX:
            //     return [('id', 'in', user_ids)]
            // 
            // return domain
            */
            return default;
        }

        protected async Task<ResUsers> SearchDisplayNameInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _search_display_name(self, operator, value):
            // domain = super()._search_display_name(operator, value)
            // if operator in ('in', 'ilike') and value:
            //     name_domain = [('login', 'in', [value] if isinstance(value, str) else value)]
            //     # avoid searching both by login and name because they reside in two different tables
            //     # doing so prevents from using indexes and introduces a performance issue
            //     if users := self.search(name_domain):
            //         domain = [('id', 'in', users.ids)]
            // return domain
            */
            return default;
        }

        protected async Task<ResUsers> SearchResUsersSettingsIdInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _search_res_users_settings_id(self, operator, operand):
            // return Domain('res_users_settings_ids', operator, operand)
            */
            return default;
        }

        protected async Task<ResUsers> SearchStateInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py) ---
            // def _search_state(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // if len(value) > 1:
            //     return Domain.TRUE
            // in_log = 'active' in value
            // return Domain('log_ids', '!=' if in_log else '=', False)
            */
            return default;
        }

        protected async Task<ResUsers> SelfAccessibleFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _self_accessible_fields(self) -> tuple[frozenset[str], frozenset[str]]:
            // """Readable and writable fields by portal users."""
            // readable = frozenset(self.SELF_READABLE_FIELDS)
            // writeable = frozenset(self.SELF_WRITEABLE_FIELDS)
            // return readable, writeable
            */
            return default;
        }

        protected async Task<ResUsers> SendProfileValidationEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_profile, FILE: res_users.py) ---
            // def _send_profile_validation_email(self, **kwargs):
            // if not self.email:
            //     return False
            // token = self._generate_profile_token(self.id, self.email)
            // activation_template = self.env.ref('website_profile.validation_email')
            // if activation_template:
            //     params = {
            //         'token': token,
            //         'user_id': self.id,
            //         'email': self.email
            //     }
            //     params.update(kwargs)
            //     token_url = self.get_base_url() + '/profile/validate_email?%s' % urls.url_encode(params)
            //     activation_template.sudo().with_context(token_url=token_url).send_mail(
            //         self.id, force_send=True, raise_exception=True)
            // return True
            */
            return default;
        }

        protected async Task<ResUsers> SendTotpMailCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py) ---
            // def _send_totp_mail_code(self):
            // self.ensure_one()
            // self._totp_rate_limit('send_email')
            // 
            // if not self.email:
            //     raise UserError(_("Cannot send email: user %s has no email address.", self.name))
            // 
            // template = self.env.ref('auth_totp_mail.mail_template_totp_mail_code').sudo()
            // context = {}
            // if request:
            //     device = request.httprequest.user_agent.platform
            //     browser = request.httprequest.user_agent.browser
            //     context.update({
            //         'location': None,
            //         'device': device and device.capitalize() or None,
            //         'browser': browser and browser.capitalize() or None,
            //         'ip': request.httprequest.environ['REMOTE_ADDR'],
            //     })
            //     if request.geoip.city.name:
            //         context['location'] = f"{request.geoip.city.name}, {request.geoip.country_name}"
            // 
            // email_values = {
            //     'email_to': self.email,
            //     'email_cc': False,
            //     'auto_delete': True,
            //     'recipient_ids': [],
            //     'partner_ids': [],
            //     'scheduled_date': False,
            // }
            // template.with_context(**context).send_mail(
            //     self.id, force_send=True, raise_exception=True,
            //     email_values=email_values,
            //     email_layout_xmlid='mail.mail_notification_light'
            // )
            */
            return default;
        }

        public async Task<ResUsers> SendUnregisteredUserReminderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py) ---
            // def send_unregistered_user_reminder(self, *, after_days=5, batch_size=100):
            // email_template = self.env.ref('auth_signup.mail_template_data_unregistered_users', raise_if_not_found=False)
            // if not email_template:
            //     _logger.warning("Template 'auth_signup.mail_template_data_unregistered_users' was not found. Cannot send reminder notifications.")
            //     self.env['ir.cron']._commit_progress(deactivate=True)
            //     return
            // datetime_min = fields.Datetime.today() - relativedelta(days=after_days)
            // datetime_max = datetime_min + relativedelta(days=1)
            // 
            // invited_by_users = self.search_fetch([
            //     ('share', '=', False),
            //     ('create_uid.email', '!=', False),
            //     ('create_date', '>=', datetime_min),
            //     ('create_date', '<', datetime_max),
            //     ('log_ids', '=', False),
            // ], ['name', 'login', 'create_uid']).grouped('create_uid')
            // 
            // # Do not use progress since we have no way of knowing to whom we have
            // # already sent e-mails.
            // 
            // for user, invited_users in invited_by_users.items():
            //     invited_user_emails = [f"{u.name} ({u.login})" for u in invited_users]
            //     template = email_template.with_context(dbname=self.env.cr.dbname, invited_users=invited_user_emails)
            //     template.send_mail(user.id, email_layout_xmlid='mail.mail_notification_light', force_send=False)
            //     if not self.env['ir.cron']._commit_progress(len(invited_users)):
            //         _logger.info("send_unregistered_user_reminder: timeout reached, stopping")
            //         break
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> SessionTokenGetValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _session_token_get_values(self):
            // self.env.cr.execute(SQL(
            //     "SELECT %(select)s FROM %(from)s %(joins)s WHERE %(where)s GROUP BY %(group_by)s",
            //     **self._get_session_token_query_params(),
            // ))
            // if self.env.cr.rowcount != 1:
            //     self.env.registry.clear_cache()
            //     return False
            // data_fields = self.env.cr.fetchone()
            // # create tuple with column name and value, allowing for overrides to manipulate the values
            // cr_description = self.env.cr.description
            // return tuple((column.name, data_fields[index]) for index, column in enumerate(cr_description))
            */
            return default;
        }

        protected async Task<ResUsers> SessionTokenHashComputeInternalAsync(object sid, object field_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _session_token_hash_compute(self, sid, field_values):
            // if not field_values:
            //     return False
            // # Generate hmac key using the column name and its value, only if the value is not None
            // # To avoid invalidating sessions when installing a new feature modifying the session token computation
            // # while not still being used.
            // key_tuple = tuple((k, v) for k, v in field_values if v is not None)
            // # encode the key tuple to a bytestring
            // key = str(key_tuple).encode()
            // # hmac the session id
            // data = sid.encode()
            // h = hmac.new(key, data, sha256)
            // # return the session token with a prefix version
            // return h.hexdigest()
            */
            return default;
        }

        protected async Task<ResUsers> SetEmptyPasswordInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_ldap, FILE: res_users.py) ---
            // def _set_empty_password(self):
            // self.flush_recordset(['password'])
            // self.env.cr.execute(
            //     'UPDATE res_users SET password=NULL WHERE id=%s',
            //     (self.id,)
            // )
            // self.invalidate_recordset(['password'])
            */
            return default;
        }

        protected async Task<ResUsers> SetEncryptedPasswordInternalAsync(object uid, object pw)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _set_encrypted_password(self, uid, pw):
            // assert self._crypt_context().identify(pw) != 'plaintext'
            // 
            // self.env.cr.execute(
            //     'UPDATE res_users SET password=%s WHERE id=%s',
            //     (pw, uid)
            // )
            // self.browse(uid).invalidate_recordset(['password'])
            */
            return default;
        }

        protected async Task<ResUsers> SetICPFirstSynchronizationDateInternalAsync(object now)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py) ---
            // def _set_ICP_first_synchronization_date(self, now):
            // """
            // Set the first synchronization date as an ICP parameter when applicable (param not defined yet
            // and calendar never synchronized before). This parameter is used for not synchronizing previously
            // created Odoo events and thus avoid spamming invitations for those events.
            // """
            // ICP = self.env['ir.config_parameter'].sudo()
            // first_synchronization_date = ICP.get_param('microsoft_calendar.sync.first_synchronization_date')
            // 
            // if not first_synchronization_date:
            //     # Check if any calendar has synchronized before by checking the user's tokens.
            //     any_calendar_synchronized = self.env['res.users'].sudo().search_count(
            //         domain=[('microsoft_calendar_sync_token', '!=', False)],
            //         limit=1
            //     )
            // 
            //     # Check if any user synchronized its calendar before by saving the date token.
            //     # Add one minute of time diff for avoiding write time delay conflicts with the next sync methods.
            //     if not any_calendar_synchronized:
            //         ICP.set_param('microsoft_calendar.sync.first_synchronization_date', now - timedelta(minutes=1))
            */
            return default;
        }

        protected async Task<ResUsers> SetMicrosoftAuthTokensInternalAsync(object access_token, object refresh_token, object ttl)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_account, FILE: res_users.py) ---
            // def _set_microsoft_auth_tokens(self, access_token, refresh_token, ttl):
            // self.write({
            //     'microsoft_calendar_rtoken': refresh_token,
            //     'microsoft_calendar_token': access_token,
            //     'microsoft_calendar_token_validity': fields.Datetime.now() + timedelta(seconds=ttl) if ttl else False,
            // })
            */
            return default;
        }

        protected async Task<ResUsers> SetNewPasswordInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _set_new_password(self):
            // for user in self:
            //     if not user.new_password:
            //         # Do not update the password if no value is provided, ignore silently.
            //         # For example web client submits False values for all empty fields.
            //         continue
            //     if user == self.env.user:
            //         # To change their own password, users must use the client-specific change password wizard,
            //         # so that the new password is immediately used for further RPC requests, otherwise the user
            //         # will face unexpected 'Access Denied' exceptions.
            //         raise UserError(_('Please use the change password wizard (in User Preferences or User menu) to change your own password.'))
            //     else:
            //         user.password = user.new_password
            */
            return default;
        }

        protected async Task<ResUsers> SetPasswordInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_password_policy, FILE: res_users.py) ---
            // def _set_password(self):
            // self._check_password_policy(self.mapped('password'))
            // 
            // super(ResUsers, self)._set_password()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _set_password(self):
            // ctx = self._crypt_context()
            // for user in self:
            //     self._set_encrypted_password(user.id, ctx.hash(user.password))
            */
            return default;
        }

        public async Task<ResUsers> SetupOutgoingMailServerAsync(Guid id, ResUsersSetupOutgoingMailServerRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def action_setup_outgoing_mail_server(self, server_type):
            // """Configure the outgoing mail servers."""
            // user = self.env.user
            // if not user.has_external_mail_server:
            //     raise UserError(_('You are not allowed to create a personal mail server.'))
            // 
            // if not user._is_internal():
            //     raise UserError(_('Only internal users can configure a personal mail server.'))
            // 
            // existing_mail_server = self.env["ir.mail_server"].sudo() \
            //     .with_context(active_test=False).search([("owner_user_id", "=", user.id)])
            // 
            // if server_type == 'default':
            //     # Use the default server
            //     if existing_mail_server:
            //         existing_mail_server.unlink()
            // 
            //     return {
            //         "type": "ir.actions.client",
            //         "tag": "display_notification",
            //         "params": {
            //             "message": _("Switching back to the default server."),
            //             "type": "warning",
            //         },
            //     }
            // 
            // email = user.email
            // if not email:
            //     raise UserError(_("Please set your email before connecting your mail server."))
            // 
            // normalized_email = tools.email_normalize(email)
            // if (
            //     not normalized_email
            //     or "@" not in normalized_email
            //     # Be sure it's well parsed by `ir.mail_server`
            //     or self.env["ir.mail_server"]._parse_from_filter(normalized_email)
            //     != [normalized_email]
            // ):
            //     raise UserError(_("Wrong email address %s.", email))
            // 
            // # Check that the user's email is not used by `mail.alias.domain` to avoid leaking the outgoing emails
            // alias_domain = self.env["mail.alias.domain"].sudo().search([])
            // cli_default_from = tools.config.get("email_from")
            // match_from_filter = self.env["ir.mail_server"]._match_from_filter
            // if (
            //     any(match_from_filter(e, normalized_email) for e in alias_domain.mapped("default_from_email"))
            //     or (cli_default_from and match_from_filter(cli_default_from, normalized_email))
            // ):
            //     raise UserError(_("Your email address is used by an alias domain, and so you can not create a mail server for it."))
            // 
            // if (
            //     server_type == user.outgoing_mail_server_type
            //     and user.outgoing_mail_server_id.from_filter == normalized_email
            //     and user.outgoing_mail_server_id.smtp_user == normalized_email
            // ):
            //     # Re-connect the account
            //     return self._get_mail_server_setup_end_action(user.outgoing_mail_server_id)
            // 
            // if existing_mail_server:
            //     existing_mail_server.unlink()
            // 
            // values = {
            //     # Will be un-archived once logged in
            //     # Archived personal server will be deleted in GC CRON
            //     # to clean pending connection that didn't finish
            //     "active": False,
            //     "name": _("%s's outgoing email", user.name),
            //     "smtp_user": normalized_email,
            //     "smtp_pass": False,
            //     "from_filter": normalized_email,
            //     "smtp_port": 587,
            //     "smtp_encryption": "starttls",
            //     "owner_user_id": user.id,
            //     **self._get_mail_server_values(server_type),
            // }
            // smtp_server = self.env["ir.mail_server"].sudo().create(values)
            // return self._get_mail_server_setup_end_action(smtp_server)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> ShouldCaptchaLoginInternalAsync(object credential)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: res_users.py) ---
            // def _should_captcha_login(self, credential):
            // if request and request.env.context.get('skip_captcha_login') is SKIP_CAPTCHA_LOGIN:
            //     return False
            // return credential['type'] == 'password'
            */
            return default;
        }

        public async Task<ResUsers> ShowAccessesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def action_show_accesses(self):
            // self.ensure_one()
            // return {
            //     'name': _('Access Rights'),
            //     'view_mode': 'list,form',
            //     'res_model': 'ir.model.access',
            //     'type': 'ir.actions.act_window',
            //     'context': {'create': False, 'delete': False},
            //     'domain': [('id', 'in', self.all_group_ids.model_access.ids)],
            //     'target': 'current',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> ShowGroupsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def action_show_groups(self):
            // self.ensure_one()
            // return {
            //     'name': _('Groups'),
            //     'view_mode': 'list,form',
            //     'res_model': 'res.groups',
            //     'type': 'ir.actions.act_window',
            //     'context': {'create': False, 'delete': False},
            //     'domain': [('id', 'in', self.all_group_ids.ids)],
            //     'target': 'current',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> ShowRulesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def action_show_rules(self):
            // self.ensure_one()
            // return {
            //     'name': _('Record Rules'),
            //     'view_mode': 'list,form',
            //     'res_model': 'ir.rule',
            //     'type': 'ir.actions.act_window',
            //     'context': {'create': False, 'delete': False},
            //     'domain': [('id', 'in', self.all_group_ids.rule_groups.ids)],
            //     'target': 'current',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> SignupAsync(Guid id, ResUsersSignupRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py) ---
            // def signup(self, values, token=None):
            // """ signup a user, to either:
            //     - create a new user (no token), or
            //     - create a user for a partner (with token, but no user for partner), or
            //     - change the password of a user (with token, and existing user).
            //     :param values: a dictionary with field values that are written on user
            //     :param token: signup token (optional)
            //     :return: (dbname, login, password) for the signed up user
            // """
            // if token:
            //     # signup with a token: find the corresponding partner id
            //     partner = self.env['res.partner']._signup_retrieve_partner(token, check_validity=True, raise_exception=True)
            //     # invalidate signup token
            //     partner.write({'signup_type': False})
            //     partner_user = partner.user_ids and partner.user_ids[0] or False
            // 
            //     # avoid overwriting existing (presumably correct) values with geolocation data
            //     if partner.country_id or partner.zip or partner.city:
            //         values.pop('city', None)
            //         values.pop('country_id', None)
            //     if partner.lang:
            //         values.pop('lang', None)
            // 
            //     if partner_user:
            //         # user exists, modify it according to values
            //         values.pop('login', None)
            //         values.pop('name', None)
            //         partner_user.write(values)
            //         if not partner_user.login_date:
            //             partner_user._notify_inviter()
            //         return (partner_user.login, values.get('password'))
            //     else:
            //         # user does not exist: sign up invited user
            //         values.update({
            //             'name': partner.name,
            //             'partner_id': partner.id,
            //             'email': values.get('email') or values.get('login'),
            //         })
            //         if partner.company_id:
            //             values['company_id'] = partner.company_id.id
            //             values['company_ids'] = [(6, 0, [partner.company_id.id])]
            //         partner_user = self._signup_create_user(values)
            //         partner_user._notify_inviter()
            // else:
            //     # no token, sign up an external user
            //     values['email'] = values.get('email') or values.get('login')
            //     self._signup_create_user(values)
            // 
            // return (values.get('login'), values.get('password'))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> SignupCreateUserInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py) ---
            // def _signup_create_user(self, values):
            // """ signup a new user using the template user """
            // 
            // # check that uninvited users may sign up
            // if 'partner_id' not in values:
            //     if self._get_signup_invitation_scope() != 'b2c':
            //         raise SignupError(_('Signup is not allowed for uninvited users'))
            // return self._create_user_from_template(values)
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_users.py) ---
            // def _signup_create_user(self, values):
            // current_website = self.env['website'].get_current_website()
            // # Note that for the moment, portal users can connect to all websites of
            // # all companies as long as the specific_user_account setting is not
            // # activated.
            // values['company_id'] = current_website.company_id.id
            // values['company_ids'] = [Command.link(current_website.company_id.id)]
            // if request and current_website.specific_user_account:
            //     values['website_id'] = current_website.id
            // new_user = super(ResUsers, self)._signup_create_user(values)
            // return new_user
            */
            return default;
        }

        public async Task<ResUsers> StopGoogleSynchronizationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py) ---
            // def stop_google_synchronization(self):
            // self.ensure_one()
            // self.sudo().google_synchronization_stopped = True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> StopMicrosoftSynchronizationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py) ---
            // def stop_microsoft_synchronization(self):
            // self.ensure_one()
            // self.sudo().microsoft_synchronization_stopped = True
            // self.sudo().microsoft_last_sync_date = None
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> SwitchTourEnabledAsync(Guid id, ResUsersSwitchTourEnabledRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_tour, FILE: res_users.py) ---
            // def switch_tour_enabled(self, val):
            // self.env.user.sudo().tour_enabled = val
            // return self.env.user.tour_enabled
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> SyncAllGoogleCalendarInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py) ---
            // def _sync_all_google_calendar(self):
            // """ Cron job """
            // users = self.env['res.users'].sudo().search([('google_calendar_rtoken', '!=', False), ('google_synchronization_stopped', '=', False)])
            // google = GoogleCalendarService(self.env['google.service'])
            // for user in users:
            //     _logger.info("Calendar Synchro - Starting synchronization for %s", user)
            //     try:
            //         user.with_user(user).sudo()._sync_google_calendar(google)
            //         self.env.cr.commit()
            //     except Exception as e:
            //         _logger.exception("[%s] Calendar Synchro - Exception : %s!", user, exception_to_unicode(e))
            //         self.env.cr.rollback()
            */
            return default;
        }

        protected async Task<ResUsers> SyncAllMicrosoftCalendarInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py) ---
            // def _sync_all_microsoft_calendar(self):
            // """ Cron job """
            // users = self.env['res.users'].sudo().search([('microsoft_calendar_rtoken', '!=', False), ('microsoft_synchronization_stopped', '=', False)])
            // for user in users:
            //     _logger.info("Calendar Synchro - Starting synchronization for %s", user)
            //     try:
            //         user.with_user(user).sudo()._sync_microsoft_calendar()
            //         self.env.cr.commit()
            //     except Exception as e:
            //         _logger.exception("[%s] Calendar Synchro - Exception : %s!", user, exception_to_unicode(e))
            //         self.env.cr.rollback()
            */
            return default;
        }

        protected async Task<ResUsers> SyncGoogleCalendarInternalAsync(object calendar_service)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py) ---
            // def _sync_google_calendar(self, calendar_service: GoogleCalendarService):
            // self.ensure_one()
            // results = self._sync_request(calendar_service)
            // if not results or (not results.get('events') and not self._check_pending_odoo_records()):
            //     return False
            // events, default_reminders, full_sync = results.values()
            // # Google -> Odoo
            // send_updates = not full_sync
            // events.clear_type_ambiguity(self.env)
            // recurrences = events.filter(lambda e: e.is_recurrence())
            // 
            // # We apply Google updates only if their write date is later than the write date in Odoo.
            // # It's possible that multiple updates affect the same record, maybe not directly.
            // # To handle this, we preserve the write dates in Odoo before applying any updates,
            // # and use these dates instead of the current live dates.
            // odoo_events = self.env['calendar.event'].browse((events - recurrences).odoo_ids(self.env))
            // odoo_recurrences = self.env['calendar.recurrence'].browse(recurrences.odoo_ids(self.env))
            // recurrences_write_dates = {r.id: r.write_date for r in odoo_recurrences}
            // events_write_dates = {e.id: e.write_date for e in odoo_events}
            // synced_recurrences = self.env['calendar.recurrence']._sync_google2odoo(recurrences, recurrences_write_dates)
            // synced_events = self.env['calendar.event']._sync_google2odoo(events - recurrences, events_write_dates, default_reminders=default_reminders)
            // 
            // # Odoo -> Google
            // recurrences = self.env['calendar.recurrence']._get_records_to_sync(full_sync=full_sync)
            // recurrences -= synced_recurrences
            // recurrences.with_context(send_updates=send_updates)._sync_odoo2google(calendar_service)
            // synced_events |= recurrences.calendar_event_ids - recurrences._get_outliers()
            // synced_events |= synced_recurrences.calendar_event_ids - synced_recurrences._get_outliers()
            // events = self.env['calendar.event']._get_records_to_sync(full_sync=full_sync)
            // (events - synced_events).with_context(send_updates=send_updates)._sync_odoo2google(calendar_service)
            // 
            // return bool(results) and (bool(events | synced_events) or bool(recurrences | synced_recurrences))
            */
            return default;
        }

        protected async Task<ResUsers> SyncMicrosoftCalendarInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py) ---
            // def _sync_microsoft_calendar(self):
            // self.ensure_one()
            // self.sudo().microsoft_last_sync_date = datetime.now()
            // if self._get_microsoft_sync_status() != "sync_active":
            //     return False
            // 
            // # Set the first synchronization date as an ICP parameter before writing the variable
            // # 'microsoft_calendar_sync_token' below, so we identify the first synchronization.
            // self._set_ICP_first_synchronization_date(fields.Datetime.now())
            // 
            // calendar_service = self.env["calendar.event"]._get_microsoft_service()
            // full_sync = not bool(self.sudo().microsoft_calendar_sync_token)
            // with microsoft_calendar_token(self) as token:
            //     try:
            //         events, next_sync_token = calendar_service.get_events(self.sudo().microsoft_calendar_sync_token, token=token)
            //     except InvalidSyncToken:
            //         events, next_sync_token = calendar_service.get_events(token=token)
            //         full_sync = True
            // self.res_users_settings_id.sudo().microsoft_calendar_sync_token = next_sync_token
            // 
            // # Microsoft -> Odoo
            // synced_events, synced_recurrences = self.env['calendar.event']._sync_microsoft2odoo(events) if events else (self.env['calendar.event'], self.env['calendar.recurrence'])
            // 
            // # Odoo -> Microsoft
            // recurrences = self.env['calendar.recurrence']._get_microsoft_records_to_sync(full_sync=full_sync)
            // recurrences -= synced_recurrences
            // recurrences._sync_odoo2microsoft()
            // synced_events |= recurrences.calendar_event_ids
            // 
            // events = self.env['calendar.event']._get_microsoft_records_to_sync(full_sync=full_sync)
            // (events - synced_events)._sync_odoo2microsoft()
            // self.sudo().microsoft_last_sync_date = datetime.now()
            // 
            // return bool(events | synced_events) or bool(recurrences | synced_recurrences)
            */
            return default;
        }

        protected async Task<ResUsers> SyncRequestInternalAsync(object calendar_service, Guid event_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py) ---
            // def _sync_request(self, calendar_service, event_id=None):
            // if self._get_google_sync_status() != "sync_active":
            //     return False
            // # don't attempt to sync when another sync is already in progress, as we wouldn't be
            // # able to commit the transaction anyway (row is locked)
            // self.ensure_one()
            // try:
            //     self.lock_for_update(allow_referencing=True)
            // except LockError:
            //     _logger.info("skipping calendar sync, locked user %s", self.login)
            //     return False
            // 
            // full_sync = not bool(self.sudo().google_calendar_sync_token)
            // with google_calendar_token(self) as token:
            //     try:
            //         if not event_id:
            //             events, next_sync_token, default_reminders = calendar_service.get_events(self.res_users_settings_id.sudo().google_calendar_sync_token, token=token)
            //         else:
            //             # We force the sync_token parameter to avoid doing a full sync.
            //             # Other events are fetched when the calendar view is displayed.
            //             events, next_sync_token, default_reminders = calendar_service.get_events(sync_token=token, token=token, event_id=event_id)
            //     except InvalidSyncToken:
            //         events, next_sync_token, default_reminders = calendar_service.get_events(token=token)
            //         full_sync = True
            // if next_sync_token:
            //     self.res_users_settings_id.sudo().google_calendar_sync_token = next_sync_token
            // return {
            //     'events': events,
            //     'default_reminders': default_reminders,
            //     'full_sync': full_sync,
            // }
            */
            return default;
        }

        protected async Task<ResUsers> SyncSingleEventInternalAsync(object calendar_service, object odoo_event, Guid event_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py) ---
            // def _sync_single_event(self, calendar_service: GoogleCalendarService, odoo_event, event_id):
            // self.ensure_one()
            // results = self._sync_request(calendar_service, event_id)
            // if not results or not results.get('events'):
            //     return False
            // event, default_reminders, full_sync = results.values()
            // # Google -> Odoo
            // send_updates = not full_sync
            // event.clear_type_ambiguity(self.env)
            // synced_events = self.env['calendar.event']._sync_google2odoo(event, default_reminders=default_reminders)
            // # Odoo -> Google
            // odoo_event.with_context(send_updates=send_updates)._sync_odoo2google(calendar_service)
            // return bool(odoo_event | synced_events)
            */
            return default;
        }

        protected async Task<ResUsers> SystrayGetCalendarEventDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_users.py) ---
            // def _systray_get_calendar_event_domain(self):
            // # Determine the domain for which the users should be notified. This method sends notification to
            // # events occurring between now and the end of the day. Note that "now" needs to be computed in the
            // # user TZ and converted into UTC to compare with the records values and "the end of the day" needs
            // # also conversion. Otherwise TZ diverting a lot from UTC would send notification for events occurring
            // # tomorrow.
            // # The user is notified if the start is occurring between now and the end of the day
            // # if the event is not finished.
            // #   |           |
            // #   |===========|===> DAY A (`start_dt`): now in the user TZ
            // #   |           |
            // #   |           | <--- `start_dt_utc`: now is on the right if the user lives
            // #   |           |               in West Longitude (America for example)
            // #   |           |
            // #   |  -------  | <--- `start`: the start of the event (in UTC)
            // #   | | event | |
            // #   |  -------  | <--- `stop`: the stop of the event (in UTC)
            // #   |           |
            // #   |           |
            // #   |           | <--- `stop_dt_utc` = `stop_dt` if user lives in an area of East longitude (positive shift compared to UTC, Belgium for example)
            // #   |           |
            // #   |           |
            // #   |-----------| <--- `stop_dt` = end of the day for DAY A from user point of view (23:59 in this TZ)
            // #   |===========|===> DAY B
            // #   |           |
            // #   |           | <--- `stop_dt_utc` = `stop_dt` if user lives in an area of West longitude (positive shift compared to UTC, America for example)
            // #   |           |
            // start_dt_utc = start_dt = datetime.datetime.now(UTC)
            // stop_dt_utc = UTC.localize(datetime.datetime.combine(start_dt_utc.date(), datetime.time.max))
            // 
            // tz = self.env.user.tz
            // if tz:
            //     user_tz = timezone(tz)
            //     start_dt = start_dt_utc.astimezone(user_tz)
            //     stop_dt = user_tz.localize(datetime.datetime.combine(start_dt.date(), datetime.time.max))
            //     stop_dt_utc = stop_dt.astimezone(UTC)
            // 
            // start_date = start_dt.date()
            // 
            // current_user_non_declined_attendee_ids = self.env['calendar.attendee']._search([
            //     ('partner_id', '=', self.env.user.partner_id.id),
            //     ('state', '!=', 'declined'),
            // ])
            // 
            // return ['&', '|',
            //         '&',
            //             '|',
            //                 ['start', '>=', fields.Datetime.to_string(start_dt_utc)],
            //                 ['stop', '>=', fields.Datetime.to_string(start_dt_utc)],
            //             ['start', '<=', fields.Datetime.to_string(stop_dt_utc)],
            //         '&',
            //             ['allday', '=', True],
            //             ['start_date', '=', fields.Date.to_string(start_date)],
            //         ('attendee_ids', 'in', current_user_non_declined_attendee_ids)]
            */
            return default;
        }

        public async Task<ResUsers> TestOutgoingMailServerAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def action_test_outgoing_mail_server(self):
            // user = self.env.user
            // if not user.has_external_mail_server:
            //     raise UserError(_('You are not allowed to test personal mail servers.'))
            // 
            // if not user.has_group('base.group_user'):
            //     raise UserError(_('Only internal users can configure personal mail servers.'))
            // 
            // server_sudo = user.outgoing_mail_server_id.sudo()
            // if not server_sudo:
            //     raise UserError(_('No mail server configured'))
            // server_sudo.test_smtp_connection()
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'message': _('Connection Test Successful!'),
            //         'type': 'success',
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> TotpDisableAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py) ---
            // def action_totp_disable(self):
            // logins = ', '.join(map(repr, self.mapped('login')))
            // if not (self == self.env.user or self.env.user._is_admin() or self.env.su):
            //     _logger.info("2FA disable: REJECT for %s (%s) by uid #%s", self, logins, self.env.user.id)
            //     return False
            // 
            // self.revoke_all_devices()
            // self.sudo().write({'totp_secret': False})
            // 
            // if request and self == self.env.user:
            //     self.env.flush_all()
            //     # update session token so the user does not get logged out (cache cleared by change)
            //     new_token = self.env.user._compute_session_token(request.session.sid)
            //     request.session.session_token = new_token
            // 
            // _logger.info("2FA disable: SUCCESS for %s (%s) by uid #%s", self, logins, self.env.user.id)
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'warning',
            //         'message': _("Two-factor authentication disabled for the following user(s): %s", ', '.join(self.mapped('name'))),
            //         'next': {'type': 'ir.actions.act_window_close'},
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> TotpEnableSearchInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py) ---
            // def _totp_enable_search(self, operator, value):
            // value = not value if operator == '!=' else value
            // if value:
            //     self.env.cr.execute("SELECT id FROM res_users WHERE totp_secret IS NOT NULL")
            // else:
            //     self.env.cr.execute("SELECT id FROM res_users WHERE totp_secret IS NULL OR totp_secret='false'")
            // result = self.env.cr.fetchall()
            // return [('id', 'in', [x[0] for x in result])]
            */
            return default;
        }

        public async Task<ResUsers> TotpEnableWizardAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py) ---
            // def action_totp_enable_wizard(self):
            // if self.env.user != self:
            //     raise UserError(_("Two-factor authentication can only be enabled for yourself"))
            // 
            // if self.totp_enabled:
            //     raise UserError(_("Two-factor authentication already enabled"))
            // 
            // secret_bytes_count = TOTP_SECRET_SIZE // 8
            // secret = base64.b32encode(os.urandom(secret_bytes_count)).decode()
            // # format secret in groups of 4 characters for readability
            // secret = ' '.join(map(''.join, zip(*[iter(secret)]*4)))
            // w = self.env['auth_totp.wizard'].create({
            //     'user_id': self.id,
            //     'secret': secret,
            // })
            // return {
            //     'type': 'ir.actions.act_window',
            //     'target': 'new',
            //     'res_model': 'auth_totp.wizard',
            //     'name': _("Two-Factor Authentication Activation"),
            //     'res_id': w.id,
            //     'views': [(False, 'form')],
            //     'context': self.env.context | {'dialog_size': 'medium'},
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> TotpInviteAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py) ---
            // def action_totp_invite(self):
            // invite_template = self.env.ref('auth_totp_mail.mail_template_totp_invite')
            // users_to_invite = self.sudo().filtered(lambda user: not user.totp_secret)
            // for user in users_to_invite:
            //     email_values = {
            //         'email_from': self.env.user.email_formatted,
            //         'author_id': self.env.user.partner_id.id,
            //     }
            //     invite_template.send_mail(user.id, force_send=True, email_values=email_values,
            //                               email_layout_xmlid='mail.mail_notification_light')
            // 
            // # Display a confirmation toaster
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'info',
            //         'sticky': False,
            //         'message': _("Invitation to use two-factor authentication sent for the following user(s): %s",
            //                      ', '.join(users_to_invite.mapped('name'))),
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> TotpRateLimitInternalAsync(object limit_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py) ---
            // def _totp_rate_limit(self, limit_type):
            // self.ensure_one()
            // assert request, "A request is required to be able to rate limit TOTP related actions"
            // limit, interval = TOTP_RATE_LIMITS[limit_type]
            // RateLimitLog = self.env['auth.totp.rate.limit.log'].sudo()
            // ip = request.httprequest.environ['REMOTE_ADDR']
            // domain = [
            //     ('user_id', '=', self.id),
            //     ('create_date', '>=', datetime.now() - timedelta(seconds=interval)),
            //     ('limit_type', '=', limit_type),
            // ]
            // count = RateLimitLog.search_count(domain)
            // if count >= limit:
            //     descriptions = {
            //         'send_email': _('You reached the limit of authentication mails sent for your account, please try again later.'),
            //         'code_check': _('You reached the limit of code verifications for your account, please try again later.'),
            //     }
            //     description = descriptions[limit_type]
            //     raise AccessDenied(description)
            // RateLimitLog.create({
            //     'user_id': self.id,
            //     'ip': ip,
            //     'limit_type': limit_type,
            // })
            */
            return default;
        }

        protected async Task<ResUsers> TotpRateLimitPurgeInternalAsync(object limit_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py) ---
            // def _totp_rate_limit_purge(self, limit_type):
            // self.ensure_one()
            // assert request, "A request is required to be able to rate limit TOTP related actions"
            // RateLimitLog = self.env['auth.totp.rate.limit.log'].sudo()
            // RateLimitLog.search([
            //     ('user_id', '=', self.id),
            //     ('limit_type', '=', limit_type),
            // ]).unlink()
            */
            return default;
        }

        protected async Task<ResUsers> TotpTrySettingInternalAsync(object secret, object code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp, FILE: res_users.py) ---
            // def _totp_try_setting(self, secret, code):
            // if self.totp_enabled or self != self.env.user:
            //     _logger.info("2FA enable: REJECT for %s %r", self, self.login)
            //     return False
            // 
            // secret = compress(secret).upper()
            // match = TOTP(base64.b32decode(secret)).match(code)
            // if match is None:
            //     _logger.info("2FA enable: REJECT CODE for %s %r", self, self.login)
            //     return False
            // 
            // self.sudo().totp_secret = secret
            // self.sudo().totp_last_counter = match
            // if request:
            //     self.env.flush_all()
            //     # update session token so the user does not get logged out (cache cleared by change)
            //     new_token = self.env.user._compute_session_token(request.session.sid)
            //     request.session.session_token = new_token
            // 
            // _logger.info("2FA enable: SUCCESS for %s %r", self, self.login)
            // return True
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def unlink(self):
            // self._unsubscribe_from_non_public_channels()
            // return super().unlink()
            */
            return await base.UnlinkAsync(ids);
        }

        protected async Task<ResUsers> UnlinkExceptMasterDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _unlink_except_master_data(self):
            // portal_user_template = self.env.ref('base.template_portal_user_id', False)
            // public_user = self.env.ref('base.public_user', False)
            // if SUPERUSER_ID in self.ids:
            //     raise UserError(_('You can not remove the admin user as it is used internally for resources created by Odoo (updates, module installation, ...)'))
            // user_admin = self.env.ref('base.user_admin', raise_if_not_found=False)
            // if user_admin and user_admin in self:
            //     raise UserError(_('You cannot delete the admin user because it is utilized in various places (such as security configurations,...). Instead, archive it.'))
            // self.env.registry.clear_cache()
            // if portal_user_template and portal_user_template in self:
            //     raise UserError(_('Deleting the template users is not allowed. Deleting this profile will compromise critical functionalities.'))
            // if public_user and public_user in self:
            //     raise UserError(_("Deleting the public user is not allowed. Deleting this profile will compromise critical functionalities."))
            */
            return default;
        }

        public async Task<ResUsers> UnpauseGoogleSynchronizationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_calendar, FILE: res_users.py) ---
            // def unpause_google_synchronization(self):
            // self.env['ir.config_parameter'].sudo().set_param("google_calendar_sync_paused", False)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> UnpauseMicrosoftSynchronizationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_calendar, FILE: res_users.py) ---
            // def unpause_microsoft_synchronization(self):
            // self.env['ir.config_parameter'].sudo().set_param("microsoft_calendar_sync_paused", False)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResUsers> UnsubscribeFromNonPublicChannelsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def _unsubscribe_from_non_public_channels(self):
            // """This method un-subscribes users from group restricted channels. Main purpose
            // of this method is to prevent sending internal communication to archived / deleted users.
            // """
            // domain = [("partner_id", "in", self.partner_id.ids)]
            // # sudo: discuss.channel.member - removing member of other users based on channel restrictions
            // current_cm = self.env["discuss.channel.member"].sudo().search(domain)
            // current_cm.filtered(
            //     lambda cm: (cm.channel_id.channel_type == "channel" and cm.channel_id.group_public_id)
            // ).unlink()
            */
            return default;
        }

        protected async Task<ResUsers> UpdateLastLoginInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _update_last_login(self):
            // # only create new records to avoid any side-effect on concurrent transactions
            // # extra records will be deleted by the periodical garbage collection
            // self.env['res.users.log'].sudo().create({})
            */
            return default;
        }

        public async Task<ResUsers> WebCreateUsersAsync(Guid id, ResUsersWebCreateUsersRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py) ---
            // def web_create_users(self, emails):
            // inactive_users = self.search([('state', '=', 'new'), '|', ('login', 'in', emails), ('email', 'in', emails)])
            // new_emails = set(emails) - set(inactive_users.mapped('email'))
            // res = super(ResUsers, self).web_create_users(list(new_emails))
            // if inactive_users:
            //     inactive_users.with_context(create_user=True).action_reset_password()
            // return res
            --- ODOO METHOD SOURCE (MODULE: base_setup, FILE: res_users.py) ---
            // def web_create_users(self, emails):
            // emails_normalized = [tools.mail.parse_contact_from_email(email)[1] for email in emails]
            // 
            // if 'email_normalized' not in self._fields:
            //     raise UserError(self.env._("You have to install the Discuss application to use this feature."))
            // 
            // # Reactivate already existing users if needed
            // deactivated_users = self.with_context(active_test=False).search([
            //     ('active', '=', False),
            //     '|', ('login', 'in', emails + emails_normalized), ('email_normalized', 'in', emails_normalized)])
            // for user in deactivated_users:
            //     user.active = True
            // done = deactivated_users.mapped('email_normalized')
            // 
            // new_emails = set(emails) - set(deactivated_users.mapped('email'))
            // 
            // # Process new email addresses : create new users
            // for email in new_emails:
            //     name, email_normalized = tools.mail.parse_contact_from_email(email)
            //     if email_normalized in done:
            //         continue
            //     default_values = {'login': email_normalized, 'name': name or email_normalized, 'email': email_normalized, 'active': True}
            //     user = self.with_context(signup_valid=True).create(default_values)
            // 
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsers> WebsitePublishButtonAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_users.py) ---
            // def website_publish_button(self):
            // return self.partner_id.website_publish_button()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, ResUsers entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_signup, FILE: res_users.py) ---
            // def write(self, vals):
            // if 'active' in vals and not vals['active']:
            //     self.partner_id.signup_cancel()
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_users.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // 
            // if 'totp_secret' in vals:
            //     if vals.get('totp_secret'):
            //         self._notify_security_setting_update(
            //             _("Security Update: 2FA Activated"),
            //             _("Two-factor authentication has been activated on your account"),
            //             suggest_2fa=False,
            //         )
            //     else:
            //         self._notify_security_setting_update(
            //             _("Security Update: 2FA Deactivated"),
            //             _("Two-factor authentication has been deactivated on your account"),
            //             suggest_2fa=False,
            //         )
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: calendar, FILE: res_users.py) ---
            // def write(self, vals):
            // """ Forbid the calendar default privacy update from different users for keeping private events secured. """
            // privacy_update = 'calendar_default_privacy' in vals
            // if privacy_update and self != self.env.user:
            //     raise AccessError(_("You are not allowed to change the calendar default privacy of another user due to privacy constraints."))
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: res_users.py) ---
            // def write(self, vals):
            // if 'karma' in vals:
            //     self._add_karma_batch({
            //         user: {
            //             'gain': int(vals['karma']) - user.karma,
            //             'origin_ref': f'res.users,{self.env.uid}',
            //         }
            //         for user in self
            //         if int(vals['karma']) != user.karma
            //     })
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: res_users.py) ---
            // def write(self, vals):
            // """
            // Synchronize user and its related employee
            // and check access rights if employees are not allowed to update
            // their own data (otherwise sudo is applied for self data).
            // """
            // hr_fields = {
            //     field_name: field
            //     for field_name, field in self._fields.items()
            //     if field.related_field and field.related_field.model_name == 'hr.employee' and field_name in vals
            // }
            // 
            // employee_domain = [
            //     *self.env['hr.employee']._check_company_domain(self.env.company),
            //     ('user_id', 'in', self.ids),
            // ]
            // if hr_fields:
            //     employees = self.env['hr.employee'].sudo().search(employee_domain)
            //     get_field = self.env['ir.model.fields']._get
            //     field_names = Markup().join([
            //          Markup("<li>%s</li>") % get_field("res.users", fname).field_description for fname in hr_fields
            //     ])
            //     for employee in employees:
            //         reason_message, partner_ids = self._get_personal_info_partner_ids_to_notify(employee)
            //         if partner_ids:
            //             employee.message_notify(
            //                 body=Markup("<p>%s</p><p>%s</p><ul>%s</ul><p><em>%s</em></p>") % (
            //                     _('Personal information update.'),
            //                     _("The following fields were modified by %s", employee.name),
            //                     field_names,
            //                     reason_message,
            //                 ),
            //                 partner_ids=partner_ids,
            //             )
            // result = super().write(vals)
            // 
            // employee_values = {}
            // for fname in [f for f in self._get_employee_fields_to_sync() if f in vals]:
            //     employee_values[fname] = vals[fname]
            // 
            // if employee_values:
            //     if 'email' in employee_values:
            //         employee_values['work_email'] = employee_values.pop('email')
            //     if 'image_1920' in vals:
            //         without_image = self.env['hr.employee'].sudo().search(employee_domain + [('image_1920', '=', False)])
            //         with_image = self.env['hr.employee'].sudo().search(employee_domain + [('image_1920', '!=', False)])
            //         without_image.write(employee_values)
            //         with_image.write(employee_values)
            //     else:
            //         employees = self.env['hr.employee'].sudo().search(employee_domain)
            //         if employees:
            //             employees.write(employee_values)
            // return result
            --- ODOO METHOD SOURCE (MODULE: im_livechat, FILE: res_users.py) ---
            // def write(self, vals):
            // if vals.get("group_ids"):
            //     operator_group = self.env.ref("im_livechat.im_livechat_group_user")
            //     if operator_group in self.all_group_ids:
            //         result = super().write(vals)
            //         lost_operators = self.filtered_domain([("all_group_ids", "not in", operator_group.id)])
            //         # sudo - im_livechat.channel: user manager can remove user from livechat channels
            //         self.env["im_livechat.channel"].sudo() \
            //             .search([("user_ids", "in", lost_operators.ids)]) \
            //             .write({"user_ids": [Command.unlink(operator.id) for operator in lost_operators]})
            //         return result
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // if "active" in vals and not vals["active"]:
            //     self._unsubscribe_from_non_public_channels()
            // if vals.get("group_ids"):
            //     # form: {'group_ids': [(3, 10), (3, 3), (4, 10), (4, 3)]} or {'group_ids': [(6, 0, [ids]}
            //     user_group_ids = [command[1] for command in vals["group_ids"] if command[0] == 4]
            //     user_group_ids += [id for command in vals["group_ids"] if command[0] == 6 for id in command[2]]
            //     user_group_ids += self.env['res.groups'].browse(user_group_ids).all_implied_ids._ids
            //     self.env["discuss.channel"].search([("group_ids", "in", user_group_ids)])._subscribe_users_automatically()
            // return res
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_users.py) ---
            // def write(self, vals):
            // log_portal_access = 'group_ids' in vals and not self.env.context.get('mail_create_nolog') and not self.env.context.get('mail_notrack')
            // user_portal_access_dict = {
            //     user.id: user._is_portal()
            //     for user in self
            // } if log_portal_access else {}
            // 
            // previous_email_by_user = {}
            // if vals.get('email'):
            //     previous_email_by_user = {
            //         user: user.email
            //         for user in self.filtered(lambda user: bool(user.email_normalized))
            //         if user.email_normalized != email_normalize(vals['email'])
            //     }
            // if 'notification_type' in vals:
            //     user_notification_type_modified = self.filtered(lambda user: user.notification_type != vals['notification_type'])
            // 
            // write_res = super().write(vals)
            // 
            // # log a portal status change (manual tracking)
            // if log_portal_access:
            //     for user in self:
            //         user_has_group = user._is_portal()
            //         portal_access_changed = user_has_group != user_portal_access_dict[user.id]
            //         if portal_access_changed:
            //             body = user._get_portal_access_update_body(user_has_group)
            //             user.partner_id.message_post(
            //                 body=body,
            //                 message_type='notification',
            //                 subtype_xmlid='mail.mt_note'
            //             )
            // 
            // if 'login' in vals:
            //     self._notify_security_setting_update(
            //         _("Security Update: Login Changed"),
            //         _("Your account login has been updated"),
            //     )
            // if 'password' in vals:
            //     self._notify_security_setting_update(
            //         _("Security Update: Password Changed"),
            //         _("Your account password has been updated"),
            //     )
            // if 'email' in vals:
            //     # when the email is modified, we want notify the previous address (and not the new one)
            //     for user, previous_email in previous_email_by_user.items():
            //         self._notify_security_setting_update(
            //             _("Security Update: Email Changed"),
            //             _(
            //                 "Your account email has been changed from %(old_email)s to %(new_email)s.",
            //                 old_email=previous_email,
            //                 new_email=user.email,
            //             ),
            //             mail_values={'email_to': previous_email},
            //             suggest_password_reset=False,
            //         )
            // if "notification_type" in vals:
            //     for user in user_notification_type_modified:
            //         Store(bus_channel=user).add(user, "notification_type").bus_send()
            // 
            // return write_res
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: res_users.py) ---
            // def write(self, vals):
            // rslt = super().write(vals)
            // 
            // # If the timezone of the admin user gets set on their first login, also update the timezone of the default working calendar
            // if (vals.get('tz') and len(self) == 1 and not self.env.user.login_date
            //     and self.env.user == self.env.ref('base.user_admin', False) and self == self.env.user):
            //     if self.resource_calendar_id:
            //         self.resource_calendar_id.tz = vals['tz']
            //     else:
            //         self.env.ref('resource.resource_calendar_std', False).tz = vals['tz']
            // 
            // return rslt
            --- ODOO METHOD SOURCE (MODULE: website_slides, FILE: res_users.py) ---
            // def write(self, vals):
            // """ Trigger automatic subscription based on updated user groups """
            // res = super().write(vals)
            // if 'group_ids' in vals:
            //     group_ids = [command[1] for command in vals['group_ids'] if command[0] == Command.LINK]
            //     group_ids += [id_ for command in vals['group_ids'] if command[0] == Command.SET for id_ in command[2]]
            //     added_group_ids = self.env['res.groups'].browse(group_ids).all_implied_ids.ids
            //     self.env['slide.channel'].sudo().search([('enroll_group_ids', 'in', added_group_ids)])._action_add_members(self.mapped('partner_id'))
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def write(self, vals):
            // if vals.get('active') and SUPERUSER_ID in self._ids:
            //     raise UserError(_("You cannot activate the superuser."))
            // if vals.get('active') == False and self.env.uid in self._ids:  # noqa: E712
            //     raise UserError(_("You cannot deactivate the user you're currently logged in as."))
            // 
            // if vals.get('active'):
            //     # unarchive partners before unarchiving the users
            //     self.partner_id.action_unarchive()
            // if self == self.env.user:
            //     writeable = self._self_accessible_fields()[1]
            //     for key in list(vals):
            //         if key not in writeable:
            //             break
            //     else:
            //         if 'company_id' in vals:
            //             if vals['company_id'] not in self.env.user.company_ids.ids:
            //                 del vals['company_id']
            //         # safe fields only, so we write as super-user to bypass access rights
            //         self = self.sudo()
            // 
            // res = super().write(vals)
            // 
            // if 'company_id' in vals:
            //     for user in self:
            //         # if partner is global we keep it that way
            //         if user.partner_id.company_id and user.partner_id.company_id.id != vals['company_id']:
            //             user.partner_id.write({'company_id': user.company_id.id})
            // 
            // if 'company_id' in vals or 'company_ids' in vals:
            //     # Reset lazy properties `company` & `companies` on all envs,
            //     # This is unlikely in a business code to change the company of a user and then do business stuff
            //     # but in case it happens this is handled.
            //     # e.g. `account_test_savepoint.py` `setup_company_data`, triggered by `test_account_invoice_report.py`
            //     for env in list(self.env.transaction.envs):
            //         if env.user in self:
            //             reset_cached_properties(env)
            // 
            // if 'group_ids' in vals and self.ids:
            //     # clear caches linked to the users
            //     self.env['ir.model.access'].call_cache_clearing_methods()
            // 
            // # per-method / per-model caches have been removed so the various
            // # clear_cache/clear_caches methods pretty much just end up calling
            // # Registry.clear_cache
            // invalidation_fields = self._get_invalidation_fields()
            // if invalidation_fields & vals.keys():
            //     self.env.registry.clear_cache()
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // if 'company_ids' not in vals:
            //     return res
            // group_multi_company_id = self.env['ir.model.data']._xmlid_to_res_id(
            //     'base.group_multi_company', raise_if_not_found=False)
            // if group_multi_company_id:
            //     for user in self:
            //         if len(user.company_ids) <= 1 and group_multi_company_id in user.group_ids.ids:
            //             user.write({'group_ids': [Command.unlink(group_multi_company_id)]})
            //         elif len(user.company_ids) > 1 and group_multi_company_id not in user.group_ids.ids:
            //             user.write({'group_ids': [Command.link(group_multi_company_id)]})
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}
