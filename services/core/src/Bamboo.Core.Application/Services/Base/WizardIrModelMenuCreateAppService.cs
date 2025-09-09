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
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;

namespace Bamboo.Core.Application.Services
{
    [Module("BaseModule")]
    public class WizardIrModelMenuCreateAppService : GenericApplicationService<WizardIrModelMenuCreate>, IWizardIrModelMenuCreateAppService
    {

        public WizardIrModelMenuCreateAppService(IRepository<WizardIrModelMenuCreate, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<WizardIrModelMenuCreate> MenuCreateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_model.py) ---
            // def menu_create(self):
            // for menu in self:
            //     model = self.env['ir.model'].browse(self._context.get('model_id'))
            //     vals = {
            //         'name': menu.name,
            //         'res_model': model.model,
            //         'view_mode': 'list,form',
            //     }
            //     action_id = self.env['ir.actions.act_window'].create(vals)
            //     self.env['ir.ui.menu'].create({
            //         'name': menu.name,
            //         'parent_id': menu.menu_id.id,
            //         'action': 'ir.actions.act_window,%d' % (action_id,)
            //     })
            // return {'type': 'ir.actions.act_window_close'}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}