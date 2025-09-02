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
    public class ResourceResourceAppService : GenericApplicationService<ResourceResource>, IResourceResourceAppService
    {

        public ResourceResourceAppService(IRepository<ResourceResource, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<ResourceResource> AdjustToCalendarInternalAsync(object start, object end, object compute_leaves)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_resource.py) ---
            // def _adjust_to_calendar(self, start, end, compute_leaves=True):
            // """Adjust the given start and end datetimes to the closest effective hours encoded
            // in the resource calendar. Only attendances in the same day as `start` and `end` are
            // considered (respectively). If no attendance is found during that day, the closest hour
            // is None.
            // e.g. simplified example:
            //      given two attendances: 8am-1pm and 2pm-5pm, given start=9am and end=6pm
            //      resource._adjust_to_calendar(start, end)
            //      >>> {resource: (8am, 5pm)}
            // :return: Closest matching start and end of working periods for each resource
            // :rtype: dict(resource, tuple(datetime | None, datetime | None))
            // """
            // start, revert_start_tz = make_aware(start)
            // end, revert_end_tz = make_aware(end)
            // result = {}
            // for resource in self:
            //     resource_tz = timezone(resource.tz)
            //     start, end = start.astimezone(resource_tz), end.astimezone(resource_tz)
            //     search_range = [
            //         start + relativedelta(hour=0, minute=0, second=0),
            //         end + relativedelta(days=1, hour=0, minute=0, second=0),
            //     ]
            //     calendar = resource.calendar_id or resource.company_id.resource_calendar_id or self.env.company.resource_calendar_id
            //     calendar_start = calendar._get_closest_work_time(start, resource=resource, search_range=search_range,
            //                                                                  compute_leaves=compute_leaves)
            //     search_range[0] = start
            //     calendar_end = calendar._get_closest_work_time(max(start, end), match_end=True,
            //                                                                resource=resource, search_range=search_range,
            //                                                                compute_leaves=compute_leaves)
            //     result[resource] = (
            //         calendar_start and revert_start_tz(calendar_start),
            //         calendar_end and revert_end_tz(calendar_end),
            //     )
            // return result
            */
            return default;
        }

        protected async Task<ResourceResource> ComputeAvatar128InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: resource.py) ---
            // def _compute_avatar_128(self):
            // is_hr_user = self.env.user.has_group('hr.group_hr_user')
            // if not is_hr_user:
            //     public_employees = self.env['hr.employee.public'].with_context(active_test=False).search([
            //         ('resource_id', 'in', self.ids),
            //     ])
            //     avatar_per_employee_id = {emp.id: emp.avatar_128 for emp in public_employees}
            // 
            // for resource in self:
            //     employee = resource.employee_id
            //     if not employee:
            //         resource.avatar_128 = False
            //         continue
            //     if is_hr_user:
            //         resource.avatar_128 = employee[0].avatar_128
            //     else:
            //         resource.avatar_128 = avatar_per_employee_id[employee[0].id] if employee else False
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_resource.py) ---
            // def _compute_avatar_128(self):
            // for resource in self:
            //     resource.avatar_128 = resource.user_id.avatar_128
            */
            return default;
        }

        public async Task<ResourceResource> CopyDataAsync(Guid id, ResourceResourceCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_resource.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", resource.name)) for resource, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResourceResource> GetAvatarCardDataAsync(Guid id, ResourceResourceGetAvatarCardDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource_mail, FILE: resource_resource.py) ---
            // def get_avatar_card_data(self, fields):
            // return self._read_format(fields)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResourceResource> GetCalendarsValidityWithinPeriodInternalAsync(object start, object end, object default_company)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_contract, FILE: resource_resource.py) ---
            // def _get_calendars_validity_within_period(self, start, end, default_company=None):
            // assert start.tzinfo and end.tzinfo
            // if not self:
            //     return super()._get_calendars_validity_within_period(start, end, default_company=default_company)
            // calendars_within_period_per_resource = defaultdict(lambda: defaultdict(Intervals))  # keys are [resource id:integer][calendar:self.env['resource.calendar']]
            // # Employees that have ever had an active contract
            // employee_ids_with_active_contracts = {
            //     employee.id for [employee] in
            //     self.env['hr.contract']._read_group(
            //         domain=[
            //             ('employee_id', 'in', self.employee_id.ids),
            //             '|', ('state', '=', 'open'),
            //             '|', ('state', '=', 'close'),
            //                  '&', ('state', '=', 'draft'), ('kanban_state', '=', 'done')
            //         ],
            //         groupby=['employee_id'],
            //     )
            // }
            // resource_without_contract = self.filtered(
            //     lambda r: not r.employee_id\
            //            or not r.employee_id.id in employee_ids_with_active_contracts\
            //            or r.employee_id.employee_type not in ['employee', 'student']
            // )
            // if resource_without_contract:
            //     calendars_within_period_per_resource.update(
            //         super(ResourceResource, resource_without_contract)._get_calendars_validity_within_period(start, end, default_company=default_company)
            //     )
            // resource_with_contract = self - resource_without_contract
            // if not resource_with_contract:
            //     return calendars_within_period_per_resource
            // timezones = {resource.tz for resource in resource_with_contract}
            // date_start = min(start.astimezone(timezone(tz)).date() for tz in timezones)
            // date_end = max(end.astimezone(timezone(tz)).date() for tz in timezones)
            // contracts = resource_with_contract.employee_id._get_contracts(
            //     date_start, date_end, states=['open', 'draft', 'close']
            // ).filtered(lambda c: c.state in ['open', 'close'] or c.kanban_state == 'done')
            // for contract in contracts:
            //     tz = timezone(contract.employee_id.tz)
            //     calendars_within_period_per_resource[contract.employee_id.resource_id.id][contract.resource_calendar_id] |= Intervals([(
            //         tz.localize(datetime.combine(contract.date_start, datetime.min.time())) if contract.date_start > start.astimezone(tz).date() else start,
            //         tz.localize(datetime.combine(contract.date_end, datetime.max.time())) if contract.date_end and contract.date_end < end.astimezone(tz).date() else end,
            //         self.env['resource.calendar.attendance']
            //     )])
            // return calendars_within_period_per_resource
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_resource.py) ---
            // def _get_calendars_validity_within_period(self, start, end, default_company=None):
            // """ Gets a dict of dict with resource's id as first key and resource's calendar as secondary key
            //     The value is the validity interval of the calendar for the given resource.
            // 
            //     Here the validity interval for each calendar is the whole interval but it's meant to be overriden in further modules
            //     handling resource's employee contracts.
            // """
            // assert start.tzinfo and end.tzinfo
            // resource_calendars_within_period = defaultdict(lambda: defaultdict(Intervals))  # keys are [resource id:integer][calendar:self.env['resource.calendar']]
            // default_calendar = default_company and default_company.resource_calendar_id or self.env.company.resource_calendar_id
            // if not self:
            //     # if no resource, add the company resource calendar.
            //     resource_calendars_within_period[False][default_calendar] = Intervals([(start, end, self.env['resource.calendar.attendance'])])
            // for resource in self:
            //     calendar = resource.calendar_id or resource.company_id.resource_calendar_id or default_calendar
            //     resource_calendars_within_period[resource.id][calendar] = Intervals([(start, end, self.env['resource.calendar.attendance'])])
            // return resource_calendars_within_period
            */
            return default;
        }

        protected async Task<ResourceResource> GetUnavailableIntervalsInternalAsync(object start, object end)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_resource.py) ---
            // def _get_unavailable_intervals(self, start, end):
            // """ Compute the intervals during which employee is unavailable with hour granularity between start and end
            //     Note: this method is used in enterprise (forecast and planning)
            // 
            // """
            // start_datetime = timezone_datetime(start)
            // end_datetime = timezone_datetime(end)
            // resource_mapping = {}
            // calendar_mapping = defaultdict(lambda: self.env['resource.resource'])
            // for resource in self:
            //     calendar_mapping[resource.calendar_id or resource.company_id.resource_calendar_id] |= resource
            // 
            // for calendar, resources in calendar_mapping.items():
            //     if not calendar:
            //         continue
            //     resources_unavailable_intervals = calendar._unavailable_intervals_batch(start_datetime, end_datetime, resources, tz=timezone(calendar.tz))
            //     resource_mapping.update(resources_unavailable_intervals)
            // return resource_mapping
            */
            return default;
        }

        protected async Task<ResourceResource> GetValidWorkIntervalsInternalAsync(object start, object end, object calendars, object compute_leaves)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_resource.py) ---
            // def _get_valid_work_intervals(self, start, end, calendars=None, compute_leaves=True):
            // """ Gets the valid work intervals of the resource following their calendars between ``start`` and ``end``
            // 
            //     This methods handle the eventuality of a resource having multiple resource calendars, see _get_calendars_validity_within_period method
            //     for further explanation.
            // 
            //     For flexible calendars and fully flexible resources: -> return the whole interval
            // """
            // assert start.tzinfo and end.tzinfo
            // resource_calendar_validity_intervals = {}
            // calendar_resources = defaultdict(lambda: self.env['resource.resource'])
            // resource_work_intervals = defaultdict(Intervals)
            // calendar_work_intervals = dict()
            // 
            // resource_calendar_validity_intervals = self.sudo()._get_calendars_validity_within_period(start, end)
            // for resource in self:
            //     # For each resource, retrieve its calendar and their validity intervals
            //     for calendar in resource_calendar_validity_intervals[resource.id]:
            //         calendar_resources[calendar] |= resource
            // for calendar in (calendars or []):
            //     calendar_resources[calendar] |= self.env['resource.resource']
            // for calendar, resources in calendar_resources.items():
            //     # for fully flexible resource, return the whole interval
            //     if not calendar:
            //         for resource in resources:
            //             resource_work_intervals[resource.id] |= Intervals([(start, end, self.env['resource.calendar.attendance'])])
            //         continue
            //     # For each calendar used by the resources, retrieve the work intervals for every resources using it
            //     work_intervals_batch = calendar._work_intervals_batch(start, end, resources=resources, compute_leaves=compute_leaves)
            //     for resource in resources:
            //         # Make the conjunction between work intervals and calendar validity
            //         resource_work_intervals[resource.id] |= work_intervals_batch[resource.id] & resource_calendar_validity_intervals[resource.id][calendar]
            //     calendar_work_intervals[calendar.id] = work_intervals_batch[False]
            // 
            // return resource_work_intervals, calendar_work_intervals
            */
            return default;
        }

        protected async Task<ResourceResource> GetWorkIntervalInternalAsync(object start, object end)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_resource.py) ---
            // def _get_work_interval(self, start, end):
            // # Deprecated method. Use `_adjust_to_calendar` instead
            // return self._adjust_to_calendar(start, end)
            */
            return default;
        }

        protected async Task<ResourceResource> IsFlexibleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_resource.py) ---
            // def _is_flexible(self):
            // """ An employee is considered flexible if the field flexible_hours is True on the calendar
            //     or the employee is not assigned any calendar, in which case is considered as Fully flexible.
            // """
            // self.ensure_one()
            // return self._is_fully_flexible() or (self.calendar_id and self.calendar_id.flexible_hours)
            */
            return default;
        }

        protected async Task<ResourceResource> IsFullyFlexibleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_resource.py) ---
            // def _is_fully_flexible(self):
            // """ employee has a fully flexible schedule has no working calendar set """
            // self.ensure_one()
            // return not self.calendar_id
            */
            return default;
        }

        protected async Task<ResourceResource> OnchangeCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_resource.py) ---
            // def _onchange_company_id(self):
            // if self.company_id:
            //     self.calendar_id = self.company_id.resource_calendar_id.id
            */
            return default;
        }

        protected async Task<ResourceResource> OnchangeUserIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_resource.py) ---
            // def _onchange_user_id(self):
            // if self.user_id:
            //     self.tz = self.user_id.tz
            */
            return default;
        }
    }
}