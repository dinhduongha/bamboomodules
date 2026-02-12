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
    [Module("utm", Category = "Marketing", Depends = new[] { "base", "web" })]
    public partial class UtmSourceMixinAppService : ApplicationService, IUtmSourceMixinAppService
    {

        public UtmSourceMixinAppService() 
        {

        }

        public async Task<TEntity> ActionCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCompareVersionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_compare_versions) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDuplicateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_duplicate) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ActionFetchFavoritesAsync<TEntity>(IEnumerable<TEntity> entities, object extra_domain) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_fetch_favorites) ---
            */
            return default;
        }

        public async Task<TEntity> ActionLaunchAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_launch) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPutInQueueAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_put_in_queue) ---
            */
            return default;
        }

        public async Task<TEntity> ActionReloadAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_reload) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRemoveFavoriteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_remove_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRetryFailedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_retry_failed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionScheduleAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_schedule) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSelectAsWinnerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_select_as_winner) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendMailAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_send_mail) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _action_send_mail) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _action_send_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendWinnerMailingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_send_winner_mailing) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetFavoriteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_set_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTestAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_test) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewBouncedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_bounced) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewClickedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_clicked) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewDeliveredAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_delivered) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewDocumentsFilteredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_filter) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _action_view_documents_filtered) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewLinkTrackersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_link_trackers) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewLivechatChannelsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: action_view_livechat_channels) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewMailingContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_mailing_contacts) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewOpenedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_opened) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRepliedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_replied) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesCanceledAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_canceled) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesFailedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_failed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesFilteredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_filter) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _action_view_traces_filtered) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesProcessAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_process) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesScheduledAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_scheduled) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_sent) ---
            */
            return default;
        }

        public async Task<TEntity> CheckMailingFilterModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _check_mailing_filter_model) ---
            */
            return default;
        }

        public async Task<TEntity> CheckQuestionSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _check_question_selection) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAbTestingDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_ab_testing_description) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAbTestingIsWinnerMailingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_ab_testing_is_winner_mailing) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCalendarDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_calendar_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeClicksRatioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_clicks_ratio) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_email_from) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFavoriteDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_favorite_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFirstStepWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _compute_first_step_warning) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_recruitment_source.py, METHOD: _compute_has_domain) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsAbTestSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_is_ab_test_sent) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsBodyEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_is_body_empty) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkTrackersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_link_trackers_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLivechatChannelCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _compute_livechat_channel_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailServerAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mail_server_available) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_domain) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingFilterCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_filter_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingFilterIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_filter_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingModelRealInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_model_real) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingOnMailingListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_on_mailing_list) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingTypeDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_type_description) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMediumIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_medium_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNextDepartureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_next_departure) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRenderModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_render_model) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_reply_to) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReplyToModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_reply_to_mode) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeScheduleDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_schedule_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_total) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWarningMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_warning_message) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertInlineImagesToUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object html_content) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _convert_inline_images_to_urls) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertLinksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: convert_links) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: utm, FILE: utm_source.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAbTestingUtmCampaignsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _create_ab_testing_utm_campaigns) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAliasAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_recruitment_source.py, METHOD: create_alias) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAndGetAliasAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_recruitment_source.py, METHOD: create_and_get_alias) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: utm, FILE: utm_source.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAttachmentsFromInlineImagesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object b64images) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _create_attachments_from_inline_images) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: utm, FILE: utm_source.py, METHOD: default_get) ---
            */
            return default;
        }

        public async Task<TEntity> FixAttachmentOwnershipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _fix_attachment_ownership) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateMailingRecipientTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid document_id, object email) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _generate_mailing_recipient_token) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateMailingReportTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _generate_mailing_report_token) ---
            */
            return default;
        }

        public async Task<TEntity> GetAbTestingDescriptionModifyingFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_ab_testing_description_modifying_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetAbTestingDescriptionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_ab_testing_description_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetAbTestingSiblingsMailingsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_ab_testing_siblings_mailings) ---
            */
            return default;
        }

        public async Task<TEntity> GetAbTestingWinnerSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_ab_testing_winner_selection) ---
            */
            return default;
        }

        public async Task<TEntity> GetChatbotLanguageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _get_chatbot_language) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultAbTestingCampaignValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_default_ab_testing_campaign_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultMailServerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_default_mail_server_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultMailingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_default_mailing_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetImageByUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url, object session) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_image_by_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetLinkTrackerValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_link_tracker_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetMassMailingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_mass_mailing_context) ---
            */
            return default;
        }

        public async Task<TEntity> GetOptOutListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_opt_out_list) ---
            */
            return default;
        }

        public async Task<TEntity> GetPrettyMailingTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_pretty_mailing_type) ---
            */
            return default;
        }

        public async Task<TEntity> GetRecipientsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_recipients_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_recipients) ---
            */
            return default;
        }

        public async Task<TEntity> GetRemainingRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_remaining_recipients) ---
            */
            return default;
        }

        public async Task<TEntity> GetSeenListExtraInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_seen_list_extra) ---
            */
            return default;
        }

        public async Task<TEntity> GetSeenListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_seen_list) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnsubscribeOneclickUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to, Guid res_id) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_unsubscribe_oneclick_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnsubscribeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to, Guid res_id) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_unsubscribe_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetViewUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to, Guid res_id) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_view_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetWelcomeStepsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _get_welcome_steps) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeScriptStepIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _onchange_script_step_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ParseMailingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _parse_mailing_domain) ---
            */
            return default;
        }

        public async Task<TEntity> PostWelcomeStepsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object discuss_channel) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _post_welcome_steps) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareStatisticsEmailValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _prepare_statistics_email_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ProcessMassMailingQueueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _process_mass_mailing_queue) ---
            */
            return default;
        }

        public async Task<TEntity> ToStoreDefaultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_recruitment_source.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_address, object discuss_channel) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: _validate_email) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IUtmSourceMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: chatbot_script.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: utm, FILE: utm_source.py, METHOD: write) ---
            */
            return default;
        }
    }
}