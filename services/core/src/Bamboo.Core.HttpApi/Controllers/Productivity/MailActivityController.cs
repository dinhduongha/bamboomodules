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
    [Route("api/v1/productivity/MailActivity")]
    public partial class MailActivityController : AbpController
    {
        protected readonly IMailActivityAppService _appService;
        public MailActivityController(IMailActivityAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-cancel")]
        public async Task<IActionResult> CancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-close-dialog")]
        public async Task<IActionResult> CloseDialogAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CloseDialogAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-calendar-event")]
        public async Task<IActionResult> CreateCalendarEventAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateCalendarEventAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-done")]
        public async Task<IActionResult> DoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-done-redirect-to-other")]
        public async Task<IActionResult> DoneRedirectToOtherAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DoneRedirectToOtherAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-done-schedule-next")]
        public async Task<IActionResult> DoneScheduleNextAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DoneScheduleNextAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-feedback")]
        public async Task<IActionResult> FeedbackAsync([FromBody] MailActivityFeedbackRequestDto input)
        {
            var result = await _appService.FeedbackAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-feedback-schedule-next")]
        public async Task<IActionResult> FeedbackScheduleNextAsync([FromBody] MailActivityFeedbackScheduleNextRequestDto input)
        {
            var result = await _appService.FeedbackScheduleNextAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-notify")]
        public async Task<IActionResult> NotifyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.NotifyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-document")]
        public async Task<IActionResult> OpenDocumentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenDocumentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reschedule-nextweek")]
        public async Task<IActionResult> RescheduleNextweekAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RescheduleNextweekAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reschedule-today")]
        public async Task<IActionResult> RescheduleTodayAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RescheduleTodayAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reschedule-tomorrow")]
        public async Task<IActionResult> RescheduleTomorrowAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RescheduleTomorrowAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("activity-format")]
        public async Task<IActionResult> ActivityFormatAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ActivityFormatAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-activity-data")]
        public async Task<IActionResult> GetActivityDataAsync([FromBody] MailActivityGetActivityDataRequestDto input)
        {
            var result = await _appService.GetActivityDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unlink-w-meeting")]
        public async Task<IActionResult> UnlinkWMeetingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnlinkWMeetingAsync(ids);
            return Ok(result);
        }
    }
    
}