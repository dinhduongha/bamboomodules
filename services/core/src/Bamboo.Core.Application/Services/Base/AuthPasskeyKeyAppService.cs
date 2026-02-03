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
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("AuthPasskey", Category = "Base", Depends = new[] { "base_setup", "web" })]
    public partial class AuthPasskeyKeyAppService : GenericAppService<AuthPasskeyKey>, IAuthPasskeyKeyAppService
    {

        public AuthPasskeyKeyAppService(IRepository<AuthPasskeyKey, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<AuthPasskeyKey> ComputePublicKeyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py) ---
            // def _compute_public_key(self):
            // query = 'SELECT public_key FROM auth_passkey_key WHERE id = %s'
            // for passkey in self:
            //     self.env.cr.execute(SQL(query, passkey.id))
            //     public_key = self.env.cr.fetchone()[0]
            //     passkey.public_key = public_key
            */
            return default;
        }

        public async Task<AuthPasskeyKey> DeletePasskeyAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py) ---
            // def action_delete_passkey(self):
            // for key in self:
            //     if key.create_uid.id == self.env.user.id:
            //         # Force to go through `res.users.auth_passkey_key_ids` to trigger the session token cache invalidation
            //         # See `res.users.write` and `_get_invalidation_fields`
            //         # `self.env.user` is already sudo, so no need to re-apply `sudo` to get delete access right.
            //         self.env.user.write({'auth_passkey_key_ids': [Command.delete(key.id)]})
            //         new_token = self.env.user._compute_session_token(request.session.sid)
            //         request.session.session_token = new_token
            //     else:
            //         _logger.info(
            //             "%s (#%d) attempted to delete passkey (#%d) belonging to %s (#%d) from %s but was denied.",
            //             self.env.user.login, self.env.user.id,
            //             key.id,
            //             key.create_uid.login, key.create_uid.id,
            //             request.httprequest.environ['REMOTE_ADDR'] if request else 'n/a'
            //         )
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        protected async Task<AuthPasskeyKey> GetSessionChallengeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py) ---
            // def _get_session_challenge(self):
            // challenge = request.session.pop('webauthn_challenge', None)
            // if not challenge:
            //     raise AccessDenied('Cannot find a challenge for this session')  # pylint: disable=missing-gettext
            // return challenge
            */
            return default;
        }

        public async Task<AuthPasskeyKey> InitAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py) ---
            // def init(self):
            // super().init()
            // if not sql.column_exists(self.env.cr, 'auth_passkey_key', 'public_key'):
            //     self.env.cr.execute(SQL('ALTER TABLE auth_passkey_key ADD COLUMN public_key varchar'))
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<AuthPasskeyKey> InversePublicKeyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py) ---
            // def _inverse_public_key(self):
            // pass
            */
            return default;
        }

        public async Task<AuthPasskeyKey> RenamePasskeyAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py) ---
            // def action_rename_passkey(self):
            // return {
            //     'name': _('Rename Passkey'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'auth.passkey.key',
            //     'view_id': self.env.ref('auth_passkey.auth_passkey_key_rename').id,
            //     'view_mode': 'form',
            //     'target': 'new',
            //     'res_id': self.id,
            //     'context': {
            //         'dialog_size': 'medium',
            //     }
            // }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        protected async Task<AuthPasskeyKey> StartAuthInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py) ---
            // def _start_auth(self):
            // assert request
            // authentication_options = json.loads(options_to_json(generate_authentication_options(
            //     rp_id=url_parse(self.get_base_url()).host,
            //     user_verification=UserVerificationRequirement.REQUIRED,
            // )))
            // request.session['webauthn_challenge'] = authentication_options['challenge']
            // return authentication_options
            */
            return default;
        }

        [ApiModel]
        protected async Task<AuthPasskeyKey> StartRegistrationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py) ---
            // def _start_registration(self):
            // assert request
            // registration_options = json.loads(options_to_json(generate_registration_options(
            //     rp_id=url_parse(self.get_base_url()).host,
            //     rp_name='Odoo',
            //     user_id=str(self.env.user.id).encode(),
            //     user_name=self.env.user.login,
            //     authenticator_selection=AuthenticatorSelectionCriteria(
            //         resident_key=ResidentKeyRequirement.REQUIRED,
            //         user_verification=UserVerificationRequirement.REQUIRED
            //     )
            // )))
            // request.session['webauthn_challenge'] = registration_options['challenge']
            // return registration_options
            */
            return default;
        }

        [ApiModel]
        protected async Task<AuthPasskeyKey> VerifyAuthInternalAsync(object auth, object public_key, object sign_count)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py) ---
            // def _verify_auth(self, auth, public_key, sign_count):
            // parsed_url = url_parse(self.get_base_url())
            // auth_verification = verify_authentication_response(
            //     credential=auth,
            //     expected_challenge=base64url_to_bytes(self._get_session_challenge()),
            //     expected_origin=parsed_url.replace(path='').to_url(),
            //     expected_rp_id=parsed_url.host,
            //     credential_public_key=base64url_to_bytes(public_key),
            //     credential_current_sign_count=sign_count,
            //     require_user_verification=True,
            // )
            // return auth_verification.new_sign_count
            */
            return default;
        }

        [ApiModel]
        protected async Task<AuthPasskeyKey> VerifyRegistrationOptionsInternalAsync(object registration)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py) ---
            // def _verify_registration_options(self, registration):
            // parsed_url = url_parse(self.get_base_url())
            // verification = verify_registration_response(
            //     credential=registration,
            //     expected_challenge=base64url_to_bytes(self._get_session_challenge()),
            //     expected_origin=parsed_url.replace(path='').to_url(),
            //     expected_rp_id=parsed_url.host,
            //     require_user_verification=True,
            // )
            // return {
            //     'credential_id': verification.credential_id,
            //     'credential_public_key': verification.credential_public_key,
            // }
            */
            return default;
        }
    }
}