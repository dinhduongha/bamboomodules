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
    public partial class IrFiltersAppService
    {

        [ApiModel]
        protected async Task<IrFilters> GetActionDomainInternalAsync(Guid action_id, Guid embedded_action_id, Guid embedded_parent_res_id)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_filters.py, METHOD: _get_action_domain) ---
            */
            return default;
        }

        protected async Task<IrFilters> GetEvalDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_filters.py, METHOD: _get_eval_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrFilters> ListAllModelsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_filters.py, METHOD: _list_all_models) ---
            */
            return default;
        }
    }
}