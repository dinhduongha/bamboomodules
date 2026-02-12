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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("analytic", Category = "Accounting", Depends = new[] { "base", "mail", "uom" })]
    public partial class AnalyticMixinAppService : ApplicationService, IAnalyticMixinAppService
    {

        public AnalyticMixinAppService() 
        {

        }

        public async Task<TEntity> ActionAddFromCatalogAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: action_add_from_catalog) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: action_add_from_catalog) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: action_add_from_catalog) ---
            */
            return default;
        }

        public async Task<TEntity> ActionApproveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_approve) ---
            */
            return default;
        }

        public async Task<TEntity> ActionApproveDuplicatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_approve_duplicates) ---
            */
            return default;
        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: action_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionAutomaticEntryAsync<TEntity>(IEnumerable<TEntity> entities, object default_action) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: action_automatic_entry) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAccountMoveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_open_account_move) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenBusinessDocAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: action_open_business_doc) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: action_open_order) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenSplitExpenseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_open_split_expense) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPayAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_pay) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPaymentItemsRegisterPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: action_payment_items_register_payment) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_post) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRefuseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_refuse) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRegisterPaymentAsync<TEntity>(IEnumerable<TEntity> entities, object ctx) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: action_register_payment) ---
            */
            return default;
        }

        public async Task<TEntity> ActionResetAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_reset) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShowOperationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: action_show_operations) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShowSameReceiptExpenseIdsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_show_same_receipt_expense_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSplitWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_split_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSubmitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_submit) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnreconcileMatchEntriesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: action_unreconcile_match_entries) ---
            */
            return default;
        }

        public async Task<TEntity> ActionWorkOrderAlternativesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: action_work_order_alternatives) ---
            */
            return default;
        }

        public async Task<TEntity> ActionWorkOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: action_work_order) ---
            */
            return default;
        }

        public async Task<TEntity> AddPrecomputedValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _add_precomputed_values) ---
            */
            return default;
        }

        public async Task<TEntity> AdditionalNamePerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _additional_name_per_id) ---
            */
            return default;
        }

        public async Task<TEntity> AffectTaxReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _affect_tax_report) ---
            */
            return default;
        }

        public async Task<TEntity> AllReconciledLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _all_reconciled_lines) ---
            */
            return default;
        }

        public async Task<TEntity> AmountResidualInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _amount_residual) ---
            */
            return default;
        }

        public async Task<TEntity> AttachDocumentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: attach_document) ---
            */
            return default;
        }

        public async Task<TEntity> CanBeAutovalidatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _can_be_autovalidated) ---
            */
            return default;
        }

        public async Task<TEntity> CanBeEditedOnPortalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _can_be_edited_on_portal) ---
            */
            return default;
        }

        public async Task<TEntity> CanBeInvoicedAloneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _can_be_invoiced_alone) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAlternativeWorkcenterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _check_alternative_workcenter) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAmlsExigibilityForReconciliationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object shadowed_aml_values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _check_amls_exigibility_for_reconciliation) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCabaNonCabaSharedTagsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _check_caba_non_caba_shared_tags) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCanApproveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _check_can_approve) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCanCreateMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _check_can_create_move) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCanRefuseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _check_can_refuse) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCanResetApprovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _check_can_reset_approval) ---
            */
            return default;
        }

        public async Task<TEntity> CheckComboItemIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _check_combo_item_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCompanyAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_distribution_model.py, METHOD: _check_company_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> CheckConstrainsAccountIdJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _check_constrains_account_id_journal_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckEdiLineTaxRequiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _check_edi_line_tax_required) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckFieldAccessRightsAsync<TEntity>(IEnumerable<TEntity> entities, object operation, object field_names) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: check_field_access_rights) ---
            */
            return default;
        }

        public async Task<TEntity> CheckLineUnlinkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _check_line_unlink) ---
            */
            return default;
        }

        public async Task<TEntity> CheckNonZeroInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _check_non_zero) ---
            */
            return default;
        }

        public async Task<TEntity> CheckO2oPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _check_o2o_payment) ---
            */
            return default;
        }

        public async Task<TEntity> CheckOffBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _check_off_balance) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPayableReceivableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _check_payable_receivable) ---
            */
            return default;
        }

        public async Task<TEntity> CheckProrataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _check_prorata) ---
            */
            return default;
        }

        public async Task<TEntity> CheckReconciliationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _check_reconciliation) ---
            */
            return default;
        }

        public async Task<TEntity> CheckTaxLockDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _check_tax_lock_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_account_id) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_account_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowedUomIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_allowed_uom_ids) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_allowed_uom_ids) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_allowed_uom_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_amount_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_amount) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_amount) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_amount_invoiced) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountResidualInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_amount_residual) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountToInvoiceAtDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_amount_to_invoice_at_date) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_amount_to_invoice_at_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_amount_to_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAnalyticDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_analytic_distribution) ---
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py, METHOD: _compute_analytic_distribution) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_analytic_distribution) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_analytic_distribution) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_analytic_distribution) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_balance) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBlockedTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_blocked_time) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBoardAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sequence, object residual_amount, object amount_to_depr, object undone_dotation_number, List<Guid> posted_depreciation_line_ids, object total_days, object depreciation_date) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _compute_board_amount) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBoardUndoneDotationNbInternalAsync<TEntity>(IEnumerable<TEntity> entities, object depreciation_date, object total_days) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _compute_board_undone_dotation_nb) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanApproveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_can_approve) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanResetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_can_reset) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCostsHourAccountIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: mrp_workcenter.py, METHOD: _compute_costs_hour_account_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCumulatedBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_cumulated_balance) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_currency_id) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_currency_rate) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCustomAttributeValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_custom_attribute_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCustomerLeadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_customer_lead) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDebitCreditInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_debit_credit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDepreciationBoardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: compute_depreciation_board) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDiscountAllocationKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_discount_allocation_key) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDiscountAllocationNeededInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_discount_allocation_needed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_discount) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_display_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDistributionAnalyticAccountIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py, METHOD: _compute_distribution_analytic_account_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDuplicateExpenseIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_duplicate_expense_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_employee_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date, object group_entries) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _compute_entries) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEpdKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_epd_key) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEpdNeededInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_epd_needed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFloatAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py, METHOD: _compute_float_amount) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFromEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_from_employee_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFromProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_from_product) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ComputeGeneratedEntriesAsync<TEntity>(IEnumerable<TEntity> entities, object date, object asset_type) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: compute_generated_entries) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasInvalidAnalyticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_has_invalid_analytics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasRoutingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_has_routing_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_invoice_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsEditableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_is_editable) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMultipleCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_is_multiple_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsProductArchivedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_is_product_archived) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsRefundInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_is_refund) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsStornoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_is_storno) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeKanbanDashboardGraphInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_kanban_dashboard_graph) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_name) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_name) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNbAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_nb_attachment) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNoFollowupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_no_followup) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNoVariantAttributeValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_no_variant_attribute_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_oee) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOrderedQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: _compute_ordered_qty) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_parent_id) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_parent_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_payment_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentMethodLineIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_payment_method_line_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePerformanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_performance) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePriceReduceTaxexclInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_price_reduce_taxexcl) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePriceReduceTaxincInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_price_reduce_taxinc) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePriceUnitAndDatePlannedAndNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_price_unit_and_date_planned_and_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePriceUnitDiscountedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_price_unit_discounted) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePriceUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_price_unit) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_price_unit) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: _compute_price_unit) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_price_unit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePriceUnitProductUomInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_price_unit_product_uom) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePricelistItemIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_pricelist_item_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_product_description) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_product_template_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_product_uom_id) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: _compute_product_uom_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_product_uom_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductUomQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_product_uom_qty) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_product_uom_qty) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductUomReadonlyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_product_uom_readonly) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductUpdatableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_product_updatable) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductiveTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_productive_time) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseLineWarnMsgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_purchase_line_warn_msg) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyDeliveredAtDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_qty_delivered_at_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyDeliveredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_qty_delivered) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyDeliveredMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_qty_delivered_method) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyInvoicedAtDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_qty_invoiced_at_date) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_qty_invoiced_at_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_qty_invoiced) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_qty_invoiced) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyInvoicedPostedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_qty_invoiced_posted) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyReceivedAtDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_qty_received_at_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyReceivedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_qty_received) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyReceivedMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_qty_received_method) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQtyToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_qty_to_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuantityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_quantity) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReconciledLinesExcludingExchangeDiffIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_reconciled_lines_excluding_exchange_diff_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReconciledLinesIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_reconciled_lines_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSaleLineWarnMsgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_sale_line_warn_msg) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSameCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_same_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSameReceiptExpenseIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_same_receipt_expense_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSelectablePaymentMethodLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_selectable_payment_method_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSelectedSellerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_selected_seller_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxAmountCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_tax_amount_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_tax_amount) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _compute_tax_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_tax_ids) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_tax_ids) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_tax_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTermKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_term_key) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalAmountCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_total_amount_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_total_amount) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _compute_totals) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTranslatedProductNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_translated_product_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUntaxedAmountInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_untaxed_amount_invoiced) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUntaxedAmountToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _compute_untaxed_amount_to_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_uom_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUomQtyAsync<TEntity>(IEnumerable<TEntity> entities, object new_qty, object stock_move, object rounding) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: compute_uom_qty) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkingStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_working_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkorderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_workorder_count) ---
            */
            return default;
        }

        public async Task<TEntity> ConditionalAddToComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object condition) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _conditional_add_to_compute) ---
            */
            return default;
        }

        public async Task<TEntity> ConstrainsDeductibleAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _constrains_deductible_amount) ---
            */
            return default;
        }

        public async Task<TEntity> ConstrainsMatchingNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _constrains_matching_number) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertToMiddleOfDayInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _convert_to_middle_of_day) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertToSolCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object currency) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _convert_to_sol_currency) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataExtendBusinessFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _copy_data_extend_business_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAnalyticLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _create_analytic_lines) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateCompanyPaidMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _create_company_paid_moves) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object @value) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_distribution_model.py, METHOD: _create_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateExchangeDifferenceMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object exchange_diff_values_list) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _create_exchange_difference_moves) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateExpenseFromAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids, object view_type) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: create_expense_from_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> CreateSupplierInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: _create_supplier_info) ---
            */
            return default;
        }

        public async Task<TEntity> CreationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _creation_message) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CronGenerateEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _cron_generate_entries) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DateInThePastInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _date_in_the_past) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _date_in_the_past) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _default_employee_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: default_get) ---
            */
            return default;
        }

        public async Task<TEntity> DoApproveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object check) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _do_approve) ---
            */
            return default;
        }

        public async Task<TEntity> DoRefuseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reason) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _do_refuse) ---
            */
            return default;
        }

        public async Task<TEntity> DoResetApprovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _do_reset_approval) ---
            */
            return default;
        }

        public async Task<TEntity> DomainProductIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _domain_product_id) ---
            */
            return default;
        }

        public async Task<TEntity> EntryCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _entry_count) ---
            */
            return default;
        }

        public async Task<TEntity> ExceptHashedEntryLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _except_hashed_entry_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ExpectedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _expected_date) ---
            */
            return default;
        }

        public async Task<object> FieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, string @alias, string field_expr, object query) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _field_to_sql) ---
            */
            return default;
        }

        public async Task<TEntity> FilterAmlLotValuationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _filter_aml_lot_valuation) ---
            */
            return default;
        }

        public async Task<TEntity> FilterReconciledByNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, Dictionary<string, object> mapping) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _filter_reconciled_by_number) ---
            */
            return default;
        }

        public async Task<TEntity> FilteredDomainAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py, METHOD: filtered_domain) ---
            */
            return default;
        }

        public async Task<TEntity> FlushModelAsync<TEntity>(IEnumerable<TEntity> entities, object fnames) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: flush_model) ---
            */
            return default;
        }

        public async Task<TEntity> FlushRecordsetAsync<TEntity>(IEnumerable<TEntity> entities, object fnames) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: flush_recordset) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormatAmlNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_name, object move_ref, object move_name) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _format_aml_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetAmlValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_aml_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAnalyticAccountIdsFromDistributionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object distributions) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py, METHOD: _get_analytic_account_ids_from_distributions) ---
            */
            return default;
        }

        public async Task<TEntity> GetAnalyticDistributionArgumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object root_plans) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_analytic_distribution_arguments) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetApplicableModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_distribution_model.py, METHOD: _get_applicable_models) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAttachmentByRecordInternalAsync<TEntity>(IEnumerable<TEntity> entities, object id_model2attachments, object move_line) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_attachment_by_record) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttachmentDomainsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_attachment_domains) ---
            */
            return default;
        }

        public async Task<TEntity> GetBaseAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_base_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetCannotApproveReasonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_cannot_approve_reason) ---
            */
            return default;
        }

        public async Task<TEntity> GetCapacityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, object unit, object default_capacity) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_capacity) ---
            */
            return default;
        }

        public async Task<TEntity> GetChildLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_child_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetColumnToExcludeForColspanCalculationAsync<TEntity>(IEnumerable<TEntity> entities, object taxes) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: get_column_to_exclude_for_colspan_calculation) ---
            */
            return default;
        }

        public async Task<TEntity> GetComboItemDisplayPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_combo_item_display_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetComboTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object totals_field) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_combo_totals) ---
            */
            return default;
        }

        public async Task<TEntity> GetComputedTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_computed_taxes) ---
            */
            return default;
        }

        public async Task<TEntity> GetCountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object query) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py, METHOD: _get_count_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetCustomComputeTaxCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_custom_compute_tax_cache_key) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDatePlannedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object seller, object po) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _get_date_planned) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultReadFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_default_read_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultResponsibleForApprovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_default_responsible_for_approval) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultSearchDomainValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_distribution_model.py, METHOD: _get_default_search_domain_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetDeliveredQuantityByAnalyticInternalAsync<TEntity>(IEnumerable<TEntity> entities, object additional_domain) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_delivered_quantity_by_analytic) ---
            */
            return default;
        }

        public async Task<TEntity> GetDiscountedPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_discounted_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetDisplayPriceIgnoreComboInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_display_price_ignore_combo) ---
            */
            return default;
        }

        public async Task<TEntity> GetDisplayPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_display_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetDisposalMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _get_disposal_moves) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_distribution_model.py, METHOD: _get_distribution) ---
            */
            return default;
        }

        public async Task<TEntity> GetDownpaymentDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_downpayment_description) ---
            */
            return default;
        }

        public async Task<TEntity> GetDownpaymentLinePriceUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_downpayment_line_price_unit) ---
            */
            return default;
        }

        public async Task<TEntity> GetDownpaymentLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_downpayment_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetDownpaymentStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_downpayment_state) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmployeeFromEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_address) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_employee_from_email) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: get_empty_list_help) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListMailAliasInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_empty_list_mail_alias) ---
            */
            return default;
        }

        public async Task<TEntity> GetExchangeAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object amount) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_exchange_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetExchangeJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_exchange_journal) ---
            */
            return default;
        }

        public async Task<TEntity> GetExpenseAccountDestinationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_expense_account_destination) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetExpenseDashboardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: get_expense_dashboard) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstAvailableSlotInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object duration, object forward, object leaves_to_ignore, object extra_leaves_slots) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_first_available_slot) ---
            */
            return default;
        }

        public async Task<TEntity> GetGrossPriceUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _get_gross_price_unit) ---
            */
            return default;
        }

        public async Task<TEntity> GetGroupedSectionSummaryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object display_taxes) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_grouped_section_summary) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        public async Task<TEntity> GetInstallmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_currency, object payment_date, object next_payment_date) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_installments_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetIntegrityHashFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_integrity_hash_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLineSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @new, object old) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_invoice_line_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _get_invoice_lines) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_invoice_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoicedQtyPerProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_invoiced_qty_per_product) ---
            */
            return default;
        }

        public async Task<TEntity> GetJournalItemsFullNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object display_name) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_journal_items_full_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetLinesWithPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_lines_with_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetLinkedLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_linked_line) ---
            */
            return default;
        }

        public async Task<TEntity> GetLinkedLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_linked_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetLockDateProtectedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_lock_date_protected_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetMatchedMoveIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_matched_move_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetMoveLineNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_move_line_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetOrderDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_order_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetOutstandingAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_outstanding_account_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetParentSectionLineAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: get_parent_section_line) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: get_parent_section_line) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: get_parent_section_line) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_partner_display) ---
            */
            return default;
        }

        public async Task<TEntity> GetPricelistKwargsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_pricelist_kwargs) ---
            */
            return default;
        }

        public async Task<TEntity> GetPricelistPriceBeforeDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_pricelist_price_before_discount) ---
            */
            return default;
        }

        public async Task<TEntity> GetPricelistPriceContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_pricelist_price_context) ---
            */
            return default;
        }

        public async Task<TEntity> GetPricelistPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_pricelist_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogLinesDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_product_catalog_lines_data) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _get_product_catalog_lines_data) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_product_catalog_lines_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_product_price_context) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPurchaseDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_lang) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _get_product_purchase_description) ---
            */
            return default;
        }

        public async Task<TEntity> GetProtectedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_protected_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetReconciliationAmlFieldValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object shadowed_aml_values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_reconciliation_aml_field_value) ---
            */
            return default;
        }

        public async Task<TEntity> GetSaleOrderLineMultilineDescriptionSaleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_sale_order_line_multiline_description_sale) ---
            */
            return default;
        }

        public async Task<TEntity> GetSaleOrderLineMultilineDescriptionVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_sale_order_line_multiline_description_variants) ---
            */
            return default;
        }

        public async Task<TEntity> GetSectionLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_section_lines) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_section_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetSectionSubtotalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: get_section_subtotal) ---
            */
            return default;
        }

        public async Task<TEntity> GetSectionTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object totals_field) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _get_section_totals) ---
            */
            return default;
        }

        public async Task<TEntity> GetSelectSellersParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _get_select_sellers_params) ---
            */
            return default;
        }

        public async Task<TEntity> GetSplitValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_split_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTaxExigibleDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _get_tax_exigible_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnavailabilityIntervalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object end_datetime) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_unavailability_intervals) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUntitledExpenseNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_untitled_expense_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewsAsync<TEntity>(IEnumerable<TEntity> entities, object views, object options) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: get_views) ---
            */
            return default;
        }

        public async Task<TEntity> GetWeekRangeAndFirstLastDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_week_range_and_first_last_days) ---
            */
            return default;
        }

        public async Task<TEntity> GetWorkcenterLoadPerWeekInternalAsync<TEntity>(IEnumerable<TEntity> entities, object week_range, object date_start, object date_stop) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_workcenter_load_per_week) ---
            */
            return default;
        }

        public async Task<TEntity> HasTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _has_taxes) ---
            */
            return default;
        }

        public async Task<TEntity> HasValuedMoveIdsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: has_valued_move_ids) ---
            */
            return default;
        }

        public async Task<TEntity> InitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py, METHOD: init) ---
            */
            return default;
        }

        public async Task<TEntity> InvalidateModelAsync<TEntity>(IEnumerable<TEntity> entities, object fnames, object flush) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: invalidate_model) ---
            */
            return default;
        }

        public async Task<TEntity> InvalidateRecordsetAsync<TEntity>(IEnumerable<TEntity> entities, object fnames, object flush) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: invalidate_recordset) ---
            */
            return default;
        }

        public async Task<TEntity> InverseAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _inverse_account_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseAmountCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _inverse_amount_currency) ---
            */
            return default;
        }

        public async Task<TEntity> InverseAnalyticDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _inverse_analytic_distribution) ---
            */
            return default;
        }

        public async Task<TEntity> InverseCreditInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _inverse_credit) ---
            */
            return default;
        }

        public async Task<TEntity> InverseDebitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _inverse_debit) ---
            */
            return default;
        }

        public async Task<TEntity> InverseNoFollowupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _inverse_no_followup) ---
            */
            return default;
        }

        public async Task<TEntity> InversePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _inverse_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseProductIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _inverse_product_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseQtyReceivedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _inverse_qty_received) ---
            */
            return default;
        }

        public async Task<TEntity> InverseReconciledLinesIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _inverse_reconciled_lines_ids) ---
            */
            return default;
        }

        public async Task<TEntity> InverseTotalAmountCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _inverse_total_amount_currency) ---
            */
            return default;
        }

        public async Task<TEntity> InverseTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _inverse_total_amount) ---
            */
            return default;
        }

        public async Task<TEntity> IsDeliveryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _is_delivery) ---
            */
            return default;
        }

        public async Task<TEntity> IsDiscountLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _is_discount_line) ---
            */
            return default;
        }

        public async Task<TEntity> IsGlobalDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _is_global_discount) ---
            */
            return default;
        }

        public async Task<TEntity> IsLineInSectionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _is_line_in_section) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _is_line_in_section) ---
            */
            return default;
        }

        public async Task<Dictionary<string, object>> MergeDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities, Dictionary<string, object> old_distribution, Dictionary<string, object> new_distribution) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py, METHOD: _merge_distribution) ---
            */
            return default;
        }

        public async Task<TEntity> MergePoLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rfq_line) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _merge_po_line) ---
            */
            return default;
        }

        public async Task<TEntity> MessageAutoSubscribeFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_values, List<Guid> subtype_ids) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _message_auto_subscribe_followers) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: message_new) ---
            */
            return default;
        }

        public async Task<TEntity> ModifiyingDistributionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object old_distribution, object new_distribution) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py, METHOD: _modifiying_distribution_values) ---
            */
            return default;
        }

        public async Task<TEntity> NeedsProductPriceComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _needs_product_price_computation) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAccountAssetAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: onchange_account_asset) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAmountTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py, METHOD: _onchange_amount_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCategoryIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: onchange_category_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCategoryIdValuesAsync<TEntity>(IEnumerable<TEntity> entities, Guid category_id) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: onchange_category_id_values) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: onchange_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeDateFirstDepreciationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: onchange_date_first_depreciation) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeMethodTimeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: onchange_method_time) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeMethodTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _onchange_method_time) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeProductHasCostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _onchange_product_has_cost) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeProductIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: onchange_product_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeProductIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _onchange_product_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: onchange_type) ---
            */
            return default;
        }

        public async Task<TEntity> OpenEntriesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: open_entries) ---
            */
            return default;
        }

        public async Task<TEntity> OpenReconcileViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: open_reconcile_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> OptimizeReconciliationPlanInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reconciliation_plan, object shadowed_aml_values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _optimize_reconciliation_plan) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ParseExpenseSubjectInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expense_description, object currencies) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _parse_expense_subject) ---
            */
            return default;
        }

        public async Task<TEntity> ParseFlushFnamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fnames) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _parse_flush_fnames) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ParsePriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expense_description, object currencies) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _parse_price) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ParseProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expense_description) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _parse_product) ---
            */
            return default;
        }

        public async Task<TEntity> PostWithoutWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _post_without_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> PostWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _post_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareAccountMoveLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _prepare_account_move_line) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareAddMissingFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _prepare_add_missing_fields) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareAnalyticDistributionLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object distribution, List<Guid> account_ids, object distribution_on_each_plan) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prepare_analytic_distribution_line) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareAnalyticLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prepare_analytic_lines) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _prepare_base_line_for_taxes_computation) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _prepare_base_line_for_taxes_computation) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _prepare_base_line_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareCreateValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prepare_create_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareEdiValsToExportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prepare_edi_vals_to_export) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareExchangeDifferenceMoveValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amounts_list, object company, object exchange_date) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prepare_exchange_difference_move_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareGraphDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object load_data, object week_range) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _prepare_graph_data) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _prepare_invoice_line) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceLinesValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _prepare_invoice_lines_vals_list) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareMoveLineResidualAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object aml_values, object counterpart_currency, object shadowed_aml_values, object other_aml_values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prepare_move_line_residual_amounts) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareMoveLinesValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _prepare_move_lines_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareMoveValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _prepare_move_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PreparePaymentsValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _prepare_payments_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareProcurementValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _prepare_procurement_values) ---
            */
            return default;
        }

        public async Task<TEntity> PreparePurchaseOrderLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object product_qty, object price_unit, List<Guid> taxes_ids) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _prepare_purchase_order_line) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: _prepare_purchase_order_line) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareQtyDeliveredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _prepare_qty_delivered) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareQtyInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _prepare_qty_invoiced) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _prepare_qty_invoiced) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareQtyReceivedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _prepare_qty_received) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareReceiptsValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _prepare_receipts_vals) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareReconciliationAmlsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values_list, object shadowed_aml_values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prepare_reconciliation_amls) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareReconciliationPlanInternalAsync<TEntity>(IEnumerable<TEntity> entities, object plan, object amls_values_map, object shadowed_aml_values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prepare_reconciliation_plan) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareReconciliationSinglePartialInternalAsync<TEntity>(IEnumerable<TEntity> entities, object debit_values, object credit_values, object shadowed_aml_values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prepare_reconciliation_single_partial) ---
            */
            return default;
        }

        public async Task<TEntity> PreventAutomaticLineDeletionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _prevent_automatic_line_deletion) ---
            */
            return default;
        }

        public async Task<TEntity> ProductIdChangeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _product_id_change) ---
            */
            return default;
        }

        public async Task<TEntity> QueryAnalyticAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object table) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py, METHOD: _query_analytic_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> ReadAsync<TEntity>(IEnumerable<TEntity> entities, object fields, object load) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: read) ---
            */
            return default;
        }

        public async Task<object> ReadGroupGroupbyInternalAsync<TEntity>(IEnumerable<TEntity> entities, string @alias, string groupby_spec, object query) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py, METHOD: _read_group_groupby) ---
            */
            return default;
        }

        public async Task<object> ReadGroupSelectInternalAsync<TEntity>(IEnumerable<TEntity> entities, string aggregate_spec, object query) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py, METHOD: _read_group_select) ---
            */
            return default;
        }

        public async Task<TEntity> ReconcileAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: reconcile) ---
            */
            return default;
        }

        public async Task<TEntity> ReconcileMarkedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _reconcile_marked) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReconcilePlanInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reconciliation_plan) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _reconcile_plan) ---
            */
            return default;
        }

        public async Task<TEntity> ReconcilePlanWithSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object plan_list, object all_amls) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _reconcile_plan_with_sync) ---
            */
            return default;
        }

        public async Task<TEntity> ReconcilePostHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _reconcile_post_hook) ---
            */
            return default;
        }

        public async Task<TEntity> ReconcilePreHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _reconcile_pre_hook) ---
            */
            return default;
        }

        public async Task<Dictionary<string, object>> ReconciledByNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _reconciled_by_number) ---
            */
            return default;
        }

        public async Task<TEntity> ReconciledLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _reconciled_lines) ---
            */
            return default;
        }

        public async Task<TEntity> RelatedAnalyticDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _related_analytic_distribution) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveMoveReconcileAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: remove_move_reconcile) ---
            */
            return default;
        }

        public async Task<TEntity> ResetPriceUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _reset_price_unit) ---
            */
            return default;
        }

        public async Task<TEntity> ReturnDisposalViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> move_ids) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _return_disposal_view) ---
            */
            return default;
        }

        public async Task<TEntity> RoundAnalyticDistributionLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object analytic_lines_vals) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _round_analytic_distribution_line) ---
            */
            return default;
        }

        public async Task<TEntity> SanitizeValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _sanitize_vals) ---
            */
            return default;
        }

        public async Task<TEntity> SanitizeValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object decimal_precision) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py, METHOD: _sanitize_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _search_account_id) ---
            */
            return default;
        }

        public async Task<TEntity> SearchAnalyticDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py, METHOD: _search_analytic_distribution) ---
            */
            return default;
        }

        public async Task<TEntity> SearchDistributionAnalyticAccountIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py, METHOD: _search_distribution_analytic_account_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchFetchAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field_names, object offset, object limit, object order) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: search_fetch) ---
            */
            return default;
        }

        public async Task<TEntity> SearchJournalGroupIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _search_journal_group_id) ---
            */
            return default;
        }

        public async Task<TEntity> SearchPanelDomainImageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object domain, object set_count, object limit) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _search_panel_domain_image) ---
            */
            return default;
        }

        public async Task<TEntity> SearchPaymentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _search_payment_date) ---
            */
            return default;
        }

        public async Task<TEntity> SearchProductTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _search_product_template_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchReadAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object fields, object offset, object limit, object order) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: search_read) ---
            */
            return default;
        }

        public async Task<TEntity> SellableLinesDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _sellable_lines_domain) ---
            */
            return default;
        }

        public async Task<TEntity> SendExpenseSuccessMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object expense) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _send_expense_success_mail) ---
            */
            return default;
        }

        public async Task<TEntity> SetAnalyticDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object inv_line_vals) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _set_analytic_distribution) ---
            */
            return default;
        }

        public async Task<TEntity> SetExpenseCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_today) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _set_expense_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> SetToCloseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: set_to_close) ---
            */
            return default;
        }

        public async Task<TEntity> SetToDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: set_to_draft) ---
            */
            return default;
        }

        public async Task<TEntity> SuggestQuantityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _suggest_quantity) ---
            */
            return default;
        }

        public async Task<TEntity> SyncInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _sync_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> TrackQtyReceivedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_qty) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _track_qty_received) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> UnblockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: unblock) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptApprovedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _unlink_except_approved) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptConfirmedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _unlink_except_confirmed) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptPostedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _unlink_except_posted) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptPurchaseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _unlink_except_purchase) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateActivitiesAndMailsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: update_activities_and_mails) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateAnalyticDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _update_analytic_distribution) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateDatePlannedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_date) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _update_date_planned) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateLineQuantityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _update_line_quantity) ---
            */
            return default;
        }

        public async Task<TEntity> ValidFieldParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object name) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _valid_field_parameter) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py, METHOD: _validate_amount) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateAnalyticDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: _validate_analytic_distribution) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: _validate_analytic_distribution) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: _validate_analytic_distribution) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: validate) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py, METHOD: _validate_distribution) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAnalyticMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_line.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_mixin.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order_line.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order_line.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: write) ---
            */
            return default;
        }
    }
}