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
    public partial class MailingMailingAppService
    {

        protected async Task<MailingMailing> ActionSendMailInternalAsync(List<Guid> res_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _action_send_mail) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: _action_send_mail) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ActionSendStatisticsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _action_send_statistics) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ActionViewDocumentsFilteredInternalAsync(object view_filter)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _action_view_documents_filtered) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ActionViewTracesFilteredInternalAsync(object view_filter)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _action_view_traces_filtered) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: _action_view_traces_filtered) ---
            */
            return default;
        }

        protected async Task<MailingMailing> CheckMailingDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: mailing_mailing.py, METHOD: _check_mailing_domain) ---
            */
            return default;
        }

        protected async Task<MailingMailing> CheckMailingFilterModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _check_mailing_filter_model) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeAbTestingDescriptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_ab_testing_description) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeAbTestingIsWinnerMailingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_ab_testing_is_winner_mailing) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeBodyPlaintextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: _compute_body_plaintext) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeCalendarDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_calendar_date) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeCardRequiresSyncCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: mailing_mailing.py, METHOD: _compute_card_requires_sync_count) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeClicksRatioInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_clicks_ratio) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeCrmLeadCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_crm, FILE: mailing_mailing.py, METHOD: _compute_crm_lead_count) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeEmailFromInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_email_from) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeFavoriteDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_favorite_date) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeIsAbTestSentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_is_ab_test_sent) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeIsBodyEmptyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_is_body_empty) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeLinkTrackersCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_link_trackers_count) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeMailServerAvailableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mail_server_available) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeMailingDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_domain) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeMailingFilterCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_filter_count) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeMailingFilterIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_filter_id) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeMailingModelIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: mailing_mailing.py, METHOD: _compute_mailing_model_id) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeMailingModelRealInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_model_real) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeMailingOnMailingListInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_on_mailing_list) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeMailingTypeDescriptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_type_description) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeMediumIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_medium_id) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: _compute_medium_id) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeNextDepartureInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_next_departure) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeRenderModelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_render_model) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeReplyToInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_reply_to) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeReplyToModeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_reply_to_mode) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeSaleInvoicedAmountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sale, FILE: mailing_mailing.py, METHOD: _compute_sale_invoiced_amount) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeSaleQuotationCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sale, FILE: mailing_mailing.py, METHOD: _compute_sale_quotation_count) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeScheduleDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_schedule_date) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeSmsHasIapFailureInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: _compute_sms_has_iap_failure) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeStatisticsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_statistics) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeTotalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_total) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeUseLeadsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_crm, FILE: mailing_mailing.py, METHOD: _compute_use_leads) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ComputeWarningMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_warning_message) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ConvertInlineImagesToUrlsInternalAsync(object html_content)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _convert_inline_images_to_urls) ---
            */
            return default;
        }

        protected async Task<MailingMailing> CreateAbTestingUtmCampaignsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _create_ab_testing_utm_campaigns) ---
            */
            return default;
        }

        protected async Task<MailingMailing> CreateAttachmentsFromInlineImagesInternalAsync(object b64images)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _create_attachments_from_inline_images) ---
            */
            return default;
        }

        protected async Task<MailingMailing> FixAttachmentOwnershipInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _fix_attachment_ownership) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GenerateMailingRecipientTokenInternalAsync(Guid document_id, object email)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _generate_mailing_recipient_token) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GenerateMailingReportTokenInternalAsync(Guid user_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _generate_mailing_report_token) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetAbTestingDescriptionModifyingFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_ab_testing_description_modifying_fields) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: _get_ab_testing_description_modifying_fields) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetAbTestingDescriptionValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_ab_testing_description_values) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: _get_ab_testing_description_values) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetAbTestingSiblingsMailingsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_ab_testing_siblings_mailings) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: _get_ab_testing_siblings_mailings) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetAbTestingWinnerSelectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_ab_testing_winner_selection) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: _get_ab_testing_winner_selection) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetDefaultAbTestingCampaignValuesInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_default_ab_testing_campaign_values) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: _get_default_ab_testing_campaign_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailingMailing> GetDefaultMailServerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_default_mail_server_id) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetDefaultMailingDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_default_mailing_domain) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetImageByUrlInternalAsync(object url, object session)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_image_by_url) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetLinkTrackerValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_link_tracker_values) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetMassMailingContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_mass_mailing_context) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetOptOutListInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_opt_out_list) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetOptOutListSmsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: _get_opt_out_list_sms) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetPrettyMailingTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_pretty_mailing_type) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: _get_pretty_mailing_type) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetRecipientsDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: mailing_mailing.py, METHOD: _get_recipients_domain) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_recipients_domain) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetRecipientsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_recipients) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetRemainingRecipientsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_remaining_recipients) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetSeenListExtraInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_seen_list_extra) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetSeenListInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_seen_list) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetSeenListSmsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: _get_seen_list_sms) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetUnsubscribeOneclickUrlInternalAsync(object email_to, Guid res_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_unsubscribe_oneclick_url) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetUnsubscribeUrlInternalAsync(object email_to, Guid res_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_unsubscribe_url) ---
            */
            return default;
        }

        protected async Task<MailingMailing> GetViewUrlInternalAsync(object email_to, Guid res_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_view_url) ---
            */
            return default;
        }

        protected async Task<MailingMailing> ParseMailingDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _parse_mailing_domain) ---
            */
            return default;
        }

        protected async Task<MailingMailing> PrepareStatisticsEmailValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _prepare_statistics_email_values) ---
            --- METHOD SOURCE (MODULE: mass_mailing_crm, FILE: mailing_mailing.py, METHOD: _prepare_statistics_email_values) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sale, FILE: mailing_mailing.py, METHOD: _prepare_statistics_email_values) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: _prepare_statistics_email_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailingMailing> ProcessMassMailingQueueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _process_mass_mailing_queue) ---
            */
            return default;
        }

        protected async Task<MailingMailing> SendSmsGetComposerValuesInternalAsync(List<Guid> res_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: _send_sms_get_composer_values) ---
            */
            return default;
        }
    }
}