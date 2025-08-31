using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Lunch
{
    public partial class LunchSupplierController
    {
        
        [HttpPost]
        [Route("{id}/action-confirm-orders")]
        public async Task<IActionResult> ActionConfirmOrdersAsync(Guid id)
        {
            var result = await _appService.ConfirmOrdersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-orders")]
        public async Task<IActionResult> ActionSendOrdersAsync(Guid id)
        {
            var result = await _appService.SendOrdersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveAsync(Guid id)
        {
            var result = await _appService.ToggleActiveAsync(id);
            return Ok(result);
        }
    }
}