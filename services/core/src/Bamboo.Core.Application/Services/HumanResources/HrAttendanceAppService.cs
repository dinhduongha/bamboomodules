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
    [Module("HrAttendanceModule", Category = "HumanResources", Depends = new[] { "hr", "barcodes", "base_geolocalize" })]
    public partial class HrAttendanceAppService : GenericApplicationService<HrAttendance>, IHrAttendanceAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        public HrAttendanceAppService(IRepository<HrAttendance, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<HrAttendance> ApproveOvertimeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def action_approve_overtime(self):
            // self.linked_overtime_ids.action_approve()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrAttendance> CheckValidityCheckInCheckOutInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _check_validity_check_in_check_out(self):
            // """ verifies if check_in is earlier than check_out. """
            // for attendance in self:
            //     if attendance.check_in and attendance.check_out:
            //         if attendance.check_out < attendance.check_in:
            //             raise exceptions.ValidationError(_('"Check Out" time cannot be earlier than "Check In" time.'))
            */
            return default;
        }

        protected async Task<HrAttendance> CheckValidityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _check_validity(self):
            // """ Verifies the validity of the attendance record compared to the others from the same employee.
            //     For the same employee we must have :
            //         * maximum 1 "open" attendance record (without check_out)
            //         * no overlapping time slices with previous employee records
            // """
            // for attendance in self:
            //     # we take the latest attendance before our check_in time and check it doesn't overlap with ours
            //     last_attendance_before_check_in = self.env['hr.attendance'].search([
            //         ('employee_id', '=', attendance.employee_id.id),
            //         ('check_in', '<=', attendance.check_in),
            //         ('id', '!=', attendance.id),
            //     ], order='check_in desc', limit=1)
            //     if last_attendance_before_check_in and last_attendance_before_check_in.check_out and last_attendance_before_check_in.check_out > attendance.check_in:
            //         raise exceptions.ValidationError(_("Cannot create new attendance record for %(empl_name)s, the employee was already checked in on %(datetime)s",
            //                                            empl_name=attendance.employee_id.name,
            //                                            datetime=format_datetime(self.env, attendance.check_in, dt_format=False)))
            // 
            //     if not attendance.check_out:
            //         # if our attendance is "open" (no check_out), we verify there is no other "open" attendance
            //         no_check_out_attendances = self.env['hr.attendance'].search([
            //             ('employee_id', '=', attendance.employee_id.id),
            //             ('check_out', '=', False),
            //             ('id', '!=', attendance.id),
            //         ], order='check_in desc', limit=1)
            //         if no_check_out_attendances:
            //             raise exceptions.ValidationError(_("Cannot create new attendance record for %(empl_name)s, the employee hasn't checked out since %(datetime)s",
            //                                                empl_name=attendance.employee_id.name,
            //                                                datetime=format_datetime(self.env, no_check_out_attendances.check_in, dt_format=False)))
            //     else:
            //         # we verify that the latest attendance with check_in time before our check_out time
            //         # is the same as the one before our check_in time computed before, otherwise it overlaps
            //         last_attendance_before_check_out = self.env['hr.attendance'].search([
            //             ('employee_id', '=', attendance.employee_id.id),
            //             ('check_in', '<', attendance.check_out),
            //             ('id', '!=', attendance.id),
            //         ], order='check_in desc', limit=1)
            //         if last_attendance_before_check_out and last_attendance_before_check_in != last_attendance_before_check_out:
            //             raise exceptions.ValidationError(_("Cannot create new attendance record for %(empl_name)s, the employee was already checked in on %(datetime)s",
            //                                                empl_name=attendance.employee_id.name,
            //                                                datetime=format_datetime(self.env, last_attendance_before_check_out.check_in, dt_format=False)))
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _compute_color(self):
            // for attendance in self:
            //     if attendance.check_out:
            //         attendance.color = 1 if attendance.worked_hours > 16 or attendance.out_mode == 'technical' else 0
            //     else:
            //         attendance.color = 1 if attendance.check_in < (datetime.today() - timedelta(days=1)) else 10
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _compute_date(self):
            // for attendance in self:
            //     if not attendance.employee_id or not attendance.check_in:  # weird precompute edge cases. Never after creation
            //         attendance.date = datetime.today()
            //         continue
            //     tz = timezone(attendance.employee_id._get_tz())
            //     attendance.date = utc.localize(attendance.check_in).astimezone(tz).date()
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _compute_display_name(self):
            // tz = request.httprequest.cookies.get('tz') if request else None
            // for attendance in self:
            //     if not attendance.check_out:
            //         attendance.display_name = _(
            //             "From %s",
            //             format_time(self.env, attendance.check_in, time_format=None, tz=tz, lang_code=self.env.lang),
            //         )
            //     else:
            //         attendance.display_name = _(
            //             "%(worked_hours)s (%(check_in)s-%(check_out)s)",
            //             worked_hours=format_duration(attendance.worked_hours),
            //             check_in=format_time(self.env, attendance.check_in, time_format=None, tz=tz, lang_code=self.env.lang),
            //             check_out=format_time(self.env, attendance.check_out, time_format=None, tz=tz, lang_code=self.env.lang),
            //         )
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeExpectedHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _compute_expected_hours(self):
            // for attendance in self:
            //     attendance.expected_hours = attendance.worked_hours - attendance.overtime_hours
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeIsManagerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _compute_is_manager(self):
            // have_manager_right = self.env.user.has_group('hr_attendance.group_hr_attendance_user')
            // have_officer_right = self.env.user.has_group('hr_attendance.group_hr_attendance_officer')
            // for attendance in self:
            //     attendance.is_manager = have_manager_right or \
            //         (have_officer_right and attendance.attendance_manager_id.id == self.env.user.id)
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeLinkedOvertimeIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _compute_linked_overtime_ids(self):
            // overtimes_by_attendance = self._linked_overtimes().grouped(lambda ot: (ot.employee_id, ot.time_start))
            // for attendance in self:
            //     attendance.linked_overtime_ids = overtimes_by_attendance.get((attendance.employee_id, attendance.check_in), False)
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeOvertimeHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _compute_overtime_hours(self):
            // for attendance in self:
            //     attendance.overtime_hours = sum(attendance.linked_overtime_ids.mapped('manual_duration'))
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeOvertimeStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _compute_overtime_status(self):
            // for attendance in self:
            //     if not attendance.linked_overtime_ids:
            //         attendance.overtime_status = False
            //     elif all(attendance.linked_overtime_ids.mapped(lambda ot: ot.status == 'approved')):
            //         attendance.overtime_status = 'approved'
            //     elif all(attendance.linked_overtime_ids.mapped(lambda ot: ot.status == 'refused')):
            //         attendance.overtime_status = 'refused'
            //     else:
            //         attendance.overtime_status = 'to_approve'
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeValidatedOvertimeHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _compute_validated_overtime_hours(self):
            // for attendance in self:
            //     attendance.validated_overtime_hours = sum(attendance.linked_overtime_ids.filtered_domain([('status', '=', 'approved')]).mapped('manual_duration'))
            */
            return default;
        }

        protected async Task<HrAttendance> ComputeWorkedHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _compute_worked_hours(self):
            // """ Computes the worked hours of the attendance record.
            //     The worked hours of resource with flexible calendar is computed as the difference
            //     between check_in and check_out, without taking into account the lunch_interval"""
            // for attendance in self:
            //     if attendance.check_out and attendance.check_in and attendance.employee_id:
            //         calendar = attendance._get_employee_calendar()
            //         resource = attendance.employee_id.resource_id
            //         tz = timezone(resource.tz) if not calendar else timezone(calendar.tz)
            //         check_in_tz = attendance.check_in.astimezone(tz)
            //         check_out_tz = attendance.check_out.astimezone(tz)
            //         lunch_intervals = []
            //         if not resource._is_flexible():
            //             lunch_intervals = attendance.employee_id._employee_attendance_intervals(check_in_tz, check_out_tz, lunch=True)
            //         attendance_intervals = Intervals([(check_in_tz, check_out_tz, attendance)]) - lunch_intervals
            //         delta = sum((i[1] - i[0]).total_seconds() for i in attendance_intervals)
            //         attendance.worked_hours = delta / 3600.0
            //     else:
            //         attendance.worked_hours = False
            */
            return default;
        }

        protected async Task<HrAttendance> CronAbsenceDetectionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _cron_absence_detection(self):
            // """
            // Objective is to create technical attendances on absence days to have negative overtime created for that day
            // """
            // yesterday = datetime.today().replace(hour=0, minute=0, second=0) - relativedelta(days=1)
            // companies = self.env['res.company'].search([('absence_management', '=', True)])
            // if not companies:
            //     return
            // 
            // checked_in_employees = self.env['hr.attendance.overtime.line'].search([('date', '=', yesterday)]).employee_id
            // 
            // technical_attendances_vals = []
            // absent_employees = self.env['hr.employee'].search([
            //     ('id', 'not in', checked_in_employees.ids),
            //     ('company_id', 'in', companies.ids),
            //     ('resource_calendar_id.flexible_hours', '=', False),
            //     ('current_version_id.contract_date_start', '<=', fields.Date.today() - relativedelta(days=1))
            // ])
            // 
            // for emp in absent_employees:
            //     local_day_start = pytz.utc.localize(yesterday).astimezone(pytz.timezone(emp._get_tz()))
            //     technical_attendances_vals.append({
            //         'check_in': local_day_start.strftime('%Y-%m-%d %H:%M:%S'),
            //         'check_out': (local_day_start + relativedelta(seconds=1)).strftime('%Y-%m-%d %H:%M:%S'),
            //         'in_mode': 'technical',
            //         'out_mode': 'technical',
            //         'employee_id': emp.id
            //     })
            // 
            // technical_attendances = self.env['hr.attendance'].create(technical_attendances_vals)
            // to_unlink = technical_attendances.filtered(lambda a: a.overtime_hours == 0)
            // 
            // body = _('This attendance was automatically created to cover an unjustified absence on that day.')
            // for technical_attendance in technical_attendances - to_unlink:
            //     technical_attendance.message_post(body=body)
            // 
            // to_unlink.unlink()
            */
            return default;
        }

        protected async Task<HrAttendance> CronAutoCheckOutInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _cron_auto_check_out(self):
            // def check_in_tz(attendance):
            //     """Returns check-in time in calendar's timezone."""
            //     return attendance.check_in.astimezone(pytz.timezone(attendance.employee_id._get_tz()))
            // 
            // to_verify = self.env['hr.attendance'].search(
            //     [('check_out', '=', False),
            //      ('employee_id.company_id.auto_check_out', '=', True),
            //      ('employee_id.resource_calendar_id.flexible_hours', '=', False)]
            // )
            // 
            // if not to_verify:
            //     return
            // 
            // to_verify_min_date = min(to_verify.mapped('check_in')).replace(hour=0, minute=0, second=0)
            // previous_attendances = self.env['hr.attendance'].search([
            //             ('employee_id', 'in', to_verify.mapped('employee_id').ids),
            //             ('check_in', '>', to_verify_min_date),
            //             ('check_out', '!=', False)
            // ])
            // 
            // mapped_previous_duration = defaultdict(lambda: defaultdict(float))
            // for previous in previous_attendances:
            //     mapped_previous_duration[previous.employee_id][check_in_tz(previous).date()] += previous.worked_hours
            // 
            // all_companies = to_verify.employee_id.company_id
            // 
            // for company in all_companies:
            //     max_tol = company.auto_check_out_tolerance
            //     to_verify_company = to_verify.filtered(lambda a: a.employee_id.company_id.id == company.id)
            // 
            //     for att in to_verify_company:
            // 
            //         employee_timezone = pytz.timezone(att.employee_id._get_tz())
            //         check_in_datetime = check_in_tz(att)
            //         now_datetime = fields.Datetime.now().astimezone(employee_timezone)
            //         current_attendance_duration = (now_datetime - check_in_datetime).total_seconds() / 3600
            //         previous_attendances_duration = mapped_previous_duration[att.employee_id][check_in_datetime.date()]
            // 
            //         expected_worked_hours = sum(
            //             att.employee_id.resource_calendar_id.attendance_ids.filtered(
            //                 lambda a: a.dayofweek == str(check_in_datetime.weekday())
            //                     and (not a.two_weeks_calendar or a.week_type == str(a.get_week_type(check_in_datetime.date())))
            //             ).mapped("duration_hours")
            //         )
            // 
            //         # Attendances where Last open attendance time + previously worked time on that day + tolerance greater than the attendances hours (including lunch) in his calendar
            //         if (current_attendance_duration + previous_attendances_duration - max_tol) > expected_worked_hours:
            //             att.check_out = att.check_in.replace(hour=23, minute=59, second=59)
            //             excess_hours = att.worked_hours - (expected_worked_hours + max_tol - previous_attendances_duration)
            //             att.write({
            //                 "check_out": max(att.check_out - relativedelta(hours=excess_hours), att.check_in + relativedelta(seconds=1)),
            //                 "out_mode": "auto_check_out"
            //             })
            //             att.message_post(
            //                 body=_('This attendance was automatically checked out because the employee exceeded the allowed time for their scheduled work hours.')
            //             )
            */
            return default;
        }

        protected async Task<HrAttendance> DefaultEmployeeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _default_employee(self):
            // if self.env.user.has_group('hr_attendance.group_hr_attendance_user'):
            //     return self.env.user.employee_id
            */
            return default;
        }

        protected async Task<HrAttendance> GetAttendanceByPeriodsByEmployeeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _get_attendance_by_periods_by_employee(self):
            // attendance_by_employee_by_day = defaultdict(lambda: defaultdict(lambda: Intervals([], keep_distinct=True)))
            // attendance_by_employee_by_week = defaultdict(lambda: defaultdict(lambda: Intervals([], keep_distinct=True)))
            // 
            // for attendance in self.sorted('check_in'):
            //     employee = attendance.employee_id
            //     check_in, check_out = attendance._get_localized_times()
            //     for day in rrule(dtstart=check_in.date(), until=check_out.date(), freq=DAILY):
            //         week_date = day + relativedelta(days=6 - day.weekday())
            // 
            //         start_datetime = datetime.combine(day, time.min)
            //         stop_datetime_for_day = datetime.combine(day, time.max)
            //         day_interval = Intervals([(start_datetime, stop_datetime_for_day, self.env['resource.calendar'])])
            // 
            //         stop_datetime_for_week = datetime.combine(week_date, time.max)
            //         week_interval = Intervals([(start_datetime, stop_datetime_for_week, self.env['resource.calendar'])])
            // 
            //         attendance_interval = Intervals([(check_in, check_out, attendance)])
            //         attendance_by_employee_by_day[employee][day] |= attendance_interval & day_interval
            //         attendance_by_employee_by_week[employee][week_date] |= attendance_interval & week_interval
            // 
            // return {
            //     'day': attendance_by_employee_by_day,
            //     'week': attendance_by_employee_by_week
            // }
            */
            return default;
        }

        protected async Task<HrAttendance> GetDatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _get_dates(self):
            // result = {}
            // for attendance in self:
            //     localized_start, localized_end = attendance._get_localized_times()
            //     result[attendance] = list(rrule(DAILY, dtstart=localized_start, until=localized_end))
            // return result
            */
            return default;
        }

        protected async Task<HrAttendance> GetDayStartAndDayInternalAsync(object employee, object dt)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _get_day_start_and_day(self, employee, dt):  # TODO probably no longer need by the end
            // # Returns a tuple containing the datetime in naive UTC of the employee's start of the day
            // # and the date it was for that employee
            // if not dt.tzinfo:
            //     calendar_tz = employee._get_calendar_tz_batch(dt)[employee.id]
            //     date_employee_tz = pytz.utc.localize(dt).astimezone(pytz.timezone(calendar_tz))
            // else:
            //     date_employee_tz = dt
            // start_day_employee_tz = date_employee_tz.replace(hour=0, minute=0, second=0)
            // return (start_day_employee_tz.astimezone(pytz.utc).replace(tzinfo=None), start_day_employee_tz.date())
            */
            return default;
        }

        protected async Task<HrAttendance> GetEmployeeCalendarInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _get_employee_calendar(self):
            // self.ensure_one()
            // return self.employee_id.resource_calendar_id or self.employee_id.company_id.resource_calendar_id
            */
            return default;
        }

        public async Task<HrAttendance> GetKioskUrlAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def get_kiosk_url(self):
            // return self.get_base_url() + "/hr_attendance/" + self.env.company.attendance_kiosk_key
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrAttendance> GetLocalizedTimesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _get_localized_times(self):
            // self.ensure_one()
            // tz = timezone(self.employee_id.sudo()._get_version(self.check_in.date()).tz)
            // localized_start = utc.localize(self.check_in).astimezone(tz).replace(tzinfo=None)
            // localized_end = utc.localize(self.check_out).astimezone(tz).replace(tzinfo=None)
            // return localized_start, localized_end
            */
            return default;
        }

        protected async Task<HrAttendance> GetOvertimesToUpdateDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _get_overtimes_to_update_domain(self):
            // if not self:
            //     return Domain.FALSE
            // domain_list = [Domain.AND([
            //     Domain('employee_id', '=', employee.id),
            //     Domain('date', '<=', max(attendances.mapped('date')) + relativedelta(SU)),
            //     Domain('date', '>=', min(attendances.mapped('date')) + relativedelta(MO(-1))),
            // ]) for employee, attendances in self.grouped('employee_id').items()]
            // domain = Domain.OR(domain_list) if len(domain_list) > 1 else domain_list[0]
            // return domain
            */
            return default;
        }

        protected async Task<HrAttendance> GetWeekDateRangeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _get_week_date_range(self):
            // assert self
            // dates = self.mapped('date')
            // date_start, date_end = min(dates), max(dates)
            // date_start = date_start - relativedelta(days=date_start.weekday())
            // date_end = date_end + relativedelta(days=6 - date_end.weekday())
            // return date_start, date_end
            */
            return default;
        }

        public async Task<HrAttendance> HasDemoDataAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def has_demo_data(self):
            // if not self.env.user.has_group("hr_attendance.group_hr_attendance_user"):
            //     return True
            // # This record only exists if the scenario has been already launched
            // demo_tag = self.env.ref('hr_attendance.resource_calendar_std_38h', raise_if_not_found=False)
            // return bool(demo_tag) or bool(self.env['ir.module.module'].search_count([('demo', '=', True)]))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrAttendance> InAttendanceMapsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def action_in_attendance_maps(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': get_google_maps_url(self.in_latitude, self.in_longitude),
            //     'target': 'new'
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrAttendance> LinkedOvertimesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _linked_overtimes(self):
            // return self.env['hr.attendance.overtime.line'].search([
            //     ('time_start', 'in', self.mapped('check_in')),
            //     ('employee_id', 'in', self.employee_id.ids),
            // ])
            */
            return default;
        }

        protected async Task<HrAttendance> LoadDemoDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _load_demo_data(self):
            // if self.has_demo_data():
            //     return
            // env_sudo = self.sudo().with_context({}).env
            // env_sudo['hr.employee']._load_scenario()
            // # Load employees, schedules, departments and partners
            // convert.convert_file(env_sudo, 'hr_attendance', 'data/scenarios/hr_attendance_scenario.xml', None, mode='init')
            // 
            // employee_sj = self.env.ref('hr.employee_sj')
            // employee_mw = self.env.ref('hr.employee_mw')
            // employee_eg = self.env.ref('hr.employee_eg')
            // 
            // # Retrieve employee from xml file
            // # Calculate attendances records for the previous month and the current until today
            // now = datetime.now()
            // previous_month_datetime = (now - relativedelta(months=1))
            // date_range = now.day + monthrange(previous_month_datetime.year, previous_month_datetime.month)[1]
            // city_coordinates = (50.27, 5.31)
            // city_coordinates_exception = (51.01, 2.82)
            // city_dict = {
            //             'latitude': city_coordinates_exception[0],
            //             'longitude': city_coordinates_exception[1],
            //             'city': 'Rellemstraat'
            //         }
            // city_exception_dict = {
            //     'latitude': city_coordinates[0],
            //     'longitude': city_coordinates[1],
            //     'city': 'Waillet'
            // }
            // attendance_values = []
            // for i in range(1, date_range):
            //     check_in_date = now.replace(hour=6, minute=0, second=randint(0, 59)) + timedelta(days=-i, minutes=randint(-2, 3))
            //     if check_in_date.weekday() not in range(0, 5):
            //         continue
            //     check_out_date = now.replace(hour=10, minute=0, second=randint(0, 59)) + timedelta(days=-i, minutes=randint(-2, -1))
            //     check_in_date_after_lunch = now.replace(hour=11, minute=0, second=randint(0, 59)) + timedelta(days=-i, minutes=randint(-2, -1))
            //     check_out_date_after_lunch = now.replace(hour=15, minute=0, second=randint(0, 59)) + timedelta(days=-i, minutes=randint(1, 3))
            // 
            //     # employee_eg doesn't work on friday
            //     eg_data = []
            //     if check_in_date.weekday() != 4:
            //         # employee_eg will compensate her work's hours between weeks.
            //         if check_in_date.isocalendar().week % 2:
            //             employee_eg_hours = {
            //                 'check_in_date': check_in_date + timedelta(hours=1),
            //                 'check_out_date': check_out_date,
            //                 'check_in_date_after_lunch': check_in_date_after_lunch,
            //                 'check_out_date_after_lunch': check_out_date_after_lunch + timedelta(hours=-1),
            //             }
            //         else:
            //             employee_eg_hours = {
            //                 'check_in_date': check_in_date,
            //                 'check_out_date': check_out_date,
            //                 'check_in_date_after_lunch': check_in_date_after_lunch,
            //                 'check_out_date_after_lunch': check_out_date_after_lunch + timedelta(hours=1, minutes=30),
            //             }
            //         eg_data = [{
            //             'employee_id': employee_eg.id,
            //             'check_in': employee_eg_hours['check_in_date'],
            //             'check_out': employee_eg_hours['check_out_date'],
            //             'in_mode': "kiosk",
            //             'out_mode': "kiosk"
            //         }, {
            //             'employee_id': employee_eg.id,
            //             'check_in': employee_eg_hours['check_in_date_after_lunch'],
            //             'check_out': employee_eg_hours['check_out_date_after_lunch'],
            //             'in_mode': "kiosk",
            //             'out_mode': "kiosk",
            //         }]
            // 
            //     # calculate GPS coordination for employee_mw (systray attendance)
            //     if randint(1, 10) == 1:
            //         city_data = city_exception_dict
            //     else:
            //         city_data = city_dict
            //     mw_data = [{
            //         'employee_id': employee_mw.id,
            //         'check_in': check_in_date,
            //         'check_out': check_out_date,
            //         'in_mode': "systray",
            //         'out_mode': "systray",
            //         'in_longitude': city_data['longitude'],
            //         'out_longitude': city_data['longitude'],
            //         'in_latitude': city_data['latitude'],
            //         'out_latitude': city_data['latitude'],
            //         'in_location': city_data['city'],
            //         'out_location': city_data['city'],
            //         'in_ip_address': "127.0.0.1",
            //         'out_ip_address': "127.0.0.1",
            //         'in_browser': 'chrome',
            //         'out_browser': 'chrome'
            //     }, {
            //         'employee_id': employee_mw.id,
            //         'check_in': check_in_date_after_lunch,
            //         'check_out': check_out_date_after_lunch,
            //         'in_mode': "systray",
            //         'out_mode': "systray",
            //         'in_longitude': city_data['longitude'],
            //         'out_longitude': city_data['longitude'],
            //         'in_latitude': city_data['latitude'],
            //         'out_latitude': city_data['latitude'],
            //         'in_location': city_data['city'],
            //         'out_location': city_data['city'],
            //         'in_ip_address': "127.0.0.1",
            //         'out_ip_address': "127.0.0.1",
            //         'in_browser': 'chrome',
            //         'out_browser': 'chrome'
            //     }]
            //     sj_data = [{
            //         'employee_id': employee_sj.id,
            //         'check_in': check_in_date + timedelta(minutes=randint(-10, -5)),
            //         'check_out': check_out_date,
            //         'in_mode': "manual",
            //         'out_mode': "manual"
            //     }, {
            //         'employee_id': employee_sj.id,
            //         'check_in': check_in_date_after_lunch,
            //         'check_out': check_out_date_after_lunch + timedelta(hours=1, minutes=randint(-20, 10)),
            //         'in_mode': "manual",
            //         'out_mode': "manual"
            //     }]
            //     attendance_values.extend(eg_data + mw_data + sj_data)
            // self.env['hr.attendance'].create(attendance_values)
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'reload',
            // }
            */
            return default;
        }

        public async Task<HrAttendance> OutAttendanceMapsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def action_out_attendance_maps(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': get_google_maps_url(self.out_latitude, self.out_longitude),
            //     'target': 'new'
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrAttendance> ReadGroupEmployeeIdInternalAsync(object resources, object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _read_group_employee_id(self, resources, domain):
            // user_domain = Domain(self.env.context.get('user_domain') or Domain.TRUE)
            // employee_domain = Domain('company_id', 'in', self.env.context.get('allowed_company_ids', []))
            // if not self.env.user.has_group('hr_attendance.group_hr_attendance_user'):
            //     employee_domain &= Domain('attendance_manager_id', '=', self.env.user.id)
            // if user_domain.is_true():
            //     # Workaround to make it work only for list view.
            //     if 'gantt_start_date' in self.env.context:
            //         return self.env['hr.employee'].search(employee_domain)
            //     return resources & self.env['hr.employee'].search(employee_domain)
            // else:
            //     employee_name_domain = Domain.OR(
            //         Domain('name', condition.operator, condition.value)
            //         for condition in user_domain.iter_conditions()
            //         if condition.field_expr == 'employee_id'
            //     )
            //     return resources | self.env['hr.employee'].search(employee_name_domain & employee_domain)
            */
            return default;
        }

        public async Task<HrAttendance> RefuseOvertimeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def action_refuse_overtime(self):
            // self.linked_overtime_ids.action_refuse()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrAttendance> TryKioskAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def action_try_kiosk(self):
            // if not self.env.user.has_group("hr_attendance.group_hr_attendance_user"):
            //     return {
            //             'type': 'ir.actions.client',
            //             'tag': 'display_notification',
            //             'params': {
            //                 'message': _("You don't have the rights to execute that action."),
            //                 'type': 'info',
            //             }
            //     }
            // return {
            //     'type': 'ir.actions.act_url',
            //     'target': 'self',
            //     'url': self.env.company.attendance_kiosk_url + '?from_trial_mode=True'
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrAttendance> UpdateOvertimeInternalAsync(object attendance_domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py) ---
            // def _update_overtime(self, attendance_domain=None):
            // if not attendance_domain:
            //     attendance_domain = self._get_overtimes_to_update_domain()
            // self.env['hr.attendance.overtime.line'].search(attendance_domain).unlink()
            // all_attendances = (self | self.env['hr.attendance'].search(attendance_domain)).filtered_domain([('check_out', '!=', False)])
            // if not all_attendances:
            //     return
            // 
            // start_check_in = min(all_attendances.mapped('check_in')).date() - relativedelta(days=1)  # for timezone
            // min_check_in = utc.localize(datetime.combine(start_check_in, datetime.min.time()))
            // 
            // start_check_out = max(all_attendances.mapped('check_out')).date() + relativedelta(days=1)
            // max_check_out = utc.localize(datetime.combine(start_check_out, datetime.max.time()))  # for timezone
            // 
            // version_periods_by_employee = all_attendances.employee_id.sudo()._get_version_periods(min_check_in, max_check_out)
            // attendances_by_employee = all_attendances.grouped('employee_id')
            // attendances_by_ruleset = defaultdict(lambda: self.env['hr.attendance'])
            // for employee, emp_attendance in attendances_by_employee.items():
            //     for attendance in emp_attendance:
            //         attendance_intervals = Intervals([(
            //             utc.localize(attendance.check_in),
            //             utc.localize(attendance.check_out),
            //             self.env['hr.version'])])
            //         inter = Intervals(version_periods_by_employee[employee]) & attendance_intervals
            //         if not inter:
            //             continue
            //         version = inter._items[0][2]
            //         ruleset = version.ruleset_id
            //         if ruleset:
            //             attendances_by_ruleset[ruleset] += attendance
            // employees = all_attendances.employee_id
            // schedules_intervals_by_employee = employees._get_schedules_by_employee_by_work_type(min_check_in, max_check_out, version_periods_by_employee)
            // overtime_vals_list = []
            // for ruleset, ruleset_attendances in attendances_by_ruleset.items():
            //     attendances_dates = list(chain(*ruleset_attendances._get_dates().values()))
            //     overtime_vals_list.extend(
            //         ruleset.rule_ids._generate_overtime_vals_v2(min(attendances_dates), max(attendances_dates), ruleset_attendances, schedules_intervals_by_employee)
            //     )
            // self.env['hr.attendance.overtime.line'].create(overtime_vals_list)
            // self.env.add_to_compute(self._fields['overtime_hours'], all_attendances)
            */
            return default;
        }
    }
}