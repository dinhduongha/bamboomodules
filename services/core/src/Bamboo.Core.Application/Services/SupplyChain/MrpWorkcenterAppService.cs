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
    [Module("Mrp", Category = "SupplyChain", Depends = new[] { "product", "stock", "resource" })]
    public partial class MrpWorkcenterAppService : GenericAppService<MrpWorkcenter>, IMrpWorkcenterAppService
    {
        protected readonly IAnalyticMixinAppService _analyticMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IResourceMixinAppService _resourceMixinAppService;
        public MrpWorkcenterAppService(IRepository<MrpWorkcenter, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAnalyticMixinAppService analyticMixinAppService, IMailThreadAppService mailThreadAppService, IResourceMixinAppService resourceMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _analyticMixinAppService = analyticMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _resourceMixinAppService = resourceMixinAppService;
        }

        public async Task<MrpWorkcenter> ArchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: action_archive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpWorkcenter> ShowOperationsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: action_show_operations) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpWorkcenter> UnblockAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: unblock) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpWorkcenter> WorkOrderAlternativesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: action_work_order_alternatives) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MrpWorkcenter> WorkOrderAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: action_work_order) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}