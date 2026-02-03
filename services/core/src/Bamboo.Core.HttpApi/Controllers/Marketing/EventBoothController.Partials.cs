using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class EventBoothController
    {
        
        [HttpPost]
        [Route("action-confirm")]
        public async Task<IActionResult> ActionConfirmAsync(EventBoothConfirmRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ConfirmAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-paid")]
        public async Task<IActionResult> ActionSetPaidAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetPaidAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sale-order")]
        public async Task<IActionResult> ActionViewSaleOrderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSaleOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sponsor")]
        public async Task<IActionResult> ActionViewSponsorAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSponsorAsync(ids);
            return Ok(result);
        }
    }
}