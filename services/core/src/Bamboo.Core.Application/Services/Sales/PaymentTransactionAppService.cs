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
    public partial class PaymentTransactionAppService : GenericAppService<PaymentTransaction>, IPaymentTransactionAppService
    {

        public PaymentTransactionAppService(IRepository<PaymentTransaction, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<PaymentTransaction> CaptureAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: action_capture) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<PaymentTransaction> CreateAsync(CreateRequestDto<PaymentTransaction> input)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: payment_redsys, FILE: payment_transaction.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<PaymentTransaction> DemoSetCanceledAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py, METHOD: action_demo_set_canceled) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentTransaction> DemoSetDoneAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py, METHOD: action_demo_set_done) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentTransaction> DemoSetErrorAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: payment_demo, FILE: payment_transaction.py, METHOD: action_demo_set_error) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentTransaction> PostProcessAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: action_post_process) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentTransaction> RefundAsync(PaymentTransactionRefundRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: action_refund) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentTransaction> ViewInvoicesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account_payment, FILE: payment_transaction.py, METHOD: action_view_invoices) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentTransaction> ViewPosOrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: payment_transaction.py, METHOD: action_view_pos_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentTransaction> ViewRefundsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: action_view_refunds) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentTransaction> ViewSalesOrdersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: payment_transaction.py, METHOD: action_view_sales_orders) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<PaymentTransaction> VoidAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: payment_transaction.py, METHOD: action_void) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}