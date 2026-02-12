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
    [Module("Stock", Category = "SupplyChain", Depends = new[] { "product", "barcodes_gs1_nomenclature", "digest" })]
    public partial class ProcurementGroupAppService : GenericAppService<ProcurementGroup>, IProcurementGroupAppService
    {

        public ProcurementGroupAppService(IRepository<ProcurementGroup, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        [ApiModel]
        public async Task<ProcurementGroup> RunAsync(ProcurementGroupRunRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: stock_rule.py, METHOD: run) ---
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: stock.py, METHOD: run) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: run) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ProcurementGroup> RunSchedulerAsync(ProcurementGroupRunSchedulerRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_rule.py, METHOD: run_scheduler) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}