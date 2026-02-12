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
    [Route("api/v1/sales/LoyaltyCard")]
    public partial class LoyaltyCardController : AbpController
    {
        protected readonly ILoyaltyCardAppService _appService;
        public LoyaltyCardController(ILoyaltyCardAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ArchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-coupon-send")]
        public async Task<IActionResult> CouponSendAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CouponSendAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-coupon-share")]
        public async Task<IActionResult> CouponShareAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CouponShareAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-loyalty-update-balance")]
        public async Task<IActionResult> LoyaltyUpdateBalanceAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.LoyaltyUpdateBalanceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-gift-card-status")]
        public async Task<IActionResult> GetGiftCardStatusAsync([FromBody] LoyaltyCardGetGiftCardStatusRequestDto input)
        {
            var result = await _appService.GetGiftCardStatusAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-loyalty-card-partner-by-code")]
        public async Task<IActionResult> GetLoyaltyCardPartnerByCodeAsync([FromBody] LoyaltyCardGetLoyaltyCardPartnerByCodeRequestDto input)
        {
            var result = await _appService.GetLoyaltyCardPartnerByCodeAsync(input);
            return Ok(result);
        }
    }
    
}