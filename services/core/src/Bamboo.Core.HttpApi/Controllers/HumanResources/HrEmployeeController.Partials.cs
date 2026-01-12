using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrEmployeeController
    {
        
        [HttpPost]
        [Route("{id}/action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid id)
        {
            var result = await _appService.ArchiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-create-user")]
        public async Task<IActionResult> ActionCreateUserAsync(Guid id)
        {
            var result = await _appService.CreateUserAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-create-users")]
        public async Task<IActionResult> ActionCreateUsersAsync(Guid id)
        {
            var result = await _appService.CreateUsersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-create-users-confirmation")]
        public async Task<IActionResult> ActionCreateUsersConfirmationAsync(Guid id)
        {
            var result = await _appService.CreateUsersConfirmationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-allocation-wizard")]
        public async Task<IActionResult> ActionOpenAllocationWizardAsync(Guid id)
        {
            var result = await _appService.OpenAllocationWizardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-courses")]
        public async Task<IActionResult> ActionOpenCoursesAsync(Guid id)
        {
            var result = await _appService.OpenCoursesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-employee-cars")]
        public async Task<IActionResult> ActionOpenEmployeeCarsAsync(Guid id)
        {
            var result = await _appService.OpenEmployeeCarsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-last-month-attendances")]
        public async Task<IActionResult> ActionOpenLastMonthAttendancesAsync(Guid id)
        {
            var result = await _appService.OpenLastMonthAttendancesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-leave-request")]
        public async Task<IActionResult> ActionOpenLeaveRequestAsync(Guid id)
        {
            var result = await _appService.OpenLeaveRequestAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-versions")]
        public async Task<IActionResult> ActionOpenVersionsAsync(Guid id)
        {
            var result = await _appService.OpenVersionsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-work-entries")]
        public async Task<IActionResult> ActionOpenWorkEntriesAsync(Guid id, [FromBody] HrEmployeeOpenWorkEntriesRequestDto input)
        {
            var result = await _appService.OpenWorkEntriesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-related-contacts")]
        public async Task<IActionResult> ActionRelatedContactsAsync(Guid id)
        {
            var result = await _appService.RelatedContactsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-log")]
        public async Task<IActionResult> ActionSendLogAsync(Guid id)
        {
            var result = await _appService.SendLogAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-sms")]
        public async Task<IActionResult> ActionSendSmsAsync(Guid id)
        {
            var result = await _appService.SendSmsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-absent")]
        public async Task<IActionResult> ActionSetAbsentAsync(Guid id)
        {
            var result = await _appService.SetAbsentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-present")]
        public async Task<IActionResult> ActionSetPresentAsync(Guid id)
        {
            var result = await _appService.SetPresentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-time-off-dashboard")]
        public async Task<IActionResult> ActionTimeOffDashboardAsync(Guid id)
        {
            var result = await _appService.TimeOffDashboardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-timesheet-from-employee")]
        public async Task<IActionResult> ActionTimesheetFromEmployeeAsync(Guid id)
        {
            var result = await _appService.TimesheetFromEmployeeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-toggle-primary-bank-account-trust")]
        public async Task<IActionResult> ActionTogglePrimaryBankAccountTrustAsync(Guid id)
        {
            var result = await _appService.TogglePrimaryBankAccountTrustAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-unarchive")]
        public async Task<IActionResult> ActionUnarchiveAsync(Guid id)
        {
            var result = await _appService.UnarchiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-unlink-wizard")]
        public async Task<IActionResult> ActionUnlinkWizardAsync(Guid id)
        {
            var result = await _appService.UnlinkWizardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-no-existing-contract")]
        public async Task<IActionResult> CheckNoExistingContractAsync(Guid id, [FromBody] HrEmployeeCheckNoExistingContractRequestDto input)
        {
            var result = await _appService.CheckNoExistingContractAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-contract")]
        public async Task<IActionResult> CreateContractAsync(Guid id, [FromBody] HrEmployeeCreateContractRequestDto input)
        {
            var result = await _appService.CreateContractAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-version")]
        public async Task<IActionResult> CreateVersionAsync(Guid id, [FromBody] HrEmployeeCreateVersionRequestDto input)
        {
            var result = await _appService.CreateVersionAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/fetch")]
        public async Task<IActionResult> FetchAsync(Guid id, [FromBody] HrEmployeeFetchRequestDto input)
        {
            var result = await _appService.FetchAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/generate-random-barcode")]
        public async Task<IActionResult> GenerateRandomBarcodeAsync(Guid id)
        {
            var result = await _appService.GenerateRandomBarcodeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/generate-work-entries")]
        public async Task<IActionResult> GenerateWorkEntriesAsync(Guid id, [FromBody] HrEmployeeGenerateWorkEntriesRequestDto input)
        {
            var result = await _appService.GenerateWorkEntriesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-accounts-with-fixed-allocations")]
        public async Task<IActionResult> GetAccountsWithFixedAllocationsAsync(Guid id)
        {
            var result = await _appService.GetAccountsWithFixedAllocationsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-allocation-requests-amount")]
        public async Task<IActionResult> GetAllocationRequestsAmountAsync(Guid id)
        {
            var result = await _appService.GetAllocationRequestsAmountAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-avatar-card-data")]
        public async Task<IActionResult> GetAvatarCardDataAsync(Guid id, [FromBody] HrEmployeeGetAvatarCardDataRequestDto input)
        {
            var result = await _appService.GetAvatarCardDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-bank-account-salary-allocation")]
        public async Task<IActionResult> GetBankAccountSalaryAllocationAsync(Guid id, [FromBody] HrEmployeeGetBankAccountSalaryAllocationRequestDto input)
        {
            var result = await _appService.GetBankAccountSalaryAllocationAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-barcodes-and-pin-hashed")]
        public async Task<IActionResult> GetBarcodesAndPinHashedAsync(Guid id)
        {
            var result = await _appService.GetBarcodesAndPinHashedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-formview-action")]
        public async Task<IActionResult> GetFormviewActionAsync(Guid id, [FromBody] HrEmployeeGetFormviewActionRequestDto input)
        {
            var result = await _appService.GetFormviewActionAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-formview-id")]
        public async Task<IActionResult> GetFormviewIdAsync(Guid id, [FromBody] HrEmployeeGetFormviewIdRequestDto input)
        {
            var result = await _appService.GetFormviewIdAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync(Guid id)
        {
            var result = await _appService.GetImportTemplatesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-internal-resume-lines")]
        public async Task<IActionResult> GetInternalResumeLinesAsync(Guid id, [FromBody] HrEmployeeGetInternalResumeLinesRequestDto input)
        {
            var result = await _appService.GetInternalResumeLinesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-mandatory-days")]
        public async Task<IActionResult> GetMandatoryDaysAsync(Guid id, [FromBody] HrEmployeeGetMandatoryDaysRequestDto input)
        {
            var result = await _appService.GetMandatoryDaysAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-mandatory-days-data")]
        public async Task<IActionResult> GetMandatoryDaysDataAsync(Guid id, [FromBody] HrEmployeeGetMandatoryDaysDataRequestDto input)
        {
            var result = await _appService.GetMandatoryDaysDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-overtime-data")]
        public async Task<IActionResult> GetOvertimeDataAsync(Guid id, [FromBody] HrEmployeeGetOvertimeDataRequestDto input)
        {
            var result = await _appService.GetOvertimeDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-overtime-data-by-employee")]
        public async Task<IActionResult> GetOvertimeDataByEmployeeAsync(Guid id)
        {
            var result = await _appService.GetOvertimeDataByEmployeeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-presence-server-action-data")]
        public async Task<IActionResult> GetPresenceServerActionDataAsync(Guid id)
        {
            var result = await _appService.GetPresenceServerDataAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-public-holidays-data")]
        public async Task<IActionResult> GetPublicHolidaysDataAsync(Guid id, [FromBody] HrEmployeeGetPublicHolidaysDataRequestDto input)
        {
            var result = await _appService.GetPublicHolidaysDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-remaining-percentage")]
        public async Task<IActionResult> GetRemainingPercentageAsync(Guid id)
        {
            var result = await _appService.GetRemainingPercentageAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-special-days-data")]
        public async Task<IActionResult> GetSpecialDaysDataAsync(Guid id, [FromBody] HrEmployeeGetSpecialDaysDataRequestDto input)
        {
            var result = await _appService.GetSpecialDaysDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-time-off-dashboard-data")]
        public async Task<IActionResult> GetTimeOffDashboardDataAsync(Guid id, [FromBody] HrEmployeeGetTimeOffDashboardDataRequestDto input)
        {
            var result = await _appService.GetTimeOffDashboardDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-view")]
        public async Task<IActionResult> GetViewAsync(Guid id, [FromBody] HrEmployeeGetViewRequestDto input)
        {
            var result = await _appService.GetViewAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-views")]
        public async Task<IActionResult> GetViewsAsync(Guid id, [FromBody] HrEmployeeGetViewsRequestDto input)
        {
            var result = await _appService.GetViewsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/new")]
        public async Task<IActionResult> NewAsync(Guid id, [FromBody] HrEmployeeNewRequestDto input)
        {
            var result = await _appService.NewAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/notify-expiring-contract-work-permit")]
        public async Task<IActionResult> NotifyExpiringContractWorkPermitAsync(Guid id)
        {
            var result = await _appService.NotifyExpiringContractWorkPermitAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-barcode-scanner")]
        public async Task<IActionResult> OpenBarcodeScannerAsync(Guid id)
        {
            var result = await _appService.OpenBarcodeScannerAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/search-fetch")]
        public async Task<IActionResult> SearchFetchAsync(Guid id, [FromBody] HrEmployeeSearchFetchRequestDto input)
        {
            var result = await _appService.SearchFetchAsync(id, input);
            return Ok(result);
        }
    }
}