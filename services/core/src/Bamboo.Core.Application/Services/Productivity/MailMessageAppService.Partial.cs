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
    public partial class MailMessageAppService
    {

        protected async Task<MailMessage> BusChannelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _bus_channel) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _bus_channel) ---
            */
            return default;
        }

        protected async Task<MailMessage> BusSendReactionGroupInternalAsync(object content)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _bus_send_reaction_group) ---
            */
            return default;
        }

        protected async Task<MailMessage> CheckAccessInternalAsync(string operation)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _check_access) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputeAccountAuditLogAccountIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_message.py, METHOD: _compute_account_audit_log_account_id) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputeAccountAuditLogCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_message.py, METHOD: _compute_account_audit_log_company_id) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputeAccountAuditLogMoveIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_message.py, METHOD: _compute_account_audit_log_move_id) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputeAccountAuditLogPartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_message.py, METHOD: _compute_account_audit_log_partner_id) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputeAccountAuditLogPreviewInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_message.py, METHOD: _compute_account_audit_log_preview) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputeAccountAuditLogRestrictedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_message.py, METHOD: _compute_account_audit_log_restricted) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputeAccountAuditLogTaxIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_message.py, METHOD: _compute_account_audit_log_tax_id) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputeAuditLogRelatedRecordIdInternalAsync(object model, object fname)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_message.py, METHOD: _compute_audit_log_related_record_id) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputeChannelIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _compute_channel_id) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputeHasErrorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _compute_has_error) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputeHasSmsErrorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: mail_message.py, METHOD: _compute_has_sms_error) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputeIsCurrentUserOrGuestAuthorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _compute_is_current_user_or_guest_author) ---
            --- METHOD SOURCE (MODULE: portal, FILE: mail_message.py, METHOD: _compute_is_current_user_or_guest_author) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputeLinkedMessageIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _compute_linked_message_ids) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputeNeedactionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _compute_needaction) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputePreviewInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _compute_preview) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputeRatingIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: mail_message.py, METHOD: _compute_rating_id) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputeRatingValueInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: mail_message.py, METHOD: _compute_rating_value) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputeRecordNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _compute_record_name) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputeSnailmailErrorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: mail_message.py, METHOD: _compute_snailmail_error) ---
            */
            return default;
        }

        protected async Task<MailMessage> ComputeStarredInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _compute_starred) ---
            */
            return default;
        }

        protected async Task<MailMessage> ExceptAuditLogInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_message.py, METHOD: _except_audit_log) ---
            */
            return default;
        }

        protected async Task<MailMessage> ExtrasToStoreInternalAsync(object store, object format_reply)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _extras_to_store) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _extras_to_store) ---
            */
            return default;
        }

        protected async Task<MailMessage> FieldStoreReprInternalAsync(object field_name)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _field_store_repr) ---
            */
            return default;
        }

        protected async Task<MailMessage> FilterEmptyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _filter_empty) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailMessage> FindAllowedDocIdsInternalAsync(List<Guid> model_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _find_allowed_doc_ids) ---
            */
            return default;
        }

        protected async Task<MailMessage> GetForbiddenAccessInternalAsync(string operation)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _get_forbidden_access) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailMessage> GetMessageIdInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _get_message_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailMessage> GetReplyToInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _get_reply_to) ---
            */
            return default;
        }

        protected async Task<MailMessage> GetSearchDomainShareInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _get_search_domain_share) ---
            */
            return default;
        }

        protected async Task<MailMessage> GetStoreAttachmentFieldsInternalAsync(object target)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _get_store_attachment_fields) ---
            */
            return default;
        }

        protected async Task<MailMessage> GetStoreLinkedMessagesFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _get_store_linked_messages_fields) ---
            */
            return default;
        }

        protected async Task<MailMessage> GetStorePartnerNameFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: mail_message.py, METHOD: _get_store_partner_name_fields) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _get_store_partner_name_fields) ---
            */
            return default;
        }

        protected async Task<MailMessage> GetTrackingValuesDomainInternalAsync(object search_term)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _get_tracking_values_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailMessage> GetWithAccessInternalAsync(Guid message_id, object mode)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _get_with_access) ---
            */
            return default;
        }

        protected async Task<MailMessage> InvalidateDocumentsInternalAsync(object model, Guid res_id)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _invalidate_documents) ---
            */
            return default;
        }

        protected async Task<MailMessage> IsEmptyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _is_empty) ---
            --- METHOD SOURCE (MODULE: rating, FILE: mail_message.py, METHOD: _is_empty) ---
            */
            return default;
        }

        protected async Task<MailMessage> IsThreadMessageInternalAsync(object vals, object thread)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _is_thread_message) ---
            */
            return default;
        }

        protected async Task<MailMessage> IsThreadMessageVisibleInternalAsync(object vals, object thread)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _is_thread_message_visible) ---
            */
            return default;
        }

        protected async Task<object> MakeAccessErrorInternalAsync(string operation)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _make_access_error) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailMessage> MessageFetchInternalAsync(object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _message_fetch) ---
            */
            return default;
        }

        protected async Task<MailMessage> MessageNotificationsToStoreInternalAsync(object store)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _message_notifications_to_store) ---
            */
            return default;
        }

        protected async Task<MailMessage> MessageReactionInternalAsync(object content, object action, object partner, object guest, object store)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _message_reaction) ---
            */
            return default;
        }

        protected async Task<MailMessage> NotifyMessageNotificationUpdateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _notify_message_notification_update) ---
            */
            return default;
        }

        protected async Task<MailMessage> PortalGetDefaultFormatPropertiesNamesInternalAsync(object options)
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: mail_message.py, METHOD: _portal_get_default_format_properties_names) ---
            --- METHOD SOURCE (MODULE: portal_rating, FILE: mail_message.py, METHOD: _portal_get_default_format_properties_names) ---
            */
            return default;
        }

        protected async Task<MailMessage> PortalMessageFormatAttachmentsInternalAsync(object attachment_values)
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: mail_message.py, METHOD: _portal_message_format_attachments) ---
            */
            return default;
        }

        protected async Task<MailMessage> PortalMessageFormatInternalAsync(object properties_names, object options)
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: mail_message.py, METHOD: _portal_message_format) ---
            --- METHOD SOURCE (MODULE: portal_rating, FILE: mail_message.py, METHOD: _portal_message_format) ---
            */
            return default;
        }

        protected async Task<MailMessage> PortalMessageFormatRatingInternalAsync(object rating_values)
        {
            /*
            --- METHOD SOURCE (MODULE: portal_rating, FILE: mail_message.py, METHOD: _portal_message_format_rating) ---
            */
            return default;
        }

        protected async Task<MailMessage> ReactionGroupToStoreInternalAsync(object store, object content)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _reaction_group_to_store) ---
            */
            return default;
        }

        protected async Task<MailMessage> RecordByMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _record_by_message) ---
            */
            return default;
        }

        protected async Task<MailMessage> RecordsByModelNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _records_by_model_name) ---
            */
            return default;
        }

        protected async Task<MailMessage> SearchAccountAuditLogAccountIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_message.py, METHOD: _search_account_audit_log_account_id) ---
            */
            return default;
        }

        protected async Task<MailMessage> SearchAccountAuditLogCompanyIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_message.py, METHOD: _search_account_audit_log_company_id) ---
            */
            return default;
        }

        protected async Task<MailMessage> SearchAccountAuditLogMoveIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_message.py, METHOD: _search_account_audit_log_move_id) ---
            */
            return default;
        }

        protected async Task<MailMessage> SearchAccountAuditLogPartnerIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_message.py, METHOD: _search_account_audit_log_partner_id) ---
            */
            return default;
        }

        protected async Task<MailMessage> SearchAccountAuditLogPreviewInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_message.py, METHOD: _search_account_audit_log_preview) ---
            */
            return default;
        }

        protected async Task<MailMessage> SearchAccountAuditLogRestrictedInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_message.py, METHOD: _search_account_audit_log_restricted) ---
            */
            return default;
        }

        protected async Task<MailMessage> SearchAccountAuditLogTaxIdInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_message.py, METHOD: _search_account_audit_log_tax_id) ---
            */
            return default;
        }

        protected async Task<MailMessage> SearchAuditLogRelatedRecordIdInternalAsync(object model, object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: mail_message.py, METHOD: _search_audit_log_related_record_id) ---
            */
            return default;
        }

        protected async Task<MailMessage> SearchHasErrorInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _search_has_error) ---
            */
            return default;
        }

        protected async Task<MailMessage> SearchHasSmsErrorInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: mail_message.py, METHOD: _search_has_sms_error) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailMessage> SearchInternalAsync(object domain, object offset, object limit, object order)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _search) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailMessage> SearchNeedactionInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _search_needaction) ---
            */
            return default;
        }

        protected async Task<MailMessage> SearchRatingValueInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: mail_message.py, METHOD: _search_rating_value) ---
            */
            return default;
        }

        protected async Task<MailMessage> SearchSnailmailErrorInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: mail_message.py, METHOD: _search_snailmail_error) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<MailMessage> SearchStarredInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _search_starred) ---
            */
            return default;
        }

        protected async Task<MailMessage> ToStoreDefaultsInternalAsync(object target)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: mail_message.py, METHOD: _to_store_defaults) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _to_store_defaults) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _to_store_defaults) ---
            --- METHOD SOURCE (MODULE: rating, FILE: mail_message.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }

        protected async Task<MailMessage> ToStoreInternalAsync(object store, object fields)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: mail_message.py, METHOD: _to_store) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_message.py, METHOD: _to_store) ---
            --- METHOD SOURCE (MODULE: rating, FILE: mail_message.py, METHOD: _to_store) ---
            */
            return default;
        }
    }
}