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
    public partial class IrAssetAppService : GenericAppService<IrAsset>, IIrAssetAppService
    {

        public IrAssetAppService(IRepository<IrAsset, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<IrAsset> FilterDuplicateAsync(IrAssetFilterDuplicateRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_asset.py, METHOD: filter_duplicate) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<IrAsset> input)
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_asset.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_asset.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}