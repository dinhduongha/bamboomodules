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
    [Module("base", Category = "Base")]
    public partial class ImageMixinAppService : ApplicationService, IImageMixinAppService
    {

        public ImageMixinAppService() 
        {

        }

        public async Task<TEntity> ActionAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partners, object member_status, object raise_on_access) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_add_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product_category.py, METHOD: action_archive) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionChannelEnrollAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_channel_enroll) ---
            */
            return default;
        }

        public async Task<TEntity> ActionChannelInviteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_channel_invite) ---
            */
            return default;
        }

        public async Task<TEntity> ActionChannelOpenInviteWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template, object enroll_mode) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_channel_open_invite_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDislikeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_dislike) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGrantAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_grant_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionLikeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_like) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMarkCompletedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_mark_completed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMarkCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_mark_completed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMarkUncompletedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_mark_uncompleted) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenDocumentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: action_open_documents) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenLabelLayoutAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: action_open_label_layout) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToCompletedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_completed_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToEngagedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_engaged_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToInvitedMembersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_invited_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToMembersAsync<TEntity>(IEnumerable<TEntity> entities, object status_filter) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_redirect_to_members) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRefuseAccessAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_refuse_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRequestAccessAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_request_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRequestAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_request_access) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetQuizDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object completed) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_set_quiz_done) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetViewedAsync<TEntity>(IEnumerable<TEntity> entities, object quiz_attempts_inc) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_set_viewed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetViewedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partner, object quiz_attempts_inc) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_set_viewed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnarchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product_category.py, METHOD: action_unarchive) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_unarchive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewEmbedsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_view_embeds) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewLivechatChannelsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: action_view_livechat_channels) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRatingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_view_ratings) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewSlidesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: action_view_slides) ---
            */
            return default;
        }

        public async Task<TEntity> ActionVoteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object upvote) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_vote) ---
            */
            return default;
        }

        public async Task<TEntity> AddGroupsMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _add_groups_members) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AllowPublishRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _allow_publish_rating_stats) ---
            */
            return default;
        }

        public async Task<TEntity> AvatarGenerateSvgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _avatar_generate_svg) ---
            */
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _avatar_get_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderPathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _avatar_get_placeholder_path) ---
            */
            return default;
        }

        public async Task<TEntity> BaseDomainItemIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _base_domain_item_ids) ---
            */
            return default;
        }

        public async Task<TEntity> CanGrantBadgeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py, METHOD: _can_grant_badge) ---
            */
            return default;
        }

        public async Task<TEntity> CanReturnContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object access_token) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _can_return_content) ---
            */
            return default;
        }

        public async Task<TEntity> CartesianProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_template_attribute_values_per_line, object parent_combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _cartesian_product) ---
            */
            return default;
        }

        public async Task<TEntity> CheckActiveCategoriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: _check_active_categories) ---
            */
            return default;
        }

        public async Task<TEntity> CheckActiveSuppliersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: _check_active_suppliers) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUniquenessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_barcode_uniqueness) ---
            */
            return default;
        }

        public async Task<TEntity> CheckComboIdsNotEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_combo_ids_not_empty) ---
            */
            return default;
        }

        public async Task<TEntity> CheckGrantingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py, METHOD: check_granting) ---
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: check_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckQuestionSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _check_question_selection) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSaleComboIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_sale_combo_ids) ---
            */
            return default;
        }

        public async Task<TEntity> CheckValidVideoUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_image.py, METHOD: _check_valid_video_url) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CompleteInverseExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object exclusions) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _complete_inverse_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActionRightsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_action_rights) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowCommentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_allow_comment) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _compute_avatar_1024) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _compute_avatar_128) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _compute_avatar_1920) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _compute_avatar_256) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _compute_avatar_512) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _compute_avatar) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanImage1024BeZoomedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_can_image_1024_be_zoomed) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_image.py, METHOD: _compute_can_image_1024_be_zoomed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanModerateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_can_moderate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanPublishInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_can_publish) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_can_publish) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanUploadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_can_upload) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryAndSlideIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_category_and_slide_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_category_completed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryCompletionTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_category_completion_time) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_category_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommentsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_comments_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCostCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_cost_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountFlaggedPostsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_count_flagged_posts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountPostsWaitingValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_count_posts_waiting_validation) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmbedCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_image.py, METHOD: _compute_embed_code) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_embed_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmbedCountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_embed_counts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEnrollInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_enroll) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFirstStepWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _compute_first_step_warning) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeForumStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_forum_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGoogleDriveIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_google_drive_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasConfigurableAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_has_configurable_attributes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasPendingPostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_has_pending_post) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasPublishedProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _compute_has_published_products) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ComputeHasRequestedAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_has_requested_access) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImage1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_image_1920) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsAvailableAtInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: _compute_is_available_at) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsDynamicallyCreatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_is_dynamically_created) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: _compute_is_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsNewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: _compute_is_new) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsNewSlideInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_is_new_slide) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_is_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_is_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLastOrderDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: _compute_last_order_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLastPostIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_last_post_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLikeInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_like_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatChannelCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _compute_livechat_channel_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMarkCompleteActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_mark_complete_actions) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMembersCountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_members_counts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMembershipValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_membership_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeParentsAndSelfInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _compute_parents_and_self) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerHasNewContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_partner_has_new_content) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_partners) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePrerequisiteUserHasCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_prerequisite_user_has_completed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product_category.py, METHOD: _compute_product_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductDocumentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_document_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductImageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: _compute_product_image) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductVariantCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_variant_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_variant_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseOkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_purchase_ok) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuestionsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_questions_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuizInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partner, object quiz_done) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_quiz_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRankUsersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_karma_rank.py, METHOD: _compute_rank_users_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_rating_stats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_service_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideIconClassInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slide_icon_class) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideLastUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_slide_last_update) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slide_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideViewsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slide_views) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlidesStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_slides_statistics) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slides_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTagIdsUsageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_tag_ids_usage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTemplateFieldFromVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object @default) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_template_field_from_variant_field) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_total) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserMembershipIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_user_membership_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_user_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeValidProductTemplateAttributeLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_valid_product_template_attribute_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVideoSourceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_video_source_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVimeoIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_vimeo_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_volume) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_volume_uom_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteAbsoluteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_absolute_url) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_website_absolute_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteDefaultBackgroundImageUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_default_background_image_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteShareUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_website_share_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_weight) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWeightUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_weight_uom_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeYoutubeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_youtube_id) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: copy) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_karma_rank.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_image.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateFirstProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object log_warning) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_first_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object log_warning) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> CreateVariantIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_variant_ids) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _default_access_token) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCoverPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _default_cover_properties) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: default_get) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultImageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product_category.py, METHOD: _default_image) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _default_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultWebsiteMetaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _default_website_meta) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DemoConfigureVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _demo_configure_variants) ---
            */
            return default;
        }

        public async Task<TEntity> DomainPricelistRuleIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _domain_pricelist_rule_ids) ---
            */
            return default;
        }

        public async Task<TEntity> EmbedIncrementInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _embed_increment) ---
            */
            return default;
        }

        public async Task<TEntity> FetchExternalMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_external_metadata) ---
            */
            return default;
        }

        public async Task<TEntity> FetchGoogleDriveMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_google_drive_metadata) ---
            */
            return default;
        }

        public async Task<TEntity> FetchVimeoMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_vimeo_metadata) ---
            */
            return default;
        }

        public async Task<TEntity> FetchYoutubeMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_youtube_metadata) ---
            */
            return default;
        }

        public async Task<TEntity> FilterAddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object raise_on_access) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _filter_add_members) ---
            */
            return default;
        }

        public async Task<TEntity> FilterCombinationsImpossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination_tuples, object ignore_no_variant) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _filter_combinations_impossible_by_config) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_access_action) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_access_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object parent_name, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_attribute_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttributesExtraPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_attributes_extra_price) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAvailableCategoryDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid website_id) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _get_available_category_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAvailableSnippetCategoriesAsync<TEntity>(IEnumerable<TEntity> entities, Guid website_id) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: get_available_snippet_categories) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvailableUomsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_available_uoms) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvatar128AccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py, METHOD: _get_avatar_128_access_token) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: get_backend_menu_id) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: get_backend_menu_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetBadgeUserStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py, METHOD: _get_badge_user_stats) ---
            */
            return default;
        }

        public async Task<TEntity> GetBaseUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: get_base_url) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCanPublishErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_can_publish_error_message) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_can_publish_error_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetCategorizedSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_domain, object order, object force_void, object limit, object offset) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_categorized_slides) ---
            */
            return default;
        }

        public async Task<TEntity> GetChatbotLanguageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _get_chatbot_language) ---
            */
            return default;
        }

        public async Task<TEntity> GetClosestPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_closest_possible_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetClosestPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_closest_possible_combinations) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompletionTimePdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data_bytes) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_completion_time_pdf) ---
            */
            return default;
        }

        public async Task<TEntity> GetContextualPriceAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_contextual_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetContextualPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_contextual_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetContextualPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_contextual_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultEnrollMsgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_default_enroll_msg) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_default_uom_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultWelcomeMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _get_default_welcome_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetEarnedKarmaInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_earned_karma) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_empty_list_help) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_first_possible_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstPossibleVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_first_possible_variant_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetLengthUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_length_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetLengthUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_length_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        public async Task<TEntity> GetListPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_list_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetMappedAttributeNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_mapped_attribute_names) ---
            */
            return default;
        }

        public async Task<TEntity> GetNextCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_next_category) ---
            */
            return default;
        }

        public async Task<TEntity> GetOwnAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_own_attribute_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> GetOwnersInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py, METHOD: _get_owners_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetParentAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_parent_attribute_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> GetPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_placeholder_filename) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_placeholder_filename) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_placeholder_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_possible_combinations) ---
            */
            return default;
        }

        public async Task<TEntity> GetPossibleVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_possible_variants) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductDocumentDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_document_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_placeholder_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_price_context) ---
            */
            return default;
        }

        public async Task<TEntity> GetRelatedFieldsVariantTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_related_fields_variant_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetSingleProductVariantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_single_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> GetTagsFirstCharInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tags) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _get_tags_first_char) ---
            */
            return default;
        }

        public async Task<TEntity> GetVariantForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_variant_for_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetVariantIdForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filtered_combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_variant_id_for_combination) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetVolumeUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_volume_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetVolumeUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_volume_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWeightUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_weight_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWeightUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_weight_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        public async Task<TEntity> GetWelcomeStepsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _get_welcome_steps) ---
            */
            return default;
        }

        public async Task<TEntity> GoToWebsiteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: go_to_website) ---
            */
            return default;
        }

        public async Task<TEntity> HasDynamicAttributesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: has_dynamic_attributes) ---
            */
            return default;
        }

        public async Task<bool> HasMultipleUomsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _has_multiple_uoms) ---
            */
            return default;
        }

        public async Task<TEntity> InitColumnInternalAsync<TEntity>(IEnumerable<TEntity> entities, object column_name) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _init_column) ---
            */
            return default;
        }

        public async Task<TEntity> InverseIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: _inverse_is_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> IsCombinationPossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _is_combination_possible_by_config) ---
            */
            return default;
        }

        public async Task<TEntity> IsCombinationPossibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object parent_combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _is_combination_possible) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _mail_get_partner_fields) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _mail_get_partner_fields) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: message_post) ---
            */
            return default;
        }

        public async Task<TEntity> MoveCategorySlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object category, object new_category) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _move_category_slides) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameSearchAsync<TEntity>(IEnumerable<TEntity> entities, object name, object domain, object @operator, object limit) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: name_search) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        public async Task<TEntity> OnChangeDocumentBinaryContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _on_change_document_binary_content) ---
            */
            return default;
        }

        public async Task<TEntity> OnChangeSlideCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _on_change_slide_category) ---
            */
            return default;
        }

        public async Task<TEntity> OnChangeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _on_change_url) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeScriptStepIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _onchange_script_step_ids) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_uom_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeVideoUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_image.py, METHOD: _onchange_video_url) ---
            */
            return default;
        }

        public async Task<TEntity> PostPublicationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _post_publication) ---
            */
            return default;
        }

        public async Task<TEntity> PostWelcomeStepsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object discuss_channel) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _post_welcome_steps) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _prepare_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareVariantValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _prepare_variant_values) ---
            */
            return default;
        }

        public async Task<TEntity> PriceComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price_type, object uom, object currency, object company, object date) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _price_compute) ---
            */
            return default;
        }

        public async Task<TEntity> RatingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _rating_domain) ---
            */
            return default;
        }

        public async Task<TEntity> ReadGroupCategIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object categories, object domain) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _read_group_categ_id) ---
            */
            return default;
        }

        public async Task<TEntity> RemainingSendingCalcInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py, METHOD: _remaining_sending_calc) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveMembershipInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _remove_membership) ---
            */
            return default;
        }

        public async Task<TEntity> ResequenceSlidesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slide, object force_category) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _resequence_slides) ---
            */
            return default;
        }

        public async Task<TEntity> SearchBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_barcode) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_display_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchHasPublishedProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _search_has_published_products) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsAvailableAtInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: _search_is_available_at) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberChannelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invited) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member_channel_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberInvitedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member_invited) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_visible) ---
            */
            return default;
        }

        public async Task<TEntity> SearchPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchRenderResultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fetch_fields, object mapping, object icon, object limit) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _search_render_results) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_public_category.py, METHOD: _search_render_results) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _search_render_results) ---
            */
            return default;
        }

        public async Task<TEntity> SearchStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> SendShareEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object fullscreen) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _send_share_email) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _send_share_email) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<List<object>> ServiceTrackingBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            */
            return default;
        }

        public async Task<TEntity> SetBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> SetDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> SetDefaultFaqInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _set_default_faq) ---
            */
            return default;
        }

        public async Task<TEntity> SetProductVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_product_variant_field) ---
            */
            return default;
        }

        public async Task<TEntity> SetStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> SetVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_volume) ---
            */
            return default;
        }

        public async Task<TEntity> SetWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_weight) ---
            */
            return default;
        }

        public async Task<TEntity> SyncActiveFromRelatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: _sync_active_from_related) ---
            */
            return default;
        }

        public async Task<TEntity> SyncActiveProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product_category.py, METHOD: _sync_active_products) ---
            */
            return default;
        }

        public async Task<TEntity> TagToWriteValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tags) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _tag_to_write_vals) ---
            */
            return default;
        }

        public async Task<TEntity> ToStoreDefaultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_address, object discuss_channel) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _validate_email) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IImageMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_karma_rank.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_product.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: write) ---
            */
            return default;
        }
    }
}