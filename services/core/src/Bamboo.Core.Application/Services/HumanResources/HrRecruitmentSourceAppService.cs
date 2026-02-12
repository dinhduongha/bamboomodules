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
    [Module("HrRecruitment", Category = "HumanResources", Depends = new[] { "hr", "calendar", "utm", "attachment_indexation", "web_tour", "digest" })]
    public partial class HrRecruitmentSourceAppService : GenericAppService<HrRecruitmentSource>, IHrRecruitmentSourceAppService
    {
        protected readonly IUtmSourceMixinAppService _utmSourceMixinAppService;
        public HrRecruitmentSourceAppService(IRepository<HrRecruitmentSource, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IUtmSourceMixinAppService utmSourceMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _utmSourceMixinAppService = utmSourceMixinAppService;
        }

        public async Task<HrRecruitmentSource> CreateAliasAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_recruitment_source.py, METHOD: create_alias) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrRecruitmentSource> CreateAndGetAliasAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_recruitment_source.py, METHOD: create_and_get_alias) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}