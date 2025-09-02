using Volo.Abp.Application.Services;
using System.Linq;
using Volo.Abp.Domain.Entities;
using System.Collections.Generic;
using Bamboo.Core.Domain.Shared.Interfaces;
using System;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces.Mixins
{
    public interface IGoogleGmailMixinAppService : IMixinAppService
    {
        Task<TEntity> ActionRetrieveMaxEmailSizeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> ActiveUsagesComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> BuildEmailAsync<TEntity>(IEnumerable<TEntity> entities, object email_from, object email_to, object subject, object body, object email_cc, object email_bcc, object reply_to, object attachments, Guid message_id, object references, Guid object_id, object subtype, object headers, object body_alternative, object subtype_alternative) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> ButtonConfirmLoginAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> CheckSmtpSslFilesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> CheckUseGoogleGmailServiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> CheckUseMicrosoftOutlookServiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> ComputeGmailUriInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> ComputeIsMicrosoftOutlookConfiguredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> ComputeServerTypeInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> ComputeSmtpAuthenticationInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> ConnectAsync<TEntity>(IEnumerable<TEntity> entities, object host, object port, object user, object password, object encryption, object smtp_from, object ssl_certificate, object ssl_private_key, object smtp_debug, Guid mail_server_id, object allow_archived) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> FetchGmailAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object refresh_token) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> FetchGmailRefreshTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object authorization_code) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> FetchGmailTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object grant_type) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> FetchMailAsync<TEntity>(IEnumerable<TEntity> entities, object raise_exception) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> FetchMailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> FindMailServerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_from, object mail_servers) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> GenerateOauth2StringInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object refresh_token) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> GetConnectionTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> GetDefaultBounceAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> GetDefaultFromAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> GetDefaultFromFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> GetGmailCsrfTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> GetMaxEmailSizeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> GetTestEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> GetTestEmailToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> ImapLoginInternalAsync<TEntity>(IEnumerable<TEntity> entities, object connection) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> MatchFromFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_from, object from_filter) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> OnChangeSmtpUserGmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> OnChangeSmtpUserOutlookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> OnchangeEncryptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> OnchangeServerTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> OnchangeSmtpAuthenticationGmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> OnchangeSmtpAuthenticationOutlookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> OpenGoogleGmailUriAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> PrepareEmailMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object smtp_session) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> SendEmailAsync<TEntity>(IEnumerable<TEntity> entities, object message, Guid mail_server_id, object smtp_server, object smtp_port, object smtp_user, object smtp_password, object smtp_encryption, object smtp_ssl_certificate, object smtp_ssl_private_key, object smtp_debug, object smtp_session) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> SetDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> SmtpLoginInternalAsync<TEntity>(IEnumerable<TEntity> entities, object connection, object smtp_user, object smtp_password) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> TestSmtpConnectionAsync<TEntity>(IEnumerable<TEntity> entities, object autodetect_max_email_size) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> UpdateCronInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
        Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IGoogleGmailMixinable;
    }
}