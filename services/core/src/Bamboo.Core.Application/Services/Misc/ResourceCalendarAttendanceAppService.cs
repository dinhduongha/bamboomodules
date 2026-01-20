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
    [Module("Resource", Category = "Misc", Depends = new[] { "base", "web" })]
    public partial class ResourceCalendarAttendanceAppService : GenericApplicationService<ResourceCalendarAttendance>, IResourceCalendarAttendanceAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ResourceCalendarAttendanceAppService(IRepository<ResourceCalendarAttendance, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<ResourceCalendarAttendance> CheckDayPeriodInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar_attendance.py) ---
            // def _check_day_period(self):
            // for attendance in self:
            //     if attendance.day_period == 'lunch' and attendance.duration_based:
            //         raise UserError(self.env._("%(att)s is a break attendance, You should not have such record on duration based calendar", att=attendance.name))
            */
            return default;
        }

        protected async Task<ResourceCalendarAttendance> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar_attendance.py) ---
            // def _compute_display_name(self):
            // super()._compute_display_name()
            // this_week_type = str(self.get_week_type(fields.Date.context_today(self)))
            // section_names = {'0': self.env._('First week'), '1': self.env._('Second week')}
            // section_info = {True: self.env._('this week'), False: self.env._('other week')}
            // for record in self.filtered(lambda l: l.display_type == 'line_section'):
            //     section_name = f"{section_names[record.week_type]} ({section_info[this_week_type == record.week_type]})"
            //     record.display_name = section_name
            */
            return default;
        }

        protected async Task<ResourceCalendarAttendance> ComputeDurationDaysInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar_attendance.py) ---
            // def _compute_duration_days(self):
            // for attendance in self:
            //     if attendance.day_period == 'lunch':
            //         attendance.duration_days = 0
            //     elif attendance.day_period == 'full_day':
            //         attendance.duration_days = 1
            //     else:
            //         attendance.duration_days = 0.5 if attendance.duration_hours <= attendance.calendar_id.hours_per_day * 3 / 4 else 1
            */
            return default;
        }

        protected async Task<ResourceCalendarAttendance> ComputeDurationHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar_attendance.py) ---
            // def _compute_duration_hours(self):
            // for attendance in self.filtered('hour_to'):
            //     attendance.duration_hours = (attendance.hour_to - attendance.hour_from) if attendance.day_period != 'lunch' else 0
            */
            return default;
        }

        protected async Task<ResourceCalendarAttendance> CopyAttendanceValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: resource_calendar_attendance.py) ---
            // def _copy_attendance_vals(self):
            // res = super()._copy_attendance_vals()
            // res['work_entry_type_id'] = self.work_entry_type_id.id
            // return res
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar_attendance.py) ---
            // def _copy_attendance_vals(self):
            // self.ensure_one()
            // return {
            //     'name': self.name,
            //     'dayofweek': self.dayofweek,
            //     'hour_from': self.hour_from,
            //     'hour_to': self.hour_to,
            //     'day_period': self.day_period,
            //     'week_type': self.week_type,
            //     'display_type': self.display_type,
            //     'sequence': self.sequence,
            // }
            */
            return default;
        }

        protected async Task<ResourceCalendarAttendance> DefaultWorkEntryTypeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: resource_calendar_attendance.py) ---
            // def _default_work_entry_type_id(self):
            // return self.env.ref('hr_work_entry.work_entry_type_attendance', raise_if_not_found=False)
            */
            return default;
        }

        public async Task<ResourceCalendarAttendance> GetWeekTypeAsync(Guid id, ResourceCalendarAttendanceGetWeekTypeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar_attendance.py) ---
            // def get_week_type(self, date):
            // # week_type is defined by
            // #  * counting the number of days from January 1 of year 1
            // #    (extrapolated to dates prior to the first adoption of the Gregorian calendar)
            // #  * converted to week numbers and then the parity of this number is asserted.
            // # It ensures that an even week number always follows an odd week number. With classical week number,
            // # some years have 53 weeks. Therefore, two consecutive odd week number follow each other (53 --> 1).
            // return int(math.floor((date.toordinal() - 1) / 7) % 2)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResourceCalendarAttendance> InverseDurationHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar_attendance.py) ---
            // def _inverse_duration_hours(self):
            // for calendar, attendances in self.grouped('calendar_id').items():
            //     if not calendar.duration_based:
            //         continue
            //     for attendance in attendances:
            //         if attendance.day_period == 'full_day':
            //             period_duration = attendance.duration_hours / 2
            //             attendance.hour_to = 12 + period_duration
            //             attendance.hour_from = 12 - period_duration
            //         elif attendance.day_period == 'morning':
            //             attendance.hour_to = 12
            //             attendance.hour_from = 12 - attendance.duration_hours
            //         elif attendance.day_period == 'afternoon':
            //             attendance.hour_to = 12 + attendance.duration_hours
            //             attendance.hour_from = 12
            */
            return default;
        }

        protected async Task<ResourceCalendarAttendance> IsWorkPeriodInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: resource_calendar_attendance.py) ---
            // def _is_work_period(self):
            // return not self.work_entry_type_id.is_leave and super()._is_work_period()
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar_attendance.py) ---
            // def _is_work_period(self):
            // return self.day_period != 'lunch' and not self.display_type
            */
            return default;
        }

        protected async Task<ResourceCalendarAttendance> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: resource_calendar_attendance.py) ---
            // def _load_pos_data_domain(self, data, config):
            // attendance_ids = []
            // for preset in data['pos.preset']:
            //     attendance_ids += preset['attendance_ids']
            // return [('id', 'in', attendance_ids)]
            */
            return default;
        }

        protected async Task<ResourceCalendarAttendance> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: resource_calendar_attendance.py) ---
            // def _load_pos_data_fields(self, config):
            // return ['id', 'hour_from', 'hour_to', 'dayofweek', 'day_period']
            */
            return default;
        }

        protected async Task<ResourceCalendarAttendance> OnchangeHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar_attendance.py) ---
            // def _onchange_hours(self):
            // # avoid negative or after midnight
            // self.hour_from = min(self.hour_from, 23.99)
            // self.hour_from = max(self.hour_from, 0.0)
            // self.hour_to = min(self.hour_to, 24)
            // self.hour_to = max(self.hour_to, 0.0)
            // 
            // # avoid wrong order
            // self.hour_to = max(self.hour_to, self.hour_from)
            */
            return default;
        }
    }
}