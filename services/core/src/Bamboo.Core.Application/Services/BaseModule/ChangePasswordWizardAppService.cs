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
    public class ChangePasswordWizardAppService : GenericApplicationService<ChangePasswordWizard>, IChangePasswordWizardAppService
    {

        public ChangePasswordWizardAppService(IRepository<ChangePasswordWizard, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<ChangePasswordWizard> ChangePasswordButtonAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def change_password_button(self):
            // self.ensure_one()
            // self.user_ids.change_password_button()
            // if self.env.user in self.user_ids.user_id:
            //     return {'type': 'ir.actions.client', 'tag': 'reload'}
            // return {'type': 'ir.actions.act_window_close'}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ChangePasswordWizard> DefaultUserIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def _default_user_ids(self):
            // user_ids = self._context.get('active_model') == 'res.users' and self._context.get('active_ids') or []
            // return [
            //     Command.create({'user_id': user.id, 'user_login': user.login})
            //     for user in self.env['res.users'].browse(user_ids)
            // ]
            */
            return default;
        }
    }
}