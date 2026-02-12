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
    [Module("mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public partial class MailThreadCcAppService : ApplicationService, IMailThreadCcAppService
    {

        public MailThreadCcAppService() 
        {

        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_archive) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionConvertToSubtaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_convert_to_subtask) ---
            */
            return default;
        }

        public async Task<TEntity> ActionConvertToTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_convert_to_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateFromTemplateAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_create_from_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_create_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDependentTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_dependent_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionJobAddApplicantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_job_add_applicants) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenApplicationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_open_applications) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_open_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenEmployeeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_open_employee) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenParentTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_open_parent_task) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenRatingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_open_ratings) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_open_task) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingOpenBlockingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_open_blocking) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingOpenSubtasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_open_subtasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingOpenTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_open_task) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingRecurringTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_recurring_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingViewParentTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_view_parent_task) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRecurringTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_recurring_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToProjectTaskFormAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_redirect_to_project_task_form) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRescheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_reschedule_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRestoreAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_restore) ---
            */
            return default;
        }

        public async Task<TEntity> ActionScheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities, object smart_calendar) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_schedule_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendEmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_send_email) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetAutomatedProbabilityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_set_automated_probability) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetLostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_set_lost) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetWonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_set_won) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetWonRainbowmanAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_set_won_rainbowman) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShowPotentialDuplicatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_show_potential_duplicates) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTalentPoolAddApplicantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_talent_pool_add_applicants) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTalentPoolStatButtonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_talent_pool_stat_button) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnarchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: action_unarchive) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: action_unarchive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUndoConvertToTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_undo_convert_to_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnlinkRecurrenceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_unlink_recurrence) ---
            */
            return default;
        }

        public async Task<TEntity> ActivityUpdateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: activity_update) ---
            */
            return default;
        }

        public async Task<TEntity> AddFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _add_followers) ---
            */
            return default;
        }

        public async Task<TEntity> ArchiveApplicantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: archive_applicant) ---
            */
            return default;
        }

        public async Task<TEntity> ArchiveEquipmentRequestAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: archive_equipment_request) ---
            */
            return default;
        }

        public async Task<TEntity> AssignUserlessLeadInTeamInternalAsync<TEntity>(IEnumerable<TEntity> entities, string creation_source) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _assign_userless_lead_in_team) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> BuildDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_update.py, METHOD: _build_description) ---
            */
            return default;
        }

        public async Task<TEntity> CheckInterviewerAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _check_interviewer_access) ---
            */
            return default;
        }

        public async Task<TEntity> CheckNoCyclicDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _check_no_cyclic_dependencies) ---
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _check_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckRepeatIntervalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _check_repeat_interval) ---
            */
            return default;
        }

        public async Task<TEntity> CheckScheduleEndInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _check_schedule_end) ---
            */
            return default;
        }

        public async Task<TEntity> CheckTalentPoolRequiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _check_talent_pool_required) ---
            */
            return default;
        }

        public async Task<TEntity> CheckWonValidityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _check_won_validity) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_access_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_application_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAttachmentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_attachment_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeClosedTaskPercentageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_update.py, METHOD: _compute_closed_task_percentage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_update.py, METHOD: _compute_color) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_commercial_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_company_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_company_id) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_company) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_contact_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentUserSameCompanyPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_current_user_same_company_partner) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_date_closed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateLastStageUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_date_last_stage_update) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_date_open) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDayCloseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_day_close) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_day) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDayOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_day_open) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDelayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_delay) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDepartmentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_department) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDependOnCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_depend_on_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDependentTasksCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_dependent_tasks_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayFollowButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_display_follow_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayInProjectInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_display_in_project) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayParentTaskButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_display_parent_task_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDurationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_duration) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeElapsedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_elapsed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailDomainCriterionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_email_domain_criterion) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_email_from) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_email_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFunctionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_function) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasLateAndUnreachedMilestoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_has_late_and_unreached_milestone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasTemplateAncestorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_has_template_ancestor) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsApplicantInPoolInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_is_applicant_in_pool) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsAutomatedProbabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_is_automated_probability) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_is_closed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPartnerVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_is_partner_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPoolInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_is_pool) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLangActiveCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_lang_active_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLangIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_lang_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkPreviewNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_link_preview_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMaintenanceTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_maintenance_team_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_meeting_display) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_meeting_display) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMilestoneIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_milestone_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNameCroppedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_update.py, METHOD: _compute_name_cropped) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerAddressValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_partner_address_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerEmailUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_partner_email_update) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_partner_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_partner_phone_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_partner_phone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneSanitizedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_partner_phone_sanitized) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_partner_phone_update) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePersonalStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_personal_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_phone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePhoneStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_phone_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePortalUserNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_portal_user_names) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePotentialLeadDuplicatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_potential_lead_duplicates) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_probabilities) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProgressPercentageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_update.py, METHOD: _compute_progress_percentage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProjectIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_project_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProratedRevenueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_prorated_revenue) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_recurring_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringMaintenanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_recurring_maintenance) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueMonthlyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_recurring_revenue_monthly) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueMonthlyProratedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_recurring_revenue_monthly_prorated) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueProratedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_recurring_revenue_prorated) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRepeatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_repeat) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeScheduleEndInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_schedule_end) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_stage_id) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_stage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskAllocatedHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_subtask_allocated_hours) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskCompletionPercentageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_subtask_completion_percentage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_subtask_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTalentPoolCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_talent_pool_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_team_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserCompanyIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_user_company_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_user_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _compute_user) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_website) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWonStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _compute_won_status) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertOpportunityAsync<TEntity>(IEnumerable<TEntity> entities, object partner, List<Guid> user_ids, Guid team_id) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: convert_opportunity) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertOpportunityDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, Guid team_id) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _convert_opportunity_data) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_update.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateCustomerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_parent) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _create_customer) ---
            */
            return default;
        }

        public async Task<TEntity> CreateEmployeeFromApplicantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: create_employee_from_applicant) ---
            */
            return default;
        }

        public async Task<TEntity> CreateTaskMappingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object copied_tasks) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _create_task_mapping) ---
            */
            return default;
        }

        public async Task<TEntity> CreationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _creation_message) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _creation_message) ---
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _creation_subtype) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _creation_subtype) ---
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _creation_subtype) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _creation_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> CronUpdateAutomatedProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _cron_update_automated_probabilities) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _default_company_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_update.py, METHOD: default_get) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultStageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _default_stage) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _default_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureCompanyConsistencyWithPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _ensure_company_consistency_with_partner) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureFieldsWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object defaults) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _ensure_fields_write) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureSuperTaskIsNotPrivateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _ensure_super_task_is_not_private) ---
            */
            return default;
        }

        public async Task<TEntity> ExtractPriorityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _extract_priority) ---
            */
            return default;
        }

        public async Task<TEntity> ExtractTagsAndUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _extract_tags_and_users) ---
            */
            return default;
        }

        public async Task<object> FieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @alias, object field_expr, object query) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _field_to_sql) ---
            */
            return default;
        }

        public async Task<TEntity> FindInternalUsersFromAddressMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails, Guid project_id) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _find_internal_users_from_address_mail) ---
            */
            return default;
        }

        public async Task<TEntity> FindMatchingPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _find_matching_partner) ---
            */
            return default;
        }

        public async Task<TEntity> FormatPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _format_properties) ---
            */
            return default;
        }

        public async Task<TEntity> GetActivityNoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _get_activity_note) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllSubtasksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_all_subtasks) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAllowedAccessParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_allowed_access_params) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttachmentNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_attachment_number) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttachmentsSearchDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_attachments_search_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetCannotStartWithPatternsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_cannot_start_with_patterns) ---
            */
            return default;
        }

        public async Task<TEntity> GetCustomerInformationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_customer_information) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_customer_information) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project, object parent) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_default_partner_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultPersonalStageCreateValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_default_personal_stage_create_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_default_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _get_default_team_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDurationFromTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object trackings) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_duration_from_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeCreateValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_employee_create_vals) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: get_empty_list_help) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: get_empty_list_help) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_empty_list_help) ---
            */
            return default;
        }

        public async Task<TEntity> GetGroupPatternInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_group_pattern) ---
            */
            return default;
        }

        public async Task<TEntity> GetGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_groups) ---
            */
            return default;
        }

        public async Task<TEntity> GetGroupsPatternsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_groups_patterns) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetLastUpdatedMilestoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_update.py, METHOD: _get_last_updated_milestone) ---
            */
            return default;
        }

        public async Task<TEntity> GetLeadDuplicatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object email, object include_lost) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_lead_duplicates) ---
            */
            return default;
        }

        public async Task<TEntity> GetMentionSuggestionsAsync<TEntity>(IEnumerable<TEntity> entities, object search, object limit) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_mention_suggestions) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMilestoneValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_update.py, METHOD: _get_milestone_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetOpportunityMeetingViewParametersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_opportunity_meeting_view_parameters) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerEmailUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_void) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_partner_email_update) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPhoneUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_void) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_partner_phone_update) ---
            */
            return default;
        }

        public async Task<TEntity> GetProjectsToMakeBillableDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object additional_domain) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_projects_to_make_billable_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetRainbowmanMessageAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: get_rainbowman_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetRainbowmanMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_rainbowman_message) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRecurrenceFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_recurrence_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetRottingDependsFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_rotting_depends_fields) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_rotting_depends_fields) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_rotting_depends_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetRottingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _get_rotting_domain) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_rotting_domain) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_rotting_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetSimilarApplicantsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ignore_talent, object only_talent) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _get_similar_applicants_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetSubtaskIdsPerTaskIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_subtask_ids_per_task_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetSubtasksRecursivelyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_subtasks_recursively) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateDefaultContextWhitelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_template_default_context_whitelist) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateFieldBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_template_field_blacklist) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_update.py, METHOD: _get_template_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetThreadWithAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid thread_id) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_thread_with_access) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUnusualDaysAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_unusual_days) ---
            */
            return default;
        }

        public async Task<TEntity> GetVersionedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_versioned_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: get_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_view_cache_key) ---
            */
            return default;
        }

        public async Task<TEntity> HandlePartnerAssignmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid force_partner_id, object create_missing, object with_parent) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _handle_partner_assignment) ---
            */
            return default;
        }

        public async Task<TEntity> HandleSalesmenAssignmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> user_ids, Guid team_id) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _handle_salesmen_assignment) ---
            */
            return default;
        }

        public async Task<TEntity> HandleWonLostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object old_status_by_lead, object new_status_by_lead) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _handle_won_lost) ---
            */
            return default;
        }

        public async Task<TEntity> HasFieldAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object operation) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _has_field_access) ---
            */
            return default;
        }

        public async Task<TEntity> InverseDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> InverseEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _inverse_email_from) ---
            */
            return default;
        }

        public async Task<TEntity> InverseParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> InversePartnerEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _inverse_partner_email) ---
            */
            return default;
        }

        public async Task<TEntity> InversePartnerPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_partner_phone) ---
            */
            return default;
        }

        public async Task<TEntity> InversePhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _inverse_phone) ---
            */
            return default;
        }

        public async Task<TEntity> InverseStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_state) ---
            */
            return default;
        }

        public async Task<TEntity> IsBlockedByDependencesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: is_blocked_by_dependences) ---
            */
            return default;
        }

        public async Task<TEntity> IsRecurrenceValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _is_recurrence_valid) ---
            */
            return default;
        }

        public async Task<TEntity> IsRuleBasedAssignmentActivatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _is_rule_based_assignment_activated) ---
            */
            return default;
        }

        public async Task<TEntity> LinkApplicantToTalentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: link_applicant_to_talent) ---
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _load_records_create) ---
            */
            return default;
        }

        public async Task<TEntity> LogMeetingAsync<TEntity>(IEnumerable<TEntity> entities, object meeting) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: log_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> MailCcSanitizedRawDictInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cc_string) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_cc.py, METHOD: _mail_cc_sanitized_raw_dict) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetMessageSubtypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _mail_get_message_subtypes) ---
            */
            return default;
        }

        public async Task<TEntity> MergeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fnames) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_data) ---
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_dependences_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesCalendarEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_dependences_calendar_events) ---
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesHistoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_dependences_history) ---
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_dependences) ---
            */
            return default;
        }

        public async Task<TEntity> MergeFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_followers) ---
            #endif
            return default;
        }

        public async Task<TEntity> MergeGetFieldsAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_get_fields_address) ---
            */
            return default;
        }

        public async Task<TEntity> MergeGetFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_get_fields) ---
            */
            return default;
        }

        public async Task<TEntity> MergeGetFieldsSpecificInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_get_fields_specific) ---
            */
            return default;
        }

        public async Task<TEntity> MergeLogSummaryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object merged_followers, object opportunities_tail) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_log_summary) ---
            */
            return default;
        }

        public async Task<TEntity> MergeOpportunityAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, Guid team_id, object auto_unlink) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: merge_opportunity) ---
            */
            return default;
        }

        public async Task<TEntity> MergeOpportunityInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, Guid team_id, object auto_unlink, object max_length) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _merge_opportunity) ---
            */
            return default;
        }

        public async Task<TEntity> MessageAddSuggestedRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_primary_email) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_cc.py, METHOD: _message_add_suggested_recipients) ---
            */
            return default;
        }

        public async Task<TEntity> MessageAutoSubscribeFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_values, List<Guid> default_subtype_ids) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _message_auto_subscribe_followers) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: message_new) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: message_new) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_cc.py, METHOD: message_new) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: message_new) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _message_post_after_hook) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _message_post_after_hook) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _message_post_after_hook) ---
            #endif
            return default;
        }

        public async Task<TEntity> MessageSubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> subtype_ids) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: message_subscribe) ---
            */
            return default;
        }

        public async Task<TEntity> MessageUpdateAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object update_vals) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_cc.py, METHOD: message_update) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: message_update) ---
            */
            return default;
        }

        public async Task<TEntity> NeedNewActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _need_new_activity) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailGetHeadersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object headers) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_by_email_get_headers) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailPrepareRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default, Guid author_id) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _notify_get_reply_to) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _notify_get_reply_to) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_get_reply_to) ---
            */
            return default;
        }

        public async Task<TEntity> OPENSTATESAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: OPEN_STATES) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCommercialPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _onchange_commercial_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePhoneValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _onchange_phone_validation) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeProjectIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _onchange_project_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTaskCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _onchange_task_company) ---
            */
            return default;
        }

        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _phone_get_number_fields) ---
            */
            return default;
        }

        public async Task<TEntity> PlanTaskInCalendarAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: plan_task_in_calendar) ---
            */
            return default;
        }

        public async Task<TEntity> PlsGetLeadPlsValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_lead_pls_values) ---
            */
            return default;
        }

        public async Task<TEntity> PlsGetNaiveBayesProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object batch_mode, object is_tooltip) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_naive_bayes_probabilities) ---
            */
            return default;
        }

        public async Task<TEntity> PlsGetSafeFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_safe_fields) ---
            */
            return default;
        }

        public async Task<TEntity> PlsGetSafeStartDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_safe_start_date) ---
            */
            return default;
        }

        public async Task<TEntity> PlsGetWonLostTotalCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object team_results) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_get_won_lost_total_count) ---
            */
            return default;
        }

        public async Task<TEntity> PlsIncrementFrequenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object from_state, object to_state) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_increment_frequencies) ---
            */
            return default;
        }

        public async Task<TEntity> PlsIncrementFrequencyDictInternalAsync<TEntity>(IEnumerable<TEntity> entities, object frequencies, object field, object @value, object won, object lost) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_increment_frequency_dict) ---
            */
            return default;
        }

        public async Task<TEntity> PlsPrepareFrequenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lead_values, object leads_pls_fields, object target_state) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_prepare_frequencies) ---
            */
            return default;
        }

        public async Task<TEntity> PlsPrepareUpdateFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rebuild, object target_state) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_prepare_update_frequency_table) ---
            */
            return default;
        }

        public async Task<TEntity> PlsUpdateFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_frequencies_by_team, object step, object existing_frequencies_by_team) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _pls_update_frequency_table) ---
            */
            return default;
        }

        public async Task<TEntity> PopulateMissingPersonalStagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _populate_missing_personal_stages) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PortalAccessibleFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _portal_accessible_fields) ---
            */
            return default;
        }

        public async Task<TEntity> PortalGetParentHashTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object pid) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _portal_get_parent_hash_token) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareAddressValuesFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_address_values_from_partner) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareContactNameFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_contact_name_from_partner) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareCustomerValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_name, object is_company, Guid parent_id) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_customer_values) ---
            */
            return default;
        }

        public async Task<TEntity> PreparePartnerNameFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_partner_name_from_partner) ---
            */
            return default;
        }

        public async Task<TEntity> PreparePatternGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _prepare_pattern_groups) ---
            */
            return default;
        }

        public async Task<TEntity> PreparePlsTooltipDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: prepare_pls_tooltip_data) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareValuesFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _prepare_values_from_partner) ---
            */
            return default;
        }

        public async Task<TEntity> ProjectSharingToggleIsFollowerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: project_sharing_toggle_is_follower) ---
            */
            return default;
        }

        public async Task<TEntity> RatingApplyAsync<TEntity>(IEnumerable<TEntity> entities, object rate, object token, object rating, object feedback, object subtype_xmlid, object notify_delay_send) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: rating_apply) ---
            */
            return default;
        }

        public async Task<TEntity> RatingApplyGetDefaultSubtypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_apply_get_default_subtype_id) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetOperatorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_get_operator) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetParentFieldNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_get_parent_field_name) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_get_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<List<object>> ReadGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object groupby, object aggregates, object having, object offset, object limit, object order) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _read_group) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadGroupPersonalStageTypeIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _read_group_personal_stage_type_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadGroupStageIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _read_group_stage_ids) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _read_group_stage_ids) ---
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _read_group_stage_ids) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _read_group_stage_ids) ---
            */
            return default;
        }

        public async Task<TEntity> RebuildPlsFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _rebuild_pls_frequency_table) ---
            */
            return default;
        }

        public async Task<TEntity> RedirectLeadOpportunityViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: redirect_lead_opportunity_view) ---
            */
            return default;
        }

        public async Task<TEntity> ResetApplicantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: reset_applicant) ---
            */
            return default;
        }

        public async Task<TEntity> ResetEquipmentRequestAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: reset_equipment_request) ---
            */
            return default;
        }

        public async Task<TEntity> ResolveCopiedDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object copied_tasks) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _resolve_copied_dependencies) ---
            */
            return default;
        }

        public async Task<TEntity> SearchApplicationStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _search_application_status) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchFetchAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field_names, object offset, object limit, object order) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: search_fetch) ---
            */
            return default;
        }

        public async Task<TEntity> SearchHasLateAndUnreachedMilestoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_has_late_and_unreached_milestone) ---
            */
            return default;
        }

        public async Task<TEntity> SearchHasTemplateAncestorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_has_template_ancestor) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsApplicantInPoolInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _search_is_applicant_in_pool) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_is_closed) ---
            */
            return default;
        }

        public async Task<TEntity> SearchOnComodelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field, object comodel, object additional_domain) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_on_comodel) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPersonalStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_personal_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> SearchPortalUserNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_portal_user_names) ---
            */
            return default;
        }

        public async Task<TEntity> SendEmailNotifyToCcInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners_to_notify) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _send_email_notify_to_cc) ---
            */
            return default;
        }

        public async Task<TEntity> SendTaskRatingMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_send) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _send_task_rating_mail) ---
            */
            return default;
        }

        public async Task<TEntity> SetStageOnProjectFromTaskInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _set_stage_on_project_from_task) ---
            */
            return default;
        }

        public async Task<TEntity> SortByConfidenceLevelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reverse) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _sort_by_confidence_level) ---
            */
            return default;
        }

        public async Task<TEntity> StageFindAsync<TEntity>(IEnumerable<TEntity> entities, Guid section_id, object domain, object order) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: stage_find) ---
            */
            return default;
        }

        public async Task<TEntity> StageFindInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid team_id, object domain, object order, object limit) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _stage_find) ---
            */
            return default;
        }

        public async Task<TEntity> TASKPORTALREADABLEFIELDSAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: TASK_PORTAL_READABLE_FIELDS) ---
            */
            return default;
        }

        public async Task<TEntity> TASKPORTALWRITABLEFIELDSAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: TASK_PORTAL_WRITABLE_FIELDS) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> TaskMessageAutoSubscribeNotifyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object users_per_task) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _task_message_auto_subscribe_notify) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: _track_template) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _track_template) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_update.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnsubscribePortalUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _unsubscribe_portal_users) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateAutomatedProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: _update_automated_probabilities) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateDateEndAsync<TEntity>(IEnumerable<TEntity> entities, Guid stage_id) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: update_date_end) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadCcable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_lead.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: write) ---
            */
            return default;
        }
    }
}