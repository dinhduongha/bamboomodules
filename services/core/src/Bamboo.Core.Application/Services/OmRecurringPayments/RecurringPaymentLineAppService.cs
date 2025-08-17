using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("OmRecurringPayments", Depends = new[] { "account" })]
    public class RecurringPaymentLineAppService : GenericApplicationService<RecurringPaymentLine>, IRecurringPaymentLineAppService
    {

        public RecurringPaymentLineAppService(IRepository<RecurringPaymentLine, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<RecurringPaymentLine> CreatePaymentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_recurring_payments, FILE: recurring_payment.py) ---
            // def action_create_payment(self):
            // vals = {
            //     'payment_type': self.recurring_payment_id.payment_type,
            //     'amount': self.amount,
            //     'currency_id': self.currency_id.id,
            //     'journal_id': self.journal_id.id,
            //     'company_id': self.company_id.id,
            //     'date': self.date,
            //     'memo': self.recurring_payment_id.name,
            //     'partner_id': self.partner_id.id,
            // }
            // payment = self.env['account.payment'].create(vals)
            // if payment:
            //     if self.recurring_payment_id.journal_state == 'posted':
            //         payment.action_post()
            //     self.write({'state': 'done', 'payment_id': payment.id})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}