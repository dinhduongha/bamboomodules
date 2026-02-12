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
    public partial class ResourceResourceAppService
    {

        protected async Task<ResourceResource> AdjustToCalendarInternalAsync(object start, object end, object compute_leaves)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_resource.py, METHOD: _adjust_to_calendar) ---
            */
            return default;
        }

        protected async Task<ResourceResource> ComputeAvatar128InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: resource.py, METHOD: _compute_avatar_128) ---
            --- METHOD SOURCE (MODULE: resource, FILE: resource_resource.py, METHOD: _compute_avatar_128) ---
            */
            return default;
        }

        protected async Task<ResourceResource> ComputeDepartmentIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: resource.py, METHOD: _compute_department_id) ---
            */
            return default;
        }

        protected async Task<ResourceResource> ComputeJobTitleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: resource.py, METHOD: _compute_job_title) ---
            */
            return default;
        }

        protected async Task<ResourceResource> DefaultColorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource_mail, FILE: resource_resource.py, METHOD: _default_color) ---
            */
            return default;
        }

        protected async Task<ResourceResource> FormatLeaveInternalAsync(object leave, object resource_hours_per_day, object resource_hours_per_week, object ranges_to_remove, object start_day, object end_day, object locale)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py, METHOD: _format_leave) ---
            --- METHOD SOURCE (MODULE: resource, FILE: resource_resource.py, METHOD: _format_leave) ---
            */
            return default;
        }

        protected async Task<ResourceResource> GetCalendarAtInternalAsync(object date_target, object tz)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: resource.py, METHOD: _get_calendar_at) ---
            --- METHOD SOURCE (MODULE: resource, FILE: resource_resource.py, METHOD: _get_calendar_at) ---
            */
            return default;
        }

        protected async Task<ResourceResource> GetCalendarsValidityWithinPeriodInternalAsync(object start, object end, object default_company)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: resource.py, METHOD: _get_calendars_validity_within_period) ---
            --- METHOD SOURCE (MODULE: resource, FILE: resource_resource.py, METHOD: _get_calendars_validity_within_period) ---
            */
            return default;
        }

        protected async Task<ResourceResource> GetContractsValidPeriodsInternalAsync(object start, object end)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: resource.py, METHOD: _get_contracts_valid_periods) ---
            */
            return default;
        }

        protected async Task<ResourceResource> GetFlexibleResourceValidWorkIntervalsInternalAsync(object start, object end)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_resource.py, METHOD: _get_flexible_resource_valid_work_intervals) ---
            */
            return default;
        }

        protected async Task<ResourceResource> GetFlexibleResourceWorkHoursInternalAsync(object intervals, object flexible_resources_hours_per_day, object flexible_resources_hours_per_week, object work_hours_per_day)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_resource.py, METHOD: _get_flexible_resource_work_hours) ---
            */
            return default;
        }

        protected async Task<ResourceResource> GetFlexibleResourcesCalendarsValidityWithinPeriodInternalAsync(object start, object end)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: resource.py, METHOD: _get_flexible_resources_calendars_validity_within_period) ---
            --- METHOD SOURCE (MODULE: resource, FILE: resource_resource.py, METHOD: _get_flexible_resources_calendars_validity_within_period) ---
            */
            return default;
        }

        protected async Task<ResourceResource> GetFlexibleResourcesDefaultWorkIntervalsInternalAsync(object start, object end)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_resource.py, METHOD: _get_flexible_resources_default_work_intervals) ---
            */
            return default;
        }

        protected async Task<ResourceResource> GetResourceWithoutContractInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: resource.py, METHOD: _get_resource_without_contract) ---
            */
            return default;
        }

        protected async Task<ResourceResource> GetUnavailableIntervalsInternalAsync(object start, object end)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_resource.py, METHOD: _get_unavailable_intervals) ---
            */
            return default;
        }

        protected async Task<ResourceResource> GetValidWorkIntervalsInternalAsync(object start, object end, object calendars, object compute_leaves)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_resource.py, METHOD: _get_valid_work_intervals) ---
            */
            return default;
        }

        protected async Task<ResourceResource> GetWorkIntervalInternalAsync(object start, object end)
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_resource.py, METHOD: _get_work_interval) ---
            */
            return default;
        }

        protected async Task<ResourceResource> InverseCalendarIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: resource.py, METHOD: _inverse_calendar_id) ---
            */
            return default;
        }

        protected async Task<ResourceResource> IsFlexibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_resource.py, METHOD: _is_flexible) ---
            */
            return default;
        }

        protected async Task<ResourceResource> IsFullyFlexibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_resource.py, METHOD: _is_fully_flexible) ---
            */
            return default;
        }

        protected async Task<ResourceResource> OnchangeCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_resource.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        protected async Task<ResourceResource> OnchangeUserIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: resource_resource.py, METHOD: _onchange_user_id) ---
            */
            return default;
        }
    }
}