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
    public partial class AccountAnalyticLineAppService
    {

        protected async Task<AccountAnalyticLine> CheckCanCreateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _check_can_create) ---
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: account_analytic.py, METHOD: _check_can_create) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> CheckCanWriteInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _check_can_write) ---
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: account_analytic.py, METHOD: _check_can_write) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _check_can_write) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> CheckGeneralAccountIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_analytic_line.py, METHOD: _check_general_account_id) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> CheckTimesheetCanBeBilledInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _check_timesheet_can_be_billed) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeAnalyticDistributionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_line.py, METHOD: _compute_analytic_distribution) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeCalendarDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _compute_calendar_display_name) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeCommercialPartnerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _compute_commercial_partner) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeDepartmentIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _compute_department_id) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeEncodingUomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _compute_encoding_uom_id) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeGeneralAccountIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_analytic_line.py, METHOD: _compute_general_account_id) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeMessagePartnerIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _compute_message_partner_ids) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputePartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_analytic_line.py, METHOD: _compute_partner_id) ---
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _compute_partner_id) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _compute_partner_id) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeProjectIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _compute_project_id) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _compute_project_id) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeReadonlyTimesheetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _compute_readonly_timesheet) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeSoLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _compute_so_line) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeTaskIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _compute_task_id) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeTimesheetInvoiceTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _compute_timesheet_invoice_type) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> ComputeUserIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _compute_user_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountAnalyticLine> ConvertHoursToDaysInternalAsync(object time)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _convert_hours_to_days) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> DefaultUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _default_user) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> DomainEmployeeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _domain_employee_id) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> DomainProjectIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _domain_project_id) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> DomainSoLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _domain_so_line) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountAnalyticLine> EnsureUomHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _ensure_uom_hours) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> GetEmployeeMappingEntryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _get_employee_mapping_entry) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> GetFavoriteProjectIdDomainInternalAsync(Guid employee_id)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _get_favorite_project_id_domain) ---
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: account_analytic.py, METHOD: _get_favorite_project_id_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountAnalyticLine> GetFavoriteProjectIdInternalAsync(Guid employee_id)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _get_favorite_project_id) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> GetRedirectActionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: account_analytic.py, METHOD: _get_redirect_action) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> GetReportBaseFilenameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _get_report_base_filename) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> GetTimesheetTimeDayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _get_timesheet_time_day) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> GetTimesheetsToMergeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _get_timesheets_to_merge) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> HourlyCostInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _hourly_cost) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _hourly_cost) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> InverseAnalyticDistributionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_line.py, METHOD: _inverse_analytic_distribution) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> IsNotBilledInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _is_not_billed) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> IsReadonlyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _is_readonly) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _is_readonly) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> IsTimesheetEncodeUomDayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _is_timesheet_encode_uom_day) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> IsUpdatableTimesheetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _is_updatable_timesheet) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _is_updatable_timesheet) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> OnchangeProjectIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _onchange_project_id) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> SearchFiscalDateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_line.py, METHOD: _search_fiscal_date) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> SearchMessagePartnerIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _search_message_partner_ids) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountAnalyticLine> ShowPortalTimesheetsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _show_portal_timesheets) ---
            --- METHOD SOURCE (MODULE: website_timesheet, FILE: account_analytic_line.py, METHOD: _show_portal_timesheets) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> SplitAmountFnameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_line.py, METHOD: _split_amount_fname) ---
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _split_amount_fname) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> TimesheetConvertSolUomInternalAsync(object sol, object to_unit)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _timesheet_convert_sol_uom) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> TimesheetDetermineSaleLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _timesheet_determine_sale_line) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> TimesheetGetPortalDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _timesheet_get_portal_domain) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _timesheet_get_portal_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountAnalyticLine> TimesheetGetSaleDomainInternalAsync(List<Guid> order_lines_ids, List<Guid> invoice_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _timesheet_get_sale_domain) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> TimesheetPostprocessInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _timesheet_postprocess) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _timesheet_postprocess) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> TimesheetPostprocessValuesInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _timesheet_postprocess_values) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> TimesheetPreprocessGetAccountsInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_timesheet.py, METHOD: _timesheet_preprocess_get_accounts) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _timesheet_preprocess_get_accounts) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> UnlinkExceptInvoicedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: hr_timesheet.py, METHOD: _unlink_except_invoiced) ---
            */
            return default;
        }

        protected async Task<AccountAnalyticLine> UnlinkExceptLinkedLeaveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: account_analytic.py, METHOD: _unlink_except_linked_leave) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountAnalyticLine> WhereCalcInternalAsync(object domain, object active_test)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_budget, FILE: account_analytic_account.py, METHOD: _where_calc) ---
            */
            return default;
        }
    }
}