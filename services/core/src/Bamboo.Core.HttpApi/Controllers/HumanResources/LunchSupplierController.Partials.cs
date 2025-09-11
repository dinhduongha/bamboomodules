using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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