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
    [Module("Resource", Category = "Misc", Depends = new[] { "base", "web" })]
    public class ResourceCalendarAppService : GenericApplicationService<ResourceCalendar>, IResourceCalendarAppService
    {

        public ResourceCalendarAppService(IRepository<ResourceCalendar, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<ResourceCalendar> AttendanceIntervalsBatchInternalAsync(object start_dt, object end_dt, object resources, object domain, object tz, object lunch)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _attendance_intervals_batch(self, start_dt, end_dt, resources=None, domain=None, tz=None, lunch=False):
            // assert start_dt.tzinfo and end_dt.tzinfo
            // self.ensure_one()
            // if not resources:
            //     resources = self.env['resource.resource']
            //     resources_list = [resources]
            // else:
            //     resources_list = list(resources) + [self.env['resource.resource']]
            // resource_ids = [r.id for r in resources_list]
            // domain = domain if domain is not None else []
            // domain = expression.AND([domain, [
            //     ('calendar_id', '=', self.id),
            //     ('resource_id', 'in', resource_ids),
            //     ('display_type', '=', False),
            //     ('day_period', '!=' if not lunch else '=', 'lunch'),
            // ]])
            // 
            // attendances = self.env['resource.calendar.attendance'].search(domain)
            // # Since we only have one calendar to take in account
            // # Group resources per tz they will all have the same result
            // resources_per_tz = defaultdict(list)
            // for resource in resources_list:
            //     resources_per_tz[tz or timezone((resource or self).tz)].append(resource)
            // # Resource specific attendances
            // attendance_per_resource = defaultdict(lambda: self.env['resource.calendar.attendance'])
            // # Calendar attendances per day of the week
            // # * 7 days per week * 2 for two week calendars
            // attendances_per_day = [self.env['resource.calendar.attendance']] * 7 * 2
            // weekdays = set()
            // for attendance in attendances:
            //     if attendance.resource_id:
            //         attendance_per_resource[attendance.resource_id] |= attendance
            //     weekday = int(attendance.dayofweek)
            //     weekdays.add(weekday)
            //     if self.two_weeks_calendar:
            //         weektype = int(attendance.week_type)
            //         attendances_per_day[weekday + 7 * weektype] |= attendance
            //     else:
            //         attendances_per_day[weekday] |= attendance
            //         attendances_per_day[weekday + 7] |= attendance
            // 
            // start = start_dt.astimezone(utc)
            // end = end_dt.astimezone(utc)
            // bounds_per_tz = {
            //     tz: (start_dt.astimezone(tz), end_dt.astimezone(tz))
            //     for tz in resources_per_tz.keys()
            // }
            // # Use the outer bounds from the requested timezones
            // for tz, bounds in bounds_per_tz.items():
            //     start = min(start, bounds[0].replace(tzinfo=utc))
            //     end = max(end, bounds[1].replace(tzinfo=utc))
            // # Generate once with utc as timezone
            // days = rrule(DAILY, start.date(), until=end.date(), byweekday=weekdays)
            // ResourceCalendarAttendance = self.env['resource.calendar.attendance']
            // base_result = []
            // per_resource_result = defaultdict(list)
            // for day in days:
            //     week_type = ResourceCalendarAttendance.get_week_type(day)
            //     attendances = attendances_per_day[day.weekday() + 7 * week_type]
            //     for attendance in attendances:
            //         if (attendance.date_from and day.date() < attendance.date_from) or\
            //             (attendance.date_to and attendance.date_to < day.date()):
            //             continue
            //         day_from = datetime.combine(day, float_to_time(attendance.hour_from))
            //         day_to = datetime.combine(day, float_to_time(attendance.hour_to))
            //         if attendance.resource_id:
            //             per_resource_result[attendance.resource_id].append((day_from, day_to, attendance))
            //         else:
            //             base_result.append((day_from, day_to, attendance))
            // 
            // 
            // # Copy the result localized once per necessary timezone
            // # Strictly speaking comparing start_dt < time or start_dt.astimezone(tz) < time
            // # should always yield the same result. however while working with dates it is easier
            // # if all dates have the same format
            // result_per_tz = {
            //     tz: [(max(bounds_per_tz[tz][0], tz.localize(val[0])),
            //         min(bounds_per_tz[tz][1], tz.localize(val[1])),
            //         val[2])
            //             for val in base_result]
            //     for tz in resources_per_tz.keys()
            // }
            // result_per_resource_id = dict()
            // for tz, resources in resources_per_tz.items():
            //     res = result_per_tz[tz]
            //     res_intervals = WorkIntervals(res)
            //     start_datetime = start_dt.astimezone(tz)
            //     end_datetime = end_dt.astimezone(tz)
            // 
            //     for resource in resources:
            //         if resource and resource._is_fully_flexible():
            //             # If the resource is fully flexible, return the whole period from start_dt to end_dt with a dummy attendance
            //             hours = (end_dt - start_dt).total_seconds() / 3600
            //             days = hours / 24
            //             dummy_attendance = self.env['resource.calendar.attendance'].new({
            //                 'duration_hours': hours,
            //                 'duration_days': days,
            //             })
            //             result_per_resource_id[resource.id] = WorkIntervals([(start_dt, end_dt, dummy_attendance)])
            //         elif resource and resource.calendar_id.flexible_hours:
            //             # For flexible Calendars, we create intervals to fill in the weekly intervals with the average daily hours
            //             # until the full time required hours are met. This gives us the most correct approximation when looking at a daily
            //             # and weekly range for time offs and overtime calculations and work entry generation
            //             start_date = start_datetime.date()
            //             end_datetime_adjusted = end_datetime - relativedelta(seconds=1)
            //             end_date = end_datetime_adjusted.date()
            // 
            //             full_time_required_hours = resource.calendar_id.full_time_required_hours
            //             max_hours_per_day = resource.calendar_id.hours_per_day
            // 
            //             intervals = []
            //             current_monday = start_date - timedelta(days=start_date.weekday())
            // 
            //             while current_monday <= end_date:
            //                 current_sunday = current_monday + timedelta(days=6)
            // 
            //                 week_start = max(current_monday, start_date)
            //                 week_end = min(current_sunday, end_date)
            // 
            //                 if current_monday < start_date:
            //                     prior_days = (start_date - current_monday).days
            //                     prior_hours = min(full_time_required_hours, max_hours_per_day * prior_days)
            //                 else:
            //                     prior_hours = 0
            // 
            //                 remaining_hours = max(0, full_time_required_hours - prior_hours)
            // 
            //                 current_day = week_start
            //                 while current_day <= week_end:
            //                     if remaining_hours > 0:
            //                         allocate_hours = min(max_hours_per_day, remaining_hours)
            //                         remaining_hours -= allocate_hours
            // 
            //                         # Create interval centered at 12:00 PM
            //                         midpoint = tz.localize(datetime.combine(current_day, time(12, 0)))
            //                         start_time = midpoint - timedelta(hours=allocate_hours / 2)
            //                         end_time = midpoint + timedelta(hours=allocate_hours / 2)
            // 
            //                         dummy_attendance = self.env['resource.calendar.attendance'].new({
            //                             'duration_hours': allocate_hours,
            //                             'duration_days': 1,
            //                         })
            // 
            //                         intervals.append((start_time, end_time, dummy_attendance))
            // 
            //                     current_day += timedelta(days=1)
            // 
            //                 current_monday += timedelta(days=7)
            // 
            //             result_per_resource_id[resource.id] = WorkIntervals(intervals)
            //         elif resource in per_resource_result:
            //             resource_specific_result = [(max(bounds_per_tz[tz][0], tz.localize(val[0])), min(bounds_per_tz[tz][1], tz.localize(val[1])), val[2])
            //                 for val in per_resource_result[resource]]
            //             result_per_resource_id[resource.id] = WorkIntervals(itertools.chain(res, resource_specific_result))
            //         else:
            //             result_per_resource_id[resource.id] = res_intervals
            // return result_per_resource_id
            */
            return default;
        }

        protected async Task<ResourceCalendar> CalculateHoursPerWeekInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: resource_calendar.py) ---
            // def _calculate_hours_per_week(self):
            // self.ensure_one()
            // sum_hours = sum(
            //     (a.hour_to - a.hour_from) for a in self.attendance_ids.filtered(lambda a: a.day_period != 'lunch'))
            // return sum_hours / 2 if self.two_weeks_calendar else sum_hours
            */
            return default;
        }

        protected async Task<ResourceCalendar> CalculateIsFulltimeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: resource_calendar.py) ---
            // def _calculate_is_fulltime(self):
            // self.ensure_one()
            // return not float_compare(self.full_time_required_hours, self._calculate_hours_per_week(), 3)
            */
            return default;
        }

        protected async Task<ResourceCalendar> CheckAttendanceIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _check_attendance_ids(self):
            // for resource in self:
            //     if (resource.two_weeks_calendar and
            //             resource.attendance_ids.filtered(lambda a: a.display_type == 'line_section') and
            //             not resource.attendance_ids.sorted('sequence')[0].display_type):
            //         raise ValidationError(_("In a calendar with 2 weeks mode, all periods need to be in the sections."))
            */
            return default;
        }

        protected async Task<ResourceCalendar> CheckAttendanceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _check_attendance(self):
            // # Avoid superimpose in attendance
            // for calendar in self:
            //     attendance_ids = calendar.attendance_ids.filtered(lambda attendance: not attendance.resource_id and attendance.display_type is False)
            //     if calendar.two_weeks_calendar:
            //         calendar._check_overlap(attendance_ids.filtered(lambda attendance: attendance.week_type == '0'))
            //         calendar._check_overlap(attendance_ids.filtered(lambda attendance: attendance.week_type == '1'))
            //     else:
            //         calendar._check_overlap(attendance_ids)
            */
            return default;
        }

        protected async Task<ResourceCalendar> CheckOverlapInternalAsync(List<Guid> attendance_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _check_overlap(self, attendance_ids):
            // """ attendance_ids correspond to attendance of a week,
            //     will check for each day of week that there are no superimpose. """
            // result = []
            // for attendance in attendance_ids.filtered(lambda att: not att.date_from and not att.date_to):
            //     # 0.000001 is added to each start hour to avoid to detect two contiguous intervals as superimposing.
            //     # Indeed Intervals function will join 2 intervals with the start and stop hour corresponding.
            //     result.append((int(attendance.dayofweek) * 24 + attendance.hour_from + 0.000001, int(attendance.dayofweek) * 24 + attendance.hour_to, attendance))
            // 
            // if len(Intervals(result)) != len(result):
            //     raise ValidationError(_("Attendances can't overlap."))
            */
            return default;
        }

        protected async Task<ResourceCalendar> ComputeAssociatedLeavesCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_holidays, FILE: resource.py) ---
            // def _compute_associated_leaves_count(self):
            // leaves_read_group = self.env['resource.calendar.leaves']._read_group(
            //     [('resource_id', '=', False), ('calendar_id', 'in', [False, *self.ids])],
            //     ['calendar_id'],
            //     ['__count'],
            // )
            // result = {calendar.id if calendar else 'global': count for calendar, count in leaves_read_group}
            // global_leave_count = result.get('global', 0)
            // for calendar in self:
            //     calendar.associated_leaves_count = result.get(calendar.id, 0) + global_leave_count
            */
            return default;
        }

        protected async Task<ResourceCalendar> ComputeAttendanceIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _compute_attendance_ids(self):
            // for calendar in self.filtered(lambda c: not c._origin or c._origin.company_id != c.company_id and c.company_id):
            //     company_calendar = calendar.company_id.resource_calendar_id
            //     calendar.update({
            //         'two_weeks_calendar': company_calendar.two_weeks_calendar,
            //         'tz': company_calendar.tz,
            //         'attendance_ids': [(5, 0, 0)] + [
            //             (0, 0, attendance._copy_attendance_vals()) for attendance in company_calendar.attendance_ids if not attendance.resource_id]
            //     })
            */
            return default;
        }

        protected async Task<ResourceCalendar> ComputeContractsCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: resource.py) ---
            // def _compute_contracts_count(self):
            // count_data = self.env['hr.contract']._read_group(
            //     [('resource_calendar_id', 'in', self.ids), ('employee_id', '!=', False)],
            //     ['resource_calendar_id'],
            //     ['__count'])
            // mapped_counts = {resource_calendar.id: count for resource_calendar, count in count_data}
            // for calendar in self:
            //     calendar.contracts_count = mapped_counts.get(calendar.id, 0)
            */
            return default;
        }

        protected async Task<ResourceCalendar> ComputeGlobalLeaveIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _compute_global_leave_ids(self):
            // for calendar in self.filtered(lambda c: not c._origin or c._origin.company_id != c.company_id):
            //     calendar.update({
            //         'global_leave_ids': [(5, 0, 0)] + [
            //             (0, 0, leave._copy_leave_vals()) for leave in calendar.company_id.resource_calendar_id.global_leave_ids]
            //     })
            */
            return default;
        }

        protected async Task<ResourceCalendar> ComputeHoursPerDayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _compute_hours_per_day(self):
            // for calendar in self:
            //     if calendar.flexible_hours:
            //         continue
            //     attendances = calendar._get_global_attendances()
            //     calendar.hours_per_day = calendar._get_hours_per_day(attendances)
            */
            return default;
        }

        protected async Task<ResourceCalendar> ComputeTwoWeeksExplanationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _compute_two_weeks_explanation(self):
            // today = fields.Date.today()
            // week_type = self.env['resource.calendar.attendance'].get_week_type(today)
            // week_type_str = _("second") if week_type else _("first")
            // first_day = date_utils.start_of(today, 'week')
            // last_day = date_utils.end_of(today, 'week')
            // self.two_weeks_explanation = _(
            //     "The current week (from %(first_day)s to %(last_day)s) corresponds to week number %(number)s.",
            //     first_day=first_day,
            //     last_day=last_day,
            //     number=week_type_str,
            // )
            */
            return default;
        }

        protected async Task<ResourceCalendar> ComputeTzOffsetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _compute_tz_offset(self):
            // for calendar in self:
            //     calendar.tz_offset = datetime.now(timezone(calendar.tz or 'GMT')).strftime('%z')
            */
            return default;
        }

        public async Task<ResourceCalendar> CopyDataAsync(Guid id, ResourceCalendarCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", calendar.name)) for calendar, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResourceCalendar> GetAttendanceIntervalsDaysDataInternalAsync(object attendance_intervals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _get_attendance_intervals_days_data(self, attendance_intervals):
            // """
            // helper function to compute duration of `intervals` that have
            // 'resource.calendar.attendance' records as payload (3rd element in tuple).
            // expressed in days and hours.
            // 
            // resource.calendar.attendance records have durations associated
            // with them so this method merely calculates the proportion that is
            // covered by the intervals.
            // """
            // day_hours = defaultdict(float)
            // day_days = defaultdict(float)
            // for start, stop, meta in attendance_intervals:
            //     # If the interval covers only a part of the original attendance, we
            //     # take durations in days proportionally to what is left of the interval.
            //     interval_hours = (stop - start).total_seconds() / 3600
            //     if len(self) == 1 and self.flexible_hours:
            //         day_hours[start.date()] += meta.duration_hours
            //         day_days[start.date()] += meta.duration_days
            //     else:
            //         day_hours[start.date()] += interval_hours
            //         day_days[start.date()] += sum(meta.mapped('duration_days')) * interval_hours / sum(meta.mapped('duration_hours'))
            // 
            // return {
            //     # Round the number of days to the closest 16th of a day.
            //     'days': float_round(sum(day_days[day] for day in day_days), precision_rounding=0.001),
            //     'hours': sum(day_hours.values()),
            // }
            */
            return default;
        }

        protected async Task<ResourceCalendar> GetClosestWorkTimeInternalAsync(object dt, object match_end, object resource, object search_range, object compute_leaves)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _get_closest_work_time(self, dt, match_end=False, resource=None, search_range=None, compute_leaves=True):
            // """Return the closest work interval boundary within the search range.
            // Consider only starts of intervals unless `match_end` is True. It will then only consider
            // ends of intervals.
            // :param dt: reference datetime
            // :param match_end: wether to search for the begining of an interval or the end.
            // :param search_range: time interval considered. Defaults to the entire day of `dt`
            // :rtype: datetime | None
            // """
            // def interval_dt(interval):
            //     return interval[1 if match_end else 0]
            // 
            // tz = resource.tz if resource else self.tz
            // if resource is None:
            //     resource = self.env['resource.resource']
            // 
            // if not dt.tzinfo or search_range and not (search_range[0].tzinfo and search_range[1].tzinfo):
            //     raise ValueError('Provided datetimes needs to be timezoned')
            // 
            // dt = dt.astimezone(timezone(tz))
            // 
            // if not search_range:
            //     range_start = dt + relativedelta(hour=0, minute=0, second=0)
            //     range_end = dt + relativedelta(days=1, hour=0, minute=0, second=0)
            // else:
            //     range_start, range_end = search_range
            // 
            // if not range_start <= dt <= range_end:
            //     return None
            // work_intervals = sorted(
            //     self._work_intervals_batch(range_start, range_end, resource, compute_leaves=compute_leaves)[resource.id],
            //     key=lambda i: abs(interval_dt(i) - dt),
            // )
            // return interval_dt(work_intervals[0]) if work_intervals else None
            */
            return default;
        }

        protected async Task<ResourceCalendar> GetDaysDataInternalAsync(object intervals, object day_total)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _get_days_data(self, intervals, day_total):
            // """
            // helper function to compute duration of `intervals`
            // expressed in days and hours.
            // `day_total` is a dict {date: n_hours} with the number of hours for each day.
            // """
            // day_hours = defaultdict(float)
            // for start, stop, meta in intervals:
            //     day_hours[start.date()] += (stop - start).total_seconds() / 3600
            // 
            // # compute number of days the hours span over
            // days = float_round(sum(
            //     day_hours[day] / day_total[day] if day_total[day] else 0
            //     for day in day_hours
            // ), precision_rounding=0.001)
            // return {
            //     'days': days,
            //     'hours': sum(day_hours.values()),
            // }
            */
            return default;
        }

        protected async Task<ResourceCalendar> GetGlobalAttendancesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry_contract, FILE: resource_calendar.py) ---
            // def _get_global_attendances(self):
            // return super()._get_global_attendances().filtered(lambda a: not a.work_entry_type_id.is_leave)
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _get_global_attendances(self):
            // return self.attendance_ids.filtered(lambda attendance:
            //     attendance.day_period != 'lunch'
            //     and not attendance.date_from and not attendance.date_to
            //     and not attendance.resource_id and not attendance.display_type)
            */
            return default;
        }

        protected async Task<ResourceCalendar> GetHoursPerDayInternalAsync(object attendances)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _get_hours_per_day(self, attendances):
            // """
            // Calculate the average hours worked per workday.
            // """
            // if not attendances:
            //     return 0
            // 
            // hour_count = 0.0
            // for attendance in attendances:
            //     hour_count += attendance.hour_to - attendance.hour_from
            // 
            // if self.two_weeks_calendar:
            //     number_of_days = len(set(attendances.filtered(lambda cal: cal.week_type == '1').mapped('dayofweek')))
            //     number_of_days += len(set(attendances.filtered(lambda cal: cal.week_type == '0').mapped('dayofweek')))
            // else:
            //     number_of_days = len(set(attendances.mapped('dayofweek')))
            // 
            // if not number_of_days:
            //     return 0
            // 
            // return float_round(hour_count / float(number_of_days), precision_digits=2)
            */
            return default;
        }

        protected async Task<ResourceCalendar> GetMaxNumberOfHoursInternalAsync(object start, object end)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _get_max_number_of_hours(self, start, end):
            // self.ensure_one()
            // if not self.attendance_ids:
            //     return 0
            // mapped_data = defaultdict(lambda: 0)
            // for attendance in self.attendance_ids.filtered(lambda a: a.day_period != 'lunch' and ((not a.date_from or not a.date_to) or (a.date_from <= end.date() and a.date_to >= start.date()))):
            //     mapped_data[(attendance.week_type, attendance.dayofweek)] += attendance.hour_to - attendance.hour_from
            // return max(mapped_data.values())
            */
            return default;
        }

        protected async Task<ResourceCalendar> GetResourcesDayTotalInternalAsync(object from_datetime, object to_datetime, object resources)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _get_resources_day_total(self, from_datetime, to_datetime, resources=None):
            // """
            // @return dict with hours of attendance in each day between `from_datetime` and `to_datetime`
            // """
            // self.ensure_one()
            // if not resources:
            //     resources = self.env['resource.resource']
            //     resources_list = [resources]
            // else:
            //     resources_list = list(resources) + [self.env['resource.resource']]
            // # total hours per day:  retrieve attendances with one extra day margin,
            // # in order to compute the total hours on the first and last days
            // from_full = from_datetime - timedelta(days=1)
            // to_full = to_datetime + timedelta(days=1)
            // intervals = self._attendance_intervals_batch(from_full, to_full, resources=resources)
            // 
            // result = defaultdict(lambda: defaultdict(float))
            // for resource in resources_list:
            //     day_total = result[resource.id]
            //     for start, stop, meta in intervals[resource.id]:
            //         day_total[start.date()] += (stop - start).total_seconds() / 3600
            // return result
            */
            return default;
        }

        protected async Task<ResourceCalendar> GetUnusualDaysInternalAsync(object start_dt, object end_dt, Guid company_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _get_unusual_days(self, start_dt, end_dt, company_id=False):
            // if not self:
            //     return {}
            // self.ensure_one()
            // if not start_dt.tzinfo:
            //     start_dt = start_dt.replace(tzinfo=utc)
            // if not end_dt.tzinfo:
            //     end_dt = end_dt.replace(tzinfo=utc)
            // 
            // domain = []
            // if company_id:
            //     domain = [('company_id', 'in', (company_id.id, False))]
            // if self.flexible_hours:
            //     works = {d[0].date() for d in self._leave_intervals_batch(start_dt, end_dt, domain=domain)[False]}
            //     return {fields.Date.to_string(day.date()): (day.date() in works) for day in rrule(DAILY, start_dt, until=end_dt)}
            // works = {d[0].date() for d in self._work_intervals_batch(start_dt, end_dt, domain=domain)[False]}
            // return {fields.Date.to_string(day.date()): (day.date() not in works) for day in rrule(DAILY, start_dt, until=end_dt)}
            */
            return default;
        }

        public async Task<ResourceCalendar> GetWorkDurationDataAsync(Guid id, ResourceCalendarGetWorkDurationDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def get_work_duration_data(self, from_datetime, to_datetime, compute_leaves=True, domain=None):
            // """
            //     Get the working duration (in days and hours) for a given period, only
            //     based on the current calendar. This method does not use resource to
            //     compute it.
            // 
            //     `domain` is used in order to recognise the leaves to take,
            //     None means default value ('time_type', '=', 'leave')
            // 
            //     Returns a dict {'days': n, 'hours': h} containing the
            //     quantity of working time expressed as days and as hours.
            // """
            // # naive datetimes are made explicit in UTC
            // from_datetime, dummy = make_aware(from_datetime)
            // to_datetime, dummy = make_aware(to_datetime)
            // 
            // # actual hours per day
            // if compute_leaves:
            //     intervals = self._work_intervals_batch(from_datetime, to_datetime, domain=domain)[False]
            // else:
            //     intervals = self._attendance_intervals_batch(from_datetime, to_datetime, domain=domain)[False]
            // 
            // return self._get_attendance_intervals_days_data(intervals)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResourceCalendar> GetWorkHoursCountAsync(Guid id, ResourceCalendarGetWorkHoursCountRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def get_work_hours_count(self, start_dt, end_dt, compute_leaves=True, domain=None):
            // """
            //     `compute_leaves` controls whether or not this method is taking into
            //     account the global leaves.
            // 
            //     `domain` controls the way leaves are recognized.
            //     None means default value ('time_type', '=', 'leave')
            // 
            //     Counts the number of work hours between two datetimes.
            // """
            // self.ensure_one()
            // # Set timezone in UTC if no timezone is explicitly given
            // if not start_dt.tzinfo:
            //     start_dt = start_dt.replace(tzinfo=utc)
            // if not end_dt.tzinfo:
            //     end_dt = end_dt.replace(tzinfo=utc)
            // 
            // if compute_leaves:
            //     intervals = self._work_intervals_batch(start_dt, end_dt, domain=domain)[False]
            // else:
            //     intervals = self._attendance_intervals_batch(start_dt, end_dt)[False]
            // 
            // return sum(
            //     (stop - start).total_seconds() / 3600
            //     for start, stop, meta in intervals
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResourceCalendar> GetWorkingHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _get_working_hours(self):
            // self.ensure_one()
            // 
            // working_days = defaultdict(lambda: defaultdict(lambda: False))
            // for attendance in self.attendance_ids:
            //     working_days[attendance.week_type][attendance.dayofweek] = True
            // return working_days
            */
            return default;
        }

        protected async Task<ResourceCalendar> HandleFlexibleLeaveIntervalInternalAsync(object dt0, object dt1, object leave)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _handle_flexible_leave_interval(self, dt0, dt1, leave):
            // """Hook method to handle flexible leave intervals. Can be overridden in other modules."""
            // tz = dt0.tzinfo  # Get the timezone information from dt0
            // dt0 = datetime.combine(dt0.date(), time.min).replace(tzinfo=tz)
            // dt1 = datetime.combine(dt1.date(), time.max).replace(tzinfo=tz)
            // return dt0, dt1
            */
            return default;
        }

        protected async Task<ResourceCalendar> LeaveIntervalsBatchInternalAsync(object start_dt, object end_dt, object resources, object domain, object tz, object any_calendar)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _leave_intervals_batch(self, start_dt, end_dt, resources=None, domain=None, tz=None, any_calendar=False):
            // """ Return the leave intervals in the given datetime range.
            //     The returned intervals are expressed in specified tz or in the calendar's timezone.
            // """
            // assert start_dt.tzinfo and end_dt.tzinfo
            // self.ensure_one()
            // 
            // if not resources:
            //     resources = self.env['resource.resource']
            //     resources_list = [resources]
            // else:
            //     resources_list = list(resources) + [self.env['resource.resource']]
            // if domain is None:
            //     domain = [('time_type', '=', 'leave')]
            // if not any_calendar:
            //     domain = domain + [('calendar_id', 'in', [False, self.id])]
            // # for the computation, express all datetimes in UTC
            // # Public leave don't have a resource_id
            // domain = domain + [
            //     ('resource_id', 'in', [False] + [r.id for r in resources_list]),
            //     ('date_from', '<=', datetime_to_string(end_dt)),
            //     ('date_to', '>=', datetime_to_string(start_dt)),
            // ]
            // 
            // # retrieve leave intervals in (start_dt, end_dt)
            // result = defaultdict(lambda: [])
            // tz_dates = {}
            // all_leaves = self.env['resource.calendar.leaves'].search(domain)
            // for leave in all_leaves:
            //     leave_resource = leave.resource_id
            //     leave_company = leave.company_id
            //     leave_date_from = leave.date_from
            //     leave_date_to = leave.date_to
            //     for resource in resources_list:
            //         if leave_resource.id not in [False, resource.id] or (not leave_resource and resource and resource.company_id != leave_company):
            //             continue
            //         tz = tz if tz else timezone((resource or self).tz)
            //         if (tz, start_dt) in tz_dates:
            //             start = tz_dates[(tz, start_dt)]
            //         else:
            //             start = start_dt.astimezone(tz)
            //             tz_dates[(tz, start_dt)] = start
            //         if (tz, end_dt) in tz_dates:
            //             end = tz_dates[(tz, end_dt)]
            //         else:
            //             end = end_dt.astimezone(tz)
            //             tz_dates[(tz, end_dt)] = end
            //         dt0 = string_to_datetime(leave_date_from).astimezone(tz)
            //         dt1 = string_to_datetime(leave_date_to).astimezone(tz)
            //         if leave_resource and leave_resource._is_fully_flexible():
            //             dt0, dt1 = self._handle_flexible_leave_interval(dt0, dt1, leave)
            //         result[resource.id].append((max(start, dt0), min(end, dt1), leave))
            // 
            // return {r.id: Intervals(result[r.id]) for r in resources_list}
            */
            return default;
        }

        protected async Task<ResourceCalendar> LeaveIntervalsInternalAsync(object start_dt, object end_dt, object resource, object domain, object tz)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _leave_intervals(self, start_dt, end_dt, resource=None, domain=None, tz=None):
            // if resource is None:
            //     resource = self.env['resource.resource']
            // return self._leave_intervals_batch(
            //     start_dt, end_dt, resources=resource, domain=domain, tz=tz
            // )[resource.id]
            */
            return default;
        }

        protected async Task<ResourceCalendar> OnchangeAttendanceIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _onchange_attendance_ids(self):
            // if not self.two_weeks_calendar:
            //     return
            // 
            // even_week_seq = self.attendance_ids.filtered(lambda att: att.display_type == 'line_section' and att.week_type == '0')
            // odd_week_seq = self.attendance_ids.filtered(lambda att: att.display_type == 'line_section' and att.week_type == '1')
            // if len(even_week_seq) != 1 or len(odd_week_seq) != 1:
            //     raise ValidationError(_("You can't delete section between weeks."))
            // 
            // even_week_seq = even_week_seq.sequence
            // odd_week_seq = odd_week_seq.sequence
            // 
            // for line in self.attendance_ids.filtered(lambda att: att.display_type is False):
            //     if even_week_seq > odd_week_seq:
            //         line.week_type = '1' if even_week_seq > line.sequence else '0'
            //     else:
            //         line.week_type = '0' if odd_week_seq > line.sequence else '1'
            */
            return default;
        }

        public async Task<ResourceCalendar> OpenContractsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: resource.py) ---
            // def action_open_contracts(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("hr_contract.action_hr_contract")
            // action.update({'domain': [('resource_calendar_id', '=', self.id), ('employee_id', '!=', False)]})
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResourceCalendar> PlanDaysAsync(Guid id, ResourceCalendarPlanDaysRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def plan_days(self, days, day_dt, compute_leaves=False, domain=None):
            // """
            // `compute_leaves` controls whether or not this method is taking into
            // account the global leaves.
            // 
            // `domain` controls the way leaves are recognized.
            // None means default value ('time_type', '=', 'leave')
            // 
            // Returns the datetime of a days scheduling.
            // """
            // day_dt, revert = make_aware(day_dt)
            // 
            // # which method to use for retrieving intervals
            // if compute_leaves:
            //     get_intervals = partial(self._work_intervals_batch, domain=domain)
            // else:
            //     get_intervals = self._attendance_intervals_batch
            // 
            // if days > 0:
            //     found = set()
            //     delta = timedelta(days=14)
            //     for n in range(100):
            //         dt = day_dt + delta * n
            //         for start, stop, meta in get_intervals(dt, dt + delta)[False]:
            //             found.add(start.date())
            //             if len(found) == days:
            //                 return revert(stop)
            //     return False
            // 
            // elif days < 0:
            //     days = abs(days)
            //     found = set()
            //     delta = timedelta(days=14)
            //     for n in range(100):
            //         dt = day_dt - delta * n
            //         for start, stop, meta in reversed(get_intervals(dt - delta, dt)[False]):
            //             found.add(start.date())
            //             if len(found) == days:
            //                 return revert(start)
            //     return False
            // 
            // else:
            //     return revert(day_dt)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResourceCalendar> PlanHoursAsync(Guid id, ResourceCalendarPlanHoursRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def plan_hours(self, hours, day_dt, compute_leaves=False, domain=None, resource=None):
            // """
            // `compute_leaves` controls whether or not this method is taking into
            // account the global leaves.
            // 
            // `domain` controls the way leaves are recognized.
            // None means default value ('time_type', '=', 'leave')
            // 
            // Return datetime after having planned hours
            // """
            // day_dt, revert = make_aware(day_dt)
            // 
            // if resource is None:
            //     resource = self.env['resource.resource']
            // 
            // # which method to use for retrieving intervals
            // if compute_leaves:
            //     get_intervals = partial(self._work_intervals_batch, domain=domain, resources=resource)
            //     resource_id = resource.id
            // else:
            //     get_intervals = self._attendance_intervals_batch
            //     resource_id = False
            // 
            // if hours >= 0:
            //     delta = timedelta(days=14)
            //     for n in range(100):
            //         dt = day_dt + delta * n
            //         for start, stop, meta in get_intervals(dt, dt + delta)[resource_id]:
            //             interval_hours = (stop - start).total_seconds() / 3600
            //             if hours <= interval_hours:
            //                 return revert(start + timedelta(hours=hours))
            //             hours -= interval_hours
            //     return False
            // else:
            //     hours = abs(hours)
            //     delta = timedelta(days=14)
            //     for n in range(100):
            //         dt = day_dt - delta * n
            //         for start, stop, meta in reversed(get_intervals(dt - delta, dt)[resource_id]):
            //             interval_hours = (stop - start).total_seconds() / 3600
            //             if hours <= interval_hours:
            //                 return revert(stop - timedelta(hours=hours))
            //             hours -= interval_hours
            //     return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResourceCalendar> SwitchCalendarTypeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def switch_calendar_type(self):
            // if not self.two_weeks_calendar:
            //     self.attendance_ids.unlink()
            //     self.attendance_ids = [
            //         (0, 0, {
            //             'name': 'First week',
            //             'dayofweek': '0',
            //             'sequence': '0',
            //             'hour_from': 0,
            //             'day_period': 'morning',
            //             'week_type': '0',
            //             'hour_to': 0,
            //             'display_type':
            //             'line_section'}),
            //         (0, 0, {
            //             'name': 'Second week',
            //             'dayofweek': '0',
            //             'sequence': '25',
            //             'hour_from': 0,
            //             'day_period': 'morning',
            //             'week_type': '1',
            //             'hour_to': 0,
            //             'display_type': 'line_section'}),
            //     ]
            // 
            //     self.two_weeks_calendar = True
            //     default_attendance = self.default_get(['attendance_ids'])['attendance_ids']
            //     for idx, att in enumerate(default_attendance):
            //         att[2]["week_type"] = '0'
            //         att[2]["sequence"] = idx + 1
            //     self.attendance_ids = default_attendance
            //     for idx, att in enumerate(default_attendance):
            //         att[2]["week_type"] = '1'
            //         att[2]["sequence"] = idx + 26
            //     self.attendance_ids = default_attendance
            // else:
            //     self.two_weeks_calendar = False
            //     self.attendance_ids.unlink()
            //     self.attendance_ids = self.default_get(['attendance_ids'])['attendance_ids']
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResourceCalendar> TransferLeavesToAsync(Guid id, ResourceCalendarTransferLeavesToRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: resource.py) ---
            // def transfer_leaves_to(self, other_calendar, resources=None, from_date=None):
            // """
            //     Transfer some resource.calendar.leaves from 'self' to another calendar 'other_calendar'.
            //     Transfered leaves linked to `resources` (or all if `resources` is None) and starting
            //     after 'from_date' (or today if None).
            // """
            // from_date = from_date or fields.Datetime.now().replace(hour=0, minute=0, second=0, microsecond=0)
            // domain = [
            //     ('calendar_id', 'in', self.ids),
            //     ('date_from', '>=', from_date),
            // ]
            // domain = AND([domain, [('resource_id', 'in', resources.ids)]]) if resources else domain
            // 
            // self.env['resource.calendar.leaves'].search(domain).write({
            //     'calendar_id': other_calendar.id,
            // })
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResourceCalendar> UnavailableIntervalsBatchInternalAsync(object start_dt, object end_dt, object resources, object domain, object tz)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _unavailable_intervals_batch(self, start_dt, end_dt, resources=None, domain=None, tz=None):
            // """ Return the unavailable intervals between the given datetimes. """
            // if not resources:
            //     resources = self.env['resource.resource']
            //     resources_list = [resources]
            // else:
            //     resources_list = list(resources)
            // 
            // resources_work_intervals = self._work_intervals_batch(start_dt, end_dt, resources, domain, tz)
            // result = {}
            // for resource in resources_list:
            //     if resource and resource._is_fully_flexible():
            //         continue
            //     work_intervals = [(start, stop) for start, stop, meta in resources_work_intervals[resource.id]]
            //     # start + flatten(intervals) + end
            //     work_intervals = [start_dt] + list(chain.from_iterable(work_intervals)) + [end_dt]
            //     # put it back to UTC
            //     work_intervals = list(map(lambda dt: dt.astimezone(utc), work_intervals))
            //     # pick groups of two
            //     work_intervals = list(zip(work_intervals[0::2], work_intervals[1::2]))
            //     result[resource.id] = work_intervals
            // return result
            */
            return default;
        }

        protected async Task<ResourceCalendar> UnavailableIntervalsInternalAsync(object start_dt, object end_dt, object resource, object domain, object tz)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _unavailable_intervals(self, start_dt, end_dt, resource=None, domain=None, tz=None):
            // if resource is None:
            //     resource = self.env['resource.resource']
            // return self._unavailable_intervals_batch(
            //     start_dt, end_dt, resources=resource, domain=domain, tz=tz
            // )[resource.id]
            */
            return default;
        }

        protected async Task<ResourceCalendar> WorkIntervalsBatchInternalAsync(object start_dt, object end_dt, object resources, object domain, object tz, object compute_leaves)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _work_intervals_batch(self, start_dt, end_dt, resources=None, domain=None, tz=None, compute_leaves=True):
            // """ Return the effective work intervals between the given datetimes. """
            // if not resources:
            //     resources = self.env['resource.resource']
            //     resources_list = [resources]
            // else:
            //     resources_list = list(resources) + [self.env['resource.resource']]
            // 
            // attendance_intervals = self._attendance_intervals_batch(start_dt, end_dt, resources, tz=tz or self.env.context.get("employee_timezone"))
            // if compute_leaves:
            //     leave_intervals = self._leave_intervals_batch(start_dt, end_dt, resources, domain, tz=tz)
            //     return {
            //         r.id: (attendance_intervals[r.id] - leave_intervals[r.id]) for r in resources_list
            //     }
            // else:
            //     return {
            //         r.id: attendance_intervals[r.id] for r in resources_list
            //     }
            */
            return default;
        }

        protected async Task<ResourceCalendar> WorksOnDateInternalAsync(object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar.py) ---
            // def _works_on_date(self, date):
            // self.ensure_one()
            // 
            // working_days = self._get_working_hours()
            // dayofweek = str(date.weekday())
            // if self.two_weeks_calendar:
            //     weektype = str(self.env['resource.calendar.attendance'].get_week_type(date))
            //     return working_days[weektype][dayofweek]
            // return working_days[False][dayofweek]
            */
            return default;
        }
    }
}