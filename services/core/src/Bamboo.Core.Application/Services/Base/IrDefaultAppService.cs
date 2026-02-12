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
    [Module("BaseModule", Category = "Base")]
    public partial class IrDefaultAppService : GenericAppService<IrDefault>, IIrDefaultAppService
    {

        public IrDefaultAppService(IRepository<IrDefault, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        [ApiModel]
        public async Task<IrDefault> DiscardRecordsAsync(IrDefaultDiscardRecordsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_default.py, METHOD: discard_records) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrDefault> DiscardValuesAsync(IrDefaultDiscardValuesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_default.py, METHOD: discard_values) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrDefault> SetAsync(IrDefaultSetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_default.py, METHOD: set) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}