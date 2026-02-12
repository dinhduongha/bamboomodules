using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/human-resources/LunchOrder")]
    public partial class LunchOrderController : AbpController
    {
        protected readonly ILunchOrderAppService _appService;
        public LunchOrderController(ILunchOrderAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-cancel")]
        public async Task<IActionResult> CancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-confirm")]
        public async Task<IActionResult> ConfirmAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ConfirmAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-notify")]
        public async Task<IActionResult> NotifyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.NotifyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-order")]
        public async Task<IActionResult> OrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reorder")]
        public async Task<IActionResult> ReorderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ReorderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reset")]
        public async Task<IActionResult> ResetAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ResetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send")]
        public async Task<IActionResult> SendAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("add-to-cart")]
        public async Task<IActionResult> AddToCartAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddToCartAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-quantity")]
        public async Task<IActionResult> UpdateQuantityAsync([FromBody] LunchOrderUpdateQuantityRequestDto input)
        {
            var result = await _appService.UpdateQuantityAsync(input);
            return Ok(result);
        }
    }
    
}