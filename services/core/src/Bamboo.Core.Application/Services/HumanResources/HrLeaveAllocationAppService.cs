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
    [Module("HrHolidays", Category = "HumanResources", Depends = new[] { "hr", "calendar", "resource" })]
    public partial class HrLeaveAllocationAppService : GenericAppService<HrLeaveAllocation>, IHrLeaveAllocationAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public HrLeaveAllocationAppService(IRepository<HrLeaveAllocation, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<HrLeaveAllocation> ActivityUpdateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: activity_update) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeaveAllocation> AddFollowerAsync(HrLeaveAllocationAddFollowerRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: add_follower) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeaveAllocation> ApproveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: action_approve) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<HrLeaveAllocation> CreateAsync(CreateRequestDto<HrLeaveAllocation> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave_allocation.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public override async Task<HrLeaveAllocation> DefaultGetAsync(DefaultGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave_allocation.py, METHOD: default_get) ---
            */
            return await base.DefaultGetAsync(input);
        }

        public async Task<HrLeaveAllocation> MessageSubscribeAsync(HrLeaveAllocationMessageSubscribeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: message_subscribe) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeaveAllocation> RefuseAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: action_refuse) ---
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave_allocation.py, METHOD: action_refuse) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<HrLeaveAllocation> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave_allocation.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}