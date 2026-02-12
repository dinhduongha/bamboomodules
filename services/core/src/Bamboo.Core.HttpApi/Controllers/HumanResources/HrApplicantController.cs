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
    [Route("api/v1/human-resources/HrApplicant")]
    public partial class HrApplicantController : AbpController
    {
        protected readonly IHrApplicantAppService _appService;
        public HrApplicantController(IHrApplicantAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-add-to-job")]
        public async Task<IActionResult> AddToJobAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddToJobAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ArchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-meeting")]
        public async Task<IActionResult> CreateMeetingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateMeetingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-job-add-applicants")]
        public async Task<IActionResult> JobAddApplicantsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.JobAddApplicantsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-applications")]
        public async Task<IActionResult> OpenApplicationsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenApplicationsAsync(ids);
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
        [Route("action-open-employee")]
        public async Task<IActionResult> OpenEmployeeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenEmployeeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-print-survey")]
        public async Task<IActionResult> PrintSurveyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PrintSurveyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-email")]
        public async Task<IActionResult> SendEmailAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendEmailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-sms")]
        public async Task<IActionResult> SendSmsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendSmsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-survey")]
        public async Task<IActionResult> SendSurveyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendSurveyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-talent-pool-add-applicants")]
        public async Task<IActionResult> TalentPoolAddApplicantsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.TalentPoolAddApplicantsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-talent-pool-stat-button")]
        public async Task<IActionResult> TalentPoolStatButtonAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.TalentPoolStatButtonAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unarchive")]
        public async Task<IActionResult> UnarchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnarchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("archive-applicant")]
        public async Task<IActionResult> ArchiveApplicantAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ArchiveApplicantAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] HrApplicantCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-employee-from-applicant")]
        public async Task<IActionResult> CreateEmployeeFromApplicantAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateEmployeeFromApplicantAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync([FromBody] HrApplicantGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-view")]
        public async Task<IActionResult> GetViewAsync([FromBody] HrApplicantGetViewRequestDto input)
        {
            var result = await _appService.GetViewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("link-applicant-to-talent")]
        public async Task<IActionResult> LinkApplicantToTalentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.LinkApplicantToTalentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-new")]
        public async Task<IActionResult> MessageNewAsync([FromBody] HrApplicantMessageNewRequestDto input)
        {
            var result = await _appService.MessageNewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("reset-applicant")]
        public async Task<IActionResult> ResetApplicantAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ResetApplicantAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("website-form-input-filter")]
        public async Task<IActionResult> WebsiteFormInputFilterAsync([FromBody] HrApplicantWebsiteFormInputFilterRequestDto input)
        {
            var result = await _appService.WebsiteFormInputFilterAsync(input);
            return Ok(result);
        }
    }
    
}