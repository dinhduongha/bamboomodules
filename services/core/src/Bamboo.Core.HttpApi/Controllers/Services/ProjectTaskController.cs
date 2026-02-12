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
    [Route("api/v1/services/ProjectTask")]
    public partial class ProjectTaskController : AbpController
    {
        protected readonly IProjectTaskAppService _appService;
        public ProjectTaskController(IProjectTaskAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ArchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-convert-to-subtask")]
        public async Task<IActionResult> ConvertToSubtaskAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ConvertToSubtaskAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-convert-to-task")]
        public async Task<IActionResult> ConvertToTaskAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ConvertToTaskAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-convert-to-template")]
        public async Task<IActionResult> ConvertToTemplateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ConvertToTemplateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-from-template")]
        public async Task<IActionResult> CreateFromTemplateAsync([FromBody] ProjectTaskCreateFromTemplateRequestDto input)
        {
            var result = await _appService.CreateFromTemplateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-dependent-tasks")]
        public async Task<IActionResult> DependentTasksAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DependentTasksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-parent-task")]
        public async Task<IActionResult> OpenParentTaskAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenParentTaskAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-ratings")]
        public async Task<IActionResult> OpenRatingsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenRatingsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-task")]
        public async Task<IActionResult> OpenTaskAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenTaskAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-project-sharing-open-blocking")]
        public async Task<IActionResult> ProjectSharingOpenBlockingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ProjectSharingOpenBlockingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-project-sharing-open-subtasks")]
        public async Task<IActionResult> ProjectSharingOpenSubtasksAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ProjectSharingOpenSubtasksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-project-sharing-open-task")]
        public async Task<IActionResult> ProjectSharingOpenTaskAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ProjectSharingOpenTaskAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-project-sharing-recurring-tasks")]
        public async Task<IActionResult> ProjectSharingRecurringTasksAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ProjectSharingRecurringTasksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-project-sharing-view-parent-task")]
        public async Task<IActionResult> ProjectSharingViewParentTaskAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ProjectSharingViewParentTaskAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-project-sharing-view-so")]
        public async Task<IActionResult> ProjectSharingViewSoAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ProjectSharingViewSoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-recurring-tasks")]
        public async Task<IActionResult> RecurringTasksAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RecurringTasksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-project-task-form")]
        public async Task<IActionResult> RedirectToProjectTaskFormAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RedirectToProjectTaskFormAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-undo-convert-to-template")]
        public async Task<IActionResult> UndoConvertToTemplateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UndoConvertToTemplateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unlink-recurrence")]
        public async Task<IActionResult> UnlinkRecurrenceAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnlinkRecurrenceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-so")]
        public async Task<IActionResult> ViewSoAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-subtask-timesheet")]
        public async Task<IActionResult> ViewSubtaskTimesheetAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSubtaskTimesheetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] ProjectTaskCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync([FromBody] ProjectTaskGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetImportTemplatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-mention-suggestions")]
        public async Task<IActionResult> GetMentionSuggestionsAsync([FromBody] ProjectTaskGetMentionSuggestionsRequestDto input)
        {
            var result = await _appService.GetMentionSuggestionsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-todo-views-id")]
        public async Task<IActionResult> GetTodoViewsIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetTodoViewsIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-unusual-days")]
        public async Task<IActionResult> GetUnusualDaysAsync([FromBody] ProjectTaskGetUnusualDaysRequestDto input)
        {
            var result = await _appService.GetUnusualDaysAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-blocked-by-dependences")]
        public async Task<IActionResult> IsBlockedByDependencesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.IsBlockedByDependencesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-new")]
        public async Task<IActionResult> MessageNewAsync([FromBody] ProjectTaskMessageNewRequestDto input)
        {
            var result = await _appService.MessageNewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-subscribe")]
        public async Task<IActionResult> MessageSubscribeAsync([FromBody] ProjectTaskMessageSubscribeRequestDto input)
        {
            var result = await _appService.MessageSubscribeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-update")]
        public async Task<IActionResult> MessageUpdateAsync([FromBody] ProjectTaskMessageUpdateRequestDto input)
        {
            var result = await _appService.MessageUpdateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("o-p-e-n-s-t-a-t-e-s")]
        public async Task<IActionResult> OPENSTATESAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OPENSTATESAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("plan-task-in-calendar")]
        public async Task<IActionResult> PlanTaskInCalendarAsync([FromBody] ProjectTaskPlanTaskInCalendarRequestDto input)
        {
            var result = await _appService.PlanTaskInCalendarAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("project-sharing-toggle-is-follower")]
        public async Task<IActionResult> ProjectSharingToggleIsFollowerAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ProjectSharingToggleIsFollowerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("rating-apply")]
        public async Task<IActionResult> RatingApplyAsync([FromBody] ProjectTaskRatingApplyRequestDto input)
        {
            var result = await _appService.RatingApplyAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("stage-find")]
        public async Task<IActionResult> StageFindAsync([FromBody] ProjectTaskStageFindRequestDto input)
        {
            var result = await _appService.StageFindAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("t-a-s-k-p-o-r-t-a-l-r-e-a-d-a-b-l-e-f-i-e-l-d-s")]
        public async Task<IActionResult> TASKPORTALREADABLEFIELDSAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.TASKPORTALREADABLEFIELDSAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("t-a-s-k-p-o-r-t-a-l-w-r-i-t-a-b-l-e-f-i-e-l-d-s")]
        public async Task<IActionResult> TASKPORTALWRITABLEFIELDSAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.TASKPORTALWRITABLEFIELDSAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-date-end")]
        public async Task<IActionResult> UpdateDateEndAsync([FromBody] ProjectTaskUpdateDateEndRequestDto input)
        {
            var result = await _appService.UpdateDateEndAsync(input);
            return Ok(result);
        }
    }
    
}