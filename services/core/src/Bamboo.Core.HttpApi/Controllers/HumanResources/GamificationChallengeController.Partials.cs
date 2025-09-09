using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Gamification
{
    public partial class GamificationChallengeController
    {
        
        [HttpPost]
        [Route("{id}/accept-challenge")]
        public async Task<IActionResult> AcceptChallengeAsync(Guid id)
        {
            var result = await _appService.AcceptChallengeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-check")]
        public async Task<IActionResult> ActionCheckAsync(Guid id)
        {
            var result = await _appService.CheckAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-report-progress")]
        public async Task<IActionResult> ActionReportProgressAsync(Guid id)
        {
            var result = await _appService.ReportProgressAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-start")]
        public async Task<IActionResult> ActionStartAsync(Guid id)
        {
            var result = await _appService.StartAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-users")]
        public async Task<IActionResult> ActionViewUsersAsync(Guid id)
        {
            var result = await _appService.ViewUsersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/discard-challenge")]
        public async Task<IActionResult> DiscardChallengeAsync(Guid id)
        {
            var result = await _appService.DiscardChallengeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/report-progress")]
        public async Task<IActionResult> ReportProgressAsync(Guid id, [FromBody] GamificationChallengeReportProgressRequestDto input)
        {
            var result = await _appService.ReportProgressAsync(id, input);
            return Ok(result);
        }
    }
}