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
    public interface IHrEmployeeAppService : IGenericAppService<HrEmployee>
    {
        Task<HrEmployee> ArchiveAsync(Guid[] ids);
        Task<HrEmployee> CheckNoExistingContractAsync(HrEmployeeCheckNoExistingContractRequestDto input);
        Task<HrEmployee> CreateContractAsync(HrEmployeeCreateContractRequestDto input);
        Task<HrEmployee> CreateUserAsync(Guid[] ids);
        Task<HrEmployee> CreateUsersAsync(Guid[] ids);
        Task<HrEmployee> CreateUsersConfirmationAsync(Guid[] ids);
        Task<HrEmployee> CreateVersionAsync(HrEmployeeCreateVersionRequestDto input);
        Task<HrEmployee> FetchAsync(HrEmployeeFetchRequestDto input);
        Task<HrEmployee> GenerateRandomBarcodeAsync(Guid[] ids);
        Task<HrEmployee> GenerateWorkEntriesAsync(HrEmployeeGenerateWorkEntriesRequestDto input);
        Task<HrEmployee> GetAccountsWithFixedAllocationsAsync(Guid[] ids);
        Task<HrEmployee> GetAllocationRequestsAmountAsync(Guid[] ids);
        Task<HrEmployee> GetAvatarCardDataAsync(HrEmployeeGetAvatarCardDataRequestDto input);
        Task<HrEmployee> GetBankAccountSalaryAllocationAsync(HrEmployeeGetBankAccountSalaryAllocationRequestDto input);
        Task<HrEmployee> GetBarcodesAndPinHashedAsync(Guid[] ids);
        Task<HrEmployee> GetFormviewActionAsync(HrEmployeeGetFormviewActionRequestDto input);
        Task<HrEmployee> GetFormviewIdAsync(HrEmployeeGetFormviewIdRequestDto input);
        Task<HrEmployee> GetImportTemplatesAsync(Guid[] ids);
        Task<HrEmployee> GetInternalResumeLinesAsync(HrEmployeeGetInternalResumeLinesRequestDto input);
        Task<HrEmployee> GetMandatoryDaysAsync(HrEmployeeGetMandatoryDaysRequestDto input);
        Task<HrEmployee> GetMandatoryDaysDataAsync(HrEmployeeGetMandatoryDaysDataRequestDto input);
        Task<HrEmployee> GetOvertimeDataAsync(HrEmployeeGetOvertimeDataRequestDto input);
        Task<HrEmployee> GetOvertimeDataByEmployeeAsync(Guid[] ids);
        Task<HrEmployee> GetPresenceServerDataAsync(Guid[] ids);
        Task<HrEmployee> GetPublicHolidaysDataAsync(HrEmployeeGetPublicHolidaysDataRequestDto input);
        Task<HrEmployee> GetRemainingPercentageAsync(Guid[] ids);
        Task<HrEmployee> GetSpecialDaysDataAsync(HrEmployeeGetSpecialDaysDataRequestDto input);
        Task<HrEmployee> GetTimeOffDashboardDataAsync(HrEmployeeGetTimeOffDashboardDataRequestDto input);
        Task<HrEmployee> GetViewAsync(HrEmployeeGetViewRequestDto input);
        Task<HrEmployee> GetViewsAsync(HrEmployeeGetViewsRequestDto input);
        Task<HrEmployee> NewAsync(HrEmployeeNewRequestDto input);
        Task<HrEmployee> NotifyExpiringContractWorkPermitAsync(Guid[] ids);
        Task<HrEmployee> OpenAllocationWizardAsync(Guid[] ids);
        Task<HrEmployee> OpenBarcodeScannerAsync(Guid[] ids);
        Task<HrEmployee> OpenCoursesAsync(Guid[] ids);
        Task<HrEmployee> OpenEmployeeCarsAsync(Guid[] ids);
        Task<HrEmployee> OpenLastMonthAttendancesAsync(Guid[] ids);
        Task<HrEmployee> OpenLeaveRequestAsync(Guid[] ids);
        Task<HrEmployee> OpenVersionsAsync(Guid[] ids);
        Task<HrEmployee> OpenWorkEntriesAsync(HrEmployeeOpenWorkEntriesRequestDto input);
        Task<HrEmployee> RelatedContactsAsync(Guid[] ids);
        Task<HrEmployee> SearchFetchAsync(HrEmployeeSearchFetchRequestDto input);
        Task<HrEmployee> SendLogAsync(Guid[] ids);
        Task<HrEmployee> SendSmsAsync(Guid[] ids);
        Task<HrEmployee> SetAbsentAsync(Guid[] ids);
        Task<HrEmployee> SetPresentAsync(Guid[] ids);
        Task<HrEmployee> TimeOffDashboardAsync(Guid[] ids);
        Task<HrEmployee> TimesheetFromEmployeeAsync(Guid[] ids);
        Task<HrEmployee> TogglePrimaryBankAccountTrustAsync(Guid[] ids);
        Task<HrEmployee> UnarchiveAsync(Guid[] ids);
        Task<HrEmployee> UnlinkWizardAsync(Guid[] ids);
    }
}