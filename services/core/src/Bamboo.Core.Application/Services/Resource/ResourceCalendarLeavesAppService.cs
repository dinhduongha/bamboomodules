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
    [Module("Resource", Depends = new[] { "base", "web" })]
    public class ResourceCalendarLeavesAppService : GenericApplicationService<ResourceCalendarLeaves>, IResourceCalendarLeavesAppService
    {

        public ResourceCalendarLeavesAppService(IRepository<ResourceCalendarLeaves, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<ResourceCalendarLeaves> CheckCompareDatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py) ---
            // def _check_compare_dates(self):
            // all_existing_leaves = self.env['resource.calendar.leaves'].search([
            //     ('resource_id', '=', False),
            //     ('company_id', 'in', self.company_id.ids),
            //     ('date_from', '<=', max(self.mapped('date_to'))),
            //     ('date_to', '>=', min(self.mapped('date_from'))),
            // ])
            // for record in self:
            //     if not record.resource_id:
            //         existing_leaves = all_existing_leaves.filtered(lambda leave:
            //                 record.id != leave.id
            //                 and record['company_id'] == leave['company_id']
            //                 and record['date_from'] <= leave['date_to']
            //                 and record['date_to'] >= leave['date_from'])
            //         if record.calendar_id:
            //             existing_leaves = existing_leaves.filtered(lambda l: not l.calendar_id or l.calendar_id == record.calendar_id)
            //         if existing_leaves:
            //             raise ValidationError(_('Two public holidays cannot overlap each other for the same working hours.'))
            */
            return default;
        }

        public async Task<ResourceCalendarLeaves> CheckDatesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar_leaves.py) ---
            // def check_dates(self):
            // if self.filtered(lambda leave: leave.date_from > leave.date_to):
            //     raise ValidationError(_('The start date of the time off must be earlier than the end date.'))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResourceCalendarLeaves> ComputeCalendarIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: resource_calendar_leaves.py) ---
            // def _compute_calendar_id(self):
            // def date2datetime(date, tz):
            //     dt = datetime.fromordinal(date.toordinal())
            //     return tz.localize(dt).astimezone(utc).replace(tzinfo=None)
            // 
            // leaves_by_contract = self.grouped(lambda leave: leave.resource_id.employee_id.contract_id)
            // # set aside leaves without contract_id for super
            // remaining = leaves_by_contract.pop(
            //     self.env['hr.contract'],
            //     self.env['resource.calendar.leaves'],
            // )
            // for contract, leaves in leaves_by_contract.items():
            //     tz = timezone(contract.resource_calendar_id.tz or 'UTC')
            //     start_dt = date2datetime(contract.date_start, tz)
            //     end_dt = date2datetime(contract.date_end, tz) if contract.date_end else datetime.max
            //     # only modify leaves that fall under the active contract
            //     leaves.filtered(
            //         lambda leave: start_dt <= leave.date_from < end_dt
            //     ).calendar_id = contract.resource_calendar_id
            // 
            // super(ResourceCalendarLeaves, remaining)._compute_calendar_id()
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar_leaves.py) ---
            // def _compute_calendar_id(self):
            // for leave in self.filtered('resource_id'):
            //     leave.calendar_id = leave.resource_id.calendar_id
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> ComputeCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar_leaves.py) ---
            // def _compute_company_id(self):
            // for leave in self:
            //     leave.company_id = leave.calendar_id.company_id or self.env.company
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> ComputeDateToInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar_leaves.py) ---
            // def _compute_date_to(self):
            // user_tz = timezone(self.env.user.tz or self._context.get('tz') or self.company_id.resource_calendar_id.tz or 'UTC')
            // for leave in self:
            //     if not leave.date_from or (leave.date_to and leave.date_to > leave.date_from):
            //         continue
            //     local_date_from = utc.localize(leave.date_from).astimezone(user_tz)
            //     local_date_to = local_date_from + relativedelta(hour=23, minute=59, second=59)
            //     leave.date_to = local_date_to.astimezone(utc).replace(tzinfo=None)
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> ConvertTimezoneInternalAsync(object utc_naive_datetime, object tz_from, object tz_to)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py) ---
            // def _convert_timezone(self, utc_naive_datetime, tz_from, tz_to):
            // """
            //     Convert a naive date to another timezone that initial timezone
            //     used to generate the date.
            //     :param utc_naive_datetime: utc date without tzinfo
            //     :type utc_naive_datetime: datetime
            //     :param tz_from: timezone used to obtained `utc_naive_datetime`
            //     :param tz_to: timezone in which we want the date
            //     :return: datetime converted into tz_to without tzinfo
            //     :rtype: datetime
            // """
            // naive_datetime_from = utc_naive_datetime.astimezone(tz_from).replace(tzinfo=None)
            // aware_datetime_to = tz_to.localize(naive_datetime_from)
            // utc_naive_datetime_to = aware_datetime_to.astimezone(pytz.utc).replace(tzinfo=None)
            // return utc_naive_datetime_to
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> CopyLeaveValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: resource.py) ---
            // def _copy_leave_vals(self):
            // res = super()._copy_leave_vals()
            // res['work_entry_type_id'] = self.work_entry_type_id.id
            // return res
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar_leaves.py) ---
            // def _copy_leave_vals(self):
            // self.ensure_one()
            // return {
            //     'name': self.name,
            //     'date_from': self.date_from,
            //     'date_to': self.date_to,
            //     'time_type': self.time_type,
            // }
            */
            return default;
        }

        public override async Task<ResourceCalendarLeaves> CreateAsync(ResourceCalendarLeaves entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py) ---
            // def create(self, vals_list):
            // vals_list = self._prepare_public_holidays_values(vals_list)
            // res = super().create(vals_list)
            // time_domain_dict = res._get_time_domain_dict()
            // self._reevaluate_leaves(time_domain_dict)
            // return res
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: resource_calendar_leaves.py) ---
            // def create(self, vals_list):
            // results = super(ResourceCalendarLeaves, self).create(vals_list)
            // results._generate_timesheeets()
            // return results
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<ResourceCalendarLeaves> EnsureDatetimeInternalAsync(object datetime_representation, object date_format)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py) ---
            // def _ensure_datetime(self, datetime_representation, date_format=None):
            // """
            //     Be sure to get a datetime object if we have the necessary information.
            //     :param datetime_reprentation: object which should represent a datetime
            //     :rtype: datetime if a correct datetime_represtion, None otherwise
            // """
            // if isinstance(datetime_representation, datetime):
            //     return datetime_representation
            // elif isinstance(datetime_representation, str) and date_format:
            //     return datetime.strptime(datetime_representation, date_format)
            // else:
            //     return None
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> GeneratePublicTimeOffTimesheetsInternalAsync(object employees)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: resource_calendar_leaves.py) ---
            // def _generate_public_time_off_timesheets(self, employees):
            // timesheet_vals_list = []
            // resource_calendars = self._get_resource_calendars()
            // work_hours_data = self._work_time_per_day(resource_calendars)
            // timesheet_read_group = self.env['account.analytic.line']._read_group(
            //     [('global_leave_id', 'in', self.ids), ('employee_id', 'in', employees.ids)],
            //     ['employee_id'],
            //     ['date:array_agg']
            // )
            // timesheet_dates_per_employee_id = {
            //     employee.id: date
            //     for employee, date in timesheet_read_group
            // }
            // for leave in self:
            //     for employee in employees:
            //         if leave.calendar_id and employee.resource_calendar_id != leave.calendar_id:
            //             continue
            //         calendar = leave.calendar_id or employee.resource_calendar_id
            //         work_hours_list = work_hours_data[calendar.id][leave.id]
            //         timesheet_dates = timesheet_dates_per_employee_id.get(employee.id, [])
            //         for index, (day_date, work_hours_count) in enumerate(work_hours_list):
            //             generate_timesheet = day_date not in timesheet_dates
            //             if not generate_timesheet:
            //                 continue
            //             timesheet_vals = leave._timesheet_prepare_line_values(
            //                 index,
            //                 employee,
            //                 work_hours_list,
            //                 day_date,
            //                 work_hours_count
            //             )
            //             timesheet_vals_list.append(timesheet_vals)
            // return self.env['account.analytic.line'].sudo().create(timesheet_vals_list)
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> GenerateTimesheeetsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: resource_calendar_leaves.py) ---
            // def _generate_timesheeets(self):
            // results_with_leave_timesheet = self.filtered(lambda r: not r.resource_id and r.company_id.internal_project_id and r.company_id.leave_timesheet_task_id)
            // if results_with_leave_timesheet:
            //     results_with_leave_timesheet._timesheet_create_lines()
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> GetDomainInternalAsync(object time_domain_dict)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py) ---
            // def _get_domain(self, time_domain_dict):
            // domain = expression.OR([
            //     [
            //         ('employee_company_id', '=', date['company_id']),
            //         ('date_to', '>', date['date_from']),
            //         ('date_from', '<', date['date_to']),
            //     ]
            //     for date in time_domain_dict
            // ])
            // return expression.AND([domain, [('state', 'not in', ['refuse', 'cancel'])]])
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> GetResourceCalendarsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: resource_calendar_leaves.py) ---
            // def _get_resource_calendars(self):
            // leaves_with_calendar = self.filtered('calendar_id')
            // calendars = leaves_with_calendar.calendar_id
            // leaves_wo_calendar = self - leaves_with_calendar
            // if leaves_wo_calendar:
            //     calendars += self.env['resource.calendar'].search([('company_id', 'in', leaves_wo_calendar.company_id.ids)])
            // return calendars
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> GetTimeDomainDictInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py) ---
            // def _get_time_domain_dict(self):
            // return [{
            //     'company_id' : record.company_id.id,
            //     'date_from' : record.date_from,
            //     'date_to' : record.date_to
            // } for record in self if not record.resource_id]
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> PreparePublicHolidaysValuesInternalAsync(object vals_list)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py) ---
            // def _prepare_public_holidays_values(self, vals_list):
            // for vals in vals_list:
            //     # Manage the case of create a Public Time Off in another timezone
            //     # The datetime created has to be in UTC for the calendar's timezone
            //     if not vals.get('calendar_id') or vals.get('resource_id') or \
            //         not isinstance(vals.get('date_from'), (datetime, str)) or \
            //         not isinstance(vals.get('date_to'), (datetime, str)):
            //         continue
            //     user_tz = pytz.timezone(self.env.user.tz) if self.env.user.tz else pytz.utc
            //     calendar_tz = pytz.timezone(self.env['resource.calendar'].browse(vals['calendar_id']).tz)
            //     if user_tz != calendar_tz:
            //         datetime_from = self._ensure_datetime(vals['date_from'], '%Y-%m-%d %H:%M:%S')
            //         datetime_to = self._ensure_datetime(vals['date_to'], '%Y-%m-%d %H:%M:%S')
            //         if datetime_from and datetime_to:
            //             vals['date_from'] = self._convert_timezone(datetime_from, user_tz, calendar_tz)
            //             vals['date_to'] = self._convert_timezone(datetime_to, user_tz, calendar_tz)
            // return vals_list
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> ReevaluateLeavesInternalAsync(object time_domain_dict)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py) ---
            // def _reevaluate_leaves(self, time_domain_dict):
            // if not time_domain_dict:
            //     return
            // 
            // domain = self._get_domain(time_domain_dict)
            // leaves = self.env['hr.leave'].search(domain)
            // if not leaves:
            //     return
            // 
            // previous_durations = leaves.mapped('number_of_days')
            // previous_states = leaves.mapped('state')
            // leaves.sudo().write({
            //     'state': 'confirm',
            // })
            // self.env.add_to_compute(self.env['hr.leave']._fields['number_of_days'], leaves)
            // self.env.add_to_compute(self.env['hr.leave']._fields['duration_display'], leaves)
            // sick_time_status = self.env.ref('hr_holidays.holiday_status_sl', raise_if_not_found=False)
            // leaves_to_recreate = self.env['hr.leave']
            // for previous_duration, leave, state in zip(previous_durations, leaves, previous_states):
            //     duration_difference = previous_duration - leave.number_of_days
            //     message = False
            //     if duration_difference > 0 and leave.holiday_status_id.requires_allocation == 'yes':
            //         message = _("Due to a change in global time offs, you have been granted %s day(s) back.", duration_difference)
            //     if leave.number_of_days > previous_duration\
            //             and (not sick_time_status or leave.holiday_status_id not in sick_time_status):
            //         message = _("Due to a change in global time offs, %s extra day(s) have been taken from your allocation. Please review this leave if you need it to be changed.", -1 * duration_difference)
            //     try:
            //         leave.write({'state': state})
            //         leave._check_validity()
            //         if leave.state == 'validate':
            //             # recreate the resource leave that were removed by writing state to draft
            //             leaves_to_recreate |= leave
            //     except ValidationError:
            //         leave.action_refuse()
            //         message = _("Due to a change in global time offs, this leave no longer has the required amount of available allocation and has been set to refused. Please review this leave.")
            //     if message:
            //         leave._notify_change(message)
            // leaves_to_recreate.sudo()._create_resource_leave()
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> TimesheetCreateLinesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: resource_calendar_leaves.py) ---
            // def _timesheet_create_lines(self):
            // """ Create timesheet leaves for each employee using the same calendar containing in self.calendar_id
            // 
            //     If the employee has already a time off in the same day then no timesheet should be created.
            // """
            // resource_calendars = self._get_resource_calendars()
            // work_hours_data = self._work_time_per_day(resource_calendars)
            // employees_groups = self.env['hr.employee']._read_group(
            //     [('resource_calendar_id', 'in', resource_calendars.ids), ('company_id', 'in', self.env.companies.ids)],
            //     ['resource_calendar_id'],
            //     ['id:recordset'])
            // mapped_employee = {
            //     resource_calendar.id: employees
            //     for resource_calendar, employees in employees_groups
            // }
            // employee_ids_all = [_id for __, employees in employees_groups for _id in employees._ids]
            // min_date = max_date = None
            // for values in work_hours_data.values():
            //     for vals in values.values():
            //         for d, dummy in vals:
            //             if not min_date and not max_date:
            //                 min_date = max_date = d
            //             elif d < min_date:
            //                 min_date = d
            //             elif d > max_date:
            //                 max_date = d
            // 
            // holidays_read_group = self.env['hr.leave']._read_group([
            //     ('employee_id', 'in', employee_ids_all),
            //     ('date_from', '<=', max_date),
            //     ('date_to', '>=', min_date),
            //     ('state', '=', 'validate'),
            // ], ['employee_id'], ['date_from:array_agg', 'date_to:array_agg'])
            // holidays_by_employee = {
            //     employee.id: [
            //         (date_from.date(), date_to.date()) for date_from, date_to in zip(date_from_list, date_to_list)
            //     ] for employee, date_from_list, date_to_list in holidays_read_group
            // }
            // vals_list = []
            // 
            // def get_timesheets_data(employees, work_hours_list, vals_list):
            //     for employee in employees:
            //         holidays = holidays_by_employee.get(employee.id)
            //         for index, (day_date, work_hours_count) in enumerate(work_hours_list):
            //             if not holidays or all(not (date_from <= day_date and date_to >= day_date) for date_from, date_to in holidays):
            //                 vals_list.append(
            //                     leave._timesheet_prepare_line_values(
            //                         index,
            //                         employee,
            //                         work_hours_list,
            //                         day_date,
            //                         work_hours_count
            //                     )
            //                 )
            //     return vals_list
            // 
            // for leave in self:
            //     if not leave.calendar_id:
            //         for calendar_id, calendar_employees in mapped_employee.items():
            //             work_hours_list = work_hours_data[calendar_id][leave.id]
            //             vals_list = get_timesheets_data(calendar_employees, work_hours_list, vals_list)
            //     else:
            //         employees = mapped_employee.get(leave.calendar_id.id, self.env['hr.employee'])
            //         work_hours_list = work_hours_data[leave.calendar_id.id][leave.id]
            //         vals_list = get_timesheets_data(employees, work_hours_list, vals_list)
            // 
            // return self.env['account.analytic.line'].sudo().create(vals_list)
            */
            return default;
        }

        protected async Task<ResourceCalendarLeaves> TimesheetPrepareLineValuesInternalAsync(object index, Guid employee_id, object work_hours_data, object day_date, object work_hours_count)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: resource_calendar_leaves.py) ---
            // def _timesheet_prepare_line_values(self, index, employee_id, work_hours_data, day_date, work_hours_count):
            // self.ensure_one()
            // return {
            //     'name': _("Time Off (%(index)s/%(total)s)", index=index + 1, total=len(work_hours_data)),
            //     'project_id': employee_id.company_id.internal_project_id.id,
            //     'task_id': employee_id.company_id.leave_timesheet_task_id.id,
            //     'account_id': employee_id.company_id.internal_project_id.account_id.id,
            //     'unit_amount': work_hours_count,
            //     'user_id': employee_id.user_id.id,
            //     'date': day_date,
            //     'global_leave_id': self.id,
            //     'employee_id': employee_id.id,
            //     'company_id': employee_id.company_id.id,
            // }
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py) ---
            // def unlink(self):
            // time_domain_dict = self._get_time_domain_dict()
            // res = super().unlink()
            // self._reevaluate_leaves(time_domain_dict)
            // 
            // return res
            */
            return await base.UnlinkAsync(ids);
        }

        protected async Task<ResourceCalendarLeaves> WorkTimePerDayInternalAsync(object resource_calendars)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: resource_calendar_leaves.py) ---
            // def _work_time_per_day(self, resource_calendars=False):
            // """ Get work time per day based on the calendar and its attendances
            // 
            //     1) Gets all calendars with their characteristics (i.e.
            //         (a) the leaves in it,
            //         (b) the resources which have a leave,
            //         (c) the oldest and
            //         (d) the latest leave dates
            //        ) for leaves in self (first for calendar's leaves, then for company's global leaves)
            //     2) Search the attendances based on the characteristics retrieved for each calendar.
            //         The attendances found are the ones between the date_from of the oldest leave
            //         and the date_to of the most recent leave.
            //     3) Create a dict as result of this method containing:
            //         {
            //             leave: {
            //                     max(date_start of work hours, date_start of the leave):
            //                         the duration in days of the work including the leave
            //             }
            //         }
            // """
            // resource_calendars = resource_calendars or self._get_resource_calendars()
            // # to easily find the calendar with its id.
            // calendars_dict = {calendar.id: calendar for calendar in resource_calendars}
            // 
            // leaves_read_group = self.env['resource.calendar.leaves']._read_group(
            //     [('id', 'in', self.ids), ('calendar_id', '!=', False)],
            //     ['calendar_id'],
            //     ['id:recordset', 'resource_id:recordset', 'date_from:min', 'date_to:max'],
            // )
            // # dict of keys: calendar_id
            // #   and values : { 'date_from': datetime, 'date_to': datetime, resources: self.env['resource.resource'] }
            // cal_attendance_intervals_dict = {}
            // for calendar, leaves, resources, date_from_min, date_to_max in leaves_read_group:
            //     calendar_data = {
            //         'date_from': utc.localize(date_from_min),
            //         'date_to': utc.localize(date_to_max),
            //         'resources': resources,
            //         'leaves': leaves,
            //     }
            //     cal_attendance_intervals_dict[calendar.id] = calendar_data
            // 
            // comp_leaves_read_group = self.env['resource.calendar.leaves']._read_group(
            //     [('id', 'in', self.ids), ('calendar_id', '=', False)],
            //     ['company_id'],
            //     ['id:recordset', 'resource_id:recordset', 'date_from:min', 'date_to:max'],
            // )
            // for company, leaves, resources, date_from_min, date_to_max in comp_leaves_read_group:
            //     for calendar_id in resource_calendars.ids:
            //         if calendars_dict[calendar_id].company_id != company:
            //             continue  # only consider global leaves of the same company as the calendar
            //         calendar_data = cal_attendance_intervals_dict.get(calendar_id)
            //         if calendar_data is None:
            //             calendar_data = {
            //                 'date_from': utc.localize(date_from_min),
            //                 'date_to': utc.localize(date_to_max),
            //                 'resources': resources,
            //                 'leaves': leaves,
            //             }
            //             cal_attendance_intervals_dict[calendar_id] = calendar_data
            //         else:
            //             calendar_data.update(
            //                 date_from=min(utc.localize(date_from_min), calendar_data['date_from']),
            //                 date_to=max(utc.localize(date_to_max), calendar_data['date_to']),
            //                 resources=resources | calendar_data['resources'],
            //                 leaves=leaves | calendar_data['leaves'],
            //             )
            // 
            // # dict of keys: calendar_id
            // #   and values: a dict of keys: leave.id
            // #         and values: a dict of keys: date
            // #              and values: number of days
            // results = defaultdict(lambda: defaultdict(lambda: defaultdict(float)))
            // for calendar_id, cal_attendance_intervals_params_entry in cal_attendance_intervals_dict.items():
            //     calendar = calendars_dict[calendar_id]
            //     work_hours_intervals = calendar._attendance_intervals_batch(
            //         cal_attendance_intervals_params_entry['date_from'],
            //         cal_attendance_intervals_params_entry['date_to'],
            //         cal_attendance_intervals_params_entry['resources'],
            //         tz=timezone(calendar.tz)
            //     )
            //     for leave in cal_attendance_intervals_params_entry['leaves']:
            //         work_hours_data = work_hours_intervals[leave.resource_id.id]
            // 
            //         for date_from, date_to, dummy in work_hours_data:
            //             if date_to > utc.localize(leave.date_from) and date_from < utc.localize(leave.date_to):
            //                 tmp_start = max(date_from, utc.localize(leave.date_from))
            //                 tmp_end = min(date_to, utc.localize(leave.date_to))
            //                 results[calendar_id][leave.id][tmp_start.date()] += (tmp_end - tmp_start).total_seconds() / 3600
            //         results[calendar_id][leave.id] = sorted(results[calendar_id][leave.id].items())
            // return results
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, ResourceCalendarLeaves entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py) ---
            // def write(self, vals):
            // time_domain_dict = self._get_time_domain_dict()
            // res = super().write(vals)
            // time_domain_dict.extend(self._get_time_domain_dict())
            // self._reevaluate_leaves(time_domain_dict)
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: resource_calendar_leaves.py) ---
            // def write(self, vals):
            // date_from, date_to, calendar_id = vals.get('date_from'), vals.get('date_to'), vals.get('calendar_id')
            // global_time_off_updated = self.env['resource.calendar.leaves']
            // if date_from or date_to or 'calendar_id' in vals:
            //     global_time_off_updated = self.filtered(lambda r: (date_from is not None and r.date_from != date_from) or (date_to is not None and r.date_to != date_to) or (calendar_id is None or r.calendar_id.id != calendar_id))
            //     timesheets = global_time_off_updated.sudo().timesheet_ids
            //     if timesheets:
            //         timesheets.write({'global_leave_id': False})
            //         timesheets.unlink()
            // result = super(ResourceCalendarLeaves, self).write(vals)
            // global_time_off_updated and global_time_off_updated.sudo()._generate_timesheeets()
            // return result
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}