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
    [Route("api/v1/human-resources/GamificationGoal")]
    public partial class GamificationGoalController : AbpController
    {
        protected readonly IGamificationGoalAppService _appService;
        public GamificationGoalController(IGamificationGoalAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-cancel")]
        public async Task<IActionResult> CancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-fail")]
        public async Task<IActionResult> FailAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.FailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reach")]
        public async Task<IActionResult> ReachAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ReachAsync(ids);
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
        [Route("get-action")]
        public async Task<IActionResult> GetActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-goal")]
        public async Task<IActionResult> UpdateGoalAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UpdateGoalAsync(ids);
            return Ok(result);
        }
    }
    
}