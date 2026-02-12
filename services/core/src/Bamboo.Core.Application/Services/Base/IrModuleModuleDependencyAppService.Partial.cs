using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
    public partial class IrModuleModuleDependencyAppService
    {

        protected async Task<IrModuleModuleDependency> ComputeDependInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _compute_depend) ---
            */
            return default;
        }

        protected async Task<IrModuleModuleDependency> ComputeStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _compute_state) ---
            */
            return default;
        }

        protected async Task<IrModuleModuleDependency> SearchDependInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_module.py, METHOD: _search_depend) ---
            */
            return default;
        }
    }
}