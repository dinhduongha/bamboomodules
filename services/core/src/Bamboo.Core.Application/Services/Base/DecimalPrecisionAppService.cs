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
    [Module("BaseModule", Category = "Base")]
    public partial class DecimalPrecisionAppService : GenericAppService<DecimalPrecision>, IDecimalPrecisionAppService
    {
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public DecimalPrecisionAppService(IRepository<DecimalPrecision, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        [ApiModel]
        public async Task<DecimalPrecision> PrecisionGetAsync(DecimalPrecisionPrecisionGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: decimal_precision.py, METHOD: precision_get) ---
            --- METHOD SOURCE (MODULE: base, FILE: decimal_precision.py, METHOD: precision_get) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}