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
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("OmRecurringPayments", Category = "Accounting", Depends = new[] { "account" })]
    public partial class RecurringPaymentAppService : GenericAppService<RecurringPayment>, IRecurringPaymentAppService
    {

        public RecurringPaymentAppService(IRepository<RecurringPayment, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<RecurringPayment> ComputeNextDateAsync(RecurringPaymentComputeNextDateRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_recurring_payments, FILE: recurring_payment.py, METHOD: compute_next_date) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RecurringPayment> CreateLinesAsync(RecurringPaymentCreateLinesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_recurring_payments, FILE: recurring_payment.py, METHOD: action_create_lines) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RecurringPayment> DoneAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_recurring_payments, FILE: recurring_payment.py, METHOD: action_done) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RecurringPayment> DraftAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_recurring_payments, FILE: recurring_payment.py, METHOD: action_draft) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<RecurringPayment> GeneratePaymentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_recurring_payments, FILE: recurring_payment.py, METHOD: action_generate_payment) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}