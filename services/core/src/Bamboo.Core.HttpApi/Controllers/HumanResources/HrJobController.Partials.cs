using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrJobController
    {
        
        [HttpPost]
        [Route("{id}/action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid id)
        {
            var result = await _appService.ArchiveAsync(id);
            return Ok(result);
        }
        
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
        [Route("{id}/action-open-employees")]
        public async Task<IActionResult> ActionOpenEmployeesAsync(Guid id)
        {
            var result = await _appService.OpenEmployeesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-search-matching-applicants")]
        public async Task<IActionResult> ActionSearchMatchingApplicantsAsync(Guid id)
        {
            var result = await _appService.SearchMatchingApplicantsAsync(id);
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
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] HrJobCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
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
    }
}