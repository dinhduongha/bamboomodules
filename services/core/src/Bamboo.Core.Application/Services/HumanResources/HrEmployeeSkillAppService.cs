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
    [Module("HrSkills", Category = "HumanResources", Depends = new[] { "hr" })]
    public partial class HrEmployeeSkillAppService : GenericAppService<HrEmployeeSkill>, IHrEmployeeSkillAppService
    {
        protected readonly IHrIndividualSkillMixinAppService _hrIndividualSkillMixinAppService;
        public HrEmployeeSkillAppService(IRepository<HrEmployeeSkill, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IHrIndividualSkillMixinAppService hrIndividualSkillMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _hrIndividualSkillMixinAppService = hrIndividualSkillMixinAppService;
        }

        public async Task<HrEmployeeSkill> GetCurrentSkillsByEmployeeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee_skill.py, METHOD: get_current_skills_by_employee) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployeeSkill> OpenHrEmployeeSkillModalAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee_skill.py, METHOD: open_hr_employee_skill_modal) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrEmployeeSkill> SaveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee_skill.py, METHOD: action_save) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}