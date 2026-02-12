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
    [Module("Maintenance", Category = "SupplyChain", Depends = new[] { "mail" })]
    public partial class MaintenanceRequestAppService : GenericAppService<MaintenanceRequest>, IMaintenanceRequestAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadCcAppService _mailThreadCcAppService;
        public MaintenanceRequestAppService(IRepository<MaintenanceRequest, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadCcAppService mailThreadCcAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadCcAppService = mailThreadCcAppService;
        }

        public async Task<MaintenanceRequest> ActivityUpdateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: activity_update) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MaintenanceRequest> ArchiveEquipmentRequestAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: archive_equipment_request) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<MaintenanceRequest> CreateAsync(CreateRequestDto<MaintenanceRequest> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public async Task<MaintenanceRequest> MessageNewAsync(MaintenanceRequestMessageNewRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py, METHOD: message_new) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MaintenanceRequest> ResetEquipmentRequestAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: reset_equipment_request) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<MaintenanceRequest> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}