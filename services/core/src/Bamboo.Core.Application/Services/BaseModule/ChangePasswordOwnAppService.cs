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
    [Module("BaseModule")]
    public class ChangePasswordOwnAppService : GenericApplicationService<ChangePasswordOwn>, IChangePasswordOwnAppService
    {

        public ChangePasswordOwnAppService(IRepository<ChangePasswordOwn, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<ChangePasswordOwn> ChangePasswordAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def change_password(self):
            // self.env.user._change_password(self.new_password)
            // self.unlink()
            // # reload to avoid a session expired error
            // # would be great to update the session id in-place, but it seems dicey
            // return {'type': 'ir.actions.client', 'tag': 'reload'}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ChangePasswordOwn> CheckPasswordConfirmationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _check_password_confirmation(self):
            // if self.confirm_password != self.new_password:
            //     raise ValidationError(_("The new password and its confirmation must be identical."))
            */
            return default;
        }
    }
}