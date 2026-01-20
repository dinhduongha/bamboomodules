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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("HrHolidays", Category = "HumanResources", Depends = new[] { "hr", "calendar", "resource" })]
    public partial class HrLeaveAppService : GenericApplicationService<HrLeave>, IHrLeaveAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadMainAttachmentAppService _mailThreadMainAttachmentAppService;
        public HrLeaveAppService(IRepository<HrLeave, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadMainAttachmentAppService mailThreadMainAttachmentAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadMainAttachmentAppService = mailThreadMainAttachmentAppService;
        }

        protected async Task<HrLeave> ActionUserCancelInternalAsync(object reason)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _action_user_cancel(self, reason=None):
            // self.ensure_one()
            // if not self.can_cancel:
            //     raise ValidationError(_('This time off cannot be cancelled.'))
            // 
            // self._force_cancel(reason, 'mail.mt_note')
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py) ---
            // def _action_user_cancel(self, reason=None):
            // res = super()._action_user_cancel(reason)
            // self.sudo()._regen_work_entries()
            // return res
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_leave.py) ---
            // def _action_user_cancel(self, reason=None):
            // res = super()._action_user_cancel(reason)
            // timesheets = self.sudo().timesheet_ids
            // timesheets.write({'holiday_id': False})
            // timesheets.unlink()
            // self._check_missing_global_leave_timesheets()
            // return res
            */
            return default;
        }

        protected async Task<HrLeave> ActionValidateInternalAsync(object check_state)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _action_validate(self, check_state=True):
            // current_employee = self.env.user.employee_id
            // leaves = self._get_leaves_on_public_holiday()
            // if check_state and any(not holiday.can_validate for holiday in self):
            //     raise UserError(_('You can\'t validate this leave.'))
            // if leaves:
            //     raise ValidationError(_('The following employees are not supposed to work during that period:\n %s') % ','.join(leaves.mapped('employee_id.name')))
            // 
            // self.write({'state': 'validate'})
            // 
            // leaves_second_approver = self.env['hr.leave']
            // leaves_first_approver = self.env['hr.leave']
            // 
            // for leave in self:
            //     if leave.validation_type == 'both':
            //         leaves_second_approver += leave
            //     else:
            //         leaves_first_approver += leave
            // 
            // leaves_second_approver.write({'second_approver_id': current_employee.id})
            // leaves_first_approver.write({'first_approver_id': current_employee.id})
            // 
            // self._validate_leave_request()
            // if not self.env.context.get('leave_fast_create'):
            //     self.filtered(lambda holiday: holiday.validation_type != 'no_validation').activity_update()
            // return True
            */
            return default;
        }

        public async Task<HrLeave> ActivityUpdateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def activity_update(self):
            // if self.env.context.get('mail_activity_automation_skip'):
            //     return
            // 
            // to_clean, to_do, to_do_confirm_activity = self.env['hr.leave'], self.env['hr.leave'], self.env['hr.leave']
            // activity_vals = []
            // today = fields.Date.today()
            // model_id = self.env['ir.model']._get_id('hr.leave')
            // confirm_activity = self.env.ref('hr_holidays.mail_act_leave_approval')
            // approval_activity = self.env.ref('hr_holidays.mail_act_leave_second_approval')
            // for holiday in self:
            //     if holiday.state in ['confirm', 'validate1']:
            //         if holiday.holiday_status_id.leave_validation_type != 'no_validation':
            //             if holiday.state == 'confirm':
            //                 activity_type = confirm_activity
            //                 note = _(
            //                     'New %(leave_type)s Request created by %(user)s',
            //                     leave_type=holiday.holiday_status_id.name,
            //                     user=holiday.create_uid.name,
            //                 )
            //             else:
            //                 activity_type = approval_activity
            //                 note = _(
            //                     'Second approval request for %(leave_type)s',
            //                     leave_type=holiday.holiday_status_id.name,
            //                 )
            //                 to_do_confirm_activity += holiday
            //             user_ids = holiday.sudo()._get_responsible_for_approval().ids
            //             for user_id in user_ids:
            //                 date_deadline = (
            //                     (holiday.date_from -
            //                      relativedelta(**{activity_type.delay_unit or 'days': activity_type.delay_count or 0})).date()
            //                     if holiday.date_from else today)
            //                 if date_deadline < today:
            //                     date_deadline = today
            //                 activity_vals.append({
            //                     'activity_type_id': activity_type.id,
            //                     'automated': True,
            //                     'date_deadline': date_deadline,
            //                     'note': note,
            //                     'user_id': user_id,
            //                     'res_id': holiday.id,
            //                     'res_model_id': model_id,
            //                 })
            //     elif holiday.state == 'validate':
            //         to_do |= holiday
            //     elif holiday.state in ['refuse', 'cancel']:
            //         to_clean |= holiday
            // if to_clean:
            //     to_clean.activity_unlink(self._get_to_clean_activities(), only_automated=False)
            // if to_do_confirm_activity:
            //     to_do_confirm_activity.activity_feedback(['hr_holidays.mail_act_leave_approval'])
            // if to_do:
            //     to_do.activity_feedback(['hr_holidays.mail_act_leave_approval', 'hr_holidays.mail_act_leave_second_approval'])
            // self.env['mail.activity'].with_context(short_name=False).create(activity_vals)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrLeave> AddFollowerAsync(Guid id, HrLeaveAddFollowerRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def add_follower(self, employee_id):
            // employee = self.env['hr.employee'].browse(employee_id)
            // if employee.user_id:
            //     self.message_subscribe(partner_ids=employee.user_id.partner_id.ids)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrLeave> ApproveAsync(Guid id, HrLeaveApproveRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def action_approve(self, check_state=True):
            // current_employee = self.env.user.employee_id
            // leave_to_approve = self.env['hr.leave']
            // leave_to_validate = self.env['hr.leave']
            // for leave in self:
            //     if check_state and leave.can_validate or not check_state and leave.validation_type != "both":
            //         leave_to_validate += leave
            //     elif check_state and leave.can_approve or not check_state and leave.validation_type == 'both':
            //         leave_to_approve += leave
            //     else:
            //         raise UserError(self.env._('You cannot approve this leave.'))
            // leave_to_approve.write({'state': 'validate1', 'first_approver_id': current_employee.id})
            // leave_to_validate._action_validate(check_state)
            // if not self.env.context.get('leave_fast_create'):
            //     self.activity_update()
            // return True
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py) ---
            // def action_approve(self, check_state=True):
            // res = super().action_approve(check_state)
            // self._check_overtime_deductible(self)
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrLeave> BackToApprovalAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def action_back_to_approval(self):
            // self.filtered(lambda l: l.can_back_to_approve)._move_validate_leave_to_confirm()
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrLeave> CancelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def action_cancel(self):
            // self.ensure_one()
            // 
            // return {
            //     'name': _('Cancel Time Off'),
            //     'type': 'ir.actions.act_window',
            //     'target': 'new',
            //     'res_model': 'hr.holidays.cancel.leave',
            //     'view_mode': 'form',
            //     'views': [[False, 'form']],
            //     'context': {
            //         'default_leave_id': self.id,
            //         'dialog_size': "medium",
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrLeave> CancelInvalidLeavesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _cancel_invalid_leaves(self):
            // inspected_date = fields.Date.today() + timedelta(days=31)
            // start_datetime = datetime.combine(fields.Date.today(), datetime.min.time())
            // end_datetime = datetime.combine(inspected_date, datetime.max.time())
            // concerned_leaves = self.search([
            //     ('date_from', '>=', start_datetime),
            //     ('date_from', '<=', end_datetime),
            //     ('state', 'in', ['confirm', 'validate1', 'validate']),
            // ], order='date_from desc')
            // accrual_allocations = self.env['hr.leave.allocation'].search([
            //     ('employee_id', 'in', concerned_leaves.employee_id.ids),
            //     ('holiday_status_id', 'in', concerned_leaves.holiday_status_id.ids),
            //     ('allocation_type', '=', 'accrual'),
            //     ('date_from', '<=', end_datetime),
            //     '|',
            //     ('date_to', '>=', start_datetime),
            //     ('date_to', '=', False),
            // ])
            // # only take leaves linked to accruals
            // concerned_leaves = concerned_leaves\
            //     .filtered(lambda leave: leave.holiday_status_id in accrual_allocations.holiday_status_id)\
            //     .sorted('date_from', reverse=True)
            // reason = _("the accruated amount is insufficient for that duration.")
            // for leave in concerned_leaves:
            //     leave_type = leave.holiday_status_id
            //     date = leave.date_from.date()
            //     leave_type_data = leave_type.get_allocation_data(leave.employee_id, date)
            //     exceeding_duration = leave_type_data[leave.employee_id][0][1]['total_virtual_excess']
            //     excess_limit = leave_type.max_allowed_negative if leave_type.allows_negative else 0
            //     if exceeding_duration <= excess_limit:
            //         continue
            //     leave._force_cancel(reason, 'mail.mt_note')
            */
            return default;
        }

        protected async Task<HrLeave> CancelWorkEntryConflictInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py) ---
            // def _cancel_work_entry_conflict(self):
            // """
            // Creates a leave work entry for each hr.leave in self.
            // Check overlapping work entries with self.
            // Work entries completely included in a leave are archived.
            // e.g.:
            //     |----- work entry ----|---- work entry ----|
            //         |------------------- hr.leave ---------------|
            //                             ||
            //                             vv
            //     |----* work entry ****|
            //         |************ work entry leave --------------|
            // """
            // if not self:
            //     return
            // 
            // # 1. Create a work entry for each leave
            // work_entries_vals_list = []
            // for leave in self:
            //     contracts = leave.employee_id.sudo()._get_versions_with_contract_overlap_with_period(leave.date_from.date(), leave.date_to.date())
            //     for contract in contracts:
            //         # Generate only if it has aleady been generated
            //         if leave.date_to >= contract.date_generated_from and leave.date_from <= contract.date_generated_to:
            //             work_entries_vals_list += contracts._get_work_entries_values(
            //                 datetime.combine(leave.date_from, time.min),
            //                 datetime.combine(leave.date_to, time.max),
            //             )
            // 
            // work_entries_vals_list = self.env['hr.version']._generate_work_entries_postprocess(work_entries_vals_list)
            // new_leave_work_entries = self.env['hr.work.entry'].create(work_entries_vals_list)
            // 
            // if new_leave_work_entries:
            //     # 2. Fetch overlapping work entries, grouped by employees
            //     start = min(self.mapped('date_from'), default=False)
            //     stop = max(self.mapped('date_to'), default=False)
            //     work_entry_groups = self.env['hr.work.entry']._read_group([
            //         ('date', '<=', stop),
            //         ('date', '>=', start),
            //         ('employee_id', 'in', self.employee_id.ids),
            //     ], ['employee_id'], ['id:recordset'])
            //     work_entries_by_employee = {
            //         employee.id: work_entries
            //         for employee, work_entries in work_entry_groups
            //     }
            // 
            //     # 3. Archive work entries included in leaves
            //     included = self.env['hr.work.entry']
            //     overlappping = self.env['hr.work.entry']
            //     for work_entries in work_entries_by_employee.values():
            //         # Work entries for this employee
            //         new_employee_work_entries = work_entries & new_leave_work_entries
            //         previous_employee_work_entries = work_entries - new_leave_work_entries
            // 
            //         # Build intervals from work entries
            //         leave_intervals = new_employee_work_entries._to_intervals()
            //         conflicts_intervals = previous_employee_work_entries._to_intervals()
            // 
            //         # Compute intervals completely outside any leave
            //         # Intervals are outside, but associated records are overlapping.
            //         outside_intervals = conflicts_intervals - leave_intervals
            // 
            //         overlappping |= self.env['hr.work.entry']._from_intervals(outside_intervals)
            //         included |= previous_employee_work_entries - overlappping
            //     overlappping.filtered(lambda entry: entry.state != 'validated').write({'leave_id': False})
            //     included.filtered(lambda entry: entry.state != 'validated').write({'active': False})
            */
            return default;
        }

        protected async Task<HrLeave> CheckApprovalUpdateInternalAsync(object state, object raise_if_not_possible)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _check_approval_update(self, state, raise_if_not_possible=True):
            //         """ Check if target state is achievable. """
            //         if self.env.is_superuser():
            //             return True
            // 
            //         is_officer = self.env.user.has_group('hr_holidays.group_hr_holidays_user')
            // 
            //         for holiday in self:
            //             is_time_off_manager = holiday.employee_id.leave_manager_id == self.env.user
            //             dict_all_possible_state = holiday._get_next_states_by_state()
            //             validation_type = holiday.validation_type
            //             error_message = ""
            //             # Standard Check
            //             if holiday.state == state:
            //                 error_message = self.env._('You can\'t do the same action twice.')
            //             elif state == 'validate1' and validation_type != 'both':
            //                 error_message = self.env._('Not possible state. State Approve is only used for leave needed 2 approvals')
            //             elif holiday.state == 'cancel':
            //                 error_message = self.env._('A cancelled leave cannot be modified.')
            //             elif state not in dict_all_possible_state.get(holiday.state, {}):
            //                 if state == 'cancel':
            //                     error_message = self.env._('You can only cancel your own leave. You can cancel a leave only if this leave \
            // is approved, validated or refused.')
            //                 elif state == 'confirm':
            //                     error_message = self.env._('You can\'t reset a leave. Cancel/delete this one and create an other')
            //                 elif state == 'validate1':
            //                     if not is_time_off_manager:
            //                         error_message = self.env._('Only a Time Off Officer/Manager can approve a leave.')
            //                     else:
            //                         error_message = self.env._('You can\'t approve a validated leave.')
            //                 elif state == "validate":
            //                     if not is_time_off_manager:
            //                         error_message = self.env._('Only a Time Off Officer/Manager can validate a leave.')
            //                     elif holiday.state == "refuse":
            //                         error_message = self.env._('You can\'t approve this refused leave.')
            //                     else:
            //                         error_message = self.env._('You can only validate a leave with validation by Time Off Manager.')
            //                 elif state == "refuse":
            //                     if not is_time_off_manager:
            //                         error_message = self.env._('Only a Time Off Officer/Manager can refuse a leave.')
            //                     else:
            //                         error_message = self.env._('You can\'t refuse a leave with validation by Time Off Officer.')
            //             elif state != "cancel":
            //                 try:
            //                     holiday.check_access('write')
            //                 except UserError as e:
            //                     if raise_if_not_possible:
            //                         raise UserError(e)
            //                     return False
            //                 else:
            //                     continue
            //             if error_message:
            //                 if raise_if_not_possible:
            //                     raise UserError(error_message)
            //                 return False
            //         return True
            */
            return default;
        }

        protected async Task<HrLeave> CheckContractsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _check_contracts(self):
            //         """
            //             A leave cannot be set across multiple contracts.
            //             Note: a leave can be across multiple contracts despite this constraint.
            //             It happens if a leave is correctly created (not across multiple contracts) but
            //             contracts are later modifed/created in the middle of the leave.
            //         """
            //         for holiday in self.filtered('employee_id'):
            //             versions = holiday._get_overlapping_contracts()
            //             if len(versions.resource_calendar_id) > 1:
            //                 raise ValidationError(
            //                     self.env._("""A leave cannot be set across multiple versions with different working schedules.
            // 
            // Please create one time off for each version period.
            // 
            // Time off:
            // %(time_off)s
            // 
            // Versions:
            // %(versions)s""",
            //                       time_off=holiday.display_name,
            //                       versions='\n'.join(_(
            //                           "- '%(version)s' from %(start_date)s to %(end_date)s",
            //                           version=version.name or version.employee_id.name,
            //                           start_date=format_date(self.env, version.date_start),
            //                           end_date=format_date(self.env, version.date_end) if version.date_end else self.env._("undefined"),
            //                       ) for version in versions)))
            */
            return default;
        }

        protected async Task<HrLeave> CheckDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _check_date(self):
            // if self.env.context.get('leave_skip_date_check', False):
            //     return
            // for holiday in self:
            //     if holiday.dashboard_warning_message:
            //         raise ValidationError(holiday.dashboard_warning_message)
            */
            return default;
        }

        protected async Task<HrLeave> CheckDateStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _check_date_state(self):
            // if self.env.context.get('leave_skip_state_check'):
            //     return
            // for holiday in self:
            //     if holiday.state in ['validate1', 'validate']:
            //         raise ValidationError(_("This modification is not allowed in the current state."))
            */
            return default;
        }

        protected async Task<HrLeave> CheckDoubleValidationRulesInternalAsync(object employees, object state)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _check_double_validation_rules(self, employees, state):
            // if self.env.user.has_group('hr_holidays.group_hr_holidays_manager'):
            //     return
            // 
            // is_leave_user = self.env.user.has_group('hr_holidays.group_hr_holidays_user')
            // if state == 'validate1':
            //     employees = employees.filtered(lambda employee: employee.leave_manager_id != self.env.user)
            //     if employees and not is_leave_user:
            //         raise AccessError(_('You cannot first approve a time off for %s, because you are not his time off manager', employees[0].name))
            // elif state == 'validate' and not is_leave_user:
            //     # Is probably handled via ir.rule
            //     raise AccessError(_('You don\'t have the rights to apply second approval on a time off request'))
            */
            return default;
        }

        protected async Task<HrLeave> CheckMissingGlobalLeaveTimesheetsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_leave.py) ---
            // def _check_missing_global_leave_timesheets(self):
            // if not self:
            //     return
            // min_date = min(self.mapped('date_from'))
            // max_date = max(self.mapped('date_to'))
            // 
            // global_leaves = self.env['resource.calendar.leaves'].search([
            //     ("resource_id", "=", False),
            //     ("date_to", ">=", min_date),
            //     ("date_from", "<=", max_date),
            //     ("company_id.internal_project_id", "!=", False),
            //     ("company_id.leave_timesheet_task_id", "!=", False),
            // ])
            // if global_leaves:
            //     global_leaves._generate_public_time_off_timesheets(self.employee_id)
            */
            return default;
        }

        protected async Task<HrLeave> CheckOvertimeDeductibleInternalAsync(object leaves)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py) ---
            // def _check_overtime_deductible(self, leaves):
            // # If the type of leave is overtime deductible, we have to check that the employee has enough extra hours
            // hours = self._get_deductible_employee_overtime(leaves.employee_id)
            // for leave in leaves.filtered('overtime_deductible'):
            //     if hours[leave.employee_id] < 0:
            //         if leave.employee_id.user_id == self.env.user:
            //             raise ValidationError(_('You do not have enough extra hours to request this leave'))
            //         raise ValidationError(_('The employee does not have enough extra hours to request this leave.'))
            */
            return default;
        }

        protected async Task<HrLeave> CheckValidityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _check_validity(self):
            // sorted_leaves = defaultdict(lambda: self.env['hr.leave'])
            // for leave in self:
            //     sorted_leaves[(leave.holiday_status_id, leave.date_from.date())] |= leave
            // for (leave_type, date_from), leaves in sorted_leaves.items():
            //     if not leave_type.requires_allocation:
            //         continue
            //     employees = leaves.employee_id
            //     leave_data = leave_type.get_allocation_data(employees, date_from)
            //     if leave_type.allows_negative:
            //         max_excess = leave_type.max_allowed_negative
            //         for employee in employees:
            //             if not leave_data[employee]:
            //                 raise ValidationError(_("You do not have any allocation for this time off type.\n"
            //                                         "Please request an allocation before submitting your time off request."))
            //             if leave_data[employee] and leave_data[employee][0][1]['virtual_remaining_leaves'] < -max_excess:
            //                 raise ValidationError(_("There is no valid allocation to cover that request."))
            //         continue
            // 
            //     previous_leave_data = leave_type.with_context(
            //         ignored_leave_ids=leaves.ids
            //     ).get_allocation_data(employees, date_from)
            //     for employee in employees:
            //         previous_emp_data = previous_leave_data[employee] and previous_leave_data[employee][0][1]['virtual_excess_data']
            //         emp_data = leave_data[employee] and leave_data[employee][0][1]['virtual_excess_data']
            //         if not leave_data[employee]:
            //             raise ValidationError(_("You do not have any allocation for this time off type.\n"
            //                                     "Please request an allocation before submitting your time off request."))
            //         if not previous_emp_data and not emp_data:
            //             continue
            //         if previous_emp_data != emp_data and len(emp_data) >= len(previous_emp_data):
            //             raise ValidationError(_("There is no valid allocation to cover that request."))
            // is_leave_user = self.env.user.has_group('hr_holidays.group_hr_holidays_user')
            // if not is_leave_user and any(leave.has_mandatory_day for leave in self):
            //     raise ValidationError(_('You are not allowed to request time off on a Mandatory Day'))
            */
            return default;
        }

        protected async Task<HrLeave> ComputeCanApproveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_can_approve(self):
            // for holiday in self:
            //     holiday.can_approve = holiday._check_approval_update('validate1', raise_if_not_possible=False)
            */
            return default;
        }

        protected async Task<HrLeave> ComputeCanBackToApproveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_can_back_to_approve(self):
            // for holiday in self:
            //     holiday.can_back_to_approve = holiday.state == 'validate' and holiday._check_approval_update('confirm', raise_if_not_possible=False)
            */
            return default;
        }

        protected async Task<HrLeave> ComputeCanCancelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_can_cancel(self):
            // for holiday in self:
            //     holiday.can_cancel = holiday._check_approval_update('cancel', raise_if_not_possible=False)
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py) ---
            // def _compute_can_cancel(self):
            // super()._compute_can_cancel()
            // 
            // cancellable_leaves = self.filtered('can_cancel')
            // work_entries = self.env['hr.work.entry'].sudo().search([('state', '=', 'validated'), ('leave_id', 'in', cancellable_leaves.ids)])
            // leave_ids = work_entries.mapped('leave_id').ids
            // 
            // for leave in cancellable_leaves:
            //     leave.can_cancel = leave.id not in leave_ids
            */
            return default;
        }

        protected async Task<HrLeave> ComputeCanRefuseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_can_refuse(self):
            // for holiday in self:
            //     holiday.can_refuse = holiday._check_approval_update('refuse', raise_if_not_possible=False)
            */
            return default;
        }

        protected async Task<HrLeave> ComputeCanValidateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_can_validate(self):
            // for holiday in self:
            //     holiday.can_validate = holiday._check_approval_update('validate', raise_if_not_possible=False)
            */
            return default;
        }

        protected async Task<HrLeave> ComputeCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_company_id(self):
            // for holiday in self:
            //     holiday.company_id = holiday.employee_company_id or holiday.department_id.company_id or self.env.company
            */
            return default;
        }

        protected async Task<HrLeave> ComputeDashboardWarningMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_dashboard_warning_message(self):
            // all_leaves = self.search([
            //     ('date_from', '<', max(self.mapped('date_to'))),
            //     ('date_to', '>', min(self.mapped('date_from'))),
            //     ('employee_id', 'in', self.employee_id.ids),
            //     ('holiday_status_id.allow_request_on_top', '=', False),
            //     ('state', 'not in', ['cancel', 'refuse']),
            // ])
            // self.filtered(lambda self: self.state in ['cancel', 'refuse']).dashboard_warning_message = False
            // for holiday in self.filtered(lambda self: self.state not in ['cancel', 'refuse']):
            //     conflicting_holidays = all_leaves.filtered_domain([
            //         ('employee_id', 'in', holiday.employee_id.ids),
            //         ('date_from', '<', holiday.date_to),
            //         ('date_to', '>', holiday.date_from),
            //         ('id', 'not in', holiday.ids),
            //     ])
            //     if not conflicting_holidays:
            //         holiday.dashboard_warning_message = False
            //         continue
            // 
            //     conflicting_holidays_list = []
            //     # Do not display the name of the employee if the conflicting holidays have an employee_id.user_id equivalent to the user id
            //     holidays_only_have_uid = bool(holiday.employee_id)
            //     holiday_states = dict(conflicting_holidays.fields_get(allfields=['state'])['state']['selection'])
            //     for conflicting_holiday in conflicting_holidays:
            //         conflicting_holiday_data = {
            //             'employee_name': conflicting_holiday.employee_id.name,
            //             'date_from': format_date(self.env, min(conflicting_holiday.mapped('date_from'))),
            //             'date_to': format_date(self.env, min(conflicting_holiday.mapped('date_to'))),
            //             'state': holiday_states[conflicting_holiday.state]
            //         }
            //         if conflicting_holiday.employee_id.user_id.id != self.env.uid:
            //             holidays_only_have_uid = False
            //         if conflicting_holiday_data not in conflicting_holidays_list:
            //             conflicting_holidays_list.append(conflicting_holiday_data)
            // 
            //     msg = ""
            //     if holidays_only_have_uid:
            //         msg = self.env._('You\'ve already booked time off which overlaps with this period:')
            //     else:
            //         msg = self.env._('An employee already booked time off which overlaps with this period:')
            // 
            //     holiday.dashboard_warning_message = msg + "".join(
            //         ('\n\t' + self.env._('%(employee_name)s from %(date_from)s to %(date_to)s - %(state)s')) % {
            //             'employee_name': conflicting_holiday_data['employee_name'] if not holidays_only_have_uid else "",
            //             'date_from': conflicting_holiday_data['date_from'],
            //             'date_to': conflicting_holiday_data['date_to'],
            //             'state': conflicting_holiday_data['state']
            //         } for conflicting_holiday_data in conflicting_holidays_list
            //     )
            */
            return default;
        }

        protected async Task<HrLeave> ComputeDateFromToInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_date_from_to(self):
            // for holiday in self:
            //     if not holiday.request_date_from:
            //         holiday.date_from = False
            //         continue
            // 
            //     if not holiday.request_date_to:
            //         holiday.date_to = False
            //         continue
            // 
            //     if holiday.request_unit_hours:
            //         hour_from = holiday.request_hour_from
            //         hour_to = holiday.request_hour_to
            //         if not hour_from or not hour_to:
            //             computed_from, computed_to = holiday._get_hour_from_to(holiday.request_date_from, holiday.request_date_to)
            //             hour_from = hour_from or computed_from
            //             hour_to = hour_to or computed_to
            // 
            //     elif holiday.request_unit_half:
            //         period_map = {'am': 'morning', 'pm': 'afternoon'}
            //         from_period = period_map.get(holiday.request_date_from_period)
            //         to_period = period_map.get(holiday.request_date_to_period)
            //         if holiday.request_date_from == holiday.request_date_to:
            //             day_period = from_period if from_period == to_period else None
            //             hour_from, hour_to = holiday._get_hour_from_to(holiday.request_date_from, holiday.request_date_to,
            //                 day_period)
            //         else:
            //             hour_from, _ = holiday._get_hour_from_to(holiday.request_date_from, holiday.request_date_from, from_period)
            //             _, hour_to = holiday._get_hour_from_to(holiday.request_date_to, holiday.request_date_to, to_period)
            // 
            //     else:
            //         hour_from, hour_to = holiday._get_hour_from_to(holiday.request_date_from, holiday.request_date_to)
            // 
            //     holiday.date_from = self._to_utc(holiday.request_date_from, hour_from, holiday.employee_id or holiday)
            //     holiday.date_to = self._to_utc(holiday.request_date_to, hour_to, holiday.employee_id or holiday)
            */
            return default;
        }

        protected async Task<HrLeave> ComputeDepartmentIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_department_id(self):
            // for holiday in self:
            //     holiday.department_id = holiday.employee_id.department_id
            */
            return default;
        }

        protected async Task<HrLeave> ComputeDescriptionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_description(self):
            // self.check_access('read')
            // 
            // is_officer = self.env.user.has_group('hr_holidays.group_hr_holidays_user')
            // 
            // for leave in self:
            //     if is_officer or leave.user_id == self.env.user or leave.employee_id.leave_manager_id == self.env.user:
            //         leave.name = leave.sudo().private_name
            //     else:
            //         leave.name = '*****'
            */
            return default;
        }

        protected async Task<HrLeave> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_display_name(self):
            // for leave in self:
            //     user_tz = pytz.timezone(leave.tz)
            //     date_from_utc = leave.date_from and leave.date_from.astimezone(user_tz).date()
            //     date_to_utc = leave.date_to and leave.date_to.astimezone(user_tz).date()
            //     time_off_type_display = leave.holiday_status_id.name
            //     if self.env.context.get('short_name'):
            //         short_leave_name = leave.name or time_off_type_display or _('Time Off')
            //         leave.display_name = _("%(name)s: %(duration)s", name=short_leave_name, duration=leave.duration_display)
            //     else:
            //         target = leave.employee_id.name or ""
            //         display_date = format_date(self.env, date_from_utc) or ""
            //         if leave.number_of_days > 1 and date_from_utc and date_to_utc:
            //             display_date += _(' to %(date_to_utc)s',
            //                 date_to_utc=format_date(self.env, date_to_utc) or ""
            //             )
            //         if not target or self.env.context.get('hide_employee_name') and 'employee_id' in self.env.context.get('group_by', []):
            //             leave.display_name = _("%(leave_type)s: %(duration)s (%(start)s)",
            //                 leave_type=time_off_type_display,
            //                 duration=leave.duration_display,
            //                 start=display_date,
            //             )
            //         elif not time_off_type_display:
            //             leave.display_name = _("%(person)s: %(duration)s (%(start)s)",
            //                 person=target,
            //                 duration=leave.duration_display,
            //                 start=display_date,
            //             )
            //         else:
            //             leave.display_name = _("%(person)s on %(leave_type)s: %(duration)s (%(start)s)",
            //                 person=target,
            //                 leave_type=time_off_type_display,
            //                 duration=leave.duration_display,
            //                 start=display_date,
            //             )
            */
            return default;
        }

        protected async Task<HrLeave> ComputeDurationDisplayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_duration_display(self):
            // for leave in self:
            //     duration = leave.number_of_days
            //     unit = _('days')
            //     display = "%g %s" % (float_round(duration, precision_digits=2), unit)
            //     if leave.leave_type_request_unit == "hour":
            //         hours, minutes = divmod(abs(leave.number_of_hours) * 60, 60)
            //         minutes = round(minutes)
            //         if minutes == 60:
            //             minutes = 0
            //             hours += 1
            //         duration = '%d:%02d' % (hours, minutes)
            //         unit = _("hours")
            //         display = f"{duration} {unit}"
            //     leave.duration_display = display
            */
            return default;
        }

        protected async Task<HrLeave> ComputeDurationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_duration(self):
            // durations = self._get_durations()
            // for leave in self:
            //     days, hours = durations[leave.id]
            //     leave.number_of_hours = hours
            //     leave.number_of_days = days
            */
            return default;
        }

        protected async Task<HrLeave> ComputeEmployeeOvertimeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py) ---
            // def _compute_employee_overtime(self):
            // diff_by_employee = self._get_deductible_employee_overtime(self.employee_id)
            // for leave in self:
            //     leave.employee_overtime = diff_by_employee[leave.employee_id]
            */
            return default;
        }

        protected async Task<HrLeave> ComputeFromEmployeeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_from_employee_id(self):
            // for holiday in self:
            //     if not holiday.holiday_status_id.requires_allocation:
            //         continue
            //     if not holiday.employee_id:
            //         holiday.holiday_status_id = False
            //     elif holiday.employee_id.user_id != self.env.user and holiday._origin.employee_id != holiday.employee_id:
            //         if holiday.employee_id and not holiday.holiday_status_id.with_context(employee_id=holiday.employee_id.id).has_valid_allocation:
            //             holiday.holiday_status_id = False
            */
            return default;
        }

        protected async Task<HrLeave> ComputeHasMandatoryDayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_has_mandatory_day(self):
            // date_from, date_to = min(self.mapped('date_from')), max(self.mapped('date_to'))
            // if date_from and date_to:
            //     # Sudo to get access to version fields on employee (job_id)
            //     mandatory_days = self.employee_id.sudo()._get_mandatory_days(
            //         date_from.date(),
            //         date_to.date())
            // 
            //     for leave in self:
            //         department_ids = leave.employee_id.department_id.ids
            //         domain = [
            //             ('start_date', '<=', leave.date_to.date()),
            //             ('end_date', '>=', leave.date_from.date()),
            //             '|',
            //                 ('resource_calendar_id', '=', False),
            //                 ('resource_calendar_id', '=', leave.resource_calendar_id.id),
            //         ]
            //         if department_ids:
            //             domain += [
            //                 '|',
            //                 ('department_ids', '=', False),
            //                 ('department_ids', 'parent_of', department_ids),
            //             ]
            //         else:
            //             domain += [('department_ids', '=', False)]
            // 
            //         if leave.holiday_status_id.company_id:
            //             domain += [('company_id', '=', leave.holiday_status_id.company_id.id)]
            //         leave.has_mandatory_day = leave.date_from and leave.date_to and mandatory_days.filtered_domain(domain)
            // else:
            //     self.has_mandatory_day = False
            */
            return default;
        }

        protected async Task<HrLeave> ComputeIsHatchedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_is_hatched(self):
            // for holiday in self:
            //     holiday.is_striked = holiday.state == 'refuse'
            //     holiday.is_hatched = holiday.state not in ['refuse', 'validate']
            */
            return default;
        }

        protected async Task<HrLeave> ComputeLastSeveralDaysInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_last_several_days(self):
            // for holiday in self:
            //     holiday.last_several_days = holiday.number_of_days > 1
            */
            return default;
        }

        protected async Task<HrLeave> ComputeLeaveTypeIncreasesDurationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_leave_type_increases_duration(self):
            // durations = self._get_durations(check_leave_type=False)
            // for leave in self:
            //     days = durations[leave.id][0]
            //     if leave.leave_type_request_unit == 'day' and leave.holiday_status_requires_allocation and days < leave.number_of_days:
            //         leave.leave_type_increases_duration = self.env._("According to your working schedule you are expected to work"
            //         " %(days)s days in this period, but %(nb_days)s days will be used because this leave"
            //         " %(leave_type_name)s can only be taken by days.",
            //         days=days, nb_days=leave.number_of_days, leave_type_name=leave.holiday_status_id.name)
            //     else:
            //         leave.leave_type_increases_duration = ''
            */
            return default;
        }

        protected async Task<HrLeave> ComputeLeavesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_leaves(self):
            // date_from = fields.Date.from_string(self.env.context['default_request_date_from']) if 'default_request_date_from' in self.env.context else fields.Date.today()
            // employee_days_per_allocation = self.employee_id._get_consumed_leaves(self.holiday_status_id, date_from)[0]
            // for leave in self:
            //     virtual_remaining_leaves = 0
            //     max_leaves = 0
            //     for allocation, allocation_dict in employee_days_per_allocation[leave.employee_id][leave.holiday_status_id].items():
            //         if allocation and (not allocation.date_to or allocation.date_to >= date_from):
            //             max_leaves += allocation_dict['max_leaves']
            //             virtual_remaining_leaves += allocation_dict['virtual_remaining_leaves']
            //     leave.virtual_remaining_leaves = virtual_remaining_leaves
            //     leave.max_leaves = max_leaves
            */
            return default;
        }

        protected async Task<HrLeave> ComputeOvertimeDeductibleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py) ---
            // def _compute_overtime_deductible(self):
            // for leave in self:
            //     leave.overtime_deductible = leave.holiday_status_id.overtime_deductible and not leave.holiday_status_id.requires_allocation
            */
            return default;
        }

        protected async Task<HrLeave> ComputeRequestHourFromToInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_request_hour_from_to(self):
            // env_company_calendar = self.env.company.resource_calendar_id
            // for leave in self:
            //     calendar = leave.resource_calendar_id or env_company_calendar
            //     if (not leave.request_unit_hours
            //             and leave.employee_id
            //             and leave.request_date_from
            //             and leave.request_date_to
            //             and calendar):
            //         hour_from, hour_to = leave._get_hour_from_to(leave.request_date_from, leave.request_date_to)
            //         leave.request_hour_from = hour_from
            //         leave.request_hour_to = hour_to
            */
            return default;
        }

        protected async Task<HrLeave> ComputeRequestUnitHalfInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_request_unit_half(self):
            // for holiday in self:
            //     holiday.request_unit_half = holiday.leave_type_request_unit == 'half_day'
            */
            return default;
        }

        protected async Task<HrLeave> ComputeRequestUnitHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_request_unit_hours(self):
            // for holiday in self:
            //     holiday.request_unit_hours = holiday.leave_type_request_unit == 'hour'
            */
            return default;
        }

        protected async Task<HrLeave> ComputeResourceCalendarIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_resource_calendar_id(self):
            // leaves_without_emp_or_date = self.filtered(
            //     lambda leave: not (leave.employee_id and leave.request_date_from and leave.request_date_to)
            // )
            // valid_leaves = self - leaves_without_emp_or_date
            // leaves_without_emp_or_date.resource_calendar_id = self.env.company.resource_calendar_id
            // if not valid_leaves:
            //     return
            // employees_by_dates = defaultdict(lambda: self.env['hr.employee'])
            // contracts_by_employee = dict(
            //     self.env['hr.version']._read_group(
            //         domain=[('employee_id', 'in', self.employee_id.ids)],
            //         groupby=['employee_id'],
            //         aggregates=['id:recordset']
            //     )
            // )
            // for leave in valid_leaves:
            //     employees_by_dates[leave.request_date_from] += leave.employee_id
            // calendar_by_dates = {date_from: employees._get_calendars(date_from) for date_from, employees in employees_by_dates.items()}
            // for leave in valid_leaves:
            //     calendar = calendar_by_dates.get(leave.request_date_from, {}).get(leave.employee_id.id) \
            //                 or self.env.company.resource_calendar_id
            //     # We use the request dates to find the contracts, because date_from
            //     # and date_to are not set yet at this point. Since these dates are
            //     # used to get the contracts for which these leaves apply and
            //     # contract start- and end-dates are just dates (and not datetimes)
            //     # these dates are comparable.
            //     contracts = contracts_by_employee.get(leave.employee_id, self.env['hr.version']).filtered(
            //         lambda c: c.date_start <= leave.request_date_to and
            //                   (not c.date_end or c.date_end >= leave.request_date_from))
            //     if contracts:
            //         # If there are more than one contract they should all have the
            //         # same calendar, otherwise a constraint is violated.
            //         calendar = contracts[:1].resource_calendar_id
            //     leave.resource_calendar_id = calendar
            */
            return default;
        }

        protected async Task<HrLeave> ComputeSupportedAttachmentIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_supported_attachment_ids(self):
            // for holiday in self:
            //     holiday.supported_attachment_ids = holiday.attachment_ids
            //     holiday.supported_attachment_ids_count = len(holiday.attachment_ids.ids)
            */
            return default;
        }

        protected async Task<HrLeave> ComputeTzInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_tz(self):
            // for leave in self:
            //     leave.tz = leave.resource_calendar_id.tz or self.env.company.resource_calendar_id.tz or self.env.user.tz or 'UTC'
            */
            return default;
        }

        protected async Task<HrLeave> ComputeTzMismatchInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _compute_tz_mismatch(self):
            // for leave in self:
            //     leave.tz_mismatch = leave.tz != self.env.user.tz
            */
            return default;
        }

        public async Task<HrLeave> CopyDataAsync(Guid id, HrLeaveCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // if self.env.context.get('skip_copy_check'):
            //     return vals_list
            // if all(leave.state in ['cancel', 'refuse'] for leave in self):  # No overlap constraint in these cases
            //     return vals_list
            // raise UserError(_('A time off cannot be duplicated.'))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<HrLeave> CreateAsync(HrLeave entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def create(self, vals_list):
            // # Override to avoid automatic logging of creation
            // if not self.env.context.get('leave_fast_create'):
            //     leave_types = self.env['hr.leave.type'].browse([values.get('holiday_status_id') for values in vals_list if values.get('holiday_status_id')])
            //     mapped_validation_type = {leave_type.id: leave_type.leave_validation_type for leave_type in leave_types}
            // 
            //     for values in vals_list:
            //         employee_id = values.get('employee_id', False)
            //         leave_type_id = values.get('holiday_status_id')
            // 
            //         # Handle double validation
            //         if mapped_validation_type[leave_type_id] == 'both':
            //             self._check_double_validation_rules(employee_id, values.get('state', False))
            // 
            // if any(not vals.get('employee_id') for vals in vals_list):
            //     raise UserError(_("There is no employee set on the time off. Please make sure you're logged in the correct company."))
            // holidays = super(HrLeave, self.with_context(mail_create_nosubscribe=True)).create(vals_list)
            // holidays._check_validity()
            // self.env['hr.leave.allocation'].invalidate_model(['leaves_taken', 'max_leaves'])  # missing dependency on compute
            // 
            // for holiday in holidays:
            //     if not self.env.context.get('leave_fast_create'):
            //         # Everything that is done here must be done using sudo because we might
            //         # have different create and write rights
            //         # eg : holidays_user can create a leave request with validation_type = 'manager' for someone else
            //         # but they can only write on it if they are leave_manager_id
            //         holiday_sudo = holiday.sudo()
            //         holiday_sudo.add_follower(holiday.employee_id.id)
            //         if holiday.validation_type == 'manager':
            //             holiday_sudo.message_subscribe(partner_ids=holiday.employee_id.leave_manager_id.partner_id.ids)
            //         if holiday.validation_type == 'no_validation':
            //             # Automatic validation should be done in sudo, because user might not have the rights to do it by himself
            //             holiday_sudo.action_approve()
            //             holiday_sudo.message_subscribe(partner_ids=holiday._get_responsible_for_approval().partner_id.ids)
            //             holiday_sudo.message_post(body=_("The time off has been automatically approved"), subtype_xmlid="mail.mt_comment") # Message from OdooBot (sudo)
            //         elif not self.env.context.get('import_file'):
            //             holiday_sudo.activity_update()
            // return holidays
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py) ---
            // def create(self, vals_list):
            // res = super().create(vals_list)
            // self._check_overtime_deductible(res)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py) ---
            // def create(self, vals_list):
            // employee_ids = {v['employee_id'] for v in vals_list if v.get('employee_id')}
            // # We check a whole day before and after the interval of the earliest
            // # request_date_from and latest request_date_end because date_{from,to}
            // # can lie in this range due to time zone reasons.
            // # (We can't use date_from and date_to as they are not yet computed at
            // # this point.)
            // start_dates = [fields.Date.to_date(v.get('request_date_from')) for v in vals_list if v.get('request_date_from')]
            // stop_dates = [fields.Date.to_date(v.get('request_date_to')) for v in vals_list if v.get('request_date_to')]
            // start = datetime.combine(min(start_dates, default=datetime.max.date()) - relativedelta(days=1), time.min)
            // stop = datetime.combine(max(stop_dates, default=datetime.min.date()) + relativedelta(days=1), time.max)
            // with self.env['hr.work.entry']._error_checking(start=start, stop=stop, employee_ids=employee_ids):
            //     return super().create(vals_list)
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<HrLeave> CreateResourceLeaveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _create_resource_leave(self):
            // """ This method will create entry in resource calendar time off object at the time of holidays validated
            // :returns: created `resource.calendar.leaves`
            // """
            // vals_list = [leave._prepare_resource_leave_vals() for leave in self]
            // return self.env['resource.calendar.leaves'].sudo().create(vals_list)
            */
            return default;
        }

        protected async Task<HrLeave> DefaultGetRequestDatesInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _default_get_request_dates(self, values):
            // # The UI views initialize date_{from,to} due to how calendar views work.
            // # However it is request_date_{from,to} that should be used instead.
            // # Instead of overwriting all the javascript methods to use
            // # request_date_{from,to} instead of date_{from,to}, we just convert
            // # date_{from,to} to request_date_{from,to} here.
            // 
            // # Request dates are determined during an onchange scenario.
            // # To ensure that the values are correct in the client context (UI),
            // # the timezone must be applied (because no processing is carried out
            // # when these dates are received on the frontend).
            // # Note:
            // # Without the application of the timezone, days based on UTC datetimes
            // # will be returned (and will therefore not be correct for the client).
            // client_tz = self.env.tz
            // if values.get('date_from'):
            //     if not values.get('request_date_from'):
            //         values['request_date_from'] = pytz.utc.localize(values['date_from']).astimezone(client_tz)
            //     del values['date_from']
            // if values.get('date_to'):
            //     if not values.get('request_date_to'):
            //         values['request_date_to'] = pytz.utc.localize(values['date_to']).astimezone(client_tz)
            //     del values['date_to']
            // return values
            */
            return default;
        }

        public async Task<HrLeave> DocumentsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def action_documents(self):
            // domain = [('id', 'in', self.attachment_ids.ids)]
            // return {
            //     'name': _("Supporting Documents"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'ir.attachment',
            //     'context': {'create': False},
            //     'view_mode': 'kanban',
            //     'domain': domain
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrLeave> ForceCancelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _force_cancel(self, reason=None, msg_subtype='mail.mt_comment', notify_responsibles=True):
            // leaves = self.browse() if self.env.context.get(MODULE_UNINSTALL_FLAG) else self
            // if reason:
            //     model_description = self.env['ir.model']._get('hr.holidays').display_name
            //     for leave in leaves:
            //         body = self.env._(
            //             "The time off request has been cancelled for the following reason:%(reason)s",
            //             reason=Markup("<p>{reason}</p>").format(reason=reason)
            //         )
            //         leave.message_post(
            //             body=body,
            //             subtype_xmlid=msg_subtype
            //         )
            // 
            //         if not notify_responsibles:
            //             continue
            // 
            //         responsibles = self.env['res.partner']
            //         # manager
            //         if (leave.holiday_status_id.leave_validation_type == 'manager' and leave.state == 'validate') or (leave.holiday_status_id.leave_validation_type == 'both' and leave.state == 'validate1'):
            //             responsibles = leave.employee_id.leave_manager_id.partner_id
            //         # officer
            //         elif leave.holiday_status_id.leave_validation_type == 'hr' and leave.state == 'validate':
            //             responsibles = leave.holiday_status_id.responsible_ids.partner_id
            //         # both
            //         elif leave.holiday_status_id.leave_validation_type == 'both' and leave.state == 'validate':
            //             responsibles = leave.employee_id.leave_manager_id.partner_id
            //             responsibles |= leave.holiday_status_id.responsible_ids.partner_id
            // 
            //         if responsibles:
            //             body = self.env._(
            //                 "%(leave_name)s has been cancelled for the following reason: %(reason)s",
            //                 leave_name=leave.display_name,
            //                 reason=Markup("<blockquote>{reason}</blockquote>").format(reason=reason),
            //             )
            //             leave.message_notify(
            //                 partner_ids=responsibles.ids,
            //                 model_description=model_description,
            //                 subject=self.env._('Cancelled Time Off'),
            //                 body=body,
            //                 email_layout_xmlid="mail.mail_notification_layout",
            //                 subtitles=[leave.display_name],
            //             )
            // leave_sudo = self.sudo()
            // leave_sudo.state = "cancel"
            // leave_sudo.activity_update()
            // leave_sudo._post_leave_cancel()
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py) ---
            // def _force_cancel(self, *args, **kwargs):
            // super()._force_cancel(*args, **kwargs)
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_leave.py) ---
            // def _force_cancel(self, *args, **kwargs):
            // super()._force_cancel(*args, **kwargs)
            // # override this method to reevaluate timesheets after the leaves are updated via force cancel
            // timesheets = self.sudo().timesheet_ids
            // timesheets.holiday_id = False
            // timesheets.unlink()
            */
            return default;
        }

        protected async Task<HrLeave> GenerateTimesheetsInternalAsync(object ignored_resource_calendar_leaves)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_leave.py) ---
            // def _generate_timesheets(self, ignored_resource_calendar_leaves=None):
            // """ Timesheet will be generated on leave validation
            //     internal_project_id and leave_timesheet_task_id are used.
            //     The generated timesheet will be attached to this project/task.
            // """
            // vals_list = []
            // leave_ids = []
            // calendar_leaves_data = self.env['resource.calendar.leaves']._read_group([('holiday_id', 'in', self.ids)], ['holiday_id'], ['id:array_agg'])
            // mapped_calendar_leaves = {leave: calendar_leave_ids[0] for leave, calendar_leave_ids in calendar_leaves_data}
            // for leave in self:
            //     project, task = leave.employee_id.company_id.internal_project_id, leave.employee_id.company_id.leave_timesheet_task_id
            // 
            //     if not project or not task or leave.holiday_status_id.time_type == 'other':
            //         continue
            // 
            //     leave_ids.append(leave.id)
            //     if not leave.employee_id:
            //         continue
            // 
            //     calendar = leave.employee_id.resource_calendar_id
            //     calendar_timezone = pytz.timezone((calendar or leave.employee_id).tz)
            // 
            //     if calendar.flexible_hours and (leave.request_unit_hours or leave.request_unit_half or leave.date_from.date() == leave.date_to.date()):
            //         leave_date = leave.date_from.astimezone(calendar_timezone).date()
            //         if leave.request_unit_hours:
            //             hours = leave.request_hour_to - leave.request_hour_from
            //         elif leave.request_unit_half:
            //             hours = calendar.hours_per_day / 2
            //         else:  # Single-day leave
            //             hours = calendar.hours_per_day
            //         work_hours_data = [(leave_date, hours)]
            //     else:
            //         ignored_resource_calendar_leaves = ignored_resource_calendar_leaves or []
            //         if leave in mapped_calendar_leaves:
            //             ignored_resource_calendar_leaves.append(mapped_calendar_leaves[leave])
            //         work_hours_data = leave.employee_id._list_work_time_per_day(
            //             leave.date_from,
            //             leave.date_to,
            //             domain=[('id', 'not in', ignored_resource_calendar_leaves)] if ignored_resource_calendar_leaves else None)[leave.employee_id.id]
            // 
            //     for index, (day_date, work_hours_count) in enumerate(work_hours_data):
            //         vals_list.append(leave._timesheet_prepare_line_values(index, work_hours_data, day_date, work_hours_count, project, task))
            // 
            // # Unlink previous timesheets to avoid doublon (shouldn't happen on the interface but meh). Necessary when the function is called to regenerate timesheets.
            // old_timesheets = self.env["account.analytic.line"].sudo().search([('project_id', '!=', False), ('holiday_id', 'in', leave_ids)])
            // if old_timesheets:
            //     old_timesheets.holiday_id = False
            //     old_timesheets.unlink()
            // 
            // self.env['account.analytic.line'].sudo().create(vals_list)
            */
            return default;
        }

        protected async Task<HrLeave> GetDeductibleEmployeeOvertimeInternalAsync(object employees)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py) ---
            // def _get_deductible_employee_overtime(self, employees):
            // # return dict {employee: number of hours}
            // diff_by_employee = defaultdict(lambda: 0)
            // for employee, hours in self.env['hr.attendance.overtime.line'].sudo()._read_group(
            //     domain=[
            //         ('compensable_as_leave', '=', True),
            //         ('employee_id', 'in', employees.ids),
            //         ('status', '=', 'approved'),
            //     ],
            //     groupby=['employee_id'],
            //     aggregates=['manual_duration:sum'],
            // ):
            //     diff_by_employee[employee] += hours
            // for employee, hours in self._read_group(
            //     domain=[
            //         ('holiday_status_id.overtime_deductible', '=', True),
            //         ('holiday_status_id.requires_allocation', '=', False),
            //         ('employee_id', 'in', employees.ids),
            //         ('state', 'not in', ['refuse', 'cancel']),
            //     ],
            //     groupby=['employee_id'],
            //     aggregates=['number_of_hours:sum'],
            // ):
            //     diff_by_employee[employee] -= hours
            // for employee, hours in self.env['hr.leave.allocation']._read_group(
            //     domain=[
            //         ('holiday_status_id.overtime_deductible', '=', True),
            //         ('employee_id', 'in', employees.ids),
            //         ('state', '=', 'confirm'),
            //     ],
            //     groupby=['employee_id'],
            //     aggregates=['number_of_hours_display:sum'],
            // ):
            //     diff_by_employee[employee] -= hours
            // return diff_by_employee
            */
            return default;
        }

        protected async Task<HrLeave> GetDurationsInternalAsync(object check_leave_type, object resource_calendar)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _get_durations(self, check_leave_type=True, resource_calendar=None):
            // """
            // This method is factored out into a separate method from
            // _compute_duration so it can be hooked and called without necessarily
            // modifying the fields and triggering more computes of fields that
            // depend on number_of_hours or number_of_days.
            // """
            // result = {}
            // employee_leaves = self.filtered('employee_id')
            // employees_by_dates_calendar = defaultdict(lambda: self.env['hr.employee'])
            // for leave in employee_leaves:
            //     if not leave.date_from or not leave.date_to:
            //         continue
            //     employees_by_dates_calendar[(leave.date_from, leave.date_to, leave.holiday_status_id.include_public_holidays_in_duration, resource_calendar or leave.resource_calendar_id)] += leave.employee_id
            // # We force the company in the domain as we are more than likely in a compute_sudo
            // domain = [('time_type', '=', 'leave'),
            //           ('company_id', 'in', self.env.companies.ids + self.env.context.get('allowed_company_ids', [])),
            //           # When searching for resource leave intervals, we exclude the one that
            //           # is related to the leave we're currently trying to compute for.
            //           '|', ('holiday_id', '=', False), ('holiday_id', 'not in', employee_leaves.ids)]
            // # Precompute values in batch for performance purposes
            // work_time_per_day_mapped = {
            //     (date_from, date_to, include_public_holidays_in_duration, calendar): employees.with_context(
            //             compute_leaves=not include_public_holidays_in_duration)._list_work_time_per_day(date_from, date_to, domain=domain, calendar=calendar)
            //     for (date_from, date_to, include_public_holidays_in_duration, calendar), employees in employees_by_dates_calendar.items()
            // }
            // work_days_data_mapped = {
            //     (date_from, date_to, include_public_holidays_in_duration, calendar): employees._get_work_days_data_batch(date_from, date_to, compute_leaves=not include_public_holidays_in_duration, domain=domain, calendar=calendar)
            //     for (date_from, date_to, include_public_holidays_in_duration, calendar), employees in employees_by_dates_calendar.items()
            // }
            // for leave in self:
            //     calendar = resource_calendar or leave.resource_calendar_id
            //     if not leave.date_from or not leave.date_to or (not calendar and not leave.employee_id):
            //         result[leave.id] = (0, 0)
            //         continue
            //     hours, days = (0, 0)
            //     if leave.employee_id:
            //         # For flexible employees, if it's a single day leave, we force it to the real duration since the virtual intervals might not match reality on that day, especially for custom hours
            //         # sudo as is_flexible is on version model and employee does not have access to it.
            //         if leave.employee_id.sudo().is_flexible and leave.request_date_to == leave.request_date_from:
            //             public_holidays = self.env['resource.calendar.leaves'].search([
            //                 ('resource_id', '=', False),
            //                 ('date_from', '<', leave.date_to),
            //                 ('date_to', '>', leave.date_from),
            //                 ('calendar_id', 'in', [False, calendar.id]),
            //                 ('company_id', '=', leave.company_id.id)
            //             ])
            //             if public_holidays:
            //                 public_holidays_intervals = Intervals([(ph.date_from, ph.date_to, ph) for ph in public_holidays])
            //                 leave_intervals = Intervals([(leave.date_from, leave.date_to, leave)])
            //                 real_leave_intervals = leave_intervals - public_holidays_intervals
            //                 hours = 0
            //                 for start, stop, meta in real_leave_intervals:
            //                     hours += (stop - start).total_seconds() / 3600
            //             else:
            //                 hours = (leave.date_to - leave.date_from).total_seconds() / 3600
            //             if not leave.request_unit_hours and not public_holidays:
            //                 days = 1 if not leave.request_unit_half or leave.request_date_from_period != leave.request_date_to_period else 0.5
            //             else:
            //                 days = hours / 24
            //         elif leave.leave_type_request_unit == 'day' and check_leave_type:
            //             # list of tuples (day, hours)
            //             work_time_per_day_list = work_time_per_day_mapped[leave.date_from, leave.date_to, leave.holiday_status_id.include_public_holidays_in_duration, calendar][leave.employee_id.id]
            //             days = len(work_time_per_day_list)
            //             hours = sum(map(lambda t: t[1], work_time_per_day_list))
            //         else:
            //             work_days_data = work_days_data_mapped[leave.date_from, leave.date_to, leave.holiday_status_id.include_public_holidays_in_duration, calendar][leave.employee_id.id]
            //             hours, days = work_days_data['hours'], work_days_data['days']
            //     else:
            //         today_hours = calendar.get_work_hours_count(
            //             datetime.combine(leave.date_from.date(), time.min),
            //             datetime.combine(leave.date_from.date(), time.max),
            //             False)
            //         hours = calendar.get_work_hours_count(leave.date_from, leave.date_to, compute_leaves=not leave.holiday_status_id.include_public_holidays_in_duration)
            //         days = hours / (today_hours or HOURS_PER_DAY)
            //     if leave.leave_type_request_unit == 'day' and check_leave_type:
            //         days = ceil(days)
            //     result[leave.id] = (days, hours)
            // return result
            */
            return default;
        }

        protected async Task<HrLeave> GetEmployeeDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _get_employee_domain(self):
            // domain = [
            //     ('active', '=', True),
            //     ('company_id', 'in', self.env.companies.ids),
            // ]
            // if not self.env.user.has_group('hr_holidays.group_hr_holidays_user'):
            //     domain += [
            //         '|',
            //         ('user_id', '=', self.env.uid),
            //         ('leave_manager_id', '=', self.env.uid),
            //     ]
            // return domain
            */
            return default;
        }

        protected async Task<HrLeave> GetHourFromToInternalAsync(object request_date_from, object request_date_to, object day_period)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _get_hour_from_to(self, request_date_from, request_date_to, day_period=None):
            // """
            // Return the hour_from and hour_to for the given request dates, based on
            // the resource calendar.
            // 
            // If there are no attendances on the exact days of the request, return
            // the earliest hour_from and latest hour_to that exist in the schedule.
            // """
            // calendar = self.resource_calendar_id
            // if not calendar:
            //     return (0, 24)
            // calendar.ensure_one()
            // 
            // hour_from, _ = calendar._get_hours_for_date(request_date_from, day_period)
            // _, hour_to = calendar._get_hours_for_date(request_date_to, day_period)
            // 
            // return (hour_from, hour_to)
            */
            return default;
        }

        protected async Task<HrLeave> GetLeavesOnPublicHolidayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _get_leaves_on_public_holiday(self):
            // return self.filtered(lambda l: l.employee_id and not l.number_of_days)
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py) ---
            // def _get_leaves_on_public_holiday(self):
            // return super()._get_leaves_on_public_holiday().filtered(
            //     lambda l: l.holiday_status_id.work_entry_type_id.code not in ['LEAVE110', 'LEAVE210', 'LEAVE280'])
            */
            return default;
        }

        protected async Task<HrLeave> GetNextStatesByStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _get_next_states_by_state(self):
            // self.ensure_one()
            // state_result = {
            //     'confirm': set(),
            //     'validate1': set(),
            //     'validate': set(),
            //     'refuse': set(),
            //     'cancel': set()
            // }
            // validation_type = self.validation_type
            // 
            // user_employees = self.env.user.employee_ids
            // is_own_leave = self.employee_id in user_employees
            // is_in_past = self.date_from and self.date_from.date() < fields.Date.today()
            // 
            // is_officer = self.env.user.has_group('hr_holidays.group_hr_holidays_user')
            // is_time_off_manager = self.employee_id.leave_manager_id == self.env.user
            // 
            // if is_own_leave and (not is_in_past or is_officer):
            //     state_result['validate1'].add('cancel')
            //     state_result['validate'].add('cancel')
            //     state_result['refuse'].add('cancel')
            // 
            // if is_officer:
            //     if validation_type == 'both':
            //         state_result['confirm'].add('validate1')
            //         state_result['refuse'].add('validate1')
            //         state_result['cancel'].add('validate1')
            //     state_result['confirm'].update({'validate', 'refuse'})
            //     state_result['validate1'].update({'confirm', 'validate', 'refuse'})
            //     state_result['validate'].update({'confirm', 'refuse'})
            //     state_result['refuse'].update({'confirm', 'validate'})
            //     state_result['cancel'].update({'confirm', 'validate', 'refuse'})
            // elif is_time_off_manager:
            //     if validation_type != 'hr':
            //         state_result['confirm'].add('refuse')
            //         state_result['validate'].add('refuse')
            //     if validation_type == 'both':
            //         state_result['confirm'].add('validate1')
            //         state_result['validate1'].add('refuse')
            //     elif validation_type == 'manager':
            //         state_result['confirm'].add('validate')
            //         state_result['refuse'].add('validate')
            // 
            // return state_result
            */
            return default;
        }

        protected async Task<HrLeave> GetOverlappingContractsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _get_overlapping_contracts(self):
            // self.ensure_one()
            // domain = Domain.AND([
            //     Domain('employee_id', '=', self.employee_id.id),
            //     Domain('contract_date_start', '<=', self.date_to),
            //     Domain.OR([
            //         Domain('contract_date_end', '>=', self.date_from),
            //         Domain('contract_date_end', '=', False),
            //     ])
            // ])
            // versions = self.env['hr.version'].sudo().search(domain)
            // return versions.filtered(lambda v: v._is_overlapping_period(self.date_from.date(), self.date_to.date()))
            */
            return default;
        }

        protected async Task<HrLeave> GetRedirectSuggestedCompanyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _get_redirect_suggested_company(self):
            // return self.holiday_status_id.company_id
            */
            return default;
        }

        protected async Task<HrLeave> GetResponsibleForApprovalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _get_responsible_for_approval(self):
            // self.ensure_one()
            // 
            // responsible = self.env['res.users']
            // if self.validation_type == 'manager' or (self.validation_type == 'both' and self.state == 'confirm'):
            //     if self.employee_id.leave_manager_id:
            //         responsible = self.employee_id.leave_manager_id
            //     elif self.employee_id.parent_id.user_id:
            //         responsible = self.employee_id.parent_id.user_id
            // elif self.validation_type == 'hr' or (self.validation_type == 'both' and self.state == 'validate1'):
            //     if self.holiday_status_id.responsible_ids:
            //         responsible = self.holiday_status_id.responsible_ids
            // return responsible
            */
            return default;
        }

        protected async Task<HrLeave> GetToCleanActivitiesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _get_to_clean_activities(self):
            // return ['hr_holidays.mail_act_leave_approval', 'hr_holidays.mail_act_leave_second_approval']
            */
            return default;
        }

        public async Task<HrLeave> GetUnusualDaysAsync(Guid id, HrLeaveGetUnusualDaysRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def get_unusual_days(self, date_from, date_to=None):
            // employee_id = self.env.context.get('employee_id', False)
            // employee = self.env['hr.employee'].browse(employee_id) if employee_id else self.env.user.employee_id
            // return employee.sudo(False)._get_unusual_days(date_from, date_to)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrLeave> InverseDescriptionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _inverse_description(self):
            // is_officer = self.env.user.has_group('hr_holidays.group_hr_holidays_user')
            // 
            // for leave in self:
            //     if is_officer or leave.user_id == self.env.user or leave.employee_id.leave_manager_id == self.env.user:
            //         leave.sudo().private_name = leave.name
            */
            return default;
        }

        protected async Task<HrLeave> InverseSupportedAttachmentIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _inverse_supported_attachment_ids(self):
            // for holiday in self:
            //     holiday.attachment_ids = holiday.supported_attachment_ids
            // self.invalidate_recordset(['attachment_ids'])
            */
            return default;
        }

        public async Task<HrLeave> MessageSubscribeAsync(Guid id, HrLeaveMessageSubscribeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def message_subscribe(self, partner_ids=None, subtype_ids=None):
            // # due to record rule can not allow to add follower and mention on validated leave so subscribe through sudo
            // if any(holiday.state in ['validate', 'validate1'] for holiday in self):
            //     self.check_access('read')
            //     return super(HrLeave, self.sudo()).message_subscribe(partner_ids=partner_ids, subtype_ids=subtype_ids)
            // return super().message_subscribe(partner_ids=partner_ids, subtype_ids=subtype_ids)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrLeave> MoveValidateLeaveToConfirmInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _move_validate_leave_to_confirm(self):
            // self.write({'state': 'confirm'})
            // self.activity_update()
            // self._post_leave_cancel()
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py) ---
            // def _move_validate_leave_to_confirm(self):
            // res = super()._move_validate_leave_to_confirm()
            // self._regen_work_entries()
            // return res
            */
            return default;
        }

        protected async Task<HrLeave> NotifyChangeInternalAsync(object message, object subtype_xmlid)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _notify_change(self, message, subtype_xmlid='mail.mt_note'):
            // for leave in self:
            //     leave.message_post(body=message, subtype_xmlid=subtype_xmlid)
            // 
            //     recipient = None
            //     if leave.user_id:
            //         recipient = leave.user_id.partner_id.id
            //     elif leave.employee_id:
            //         recipient = leave.employee_id.work_contact_id.id
            // 
            //     if recipient:
            //         self.env['mail.thread'].sudo().message_notify(
            //             body=message,
            //             partner_ids=[recipient],
            //             subject=_('Your Time Off'),
            //         )
            */
            return default;
        }

        protected async Task<HrLeave> NotifyManagerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _notify_manager(self):
            // leaves = self.filtered(lambda hol: (hol.validation_type == 'both' and hol.state in ['validate1', 'validate']) or (hol.validation_type == 'manager' and hol.state == 'validate'))
            // model_description = self.env['ir.model']._get('hr.holidays').name
            // for holiday in leaves:
            //     responsible = holiday.employee_id.leave_manager_id.partner_id.ids
            //     if responsible:
            //         holiday.sudo().message_notify(
            //             partner_ids=responsible,
            //             model_description=model_description,
            //             subject=_('Refused Time Off'),
            //             body=_(
            //                 '%(holiday_name)s has been refused.',
            //                 holiday_name=holiday.display_name,
            //             ),
            //             email_layout_xmlid="mail.mail_notification_layout",
            //             subtitles=[holiday.display_name],
            //         )
            */
            return default;
        }

        protected async Task<HrLeave> OnchangeHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _onchange_hours(self):
            // # avoid negative or after midnight
            // self.request_hour_from = min(max(self.request_hour_from, 0.0), 23.99)
            // self.request_hour_to = min(max(self.request_hour_to, 0.0), 24)
            */
            return default;
        }

        public async Task<HrLeave> OpenPendingRequestsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def open_pending_requests(self):
            // user_employee = self.env.user.employee_id
            // employee = self.env['hr.employee']._get_contextual_employee()
            // context = {'search_default_approve': True, 'search_default_second_approval': True}
            // domain = []
            // if employee != user_employee:
            //     view_name = 'hr_holidays.hr_leave_allocation_view_tree'
            //     context.update({'search_default_employee_id': employee.id})
            // else:
            //     view_name = 'hr_holidays.hr_leave_allocation_view_tree_my'
            //     domain = [('employee_id', '=', employee.id)]
            // return {
            //     'name': _('Allocation Requests'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.leave.allocation',
            //     'views': [[self.env.ref(view_name).id, 'list']],
            //     'domain': domain,
            //     'context': context,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrLeave> PostLeaveCancelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _post_leave_cancel(self):
            // self.meeting_id.active = False
            // self._remove_resource_leave()
            */
            return default;
        }

        protected async Task<HrLeave> PrepareHolidaysMeetingValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _prepare_holidays_meeting_values(self):
            // result = defaultdict(list)
            // for holiday in self:
            //     user = holiday.user_id
            //     meeting_name = _(
            //         "%(employee)s on Time Off : %(duration)s",
            //         employee=holiday.employee_id.name or holiday.category_id.name,
            //         duration=holiday.duration_display)
            //     allday_value = not holiday.request_unit_half
            //     if holiday.leave_type_request_unit == 'hour':
            //         allday_value = float_compare(holiday.number_of_days, 1.0, 1) >= 0
            // 
            //     leave_tz = pytz.timezone(holiday.tz) if holiday.tz else pytz.UTC
            //     start_value = pytz.UTC.localize(holiday.date_from).astimezone(leave_tz).replace(tzinfo=None)
            //     stop_value = pytz.UTC.localize(holiday.date_to).astimezone(leave_tz).replace(tzinfo=None)
            // 
            //     meeting_values = {
            //         'name': meeting_name,
            //         'duration': holiday.number_of_days * (holiday.resource_calendar_id.hours_per_day or HOURS_PER_DAY),
            //         'description': holiday.notes,
            //         'user_id': user.id,
            //         'start': start_value,
            //         'stop': stop_value,
            //         'allday': allday_value,
            //         'privacy': 'confidential',
            //         'event_tz': user.tz,
            //         'activity_ids': [(5, 0, 0)],
            //         'res_id': holiday.id,
            //     }
            //     # Add the partner_id (if exist) as an attendee
            //     partner_id = (user and user.partner_id) or (holiday.employee_id and holiday.employee_id.work_contact_id)
            //     if partner_id:
            //         meeting_values['partner_ids'] = [(4, partner_id.id)]
            //     result[user.id].append(meeting_values)
            // return result
            */
            return default;
        }

        protected async Task<HrLeave> PrepareResourceLeaveValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _prepare_resource_leave_vals(self):
            // """Hook method for others to inject data
            // """
            // self.ensure_one()
            // return {
            //     'name': _("%s: Time Off", self.employee_id.name),
            //     'date_from': self.date_from,
            //     'holiday_id': self.id,
            //     'date_to': self.date_to,
            //     'resource_id': self.employee_id.resource_id.id,
            //     'calendar_id': self.resource_calendar_id.id,
            //     'time_type': self.holiday_status_id.time_type,
            //     'elligible_for_accrual_rate': self.holiday_status_id.elligible_for_accrual_rate,
            // }
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py) ---
            // def _prepare_resource_leave_vals(self):
            // vals = super(HrLeave, self)._prepare_resource_leave_vals()
            // vals['work_entry_type_id'] = self.holiday_status_id.work_entry_type_id.id
            // return vals
            */
            return default;
        }

        public async Task<HrLeave> RefuseAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def action_refuse(self):
            // current_employee = self.env.user.employee_id
            // if any(holiday.state not in ['confirm', 'validate', 'validate1'] for holiday in self):
            //     raise UserError(_('Time off request must be confirmed or validated in order to refuse it.'))
            // 
            // self._notify_manager()
            // validated_holidays = self.filtered(lambda hol: hol.state == 'validate1')
            // validated_holidays.write({'state': 'refuse', 'first_approver_id': current_employee.id})
            // (self - validated_holidays).write({'state': 'refuse', 'second_approver_id': current_employee.id})
            // # Delete the meeting
            // self.mapped('meeting_id').write({'active': False})
            // # Post a second message, more verbose than the tracking message
            // for holiday in self:
            //     if holiday.employee_id.user_id:
            //         holiday.message_post(
            //             body=_('Your %(leave_type)s planned on %(date)s has been refused', leave_type=holiday.holiday_status_id.display_name, date=holiday.date_from),
            //             partner_ids=holiday.employee_id.user_id.partner_id.ids)
            // 
            // self.activity_update()
            // return True
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py) ---
            // def action_refuse(self):
            // res = super().action_refuse()
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py) ---
            // def action_refuse(self):
            // """
            // Override to archive linked work entries and recreate attendance work entries
            // where the refused leave was.
            // """
            // res = super().action_refuse()
            // self._regen_work_entries()
            // return res
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_leave.py) ---
            // def action_refuse(self):
            // """ Remove the timesheets linked to the refused holidays """
            // result = super().action_refuse()
            // timesheets = self.sudo().mapped('timesheet_ids')
            // timesheets.write({'holiday_id': False})
            // timesheets.unlink()
            // self._check_missing_global_leave_timesheets()
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrLeave> RegenWorkEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py) ---
            // def _regen_work_entries(self):
            // """
            // Called when the leave is refused or cancelled to regenerate the work entries properly for that period.
            // """
            // work_entries = self.env['hr.work.entry'].sudo().search([('leave_id', 'in', self.ids)])
            // 
            // work_entries.write({'active': False})
            // # Re-create attendance work entries
            // vals_list = []
            // for work_entry in work_entries:
            //     vals_list += work_entry.version_id._get_work_entries_values(
            //         datetime.combine(work_entry.date, time.min),
            //         datetime.combine(work_entry.date, time.max))
            // vals_list = self.env['hr.version']._generate_work_entries_postprocess(vals_list)
            // self.env['hr.work.entry'].create(vals_list)
            */
            return default;
        }

        protected async Task<HrLeave> RemoveResourceLeaveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _remove_resource_leave(self):
            // """ This method will create entry in resource calendar time off object at the time of holidays cancel/removed """
            // return self.env['resource.calendar.leaves'].search([('holiday_id', 'in', self.ids)]).unlink()
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py) ---
            // def _remove_resource_leave(self):
            // res = super()._remove_resource_leave()
            // self._update_leaves_overtime()
            // return res
            */
            return default;
        }

        public async Task<HrLeave> ResetConfirmAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py) ---
            // def action_reset_confirm(self):
            // self._check_overtime_deductible(self)
            // res = super().action_reset_confirm()
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrLeave> SearchDescriptionInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _search_description(self, operator, value):
            // is_officer = self.env.user.has_group('hr_holidays.group_hr_holidays_user')
            // domain = Domain('private_name', operator, value)
            // 
            // if not is_officer:
            //     domain &= Domain('user_id', '=', self.env.user.id)
            // query = self.sudo()._search(domain)
            // return Domain('id', 'in', query)
            */
            return default;
        }

        protected async Task<HrLeave> SplitLeavesInternalAsync(object split_date_from, object split_date_to)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _split_leaves(self, split_date_from, split_date_to=False):
            // """
            // This method splits an original leave in two leaves and returns the new one for each leave in self.
            // E.g. (start, stop) -> (start, split_date_from - 1day), (split_date_to, stop)
            // :param split_date_from: The starting date of the splicing interval (includes)
            // :param split_date_to: The ending date of the splicing interval. (not includes)
            // :param changes_message: The message will be translated and posted in the first leave's chatter
            // 
            // If split_date_to is not set; the splicing interval will be equals to [split_date_form, split_date_from -1]
            // to avoid one day leave.
            // """
            // new_leaves_vals = []
            // if not split_date_to:
            //     split_date_to = split_date_from
            // 
            // # Only leaves that span a period outside of the split interval need
            // # to be split.
            // multi_day_leaves = self.filtered(lambda l: l.request_date_from < split_date_from or l.request_date_to >= split_date_to)
            // for leave in multi_day_leaves:
            //     new_leave_vals = []
            //     target_leave_vals = []
            //     if leave.request_date_from < split_date_from:
            //         new_leave_vals.append(leave.with_context(skip_copy_check=True).copy_data({
            //             'request_date_to': split_date_from + timedelta(days=-1),
            //             'state': leave.state
            //         })[0])
            // 
            //     # Do the same for the new leave after the split
            //     if leave.request_date_to >= split_date_to:
            //         new_leave_vals.append(leave.with_context(skip_copy_check=True).copy_data({
            //             'request_date_from': split_date_to,
            //             'state': leave.state
            //         })[0])
            // 
            //     # For those two new leaves, only create them if they actually have a non-zero duration.
            //     for leave_vals in new_leave_vals:
            //         new_leave = self.env['hr.leave'].new(leave_vals)
            //         new_leave._compute_date_from_to()
            //         if new_leave.date_from < new_leave.date_to:
            //             target_leave_vals.append(new_leave._convert_to_write(new_leave._cache))
            // 
            //     if target_leave_vals:
            //         vals = target_leave_vals.pop(0)
            //         leave.with_context(leave_skip_state_check=True).write({
            //             'request_date_from': vals['request_date_from'],
            //             'request_date_to': vals['request_date_to'],
            //         })
            //         if target_leave_vals:
            //             new_leaves_vals.extend(target_leave_vals)
            // 
            // if not new_leaves_vals:
            //     return self.env['hr.leave']
            // return self.env['hr.leave'].with_context(
            //     tracking_disable=True,
            //     mail_activity_automation_skip=True,
            //     leave_fast_create=True,
            //     leave_skip_state_check=True
            // ).create(new_leaves_vals)
            */
            return default;
        }

        protected async Task<HrLeave> TimesheetPrepareLineValuesInternalAsync(object index, object work_hours_data, object day_date, object work_hours_count, object project, object task)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_leave.py) ---
            // def _timesheet_prepare_line_values(self, index, work_hours_data, day_date, work_hours_count, project, task):
            // self.ensure_one()
            // return {
            //     'name': _("Time Off (%(index)s/%(total)s)", index=index + 1, total=len(work_hours_data)),
            //     'project_id': project.id,
            //     'task_id': task.id,
            //     'account_id': project.sudo().account_id.id,
            //     'unit_amount': work_hours_count,
            //     'user_id': self.employee_id.user_id.id,
            //     'date': day_date,
            //     'holiday_id': self.id,
            //     'employee_id': self.employee_id.id,
            //     'company_id': task.sudo().company_id.id or project.sudo().company_id.id,
            // }
            */
            return default;
        }

        protected async Task<HrLeave> ToUtcInternalAsync(object date, object hour, object resource)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _to_utc(self, date, hour, resource):
            // hour = float_to_time(float(hour))
            // holiday_tz = pytz.timezone(resource.tz or self.env.user.tz or 'UTC')
            // return holiday_tz.localize(datetime.combine(date, hour)).astimezone(pytz.UTC).replace(tzinfo=None)
            */
            return default;
        }

        protected async Task<HrLeave> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _track_subtype(self, init_values):
            // if 'state' in init_values and self.state == 'validate':
            //     leave_notif_subtype = self.holiday_status_id.leave_notif_subtype_id
            //     return leave_notif_subtype or self.env.ref('hr_holidays.mt_leave')
            // return super()._track_subtype(init_values)
            */
            return default;
        }

        protected async Task<HrLeave> UnlinkIfCorrectStatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _unlink_if_correct_states(self):
            // error_message = self.env._('Oops! %(state)s Time-Off requests can only be deleted by Administrators.')
            // state_description_values = {elem[0]: elem[1] for elem in self._fields['state']._description_selection(self.env)}
            // now = fields.Datetime.now().date()
            // 
            // if not self.env.user.has_group('hr_holidays.group_hr_holidays_user'):
            //     for hol in self:
            //         if hol.state not in ['confirm', 'validate1', 'cancel']:
            //             raise UserError(error_message % {'state': state_description_values.get(self[:1].state)})
            //         if hol.date_from.date() < now:
            //             raise UserError(_("You can't delete a time off request that is in the past."))
            // elif not self.env.user.has_group('hr_holidays.group_hr_holidays_manager'):
            //     for holiday in self.filtered(lambda holiday: holiday.state not in ['cancel', 'confirm']):
            //         error_message = self.env._('Oops! %(state)s Time-Off requests can only be deleted by Administrators.')
            //         raise UserError(error_message % {'state': state_description_values.get(holiday.state)})
            */
            return default;
        }

        protected async Task<HrLeave> UpdateLeavesOvertimeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py) ---
            // def _update_leaves_overtime(self):
            // Attendance = self.env['hr.attendance']
            // dates = [
            //     Attendance._attendance_date(leave.date_from, leave.employee_id)
            //     for leave in self.filtered(lambda leave: leave.state == 'confirmed')
            // ]
            // if dates:
            //     Attendance.search([
            //         ('date', '>=', min(dates)),
            //         ('date', '<=', max(dates)),
            //         ('employee_id', 'in', self.employee_id.ids),
            //     ])._update_overtimes()
            */
            return default;
        }

        protected async Task<HrLeave> ValidateLeaveRequestInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def _validate_leave_request(self):
            // """ Validate time off requests
            // by creating a calendar event and a resource time off. """
            // holidays = self.filtered("employee_id")
            // holidays._create_resource_leave()
            // meeting_holidays = holidays.filtered(lambda l: l.holiday_status_id.create_calendar_meeting)
            // meetings = self.env['calendar.event']
            // if meeting_holidays:
            //     Meeting = self.env['calendar.event']
            //     Meeting.check_access('create')
            //     meeting_values_for_user_id = meeting_holidays._prepare_holidays_meeting_values()
            //     Meeting = self.env['calendar.event']
            //     for user_id, meeting_values in meeting_values_for_user_id.items():
            //         meetings += Meeting.with_user(user_id or self.env.uid).sudo().with_context(clean_context({**self.env.context, **dict(
            //                         allowed_company_ids=[],
            //                         no_mail_to_attendees=True,
            //                         calendar_no_videocall=True,
            //                         active_model=self._name
            //                     )})).create(meeting_values)
            // Holiday = self.env['hr.leave']
            // for meeting in meetings:
            //     Holiday.browse(meeting.res_id).meeting_id = meeting
            // 
            // for holiday in holidays:
            //     user_tz = pytz.timezone(holiday.tz)
            //     utc_tz = pytz.utc.localize(holiday.date_from).astimezone(user_tz)
            //     notify_partner_ids = holiday.employee_id.user_id.partner_id.ids
            //     holiday.message_post(
            //         body=_(
            //             'Your %(leave_type)s planned on %(date)s has been accepted',
            //             leave_type=holiday.holiday_status_id.display_name,
            //             date=utc_tz.replace(tzinfo=None)
            //         ),
            //         partner_ids=notify_partner_ids)
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py) ---
            // def _validate_leave_request(self):
            // super()._validate_leave_request()
            // self._update_leaves_overtime()
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py) ---
            // def _validate_leave_request(self):
            // super()._validate_leave_request()
            // self.sudo()._cancel_work_entry_conflict()  # delete preexisting conflicting work_entries
            // return True
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_leave.py) ---
            // def _validate_leave_request(self):
            // self._generate_timesheets()
            // return super()._validate_leave_request()
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, HrLeave entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave.py) ---
            // def write(self, vals):
            // values = vals
            // is_officer = self.env.user.has_group('hr_holidays.group_hr_holidays_user') or self.env.is_superuser()
            // if not is_officer and values.keys() - {'attachment_ids', 'supported_attachment_ids', 'message_main_attachment_id'}:
            //     if any(hol.date_from.date() < fields.Date.today() and hol.employee_id.leave_manager_id != self.env.user
            //            and hol.state not in ('confirm', 'draft') for hol in self):
            //         raise UserError(_('You must have manager rights to modify/validate a time off that already begun'))
            //     if any(leave.state == 'cancel' for leave in self):
            //         raise UserError(_('Only a manager can modify a canceled leave.'))
            // 
            // # Unlink existing resource.calendar.leaves for validated time off
            // if 'state' in values and values['state'] != 'validate':
            //     validated_leaves = self.filtered(lambda l: l.state == 'validate')
            //     validated_leaves._remove_resource_leave()
            // 
            // employee_id = values.get('employee_id', False)
            // if not self.env.context.get('leave_fast_create'):
            //     if values.get('state'):
            //         self._check_approval_update(values['state'])
            //         if any(holiday.validation_type == 'both' for holiday in self):
            //             if values.get('employee_id'):
            //                 employees = self.env['hr.employee'].browse(values.get('employee_id'))
            //             else:
            //                 employees = self.mapped('employee_id')
            //             self._check_double_validation_rules(employees, values['state'])
            //     if 'date_from' in values:
            //         values['request_date_from'] = values['date_from']
            //     if 'date_to' in values:
            //         values['request_date_to'] = values['date_to']
            // result = super().write(values)
            // if any(field in values for field in ['request_date_from', 'date_from', 'request_date_from', 'date_to', 'holiday_status_id', 'employee_id', 'state']):
            //     self._check_validity()
            //     self.env['hr.leave.allocation'].invalidate_model(['leaves_taken', 'max_leaves'])  # missing dependency on compute
            // if not self.env.context.get('leave_fast_create'):
            //     for holiday in self:
            //         if employee_id:
            //             holiday.add_follower(employee_id)
            // 
            // return result
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // fields_to_check = {'number_of_days', 'request_date_from', 'request_date_to', 'state', 'employee_id', 'holiday_status_id'}
            // if not any(field for field in fields_to_check if field in vals):
            //     return res
            // self._check_overtime_deductible(self)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_holidays, FILE: hr_leave.py) ---
            // def write(self, vals):
            // if not self:
            //     return True
            // skip_check = not bool({'employee_id', 'state', 'request_date_from', 'request_date_to'} & vals.keys())
            // employee_ids = self.employee_id.ids
            // if 'employee_id' in vals and vals['employee_id']:
            //     employee_ids += [vals['employee_id']]
            // # We check a whole day before and after the interval of the earliest
            // # request_date_from and latest request_date_end because date_{from,to}
            // # can lie in this range due to time zone reasons.
            // # (We can't use date_from and date_to as they are not yet computed at
            // # this point.)
            // start_dates = self.filtered('request_date_from').mapped('request_date_from') + [fields.Date.to_date(vals.get('request_date_from', False)) or datetime.max.date()]
            // stop_dates = self.filtered('request_date_to').mapped('request_date_to') + [fields.Date.to_date(vals.get('request_date_to', False)) or datetime.min.date()]
            // start = datetime.combine(min(start_dates) - relativedelta(days=1), time.min)
            // stop = datetime.combine(max(stop_dates) + relativedelta(days=1), time.max)
            // with self.env['hr.work.entry']._error_checking(start=start, stop=stop, skip=skip_check, employee_ids=employee_ids):
            //     return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_leave.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // # reevaluate timesheets after the leaves are wrote in order to remove empty timesheets
            // timesheet_ids_to_remove = []
            // for leave in self:
            //     if leave.number_of_days == 0 and leave.sudo().timesheet_ids:
            //         leave.sudo().timesheet_ids.holiday_id = False
            //         timesheet_ids_to_remove.extend(leave.timesheet_ids)
            // self.env['account.analytic.line'].browse(set(timesheet_ids_to_remove)).sudo().unlink()
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}