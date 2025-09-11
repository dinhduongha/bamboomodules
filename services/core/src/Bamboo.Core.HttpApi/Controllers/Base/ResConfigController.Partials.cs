using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResConfigController
    {
        
        [HttpPost]
        [Route("{id}/action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid id)
        {
            var result = await _appService.CancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-next")]
        public async Task<IActionResult> ActionNextAsync(Guid id)
        {
            var result = await _appService.NextAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-skip")]
        public async Task<IActionResult> ActionSkipAsync(Guid id)
        {
            var result = await _appService.SkipAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/cancel")]
        public async Task<IActionResult> CancelAsync(Guid id)
        {
            var result = await _appService.CancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/execute")]
        public async Task<IActionResult> ExecuteAsync(Guid id)
        {
            var result = await _appService.ExecuteAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/next")]
        public async Task<IActionResult> NextAsync(Guid id)
        {
            var result = await _appService.NextAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/start")]
        public async Task<IActionResult> StartAsync(Guid id)
        {
            var result = await _appService.StartAsync(id);
            return Ok(result);
        }
    }
}