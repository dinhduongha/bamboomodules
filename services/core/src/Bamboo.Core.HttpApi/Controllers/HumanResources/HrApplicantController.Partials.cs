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
        [Route("action-add-to-job")]
        public async Task<IActionResult> ActionAddToJobAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AddToJobAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-meeting")]
        public async Task<IActionResult> ActionCreateMeetingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateMeetingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-job-add-applicants")]
        public async Task<IActionResult> ActionJobAddApplicantsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.JobAddApplicantsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-applications")]
        public async Task<IActionResult> ActionOpenApplicationsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenApplicationsAsync(ids);
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
        [Route("action-open-employee")]
        public async Task<IActionResult> ActionOpenEmployeeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenEmployeeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-print-survey")]
        public async Task<IActionResult> ActionPrintSurveyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PrintSurveyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-email")]
        public async Task<IActionResult> ActionSendEmailAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendEmailAsync(ids);
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
        [Route("action-send-survey")]
        public async Task<IActionResult> ActionSendSurveyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendSurveyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-talent-pool-add-applicants")]
        public async Task<IActionResult> ActionTalentPoolAddApplicantsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.TalentPoolAddApplicantsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-talent-pool-stat-button")]
        public async Task<IActionResult> ActionTalentPoolStatButtonAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.TalentPoolStatButtonAsync(ids);
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
        [Route("archive-applicant")]
        public async Task<IActionResult> ArchiveApplicantAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ArchiveApplicantAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(HrApplicantCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-employee-from-applicant")]
        public async Task<IActionResult> CreateEmployeeFromApplicantAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateEmployeeFromApplicantAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync(HrApplicantGetEmptyListHelpRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetEmptyListHelpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-view")]
        public async Task<IActionResult> GetViewAsync(HrApplicantGetViewRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetViewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("link-applicant-to-talent")]
        public async Task<IActionResult> LinkApplicantToTalentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.LinkApplicantToTalentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-new")]
        public async Task<IActionResult> MessageNewAsync(HrApplicantMessageNewRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MessageNewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("reset-applicant")]
        public async Task<IActionResult> ResetApplicantAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ResetApplicantAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("website-form-input-filter")]
        public async Task<IActionResult> WebsiteFormInputFilterAsync(HrApplicantWebsiteFormInputFilterRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.WebsiteFormInputFilterAsync(input);
            return Ok(result);
        }
    }
}