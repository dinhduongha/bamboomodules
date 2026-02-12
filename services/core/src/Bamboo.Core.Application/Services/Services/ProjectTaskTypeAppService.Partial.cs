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
    public partial class ProjectTaskTypeAppService
    {

        protected async Task<ProjectTaskType> CheckPersonalStageNotLinkedToProjectsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task_type.py, METHOD: _check_personal_stage_not_linked_to_projects) ---
            */
            return default;
        }

        protected async Task<ProjectTaskType> ComputeRatingRequestDeadlineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task_type.py, METHOD: _compute_rating_request_deadline) ---
            */
            return default;
        }

        protected async Task<ProjectTaskType> ComputeShowRatingActiveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task_type.py, METHOD: _compute_show_rating_active) ---
            */
            return default;
        }

        protected async Task<ProjectTaskType> ComputeUserIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task_type.py, METHOD: _compute_user_id) ---
            */
            return default;
        }

        protected async Task<ProjectTaskType> DefaultUserIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task_type.py, METHOD: _default_user_id) ---
            */
            return default;
        }

        protected async Task<ProjectTaskType> GetDefaultProjectIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task_type.py, METHOD: _get_default_project_ids) ---
            */
            return default;
        }

        protected async Task<ProjectTaskType> OnchangeProjectIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task_type.py, METHOD: _onchange_project_ids) ---
            */
            return default;
        }

        protected async Task<ProjectTaskType> PreparePersonalStagesDeletionInternalAsync(object remaining_stages_dict, object personal_stages_to_update)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task_type.py, METHOD: _prepare_personal_stages_deletion) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectTaskType> SendRatingAllInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task_type.py, METHOD: _send_rating_all) ---
            */
            return default;
        }

        protected async Task<ProjectTaskType> UnlinkIfRemainingPersonalStagesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task_type.py, METHOD: _unlink_if_remaining_personal_stages) ---
            */
            return default;
        }
    }
}