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
    public partial class MrpWorkorderAppService
    {

        protected async Task<MrpWorkorder> ActionConfirmInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _action_confirm) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> CalCostInternalAsync(object date)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _cal_cost) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> CalculateDateFinishedInternalAsync(object date_start, object new_workcenter)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _calculate_date_finished) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> CalculateDurationExpectedInternalAsync(object date_start, object date_finished)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _calculate_duration_expected) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> CheckNoCyclicDependenciesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _check_no_cyclic_dependencies) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ComputeBarcodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _compute_barcode) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ComputeCurrentOperationCostInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _compute_current_operation_cost) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ComputeDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _compute_dates) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ComputeDurationExpectedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _compute_duration_expected) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ComputeDurationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _compute_duration) ---
            --- METHOD SOURCE (MODULE: mrp_account, FILE: mrp_workorder.py, METHOD: _compute_duration) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ComputeExpectedOperationCostInternalAsync(object without_employee_cost)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _compute_expected_operation_cost) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ComputeIsProducedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _compute_is_produced) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ComputeJsonPopoverInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _compute_json_popover) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ComputeProductionDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _compute_production_date) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ComputeProgressInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _compute_progress) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ComputeQtyProducingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _compute_qty_producing) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ComputeQtyReadyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _compute_qty_ready) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ComputeQtyRemainingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _compute_qty_remaining) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ComputeScrapMoveCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _compute_scrap_move_count) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ComputeStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _compute_state) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ComputeWorkingUsersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _compute_working_users) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> CreateOrUpdateAnalyticEntryForRecordInternalAsync(object @value, object hours)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: mrp_workorder.py, METHOD: _create_or_update_analytic_entry_for_record) ---
            --- METHOD SOURCE (MODULE: project_mrp_account, FILE: mrp_workorder.py, METHOD: _create_or_update_analytic_entry_for_record) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> CreateOrUpdateAnalyticEntryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: mrp_workorder.py, METHOD: _create_or_update_analytic_entry) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> DefaultSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _default_sequence) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> GetByproductMoveToUpdateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _get_byproduct_move_to_update) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> GetConflictedWorkorderIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _get_conflicted_workorder_ids) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> GetCurrentTheoricalOperationCostInternalAsync(object without_employee_cost)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _get_current_theorical_operation_cost) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> GetDurationExpectedInternalAsync(object alternative_workcenter, object ratio)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _get_duration_expected) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> GetOperationValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _get_operation_values) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> OnchangeDateFinishedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _onchange_date_finished) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> OnchangeDateStartInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _onchange_date_start) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> OnchangeFinishedLotIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _onchange_finished_lot_ids) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> OnchangeOperationIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _onchange_operation_id) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> PlanWorkorderInternalAsync(object replan)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _plan_workorder) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> PrepareAnalyticLineValuesInternalAsync(object account_field_values, object amount, object unit_amount)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: mrp_workorder.py, METHOD: _prepare_analytic_line_values) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> PrepareTimelineValsInternalAsync(object duration, object date_start, object date_end)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _prepare_timeline_vals) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ReadGroupWorkcenterIdInternalAsync(object workcenters, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _read_group_workcenter_id) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> SetCostModeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _set_cost_mode) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> SetDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _set_dates) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> SetDurationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _set_duration) ---
            --- METHOD SOURCE (MODULE: mrp_account, FILE: mrp_workorder.py, METHOD: _set_duration) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> SetQtyProducingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _set_qty_producing) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ShouldEstimateCostInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _should_estimate_cost) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> ShouldStartTimerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _should_start_timer) ---
            */
            return default;
        }

        protected async Task<MrpWorkorder> UpdateQtyProducingInternalAsync(object quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workorder.py, METHOD: _update_qty_producing) ---
            */
            return default;
        }
    }
}