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
    public partial class SlideSlideAppService
    {

        protected async Task<SlideSlide> ActionMarkCompletedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_mark_completed) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ActionSetQuizDoneInternalAsync(object completed)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_set_quiz_done) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ActionSetViewedInternalAsync(object target_partner, object quiz_attempts_inc)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_set_viewed) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ActionVoteInternalAsync(object upvote)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_vote) ---
            */
            return default;
        }

        protected async Task<SlideSlide> CanReturnContentInternalAsync(object field_name, object access_token)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _can_return_content) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeCanPublishInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_can_publish) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeCategoryCompletedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_category_completed) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeCategoryCompletionTimeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_category_completion_time) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeCategoryIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_category_id) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeCommentsCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_comments_count) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeEmbedCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_embed_code) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeEmbedCountsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_embed_counts) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeGoogleDriveIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_google_drive_id) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeImage1920InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_image_1920) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeIsNewSlideInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_is_new_slide) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeIsPreviewInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides_survey, FILE: slide_slide.py, METHOD: _compute_is_preview) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeLikeInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_like_info) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeMarkCompleteActionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_mark_complete_actions) ---
            --- METHOD SOURCE (MODULE: website_slides_survey, FILE: slide_slide.py, METHOD: _compute_mark_complete_actions) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides_survey, FILE: slide_slide.py, METHOD: _compute_name) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeQuestionsCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_questions_count) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeQuizInfoInternalAsync(object target_partner, object quiz_done)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_quiz_info) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeSlideIconClassInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slide_icon_class) ---
            --- METHOD SOURCE (MODULE: website_slides_survey, FILE: slide_slide.py, METHOD: _compute_slide_icon_class) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeSlideTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slide_type) ---
            --- METHOD SOURCE (MODULE: website_slides_survey, FILE: slide_slide.py, METHOD: _compute_slide_type) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeSlideViewsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slide_views) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeSlidesStatisticsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slides_statistics) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeTotalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_total) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeUserMembershipIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_user_membership_id) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeVideoSourceTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_video_source_type) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeVimeoIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_vimeo_id) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeWebsiteAbsoluteUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_website_absolute_url) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeWebsiteShareUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_website_share_url) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeWebsiteUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        protected async Task<SlideSlide> ComputeYoutubeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_youtube_id) ---
            */
            return default;
        }

        protected async Task<SlideSlide> DefaultWebsiteMetaInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _default_website_meta) ---
            */
            return default;
        }

        protected async Task<SlideSlide> EmbedIncrementInternalAsync(object url)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _embed_increment) ---
            */
            return default;
        }

        protected async Task<SlideSlide> EnsureChallengeCategoryInternalAsync(object old_surveys, object unlink)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides_survey, FILE: slide_slide.py, METHOD: _ensure_challenge_category) ---
            */
            return default;
        }

        protected async Task<SlideSlide> FetchExternalMetadataInternalAsync(object image_url_only)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_external_metadata) ---
            */
            return default;
        }

        protected async Task<SlideSlide> FetchGoogleDriveMetadataInternalAsync(object image_url_only)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_google_drive_metadata) ---
            */
            return default;
        }

        protected async Task<SlideSlide> FetchVimeoMetadataInternalAsync(object image_url_only)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_vimeo_metadata) ---
            */
            return default;
        }

        protected async Task<SlideSlide> FetchYoutubeMetadataInternalAsync(object image_url_only)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_youtube_metadata) ---
            */
            return default;
        }

        protected async Task<SlideSlide> GenerateCertificationUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides_survey, FILE: slide_slide.py, METHOD: _generate_certification_url) ---
            */
            return default;
        }

        protected async Task<SlideSlide> GetAccessActionInternalAsync(object access_uid, object force_website)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_access_action) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SlideSlide> GetCanPublishErrorMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_can_publish_error_message) ---
            */
            return default;
        }

        protected async Task<SlideSlide> GetCompletionTimePdfInternalAsync(object data_bytes)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_completion_time_pdf) ---
            */
            return default;
        }

        protected async Task<SlideSlide> GetNextCategoryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_next_category) ---
            */
            return default;
        }

        protected async Task<SlideSlide> GetPlaceholderFilenameInternalAsync(object field)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_placeholder_filename) ---
            */
            return default;
        }

        protected async Task<SlideSlide> MailGetPartnerFieldsInternalAsync(object introspect_fields)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _mail_get_partner_fields) ---
            */
            return default;
        }

        protected async Task<SlideSlide> NotifyGetRecipientsGroupsInternalAsync(object message, object model_description, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        protected async Task<SlideSlide> OnChangeDocumentBinaryContentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _on_change_document_binary_content) ---
            */
            return default;
        }

        protected async Task<SlideSlide> OnChangeSlideCategoryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _on_change_slide_category) ---
            */
            return default;
        }

        protected async Task<SlideSlide> OnChangeUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _on_change_url) ---
            */
            return default;
        }

        protected async Task<SlideSlide> PostPublicationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _post_publication) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SlideSlide> SearchGetDetailInternalAsync(object website, object order, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        protected async Task<SlideSlide> SearchRenderResultsInternalAsync(object fetch_fields, object mapping, object icon, object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _search_render_results) ---
            */
            return default;
        }

        protected async Task<SlideSlide> SendShareEmailInternalAsync(object email, object fullscreen)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _send_share_email) ---
            */
            return default;
        }
    }
}