using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MailActivityController
    {
        
        [HttpPost]
        [Route("{id}/action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid id)
        {
            var result = await _appService.CancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-close-dialog")]
        public async Task<IActionResult> ActionCloseDialogAsync(Guid id)
        {
            var result = await _appService.CloseDialogAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-create-calendar-event")]
        public async Task<IActionResult> ActionCreateCalendarEventAsync(Guid id)
        {
            var result = await _appService.CreateCalendarEventAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-done")]
        public async Task<IActionResult> ActionDoneAsync(Guid id)
        {
            var result = await _appService.DoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-done-redirect-to-other")]
        public async Task<IActionResult> ActionDoneRedirectToOtherAsync(Guid id)
        {
            var result = await _appService.DoneRedirectToOtherAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-done-schedule-next")]
        public async Task<IActionResult> ActionDoneScheduleNextAsync(Guid id)
        {
            var result = await _appService.DoneScheduleNextAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-feedback")]
        public async Task<IActionResult> ActionFeedbackAsync(Guid id, [FromBody] MailActivityFeedbackRequestDto input)
        {
            var result = await _appService.FeedbackAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-feedback-schedule-next")]
        public async Task<IActionResult> ActionFeedbackScheduleNextAsync(Guid id, [FromBody] MailActivityFeedbackScheduleNextRequestDto input)
        {
            var result = await _appService.FeedbackScheduleNextAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-notify")]
        public async Task<IActionResult> ActionNotifyAsync(Guid id)
        {
            var result = await _appService.NotifyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-document")]
        public async Task<IActionResult> ActionOpenDocumentAsync(Guid id)
        {
            var result = await _appService.OpenDocumentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-snooze")]
        public async Task<IActionResult> ActionSnoozeAsync(Guid id)
        {
            var result = await _appService.SnoozeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/activity-format")]
        public async Task<IActionResult> ActivityFormatAsync(Guid id)
        {
            var result = await _appService.ActivityFormatAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-activity-data")]
        public async Task<IActionResult> GetActivityDataAsync(Guid id, [FromBody] MailActivityGetActivityDataRequestDto input)
        {
            var result = await _appService.GetActivityDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/unlink-w-meeting")]
        public async Task<IActionResult> UnlinkWMeetingAsync(Guid id)
        {
            var result = await _appService.UnlinkWMeetingAsync(id);
            return Ok(result);
        }
    }
}