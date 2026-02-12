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
    public partial class ProjectUpdateAppService
    {

        [ApiModel]
        protected async Task<ProjectUpdate> BuildDescriptionInternalAsync(object project)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_update.py, METHOD: _build_description) ---
            */
            return default;
        }

        protected async Task<ProjectUpdate> ComputeClosedTaskPercentageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_update.py, METHOD: _compute_closed_task_percentage) ---
            */
            return default;
        }

        protected async Task<ProjectUpdate> ComputeColorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_update.py, METHOD: _compute_color) ---
            */
            return default;
        }

        protected async Task<ProjectUpdate> ComputeDisplayTimesheetStatsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_update.py, METHOD: _compute_display_timesheet_stats) ---
            */
            return default;
        }

        protected async Task<ProjectUpdate> ComputeNameCroppedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_update.py, METHOD: _compute_name_cropped) ---
            */
            return default;
        }

        protected async Task<ProjectUpdate> ComputeProgressPercentageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_update.py, METHOD: _compute_progress_percentage) ---
            */
            return default;
        }

        protected async Task<ProjectUpdate> ComputeTimesheetPercentageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_update.py, METHOD: _compute_timesheet_percentage) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectUpdate> GetLastUpdatedMilestoneInternalAsync(object project)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_update.py, METHOD: _get_last_updated_milestone) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectUpdate> GetMilestoneValuesInternalAsync(object project)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_update.py, METHOD: _get_milestone_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectUpdate> GetTemplateValuesInternalAsync(object project)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_update.py, METHOD: _get_template_values) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_update.py, METHOD: _get_template_values) ---
            */
            return default;
        }
    }
}