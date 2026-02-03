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
        [Route("action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-new-survey")]
        public async Task<IActionResult> ActionNewSurveyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.NewSurveyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-activities")]
        public async Task<IActionResult> ActionOpenActivitiesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenActivitiesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-attachments")]
        public async Task<IActionResult> ActionOpenAttachmentsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenAttachmentsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-employees")]
        public async Task<IActionResult> ActionOpenEmployeesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenEmployeesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-search-matching-applicants")]
        public async Task<IActionResult> ActionSearchMatchingApplicantsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SearchMatchingApplicantsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-test-survey")]
        public async Task<IActionResult> ActionTestSurveyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.TestSurveyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(HrJobCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-backend-menu-id")]
        public async Task<IActionResult> GetBackendMenuIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetBackendMenuIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-open")]
        public async Task<IActionResult> SetOpenAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetOpenAsync(ids);
            return Ok(result);
        }
    }
}