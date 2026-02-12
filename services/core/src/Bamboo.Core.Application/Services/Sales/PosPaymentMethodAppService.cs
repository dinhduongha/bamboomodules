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
    public partial class PosPaymentMethodAppService : GenericAppService<PosPaymentMethod>, IPosPaymentMethodAppService
    {
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public PosPaymentMethodAppService(IRepository<PosPaymentMethod, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<PosPaymentMethod> CopyDataAsync(PosPaymentMethodCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<PosPaymentMethod> CreateAsync(CreateRequestDto<PosPaymentMethod> input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: pos_viva_com, FILE: pos_payment_method.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<PosPaymentMethod> ForcePdvAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py, METHOD: force_pdv) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> GetLatestAdyenStatusAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py, METHOD: get_latest_adyen_status) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> GetLatestVivaComStatusAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_viva_com, FILE: pos_payment_method.py, METHOD: get_latest_viva_com_status) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<PosPaymentMethod> GetProviderStatusAsync(PosPaymentMethodGetProviderStatusRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: get_provider_status) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> GetQrCodeAsync(PosPaymentMethodGetQrCodeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: get_qr_code) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> MpGetPaymentStatusAsync(PosPaymentMethodMpGetPaymentStatusRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py, METHOD: mp_get_payment_status) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> MpPaymentIntentCancelAsync(PosPaymentMethodMpPaymentIntentCancelRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py, METHOD: mp_payment_intent_cancel) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> MpPaymentIntentCreateAsync(PosPaymentMethodMpPaymentIntentCreateRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py, METHOD: mp_payment_intent_create) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> MpPaymentIntentGetAsync(PosPaymentMethodMpPaymentIntentGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py, METHOD: mp_payment_intent_get) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> PineLabsCancelPaymentRequestAsync(PosPaymentMethodPineLabsCancelPaymentRequestRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_pine_labs, FILE: pos_payment_method.py, METHOD: pine_labs_cancel_payment_request) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> PineLabsFetchPaymentStatusAsync(PosPaymentMethodPineLabsFetchPaymentStatusRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_pine_labs, FILE: pos_payment_method.py, METHOD: pine_labs_fetch_payment_status) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> PineLabsMakePaymentRequestAsync(PosPaymentMethodPineLabsMakePaymentRequestRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_pine_labs, FILE: pos_payment_method.py, METHOD: pine_labs_make_payment_request) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> ProxyAdyenRequestAsync(PosPaymentMethodProxyAdyenRequestRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_adyen, FILE: pos_payment_method.py, METHOD: proxy_adyen_request) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> QfpaySignRequestAsync(PosPaymentMethodQfpaySignRequestRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_qfpay, FILE: pos_payment_method.py, METHOD: qfpay_sign_request) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> RazorpayCancelPaymentRequestAsync(PosPaymentMethodRazorpayCancelPaymentRequestRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_razorpay, FILE: pos_payment_method.py, METHOD: razorpay_cancel_payment_request) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> RazorpayFetchPaymentStatusAsync(PosPaymentMethodRazorpayFetchPaymentStatusRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_razorpay, FILE: pos_payment_method.py, METHOD: razorpay_fetch_payment_status) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> RazorpayMakePaymentRequestAsync(PosPaymentMethodRazorpayMakePaymentRequestRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_razorpay, FILE: pos_payment_method.py, METHOD: razorpay_make_payment_request) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> RazorpayMakeRefundRequestAsync(PosPaymentMethodRazorpayMakeRefundRequestRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_razorpay, FILE: pos_payment_method.py, METHOD: razorpay_make_refund_request) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> SendDpopayRequestAsync(PosPaymentMethodSendDpopayRequestRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_dpopay, FILE: pos_payment_method.py, METHOD: send_dpopay_request) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<PosPaymentMethod> StripeCapturePaymentAsync(PosPaymentMethodStripeCapturePaymentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_stripe, FILE: pos_payment_method.py, METHOD: stripe_capture_payment) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<PosPaymentMethod> StripeConnectionTokenAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_stripe, FILE: pos_payment_method.py, METHOD: stripe_connection_token) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> StripeKeyAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_stripe, FILE: pos_payment_method.py, METHOD: action_stripe_key) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> StripePaymentIntentAsync(PosPaymentMethodStripePaymentIntentRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_stripe, FILE: pos_payment_method.py, METHOD: stripe_payment_intent) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> VivaComGetPaymentStatusAsync(PosPaymentMethodVivaComGetPaymentStatusRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_viva_com, FILE: pos_payment_method.py, METHOD: viva_com_get_payment_status) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> VivaComSendPaymentCancelAsync(PosPaymentMethodVivaComSendPaymentCancelRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_viva_com, FILE: pos_payment_method.py, METHOD: viva_com_send_payment_cancel) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> VivaComSendPaymentRequestAsync(PosPaymentMethodVivaComSendPaymentRequestRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_viva_com, FILE: pos_payment_method.py, METHOD: viva_com_send_payment_request) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PosPaymentMethod> VivaComSendRefundRequestAsync(PosPaymentMethodVivaComSendRefundRequestRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_viva_com, FILE: pos_payment_method.py, METHOD: viva_com_send_refund_request) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<PosPaymentMethod> input)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_payment_method.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: pos_mercado_pago, FILE: pos_payment_method.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment_method.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: pos_viva_com, FILE: pos_payment_method.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}