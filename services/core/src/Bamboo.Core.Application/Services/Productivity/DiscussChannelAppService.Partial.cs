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
    public partial class DiscussChannelAppService
    {

        protected async Task<DiscussChannel> ActionUnfollowInternalAsync(object partner, object guest, object post_leave_message)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _action_unfollow) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _action_unfollow) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> AddMembersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _add_members) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _add_members) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> AddNewMembersToChannelInternalAsync(object create_member_params, object inviting_partner, object users, object partners)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _add_new_members_to_channel) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> AddNextStepMessageToStoreInternalAsync(object chatbot_script_step)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _add_next_step_message_to_store) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> AllowInviteByEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _allow_invite_by_email) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> AttachmentToHtmlInternalAsync(object attachment)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _attachment_to_html) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> BroadcastInternalAsync(List<Guid> partner_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _broadcast) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ChatbotFindCustomerValuesInMessagesInternalAsync(object step_type_to_field)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _chatbot_find_customer_values_in_messages) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ChatbotPostMessageInternalAsync(object chatbot_script, object body)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _chatbot_post_message) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ChatbotRestartInternalAsync(object chatbot_script)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _chatbot_restart) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ChatbotValidateEmailInternalAsync(object email_address, object chatbot_script)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _chatbot_validate_email) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> CheckCanUpdateMessageContentInternalAsync(object message)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _check_can_update_message_content) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> CleanEmptyMessageInternalAsync(object message)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _clean_empty_message) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> CloseLivechatSessionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _close_livechat_session) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeAvatar128InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_avatar_128) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeAvatarCacheKeyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_avatar_cache_key) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeChannelNameMemberIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_channel_name_member_ids) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeChannelPartnerIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_channel_partner_ids) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeDurationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_duration) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeGroupPublicIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_group_public_id) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeHasCrmLeadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm_livechat, FILE: discuss_channel.py, METHOD: _compute_has_crm_lead) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeInvitationUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_invitation_url) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeInvitedMemberIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_invited_member_ids) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeIsEditableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_is_editable) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeIsMemberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_is_member) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatAgentHistoryIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_agent_history_ids) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatAgentPartnerIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_agent_partner_ids) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatAgentProvidingHelpHistoryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_agent_providing_help_history) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatAgentRequestingHelpHistoryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_agent_requesting_help_history) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatBotHistoryIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_bot_history_ids) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatBotPartnerIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_bot_partner_ids) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatCustomerGuestIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_customer_guest_ids) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatCustomerHistoryIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_customer_history_ids) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatCustomerPartnerIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_customer_partner_ids) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatIsEscalatedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_is_escalated) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatMatchesSelfExpertiseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_matches_self_expertise) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatMatchesSelfLangInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_matches_self_lang) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatOutcomeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_outcome) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatStartHourInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_start_hour) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_status) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeLivechatWeekDayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _compute_livechat_week_day) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeMemberCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_member_count) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeMessageCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_message_count) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ComputeSelfMemberIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_self_member_id) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ConstraintFromMessageIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _constraint_from_message_id) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ConstraintGroupIdChannelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _constraint_group_id_channel) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ConstraintParentChannelIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _constraint_parent_channel_id) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ConstraintPartnersChatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _constraint_partners_chat) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ConstraintSubscriptionDepartmentIdsChannelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: discuss_channel.py, METHOD: _constraint_subscription_department_ids_channel) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ConvertVisitorToLeadInternalAsync(object partner, object key)
        {
            /*
            --- METHOD SOURCE (MODULE: crm_livechat, FILE: discuss_channel.py, METHOD: _convert_visitor_to_lead) ---
            --- METHOD SOURCE (MODULE: website_crm_livechat, FILE: discuss_channel.py, METHOD: _convert_visitor_to_lead) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> CreateAttachmentsForPostInternalAsync(object values_list, object extra_list)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _create_attachments_for_post) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<DiscussChannel> CreateChannelInternalAsync(object name, Guid group_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _create_channel) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<DiscussChannel> CreateGroupInternalAsync(object partners_to, object default_display_mode, object name)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _create_group) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> CreateSubChannelInternalAsync(Guid from_message_id, object name)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _create_sub_channel) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> EmailLivechatTranscriptInternalAsync(object email)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _email_livechat_transcript) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ExecuteCommandHelpMessageExtraInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _execute_command_help_message_extra) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> FindOrCreateMemberForSelfInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _find_or_create_member_for_self) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> FindOrCreatePersonaForChannelInternalAsync(object guest_name, object timezone, object country_code, object create_member_params, object post_joined_message)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _find_or_create_persona_for_channel) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ForwardHumanOperatorInternalAsync(object chatbot_script_step, object users)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _forward_human_operator) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> GcBotOnlyOngoingSessionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _gc_bot_only_ongoing_sessions) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> GcEmptyLivechatSessionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _gc_empty_livechat_sessions) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> GenerateAvatarInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _generate_avatar) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<DiscussChannel> GenerateRandomTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _generate_random_token) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> GetAccessActionInternalAsync(object access_uid, object force_website)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_access_action) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<DiscussChannel> GetAllowedChannelMemberCreateParamsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _get_allowed_channel_member_create_params) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_allowed_channel_member_create_params) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> GetAllowedMessageParamsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_allowed_message_params) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> GetAllowedMessagePartnerIdsInternalAsync(List<Guid> partner_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_allowed_message_partner_ids) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> GetCallNotificationTagInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_call_notification_tag) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> GetChannelHistoryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _get_channel_history) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<DiscussChannel> GetChannelsAsMemberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_channels_as_member) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> GetHumanOperatorInternalAsync(object users, object chatbot_script_step)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _get_human_operator) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> GetLastMessagesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_last_messages) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> GetLivechatSessionFieldsToStoreInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm_livechat, FILE: discuss_channel.py, METHOD: _get_livechat_session_fields_to_store) ---
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _get_livechat_session_fields_to_store) ---
            --- METHOD SOURCE (MODULE: website_livechat, FILE: discuss_channel.py, METHOD: _get_livechat_session_fields_to_store) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> GetNotifyValidParametersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_notify_valid_parameters) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<DiscussChannel> GetOrCreateChatInternalAsync(object partners_to, object pin)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_or_create_chat) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> GetStoreMessageUpdateExtraFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_store_message_update_extra_fields) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> GetVisitorHistoryInternalAsync(object visitor)
        {
            /*
            --- METHOD SOURCE (MODULE: website_livechat, FILE: discuss_channel.py, METHOD: _get_visitor_history) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> GetVisitorLeaveMessageInternalAsync(object @operator, object cancel)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _get_visitor_leave_message) ---
            --- METHOD SOURCE (MODULE: website_livechat, FILE: discuss_channel.py, METHOD: _get_visitor_leave_message) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> InverseChannelPartnerIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _inverse_channel_partner_ids) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> LazyLoadMembersChannelTypesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _lazy_load_members_channel_types) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> MemberBasedNamingChannelTypesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _member_based_naming_channel_types) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> MessagePostAfterHookInternalAsync(object message, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _message_post_after_hook) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _message_post_after_hook) ---
            --- METHOD SOURCE (MODULE: mail_bot, FILE: discuss_channel.py, METHOD: _message_post_after_hook) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> MessageReceiveBounceInternalAsync(object email, object partner)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _message_receive_bounce) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> MessageSubscribeInternalAsync(List<Guid> partner_ids, List<Guid> subtype_ids, List<Guid> customer_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _message_subscribe) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> MessageUpdateContentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _message_update_content) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> NotifyByWebPushPreparePayloadInternalAsync(object message, object msg_vals, object force_record_name)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _notify_by_web_push_prepare_payload) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> NotifyGetRecipientsGroupsInternalAsync(object message, object model_description, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> NotifyGetRecipientsInternalAsync(object message, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _notify_get_recipients) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> NotifyThreadByWebPushInternalAsync(object message, object recipients_data, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _notify_thread_by_web_push) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> NotifyThreadInternalAsync(object message, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _notify_thread) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> PostCurrentChatbotStepMessageInternalAsync(object chatbot_script_step)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _post_current_chatbot_step_message) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> RatingGetParentFieldNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _rating_get_parent_field_name) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> RtcCancelInvitationsInternalAsync(List<Guid> member_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _rtc_cancel_invitations) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> SearchChannelPartnerIdsInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _search_channel_partner_ids) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> SearchIsMemberInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _search_is_member) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> SearchLivechatAgentHistoryIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _search_livechat_agent_history_ids) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> SearchLivechatBotHistoryIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _search_livechat_bot_history_ids) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> SearchLivechatCustomerHistoryIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _search_livechat_customer_history_ids) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> SearchLivechatMatchesSelfExpertiseInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _search_livechat_matches_self_expertise) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> SearchLivechatMatchesSelfLangInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _search_livechat_matches_self_lang) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ShouldInviteMembersToJoinCallInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: discuss_channel.py, METHOD: _should_invite_members_to_join_call) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _should_invite_members_to_join_call) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> StoreLivechatOperatorIdFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _store_livechat_operator_id_fields) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> SubscribeUsersAutomaticallyGetMembersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: discuss_channel.py, METHOD: _subscribe_users_automatically_get_members) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _subscribe_users_automatically_get_members) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> SubscribeUsersAutomaticallyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _subscribe_users_automatically) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> SyncFieldNamesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _sync_field_names) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _sync_field_names) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ToStoreDefaultsInternalAsync(object target)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _to_store_defaults) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _to_store_defaults) ---
            --- METHOD SOURCE (MODULE: website_livechat, FILE: discuss_channel.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> ToStoreInternalAsync(object store, object fields)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _to_store) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _to_store) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> TypesAllowingSeenInfosInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _types_allowing_seen_infos) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _types_allowing_seen_infos) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> TypesAllowingUnfollowInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _types_allowing_unfollow) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _types_allowing_unfollow) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> UnlinkExceptAllEmployeeChannelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _unlink_except_all_employee_channel) ---
            */
            return default;
        }

        protected async Task<DiscussChannel> UpdateForwardedChannelDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel.py, METHOD: _update_forwarded_channel_data) ---
            */
            return default;
        }
    }
}