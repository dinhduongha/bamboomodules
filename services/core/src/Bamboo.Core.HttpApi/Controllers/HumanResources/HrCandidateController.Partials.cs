using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrCandidateController
    {
        
        [HttpPost]
        [Route("action-create-application")]
        public async Task<IActionResult> ActionCreateApplicationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateApplicationAsync(ids);
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
        [Route("action-open-similar-candidates")]
        public async Task<IActionResult> ActionOpenSimilarCandidatesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenSimilarCandidatesAsync(ids);
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
        [Route("create-employee-from-candidate")]
        public async Task<IActionResult> CreateEmployeeFromCandidateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateEmployeeFromCandidateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
    }
}