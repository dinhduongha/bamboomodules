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
    public partial class MaintenanceEquipmentAppService : GenericAppService<MaintenanceEquipment>, IMaintenanceEquipmentAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IMaintenanceMixinAppService _maintenanceMixinAppService;
        public MaintenanceEquipmentAppService(IRepository<MaintenanceEquipment, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IMaintenanceMixinAppService maintenanceMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _maintenanceMixinAppService = maintenanceMixinAppService;
        }

        public override async Task<MaintenanceEquipment> CreateAsync(CreateRequestDto<MaintenanceEquipment> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<MaintenanceEquipment> OpenMatchedSerialAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_maintenance, FILE: maintenance.py, METHOD: action_open_matched_serial) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<MaintenanceEquipment> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_maintenance, FILE: equipment.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}