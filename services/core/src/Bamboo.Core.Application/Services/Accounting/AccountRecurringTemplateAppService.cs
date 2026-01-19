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
    public partial class AccountRecurringTemplateAppService : GenericApplicationService<AccountRecurringTemplate>, IAccountRecurringTemplateAppService
    {

        public AccountRecurringTemplateAppService(IRepository<AccountRecurringTemplate, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<AccountRecurringTemplate> ComputeNextCallInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_recurring_payments, FILE: recurring_template.py) ---
            // def _compute_next_call(self):
            // for rec in self:
            //     exec_date = rec.date_begin + relativedelta(days=rec.recurring_interval)
            //     if exec_date <= rec.date_end:
            //         rec.next_call = exec_date
            //     else:
            //         rec.state = 'done'
            */
            return default;
        }

        public async Task<AccountRecurringTemplate> DoneAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_recurring_payments, FILE: recurring_template.py) ---
            // def action_done(self):
            // for rec in self:
            //     rec.state = 'done'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<AccountRecurringTemplate> DraftAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_recurring_payments, FILE: recurring_template.py) ---
            // def action_draft(self):
            // for rec in self:
            //     rec.state = 'draft'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}