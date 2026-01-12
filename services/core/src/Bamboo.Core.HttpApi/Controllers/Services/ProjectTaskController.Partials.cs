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
        [Route("{id}/action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid id)
        {
            var result = await _appService.ArchiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-convert-to-subtask")]
        public async Task<IActionResult> ActionConvertToSubtaskAsync(Guid id)
        {
            var result = await _appService.ConvertToSubtaskAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-convert-to-task")]
        public async Task<IActionResult> ActionConvertToTaskAsync(Guid id)
        {
            var result = await _appService.ConvertToTaskAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-convert-to-template")]
        public async Task<IActionResult> ActionConvertToTemplateAsync(Guid id)
        {
            var result = await _appService.ConvertToTemplateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-create-from-template")]
        public async Task<IActionResult> ActionCreateFromTemplateAsync(Guid id, [FromBody] ProjectTaskCreateFromTemplateRequestDto input)
        {
            var result = await _appService.CreateFromTemplateAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-dependent-tasks")]
        public async Task<IActionResult> ActionDependentTasksAsync(Guid id)
        {
            var result = await _appService.DependentTasksAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-parent-task")]
        public async Task<IActionResult> ActionOpenParentTaskAsync(Guid id)
        {
            var result = await _appService.OpenParentTaskAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-ratings")]
        public async Task<IActionResult> ActionOpenRatingsAsync(Guid id)
        {
            var result = await _appService.OpenRatingsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-task")]
        public async Task<IActionResult> ActionOpenTaskAsync(Guid id)
        {
            var result = await _appService.OpenTaskAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-project-sharing-open-blocking")]
        public async Task<IActionResult> ActionProjectSharingOpenBlockingAsync(Guid id)
        {
            var result = await _appService.ProjectSharingOpenBlockingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-project-sharing-open-subtasks")]
        public async Task<IActionResult> ActionProjectSharingOpenSubtasksAsync(Guid id)
        {
            var result = await _appService.ProjectSharingOpenSubtasksAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-project-sharing-open-task")]
        public async Task<IActionResult> ActionProjectSharingOpenTaskAsync(Guid id)
        {
            var result = await _appService.ProjectSharingOpenTaskAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-project-sharing-recurring-tasks")]
        public async Task<IActionResult> ActionProjectSharingRecurringTasksAsync(Guid id)
        {
            var result = await _appService.ProjectSharingRecurringTasksAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-project-sharing-view-parent-task")]
        public async Task<IActionResult> ActionProjectSharingViewParentTaskAsync(Guid id)
        {
            var result = await _appService.ProjectSharingViewParentTaskAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-project-sharing-view-so")]
        public async Task<IActionResult> ActionProjectSharingViewSoAsync(Guid id)
        {
            var result = await _appService.ProjectSharingViewSoAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-recurring-tasks")]
        public async Task<IActionResult> ActionRecurringTasksAsync(Guid id)
        {
            var result = await _appService.RecurringTasksAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-redirect-to-project-task-form")]
        public async Task<IActionResult> ActionRedirectToProjectTaskFormAsync(Guid id)
        {
            var result = await _appService.RedirectToProjectTaskFormAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-undo-convert-to-template")]
        public async Task<IActionResult> ActionUndoConvertToTemplateAsync(Guid id)
        {
            var result = await _appService.UndoConvertToTemplateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-unlink-recurrence")]
        public async Task<IActionResult> ActionUnlinkRecurrenceAsync(Guid id)
        {
            var result = await _appService.UnlinkRecurrenceAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-so")]
        public async Task<IActionResult> ActionViewSoAsync(Guid id)
        {
            var result = await _appService.ViewSoAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-subtask-timesheet")]
        public async Task<IActionResult> ActionViewSubtaskTimesheetAsync(Guid id)
        {
            var result = await _appService.ViewSubtaskTimesheetAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] ProjectTaskCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync(Guid id, [FromBody] ProjectTaskGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync(Guid id)
        {
            var result = await _appService.GetImportTemplatesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-mention-suggestions")]
        public async Task<IActionResult> GetMentionSuggestionsAsync(Guid id, [FromBody] ProjectTaskGetMentionSuggestionsRequestDto input)
        {
            var result = await _appService.GetMentionSuggestionsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-todo-views-id")]
        public async Task<IActionResult> GetTodoViewsIdAsync(Guid id)
        {
            var result = await _appService.GetTodoViewsIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-unusual-days")]
        public async Task<IActionResult> GetUnusualDaysAsync(Guid id, [FromBody] ProjectTaskGetUnusualDaysRequestDto input)
        {
            var result = await _appService.GetUnusualDaysAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-blocked-by-dependences")]
        public async Task<IActionResult> IsBlockedByDependencesAsync(Guid id)
        {
            var result = await _appService.IsBlockedByDependencesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-new")]
        public async Task<IActionResult> MessageNewAsync(Guid id, [FromBody] ProjectTaskMessageNewRequestDto input)
        {
            var result = await _appService.MessageNewAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-subscribe")]
        public async Task<IActionResult> MessageSubscribeAsync(Guid id, [FromBody] ProjectTaskMessageSubscribeRequestDto input)
        {
            var result = await _appService.MessageSubscribeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-update")]
        public async Task<IActionResult> MessageUpdateAsync(Guid id, [FromBody] ProjectTaskMessageUpdateRequestDto input)
        {
            var result = await _appService.MessageUpdateAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/o-p-e-n-s-t-a-t-e-s")]
        public async Task<IActionResult> OPENSTATESAsync(Guid id)
        {
            var result = await _appService.OPENSTATESAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/plan-task-in-calendar")]
        public async Task<IActionResult> PlanTaskInCalendarAsync(Guid id, [FromBody] ProjectTaskPlanTaskInCalendarRequestDto input)
        {
            var result = await _appService.PlanTaskInCalendarAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/project-sharing-toggle-is-follower")]
        public async Task<IActionResult> ProjectSharingToggleIsFollowerAsync(Guid id)
        {
            var result = await _appService.ProjectSharingToggleIsFollowerAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/rating-apply")]
        public async Task<IActionResult> RatingApplyAsync(Guid id, [FromBody] ProjectTaskRatingApplyRequestDto input)
        {
            var result = await _appService.RatingApplyAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/stage-find")]
        public async Task<IActionResult> StageFindAsync(Guid id, [FromBody] ProjectTaskStageFindRequestDto input)
        {
            var result = await _appService.StageFindAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/t-a-s-k-p-o-r-t-a-l-r-e-a-d-a-b-l-e-f-i-e-l-d-s")]
        public async Task<IActionResult> TASKPORTALREADABLEFIELDSAsync(Guid id)
        {
            var result = await _appService.TASKPORTALREADABLEFIELDSAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/t-a-s-k-p-o-r-t-a-l-w-r-i-t-a-b-l-e-f-i-e-l-d-s")]
        public async Task<IActionResult> TASKPORTALWRITABLEFIELDSAsync(Guid id)
        {
            var result = await _appService.TASKPORTALWRITABLEFIELDSAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/update-date-end")]
        public async Task<IActionResult> UpdateDateEndAsync(Guid id, [FromBody] ProjectTaskUpdateDateEndRequestDto input)
        {
            var result = await _appService.UpdateDateEndAsync(id, input);
            return Ok(result);
        }
    }
}