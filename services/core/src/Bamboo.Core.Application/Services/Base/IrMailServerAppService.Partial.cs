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
    public partial class IrMailServerAppService
    {

        protected async Task<IrMailServer> ActiveUsagesComputeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py, METHOD: _active_usages_compute) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: ir_mail_server.py, METHOD: _active_usages_compute) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _active_usages_compute) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrMailServer> AlterMessageInternalAsync(object message, object smtp_from, object smtp_to_list)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _alter_message__) ---
            */
            return default;
        }

        protected async Task<IrMailServer> BuildEmailInternalAsync(object email_from, object email_to, object subject, object body, object email_cc, object email_bcc, object reply_to, object attachments, Guid message_id, object references, Guid object_id, object subtype, object headers, object body_alternative, object subtype_alternative)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _build_email__) ---
            */
            return default;
        }

        protected async Task<IrMailServer> CheckForcedMailServerInternalAsync(object mail_server, object allow_archived, object smtp_from)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py, METHOD: _check_forced_mail_server) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _check_forced_mail_server) ---
            */
            return default;
        }

        protected async Task<IrMailServer> CheckSmtpSslFilesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _check_smtp_ssl_files) ---
            */
            return default;
        }

        protected async Task<IrMailServer> CheckUseGoogleGmailServiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_gmail, FILE: ir_mail_server.py, METHOD: _check_use_google_gmail_service) ---
            */
            return default;
        }

        protected async Task<IrMailServer> CheckUseMicrosoftOutlookServiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py, METHOD: _check_use_microsoft_outlook_service) ---
            */
            return default;
        }

        protected async Task<IrMailServer> ComputeSmtpAuthenticationInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_gmail, FILE: ir_mail_server.py, METHOD: _compute_smtp_authentication_info) ---
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py, METHOD: _compute_smtp_authentication_info) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _compute_smtp_authentication_info) ---
            */
            return default;
        }

        protected async Task<IrMailServer> ConnectInternalAsync(object host, object port, object user, object password, object encryption, object smtp_from, object ssl_certificate, object ssl_private_key, object smtp_debug, Guid mail_server_id, object allow_archived)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _connect__) ---
            */
            return default;
        }

        protected async Task<IrMailServer> DisableSendInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _disable_send) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrMailServer> FilterMailServersFallbackInternalAsync(object servers)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py, METHOD: _filter_mail_servers_fallback) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _filter_mail_servers_fallback) ---
            */
            return default;
        }

        protected async Task<IrMailServer> FindMailServerAllowedDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py, METHOD: _find_mail_server_allowed_domain) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _find_mail_server_allowed_domain) ---
            */
            return default;
        }

        protected async Task<IrMailServer> FindMailServerInternalAsync(object email_from, object mail_servers)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _find_mail_server) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrMailServer> GetDefaultBounceAddressInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py, METHOD: _get_default_bounce_address) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _get_default_bounce_address) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrMailServer> GetDefaultFromAddressInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py, METHOD: _get_default_from_address) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _get_default_from_address) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrMailServer> GetDefaultFromFilterInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _get_default_from_filter) ---
            */
            return default;
        }

        protected async Task<IrMailServer> GetMaxEmailSizeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _get_max_email_size) ---
            */
            return default;
        }

        protected async Task<IrMailServer> GetPersonalMailServersLimitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py, METHOD: _get_personal_mail_servers_limit) ---
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py, METHOD: _get_personal_mail_servers_limit) ---
            */
            return default;
        }

        protected async Task<IrMailServer> GetTestEmailFromInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py, METHOD: _get_test_email_from) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _get_test_email_from) ---
            */
            return default;
        }

        protected async Task<IrMailServer> GetTestEmailToInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _get_test_email_to) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrMailServer> MatchFromFilterInternalAsync(object email_from, object from_filter)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _match_from_filter) ---
            */
            return default;
        }

        protected async Task<IrMailServer> OnChangeSmtpUserGmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_gmail, FILE: ir_mail_server.py, METHOD: _on_change_smtp_user_gmail) ---
            */
            return default;
        }

        protected async Task<IrMailServer> OnChangeSmtpUserOutlookInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py, METHOD: _on_change_smtp_user_outlook) ---
            */
            return default;
        }

        protected async Task<IrMailServer> OnchangeEncryptionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_gmail, FILE: ir_mail_server.py, METHOD: _onchange_encryption) ---
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py, METHOD: _onchange_encryption) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _onchange_encryption) ---
            */
            return default;
        }

        protected async Task<IrMailServer> OnchangeSmtpAuthenticationGmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_gmail, FILE: ir_mail_server.py, METHOD: _onchange_smtp_authentication_gmail) ---
            */
            return default;
        }

        protected async Task<IrMailServer> OnchangeSmtpAuthenticationOutlookInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py, METHOD: _onchange_smtp_authentication_outlook) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrMailServer> ParseFromFilterInternalAsync(object from_filter)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _parse_from_filter) ---
            */
            return default;
        }

        protected async Task<IrMailServer> PrepareEmailMessageInternalAsync(object message, object smtp_session)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _prepare_email_message__) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<IrMailServer> PrepareSmtpToListInternalAsync(object message, object smtp_session)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _prepare_smtp_to_list) ---
            */
            return default;
        }

        protected async Task<IrMailServer> SmtpLoginInternalAsync(object connection, object smtp_user, object smtp_password)
        {
            /*
            --- METHOD SOURCE (MODULE: google_gmail, FILE: ir_mail_server.py, METHOD: _smtp_login__) ---
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py, METHOD: _smtp_login__) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _smtp_login__) ---
            */
            return default;
        }
    }
}