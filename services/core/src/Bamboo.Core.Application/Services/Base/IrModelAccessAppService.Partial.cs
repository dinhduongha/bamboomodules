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
    public partial class IrModelAccessAppService
    {

        [ApiModel]
        protected async Task<IrModelAccess> GetAccessGroupsInternalAsync(object model_name, object access_mode)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _get_access_groups) ---
            */
            return default;
        }

        protected async Task<IrModelAccess> GetAllowedModelsInternalAsync(object mode)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _get_allowed_models) ---
            */
            return default;
        }

        protected async Task<IrModelAccess> MakeAccessErrorInternalAsync(string model, string mode)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_model.py, METHOD: _make_access_error) ---
            */
            return default;
        }
    }
}