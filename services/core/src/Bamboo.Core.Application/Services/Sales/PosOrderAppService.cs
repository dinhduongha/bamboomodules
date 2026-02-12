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
    [Module("PointOfSale", Category = "Sales", Depends = new[] { "resource", "stock_account", "barcodes", "html_editor", "digest", "phone_validation", "partner_autocomplete", "iot_base", "google_address_autocomplete" })]
    public partial class PosOrderAppService : GenericAppService<PosOrder>, IPosOrderAppService
    {
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IPortalMixinAppService _portalMixinAppService;
        protected readonly IPosBusMixinAppService _posBusMixinAppService;
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public PosOrderAppService(IRepository<PosOrder, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService, IPortalMixinAppService portalMixinAppService, IPosBusMixinAppService posBusMixinAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
            _portalMixinAppService = portalMixinAppService;
            _posBusMixinAppService = posBusMixinAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<PosOrder> AddLoyaltyHistoryLinesAsync(PosOrderAddLoyaltyHistoryLinesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_order.py, METHOD: add_loyalty_history_lines) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> AddPaymentAsync(PosOrderAddPaymentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: add_payment) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> ConfirmCouponProgramsAsync(PosOrderConfirmCouponProgramsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_order.py, METHOD: confirm_coupon_programs) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<PosOrder> CreateAsync(CreateRequestDto<PosOrder> input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_order.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<PosOrder> CreateInvoicesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_create_invoices) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> GetAmountUnpaidAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_order.py, METHOD: get_amount_unpaid) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> GetAndSetOnlinePaymentsDataAsync(PosOrderGetAndSetOnlinePaymentsDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_order.py, METHOD: get_and_set_online_payments_data) ---
            --- METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_order.py, METHOD: get_and_set_online_payments_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> GetOrderToPrintAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_order.py, METHOD: get_order_to_print) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> GetPreparationChangeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: get_preparation_change) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> GetReferenceLastPartAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: get_reference_last_part) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> PosOrderCancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_pos_order_cancel) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_order.py, METHOD: action_pos_order_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> PosOrderInvoiceAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_pos_order_invoice) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> PosOrderPaidAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_pos_order_paid) ---
            --- METHOD SOURCE (MODULE: pos_restaurant_adyen, FILE: pos_order.py, METHOD: action_pos_order_paid) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> PrintEventBadgesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: pos_order.py, METHOD: print_event_badges) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> PrintEventTicketsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: pos_order.py, METHOD: print_event_tickets) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> ReadPosDataAsync(PosOrderReadPosDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: read_pos_data) ---
            --- METHOD SOURCE (MODULE: pos_event, FILE: pos_order.py, METHOD: read_pos_data) ---
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_order.py, METHOD: read_pos_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<PosOrder> ReadPosDataUuidAsync(PosOrderReadPosDataUuidRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: read_pos_data_uuid) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<PosOrder> ReadPosOrdersAsync(PosOrderReadPosOrdersRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: read_pos_orders) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> RefundAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: refund) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<PosOrder> RemoveFromUiAsync(PosOrderRemoveFromUiRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: remove_from_ui) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_order.py, METHOD: remove_from_ui) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<PosOrder> SearchPaidOrderIdsAsync(PosOrderSearchPaidOrderIdsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: search_paid_order_ids) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> SendMailAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_send_mail) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> SendReceiptAsync(PosOrderSendReceiptRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_send_receipt) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> SendSelfOrderReceiptAsync(PosOrderSendSelfOrderReceiptRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_order.py, METHOD: action_send_self_order_receipt) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> SentMessageOnSmsAsync(PosOrderSentMessageOnSmsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sms, FILE: pos_order.py, METHOD: action_sent_message_on_sms) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> StockPickingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_stock_picking) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<PosOrder> SyncFromUiAsync(PosOrderSyncFromUiRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: sync_from_ui) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py, METHOD: sync_from_ui) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_order.py, METHOD: sync_from_ui) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> ValidateCouponProgramsAsync(PosOrderValidateCouponProgramsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_order.py, METHOD: validate_coupon_programs) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> ViewAttendeeListAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: pos_order.py, METHOD: action_view_attendee_list) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> ViewInvoiceAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_view_invoice) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> ViewRefundOrdersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_view_refund_orders) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> ViewRefundedOrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_view_refunded_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosOrder> ViewSaleOrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py, METHOD: action_view_sale_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<PosOrder> input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_order.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_order.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_order.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}