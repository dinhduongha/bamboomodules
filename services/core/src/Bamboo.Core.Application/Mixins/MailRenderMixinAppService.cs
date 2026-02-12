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
    [Module("mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public partial class MailRenderMixinAppService : ApplicationService, IMailRenderMixinAppService
    {

        public MailRenderMixinAppService() 
        {

        }

        public async Task<TEntity> ActionCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCompareVersionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_compare_versions) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateSidebarActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_template.py, METHOD: action_create_sidebar_action) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDuplicateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_duplicate) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ActionFetchFavoritesAsync<TEntity>(IEnumerable<TEntity> entities, object extra_domain) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_fetch_favorites) ---
            */
            return default;
        }

        public async Task<TEntity> ActionLaunchAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_launch) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenMailPreviewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: action_open_mail_preview) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPreviewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: action_preview) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPutInQueueAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_put_in_queue) ---
            */
            return default;
        }

        public async Task<TEntity> ActionReloadAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_reload) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRemoveFavoriteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_remove_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRetryFailedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_retry_failed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionScheduleAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_schedule) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSelectAsWinnerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_select_as_winner) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendMailAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_send_mail) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _action_send_mail) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _action_send_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendWinnerMailingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_send_winner_mailing) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetFavoriteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_set_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShareAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: action_share) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShareGetDefaultBodyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _action_share_get_default_body) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTestAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_test) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnlinkSidebarActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: sms_template.py, METHOD: action_unlink_sidebar_action) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewBouncedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_bounced) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewCardsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: action_view_cards) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewCardsClickedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: action_view_cards_clicked) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewCardsSharedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: action_view_cards_shared) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewClickedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_clicked) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewDeliveredAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_delivered) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewDocumentsFilteredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_filter) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _action_view_documents_filtered) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewLinkTrackersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_link_trackers) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewMailingContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_mailing_contacts) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewMailingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: action_view_mailings) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewOpenedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_opened) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRepliedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_replied) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesCanceledAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_canceled) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesFailedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_failed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesFilteredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_filter) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _action_view_traces_filtered) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesProcessAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_process) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesScheduledAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_scheduled) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_sent) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> BuildExpressionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object sub_field_name, object null_value) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _build_expression) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAbstractModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _check_abstract_models) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAccessRightDynamicTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _check_access_right_dynamic_template) ---
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _check_access_right_dynamic_template) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCanBeRenderedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fnames, object render_options) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _check_can_be_rendered) ---
            */
            return default;
        }

        public async Task<TEntity> CheckMailingFilterModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _check_mailing_filter_model) ---
            */
            return default;
        }

        public async Task<TEntity> ClassifyPerLangInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object engine) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _classify_per_lang) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAbTestingDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_ab_testing_description) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAbTestingIsWinnerMailingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_ab_testing_is_winner_mailing) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBodyHasTemplateValueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py, METHOD: _compute_body_has_template_value) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBodyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py, METHOD: _compute_body) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCalendarDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_calendar_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanEditBodyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py, METHOD: _compute_can_edit_body) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _compute_can_write) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCardStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _compute_card_stats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeClicksRatioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_clicks_ratio) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_email_from) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFavoriteDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_favorite_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasDynamicReportsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _compute_has_dynamic_reports) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasMailServerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _compute_has_mail_server) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImagePreviewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _compute_image_preview) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsAbTestSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_is_ab_test_sent) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsBodyEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_is_body_empty) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMailTemplateEditorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py, METHOD: _compute_is_mail_template_editor) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsTemplateEditorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _compute_is_template_editor) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py, METHOD: _compute_lang) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkTrackersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_link_trackers_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailServerAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mail_server_available) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _compute_mailing_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_domain) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingFilterCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_filter_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingFilterIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_filter_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingModelRealInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_model_real) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingOnMailingListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_on_mailing_list) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingTypeDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_type_description) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMediumIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_medium_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNextDepartureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_next_departure) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRenderModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _compute_render_model) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _compute_render_model) ---
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _compute_render_model) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_render_model) ---
            --- METHOD SOURCE (MODULE: sms, FILE: sms_template.py, METHOD: _compute_render_model) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_reply_to) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReplyToModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_reply_to_mode) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeResModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _compute_res_model) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeScheduleDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_schedule_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSubjectInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py, METHOD: _compute_subject) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTemplateCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _compute_template_category) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_total) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWarningMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_warning_message) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertInlineImagesToUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object html_content) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _convert_inline_images_to_urls) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertLinksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: convert_links) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: sms, FILE: sms_template.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAbTestingUtmCampaignsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _create_ab_testing_utm_campaigns) ---
            */
            return default;
        }

        public async Task<TEntity> CreateActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: create_action) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAttachmentsFromInlineImagesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object b64images) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _create_attachments_from_inline_images) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCardTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _default_card_template_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: sms, FILE: sms_template.py, METHOD: default_get) ---
            */
            return default;
        }

        public async Task<TEntity> ExpressionIsDefaultInternalAsync<TEntity>(IEnumerable<TEntity> entities, object source, object model, object fname) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _expression_is_default) ---
            */
            return default;
        }

        public async Task<TEntity> FetchOrCreatePreviewCardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _fetch_or_create_preview_card) ---
            */
            return default;
        }

        public async Task<TEntity> FixAttachmentOwnershipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _fix_attachment_ownership) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _fix_attachment_ownership) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateMailingRecipientTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid document_id, object email) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _generate_mailing_recipient_token) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateMailingReportTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _generate_mailing_report_token) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateTemplateAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object render_results) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _generate_template_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object recipients_allow_suggested, object find_or_create_partners) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _generate_template) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateTemplateRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object allow_suggested, object find_or_create_partners, object render_results) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _generate_template_recipients) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateTemplateScheduledDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_results) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _generate_template_scheduled_date) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateTemplateStaticValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object render_fields, object render_results) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _generate_template_static_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetAbTestingDescriptionModifyingFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_ab_testing_description_modifying_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetAbTestingDescriptionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_ab_testing_description_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetAbTestingSiblingsMailingsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_ab_testing_siblings_mailings) ---
            */
            return default;
        }

        public async Task<TEntity> GetAbTestingWinnerSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_ab_testing_winner_selection) ---
            */
            return default;
        }

        public async Task<TEntity> GetCardElementValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _get_card_element_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultAbTestingCampaignValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_default_ab_testing_campaign_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultMailServerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_default_mail_server_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultMailingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_default_mailing_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetDynamicFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _get_dynamic_field_names) ---
            */
            return default;
        }

        public async Task<TEntity> GetImageB64InternalAsync<TEntity>(IEnumerable<TEntity> entities, object record) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _get_image_b64) ---
            */
            return default;
        }

        public async Task<TEntity> GetImageByUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url, object session) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_image_by_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetLinkTrackerValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_link_tracker_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetMassMailingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_mass_mailing_context) ---
            */
            return default;
        }

        public async Task<TEntity> GetModelSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _get_model_selection) ---
            */
            return default;
        }

        public async Task<TEntity> GetNonAbstractModelsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _get_non_abstract_models_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetOptOutListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_opt_out_list) ---
            */
            return default;
        }

        public async Task<TEntity> GetPrettyMailingTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_pretty_mailing_type) ---
            */
            return default;
        }

        public async Task<TEntity> GetRecipientsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_recipients_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_recipients) ---
            */
            return default;
        }

        public async Task<TEntity> GetRemainingRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_remaining_recipients) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRenderFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _get_render_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetSeenListExtraInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_seen_list_extra) ---
            */
            return default;
        }

        public async Task<TEntity> GetSeenListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_seen_list) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnsubscribeOneclickUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to, Guid res_id) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_unsubscribe_oneclick_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnsubscribeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to, Guid res_id) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_unsubscribe_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetUrlFromResIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid res_id, object suffix) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _get_url_from_res_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetViewUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to, Guid res_id) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_view_url) ---
            */
            return default;
        }

        public async Task<TEntity> HasUnsafeExpressionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _has_unsafe_expression) ---
            */
            return default;
        }

        public async Task<TEntity> HasUnsafeExpressionTemplateInlineTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object source, object model, object fname) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _has_unsafe_expression_template_inline_template) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _has_unsafe_expression_template_inline_template) ---
            */
            return default;
        }

        public async Task<TEntity> HasUnsafeExpressionTemplateQwebInternalAsync<TEntity>(IEnumerable<TEntity> entities, object source, object model, object fname) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _has_unsafe_expression_template_qweb) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _has_unsafe_expression_template_qweb) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _onchange_model) ---
            */
            return default;
        }

        public async Task<TEntity> ParseMailingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _parse_mailing_domain) ---
            */
            return default;
        }

        protected async Task<object> ParsePartnerToInternalAsync(object partner_to)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _parse_partner_to) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareStatisticsEmailValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _prepare_statistics_email_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrependPreviewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object html, object preview) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _prepend_preview) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ProcessMassMailingQueueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _process_mass_mailing_queue) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ProcessScheduledDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object scheduled_date) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _process_scheduled_date) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RenderEncapsulateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object layout_xmlid, object html, object add_context, object context_record) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _render_encapsulate) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RenderEvalContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _render_eval_context) ---
            */
            return default;
        }

        public async Task<TEntity> RenderFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, List<Guid> res_ids, object engine, object compute_lang, object res_ids_lang, object set_lang, object add_context, object options) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py, METHOD: _render_field) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _render_field) ---
            */
            return default;
        }

        public async Task<TEntity> RenderLangInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object engine) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_composer_mixin.py, METHOD: _render_lang) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _render_lang) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RenderTemplateGetValidOptionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _render_template_get_valid_options) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RenderTemplateInlineTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_txt, object model, List<Guid> res_ids, object add_context, object options) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _render_template_inline_template) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RenderTemplateInlineTemplateRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_txt, object model, List<Guid> res_ids) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _render_template_inline_template_regex) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RenderTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_src, object model, List<Guid> res_ids, object engine, object add_context, object options) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _render_template) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RenderTemplatePostprocessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object rendered) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _render_template_postprocess) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mail_render_mixin.py, METHOD: _render_template_postprocess) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RenderTemplateQwebInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_src, object model, List<Guid> res_ids, object add_context, object options) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _render_template_qweb) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RenderTemplateQwebRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_src, object model, List<Guid> res_ids) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _render_template_qweb_regex) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RenderTemplateQwebViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_ref, object model, List<Guid> res_ids, object add_context, object options) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _render_template_qweb_view) ---
            */
            return default;
        }

        public async Task<TEntity> ReplaceLocalLinksInternalAsync<TEntity>(IEnumerable<TEntity> entities, object html, object base_url) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _replace_local_links) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchTemplateCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _search_template_category) ---
            */
            return default;
        }

        public async Task<TEntity> SendCheckAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: _send_check_access) ---
            */
            return default;
        }

        public async Task<TEntity> SendMailAsync<TEntity>(IEnumerable<TEntity> entities, Guid res_id, object force_send, object raise_exception, object email_values, object email_layout_xmlid) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: send_mail) ---
            */
            return default;
        }

        public async Task<TEntity> SendMailBatchAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids, object force_send, object raise_exception, object email_values, object email_layout_xmlid) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: send_mail_batch) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ShortenLinksInternalAsync<TEntity>(IEnumerable<TEntity> entities, object html, object link_tracker_vals, object blacklist, object base_url) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: mail_render_mixin.py, METHOD: _shorten_links) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ShortenLinksTextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object content, object link_tracker_vals, object blacklist, object base_url) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: link_tracker, FILE: mail_render_mixin.py, METHOD: _shorten_links_text) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: unlink_action) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: sms, FILE: sms_template.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateCardsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object auto_commit) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _update_cards) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateFieldTranslationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object translations, object digest, object source_lang) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _update_field_translations) ---
            */
            return default;
        }

        public async Task<TEntity> ValidFieldParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object name) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: _valid_field_parameter) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailRenderMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_render_mixin.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_template.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: write) ---
            */
            return default;
        }
    }
}