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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("OmAccountBudget", Category = "Accounting", Depends = new[] { "account" })]
    public class CrossoveredBudgetAppService : GenericApplicationService<CrossoveredBudget>, ICrossoveredBudgetAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        public CrossoveredBudgetAppService(IRepository<CrossoveredBudget, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<CrossoveredBudget> BudgetCancelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py) ---
            // def action_budget_cancel(self):
            // self.write({'state': 'cancel'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrossoveredBudget> BudgetConfirmAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py) ---
            // def action_budget_confirm(self):
            // self.write({'state': 'confirm'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrossoveredBudget> BudgetDoneAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py) ---
            // def action_budget_done(self):
            // self.write({'state': 'done'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrossoveredBudget> BudgetDraftAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py) ---
            // def action_budget_draft(self):
            // self.write({'state': 'draft'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrossoveredBudget> BudgetValidateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py) ---
            // def action_budget_validate(self):
            // self.write({'state': 'validate'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}