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
    public partial class ServerActionHistoryWizardAppService
    {

        protected async Task<ServerActionHistoryWizard> ComputeCodeDiffInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_code_diff) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ServerActionHistoryWizard> DefaultRevisionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _default_revision) ---
            */
            return default;
        }
    }
}