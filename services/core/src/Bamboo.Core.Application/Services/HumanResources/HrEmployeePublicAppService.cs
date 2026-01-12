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

        public HrEmployeePublicAppService(IRepository<HrEmployeePublic, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<HrEmployeePublic> ComputeAllocationDisplayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_public.py) ---
            // def _compute_allocation_display(self):
            // self._compute_from_employee('allocation_display')
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeBadgeIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_gamification, FILE: hr_employee_public.py) ---
            // def _compute_badge_ids(self):
            // self._compute_from_employee('badge_ids')
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeChildAllCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py) ---
            // def _compute_child_all_count(self):
            // self._compute_from_employee('child_all_count')
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeChildCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py) ---
            // def _compute_child_count(self):
            // self._compute_from_employee('child_count')
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeCountryCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _compute_country_code(self):
            // self._compute_from_employee('country_code')
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeDepartmentColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_org_chart, FILE: hr_org_chart_mixin.py) ---
            // def _compute_department_color(self):
            // self._compute_from_employee('department_color')
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeFromEmployeeInternalAsync(object field_names)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _compute_from_employee(self, field_names):
            // if isinstance(field_names, str):
            //     field_names = [field_names]
            // employees_sudo = self.sudo().env['hr.employee'].browse(self.ids)
            // employee_per_id = {emp.id: emp for emp in employees_sudo}
            // for public_employee in self:
            //     employee = employee_per_id[public_employee.id]
            //     for field_name in field_names:
            //         public_employee[field_name] = employee[field_name]
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeHasBadgesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_gamification, FILE: hr_employee_public.py) ---
            // def _compute_has_badges(self):
            // self._compute_from_employee('has_badges')
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

        protected async Task<HrEmployeePublic> ComputeIsUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _compute_is_user(self):
            // user_employee_id = self.env.user.employee_id.id
            // for employee in self:
            //     employee.is_user = employee.id == user_employee_id
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeLastActivityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _compute_last_activity(self):
            // for employee in self:
            //     tz = employee.tz
            //     # sudo: res.users - can access presence of accessible user
            //     if last_presence := employee.user_id.sudo().presence_ids.last_presence:
            //         last_activity_datetime = last_presence.replace(tzinfo=UTC).astimezone(timezone(tz)).replace(tzinfo=None)
            //         employee.last_activity = last_activity_datetime.date()
            //         if employee.last_activity == fields.Date.today():
            //             employee.last_activity_time = format_time(self.env, last_presence, time_format='short')
            //         else:
            //             employee.last_activity_time = False
            //     else:
            //         employee.last_activity = False
            //         employee.last_activity_time = False
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeLeaveManagerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_public.py) ---
            // def _compute_leave_manager(self):
            // self._compute_from_employee('leave_manager_id')
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeLeaveStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_public.py) ---
            // def _compute_leave_status(self):
            // self._compute_from_employee(['leave_date_to', 'is_absent'])
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

        protected async Task<HrEmployeePublic> ComputeMemberOfDepartmentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _compute_member_of_department(self):
            // self._compute_from_employee('member_of_department')
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeNewlyHiredInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _compute_newly_hired(self):
            // self._compute_from_employee('newly_hired')
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputePresenceIconInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _compute_presence_icon(self):
            // self._compute_from_employee('hr_icon_display')
            // self._compute_from_employee('show_hr_icon_display')
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputePresenceStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _compute_presence_state(self):
            // self._compute_from_employee('hr_presence_state')
            */
            return default;
        }

        protected async Task<HrEmployeePublic> ComputeShowLeavesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_public.py) ---
            // def _compute_show_leaves(self):
            // self._compute_from_employee('show_leaves')
            */
            return default;
        }

        public async Task<HrEmployeePublic> GetAvatarCardDataAsync(Guid id, HrEmployeePublicGetAvatarCardDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def get_avatar_card_data(self, fields):
            // return self.read(fields)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployeePublic> GetFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _get_fields(self):
            // base_fields = ('id', 'employee_id', 'name', 'active')
            // version_fields = self.env['hr.version']._fields
            // return 'e.id AS id,e.id AS employee_id,e.name AS name,e.active AS active,' + ','.join(
            //     (f'v.{name}' if name in version_fields and version_fields[name].store else f'e.{name}')
            //     for name, field in self._fields.items()
            //     if name not in base_fields and field.store and field.column_type
            // )
            */
            return default;
        }

        protected async Task<HrEmployeePublic> GetManagerOnlyFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _get_manager_only_fields(self):
            // return []
            */
            return default;
        }

        protected async Task<HrEmployeePublic> GetSelectionHrIconDisplayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _get_selection_hr_icon_display(self):
            // return self.env['hr.employee']._fields['hr_icon_display']._description_selection(self.env)
            */
            return default;
        }

        protected async Task<HrEmployeePublic> GetValidEmployeeForUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _get_valid_employee_for_user(self):
            // user = self.env.user
            // # retrieve the employee of the current active company for the user
            // employee = user.employee_id
            // if not employee:
            //     # search for all employees as superadmin to not get blocked by multi-company rules
            //     user_employees = user.employee_id.sudo().search([
            //         ('user_id', '=', user.id)
            //     ])
            //     # the default company employee is most likely the correct one, but fallback to the first if not available
            //     employee = user_employees.filtered(lambda r: r.company_id == user.company_id) or user_employees[:1]
            // return employee
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
            //     FROM hr_employee e
            //     JOIN hr_version v
            //       ON v.id = e.current_version_id
            // )""" % (self._table, self._get_fields()))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployeePublic> OpenCoursesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills_slides, FILE: hr_employee_public.py) ---
            // def action_open_courses(self):
            // self.ensure_one()
            // if self.is_user:
            //     return self.employee_id.action_open_courses()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployeePublic> OpenLastMonthAttendancesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_employee_public.py) ---
            // def action_open_last_month_attendances(self):
            // self.ensure_one()
            // if self.is_user:
            //     return self.employee_id.action_open_last_month_attendances()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployeePublic> OpenTimeOffCalendarAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_public.py) ---
            // def action_open_time_off_calendar(self):
            // """Open the time off calendar filtered on this employee."""
            // self.ensure_one()
            // action = self.env.ref('hr_holidays.action_my_days_off_dashboard_calendar').sudo().read()[0]
            // action['domain'] = [('employee_id', '=', self.id)]
            // ctx = ({
            //     'active_employee_id': self.id,
            //     'search_default_employee_id': [self.id],
            //     'search_default_my_leaves': 0,
            //     'search_default_team': 0,
            //     'search_default_current_year': 1,
            //     'hide_employee_name': 1,
            // })
            // action['context'] = ctx
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrEmployeePublic> SearchAbsentEmployeeInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_public.py) ---
            // def _search_absent_employee(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // # This search is only used for the 'Absent Today' filter however
            // # this only returns employees that are absent right now.
            // today_start = date.today()
            // today_end = today_start + timedelta(1)
            // holidays = self.env['hr.leave'].sudo().search([
            //     ('employee_id', '!=', False),
            //     ('state', '=', 'validate'),
            //     ('date_from', '<', today_end),
            //     ('date_to', '>=', today_start),
            // ])
            // return [('id', 'in', holidays.employee_id.ids)]
            */
            return default;
        }

        protected async Task<HrEmployeePublic> SearchFilterForExpenseInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: hr_employee_public.py) ---
            // def _search_filter_for_expense(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // 
            // domain = Domain.FALSE  # Nothing accepted by domain, by default
            // user = self.env.user
            // employee = user.employee_id
            // if user.has_groups('hr_expense.group_hr_expense_user') or user.has_groups('account.group_account_user'):
            //     domain = Domain('company_id', '=', False) | Domain('company_id', 'child_of', self.env.company.root_id.id)  # Then, domain accepts everything
            // elif user.has_groups('hr_expense.group_hr_expense_team_approver') and user.employee_ids:
            //     domain = (
            //         Domain('department_id.manager_id', '=', employee.id)
            //         | Domain('parent_id', '=', employee.id)
            //         | Domain('id', '=', employee.id)
            //         | Domain('expense_manager_id', '=', user.id)
            //     ) & Domain('company_id', 'in', [False, employee.company_id.id])
            // elif user.employee_id:
            //     domain = Domain('id', '=', employee.id) & Domain('company_id', 'in', [False, employee.company_id.id])
            // return domain
            */
            return default;
        }

        protected async Task<HrEmployeePublic> SearchNewlyHiredInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _search_newly_hired(self, operator, value):
            // if operator not in ('in', 'not in'):
            //     return NotImplemented
            // new_hire_field = self.env['hr.employee']._get_new_hire_field()
            // new_hires = self.env['hr.employee'].sudo().search([
            //     (new_hire_field, '>', fields.Datetime.now() - timedelta(days=90))
            // ])
            // return [('id', operator, new_hires.ids)]
            */
            return default;
        }

        protected async Task<HrEmployeePublic> SearchPartOfDepartmentInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee_public.py) ---
            // def _search_part_of_department(self, operator, value):
            // if operator != 'in':
            //     return NotImplemented
            // 
            // user_employee = self._get_valid_employee_for_user()
            // if not user_employee.department_id:
            //     return [('id', 'in', user_employee.ids)]
            // return [('department_id', 'child_of', user_employee.department_id.ids)]
            */
            return default;
        }

        public async Task<HrEmployeePublic> TimeOffDashboardAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_employee_public.py) ---
            // def action_time_off_dashboard(self):
            // self.ensure_one()
            // if self.is_user:
            //     return self.employee_id.action_time_off_dashboard()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrEmployeePublic> TimesheetFromEmployeeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: hr_employee_public.py) ---
            // def action_timesheet_from_employee(self):
            // self.ensure_one()
            // if self.is_user:
            //     return self.employee_id.action_timesheet_from_employee()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}