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
    public partial class MailMailAppService
    {

        protected async Task<MailMail> CheckMailServerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_mail.py, METHOD: _check_mail_server_id) ---
            */
            return default;
        }

        protected async Task<MailMail> ComputeBodyContentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_mail.py, METHOD: _compute_body_content) ---
            */
            return default;
        }

        protected async Task<MailMail> ComputeMailMessageIdIntInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_mail.py, METHOD: _compute_mail_message_id_int) ---
            */
            return default;
        }

        protected async Task<MailMail> ComputeRestrictedAttachmentsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_mail.py, METHOD: _compute_restricted_attachments) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailMail> EstimateEmailSizeInternalAsync(object headers, object body, object attachments_size)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_mail.py, METHOD: _estimate_email_size) ---
            */
            return default;
        }

        protected async Task<MailMail> FilterMailMailServersInternalAsync(object mail_servers)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_mail.py, METHOD: _filter_mail_mail_servers) ---
            */
            return default;
        }

        protected async Task<MailMail> GcCanceledMailMailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mail_mail.py, METHOD: _gc_canceled_mail_mail) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailMail> GenerateMailRecipientTokenInternalAsync(Guid mail_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mail_mail.py, METHOD: _generate_mail_recipient_token) ---
            */
            return default;
        }

        protected async Task<MailMail> GetNotificationStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_mail.py, METHOD: _get_notification_status) ---
            */
            return default;
        }

        protected async Task<MailMail> GetNotificationValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_mail.py, METHOD: _get_notification_values) ---
            */
            return default;
        }

        protected async Task<MailMail> GetTrackingUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mail_mail.py, METHOD: _get_tracking_url) ---
            */
            return default;
        }

        protected async Task<MailMail> InverseUnrestrictedAttachmentIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_mail.py, METHOD: _inverse_unrestricted_attachment_ids) ---
            */
            return default;
        }

        protected async Task<MailMail> ParseScheduledDatetimeInternalAsync(object scheduled_datetime)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_mail.py, METHOD: _parse_scheduled_datetime) ---
            */
            return default;
        }

        protected async Task<MailMail> PersonalizeOutgoingBodyInternalAsync(object body, object partner, object doc_to_followers)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_mail.py, METHOD: _personalize_outgoing_body) ---
            */
            return default;
        }

        protected async Task<MailMail> PostprocessSentMessageInternalAsync(object success_pids, object success_emails, object failure_reason, object failure_type)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_mail.py, METHOD: _postprocess_sent_message) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mail_mail.py, METHOD: _postprocess_sent_message) ---
            */
            return default;
        }

        protected async Task<MailMail> PrepareOutgoingBodyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_mail.py, METHOD: _prepare_outgoing_body) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mail_mail.py, METHOD: _prepare_outgoing_body) ---
            */
            return default;
        }

        protected async Task<MailMail> PrepareOutgoingListInternalAsync(object mail_server, object doc_to_followers)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_mail.py, METHOD: _prepare_outgoing_list) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mail_mail.py, METHOD: _prepare_outgoing_list) ---
            */
            return default;
        }

        protected async Task<MailMail> SearchBodyContentInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_mail.py, METHOD: _search_body_content) ---
            */
            return default;
        }

        protected async Task<MailMail> SendInternalAsync(object auto_commit, object raise_exception, object smtp_session, Guid alias_domain_id, object mail_server, object post_send_callback)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_mail.py, METHOD: _send) ---
            */
            return default;
        }

        protected async Task<MailMail> SplitByDelayedBatchInternalAsync(object mail_server)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_mail.py, METHOD: _split_by_delayed_batch) ---
            */
            return default;
        }

        protected async Task<MailMail> SplitByMailConfigurationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_mail.py, METHOD: _split_by_mail_configuration) ---
            */
            return default;
        }
    }
}