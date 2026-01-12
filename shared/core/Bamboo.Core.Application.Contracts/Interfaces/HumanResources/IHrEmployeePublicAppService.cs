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
    public interface IHrEmployeePublicAppService : IGenericApplicationService<HrEmployeePublic>
    {
        Task<HrEmployeePublic> GetAvatarCardDataAsync(Guid id, HrEmployeePublicGetAvatarCardDataRequestDto input);
        Task<HrEmployeePublic> InitAsync(Guid id);
        Task<HrEmployeePublic> OpenCoursesAsync(Guid id);
        Task<HrEmployeePublic> OpenLastMonthAttendancesAsync(Guid id);
        Task<HrEmployeePublic> OpenTimeOffCalendarAsync(Guid id);
        Task<HrEmployeePublic> TimeOffDashboardAsync(Guid id);
        Task<HrEmployeePublic> TimesheetFromEmployeeAsync(Guid id);
    }
}