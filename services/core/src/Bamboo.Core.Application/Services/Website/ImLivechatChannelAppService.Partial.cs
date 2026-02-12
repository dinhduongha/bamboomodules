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
    public partial class ImLivechatChannelAppService
    {

        protected async Task<ImLivechatChannel> AreYouInsideInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _are_you_inside) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> CheckReviewLinkInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _check_review_link) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> ComputeAvailableOperatorIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _compute_available_operator_ids) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> ComputeChatbotScriptCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _compute_chatbot_script_count) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> ComputeNbrChannelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _compute_nbr_channel) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> ComputeOngoingSessionsCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _compute_ongoing_sessions_count) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> ComputeRemainingSessionCapacityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _compute_remaining_session_capacity) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> ComputeScriptExternalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _compute_script_external) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> ComputeWebPageLinkInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _compute_web_page_link) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> DefaultButtonTextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _default_button_text) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> DefaultDefaultMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _default_default_message) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> DefaultUserIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _default_user_ids) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> GetAgentMemberValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _get_agent_member_vals) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> GetAvailableOperatorsByLivechatChannelInternalAsync(object users)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _get_available_operators_by_livechat_channel) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> GetChannelInfosInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _get_channel_infos) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> GetChannelNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _get_channel_name) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> GetLessActiveOperatorInternalAsync(object operator_statuses, object operators)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _get_less_active_operator) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> GetLivechatDiscussChannelValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _get_livechat_discuss_channel_vals) ---
            --- METHOD SOURCE (MODULE: website_livechat, FILE: im_livechat_channel.py, METHOD: _get_livechat_discuss_channel_vals) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> GetOngoingSessionCountByAgentLivechatChannelInternalAsync(object users, object filter_online)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _get_ongoing_session_count_by_agent_livechat_channel) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> GetOperatorInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _get_operator_info) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> GetOperatorInternalAsync(Guid previous_operator_id, object lang, Guid country_id, object expertises, object users)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _get_operator) ---
            */
            return default;
        }

        protected async Task<ImLivechatChannel> IsLivechatAvailableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: im_livechat_channel.py, METHOD: _is_livechat_available) ---
            */
            return default;
        }
    }
}