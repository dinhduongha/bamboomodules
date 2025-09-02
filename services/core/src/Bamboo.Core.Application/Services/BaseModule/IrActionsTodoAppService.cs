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
    public class IrActionsTodoAppService : GenericApplicationService<IrActionsTodo>, IIrActionsTodoAppService
    {

        public IrActionsTodoAppService(IRepository<IrActionsTodo, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<IrActionsTodo> EnsureOneOpenTodoAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def ensure_one_open_todo(self):
            // open_todo = self.search([('state', '=', 'open')], order='sequence asc, id desc', offset=1)
            // if open_todo:
            //     open_todo.write({'state': 'done'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrActionsTodo> LaunchAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def action_launch(self):
            // """ Launch Action of Wizard"""
            // self.ensure_one()
            // 
            // self.write({'state': 'done'})
            // 
            // # Load action
            // action_type = self.action_id.type
            // action = self.env[action_type].browse(self.action_id.id)
            // 
            // result = action.read()[0]
            // if action_type != 'ir.actions.act_window':
            //     return result
            // result.setdefault('context', '{}')
            // 
            // # Open a specific record when res_id is provided in the context
            // ctx = safe_eval(result['context'], {'user': self.env.user})
            // if ctx.get('res_id'):
            //     result['res_id'] = ctx.pop('res_id')
            // 
            // # disable log for automatic wizards
            // ctx['disable_log'] = True
            // 
            // result['context'] = ctx
            // 
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrActionsTodo> OpenAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_actions.py) ---
            // def action_open(self):
            // """ Sets configuration wizard in TODO state"""
            // return self.write({'state': 'open'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}