using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Hr
{
    public partial class HrEmployeeController
    {
        
        [HttpPost]
        [Route("{id}/action-create-user")]
        public async Task<IActionResult> ActionCreateUserAsync(Guid id)
        {
            var result = await _appService.CreateUserAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-contract")]
        public async Task<IActionResult> ActionOpenContractAsync(Guid id)
        {
            var result = await _appService.OpenContractAsync(id);
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
        [Route("{id}/action-open-last-month-overtime")]
        public async Task<IActionResult> ActionOpenLastMonthOvertimeAsync(Guid id)
        {
            var result = await _appService.OpenLastMonthOvertimeAsync(id);
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
        [Route("{id}/action-unlink-wizard")]
        public async Task<IActionResult> ActionUnlinkWizardAsync(Guid id)
        {
            var result = await _appService.UnlinkWizardAsync(id);
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
        [Route("{id}/get-allocation-requests-amount")]
        public async Task<IActionResult> GetAllocationRequestsAmountAsync(Guid id)
        {
            var result = await _appService.GetAllocationRequestsAmountAsync(id);
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
        [Route("{id}/get-public-holidays-data")]
        public async Task<IActionResult> GetPublicHolidaysDataAsync(Guid id, [FromBody] HrEmployeeGetPublicHolidaysDataRequestDto input)
        {
            var result = await _appService.GetPublicHolidaysDataAsync(id, input);
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
        [Route("{id}/search-fetch")]
        public async Task<IActionResult> SearchFetchAsync(Guid id, [FromBody] HrEmployeeSearchFetchRequestDto input)
        {
            var result = await _appService.SearchFetchAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveAsync(Guid id)
        {
            var result = await _appService.ToggleActiveAsync(id);
            return Ok(result);
        }
    }
}