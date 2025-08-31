using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.EventBoothModule
{
    public partial class EventBoothController
    {
        
        [HttpPost]
        [Route("{id}/action-confirm")]
        public async Task<IActionResult> ActionConfirmAsync(Guid id, [FromBody] EventBoothConfirmRequestDto input)
        {
            var result = await _appService.ConfirmAsync(id, input.AdditionalValues);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-paid")]
        public async Task<IActionResult> ActionSetPaidAsync(Guid id)
        {
            var result = await _appService.SetPaidAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-sale-order")]
        public async Task<IActionResult> ActionViewSaleOrderAsync(Guid id)
        {
            var result = await _appService.ViewSaleOrderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-sponsor")]
        public async Task<IActionResult> ActionViewSponsorAsync(Guid id)
        {
            var result = await _appService.ViewSponsorAsync(id);
            return Ok(result);
        }
    }
}