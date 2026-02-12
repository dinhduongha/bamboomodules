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
    public partial class IrSequenceAppService : GenericAppService<IrSequence>, IIrSequenceAppService
    {

        public IrSequenceAppService(IRepository<IrSequence, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<IrSequence> GetNextCharAsync(IrSequenceGetNextCharRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_sequence.py, METHOD: get_next_char) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrSequence> NextByCodeAsync(IrSequenceNextByCodeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_sequence.py, METHOD: next_by_code) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<IrSequence> NextByIdAsync(IrSequenceNextByIdRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_sequence.py, METHOD: next_by_id) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}