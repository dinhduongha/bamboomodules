using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class EventRegistrationController
    {
        
        [HttpPost]
        [Route("action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-confirm")]
        public async Task<IActionResult> ActionConfirmAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ConfirmAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-badge-email")]
        public async Task<IActionResult> ActionSendBadgeEmailAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendBadgeEmailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-done")]
        public async Task<IActionResult> ActionSetDoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-draft")]
        public async Task<IActionResult> ActionSetDraftAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetDraftAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-pos-order")]
        public async Task<IActionResult> ActionViewPosOrderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewPosOrderAsync(ids);
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
        [Route("register-attendee")]
        public async Task<IActionResult> RegisterAttendeeAsync(EventRegistrationRegisterAttendeeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RegisterAttendeeAsync(input);
            return Ok(result);
        }
    }
}