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
    public partial class HrExpenseSheetAppService
    {

        protected async Task<HrExpenseSheet> CalculateDefaultAccountingDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _calculate_default_accounting_date) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> CheckCanApproveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _check_can_approve) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> CheckCanCreateMoveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _check_can_create_move) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> CheckCanRefuseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _check_can_refuse) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> CheckCanResetApprovalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _check_can_reset_approval) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> CheckEmployeeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _check_employee) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> CheckExpenseLinesCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _check_expense_lines_company) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> CheckPaymentModeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _check_payment_mode) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _compute_amount) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeCanApproveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _compute_can_approve) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeCanResetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _compute_can_reset) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeFromAccountMoveIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _compute_from_account_move_ids) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeFromEmployeeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _compute_from_employee_id) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeIsEditableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _compute_is_editable) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeIsMultipleCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _compute_is_multiple_currency) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeJournalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _compute_journal_id) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeMainAttachmentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _compute_main_attachment) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeNbAccountMoveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _compute_nb_account_move) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeNbExpenseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _compute_nb_expense) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputePaymentMethodLineIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _compute_payment_method_line_id) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeProductIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _compute_product_ids) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeSaleOrderCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense_sheet.py, METHOD: _compute_sale_order_count) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeSelectablePaymentMethodLineIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _compute_selectable_payment_method_line_ids) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ComputeStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _compute_state) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrExpenseSheet> DefaultEmployeeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _default_employee_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrExpenseSheet> DefaultJournalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _default_journal_id) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> DoApproveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _do_approve) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> DoCreateMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _do_create_moves) ---
            --- METHOD SOURCE (MODULE: project_sale_expense, FILE: hr_expense_sheet.py, METHOD: _do_create_moves) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense_sheet.py, METHOD: _do_create_moves) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> DoRefuseInternalAsync(object reason)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _do_refuse) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> DoResetApprovalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _do_reset_approval) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> DoReverseMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _do_reverse_moves) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> DoSubmitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _do_submit) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrExpenseSheet> GetDefaultSheetNameInternalAsync(object expenses_to_report)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _get_default_sheet_name) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> GetExpenseAccountDestinationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _get_expense_account_destination) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> GetResponsibleForApprovalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _get_responsible_for_approval) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> GetSaleOrderLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense_sheet.py, METHOD: _get_sale_order_lines) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> MessageAutoSubscribeFollowersInternalAsync(object updated_values, List<Guid> subtype_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _message_auto_subscribe_followers) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> PrepareBillsValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _prepare_bills_vals) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> PrepareMoveValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _prepare_move_vals) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> SaleExpenseResetSolQuantitiesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense_sheet.py, METHOD: _sale_expense_reset_sol_quantities) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrExpenseSheet> SearchProductIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _search_product_ids) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> UnlinkExceptPostedOrPaidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _unlink_except_posted_or_paid) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> UpdateSheetNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _update_sheet_name) ---
            */
            return default;
        }

        protected async Task<HrExpenseSheet> ValidateAnalyticDistributionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense_sheet.py, METHOD: _validate_analytic_distribution) ---
            */
            return default;
        }
    }
}