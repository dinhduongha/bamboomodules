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
    public class HrDepartmentAppService : GenericApplicationService<HrDepartment>, IHrDepartmentAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public HrDepartmentAppService(IRepository<HrDepartment, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<HrDepartment> CheckParentIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_department.py) ---
            // def _check_parent_id(self):
            // if self._has_cycle():
            //     raise ValidationError(_('You cannot create recursive departments.'))
            */
            return default;
        }

        protected async Task<HrDepartment> ComputeCompleteNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_department.py) ---
            // def _compute_complete_name(self):
            // for department in self:
            //     if department.parent_id:
            //         department.complete_name = '%s / %s' % (department.parent_id.complete_name, department.name)
            //     else:
            //         department.complete_name = department.name
            */
            return default;
        }

        protected async Task<HrDepartment> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_department.py) ---
            // def _compute_display_name(self):
            // if self.env.context.get('hierarchical_naming', True):
            //     return super()._compute_display_name()
            // for record in self:
            //     record.display_name = record.name
            */
            return default;
        }

        protected async Task<HrDepartment> ComputeExpenseSheetsToApproveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_department.py) ---
            // def _compute_expense_sheets_to_approve(self):
            // expense_sheet_data = self.env['hr.expense.sheet']._read_group([('department_id', 'in', self.ids), ('state', '=', 'submit')], ['department_id'], ['__count'])
            // result = {department.id: count for department, count in expense_sheet_data}
            // for department in self:
            //     department.expense_sheets_to_approve_count = result.get(department.id, 0)
            */
            return default;
        }

        protected async Task<HrDepartment> ComputeLeaveCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_department.py) ---
            // def _compute_leave_count(self):
            // Requests = self.env['hr.leave']
            // Allocations = self.env['hr.leave.allocation']
            // today_date = datetime.now(timezone.utc).date()
            // today_start = fields.Datetime.to_string(today_date)  # get the midnight of the current utc day
            // today_end = fields.Datetime.to_string(today_date + relativedelta(hours=23, minutes=59, seconds=59))
            // 
            // leave_data = Requests._read_group(
            //     [('department_id', 'in', self.ids),
            //      ('state', '=', 'confirm')],
            //     ['department_id'], ['__count'])
            // allocation_data = Allocations._read_group(
            //     [('department_id', 'in', self.ids),
            //      ('state', '=', 'confirm')],
            //     ['department_id'], ['__count'])
            // absence_data = Requests._read_group(
            //     [('department_id', 'in', self.ids), ('state', '=', 'validate'),
            //      ('date_from', '<=', today_end), ('date_to', '>=', today_start)],
            //     ['department_id'], ['__count'])
            // 
            // res_leave = {department.id: count for department, count in leave_data}
            // res_allocation = {department.id: count for department, count in allocation_data}
            // res_absence = {department.id: count for department, count in absence_data}
            // 
            // for department in self:
            //     department.leave_to_approve_count = res_leave.get(department.id, 0)
            //     department.allocation_to_approve_count = res_allocation.get(department.id, 0)
            //     department.absence_of_today = res_absence.get(department.id, 0)
            */
            return default;
        }

        protected async Task<HrDepartment> ComputeMasterDepartmentIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_department.py) ---
            // def _compute_master_department_id(self):
            // for department in self:
            //     department.master_department_id = int(department.parent_path.split('/')[0])
            */
            return default;
        }

        protected async Task<HrDepartment> ComputeNewApplicantCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_department.py) ---
            // def _compute_new_applicant_count(self):
            // if self.env.user.has_group('hr_recruitment.group_hr_recruitment_interviewer'):
            //     applicant_data = self.env['hr.applicant']._read_group(
            //         [('department_id', 'in', self.ids), ('stage_id.sequence', '<=', '1')],
            //         ['department_id'], ['__count'])
            //     result = {department.id: count for department, count in applicant_data}
            //     for department in self:
            //         department.new_applicant_count = result.get(department.id, 0)
            // else:
            //     self.new_applicant_count = 0
            */
            return default;
        }

        protected async Task<HrDepartment> ComputePlanCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_department.py) ---
            // def _compute_plan_count(self):
            // plans_data = self.env['mail.activity.plan']._read_group(
            //     domain=[
            //         '|',
            //         ('department_id', '=', False),
            //         ('department_id', 'in', self.ids),
            //         ('company_id', 'in', self.env.companies.ids + [False])
            //     ],
            //     groupby=['department_id'],
            //     aggregates=['__count'],
            // )
            // plans_count = {department.id: count for department, count in plans_data}
            // for department in self:
            //     department.plans_count = plans_count.get(department.id, 0) + plans_count.get(False, 0)
            */
            return default;
        }

        protected async Task<HrDepartment> ComputeRecruitmentStatsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_department.py) ---
            // def _compute_recruitment_stats(self):
            // job_data = self.env['hr.job']._read_group(
            //     [('department_id', 'in', self.ids)],
            //     ['department_id'], ['no_of_hired_employee:sum', 'no_of_recruitment:sum'])
            // new_emp = {department.id: nb_employee for department, nb_employee, __ in job_data}
            // expected_emp = {department.id: nb_recruitment for department, __, nb_recruitment in job_data}
            // for department in self:
            //     department.new_hired_employee = new_emp.get(department.id, 0)
            //     department.expected_employee = expected_emp.get(department.id, 0)
            */
            return default;
        }

        protected async Task<HrDepartment> ComputeTotalEmployeeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_department.py) ---
            // def _compute_total_employee(self):
            // emp_data = self.env['hr.employee'].sudo()._read_group([('department_id', 'in', self.ids), ('company_id', 'in', self.env.companies.ids)], ['department_id'], ['__count'])
            // result = {department.id: count for department, count in emp_data}
            // for department in self:
            //     department.total_employee = result.get(department.id, 0)
            */
            return default;
        }

        public async Task<HrDepartment> EmployeeFromDepartmentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_department.py) ---
            // def action_employee_from_department(self):
            // if self.env['hr.employee'].has_access('read'):
            //     res_model = "hr.employee"
            //     search_view_id = self.env.ref('hr.view_employee_filter').id
            // else:
            //     res_model = "hr.employee.public"
            //     search_view_id = self.env.ref('hr.hr_employee_public_view_search').id
            // return {
            //     'name': _("Employees"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': res_model,
            //     'view_mode': 'list,kanban,form',
            //     'views': [(False, 'list'), (False, 'kanban'), (False, 'form')],
            //     'search_view_id': [search_view_id, 'search'],
            //     'context': {
            //         'searchpanel_default_department_id': self.id,
            //         'default_department_id': self.id,
            //         'search_default_group_department': 1,
            //         'search_default_department_id': self.id,
            //         'expand': 1
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrDepartment> GetActionContextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_department.py) ---
            // def _get_action_context(self):
            // return {
            //     'search_default_approve': 1,
            //     'search_default_active_employee': 2,
            //     'search_default_department_id': self.id,
            //     'default_department_id': self.id,
            //     'searchpanel_default_department_id': self.id,
            // }
            */
            return default;
        }

        public async Task<HrDepartment> GetChildrenDepartmentIdsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_department.py) ---
            // def get_children_department_ids(self):
            // return self.env['hr.department'].search([('id', 'child_of', self.ids)])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrDepartment> GetDepartmentHierarchyAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_department.py) ---
            // def get_department_hierarchy(self):
            // if not self:
            //     return {}
            // 
            // hierarchy = {
            //     'parent': {
            //         'id': self.parent_id.id,
            //         'name': self.parent_id.name,
            //         'employees': self.parent_id.total_employee,
            //     } if self.parent_id else False,
            //     'self': {
            //         'id': self.id,
            //         'name': self.name,
            //         'employees': self.total_employee,
            //     },
            //     'children': [
            //         {
            //             'id': child.id,
            //             'name': child.name,
            //             'employees': child.total_employee
            //         } for child in self.child_ids
            //     ]
            // }
            // 
            // return hierarchy
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrDepartment> GetFormviewActionAsync(Guid id, HrDepartmentGetFormviewActionRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_department.py) ---
            // def get_formview_action(self, access_uid=None):
            // res = super().get_formview_action(access_uid=access_uid)
            // if (not self.env.user.has_group('hr.group_hr_user') and
            //    self.env.context.get('open_employees_kanban', False)):
            //     res.update({
            //         'name': self.name,
            //         'res_model': 'hr.employee.public',
            //         'view_mode': 'kanban',
            //         'views': [(False, 'kanban'), (False, 'form')],
            //         'context': {'searchpanel_default_department_id': self.id},
            //         'res_id': False,
            //     })
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrDepartment> OpenAllocationDepartmentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_department.py) ---
            // def action_open_allocation_department(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("hr_holidays.hr_leave_allocation_action_approve_department")
            // action['context'] = self._get_action_context()
            // action['context']['search_default_second_approval'] = 3
            // action['domain'] = expression.AND([ast.literal_eval(action['domain']), [('state', '=', 'confirm')]])
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrDepartment> OpenLeaveDepartmentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_department.py) ---
            // def action_open_leave_department(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("hr_holidays.hr_leave_action_action_approve_department")
            // action['context'] = {
            //     **self._get_action_context(),
            //     'search_default_active_time_off': 3,
            //     'hide_employee_name': 1
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrDepartment> OpenViewChildDepartmentsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_department.py) ---
            // def action_open_view_child_departments(self):
            // self.ensure_one()
            // return {
            //     "type": "ir.actions.act_window",
            //     "res_model": "hr.department",
            //     "views": [[False, "kanban"], [False, "list"], [False, "form"]],
            //     "domain": [['id', 'in', self.get_children_department_ids().ids]],
            //     "name": "Child departments",
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrDepartment> PlanFromDepartmentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_department.py) ---
            // def action_plan_from_department(self):
            // action = self.env['ir.actions.actions']._for_xml_id('hr.mail_activity_plan_action')
            // action['context'] = dict(ast.literal_eval(action.get('context')), default_department_id=self.id)
            // domain = [
            //     '|',
            //     ('department_id', '=', False),
            //     ('department_id', 'in', self.ids),
            // ]
            // if 'domain' in action:
            //     allowed_company_ids = self.env.context.get('allowed_company_ids', [])
            //     action['domain'] = expression.AND([
            //         ast.literal_eval(action['domain'].replace('allowed_company_ids', str(allowed_company_ids))), domain
            //     ])
            // else:
            //     action['domain'] = domain
            // if self.plans_count == 0:
            //     action['views'] = [(False, 'form')]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrDepartment> SearchHasReadAccessInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_department.py) ---
            // def _search_has_read_access(self, operator, value):
            // supported_operators = ["="]
            // if operator not in supported_operators or not isinstance(value, bool):
            //     raise NotImplementedError()
            // if not value:
            //     return [(1, "=", 0)]
            // if self.env['hr.employee'].has_access('read'):
            //     return [(1, "=", 1)]
            // departments_ids = self.env['hr.department'].sudo().search([('manager_id', 'in', self.env.user.employee_ids.ids)]).ids
            // return [('id', 'child_of', departments_ids)]
            */
            return default;
        }

        protected async Task<HrDepartment> UpdateEmployeeManagerInternalAsync(Guid manager_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_department.py) ---
            // def _update_employee_manager(self, manager_id):
            // employees = self.env['hr.employee']
            // for department in self:
            //     employees = employees | self.env['hr.employee'].search([
            //         ('id', '!=', manager_id),
            //         ('department_id', '=', department.id),
            //         ('parent_id', '=', department.manager_id.id)
            //     ])
            // employees.write({'parent_id': manager_id})
            */
            return default;
        }
    }
}