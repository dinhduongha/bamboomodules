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
    [Module("HrHolidays", Depends = new[] { "hr", "calendar", "resource" })]
    public class HrLeaveAccrualPlanAppService : GenericApplicationService<HrLeaveAccrualPlan>, IHrLeaveAccrualPlanAppService
    {

        public HrLeaveAccrualPlanAppService(IRepository<HrLeaveAccrualPlan, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<HrLeaveAccrualPlan> ComputeAddedValueTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py) ---
            // def _compute_added_value_type(self):
            // for plan in self:
            //     if plan.level_ids:
            //         plan.added_value_type = plan.level_ids[0].added_value_type
            */
            return default;
        }

        protected async Task<HrLeaveAccrualPlan> ComputeCarryoverDayDisplayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py) ---
            // def _compute_carryover_day_display(self):
            // days_select = _get_selection_days(self)
            // for plan in self:
            //     plan.carryover_day_display = days_select[min(plan.carryover_day - 1, 28)][0]
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

        public async Task<HrLeaveAccrualPlan> CopyDataAsync(Guid id, HrLeaveAccrualPlanCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", plan.name)) for plan, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrLeaveAccrualPlan> InverseCarryoverDayDisplayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py) ---
            // def _inverse_carryover_day_display(self):
            // for plan in self:
            //     if plan.carryover_day_display == 'last':
            //         plan.carryover_day = 31
            //     else:
            //         plan.carryover_day = DAY_SELECT_VALUES.index(plan.carryover_day_display) + 1
            */
            return default;
        }

        public async Task<HrLeaveAccrualPlan> OpenAccrualPlanEmployeesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_accrual_plan.py) ---
            // def action_open_accrual_plan_employees(self):
            // self.ensure_one()
            // 
            // return {
            //     'name': _("Accrual Plan's Employees"),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'kanban,list,form',
            //     'res_model': 'hr.employee',
            //     'domain': [('id', 'in', self.allocation_ids.employee_id.ids)],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
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