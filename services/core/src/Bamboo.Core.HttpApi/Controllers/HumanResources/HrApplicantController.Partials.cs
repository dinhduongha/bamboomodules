using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrApplicantController
    {
        
        [HttpPost]
        [Route("{id}/action-create-meeting")]
        public async Task<IActionResult> ActionCreateMeetingAsync(Guid id)
        {
            var result = await _appService.CreateMeetingAsync(id);
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
        [Route("{id}/action-open-employee")]
        public async Task<IActionResult> ActionOpenEmployeeAsync(Guid id)
        {
            var result = await _appService.OpenEmployeeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-other-applications")]
        public async Task<IActionResult> ActionOpenOtherApplicationsAsync(Guid id)
        {
            var result = await _appService.OpenOtherApplicationsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-print-survey")]
        public async Task<IActionResult> ActionPrintSurveyAsync(Guid id)
        {
            var result = await _appService.PrintSurveyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-email")]
        public async Task<IActionResult> ActionSendEmailAsync(Guid id)
        {
            var result = await _appService.SendEmailAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-survey")]
        public async Task<IActionResult> ActionSendSurveyAsync(Guid id)
        {
            var result = await _appService.SendSurveyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/archive-applicant")]
        public async Task<IActionResult> ArchiveApplicantAsync(Guid id)
        {
            var result = await _appService.ArchiveApplicantAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-employee-from-applicant")]
        public async Task<IActionResult> CreateEmployeeFromApplicantAsync(Guid id)
        {
            var result = await _appService.CreateEmployeeFromApplicantAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync(Guid id, [FromBody] HrApplicantGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-view")]
        public async Task<IActionResult> GetViewAsync(Guid id, [FromBody] HrApplicantGetViewRequestDto input)
        {
            var result = await _appService.GetViewAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-new")]
        public async Task<IActionResult> MessageNewAsync(Guid id, [FromBody] HrApplicantMessageNewRequestDto input)
        {
            var result = await _appService.MessageNewAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/reset-applicant")]
        public async Task<IActionResult> ResetApplicantAsync(Guid id)
        {
            var result = await _appService.ResetApplicantAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveAsync(Guid id)
        {
            var result = await _appService.ToggleActiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/website-form-input-filter")]
        public async Task<IActionResult> WebsiteFormInputFilterAsync(Guid id, [FromBody] HrApplicantWebsiteFormInputFilterRequestDto input)
        {
            var result = await _appService.WebsiteFormInputFilterAsync(id, input);
            return Ok(result);
        }
    }
}