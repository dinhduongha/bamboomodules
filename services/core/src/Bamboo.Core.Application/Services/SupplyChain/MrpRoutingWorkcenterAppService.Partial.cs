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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class MrpRoutingWorkcenterAppService
    {

        protected async Task<MrpRoutingWorkcenter> CheckNoCyclicDependenciesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py, METHOD: _check_no_cyclic_dependencies) ---
            */
            return default;
        }

        protected async Task<MrpRoutingWorkcenter> ComputeCostInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py, METHOD: _compute_cost) ---
            */
            return default;
        }

        protected async Task<MrpRoutingWorkcenter> ComputeTimeComputedOnInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py, METHOD: _compute_time_computed_on) ---
            */
            return default;
        }

        protected async Task<MrpRoutingWorkcenter> ComputeTimeCycleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py, METHOD: _compute_time_cycle) ---
            */
            return default;
        }

        protected async Task<MrpRoutingWorkcenter> ComputeWorkorderCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py, METHOD: _compute_workorder_count) ---
            */
            return default;
        }

        protected async Task<MrpRoutingWorkcenter> SkipOperationLineInternalAsync(object product, object never_attribute_values)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py, METHOD: _skip_operation_line) ---
            */
            return default;
        }
    }
}