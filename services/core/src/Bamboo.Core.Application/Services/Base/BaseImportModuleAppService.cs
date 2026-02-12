using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
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
    [Module("BaseImportModuleModule", Category = "Base", Depends = new[] { "web" })]
    public partial class BaseImportModuleAppService : GenericAppService<BaseImportModule>, IBaseImportModuleAppService
    {

        public BaseImportModuleAppService(IRepository<BaseImportModule, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<BaseImportModule> GetDependenciesToInstallNamesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: base_import_module.py, METHOD: get_dependencies_to_install_names) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<BaseImportModule> ImportModuleAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: base_import_module.py, METHOD: import_module) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<BaseImportModule> ModuleOpenAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base_import_module, FILE: base_import_module.py, METHOD: action_module_open) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}