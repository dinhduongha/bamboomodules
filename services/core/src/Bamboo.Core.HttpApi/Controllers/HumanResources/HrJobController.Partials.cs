using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrJobController
    {
        
        [HttpPost]
        [Route("{id}/action-new-survey")]
        public async Task<IActionResult> ActionNewSurveyAsync(Guid id)
        {
            var result = await _appService.NewSurveyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-activities")]
        public async Task<IActionResult> ActionOpenActivitiesAsync(Guid id)
        {
            var result = await _appService.OpenActivitiesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-attachments")]
        public async Task<IActionResult> ActionOpenAttachmentsAsync(Guid id)
        {
            var result = await _appService.OpenAttachmentsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-late-activities")]
        public async Task<IActionResult> ActionOpenLateActivitiesAsync(Guid id)
        {
            var result = await _appService.OpenLateActivitiesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-today-activities")]
        public async Task<IActionResult> ActionOpenTodayActivitiesAsync(Guid id)
        {
            var result = await _appService.OpenTodayActivitiesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-search-matching-candidates")]
        public async Task<IActionResult> ActionSearchMatchingCandidatesAsync(Guid id)
        {
            var result = await _appService.SearchMatchingCandidatesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-test-survey")]
        public async Task<IActionResult> ActionTestSurveyAsync(Guid id)
        {
            var result = await _appService.TestSurveyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/close-dialog")]
        public async Task<IActionResult> CloseDialogAsync(Guid id)
        {
            var result = await _appService.CloseDialogAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] HrJobCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/edit-dialog")]
        public async Task<IActionResult> EditDialogAsync(Guid id)
        {
            var result = await _appService.EditDialogAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-backend-menu-id")]
        public async Task<IActionResult> GetBackendMenuIdAsync(Guid id)
        {
            var result = await _appService.GetBackendMenuIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-open")]
        public async Task<IActionResult> SetOpenAsync(Guid id)
        {
            var result = await _appService.SetOpenAsync(id);
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