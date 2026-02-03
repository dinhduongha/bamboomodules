using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class LoyaltyCardController
    {
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-coupon-send")]
        public async Task<IActionResult> ActionCouponSendAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CouponSendAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-coupon-share")]
        public async Task<IActionResult> ActionCouponShareAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CouponShareAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-loyalty-update-balance")]
        public async Task<IActionResult> ActionLoyaltyUpdateBalanceAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.LoyaltyUpdateBalanceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-gift-card-status")]
        public async Task<IActionResult> GetGiftCardStatusAsync(LoyaltyCardGetGiftCardStatusRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetGiftCardStatusAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-loyalty-card-partner-by-code")]
        public async Task<IActionResult> GetLoyaltyCardPartnerByCodeAsync(LoyaltyCardGetLoyaltyCardPartnerByCodeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetLoyaltyCardPartnerByCodeAsync(input);
            return Ok(result);
        }
    }
}