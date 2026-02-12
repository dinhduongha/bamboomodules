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
    [Route("api/v1/human-resources/HrCandidate")]
    public partial class HrCandidateController : AbpController
    {
        protected readonly IHrCandidateAppService _appService;
        public HrCandidateController(IHrCandidateAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-create-application")]
        public async Task<IActionResult> CreateApplicationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateApplicationAsync(ids);
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
        [Route("action-open-similar-candidates")]
        public async Task<IActionResult> OpenSimilarCandidatesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenSimilarCandidatesAsync(ids);
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
        [Route("create-employee-from-candidate")]
        public async Task<IActionResult> CreateEmployeeFromCandidateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateEmployeeFromCandidateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
    }
    
}