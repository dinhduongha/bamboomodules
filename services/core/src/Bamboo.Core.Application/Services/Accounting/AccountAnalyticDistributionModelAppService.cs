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
    [Module("Analytic", Category = "Accounting", Depends = new[] { "base", "mail", "uom" })]
    public partial class AccountAnalyticDistributionModelAppService : GenericAppService<AccountAnalyticDistributionModel>, IAccountAnalyticDistributionModelAppService
    {
        protected readonly IAnalyticMixinAppService _analyticMixinAppService;
        public AccountAnalyticDistributionModelAppService(IRepository<AccountAnalyticDistributionModel, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAnalyticMixinAppService analyticMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _analyticMixinAppService = analyticMixinAppService;
        }

        public async Task<AccountAnalyticDistributionModel> ReadDistributionModelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_distribution_model.py, METHOD: action_read_distribution_model) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}