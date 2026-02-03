using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MailActivityController
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
        [Route("action-close-dialog")]
        public async Task<IActionResult> ActionCloseDialogAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CloseDialogAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-calendar-event")]
        public async Task<IActionResult> ActionCreateCalendarEventAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateCalendarEventAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-done")]
        public async Task<IActionResult> ActionDoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-done-redirect-to-other")]
        public async Task<IActionResult> ActionDoneRedirectToOtherAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DoneRedirectToOtherAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-done-schedule-next")]
        public async Task<IActionResult> ActionDoneScheduleNextAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DoneScheduleNextAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-feedback")]
        public async Task<IActionResult> ActionFeedbackAsync(MailActivityFeedbackRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FeedbackAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-feedback-schedule-next")]
        public async Task<IActionResult> ActionFeedbackScheduleNextAsync(MailActivityFeedbackScheduleNextRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FeedbackScheduleNextAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-notify")]
        public async Task<IActionResult> ActionNotifyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.NotifyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-document")]
        public async Task<IActionResult> ActionOpenDocumentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenDocumentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reschedule-nextweek")]
        public async Task<IActionResult> ActionRescheduleNextweekAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RescheduleNextweekAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reschedule-today")]
        public async Task<IActionResult> ActionRescheduleTodayAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RescheduleTodayAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reschedule-tomorrow")]
        public async Task<IActionResult> ActionRescheduleTomorrowAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RescheduleTomorrowAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("activity-format")]
        public async Task<IActionResult> ActivityFormatAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ActivityFormatAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-activity-data")]
        public async Task<IActionResult> GetActivityDataAsync(MailActivityGetActivityDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetActivityDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unlink-w-meeting")]
        public async Task<IActionResult> UnlinkWMeetingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnlinkWMeetingAsync(ids);
            return Ok(result);
        }
    }
}