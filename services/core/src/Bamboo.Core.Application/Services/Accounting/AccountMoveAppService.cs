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
    [Module("Account", Category = "Accounting", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public partial class AccountMoveAppService : GenericAppService<AccountMove>, IAccountMoveAppService
    {
        protected readonly IAccountDocumentImportMixinAppService _accountDocumentImportMixinAppService;
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadMainAttachmentAppService _mailThreadMainAttachmentAppService;
        protected readonly IPortalMixinAppService _portalMixinAppService;
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        protected readonly IProductCatalogMixinAppService _productCatalogMixinAppService;
        protected readonly ISequenceMixinAppService _sequenceMixinAppService;
        protected readonly IUtmMixinAppService _utmMixinAppService;
        public AccountMoveAppService(IRepository<AccountMove, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAccountDocumentImportMixinAppService accountDocumentImportMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadMainAttachmentAppService mailThreadMainAttachmentAppService, IPortalMixinAppService portalMixinAppService, IPosLoadMixinAppService posLoadMixinAppService, IProductCatalogMixinAppService productCatalogMixinAppService, ISequenceMixinAppService sequenceMixinAppService, IUtmMixinAppService utmMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _accountDocumentImportMixinAppService = accountDocumentImportMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadMainAttachmentAppService = mailThreadMainAttachmentAppService;
            _portalMixinAppService = portalMixinAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
            _productCatalogMixinAppService = productCatalogMixinAppService;
            _sequenceMixinAppService = sequenceMixinAppService;
            _utmMixinAppService = utmMixinAppService;
        }

        public async Task<AccountMove> ActivateCurrencyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_activate_currency) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> AddFromCatalogAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_add_from_catalog) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ButtonAbandonCancelPostedPostedMovesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: button_abandon_cancel_posted_posted_moves) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ButtonCancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_cancel) ---
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: button_cancel) ---
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py, METHOD: button_cancel) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: account_move.py, METHOD: button_cancel) ---
            --- METHOD SOURCE (MODULE: sale, FILE: account_move.py, METHOD: button_cancel) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: account_move.py, METHOD: button_cancel) ---
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account.py, METHOD: button_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ButtonCancelPostedMovesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: button_cancel_posted_moves) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ButtonCreateLandedCostsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py, METHOD: button_create_landed_costs) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ButtonDraftAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_draft) ---
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: button_draft) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py, METHOD: button_draft) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: account_invoice.py, METHOD: button_draft) ---
            --- METHOD SOURCE (MODULE: sale, FILE: account_move.py, METHOD: button_draft) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: account_move.py, METHOD: button_draft) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: account_move.py, METHOD: button_draft) ---
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py, METHOD: button_draft) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ButtonForceCancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: button_force_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ButtonHashAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_hash) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ButtonProcessEdiWebServicesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: button_process_edi_web_services) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ButtonRequestCancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_request_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ButtonSetCheckedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_set_checked) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> CancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py, METHOD: action_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> CancelPeppolDocumentsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_move.py, METHOD: action_cancel_peppol_documents) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> CheckMoveSequenceChainAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: check_move_sequence_chain) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> CheckSelectedMovesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: check_selected_moves) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ComputeMoveSentValuesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: compute_move_sent_values) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<AccountMove> CopyAsync(CopyRequestDto<AccountMove> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: copy) ---
            --- METHOD SOURCE (MODULE: mrp_account, FILE: account_move.py, METHOD: copy) ---
            */
            return await base.CopyAsync(input);
        }

        public async Task<AccountMove> CopyDataAsync(AccountMoveCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: account_move.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<AccountMove> CreateAsync(CreateRequestDto<AccountMove> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<AccountMove> DebitNoteAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_debit_note, FILE: account_move.py, METHOD: action_debit_note) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> DuplicateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_duplicate) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ForceRegisterPaymentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_force_register_payment) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> GetCurrencyRateAsync(AccountMoveGetCurrencyRateRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_currency_rate) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> GetExtraPrintItemsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_extra_print_items) ---
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py, METHOD: get_extra_print_items) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountMove> GetImportTemplatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_import_templates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountMove> GetInboundTypesAsync(AccountMoveGetInboundTypesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_inbound_types) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountMove> GetInvoiceLocalisationFieldsRequiredToInvoiceAsync(AccountMoveGetInvoiceLocalisationFieldsRequiredToInvoiceRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_invoice_localisation_fields_required_to_invoice) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountMove> GetInvoiceTypesAsync(AccountMoveGetInvoiceTypesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_invoice_types) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountMove> GetOutboundTypesAsync(AccountMoveGetOutboundTypesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_outbound_types) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiPrivate]
        public async Task<AccountMove> GetPortalLastTransactionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_move.py, METHOD: get_portal_last_transaction) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountMove> GetPurchaseTypesAsync(AccountMoveGetPurchaseTypesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_purchase_types) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountMove> GetSaleTypesAsync(AccountMoveGetSaleTypesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_sale_types) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> InvoiceDownloadPdfAsync(AccountMoveInvoiceDownloadPdfRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_invoice_download_pdf) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> InvoiceDownloadUblAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: account_move.py, METHOD: action_invoice_download_ubl) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> InvoiceSentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_invoice_sent) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> InvoiceValidateSendEmailAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product_email_template, FILE: account_move.py, METHOD: invoice_validate_send_email) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> IsEntryAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_entry) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> IsInboundAsync(AccountMoveIsInboundRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_inbound) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> IsInvoiceAsync(AccountMoveIsInvoiceRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_invoice) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> IsOutboundAsync(AccountMoveIsOutboundRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_outbound) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> IsPurchaseDocumentAsync(AccountMoveIsPurchaseDocumentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_purchase_document) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> IsReceiptAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_receipt) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> IsSaleDocumentAsync(AccountMoveIsSaleDocumentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_sale_document) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> JsAssignOutstandingLineAsync(AccountMoveJsAssignOutstandingLineRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: js_assign_outstanding_line) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> JsRemoveOutstandingPartialAsync(AccountMoveJsRemoveOutstandingPartialRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: js_remove_outstanding_partial) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<AccountMove> MessageNewAsync(AccountMoveMessageNewRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: message_new) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> MoveDownloadAllAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_move_download_all) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> OpenAdjustingEntriesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_adjusting_entries) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> OpenAdjustingEntryOriginMovesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_adjusting_entry_origin_moves) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> OpenBusinessDocAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_open_business_doc) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> OpenCreatedCabaEntriesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_created_caba_entries) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> OpenExpenseAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: account_move.py, METHOD: action_open_expense) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> OpenPaymentsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_payments) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> OpenReconcileViewAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_reconcile_view) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> PaymentCaptureAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_move.py, METHOD: payment_action_capture) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> PaymentVoidAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_move.py, METHOD: payment_action_void) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> PostAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_post) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: account_move.py, METHOD: action_post) ---
            --- METHOD SOURCE (MODULE: sale, FILE: account_move.py, METHOD: action_post) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move.py, METHOD: action_post) ---
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account.py, METHOD: action_post) ---
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_move.py, METHOD: action_post) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> PreviewInvoiceAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: preview_invoice) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: account_move.py, METHOD: preview_invoice) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> PrintPdfAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_print_pdf) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ProcessEdiWebServicesAsync(AccountMoveProcessEdiWebServicesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: action_process_edi_web_services) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> PurchaseMatchingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: action_purchase_matching) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ReflectCancelledSolAsync(AccountMoveReflectCancelledSolRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: account_move.py, METHOD: reflect_cancelled_sol) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> RefreshInvoiceCurrencyRateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: refresh_invoice_currency_rate) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> RegisterPaymentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_register_payment) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> RetryEdiDocumentsErrorAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi, FILE: account_move.py, METHOD: action_retry_edi_documents_error) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ReverseAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_reverse) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> SendAndPrintAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_send_and_print) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: account_move.py, METHOD: action_send_and_print) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> SetMovesCheckedAsync(AccountMoveSetMovesCheckedRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: set_moves_checked) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> SwitchMoveTypeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_switch_move_type) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ToggleBlockPaymentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_toggle_block_payment) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: sale, FILE: account_move.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: sale_expense, FILE: account_move.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public async Task<AccountMove> UnlinkSnailmailLettersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail_account, FILE: account_move.py, METHOD: unlink_snailmail_letters) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> UpdateFposValuesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_update_fpos_values) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ValidateMovesWithConfirmationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_validate_moves_with_confirmation) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ViewDebitNotesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_debit_note, FILE: account_move.py, METHOD: action_view_debit_notes) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ViewLandedCostsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: account_move.py, METHOD: action_view_landed_costs) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ViewPaymentTransactionsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: account_move.py, METHOD: action_view_payment_transactions) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ViewSourcePosOrdersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: account_move.py, METHOD: action_view_source_pos_orders) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ViewSourcePurchaseOrdersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: action_view_source_purchase_orders) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ViewSourceSaleOrdersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: account_move.py, METHOD: action_view_source_sale_orders) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ViewTimesheetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: account_move.py, METHOD: action_view_timesheet) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<AccountMove> ViewWipProductionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_account, FILE: account_move.py, METHOD: action_view_wip_production) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<AccountMove> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: account_invoice.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}