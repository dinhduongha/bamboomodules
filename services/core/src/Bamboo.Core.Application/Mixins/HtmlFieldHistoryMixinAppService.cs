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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("html_editor", Category = "Misc", Depends = new[] { "base", "bus", "web" })]
    public partial class HtmlFieldHistoryMixinAppService : ApplicationService, IHtmlFieldHistoryMixinAppService
    {

        public HtmlFieldHistoryMixinAppService() 
        {

        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionConvertToSubtaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_convert_to_subtask) ---
            */
            return default;
        }

        public async Task<TEntity> ActionConvertToTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_convert_to_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateFromTemplateAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_create_from_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDependentTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_dependent_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenParentTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_open_parent_task) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenRatingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_open_ratings) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_open_task) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingOpenBlockingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_open_blocking) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingOpenSubtasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_open_subtasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingOpenTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_open_task) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingRecurringTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_recurring_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingViewParentTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_view_parent_task) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRecurringTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_recurring_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToProjectTaskFormAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_redirect_to_project_task_form) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUndoConvertToTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_undo_convert_to_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnlinkRecurrenceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_unlink_recurrence) ---
            */
            return default;
        }

        public async Task<TEntity> CheckNoCyclicDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _check_no_cyclic_dependencies) ---
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _check_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_access_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAttachmentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_attachment_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentUserSameCompanyPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_current_user_same_company_partner) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDependOnCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_depend_on_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDependentTasksCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_dependent_tasks_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayFollowButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_display_follow_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayInProjectInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_display_in_project) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayParentTaskButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_display_parent_task_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeElapsedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_elapsed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasLateAndUnreachedMilestoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_has_late_and_unreached_milestone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasTemplateAncestorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_has_template_ancestor) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_is_closed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkPreviewNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_link_preview_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: html_field_history_mixin.py, METHOD: _compute_metadata) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMilestoneIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_milestone_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_partner_phone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePersonalStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_personal_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePortalUserNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_portal_user_names) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProjectIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_project_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_recurring_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRepeatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_repeat) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskAllocatedHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_subtask_allocated_hours) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskCompletionPercentageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_subtask_completion_percentage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_subtask_count) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateTaskMappingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object copied_tasks) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _create_task_mapping) ---
            */
            return default;
        }

        public async Task<TEntity> CreationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _creation_message) ---
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _creation_subtype) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _default_company_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: default_get) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _default_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureCompanyConsistencyWithPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _ensure_company_consistency_with_partner) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureFieldsWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object defaults) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _ensure_fields_write) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureSuperTaskIsNotPrivateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _ensure_super_task_is_not_private) ---
            */
            return default;
        }

        public async Task<TEntity> ExtractPriorityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _extract_priority) ---
            */
            return default;
        }

        public async Task<TEntity> ExtractTagsAndUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _extract_tags_and_users) ---
            */
            return default;
        }

        public async Task<TEntity> FindInternalUsersFromAddressMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails, Guid project_id) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _find_internal_users_from_address_mail) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllSubtasksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_all_subtasks) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAllowedAccessParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_allowed_access_params) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttachmentsSearchDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_attachments_search_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetCannotStartWithPatternsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_cannot_start_with_patterns) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project, object parent) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_default_partner_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultPersonalStageCreateValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_default_personal_stage_create_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_default_stage_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_empty_list_help) ---
            */
            return default;
        }

        public async Task<TEntity> GetGroupPatternInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_group_pattern) ---
            */
            return default;
        }

        public async Task<TEntity> GetGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_groups) ---
            */
            return default;
        }

        public async Task<TEntity> GetGroupsPatternsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_groups_patterns) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        public async Task<TEntity> GetMentionSuggestionsAsync<TEntity>(IEnumerable<TEntity> entities, object search, object limit) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_mention_suggestions) ---
            */
            return default;
        }

        public async Task<TEntity> GetProjectsToMakeBillableDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object additional_domain) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_projects_to_make_billable_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRecurrenceFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_recurrence_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetRottingDependsFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_rotting_depends_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetRottingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_rotting_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetSubtaskIdsPerTaskIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_subtask_ids_per_task_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetSubtasksRecursivelyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_subtasks_recursively) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateDefaultContextWhitelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_template_default_context_whitelist) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateFieldBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_template_field_blacklist) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetThreadWithAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid thread_id) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_thread_with_access) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUnusualDaysAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_unusual_days) ---
            */
            return default;
        }

        public async Task<TEntity> GetVersionedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: html_field_history_mixin.py, METHOD: _get_versioned_fields) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_versioned_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_view_cache_key) ---
            */
            return default;
        }

        public async Task<TEntity> HasFieldAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object operation) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _has_field_access) ---
            */
            return default;
        }

        public async Task<TEntity> HtmlFieldHistoryGetComparisonAtRevisionAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, Guid revision_id) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: html_field_history_mixin.py, METHOD: html_field_history_get_comparison_at_revision) ---
            */
            return default;
        }

        public async Task<TEntity> HtmlFieldHistoryGetContentAtRevisionAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, Guid revision_id) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: html_field_history_mixin.py, METHOD: html_field_history_get_content_at_revision) ---
            */
            return default;
        }

        public async Task<TEntity> HtmlFieldHistoryGetUnifiedDiffAtRevisionAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, Guid revision_id) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: html_field_history_mixin.py, METHOD: html_field_history_get_unified_diff_at_revision) ---
            */
            return default;
        }

        public async Task<TEntity> InverseDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> InverseParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> InversePartnerPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_partner_phone) ---
            */
            return default;
        }

        public async Task<TEntity> InverseStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_state) ---
            */
            return default;
        }

        public async Task<TEntity> IsBlockedByDependencesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: is_blocked_by_dependences) ---
            */
            return default;
        }

        public async Task<TEntity> IsRecurrenceValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _is_recurrence_valid) ---
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _load_records_create) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetMessageSubtypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _mail_get_message_subtypes) ---
            */
            return default;
        }

        public async Task<TEntity> MessageAutoSubscribeFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_values, List<Guid> default_subtype_ids) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _message_auto_subscribe_followers) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: message_new) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _message_post_after_hook) ---
            #endif
            return default;
        }

        public async Task<TEntity> MessageSubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> subtype_ids) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: message_subscribe) ---
            */
            return default;
        }

        public async Task<TEntity> MessageUpdateAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object update_vals) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: message_update) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailGetHeadersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object headers) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_by_email_get_headers) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailPrepareRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default, Guid author_id) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_get_reply_to) ---
            */
            return default;
        }

        public async Task<TEntity> OPENSTATESAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: OPEN_STATES) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeProjectIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _onchange_project_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTaskCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _onchange_task_company) ---
            */
            return default;
        }

        public async Task<TEntity> PlanTaskInCalendarAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: plan_task_in_calendar) ---
            */
            return default;
        }

        public async Task<TEntity> PopulateMissingPersonalStagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _populate_missing_personal_stages) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PortalAccessibleFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _portal_accessible_fields) ---
            */
            return default;
        }

        public async Task<TEntity> PortalGetParentHashTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object pid) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _portal_get_parent_hash_token) ---
            */
            return default;
        }

        public async Task<TEntity> PreparePatternGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _prepare_pattern_groups) ---
            */
            return default;
        }

        public async Task<TEntity> ProjectSharingToggleIsFollowerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: project_sharing_toggle_is_follower) ---
            */
            return default;
        }

        public async Task<TEntity> RatingApplyAsync<TEntity>(IEnumerable<TEntity> entities, object rate, object token, object rating, object feedback, object subtype_xmlid, object notify_delay_send) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: rating_apply) ---
            */
            return default;
        }

        public async Task<TEntity> RatingApplyGetDefaultSubtypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_apply_get_default_subtype_id) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetOperatorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_get_operator) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetParentFieldNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_get_parent_field_name) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_get_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<List<object>> ReadGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object groupby, object aggregates, object having, object offset, object limit, object order) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _read_group) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadGroupPersonalStageTypeIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _read_group_personal_stage_type_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadGroupStageIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _read_group_stage_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ResolveCopiedDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object copied_tasks) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _resolve_copied_dependencies) ---
            */
            return default;
        }

        public async Task<TEntity> SearchHasLateAndUnreachedMilestoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_has_late_and_unreached_milestone) ---
            */
            return default;
        }

        public async Task<TEntity> SearchHasTemplateAncestorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_has_template_ancestor) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_is_closed) ---
            */
            return default;
        }

        public async Task<TEntity> SearchOnComodelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field, object comodel, object additional_domain) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_on_comodel) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPersonalStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_personal_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> SearchPortalUserNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_portal_user_names) ---
            */
            return default;
        }

        public async Task<TEntity> SendEmailNotifyToCcInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners_to_notify) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _send_email_notify_to_cc) ---
            */
            return default;
        }

        public async Task<TEntity> SendTaskRatingMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_send) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _send_task_rating_mail) ---
            */
            return default;
        }

        public async Task<TEntity> SetStageOnProjectFromTaskInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _set_stage_on_project_from_task) ---
            */
            return default;
        }

        public async Task<TEntity> StageFindAsync<TEntity>(IEnumerable<TEntity> entities, Guid section_id, object domain, object order) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: stage_find) ---
            */
            return default;
        }

        public async Task<TEntity> TASKPORTALREADABLEFIELDSAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: TASK_PORTAL_READABLE_FIELDS) ---
            */
            return default;
        }

        public async Task<TEntity> TASKPORTALWRITABLEFIELDSAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: TASK_PORTAL_WRITABLE_FIELDS) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> TaskMessageAutoSubscribeNotifyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object users_per_task) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _task_message_auto_subscribe_notify) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _track_template) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnsubscribePortalUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _unsubscribe_portal_users) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateDateEndAsync<TEntity>(IEnumerable<TEntity> entities, Guid stage_id) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: update_date_end) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IHtmlFieldHistoryMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: html_editor, FILE: html_field_history_mixin.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: write) ---
            */
            return default;
        }
    }
}