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
    public interface IHrEmployeeAppService : IGenericApplicationService<HrEmployee>
    {
        Task<HrEmployee> CreateUserAsync(Guid id);
        Task<HrEmployee> FetchAsync(Guid id, HrEmployeeFetchRequestDto input);
        Task<HrEmployee> GenerateRandomBarcodeAsync(Guid id);
        Task<HrEmployee> GenerateWorkEntriesAsync(Guid id, HrEmployeeGenerateWorkEntriesRequestDto input);
        Task<HrEmployee> GetAllocationRequestsAmountAsync(Guid id);
        Task<HrEmployee> GetBarcodesAndPinHashedAsync(Guid id);
        Task<HrEmployee> GetFormviewActionAsync(Guid id, HrEmployeeGetFormviewActionRequestDto input);
        Task<HrEmployee> GetFormviewIdAsync(Guid id, HrEmployeeGetFormviewIdRequestDto input);
        Task<HrEmployee> GetImportTemplatesAsync(Guid id);
        Task<HrEmployee> GetMandatoryDaysAsync(Guid id, HrEmployeeGetMandatoryDaysRequestDto input);
        Task<HrEmployee> GetMandatoryDaysDataAsync(Guid id, HrEmployeeGetMandatoryDaysDataRequestDto input);
        Task<HrEmployee> GetPublicHolidaysDataAsync(Guid id, HrEmployeeGetPublicHolidaysDataRequestDto input);
        Task<HrEmployee> GetSpecialDaysDataAsync(Guid id, HrEmployeeGetSpecialDaysDataRequestDto input);
        Task<HrEmployee> GetViewAsync(Guid id, HrEmployeeGetViewRequestDto input);
        Task<HrEmployee> GetViewsAsync(Guid id, HrEmployeeGetViewsRequestDto input);
        Task<HrEmployee> OpenContractAsync(Guid id);
        Task<HrEmployee> OpenCoursesAsync(Guid id);
        Task<HrEmployee> OpenEmployeeCarsAsync(Guid id);
        Task<HrEmployee> OpenLastMonthAttendancesAsync(Guid id);
        Task<HrEmployee> OpenLastMonthOvertimeAsync(Guid id);
        Task<HrEmployee> OpenWorkEntriesAsync(Guid id, HrEmployeeOpenWorkEntriesRequestDto input);
        Task<HrEmployee> RelatedContactsAsync(Guid id);
        Task<HrEmployee> SearchFetchAsync(Guid id, HrEmployeeSearchFetchRequestDto input);
        Task<HrEmployee> TimeOffDashboardAsync(Guid id);
        Task<HrEmployee> TimesheetFromEmployeeAsync(Guid id);
        Task<HrEmployee> ToggleActiveAsync(Guid id);
        Task<HrEmployee> UnlinkWizardAsync(Guid id);
    }
}