using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class PosPresetController
    {
        
        [HttpPost]
        [Route("action-open-linked-config")]
        public async Task<IActionResult> ActionOpenLinkedConfigAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenLinkedConfigAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-linked-orders")]
        public async Task<IActionResult> ActionOpenLinkedOrdersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenLinkedOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-available-slots")]
        public async Task<IActionResult> GetAvailableSlotsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetAvailableSlotsAsync(ids);
            return Ok(result);
        }
    }
}