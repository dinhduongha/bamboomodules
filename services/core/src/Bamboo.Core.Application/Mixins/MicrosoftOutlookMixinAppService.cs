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
    [Module("microsoft_outlook", Category = "Misc", Depends = new[] { "mail" })]
    public partial class MicrosoftOutlookMixinAppService : ApplicationService, IMicrosoftOutlookMixinAppService
    {

        public MicrosoftOutlookMixinAppService() 
        {

        }

        public async Task<TEntity> ActionRetrieveMaxEmailSizeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: action_retrieve_max_email_size) ---
            */
            return default;
        }

        public async Task<TEntity> ActiveUsagesComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py, METHOD: _active_usages_compute) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: ir_mail_server.py, METHOD: _active_usages_compute) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _active_usages_compute) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AlterMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object smtp_from, object smtp_to_list) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _alter_message__) ---
            */
            return default;
        }

        public async Task<TEntity> BuildEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_from, object email_to, object subject, object body, object email_cc, object email_bcc, object reply_to, object attachments, Guid message_id, object references, Guid object_id, object subtype, object headers, object body_alternative, object subtype_alternative) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _build_email__) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonConfirmLoginAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: button_confirm_login) ---
            */
            return default;
        }

        public async Task<TEntity> CheckForcedMailServerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_server, object allow_archived, object smtp_from) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py, METHOD: _check_forced_mail_server) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _check_forced_mail_server) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSmtpSslFilesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _check_smtp_ssl_files) ---
            */
            return default;
        }

        public async Task<TEntity> CheckUseGoogleGmailServiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_gmail, FILE: fetchmail_server.py, METHOD: _check_use_google_gmail_service) ---
            */
            return default;
        }

        public async Task<TEntity> CheckUseMicrosoftOutlookServiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: fetchmail_server.py, METHOD: _check_use_microsoft_outlook_service) ---
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py, METHOD: _check_use_microsoft_outlook_service) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOutlookUriInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: microsoft_outlook_mixin.py, METHOD: _compute_outlook_uri) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServerTypeInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: fetchmail_server.py, METHOD: _compute_server_type_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSmtpAuthenticationInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py, METHOD: _compute_smtp_authentication_info) ---
            */
            return default;
        }

        public async Task<TEntity> ConnectInternalAsync<TEntity>(IEnumerable<TEntity> entities, object allow_archived) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: _connect__) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: create) ---
            */
            return default;
        }

        protected async Task<object> DisableSendInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _disable_send) ---
            */
            return default;
        }

        public async Task<TEntity> FetchMailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: fetch_mail) ---
            */
            return default;
        }

        public async Task<TEntity> FetchMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object batch_limit) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: _fetch_mail) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FetchMailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: _fetch_mails) ---
            */
            return default;
        }

        public async Task<TEntity> FetchOutlookAccessTokenIapInternalAsync<TEntity>(IEnumerable<TEntity> entities, object refresh_token) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: microsoft_outlook_mixin.py, METHOD: _fetch_outlook_access_token_iap) ---
            */
            return default;
        }

        public async Task<TEntity> FetchOutlookAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object refresh_token) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: microsoft_outlook_mixin.py, METHOD: _fetch_outlook_access_token) ---
            */
            return default;
        }

        public async Task<TEntity> FetchOutlookRefreshTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object authorization_code) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: microsoft_outlook_mixin.py, METHOD: _fetch_outlook_refresh_token) ---
            */
            return default;
        }

        public async Task<TEntity> FetchOutlookTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object grant_type) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: microsoft_outlook_mixin.py, METHOD: _fetch_outlook_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FilterMailServersFallbackInternalAsync<TEntity>(IEnumerable<TEntity> entities, object servers) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py, METHOD: _filter_mail_servers_fallback) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _filter_mail_servers_fallback) ---
            */
            return default;
        }

        public async Task<TEntity> FindMailServerAllowedDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py, METHOD: _find_mail_server_allowed_domain) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _find_mail_server_allowed_domain) ---
            */
            return default;
        }

        public async Task<TEntity> FindMailServerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_from, object mail_servers) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _find_mail_server) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateOutlookOauth2StringInternalAsync<TEntity>(IEnumerable<TEntity> entities, object login) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: microsoft_outlook_mixin.py, METHOD: _generate_outlook_oauth2_string) ---
            */
            return default;
        }

        public async Task<TEntity> GetConnectionTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: fetchmail_server.py, METHOD: _get_connection_type) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultBounceAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py, METHOD: _get_default_bounce_address) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _get_default_bounce_address) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultFromAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py, METHOD: _get_default_from_address) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _get_default_from_address) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultFromFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _get_default_from_filter) ---
            */
            return default;
        }

        public async Task<TEntity> GetMaxEmailSizeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _get_max_email_size) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMicrosoftEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: microsoft_outlook_mixin.py, METHOD: _get_microsoft_endpoint) ---
            */
            return default;
        }

        public async Task<TEntity> GetOutlookCsrfTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: microsoft_outlook_mixin.py, METHOD: _get_outlook_csrf_token) ---
            */
            return default;
        }

        public async Task<TEntity> GetPersonalMailServersLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py, METHOD: _get_personal_mail_servers_limit) ---
            */
            return default;
        }

        public async Task<TEntity> GetTestEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py, METHOD: _get_test_email_from) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _get_test_email_from) ---
            */
            return default;
        }

        public async Task<TEntity> GetTestEmailToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _get_test_email_to) ---
            */
            return default;
        }

        public async Task<TEntity> ImapLoginInternalAsync<TEntity>(IEnumerable<TEntity> entities, object connection) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: fetchmail_server.py, METHOD: _imap_login__) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MatchFromFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_from, object from_filter) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _match_from_filter) ---
            */
            return default;
        }

        public async Task<TEntity> OnChangeSmtpUserGmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_gmail, FILE: ir_mail_server.py, METHOD: _on_change_smtp_user_gmail) ---
            */
            return default;
        }

        public async Task<TEntity> OnChangeSmtpUserOutlookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py, METHOD: _on_change_smtp_user_outlook) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeEncryptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py, METHOD: _onchange_encryption) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeServerTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: fetchmail_server.py, METHOD: onchange_server_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeSmtpAuthenticationGmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: google_gmail, FILE: ir_mail_server.py, METHOD: _onchange_smtp_authentication_gmail) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeSmtpAuthenticationOutlookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py, METHOD: _onchange_smtp_authentication_outlook) ---
            */
            return default;
        }

        public async Task<TEntity> OpenMicrosoftOutlookUriAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: microsoft_outlook_mixin.py, METHOD: open_microsoft_outlook_uri) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ParseFromFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object from_filter) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _parse_from_filter) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareEmailMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object smtp_session) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _prepare_email_message__) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareSmtpToListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object smtp_session) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: _prepare_smtp_to_list) ---
            */
            return default;
        }

        public async Task<TEntity> RaiseIapErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: microsoft_outlook_mixin.py, METHOD: _raise_iap_error) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SendEmailAsync<TEntity>(IEnumerable<TEntity> entities, object message, Guid mail_server_id, object smtp_server, object smtp_port, object smtp_user, object smtp_password, object smtp_encryption, object smtp_ssl_certificate, object smtp_ssl_private_key, object smtp_debug, object smtp_session) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: send_email) ---
            */
            return default;
        }

        public async Task<TEntity> SetDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: set_draft) ---
            */
            return default;
        }

        public async Task<TEntity> SmtpLoginInternalAsync<TEntity>(IEnumerable<TEntity> entities, object connection, object smtp_user, object smtp_password) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py, METHOD: _smtp_login__) ---
            */
            return default;
        }

        public async Task<TEntity> TestSmtpConnectionAsync<TEntity>(IEnumerable<TEntity> entities, object autodetect_max_email_size) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py, METHOD: test_smtp_connection) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: unlink) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> UpdateCronInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: _update_cron) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: write) ---
            */
            return default;
        }
    }
}