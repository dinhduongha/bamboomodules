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
    [Route("api/v1/human-resources/GamificationChallenge")]
    public partial class GamificationChallengeController : AbpController
    {
        protected readonly IGamificationChallengeAppService _appService;
        public GamificationChallengeController(IGamificationChallengeAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("accept-challenge")]
        public async Task<IActionResult> AcceptChallengeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AcceptChallengeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-check")]
        public async Task<IActionResult> CheckAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-report-progress")]
        public async Task<IActionResult> ReportProgressAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ReportProgressAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-start")]
        public async Task<IActionResult> StartAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.StartAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-users")]
        public async Task<IActionResult> ViewUsersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewUsersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("discard-challenge")]
        public async Task<IActionResult> DiscardChallengeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DiscardChallengeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("report-progress")]
        public async Task<IActionResult> ReportProgressAsync([FromBody] GamificationChallengeReportProgressRequestDto input)
        {
            var result = await _appService.ReportProgressAsync(input);
            return Ok(result);
        }
    }
    
}