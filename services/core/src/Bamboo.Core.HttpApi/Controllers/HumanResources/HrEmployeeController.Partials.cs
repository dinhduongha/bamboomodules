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
        [Route("action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-user")]
        public async Task<IActionResult> ActionCreateUserAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateUserAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-users")]
        public async Task<IActionResult> ActionCreateUsersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateUsersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-users-confirmation")]
        public async Task<IActionResult> ActionCreateUsersConfirmationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateUsersConfirmationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-allocation-wizard")]
        public async Task<IActionResult> ActionOpenAllocationWizardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenAllocationWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-courses")]
        public async Task<IActionResult> ActionOpenCoursesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenCoursesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-employee-cars")]
        public async Task<IActionResult> ActionOpenEmployeeCarsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenEmployeeCarsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-last-month-attendances")]
        public async Task<IActionResult> ActionOpenLastMonthAttendancesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenLastMonthAttendancesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-leave-request")]
        public async Task<IActionResult> ActionOpenLeaveRequestAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenLeaveRequestAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-versions")]
        public async Task<IActionResult> ActionOpenVersionsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenVersionsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-work-entries")]
        public async Task<IActionResult> ActionOpenWorkEntriesAsync(HrEmployeeOpenWorkEntriesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.OpenWorkEntriesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-related-contacts")]
        public async Task<IActionResult> ActionRelatedContactsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RelatedContactsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-log")]
        public async Task<IActionResult> ActionSendLogAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendLogAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-sms")]
        public async Task<IActionResult> ActionSendSmsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendSmsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-absent")]
        public async Task<IActionResult> ActionSetAbsentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetAbsentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-present")]
        public async Task<IActionResult> ActionSetPresentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetPresentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-time-off-dashboard")]
        public async Task<IActionResult> ActionTimeOffDashboardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.TimeOffDashboardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-timesheet-from-employee")]
        public async Task<IActionResult> ActionTimesheetFromEmployeeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.TimesheetFromEmployeeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-toggle-primary-bank-account-trust")]
        public async Task<IActionResult> ActionTogglePrimaryBankAccountTrustAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.TogglePrimaryBankAccountTrustAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unarchive")]
        public async Task<IActionResult> ActionUnarchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnarchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unlink-wizard")]
        public async Task<IActionResult> ActionUnlinkWizardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnlinkWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-no-existing-contract")]
        public async Task<IActionResult> CheckNoExistingContractAsync(HrEmployeeCheckNoExistingContractRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckNoExistingContractAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-contract")]
        public async Task<IActionResult> CreateContractAsync(HrEmployeeCreateContractRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CreateContractAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-version")]
        public async Task<IActionResult> CreateVersionAsync(HrEmployeeCreateVersionRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CreateVersionAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("fetch")]
        public async Task<IActionResult> FetchAsync(HrEmployeeFetchRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FetchAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("generate-random-barcode")]
        public async Task<IActionResult> GenerateRandomBarcodeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GenerateRandomBarcodeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("generate-work-entries")]
        public async Task<IActionResult> GenerateWorkEntriesAsync(HrEmployeeGenerateWorkEntriesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GenerateWorkEntriesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-accounts-with-fixed-allocations")]
        public async Task<IActionResult> GetAccountsWithFixedAllocationsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetAccountsWithFixedAllocationsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-allocation-requests-amount")]
        public async Task<IActionResult> GetAllocationRequestsAmountAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetAllocationRequestsAmountAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-avatar-card-data")]
        public async Task<IActionResult> GetAvatarCardDataAsync(HrEmployeeGetAvatarCardDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetAvatarCardDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-bank-account-salary-allocation")]
        public async Task<IActionResult> GetBankAccountSalaryAllocationAsync(HrEmployeeGetBankAccountSalaryAllocationRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetBankAccountSalaryAllocationAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-barcodes-and-pin-hashed")]
        public async Task<IActionResult> GetBarcodesAndPinHashedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetBarcodesAndPinHashedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-formview-action")]
        public async Task<IActionResult> GetFormviewActionAsync(HrEmployeeGetFormviewActionRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetFormviewActionAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-formview-id")]
        public async Task<IActionResult> GetFormviewIdAsync(HrEmployeeGetFormviewIdRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetFormviewIdAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetImportTemplatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-internal-resume-lines")]
        public async Task<IActionResult> GetInternalResumeLinesAsync(HrEmployeeGetInternalResumeLinesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetInternalResumeLinesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-mandatory-days")]
        public async Task<IActionResult> GetMandatoryDaysAsync(HrEmployeeGetMandatoryDaysRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetMandatoryDaysAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-mandatory-days-data")]
        public async Task<IActionResult> GetMandatoryDaysDataAsync(HrEmployeeGetMandatoryDaysDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetMandatoryDaysDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-overtime-data")]
        public async Task<IActionResult> GetOvertimeDataAsync(HrEmployeeGetOvertimeDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetOvertimeDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-overtime-data-by-employee")]
        public async Task<IActionResult> GetOvertimeDataByEmployeeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetOvertimeDataByEmployeeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-presence-server-action-data")]
        public async Task<IActionResult> GetPresenceServerActionDataAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetPresenceServerDataAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-public-holidays-data")]
        public async Task<IActionResult> GetPublicHolidaysDataAsync(HrEmployeeGetPublicHolidaysDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetPublicHolidaysDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-remaining-percentage")]
        public async Task<IActionResult> GetRemainingPercentageAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetRemainingPercentageAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-special-days-data")]
        public async Task<IActionResult> GetSpecialDaysDataAsync(HrEmployeeGetSpecialDaysDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetSpecialDaysDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-time-off-dashboard-data")]
        public async Task<IActionResult> GetTimeOffDashboardDataAsync(HrEmployeeGetTimeOffDashboardDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetTimeOffDashboardDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-view")]
        public async Task<IActionResult> GetViewAsync(HrEmployeeGetViewRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetViewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-views")]
        public async Task<IActionResult> GetViewsAsync(HrEmployeeGetViewsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetViewsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> NewAsync(HrEmployeeNewRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.NewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("notify-expiring-contract-work-permit")]
        public async Task<IActionResult> NotifyExpiringContractWorkPermitAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.NotifyExpiringContractWorkPermitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-barcode-scanner")]
        public async Task<IActionResult> OpenBarcodeScannerAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenBarcodeScannerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-fetch")]
        public async Task<IActionResult> SearchFetchAsync(HrEmployeeSearchFetchRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SearchFetchAsync(input);
            return Ok(result);
        }
    }
}