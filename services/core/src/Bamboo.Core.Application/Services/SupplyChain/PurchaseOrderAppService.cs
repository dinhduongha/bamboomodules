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
    [Module("Purchase", Category = "SupplyChain", Depends = new[] { "account" })]
    public partial class PurchaseOrderAppService : GenericAppService<PurchaseOrder>, IPurchaseOrderAppService
    {
        protected readonly IAccountDocumentImportMixinAppService _accountDocumentImportMixinAppService;
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IPortalMixinAppService _portalMixinAppService;
        protected readonly IProductCatalogMixinAppService _productCatalogMixinAppService;
        public PurchaseOrderAppService(IRepository<PurchaseOrder, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAccountDocumentImportMixinAppService accountDocumentImportMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IPortalMixinAppService portalMixinAppService, IProductCatalogMixinAppService productCatalogMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _accountDocumentImportMixinAppService = accountDocumentImportMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _portalMixinAppService = portalMixinAppService;
            _productCatalogMixinAppService = productCatalogMixinAppService;
        }

        public async Task<PurchaseOrder> AcknowledgeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_acknowledge) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> AddFromCatalogAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_add_from_catalog) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: action_add_from_catalog) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> BillMatchingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_bill_matching) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> ButtonApproveAsync(PurchaseOrderButtonApproveRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_approve) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: button_approve) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> ButtonCancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_cancel) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: button_cancel) ---
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: purchase_order.py, METHOD: button_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> ButtonConfirmAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_confirm) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py, METHOD: button_confirm) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> ButtonDraftAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_draft) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> ButtonLockAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_lock) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> ButtonUnlockAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_unlock) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> CompareAlternativeLinesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py, METHOD: action_compare_alternative_lines) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> CreateAlternativeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py, METHOD: action_create_alternative) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<PurchaseOrder> CreateAsync(CreateRequestDto<PurchaseOrder> input)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<PurchaseOrder> CreateDocumentFromAttachmentAsync(PurchaseOrderCreateDocumentFromAttachmentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: create_document_from_attachment) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> CreateInvoiceAsync(PurchaseOrderCreateInvoiceRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_create_invoice) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> GetAcknowledgeUrlAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_acknowledge_url) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> GetConfirmUrlAsync(PurchaseOrderGetConfirmUrlRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_confirm_url) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<PurchaseOrder> GetImportTemplatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_import_templates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> GetLocalizedDatePlannedAsync(PurchaseOrderGetLocalizedDatePlannedRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_localized_date_planned) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> GetOrderTimezoneAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_order_timezone) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> GetReportMatrixesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_product_matrix, FILE: purchase.py, METHOD: get_report_matrixes) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> GetTenderBestLinesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py, METHOD: get_tender_best_lines) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> GetUpdateUrlAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_update_url) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> MergeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_merge) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> MessagePostAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: message_post) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> OnchangeDatePlannedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: onchange_date_planned) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> OnchangePartnerIdAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: onchange_partner_id) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> OnchangePickingTypeIdAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: purchase.py, METHOD: onchange_picking_type_id) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> OpenBusinessDocAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_open_business_doc) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> PrintQuotationAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: print_quotation) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> PurchaseComparisonAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_purchase_comparison) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> PurchaseOrderSuggestAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: action_purchase_order_suggest) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<PurchaseOrder> RetrieveDashboardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: retrieve_dashboard) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: retrieve_dashboard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> RfqSendAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_rfq_send) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> SendReminderPreviewAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: send_reminder_preview) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> ViewDropshipAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: purchase.py, METHOD: action_view_dropship) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> ViewInvoiceAsync(PurchaseOrderViewInvoiceRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_view_invoice) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> ViewMrpProductionsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_mrp, FILE: purchase.py, METHOD: action_view_mrp_productions) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> ViewPickingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: action_view_picking) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: purchase.py, METHOD: action_view_picking) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> ViewRepairOrdersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_repair, FILE: purchase_order.py, METHOD: action_view_repair_orders) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> ViewSaleOrdersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_purchase, FILE: purchase_order.py, METHOD: action_view_sale_orders) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PurchaseOrder> ViewSubcontractingResupplyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_purchase, FILE: purchase_order.py, METHOD: action_view_subcontracting_resupply) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<PurchaseOrder> input)
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: purchase_order.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}