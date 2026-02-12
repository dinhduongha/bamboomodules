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
    [Module("Lunch", Category = "HumanResources", Depends = new[] { "mail" })]
    public partial class LunchProductAppService : GenericAppService<LunchProduct>, ILunchProductAppService
    {
        protected readonly IImageMixinAppService _imageMixinAppService;
        public LunchProductAppService(IRepository<LunchProduct, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IImageMixinAppService imageMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _imageMixinAppService = imageMixinAppService;
        }

        public async Task<LunchProduct> ToggleActiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: toggle_active) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}