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
    public partial class ResGroupsAppService
    {

        [ApiModel]
        protected async Task<ResGroups> ActivateGroupAccountSecuredInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_users.py, METHOD: _activate_group_account_secured) ---
            */
            return default;
        }

        protected async Task<ResGroups> ApplyGroupInternalAsync(object implied_group)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _apply_group) ---
            */
            return default;
        }

        protected async Task<ResGroups> CheckDisjointGroupsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _check_disjoint_groups) ---
            */
            return default;
        }

        protected async Task<ResGroups> CheckUserDisjointGroupsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _check_user_disjoint_groups) ---
            */
            return default;
        }

        protected async Task<ResGroups> ComputeAllImpliedByIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _compute_all_implied_by_ids) ---
            */
            return default;
        }

        protected async Task<ResGroups> ComputeAllImpliedIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _compute_all_implied_ids) ---
            */
            return default;
        }

        protected async Task<ResGroups> ComputeAllUserIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _compute_all_user_ids) ---
            */
            return default;
        }

        protected async Task<ResGroups> ComputeAllUsersCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _compute_all_users_count) ---
            */
            return default;
        }

        protected async Task<ResGroups> ComputeDisjointIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _compute_disjoint_ids) ---
            */
            return default;
        }

        protected async Task<ResGroups> ComputeFullNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _compute_full_name) ---
            */
            return default;
        }

        protected async Task<ResGroups> ComputeHasLockTimeoutInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _compute_has_lock_timeout) ---
            */
            return default;
        }

        protected async Task<ResGroups> ComputeLockTimeout2faSelectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _compute_lock_timeout_2fa_selection) ---
            */
            return default;
        }

        protected async Task<ResGroups> ComputeLockTimeoutDelayUnitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _compute_lock_timeout_delay_unit) ---
            */
            return default;
        }

        protected async Task<ResGroups> ComputeLockTimeoutInactivity2faSelectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _compute_lock_timeout_inactivity_2fa_selection) ---
            */
            return default;
        }

        protected async Task<ResGroups> ComputeLockTimeoutInactivityBoolInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _compute_lock_timeout_inactivity_bool) ---
            */
            return default;
        }

        protected async Task<ResGroups> ComputeLockTimeoutInactivityDelayUnitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _compute_lock_timeout_inactivity_delay_unit) ---
            */
            return default;
        }

        protected async Task<ResGroups> ComputeViewGroupHierarchyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _compute_view_group_hierarchy) ---
            */
            return default;
        }

        protected async Task<ResGroups> EnsureXmlIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _ensure_xml_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResGroups> GetGroupDefinitionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _get_group_definitions) ---
            */
            return default;
        }

        protected async Task<ResGroups> GetLockTimeoutsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _get_lock_timeouts) ---
            */
            return default;
        }

        protected async Task<ResGroups> GetUserTypeGroupsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _get_user_type_groups) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResGroups> GetViewGroupHierarchyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _get_view_group_hierarchy) ---
            */
            return default;
        }

        protected async Task<ResGroups> InverseAllUserIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _inverse_all_user_ids) ---
            */
            return default;
        }

        protected async Task<ResGroups> InverseLockTimeout2faSelectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _inverse_lock_timeout_2fa_selection) ---
            */
            return default;
        }

        protected async Task<ResGroups> InverseLockTimeoutInactivity2faSelectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _inverse_lock_timeout_inactivity_2fa_selection) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResGroups> IsFeatureEnabledInternalAsync(object group_reference)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _is_feature_enabled) ---
            */
            return default;
        }

        protected async Task<ResGroups> OnchangeHasLockTimeoutInactivityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _onchange_has_lock_timeout_inactivity) ---
            */
            return default;
        }

        protected async Task<ResGroups> OnchangeHasLockTimeoutInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _onchange_has_lock_timeout) ---
            */
            return default;
        }

        protected async Task<ResGroups> OnchangeLockTimeoutDelayUnitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _onchange_lock_timeout_delay_unit) ---
            */
            return default;
        }

        protected async Task<ResGroups> OnchangeLockTimeoutInactivityDelayUnitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_timeout, FILE: res_groups.py, METHOD: _onchange_lock_timeout_inactivity_delay_unit) ---
            */
            return default;
        }

        protected async Task<ResGroups> RemoveGroupInternalAsync(object implied_group)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _remove_group) ---
            */
            return default;
        }

        protected async Task<ResGroups> SearchAllImpliedByIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _search_all_implied_by_ids) ---
            */
            return default;
        }

        protected async Task<ResGroups> SearchAllImpliedIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _search_all_implied_ids) ---
            */
            return default;
        }

        protected async Task<ResGroups> SearchAllUserIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _search_all_user_ids) ---
            */
            return default;
        }

        protected async Task<ResGroups> SearchFullNameInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _search_full_name) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResGroups> SearchInternalAsync(object domain, object offset, object limit, object order)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _search) ---
            */
            return default;
        }

        protected async Task<ResGroups> UnlinkExceptSettingsGroupInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_groups.py, METHOD: _unlink_except_settings_group) ---
            */
            return default;
        }
    }
}