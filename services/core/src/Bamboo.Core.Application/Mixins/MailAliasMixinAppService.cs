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
    public partial class MailAliasMixinAppService : ApplicationService, IMailAliasMixinAppService
    {

        public MailAliasMixinAppService() 
        {

        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: action_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionAssignLeadsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: action_assign_leads) ---
            */
            return default;
        }

        public async Task<TEntity> ActionAssignLeadsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_quota, object creation_delta_days) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _action_assign_leads) ---
            */
            return default;
        }

        public async Task<TEntity> ActionAssignLeadsLogsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object teams_data, object members_data) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _action_assign_leads_logs) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCloseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: action_close) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateFromTemplateAsync<TEntity>(IEnumerable<TEntity> entities, object values, object role_to_users_mapping) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_create_from_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateTemplateFromProjectAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_create_template_from_project) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGetListViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_get_list_view) ---
            */
            return default;
        }

        public async Task<TEntity> ActionJoinAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: action_join) ---
            */
            return default;
        }

        public async Task<TEntity> ActionLeaveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: action_leave) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ActionLoadRecruitmentScenarioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _action_load_recruitment_scenario) ---
            */
            return default;
        }

        public async Task<TEntity> ActionNewSurveyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_job.py, METHOD: action_new_survey) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenActivitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: action_open_activities) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: action_open) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: action_open_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenEmployeesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: action_open_employees) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenLeadsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: action_open_leads) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenShareProjectWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_open_share_project_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenUnassignedLeadsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: action_open_unassigned_leads) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ActionOpportunityForecastAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: action_opportunity_forecast) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPrimaryChannelButtonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: action_primary_channel_button) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProfitabilityItemsAsync<TEntity>(IEnumerable<TEntity> entities, object section_name, object domain, Guid res_id) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_profitability_items) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectTaskBurndownChartReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_project_task_burndown_chart_report) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSearchMatchingApplicantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_job.py, METHOD: action_search_matching_applicants) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendGuidelinesAsync<TEntity>(IEnumerable<TEntity> entities, object members) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: action_send_guidelines) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTestSurveyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_job.py, METHOD: action_test_survey) ---
            */
            return default;
        }

        public async Task<TEntity> ActionToggleProjectTemplateModeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_toggle_project_template_mode) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUndoConvertToTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_undo_convert_to_template) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ActionUpdateToPipelineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object action) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _action_update_to_pipeline) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewAllRatingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_view_all_rating) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksAnalysisAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_view_tasks_analysis) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_view_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksFromProjectMilestoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_view_tasks_from_project_milestone) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ActionYourPipelineAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: action_your_pipeline) ---
            */
            return default;
        }

        public async Task<TEntity> AddCollaboratorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners, object limited_access) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _add_collaborators) ---
            */
            return default;
        }

        public async Task<TEntity> AddFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _add_followers) ---
            */
            return default;
        }

        public async Task<TEntity> AddMembersToFavoritesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _add_members_to_favorites) ---
            */
            return default;
        }

        public async Task<TEntity> AddressIdDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _address_id_domain) ---
            */
            return default;
        }

        public async Task<TEntity> AliasGetCreationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _alias_get_creation_values) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _alias_get_creation_values) ---
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _alias_get_creation_values) ---
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _alias_get_creation_values) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _alias_get_creation_values) ---
            */
            return default;
        }

        public async Task<TEntity> AliasGetErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object message_dict, object @alias) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _alias_get_error) ---
            */
            return default;
        }

        public async Task<TEntity> AllocateLeadsDeduplicateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object leads, object duplicates_cache) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _allocate_leads_deduplicate) ---
            */
            return default;
        }

        public async Task<TEntity> AllocateLeadsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object creation_delta_days) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _allocate_leads) ---
            */
            return default;
        }

        public async Task<TEntity> AssignAndConvertLeadsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_quota) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _assign_and_convert_leads) ---
            */
            return default;
        }

        public async Task<TEntity> ChangePrivacyVisibilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_visibility) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _change_privacy_visibility) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAccessModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _check_access_mode) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _check_account_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckFeaturesEnabledAsync<TEntity>(IEnumerable<TEntity> entities, object updated_features) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: check_features_enabled) ---
            */
            return default;
        }

        public async Task<TEntity> CheckModerationGuidelinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _check_moderation_guidelines) ---
            */
            return default;
        }

        public async Task<TEntity> CheckModerationNotifyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _check_moderation_notify) ---
            */
            return default;
        }

        public async Task<TEntity> CheckModeratorEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _check_moderator_email) ---
            */
            return default;
        }

        public async Task<TEntity> CheckModeratorExistenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _check_moderator_existence) ---
            */
            return default;
        }

        public async Task<TEntity> CheckProjectGroupAtRemovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _check_project_group_at_removal) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckProjectGroupWithFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object group_name) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _check_project_group_with_field) ---
            */
            return default;
        }

        public async Task<TEntity> CheckProjectSharingAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _check_project_sharing_access) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CleanEmailBodyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object body_html) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _clean_email_body) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAbandonedCartsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: crm_team.py, METHOD: _compute_abandoned_carts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessInstructionMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_access_instruction_message) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_access_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActivitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_activities) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_all_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowedUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_job.py, METHOD: _compute_allowed_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicantHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_applicant_hired) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicantMatchingScoreInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_job.py, METHOD: _compute_applicant_matching_score) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAssignmentEnabledInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _compute_assignment_enabled) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAssignmentMaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _compute_assignment_max) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanManageGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _compute_can_manage_group) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeClosedTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_closed_task_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCollaboratorCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_collaborator_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentJobSkillIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_job.py, METHOD: _compute_current_job_skill_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDashboardButtonNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _compute_dashboard_button_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDocumentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_document_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeeCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_employee_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_job.py, METHOD: _compute_employees) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEquipmentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_equipment) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExtendedInterviewerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_extended_interviewer_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFullUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _compute_full_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: crm_team.py, METHOD: _compute_invoiced) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_is_favorite) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_is_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _compute_is_member) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMembershipMultiInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _compute_is_membership_multi) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMilestoneExceededInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_is_milestone_exceeded) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsModeratorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _compute_is_moderator) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLastUpdateColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_last_update_color) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLastUpdateStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_last_update_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLeadAllAssignedMonthCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _compute_lead_all_assigned_month_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLeadUnassignedCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _compute_lead_unassigned_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailGroupMessageCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _compute_mail_group_message_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailGroupMessageLastMonthCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _compute_mail_group_message_last_month_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailGroupMessageModerationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _compute_mail_group_message_moderation_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMemberCompanyIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _compute_member_company_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMemberCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _compute_member_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMemberIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _compute_member_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMemberPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _compute_member_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMemberWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _compute_member_warning) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMilestoneCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_milestone_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMilestoneReachedCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_milestone_reached_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeModerationRuleCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _compute_moderation_rule_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNewApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_new_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNextMilestoneIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_next_milestone_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNoOfHiredEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_no_of_hired_employee) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOldApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_old_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOpenApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _compute_open_application_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOpenTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_open_task_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePrivacyVisibilityWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_privacy_visibility_warning) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePublishedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _compute_published_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeResourceCalendarIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_resource_calendar_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSaleOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: crm_team.py, METHOD: _compute_sale_order_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowRatingsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_show_ratings) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSkillIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_job.py, METHOD: _compute_skill_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskCompletionPercentageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_task_completion_percentage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_task_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTodoRequestsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_todo_requests) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalUpdateIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_total_update_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        public async Task<TEntity> ConstrainsAssignmentDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _constrains_assignment_domain) ---
            */
            return default;
        }

        public async Task<TEntity> ConstrainsCompanyMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _constrains_company_members) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CopyEmbeddedActionsConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_projects, object shared_embedded_actions_mapping) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _copy_embedded_actions_config) ---
            */
            return default;
        }

        public async Task<TEntity> CopySharedEmbeddedActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_projects) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _copy_shared_embedded_actions) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAnalyticAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _create_analytic_account) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateTemplateFromProjectUndoCallbackAsync<TEntity>(IEnumerable<TEntity> entities, object callbacks) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: create_template_from_project_undo_callback) ---
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _creation_subtype) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CronAssignLeadsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_quota, object creation_delta_days) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _cron_assign_leads) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CronNotifyModeratorsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _cron_notify_moderators) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultAddressIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _default_address_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: default_get) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _default_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureStageHasSameCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _ensure_stage_has_same_company) ---
            */
            return default;
        }

        public async Task<TEntity> FindMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, Guid partner_id) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _find_member) ---
            */
            return default;
        }

        public async Task<TEntity> FindMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, Guid partner_id) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _find_members) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateActionTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object action) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _generate_action_token) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateActionUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object action) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _generate_action_url) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateEmailAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _generate_email_access_token) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateGroupAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _generate_group_access_token) ---
            */
            return default;
        }

        public async Task<TEntity> GetAbandonedCartsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: crm_team.py, METHOD: get_abandoned_carts) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountNodeContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object plan) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_account_node_context) ---
            */
            return default;
        }

        public async Task<TEntity> GetAlreadyIncludedProfitabilityInvoiceLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_already_included_profitability_invoice_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: get_backend_menu_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _get_default_color) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultFavoriteUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _get_default_favorite_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultJobDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _get_default_job_details) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, object domain) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _get_default_team_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultWebsiteDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _get_default_website_description) ---
            */
            return default;
        }

        public async Task<TEntity> GetEmailUnsubscribeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _get_email_unsubscribe_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstStageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _get_first_stage) ---
            */
            return default;
        }

        public async Task<TEntity> GetHidePartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_hide_partner) ---
            */
            return default;
        }

        public async Task<TEntity> GetItemsFromAalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_action) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_items_from_aal) ---
            */
            return default;
        }

        public async Task<TEntity> GetLastUpdateOrDefaultAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: get_last_update_or_default) ---
            */
            return default;
        }

        public async Task<TEntity> GetLeadToAssignDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _get_lead_to_assign_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetMilestonesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: get_milestones) ---
            */
            return default;
        }

        public async Task<TEntity> GetMilestonesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_milestones) ---
            */
            return default;
        }

        public async Task<TEntity> GetNewCollaboratorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_new_collaborators) ---
            */
            return default;
        }

        public async Task<TEntity> GetPanelDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: get_panel_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetPlanDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object plan) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_plan_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityAalDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_aal_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityItemsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_action) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_items) ---
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_labels) ---
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilitySequencePerInvoiceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_sequence_per_invoice_type) ---
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetProjectFeaturesMappingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_project_features_mapping) ---
            */
            return default;
        }

        public async Task<TEntity> GetProjectsToMakeBillableDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_projects_to_make_billable_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetStatButtonsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_stat_buttons) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateDefaultContextWhitelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_default_context_whitelist) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateFieldBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_field_blacklist) ---
            */
            return default;
        }

        public async Task<TEntity> GetTemplateFromProjectUndoCallbacksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_from_project_undo_callbacks) ---
            */
            return default;
        }

        public async Task<TEntity> GetTemplateTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: get_template_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> GetTemplateToProjectConfirmationCallbacksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_to_project_confirmation_callbacks) ---
            */
            return default;
        }

        public async Task<TEntity> GetTemplateToProjectWarningsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_to_project_warnings) ---
            */
            return default;
        }

        public async Task<TEntity> GetUserValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_user_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetValuesAnalyticAccountBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project_vals_list) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_values_analytic_account_batch) ---
            */
            return default;
        }

        public async Task<TEntity> InSaleScopeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: crm_team.py, METHOD: _in_sale_scope) ---
            */
            return default;
        }

        public async Task<TEntity> InitColumnAliasIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin.py, METHOD: _init_column_alias_id) ---
            */
            return default;
        }

        public async Task<TEntity> InitColumnInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin.py, METHOD: _init_column) ---
            */
            return default;
        }

        public async Task<TEntity> InverseAllowMilestonesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _inverse_allow_milestones) ---
            */
            return default;
        }

        public async Task<TEntity> InverseAllowRecurringTasksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _inverse_allow_recurring_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> InverseAllowTaskDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _inverse_allow_task_dependencies) ---
            */
            return default;
        }

        public async Task<TEntity> InverseCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _inverse_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _inverse_is_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> InverseMemberIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _inverse_member_ids) ---
            */
            return default;
        }

        public async Task<TEntity> JoinGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, Guid partner_id) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _join_group) ---
            */
            return default;
        }

        public async Task<TEntity> LeaveGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, Guid partner_id, object all_members) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _leave_group) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetMessageSubtypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _mail_get_message_subtypes) ---
            */
            return default;
        }

        public async Task<TEntity> MapTasksAsync<TEntity>(IEnumerable<TEntity> entities, Guid new_project_id) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: map_tasks) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MapTasksDefaultValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _map_tasks_default_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: message_new) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities, object body, object subject, object email_from, Guid author_id) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: message_post) ---
            */
            return default;
        }

        public async Task<TEntity> MessageSubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> subtype_ids) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: message_subscribe) ---
            */
            return default;
        }

        public async Task<TEntity> MessageUnsubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: message_unsubscribe) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageUpdateAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object update_vals) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: message_update) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: name_create) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _notify_members) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyModeratorsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _notify_moderators) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAccessModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _onchange_access_mode) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeModerationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _onchange_moderation) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeUseLeadsOpportunitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: _onchange_use_leads_opportunities) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _onchange_website_published) ---
            */
            return default;
        }

        public async Task<TEntity> OrderFieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @alias, object field_name, object direction, object nulls, object query) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: _order_field_to_sql) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _order_field_to_sql) ---
            */
            return default;
        }

        public async Task<TEntity> ProjectUpdateAllActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: project_update_all_action) ---
            */
            return default;
        }

        public async Task<TEntity> RequireNewAliasInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record_vals) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin.py, METHOD: _require_new_alias) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RoutingCheckRouteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object message_dict, object route, object raise_exception) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _routing_check_route) ---
            */
            return default;
        }

        public async Task<TEntity> SearchCurrentJobSkillIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills, FILE: hr_job.py, METHOD: _search_current_job_skill_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _search_is_favorite) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsMilestoneExceededInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _search_is_milestone_exceeded) ---
            */
            return default;
        }

        public async Task<TEntity> SearchMemberIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _search_member_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchMemberPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _search_member_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SendSubscribeConfirmationEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _send_subscribe_confirmation_email) ---
            */
            return default;
        }

        public async Task<TEntity> SendUnsubscribeConfirmationEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py, METHOD: _send_unsubscribe_confirmation_email) ---
            */
            return default;
        }

        public async Task<TEntity> SetFavoriteUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_favorite) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _set_favorite_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SetOpenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py, METHOD: set_open) ---
            */
            return default;
        }

        public async Task<TEntity> ShowProfitabilityHelperInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _show_profitability_helper) ---
            */
            return default;
        }

        public async Task<TEntity> ShowProfitabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _show_profitability) ---
            */
            return default;
        }

        public async Task<TEntity> TemplateToProjectConfirmationCallbackAsync<TEntity>(IEnumerable<TEntity> entities, object callbacks) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: template_to_project_confirmation_callback) ---
            */
            return default;
        }

        public async Task<TEntity> ThreadToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object fields) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _thread_to_store) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleFavoriteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: toggle_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleTemplateModeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_template) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _toggle_template_mode) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _track_template) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptDefaultInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _unlink_except_default) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptUsedForSalesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: crm_team.py, METHOD: _unlink_except_used_for_sales) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateInvoicedTargetAsync<TEntity>(IEnumerable<TEntity> entities, object @value) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: crm_team.py, METHOD: update_invoiced_target) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: crm_team.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: write) ---
            */
            return default;
        }

        public async Task<TEntity> _ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object count_field, object additional_domain) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: __compute_task_count) ---
            */
            return default;
        }
    }
}