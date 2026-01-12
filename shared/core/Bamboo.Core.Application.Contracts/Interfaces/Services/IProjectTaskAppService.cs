using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IProjectTaskAppService : IGenericApplicationService<ProjectTask>
    {
        Task<ProjectTask> ArchiveAsync(Guid id);
        Task<ProjectTask> ConvertToSubtaskAsync(Guid id);
        Task<ProjectTask> ConvertToTaskAsync(Guid id);
        Task<ProjectTask> ConvertToTemplateAsync(Guid id);
        Task<ProjectTask> CopyDataAsync(Guid id, ProjectTaskCopyDataRequestDto input);
        Task<ProjectTask> CreateFromTemplateAsync(Guid id, ProjectTaskCreateFromTemplateRequestDto input);
        Task<ProjectTask> DependentTasksAsync(Guid id);
        Task<ProjectTask> GetEmptyListHelpAsync(Guid id, ProjectTaskGetEmptyListHelpRequestDto input);
        Task<ProjectTask> GetImportTemplatesAsync(Guid id);
        Task<ProjectTask> GetMentionSuggestionsAsync(Guid id, ProjectTaskGetMentionSuggestionsRequestDto input);
        Task<ProjectTask> GetTodoViewsIdAsync(Guid id);
        Task<ProjectTask> GetUnusualDaysAsync(Guid id, ProjectTaskGetUnusualDaysRequestDto input);
        Task<ProjectTask> IsBlockedByDependencesAsync(Guid id);
        Task<ProjectTask> MessageNewAsync(Guid id, ProjectTaskMessageNewRequestDto input);
        Task<ProjectTask> MessageSubscribeAsync(Guid id, ProjectTaskMessageSubscribeRequestDto input);
        Task<ProjectTask> MessageUpdateAsync(Guid id, ProjectTaskMessageUpdateRequestDto input);
        Task<ProjectTask> OPENSTATESAsync(Guid id);
        Task<ProjectTask> OpenParentTaskAsync(Guid id);
        Task<ProjectTask> OpenRatingsAsync(Guid id);
        Task<ProjectTask> OpenTaskAsync(Guid id);
        Task<ProjectTask> PlanTaskInCalendarAsync(Guid id, ProjectTaskPlanTaskInCalendarRequestDto input);
        Task<ProjectTask> ProjectSharingOpenBlockingAsync(Guid id);
        Task<ProjectTask> ProjectSharingOpenSubtasksAsync(Guid id);
        Task<ProjectTask> ProjectSharingOpenTaskAsync(Guid id);
        Task<ProjectTask> ProjectSharingRecurringTasksAsync(Guid id);
        Task<ProjectTask> ProjectSharingToggleIsFollowerAsync(Guid id);
        Task<ProjectTask> ProjectSharingViewParentTaskAsync(Guid id);
        Task<ProjectTask> ProjectSharingViewSoAsync(Guid id);
        Task<ProjectTask> RatingApplyAsync(Guid id, ProjectTaskRatingApplyRequestDto input);
        Task<ProjectTask> RecurringTasksAsync(Guid id);
        Task<ProjectTask> RedirectToProjectTaskFormAsync(Guid id);
        Task<ProjectTask> StageFindAsync(Guid id, ProjectTaskStageFindRequestDto input);
        Task<ProjectTask> TASKPORTALREADABLEFIELDSAsync(Guid id);
        Task<ProjectTask> TASKPORTALWRITABLEFIELDSAsync(Guid id);
        Task<ProjectTask> UndoConvertToTemplateAsync(Guid id);
        Task<ProjectTask> UnlinkRecurrenceAsync(Guid id);
        Task<ProjectTask> UpdateDateEndAsync(Guid id, ProjectTaskUpdateDateEndRequestDto input);
        Task<ProjectTask> ViewSoAsync(Guid id);
        Task<ProjectTask> ViewSubtaskTimesheetAsync(Guid id);
    }
}