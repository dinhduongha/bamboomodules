using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IHrAttendanceAppService : IGenericApplicationService<HrAttendance>
    {
        Task<HrAttendance> ApproveOvertimeAsync(Guid[] ids);
        Task<HrAttendance> GetKioskUrlAsync(Guid[] ids);
        Task<HrAttendance> HasDemoDataAsync(Guid[] ids);
        Task<HrAttendance> InAttendanceMapsAsync(Guid[] ids);
        Task<HrAttendance> OutAttendanceMapsAsync(Guid[] ids);
        Task<HrAttendance> RefuseOvertimeAsync(Guid[] ids);
        Task<HrAttendance> TryKioskAsync(Guid[] ids);
    }
}