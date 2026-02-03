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
        Task<HrEmployeePublic> GetAvatarCardDataAsync(HrEmployeePublicGetAvatarCardDataRequestDto input);
        Task<HrEmployeePublic> InitAsync(Guid[] ids);
        Task<HrEmployeePublic> OpenCoursesAsync(Guid[] ids);
        Task<HrEmployeePublic> OpenLastMonthAttendancesAsync(Guid[] ids);
        Task<HrEmployeePublic> OpenTimeOffCalendarAsync(Guid[] ids);
        Task<HrEmployeePublic> TimeOffDashboardAsync(Guid[] ids);
        Task<HrEmployeePublic> TimesheetFromEmployeeAsync(Guid[] ids);
    }
}