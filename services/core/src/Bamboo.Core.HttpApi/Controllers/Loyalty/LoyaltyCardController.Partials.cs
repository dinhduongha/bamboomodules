using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Loyalty
{
    public partial class LoyaltyCardController
    {
        
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
    }
}