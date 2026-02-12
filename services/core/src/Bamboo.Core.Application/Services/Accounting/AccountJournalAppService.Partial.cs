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
    public partial class AccountJournalAppService
    {

        protected async Task<AccountJournal> AliasGetCreationValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _alias_get_creation_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountJournal> AliasPrepareAliasNameInternalAsync(object alias_name, object name, object code, object jtype, object company)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _alias_prepare_alias_name) ---
            */
            return default;
        }

        protected async Task<AccountJournal> BuildNoJournalErrorMsgInternalAsync(object company_name, object journal_types)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _build_no_journal_error_msg) ---
            */
            return default;
        }

        protected async Task<AccountJournal> CheckAutoPostDraftEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_auto_post_draft_entries) ---
            */
            return default;
        }

        protected async Task<AccountJournal> CheckBankAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_bank_account) ---
            */
            return default;
        }

        protected async Task<AccountJournal> CheckCompanyConsistencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_company_consistency) ---
            */
            return default;
        }

        protected async Task<AccountJournal> CheckIncomingEinvoiceNotificationEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_incoming_einvoice_notification_email) ---
            */
            return default;
        }

        protected async Task<AccountJournal> CheckNoActivePaymentsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_journal.py, METHOD: _check_no_active_payments) ---
            */
            return default;
        }

        protected async Task<AccountJournal> CheckPaymentMethodLineIdsMultiplicityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_payment_method_line_ids_multiplicity) ---
            */
            return default;
        }

        protected async Task<AccountJournal> CheckTypeDefaultAccountIdTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_type_default_account_id_type) ---
            */
            return default;
        }

        protected async Task<AccountJournal> CheckTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_journal.py, METHOD: _check_type) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeAccountingDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_accounting_date) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeAvailableInvoiceTemplatePdfReportIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_available_invoice_template_pdf_report_ids) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeAvailablePaymentMethodIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_available_payment_method_ids) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeCheckNextNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_journal.py, METHOD: _compute_check_next_number) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_code) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeCompatibleEdiIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_journal.py, METHOD: _compute_compatible_edi_ids) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeCurrentStatementBalanceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _compute_current_statement_balance) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeDebitSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_debit_note, FILE: account_journal.py, METHOD: _compute_debit_sequence) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeDefaultAccountTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_default_account_type) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeDisplayAliasFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_display_alias_fields) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeEdiFormatIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_journal.py, METHOD: _compute_edi_format_ids) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeEntriesCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _compute_entries_count) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeHasEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _compute_has_entries) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeHasInvalidStatementsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_has_invalid_statements) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeHasSequenceHolesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _compute_has_sequence_holes) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeHasUnhashedEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _compute_has_unhashed_entries) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeInboundPaymentMethodLineIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_inbound_payment_method_line_ids) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeIncomingEinvoiceNotificationEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_incoming_einvoice_notification_email) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeLastBankStatementInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _compute_last_bank_statement) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeNamePlaceholderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_name_placeholder) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeOutboundPaymentMethodLineIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_outbound_payment_method_line_ids) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputePaymentSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_payment_sequence) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeRefundSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_refund_sequence) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeSelectedPaymentMethodCodesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_selected_payment_method_codes) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeShowFetchInEinvoicesButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_show_fetch_in_einvoices_button) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_journal.py, METHOD: _compute_show_fetch_in_einvoices_button) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeShowRefreshOutEinvoicesStatusButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_show_refresh_out_einvoices_status_button) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_journal.py, METHOD: _compute_show_refresh_out_einvoices_status_button) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ComputeSuspenseAccountIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_suspense_account_id) ---
            */
            return default;
        }

        protected async Task<AccountJournal> CountResultsAndSumAmountsInternalAsync(object results_dict, object target_currency)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _count_results_and_sum_amounts) ---
            */
            return default;
        }

        protected async Task<AccountJournal> CreateCheckSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_journal.py, METHOD: _create_check_sequence) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountJournal> CreateDefaultAccountInternalAsync(object company, object journal_type, object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _create_default_account) ---
            */
            return default;
        }

        protected async Task<AccountJournal> CreateDocumentFromAttachmentInternalAsync(List<Guid> attachment_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _create_document_from_attachment) ---
            */
            return default;
        }

        protected async Task<AccountJournal> DefaultDisplayInvoiceTemplatePdfReportIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _default_display_invoice_template_pdf_report_id) ---
            */
            return default;
        }

        protected async Task<AccountJournal> DefaultInboundPaymentMethodsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _default_inbound_payment_methods) ---
            */
            return default;
        }

        protected async Task<AccountJournal> DefaultInvoiceReferenceModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _default_invoice_reference_model) ---
            */
            return default;
        }

        protected async Task<AccountJournal> DefaultOutboundPaymentMethodsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _default_outbound_payment_methods) ---
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_journal.py, METHOD: _default_outbound_payment_methods) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountJournal> EnsureCompanyAccountJournalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_journal.py, METHOD: _ensure_company_account_journal) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountJournal> EnsureUniqueAliasInternalAsync(object vals, object company)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _ensure_unique_alias) ---
            */
            return default;
        }

        protected async Task<AccountJournal> FillBankCashDashboardDataInternalAsync(object dashboard_data)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _fill_bank_cash_dashboard_data) ---
            */
            return default;
        }

        protected async Task<AccountJournal> FillDashboardDataCountInternalAsync(object dashboard_data, object model, object name, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _fill_dashboard_data_count) ---
            */
            return default;
        }

        protected async Task<AccountJournal> FillGeneralDashboardDataInternalAsync(object dashboard_data)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _fill_general_dashboard_data) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountJournal> FillMissingValuesInternalAsync(object vals, object protected_codes)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _fill_missing_values) ---
            */
            return default;
        }

        protected async Task<AccountJournal> FillOnboardingDataInternalAsync(object dashboard_data)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _fill_onboarding_data) ---
            */
            return default;
        }

        protected async Task<AccountJournal> FillSalePurchaseDashboardDataInternalAsync(object dashboard_data)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _fill_sale_purchase_dashboard_data) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetAvailablePaymentMethodLinesInternalAsync(object payment_type)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_available_payment_method_lines) ---
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_journal.py, METHOD: _get_available_payment_method_lines) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetBankCashGraphDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _get_bank_cash_graph_data) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetBankStatementsAvailableSourcesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_bank_statements_available_sources) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetCheckPrintingLayoutsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_journal.py, METHOD: _get_check_printing_layouts) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetDefaultAccountDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_default_account_domain) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetDirectBankPaymentsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _get_direct_bank_payments) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetDraftSalesPurchasesQueryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _get_draft_sales_purchases_query) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetJournalBankAccountBalanceInternalAsync(object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journal_bank_account_balance) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetJournalDashboardBankRunningBalanceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _get_journal_dashboard_bank_running_balance) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetJournalDashboardDataBatchedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _get_journal_dashboard_data_batched) ---
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_journal.py, METHOD: _get_journal_dashboard_data_batched) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetJournalDashboardOutstandingPaymentsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _get_journal_dashboard_outstanding_payments) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetJournalInboundOutstandingPaymentAccountsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journal_inbound_outstanding_payment_accounts) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_journal.py, METHOD: _get_journal_inbound_outstanding_payment_accounts) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetJournalNotificationUnsubscribeScopeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journal_notification_unsubscribe_scope) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetJournalOutboundOutstandingPaymentAccountsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journal_outbound_outstanding_payment_accounts) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetJournalsPaymentMethodInformationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journals_payment_method_information) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetJsonActivityDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _get_json_activity_data) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetMoveActionContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _get_move_action_context) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetMovesToHashInternalAsync(object include_pre_last_hash, object early_stop)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _get_moves_to_hash) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountJournal> GetNextJournalDefaultCodeInternalAsync(object journal_type, object company, object cache, object protected_codes)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_next_journal_default_code) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetOpenSalePurchaseQueryInternalAsync(object journal_type)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _get_open_sale_purchase_query) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetSalePurchaseGraphDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _get_sale_purchase_graph_data) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetToCheckPaymentQueryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _get_to_check_payment_query) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GetToPaySelectInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _get_to_pay_select) ---
            */
            return default;
        }

        protected async Task<AccountJournal> GraphTitleAndKeyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _graph_title_and_key) ---
            */
            return default;
        }

        protected async Task<AccountJournal> InverseCheckNextNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_check_printing, FILE: account_journal.py, METHOD: _inverse_check_next_number) ---
            */
            return default;
        }

        protected async Task<AccountJournal> IsPaymentMethodAvailableInternalAsync(object payment_method_code, object complete_domain)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _is_payment_method_available) ---
            */
            return default;
        }

        protected async Task<AccountJournal> KanbanDashboardGraphInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _kanban_dashboard_graph) ---
            */
            return default;
        }

        protected async Task<AccountJournal> KanbanDashboardInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _kanban_dashboard) ---
            */
            return default;
        }

        protected async Task<AccountJournal> NotifyEinvoicesReceivedInternalAsync(object moves)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _notify_einvoices_received) ---
            */
            return default;
        }

        protected async Task<AccountJournal> NotifyInvoiceSubscribersInternalAsync(object invoice, object mail_params)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _notify_invoice_subscribers) ---
            */
            return default;
        }

        protected async Task<AccountJournal> OnchangeIncomingEinvoiceNotificationEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _onchange_incoming_einvoice_notification_email) ---
            */
            return default;
        }

        protected async Task<AccountJournal> OnchangeTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _onchange_type) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountJournal> PrepareCreditAccountValsInternalAsync(object company, object code, object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _prepare_credit_account_vals) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountJournal> PrepareLiquidityAccountValsInternalAsync(object company, object code, object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _prepare_liquidity_account_vals) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ProcessReferenceForSaleOrderInternalAsync(object order_reference)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _process_reference_for_sale_order) ---
            */
            return default;
        }

        protected async Task<AccountJournal> QueryHasSequenceHolesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _query_has_sequence_holes) ---
            */
            return default;
        }

        protected async Task<AccountJournal> SelectActionToOpenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _select_action_to_open) ---
            */
            return default;
        }

        protected async Task<AccountJournal> ShowSequenceHolesInternalAsync(object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _show_sequence_holes) ---
            */
            return default;
        }

        protected async Task<AccountJournal> TransformActivityDictInternalAsync(object activity_data)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal_dashboard.py, METHOD: _transform_activity_dict) ---
            */
            return default;
        }

        protected async Task<AccountJournal> UnlinkExceptLinkedToPaymentProviderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_journal.py, METHOD: _unlink_except_linked_to_payment_provider) ---
            */
            return default;
        }

        protected async Task<AccountJournal> UnlinkJournalExceptWithActivePaymentsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_journal.py, METHOD: _unlink_journal_except_with_active_payments) ---
            */
            return default;
        }

        protected async Task<AccountJournal> UnsubscribeInvoiceNotificationEmailInternalAsync(object email_to_remove)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _unsubscribe_invoice_notification_email) ---
            */
            return default;
        }

        private async Task<AccountJournal> _GetBankStatementsAvailableSourcesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: __get_bank_statements_available_sources) ---
            */
            return default;
        }
    }
}