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
    public partial class SlideChannelAppService
    {

        protected async Task<SlideChannel> ActionAddMembersInternalAsync(object target_partners, object member_status, object raise_on_access)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills_slides, FILE: slide_channel.py, METHOD: _action_add_members) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_add_members) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ActionChannelOpenInviteWizardInternalAsync(object mail_template, object enroll_mode)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_channel_open_invite_wizard) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ActionRequestAccessInternalAsync(object partner)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _action_request_access) ---
            */
            return default;
        }

        protected async Task<SlideChannel> AddGroupsMembersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _add_groups_members) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SlideChannel> AllowPublishRatingStatsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _allow_publish_rating_stats) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputeActionRightsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_action_rights) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputeAllowCommentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_allow_comment) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputeCanPublishInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_can_publish) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputeCanUploadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_can_upload) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputeCategoryAndSlideIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_category_and_slide_ids) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputeEnrollInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_enroll) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SlideChannel> ComputeHasRequestedAccessInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_has_requested_access) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputeIsVisibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_is_visible) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputeMembersCertifiedCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides_survey, FILE: slide_channel.py, METHOD: _compute_members_certified_count) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputeMembersCountsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_members_counts) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputeMembershipValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_membership_values) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputePartnerHasNewContentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_partner_has_new_content) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputePartnersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_partners) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputePrerequisiteUserHasCompletedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_prerequisite_user_has_completed) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputeProductSaleRevenuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: slide_channel.py, METHOD: _compute_product_sale_revenues) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputeRatingStatsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_rating_stats) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputeSlideLastUpdateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_slide_last_update) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputeSlidesStatisticsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_slides_statistics) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputeUserStatisticsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_user_statistics) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputeWebsiteAbsoluteUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_absolute_url) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputeWebsiteDefaultBackgroundImageUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_default_background_image_url) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ComputeWebsiteUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        protected async Task<SlideChannel> DefaultAccessTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _default_access_token) ---
            */
            return default;
        }

        protected async Task<SlideChannel> DefaultCoverPropertiesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _default_cover_properties) ---
            */
            return default;
        }

        protected async Task<SlideChannel> FilterAddMembersInternalAsync(object raise_on_access)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _filter_add_members) ---
            */
            return default;
        }

        protected async Task<SlideChannel> GetAccessActionInternalAsync(object access_uid, object force_website)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_access_action) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SlideChannel> GetCanPublishErrorMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_can_publish_error_message) ---
            */
            return default;
        }

        protected async Task<SlideChannel> GetCategorizedSlidesInternalAsync(object base_domain, object order, object force_void, object limit, object offset)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_categorized_slides) ---
            */
            return default;
        }

        protected async Task<SlideChannel> GetDefaultEnrollMsgInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_default_enroll_msg) ---
            */
            return default;
        }

        protected async Task<SlideChannel> GetDefaultProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: slide_channel.py, METHOD: _get_default_product_id) ---
            */
            return default;
        }

        protected async Task<SlideChannel> GetEarnedKarmaInternalAsync(List<Guid> partner_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_earned_karma) ---
            */
            return default;
        }

        protected async Task<SlideChannel> GetPlaceholderFilenameInternalAsync(object field)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _get_placeholder_filename) ---
            */
            return default;
        }

        protected async Task<SlideChannel> InitColumnInternalAsync(object column_name)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _init_column) ---
            */
            return default;
        }

        protected async Task<SlideChannel> MailGetPartnerFieldsInternalAsync(object introspect_fields)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _mail_get_partner_fields) ---
            */
            return default;
        }

        protected async Task<SlideChannel> MessageEmployeeChatterInternalAsync(object msg, object partners)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills_slides, FILE: slide_channel.py, METHOD: _message_employee_chatter) ---
            */
            return default;
        }

        protected async Task<SlideChannel> MoveCategorySlidesInternalAsync(object category, object new_category)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _move_category_slides) ---
            */
            return default;
        }

        protected async Task<SlideChannel> RatingDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _rating_domain) ---
            */
            return default;
        }

        protected async Task<SlideChannel> RemoveMembershipInternalAsync(List<Guid> partner_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_skills_slides, FILE: slide_channel.py, METHOD: _remove_membership) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _remove_membership) ---
            --- METHOD SOURCE (MODULE: website_slides_survey, FILE: slide_channel.py, METHOD: _remove_membership) ---
            */
            return default;
        }

        protected async Task<SlideChannel> ResequenceSlidesInternalAsync(object slide, object force_category)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _resequence_slides) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SlideChannel> SearchGetDetailInternalAsync(object website, object order, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        protected async Task<SlideChannel> SearchIsMemberChannelIdsInternalAsync(object invited)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member_channel_ids) ---
            */
            return default;
        }

        protected async Task<SlideChannel> SearchIsMemberInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member) ---
            */
            return default;
        }

        protected async Task<SlideChannel> SearchIsMemberInvitedInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_member_invited) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<SlideChannel> SearchIsVisibleInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_is_visible) ---
            */
            return default;
        }

        protected async Task<SlideChannel> SearchPartnerIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _search_partner_ids) ---
            */
            return default;
        }

        protected async Task<SlideChannel> SendShareEmailInternalAsync(object emails)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_channel.py, METHOD: _send_share_email) ---
            */
            return default;
        }

        protected async Task<SlideChannel> SynchronizeProductPublishInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_slides, FILE: slide_channel.py, METHOD: _synchronize_product_publish) ---
            */
            return default;
        }
    }
}