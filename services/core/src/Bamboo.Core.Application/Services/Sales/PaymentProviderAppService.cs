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
    [Module("Payment", Category = "Sales", Depends = new[] { "onboarding", "portal" })]
    public partial class PaymentProviderAppService : GenericAppService<PaymentProvider>, IPaymentProviderAppService
    {

        public PaymentProviderAppService(IRepository<PaymentProvider, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<PaymentProvider> ButtonImmediateInstallAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: button_immediate_install) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<PaymentProvider> CopyAsync(CopyRequestDto<PaymentProvider> input)
        {
            /*
            --- METHOD SOURCE (MODULE: website_payment, FILE: payment_provider.py, METHOD: copy) ---
            */
            return await base.CopyAsync(input);
        }

        public override async Task<PaymentProvider> CreateAsync(CreateRequestDto<PaymentProvider> input)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: payment_custom, FILE: payment_provider.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<PaymentProvider> GetBaseUrlAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_payment, FILE: payment_provider.py, METHOD: get_base_url) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentProvider> PaypalCreateWebhookAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_paypal, FILE: payment_provider.py, METHOD: action_paypal_create_webhook) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentProvider> RazorpayCreateWebhookAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py, METHOD: action_razorpay_create_webhook) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentProvider> RecomputePendingMsgAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_custom, FILE: payment_provider.py, METHOD: action_recompute_pending_msg) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentProvider> ResetCredentialsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: action_reset_credentials) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentProvider> StartOnboardingAsync(PaymentProviderStartOnboardingRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: action_start_onboarding) ---
            --- METHOD SOURCE (MODULE: payment_mercado_pago, FILE: payment_provider.py, METHOD: action_start_onboarding) ---
            --- METHOD SOURCE (MODULE: payment_razorpay, FILE: payment_provider.py, METHOD: action_start_onboarding) ---
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: action_start_onboarding) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentProvider> StripeCreateWebhookAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: action_stripe_create_webhook) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentProvider> StripeVerifyApplePayDomainAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_stripe, FILE: payment_provider.py, METHOD: action_stripe_verify_apple_pay_domain) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentProvider> SyncPaymobPaymentMethodsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_paymob, FILE: payment_provider.py, METHOD: action_sync_paymob_payment_methods) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentProvider> ToggleIsPublishedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: action_toggle_is_published) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentProvider> UpdateMerchantDetailsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_authorize, FILE: payment_provider.py, METHOD: action_update_merchant_details) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentProvider> ViewPaymentMethodsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: action_view_payment_methods) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<PaymentProvider> input)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_provider.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: payment_adyen, FILE: payment_provider.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}