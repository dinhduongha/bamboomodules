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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("HrSkills", Category = "HumanResources", Depends = new[] { "hr" })]
    public partial class HrEmployeeSkillAppService : GenericApplicationService<HrEmployeeSkill>, IHrEmployeeSkillAppService
    {
        private readonly IHrIndividualSkillMixinAppService _hrIndividualSkillMixinAppService;
        public HrEmployeeSkillAppService(IRepository<HrEmployeeSkill, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IHrIndividualSkillMixinAppService hrIndividualSkillMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _hrIndividualSkillMixinAppService = hrIndividualSkillMixinAppService;
        }

        public async Task<HrEmployeeSkill> GetCurrentSkillsByEmployeeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee_skill.py) ---
            // def get_current_skills_by_employee(self):
            // emp_skill_grouped = dict(self.grouped(lambda emp_skill: (emp_skill.employee_id, emp_skill.skill_id)))
            // result_dict = defaultdict(lambda: self.env['hr.employee.skill'])
            // for (employee, skill), emp_skills in emp_skill_grouped.items():
            //     filtered_emp_skill = emp_skills.filtered(
            //         lambda employee_skill: not employee_skill.valid_to or employee_skill.valid_to >= fields.Date.today()
            //     )
            //     if skill.skill_type_id.is_certification and not filtered_emp_skill:
            //         expired_skills = (emp_skills - filtered_emp_skill)
            //         expired_skills_group_by_valid_to = expired_skills.grouped('valid_to')
            //         max_valid_to = max(expired_skills.mapped('valid_to'))
            //         result_dict[employee.id] += expired_skills_group_by_valid_to[max_valid_to]
            //         continue
            //     result_dict[employee.id] += filtered_emp_skill
            // return result_dict
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployeeSkill> LinkedFieldNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee_skill.py) ---
            // def _linked_field_name(self):
            // return 'employee_id'
            */
            return default;
        }

        public async Task<HrEmployeeSkill> OpenHrEmployeeSkillModalAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee_skill.py) ---
            // def open_hr_employee_skill_modal(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.employee.skill',
            //     'res_id': self.id if self else False,
            //     'target': 'new',
            //     'context': {
            //         'show_employee': True,
            //         'default_skill_type_id': self.env['hr.skill.type'].search([('is_certification', '=', True)], limit=1).id
            //     },
            //     'views': [(self.env.ref('hr_skills.employee_skill_view_inherit_certificate_form').id, 'form')],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployeeSkill> SaveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_employee_skill.py) ---
            // def action_save(self):
            // return {'type': 'ir.actions.act_window_close'}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}