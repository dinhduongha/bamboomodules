using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
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
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("HrAttendanceModule", Category = "HumanResources", Depends = new[] { "hr", "barcodes", "base_geolocalize" })]
    public partial class HrAttendanceOvertimeRulesetAppService : GenericAppService<HrAttendanceOvertimeRuleset>, IHrAttendanceOvertimeRulesetAppService
    {

        public HrAttendanceOvertimeRulesetAppService(IRepository<HrAttendanceOvertimeRuleset, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<HrAttendanceOvertimeRuleset> RegenerateOvertimesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance_overtime_ruleset.py, METHOD: action_regenerate_overtimes) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}