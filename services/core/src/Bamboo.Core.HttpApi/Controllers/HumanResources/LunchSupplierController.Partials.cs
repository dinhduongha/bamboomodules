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
    }
}