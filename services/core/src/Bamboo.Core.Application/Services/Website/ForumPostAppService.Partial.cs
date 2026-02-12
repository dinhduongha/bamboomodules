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
    public partial class ForumPostAppService
    {

        protected async Task<ForumPost> CheckParentIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _check_parent_id) ---
            */
            return default;
        }

        protected async Task<ForumPost> ComputeChildCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_child_count) ---
            */
            return default;
        }

        protected async Task<ForumPost> ComputeFavoriteCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_favorite_count) ---
            */
            return default;
        }

        protected async Task<ForumPost> ComputeHasValidatedAnswerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_has_validated_answer) ---
            */
            return default;
        }

        protected async Task<ForumPost> ComputePlainContentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_plain_content) ---
            */
            return default;
        }

        protected async Task<ForumPost> ComputePostKarmaRightsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_post_karma_rights) ---
            */
            return default;
        }

        protected async Task<ForumPost> ComputeRelevancyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_relevancy) ---
            */
            return default;
        }

        protected async Task<ForumPost> ComputeSelfReplyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_self_reply) ---
            */
            return default;
        }

        protected async Task<ForumPost> ComputeUidHasAnsweredInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_uid_has_answered) ---
            */
            return default;
        }

        protected async Task<ForumPost> ComputeUserFavouriteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_user_favourite) ---
            */
            return default;
        }

        protected async Task<ForumPost> ComputeUserVoteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_user_vote) ---
            */
            return default;
        }

        protected async Task<ForumPost> ComputeVoteCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_vote_count) ---
            */
            return default;
        }

        protected async Task<ForumPost> ComputeWebsiteUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        protected async Task<ForumPost> DefaultWebsiteMetaInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _default_website_meta) ---
            */
            return default;
        }

        protected async Task<ForumPost> FlagInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _flag) ---
            */
            return default;
        }

        protected async Task<ForumPost> GetAccessActionInternalAsync(object access_uid, object force_website)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _get_access_action) ---
            */
            return default;
        }

        protected async Task<ForumPost> GetMicrodataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _get_microdata) ---
            */
            return default;
        }

        protected async Task<ForumPost> GetRelatedPostsInternalAsync(object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _get_related_posts) ---
            */
            return default;
        }

        protected async Task<ForumPost> GetStructuredDataInternalAsync(object post_type)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _get_structured_data) ---
            */
            return default;
        }

        protected async Task<ForumPost> MailGetOperationForMailMessageOperationInternalAsync(object message_operation)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _mail_get_operation_for_mail_message_operation) ---
            */
            return default;
        }

        protected async Task<ForumPost> MarkAsOffensiveInternalAsync(Guid reason_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _mark_as_offensive) ---
            */
            return default;
        }

        protected async Task<ForumPost> NotifyGetRecipientsGroupsInternalAsync(object message, object model_description, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        protected async Task<ForumPost> NotifyStateUpdateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _notify_state_update) ---
            */
            return default;
        }

        protected async Task<ForumPost> NotifyThreadByInboxInternalAsync(object message, object recipients_data, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _notify_thread_by_inbox) ---
            */
            return default;
        }

        protected async Task<ForumPost> RefuseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _refuse) ---
            */
            return default;
        }

        protected async Task<ForumPost> SearchCanViewInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _search_can_view) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ForumPost> SearchGetDetailInternalAsync(object website, object order, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        protected async Task<ForumPost> SearchRenderResultsInternalAsync(object fetch_fields, object mapping, object icon, object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _search_render_results) ---
            */
            return default;
        }

        protected async Task<ForumPost> SetViewedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _set_viewed) ---
            */
            return default;
        }

        protected async Task<ForumPost> UnlinkIfEnoughKarmaInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _unlink_if_enough_karma) ---
            */
            return default;
        }

        protected async Task<ForumPost> UpdateContentInternalAsync(object content, Guid forum_id)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _update_content) ---
            */
            return default;
        }

        protected async Task<ForumPost> UpdateLastActivityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _update_last_activity) ---
            */
            return default;
        }
    }
}