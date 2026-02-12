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
    public partial class HrExpenseAppService
    {

        protected async Task<HrExpense> CanBeAutovalidatedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _can_be_autovalidated) ---
            */
            return default;
        }

        protected async Task<HrExpense> CheckCanApproveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _check_can_approve) ---
            */
            return default;
        }

        protected async Task<HrExpense> CheckCanCreateMoveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _check_can_create_move) ---
            */
            return default;
        }

        protected async Task<HrExpense> CheckCanRefuseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _check_can_refuse) ---
            */
            return default;
        }

        protected async Task<HrExpense> CheckCanResetApprovalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _check_can_reset_approval) ---
            */
            return default;
        }

        protected async Task<HrExpense> CheckNonZeroInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _check_non_zero) ---
            */
            return default;
        }

        protected async Task<HrExpense> CheckO2oPaymentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _check_o2o_payment) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeAccountIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_account_id) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeAnalyticDistributionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_analytic_distribution) ---
            --- METHOD SOURCE (MODULE: project_hr_expense, FILE: hr_expense.py, METHOD: _compute_analytic_distribution) ---
            --- METHOD SOURCE (MODULE: project_sale_expense, FILE: hr_expense.py, METHOD: _compute_analytic_distribution) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeCanApproveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_can_approve) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeCanBeReinvoicedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense.py, METHOD: _compute_can_be_reinvoiced) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeCanResetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_can_reset) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeCurrencyRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_currency_rate) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeDuplicateExpenseIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_duplicate_expense_ids) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeEmployeeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_employee_id) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeFromEmployeeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_from_employee_id) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeFromProductInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_from_product) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeIsEditableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_is_editable) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeIsMultipleCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_is_multiple_currency) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_name) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeNbAttachmentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_nb_attachment) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputePaymentMethodLineIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_payment_method_line_id) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputePriceUnitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_price_unit) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeProductDescriptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_product_description) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeSaleOrderIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense.py, METHOD: _compute_sale_order_id) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeSameReceiptExpenseIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_same_receipt_expense_ids) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeSelectablePaymentMethodLineIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_selectable_payment_method_line_ids) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_state) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeTaxAmountCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_tax_amount_currency) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeTaxAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_tax_amount) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeTaxIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_tax_ids) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeTotalAmountCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_total_amount_currency) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeTotalAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_total_amount) ---
            */
            return default;
        }

        protected async Task<HrExpense> ComputeUomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_uom_id) ---
            */
            return default;
        }

        protected async Task<HrExpense> CreateCompanyPaidMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _create_company_paid_moves) ---
            */
            return default;
        }

        protected async Task<HrExpense> CreationMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _creation_message) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrExpense> DefaultEmployeeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _default_employee_id) ---
            */
            return default;
        }

        protected async Task<HrExpense> DoApproveInternalAsync(object check)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _do_approve) ---
            */
            return default;
        }

        protected async Task<HrExpense> DoRefuseInternalAsync(object reason)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _do_refuse) ---
            */
            return default;
        }

        protected async Task<HrExpense> DoResetApprovalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _do_reset_approval) ---
            */
            return default;
        }

        protected async Task<HrExpense> GetBaseAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_base_account) ---
            */
            return default;
        }

        protected async Task<HrExpense> GetCannotApproveReasonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_cannot_approve_reason) ---
            */
            return default;
        }

        protected async Task<HrExpense> GetDefaultResponsibleForApprovalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_default_responsible_for_approval) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrExpense> GetEmployeeFromEmailInternalAsync(object email_address)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_employee_from_email) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrExpense> GetEmptyListMailAliasInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_empty_list_mail_alias) ---
            */
            return default;
        }

        protected async Task<HrExpense> GetExpenseAccountDestinationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_expense_account_destination) ---
            */
            return default;
        }

        protected async Task<HrExpense> GetMoveLineNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_move_line_name) ---
            */
            return default;
        }

        protected async Task<HrExpense> GetOutstandingAccountIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_outstanding_account_id) ---
            */
            return default;
        }

        protected async Task<HrExpense> GetSplitValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_split_values) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense.py, METHOD: _get_split_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrExpense> GetUntitledExpenseNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_untitled_expense_name) ---
            */
            return default;
        }

        protected async Task<HrExpense> InverseTotalAmountCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _inverse_total_amount_currency) ---
            */
            return default;
        }

        protected async Task<HrExpense> InverseTotalAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _inverse_total_amount) ---
            */
            return default;
        }

        protected async Task<HrExpense> MessageAutoSubscribeFollowersInternalAsync(object updated_values, List<Guid> subtype_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _message_auto_subscribe_followers) ---
            */
            return default;
        }

        protected async Task<HrExpense> NeedsProductPriceComputationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _needs_product_price_computation) ---
            */
            return default;
        }

        protected async Task<HrExpense> OnchangeProductHasCostInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _onchange_product_has_cost) ---
            */
            return default;
        }

        protected async Task<HrExpense> OnchangeSaleOrderIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense.py, METHOD: _onchange_sale_order_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrExpense> ParseExpenseSubjectInternalAsync(object expense_description, object currencies)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _parse_expense_subject) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrExpense> ParsePriceInternalAsync(object expense_description, object currencies)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _parse_price) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<HrExpense> ParseProductInternalAsync(object expense_description)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _parse_product) ---
            */
            return default;
        }

        protected async Task<HrExpense> PostWithoutWizardInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _post_without_wizard) ---
            */
            return default;
        }

        protected async Task<HrExpense> PostWizardInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _post_wizard) ---
            */
            return default;
        }

        protected async Task<HrExpense> PrepareBaseLineForTaxesComputationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _prepare_base_line_for_taxes_computation) ---
            */
            return default;
        }

        protected async Task<HrExpense> PrepareMoveLinesValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _prepare_move_lines_vals) ---
            */
            return default;
        }

        protected async Task<HrExpense> PrepareMoveValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _prepare_move_vals) ---
            */
            return default;
        }

        protected async Task<HrExpense> PreparePaymentsValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _prepare_payments_vals) ---
            */
            return default;
        }

        protected async Task<HrExpense> PrepareReceiptsValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _prepare_receipts_vals) ---
            */
            return default;
        }

        protected async Task<HrExpense> SaleExpenseResetSolQuantitiesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_expense, FILE: hr_expense.py, METHOD: _sale_expense_reset_sol_quantities) ---
            */
            return default;
        }

        protected async Task<HrExpense> SendExpenseSuccessMailInternalAsync(object msg_dict, object expense)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _send_expense_success_mail) ---
            */
            return default;
        }

        protected async Task<HrExpense> SetExpenseCurrencyRateInternalAsync(object date_today)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _set_expense_currency_rate) ---
            */
            return default;
        }

        protected async Task<HrExpense> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        protected async Task<HrExpense> UnlinkExceptApprovedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _unlink_except_approved) ---
            */
            return default;
        }
    }
}