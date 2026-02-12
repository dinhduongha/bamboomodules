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
    [Route("api/v1/marketing/EventRegistration")]
    public partial class EventRegistrationController : AbpController
    {
        protected readonly IEventRegistrationAppService _appService;
        public EventRegistrationController(IEventRegistrationAppService appService) { _appService = appService; }
        
        
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
        [Route("action-send-badge-email")]
        public async Task<IActionResult> SendBadgeEmailAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendBadgeEmailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-done")]
        public async Task<IActionResult> SetDoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-draft")]
        public async Task<IActionResult> SetDraftAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetDraftAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-pos-order")]
        public async Task<IActionResult> ViewPosOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewPosOrderAsync(ids);
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
        [Route("register-attendee")]
        public async Task<IActionResult> RegisterAttendeeAsync([FromBody] EventRegistrationRegisterAttendeeRequestDto input)
        {
            var result = await _appService.RegisterAttendeeAsync(input);
            return Ok(result);
        }
    }
    
}