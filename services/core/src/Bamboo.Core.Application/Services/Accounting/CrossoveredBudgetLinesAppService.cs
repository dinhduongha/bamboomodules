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
    [Module("OmAccountBudget", Category = "Accounting", Depends = new[] { "account" })]
    public partial class CrossoveredBudgetLinesAppService : GenericAppService<CrossoveredBudgetLines>, ICrossoveredBudgetLinesAppService
    {

        public CrossoveredBudgetLinesAppService(IRepository<CrossoveredBudgetLines, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<CrossoveredBudgetLines> OpenBudgetEntriesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py, METHOD: action_open_budget_entries) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}