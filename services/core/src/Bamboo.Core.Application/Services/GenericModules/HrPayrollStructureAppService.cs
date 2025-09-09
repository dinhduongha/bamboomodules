using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;

namespace Bamboo.Core.Application.Services
{
    [Module("OmHrPayroll", Depends = new[] { "mail", "hr_contract", "hr_holidays" })]
    public class HrPayrollStructureAppService : GenericApplicationService<HrPayrollStructure>, IHrPayrollStructureAppService
    {

        public HrPayrollStructureAppService(IRepository<HrPayrollStructure, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<HrPayrollStructure> CheckParentIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_salary_rule.py) ---
            // def _check_parent_id(self):
            // if not self._check_recursion():
            //     raise ValidationError(_('You cannot create a recursive salary structure.'))
            */
            return default;
        }

        public async Task<HrPayrollStructure> GetAllRulesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_salary_rule.py) ---
            // def get_all_rules(self):
            // """
            // @return: returns a list of tuple (id, sequence) of rules that are maybe to apply
            // """
            // all_rules = []
            // for struct in self:
            //     all_rules += struct.rule_ids._recursive_search_of_rules()
            // return all_rules
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrPayrollStructure> GetParentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_salary_rule.py) ---
            // def _get_parent(self):
            // return self.env.ref('om_om_hr_payroll.structure_base', False)
            */
            return default;
        }

        protected async Task<HrPayrollStructure> GetParentStructureInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_hr_payroll, FILE: hr_salary_rule.py) ---
            // def _get_parent_structure(self):
            // parent = self.mapped('parent_id')
            // if parent:
            //     parent = parent._get_parent_structure()
            // return parent + self
            */
            return default;
        }
    }
}