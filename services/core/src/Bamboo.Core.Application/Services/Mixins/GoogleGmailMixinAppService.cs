using Volo.Abp.ObjectMapping;
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
    [Module("google_gmail", Category = "Misc", Depends = new[] { "mail" })]
    public partial class GoogleGmailMixinAppService : ApplicationService, IGoogleGmailMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public GoogleGmailMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionRetrieveMaxEmailSizeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def action_retrieve_max_email_size(self):
            // self.ensure_one()
            // return self.test_smtp_connection(autodetect_max_email_size=True)
            */
            return default;
        }

        public async Task<TEntity> ActiveUsagesComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py) ---
            // def _active_usages_compute(self):
            // usages_super = super()._active_usages_compute()
            // for record in self.filtered('mail_template_ids'):
            //     usages_super.setdefault(record.id, []).extend(
            //         self.env._('%s (Email Template)', t.display_name)
            //         for t in record.mail_template_ids
            //     )
            // return usages_super
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: ir_mail_server.py) ---
            // def _active_usages_compute(self):
            // def format_usage(mailing_id):
            //     base = _('Mass Mailing "%s"', mailing_id.display_name)
            //     if not mailing_id.schedule_date:
            //         return base
            //     details = _('(scheduled for %s)', format_date(self.env, mailing_id.schedule_date))
            //     return f'{base} {details}'
            // 
            // usages_super = super()._active_usages_compute()
            // default_mail_server_id = self.env['mailing.mailing']._get_default_mail_server_id()
            // for record in self:
            //     usages = []
            //     if default_mail_server_id == record.id:
            //         usages.append(_('Email Marketing uses it as its default mail server to send mass mailings'))
            //     usages.extend(map(format_usage, record.active_mailing_ids))
            //     if usages:
            //         usages_super.setdefault(record.id, []).extend(usages)
            // return usages_super
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _active_usages_compute(self):
            // """Compute a dict server id to list of user-friendly outgoing mail servers usage of this record set.
            // 
            // This method must be overridden by all modules that uses this class in order to complete the list with
            // user-friendly string describing the active elements that could send mail through the instance of this class.
            // :return dict: { ir_mail_server.id: usage_str_list }.
            // """
            // return dict()
            */
            return default;
        }

        public async Task<TEntity> AlterMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object smtp_from, object smtp_to_list) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _alter_message__(self, message, smtp_from, smtp_to_list):  # noqa: PLW3201
            // # `To:` header forged, e.g. for posting on discuss.channels, to avoid confusion
            // if x_forge_to := message['X-Forge-To']:
            //     message.replace_header('To', x_forge_to)
            // # `To:` header extended, e.g. for adding "virtual" recipients, aka fake recipients
            // # that do not impact SMTP To
            // elif x_msg_add_to := message['X-Msg-To-Add']:
            //     to = message['To'] or ''
            //     to_normalized = tools.mail.email_normalize_all(to)
            //     message.replace_header(
            //         'To', ', '.join([
            //             to,
            //             ', '.join(
            //                 address for address in tools.mail.email_split_and_format(x_msg_add_to)
            //                 if tools.mail.email_normalize(address, strict=False) not in to_normalized
            //             ),
            //         ]
            //         ))
            // 
            // if message['From'] != smtp_from:
            //     message.replace_header('From', smtp_from)
            // 
            // # cleanup unwanted headers
            // del message['Bcc']                   # see odoo/odoo@2445f9e3c22db810d61996afde883e4ca608f15b
            // del message['X-Forge-To']
            // del message['X-Msg-To-Add']
            // del message['X-Msg-To-Consolidate']
            */
            return default;
        }

        public async Task<TEntity> BuildEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_from, object email_to, object subject, object body, object email_cc, object email_bcc, object reply_to, object attachments, Guid message_id, object references, Guid object_id, object subtype, object headers, object body_alternative, object subtype_alternative) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _build_email__(self, email_from, email_to, subject, body, email_cc=None, email_bcc=None, reply_to=False,  # noqa: PLW3201
            //             attachments=None, message_id=None, references=None, object_id=False, subtype='plain', headers=None,
            //             body_alternative=None, subtype_alternative='plain'):
            // """Constructs an RFC2822 email.message.Message object based on the keyword arguments passed, and returns it.
            // 
            //    :param string email_from: sender email address
            //    :param list email_to: list of recipient addresses (to be joined with commas)
            //    :param string subject: email subject (no pre-encoding/quoting necessary)
            //    :param string body: email body, of the type ``subtype`` (by default, plaintext).
            //                        If html subtype is used, the message will be automatically converted
            //                        to plaintext and wrapped in multipart/alternative, unless an explicit
            //                        ``body_alternative`` version is passed.
            //    :param string body_alternative: optional alternative body, of the type specified in ``subtype_alternative``
            //    :param string reply_to: optional value of Reply-To header
            //    :param string object_id: optional tracking identifier, to be included in the message-id for
            //                             recognizing replies. Suggested format for object-id is "res_id-model",
            //                             e.g. "12345-crm.lead".
            //    :param string subtype: optional mime subtype for the text body (usually 'plain' or 'html'),
            //                           must match the format of the ``body`` parameter. Default is 'plain',
            //                           making the content part of the mail "text/plain".
            //    :param string subtype_alternative: optional mime subtype of ``body_alternative`` (usually 'plain'
            //                                       or 'html'). Default is 'plain'.
            //    :param list attachments: list of (filename, filecontents) pairs, where filecontents is a string
            //                             containing the bytes of the attachment
            //    :param message_id:
            //    :param references:
            //    :param list email_cc: optional list of string values for CC header (to be joined with commas)
            //    :param list email_bcc: optional list of string values for BCC header (to be joined with commas)
            //    :param dict headers: optional map of headers to set on the outgoing mail (may override the
            //                         other headers, including Subject, Reply-To, Message-Id, etc.)
            //    :rtype: email.message.EmailMessage
            //    :return: the new RFC2822 email message
            // """
            // email_from = email_from or self.env.context.get('domain_notifications_email') or self._get_default_from_address()
            // assert email_from, self.NO_FOUND_FROM
            // 
            // headers = headers or {}         # need valid dict later
            // email_cc = email_cc or []
            // email_bcc = email_bcc or []
            // 
            // msg = EmailMessage(policy=email.policy.SMTP)
            // if not message_id:
            //     if object_id:
            //         message_id = tools.mail.generate_tracking_message_id(object_id)
            //     else:
            //         message_id = make_msgid()
            // msg['Message-Id'] = message_id
            // if references:
            //     msg['references'] = references
            // msg['Subject'] = subject
            // msg['From'] = email_from
            // del msg['Reply-To']
            // msg['Reply-To'] = reply_to or email_from
            // msg['To'] = email_to
            // if email_cc:
            //     msg['Cc'] = email_cc
            // if email_bcc:
            //     msg['Bcc'] = email_bcc
            // msg['Date'] = datetime.datetime.utcnow()
            // for key, value in headers.items():
            //     msg[key] = value
            // 
            // email_body = body or ''
            // if subtype == 'html' and not body_alternative:
            //     msg['MIME-Version'] = '1.0'
            //     msg.add_alternative(tools.html2plaintext(email_body), subtype='plain', charset='utf-8')
            //     msg.add_alternative(email_body, subtype=subtype, charset='utf-8')
            // elif body_alternative:
            //     msg['MIME-Version'] = '1.0'
            //     msg.add_alternative(body_alternative, subtype=subtype_alternative, charset='utf-8')
            //     msg.add_alternative(email_body, subtype=subtype, charset='utf-8')
            // else:
            //     msg.set_content(email_body, subtype=subtype, charset='utf-8')
            // 
            // if attachments:
            //     for (fname, fcontent, mime) in attachments:
            //         maintype, subtype = mime.split('/') if mime and '/' in mime else ('application', 'octet-stream')
            //         if maintype == 'message' and subtype == 'rfc822':
            //             msg.add_attachment(BytesParser().parsebytes(fcontent), filename=fname)
            //         else:
            //             msg.add_attachment(fcontent, maintype, subtype, filename=fname)
            // return msg
            */
            return default;
        }

        public async Task<TEntity> ButtonConfirmLoginAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def button_confirm_login(self):
            // for server in self:
            //     connection = None
            //     try:
            //         connection = server._connect__(allow_archived=True)
            //         server.write({'state': 'done'})
            //     except UnicodeError as e:
            //         raise UserError(_("Invalid server name!\n %s", tools.exception_to_unicode(e)))
            //     except (gaierror, timeout, IMAP4.abort) as e:
            //         raise UserError(_("No response received. Check server information.\n %s", tools.exception_to_unicode(e)))
            //     except (IMAP4.error, poplib.error_proto) as err:
            //         raise UserError(_("Server replied with following exception:\n %s", tools.exception_to_unicode(err)))
            //     except SSLError as e:
            //         raise UserError(_("An SSL exception occurred. Check SSL/TLS configuration on server port.\n %s", tools.exception_to_unicode(e)))
            //     except (OSError, Exception) as err:
            //         _logger.info("Failed to connect to %s server %s.", server.server_type, server.name, exc_info=True)
            //         raise UserError(_("Connection test failed: %s", tools.exception_to_unicode(err)))
            //     finally:
            //         try:
            //             if connection:
            //                 connection.disconnect()
            //         except Exception:
            //             # ignored, just a consequence of the previous exception
            //             pass
            // return True
            */
            return default;
        }

        public async Task<TEntity> CheckForcedMailServerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_server, object allow_archived, object smtp_from) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py) ---
            // def _check_forced_mail_server(self, mail_server, allow_archived, smtp_from):
            // super()._check_forced_mail_server(mail_server, allow_archived, smtp_from)
            // 
            // if mail_server.owner_user_id:
            //     if email_normalize(smtp_from) != mail_server.from_filter:
            //         raise UserError(_('The server "%s" cannot be forced as it belongs to a user.', mail_server.display_name))
            //     if not mail_server.active:
            //         raise UserError(_('The server "%s" cannot be forced as it belongs to a user and is archived.', mail_server.display_name))
            //     if mail_server.owner_user_id.outgoing_mail_server_id != mail_server:
            //         raise UserError(_('The server "%s" cannot be forced as the owner does not use it anymore.', mail_server.display_name))
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _check_forced_mail_server(self, mail_server, allow_archived, smtp_from):
            // if not allow_archived and not mail_server.active:
            //     raise UserError(_('The server "%s" cannot be used because it is archived.', mail_server.display_name))
            */
            return default;
        }

        public async Task<TEntity> CheckSmtpSslFilesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _check_smtp_ssl_files(self):
            // for mail_server in self:
            //     if mail_server.smtp_authentication == 'certificate':
            //         if not mail_server.smtp_ssl_private_key:
            //             raise UserError(_('SSL private key is missing for %s.', mail_server.name))
            //         if not mail_server.smtp_ssl_certificate:
            //             raise UserError(_('SSL certificate is missing for %s.', mail_server.name))
            */
            return default;
        }

        public async Task<TEntity> CheckUseGoogleGmailServiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: fetchmail_server.py) ---
            // def _check_use_google_gmail_service(self):
            // for server in self:
            //     if server.server_type == 'gmail' and not server.is_ssl:
            //         raise UserError(_('SSL is required for server “%s”.', server.name))
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: ir_mail_server.py) ---
            // def _check_use_google_gmail_service(self):
            // gmail_servers = self.filtered(lambda server: server.smtp_authentication == 'gmail')
            // for server in gmail_servers:
            //     if server.smtp_pass:
            //         raise UserError(_(
            //             'Please leave the password field empty for Gmail mail server “%s”. '
            //             'The OAuth process does not require it', server.name))
            // 
            //     if server.smtp_encryption != 'starttls':
            //         raise UserError(_(
            //             'Incorrect Connection Security for Gmail mail server “%s”. '
            //             'Please set it to "TLS (STARTTLS)".', server.name))
            // 
            //     if not server.smtp_user:
            //         raise UserError(_(
            //             'Please fill the "Username" field with your Gmail username (your email address). '
            //             'This should be the same account as the one used for the Gmail OAuthentication Token.'))
            */
            return default;
        }

        public async Task<TEntity> CheckUseMicrosoftOutlookServiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: fetchmail_server.py) ---
            // def _check_use_microsoft_outlook_service(self):
            // for server in self:
            //     if server.server_type == 'outlook' and not server.is_ssl:
            //         raise UserError(_('SSL is required for server “%s”.', server.name))
            */
            return default;
        }

        public async Task<TEntity> ComputeGmailUriInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: google_gmail_mixin.py) ---
            // def _compute_gmail_uri(self):
            // Config = self.env['ir.config_parameter'].sudo()
            // google_gmail_client_id = Config.get_param('google_gmail_client_id')
            // google_gmail_client_secret = Config.get_param('google_gmail_client_secret')
            // is_configured = google_gmail_client_id and google_gmail_client_secret
            // base_url = self.get_base_url()
            // 
            // if not is_configured:
            //     self.google_gmail_uri = False
            // else:
            //     for record in self:
            //         google_gmail_uri = 'https://accounts.google.com/o/oauth2/v2/auth?%s' % url_encode({
            //             'client_id': google_gmail_client_id,
            //             'redirect_uri': url_join(base_url, '/google_gmail/confirm'),
            //             'response_type': 'code',
            //             'scope': self._SERVICE_SCOPE,
            //             # access_type and prompt needed to get a refresh token
            //             'access_type': 'offline',
            //             'prompt': 'consent',
            //             'state': json.dumps({
            //                 'model': record._name,
            //                 'id': record.id or False,
            //                 'csrf_token': record._get_gmail_csrf_token() if record.id else False,
            //             })
            //         })
            //         record.google_gmail_uri = google_gmail_uri
            */
            return default;
        }

        public async Task<TEntity> ComputeServerTypeInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: fetchmail_server.py) ---
            // def _compute_server_type_info(self):
            // gmail_servers = self.filtered(lambda server: server.server_type == 'gmail')
            // gmail_servers.server_type_info = _(
            //     'Connect your Gmail account with the OAuth Authentication process. \n'
            //     'You will be redirected to the Gmail login page where you will '
            //     'need to accept the permission.')
            // super(FetchmailServer, self - gmail_servers)._compute_server_type_info()
            */
            return default;
        }

        public async Task<TEntity> ComputeSmtpAuthenticationInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: ir_mail_server.py) ---
            // def _compute_smtp_authentication_info(self):
            // gmail_servers = self.filtered(lambda server: server.smtp_authentication == 'gmail')
            // gmail_servers.smtp_authentication_info = _(
            //     'Connect your Gmail account with the OAuth Authentication process.  \n'
            //     'By default, only a user with a matching email address will be able to use this server. '
            //     'To extend its use, you should set a "mail.default.from" system parameter.')
            // super(IrMail_Server, self - gmail_servers)._compute_smtp_authentication_info()
            */
            return default;
        }

        public async Task<TEntity> ConnectInternalAsync<TEntity>(IEnumerable<TEntity> entities, object allow_archived) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def _connect__(self, allow_archived=False):  # noqa: PLW3201
            // """
            // :param bool allow_archived: by default (False), an exception is raised when calling this method on an
            //    archived record. It can be set to True for testing so that the exception is no longer raised.
            // """
            // self.ensure_one()
            // if not allow_archived and not self.active:
            //     raise UserError(_('The server "%s" cannot be used because it is archived.', self.display_name))
            // connection_type = self._get_connection_type()
            // if connection_type == 'imap':
            //     server, port, is_ssl = self.server, int(self.port), self.is_ssl
            //     connection = OdooIMAP4_SSL(server, port, timeout=MAIL_TIMEOUT) if is_ssl else OdooIMAP4(server, port, timeout=MAIL_TIMEOUT)
            //     self._imap_login__(connection)
            // elif connection_type == 'pop':
            //     server, port, is_ssl = self.server, int(self.port), self.is_ssl
            //     connection = OdooPOP3_SSL(server, port, timeout=MAIL_TIMEOUT) if is_ssl else OdooPOP3(server, port, timeout=MAIL_TIMEOUT)
            //     #TODO: use this to remove only unread messages
            //     #connection.user("recent:"+server.user)
            //     connection.user(self.user)
            //     connection.pass_(self.password)
            // return connection
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def create(self, vals_list):
            // res = super().create(vals_list)
            // self._update_cron()
            // return res
            */
            return default;
        }

        protected async Task<object> DisableSendInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _disable_send(cls):
            // """Whether to disable sending e-mails"""
            // # no e-mails during testing or when registry is initializing
            // return modules.module.current_test or cls.pool._init
            */
            return default;
        }

        public async Task<TEntity> FetchGmailAccessTokenIapInternalAsync<TEntity>(IEnumerable<TEntity> entities, object refresh_token) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: google_gmail_mixin.py) ---
            // def _fetch_gmail_access_token_iap(self, refresh_token):
            // """Fetch the access token using IAP.
            // 
            // Make a HTTP request to IAP, that will make a HTTP request
            // to the Gmail API and give us the result.
            // 
            // :return:
            //     access_token, access_token_expiration
            // """
            // gmail_iap_endpoint = self.env['ir.config_parameter'].sudo().get_param(
            //     'mail.server.gmail.iap.endpoint',
            //     self.env['google.gmail.mixin']._DEFAULT_GMAIL_IAP_ENDPOINT,
            // )
            // db_uuid = self.env['ir.config_parameter'].sudo().get_param('database.uuid')
            // 
            // response = requests.get(
            //     url_join(gmail_iap_endpoint, '/api/mail_oauth/1/gmail_access_token'),
            //     params={'refresh_token': refresh_token, 'db_uuid': db_uuid},
            //     timeout=GMAIL_TOKEN_REQUEST_TIMEOUT,
            // )
            // 
            // if not response.ok:
            //     _logger.error('Can not contact IAP: %s.', response.text)
            //     raise UserError(_('Oops, we could not authenticate you. Please try again later.'))
            // 
            // response = response.json()
            // if 'error' in response:
            //     self._raise_iap_error(response['error'])
            // 
            // return response
            */
            return default;
        }

        public async Task<TEntity> FetchGmailAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object refresh_token) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: google_gmail_mixin.py) ---
            // def _fetch_gmail_access_token(self, refresh_token):
            // """Refresh the access token thanks to the refresh token.
            // 
            // :return:
            //     access_token, access_token_expiration
            // """
            // Config = self.env['ir.config_parameter'].sudo()
            // 
            // google_gmail_client_id = Config.get_param('google_gmail_client_id')
            // google_gmail_client_secret = Config.get_param('google_gmail_client_secret')
            // if not google_gmail_client_id or not google_gmail_client_secret:
            //     return self._fetch_gmail_access_token_iap(refresh_token)
            // 
            // response = self._fetch_gmail_token('refresh_token', refresh_token=refresh_token)
            // return (
            //     response['access_token'],
            //     int(time.time()) + response['expires_in'],
            // )
            */
            return default;
        }

        public async Task<TEntity> FetchGmailRefreshTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object authorization_code) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: google_gmail_mixin.py) ---
            // def _fetch_gmail_refresh_token(self, authorization_code):
            // """Request the refresh token and the initial access token from the authorization code.
            // 
            // :return:
            //     refresh_token, access_token, access_token_expiration
            // """
            // response = self._fetch_gmail_token('authorization_code', code=authorization_code)
            // 
            // return (
            //     response['refresh_token'],
            //     response['access_token'],
            //     int(time.time()) + response['expires_in'],
            // )
            */
            return default;
        }

        public async Task<TEntity> FetchGmailTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object grant_type) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: google_gmail_mixin.py) ---
            // def _fetch_gmail_token(self, grant_type, **values):
            // """Generic method to request an access token or a refresh token.
            // 
            // Return the JSON response of the GMail API and manage the errors which can occur.
            // 
            // :param grant_type: Depends the action we want to do (refresh_token or authorization_code)
            // :param values: Additional parameters that will be given to the GMail endpoint
            // """
            // Config = self.env['ir.config_parameter'].sudo()
            // google_gmail_client_id = Config.get_param('google_gmail_client_id')
            // google_gmail_client_secret = Config.get_param('google_gmail_client_secret')
            // base_url = self.get_base_url()
            // redirect_uri = url_join(base_url, '/google_gmail/confirm')
            // 
            // response = requests.post(
            //     'https://oauth2.googleapis.com/token',
            //     data={
            //         'client_id': google_gmail_client_id,
            //         'client_secret': google_gmail_client_secret,
            //         'grant_type': grant_type,
            //         'redirect_uri': redirect_uri,
            //         **values,
            //     },
            //     timeout=GMAIL_TOKEN_REQUEST_TIMEOUT,
            // )
            // 
            // if not response.ok:
            //     raise UserError(_('An error occurred when fetching the access token.'))
            // 
            // return response.json()
            */
            return default;
        }

        public async Task<TEntity> FetchMailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def fetch_mail(self):
            // """ Action to fetch the mail from the current server. """
            // self.ensure_one().check_access('write')
            // exception = self.sudo()._fetch_mail()
            // if exception is not None:
            //     raise exception
            */
            return default;
        }

        public async Task<TEntity> FetchMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object batch_limit) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def _fetch_mail(self, batch_limit=50) -> Exception | None:
            // """ Fetch e-mails from multiple servers.
            // 
            // Commit after each message.
            // """
            // result_exception = None
            // servers = self.with_context(fetchmail_cron_running=True)
            // total_remaining = len(servers)  # number of remaining messages + number of unchecked servers
            // self.env['ir.cron']._commit_progress(remaining=total_remaining)
            // 
            // for server in servers:
            //     total_remaining -= 1  # the server is checked
            //     if not server.try_lock_for_update(allow_referencing=True).filtered_domain(MAIL_SERVER_DOMAIN):
            //         _logger.info('Skip checking for new mails on mail server id %d (unavailable)', server.id)
            //         continue
            //     server_type_and_name = server.server_type, server.name  # avoid reading this after each commit
            //     _logger.info('Start checking for new emails on %s server %s', *server_type_and_name)
            //     count, failed = 0, 0
            // 
            //     # processing messages in a separate transaction to keep lock on the server
            //     server_connection = None
            //     message_cr = None
            //     try:
            //         server_connection = server._connect__()
            //         message_cr = self.env.registry.cursor()
            //         MailThread = server.env['mail.thread'].with_env(self.env(cr=message_cr)).with_context(default_fetchmail_server_id=server.id)
            //         thread_process_message = functools.partial(
            //             MailThread.message_process,
            //             model=server.object_id.model,
            //             save_original=server.original,
            //             strip_attachments=(not server.attach),
            //         )
            //         unread_message_count = server_connection.check_unread_messages()
            //         _logger.debug('%d unread messages on %s server %s.', unread_message_count, *server_type_and_name)
            //         total_remaining += unread_message_count
            //         for message_num, message in server_connection.retrieve_unread_messages():
            //             _logger.debug('Fetched message %r on %s server %s.', message_num, *server_type_and_name)
            //             count += 1
            //             total_remaining -= 1
            //             try:
            //                 thread_process_message(message=message)
            //                 remaining_time = MailThread.env['ir.cron']._commit_progress(1)
            //             except Exception:  # noqa: BLE001
            //                 MailThread.env.cr.rollback()
            //                 failed += 1
            //                 _logger.info('Failed to process mail from %s server %s.', *server_type_and_name, exc_info=True)
            //                 remaining_time = MailThread.env['ir.cron']._commit_progress()
            //             server_connection.handled_message(message_num)
            //             if count >= batch_limit or not remaining_time:
            //                 break
            //         server.error_date = False
            //         server.error_message = False
            //     except Exception as e:  # noqa: BLE001
            //         result_exception = e
            //         _logger.info("General failure when trying to fetch mail from %s server %s.", *server_type_and_name, exc_info=True)
            //         if not server.error_date:
            //             server.error_date = fields.Datetime.now()
            //             server.error_message = exception_to_unicode(e)
            //         elif server.error_date < fields.Datetime.now() - MAIL_SERVER_DEACTIVATE_TIME:
            //             message = "Deactivating fetchmail %s server %s (too many failures)" % server_type_and_name
            //             server.set_draft()
            //             server.env['ir.cron']._notify_admin(message)
            //     finally:
            //         if message_cr is not None:
            //             message_cr.close()
            //         try:
            //             if server_connection:
            //                 server_connection.disconnect()
            //         except (OSError, IMAP4.abort):
            //             _logger.warning('Failed to properly finish %s connection: %s.', *server_type_and_name, exc_info=True)
            //     _logger.info("Fetched %d email(s) on %s server %s; %d succeeded, %d failed.", count, *server_type_and_name, (count - failed), failed)
            //     server.write({'date': fields.Datetime.now()})
            //     # Commit before updating the progress because progress may be
            //     # updated for messages using another transaction. Without a commit
            //     # before updating the progress, we would have a serialization error.
            //     self.env.cr.commit()
            //     if not self.env['ir.cron']._commit_progress(remaining=total_remaining):
            //         break
            // return result_exception
            */
            return default;
        }

        public async Task<TEntity> FetchMailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def _fetch_mails(self, **kw):
            // """ Method called by cron to fetch mails from servers """
            // assert self.env.context.get('cron_id') == self.env.ref('mail.ir_cron_mail_gateway_action').id, "Meant for cron usage only"
            // self.search(MAIL_SERVER_DOMAIN)._fetch_mail(**kw)
            // if not self.search_count(MAIL_SERVER_DOMAIN):
            //     # no server is active anymore
            //     self.env['ir.cron']._commit_progress(deactivate=True)
            */
            return default;
        }

        public async Task<TEntity> FilterMailServersFallbackInternalAsync<TEntity>(IEnumerable<TEntity> entities, object servers) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py) ---
            // def _filter_mail_servers_fallback(self, servers):
            // return servers.filtered(lambda s: not s.owner_user_id)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _filter_mail_servers_fallback(self, servers):
            // """Filter the mail servers that can be used as fallback, or for default email from."""
            // return servers
            */
            return default;
        }

        public async Task<TEntity> FindMailServerAllowedDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py) ---
            // def _find_mail_server_allowed_domain(self):
            // """Restrict search to 'public' servers."""
            // domain = super()._find_mail_server_allowed_domain()
            // domain &= Domain('owner_user_id', '=', False)
            // return domain
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _find_mail_server_allowed_domain(self):
            // """Overridable domain getter for all mail servers that may be used as default."""
            // return fields.Domain.TRUE
            */
            return default;
        }

        public async Task<TEntity> FindMailServerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_from, object mail_servers) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _find_mail_server(self, email_from, mail_servers=None):
            // """Find the appropriate mail server for the given email address.
            // 
            // :rtype: tuple[IrMail_Server | None, str]
            // :returns: A two-elements tuple: ``(Record<ir.mail_server>, email_from)``
            // 
            //   1. Mail server to use to send the email (``None`` if we use the odoo-bin arguments)
            //   2. Email FROM to use to send the email (in some case, it might be impossible
            //      to use the given email address directly if no mail server is configured for)
            // """
            // email_from_normalized = email_normalize(email_from)
            // email_from_domain = email_domain_extract(email_from_normalized)
            // notifications_email = self.env.context.get('domain_notifications_email') or email_normalize(self._get_default_from_address())
            // notifications_domain = email_domain_extract(notifications_email)
            // 
            // if mail_servers is None:
            //     mail_servers = self.sudo().search(self._find_mail_server_allowed_domain(), order='sequence')
            // # 0. Archived mail server should never be used
            // mail_servers = mail_servers.filtered('active')
            // 
            // def first_match(target, normalize_method):
            //     for mail_server in mail_servers:
            //         if mail_server.from_filter and any(
            //             normalize_method(email.strip()) == target
            //             for email in mail_server.from_filter.split(',')
            //         ):
            //             return mail_server
            // 
            // # 1. Try to find a mail server for the right mail from
            // # Skip if passed email_from is False (example Odoobot has no email address)
            // if email_from_normalized:
            //     if mail_server := first_match(email_from_normalized, email_normalize):
            //         return mail_server, email_from
            // 
            //     if mail_server := first_match(email_from_domain, email_domain_normalize):
            //         return mail_server, email_from
            // 
            // mail_servers = self._filter_mail_servers_fallback(mail_servers)
            // 
            // # 2. Try to find a mail server for <notifications@domain.com>
            // if notifications_email:
            //     if mail_server := first_match(notifications_email, email_normalize):
            //         return mail_server, notifications_email
            // 
            //     if mail_server := first_match(notifications_domain, email_domain_normalize):
            //         return mail_server, notifications_email
            // 
            // # 3. Take the first mail server without "from_filter" because
            // # nothing else has been found... Will spoof the FROM because
            // # we have no other choices (will use the notification email if available
            // # otherwise we will use the user email)
            // if mail_server := mail_servers.filtered(lambda m: not m.from_filter):
            //     return mail_server[0], notifications_email or email_from
            // 
            // # 4. Return the first mail server even if it was configured for another domain
            // if mail_servers:
            //     _logger.warning(
            //         "No mail server matches the from_filter, using %s as fallback",
            //         notifications_email or email_from)
            //     return mail_servers[0], notifications_email or email_from
            // 
            // # 5: SMTP config in odoo-bin arguments
            // from_filter = self.env['ir.mail_server']._get_default_from_filter()
            // 
            // if self._match_from_filter(email_from, from_filter):
            //     return None, email_from
            // 
            // if notifications_email and self._match_from_filter(notifications_email, from_filter):
            //     return None, notifications_email
            // 
            // _logger.warning(
            //     "The from filter of the CLI configuration does not match the notification email "
            //     "or the user email, using %s as fallback",
            //     notifications_email or email_from)
            // return None, notifications_email or email_from
            */
            return default;
        }

        public async Task<TEntity> GenerateOauth2StringInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object refresh_token) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: google_gmail_mixin.py) ---
            // def _generate_oauth2_string(self, user, refresh_token):
            // """Generate a OAuth2 string which can be used for authentication.
            // 
            // :param user: Email address of the Gmail account to authenticate
            // :param refresh_token: Refresh token for the given Gmail account
            // 
            // :return: The SASL argument for the OAuth2 mechanism.
            // """
            // self.ensure_one()
            // now_timestamp = int(time.time())
            // if not self.google_gmail_access_token \
            //    or not self.google_gmail_access_token_expiration \
            //    or self.google_gmail_access_token_expiration - GMAIL_TOKEN_VALIDITY_THRESHOLD < now_timestamp:
            // 
            //     access_token, expiration = self._fetch_gmail_access_token(self.google_gmail_refresh_token)
            // 
            //     self.write({
            //         'google_gmail_access_token': access_token,
            //         'google_gmail_access_token_expiration': expiration,
            //     })
            // 
            //     _logger.info(
            //         'Google Gmail: fetch new access token. Expires in %i minutes',
            //         (self.google_gmail_access_token_expiration - now_timestamp) // 60)
            // else:
            //     _logger.info(
            //         'Google Gmail: reuse existing access token. Expire in %i minutes',
            //         (self.google_gmail_access_token_expiration - now_timestamp) // 60)
            // 
            // return 'user=%s\1auth=Bearer %s\1\1' % (user, self.google_gmail_access_token)
            */
            return default;
        }

        public async Task<TEntity> GetConnectionTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: fetchmail_server.py) ---
            // def _get_connection_type(self):
            // """Return which connection must be used for this mail server (IMAP or POP).
            // The Gmail mail server used an IMAP connection.
            // """
            // self.ensure_one()
            // return 'imap' if self.server_type == 'gmail' else super()._get_connection_type()
            */
            return default;
        }

        public async Task<TEntity> GetDefaultBounceAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py) ---
            // def _get_default_bounce_address(self):
            // """ Compute the default bounce address. Try to use mail-defined config
            // parameter bounce alias if set. """
            // if self.env.company.bounce_email:
            //     return self.env.company.bounce_email
            // return super()._get_default_bounce_address()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _get_default_bounce_address(self):
            // """ Computes the default bounce address. It is used to set the envelop
            // address if no envelop address is provided in the message.
            // 
            // :return: defaults to the ``--email-from`` CLI/config parameter.
            // :rtype: str | None
            // """
            // return tools.config.get("email_from")
            */
            return default;
        }

        public async Task<TEntity> GetDefaultFromAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py) ---
            // def _get_default_from_address(self):
            // """ Default from: try to use default_from defined on company's alias
            // domain. """
            // if default_from := self.env.company.default_from_email:
            //     return default_from
            // return super()._get_default_from_address()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _get_default_from_address(self):
            // """ Computes the default from address. It is used for the "header from"
            // address when no other has been received.
            // 
            // :return: defaults to the ``--email-from`` CLI/config parameter.
            // :rtype: str | None
            // """
            // return tools.config.get("email_from")
            */
            return default;
        }

        public async Task<TEntity> GetDefaultFromFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _get_default_from_filter(self):
            // """ Computes the default from_filter. It is used when no specific
            // ir.mail_server is used when sending emails, hence having no value for
            // from_filter.
            // 
            // :return: defaults to 'mail.default.from_filter', then
            //   ``--from-filter`` CLI/config parameter.
            // :rtype: str | None
            // """
            // return self.env['ir.config_parameter'].sudo().get_param(
            //     'mail.default.from_filter', tools.config.get('from_filter')
            // )
            */
            return default;
        }

        public async Task<TEntity> GetGmailCsrfTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: google_gmail_mixin.py) ---
            // def _get_gmail_csrf_token(self):
            // """Generate a CSRF token that will be verified in `google_gmail_callback`.
            // 
            // This will prevent a malicious person to make an admin user disconnect the mail servers.
            // """
            // self.ensure_one()
            // _logger.info('Google Gmail: generate CSRF token for %s #%i', self._name, self.id)
            // return tools.misc.hmac(
            //     env=self.env(su=True),
            //     scope='google_gmail_oauth',
            //     message=(self._name, self.id),
            // )
            */
            return default;
        }

        public async Task<TEntity> GetMaxEmailSizeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _get_max_email_size(self):
            // if self.max_email_size:
            //     return self.max_email_size
            // return float(self.env['ir.config_parameter'].sudo().get_param('base.default_max_email_size', '10'))
            */
            return default;
        }

        public async Task<TEntity> GetPersonalMailServersLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py) ---
            // def _get_personal_mail_servers_limit(self):
            // """Return the number of email we can send in 1 minutes for this outgoing server.
            // 
            // 0 fallbacks to 30 to avoid blocking servers.
            // """
            // return int(self.env['ir.config_parameter'].sudo().get_param('mail.server.personal.limit.minutes')) or 30
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py) ---
            // def _get_personal_mail_servers_limit(self):
            // """Return the number of email we can send in 1 minutes for this outgoing server.
            // 
            // 0 fallbacks to 30 to avoid blocking servers.
            // """
            // if self.smtp_authentication == 'outlook':
            //     # Outlook flag way faster email as spam, so we set a lower limit
            //     return int(self.env['ir.config_parameter'].sudo()
            //         .get_param('mail.server.personal.limit.minutes_outlook')) or 10
            // return super()._get_personal_mail_servers_limit()
            */
            return default;
        }

        public async Task<TEntity> GetTestEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_mail_server.py) ---
            // def _get_test_email_from(self):
            // self.ensure_one()
            // if from_filter_parts := [part.strip() for part in (self.from_filter or '').split(",") if part.strip()]:
            //     # find first found complete email in filter parts
            //     if mail_from := next((email for email in from_filter_parts if "@" in email), None):
            //         return mail_from
            //     # the mail server is configured for a domain that matches the default email address
            //     alias_domains = self.env['mail.alias.domain'].sudo().search([])
            //     matching = next(
            //         (alias_domain for alias_domain in alias_domains
            //          if self._match_from_filter(alias_domain.default_from_email, self.from_filter)
            //         ), False
            //     )
            //     if matching:
            //         return matching.default_from_email
            //     # fake default_from "odoo@domain"
            //     return f"odoo@{from_filter_parts[0]}"
            // # no from_filter or from_filter is configured for a domain different that
            // # the default_from of company's alias_domain -> fallback
            // return super()._get_test_email_from()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _get_test_email_from(self):
            // self.ensure_one()
            // email_from = False
            // if from_filter_parts := self._parse_from_filter(self.from_filter):
            //     # find first found complete email in filter parts
            //     email_from = next((email for email in from_filter_parts if "@" in email), False)
            //     # no complete email -> consider noreply
            //     if not email_from:
            //         email_from = f"noreply@{from_filter_parts[0]}"
            // if not email_from:
            //     # Fallback to current user email if there's no from filter
            //     email_from = self.env.user.email
            // if not email_from or "@" not in email_from:
            //     raise UserError(_('Please configure an email on the current user to simulate '
            //                       'sending an email message via this outgoing server'))
            // return email_from
            */
            return default;
        }

        public async Task<TEntity> GetTestEmailToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _get_test_email_to(self):
            // return "noreply@odoo.com"
            */
            return default;
        }

        public async Task<TEntity> ImapLoginInternalAsync<TEntity>(IEnumerable<TEntity> entities, object connection) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: fetchmail_server.py) ---
            // def _imap_login__(self, connection):  # noqa: PLW3201
            // """Authenticate the IMAP connection.
            // 
            // If the mail server is Gmail, we use the OAuth2 authentication protocol.
            // """
            // self.ensure_one()
            // if self.server_type == 'gmail':
            //     auth_string = self._generate_oauth2_string(self.user, self.google_gmail_refresh_token)
            //     connection.authenticate('XOAUTH2', lambda x: auth_string)
            //     connection.select('INBOX')
            // else:
            //     super()._imap_login__(connection)
            */
            return default;
        }

        public async Task<TEntity> MatchFromFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_from, object from_filter) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _match_from_filter(self, email_from, from_filter):
            // """Return True is the given email address match the "from_filter" field.
            // 
            // The from filter can be Falsy (always match),
            // a domain name or an full email address.
            // """
            // if not from_filter:
            //     return True
            // 
            // normalized_mail_from = email_normalize(email_from)
            // normalized_domain = email_domain_extract(normalized_mail_from)
            // 
            // for email_filter in self._parse_from_filter(from_filter):
            //     if '@' in email_filter and email_normalize(email_filter) == normalized_mail_from:
            //         return True
            //     if '@' not in email_filter and email_domain_normalize(email_filter) == normalized_domain:
            //         return True
            // return False
            */
            return default;
        }

        public async Task<TEntity> OnChangeSmtpUserGmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: ir_mail_server.py) ---
            // def _on_change_smtp_user_gmail(self):
            // """The Gmail mail servers can only be used for the user personal email address."""
            // if self.smtp_authentication == 'gmail':
            //     self.from_filter = self.smtp_user
            */
            return default;
        }

        public async Task<TEntity> OnChangeSmtpUserOutlookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py) ---
            // def _on_change_smtp_user_outlook(self):
            // """The Outlook mail servers can only be used for the user personal email address."""
            // if self.smtp_authentication == 'outlook':
            //     self.from_filter = self.smtp_user
            */
            return default;
        }

        public async Task<TEntity> OnchangeEncryptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: ir_mail_server.py) ---
            // def _onchange_encryption(self):
            // """Do not change the SMTP configuration if it's a Gmail server
            // (e.g. the port which is already set)"""
            // if self.smtp_authentication != 'gmail':
            //     super()._onchange_encryption()
            */
            return default;
        }

        public async Task<TEntity> OnchangeServerTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: fetchmail_server.py) ---
            // def onchange_server_type(self):
            // """Set the default configuration for a IMAP Gmail server."""
            // if self.server_type == 'gmail':
            //     self.server = 'imap.gmail.com'
            //     self.is_ssl = True
            //     self.port = 993
            // else:
            //     self.google_gmail_refresh_token = False
            //     self.google_gmail_access_token = False
            //     self.google_gmail_access_token_expiration = False
            //     super().onchange_server_type()
            */
            return default;
        }

        public async Task<TEntity> OnchangeSmtpAuthenticationGmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: ir_mail_server.py) ---
            // def _onchange_smtp_authentication_gmail(self):
            // if self.smtp_authentication == 'gmail':
            //     self.smtp_host = 'smtp.gmail.com'
            //     self.smtp_encryption = 'starttls'
            //     self.smtp_port = 587
            // else:
            //     self.google_gmail_refresh_token = False
            //     self.google_gmail_access_token = False
            //     self.google_gmail_access_token_expiration = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeSmtpAuthenticationOutlookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py) ---
            // def _onchange_smtp_authentication_outlook(self):
            // if self.smtp_authentication == 'outlook':
            //     self.smtp_host = 'smtp.outlook.com'
            //     self.smtp_encryption = 'starttls'
            //     self.smtp_port = 587
            // else:
            //     self.microsoft_outlook_refresh_token = False
            //     self.microsoft_outlook_access_token = False
            //     self.microsoft_outlook_access_token_expiration = False
            */
            return default;
        }

        public async Task<TEntity> OpenGoogleGmailUriAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: google_gmail_mixin.py) ---
            // def open_google_gmail_uri(self):
            // """Open the URL to accept the Gmail permission.
            // 
            // This is done with an action, so we can force the user the save the form.
            // We need him to save the form so the current mail server record exist in DB, and
            // we can include the record ID in the URL.
            // """
            // self.ensure_one()
            // 
            // if not self.env.is_admin():
            //     raise AccessError(_('Only the administrator can link a Gmail mail server.'))
            // 
            // email_normalized = tools.email_normalize(self[self._email_field])
            // if not email_normalized:
            //     raise UserError(_('Please enter a valid email address.'))
            // 
            // Config = self.env['ir.config_parameter'].sudo()
            // google_gmail_client_id = Config.get_param('google_gmail_client_id')
            // google_gmail_client_secret = Config.get_param('google_gmail_client_secret')
            // is_configured = google_gmail_client_id and google_gmail_client_secret
            // 
            // if not is_configured:  # use IAP (see '/google_gmail/iap_confirm')
            //     if release.version_info[-1] != 'e':
            //         raise UserError(_('Please configure your Gmail credentials.'))
            // 
            //     gmail_iap_endpoint = self.env['ir.config_parameter'].sudo().get_param(
            //         'mail.server.gmail.iap.endpoint',
            //         self._DEFAULT_GMAIL_IAP_ENDPOINT,
            //     )
            //     db_uuid = self.env['ir.config_parameter'].sudo().get_param('database.uuid')
            // 
            //     # final callback URL that will receive the token from IAP
            //     callback_params = url_encode({
            //         'model': self._name,
            //         'rec_id': self.id,
            //         'csrf_token': self._get_gmail_csrf_token(),
            //     })
            //     callback_url = url_join(self.get_base_url(), f'/google_gmail/iap_confirm?{callback_params}')
            // 
            //     iap_url = url_join(gmail_iap_endpoint, '/api/mail_oauth/1/gmail')
            //     try:
            //         response = requests.get(
            //             iap_url,
            //             params={'db_uuid': db_uuid, 'callback_url': callback_url},
            //             timeout=GMAIL_TOKEN_REQUEST_TIMEOUT)
            //         response.raise_for_status()
            //     except requests.exceptions.RequestException as e:
            //         _logger.error('Can not contact IAP: %s.', e)
            //         raise UserError(_('Oops, we could not authenticate you. Please try again later.'))
            // 
            //     response = response.json()
            //     if 'error' in response:
            //         self._raise_iap_error(response['error'])
            // 
            //     # URL on IAP that will redirect to Gmail login page
            //     google_gmail_uri = response['url']
            // 
            // else:
            //     google_gmail_uri = self.google_gmail_uri
            // 
            // if not google_gmail_uri:
            //     raise UserError(_('Please configure your Gmail credentials.'))
            // 
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': google_gmail_uri,
            //     'target': 'self',
            // }
            */
            return default;
        }

        public async Task<TEntity> ParseFromFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object from_filter) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _parse_from_filter(self, from_filter):
            // return [part.strip() for part in (from_filter or '').split(',') if part.strip()]
            */
            return default;
        }

        public async Task<TEntity> PrepareEmailMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object smtp_session) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _prepare_email_message__(self, message, smtp_session):  # noqa: PLW3201
            // """Prepare the SMTP information (from, to, message) before sending.
            // 
            // :param message: the email.message.Message to send, information like the
            //     Return-Path, the From, etc... will be used to find the smtp_from and to smtp_to
            // :param smtp_session: the opened SMTP session to use to authenticate the sender
            // 
            // :return: smtp_from, smtp_to_list, message
            //     smtp_from: email to used during the authentication to the mail server
            //     smtp_to_list: list of email address which will receive the email
            //     message: the email.message.Message to send
            // """
            // # Use the default bounce address **only if** no Return-Path was
            // # provided by caller.  Caller may be using Variable Envelope Return
            // # Path (VERP) to detect no-longer valid email addresses.
            // # context may force a value, e.g. mail.alias.domain usage
            // bounce_address = self.env.context.get('domain_bounce_address') or message['Return-Path'] or self._get_default_bounce_address() or message['From']
            // 
            // smtp_from = message['From'] or bounce_address
            // assert smtp_from, self.NO_FOUND_SMTP_FROM
            // 
            // smtp_to_list = self._prepare_smtp_to_list(message, smtp_session)
            // assert smtp_to_list, self.NO_VALID_RECIPIENT
            // 
            // # Try to not spoof the mail from headers; fetch session-based or contextualized
            // # values for encapsulation computation
            // from_filter = getattr(smtp_session, 'from_filter', False)
            // smtp_from = getattr(smtp_session, 'smtp_from', False) or smtp_from
            // notifications_email = email_normalize(
            //     self.env.context.get('domain_notifications_email') or self._get_default_from_address()
            // )
            // if notifications_email and email_normalize(smtp_from) == notifications_email and email_normalize(message['From']) != notifications_email:
            //     smtp_from = encapsulate_email(message['From'], notifications_email)
            // 
            // # alter message
            // self._alter_message__(message, smtp_from, smtp_to_list)
            // 
            // # Check if it's still possible to put the bounce address as smtp_from
            // if self._match_from_filter(bounce_address, from_filter):
            //     # Mail headers FROM will be spoofed to be able to receive bounce notifications
            //     # Because the mail server support the domain of the bounce address
            //     smtp_from = bounce_address
            // 
            // # The email's "Envelope From" (Return-Path) must only contain ASCII characters.
            // smtp_from_rfc2822 = extract_rfc2822_addresses(smtp_from)
            // if not smtp_from_rfc2822:
            //     raise AssertionError(
            //         self.NO_VALID_FROM,
            //         f"Malformed 'Return-Path' or 'From' address: {smtp_from} - "
            //         "It should contain one valid plain ASCII email"
            //     )
            // smtp_from = smtp_from_rfc2822[-1]
            // 
            // return smtp_from, smtp_to_list, message
            */
            return default;
        }

        public async Task<TEntity> PrepareSmtpToListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object smtp_session) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _prepare_smtp_to_list(self, message, smtp_session):
            // """ Prepare SMTP To address list, based on To / Cc / Bcc.
            // 
            // Optional 'send_validated_to' context key filter restricts addresses to
            // be part of that list.
            // 
            // Optional 'send_smtp_skip_to' context key holds a recipients block list
            // """
            // email_to = message['To']
            // email_cc = message['Cc']
            // email_bcc = message['Bcc']
            // 
            // # Support optional pre-validated To list, used notably when formatted
            // # emails may create fake emails using extract_rfc2822_addresses, e.g.
            // # '"Bike@Home" <email@domain.com>' which can be considered as containing
            // # 2 emails by extract_rfc2822_addresses
            // validated_to = self.env.context.get('send_validated_to') or []
            // 
            // # Support optional skip To list
            // skip_to_lst = self.env.context.get('send_smtp_skip_to') or []
            // 
            // # All recipient addresses must only contain ASCII characters
            // return [
            //     address
            //     for base in [email_to, email_cc, email_bcc]
            //     # be sure a given address does not return duplicates (but duplicates
            //     # in final smtp to list is still ok)
            //     for address in tools.misc.unique(extract_rfc2822_addresses(base))
            //     if (
            //         address and (not validated_to or address in validated_to)
            //         and email_normalize(address, strict=False) not in skip_to_lst
            //     )
            // ]
            */
            return default;
        }

        public async Task<TEntity> RaiseIapErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: google_gmail_mixin.py) ---
            // def _raise_iap_error(self, error):
            // raise UserError(get_iap_error_message(self.env, error))
            */
            return default;
        }

        public async Task<TEntity> SendEmailAsync<TEntity>(IEnumerable<TEntity> entities, object message, Guid mail_server_id, object smtp_server, object smtp_port, object smtp_user, object smtp_password, object smtp_encryption, object smtp_ssl_certificate, object smtp_ssl_private_key, object smtp_debug, object smtp_session) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def send_email(self, message, mail_server_id=None, smtp_server=None, smtp_port=None,
            //            smtp_user=None, smtp_password=None, smtp_encryption=None,
            //            smtp_ssl_certificate=None, smtp_ssl_private_key=None,
            //            smtp_debug=False, smtp_session=None):
            // """Sends an email directly (no queuing).
            // 
            // No retries are done, the caller should handle MailDeliveryException in order to ensure that
            // the mail is never lost.
            // 
            // If the mail_server_id is provided, sends using this mail server, ignoring other smtp_* arguments.
            // If mail_server_id is None and smtp_server is None, use the default mail server (highest priority).
            // If mail_server_id is None and smtp_server is not None, use the provided smtp_* arguments.
            // If both mail_server_id and smtp_server are None, look for an 'smtp_server' value in server config,
            // and fails if not found.
            // 
            // :param message: the email.message.Message to send. The envelope sender will be extracted from the
            //                 ``Return-Path`` (if present), or will be set to the default bounce address.
            //                 The envelope recipients will be extracted from the combined list of ``To``,
            //                 ``CC`` and ``BCC`` headers.
            // :param smtp_session: optional pre-established SMTP session. When provided,
            //                      overrides `mail_server_id` and all the `smtp_*` parameters.
            //                      Passing the matching `mail_server_id` may yield better debugging/log
            //                      messages. The caller is in charge of disconnecting the session.
            // :param mail_server_id: optional id of ir.mail_server to use for sending. overrides other smtp_* arguments.
            // :param smtp_server: optional hostname of SMTP server to use
            // :param smtp_encryption: optional TLS mode, one of 'none', 'starttls', 'starttls_strict', 'ssl', or 'ssl_strict'.
            //     The 'strict' variants verify the remote server's certificate against the operating system trust store.
            // :param smtp_port: optional SMTP port, if mail_server_id is not passed
            // :param smtp_user: optional SMTP user, if mail_server_id is not passed
            // :param smtp_password: optional SMTP password to use, if mail_server_id is not passed
            // :param smtp_ssl_certificate: filename of the SSL certificate used for authentication
            // :param smtp_ssl_private_key: filename of the SSL private key used for authentication
            // :param smtp_debug: optional SMTP debug flag, if mail_server_id is not passed
            // :return: the Message-ID of the message that was just sent, if successfully sent, otherwise raises
            //          MailDeliveryException and logs root cause.
            // """
            // smtp = smtp_session
            // if not smtp:
            //     smtp = self._connect__(
            //         smtp_server, smtp_port, smtp_user, smtp_password, smtp_encryption,
            //         smtp_from=message['From'], ssl_certificate=smtp_ssl_certificate, ssl_private_key=smtp_ssl_private_key,
            //         smtp_debug=smtp_debug, mail_server_id=mail_server_id,)
            // 
            // smtp_from, smtp_to_list, message = self._prepare_email_message__(message, smtp)
            // 
            // # Do not actually send emails in testing mode!
            // if self._disable_send():
            //     _test_logger.debug("skip sending email in test mode")
            //     return message['Message-Id']
            // 
            // try:
            //     message_id = message['Message-Id']
            // 
            //     smtp.send_message(message, smtp_from, smtp_to_list)
            // 
            //     # do not quit() a pre-established smtp_session
            //     if not smtp_session:
            //         smtp.quit()
            // except smtplib.SMTPServerDisconnected:
            //     raise
            // except Exception as e:
            //     msg = _(
            //         "Mail delivery failed via SMTP server '%(server)s'.\n%(exception_name)s: %(message)s",
            //         server=smtp_server,
            //         exception_name=e.__class__.__name__,
            //         message=e,
            //     )
            //     _logger.info(msg)
            //     raise MailDeliveryException(_("Mail Delivery Failed"), msg)
            // return message_id
            */
            return default;
        }

        public async Task<TEntity> SetDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def set_draft(self):
            // self.write({'state': 'draft'})
            // return True
            */
            return default;
        }

        public async Task<TEntity> SmtpLoginInternalAsync<TEntity>(IEnumerable<TEntity> entities, object connection, object smtp_user, object smtp_password) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: ir_mail_server.py) ---
            // def _smtp_login__(self, connection, smtp_user, smtp_password):  # noqa: PLW3201
            // if len(self) == 1 and self.smtp_authentication == 'gmail':
            //     auth_string = self._generate_oauth2_string(smtp_user, self.google_gmail_refresh_token)
            //     oauth_param = base64.b64encode(auth_string.encode()).decode()
            //     connection.ehlo()
            //     connection.docmd('AUTH', f'XOAUTH2 {oauth_param}')
            // else:
            //     super()._smtp_login__(connection, smtp_user, smtp_password)
            */
            return default;
        }

        public async Task<TEntity> TestSmtpConnectionAsync<TEntity>(IEnumerable<TEntity> entities, object autodetect_max_email_size) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def test_smtp_connection(self, autodetect_max_email_size=False):
            // """Test the connection and if autodetect_max_email_size, set auto-detected max email size.
            // 
            // :param bool autodetect_max_email_size: whether to autodetect the max email size
            // :return: client action to notify the user of the result of the operation (connection test or
            //     auto-detection successful depending on the ``autodetect_max_email_size`` parameter)
            // :rtype: dict
            // 
            // :raises UserError: if the connection fails and if ``autodetect_max_email_size`` and
            //     the server doesn't support the auto-detection of email max size
            // """
            // for server in self:
            //     smtp = False
            //     try:
            //         # simulate sending an email from current user's address - without sending it!
            //         email_from = server._get_test_email_from()
            //         email_to = server._get_test_email_to()
            //         smtp = self._connect__(mail_server_id=server.id, allow_archived=True, smtp_from=email_from)
            //         # Testing the MAIL FROM step should detect sender filter problems
            //         (code, repl) = smtp.mail(email_from)
            //         if code != 250:
            //             raise UserError(_('The server refused the sender address (%(email_from)s) with error %(repl)s', email_from=email_from, repl=repl))  # noqa: TRY301
            //         # Testing the RCPT TO step should detect most relaying problems
            //         (code, repl) = smtp.rcpt(email_to)
            //         if code not in (250, 251):
            //             raise UserError(_('The server refused the test recipient (%(email_to)s) with error %(repl)s', email_to=email_to, repl=repl))  # noqa: TRY301
            //         # Beginning the DATA step should detect some deferred rejections
            //         # Can't use self.data() as it would actually send the mail!
            //         smtp.putcmd("data")
            //         (code, repl) = smtp.getreply()
            //         if code != 354:
            //             raise UserError(_('The server refused the test connection with error %(repl)s', repl=repl))  # noqa: TRY301
            //         if autodetect_max_email_size:
            //             max_size = smtp.esmtp_features.get('size')
            //             if not max_size:
            //                 raise UserError(_('The server "%(server_name)s" doesn\'t return the maximum email size.',
            //                                   server_name=server.name))
            //             server.max_email_size = float(max_size) / (1024 ** 2)
            //     except (UnicodeError, idna.core.InvalidCodepoint) as e:
            //         raise UserError(_("Invalid server name!\n %s", e)) from e
            //     except (gaierror, timeout) as e:
            //         raise UserError(_("No response received. Check server address and port number.\n %s", e)) from e
            //     except smtplib.SMTPServerDisconnected as e:
            //         raise UserError(_("The server has closed the connection unexpectedly. Check configuration served on this port number.\n %s", e)) from e
            //     except smtplib.SMTPResponseException as e:
            //         raise UserError(_("Server replied with following exception:\n %s", e)) from e
            //     except smtplib.SMTPNotSupportedError as e:
            //         raise UserError(_("An option is not supported by the server:\n %s", e)) from e
            //     except smtplib.SMTPException as e:
            //         raise UserError(_("An SMTP exception occurred. Check port number and connection security type.\n %s", e)) from e
            //     except CertificateError as e:
            //         raise UserError(_("An SSL exception occurred. Check connection security type.\n CertificateError: %s", e)) from e
            //     except (ssl.SSLError, SSLError) as e:
            //         raise UserError(_("An SSL exception occurred. Check connection security type.\n %s", e)) from e
            //     except UserError:
            //         raise
            //     except Exception as e:
            //         _logger.warning("Connection test on %s failed with a generic error.", server, exc_info=True)
            //         raise UserError(_("Connection Test Failed! Here is what we got instead:\n %s", e)) from e
            //     finally:
            //         try:
            //             if smtp:
            //                 smtp.close()
            //         except Exception:
            //             # ignored, just a consequence of the previous exception
            //             pass
            // 
            // if autodetect_max_email_size:
            //     message = _(
            //         'Email maximum size updated (%(details)s).',
            //         details=', '.join(f'{server.name}: {human_size(server.max_email_size * 1024 ** 2)}' for server in self))
            // else:
            //     message = _('Connection Test Successful!')
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'message': message,
            //         'type': 'success',
            //         'sticky': False,
            //         'next': {'type': 'ir.actions.act_window_close'},  # force a form reload
            //     },
            // }
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def unlink(self):
            // res = super().unlink()
            // self._update_cron()
            // return res
            */
            return default;
        }

        public async Task<TEntity> UpdateCronInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def _update_cron(self):
            // if self.env.context.get('fetchmail_cron_running'):
            //     return
            // try:
            //     # Enabled/Disable cron based on the number of 'done' server of type pop or imap
            //     cron = self.env.ref('mail.ir_cron_mail_gateway_action')
            //     cron.toggle(model=self._name, domain=MAIL_SERVER_DOMAIN)
            // except ValueError:
            //     pass
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IGoogleGmailMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def write(self, vals):
            // res = super().write(vals)
            // self._update_cron()
            // return res
            */
            return default;
        }
    }
}