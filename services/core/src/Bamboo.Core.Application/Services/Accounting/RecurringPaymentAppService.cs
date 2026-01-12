using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("OmRecurringPayments", Category = "Accounting", Depends = new[] { "account" })]
    public class RecurringPaymentAppService : GenericApplicationService<RecurringPayment>, IRecurringPaymentAppService
    {

        public RecurringPaymentAppService(IRepository<RecurringPayment, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<RecurringPayment> CheckAmountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_recurring_payments, FILE: recurring_payment.py) ---
            // def _check_amount(self):
            // if self.amount <= 0:
            //     raise ValidationError(_('Amount Must Be Non-Zero Positive Number'))
            */
            return default;
        }

        public async Task<RecurringPayment> ComputeNextDateAsync(Guid id, RecurringPaymentComputeNextDateRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_recurring_payments, FILE: recurring_payment.py) ---
            // def compute_next_date(self, date):
            // period = self.recurring_period
            // interval = self.recurring_interval
            // if period == 'days':
            //     date += relativedelta(days=interval)
            // elif period == 'weeks':
            //     date += relativedelta(weeks=interval)
            // elif period == 'months':
            //     date += relativedelta(months=interval)
            // else:
            //     date += relativedelta(years=interval)
            // return date
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<RecurringPayment> CreateLinesAsync(Guid id, RecurringPaymentCreateLinesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_recurring_payments, FILE: recurring_payment.py) ---
            // def action_create_lines(self, date):
            // ids = self.env['recurring.payment.line']
            // vals = {
            //     'partner_id': self.partner_id.id,
            //     'amount': self.amount,
            //     'date': date,
            //     'recurring_payment_id': self.id,
            //     'journal_id': self.journal_id.id,
            //     'currency_id': self.currency_id.id,
            //     'state': 'draft'
            // }
            // ids.create(vals)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<RecurringPayment> DoneAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_recurring_payments, FILE: recurring_payment.py) ---
            // def action_done(self):
            // date_begin = self.date_begin
            // while date_begin < self.date_end:
            //     date = date_begin
            //     self.action_create_lines(date)
            //     date_begin = self.compute_next_date(date)
            // self.state = 'done'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<RecurringPayment> DraftAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_recurring_payments, FILE: recurring_payment.py) ---
            // def action_draft(self):
            // if self.line_ids.filtered(lambda t: t.state == 'done'):
            //     raise ValidationError(_('You cannot Set to Draft as one of the line is already in done state'))
            // else:
            //     for line in self.line_ids:
            //         line.unlink()
            //     self.state = 'draft'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<RecurringPayment> GeneratePaymentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_recurring_payments, FILE: recurring_payment.py) ---
            // def action_generate_payment(self):
            // line_ids = self.env['recurring.payment.line'].search([('date', '<=', date.today()),
            //                                                                ('state', '!=', 'done')])
            // for line in line_ids:
            //     line.action_create_payment()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}