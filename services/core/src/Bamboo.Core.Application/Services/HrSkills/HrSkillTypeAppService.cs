using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("HrSkills", Depends = new[] { "hr" })]
    public class HrSkillTypeAppService : GenericApplicationService<HrSkillType>, IHrSkillTypeAppService
    {

        public HrSkillTypeAppService(IRepository<HrSkillType, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<HrSkillType> CopyDataAsync(Guid id, HrSkillTypeCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_skill_type.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", skill_type.name), color=0) for skill_type, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrSkillType> GetDefaultColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_skill_type.py) ---
            // def _get_default_color(self):
            // return randint(1, 11)
            */
            return default;
        }
    }
}