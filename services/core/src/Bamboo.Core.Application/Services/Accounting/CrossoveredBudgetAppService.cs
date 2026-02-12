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
    [Module("OmAccountBudget", Category = "Accounting", Depends = new[] { "account" })]
    public partial class CrossoveredBudgetAppService : GenericAppService<CrossoveredBudget>, ICrossoveredBudgetAppService
    {
        protected readonly IMailThreadAppService _mailThreadAppService;
        public CrossoveredBudgetAppService(IRepository<CrossoveredBudget, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<CrossoveredBudget> BudgetCancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py, METHOD: action_budget_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrossoveredBudget> BudgetConfirmAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py, METHOD: action_budget_confirm) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrossoveredBudget> BudgetDoneAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py, METHOD: action_budget_done) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrossoveredBudget> BudgetDraftAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py, METHOD: action_budget_draft) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<CrossoveredBudget> BudgetValidateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py, METHOD: action_budget_validate) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}