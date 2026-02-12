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
    public partial class MaintenanceRequestAppService
    {

        protected async Task<MaintenanceRequest> AddFollowersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _add_followers) ---
            */
            return default;
        }

        protected async Task<MaintenanceRequest> CheckRepeatIntervalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _check_repeat_interval) ---
            */
            return default;
        }

        protected async Task<MaintenanceRequest> CheckScheduleEndInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _check_schedule_end) ---
            */
            return default;
        }

        protected async Task<MaintenanceRequest> ComputeDurationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_duration) ---
            */
            return default;
        }

        protected async Task<MaintenanceRequest> ComputeMaintenanceTeamIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_maintenance_team_id) ---
            */
            return default;
        }

        protected async Task<MaintenanceRequest> ComputeOwnerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py, METHOD: _compute_owner) ---
            */
            return default;
        }

        protected async Task<MaintenanceRequest> ComputeRecurringMaintenanceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_recurring_maintenance) ---
            */
            return default;
        }

        protected async Task<MaintenanceRequest> ComputeScheduleEndInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_schedule_end) ---
            */
            return default;
        }

        protected async Task<MaintenanceRequest> ComputeUserIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_user_id) ---
            */
            return default;
        }

        protected async Task<MaintenanceRequest> CreationSubtypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _creation_subtype) ---
            */
            return default;
        }

        protected async Task<MaintenanceRequest> DefaultEmployeeGetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py, METHOD: _default_employee_get) ---
            */
            return default;
        }

        protected async Task<MaintenanceRequest> DefaultStageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _default_stage) ---
            */
            return default;
        }

        protected async Task<MaintenanceRequest> GetActivityNoteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _get_activity_note) ---
            */
            return default;
        }

        protected async Task<MaintenanceRequest> GetDefaultTeamIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _get_default_team_id) ---
            */
            return default;
        }

        protected async Task<MaintenanceRequest> NeedNewActivityInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _need_new_activity) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MaintenanceRequest> ReadGroupStageIdsInternalAsync(object stages, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _read_group_stage_ids) ---
            */
            return default;
        }

        protected async Task<MaintenanceRequest> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _track_subtype) ---
            */
            return default;
        }
    }
}