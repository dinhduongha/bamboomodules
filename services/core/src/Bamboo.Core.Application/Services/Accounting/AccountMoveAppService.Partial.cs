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
    public partial class AccountMoveAppService
    {

        protected async Task<AccountMove> ActionInvoiceReadyToBeSentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _action_invoice_ready_to_be_sent) ---
            --- METHOD SOURCE (MODULE: sale, FILE: account_move.py, METHOD: _action_invoice_ready_to_be_sent) ---
            */
            return default;
        }

        protected async Task<AccountMove> AddPurchaseOrderLinesInternalAsync(object purchase_order_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: _add_purchase_order_lines) ---
            */
            return default;
        }

        protected async Task<AccountMove> AffectTaxReportInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _affect_tax_report) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> ApplyDeltaRecurringEntriesInternalAsync(object date, object date_origin, object period)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _apply_delta_recurring_entries) ---
            */
            return default;
        }

        protected async Task<AccountMove> AutoInitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _auto_init) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: account_move.py, METHOD: _auto_init) ---
            */
            return default;
        }

        protected async Task<AccountMove> AutopostBillInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _autopost_bill) ---
            */
            return default;
        }

        protected async Task<AccountMove> AutopostDraftEntriesInternalAsync(object batch_size)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _autopost_draft_entries) ---
            */
            return default;
        }

        protected async Task<AccountMove> BuildCreditWarningMessageInternalAsync(object record, object current_amount, object exclude_current, object exclude_amount)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _build_credit_warning_message) ---
            */
            return default;
        }

        protected async Task<AccountMove> CalculateHashesInternalAsync(object previous_hash)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _calculate_hashes) ---
            */
            return default;
        }

        protected async Task<AccountMove> CanBeUnlinkedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _can_be_unlinked) ---
            */
            return default;
        }

        protected async Task<AccountMove> CanCommitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _can_commit) ---
            */
            return default;
        }

        protected async Task<AccountMove> CanForceCancelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _can_force_cancel) ---
            */
            return default;
        }

        protected async Task<AccountMove> CheckBalancedInternalAsync(object container)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_balanced) ---
            */
            return default;
        }

        protected async Task<AccountMove> CheckDraftableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_draftable) ---
            */
            return default;
        }

        protected async Task<AccountMove> CheckEdiDocumentsForResetToDraftInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: _check_edi_documents_for_reset_to_draft) ---
            */
            return default;
        }

        protected async Task<AccountMove> CheckExpenseIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py, METHOD: _check_expense_ids) ---
            */
            return default;
        }

        protected async Task<AccountMove> CheckFiscalLockDatesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_fiscal_lock_dates) ---
            */
            return default;
        }

        protected async Task<AccountMove> CheckInvoiceCurrencyRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_invoice_currency_rate) ---
            */
            return default;
        }

        protected async Task<AccountMove> CheckJournalMoveTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_journal_move_type) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py, METHOD: _check_journal_move_type) ---
            */
            return default;
        }

        protected async Task<AccountMove> CheckTotalAmountInternalAsync(object amount_total)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_total_amount) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> CleanupWriteOrmValuesInternalAsync(object record, object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _cleanup_write_orm_values) ---
            */
            return default;
        }

        protected async Task<AccountMove> CollectTaxCashBasisValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _collect_tax_cash_basis_values) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAbnormalWarningsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_abnormal_warnings) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAccessUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_access_url) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAdjustingEntriesCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_adjusting_entries_count) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAdjustingEntryOriginLabelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_adjusting_entry_origin_label) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAdjustingEntryOriginMovesCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_adjusting_entry_origin_moves_count) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAlertsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_alerts) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAlwaysTaxExigibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_always_tax_exigible) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py, METHOD: _compute_always_tax_exigible) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_amount) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py, METHOD: _compute_amount) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAmountPaidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_move.py, METHOD: _compute_amount_paid) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAmountTotalWordsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_amount_total_words) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAuthorizedTransactionIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_move.py, METHOD: _compute_authorized_transaction_ids) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeAutoPostUntilInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_auto_post_until) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeBankPartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_bank_partner_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeCheckedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_checked) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeCommercialPartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_commercial_partner_id) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py, METHOD: _compute_commercial_partner_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_date) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeDebitCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_debit_note, FILE: account_move.py, METHOD: _compute_debit_count) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeDeliveryDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_delivery_date) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py, METHOD: _compute_delivery_date) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeDirectionSignInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_direction_sign) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeDisplayInactiveCurrencyWarningInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_inactive_currency_warning) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeDisplayLinkQrCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_link_qr_code) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeDisplayQrCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_qr_code) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeDisplaySendButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_send_button) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_move.py, METHOD: _compute_display_send_button) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeDuplicatedRefIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_duplicated_ref_ids) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeEdiErrorCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: _compute_edi_error_count) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeEdiErrorMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: _compute_edi_error_message) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeEdiShowAbandonCancelButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: _compute_edi_show_abandon_cancel_button) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeEdiShowCancelButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: _compute_edi_show_cancel_button) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeEdiShowForceCancelButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: _compute_edi_show_force_cancel_button) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeEdiStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: _compute_edi_state) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeEdiWebServicesToProcessInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: _compute_edi_web_services_to_process) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeExpectedCurrencyRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_expected_currency_rate) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeFilenameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py, METHOD: _compute_filename) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeFiscalPositionIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_fiscal_position_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeHasReconciledEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_has_reconciled_entries) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeHidePostButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_hide_post_button) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeHighestNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_highest_name) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeHighlightSendButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_highlight_send_button) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeIncotermInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_incoterm) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeIncotermLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_incoterm_location) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: account_invoice.py, METHOD: _compute_incoterm_location) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py, METHOD: _compute_incoterm_location) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeInvoiceCurrencyRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_currency_rate) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeInvoiceDateDueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_date_due) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeInvoiceDefaultSalePersonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_default_sale_person) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeInvoiceFilterTypeDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_filter_type_domain) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeInvoiceHasOutstandingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_has_outstanding) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeInvoiceIncotermPlaceholderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_incoterm_placeholder) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeInvoicePartnerDisplayInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_partner_display_info) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeInvoicePaymentTermIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_payment_term_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeIsBeingSentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_is_being_sent) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeIsPurchaseMatchedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: _compute_is_purchase_matched) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeIsSaleInstalledInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_is_sale_installed) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeIsStornoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_is_storno) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py, METHOD: _compute_is_storno) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeJournalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_journal_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeLandedCostsVisibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py, METHOD: _compute_landed_costs_visible) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeLinkedAttachmentIdInternalAsync(object attachment_field, object binary_field)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_linked_attachment_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeMadeSequenceGapInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_made_sequence_gap) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_name) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeNamePlaceholderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_name_placeholder) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeNarrationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_narration) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeNbExpensesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py, METHOD: _compute_nb_expenses) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeNeedCancelRequestInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_need_cancel_request) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeNeededTermsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_needed_terms) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py, METHOD: _compute_needed_terms) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeNextPaymentDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_next_payment_date) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeNoFollowupInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_no_followup) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeOriginPoCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: _compute_origin_po_count) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeOriginPosCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py, METHOD: _compute_origin_pos_count) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeOriginSoCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: account_move.py, METHOD: _compute_origin_so_count) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputePartnerBankIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_partner_bank_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputePartnerCreditWarningInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_partner_credit_warning) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputePartnerShippingIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_partner_shipping_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputePaymentCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payment_count) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputePaymentReferenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payment_reference) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputePaymentStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payment_state) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputePaymentTermDetailsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payment_term_details) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputePaymentsWidgetReconciledInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payments_widget_reconciled_info) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py, METHOD: _compute_payments_widget_reconciled_info) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputePaymentsWidgetToReconcileInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payments_widget_to_reconcile_info) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputePeppolMoveStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_move.py, METHOD: _compute_peppol_move_state) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputePreferredPaymentMethodLineIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_preferred_payment_method_line_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputePurchaseOrderNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: _compute_purchase_order_name) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputePurchaseWarningTextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: _compute_purchase_warning_text) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeQuickEditModeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_quick_edit_mode) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeQuickEncodingValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_quick_encoding_vals) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeReconciledPaymentIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_reconciled_payment_ids) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeSaleWarningTextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: account_move.py, METHOD: _compute_sale_warning_text) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeSecuredInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_secured) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeShowDeliveryDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_delivery_date) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeShowJournalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_journal) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeShowPaymentTermDetailsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_payment_term_details) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeShowResetToDraftButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_reset_to_draft_button) ---
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: _compute_show_reset_to_draft_button) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeShowTaxableSupplyDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_taxable_supply_date) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeStatusInPaymentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_status_in_payment) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeSuitableJournalIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_suitable_journal_ids) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTaxCountryCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_tax_country_code) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTaxCountryIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_tax_country_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTaxLockDateMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_tax_lock_date_message) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTaxTotalsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_tax_totals) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py, METHOD: _compute_tax_totals) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTaxableSupplyDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_taxable_supply_date) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTaxableSupplyDatePlaceholderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_taxable_supply_date_placeholder) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTaxesLegalNotesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_taxes_legal_notes) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTeamIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: account_move.py, METHOD: _compute_team_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTimesheetCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move.py, METHOD: _compute_timesheet_count) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTimesheetTotalDurationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move.py, METHOD: _compute_timesheet_total_duration) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTransactionCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_move.py, METHOD: _compute_transaction_count) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeTypeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_type_name) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeWebsiteIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: account_move.py, METHOD: _compute_website_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> ComputeWipProductionCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: account_move.py, METHOD: _compute_wip_production_count) ---
            */
            return default;
        }

        protected async Task<AccountMove> ConditionalAddToComputeInternalAsync(object fname, object condition)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _conditional_add_to_compute) ---
            */
            return default;
        }

        protected async Task<AccountMove> CopyRecurringEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _copy_recurring_entries) ---
            */
            return default;
        }

        protected async Task<AccountMove> CreationMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _creation_message) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py, METHOD: _creation_message) ---
            */
            return default;
        }

        protected async Task<AccountMove> CreationSubtypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _creation_subtype) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> CronAccountMoveSendInternalAsync(object job_count)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _cron_account_move_send) ---
            */
            return default;
        }

        protected async Task<AccountMove> DefaultOrderLineValuesInternalAsync(object child_field)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _default_order_line_values) ---
            */
            return default;
        }

        protected async Task<AccountMove> DetachAttachmentsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _detach_attachments) ---
            */
            return default;
        }

        protected async Task<AccountMove> DisableDiscountPrecisionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _disable_discount_precision) ---
            */
            return default;
        }

        protected async Task<AccountMove> DisableRecursionInternalAsync(object container, object key, object @default, object target)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _disable_recursion) ---
            */
            return default;
        }

        protected async Task<AccountMove> EarlyPaymentDiscountMoveTypesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _early_payment_discount_move_types) ---
            */
            return default;
        }

        protected async Task<AccountMove> EdiAllowButtonDraftInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: _edi_allow_button_draft) ---
            */
            return default;
        }

        protected async Task<AccountMove> ExtendWithAttachmentsInternalAsync(object files_data, object @new)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _extend_with_attachments) ---
            */
            return default;
        }

        protected async Task<AccountMove> FetchDuplicateReferenceInternalAsync(object matching_states)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _fetch_duplicate_reference) ---
            */
            return default;
        }

        protected async Task<object> FieldToSqlInternalAsync(string @alias, string fname, object query)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _field_to_sql) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> FieldWillChangeInternalAsync(object record, object vals, object field_name)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _field_will_change) ---
            */
            return default;
        }

        protected async Task<AccountMove> FindAndSetPurchaseOrdersInternalAsync(object po_references, Guid partner_id, object amount_total, object from_ocr, object timeout)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _find_and_set_purchase_orders) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: _find_and_set_purchase_orders) ---
            */
            return default;
        }

        protected async Task<AccountMove> FindMatchingPoAndInvLinesInternalAsync(object po_lines, object inv_lines, object timeout)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: _find_matching_po_and_inv_lines) ---
            */
            return default;
        }

        protected async Task<AccountMove> FindMatchingSubsetPoLinesInternalAsync(object po_lines_with_amount, object goal_total, object timeout)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: _find_matching_subset_po_lines) ---
            */
            return default;
        }

        protected async Task<AccountMove> GenerateAndSendInternalAsync(object force_synchronous, object allow_fallback_pdf)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _generate_and_send) ---
            */
            return default;
        }

        protected async Task<AccountMove> GeneratePortalPaymentQrInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _generate_portal_payment_qr) ---
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_move.py, METHOD: _generate_portal_payment_qr) ---
            */
            return default;
        }

        protected async Task<AccountMove> GenerateQrCodeInternalAsync(object silent_errors)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _generate_qr_code) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetAccountingDateInternalAsync(object invoice_date, object has_tax, object lock_dates)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_accounting_date) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetAccountingDateSourceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_accounting_date_source) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetActionAddFromCatalogExtraContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetActionPerItemInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: account_move.py, METHOD: _get_action_per_item) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetActionWithBaseDocumentLayoutConfiguratorInternalAsync(object report_action)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_action_with_base_document_layout_configurator) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetAlertsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_alerts) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetAllReconciledInvoicePartialsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_all_reconciled_invoice_partials) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetAngloSaxonPriceCtxInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py, METHOD: _get_anglo_saxon_price_ctx) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: account_move.py, METHOD: _get_anglo_saxon_price_ctx) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetAutomaticBalancingAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_automatic_balancing_account) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetAvailableActionReportsInternalAsync(object is_invoice_report)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_available_action_reports) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetAvailableInvoiceTemplatePdfReportIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_available_invoice_template_pdf_report_ids) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetChainInfoInternalAsync(object force_hash, object include_pre_last_hash, object early_stop)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_chain_info) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetChainsToHashInternalAsync(object force_hash, object raise_if_gap, object raise_if_no_document, object include_pre_last_hash, object early_stop)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_chains_to_hash) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetCopyMessageContentInternalAsync(object @default)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_copy_message_content) ---
            --- METHOD SOURCE (MODULE: account_debit_note, FILE: account_move.py, METHOD: _get_copy_message_content) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetDefaultPaymentLinkValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_move.py, METHOD: _get_default_payment_link_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> GetDefaultReadFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_default_read_fields) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetDiscountAllocationAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_discount_allocation_account) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetEdiAttachmentInternalAsync(object edi_format)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: _get_edi_attachment) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetEdiCreationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_edi_creation) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetEdiDecoderInternalAsync(object file_data, object @new)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py, METHOD: _get_edi_decoder) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetEdiDocumentInternalAsync(object edi_format)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: _get_edi_document) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetFieldsToCopyRecurringEntriesInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_fields_to_copy_recurring_entries) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetFieldsToDetachInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_fields_to_detach) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py, METHOD: _get_fields_to_detach) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> GetFrequentAccountAndTaxesInternalAsync(Guid company_id, Guid partner_id, object move_type)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_frequent_account_and_taxes) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetImportFileTypeInternalAsync(object file_data)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py, METHOD: _get_import_file_type) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetInstallmentsDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_installments_data) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetIntegrityHashFieldsAndSubfieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_integrity_hash_fields_and_subfields) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetIntegrityHashFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_integrity_hash_fields) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceComputedReferenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_computed_reference) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> GetInvoiceCounterpartAmlsForEarlyPaymentDiscountInternalAsync(object aml_values_list, object open_balance)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_counterpart_amls_for_early_payment_discount) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceCounterpartAmlsForEarlyPaymentDiscountPerPaymentTermLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_counterpart_amls_for_early_payment_discount_per_payment_term_line) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceCurrencyRateDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_currency_rate_date) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> GetInvoiceFilterTypeDomainInternalAsync(object move_type)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_filter_type_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> GetInvoiceInPaymentStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_in_payment_state) ---
            --- METHOD SOURCE (MODULE: om_account_accountant, FILE: account_move.py, METHOD: _get_invoice_in_payment_state) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceLegalDocumentsAllInternalAsync(object allow_fallback)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_legal_documents_all) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceLegalDocumentsInternalAsync(object filetype, object allow_fallback)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_legal_documents) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py, METHOD: _get_invoice_legal_documents) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceNextPaymentValuesInternalAsync(object custom_amount)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_next_payment_values) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoicePdfProformaInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_pdf_proforma) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoicePortalExtraValuesInternalAsync(object custom_amount)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_portal_extra_values) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceProformaPdfReportFilenameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_proforma_pdf_report_filename) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceReferenceEuroInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_euro_invoice) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceReferenceEuroPartnerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_euro_partner) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceReferenceNumberInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_number_invoice) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceReferenceNumberPartnerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_number_partner) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceReferenceOdooInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_odoo_invoice) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceReferenceOdooPartnerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_odoo_partner) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoiceReportFilenameInternalAsync(object extension, object report)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_report_filename) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetInvoicedLotValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py, METHOD: _get_invoiced_lot_values) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py, METHOD: _get_invoiced_lot_values) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: account_move.py, METHOD: _get_invoiced_lot_values) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetLastSequenceDomainInternalAsync(object relaxed)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_last_sequence_domain) ---
            --- METHOD SOURCE (MODULE: account_debit_note, FILE: account_move.py, METHOD: _get_last_sequence_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> GetLineValsListInternalAsync(object lines_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py, METHOD: _get_line_vals_list) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetLinesOnchangeCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_lines_onchange_currency) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: account_move.py, METHOD: _get_lines_onchange_currency) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetLockDateMessageInternalAsync(object invoice_date, object has_tax)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_lock_date_message) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetMailTemplateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_mail_template) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetMailThreadDataAttachmentsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_mail_thread_data_attachments) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetMoveDisplayNameInternalAsync(object show_ref)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_move_display_name) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> GetMoveHashDomainInternalAsync(object common_domain, object force_hash)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_move_hash_domain) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetMoveLinesToReportInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_move_lines_to_report) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetMoveZipExportDocsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_move_zip_export_docs) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetMovesRequiringConfirmationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_moves_requiring_confirmation) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetNameInvoiceReportInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_name_invoice_report) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetOnlinePaymentErrorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_move.py, METHOD: _get_online_payment_error) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetParentFieldOnChildModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_parent_field_on_child_model) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetPartnerCreditWarningExcludeAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_partner_credit_warning_exclude_amount) ---
            --- METHOD SOURCE (MODULE: sale, FILE: account_move.py, METHOD: _get_partner_credit_warning_exclude_amount) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetPortalPaymentLinkInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_portal_payment_link) ---
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_move.py, METHOD: _get_portal_payment_link) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetProductCatalogDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_product_catalog_domain) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetProductCatalogOrderDataInternalAsync(object products)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_product_catalog_order_data) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetProductCatalogRecordLinesInternalAsync(List<Guid> product_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_product_catalog_record_lines) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetProductPriceAndDataInternalAsync(object product)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_product_price_and_data) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetProtectedValsInternalAsync(object vals, object records)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_protected_vals) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py, METHOD: _get_protected_vals) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetQuickEditSuggestionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_quick_edit_suggestions) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetRangeDatesInternalAsync(object order)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move.py, METHOD: _get_range_dates) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetReconciledAmlsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_amls) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetReconciledInvoicesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_invoices) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetReconciledInvoicesPartialsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_invoices_partials) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetReconciledPaymentsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_payments) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetReconciledStatementLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_statement_lines) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetRelatedStockMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: account_move.py, METHOD: _get_related_stock_moves) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetReportBaseFilenameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_report_base_filename) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetRoundedBaseAndTaxLinesInternalAsync(object round_from_tax_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_rounded_base_and_tax_lines) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetSaleOrderInvoicedAmountInternalAsync(object order)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: account_move.py, METHOD: _get_sale_order_invoiced_amount) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetSequenceDateRangeInternalAsync(object reset)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_sequence_date_range) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetSpecificTaxInternalAsync(object name, object amount_type, object amount, object tax_type)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py, METHOD: _get_specific_tax) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetStartingSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_starting_sequence) ---
            --- METHOD SOURCE (MODULE: account_debit_note, FILE: account_move.py, METHOD: _get_starting_sequence) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> GetSuitableJournalIdsInternalAsync(object move_type, object company)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_suitable_journal_ids) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetSyncStackInternalAsync(object container)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_sync_stack) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetUnbalancedMovesInternalAsync(object container)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_unbalanced_moves) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetUnlinkLoggerMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_unlink_logger_message) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetValidJournalTypesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_valid_journal_types) ---
            */
            return default;
        }

        protected async Task<AccountMove> GetViolatedLockDatesInternalAsync(object invoice_date, object has_tax)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_violated_lock_dates) ---
            */
            return default;
        }

        protected async Task<AccountMove> HasToBePaidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_move.py, METHOD: _has_to_be_paid) ---
            */
            return default;
        }

        protected async Task<AccountMove> HashMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _hash_moves) ---
            */
            return default;
        }

        protected async Task<AccountMove> InverseAmountTotalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_amount_total) ---
            */
            return default;
        }

        protected async Task<AccountMove> InverseCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_company_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> InverseCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_currency_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> InverseInvoicePaymentTermIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_invoice_payment_term_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> InverseJournalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_journal_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> InverseNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_name) ---
            */
            return default;
        }

        protected async Task<AccountMove> InverseNoFollowupInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_no_followup) ---
            */
            return default;
        }

        protected async Task<AccountMove> InversePartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_partner_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> InversePaymentReferenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_payment_reference) ---
            */
            return default;
        }

        protected async Task<AccountMove> InverseTaxTotalsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_tax_totals) ---
            */
            return default;
        }

        protected async Task<AccountMove> InvoicePaidHookInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _invoice_paid_hook) ---
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: account_move.py, METHOD: _invoice_paid_hook) ---
            --- METHOD SOURCE (MODULE: sale, FILE: account_move.py, METHOD: _invoice_paid_hook) ---
            */
            return default;
        }

        protected async Task<AccountMove> IsActionReportAvailableInternalAsync(object action_report, object is_invoice_report)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_action_report_available) ---
            */
            return default;
        }

        protected async Task<AccountMove> IsDownpaymentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_downpayment) ---
            --- METHOD SOURCE (MODULE: sale, FILE: account_move.py, METHOD: _is_downpayment) ---
            */
            return default;
        }

        protected async Task<AccountMove> IsEligibleForEarlyPaymentDiscountInternalAsync(object currency, object reference_date)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_eligible_for_early_payment_discount) ---
            */
            return default;
        }

        protected async Task<AccountMove> IsExportableAsSelfInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py, METHOD: _is_exportable_as_self_invoice) ---
            */
            return default;
        }

        protected async Task<AccountMove> IsLineValidForSectionLineCountInternalAsync(object line)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_line_valid_for_section_line_count) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> IsMoveRestrictedInternalAsync(object move, object force_hash)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_move_restricted) ---
            */
            return default;
        }

        protected async Task<AccountMove> IsProtectedByAuditTrailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_protected_by_audit_trail) ---
            */
            return default;
        }

        protected async Task<AccountMove> IsReadonlyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_readonly) ---
            */
            return default;
        }

        protected async Task<AccountMove> IsReadyToBeSentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_ready_to_be_sent) ---
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: _is_ready_to_be_sent) ---
            */
            return default;
        }

        protected async Task<AccountMove> IsUserAbleToReviewInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_user_able_to_review) ---
            */
            return default;
        }

        protected async Task<AccountMove> LinkBillOriginToPurchaseOrdersInternalAsync(object timeout)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _link_bill_origin_to_purchase_orders) ---
            */
            return default;
        }

        protected async Task<AccountMove> LinkTimesheetsToInvoiceInternalAsync(object start_date, object end_date)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move.py, METHOD: _link_timesheets_to_invoice) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<AccountMove> MailingGetDefaultDomainInternalAsync(object mailing)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _mailing_get_default_domain) ---
            */
            return default;
        }

        protected async Task<AccountMove> MatchPurchaseOrdersInternalAsync(object po_references, Guid partner_id, object amount_total, object from_ocr, object timeout)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: _match_purchase_orders) ---
            */
            return default;
        }

        protected async Task<AccountMove> MessagePostAfterHookInternalAsync(object new_message, object message_values)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _message_post_after_hook) ---
            */
            return default;
        }

        protected async Task<AccountMove> MessageSetMainAttachmentIdInternalAsync(object attachments, object force, object filter_xml)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: _message_set_main_attachment_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> MoveDictToPreviewValsInternalAsync(object move_vals, Guid currency_id)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _move_dict_to_preview_vals) ---
            */
            return default;
        }

        protected async Task<AccountMove> MustCheckConstrainsDateSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _must_check_constrains_date_sequence) ---
            */
            return default;
        }

        protected async Task<AccountMove> NeedCancelRequestInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _need_cancel_request) ---
            */
            return default;
        }

        protected async Task<AccountMove> NeedUblCiiXmlInternalAsync(object ubl_cii_format)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py, METHOD: _need_ubl_cii_xml) ---
            */
            return default;
        }

        protected async Task<AccountMove> NotifyByEmailPrepareRenderingContextInternalAsync(object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_move.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            */
            return default;
        }

        protected async Task<AccountMove> NotifyGetRecipientsGroupsInternalAsync(object message, object model_description, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        protected async Task<AccountMove> OnchangeDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_date) ---
            */
            return default;
        }

        protected async Task<AccountMove> OnchangeFposIdShowUpdateFposInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_fpos_id_show_update_fpos) ---
            */
            return default;
        }

        protected async Task<AccountMove> OnchangeInvoiceCashRoundingIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_invoice_cash_rounding_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> OnchangeInvoiceVendorBillInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_invoice_vendor_bill) ---
            */
            return default;
        }

        protected async Task<AccountMove> OnchangeJournalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_journal_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> OnchangeNameWarningInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_name_warning) ---
            */
            return default;
        }

        protected async Task<AccountMove> OnchangePartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_partner_id) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: _onchange_partner_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> OnchangePurchaseAutoCompleteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: _onchange_purchase_auto_complete) ---
            */
            return default;
        }

        protected async Task<AccountMove> OnchangeQuickEditLineIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_quick_edit_line_ids) ---
            */
            return default;
        }

        protected async Task<AccountMove> OnchangeQuickEditTotalAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_quick_edit_total_amount) ---
            */
            return default;
        }

        protected async Task<AccountMove> PostInternalAsync(object soft)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _post) ---
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: _post) ---
            --- METHOD SOURCE (MODULE: account_fleet, FILE: account_move.py, METHOD: _post) ---
            --- METHOD SOURCE (MODULE: product_email_template, FILE: account_move.py, METHOD: _post) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: account_invoice.py, METHOD: _post) ---
            --- METHOD SOURCE (MODULE: sale, FILE: account_move.py, METHOD: _post) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: account_move.py, METHOD: _post) ---
            */
            return default;
        }

        protected async Task<AccountMove> PrepareCashRoundingBaseLineForTaxesComputationInternalAsync(object cash_rounding_line)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_cash_rounding_base_line_for_taxes_computation) ---
            */
            return default;
        }

        protected async Task<AccountMove> PrepareEdiTaxDetailsInternalAsync(object filter_to_apply, object filter_invl_to_apply, object grouping_key_generator)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: _prepare_edi_tax_details) ---
            */
            return default;
        }

        protected async Task<AccountMove> PrepareEdiValsToExportInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_edi_vals_to_export) ---
            */
            return default;
        }

        protected async Task<AccountMove> PrepareEpdBaseLineForTaxesComputationInternalAsync(object epd_line)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_epd_base_line_for_taxes_computation) ---
            */
            return default;
        }

        protected async Task<AccountMove> PrepareEpdBaseLinesForTaxesComputationFromBaseLinesInternalAsync(object base_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_epd_base_lines_for_taxes_computation_from_base_lines) ---
            */
            return default;
        }

        protected async Task<AccountMove> PrepareInvoiceAggregatedTaxesInternalAsync(object filter_invl_to_apply, object filter_tax_values_to_apply, object grouping_key_generator, object round_from_tax_lines, object postfix_function)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_invoice_aggregated_taxes) ---
            */
            return default;
        }

        protected async Task<AccountMove> PrepareNonDeductibleBaseLineForTaxesComputationInternalAsync(object non_deductible_line)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_non_deductible_base_line_for_taxes_computation) ---
            */
            return default;
        }

        protected async Task<AccountMove> PrepareNonDeductibleBaseLinesForTaxesComputationFromBaseLinesInternalAsync(object base_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_non_deductible_base_lines_for_taxes_computation_from_base_lines) ---
            */
            return default;
        }

        protected async Task<AccountMove> PrepareProductBaseLineForTaxesComputationInternalAsync(object product_line)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_product_base_line_for_taxes_computation) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py, METHOD: _prepare_product_base_line_for_taxes_computation) ---
            */
            return default;
        }

        protected async Task<AccountMove> PrepareTaxLineForTaxesComputationInternalAsync(object tax_line)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_tax_line_for_taxes_computation) ---
            */
            return default;
        }

        protected async Task<AccountMove> PrepareTaxLinesForTaxesComputationInternalAsync(object tax_amls, object round_from_tax_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_tax_lines_for_taxes_computation) ---
            */
            return default;
        }

        protected async Task<AccountMove> ProcessAttachmentsForTemplatePostInternalAsync(object mail_template)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: _process_attachments_for_template_post) ---
            */
            return default;
        }

        protected async Task<AccountMove> QuickEditModeSuggestInvoiceDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _quick_edit_mode_suggest_invoice_date) ---
            */
            return default;
        }

        protected async Task<AccountMove> ReasonCannotDecodeHasInvoiceLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _reason_cannot_decode_has_invoice_lines) ---
            */
            return default;
        }

        protected async Task<AccountMove> RecomputeCashRoundingLinesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _recompute_cash_rounding_lines) ---
            */
            return default;
        }

        protected async Task<AccountMove> ReconcileReversedMovesInternalAsync(object reverse_moves, object move_reverse_cancel)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _reconcile_reversed_moves) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> RefundCleanupLinesInternalAsync(object lines)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py, METHOD: _refund_cleanup_lines) ---
            */
            return default;
        }

        protected async Task<AccountMove> RefundsOriginRequiredInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _refunds_origin_required) ---
            */
            return default;
        }

        protected async Task<AccountMove> RequireBillDateForAutopostInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _require_bill_date_for_autopost) ---
            */
            return default;
        }

        protected async Task<AccountMove> RetryEdiDocumentsErrorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: _retry_edi_documents_error) ---
            */
            return default;
        }

        protected async Task<AccountMove> ReverseMovesInternalAsync(object default_values_list, object cancel)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _reverse_moves) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py, METHOD: _reverse_moves) ---
            --- METHOD SOURCE (MODULE: sale, FILE: account_move.py, METHOD: _reverse_moves) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: account_move.py, METHOD: _reverse_moves) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> RoutingCheckRouteInternalAsync(object message, object message_dict, object route, object raise_exception)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _routing_check_route) ---
            */
            return default;
        }

        protected async Task<AccountMove> SanitizeValsInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sanitize_vals) ---
            */
            return default;
        }

        protected async Task<AccountMove> SearchDefaultJournalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_default_journal) ---
            */
            return default;
        }

        protected async Task<AccountMove> SearchJournalGroupIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_journal_group_id) ---
            */
            return default;
        }

        protected async Task<AccountMove> SearchMoveSentValuesInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_move_sent_values) ---
            */
            return default;
        }

        protected async Task<AccountMove> SearchNextPaymentDateInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_next_payment_date) ---
            */
            return default;
        }

        protected async Task<AccountMove> SearchReconciledPaymentIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_reconciled_payment_ids) ---
            */
            return default;
        }

        protected async Task<AccountMove> SearchSecuredInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_secured) ---
            */
            return default;
        }

        protected async Task<AccountMove> SendOnlyWhenReadyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _send_only_when_ready) ---
            */
            return default;
        }

        protected async Task<AccountMove> SequenceFixedRegexInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_fixed_regex) ---
            */
            return default;
        }

        protected async Task<AccountMove> SequenceMonthlyRegexInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_monthly_regex) ---
            */
            return default;
        }

        protected async Task<AccountMove> SequenceYearRangeMonthlyRegexInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_year_range_monthly_regex) ---
            */
            return default;
        }

        protected async Task<AccountMove> SequenceYearRangeRegexInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_year_range_regex) ---
            */
            return default;
        }

        protected async Task<AccountMove> SequenceYearlyRegexInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_yearly_regex) ---
            */
            return default;
        }

        protected async Task<AccountMove> SetNextMadeSequenceGapInternalAsync(bool made_gap)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _set_next_made_sequence_gap) ---
            */
            return default;
        }

        protected async Task<AccountMove> SetPurchaseOrdersInternalAsync(object purchase_orders, object force_write)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: _set_purchase_orders) ---
            */
            return default;
        }

        protected async Task<AccountMove> SetReversedEntryInternalAsync(object credit_note)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _set_reversed_entry) ---
            */
            return default;
        }

        protected async Task<AccountMove> ShowAutopostBillsWizardInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _show_autopost_bills_wizard) ---
            */
            return default;
        }

        protected async Task<AccountMove> StockAccountGetLastStepStockMovesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py, METHOD: _stock_account_get_last_step_stock_moves) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: account_invoice.py, METHOD: _stock_account_get_last_step_stock_moves) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: account_move.py, METHOD: _stock_account_get_last_step_stock_moves) ---
            */
            return default;
        }

        protected async Task<AccountMove> StockAccountPrepareAngloSaxonInLinesValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: account_invoice.py, METHOD: _stock_account_prepare_anglo_saxon_in_lines_vals) ---
            */
            return default;
        }

        protected async Task<AccountMove> StockAccountPrepareRealtimeOutLinesValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: account_move.py, METHOD: _stock_account_prepare_realtime_out_lines_vals) ---
            */
            return default;
        }

        protected async Task<AccountMove> StolenMoveInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _stolen_move) ---
            */
            return default;
        }

        protected async Task<AccountMove> SyncDynamicLineInternalAsync(object existing_key_fname, object needed_vals_fname, object needed_dirty_fname, object line_type, object container)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_dynamic_line) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> SyncDynamicLineNeededValuesInternalAsync(object values_list)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_dynamic_line_needed_values) ---
            */
            return default;
        }

        protected async Task<AccountMove> SyncDynamicLinesInternalAsync(object container)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_dynamic_lines) ---
            */
            return default;
        }

        protected async Task<AccountMove> SyncInvoiceInternalAsync(object container)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_invoice) ---
            */
            return default;
        }

        protected async Task<AccountMove> SyncNonDeductibleBaseLinesInternalAsync(object container)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_non_deductible_base_lines) ---
            */
            return default;
        }

        protected async Task<AccountMove> SyncRoundingLinesInternalAsync(object container)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_rounding_lines) ---
            */
            return default;
        }

        protected async Task<AccountMove> SyncTaxLinesInternalAsync(object container)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_tax_lines) ---
            */
            return default;
        }

        protected async Task<AccountMove> SyncUnbalancedLinesInternalAsync(object container)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_unbalanced_lines) ---
            */
            return default;
        }

        protected async Task<AccountMove> SynchronizeBusinessModelsInternalAsync(object changed_fields)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _synchronize_business_models) ---
            */
            return default;
        }

        protected async Task<AccountMove> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<AccountMove> UblParseAttachedDocumentInternalAsync(object tree)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py, METHOD: _ubl_parse_attached_document) ---
            */
            return default;
        }

        protected async Task<AccountMove> UnlinkAccountAuditTrailExceptOncePostInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _unlink_account_audit_trail_except_once_post) ---
            */
            return default;
        }

        protected async Task<AccountMove> UnlinkForbidPartsOfChainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _unlink_forbid_parts_of_chain) ---
            */
            return default;
        }

        protected async Task<AccountMove> UnlinkOrReverseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _unlink_or_reverse) ---
            */
            return default;
        }

        protected async Task<AccountMove> UnwrapAttachmentInternalAsync(object file_data, object recurse)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py, METHOD: _unwrap_attachment) ---
            */
            return default;
        }

        protected async Task<AccountMove> UpdateOrderLineInfoInternalAsync(Guid product_id, object quantity)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _update_order_line_info) ---
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py, METHOD: _update_order_line_info) ---
            */
            return default;
        }

        protected async Task<AccountMove> ValidateTaxesCountryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _validate_taxes_country) ---
            */
            return default;
        }
    }
}