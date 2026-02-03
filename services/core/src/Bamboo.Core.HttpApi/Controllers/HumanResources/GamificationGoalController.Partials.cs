using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class GamificationGoalController
    {
        
        [HttpPost]
        [Route("action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-fail")]
        public async Task<IActionResult> ActionFailAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.FailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reach")]
        public async Task<IActionResult> ActionReachAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ReachAsync(ids);
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
        [Route("get-action")]
        public async Task<IActionResult> GetActionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-goal")]
        public async Task<IActionResult> UpdateGoalAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UpdateGoalAsync(ids);
            return Ok(result);
        }
    }
}