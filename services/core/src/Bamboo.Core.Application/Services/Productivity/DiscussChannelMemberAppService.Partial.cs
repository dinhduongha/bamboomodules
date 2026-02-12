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
    public partial class DiscussChannelMemberAppService
    {

        protected async Task<DiscussChannelMember> BusChannelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _bus_channel) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<DiscussChannelMember> CleanupExpiredMutesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _cleanup_expired_mutes) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ComputeAgentExpertiseIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py, METHOD: _compute_agent_expertise_ids) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ComputeChatbotScriptIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py, METHOD: _compute_chatbot_script_id) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ComputeIsPinnedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _compute_is_pinned) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ComputeIsSelfInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _compute_is_self) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ComputeLivechatMemberTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py, METHOD: _compute_livechat_member_type) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ComputeMessageUnreadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _compute_message_unread) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ContrainsNoPublicMemberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _contrains_no_public_member) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> CreateOrUpdateHistoryInternalAsync(object values_by_member)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py, METHOD: _create_or_update_history) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> GcUnpinLivechatSessionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py, METHOD: _gc_unpin_livechat_sessions) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> GcUnpinOutdatedSubChannelsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _gc_unpin_outdated_sub_channels) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> GetExcludedRtcMembersPartnerIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py, METHOD: _get_excluded_rtc_members_partner_ids) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> GetHtmlLinkInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _get_html_link) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> GetHtmlLinkTitleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py, METHOD: _get_html_link_title) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _get_html_link_title) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> GetRtcInviteMembersDomainInternalAsync(List<Guid> member_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py, METHOD: _get_rtc_invite_members_domain) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _get_rtc_invite_members_domain) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> GetRtcServerInfoInternalAsync(object rtc_session, object ice_servers, object key)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _get_rtc_server_info) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> GetStoreGuestFieldsInternalAsync(object fields)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py, METHOD: _get_store_guest_fields) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _get_store_guest_fields) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> GetStorePartnerFieldsInternalAsync(object fields)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py, METHOD: _get_store_partner_fields) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _get_store_partner_fields) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> InverseAgentExpertiseIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py, METHOD: _inverse_agent_expertise_ids) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> InverseChatbotScriptIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py, METHOD: _inverse_chatbot_script_id) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> InverseLivechatMemberTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py, METHOD: _inverse_livechat_member_type) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> JoinSfuInternalAsync(object ice_servers, object force)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _join_sfu) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> MarkAsReadInternalAsync(Guid last_message_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _mark_as_read) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> NotifyMuteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _notify_mute) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> NotifyTypingInternalAsync(object is_typing)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _notify_typing) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> RtcInviteMembersInternalAsync(List<Guid> member_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _rtc_invite_members) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> RtcJoinCallInternalAsync(object store, List<Guid> check_rtc_session_ids, object camera)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _rtc_join_call) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> RtcLeaveCallInternalAsync(Guid session_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _rtc_leave_call) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> RtcSyncSessionsInternalAsync(List<Guid> check_rtc_session_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _rtc_sync_sessions) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> SearchIsPinnedInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _search_is_pinned) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> SearchIsSelfInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _search_is_self) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> SetLastSeenMessageInternalAsync(object message, object notify)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _set_last_seen_message) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> SetNewMessageSeparatorInternalAsync(Guid message_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _set_new_message_separator) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<DiscussChannelMember> SyncFieldNamesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _sync_field_names) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ToStoreDefaultsInternalAsync(object target)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: discuss_channel_member.py, METHOD: _to_store_defaults) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }

        protected async Task<DiscussChannelMember> ToStorePersonaInternalAsync(object fields)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel_member.py, METHOD: _to_store_persona) ---
            */
            return default;
        }
    }
}