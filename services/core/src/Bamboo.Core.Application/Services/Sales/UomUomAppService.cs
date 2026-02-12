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
    [Module("Uom", Category = "Sales", Depends = new[] { "base" })]
    public partial class UomUomAppService : GenericAppService<UomUom>, IUomUomAppService
    {
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public UomUomAppService(IRepository<UomUom, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<UomUom> CompareAsync(UomUomCompareRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: uom, FILE: uom_uom.py, METHOD: compare) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<bool> IsZeroAsync(UomUomIsZeroRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: uom, FILE: uom_uom.py, METHOD: is_zero) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<UomUom> OpenPackagingBarcodesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: uom_uom.py, METHOD: action_open_packaging_barcodes) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<float> RoundAsync(UomUomRoundRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: uom, FILE: uom_uom.py, METHOD: round) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<UomUom> input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: product.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}