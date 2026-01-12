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
        [Route("{id}/action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid id)
        {
            var result = await _appService.ArchiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-coupon-send")]
        public async Task<IActionResult> ActionCouponSendAsync(Guid id)
        {
            var result = await _appService.CouponSendAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-coupon-share")]
        public async Task<IActionResult> ActionCouponShareAsync(Guid id)
        {
            var result = await _appService.CouponShareAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-loyalty-update-balance")]
        public async Task<IActionResult> ActionLoyaltyUpdateBalanceAsync(Guid id)
        {
            var result = await _appService.LoyaltyUpdateBalanceAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-gift-card-status")]
        public async Task<IActionResult> GetGiftCardStatusAsync(Guid id, [FromBody] LoyaltyCardGetGiftCardStatusRequestDto input)
        {
            var result = await _appService.GetGiftCardStatusAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-loyalty-card-partner-by-code")]
        public async Task<IActionResult> GetLoyaltyCardPartnerByCodeAsync(Guid id, [FromBody] LoyaltyCardGetLoyaltyCardPartnerByCodeRequestDto input)
        {
            var result = await _appService.GetLoyaltyCardPartnerByCodeAsync(id, input);
            return Ok(result);
        }
    }
}