using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Event
{
    public partial class EventRegistrationController
    {
        
        [HttpPost]
        [Route("{id}/action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid id)
        {
            var result = await _appService.CancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-confirm")]
        public async Task<IActionResult> ActionConfirmAsync(Guid id)
        {
            var result = await _appService.ConfirmAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-send-badge-email")]
        public async Task<IActionResult> ActionSendBadgeEmailAsync(Guid id)
        {
            var result = await _appService.SendBadgeEmailAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-done")]
        public async Task<IActionResult> ActionSetDoneAsync(Guid id)
        {
            var result = await _appService.SetDoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-draft")]
        public async Task<IActionResult> ActionSetDraftAsync(Guid id)
        {
            var result = await _appService.SetDraftAsync(id);
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
        [Route("{id}/register-attendee")]
        public async Task<IActionResult> RegisterAttendeeAsync(Guid id, [FromBody] EventRegistrationRegisterAttendeeRequestDto input)
        {
            var result = await _appService.RegisterAttendeeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveAsync(Guid id)
        {
            var result = await _appService.ToggleActiveAsync(id);
            return Ok(result);
        }
    }
}