using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Gamification
{
    public partial class GamificationGoalController
    {
        
        [HttpPost]
        [Route("{id}/action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid id)
        {
            var result = await _appService.CancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-fail")]
        public async Task<IActionResult> ActionFailAsync(Guid id)
        {
            var result = await _appService.FailAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-reach")]
        public async Task<IActionResult> ActionReachAsync(Guid id)
        {
            var result = await _appService.ReachAsync(id);
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
        [Route("{id}/get-action")]
        public async Task<IActionResult> GetActionAsync(Guid id)
        {
            var result = await _appService.GetActionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/update-goal")]
        public async Task<IActionResult> UpdateGoalAsync(Guid id)
        {
            var result = await _appService.UpdateGoalAsync(id);
            return Ok(result);
        }
    }
}