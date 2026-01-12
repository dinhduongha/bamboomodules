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
        Task<HrAttendance> ApproveOvertimeAsync(Guid id);
        Task<HrAttendance> GetKioskUrlAsync(Guid id);
        Task<HrAttendance> HasDemoDataAsync(Guid id);
        Task<HrAttendance> InAttendanceMapsAsync(Guid id);
        Task<HrAttendance> OutAttendanceMapsAsync(Guid id);
        Task<HrAttendance> RefuseOvertimeAsync(Guid id);
        Task<HrAttendance> TryKioskAsync(Guid id);
    }
}