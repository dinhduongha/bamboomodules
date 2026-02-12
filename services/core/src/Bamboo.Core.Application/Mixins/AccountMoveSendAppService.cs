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
    [Module("account", Category = "Accounting", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public partial class AccountMoveSendAppService : ApplicationService, IAccountMoveSendAppService
    {

        public AccountMoveSendAppService() 
        {

        }

        public async Task<TEntity> ActionWhatIsPeppolActivateAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py, METHOD: action_what_is_peppol_activate) ---
            */
            return default;
        }

        public async Task<TEntity> CallWebServiceAfterInvoicePdfRenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _call_web_service_after_invoice_pdf_render) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py, METHOD: _call_web_service_after_invoice_pdf_render) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CallWebServiceBeforeInvoicePdfRenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _call_web_service_before_invoice_pdf_render) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CanCommitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _can_commit) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckInvoiceReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _check_invoice_report) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckMoveConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _check_move_constraints) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSendingDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _check_sending_data) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DisplayAttachmentsWidgetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object edi_format, object sending_methods) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _display_attachments_widget) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py, METHOD: _display_attachments_widget) ---
            */
            return default;
        }

        public async Task<TEntity> DoPeppolPreSendInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py, METHOD: _do_peppol_pre_send) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormatErrorHtmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _format_error_html) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormatErrorTextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _format_error_text) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GenerateAndSendInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves, object from_cron, object allow_raising, object allow_fallback_pdf) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _generate_and_send_invoices) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GenerateDynamicReportsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _generate_dynamic_reports) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GenerateInvoiceDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices_data, object allow_fallback_pdf) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _generate_invoice_documents) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GenerateInvoiceFallbackDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _generate_invoice_fallback_documents) ---
            */
            return default;
        }

        public async Task<TEntity> GetAlertsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves, object moves_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_alerts) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py, METHOD: _get_alerts) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py, METHOD: _get_alerts) ---
            --- METHOD SOURCE (MODULE: snailmail_account, FILE: account_move_send.py, METHOD: _get_alerts) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<Dictionary<string, object>> GetAllExtraEdisInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_all_extra_edis) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<object> GetDefaultExtraEdisInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_default_extra_edis) ---
            */
            return default;
        }

        public async Task<string> GetDefaultInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_default_invoice_edi_format) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py, METHOD: _get_default_invoice_edi_format) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultMailAttachmentsWidgetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template, object invoice_edi_format, object extra_edis, object pdf_report) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_default_mail_attachments_widget) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultMailBodyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template, object mail_lang) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_default_mail_body) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultMailLangInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_default_mail_lang) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultMailPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template, object mail_lang) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_default_mail_partner_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultMailSubjectInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template, object mail_lang) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_default_mail_subject) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultMailTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_default_mail_template_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultPdfReportIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_default_pdf_report_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<object> GetDefaultSendingMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_default_sending_methods) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py, METHOD: _get_default_sending_methods) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultSendingSettingsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object from_cron) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_default_sending_settings) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceExtraAttachmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_invoice_extra_attachments_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceExtraAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_invoice_extra_attachments) ---
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move_send.py, METHOD: _get_invoice_extra_attachments) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py, METHOD: _get_invoice_extra_attachments) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMailAttachmentFromDocInternalAsync<TEntity>(IEnumerable<TEntity> entities, object doc) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move_send.py, METHOD: _get_mail_attachment_from_doc) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMailDefaultFieldValueFromTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template, object lang, object move, object field) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_mail_default_field_value_from_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetMailLayoutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_mail_layout) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py, METHOD: _get_mail_layout) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMailParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object move_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_mail_params) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMailTemplateAttachmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_mail_template_attachments_data) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMoveConstraintsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_move_constraints) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py, METHOD: _get_move_constraints) ---
            */
            return default;
        }

        public async Task<TEntity> GetPlaceholderMailAttachmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object invoice_edi_format, object extra_edis, object pdf_report) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_placeholder_mail_attachments_data) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py, METHOD: _get_placeholder_mail_attachments_data) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPlaceholderMailTemplateDynamicAttachmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template, object pdf_report) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _get_placeholder_mail_template_dynamic_attachments_data) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUblAvailableAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_attachments_widget, object invoice_edi_format) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py, METHOD: _get_ubl_available_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> HookIfErrorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves_data, object allow_raising) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _hook_if_errors) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py, METHOD: _hook_if_errors) ---
            */
            return default;
        }

        public async Task<TEntity> HookIfSuccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves_data, object from_cron) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _hook_if_success) ---
            --- METHOD SOURCE (MODULE: snailmail_account, FILE: account_move_send.py, METHOD: _hook_if_success) ---
            */
            return default;
        }

        public async Task<TEntity> HookInvoiceDocumentAfterPdfReportRenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _hook_invoice_document_after_pdf_report_render) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py, METHOD: _hook_invoice_document_after_pdf_report_render) ---
            */
            return default;
        }

        public async Task<TEntity> HookInvoiceDocumentBeforePdfReportRenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _hook_invoice_document_before_pdf_report_render) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py, METHOD: _hook_invoice_document_before_pdf_report_render) ---
            */
            return default;
        }

        public async Task<TEntity> IsApplicableToCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object method, object company) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _is_applicable_to_company) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py, METHOD: _is_applicable_to_company) ---
            */
            return default;
        }

        public async Task<TEntity> IsApplicableToMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object method, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _is_applicable_to_move) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_move_send.py, METHOD: _is_applicable_to_move) ---
            --- METHOD SOURCE (MODULE: snailmail_account, FILE: account_move_send.py, METHOD: _is_applicable_to_move) ---
            */
            return default;
        }

        public async Task<TEntity> LinkInvoiceDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _link_invoice_documents) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py, METHOD: _link_invoice_documents) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PostprocessInvoiceUblXmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move_send.py, METHOD: _postprocess_invoice_ubl_xml) ---
            #endif
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareInvoicePdfReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _prepare_invoice_pdf_report) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareInvoiceProformaPdfReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _prepare_invoice_proforma_pdf_report) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareSnailmailLetterValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail_account, FILE: account_move_send.py, METHOD: _prepare_snailmail_letter_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RaiseDangerAlertsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object alerts) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _raise_danger_alerts) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SendMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _send_mail) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SendMailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves_data) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _send_mails) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SendNotificationsToPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid moves_grouped_by_author_partner_id, object is_success) where TEntity : IEntity<Guid>, IAccountMoveSendable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move_send.py, METHOD: _send_notifications_to_partners) ---
            */
            return default;
        }
    }
}