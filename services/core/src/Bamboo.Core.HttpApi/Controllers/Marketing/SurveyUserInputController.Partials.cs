using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class SurveyUserInputController
    {
        
        [HttpPost]
        [Route("action-print-answers")]
        public async Task<IActionResult> ActionPrintAnswersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PrintAnswersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-lead")]
        public async Task<IActionResult> ActionRedirectLeadAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectLeadAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-attempts")]
        public async Task<IActionResult> ActionRedirectToAttemptsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectToAttemptsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-resend")]
        public async Task<IActionResult> ActionResendAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ResendAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-print-url")]
        public async Task<IActionResult> GetPrintUrlAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetPrintUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-start-url")]
        public async Task<IActionResult> GetStartUrlAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetStartUrlAsync(ids);
            return Ok(result);
        }
    }
}