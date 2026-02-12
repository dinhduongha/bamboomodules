using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/human-resources/HrJob")]
    public partial class HrJobController : AbpController
    {
        protected readonly IHrJobAppService _appService;
        public HrJobController(IHrJobAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ArchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-new-survey")]
        public async Task<IActionResult> NewSurveyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.NewSurveyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-activities")]
        public async Task<IActionResult> OpenActivitiesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenActivitiesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-attachments")]
        public async Task<IActionResult> OpenAttachmentsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenAttachmentsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-employees")]
        public async Task<IActionResult> OpenEmployeesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenEmployeesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-search-matching-applicants")]
        public async Task<IActionResult> SearchMatchingApplicantsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SearchMatchingApplicantsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-test-survey")]
        public async Task<IActionResult> TestSurveyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.TestSurveyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] HrJobCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-backend-menu-id")]
        public async Task<IActionResult> GetBackendMenuIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetBackendMenuIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-open")]
        public async Task<IActionResult> SetOpenAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetOpenAsync(ids);
            return Ok(result);
        }
    }
    
}