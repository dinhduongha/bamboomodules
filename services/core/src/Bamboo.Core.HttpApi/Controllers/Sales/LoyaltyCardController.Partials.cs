using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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