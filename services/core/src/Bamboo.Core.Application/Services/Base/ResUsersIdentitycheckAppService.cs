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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("BaseModule", Category = "Base")]
    public partial class ResUsersIdentitycheckAppService : GenericApplicationService<ResUsersIdentitycheck>, IResUsersIdentitycheckAppService
    {

        public ResUsersIdentitycheckAppService(IRepository<ResUsersIdentitycheck, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<ResUsersIdentitycheck> CheckIdentityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: res_users_identitycheck.py) ---
            // def _check_identity(self):
            // if self.auth_method == 'webauthn':
            //     try:
            //         credential = {
            //             'webauthn_response': self.env.context.get('password'),
            //             'type': 'webauthn',
            //         }
            //         self.create_uid._check_credentials(credential, {'interactive': True})
            //     except AccessDenied:
            //         raise UserError(_("Incorrect Passkey. Please provide a valid passkey or use a different authentication method."))
            // else:
            //     super()._check_identity()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _check_identity(self):
            // try:
            //     credential = {
            //         'login': self.env.user.login,
            //         'password': self.env.context.get('password'),
            //         'type': 'password',
            //     }
            //     self.create_uid._check_credentials(credential, {'interactive': True})
            // except AccessDenied:
            //     raise UserError(_("Incorrect Password, try again or click on Forgot Password to reset your password."))
            */
            return default;
        }

        protected async Task<ResUsersIdentitycheck> GetDefaultAuthMethodInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: res_users_identitycheck.py) ---
            // def _get_default_auth_method(self):
            // if self.env.user.auth_passkey_key_ids:
            //     return 'webauthn'
            // else:
            //     return super()._get_default_auth_method()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _get_default_auth_method(self):
            // return 'password'
            */
            return default;
        }

        public async Task<ResUsersIdentitycheck> RunCheckAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def run_check(self):
            // # The password must be in the context with the key name `'password'`
            // assert request, "This method can only be accessed over HTTP"
            // self._check_identity()
            // 
            // request.session['identity-check-last'] = time.time()
            // ctx, model, ids, method, args, kwargs = json.loads(self.sudo().request)
            // method = getattr(self.env(context=ctx)[model].browse(ids), method)
            // assert getattr(method, '__has_check_identity', False)
            // return method(*args, **kwargs)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResUsersIdentitycheck> UsePasswordAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_passkey, FILE: res_users_identitycheck.py) ---
            // def action_use_password(self):
            // self.ensure_one()
            // self.auth_method = 'password'
            // self.password = ''
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'res.users.identitycheck',
            //     'res_id': self.id,
            //     'name': _('Security Control'),
            //     'target': 'new',
            //     'views': [(False, 'form')],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}