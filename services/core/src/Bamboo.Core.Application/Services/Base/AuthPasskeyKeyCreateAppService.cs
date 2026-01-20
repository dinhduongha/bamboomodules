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
    public partial class AuthPasskeyKeyCreateAppService : GenericApplicationService<AuthPasskeyKeyCreate>, IAuthPasskeyKeyCreateAppService
    {

        public AuthPasskeyKeyCreateAppService(IRepository<AuthPasskeyKeyCreate, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        public async Task<AuthPasskeyKeyCreate> MakeKeyAsync(Guid id, AuthPasskeyKeyCreateMakeKeyRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: auth_passkey_key.py) ---
            // def make_key(self, registration=None):
            // # We add in these fields with JS, if we didn't give them default values we would get a XML validation warning.
            // assert registration, "registration can not be empty"
            // self.ensure_one()
            // verification = request.env['auth.passkey.key']._verify_registration_options(registration)
            // # Force to go through `res.users.auth_passkey_key_ids` to trigger the session token cache invalidation
            // # See `res.users.write` and `_get_invalidation_fields`
            // # `self.env.user` is already sudo, so no need to re-apply `sudo` to get create access right.
            // self.env.user.write({'auth_passkey_key_ids': [Command.create({
            //     'name': self.name,
            //     'credential_identifier': bytes_to_base64url(verification['credential_id']),
            // })]})
            // passkey = self.env.user.auth_passkey_key_ids[0]
            // self.env.cr.execute(SQL(
            //     "UPDATE auth_passkey_key SET public_key = %s WHERE id = %s",
            //     base64.urlsafe_b64encode(verification['credential_public_key']).decode(),
            //     passkey.id,
            // ))
            // ip = request.httprequest.environ['REMOTE_ADDR'] if request else 'n/a'
            // _logger.info(
            //     "Passkey (#%d) created by %s (#%d) from %s",
            //     passkey.id,
            //     self.env.user.login, self.env.user.id,
            //     ip
            // )
            // new_token = self.env.user._compute_session_token(request.session.sid)
            // request.session.session_token = new_token
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}