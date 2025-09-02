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
    [Module("BaseImportModuleModule", Depends = new[] { "web" })]
    public class BaseImportModuleAppService : GenericApplicationService<BaseImportModule>, IBaseImportModuleAppService
    {

        public BaseImportModuleAppService(IRepository<BaseImportModule, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<BaseImportModule> GetDependenciesToInstallNamesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: base_import_module.py) ---
            // def get_dependencies_to_install_names(self):
            // module_ids, _not_found = self.env['ir.module.module']._get_missing_dependencies_modules(base64.decodebytes(self.module_file))
            // return module_ids.mapped('name')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<BaseImportModule> ImportModuleAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: base_import_module.py) ---
            // def import_module(self):
            // self.ensure_one()
            // IrModule = self.env['ir.module.module']
            // zip_data = base64.decodebytes(self.module_file)
            // fp = BytesIO()
            // fp.write(zip_data)
            // res = IrModule._import_zipfile(fp, force=self.force, with_demo=self.with_demo)
            // return {
            //     'type': 'ir.actions.act_url',
            //     'target': 'self',
            //     'url': '/odoo',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<BaseImportModule> ModuleOpenAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: base_import_module.py) ---
            // def action_module_open(self):
            // self.ensure_one()
            // return {
            //     'domain': [('name', 'in', self.env.context.get('module_name', []))],
            //     'name': 'Modules',
            //     'view_mode': 'list,form',
            //     'res_model': 'ir.module.module',
            //     'view_id': False,
            //     'type': 'ir.actions.act_window',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}