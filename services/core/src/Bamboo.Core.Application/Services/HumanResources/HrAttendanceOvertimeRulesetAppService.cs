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
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("HrAttendanceModule", Category = "HumanResources", Depends = new[] { "hr", "barcodes", "base_geolocalize" })]
    public partial class HrAttendanceOvertimeRulesetAppService : GenericApplicationService<HrAttendanceOvertimeRuleset>, IHrAttendanceOvertimeRulesetAppService
    {

        public HrAttendanceOvertimeRulesetAppService(IRepository<HrAttendanceOvertimeRuleset, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<HrAttendanceOvertimeRuleset> AttendancesToRegenerateForInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance_overtime_ruleset.py) ---
            // def _attendances_to_regenerate_for(self):
            // self.ensure_one()
            // elligible_version = self.env['hr.version'].search([('ruleset_id', '=', self.id)])
            // if not elligible_version:
            //     return self.env['hr.attendance']
            // elligible_attendances = self.env['hr.attendance'].search([
            //     ('employee_id', 'in', elligible_version.employee_id.ids),
            //     ('date', '>=', min(elligible_version.mapped('date_version'))),
            // ])
            // return elligible_attendances
            */
            return default;
        }

        protected async Task<HrAttendanceOvertimeRuleset> ComputeRulesCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance_overtime_ruleset.py) ---
            // def _compute_rules_count(self):
            // for ruleset in self:
            //     ruleset.rules_count = len(ruleset.rule_ids)
            */
            return default;
        }

        public async Task<HrAttendanceOvertimeRuleset> RegenerateOvertimesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance_overtime_ruleset.py) ---
            // def action_regenerate_overtimes(self):
            // self._attendances_to_regenerate_for()._update_overtime()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}