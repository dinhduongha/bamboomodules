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
    public partial class PosSessionAppService
    {

        protected async Task<PosSession> AccumulateAmountsInternalAsync(object data)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _accumulate_amounts) ---
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_session.py, METHOD: _accumulate_amounts) ---
            */
            return default;
        }

        protected async Task<PosSession> AggregateMovesByEmployeeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_session.py, METHOD: _aggregate_moves_by_employee) ---
            */
            return default;
        }

        protected async Task<PosSession> AggregatePaymentsAmountsByEmployeeInternalAsync(object all_payments)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_session.py, METHOD: _aggregate_payments_amounts_by_employee) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosSession> AlertOldSessionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _alert_old_session) ---
            */
            return default;
        }

        protected async Task<PosSession> AmountConverterInternalAsync(object amount, object date, object round)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _amount_converter) ---
            */
            return default;
        }

        protected async Task<PosSession> ApplyDiffOnAccountPaymentMoveInternalAsync(object account_payment, object payment_method, object diff_amount)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _apply_diff_on_account_payment_move) ---
            */
            return default;
        }

        protected async Task<PosSession> CannotCloseSessionInternalAsync(object bank_payment_method_diffs)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _cannot_close_session) ---
            */
            return default;
        }

        protected async Task<PosSession> CheckIfNoDraftOrdersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _check_if_no_draft_orders) ---
            */
            return default;
        }

        protected async Task<PosSession> CheckInvoicesArePostedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _check_invoices_are_posted) ---
            */
            return default;
        }

        protected async Task<PosSession> CheckPosConfigInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _check_pos_config) ---
            */
            return default;
        }

        protected async Task<PosSession> CheckStartDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _check_start_date) ---
            */
            return default;
        }

        protected async Task<PosSession> CloseSessionActionInternalAsync(object amount_to_balance)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _close_session_action) ---
            */
            return default;
        }

        protected async Task<PosSession> ComputeCashBalanceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_cash_balance) ---
            */
            return default;
        }

        protected async Task<PosSession> ComputeCashControlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_cash_control) ---
            */
            return default;
        }

        protected async Task<PosSession> ComputeCashJournalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_cash_journal) ---
            */
            return default;
        }

        protected async Task<PosSession> ComputeIsInCompanyCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_is_in_company_currency) ---
            */
            return default;
        }

        protected async Task<PosSession> ComputeOrderCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_order_count) ---
            */
            return default;
        }

        protected async Task<PosSession> ComputePickingCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_picking_count) ---
            */
            return default;
        }

        protected async Task<PosSession> ComputeTotalPaymentsAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_total_payments_amount) ---
            */
            return default;
        }

        protected async Task<PosSession> CreateAccountMoveInternalAsync(object balancing_account, object amount_to_balance, object bank_payment_method_diffs)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_account_move) ---
            */
            return default;
        }

        protected async Task<PosSession> CreateBalancingLineInternalAsync(object data, object balancing_account, object amount_to_balance)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_balancing_line) ---
            */
            return default;
        }

        protected async Task<PosSession> CreateBankPaymentMovesInternalAsync(object data)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_bank_payment_moves) ---
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_session.py, METHOD: _create_bank_payment_moves) ---
            */
            return default;
        }

        protected async Task<PosSession> CreateCashStatementLinesAndCashMoveLinesInternalAsync(object data)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_cash_statement_lines_and_cash_move_lines) ---
            */
            return default;
        }

        protected async Task<PosSession> CreateCombineAccountPaymentInternalAsync(object payment_method, object amounts, object diff_amount)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_combine_account_payment) ---
            */
            return default;
        }

        protected async Task<PosSession> CreateDiffAccountMoveForSplitPaymentMethodInternalAsync(object payment_method, object diff_amount)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_diff_account_move_for_split_payment_method) ---
            */
            return default;
        }

        protected async Task<PosSession> CreateInvoiceReceivableLinesInternalAsync(object data)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_invoice_receivable_lines) ---
            */
            return default;
        }

        protected async Task<PosSession> CreateNonReconciliableMoveLinesInternalAsync(object data)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_non_reconciliable_move_lines) ---
            */
            return default;
        }

        protected async Task<PosSession> CreatePayLaterReceivableLinesInternalAsync(object data)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_pay_later_receivable_lines) ---
            */
            return default;
        }

        protected async Task<PosSession> CreatePickingAtEndOfSessionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_picking_at_end_of_session) ---
            */
            return default;
        }

        protected async Task<PosSession> CreateSplitAccountPaymentInternalAsync(object payment, object amounts)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_split_account_payment) ---
            */
            return default;
        }

        protected async Task<PosSession> CreateStockValuationLinesInternalAsync(object data)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_stock_valuation_lines) ---
            */
            return default;
        }

        protected async Task<PosSession> CreditAmountsInternalAsync(object partial_move_line_vals, object amount, object amount_converted, object force_company_currency)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _credit_amounts) ---
            */
            return default;
        }

        protected async Task<PosSession> DebitAmountsInternalAsync(object partial_move_line_vals, object amount, object amount_converted, object force_company_currency)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _debit_amounts) ---
            */
            return default;
        }

        protected async Task<PosSession> GetAttributesByPtalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_attributes_by_ptal_id) ---
            */
            return default;
        }

        protected async Task<PosSession> GetBalancingAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_balancing_account) ---
            */
            return default;
        }

        protected async Task<PosSession> GetCapturedPaymentsDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_captured_payments_domain) ---
            */
            return default;
        }

        protected async Task<PosSession> GetClosedOrdersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_closed_orders) ---
            */
            return default;
        }

        protected async Task<PosSession> GetCombineReceivableValsInternalAsync(object payment_method, object amount, object amount_converted)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_combine_receivable_vals) ---
            */
            return default;
        }

        protected async Task<PosSession> GetCombineStatementLineValsInternalAsync(object journal, object amount, object payment_method)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_combine_statement_line_vals) ---
            */
            return default;
        }

        protected async Task<PosSession> GetDiffAccountMoveRefInternalAsync(object payment_method)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_diff_account_move_ref) ---
            */
            return default;
        }

        protected async Task<PosSession> GetDiffValsInternalAsync(Guid payment_method_id, object diff_amount, object outstanding_account)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_diff_vals) ---
            */
            return default;
        }

        protected async Task<PosSession> GetInvoiceReceivableValsInternalAsync(object amount, object amount_converted)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_invoice_receivable_vals) ---
            */
            return default;
        }

        protected async Task<PosSession> GetInvoiceTotalListInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_invoice_total_list) ---
            */
            return default;
        }

        protected async Task<PosSession> GetMessageAuthorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_session.py, METHOD: _get_message_author) ---
            */
            return default;
        }

        protected async Task<PosSession> GetOtherRelatedMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_other_related_moves) ---
            */
            return default;
        }

        protected async Task<PosSession> GetPartnersDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_partners_domain) ---
            */
            return default;
        }

        protected async Task<PosSession> GetReceivableAccountInternalAsync(object payment_method)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_receivable_account) ---
            */
            return default;
        }

        protected async Task<PosSession> GetRelatedAccountMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_related_account_moves) ---
            */
            return default;
        }

        protected async Task<PosSession> GetRoundingDifferenceValsInternalAsync(object amount, object amount_converted)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_rounding_difference_vals) ---
            */
            return default;
        }

        protected async Task<PosSession> GetSaleKeyInternalAsync(object base_line)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_sale_key) ---
            */
            return default;
        }

        protected async Task<PosSession> GetSaleValsInternalAsync(object key, object sale_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_sale_vals) ---
            */
            return default;
        }

        protected async Task<PosSession> GetSplitReceivableOpValsInternalAsync(object payment, object amount, object amount_converted)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_session.py, METHOD: _get_split_receivable_op_vals) ---
            */
            return default;
        }

        protected async Task<PosSession> GetSplitReceivableValsInternalAsync(object payment, object amount, object amount_converted)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_split_receivable_vals) ---
            */
            return default;
        }

        protected async Task<PosSession> GetSplitStatementLineValsInternalAsync(object journal, object amount, object payment)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_split_statement_line_vals) ---
            */
            return default;
        }

        protected async Task<PosSession> GetStockExpenseValsInternalAsync(object exp_account, object amount, object amount_converted)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_stock_expense_vals) ---
            */
            return default;
        }

        protected async Task<PosSession> GetStockValuationValsInternalAsync(object stock_val_account, object amount, object amount_converted)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_stock_valuation_vals) ---
            */
            return default;
        }

        protected async Task<PosSession> GetTaxValsInternalAsync(object key, object amount, object amount_converted, object base_amount_converted)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_tax_vals) ---
            */
            return default;
        }

        protected async Task<PosSession> GetTotalInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_total_invoice) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosSession> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosSession> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosSession> LoadPosDataModelsInternalAsync(Guid config_id)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _load_pos_data_models) ---
            --- METHOD SOURCE (MODULE: pos_event, FILE: pos_session.py, METHOD: _load_pos_data_models) ---
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_session.py, METHOD: _load_pos_data_models) ---
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_session.py, METHOD: _load_pos_data_models) ---
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_session.py, METHOD: _load_pos_data_models) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_session.py, METHOD: _load_pos_data_models) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_session.py, METHOD: _load_pos_data_models) ---
            */
            return default;
        }

        protected async Task<PosSession> LoadPosDataReadInternalAsync(object records, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_session.py, METHOD: _load_pos_data_read) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosSession> LoadPosDataRelationsInternalAsync(object model, object fields)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _load_pos_data_relations) ---
            --- METHOD SOURCE (MODULE: pos_event, FILE: pos_session.py, METHOD: _load_pos_data_relations) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosSession> LoadPosSelfDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_session.py, METHOD: _load_pos_self_data_domain) ---
            */
            return default;
        }

        protected async Task<PosSession> LoaderParamsPosPaymentMethodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_session.py, METHOD: _loader_params_pos_payment_method) ---
            */
            return default;
        }

        protected async Task<PosSession> PosHasValidProductInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _pos_has_valid_product) ---
            */
            return default;
        }

        protected async Task<PosSession> PostCashDetailsMessageInternalAsync(object state, object expected, object difference, object notes)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _post_cash_details_message) ---
            */
            return default;
        }

        protected async Task<PosSession> PostStatementDifferenceInternalAsync(object amount)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _post_statement_difference) ---
            */
            return default;
        }

        protected async Task<PosSession> PrepareAccountBankStatementLineValsInternalAsync(object session, object sign, object amount, object reason, Guid partner_id, object extras)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _prepare_account_bank_statement_line_vals) ---
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_session.py, METHOD: _prepare_account_bank_statement_line_vals) ---
            */
            return default;
        }

        protected async Task<PosSession> PrepareBalancingLineValsInternalAsync(object imbalance_amount, object move, object balancing_account)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _prepare_balancing_line_vals) ---
            */
            return default;
        }

        protected async Task<PosSession> PrepareStatementLineAmountValuesInternalAsync(object journal, object amount)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _prepare_statement_line_amount_values) ---
            */
            return default;
        }

        protected async Task<PosSession> ReconcileAccountMoveLinesInternalAsync(object data)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _reconcile_account_move_lines) ---
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_session.py, METHOD: _reconcile_account_move_lines) ---
            */
            return default;
        }

        protected async Task<PosSession> RoundAmountsInternalAsync(object amounts)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _round_amounts) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosSession> SetLastOrderPreparationChangeInternalAsync(List<Guid> order_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_session.py, METHOD: _set_last_order_preparation_change) ---
            */
            return default;
        }

        protected async Task<PosSession> SetOpeningControlDataInternalAsync(int cashbox_value, string notes)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _set_opening_control_data) ---
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_session.py, METHOD: _set_opening_control_data) ---
            */
            return default;
        }

        protected async Task<PosSession> UpdateAmountsInternalAsync(object old_amounts, object amounts_to_add, object date, object round, object force_company_currency)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _update_amounts) ---
            */
            return default;
        }

        protected async Task<PosSession> ValidateSessionInternalAsync(object balancing_account, object amount_to_balance, object bank_payment_method_diffs)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _validate_session) ---
            */
            return default;
        }
    }
}