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
    public partial class ForumForumAppService
    {

        protected async Task<ForumForum> ComputeCanModerateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_can_moderate) ---
            */
            return default;
        }

        protected async Task<ForumForum> ComputeCountFlaggedPostsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_count_flagged_posts) ---
            */
            return default;
        }

        protected async Task<ForumForum> ComputeCountPostsWaitingValidationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_count_posts_waiting_validation) ---
            */
            return default;
        }

        protected async Task<ForumForum> ComputeForumStatisticsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_forum_statistics) ---
            */
            return default;
        }

        protected async Task<ForumForum> ComputeHasPendingPostInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_has_pending_post) ---
            */
            return default;
        }

        protected async Task<ForumForum> ComputeImage1920InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides_forum, FILE: forum_forum.py, METHOD: _compute_image_1920) ---
            */
            return default;
        }

        protected async Task<ForumForum> ComputeLastPostIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_last_post_id) ---
            */
            return default;
        }

        protected async Task<ForumForum> ComputeSlideChannelIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides_forum, FILE: forum_forum.py, METHOD: _compute_slide_channel_id) ---
            */
            return default;
        }

        protected async Task<ForumForum> ComputeTagIdsUsageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_tag_ids_usage) ---
            */
            return default;
        }

        protected async Task<ForumForum> ComputeWebsiteUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ForumForum> GetDefaultWelcomeMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _get_default_welcome_message) ---
            */
            return default;
        }

        protected async Task<ForumForum> GetTagsFirstCharInternalAsync(object tags)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _get_tags_first_char) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ForumForum> SearchGetDetailInternalAsync(object website, object order, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        protected async Task<ForumForum> SearchRenderResultsInternalAsync(object fetch_fields, object mapping, object icon, object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _search_render_results) ---
            */
            return default;
        }

        protected async Task<ForumForum> SetDefaultFaqInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _set_default_faq) ---
            */
            return default;
        }

        protected async Task<ForumForum> TagToWriteValsInternalAsync(object tags)
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _tag_to_write_vals) ---
            */
            return default;
        }
    }
}