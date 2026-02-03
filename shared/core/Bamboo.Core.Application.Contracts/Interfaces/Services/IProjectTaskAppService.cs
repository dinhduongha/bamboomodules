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
    public interface IProjectTaskAppService : IGenericAppService<ProjectTask>
    {
        Task<ProjectTask> ArchiveAsync(Guid[] ids);
        Task<ProjectTask> ConvertToSubtaskAsync(Guid[] ids);
        Task<ProjectTask> ConvertToTaskAsync(Guid[] ids);
        Task<ProjectTask> ConvertToTemplateAsync(Guid[] ids);
        Task<ProjectTask> CopyDataAsync(ProjectTaskCopyDataRequestDto input);
        Task<ProjectTask> CreateFromTemplateAsync(ProjectTaskCreateFromTemplateRequestDto input);
        Task<ProjectTask> DependentTasksAsync(Guid[] ids);
        Task<ProjectTask> GetEmptyListHelpAsync(ProjectTaskGetEmptyListHelpRequestDto input);
        Task<ProjectTask> GetImportTemplatesAsync(Guid[] ids);
        Task<ProjectTask> GetMentionSuggestionsAsync(ProjectTaskGetMentionSuggestionsRequestDto input);
        Task<ProjectTask> GetTodoViewsIdAsync(Guid[] ids);
        Task<ProjectTask> GetUnusualDaysAsync(ProjectTaskGetUnusualDaysRequestDto input);
        Task<ProjectTask> IsBlockedByDependencesAsync(Guid[] ids);
        Task<ProjectTask> MessageNewAsync(ProjectTaskMessageNewRequestDto input);
        Task<ProjectTask> MessageSubscribeAsync(ProjectTaskMessageSubscribeRequestDto input);
        Task<ProjectTask> MessageUpdateAsync(ProjectTaskMessageUpdateRequestDto input);
        Task<ProjectTask> OPENSTATESAsync(Guid[] ids);
        Task<ProjectTask> OpenParentTaskAsync(Guid[] ids);
        Task<ProjectTask> OpenRatingsAsync(Guid[] ids);
        Task<ProjectTask> OpenTaskAsync(Guid[] ids);
        Task<ProjectTask> PlanTaskInCalendarAsync(ProjectTaskPlanTaskInCalendarRequestDto input);
        Task<ProjectTask> ProjectSharingOpenBlockingAsync(Guid[] ids);
        Task<ProjectTask> ProjectSharingOpenSubtasksAsync(Guid[] ids);
        Task<ProjectTask> ProjectSharingOpenTaskAsync(Guid[] ids);
        Task<ProjectTask> ProjectSharingRecurringTasksAsync(Guid[] ids);
        Task<ProjectTask> ProjectSharingToggleIsFollowerAsync(Guid[] ids);
        Task<ProjectTask> ProjectSharingViewParentTaskAsync(Guid[] ids);
        Task<ProjectTask> ProjectSharingViewSoAsync(Guid[] ids);
        Task<ProjectTask> RatingApplyAsync(ProjectTaskRatingApplyRequestDto input);
        Task<ProjectTask> RecurringTasksAsync(Guid[] ids);
        Task<ProjectTask> RedirectToProjectTaskFormAsync(Guid[] ids);
        Task<ProjectTask> StageFindAsync(ProjectTaskStageFindRequestDto input);
        Task<ProjectTask> TASKPORTALREADABLEFIELDSAsync(Guid[] ids);
        Task<ProjectTask> TASKPORTALWRITABLEFIELDSAsync(Guid[] ids);
        Task<ProjectTask> UndoConvertToTemplateAsync(Guid[] ids);
        Task<ProjectTask> UnlinkRecurrenceAsync(Guid[] ids);
        Task<ProjectTask> UpdateDateEndAsync(ProjectTaskUpdateDateEndRequestDto input);
        Task<ProjectTask> ViewSoAsync(Guid[] ids);
        Task<ProjectTask> ViewSubtaskTimesheetAsync(Guid[] ids);
    }
}