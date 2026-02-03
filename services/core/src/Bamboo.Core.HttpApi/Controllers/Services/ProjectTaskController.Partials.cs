using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ProjectTaskController
    {
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-convert-to-subtask")]
        public async Task<IActionResult> ActionConvertToSubtaskAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ConvertToSubtaskAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-convert-to-task")]
        public async Task<IActionResult> ActionConvertToTaskAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ConvertToTaskAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-convert-to-template")]
        public async Task<IActionResult> ActionConvertToTemplateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ConvertToTemplateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-from-template")]
        public async Task<IActionResult> ActionCreateFromTemplateAsync(ProjectTaskCreateFromTemplateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CreateFromTemplateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-dependent-tasks")]
        public async Task<IActionResult> ActionDependentTasksAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DependentTasksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-parent-task")]
        public async Task<IActionResult> ActionOpenParentTaskAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenParentTaskAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-ratings")]
        public async Task<IActionResult> ActionOpenRatingsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenRatingsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-task")]
        public async Task<IActionResult> ActionOpenTaskAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenTaskAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-project-sharing-open-blocking")]
        public async Task<IActionResult> ActionProjectSharingOpenBlockingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ProjectSharingOpenBlockingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-project-sharing-open-subtasks")]
        public async Task<IActionResult> ActionProjectSharingOpenSubtasksAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ProjectSharingOpenSubtasksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-project-sharing-open-task")]
        public async Task<IActionResult> ActionProjectSharingOpenTaskAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ProjectSharingOpenTaskAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-project-sharing-recurring-tasks")]
        public async Task<IActionResult> ActionProjectSharingRecurringTasksAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ProjectSharingRecurringTasksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-project-sharing-view-parent-task")]
        public async Task<IActionResult> ActionProjectSharingViewParentTaskAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ProjectSharingViewParentTaskAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-project-sharing-view-so")]
        public async Task<IActionResult> ActionProjectSharingViewSoAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ProjectSharingViewSoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-recurring-tasks")]
        public async Task<IActionResult> ActionRecurringTasksAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RecurringTasksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-project-task-form")]
        public async Task<IActionResult> ActionRedirectToProjectTaskFormAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectToProjectTaskFormAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-undo-convert-to-template")]
        public async Task<IActionResult> ActionUndoConvertToTemplateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UndoConvertToTemplateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unlink-recurrence")]
        public async Task<IActionResult> ActionUnlinkRecurrenceAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnlinkRecurrenceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-so")]
        public async Task<IActionResult> ActionViewSoAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-subtask-timesheet")]
        public async Task<IActionResult> ActionViewSubtaskTimesheetAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSubtaskTimesheetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(ProjectTaskCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync(ProjectTaskGetEmptyListHelpRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetEmptyListHelpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetImportTemplatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-mention-suggestions")]
        public async Task<IActionResult> GetMentionSuggestionsAsync(ProjectTaskGetMentionSuggestionsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetMentionSuggestionsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-todo-views-id")]
        public async Task<IActionResult> GetTodoViewsIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetTodoViewsIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-unusual-days")]
        public async Task<IActionResult> GetUnusualDaysAsync(ProjectTaskGetUnusualDaysRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetUnusualDaysAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-blocked-by-dependences")]
        public async Task<IActionResult> IsBlockedByDependencesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.IsBlockedByDependencesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-new")]
        public async Task<IActionResult> MessageNewAsync(ProjectTaskMessageNewRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MessageNewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-subscribe")]
        public async Task<IActionResult> MessageSubscribeAsync(ProjectTaskMessageSubscribeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MessageSubscribeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-update")]
        public async Task<IActionResult> MessageUpdateAsync(ProjectTaskMessageUpdateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MessageUpdateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("o-p-e-n-s-t-a-t-e-s")]
        public async Task<IActionResult> OPENSTATESAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OPENSTATESAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("plan-task-in-calendar")]
        public async Task<IActionResult> PlanTaskInCalendarAsync(ProjectTaskPlanTaskInCalendarRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.PlanTaskInCalendarAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("project-sharing-toggle-is-follower")]
        public async Task<IActionResult> ProjectSharingToggleIsFollowerAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ProjectSharingToggleIsFollowerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("rating-apply")]
        public async Task<IActionResult> RatingApplyAsync(ProjectTaskRatingApplyRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RatingApplyAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("stage-find")]
        public async Task<IActionResult> StageFindAsync(ProjectTaskStageFindRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.StageFindAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("t-a-s-k-p-o-r-t-a-l-r-e-a-d-a-b-l-e-f-i-e-l-d-s")]
        public async Task<IActionResult> TASKPORTALREADABLEFIELDSAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.TASKPORTALREADABLEFIELDSAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("t-a-s-k-p-o-r-t-a-l-w-r-i-t-a-b-l-e-f-i-e-l-d-s")]
        public async Task<IActionResult> TASKPORTALWRITABLEFIELDSAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.TASKPORTALWRITABLEFIELDSAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-date-end")]
        public async Task<IActionResult> UpdateDateEndAsync(ProjectTaskUpdateDateEndRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.UpdateDateEndAsync(input);
            return Ok(result);
        }
    }
}