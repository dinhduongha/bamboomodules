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
    public partial class AccountPaymentAppService
    {

        protected async Task<AccountPayment> AutoInitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py, METHOD: _auto_init) ---
            */
            return default;
        }

        protected async Task<AccountPayment> CheckBuildPageInfoInternalAsync(object i, object p)
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py, METHOD: _check_build_page_info) ---
            */
            return default;
        }

        protected async Task<AccountPayment> CheckFillLineInternalAsync(object amount_str)
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py, METHOD: _check_fill_line) ---
            */
            return default;
        }

        protected async Task<AccountPayment> CheckGetPagesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py, METHOD: _check_get_pages) ---
            */
            return default;
        }

        protected async Task<AccountPayment> CheckMakeStubPagesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py, METHOD: _check_make_stub_pages) ---
            */
            return default;
        }

        protected async Task<AccountPayment> CheckMoveIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _check_move_id) ---
            */
            return default;
        }

        protected async Task<AccountPayment> CheckPaymentMethodLineIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _check_payment_method_line_id) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeAmountAvailableForRefundInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py, METHOD: _compute_amount_available_for_refund) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeAmountCompanyCurrencySignedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_amount_company_currency_signed) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeAmountSignedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_amount_signed) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeAvailableJournalIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_available_journal_ids) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeAvailablePartnerBankIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_available_partner_bank_ids) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeCheckAmountInWordsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py, METHOD: _compute_check_amount_in_words) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeCheckNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py, METHOD: _compute_check_number) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeDestinationAccountIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_destination_account_id) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeDuplicatePaymentIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_duplicate_payment_ids) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeJournalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_journal_id) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_name) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeOutstandingAccountIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_outstanding_account_id) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_payment.py, METHOD: _compute_outstanding_account_id) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_payment.py, METHOD: _compute_outstanding_account_id) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputePartnerBankIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_partner_bank_id) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputePaymentMethodLineFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_payment_method_line_fields) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputePaymentMethodLineIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_payment_method_line_id) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputePaymentReceiptTitleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_payment_receipt_title) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeQrCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_qr_code) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeReconciliationStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_reconciliation_status) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeRefundsCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py, METHOD: _compute_refunds_count) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeShowCheckNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py, METHOD: _compute_show_check_number) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeShowRequirePartnerBankInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_show_require_partner_bank) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_payment.py, METHOD: _compute_show_require_partner_bank) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeStatButtonsFromReconciliationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_stat_buttons_from_reconciliation) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_state) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeSuitablePaymentTokenIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py, METHOD: _compute_suitable_payment_token_ids) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ComputeUseElectronicPaymentMethodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py, METHOD: _compute_use_electronic_payment_method) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ConstrainsCheckNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py, METHOD: _constrains_check_number) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ConstrainsCheckNumberUniqueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py, METHOD: _constrains_check_number_unique) ---
            */
            return default;
        }

        protected async Task<AccountPayment> CreatePaymentTransactionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py, METHOD: _create_payment_transaction) ---
            */
            return default;
        }

        protected async Task<AccountPayment> CreationMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_payment.py, METHOD: _creation_message) ---
            */
            return default;
        }

        protected async Task<AccountPayment> FetchDuplicateReferenceInternalAsync(object matching_states)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _fetch_duplicate_reference) ---
            */
            return default;
        }

        protected async Task<AccountPayment> GenerateJournalEntryInternalAsync(object write_off_line_vals, object force_balance, List<Guid> line_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _generate_journal_entry) ---
            */
            return default;
        }

        protected async Task<AccountPayment> GenerateMoveValsInternalAsync(object write_off_line_vals, object force_balance, List<Guid> line_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _generate_move_vals) ---
            */
            return default;
        }

        protected async Task<AccountPayment> GetAmlDefaultDisplayNameListInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _get_aml_default_display_name_list) ---
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py, METHOD: _get_aml_default_display_name_list) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountPayment> GetMethodCodesNeedingBankAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _get_method_codes_needing_bank_account) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountPayment> GetMethodCodesUsingBankAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _get_method_codes_using_bank_account) ---
            */
            return default;
        }

        protected async Task<AccountPayment> GetOutstandingAccountInternalAsync(object payment_type)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _get_outstanding_account) ---
            */
            return default;
        }

        protected async Task<AccountPayment> GetPaymentMethodCodesToExcludeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _get_payment_method_codes_to_exclude) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_payment.py, METHOD: _get_payment_method_codes_to_exclude) ---
            */
            return default;
        }

        protected async Task<AccountPayment> GetPaymentReceiptReportValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _get_payment_receipt_report_values) ---
            */
            return default;
        }

        protected async Task<AccountPayment> GetPaymentRefundWizardValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py, METHOD: _get_payment_refund_wizard_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountPayment> GetTriggerFieldsToSynchronizeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _get_trigger_fields_to_synchronize) ---
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py, METHOD: _get_trigger_fields_to_synchronize) ---
            */
            return default;
        }

        protected async Task<AccountPayment> GetValidLiquidityAccountsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _get_valid_liquidity_accounts) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountPayment> GetValidPaymentAccountTypesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _get_valid_payment_account_types) ---
            */
            return default;
        }

        protected async Task<AccountPayment> InverseCheckNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_payment.py, METHOD: _inverse_check_number) ---
            */
            return default;
        }

        protected async Task<AccountPayment> InverseMemoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _inverse_memo) ---
            */
            return default;
        }

        protected async Task<AccountPayment> MessageMailAfterHookInternalAsync(object mails)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _message_mail_after_hook) ---
            */
            return default;
        }

        protected async Task<AccountPayment> OnchangeSetPaymentTokenIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py, METHOD: _onchange_set_payment_token_id) ---
            */
            return default;
        }

        protected async Task<AccountPayment> PrepareMoveLineDefaultValsInternalAsync(object write_off_line_vals, object force_balance)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _prepare_move_line_default_vals) ---
            */
            return default;
        }

        protected async Task<AccountPayment> PreparePaymentTransactionValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_payment.py, METHOD: _prepare_payment_transaction_vals) ---
            */
            return default;
        }

        protected async Task<AccountPayment> SearchReconciledInvoiceIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _search_reconciled_invoice_ids) ---
            */
            return default;
        }

        protected async Task<AccountPayment> SeekForLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _seek_for_lines) ---
            */
            return default;
        }

        protected async Task<AccountPayment> SynchronizeToMovesInternalAsync(object changed_fields)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _synchronize_to_moves) ---
            */
            return default;
        }

        protected async Task<AccountPayment> ValidPaymentStatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _valid_payment_states) ---
            */
            return default;
        }
    }
}