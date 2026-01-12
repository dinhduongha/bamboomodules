using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("HrSkills", Category = "HumanResources", Depends = new[] { "hr" })]
    public class HrSkillTypeAppService : GenericApplicationService<HrSkillType>, IHrSkillTypeAppService
    {

        public HrSkillTypeAppService(IRepository<HrSkillType, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<HrSkillType> CheckNoNullSkillOrSkillLevelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_skill_type.py) ---
            // def _check_no_null_skill_or_skill_level(self):
            // incorrect_skill_type = self.env['hr.skill.type']
            // for skill_type in self:
            //     if not skill_type.skill_ids or not skill_type.skill_level_ids:
            //         incorrect_skill_type |= skill_type
            // if incorrect_skill_type:
            //     raise ValidationError(
            //         _("The following skills type must contain at least one skill and one level: %s",
            //           "\n".join(skill_type.name for skill_type in incorrect_skill_type)))
            */
            return default;
        }

        protected async Task<HrSkillType> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_skill_type.py) ---
            // def _compute_display_name(self):
            // for skill_type in self:
            //     if skill_type.is_certification:
            //         skill_type.display_name = skill_type.name + "\U0001F396"  # Military Medal's unicode
            //     else:
            //         skill_type.display_name = skill_type.name
            */
            return default;
        }

        protected async Task<HrSkillType> ComputeLevelsCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_skill_type.py) ---
            // def _compute_levels_count(self):
            // level_count_by_skill_type = dict(self.env['hr.skill.level']._read_group(
            //     domain=[('skill_type_id', 'in', self.ids)],
            //     groupby=['skill_type_id'],
            //     aggregates=['__count']
            // ))
            // for skill_type in self:
            //     skill_type.levels_count = level_count_by_skill_type.get(skill_type, 0)
            */
            return default;
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

        protected async Task<HrSkillType> OnchangeSkillLevelIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_skill_type.py) ---
            // def _onchange_skill_level_ids(self):
            // for level in self.skill_level_ids:
            //     if level.technical_is_new_default:
            //         (self.skill_level_ids - level).write({'default_level': False})
            //         # This value need to be set to False, to reset it for the frontend.
            //         level.technical_is_new_default = False
            //         break
            */
            return default;
        }
    }
}