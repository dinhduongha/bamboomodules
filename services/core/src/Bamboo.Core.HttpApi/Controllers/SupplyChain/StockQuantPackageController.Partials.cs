using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockQuantPackageController
    {
        
        [HttpPost]
        [Route("action-view-picking")]
        public async Task<IActionResult> ActionViewPickingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewPickingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unpack")]
        public async Task<IActionResult> UnpackAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnpackAsync(ids);
            return Ok(result);
        }
    }
}