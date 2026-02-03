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
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("HrHolidays", Category = "HumanResources", Depends = new[] { "hr", "calendar", "resource" })]
    public partial class HrLeaveAccrualPlanAppService : GenericAppService<HrLeaveAccrualPlan>, IHrLeaveAccrualPlanAppService
    {

        public HrLeaveAccrualPlanAppService(IRepository<HrLeaveAccrualPlan, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<HrLeaveAccrualPlan> ComputeCarryoverDayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py) ---
            // def _compute_carryover_day(self):
            // for plan in self:
            //     # 2020 is a leap year, so monthrange(2020, february) will return [2, 29]
            //     plan.carryover_day = str(min(monthrange(2020, int(plan.carryover_month))[1], int(plan.carryover_day)))
            */
            return default;
        }

        protected async Task<HrLeaveAccrualPlan> ComputeCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py) ---
            // def _compute_company_id(self):
            // for accrual_plan in self:
            //     if accrual_plan.time_off_type_id:
            //         accrual_plan.company_id = accrual_plan.time_off_type_id.company_id
            //     else:
            //         accrual_plan.company_id = self.env.company
            */
            return default;
        }

        protected async Task<HrLeaveAccrualPlan> ComputeEmployeeCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py) ---
            // def _compute_employee_count(self):
            // allocations_read_group = self.env['hr.leave.allocation']._read_group(
            //     [('accrual_plan_id', 'in', self.ids)],
            //     ['accrual_plan_id'],
            //     ['employee_id:count_distinct'],
            // )
            // allocations_dict = {accrual_plan.id: count for accrual_plan, count in allocations_read_group}
            // for plan in self:
            //     plan.employees_count = allocations_dict.get(plan.id, 0)
            */
            return default;
        }

        protected async Task<HrLeaveAccrualPlan> ComputeIsBasedOnWorkedTimeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py) ---
            // def _compute_is_based_on_worked_time(self):
            // for plan in self:
            //     if plan.accrued_gain_time == "start":
            //         plan.is_based_on_worked_time = False
            */
            return default;
        }

        protected async Task<HrLeaveAccrualPlan> ComputeLevelCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py) ---
            // def _compute_level_count(self):
            // level_read_group = self.env['hr.leave.accrual.level']._read_group(
            //     [('accrual_plan_id', 'in', self.ids)],
            //     groupby=['accrual_plan_id'],
            //     aggregates=['__count'],
            // )
            // mapped_count = {accrual_plan.id: count for accrual_plan, count in level_read_group}
            // for plan in self:
            //     plan.level_count = mapped_count.get(plan.id, 0)
            */
            return default;
        }

        protected async Task<HrLeaveAccrualPlan> ComputeShowTransitionModeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py) ---
            // def _compute_show_transition_mode(self):
            // for plan in self:
            //     plan.show_transition_mode = len(plan.level_ids) > 1
            */
            return default;
        }

        public async Task<HrLeaveAccrualPlan> CopyDataAsync(HrLeaveAccrualPlanCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", plan.name)) for plan, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeaveAccrualPlan> CreateAccrualPlanLevelAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py) ---
            // def action_create_accrual_plan_level(self):
            // return {
            //     'name': self.env._('New Milestone'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.leave.accrual.level',
            //     'view_mode': 'form',
            //     'views': [[False, 'form']],
            //     'view_id': self.env.ref('hr_holidays.hr_accrual_level_view_form').id,
            //     'target': 'new',
            //     'context': dict(
            //         self.env.context,
            //         new=True,
            //         default_can_be_carryover=self.can_be_carryover,
            //         default_accrued_gain_time=self.accrued_gain_time,
            //         default_can_modify_value_type=not self.time_off_type_id and not self.level_ids,
            //         default_added_value_type=self.added_value_type,
            //     ),
            // }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeaveAccrualPlan> OpenAccrualPlanEmployeesAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py) ---
            // def action_open_accrual_plan_employees(self):
            // self.ensure_one()
            // return {
            //     'name': _("Accrual Plan's Employees"),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'kanban,list,form',
            //     'res_model': 'hr.employee',
            //     'domain': [('id', 'in', self.allocation_ids.employee_id.ids)],
            // }
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrLeaveAccrualPlan> OpenAccrualPlanLevelAsync(HrLeaveAccrualPlanOpenAccrualPlanLevelRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py) ---
            // def action_open_accrual_plan_level(self, level_id):
            // return {
            //     'name': self.env._('Milestone Edition'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.leave.accrual.level',
            //     'view_mode': 'form',
            //     'views': [[False, 'form']],
            //     'target': 'new',
            //     'res_id': level_id,
            // }
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        protected async Task<HrLeaveAccrualPlan> PreventUsedPlanUnlinkInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py) ---
            // def _prevent_used_plan_unlink(self):
            // domain = [
            //     ('allocation_type', '=', 'accrual'),
            //     ('accrual_plan_id', 'in', self.ids),
            //     ('state', 'not in', ('cancel', 'refuse')),
            // ]
            // if self.env['hr.leave.allocation'].search_count(domain):
            //     raise ValidationError(_(
            //         "Some of the accrual plans you're trying to delete are linked to an existing allocation. Delete or cancel them first."
            //     ))
            */
            return default;
        }
    }
}