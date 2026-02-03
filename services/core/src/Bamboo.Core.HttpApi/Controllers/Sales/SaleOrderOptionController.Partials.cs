using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class SaleOrderOptionController
    {
        
        [HttpPost]
        [Route("add-option-to-order")]
        public async Task<IActionResult> AddOptionToOrderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AddOptionToOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-add-to-order")]
        public async Task<IActionResult> ButtonAddToOrderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonAddToOrderAsync(ids);
            return Ok(result);
        }
    }
}