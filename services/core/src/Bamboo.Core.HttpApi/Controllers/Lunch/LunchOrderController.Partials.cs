using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Lunch
{
    public partial class LunchOrderController
    {
        
        [HttpPost]
        [Route("{id}/action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid id)
        {
            var result = await _appService.CancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-confirm")]
        public async Task<IActionResult> ActionConfirmAsync(Guid id)
        {
            var result = await _appService.ConfirmAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-notify")]
        public async Task<IActionResult> ActionNotifyAsync(Guid id)
        {
            var result = await _appService.NotifyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-order")]
        public async Task<IActionResult> ActionOrderAsync(Guid id)
        {
            var result = await _appService.OrderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-reorder")]
        public async Task<IActionResult> ActionReorderAsync(Guid id)
        {
            var result = await _appService.ReorderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-reset")]
        public async Task<IActionResult> ActionResetAsync(Guid id)
        {
            var result = await _appService.ResetAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send")]
        public async Task<IActionResult> ActionSendAsync(Guid id)
        {
            var result = await _appService.SendAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/add-to-cart")]
        public async Task<IActionResult> AddToCartAsync(Guid id)
        {
            var result = await _appService.AddToCartAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/update-quantity")]
        public async Task<IActionResult> UpdateQuantityAsync(Guid id, [FromBody] LunchOrderUpdateQuantityRequestDto input)
        {
            var result = await _appService.UpdateQuantityAsync(id, input.Increment);
            return Ok(result);
        }
    }
}