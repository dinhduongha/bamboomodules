using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class CalendarEventController
    {
        
        [HttpPost]
        [Route("action-join-meeting")]
        public async Task<IActionResult> ActionJoinMeetingAsync(CalendarEventJoinMeetingRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.JoinMeetingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-join-video-call")]
        public async Task<IActionResult> ActionJoinVideoCallAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.JoinVideoCallAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-mass-archive")]
        public async Task<IActionResult> ActionMassArchiveAsync(CalendarEventMassArchiveRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MassArchiveAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-mass-deletion")]
        public async Task<IActionResult> ActionMassDeletionAsync(CalendarEventMassDeletionRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MassDeletionAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-calendar-event")]
        public async Task<IActionResult> ActionOpenCalendarEventAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenCalendarEventAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-composer")]
        public async Task<IActionResult> ActionOpenComposerAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenComposerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-sms")]
        public async Task<IActionResult> ActionSendSmsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendSmsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-sendmail")]
        public async Task<IActionResult> ActionSendmailAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SendmailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unlink-event")]
        public async Task<IActionResult> ActionUnlinkEventAsync(CalendarEventUnlinkEventRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.UnlinkEventAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("change-attendee-status")]
        public async Task<IActionResult> ChangeAttendeeStatusAsync(CalendarEventChangeAttendeeStatusRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ChangeAttendeeStatusAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("clear-videocall-location")]
        public async Task<IActionResult> ClearVideocallLocationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ClearVideocallLocationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("find-partner-customer")]
        public async Task<IActionResult> FindPartnerCustomerAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.FindPartnerCustomerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-default-duration")]
        public async Task<IActionResult> GetDefaultDurationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetDefaultDurationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-discuss-videocall-location")]
        public async Task<IActionResult> GetDiscussVideocallLocationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetDiscussVideocallLocationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-display-time-tz")]
        public async Task<IActionResult> GetDisplayTimeTzAsync(CalendarEventGetDisplayTimeTzRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetDisplayTimeTzAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-next-alarm-date")]
        public async Task<IActionResult> GetNextAlarmDateAsync(CalendarEventGetNextAlarmDateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetNextAlarmDateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-state-selections")]
        public async Task<IActionResult> GetStateSelectionsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetStateSelectionsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-unusual-days")]
        public async Task<IActionResult> GetUnusualDaysAsync(CalendarEventGetUnusualDaysRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetUnusualDaysAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-discuss-videocall-location")]
        public async Task<IActionResult> SetDiscussVideocallLocationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetDiscussVideocallLocationAsync(ids);
            return Ok(result);
        }
    }
}