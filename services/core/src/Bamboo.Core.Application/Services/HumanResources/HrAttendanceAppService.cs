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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("HrAttendanceModule", Category = "HumanResources", Depends = new[] { "hr", "barcodes", "base_geolocalize" })]
    public partial class HrAttendanceAppService : GenericAppService<HrAttendance>, IHrAttendanceAppService
    {
        protected readonly IMailThreadAppService _mailThreadAppService;
        public HrAttendanceAppService(IRepository<HrAttendance, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<HrAttendance> ApproveOvertimeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: action_approve_overtime) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrAttendance> GetKioskUrlAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: get_kiosk_url) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<HrAttendance> HasDemoDataAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: has_demo_data) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrAttendance> InAttendanceMapsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: action_in_attendance_maps) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrAttendance> OutAttendanceMapsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: action_out_attendance_maps) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrAttendance> RefuseOvertimeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: action_refuse_overtime) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<HrAttendance> TryKioskAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: action_try_kiosk) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}