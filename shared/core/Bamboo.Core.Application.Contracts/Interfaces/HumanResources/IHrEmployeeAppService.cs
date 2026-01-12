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
        Task<HrEmployee> ArchiveAsync(Guid id);
        Task<HrEmployee> CheckNoExistingContractAsync(Guid id, HrEmployeeCheckNoExistingContractRequestDto input);
        Task<HrEmployee> CreateContractAsync(Guid id, HrEmployeeCreateContractRequestDto input);
        Task<HrEmployee> CreateUserAsync(Guid id);
        Task<HrEmployee> CreateUsersAsync(Guid id);
        Task<HrEmployee> CreateUsersConfirmationAsync(Guid id);
        Task<HrEmployee> CreateVersionAsync(Guid id, HrEmployeeCreateVersionRequestDto input);
        Task<HrEmployee> FetchAsync(Guid id, HrEmployeeFetchRequestDto input);
        Task<HrEmployee> GenerateRandomBarcodeAsync(Guid id);
        Task<HrEmployee> GenerateWorkEntriesAsync(Guid id, HrEmployeeGenerateWorkEntriesRequestDto input);
        Task<HrEmployee> GetAccountsWithFixedAllocationsAsync(Guid id);
        Task<HrEmployee> GetAllocationRequestsAmountAsync(Guid id);
        Task<HrEmployee> GetAvatarCardDataAsync(Guid id, HrEmployeeGetAvatarCardDataRequestDto input);
        Task<HrEmployee> GetBankAccountSalaryAllocationAsync(Guid id, HrEmployeeGetBankAccountSalaryAllocationRequestDto input);
        Task<HrEmployee> GetBarcodesAndPinHashedAsync(Guid id);
        Task<HrEmployee> GetFormviewActionAsync(Guid id, HrEmployeeGetFormviewActionRequestDto input);
        Task<HrEmployee> GetFormviewIdAsync(Guid id, HrEmployeeGetFormviewIdRequestDto input);
        Task<HrEmployee> GetImportTemplatesAsync(Guid id);
        Task<HrEmployee> GetInternalResumeLinesAsync(Guid id, HrEmployeeGetInternalResumeLinesRequestDto input);
        Task<HrEmployee> GetMandatoryDaysAsync(Guid id, HrEmployeeGetMandatoryDaysRequestDto input);
        Task<HrEmployee> GetMandatoryDaysDataAsync(Guid id, HrEmployeeGetMandatoryDaysDataRequestDto input);
        Task<HrEmployee> GetOvertimeDataAsync(Guid id, HrEmployeeGetOvertimeDataRequestDto input);
        Task<HrEmployee> GetOvertimeDataByEmployeeAsync(Guid id);
        Task<HrEmployee> GetPresenceServerDataAsync(Guid id);
        Task<HrEmployee> GetPublicHolidaysDataAsync(Guid id, HrEmployeeGetPublicHolidaysDataRequestDto input);
        Task<HrEmployee> GetRemainingPercentageAsync(Guid id);
        Task<HrEmployee> GetSpecialDaysDataAsync(Guid id, HrEmployeeGetSpecialDaysDataRequestDto input);
        Task<HrEmployee> GetTimeOffDashboardDataAsync(Guid id, HrEmployeeGetTimeOffDashboardDataRequestDto input);
        Task<HrEmployee> GetViewAsync(Guid id, HrEmployeeGetViewRequestDto input);
        Task<HrEmployee> GetViewsAsync(Guid id, HrEmployeeGetViewsRequestDto input);
        Task<HrEmployee> NewAsync(Guid id, HrEmployeeNewRequestDto input);
        Task<HrEmployee> NotifyExpiringContractWorkPermitAsync(Guid id);
        Task<HrEmployee> OpenAllocationWizardAsync(Guid id);
        Task<HrEmployee> OpenBarcodeScannerAsync(Guid id);
        Task<HrEmployee> OpenCoursesAsync(Guid id);
        Task<HrEmployee> OpenEmployeeCarsAsync(Guid id);
        Task<HrEmployee> OpenLastMonthAttendancesAsync(Guid id);
        Task<HrEmployee> OpenLeaveRequestAsync(Guid id);
        Task<HrEmployee> OpenVersionsAsync(Guid id);
        Task<HrEmployee> OpenWorkEntriesAsync(Guid id, HrEmployeeOpenWorkEntriesRequestDto input);
        Task<HrEmployee> RelatedContactsAsync(Guid id);
        Task<HrEmployee> SearchFetchAsync(Guid id, HrEmployeeSearchFetchRequestDto input);
        Task<HrEmployee> SendLogAsync(Guid id);
        Task<HrEmployee> SendSmsAsync(Guid id);
        Task<HrEmployee> SetAbsentAsync(Guid id);
        Task<HrEmployee> SetPresentAsync(Guid id);
        Task<HrEmployee> TimeOffDashboardAsync(Guid id);
        Task<HrEmployee> TimesheetFromEmployeeAsync(Guid id);
        Task<HrEmployee> TogglePrimaryBankAccountTrustAsync(Guid id);
        Task<HrEmployee> UnarchiveAsync(Guid id);
        Task<HrEmployee> UnlinkWizardAsync(Guid id);
    }
}