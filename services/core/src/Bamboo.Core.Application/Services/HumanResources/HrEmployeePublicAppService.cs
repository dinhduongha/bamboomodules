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
    [Module("Hr", Category = "HumanResources", Depends = new[] { "base_setup", "digest", "phone_validation", "resource_mail", "web" })]
    public class HrEmployeePublicAppService : GenericApplicationService<HrEmployeePublic>, IHrEmployeePublicAppService
    {
        private readonly IHrEmployeeBaseAppService _hrEmployeeBaseAppService;
        public HrEmployeePublicAppService(IRepository<HrEmployeePublic, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IHrEmployeeBaseAppService hrEmployeeBaseAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _hrEmployeeBaseAppService = hrEmployeeBaseAppService;
        }

        protected async Task<HrEmployeePublic> ComputeEmployeeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _compute_employee_id(self):
            // for employee in self:
            //     employee.employee_id = self.env['hr.employee'].browse(employee.id)
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeIsManagerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _compute_is_manager(self):
            // all_reports = self.env['hr.employee.public'].search([('id', 'child_of', self.env.user.employee_id.id)]).ids
            // for employee in self:
            //     employee.is_manager = employee.id in all_reports
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeManagerOnlyFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _compute_manager_only_fields(self):
            // manager_fields = self._get_manager_only_fields()
            // for employee in self:
            //     if employee.is_manager:
            //         employee_sudo = employee.employee_id.sudo()
            //         for f in manager_fields:
            //             employee[f] = employee_sudo[f]
            //     else:
            //         for f in manager_fields:
            //             employee[f] = False
            */
            return default;
        }

        protected async Task<HrEmployeePublic> GetFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _get_fields(self):
            // return ','.join('emp.%s' % name for name, field in self._fields.items() if field.store and field.type not in ['many2many', 'one2many'])
            */
            return default;
        }

        protected async Task<HrEmployeePublic> GetManagerOnlyFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _get_manager_only_fields(self):
            // return []
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def _get_manager_only_fields(self):
            // return super()._get_manager_only_fields() + ['first_contract_date']
            */
            return default;
        }

        public async Task<HrEmployeePublic> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def init(self):
            // tools.drop_view_if_exists(self.env.cr, self._table)
            // self.env.cr.execute("""CREATE or REPLACE VIEW %s as (
            //     SELECT
            //         %s
            //     FROM hr_employee emp
            // )""" % (self._table, self._get_fields()))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployeePublic> SearchEmployeeIdInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _search_employee_id(self, operator, value):
            // return [('id', operator, value)]
            */
            return default;
        }

        protected async Task<HrEmployeePublic> SearchFirstContractDateInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: hr_employee.py) ---
            // def _search_first_contract_date(self, operator, value):
            // employees = self.env['hr.employee'].sudo().search([('id', 'child_of', self.env.user.employee_id.ids), ('first_contract_date', operator, value)])
            // return [('id', 'in', employees.ids)]
            */
            return default;
        }
    }
}