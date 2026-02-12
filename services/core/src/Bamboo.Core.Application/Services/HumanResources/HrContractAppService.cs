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
    [Module("HrContractModule", Category = "HumanResources", Depends = new[] { "hr" })]
    public partial class HrContractAppService : GenericAppService<HrContract>, IHrContractAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public HrContractAppService(IRepository<HrContract, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<HrContract> GenerateWorkEntriesAsync(HrContractGenerateWorkEntriesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: generate_work_entries) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrContract> GetAllStructuresAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_contract.py, METHOD: get_all_structures) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrContract> GetAttributeAsync(HrContractGetAttributeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_contract.py, METHOD: get_attribute) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrContract> HasStaticWorkEntriesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: has_static_work_entries) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrContract> OpenContractFormAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: action_open_contract_form) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrContract> OpenContractHistoryAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: action_open_contract_history) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrContract> OpenContractListAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: action_open_contract_list) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrContract> SetAttributeValueAsync(HrContractSetAttributeValueRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_contract.py, METHOD: set_attribute_value) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrContract> UpdateStateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: update_state) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<HrContract> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_contract, FILE: hr_contract.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_holidays_contract, FILE: hr_contract.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: hr_contract.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}