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
    [Route("api/v1/marketing/EventBooth")]
    public partial class EventBoothController : AbpController
    {
        protected readonly IEventBoothAppService _appService;
        public EventBoothController(IEventBoothAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-confirm")]
        public async Task<IActionResult> ConfirmAsync([FromBody] EventBoothConfirmRequestDto input)
        {
            var result = await _appService.ConfirmAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-paid")]
        public async Task<IActionResult> SetPaidAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetPaidAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sale-order")]
        public async Task<IActionResult> ViewSaleOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSaleOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sponsor")]
        public async Task<IActionResult> ViewSponsorAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSponsorAsync(ids);
            return Ok(result);
        }
    }
    
}