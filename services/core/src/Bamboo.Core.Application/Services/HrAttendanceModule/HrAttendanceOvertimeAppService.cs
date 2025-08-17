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
    [Module("HrAttendanceModule", Depends = new[] { "hr", "barcodes" })]
    public class HrAttendanceOvertimeAppService : GenericApplicationService<HrAttendanceOvertime>, IHrAttendanceOvertimeAppService
    {

        public HrAttendanceOvertimeAppService(IRepository<HrAttendanceOvertime, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<HrAttendanceOvertime> DefaultEmployeeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance_overtime.py) ---
            // def _default_employee(self):
            // return self.env.user.employee_id
            */
            return default;
        }

        public async Task<HrAttendanceOvertime> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance_overtime.py) ---
            // def init(self):
            // # Allows only 1 overtime record per employee per day unless it's an adjustment
            // self.env.cr.execute("""
            //     CREATE UNIQUE INDEX IF NOT EXISTS hr_attendance_overtime_unique_employee_per_day
            //     ON %s (employee_id, date)
            //     WHERE adjustment is false""" % (self._table))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}