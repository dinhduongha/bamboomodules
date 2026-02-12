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
    public partial class IrFiltersAppService : GenericAppService<IrFilters>, IIrFiltersAppService
    {

        public IrFiltersAppService(IRepository<IrFilters, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<IrFilters> CopyDataAsync(IrFiltersCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_filters.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrFilters> CreateFilterAsync(IrFiltersCreateFilterRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_filters.py, METHOD: create_filter) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<IrFilters> GetFiltersAsync(IrFiltersGetFiltersRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_filters.py, METHOD: get_filters) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}