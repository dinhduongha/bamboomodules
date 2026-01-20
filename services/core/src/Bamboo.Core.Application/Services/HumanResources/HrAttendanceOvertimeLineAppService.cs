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
    [Module("HrAttendanceModule", Category = "HumanResources", Depends = new[] { "hr", "barcodes", "base_geolocalize" })]
    public partial class HrAttendanceOvertimeLineAppService : GenericApplicationService<HrAttendanceOvertimeLine>, IHrAttendanceOvertimeLineAppService
    {

        public HrAttendanceOvertimeLineAppService(IRepository<HrAttendanceOvertimeLine, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        public async Task<HrAttendanceOvertimeLine> ApproveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance_overtime.py) ---
            // def action_approve(self):
            // self.write({'status': 'approved'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrAttendanceOvertimeLine> ComputeIsManagerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance_overtime.py) ---
            // def _compute_is_manager(self):
            // has_manager_right = self.env.user.has_group('hr_attendance.group_hr_attendance_manager')
            // has_officer_right = self.env.user.has_group('hr_attendance.group_hr_attendance_officer')
            // for overtime in self:
            //     overtime.is_manager = (
            //         has_manager_right or
            //         (
            //             has_officer_right
            //             and overtime.employee_id.attendance_manager_id == self.env.user
            //         )
            //     )
            */
            return default;
        }

        protected async Task<HrAttendanceOvertimeLine> ComputeManualDurationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance_overtime.py) ---
            // def _compute_manual_duration(self):
            // for overtime in self:
            //     overtime.manual_duration = overtime.duration
            */
            return default;
        }

        protected async Task<HrAttendanceOvertimeLine> ComputeStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance_overtime.py) ---
            // def _compute_status(self):
            // for overtime in self:
            //     if not overtime.status:
            //         overtime.status = 'to_approve' if overtime.employee_id.company_id.attendance_overtime_validation == 'by_manager' else 'approved'
            */
            return default;
        }

        protected async Task<HrAttendanceOvertimeLine> LinkedAttendancesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance_overtime.py) ---
            // def _linked_attendances(self):
            // return self.env['hr.attendance'].search([
            //     ('date', 'in', self.mapped('date')),
            //     ('employee_id', 'in', self.employee_id.ids),
            // ])
            */
            return default;
        }

        public async Task<HrAttendanceOvertimeLine> RefuseAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance_overtime.py) ---
            // def action_refuse(self):
            // self.write({'status': 'refused'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}