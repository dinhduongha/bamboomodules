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
    public partial class CrmTeamAppService
    {

        protected async Task<CrmTeam> ActionAssignLeadsInternalAsync(object force_quota, object creation_delta_days)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _action_assign_leads) ---
            */
            return default;
        }

        protected async Task<CrmTeam> ActionAssignLeadsLogsInternalAsync(object teams_data, object members_data)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _action_assign_leads_logs) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CrmTeam> ActionUpdateToPipelineInternalAsync(object action)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _action_update_to_pipeline) ---
            */
            return default;
        }

        protected async Task<CrmTeam> AddMembersToFavoritesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _add_members_to_favorites) ---
            */
            return default;
        }

        protected async Task<CrmTeam> AliasGetCreationValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _alias_get_creation_values) ---
            */
            return default;
        }

        protected async Task<CrmTeam> AllocateLeadsDeduplicateInternalAsync(object leads, object duplicates_cache)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _allocate_leads_deduplicate) ---
            */
            return default;
        }

        protected async Task<CrmTeam> AllocateLeadsInternalAsync(object creation_delta_days)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _allocate_leads) ---
            */
            return default;
        }

        protected async Task<CrmTeam> AssignAndConvertLeadsInternalAsync(object force_quota)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _assign_and_convert_leads) ---
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeAbandonedCartsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: crm_team.py, METHOD: _compute_abandoned_carts) ---
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeAssignmentEnabledInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _compute_assignment_enabled) ---
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeAssignmentMaxInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _compute_assignment_max) ---
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeDashboardButtonNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _compute_dashboard_button_name) ---
            --- METHOD SOURCE (MODULE: sale, FILE: crm_team.py, METHOD: _compute_dashboard_button_name) ---
            --- METHOD SOURCE (MODULE: sale_crm, FILE: crm_team.py, METHOD: _compute_dashboard_button_name) ---
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _compute_dashboard_button_name) ---
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeInvoicedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: crm_team.py, METHOD: _compute_invoiced) ---
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeIsFavoriteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _compute_is_favorite) ---
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeIsMembershipMultiInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _compute_is_membership_multi) ---
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeLeadAllAssignedMonthCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _compute_lead_all_assigned_month_count) ---
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeLeadUnassignedCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _compute_lead_unassigned_count) ---
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeMemberCompanyIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _compute_member_company_ids) ---
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeMemberIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _compute_member_ids) ---
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeMemberWarningInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _compute_member_warning) ---
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeSaleOrderCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: crm_team.py, METHOD: _compute_sale_order_count) ---
            */
            return default;
        }

        protected async Task<CrmTeam> ConstrainsAssignmentDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _constrains_assignment_domain) ---
            */
            return default;
        }

        protected async Task<CrmTeam> ConstrainsCompanyMembersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _constrains_company_members) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CrmTeam> CronAssignLeadsInternalAsync(object force_quota, object creation_delta_days)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _cron_assign_leads) ---
            */
            return default;
        }

        protected async Task<CrmTeam> GetDefaultColorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _get_default_color) ---
            */
            return default;
        }

        protected async Task<CrmTeam> GetDefaultFavoriteUserIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _get_default_favorite_user_ids) ---
            */
            return default;
        }

        protected async Task<CrmTeam> GetDefaultTeamIdInternalAsync(Guid user_id, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _get_default_team_id) ---
            */
            return default;
        }

        protected async Task<CrmTeam> GetLeadToAssignDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _get_lead_to_assign_domain) ---
            */
            return default;
        }

        protected async Task<CrmTeam> InSaleScopeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: crm_team.py, METHOD: _in_sale_scope) ---
            */
            return default;
        }

        protected async Task<CrmTeam> InverseIsFavoriteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _inverse_is_favorite) ---
            */
            return default;
        }

        protected async Task<CrmTeam> InverseMemberIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _inverse_member_ids) ---
            */
            return default;
        }

        protected async Task<CrmTeam> OnchangeUseLeadsOpportunitiesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _onchange_use_leads_opportunities) ---
            */
            return default;
        }

        protected async Task<CrmTeam> SearchMemberIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _search_member_ids) ---
            */
            return default;
        }

        protected async Task<CrmTeam> UnlinkExceptDefaultInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _unlink_except_default) ---
            */
            return default;
        }

        protected async Task<CrmTeam> UnlinkExceptUsedForSalesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: crm_team.py, METHOD: _unlink_except_used_for_sales) ---
            */
            return default;
        }
    }
}