using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
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
    public class HrLeaveTypeAppService : GenericApplicationService<HrLeaveType>, IHrLeaveTypeAppService
    {

        public HrLeaveTypeAppService(IRepository<HrLeaveType, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<HrLeaveType> CheckAllocationRequirementEditValidityAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def check_allocation_requirement_edit_validity(self):
            // if self.env['hr.leave'].search_count([('holiday_status_id', 'in', self.ids)], limit=1):
            //     raise UserError(_("The allocation requirement of a time off type cannot be changed once leaves of that type have been taken. You should create a new time off type instead."))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrLeaveType> CheckOverlappingPublicHolidaysInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def _check_overlapping_public_holidays(self):
            // public_holidays = self.env['resource.calendar.leaves'].search([
            //     ('resource_id', '=', False),
            //     '|', ('company_id', 'in', self.company_id.ids),
            //          ('company_id', '=', self.env.company.id),
            // ])
            // 
            // # Define the date range for the current year
            // min_datetime = fields.Datetime.to_string(datetime.now().replace(month=1, day=1, hour=0, minute=0, second=0, microsecond=0))
            // max_datetime = fields.Datetime.to_string(datetime.now().replace(month=12, day=31, hour=23, minute=59, second=59))
            // 
            // leaves = self.env['hr.leave'].search([
            //     ('holiday_status_id', 'in', self.ids),
            //     ('date_from', '>=', min_datetime),
            //     ('date_from', '<=', max_datetime),
            //     ('state', 'in', ('validate', 'validate1', 'confirm')),
            // ])
            // 
            // for leave in leaves:
            //     leave_from_date = leave.date_from.date()
            //     leave_to_date = leave.date_to.date()
            // 
            //     for public_holiday in public_holidays:
            //         public_holiday_from_date = public_holiday.date_from.date()
            //         public_holiday_to_date = public_holiday.date_to.date()
            // 
            //         if leave_from_date <= public_holiday_to_date and leave_to_date >= public_holiday_from_date:
            //             raise ValidationError(_("You cannot modify the 'Public Holiday Included' setting since one or more leaves for that \
            //                 time off type are overlapping with public holidays, meaning that the balance of those employees would be affected by this change."))
            */
            return default;
        }

        protected async Task<HrLeaveType> CheckTimesheetGenerateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_holidays.py) ---
            // def _check_timesheet_generate(self):
            // for holiday_status in self:
            //     if holiday_status.timesheet_generate and holiday_status.company_id:
            //         if not holiday_status.timesheet_project_id or not holiday_status.timesheet_task_id:
            //             raise ValidationError(_("Both the internal project and task are required to "
            //             "generate a timesheet for the time off %s. If you don't want a timesheet, you should "
            //             "leave the internal project and task empty.", holiday_status.name))
            */
            return default;
        }

        protected async Task<HrLeaveType> ComputeAccrualCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def _compute_accrual_count(self):
            // accrual_allocations = self.env['hr.leave.accrual.plan']._read_group([('time_off_type_id', 'in', self.ids)], ['time_off_type_id'], ['__count'])
            // mapped_data = {time_off_type.id: count for time_off_type, count in accrual_allocations}
            // for leave_type in self:
            //     leave_type.accrual_count = mapped_data.get(leave_type.id, 0)
            */
            return default;
        }

        protected async Task<HrLeaveType> ComputeAllocationCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def _compute_allocation_count(self):
            // min_datetime = fields.Datetime.to_string(datetime.now().replace(month=1, day=1, hour=0, minute=0, second=0, microsecond=0))
            // max_datetime = fields.Datetime.to_string(datetime.now().replace(month=12, day=31, hour=23, minute=59, second=59))
            // domain = [
            //     ('holiday_status_id', 'in', self.ids),
            //     ('date_from', '>=', min_datetime),
            //     ('date_from', '<=', max_datetime),
            //     ('state', 'in', ('confirm', 'validate')),
            // ]
            // 
            // grouped_res = self.env['hr.leave.allocation']._read_group(
            //     domain,
            //     ['holiday_status_id'],
            //     ['__count'],
            // )
            // grouped_dict = {holiday_status.id: count for holiday_status, count in grouped_res}
            // for allocation in self:
            //     allocation.allocation_count = grouped_dict.get(allocation.id, 0)
            */
            return default;
        }

        protected async Task<HrLeaveType> ComputeAllocationValidationTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def _compute_allocation_validation_type(self):
            // for leave_type in self:
            //     if leave_type.employee_requests == 'no':
            //         leave_type.allocation_validation_type = 'hr'
            */
            return default;
        }

        protected async Task<HrLeaveType> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def _compute_display_name(self):
            // if not self.requested_display_name():
            //     # leave counts is based on employee_id, would be inaccurate if not based on correct employee
            //     return super()._compute_display_name()
            // for record in self:
            //     name = record.name
            //     if record.requires_allocation == "yes":
            //         remaining_time = float_round(record.virtual_remaining_leaves, precision_digits=2) or 0.0
            //         maximum = float_round(record.max_leaves, precision_digits=2) or 0.0
            // 
            //         if record.request_unit == "hour":
            //             name = _("%(name)s (%(time)g remaining out of %(maximum)g hours)", name=record.name, time=remaining_time, maximum=maximum)
            //         else:
            //             name = _("%(name)s (%(time)g remaining out of %(maximum)g days)", name=record.name, time=remaining_time, maximum=maximum)
            //     record.display_name = name
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave_type.py) ---
            // def _compute_display_name(self):
            // # Exclude hours available in allocation contexts, it might be confusing otherwise
            // if not self.requested_display_name() or self._context.get('request_type', 'leave') == 'allocation':
            //     return super()._compute_display_name()
            // 
            // employee = self.env['hr.employee'].browse(self._context.get('employee_id')).sudo()
            // if employee.total_overtime <= 0:
            //     return super()._compute_display_name()
            // 
            // overtime_leaves = self.filtered(lambda l_type: l_type.overtime_deductible and l_type.requires_allocation == 'no')
            // for leave_type in overtime_leaves:
            //     leave_type.display_name = "%(name)s (%(count)s)" % {
            //         'name': leave_type.name,
            //         'count': _('%s hours available',
            //             format_duration(employee.total_overtime)),
            //     }
            // super(HRLeaveType, self - overtime_leaves)._compute_display_name()
            */
            return default;
        }

        protected async Task<HrLeaveType> ComputeGroupDaysLeaveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def _compute_group_days_leave(self):
            // min_datetime = fields.Datetime.to_string(datetime.now().replace(month=1, day=1, hour=0, minute=0, second=0, microsecond=0))
            // max_datetime = fields.Datetime.to_string(datetime.now().replace(month=12, day=31, hour=23, minute=59, second=59))
            // domain = [
            //     ('holiday_status_id', 'in', self.ids),
            //     ('date_from', '>=', min_datetime),
            //     ('date_from', '<=', max_datetime),
            //     ('state', 'in', ('validate', 'validate1', 'confirm')),
            // ]
            // grouped_res = self.env['hr.leave']._read_group(
            //     domain,
            //     ['holiday_status_id'],
            //     ['__count'],
            // )
            // grouped_dict = {holiday_status.id: count for holiday_status, count in grouped_res}
            // for allocation in self:
            //     allocation.group_days_leave = grouped_dict.get(allocation.id, 0)
            */
            return default;
        }

        protected async Task<HrLeaveType> ComputeLeavesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def _compute_leaves(self):
            // employee = self.env['hr.employee']._get_contextual_employee()
            // target_date = self._context['default_date_from'] if 'default_date_from' in self._context else None
            // # This is a workaround to save the date value in context for next triggers
            // # when context gets cleaned and 'default_' context keys gets removed
            // if target_date:
            //     self.env.context = frozendict(self.env.context, leave_date_from=self._context['default_date_from'])
            // else:
            //     target_date = self._context.get('leave_date_from', None)
            // data_days = self.get_allocation_data(employee, target_date)[employee]
            // for holiday_status in self:
            //     result = [item for item in data_days if item[0] == holiday_status.name]
            //     leave_type_tuple = result[0] if result else ('', {})
            //     holiday_status.max_leaves = leave_type_tuple[1].get('max_leaves', 0)
            //     holiday_status.leaves_taken = leave_type_tuple[1].get('leaves_taken', 0)
            //     holiday_status.virtual_remaining_leaves = leave_type_tuple[1].get('virtual_remaining_leaves', 0)
            */
            return default;
        }

        protected async Task<HrLeaveType> ComputeTimesheetGenerateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_holidays.py) ---
            // def _compute_timesheet_generate(self):
            // for leave_type in self:
            //     leave_type.timesheet_generate = not leave_type.company_id or (leave_type.timesheet_task_id and leave_type.timesheet_project_id)
            */
            return default;
        }

        protected async Task<HrLeaveType> ComputeTimesheetProjectIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_holidays.py) ---
            // def _compute_timesheet_project_id(self):
            // for leave in self:
            //     leave.timesheet_project_id = leave.company_id.internal_project_id
            */
            return default;
        }

        protected async Task<HrLeaveType> ComputeTimesheetTaskIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: hr_holidays.py) ---
            // def _compute_timesheet_task_id(self):
            // for leave_type in self:
            //     default_task_id = leave_type.company_id.leave_timesheet_task_id
            // 
            //     if default_task_id and default_task_id.project_id == leave_type.timesheet_project_id:
            //         leave_type.timesheet_task_id = default_task_id
            //     else:
            //         leave_type.timesheet_task_id = False
            */
            return default;
        }

        protected async Task<HrLeaveType> ComputeValidInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def _compute_valid(self):
            // date_from = self._context.get('default_date_from', fields.Datetime.today())
            // date_to = self._context.get('default_date_to', fields.Datetime.today())
            // employee_id = self._context.get('default_employee_id', self._context.get('employee_id', self.env.user.employee_id.id))
            // for leave_type in self:
            //     if leave_type.requires_allocation == 'yes':
            //         allocations = self.env['hr.leave.allocation'].search([
            //             ('holiday_status_id', '=', leave_type.id),
            //             ('employee_id', '=', employee_id),
            //             ('date_from', '<=', date_from),
            //             '|',
            //             ('date_to', '>=', date_to),
            //             ('date_to', '=', False),
            //         ])
            //         allowed_excess = leave_type.max_allowed_negative if leave_type.allows_negative else 0
            //         allocations = allocations.filtered(lambda alloc:
            //             alloc.allocation_type == 'accrual'
            //             or (alloc.max_leaves > 0 and (alloc.max_leaves - alloc.leaves_taken) > -allowed_excess)
            //         )
            //         leave_type.has_valid_allocation = bool(allocations)
            //     else:
            //         leave_type.has_valid_allocation = True
            */
            return default;
        }

        public async Task<HrLeaveType> CopyDataAsync(Guid id, HrLeaveTypeCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", leave_type.name)) for leave_type, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrLeaveType> GetAllocationDataAsync(Guid id, HrLeaveTypeGetAllocationDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def get_allocation_data(self, employees, target_date=None):
            // allocation_data = defaultdict(list)
            // if target_date and isinstance(target_date, str):
            //     target_date = datetime.fromisoformat(target_date).date()
            // elif target_date and isinstance(target_date, datetime):
            //     target_date = target_date.date()
            // elif not target_date:
            //     target_date = fields.Date.today()
            // 
            // allocations_leaves_consumed, extra_data = employees.with_context(
            //     ignored_leave_ids=self.env.context.get('ignored_leave_ids')
            // )._get_consumed_leaves(self, target_date)
            // leave_type_requires_allocation = self.filtered(lambda lt: lt.requires_allocation == 'yes')
            // 
            // for employee in employees:
            //     for leave_type in leave_type_requires_allocation:
            //         if len(allocations_leaves_consumed[employee][leave_type]) == 0:
            //             continue
            //         lt_info = (
            //             leave_type.name,
            //             {
            //                 'remaining_leaves': 0,
            //                 'virtual_remaining_leaves': 0,
            //                 'max_leaves': 0,
            //                 'accrual_bonus': 0,
            //                 'leaves_taken': 0,
            //                 'virtual_leaves_taken': 0,
            //                 'leaves_requested': 0,
            //                 'leaves_approved': 0,
            //                 'closest_allocation_remaining': 0,
            //                 'closest_allocation_expire': False,
            //                 'holds_changes': False,
            //                 'total_virtual_excess': 0,
            //                 'virtual_excess_data': {},
            //                 'exceeding_duration': extra_data[employee][leave_type]['exceeding_duration'],
            //                 'request_unit': leave_type.request_unit,
            //                 'icon': leave_type.sudo().icon_id.url,
            //                 'allows_negative': leave_type.allows_negative,
            //                 'max_allowed_negative': leave_type.max_allowed_negative,
            //             },
            //             leave_type.requires_allocation,
            //             leave_type.id)
            //         for excess_date, excess_days in extra_data[employee][leave_type]['excess_days'].items():
            //             amount = excess_days['amount']
            //             lt_info[1]['virtual_excess_data'].update({
            //                 excess_date.strftime('%Y-%m-%d'): excess_days
            //             }),
            //             lt_info[1]['total_virtual_excess'] += amount
            //             if not leave_type.allows_negative:
            //                 continue
            //             lt_info[1]['virtual_leaves_taken'] += amount
            //             lt_info[1]['virtual_remaining_leaves'] -= amount
            //             if excess_days['is_virtual']:
            //                 lt_info[1]['leaves_requested'] += amount
            //             else:
            //                 lt_info[1]['leaves_approved'] += amount
            //                 lt_info[1]['leaves_taken'] += amount
            //                 lt_info[1]['remaining_leaves'] -= amount
            //         allocations_now = self.env['hr.leave.allocation']
            //         allocations_date = self.env['hr.leave.allocation']
            //         allocations_with_remaining_leaves = self.env['hr.leave.allocation']
            //         for allocation, data in allocations_leaves_consumed[employee][leave_type].items():
            //             # We only need the allocation that are valid at the given date
            //             if allocation:
            //                 today = fields.Date.today()
            //                 if allocation.date_from <= today and (not allocation.date_to or allocation.date_to >= today):
            //                     # we get each allocation available now to indicate visually if
            //                     # the future evaluation holds changes compared to now
            //                     allocations_now |= allocation
            //                 if allocation.date_from <= target_date and (not allocation.date_to or allocation.date_to >= target_date):
            //                     # we get each allocation available now to indicate visually if
            //                     # the future evaluation holds changes compared to now
            //                     allocations_date |= allocation
            //                 if allocation.date_from > target_date:
            //                     continue
            //                 if allocation.date_to and allocation.date_to < target_date:
            //                     continue
            //             lt_info[1]['remaining_leaves'] += data['remaining_leaves']
            //             lt_info[1]['virtual_remaining_leaves'] += data['virtual_remaining_leaves']
            //             lt_info[1]['max_leaves'] += data['max_leaves']
            //             lt_info[1]['accrual_bonus'] += data['accrual_bonus']
            //             lt_info[1]['leaves_taken'] += data['leaves_taken']
            //             lt_info[1]['virtual_leaves_taken'] += data['virtual_leaves_taken']
            //             lt_info[1]['leaves_requested'] += data['virtual_leaves_taken'] - data['leaves_taken']
            //             lt_info[1]['leaves_approved'] += data['leaves_taken']
            //             if data['virtual_remaining_leaves'] > 0:
            //                 allocations_with_remaining_leaves |= allocation
            //         closest_expiration_date, closest_allocation_remaining = self._get_closest_expiring_leaves_date_and_count(
            //                                                                     allocations_with_remaining_leaves,
            //                                                                     allocations_leaves_consumed[employee][leave_type],
            //                                                                     target_date
            //                                                                 )
            //         if closest_expiration_date:
            //             closest_allocation_expire = format_date(self.env, closest_expiration_date)
            //             calendar = employee.resource_calendar_id
            //             start_datetime = datetime.combine(target_date, time.min).replace(tzinfo=pytz.UTC)
            //             end_datetime = datetime.combine(closest_expiration_date, time.max).replace(tzinfo=pytz.UTC)
            //             closest_allocation_dict = {}
            //             if not calendar:
            //                 closest_allocation_dict['hours'] = float_round((end_datetime - start_datetime).total_seconds() / 3600, precision_rounding=0.001)
            //                 closest_allocation_dict['days'] = (end_datetime - start_datetime).days + 1
            //             else:
            //                 # closest_allocation_duration corresponds to the time remaining before the allocation expires
            //                 calendar_attendance = calendar._work_intervals_batch(start_datetime, end_datetime, resources=employee.resource_id)
            //                 closest_allocation_dict = calendar._get_attendance_intervals_days_data(calendar_attendance[employee.resource_id.id])
            //             if leave_type.request_unit in ['hour']:
            //                 closest_allocation_duration = closest_allocation_dict['hours']
            //             else:
            //                 closest_allocation_duration = closest_allocation_dict['days']
            //         else:
            //             closest_allocation_expire = False
            //             closest_allocation_duration = False
            //         # the allocations are assumed to be different from today's allocations if there is any
            //         # accrual days granted or if there is any difference between allocations now and on the selected date
            //         holds_changes = (lt_info[1]['accrual_bonus'] > 0
            //             or bool(allocations_date - allocations_now)
            //             or bool(allocations_now - allocations_date))\
            //             and target_date != fields.Date.today()
            //         lt_info[1].update({
            //             'closest_allocation_remaining': closest_allocation_remaining,
            //             'closest_allocation_expire': closest_allocation_expire,
            //             'closest_allocation_duration': closest_allocation_duration,
            //             'holds_changes': holds_changes,
            //         })
            //         if not self.env.context.get('from_dashboard', False) or lt_info[1]['max_leaves']:
            //             allocation_data[employee].append(lt_info)
            // for employee in allocation_data:
            //     for leave_type_data in allocation_data[employee]:
            //         for key, value in leave_type_data[1].items():
            //             if isinstance(value, float):
            //                 leave_type_data[1][key] = round(value, 2)
            // return allocation_data
            --- ODOO METHOD SOURCE (MODULE: hr_holidays_attendance, FILE: hr_leave_type.py) ---
            // def get_allocation_data(self, employees, date=None):
            // res = super().get_allocation_data(employees, date)
            // deductible_time_off_types = self.env['hr.leave.type'].search([
            //     ('overtime_deductible', '=', True),
            //     ('requires_allocation', '=', 'no')])
            // leave_type_names = deductible_time_off_types.mapped('name')
            // for employee in res:
            //     for leave_data in res[employee]:
            //         if leave_data[0] in leave_type_names:
            //             leave_data[1]['virtual_remaining_leaves'] = employee.sudo().total_overtime
            //             leave_data[1]['overtime_deductible'] = True
            //         else:
            //             leave_data[1]['overtime_deductible'] = False
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrLeaveType> GetAllocationDataRequestAsync(Guid id, HrLeaveTypeGetAllocationDataRequestRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def get_allocation_data_request(self, target_date=None, hidden_allocations=True):
            // domain = [
            //     '|',
            //     ('company_id', 'in', self.env.context.get('allowed_company_ids')),
            //     ('company_id', '=', False),
            // ]
            // if not hidden_allocations:
            //     domain.append(('show_on_dashboard', '=', True))
            // leave_types = self.search(domain, order='id')
            // employee = self.env['hr.employee']._get_contextual_employee()
            // if employee:
            //     return leave_types.get_allocation_data(employee, target_date)[employee]
            // return []
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrLeaveType> GetCarriedOverDaysExpirationDataInternalAsync(object allocations, object target_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def _get_carried_over_days_expiration_data(self, allocations, target_date):
            // fake_allocations = self.env['hr.leave.allocation']
            // for allocation in allocations:
            //     fake_allocations |= self.env['hr.leave.allocation'].with_context(default_date_from=target_date).new(origin=allocation)
            // fake_allocations.sudo().with_context(default_date_from=target_date)._process_accrual_plans(target_date, log=False)
            // carried_over_days_expiration_data = {
            //     fake_allocation._origin:
            //     {
            //         'expiration_date': fake_allocation.carried_over_days_expiration_date,
            //         'no_expiring_days': max(0, fake_allocation.expiring_carryover_days - fake_allocation.leaves_taken)
            //     }
            //     for fake_allocation in fake_allocations
            // }
            // fake_allocations.invalidate_recordset()
            // return carried_over_days_expiration_data
            */
            return default;
        }

        protected async Task<HrLeaveType> GetClosestExpiringLeavesDateAndCountInternalAsync(object allocations, object remaining_leaves, object target_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def _get_closest_expiring_leaves_date_and_count(self, allocations, remaining_leaves, target_date):
            // # Get the expiration date and carryover date of all allocations and compute the closest expiration date
            // expiration_dates_per_allocation = defaultdict(lambda: {'expiration_date': fields.Date(), 'carryover_date': fields.Date(), 'carried_over_days_expiration_date': fields.Date()})
            // expiration_dates = list()
            // carried_over_days_expiration_data = self._get_carried_over_days_expiration_data(allocations, target_date)
            // for allocation in allocations:
            //     expiration_date = allocation.date_to
            // 
            //     accrual_plan_level = allocation.sudo()._get_current_accrual_plan_level_id(target_date)[0]
            //     carryover_policy = accrual_plan_level.action_with_unused_accruals if accrual_plan_level else False
            //     carryover_date = False
            //     if carryover_policy in ['maximum', 'lost']:
            //         carryover_date = allocation.sudo()._get_carryover_date(target_date)
            //         # If carry over date == target date, then add 1 year to carry over date.
            //         # Rational: for example if carry over date = 01/01 this year and target date = 01/01 this year,
            //         # then any accrued days on 01/01 this year will have their carry over date 01/01 next year
            //         # and not 01/01 this year.
            //         if carryover_date == target_date:
            //             carryover_date += relativedelta(years=1)
            // 
            //     carried_over_days_expiration_date = carried_over_days_expiration_data[allocation]['expiration_date']
            // 
            //     expiration_dates.extend([expiration_date, carryover_date, carried_over_days_expiration_date])
            //     expiration_dates_per_allocation[allocation]['expiration_date'] = expiration_date
            //     expiration_dates_per_allocation[allocation]['carryover_date'] = carryover_date
            //     expiration_dates_per_allocation[allocation]['carried_over_days_expiration_date'] = carried_over_days_expiration_date
            // 
            // expiration_dates = list(filter(lambda date: date is not False, expiration_dates))
            // expiration_dates.sort()
            // # Compute the number of expiring leaves
            // for closest_expiration_date in expiration_dates:
            //     expiring_leaves_count = 0
            //     for allocation in allocations:
            //         expiration_date = expiration_dates_per_allocation[allocation]['expiration_date']
            //         carryover_date = expiration_dates_per_allocation[allocation]['carryover_date']
            //         carried_over_days_expiration_date = expiration_dates_per_allocation[allocation]['carried_over_days_expiration_date']
            // 
            //         if expiration_date and expiration_date == closest_expiration_date:
            //             expiring_leaves_count += remaining_leaves[allocation]['virtual_remaining_leaves']
            //         elif carryover_date and carryover_date == closest_expiration_date:
            //             accrual_plan_level = allocation.sudo()._get_current_accrual_plan_level_id(target_date)[0]
            //             expiring_leaves_count += max(0, remaining_leaves[allocation]['virtual_remaining_leaves'] - accrual_plan_level.postpone_max_days)
            //         elif carried_over_days_expiration_date and carried_over_days_expiration_date == closest_expiration_date:
            //             expiring_leaves_count += carried_over_days_expiration_data[allocation]['no_expiring_days']
            // 
            //     if expiring_leaves_count != 0:
            //         return closest_expiration_date, expiring_leaves_count
            // 
            // # No leaves will expire
            // return False, 0
            */
            return default;
        }

        public async Task<HrLeaveType> HasAccrualAllocationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def has_accrual_allocation(self):
            // employee = self.env['hr.employee']._get_contextual_employee()
            // if not employee:
            //     return False
            // return bool(self.env['hr.leave.allocation'].search_count([
            //     ('employee_id', '=', employee.id),
            //     ('state', '=', 'validate'),
            //     ('allocation_type', '=', 'accrual'),
            //     '|',
            //     ('date_to', '>', date.today()),
            //     ('date_to', '=', False),
            // ]))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrLeaveType> LoadRecordsWriteInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def _load_records_write(self, values):
            // if 'requires_allocation' in values and self.requires_allocation == values['requires_allocation']:
            //     values.pop('requires_allocation')
            // return super()._load_records_write(values)
            */
            return default;
        }

        protected async Task<HrLeaveType> ModelSortingKeyInternalAsync(object leave_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def _model_sorting_key(self, leave_type):
            // remaining = leave_type.virtual_remaining_leaves > 0
            // taken = leave_type.leaves_taken > 0
            // return -1 * leave_type.sequence, leave_type.employee_requests == 'no' and remaining, leave_type.employee_requests == 'yes' and remaining, taken
            */
            return default;
        }

        public async Task<HrLeaveType> RequestedDisplayNameAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def requested_display_name(self):
            // return self._context.get('holiday_status_display_name', True) and self._context.get('employee_id')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrLeaveType> SearchInternalAsync(object domain, object offset, object limit, object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def _search(self, domain, offset=0, limit=None, order=None):
            // """ Override _search to order the results, according to some employee.
            // The order is the following
            // 
            //  - allocation fixed first, then allowing allocation, then free allocation
            //  - virtual remaining leaves (higher the better, so using reverse on sorted)
            // 
            // This override is necessary because those fields are not stored and depends
            // on an employee_id given in context. This sort will be done when there
            // is an employee_id in context and that no other order has been given
            // to the method.
            // """
            // employee = self.env['hr.employee']._get_contextual_employee()
            // if order == self._order and employee:
            //     # retrieve all leaves, sort them, then apply offset and limit
            //     leaves = self.browse(super()._search(domain))
            //     leaves = leaves.sorted(key=self._model_sorting_key, reverse=True)
            //     leaves = leaves[offset:(offset + limit) if limit else None]
            //     return leaves._as_query()
            // return super()._search(domain, offset, limit, order)
            */
            return default;
        }

        protected async Task<HrLeaveType> SearchMaxLeavesInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def _search_max_leaves(self, operator, value):
            // value = float(value)
            // employee = self.env['hr.employee']._get_contextual_employee()
            // leaves = defaultdict(int)
            // 
            // if employee:
            //     allocations = self.env['hr.leave.allocation'].search([
            //         ('employee_id', '=', employee.id),
            //         ('state', '=', 'validate')
            //     ])
            //     for allocation in allocations:
            //         leaves[allocation.holiday_status_id.id] += allocation.number_of_days
            // valid_leave = []
            // for leave in leaves:
            //     if operator == '>':
            //         if leaves[leave] > value:
            //             valid_leave.append(leave)
            //     elif operator == '<':
            //         if leaves[leave] < value:
            //             valid_leave.append(leave)
            //     elif operator == '=':
            //         if leaves[leave] == value:
            //             valid_leave.append(leave)
            //     elif operator == '!=':
            //         if leaves[leave] != value:
            //             valid_leave.append(leave)
            // 
            // return [('id', 'in', valid_leave)]
            */
            return default;
        }

        protected async Task<HrLeaveType> SearchValidInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def _search_valid(self, operator, value):
            // """ Returns leave_type ids for which a valid allocation exists
            //     or that don't need an allocation
            //     return [('id', domain_operator, [x['id'] for x in res])]
            // """
            // 
            // if {'default_date_from', 'default_date_to', 'tz'} <= set(self._context):
            //     default_date_from_dt = fields.Datetime.to_datetime(self._context.get('default_date_from'))
            //     default_date_to_dt = fields.Datetime.to_datetime(self._context.get('default_date_to'))
            // 
            //     # Cast: Datetime -> Date using user's tz
            //     date_from = fields.Date.context_today(self, default_date_from_dt)
            //     date_to = fields.Date.context_today(self, default_date_to_dt)
            // 
            // else:
            //     date_from = fields.Date.today().strftime('%Y-1-1')
            //     date_to = fields.Date.today().strftime('%Y-12-31')
            // 
            // employee_id = self._context.get('default_employee_id', self._context.get('employee_id')) or self.env.user.employee_id.id
            // 
            // if not isinstance(value, bool):
            //     raise ValueError('Invalid value: %s' % (value))
            // if operator not in ['=', '!=']:
            //     raise ValueError('Invalid operator: %s' % (operator))
            // # '!=' True or '=' False
            // if (operator == '=') ^ value:
            //     new_operator = 'not in'
            // # '=' True or '!=' False
            // else:
            //     new_operator = 'in'
            // 
            // leave_types = self.env['hr.leave.allocation'].search([
            //     ('employee_id', '=', employee_id),
            //     ('state', '=', 'validate'),
            //     ('date_from', '<=', date_to),
            //     '|',
            //     ('date_to', '>=', date_from),
            //     ('date_to', '=', False),
            // ]).holiday_status_id
            // 
            // return [('id', new_operator, leave_types.ids)]
            */
            return default;
        }

        protected async Task<HrLeaveType> SearchVirtualRemainingLeavesInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def _search_virtual_remaining_leaves(self, operator, value):
            // value = float(value)
            // leave_types = self.env['hr.leave.type'].search([])
            // valid_leave_types = self.env['hr.leave.type']
            // 
            // for leave_type in leave_types:
            //     if leave_type.requires_allocation == "yes":
            //         if operator == '>' and leave_type.virtual_remaining_leaves > value:
            //             valid_leave_types |= leave_type
            //         elif operator == '<' and leave_type.virtual_remaining_leaves < value:
            //             valid_leave_types |= leave_type
            //         elif operator == '>=' and leave_type.virtual_remaining_leaves >= value:
            //             valid_leave_types |= leave_type
            //         elif operator == '<=' and leave_type.virtual_remaining_leaves <= value:
            //             valid_leave_types |= leave_type
            //         elif operator == '=' and leave_type.virtual_remaining_leaves == value:
            //             valid_leave_types |= leave_type
            //         elif operator == '!=' and leave_type.virtual_remaining_leaves != value:
            //             valid_leave_types |= leave_type
            //     else:
            //         valid_leave_types |= leave_type
            // 
            // return [('id', 'in', valid_leave_types.ids)]
            */
            return default;
        }

        public async Task<HrLeaveType> SeeAccrualPlansAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def action_see_accrual_plans(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("hr_holidays.open_view_accrual_plans")
            // action['domain'] = [
            //     ('time_off_type_id', '=', self.id),
            // ]
            // action['context'] = {
            //     'default_time_off_type_id': self.id,
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrLeaveType> SeeDaysAllocatedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def action_see_days_allocated(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("hr_holidays.hr_leave_allocation_action_all")
            // action['domain'] = [
            //     ('holiday_status_id', 'in', self.ids),
            // ]
            // action['context'] = {
            //     'employee_id': False,
            //     'default_holiday_status_id': self.ids[0],
            //     'search_default_approved_state': 1,
            //     'search_default_year': 1,
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrLeaveType> SeeGroupLeavesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_type.py) ---
            // def action_see_group_leaves(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("hr_holidays.hr_leave_action_action_approve_department")
            // action['domain'] = [
            //     ('holiday_status_id', '=', self.ids[0]),
            // ]
            // action['context'] = {
            //     'default_holiday_status_id': self.ids[0],
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}