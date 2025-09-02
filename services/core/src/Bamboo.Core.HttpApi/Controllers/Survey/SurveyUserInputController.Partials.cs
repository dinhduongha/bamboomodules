using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Survey
{
    public partial class SurveyUserInputController
    {
        
        [HttpPost]
        [Route("{id}/action-print-answers")]
        public async Task<IActionResult> ActionPrintAnswersAsync(Guid id)
        {
            var result = await _appService.PrintAnswersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-redirect-to-attempts")]
        public async Task<IActionResult> ActionRedirectToAttemptsAsync(Guid id)
        {
            var result = await _appService.RedirectToAttemptsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-resend")]
        public async Task<IActionResult> ActionResendAsync(Guid id)
        {
            var result = await _appService.ResendAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-print-url")]
        public async Task<IActionResult> GetPrintUrlAsync(Guid id)
        {
            var result = await _appService.GetPrintUrlAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-start-url")]
        public async Task<IActionResult> GetStartUrlAsync(Guid id)
        {
            var result = await _appService.GetStartUrlAsync(id);
            return Ok(result);
        }
    }
}