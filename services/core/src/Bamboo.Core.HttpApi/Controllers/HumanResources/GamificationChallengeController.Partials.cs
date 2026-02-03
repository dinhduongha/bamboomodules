using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class GamificationChallengeController
    {
        
        [HttpPost]
        [Route("accept-challenge")]
        public async Task<IActionResult> AcceptChallengeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AcceptChallengeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-check")]
        public async Task<IActionResult> ActionCheckAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-report-progress")]
        public async Task<IActionResult> ActionReportProgressAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ReportProgressAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-start")]
        public async Task<IActionResult> ActionStartAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.StartAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-users")]
        public async Task<IActionResult> ActionViewUsersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewUsersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("discard-challenge")]
        public async Task<IActionResult> DiscardChallengeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DiscardChallengeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("report-progress")]
        public async Task<IActionResult> ReportProgressAsync(GamificationChallengeReportProgressRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ReportProgressAsync(input);
            return Ok(result);
        }
    }
}