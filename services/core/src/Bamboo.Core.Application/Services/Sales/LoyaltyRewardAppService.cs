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
    [Module("Loyalty", Category = "Sales", Depends = new[] { "product", "portal", "account" })]
    public partial class LoyaltyRewardAppService : GenericAppService<LoyaltyReward>, ILoyaltyRewardAppService
    {
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public LoyaltyRewardAppService(IRepository<LoyaltyReward, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_reward.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: loyalty_reward.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: sale_loyalty, FILE: loyalty_reward.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }
    }
}