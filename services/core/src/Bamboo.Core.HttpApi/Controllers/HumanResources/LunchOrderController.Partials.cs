using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class LunchOrderController
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
        [Route("action-confirm")]
        public async Task<IActionResult> ActionConfirmAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ConfirmAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-notify")]
        public async Task<IActionResult> ActionNotifyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.NotifyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-order")]
        public async Task<IActionResult> ActionOrderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reorder")]
        public async Task<IActionResult> ActionReorderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ReorderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reset")]
        public async Task<IActionResult> ActionResetAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ResetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send")]
        public async Task<IActionResult> ActionSendAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("add-to-cart")]
        public async Task<IActionResult> AddToCartAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AddToCartAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-quantity")]
        public async Task<IActionResult> UpdateQuantityAsync(LunchOrderUpdateQuantityRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.UpdateQuantityAsync(input);
            return Ok(result);
        }
    }
}