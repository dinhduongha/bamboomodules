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
        [Route("{id}/action-create-application")]
        public async Task<IActionResult> ActionCreateApplicationAsync(Guid id)
        {
            var result = await _appService.CreateApplicationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-create-meeting")]
        public async Task<IActionResult> ActionCreateMeetingAsync(Guid id)
        {
            var result = await _appService.CreateMeetingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-applications")]
        public async Task<IActionResult> ActionOpenApplicationsAsync(Guid id)
        {
            var result = await _appService.OpenApplicationsAsync(id);
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
        [Route("{id}/action-open-similar-candidates")]
        public async Task<IActionResult> ActionOpenSimilarCandidatesAsync(Guid id)
        {
            var result = await _appService.OpenSimilarCandidatesAsync(id);
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
        [Route("{id}/create-employee-from-candidate")]
        public async Task<IActionResult> CreateEmployeeFromCandidateAsync(Guid id)
        {
            var result = await _appService.CreateEmployeeFromCandidateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
    }
}