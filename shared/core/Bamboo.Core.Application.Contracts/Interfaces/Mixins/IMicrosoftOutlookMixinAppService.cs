using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
namespace Bamboo.Core.Application.Contracts.Interfaces.Mixins
{
    public interface IMicrosoftOutlookMixinAppService : IMixinAppService
    {
        Task<TEntity> ActionRetrieveMaxEmailSizeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> ActiveUsagesComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> BuildEmailAsync<TEntity>(IEnumerable<TEntity> entities, object email_from, object email_to, object subject, object body, object email_cc, object email_bcc, object reply_to, object attachments, Guid message_id, object references, Guid object_id, object subtype, object headers, object body_alternative, object subtype_alternative) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> ButtonConfirmLoginAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> CheckSmtpSslFilesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> CheckUseGoogleGmailServiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> CheckUseMicrosoftOutlookServiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> ComputeIsMicrosoftOutlookConfiguredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> ComputeOutlookUriInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> ComputeServerTypeInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> ComputeSmtpAuthenticationInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> ConnectAsync<TEntity>(IEnumerable<TEntity> entities, object host, object port, object user, object password, object encryption, object smtp_from, object ssl_certificate, object ssl_private_key, object smtp_debug, Guid mail_server_id, object allow_archived) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> FetchMailAsync<TEntity>(IEnumerable<TEntity> entities, object raise_exception) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> FetchMailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> FetchOutlookAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object refresh_token) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> FetchOutlookRefreshTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object authorization_code) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> FetchOutlookTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object grant_type) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> FindMailServerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_from, object mail_servers) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> GenerateOutlookOauth2StringInternalAsync<TEntity>(IEnumerable<TEntity> entities, object login) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> GetConnectionTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> GetDefaultBounceAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> GetDefaultFromAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> GetDefaultFromFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> GetMaxEmailSizeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> GetMicrosoftEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> GetOutlookCsrfTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> GetTestEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> GetTestEmailToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> ImapLoginInternalAsync<TEntity>(IEnumerable<TEntity> entities, object connection) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> MatchFromFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_from, object from_filter) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> OnChangeSmtpUserGmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> OnChangeSmtpUserOutlookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> OnchangeEncryptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> OnchangeServerTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> OnchangeSmtpAuthenticationGmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> OnchangeSmtpAuthenticationOutlookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> OpenMicrosoftOutlookUriAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> PrepareEmailMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object smtp_session) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> SendEmailAsync<TEntity>(IEnumerable<TEntity> entities, object message, Guid mail_server_id, object smtp_server, object smtp_port, object smtp_user, object smtp_password, object smtp_encryption, object smtp_ssl_certificate, object smtp_ssl_private_key, object smtp_debug, object smtp_session) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> SetDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> SmtpLoginInternalAsync<TEntity>(IEnumerable<TEntity> entities, object connection, object smtp_user, object smtp_password) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> TestSmtpConnectionAsync<TEntity>(IEnumerable<TEntity> entities, object autodetect_max_email_size) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> UpdateCronInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
        Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable;
    }
}