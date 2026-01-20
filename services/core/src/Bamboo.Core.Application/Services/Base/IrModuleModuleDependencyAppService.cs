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
    [Module("BaseModule", Category = "Base")]
    public partial class IrModuleModuleDependencyAppService : GenericApplicationService<IrModuleModuleDependency>, IIrModuleModuleDependencyAppService
    {

        public IrModuleModuleDependencyAppService(IRepository<IrModuleModuleDependency, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        public async Task<IrModuleModuleDependency> AllDependenciesAsync(Guid id, IrModuleModuleDependencyAllDependenciesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def all_dependencies(self, module_names):
            // to_search = {key: True for key in module_names}
            // res = {}
            // def search_direct_deps(to_search, res):
            //     to_search_list = to_search.keys()
            //     dependencies = self.web_search_read(domain=[("module_id.name", "in", to_search_list)], specification={"module_id":{"fields":{"name":{}}}, "name": {}, })["records"]
            //     to_search.clear()
            //     for dependency in dependencies:
            //         dep_name = dependency["name"]
            //         mod_name = dependency["module_id"]["name"]
            //         if dep_name not in res and dep_name not in to_search and dep_name not in to_search_list:
            //             to_search[dep_name] = True
            //         if mod_name not in res:
            //             res[mod_name] = []
            //         res[mod_name].append(dep_name)
            // search_direct_deps(to_search, res)
            // while to_search:
            //     search_direct_deps(to_search, res)
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModuleModuleDependency> ComputeDependInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _compute_depend(self):
            // # retrieve all modules corresponding to the dependency names
            // names = {dep.name for dep in self}
            // mods = self.env['ir.module.module'].search([('name', 'in', names)])
            // 
            // # index modules by name, and assign dependencies
            // name_mod = {mod.name: mod for mod in mods}
            // for dep in self:
            //     dep.depend_id = name_mod.get(dep.name)
            */
            return default;
        }

        protected async Task<IrModuleModuleDependency> ComputeStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _compute_state(self):
            // for dependency in self:
            //     dependency.state = dependency.depend_id.state or 'unknown'
            */
            return default;
        }

        protected async Task<IrModuleModuleDependency> SearchDependInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _search_depend(self, operator, value):
            // if operator not in ('in', 'any'):
            //     return NotImplemented
            // modules = self.env['ir.module.module'].browse(value)
            // return [('name', 'in', modules.mapped('name'))]
            */
            return default;
        }
    }
}