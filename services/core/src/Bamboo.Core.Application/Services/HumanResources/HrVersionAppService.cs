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
    [Module("Hr", Category = "HumanResources", Depends = new[] { "base_setup", "digest", "phone_validation", "resource_mail", "web" })]
    public partial class HrVersionAppService : GenericAppService<HrVersion>, IHrVersionAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public HrVersionAppService(IRepository<HrVersion, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<HrVersion> CheckContractFinishedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: check_contract_finished) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<HrVersion> CreateAsync(CreateRequestDto<HrVersion> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_version.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<HrVersion> GenerateWorkEntriesAsync(HrVersionGenerateWorkEntriesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: generate_work_entries) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrVersion> GetFormviewActionAsync(HrVersionGetFormviewActionRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: get_formview_action) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrVersion> GetValuesFromContractTemplateAsync(HrVersionGetValuesFromContractTemplateRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: get_values_from_contract_template) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrVersion> HasStaticWorkEntriesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: has_static_work_entries) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrVersion> OpenVersionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: action_open_version) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<HrVersion> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_version.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_work_entry, FILE: hr_version.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}