using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Project", Category = "Services", Depends = new[] { "analytic", "base_setup", "mail", "portal", "rating", "resource", "web", "web_tour", "digest" })]
    public partial class ProjectTaskAppService : GenericAppService<ProjectTask>, IProjectTaskAppService
    {
        protected readonly IHtmlFieldHistoryMixinAppService _htmlFieldHistoryMixinAppService;
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadCcAppService _mailThreadCcAppService;
        protected readonly IMailTrackingDurationMixinAppService _mailTrackingDurationMixinAppService;
        protected readonly IPortalMixinAppService _portalMixinAppService;
        protected readonly IRatingMixinAppService _ratingMixinAppService;
        public ProjectTaskAppService(IRepository<ProjectTask, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IHtmlFieldHistoryMixinAppService htmlFieldHistoryMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadCcAppService mailThreadCcAppService, IMailTrackingDurationMixinAppService mailTrackingDurationMixinAppService, IPortalMixinAppService portalMixinAppService, IRatingMixinAppService ratingMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _htmlFieldHistoryMixinAppService = htmlFieldHistoryMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadCcAppService = mailThreadCcAppService;
            _mailTrackingDurationMixinAppService = mailTrackingDurationMixinAppService;
            _portalMixinAppService = portalMixinAppService;
            _ratingMixinAppService = ratingMixinAppService;
        }

        public async Task<ProjectTask> ArchiveAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_archive) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> ConvertToSubtaskAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_convert_to_subtask) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> ConvertToTaskAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project_todo, FILE: project_task.py, METHOD: action_convert_to_task) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> ConvertToTemplateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_convert_to_template) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> CopyDataAsync(ProjectTaskCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<ProjectTask> CreateAsync(CreateRequestDto<ProjectTask> input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: project_sms, FILE: project_task.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: project_todo, FILE: project_task.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<ProjectTask> CreateFromTemplateAsync(ProjectTaskCreateFromTemplateRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_create_from_template) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public override async Task<ProjectTask> DefaultGetAsync(DefaultGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: default_get) ---
            */
            return await base.DefaultGetAsync(input);
        }

        public async Task<ProjectTask> DependentTasksAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_dependent_tasks) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ProjectTask> GetEmptyListHelpAsync(ProjectTaskGetEmptyListHelpRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_empty_list_help) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ProjectTask> GetImportTemplatesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_import_templates) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> GetMentionSuggestionsAsync(ProjectTaskGetMentionSuggestionsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_mention_suggestions) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ProjectTask> GetTodoViewsIdAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project_todo, FILE: project_task.py, METHOD: get_todo_views_id) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ProjectTask> GetUnusualDaysAsync(ProjectTaskGetUnusualDaysRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_unusual_days) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> IsBlockedByDependencesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: is_blocked_by_dependences) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ProjectTask> MessageNewAsync(ProjectTaskMessageNewRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: message_new) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> MessageSubscribeAsync(ProjectTaskMessageSubscribeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: message_subscribe) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> MessageUpdateAsync(ProjectTaskMessageUpdateRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: message_update) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> OPENSTATESAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: OPEN_STATES) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> OpenParentTaskAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_open_parent_task) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> OpenRatingsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_open_ratings) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> OpenTaskAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_open_task) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> PlanTaskInCalendarAsync(ProjectTaskPlanTaskInCalendarRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: plan_task_in_calendar) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> ProjectSharingOpenBlockingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_open_blocking) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> ProjectSharingOpenSubtasksAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_open_subtasks) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> ProjectSharingOpenTaskAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_open_task) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> ProjectSharingRecurringTasksAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_recurring_tasks) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> ProjectSharingToggleIsFollowerAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: project_sharing_toggle_is_follower) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> ProjectSharingViewParentTaskAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_view_parent_task) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> ProjectSharingViewSoAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: action_project_sharing_view_so) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> RatingApplyAsync(ProjectTaskRatingApplyRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: rating_apply) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> RecurringTasksAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_recurring_tasks) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> RedirectToProjectTaskFormAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_redirect_to_project_task_form) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> StageFindAsync(ProjectTaskStageFindRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: stage_find) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> TASKPORTALREADABLEFIELDSAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: TASK_PORTAL_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: TASK_PORTAL_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: TASK_PORTAL_READABLE_FIELDS) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py, METHOD: TASK_PORTAL_READABLE_FIELDS) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> TASKPORTALWRITABLEFIELDSAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: TASK_PORTAL_WRITABLE_FIELDS) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> UndoConvertToTemplateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_undo_convert_to_template) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> UnlinkRecurrenceAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_unlink_recurrence) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> UpdateDateEndAsync(ProjectTaskUpdateDateEndRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: update_date_end) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> ViewSoAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: action_view_so) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectTask> ViewSubtaskTimesheetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: action_view_subtask_timesheet) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<ProjectTask> input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: project_sms, FILE: project_task.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}