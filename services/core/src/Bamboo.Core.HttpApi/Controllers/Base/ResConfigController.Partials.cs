using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResConfigController
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
        [Route("action-next")]
        public async Task<IActionResult> ActionNextAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.NextAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-skip")]
        public async Task<IActionResult> ActionSkipAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SkipAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("cancel")]
        public async Task<IActionResult> CancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("execute")]
        public async Task<IActionResult> ExecuteAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ExecuteAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("next")]
        public async Task<IActionResult> NextAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.NextAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("start")]
        public async Task<IActionResult> StartAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.StartAsync(ids);
            return Ok(result);
        }
    }
}