using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockPackageController
    {
        
        [HttpPost]
        [Route("action-add-to-picking")]
        public async Task<IActionResult> ActionAddToPickingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AddToPickingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-put-in-pack")]
        public async Task<IActionResult> ActionPutInPackAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PutInPackAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-remove-package")]
        public async Task<IActionResult> ActionRemovePackageAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RemovePackageAsync(ids);
            return Ok(result);
        }
        
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