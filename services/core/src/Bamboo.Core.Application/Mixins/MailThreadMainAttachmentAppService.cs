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
    public partial class MailThreadMainAttachmentAppService : ApplicationService, IMailThreadMainAttachmentAppService
    {

        public MailThreadMainAttachmentAppService() 
        {

        }

        public async Task<TEntity> ActionActivateCurrencyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_activate_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ActionAddFromCatalogAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_add_from_catalog) ---
            */
            return default;
        }

        public async Task<TEntity> ActionApproveAsync<TEntity>(IEnumerable<TEntity> entities, object check_state) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_approve) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: action_approve) ---
            */
            return default;
        }

        public async Task<TEntity> ActionApproveDuplicatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_approve_duplicates) ---
            */
            return default;
        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_archive) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionBackToApprovalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: action_back_to_approval) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: action_cancel) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: action_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_create_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateUserAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_create_user) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateUsersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_create_users) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateUsersConfirmationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_create_users_confirmation) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDocumentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: action_documents) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: action_draft) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDuplicateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_duplicate) ---
            */
            return default;
        }

        public async Task<TEntity> ActionForceRegisterPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_force_register_payment) ---
            */
            return default;
        }

        public async Task<TEntity> ActionInvoiceDownloadPdfAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_invoice_download_pdf) ---
            */
            return default;
        }

        public async Task<TEntity> ActionInvoiceReadyToBeSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _action_invoice_ready_to_be_sent) ---
            */
            return default;
        }

        public async Task<TEntity> ActionInvoiceSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_invoice_sent) ---
            */
            return default;
        }

        public async Task<TEntity> ActionJobAddApplicantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_job_add_applicants) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMoveDownloadAllAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_move_download_all) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAccountMoveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_open_account_move) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAllocationWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_open_allocation_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenApplicationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_open_applications) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_open_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenBusinessDocAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_open_business_doc) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: action_open_business_doc) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenEmployeeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_open_employee) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenSplitExpenseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_open_split_expense) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenVersionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_open_versions) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPayAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_pay) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_post) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: action_post) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_post) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPrintPdfAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_print_pdf) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRefuseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_refuse) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: action_refuse) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRegisterPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_register_payment) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRejectAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: action_reject) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRelatedContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_related_contacts) ---
            */
            return default;
        }

        public async Task<TEntity> ActionResetAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_reset) ---
            */
            return default;
        }

        public async Task<TEntity> ActionReverseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_reverse) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendAndPrintAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_send_and_print) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendEmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_send_email) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShowSameReceiptExpenseIdsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_show_same_receipt_expense_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSplitWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_split_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSubmitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: action_submit) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSwitchMoveTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_switch_move_type) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTalentPoolAddApplicantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_talent_pool_add_applicants) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTalentPoolStatButtonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_talent_pool_stat_button) ---
            */
            return default;
        }

        public async Task<TEntity> ActionToggleBlockPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_toggle_block_payment) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTogglePrimaryBankAccountTrustAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_toggle_primary_bank_account_trust) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnarchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: action_unarchive) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_unarchive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUpdateFposValuesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_update_fpos_values) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUserCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reason) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _action_user_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ActionValidateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: action_validate) ---
            */
            return default;
        }

        public async Task<TEntity> ActionValidateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object check_state) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _action_validate) ---
            */
            return default;
        }

        public async Task<TEntity> ActionValidateMovesWithConfirmationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_validate_moves_with_confirmation) ---
            */
            return default;
        }

        public async Task<TEntity> ActivityUpdateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: activity_update) ---
            */
            return default;
        }

        public async Task<TEntity> AddFollowerAsync<TEntity>(IEnumerable<TEntity> entities, Guid employee_id) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: add_follower) ---
            */
            return default;
        }

        public async Task<TEntity> AffectTaxReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _affect_tax_report) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ApplyDeltaRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date, object date_origin, object period) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _apply_delta_recurring_entries) ---
            */
            return default;
        }

        public async Task<TEntity> ArchiveApplicantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: archive_applicant) ---
            */
            return default;
        }

        public async Task<TEntity> AttachDocumentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: attach_document) ---
            */
            return default;
        }

        public async Task<TEntity> AutoInitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _auto_init) ---
            */
            return default;
        }

        public async Task<TEntity> AutopostBillInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _autopost_bill) ---
            */
            return default;
        }

        public async Task<TEntity> AutopostDraftEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object batch_size) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _autopost_draft_entries) ---
            */
            return default;
        }

        public async Task<TEntity> BuildCreditWarningMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object current_amount, object exclude_current, object exclude_amount) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _build_credit_warning_message) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_draft) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonHashAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_hash) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonOpenBillsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: button_open_bills) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonOpenInvoicesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: button_open_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonOpenJournalEntryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: button_open_journal_entry) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonOpenStatementLinesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: button_open_statement_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonRequestCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_request_cancel) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: button_request_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonSetCheckedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_set_checked) ---
            */
            return default;
        }

        public async Task<TEntity> CalculateHashesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object previous_hash) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _calculate_hashes) ---
            */
            return default;
        }

        public async Task<TEntity> CanBeAutovalidatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _can_be_autovalidated) ---
            */
            return default;
        }

        public async Task<TEntity> CanBeUnlinkedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _can_be_unlinked) ---
            */
            return default;
        }

        protected async Task<object> CanCommitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _can_commit) ---
            */
            return default;
        }

        public async Task<TEntity> CanForceCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _can_force_cancel) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CancelInvalidLeavesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _cancel_invalid_leaves) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object operation) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _check_access) ---
            */
            return default;
        }

        public async Task<TEntity> CheckApprovalUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object state, object raise_if_not_possible) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _check_approval_update) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBalancedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_balanced) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCanApproveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _check_can_approve) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCanCreateMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _check_can_create_move) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCanRefuseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _check_can_refuse) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCanResetApprovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _check_can_reset_approval) ---
            */
            return default;
        }

        public async Task<TEntity> CheckContractsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _check_contracts) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _check_date) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDateStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _check_date_state) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDoubleValidationRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object employees, object state) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _check_double_validation_rules) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDraftableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_draftable) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckFieldAccessRightsAsync<TEntity>(IEnumerable<TEntity> entities, object operation, object field_names) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: check_field_access_rights) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: check_field_access_rights) ---
            */
            return default;
        }

        public async Task<TEntity> CheckFiscalLockDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_fiscal_lock_dates) ---
            */
            return default;
        }

        public async Task<TEntity> CheckInterviewerAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _check_interviewer_access) ---
            */
            return default;
        }

        public async Task<TEntity> CheckInvoiceCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_invoice_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> CheckJournalMoveTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_journal_move_type) ---
            */
            return default;
        }

        public async Task<TEntity> CheckMoveIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _check_move_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckMoveSequenceChainAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: check_move_sequence_chain) ---
            */
            return default;
        }

        public async Task<TEntity> CheckNoExistingContractAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: check_no_existing_contract) ---
            */
            return default;
        }

        public async Task<TEntity> CheckNonZeroInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _check_non_zero) ---
            */
            return default;
        }

        public async Task<TEntity> CheckO2oPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _check_o2o_payment) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPaymentMethodLineIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _check_payment_method_line_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPrivateFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _check_private_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSalaryDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _check_salary_distribution) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSelectedMovesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: check_selected_moves) ---
            */
            return default;
        }

        public async Task<TEntity> CheckTalentPoolRequiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _check_talent_pool_required) ---
            */
            return default;
        }

        public async Task<TEntity> CheckTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount_total) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_total_amount) ---
            */
            return default;
        }

        public async Task<TEntity> CheckValidityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _check_validity) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CleanupWriteOrmValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object vals) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _cleanup_write_orm_values) ---
            */
            return default;
        }

        public async Task<TEntity> CollectTaxCashBasisValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _collect_tax_cash_basis_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAbnormalWarningsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_abnormal_warnings) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_access_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_account_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAdjustingEntriesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_adjusting_entries_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAdjustingEntryOriginLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_adjusting_entry_origin_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAdjustingEntryOriginMovesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_adjusting_entry_origin_moves_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAlertsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_alerts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAlwaysTaxExigibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_always_tax_exigible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountCompanyCurrencySignedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_amount_company_currency_signed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_amount) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountSignedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_amount_signed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountTotalWordsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_amount_total_words) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAnalyticDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_analytic_distribution) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_application_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAutoPostUntilInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_auto_post_until) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailableJournalIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_available_journal_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePartnerBankIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_available_partner_bank_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_1024) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_128) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_1920) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_256) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar_512) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_avatar) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBankPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_bank_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBirthdayPublicDisplayStringInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_birthday_public_display_string) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanApproveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_can_approve) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_can_approve) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanBackToApproveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_can_back_to_approve) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_can_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanRefuseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_can_refuse) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanResetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_can_reset) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanValidateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_can_validate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCheckedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_checked) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCoachInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_coach) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_commercial_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_company_id) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_company_id) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_company) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_currency_id) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_currency_id) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_current_version_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDashboardWarningMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_dashboard_warning_message) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_date_closed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateFromToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_date_from_to) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_day) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDelayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_delay) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDeliveryDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_delivery_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDepartmentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_department_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDepartmentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_department) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_description) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDestinationAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_destination_account_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDirectionSignInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_direction_sign) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayInactiveCurrencyWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_inactive_currency_warning) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayLinkQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_link_qr_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_qr_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplaySendButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_send_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDuplicateExpenseIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_duplicate_expense_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDuplicatePaymentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_duplicate_payment_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDuplicatedRefIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_duplicated_ref_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDurationDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_duration_display) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDurationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_duration) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_employee_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExpectedCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_expected_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalPositionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_fiscal_position_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFromEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_from_employee_id) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_from_employee_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFromProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_from_product) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasMandatoryDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_has_mandatory_day) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasMultipleBankAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_has_multiple_bank_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasReconciledEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_has_reconciled_entries) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHidePostButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_hide_post_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHighestNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_highest_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHighlightSendButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_highlight_send_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIncotermInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_incoterm) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIncotermLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_incoterm_location) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceDateDueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_date_due) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceDefaultSalePersonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_default_sale_person) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceFilterTypeDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_filter_type_domain) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceHasOutstandingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_has_outstanding) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceIncotermPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_incoterm_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoicePartnerDisplayInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_partner_display_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoicePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_payment_term_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsApplicantInPoolInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_is_applicant_in_pool) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsBeingSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_is_being_sent) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsEditableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_is_editable) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsHatchedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_is_hatched) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMultipleCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_is_multiple_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPoolInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_is_pool) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsSaleInstalledInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_is_sale_installed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsStornoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_is_storno) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsTrustedBankAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_is_trusted_bank_account) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_journal_id) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_journal_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLastActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_last_activity) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLastSeveralDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_last_several_days) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLeaveTypeIncreasesDurationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_leave_type_increases_duration) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLeavesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_leaves) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLegalNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_legal_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkedAttachmentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachment_field, object binary_field) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_linked_attachment_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMadeSequenceGapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_made_sequence_gap) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_meeting_display) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMoveSentValuesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: compute_move_sent_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_name) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_name) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNamePlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_name_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNarrationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_narration) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNbAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_nb_attachment) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNeedCancelRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_need_cancel_request) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNeededTermsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_needed_terms) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNewlyHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_newly_hired) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNextPaymentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_next_payment_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNoFollowupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_no_followup) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOutstandingAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_outstanding_account_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerBankIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_partner_bank_id) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_partner_bank_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerCreditWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_partner_credit_warning) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_partner_phone_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneSanitizedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_partner_phone_sanitized) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShippingIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_partner_shipping_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payment_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentMethodLineFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_payment_method_line_fields) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentMethodLineIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_payment_method_line_id) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_payment_method_line_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentReceiptTitleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_payment_receipt_title) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payment_reference) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payment_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentTermDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payment_term_details) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentsWidgetReconciledInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payments_widget_reconciled_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentsWidgetToReconcileInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payments_widget_to_reconcile_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePreferredPaymentMethodLineIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_preferred_payment_method_line_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePresenceIconInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_presence_icon) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePresenceStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_presence_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePriceUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_price_unit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePrimaryBankAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_primary_bank_account_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_product_description) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_qr_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuickEditModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_quick_edit_mode) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuickEncodingValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_quick_encoding_vals) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReconciledPaymentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_reconciled_payment_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReconciliationStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_reconciliation_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRelatedPartnersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_related_partners_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRequestHourFromToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_request_hour_from_to) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRequestUnitHalfInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_request_unit_half) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRequestUnitHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_request_unit_hours) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeResourceCalendarIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_resource_calendar_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSameReceiptExpenseIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_same_receipt_expense_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSecuredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_secured) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSelectablePaymentMethodLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_selectable_payment_method_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowDeliveryDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_delivery_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_journal) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowPaymentTermDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_payment_term_details) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowRequirePartnerBankInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_show_require_partner_bank) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowResetToDraftButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_reset_to_draft_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowTaxableSupplyDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_taxable_supply_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_stage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStatButtonsFromReconciliationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_stat_buttons_from_reconciliation) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _compute_state) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStatusInPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_status_in_payment) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSuitableJournalIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_suitable_journal_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSupportedAttachmentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_supported_attachment_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTalentPoolCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_talent_pool_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxAmountCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_tax_amount_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_tax_amount) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxCountryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_tax_country_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_tax_country_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_tax_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxLockDateMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_tax_lock_date_message) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_tax_totals) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxableSupplyDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_taxable_supply_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxableSupplyDatePlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_taxable_supply_date_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxesLegalNotesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_taxes_legal_notes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalAmountCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_total_amount_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_total_amount) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTypeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_type_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_tz) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTzMismatchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _compute_tz_mismatch) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _compute_uom_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_user) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_version_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVersionsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_versions_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkContactDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_work_contact_details) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkLocationNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_work_location_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkLocationTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_work_location_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkPermitNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _compute_work_permit_name) ---
            */
            return default;
        }

        public async Task<TEntity> ConditionalAddToComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object condition) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _conditional_add_to_compute) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyCacheFromInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @public, object field_names) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _copy_cache_from) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CopyRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _copy_recurring_entries) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateCompanyPaidMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _create_company_paid_moves) ---
            */
            return default;
        }

        public async Task<TEntity> CreateContractAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: create_contract) ---
            */
            return default;
        }

        public async Task<TEntity> CreateEmployeeFromApplicantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: create_employee_from_applicant) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateExpenseFromAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids, object view_type) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: create_expense_from_attachments) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data_list) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateResourceLeaveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _create_resource_leave) ---
            */
            return default;
        }

        public async Task<TEntity> CreateVersionAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: create_version) ---
            */
            return default;
        }

        public async Task<TEntity> CreateWorkContactsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _create_work_contacts) ---
            */
            return default;
        }

        public async Task<TEntity> CreationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _creation_message) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _creation_message) ---
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _creation_subtype) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _creation_subtype) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CronAccountMoveSendInternalAsync<TEntity>(IEnumerable<TEntity> entities, object job_count) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _cron_account_move_send) ---
            */
            return default;
        }

        public async Task<TEntity> CronUpdateCurrentVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _cron_update_current_version_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _default_employee_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: default_get) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultGetRequestDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _default_get_request_dates) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultOrderLineValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object child_field) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _default_order_line_values) ---
            */
            return default;
        }

        public async Task<TEntity> DetachAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _detach_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> DisableDiscountPrecisionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _disable_discount_precision) ---
            */
            return default;
        }

        public async Task<TEntity> DisableRecursionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container, object key, object @default, object target) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _disable_recursion) ---
            */
            return default;
        }

        public async Task<TEntity> DoApproveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object check) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _do_approve) ---
            */
            return default;
        }

        public async Task<TEntity> DoRefuseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reason) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _do_refuse) ---
            */
            return default;
        }

        public async Task<TEntity> DoResetApprovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _do_reset_approval) ---
            */
            return default;
        }

        public async Task<TEntity> EarlyPaymentDiscountMoveTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _early_payment_discount_move_types) ---
            */
            return default;
        }

        public async Task<TEntity> EmployeeAttendanceIntervalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object lunch) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _employee_attendance_intervals) ---
            */
            return default;
        }

        public async Task<TEntity> ExtendWithAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object files_data, object @new) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _extend_with_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> FetchAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: fetch) ---
            */
            return default;
        }

        public async Task<TEntity> FetchDuplicateReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object matching_states) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _fetch_duplicate_reference) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _fetch_duplicate_reference) ---
            */
            return default;
        }

        public async Task<object> FieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, string @alias, string field_expr, object query) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _field_to_sql) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _field_to_sql) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FieldWillChangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object vals, object field_name) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _field_will_change) ---
            */
            return default;
        }

        public async Task<TEntity> FindAndSetPurchaseOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object po_references, Guid partner_id, object amount_total, object from_ocr, object timeout) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _find_and_set_purchase_orders) ---
            */
            return default;
        }

        public async Task<TEntity> ForceCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reason, object msg_subtype, object notify_responsibles) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _force_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateAndSendInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_synchronous, object allow_fallback_pdf) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _generate_and_send) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateJournalEntryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object write_off_line_vals, object force_balance, List<Guid> line_ids) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _generate_journal_entry) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateMoveValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object write_off_line_vals, object force_balance, List<Guid> line_ids) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _generate_move_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GeneratePortalPaymentQrInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _generate_portal_payment_qr) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object silent_errors) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _generate_qr_code) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateRandomBarcodeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: generate_random_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax, object lock_dates) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_accounting_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountingDateSourceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_accounting_date_source) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountsWithFixedAllocationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_accounts_with_fixed_allocations) ---
            */
            return default;
        }

        public async Task<TEntity> GetActionAddFromCatalogExtraContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            */
            return default;
        }

        public async Task<TEntity> GetActionWithBaseDocumentLayoutConfiguratorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_action) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_action_with_base_document_layout_configurator) ---
            */
            return default;
        }

        public async Task<TEntity> GetAgeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_date) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_age) ---
            */
            return default;
        }

        public async Task<TEntity> GetAlertsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_alerts) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllContractDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_all_contract_dates) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllReconciledInvoicePartialsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_all_reconciled_invoice_partials) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAllVersionsWithContractOverlapWithPeriodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_all_versions_with_contract_overlap_with_period) ---
            */
            return default;
        }

        public async Task<TEntity> GetAmlDefaultDisplayNameListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _get_aml_default_display_name_list) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttachmentNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_attachment_number) ---
            */
            return default;
        }

        public async Task<TEntity> GetAutomaticBalancingAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_automatic_balancing_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvailableActionReportsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_invoice_report) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_available_action_reports) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvailableInvoiceTemplatePdfReportIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_available_invoice_template_pdf_report_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvatarCardDataAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_avatar_card_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetBankAccountSalaryAllocationAsync<TEntity>(IEnumerable<TEntity> entities, Guid account_id) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_bank_account_salary_allocation) ---
            */
            return default;
        }

        public async Task<TEntity> GetBaseAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_base_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetCalendarAttendancesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_calendar_attendances) ---
            */
            return default;
        }

        public async Task<TEntity> GetCalendarPeriodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object check_contract) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_calendar_periods) ---
            */
            return default;
        }

        public async Task<TEntity> GetCalendarTzBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object dt) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_calendar_tz_batch) ---
            */
            return default;
        }

        public async Task<TEntity> GetCalendarsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_calendars) ---
            */
            return default;
        }

        public async Task<TEntity> GetCannotApproveReasonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_cannot_approve_reason) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCertificateSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_certificate_selection) ---
            */
            return default;
        }

        public async Task<TEntity> GetChainInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_hash, object include_pre_last_hash, object early_stop) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_chain_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetChainsToHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_hash, object raise_if_gap, object raise_if_no_document, object include_pre_last_hash, object early_stop) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_chains_to_hash) ---
            */
            return default;
        }

        public async Task<TEntity> GetContractDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_contract_dates) ---
            */
            return default;
        }

        public async Task<TEntity> GetContractVersionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_end, object domain) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_contract_versions) ---
            */
            return default;
        }

        public async Task<TEntity> GetContractsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_end, object use_latest_version, object domain) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_contracts) ---
            */
            return default;
        }

        public async Task<TEntity> GetCopyMessageContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_copy_message_content) ---
            */
            return default;
        }

        public async Task<TEntity> GetCurrencyRateAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, Guid to_currency_id, object date) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> GetCustomerInformationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_customer_information) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultReadFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_default_read_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultResponsibleForApprovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_default_responsible_for_approval) ---
            */
            return default;
        }

        public async Task<TEntity> GetDepartureDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_departure_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetDiscountAllocationAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_discount_allocation_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetDurationFromTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object trackings) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_duration_from_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> GetDurationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object check_leave_type, object resource_calendar) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _get_durations) ---
            */
            return default;
        }

        public async Task<TEntity> GetEdiCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_edi_creation) ---
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeCreateValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_employee_create_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _get_employee_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmployeeFromEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_address) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_employee_from_email) ---
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeM2oToEmptyOnArchivedEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_employee_m2o_to_empty_on_archived_employees) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmployeeWorkingNowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_employee_working_now) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: get_empty_list_help) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: get_empty_list_help) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListMailAliasInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_empty_list_mail_alias) ---
            */
            return default;
        }

        public async Task<TEntity> GetExpectedAttendancesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_expected_attendances) ---
            */
            return default;
        }

        public async Task<TEntity> GetExpenseAccountDestinationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_expense_account_destination) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetExpenseDashboardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: get_expense_dashboard) ---
            */
            return default;
        }

        public async Task<TEntity> GetExtraPrintItemsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_extra_print_items) ---
            */
            return default;
        }

        public async Task<TEntity> GetFieldsToCopyRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_fields_to_copy_recurring_entries) ---
            */
            return default;
        }

        public async Task<TEntity> GetFieldsToDetachInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_fields_to_detach) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstVersionDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object no_gap) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_first_version_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstVersionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_first_versions) ---
            */
            return default;
        }

        public async Task<TEntity> GetFormviewActionAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_formview_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetFormviewIdAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_formview_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetFrequentAccountAndTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, Guid partner_id, object move_type) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_frequent_account_and_taxes) ---
            */
            return default;
        }

        public async Task<TEntity> GetHourFromToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request_date_from, object request_date_to, object day_period) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _get_hour_from_to) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInboundTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_inbound_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetInstallmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_installments_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetIntegrityHashFieldsAndSubfieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_integrity_hash_fields_and_subfields) ---
            */
            return default;
        }

        public async Task<TEntity> GetIntegrityHashFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_integrity_hash_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceComputedReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_computed_reference) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceCounterpartAmlsForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object aml_values_list, object open_balance) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_counterpart_amls_for_early_payment_discount) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceCounterpartAmlsForEarlyPaymentDiscountPerPaymentTermLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_counterpart_amls_for_early_payment_discount_per_payment_term_line) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceCurrencyRateDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_currency_rate_date) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceFilterTypeDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_type) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_filter_type_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceInPaymentStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_in_payment_state) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLegalDocumentsAllInternalAsync<TEntity>(IEnumerable<TEntity> entities, object allow_fallback) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_legal_documents_all) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLegalDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filetype, object allow_fallback) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_legal_documents) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceLocalisationFieldsRequiredToInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, Guid country_id) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_invoice_localisation_fields_required_to_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceNextPaymentValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object custom_amount) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_next_payment_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePdfProformaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_pdf_proforma) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePortalExtraValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object custom_amount) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_portal_extra_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceProformaPdfReportFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_proforma_pdf_report_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceEuroInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_euro_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceEuroPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_euro_partner) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceNumberInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_number_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceNumberPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_number_partner) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceOdooInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_odoo_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceOdooPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_odoo_partner) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReportFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object extension, object report) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_report_filename) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_invoice_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetLastSequenceDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object relaxed) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_last_sequence_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetLeavesOnPublicHolidayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _get_leaves_on_public_holiday) ---
            */
            return default;
        }

        public async Task<TEntity> GetLinesOnchangeCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_lines_onchange_currency) ---
            */
            return default;
        }

        public async Task<TEntity> GetLockDateMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_lock_date_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetMailTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_mail_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetMailThreadDataAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_mail_thread_data_attachments) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMethodCodesNeedingBankAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _get_method_codes_needing_bank_account) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMethodCodesUsingBankAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _get_method_codes_using_bank_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetMoveDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object show_ref) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_move_display_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMoveHashDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object common_domain, object force_hash) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_move_hash_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetMoveLineNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_move_line_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetMoveLinesToReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_move_lines_to_report) ---
            */
            return default;
        }

        public async Task<TEntity> GetMoveZipExportDocsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_move_zip_export_docs) ---
            */
            return default;
        }

        public async Task<TEntity> GetMovesRequiringConfirmationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_moves_requiring_confirmation) ---
            */
            return default;
        }

        public async Task<TEntity> GetNameInvoiceReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_name_invoice_report) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNewHireFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_new_hire_field) ---
            */
            return default;
        }

        public async Task<TEntity> GetNextStatesByStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _get_next_states_by_state) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOutboundTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_outbound_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetOutstandingAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_outstanding_account_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetOutstandingAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_type) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _get_outstanding_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetOverlappingContractsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _get_overlapping_contracts) ---
            */
            return default;
        }

        public async Task<TEntity> GetParentFieldOnChildModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_parent_field_on_child_model) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerCountDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_partner_count_depends) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerCreditWarningExcludeAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_partner_credit_warning_exclude_amount) ---
            */
            return default;
        }

        public async Task<TEntity> GetPaymentMethodCodesToExcludeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _get_payment_method_codes_to_exclude) ---
            */
            return default;
        }

        public async Task<TEntity> GetPaymentReceiptReportValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _get_payment_receipt_report_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetPortalPaymentLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_portal_payment_link) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_product_catalog_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogOrderDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_product_catalog_order_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogRecordLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> product_ids) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_product_catalog_record_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceAndDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_product_price_and_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetProtectedValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object records) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_protected_vals) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPurchaseTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_purchase_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetQuickEditSuggestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_quick_edit_suggestions) ---
            */
            return default;
        }

        public async Task<TEntity> GetReconciledAmlsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_amls) ---
            */
            return default;
        }

        public async Task<TEntity> GetReconciledInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> GetReconciledInvoicesPartialsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_invoices_partials) ---
            */
            return default;
        }

        public async Task<TEntity> GetReconciledPaymentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_payments) ---
            */
            return default;
        }

        public async Task<TEntity> GetReconciledStatementLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_statement_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetRedirectSuggestedCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _get_redirect_suggested_company) ---
            */
            return default;
        }

        public async Task<TEntity> GetRelatedPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_related_partners) ---
            */
            return default;
        }

        public async Task<TEntity> GetRemainingPercentageAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_remaining_percentage) ---
            */
            return default;
        }

        public async Task<TEntity> GetReportBaseFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_report_base_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetResponsibleForApprovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _get_responsible_for_approval) ---
            */
            return default;
        }

        public async Task<TEntity> GetRottingDependsFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_rotting_depends_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetRottingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_rotting_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetRoundedBaseAndTaxLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object round_from_tax_lines) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_rounded_base_and_tax_lines) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSaleTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_sale_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetSequenceDateRangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reset) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_sequence_date_range) ---
            */
            return default;
        }

        public async Task<TEntity> GetSimilarApplicantsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ignore_talent, object only_talent) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_similar_applicants_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetSplitValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_split_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetStartingSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_starting_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreAvatarCardFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_store_avatar_card_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSuitableJournalIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_type, object company) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_suitable_journal_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetSyncStackInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_sync_stack) ---
            */
            return default;
        }

        public async Task<TEntity> GetToCleanActivitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _get_to_clean_activities) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTriggerFieldsToSynchronizeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _get_trigger_fields_to_synchronize) ---
            */
            return default;
        }

        public async Task<TEntity> GetTzBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_tz_batch) ---
            */
            return default;
        }

        public async Task<TEntity> GetTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_tz) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnbalancedMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_unbalanced_moves) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnlinkLoggerMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_unlink_logger_message) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUntitledExpenseNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _get_untitled_expense_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUnusualDaysAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: get_unusual_days) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnusualDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_unusual_days) ---
            */
            return default;
        }

        public async Task<TEntity> GetUserM2oToEmptyOnArchivedEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_user_m2o_to_empty_on_archived_employees) ---
            */
            return default;
        }

        public async Task<TEntity> GetValidJournalTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_valid_journal_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetValidLiquidityAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _get_valid_liquidity_accounts) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetValidPaymentAccountTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _get_valid_payment_account_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetVersionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_version) ---
            */
            return default;
        }

        public async Task<TEntity> GetVersionPeriodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object field, object check_contract) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_version_periods) ---
            */
            return default;
        }

        public async Task<TEntity> GetVersionsWithContractOverlapWithPeriodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _get_versions_with_contract_overlap_with_period) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_view) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: get_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewsAsync<TEntity>(IEnumerable<TEntity> entities, object views, object options) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: get_views) ---
            */
            return default;
        }

        public async Task<TEntity> GetViolatedLockDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_violated_lock_dates) ---
            */
            return default;
        }

        public async Task<TEntity> HasFieldAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object operation) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _has_field_access) ---
            */
            return default;
        }

        public async Task<TEntity> HashMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _hash_moves) ---
            */
            return default;
        }

        public async Task<TEntity> InverseAmountTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_amount_total) ---
            */
            return default;
        }

        public async Task<TEntity> InverseCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _inverse_description) ---
            */
            return default;
        }

        public async Task<TEntity> InverseInvoicePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_invoice_payment_term_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_journal_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseMemoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _inverse_memo) ---
            */
            return default;
        }

        public async Task<TEntity> InverseNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_name) ---
            */
            return default;
        }

        public async Task<TEntity> InverseNoFollowupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_no_followup) ---
            */
            return default;
        }

        public async Task<TEntity> InversePartnerEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _inverse_partner_email) ---
            */
            return default;
        }

        public async Task<TEntity> InversePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> InversePaymentReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_payment_reference) ---
            */
            return default;
        }

        public async Task<TEntity> InverseSupportedAttachmentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _inverse_supported_attachment_ids) ---
            */
            return default;
        }

        public async Task<TEntity> InverseTaxTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_tax_totals) ---
            */
            return default;
        }

        public async Task<TEntity> InverseTotalAmountCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _inverse_total_amount_currency) ---
            */
            return default;
        }

        public async Task<TEntity> InverseTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _inverse_total_amount) ---
            */
            return default;
        }

        public async Task<TEntity> InverseWorkContactDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _inverse_work_contact_details) ---
            */
            return default;
        }

        public async Task<TEntity> InvoicePaidHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _invoice_paid_hook) ---
            */
            return default;
        }

        public async Task<TEntity> IsActionReportAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object action_report, object is_invoice_report) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_action_report_available) ---
            */
            return default;
        }

        public async Task<TEntity> IsDownpaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_downpayment) ---
            */
            return default;
        }

        public async Task<TEntity> IsEligibleForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object currency, object reference_date) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_eligible_for_early_payment_discount) ---
            */
            return default;
        }

        public async Task<TEntity> IsEntryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_entry) ---
            */
            return default;
        }

        public async Task<TEntity> IsInContractInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _is_in_contract) ---
            */
            return default;
        }

        public async Task<TEntity> IsInboundAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_inbound) ---
            */
            return default;
        }

        public async Task<TEntity> IsInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> IsLineValidForSectionLineCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_line_valid_for_section_line_count) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IsMoveRestrictedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object force_hash) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_move_restricted) ---
            */
            return default;
        }

        public async Task<TEntity> IsOutboundAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_outbound) ---
            */
            return default;
        }

        public async Task<TEntity> IsProtectedByAuditTrailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_protected_by_audit_trail) ---
            */
            return default;
        }

        public async Task<TEntity> IsPurchaseDocumentAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts, object move_type) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_purchase_document) ---
            */
            return default;
        }

        public async Task<TEntity> IsReadonlyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_readonly) ---
            */
            return default;
        }

        public async Task<TEntity> IsReadyToBeSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_ready_to_be_sent) ---
            */
            return default;
        }

        public async Task<TEntity> IsReceiptAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_receipt) ---
            */
            return default;
        }

        public async Task<TEntity> IsSaleDocumentAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts, object move_type) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_sale_document) ---
            */
            return default;
        }

        public async Task<TEntity> IsUserAbleToReviewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_user_able_to_review) ---
            */
            return default;
        }

        public async Task<TEntity> JsAssignOutstandingLineAsync<TEntity>(IEnumerable<TEntity> entities, Guid line_id) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: js_assign_outstanding_line) ---
            */
            return default;
        }

        public async Task<TEntity> JsRemoveOutstandingPartialAsync<TEntity>(IEnumerable<TEntity> entities, Guid partial_id) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: js_remove_outstanding_partial) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _lang_get) ---
            */
            return default;
        }

        public async Task<TEntity> LinkApplicantToTalentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: link_applicant_to_talent) ---
            */
            return default;
        }

        public async Task<TEntity> LinkBillOriginToPurchaseOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object timeout) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _link_bill_origin_to_purchase_orders) ---
            */
            return default;
        }

        public async Task<TEntity> LoadDemoDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _load_demo_data) ---
            */
            return default;
        }

        public async Task<TEntity> LoadScenarioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _load_scenario) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _mail_get_partner_fields) ---
            */
            return default;
        }

        public async Task<TEntity> MailingGetDefaultDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mailing) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _mailing_get_default_domain) ---
            */
            return default;
        }

        public async Task<TEntity> MarkAsSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: mark_as_sent) ---
            */
            return default;
        }

        public async Task<TEntity> MessageAutoSubscribeFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_values, List<Guid> subtype_ids) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _message_auto_subscribe_followers) ---
            */
            return default;
        }

        public async Task<TEntity> MessageMailAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mails) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _message_mail_after_hook) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: message_new) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: message_new) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: message_new) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_values) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _message_post_after_hook) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _message_post_after_hook) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_main_attachment.py, METHOD: _message_post_after_hook) ---
            */
            return default;
        }

        public async Task<TEntity> MessageSetMainAttachmentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachments, object force, object filter_xml) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_main_attachment.py, METHOD: _message_set_main_attachment_id) ---
            */
            return default;
        }

        public async Task<TEntity> MessageSubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> subtype_ids) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: message_subscribe) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MoveDictToPreviewValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_vals, Guid currency_id) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _move_dict_to_preview_vals) ---
            */
            return default;
        }

        public async Task<TEntity> MoveValidateLeaveToConfirmInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _move_validate_leave_to_confirm) ---
            */
            return default;
        }

        public async Task<TEntity> MustCheckConstrainsDateSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _must_check_constrains_date_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> NeedCancelRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _need_cancel_request) ---
            */
            return default;
        }

        public async Task<TEntity> NeedsProductPriceComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _needs_product_price_computation) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NewAsync<TEntity>(IEnumerable<TEntity> entities, object values, object origin, object @ref) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: new) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailPrepareRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyChangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object subtype_xmlid) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _notify_change) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NotifyExpiringContractWorkPermitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: notify_expiring_contract_work_permit) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default, Guid author_id) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _notify_get_reply_to) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyManagerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _notify_manager) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAsync<TEntity>(IEnumerable<TEntity> entities, object values, object field_names, object fields_spec) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: onchange) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: onchange) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeContractDateStartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_contract_date_start) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeContractTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_contract_template_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_date) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeFposIdShowUpdateFposInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_fpos_id_show_update_fpos) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _onchange_hours) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeInvoiceCashRoundingIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_invoice_cash_rounding_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeInvoiceVendorBillInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_invoice_vendor_bill) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_journal_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeNameWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_name_warning) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePhoneValidationEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_phone_validation_employee) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePrivateStateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_private_state_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeProductHasCostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _onchange_product_has_cost) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeQuickEditLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_quick_edit_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeQuickEditTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_quick_edit_total_amount) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_timezone) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _onchange_user) ---
            */
            return default;
        }

        public async Task<TEntity> OpenAdjustingEntriesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_adjusting_entries) ---
            */
            return default;
        }

        public async Task<TEntity> OpenAdjustingEntryOriginMovesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_adjusting_entry_origin_moves) ---
            */
            return default;
        }

        public async Task<TEntity> OpenCreatedCabaEntriesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_created_caba_entries) ---
            */
            return default;
        }

        public async Task<TEntity> OpenPaymentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_payments) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> OpenPendingRequestsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: open_pending_requests) ---
            */
            return default;
        }

        public async Task<TEntity> OpenReconcileViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_reconcile_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ParseExpenseSubjectInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expense_description, object currencies) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _parse_expense_subject) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ParsePriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expense_description, object currencies) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _parse_price) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ParseProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expense_description) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _parse_product) ---
            */
            return default;
        }

        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _phone_get_number_fields) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _phone_get_number_fields) ---
            */
            return default;
        }

        public async Task<TEntity> PostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object soft) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _post) ---
            */
            return default;
        }

        public async Task<TEntity> PostLeaveCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _post_leave_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> PostWithoutWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _post_without_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> PostWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _post_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _prepare_base_line_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareCashRoundingBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cash_rounding_line) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_cash_rounding_base_line_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareCreateValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _prepare_create_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareEdiValsToExportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_edi_vals_to_export) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareEpdBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object epd_line) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_epd_base_line_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareEpdBaseLinesForTaxesComputationFromBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_epd_base_lines_for_taxes_computation_from_base_lines) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareHolidaysMeetingValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _prepare_holidays_meeting_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceAggregatedTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filter_invl_to_apply, object filter_tax_values_to_apply, object grouping_key_generator, object round_from_tax_lines, object postfix_function) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_invoice_aggregated_taxes) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareMoveLineDefaultValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object write_off_line_vals, object force_balance) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _prepare_move_line_default_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareMoveLinesValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _prepare_move_lines_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareMoveValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _prepare_move_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareNonDeductibleBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object non_deductible_line) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_non_deductible_base_line_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareNonDeductibleBaseLinesForTaxesComputationFromBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_non_deductible_base_lines_for_taxes_computation_from_base_lines) ---
            */
            return default;
        }

        public async Task<TEntity> PreparePaymentsValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _prepare_payments_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareProductBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_line) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_product_base_line_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareReceiptsValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _prepare_receipts_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareResourceLeaveValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _prepare_resource_leave_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareResourceValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tz) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _prepare_resource_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareTaxLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_line) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_tax_line_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareTaxLinesForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_amls, object round_from_tax_lines) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_tax_lines_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PreviewInvoiceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: preview_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> QuickEditModeSuggestInvoiceDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _quick_edit_mode_suggest_invoice_date) ---
            */
            return default;
        }

        public async Task<TEntity> ReadAsync<TEntity>(IEnumerable<TEntity> entities, object fields, object load) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: read) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadGroupStageIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _read_group_stage_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ReasonCannotDecodeHasInvoiceLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _reason_cannot_decode_has_invoice_lines) ---
            */
            return default;
        }

        public async Task<TEntity> RecomputeCashRoundingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _recompute_cash_rounding_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ReconcileReversedMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reverse_moves, object move_reverse_cancel) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _reconcile_reversed_moves) ---
            */
            return default;
        }

        public async Task<TEntity> RefreshInvoiceCurrencyRateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: refresh_invoice_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> RefundsOriginRequiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _refunds_origin_required) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveResourceLeaveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _remove_resource_leave) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveWorkContactIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object employee_company) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _remove_work_contact_id) ---
            */
            return default;
        }

        public async Task<TEntity> RequireBillDateForAutopostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _require_bill_date_for_autopost) ---
            */
            return default;
        }

        public async Task<TEntity> ResetApplicantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: reset_applicant) ---
            */
            return default;
        }

        public async Task<TEntity> ReverseMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object default_values_list, object cancel) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _reverse_moves) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RoutingCheckRouteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object message_dict, object route, object raise_exception) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _routing_check_route) ---
            */
            return default;
        }

        public async Task<TEntity> SanitizeValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sanitize_vals) ---
            */
            return default;
        }

        public async Task<TEntity> SearchApplicationStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _search_application_status) ---
            */
            return default;
        }

        public async Task<TEntity> SearchDefaultJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_default_journal) ---
            */
            return default;
        }

        public async Task<TEntity> SearchDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _search_description) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchFetchAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field_names, object offset, object limit, object order) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: search_fetch) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object offset, object limit, object order) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _search) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsApplicantInPoolInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _search_is_applicant_in_pool) ---
            */
            return default;
        }

        public async Task<TEntity> SearchJournalGroupIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_journal_group_id) ---
            */
            return default;
        }

        public async Task<TEntity> SearchMoveSentValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_move_sent_values) ---
            */
            return default;
        }

        public async Task<TEntity> SearchNewlyHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _search_newly_hired) ---
            */
            return default;
        }

        public async Task<TEntity> SearchNextPaymentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_next_payment_date) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchReadAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object fields, object offset, object limit, object order) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: search_read) ---
            */
            return default;
        }

        public async Task<TEntity> SearchReconciledInvoiceIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _search_reconciled_invoice_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchReconciledPaymentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_reconciled_payment_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchSecuredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_secured) ---
            */
            return default;
        }

        public async Task<TEntity> SearchVersionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _search_version_id) ---
            */
            return default;
        }

        public async Task<TEntity> SeekForLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _seek_for_lines) ---
            */
            return default;
        }

        public async Task<TEntity> SendExpenseSuccessMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object expense) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _send_expense_success_mail) ---
            */
            return default;
        }

        public async Task<TEntity> SendOnlyWhenReadyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _send_only_when_ready) ---
            */
            return default;
        }

        public async Task<TEntity> SequenceFixedRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_fixed_regex) ---
            */
            return default;
        }

        public async Task<TEntity> SequenceMonthlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_monthly_regex) ---
            */
            return default;
        }

        public async Task<TEntity> SequenceYearRangeMonthlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_year_range_monthly_regex) ---
            */
            return default;
        }

        public async Task<TEntity> SequenceYearRangeRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_year_range_regex) ---
            */
            return default;
        }

        public async Task<TEntity> SequenceYearlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_yearly_regex) ---
            */
            return default;
        }

        public async Task<TEntity> SetExpenseCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_today) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _set_expense_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> SetMovesCheckedAsync<TEntity>(IEnumerable<TEntity> entities, object is_checked) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: set_moves_checked) ---
            */
            return default;
        }

        public async Task<TEntity> SetNextMadeSequenceGapInternalAsync<TEntity>(IEnumerable<TEntity> entities, bool made_gap) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _set_next_made_sequence_gap) ---
            */
            return default;
        }

        public async Task<TEntity> SetReversedEntryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object credit_note) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _set_reversed_entry) ---
            */
            return default;
        }

        public async Task<TEntity> ShowAutopostBillsWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _show_autopost_bills_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> SplitLeavesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object split_date_from, object split_date_to) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _split_leaves) ---
            */
            return default;
        }

        public async Task<TEntity> StolenMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _stolen_move) ---
            */
            return default;
        }

        public async Task<TEntity> SyncDynamicLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object existing_key_fname, object needed_vals_fname, object needed_dirty_fname, object line_type, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_dynamic_line) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SyncDynamicLineNeededValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values_list) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_dynamic_line_needed_values) ---
            */
            return default;
        }

        public async Task<TEntity> SyncDynamicLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_dynamic_lines) ---
            */
            return default;
        }

        public async Task<TEntity> SyncInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> SyncNonDeductibleBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_non_deductible_base_lines) ---
            */
            return default;
        }

        public async Task<TEntity> SyncRoundingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_rounding_lines) ---
            */
            return default;
        }

        public async Task<TEntity> SyncSalaryDistributionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _sync_salary_distribution) ---
            */
            return default;
        }

        public async Task<TEntity> SyncTaxLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_tax_lines) ---
            */
            return default;
        }

        public async Task<TEntity> SyncUnbalancedLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_unbalanced_lines) ---
            */
            return default;
        }

        public async Task<TEntity> SyncUserInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object employee_has_image) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _sync_user) ---
            */
            return default;
        }

        public async Task<TEntity> SynchronizeBusinessModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changed_fields) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _synchronize_business_models) ---
            */
            return default;
        }

        public async Task<TEntity> SynchronizeToMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changed_fields) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _synchronize_to_moves) ---
            */
            return default;
        }

        public async Task<TEntity> ThreadToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object fields) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_main_attachment.py, METHOD: _thread_to_store) ---
            */
            return default;
        }

        public async Task<TEntity> ToUtcInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date, object hour, object resource) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _to_utc) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _track_template) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAccountAuditTrailExceptOncePostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _unlink_account_audit_trail_except_once_post) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptApprovedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: _unlink_except_approved) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkForbidPartsOfChainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _unlink_forbid_parts_of_chain) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfCorrectStatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _unlink_if_correct_states) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkOrReverseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _unlink_or_reverse) ---
            */
            return default;
        }

        public async Task<TEntity> UnmarkAsSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: unmark_as_sent) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateActivitiesAndMailsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: update_activities_and_mails) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateOrderLineInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid product_id, object quantity) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _update_order_line_info) ---
            */
            return default;
        }

        public async Task<TEntity> ValidPaymentStatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: _valid_payment_states) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateLeaveRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: _validate_leave_request) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTaxesCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _validate_taxes_country) ---
            */
            return default;
        }

        public async Task<TEntity> VerifyBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _verify_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> VerifyPinInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: _verify_pin) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadMainAttachmentable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_payment.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_employee.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: hr_expense.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: write) ---
            */
            return default;
        }
    }
}