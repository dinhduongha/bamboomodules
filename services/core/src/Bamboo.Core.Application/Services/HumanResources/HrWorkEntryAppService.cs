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
    [Module("HrWorkEntryModule", Category = "HumanResources", Depends = new[] { "hr" })]
    public partial class HrWorkEntryAppService : GenericAppService<HrWorkEntry>, IHrWorkEntryAppService
    {

        public HrWorkEntryAppService(IRepository<HrWorkEntry, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<HrWorkEntry> ApproveLeaveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_work_entry.py, METHOD: action_approve_leave) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrWorkEntry> GetUnusualDaysAsync(HrWorkEntryGetUnusualDaysRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: get_unusual_days) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrWorkEntry> RefuseLeaveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_work_entry.py, METHOD: action_refuse_leave) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrWorkEntry> SplitAsync(HrWorkEntrySplitRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: action_split) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrWorkEntry> ValidateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: action_validate) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<HrWorkEntry> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_work_entry.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_work_entry.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}