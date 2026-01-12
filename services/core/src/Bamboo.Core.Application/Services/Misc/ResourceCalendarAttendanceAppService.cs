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
    public class ResourceCalendarAttendanceAppService : GenericApplicationService<ResourceCalendarAttendance>, IResourceCalendarAttendanceAppService
    {

        public ResourceCalendarAttendanceAppService(IRepository<ResourceCalendarAttendance, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<ResourceCalendarAttendance> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: resource_calendar_attendance.py) ---
            // def _compute_display_name(self):
            // super()._compute_display_name()
            // this_week_type = str(self.get_week_type(fields.Date.context_today(self)))
            // section_names = {'0': _('First week'), '1': _('Second week')}
            // section_info = {True: _('this week'), False: _('other week')}
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
            // for attendance in self:
            //     attendance.duration_hours = (attendance.hour_to - attendance.hour_from) if attendance.day_period != 'lunch' else 0
            */
            return default;
        }

        protected async Task<ResourceCalendarAttendance> CopyAttendanceValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: resource.py) ---
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
            //     'date_from': self.date_from,
            //     'date_to': self.date_to,
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
            --- ODOO METHOD SOURCE (MODULE: hr_work_entry, FILE: resource.py) ---
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