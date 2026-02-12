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
    [Module("rating", Category = "Productivity", Depends = new[] { "mail" })]
    public partial class RatingParentMixinAppService : ApplicationService, IRatingParentMixinAppService
    {

        public RatingParentMixinAppService() 
        {

        }

        public async Task<TEntity> ActionCreateFromTemplateAsync<TEntity>(IEnumerable<TEntity> entities, object values, object role_to_users_mapping) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_create_from_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateTemplateFromProjectAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_create_template_from_project) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGetListViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_get_list_view) ---
            */
            return default;
        }

        public async Task<TEntity> ActionJoinAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: action_join) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenShareProjectWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_open_share_project_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProfitabilityItemsAsync<TEntity>(IEnumerable<TEntity> entities, object section_name, object domain, Guid res_id) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_profitability_items) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectTaskBurndownChartReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_project_task_burndown_chart_report) ---
            */
            return default;
        }

        public async Task<TEntity> ActionQuitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: action_quit) ---
            */
            return default;
        }

        public async Task<TEntity> ActionToggleProjectTemplateModeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_toggle_project_template_mode) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUndoConvertToTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_undo_convert_to_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewAllRatingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_view_all_rating) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewChatbotScriptsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: action_view_chatbot_scripts) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRatingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: action_view_rating) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksAnalysisAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_view_tasks_analysis) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_view_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksFromProjectMilestoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_view_tasks_from_project_milestone) ---
            */
            return default;
        }

        public async Task<TEntity> AddCollaboratorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners, object limited_access) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _add_collaborators) ---
            */
            return default;
        }

        public async Task<TEntity> AddFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _add_followers) ---
            */
            return default;
        }

        public async Task<TEntity> AliasGetCreationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _alias_get_creation_values) ---
            */
            return default;
        }

        public async Task<TEntity> AreYouInsideInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _are_you_inside) ---
            */
            return default;
        }

        public async Task<TEntity> ChangePrivacyVisibilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_visibility) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _change_privacy_visibility) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _check_account_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckFeaturesEnabledAsync<TEntity>(IEnumerable<TEntity> entities, object updated_features) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: check_features_enabled) ---
            */
            return default;
        }

        public async Task<TEntity> CheckProjectGroupAtRemovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _check_project_group_at_removal) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckProjectGroupWithFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object group_name) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _check_project_group_with_field) ---
            */
            return default;
        }

        public async Task<TEntity> CheckProjectSharingAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _check_project_sharing_access) ---
            */
            return default;
        }

        public async Task<TEntity> CheckReviewLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _check_review_link) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessInstructionMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_access_instruction_message) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_access_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailableOperatorIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _compute_available_operator_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeChatbotScriptCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _compute_chatbot_script_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeClosedTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_closed_task_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCollaboratorCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_collaborator_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_is_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMilestoneExceededInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_is_milestone_exceeded) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLastUpdateColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_last_update_color) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLastUpdateStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_last_update_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMilestoneCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_milestone_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMilestoneReachedCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_milestone_reached_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNbrChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _compute_nbr_channel) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNextMilestoneIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_next_milestone_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOngoingSessionsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _compute_ongoing_sessions_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOpenTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_open_task_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePrivacyVisibilityWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_privacy_visibility_warning) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingPercentageSatisfactionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_parent_mixin.py, METHOD: _compute_rating_percentage_satisfaction) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRemainingSessionCapacityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _compute_remaining_session_capacity) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeResourceCalendarIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_resource_calendar_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeScriptExternalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _compute_script_external) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowRatingsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_show_ratings) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskCompletionPercentageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_task_completion_percentage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_task_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalUpdateIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_total_update_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebPageLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _compute_web_page_link) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CopyEmbeddedActionsConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_projects, object shared_embedded_actions_mapping) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _copy_embedded_actions_config) ---
            */
            return default;
        }

        public async Task<TEntity> CopySharedEmbeddedActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_projects) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _copy_shared_embedded_actions) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAnalyticAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _create_analytic_account) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateTemplateFromProjectUndoCallbackAsync<TEntity>(IEnumerable<TEntity> entities, object callbacks) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: create_template_from_project_undo_callback) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultButtonTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _default_button_text) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultDefaultMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _default_default_message) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _default_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _default_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureStageHasSameCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _ensure_stage_has_same_company) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountNodeContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object plan) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_account_node_context) ---
            */
            return default;
        }

        protected async Task<object> GetAgentMemberValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _get_agent_member_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetAlreadyIncludedProfitabilityInvoiceLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_already_included_profitability_invoice_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvailableOperatorsByLivechatChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object users) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _get_available_operators_by_livechat_channel) ---
            */
            return default;
        }

        public async Task<TEntity> GetChannelInfosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _get_channel_infos) ---
            */
            return default;
        }

        protected async Task<object> GetChannelNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _get_channel_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetHidePartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_hide_partner) ---
            */
            return default;
        }

        public async Task<TEntity> GetItemsFromAalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_action) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_items_from_aal) ---
            */
            return default;
        }

        public async Task<TEntity> GetLastUpdateOrDefaultAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: get_last_update_or_default) ---
            */
            return default;
        }

        public async Task<TEntity> GetLessActiveOperatorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object operator_statuses, object operators) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _get_less_active_operator) ---
            */
            return default;
        }

        protected async Task<object> GetLivechatDiscussChannelValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _get_livechat_discuss_channel_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetLivechatInfoAsync<TEntity>(IEnumerable<TEntity> entities, object username) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: get_livechat_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetMilestonesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: get_milestones) ---
            */
            return default;
        }

        public async Task<TEntity> GetMilestonesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_milestones) ---
            */
            return default;
        }

        public async Task<TEntity> GetNewCollaboratorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_new_collaborators) ---
            */
            return default;
        }

        public async Task<TEntity> GetOngoingSessionCountByAgentLivechatChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object users, object filter_online) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _get_ongoing_session_count_by_agent_livechat_channel) ---
            */
            return default;
        }

        protected async Task<object> GetOperatorInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _get_operator_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetOperatorInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid previous_operator_id, object lang, Guid country_id, object expertises, object users) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _get_operator) ---
            */
            return default;
        }

        public async Task<TEntity> GetPanelDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: get_panel_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetPlanDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object plan) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_plan_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityAalDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_aal_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityItemsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_action) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_items) ---
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_labels) ---
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilitySequencePerInvoiceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_sequence_per_invoice_type) ---
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetProjectFeaturesMappingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_project_features_mapping) ---
            */
            return default;
        }

        public async Task<TEntity> GetProjectsToMakeBillableDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_projects_to_make_billable_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetStatButtonsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_stat_buttons) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateDefaultContextWhitelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_default_context_whitelist) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateFieldBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_field_blacklist) ---
            */
            return default;
        }

        public async Task<TEntity> GetTemplateFromProjectUndoCallbacksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_from_project_undo_callbacks) ---
            */
            return default;
        }

        public async Task<TEntity> GetTemplateTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: get_template_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> GetTemplateToProjectConfirmationCallbacksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_to_project_confirmation_callbacks) ---
            */
            return default;
        }

        public async Task<TEntity> GetTemplateToProjectWarningsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_to_project_warnings) ---
            */
            return default;
        }

        public async Task<TEntity> GetUserValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_user_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetValuesAnalyticAccountBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project_vals_list) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_values_analytic_account_batch) ---
            */
            return default;
        }

        public async Task<TEntity> InverseAllowMilestonesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _inverse_allow_milestones) ---
            */
            return default;
        }

        public async Task<TEntity> InverseAllowRecurringTasksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _inverse_allow_recurring_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> InverseAllowTaskDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _inverse_allow_task_dependencies) ---
            */
            return default;
        }

        public async Task<TEntity> InverseCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _inverse_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> IsLivechatAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _is_livechat_available) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetMessageSubtypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _mail_get_message_subtypes) ---
            */
            return default;
        }

        public async Task<TEntity> MapTasksAsync<TEntity>(IEnumerable<TEntity> entities, Guid new_project_id) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: map_tasks) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MapTasksDefaultValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _map_tasks_default_values) ---
            */
            return default;
        }

        public async Task<TEntity> MessageSubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> subtype_ids) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: message_subscribe) ---
            */
            return default;
        }

        public async Task<TEntity> MessageUnsubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: message_unsubscribe) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: name_create) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> OrderFieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @alias, object field_name, object direction, object nulls, object query) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _order_field_to_sql) ---
            */
            return default;
        }

        public async Task<TEntity> ProjectUpdateAllActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: project_update_all_action) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _search_is_favorite) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsMilestoneExceededInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _search_is_milestone_exceeded) ---
            */
            return default;
        }

        public async Task<TEntity> SearchRatingAvgInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_parent_mixin.py, METHOD: _search_rating_avg) ---
            */
            return default;
        }

        public async Task<TEntity> SetFavoriteUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_favorite) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _set_favorite_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ShowProfitabilityHelperInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _show_profitability_helper) ---
            */
            return default;
        }

        public async Task<TEntity> ShowProfitabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _show_profitability) ---
            */
            return default;
        }

        public async Task<TEntity> TemplateToProjectConfirmationCallbackAsync<TEntity>(IEnumerable<TEntity> entities, object callbacks) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: template_to_project_confirmation_callback) ---
            */
            return default;
        }

        public async Task<TEntity> ThreadToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object fields) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _thread_to_store) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleFavoriteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: toggle_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleTemplateModeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_template) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _toggle_template_mode) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _track_template) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<List<Dictionary<string, object>>> WebReadAsync<TEntity>(IEnumerable<TEntity> entities, object specification) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: web_read) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: write) ---
            */
            return default;
        }

        public async Task<TEntity> _ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object count_field, object additional_domain) where TEntity : IEntity<Guid>, IRatingParentMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: __compute_task_count) ---
            */
            return default;
        }
    }
}