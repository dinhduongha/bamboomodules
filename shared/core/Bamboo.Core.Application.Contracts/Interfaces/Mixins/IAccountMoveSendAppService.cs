using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
namespace Bamboo.Core.Application.Contracts.Interfaces.Mixins
{
    public interface IAccountMoveSendAppService : IMixinAppService
    {
        Task<TEntity> ActionWhatIsPeppolActivateAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> CallWebServiceAfterInvoicePdfRenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices_data) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> CallWebServiceBeforeInvoicePdfRenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices_data) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> CanCommitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> CheckInvoiceReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> CheckMoveConstrainsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> CheckSendingDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> DoPeppolPreSendInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> FormatErrorHtmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> FormatErrorTextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GenerateAndSendInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves, object from_cron, object allow_raising, object allow_fallback_pdf) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GenerateDynamicReportsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves_data) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GenerateInvoiceDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices_data, object allow_fallback_pdf) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GenerateInvoiceFallbackDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices_data) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GetAlertsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves, object moves_data) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<Dictionary<string, object>> GetAllExtraEdisInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<object> GetDefaultExtraEdisInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<string> GetDefaultInvoiceEdiFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GetDefaultMailAttachmentsWidgetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template, object invoice_edi_format, object extra_edis, object pdf_report) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GetDefaultMailBodyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template, object mail_lang) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GetDefaultMailLangInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GetDefaultMailPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template, object mail_lang) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GetDefaultMailSubjectInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template, object mail_lang) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GetDefaultMailTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GetDefaultPdfReportIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<object> GetDefaultSendingMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GetDefaultSendingSettingsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object from_cron) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GetInvoiceExtraAttachmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GetInvoiceExtraAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GetMailAttachmentFromDocInternalAsync<TEntity>(IEnumerable<TEntity> entities, object doc) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GetMailDefaultFieldValueFromTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template, object lang, object move, object field) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GetMailLayoutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GetMailParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object move_data) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GetMailTemplateAttachmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GetPlaceholderMailAttachmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object invoice_edi_format, object extra_edis) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> GetPlaceholderMailTemplateDynamicAttachmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template, object pdf_report) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> HookIfErrorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves_data, object allow_raising) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> HookIfSuccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves_data) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> HookInvoiceDocumentAfterPdfReportRenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_data) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> HookInvoiceDocumentBeforePdfReportRenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_data) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> IsApplicableToCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object method, object company) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> IsApplicableToMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object method, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> LinkInvoiceDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices_data) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> PostprocessInvoiceUblXmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_data) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> PrepareInvoicePdfReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoices_data) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> PrepareInvoiceProformaPdfReportInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object invoice_data) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> PrepareSnailmailLetterValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> RaiseDangerAlertsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object alerts) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> SendMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object mail_template) where TEntity : IEntity<Guid>, IAccountMoveSendable;
        Task<TEntity> SendMailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves_data) where TEntity : IEntity<Guid>, IAccountMoveSendable;
    }
}