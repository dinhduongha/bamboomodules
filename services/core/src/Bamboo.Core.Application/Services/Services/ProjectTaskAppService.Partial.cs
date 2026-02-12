using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
    public partial class ProjectTaskAppService
    {

        protected async Task<ProjectTask> CheckNoCyclicDependenciesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _check_no_cyclic_dependencies) ---
            */
            return default;
        }

        protected async Task<ProjectTask> CheckParentIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _check_parent_id) ---
            */
            return default;
        }

        protected async Task<ProjectTask> CheckProjectRootInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _check_project_root) ---
            */
            return default;
        }

        protected async Task<ProjectTask> CheckSaleLineTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: _check_sale_line_type) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeAccessUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_access_url) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeAllowTimesheetsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _compute_allow_timesheets) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeAttachmentIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_attachment_ids) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeCurrentUserSameCompanyPartnerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_current_user_same_company_partner) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeDependOnCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_depend_on_count) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeDependentTasksCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_dependent_tasks_count) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeDisplayFollowButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_display_follow_button) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeDisplayInProjectInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_display_in_project) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeDisplayParentTaskButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_display_parent_task_button) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeDisplaySaleOrderButtonInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: _compute_display_sale_order_button) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeEffectiveHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _compute_effective_hours) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeElapsedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_elapsed) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeEncodeUomInDaysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _compute_encode_uom_in_days) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeHasLateAndUnreachedMilestoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_has_late_and_unreached_milestone) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeHasMultiSolInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py, METHOD: _compute_has_multi_sol) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeHasTemplateAncestorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_has_template_ancestor) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeIsClosedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_is_closed) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeIsProjectMapEmptyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py, METHOD: _compute_is_project_map_empty) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeIsTimeoffTaskInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: project_task.py, METHOD: _compute_is_timeoff_task) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeLastSolOfCustomerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py, METHOD: _compute_last_sol_of_customer) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeLeaveTypesCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: project_task.py, METHOD: _compute_leave_types_count) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeLinkPreviewNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_link_preview_name) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeMilestoneIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_milestone_id) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputePartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_partner_id) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: _compute_partner_id) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputePartnerPhoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_partner_phone) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputePersonalStageIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_personal_stage_id) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputePortalUserNamesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_portal_user_names) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeProgressHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _compute_progress_hours) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeProjectIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_project_id) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeRecurringCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_recurring_count) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeRemainingHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _compute_remaining_hours) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeRemainingHoursPercentageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _compute_remaining_hours_percentage) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeRemainingHoursSoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py, METHOD: _compute_remaining_hours_so) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeRepeatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_repeat) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeSaleLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: _compute_sale_line) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py, METHOD: _compute_sale_line) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeSaleOrderIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: _compute_sale_order_id) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeStageIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_stage_id) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_state) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeSubtaskAllocatedHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_subtask_allocated_hours) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeSubtaskCompletionPercentageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_subtask_completion_percentage) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeSubtaskCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_subtask_count) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeSubtaskEffectiveHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _compute_subtask_effective_hours) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeTaskToInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: _compute_task_to_invoice) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ComputeTotalHoursSpentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _compute_total_hours_spent) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectTask> ConvertHoursToDaysInternalAsync(object time)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _convert_hours_to_days) ---
            */
            return default;
        }

        protected async Task<ProjectTask> CreateTaskMappingInternalAsync(object copied_tasks)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _create_task_mapping) ---
            */
            return default;
        }

        protected async Task<ProjectTask> CreationMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _creation_message) ---
            */
            return default;
        }

        protected async Task<ProjectTask> CreationSubtypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _creation_subtype) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectTask> DefaultCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _default_company_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectTask> DefaultUserIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _default_user_ids) ---
            */
            return default;
        }

        protected async Task<ProjectTask> DomainSaleLineIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: _domain_sale_line_id) ---
            */
            return default;
        }

        protected async Task<ProjectTask> EnsureCompanyConsistencyWithPartnerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _ensure_company_consistency_with_partner) ---
            */
            return default;
        }

        protected async Task<ProjectTask> EnsureFieldsWriteInternalAsync(object vals, object defaults)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _ensure_fields_write) ---
            */
            return default;
        }

        protected async Task<ProjectTask> EnsureSaleOrderLinkedInternalAsync(List<Guid> sol_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: _ensure_sale_order_linked) ---
            */
            return default;
        }

        protected async Task<ProjectTask> EnsureSuperTaskIsNotPrivateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _ensure_super_task_is_not_private) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ExtractAllocatedHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _extract_allocated_hours) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ExtractPriorityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _extract_priority) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ExtractTagsAndUsersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _extract_tags_and_users) ---
            */
            return default;
        }

        protected async Task<ProjectTask> FindInternalUsersFromAddressMailInternalAsync(object emails, Guid project_id)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _find_internal_users_from_address_mail) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetActionViewSoIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: _get_action_view_so_ids) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py, METHOD: _get_action_view_so_ids) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetAllSubtasksInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_all_subtasks) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectTask> GetAllowedAccessParamsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_allowed_access_params) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetAttachmentsSearchDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_attachments_search_domain) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetCannotStartWithPatternsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _get_cannot_start_with_patterns) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_cannot_start_with_patterns) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetDefaultPartnerIdInternalAsync(object project, object parent)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_default_partner_id) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py, METHOD: _get_default_partner_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectTask> GetDefaultPersonalStageCreateValsInternalAsync(Guid user_id)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_default_personal_stage_create_vals) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetDefaultStageIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_default_stage_id) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetGroupPatternInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _get_group_pattern) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_group_pattern) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetGroupsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _get_groups) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_groups) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetGroupsPatternsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_groups_patterns) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetLastSolOfCustomerDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py, METHOD: _get_last_sol_of_customer_domain) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetPortalTotalHoursDictInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _get_portal_total_hours_dict) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetProjectsToMakeBillableDomainInternalAsync(object additional_domain)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_projects_to_make_billable_domain) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: _get_projects_to_make_billable_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectTask> GetRecurrenceFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_recurrence_fields) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetRottingDependsFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_rotting_depends_fields) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetRottingDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_rotting_domain) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetSubtaskIdsPerTaskIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_subtask_ids_per_task_id) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetSubtasksRecursivelyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_subtasks_recursively) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetTemplateDefaultContextWhitelistInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_template_default_context_whitelist) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: _get_template_default_context_whitelist) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectTask> GetTemplateFieldBlacklistInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_template_field_blacklist) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectTask> GetThreadWithAccessInternalAsync(Guid thread_id)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_thread_with_access) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetTimesheetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _get_timesheet) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py, METHOD: _get_timesheet) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetTimesheetReportDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _get_timesheet_report_data) ---
            */
            return default;
        }

        protected async Task<ProjectTask> GetVersionedFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_versioned_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectTask> GetViewCacheKeyInternalAsync(Guid view_id, object view_type)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_view_cache_key) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectTask> GroupExpandSalesOrderInternalAsync(object sales_orders, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: _group_expand_sales_order) ---
            */
            return default;
        }

        protected async Task<ProjectTask> HasFieldAccessInternalAsync(object field, object operation)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _has_field_access) ---
            */
            return default;
        }

        protected async Task<ProjectTask> InverseDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_display_name) ---
            */
            return default;
        }

        protected async Task<ProjectTask> InverseParentIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_parent_id) ---
            */
            return default;
        }

        protected async Task<ProjectTask> InversePartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: _inverse_partner_id) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py, METHOD: _inverse_partner_id) ---
            */
            return default;
        }

        protected async Task<ProjectTask> InversePartnerPhoneInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_partner_phone) ---
            */
            return default;
        }

        protected async Task<ProjectTask> InverseStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_state) ---
            */
            return default;
        }

        protected async Task<ProjectTask> IsRecurrenceValidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _is_recurrence_valid) ---
            */
            return default;
        }

        protected async Task<ProjectTask> LoadRecordsCreateInternalAsync(object vals_list)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _load_records_create) ---
            */
            return default;
        }

        protected async Task<ProjectTask> MailGetMessageSubtypesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _mail_get_message_subtypes) ---
            */
            return default;
        }

        protected async Task<ProjectTask> MessageAutoSubscribeFollowersInternalAsync(object updated_values, List<Guid> default_subtype_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _message_auto_subscribe_followers) ---
            */
            return default;
        }

        protected async Task<ProjectTask> MessagePostAfterHookInternalAsync(object message, object msg_vals)
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _message_post_after_hook) ---
            #endif
            return default;
        }

        protected async Task<ProjectTask> NotifyByEmailGetHeadersInternalAsync(object headers)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_by_email_get_headers) ---
            */
            return default;
        }

        protected async Task<ProjectTask> NotifyByEmailPrepareRenderingContextInternalAsync(object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            */
            return default;
        }

        protected async Task<ProjectTask> NotifyGetRecipientsGroupsInternalAsync(object message, object model_description, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        protected async Task<ProjectTask> NotifyGetReplyToInternalAsync(object @default, Guid author_id)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_get_reply_to) ---
            */
            return default;
        }

        protected async Task<ProjectTask> OnchangePartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: _onchange_partner_id) ---
            */
            return default;
        }

        protected async Task<ProjectTask> OnchangeProjectIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _onchange_project_id) ---
            */
            return default;
        }

        protected async Task<ProjectTask> OnchangeTaskCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _onchange_task_company) ---
            */
            return default;
        }

        protected async Task<ProjectTask> PopulateMissingPersonalStagesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _populate_missing_personal_stages) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectTask> PortalAccessibleFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _portal_accessible_fields) ---
            */
            return default;
        }

        protected async Task<ProjectTask> PortalGetParentHashTokenInternalAsync(object pid)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _portal_get_parent_hash_token) ---
            */
            return default;
        }

        protected async Task<ProjectTask> PreparePatternGroupsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _prepare_pattern_groups) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _prepare_pattern_groups) ---
            */
            return default;
        }

        protected async Task<ProjectTask> RatingApplyGetDefaultSubtypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_apply_get_default_subtype_id) ---
            */
            return default;
        }

        protected async Task<ProjectTask> RatingGetOperatorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_get_operator) ---
            */
            return default;
        }

        protected async Task<ProjectTask> RatingGetParentFieldNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_get_parent_field_name) ---
            */
            return default;
        }

        protected async Task<ProjectTask> RatingGetPartnerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_get_partner) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: _rating_get_partner) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<List<object>> ReadGroupInternalAsync(object domain, object groupby, object aggregates, object having, object offset, object limit, object order)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _read_group) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectTask> ReadGroupPersonalStageTypeIdsInternalAsync(object stages, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _read_group_personal_stage_type_ids) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectTask> ReadGroupStageIdsInternalAsync(object stages, object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _read_group_stage_ids) ---
            */
            return default;
        }

        protected async Task<ProjectTask> ResolveCopiedDependenciesInternalAsync(object copied_tasks)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _resolve_copied_dependencies) ---
            */
            return default;
        }

        protected async Task<ProjectTask> SearchAllowTimesheetsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _search_allow_timesheets) ---
            */
            return default;
        }

        protected async Task<ProjectTask> SearchHasLateAndUnreachedMilestoneInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_has_late_and_unreached_milestone) ---
            */
            return default;
        }

        protected async Task<ProjectTask> SearchHasTemplateAncestorInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_has_template_ancestor) ---
            */
            return default;
        }

        protected async Task<ProjectTask> SearchIsClosedInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_is_closed) ---
            */
            return default;
        }

        protected async Task<ProjectTask> SearchIsTimeoffTaskInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: project_task.py, METHOD: _search_is_timeoff_task) ---
            */
            return default;
        }

        protected async Task<ProjectTask> SearchOnComodelInternalAsync(object domain, object field, object comodel, object additional_domain)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_on_comodel) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectTask> SearchPersonalStageIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_personal_stage_id) ---
            */
            return default;
        }

        protected async Task<ProjectTask> SearchPortalUserNamesInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_portal_user_names) ---
            */
            return default;
        }

        protected async Task<ProjectTask> SearchRemainingHoursPercentageInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _search_remaining_hours_percentage) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectTask> SearchRemainingHoursSoInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_task.py, METHOD: _search_remaining_hours_so) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectTask> SearchTaskToInvoiceInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_task.py, METHOD: _search_task_to_invoice) ---
            */
            return default;
        }

        protected async Task<ProjectTask> SendEmailNotifyToCcInternalAsync(object partners_to_notify)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _send_email_notify_to_cc) ---
            */
            return default;
        }

        protected async Task<ProjectTask> SendSmsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_sms, FILE: project_task.py, METHOD: _send_sms) ---
            */
            return default;
        }

        protected async Task<ProjectTask> SendTaskRatingMailInternalAsync(object force_send)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _send_task_rating_mail) ---
            */
            return default;
        }

        protected async Task<ProjectTask> SetStageOnProjectFromTaskInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _set_stage_on_project_from_task) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectTask> TaskMessageAutoSubscribeNotifyInternalAsync(object users_per_task)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _task_message_auto_subscribe_notify) ---
            */
            return default;
        }

        protected async Task<ProjectTask> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        protected async Task<ProjectTask> TrackTemplateInternalAsync(object changes)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _track_template) ---
            */
            return default;
        }

        protected async Task<ProjectTask> UnlinkExceptContainsEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _unlink_except_contains_entries) ---
            */
            return default;
        }

        protected async Task<ProjectTask> UnsubscribePortalUsersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _unsubscribe_portal_users) ---
            */
            return default;
        }

        protected async Task<ProjectTask> UomInDaysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_task.py, METHOD: _uom_in_days) ---
            */
            return default;
        }
    }
}