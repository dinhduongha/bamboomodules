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
    public partial class ProjectMilestoneAppService
    {

        protected async Task<ProjectMilestone> ComputeCanBeMarkedAsDoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _compute_can_be_marked_as_done) ---
            */
            return default;
        }

        protected async Task<ProjectMilestone> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<ProjectMilestone> ComputeIsDeadlineExceededInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _compute_is_deadline_exceeded) ---
            */
            return default;
        }

        protected async Task<ProjectMilestone> ComputeIsDeadlineFutureInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _compute_is_deadline_future) ---
            */
            return default;
        }

        protected async Task<ProjectMilestone> ComputeProductUomQtyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_milestone.py, METHOD: _compute_product_uom_qty) ---
            */
            return default;
        }

        protected async Task<ProjectMilestone> ComputeProjectAllowMilestonesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _compute_project_allow_milestones) ---
            */
            return default;
        }

        protected async Task<ProjectMilestone> ComputeQuantityPercentageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_milestone.py, METHOD: _compute_quantity_percentage) ---
            */
            return default;
        }

        protected async Task<ProjectMilestone> ComputeReachedDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _compute_reached_date) ---
            */
            return default;
        }

        protected async Task<ProjectMilestone> ComputeTaskCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _compute_task_count) ---
            */
            return default;
        }

        protected async Task<ProjectMilestone> DefaultSaleLineIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_milestone.py, METHOD: _default_sale_line_id) ---
            */
            return default;
        }

        protected async Task<ProjectMilestone> GetDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _get_data) ---
            */
            return default;
        }

        protected async Task<ProjectMilestone> GetDataListInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _get_data_list) ---
            */
            return default;
        }

        protected async Task<ProjectMilestone> GetDefaultProjectIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _get_default_project_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectMilestone> GetFieldsToExportInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _get_fields_to_export) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_milestone.py, METHOD: _get_fields_to_export) ---
            */
            return default;
        }

        protected async Task<ProjectMilestone> SearchProjectAllowMilestonesInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _search_project_allow_milestones) ---
            */
            return default;
        }
    }
}