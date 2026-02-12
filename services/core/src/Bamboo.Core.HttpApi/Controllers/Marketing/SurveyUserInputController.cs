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
    [Route("api/v1/marketing/SurveyUserInput")]
    public partial class SurveyUserInputController : AbpController
    {
        protected readonly ISurveyUserInputAppService _appService;
        public SurveyUserInputController(ISurveyUserInputAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-print-answers")]
        public async Task<IActionResult> PrintAnswersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PrintAnswersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-lead")]
        public async Task<IActionResult> RedirectLeadAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RedirectLeadAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-attempts")]
        public async Task<IActionResult> RedirectToAttemptsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RedirectToAttemptsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-resend")]
        public async Task<IActionResult> ResendAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ResendAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-print-url")]
        public async Task<IActionResult> GetPrintUrlAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetPrintUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-start-url")]
        public async Task<IActionResult> GetStartUrlAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetStartUrlAsync(ids);
            return Ok(result);
        }
    }
    
}