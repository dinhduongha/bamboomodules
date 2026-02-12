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
    [Module("mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public partial class MailAliasMixinOptionalAppService : ApplicationService, IMailAliasMixinOptionalAppService
    {

        public MailAliasMixinOptionalAppService() 
        {

        }

        public async Task<TEntity> ActionConfigureBankJournalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: action_configure_bank_journal) ---
            */
            return default;
        }

        public async Task<TEntity> AliasFilterFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values, object filters) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py, METHOD: _alias_filter_fields) ---
            */
            return default;
        }

        public async Task<TEntity> AliasGetAliasDomainIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py, METHOD: _alias_get_alias_domain_id) ---
            */
            return default;
        }

        public async Task<TEntity> AliasGetCreationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _alias_get_creation_values) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py, METHOD: _alias_get_creation_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AliasPrepareAliasNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object alias_name, object name, object code, object jtype, object company) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _alias_prepare_alias_name) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonFetchInEinvoicesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: button_fetch_in_einvoices) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonRefreshOutEinvoicesStatusAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: button_refresh_out_einvoices_status) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonUnsubscribeFromInvoiceNotificationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: button_unsubscribe_from_invoice_notifications) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAutoPostDraftEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_auto_post_draft_entries) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBankAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_bank_account) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCompanyConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_company_consistency) ---
            */
            return default;
        }

        public async Task<TEntity> CheckIncomingEinvoiceNotificationEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_incoming_einvoice_notification_email) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPaymentMethodLineIdsMultiplicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_payment_method_line_ids_multiplicity) ---
            */
            return default;
        }

        public async Task<TEntity> CheckTypeDefaultAccountIdTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_type_default_account_id_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_accounting_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAliasEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py, METHOD: _compute_alias_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailableInvoiceTemplatePdfReportIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_available_invoice_template_pdf_report_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePaymentMethodIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_available_payment_method_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDefaultAccountTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_default_account_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayAliasFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_display_alias_fields) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasInvalidStatementsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_has_invalid_statements) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInboundPaymentMethodLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_inbound_payment_method_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIncomingEinvoiceNotificationEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_incoming_einvoice_notification_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNamePlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_name_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOutboundPaymentMethodLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_outbound_payment_method_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_payment_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRefundSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_refund_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSelectedPaymentMethodCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_selected_payment_method_codes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowFetchInEinvoicesButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_show_fetch_in_einvoices_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowRefreshOutEinvoicesStatusButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_show_refresh_out_einvoices_status_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSuspenseAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_suspense_account_id) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py, METHOD: create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateDefaultAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object journal_type, object vals) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _create_default_account) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDocumentFromAttachmentAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: create_document_from_attachment) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDocumentFromAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _create_document_from_attachment) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultDisplayInvoiceTemplatePdfReportIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _default_display_invoice_template_pdf_report_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultInboundPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _default_inbound_payment_methods) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultInvoiceReferenceModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _default_invoice_reference_model) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultOutboundPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _default_outbound_payment_methods) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EnsureUniqueAliasInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object company) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _ensure_unique_alias) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FillMissingValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object protected_codes) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _fill_missing_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvailablePaymentMethodLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_type) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_available_payment_method_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetBankStatementsAvailableSourcesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_bank_statements_available_sources) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultAccountDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_default_account_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetJournalBankAccountBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journal_bank_account_balance) ---
            */
            return default;
        }

        public async Task<TEntity> GetJournalInboundOutstandingPaymentAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journal_inbound_outstanding_payment_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> GetJournalNotificationUnsubscribeScopeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journal_notification_unsubscribe_scope) ---
            */
            return default;
        }

        public async Task<TEntity> GetJournalOutboundOutstandingPaymentAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journal_outbound_outstanding_payment_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> GetJournalsPaymentMethodInformationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journals_payment_method_information) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNextJournalDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object journal_type, object company, object cache, object protected_codes) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_next_journal_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> InitColumnAliasIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin.py, METHOD: _init_column_alias_id) ---
            */
            return default;
        }

        public async Task<TEntity> InitColumnInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin.py, METHOD: _init_column) ---
            */
            return default;
        }

        public async Task<TEntity> IsPaymentMethodAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method_code, object complete_domain) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _is_payment_method_available) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyEinvoicesReceivedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _notify_einvoices_received) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyInvoiceSubscribersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object mail_params) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _notify_invoice_subscribers) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeIncomingEinvoiceNotificationEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _onchange_incoming_einvoice_notification_email) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _onchange_type) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareCreditAccountValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object code, object vals) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _prepare_credit_account_vals) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareLiquidityAccountValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object code, object vals) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _prepare_liquidity_account_vals) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessReferenceForSaleOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order_reference) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _process_reference_for_sale_order) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RequireNewAliasInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record_vals) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin.py, METHOD: _require_new_alias) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py, METHOD: _require_new_alias) ---
            */
            return default;
        }

        public async Task<TEntity> SearchAliasEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py, METHOD: _search_alias_email) ---
            */
            return default;
        }

        public async Task<TEntity> SetBankAccountAsync<TEntity>(IEnumerable<TEntity> entities, object acc_number, Guid bank_id) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: set_bank_account) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnsubscribeInvoiceNotificationEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to_remove) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _unsubscribe_invoice_notification_email) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin_optional.py, METHOD: write) ---
            */
            return default;
        }

        public async Task<TEntity> _GetBankStatementsAvailableSourcesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: __get_bank_statements_available_sources) ---
            */
            return default;
        }
    }
}