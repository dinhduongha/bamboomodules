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
    [Module("Sale", Category = "Sales", Depends = new[] { "sales_team", "account_payment", "utm" })]
    public partial class SaleOrderAppService : GenericAppService<SaleOrder>, ISaleOrderAppService
    {
        protected readonly IAccountDocumentImportMixinAppService _accountDocumentImportMixinAppService;
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IPortalMixinAppService _portalMixinAppService;
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        protected readonly IProductCatalogMixinAppService _productCatalogMixinAppService;
        protected readonly IUtmMixinAppService _utmMixinAppService;
        public SaleOrderAppService(IRepository<SaleOrder, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAccountDocumentImportMixinAppService accountDocumentImportMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IPortalMixinAppService portalMixinAppService, IPosLoadMixinAppService posLoadMixinAppService, IProductCatalogMixinAppService productCatalogMixinAppService, IUtmMixinAppService utmMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _accountDocumentImportMixinAppService = accountDocumentImportMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _portalMixinAppService = portalMixinAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
            _productCatalogMixinAppService = productCatalogMixinAppService;
            _utmMixinAppService = utmMixinAppService;
        }

        public async Task<SaleOrder> CancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ConfirmAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: sale_order.py, METHOD: action_confirm) ---
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: sale_order.py, METHOD: action_confirm) ---
            --- METHOD SOURCE (MODULE: event_sale, FILE: sale_order.py, METHOD: action_confirm) ---
            --- METHOD SOURCE (MODULE: partnership, FILE: sale_order.py, METHOD: action_confirm) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_confirm) ---
            --- METHOD SOURCE (MODULE: sale_crm, FILE: sale_order.py, METHOD: action_confirm) ---
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: sale_order.py, METHOD: action_confirm) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: action_confirm) ---
            --- METHOD SOURCE (MODULE: sale_management, FILE: sale_order.py, METHOD: action_confirm) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py, METHOD: action_confirm) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: action_confirm) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<SaleOrder> CopyAsync(CopyRequestDto<SaleOrder> input)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: copy) ---
            */
            return await base.CopyAsync(input);
        }

        public async Task<SaleOrder> CopyDataAsync(SaleOrderCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<SaleOrder> CreateAsync(CreateRequestDto<SaleOrder> input)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<SaleOrder> CreateDocumentFromAttachmentAsync(SaleOrderCreateDocumentFromAttachmentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: create_document_from_attachment) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> CreateProjectAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py, METHOD: action_create_project) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public override async Task<SaleOrder> DefaultGetAsync(DefaultGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py, METHOD: default_get) ---
            */
            return await base.DefaultGetAsync(input);
        }

        public async Task<SaleOrder> DraftAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_draft) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<SaleOrder> GetEmptyListHelpAsync(SaleOrderGetEmptyListHelpRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: get_empty_list_help) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> GetFirstServiceLineAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py, METHOD: get_first_service_line) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<SaleOrder> GetImportTemplatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: get_import_templates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> GetPortalLastTransactionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: get_portal_last_transaction) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> GetPromoCodeErrorAsync(SaleOrderGetPromoCodeErrorRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: get_promo_code_error) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> GetPromoCodeSuccessMessageAsync(SaleOrderGetPromoCodeSuccessMessageRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_loyalty, FILE: sale_order.py, METHOD: get_promo_code_success_message) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> GetReportMatrixesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_product_matrix, FILE: sale_order.py, METHOD: get_report_matrixes) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> GetUpdateIncludedPdfParamsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_pdf_quote_builder, FILE: sale_order.py, METHOD: get_update_included_pdf_params) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> LoadSaleOrderFromPosAsync(SaleOrderLoadSaleOrderFromPosRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: load_sale_order_from_pos) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> LockAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_lock) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> MessagePostAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: message_post) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> OnchangeOrderLineAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order.py, METHOD: onchange_order_line) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> OpenBusinessDocAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_open_business_doc) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> OpenDeliveryWizardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order.py, METHOD: action_open_delivery_wizard) ---
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: sale_order.py, METHOD: action_open_delivery_wizard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> OpenDiscountWizardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_open_discount_wizard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> OpenRewardWizardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: action_open_reward_wizard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> PaymentCaptureAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: payment_action_capture) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> PaymentVoidAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: payment_action_void) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> PreviewSaleOrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_preview_sale_order) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: action_preview_sale_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> QuotationSendAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_quotation_send) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> QuotationSentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_quotation_sent) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> RecoveryEmailSendAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: sale_order.py, METHOD: action_recovery_email_send) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> SetDeliveryLineAsync(SaleOrderSetDeliveryLineRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: sale_order.py, METHOD: set_delivery_line) ---
            --- METHOD SOURCE (MODULE: stock_delivery, FILE: sale_order.py, METHOD: set_delivery_line) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ShowRepairAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: sale_order.py, METHOD: action_show_repair) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> UnlockAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_unlock) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> UpdatePricesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_update_prices) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> UpdateTaxesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_update_taxes) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewAttendeeListAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: sale_order.py, METHOD: action_view_attendee_list) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewBoothListAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: sale_order.py, METHOD: action_view_booth_list) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewDeliveryAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: action_view_delivery) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: sale.py, METHOD: action_view_delivery) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewDropshipAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: sale.py, METHOD: action_view_dropship) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewGiftCardsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: sale_order.py, METHOD: action_view_gift_cards) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewInvoiceAsync(SaleOrderViewInvoiceRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_view_invoice) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewMilestoneAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py, METHOD: action_view_milestone) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewMrpProductionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_mrp, FILE: sale_order.py, METHOD: action_view_mrp_production) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewPosOrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: sale_order.py, METHOD: action_view_pos_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewProjectIdsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py, METHOD: action_view_project_ids) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewPurchaseOrdersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: sale_order.py, METHOD: action_view_purchase_orders) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<SaleOrder> ViewTimesheetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: sale_order.py, METHOD: action_view_timesheet) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<SaleOrder> input)
        {
            /*
            --- METHOD SOURCE (MODULE: event_sale, FILE: sale_order.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: sale_order.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale_stock, FILE: sale_order.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}