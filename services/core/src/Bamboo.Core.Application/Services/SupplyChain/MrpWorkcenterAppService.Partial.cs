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
    public partial class MrpWorkcenterAppService
    {

        protected async Task<MrpWorkcenter> CheckAlternativeWorkcenterInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _check_alternative_workcenter) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenter> ComputeBlockedTimeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_blocked_time) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenter> ComputeCostsHourAccountIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: mrp_workcenter.py, METHOD: _compute_costs_hour_account_ids) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenter> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenter> ComputeHasRoutingLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_has_routing_lines) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenter> ComputeKanbanDashboardGraphInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_kanban_dashboard_graph) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenter> ComputeOeeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_oee) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenter> ComputePerformanceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_performance) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenter> ComputeProductiveTimeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_productive_time) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenter> ComputeWorkingStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_working_state) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenter> ComputeWorkorderCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_workorder_count) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenter> GetCapacityInternalAsync(object product, object unit, object default_capacity)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_capacity) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenter> GetFirstAvailableSlotInternalAsync(object start_datetime, object duration, object forward, object leaves_to_ignore, object extra_leaves_slots)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_first_available_slot) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenter> GetUnavailabilityIntervalsInternalAsync(object start_datetime, object end_datetime)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_unavailability_intervals) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenter> GetWeekRangeAndFirstLastDaysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_week_range_and_first_last_days) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenter> GetWorkcenterLoadPerWeekInternalAsync(object week_range, object date_start, object date_stop)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_workcenter_load_per_week) ---
            */
            return default;
        }

        protected async Task<MrpWorkcenter> PrepareGraphDataInternalAsync(object load_data, object week_range)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _prepare_graph_data) ---
            */
            return default;
        }
    }
}