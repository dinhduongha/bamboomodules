using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class LunchSupplierController
    {
        
        [HttpPost]
        [Route("action-confirm-orders")]
        public async Task<IActionResult> ActionConfirmOrdersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ConfirmOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-orders")]
        public async Task<IActionResult> ActionSendOrdersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendOrdersAsync(ids);
            return Ok(result);
        }
    }
}