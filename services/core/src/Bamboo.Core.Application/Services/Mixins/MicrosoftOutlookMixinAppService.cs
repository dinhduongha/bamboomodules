using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("microsoft_outlook", Depends = new[] { "mail" })]
    public class MicrosoftOutlookMixinAppService : ApplicationService, IMicrosoftOutlookMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public MicrosoftOutlookMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> ActionRetrieveMaxEmailSizeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def action_retrieve_max_email_size(self):
            // self.ensure_one()
            // return self.test_smtp_connection(autodetect_max_email_size=True)
            */
            return default;
        }

        public async Task<TEntity> ActiveUsagesComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
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
            // usages_super = super(IrMailServer, self)._active_usages_compute()
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

        public async Task<TEntity> BuildEmailAsync<TEntity>(IEnumerable<TEntity> entities, object email_from, object email_to, object subject, object body, object email_cc, object email_bcc, object reply_to, object attachments, Guid message_id, object references, Guid object_id, object subtype, object headers, object body_alternative, object subtype_alternative) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def build_email(self, email_from, email_to, subject, body, email_cc=None, email_bcc=None, reply_to=False,
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
            //             #  Use binary encoding for "message/rfc822" attachments (see RFC 2046 Section 5.2.1)
            //             msg.add_attachment(fcontent, maintype, subtype, filename=fname, cte='binary')
            //         else:
            //             msg.add_attachment(fcontent, maintype, subtype, filename=fname)
            // return msg
            */
            return default;
        }

        public async Task<TEntity> ButtonConfirmLoginAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def button_confirm_login(self):
            // for server in self:
            //     connection = None
            //     try:
            //         connection = server.connect(allow_archived=True)
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
            //                 connection_type = server._get_connection_type()
            //                 if connection_type == 'imap':
            //                     connection.close()
            //                 elif connection_type == 'pop':
            //                     connection.quit()
            //         except Exception:
            //             # ignored, just a consequence of the previous exception
            //             pass
            // return True
            */
            return default;
        }

        public async Task<TEntity> CheckSmtpSslFilesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
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

        public async Task<TEntity> CheckUseGoogleGmailServiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
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

        public async Task<TEntity> CheckUseMicrosoftOutlookServiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: fetchmail_server.py) ---
            // def _check_use_microsoft_outlook_service(self):
            // for server in self:
            //     if server.server_type == 'outlook' and not server.is_ssl:
            //         raise UserError(_('SSL is required for server “%s”.', server.name))
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py) ---
            // def _check_use_microsoft_outlook_service(self):
            // outlook_servers = self.filtered(lambda server: server.smtp_authentication == 'outlook')
            // for server in outlook_servers:
            //     if server.smtp_pass:
            //         raise UserError(_(
            //             'Please leave the password field empty for Outlook mail server “%s”. '
            //             'The OAuth process does not require it', server.name))
            // 
            //     if server.smtp_encryption != 'starttls':
            //         raise UserError(_(
            //             'Incorrect Connection Security for Outlook mail server “%s”. '
            //             'Please set it to "TLS (STARTTLS)".', server.name))
            // 
            //     if not server.smtp_user:
            //         raise UserError(_(
            //                     'Please fill the "Username" field with your Outlook/Office365 username (your email address). '
            //                     'This should be the same account as the one used for the Outlook OAuthentication Token.'))
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMicrosoftOutlookConfiguredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: fetchmail_server.py) ---
            // def _compute_is_microsoft_outlook_configured(self):
            // outlook_servers = self.filtered(lambda server: server.server_type == 'outlook')
            // (self - outlook_servers).is_microsoft_outlook_configured = False
            // super(FetchmailServer, outlook_servers)._compute_is_microsoft_outlook_configured()
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py) ---
            // def _compute_is_microsoft_outlook_configured(self):
            // outlook_servers = self.filtered(lambda server: server.smtp_authentication == 'outlook')
            // (self - outlook_servers).is_microsoft_outlook_configured = False
            // super(IrMailServer, outlook_servers)._compute_is_microsoft_outlook_configured()
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: microsoft_outlook_mixin.py) ---
            // def _compute_is_microsoft_outlook_configured(self):
            // Config = self.env['ir.config_parameter'].sudo()
            // microsoft_outlook_client_id = Config.get_param('microsoft_outlook_client_id')
            // microsoft_outlook_client_secret = Config.get_param('microsoft_outlook_client_secret')
            // self.is_microsoft_outlook_configured = microsoft_outlook_client_id and microsoft_outlook_client_secret
            */
            return default;
        }

        public async Task<TEntity> ComputeOutlookUriInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: microsoft_outlook_mixin.py) ---
            // def _compute_outlook_uri(self):
            // Config = self.env['ir.config_parameter'].sudo()
            // base_url = self.get_base_url()
            // microsoft_outlook_client_id = Config.get_param('microsoft_outlook_client_id')
            // 
            // for record in self:
            //     if not record.id or not record.is_microsoft_outlook_configured:
            //         record.microsoft_outlook_uri = False
            //         continue
            // 
            //     record.microsoft_outlook_uri = url_join(self._get_microsoft_endpoint(), 'authorize?%s' % url_encode({
            //         'client_id': microsoft_outlook_client_id,
            //         'response_type': 'code',
            //         'redirect_uri': url_join(base_url, '/microsoft_outlook/confirm'),
            //         'response_mode': 'query',
            //         # offline_access is needed to have the refresh_token
            //         'scope': 'offline_access %s' % self._OUTLOOK_SCOPE,
            //         'state': json.dumps({
            //             'model': record._name,
            //             'id': record.id,
            //             'csrf_token': record._get_outlook_csrf_token(),
            //         })
            //     }))
            */
            return default;
        }

        public async Task<TEntity> ComputeServerTypeInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: fetchmail_server.py) ---
            // def _compute_server_type_info(self):
            // outlook_servers = self.filtered(lambda server: server.server_type == 'outlook')
            // outlook_servers.server_type_info = _(
            //     'Connect your personal Outlook account using OAuth. \n'
            //     'You will be redirected to the Outlook login page to accept '
            //     'the permissions.')
            // super(FetchmailServer, self - outlook_servers)._compute_server_type_info()
            */
            return default;
        }

        public async Task<TEntity> ComputeSmtpAuthenticationInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py) ---
            // def _compute_smtp_authentication_info(self):
            // outlook_servers = self.filtered(lambda server: server.smtp_authentication == 'outlook')
            // outlook_servers.smtp_authentication_info = _(
            //     'Connect your Outlook account with the OAuth Authentication process.  \n'
            //     'By default, only a user with a matching email address will be able to use this server. '
            //     'To extend its use, you should set a "mail.default.from" system parameter.')
            // super(IrMailServer, self - outlook_servers)._compute_smtp_authentication_info()
            */
            return default;
        }

        public async Task<TEntity> ConnectAsync<TEntity>(IEnumerable<TEntity> entities, object allow_archived) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def connect(self, allow_archived=False):
            // """
            // :param bool allow_archived: by default (False), an exception is raised when calling this method on an
            //    archived record. It can be set to True for testing so that the exception is no longer raised.
            // """
            // self.ensure_one()
            // if not allow_archived and not self.active:
            //     raise UserError(_('The server "%s" cannot be used because it is archived.', self.display_name))
            // connection_type = self._get_connection_type()
            // if connection_type == 'imap':
            //     connection = IMAP4Connection(self.server, int(self.port), self.is_ssl)
            //     self._imap_login(connection)
            // elif connection_type == 'pop':
            //     connection = POP3Connection(self.server, int(self.port), self.is_ssl)
            //     #TODO: use this to remove only unread messages
            //     #connection.user("recent:"+server.user)
            //     connection.user(self.user)
            //     connection.pass_(self.password)
            // return connection
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def create(self, vals_list):
            // res = super(FetchmailServer, self).create(vals_list)
            // self._update_cron()
            // return res
            */
            return default;
        }

        public async Task<TEntity> FetchMailAsync<TEntity>(IEnumerable<TEntity> entities, object raise_exception) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def fetch_mail(self, raise_exception=True):
            // """ WARNING: meant for cron usage only - will commit() after each email! """
            // additionnal_context = {
            //     'fetchmail_cron_running': True
            // }
            // MailThread = self.env['mail.thread']
            // for server in self:
            //     _logger.info('start checking for new emails on %s server %s', server.server_type, server.name)
            //     additionnal_context['default_fetchmail_server_id'] = server.id
            //     count, failed = 0, 0
            //     imap_server = None
            //     pop_server = None
            //     connection_type = server._get_connection_type()
            //     if connection_type == 'imap':
            //         try:
            //             imap_server = server.connect()
            //             imap_server.select()
            //             result, data = imap_server.search(None, '(UNSEEN)')
            //             for num in data[0].split():
            //                 res_id = None
            //                 result, data = imap_server.fetch(num, '(RFC822)')
            //                 imap_server.store(num, '-FLAGS', '\\Seen')
            //                 try:
            //                     res_id = MailThread.with_context(**additionnal_context).message_process(server.object_id.model, data[0][1], save_original=server.original, strip_attachments=(not server.attach))
            //                 except Exception:
            //                     _logger.info('Failed to process mail from %s server %s.', server.server_type, server.name, exc_info=True)
            //                     failed += 1
            //                 imap_server.store(num, '+FLAGS', '\\Seen')
            //                 self._cr.commit()
            //                 count += 1
            //             _logger.info("Fetched %d email(s) on %s server %s; %d succeeded, %d failed.", count, server.server_type, server.name, (count - failed), failed)
            //         except Exception as e:
            //             if raise_exception:
            //                 raise ValidationError(_("Couldn't get your emails. Check out the error message below for more info:\n%s", e)) from e
            //             else:
            //                 _logger.info("General failure when trying to fetch mail from %s server %s.", server.server_type, server.name, exc_info=True)
            //         finally:
            //             if imap_server:
            //                 try:
            //                     imap_server.close()
            //                     imap_server.logout()
            //                 except (OSError, IMAP4.abort):
            //                     _logger.warning('Failed to properly finish imap connection: %s.', server.name, exc_info=True)
            //     elif connection_type == 'pop':
            //         try:
            //             while True:
            //                 failed_in_loop = 0
            //                 num = 0
            //                 pop_server = server.connect()
            //                 (num_messages, total_size) = pop_server.stat()
            //                 pop_server.list()
            //                 for num in range(1, min(MAX_POP_MESSAGES, num_messages) + 1):
            //                     (header, messages, octets) = pop_server.retr(num)
            //                     message = (b'\n').join(messages)
            //                     res_id = None
            //                     try:
            //                         res_id = MailThread.with_context(**additionnal_context).message_process(server.object_id.model, message, save_original=server.original, strip_attachments=(not server.attach))
            //                         pop_server.dele(num)
            //                     except Exception:
            //                         _logger.info('Failed to process mail from %s server %s.', server.server_type, server.name, exc_info=True)
            //                         failed += 1
            //                         failed_in_loop += 1
            //                     self.env.cr.commit()
            //                 _logger.info("Fetched %d email(s) on %s server %s; %d succeeded, %d failed.", num, server.server_type, server.name, (num - failed_in_loop), failed_in_loop)
            //                 # Stop if (1) no more message left or (2) all messages have failed
            //                 if num_messages < MAX_POP_MESSAGES or failed_in_loop == num:
            //                     break
            //                 pop_server.quit()
            //         except Exception as e:
            //             if raise_exception:
            //                 raise ValidationError(_("Couldn't get your emails. Check out the error message below for more info:\n%s", e)) from e
            //             else:
            //                 _logger.info("General failure when trying to fetch mail from %s server %s.", server.server_type, server.name, exc_info=True)
            //         finally:
            //             if pop_server:
            //                 try:
            //                     pop_server.quit()
            //                 except OSError:
            //                     _logger.warning('Failed to properly finish pop connection: %s.', server.name, exc_info=True)
            //     server.write({'date': fields.Datetime.now()})
            // return True
            */
            return default;
        }

        public async Task<TEntity> FetchMailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def _fetch_mails(self):
            // """ Method called by cron to fetch mails from servers """
            // return self.search([('state', '=', 'done'), ('server_type', '!=', 'local')]).fetch_mail(raise_exception=False)
            */
            return default;
        }

        public async Task<TEntity> FetchOutlookAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object refresh_token) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: microsoft_outlook_mixin.py) ---
            // def _fetch_outlook_access_token(self, refresh_token):
            // """Refresh the access token thanks to the refresh token.
            // 
            // :return:
            //     access_token, access_token_expiration
            // """
            // response = self._fetch_outlook_token('refresh_token', refresh_token=refresh_token)
            // return (
            //     response['refresh_token'],
            //     response['access_token'],
            //     int(time.time()) + int(response['expires_in']),
            // )
            */
            return default;
        }

        public async Task<TEntity> FetchOutlookRefreshTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object authorization_code) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: microsoft_outlook_mixin.py) ---
            // def _fetch_outlook_refresh_token(self, authorization_code):
            // """Request the refresh token and the initial access token from the authorization code.
            // 
            // :return:
            //     refresh_token, access_token, access_token_expiration
            // """
            // response = self._fetch_outlook_token('authorization_code', code=authorization_code)
            // return (
            //     response['refresh_token'],
            //     response['access_token'],
            //     int(time.time()) + int(response['expires_in']),
            // )
            */
            return default;
        }

        public async Task<TEntity> FetchOutlookTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object grant_type) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: microsoft_outlook_mixin.py) ---
            // def _fetch_outlook_token(self, grant_type, **values):
            // """Generic method to request an access token or a refresh token.
            // 
            // Return the JSON response of the Outlook API and manage the errors which can occur.
            // 
            // :param grant_type: Depends the action we want to do (refresh_token or authorization_code)
            // :param values: Additional parameters that will be given to the Outlook endpoint
            // """
            // Config = self.env['ir.config_parameter'].sudo()
            // base_url = self.get_base_url()
            // microsoft_outlook_client_id = Config.get_param('microsoft_outlook_client_id')
            // microsoft_outlook_client_secret = Config.get_param('microsoft_outlook_client_secret')
            // 
            // response = requests.post(
            //     url_join(self._get_microsoft_endpoint(), 'token'),
            //     data={
            //         'client_id': microsoft_outlook_client_id,
            //         'client_secret': microsoft_outlook_client_secret,
            //         'scope': 'offline_access %s' % self._OUTLOOK_SCOPE,
            //         'redirect_uri': url_join(base_url, '/microsoft_outlook/confirm'),
            //         'grant_type': grant_type,
            //         **values,
            //     },
            //     timeout=10,
            // )
            // 
            // if not response.ok:
            //     try:
            //         error_description = response.json()['error_description']
            //     except Exception:
            //         error_description = _('Unknown error.')
            //     raise UserError(_('An error occurred when fetching the access token. %s', error_description))
            // 
            // return response.json()
            */
            return default;
        }

        public async Task<TEntity> FindMailServerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_from, object mail_servers) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _find_mail_server(self, email_from, mail_servers=None):
            // """Find the appropriate mail server for the given email address.
            // 
            // Returns: Record<ir.mail_server>, email_from
            // - Mail server to use to send the email (None if we use the odoo-bin arguments)
            // - Email FROM to use to send the email (in some case, it might be impossible
            //   to use the given email address directly if no mail server is configured for)
            // """
            // email_from_normalized = email_normalize(email_from)
            // email_from_domain = email_domain_extract(email_from_normalized)
            // notifications_email = self.env.context.get('domain_notifications_email') or email_normalize(self._get_default_from_address())
            // notifications_domain = email_domain_extract(notifications_email)
            // 
            // if mail_servers is None:
            //     mail_servers = self.sudo().search([], order='sequence')
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

        public async Task<TEntity> GenerateOutlookOauth2StringInternalAsync<TEntity>(IEnumerable<TEntity> entities, object login) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: microsoft_outlook_mixin.py) ---
            // def _generate_outlook_oauth2_string(self, login):
            // """Generate a OAuth2 string which can be used for authentication.
            // 
            // :param user: Email address of the Outlook account to authenticate
            // :return: The SASL argument for the OAuth2 mechanism.
            // """
            // self.ensure_one()
            // now_timestamp = int(time.time())
            // if not self.microsoft_outlook_access_token \
            //    or not self.microsoft_outlook_access_token_expiration \
            //    or self.microsoft_outlook_access_token_expiration < now_timestamp:
            //     if not self.microsoft_outlook_refresh_token:
            //         raise UserError(_('Please connect with your Outlook account before using it.'))
            //     (
            //         self.microsoft_outlook_refresh_token,
            //         self.microsoft_outlook_access_token,
            //         self.microsoft_outlook_access_token_expiration,
            //     ) = self._fetch_outlook_access_token(self.microsoft_outlook_refresh_token)
            //     _logger.info(
            //         'Microsoft Outlook: fetch new access token. It expires in %i minutes',
            //         (self.microsoft_outlook_access_token_expiration - now_timestamp) // 60)
            // else:
            //     _logger.info(
            //         'Microsoft Outlook: reuse existing access token. It expires in %i minutes',
            //         (self.microsoft_outlook_access_token_expiration - now_timestamp) // 60)
            // 
            // return 'user=%s\1auth=Bearer %s\1\1' % (login, self.microsoft_outlook_access_token)
            */
            return default;
        }

        public async Task<TEntity> GetConnectionTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: fetchmail_server.py) ---
            // def _get_connection_type(self):
            // """Return which connection must be used for this mail server (IMAP or POP).
            // The Outlook mail server used an IMAP connection.
            // """
            // self.ensure_one()
            // return 'imap' if self.server_type == 'outlook' else super()._get_connection_type()
            */
            return default;
        }

        public async Task<TEntity> GetDefaultBounceAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
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
            // :return str/None: defaults to the ``--email-from`` CLI/config parameter.
            // """
            // return tools.config.get("email_from")
            */
            return default;
        }

        public async Task<TEntity> GetDefaultFromAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
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
            // :return str/None: defaults to the ``--email-from`` CLI/config parameter.
            // """
            // return tools.config.get("email_from")
            */
            return default;
        }

        public async Task<TEntity> GetDefaultFromFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _get_default_from_filter(self):
            // """ Computes the default from_filter. It is used when no specific
            // ir.mail_server is used when sending emails, hence having no value for
            // from_filter.
            // 
            // :return str/None: defaults to 'mail.default.from_filter', then
            //   ``--from-filter`` CLI/config parameter.
            // """
            // return self.env['ir.config_parameter'].sudo().get_param(
            //     'mail.default.from_filter', tools.config.get('from_filter')
            // )
            */
            return default;
        }

        public async Task<TEntity> GetMaxEmailSizeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
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

        public async Task<TEntity> GetMicrosoftEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: microsoft_outlook_mixin.py) ---
            // def _get_microsoft_endpoint(self):
            // return self.env["ir.config_parameter"].sudo().get_param(
            //     'microsoft_outlook.endpoint',
            //     'https://login.microsoftonline.com/common/oauth2/v2.0/',
            // )
            */
            return default;
        }

        public async Task<TEntity> GetOutlookCsrfTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: microsoft_outlook_mixin.py) ---
            // def _get_outlook_csrf_token(self):
            // """Generate a CSRF token that will be verified in `microsoft_outlook_callback`.
            // 
            // This will prevent a malicious person to make an admin user disconnect the mail servers.
            // """
            // self.ensure_one()
            // _logger.info('Microsoft Outlook: generate CSRF token for %s #%i', self._name, self.id)
            // return hmac(
            //     env=self.env(su=True),
            //     scope='microsoft_outlook_oauth',
            //     message=(self._name, self.id),
            // )
            */
            return default;
        }

        public async Task<TEntity> GetTestEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
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
            // if from_filter_parts := [part.strip() for part in (self.from_filter or '').split(",") if part.strip()]:
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

        public async Task<TEntity> GetTestEmailToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _get_test_email_to(self):
            // return "noreply@odoo.com"
            */
            return default;
        }

        public async Task<TEntity> ImapLoginInternalAsync<TEntity>(IEnumerable<TEntity> entities, object connection) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: fetchmail_server.py) ---
            // def _imap_login(self, connection):
            // """Authenticate the IMAP connection.
            // 
            // If the mail server is Outlook, we use the OAuth2 authentication protocol.
            // """
            // self.ensure_one()
            // if self.server_type == 'outlook':
            //     auth_string = self._generate_outlook_oauth2_string(self.user)
            //     connection.authenticate('XOAUTH2', lambda x: auth_string)
            //     connection.select('INBOX')
            // else:
            //     super()._imap_login(connection)
            */
            return default;
        }

        public async Task<TEntity> MatchFromFilterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_from, object from_filter) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
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
            // for email_filter in [part.strip() for part in (from_filter or '').split(',') if part.strip()]:
            //     if '@' in email_filter and email_normalize(email_filter) == normalized_mail_from:
            //         return True
            //     if '@' not in email_filter and email_domain_normalize(email_filter) == normalized_domain:
            //         return True
            // return False
            */
            return default;
        }

        public async Task<TEntity> OnChangeSmtpUserGmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
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

        public async Task<TEntity> OnChangeSmtpUserOutlookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
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

        public async Task<TEntity> OnchangeEncryptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py) ---
            // def _onchange_encryption(self):
            // """Do not change the SMTP configuration if it's a Outlook server
            // 
            // (e.g. the port which is already set)"""
            // if self.smtp_authentication != 'outlook':
            //     super()._onchange_encryption()
            */
            return default;
        }

        public async Task<TEntity> OnchangeServerTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: fetchmail_server.py) ---
            // def onchange_server_type(self):
            // """Set the default configuration for a IMAP Outlook server."""
            // if self.server_type == 'outlook':
            //     self.server = 'imap.outlook.com'
            //     self.is_ssl = True
            //     self.port = 993
            // else:
            //     self.microsoft_outlook_refresh_token = False
            //     self.microsoft_outlook_access_token = False
            //     self.microsoft_outlook_access_token_expiration = False
            //     super(FetchmailServer, self).onchange_server_type()
            */
            return default;
        }

        public async Task<TEntity> OnchangeSmtpAuthenticationGmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: ir_mail_server.py) ---
            // def _onchange_smtp_authentication_gmail(self):
            // if self.smtp_authentication == 'gmail':
            //     self.smtp_host = 'smtp.gmail.com'
            //     self.smtp_encryption = 'starttls'
            //     self.smtp_port = 587
            // else:
            //     self.google_gmail_authorization_code = False
            //     self.google_gmail_refresh_token = False
            //     self.google_gmail_access_token = False
            //     self.google_gmail_access_token_expiration = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeSmtpAuthenticationOutlookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
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

        public async Task<TEntity> OpenMicrosoftOutlookUriAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: microsoft_outlook_mixin.py) ---
            // def open_microsoft_outlook_uri(self):
            // """Open the URL to accept the Outlook permission.
            // 
            // This is done with an action, so we can force the user the save the form.
            // We need him to save the form so the current mail server record exist in DB and
            // we can include the record ID in the URL.
            // """
            // self.ensure_one()
            // 
            // if not self.env.user.has_group('base.group_system'):
            //     raise AccessError(_('Only the administrator can link an Outlook mail server.'))
            // 
            // if not self.is_microsoft_outlook_configured:
            //     raise UserError(_('Please configure your Outlook credentials.'))
            // 
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': self.microsoft_outlook_uri,
            // }
            */
            return default;
        }

        public async Task<TEntity> PrepareEmailMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object smtp_session) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _prepare_email_message(self, message, smtp_session):
            // """Prepare the SMTP information (from, to, message) before sending.
            // 
            // :param message: the email.message.Message to send, information like the
            //     Return-Path, the From, etc... will be used to find the smtp_from and to smtp_to
            // :param smtp_session: the opened SMTP session to use to authenticate the sender
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
            // email_to = message['To']
            // email_cc = message['Cc']
            // email_bcc = message['Bcc']
            // del message['Bcc']
            // 
            // # All recipient addresses must only contain ASCII characters; support
            // # optional pre-validated To list, used notably when formatted emails may
            // # create fake emails using extract_rfc2822_addresses, e.g.
            // # '"Bike@Home" <email@domain.com>' which can be considered as containing
            // # 2 emails by extract_rfc2822_addresses
            // validated_to = self.env.context.get('send_validated_to') or []
            // smtp_to_list = [
            //     address
            //     for base in [email_to, email_cc, email_bcc]
            //     # be sure a given address does not return duplicates (but duplicates
            //     # in final smtp to list is still ok)
            //     for address in tools.misc.unique(extract_rfc2822_addresses(base))
            //     if address and (not validated_to or address in validated_to)
            // ]
            // assert smtp_to_list, self.NO_VALID_RECIPIENT
            // 
            // x_forge_to = message['X-Forge-To']
            // if x_forge_to:
            //     # `To:` header forged, e.g. for posting on discuss.channels, to avoid confusion
            //     del message['X-Forge-To']
            //     del message['To']           # avoid multiple To: headers!
            //     message['To'] = x_forge_to
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
            // if message['From'] != smtp_from:
            //     del message['From']
            //     message['From'] = smtp_from
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

        public async Task<TEntity> SendEmailAsync<TEntity>(IEnumerable<TEntity> entities, object message, Guid mail_server_id, object smtp_server, object smtp_port, object smtp_user, object smtp_password, object smtp_encryption, object smtp_ssl_certificate, object smtp_ssl_private_key, object smtp_debug, object smtp_session) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
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
            // :param smtp_encryption: optional TLS mode, one of 'none', 'starttls' or 'ssl' (see ir.mail_server fields for explanation)
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
            //     smtp = self.connect(
            //         smtp_server, smtp_port, smtp_user, smtp_password, smtp_encryption,
            //         smtp_from=message['From'], ssl_certificate=smtp_ssl_certificate, ssl_private_key=smtp_ssl_private_key,
            //         smtp_debug=smtp_debug, mail_server_id=mail_server_id,)
            // 
            // smtp_from, smtp_to_list, message = self._prepare_email_message(message, smtp)
            // 
            // # Do not actually send emails in testing mode!
            // if modules.module.current_test:
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

        public async Task<TEntity> SetDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def set_draft(self):
            // self.write({'state': 'draft'})
            // return True
            */
            return default;
        }

        public async Task<TEntity> SmtpLoginInternalAsync<TEntity>(IEnumerable<TEntity> entities, object connection, object smtp_user, object smtp_password) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py) ---
            // def _smtp_login(self, connection, smtp_user, smtp_password):
            // if len(self) == 1 and self.smtp_authentication == 'outlook':
            //     auth_string = self._generate_outlook_oauth2_string(smtp_user)
            //     oauth_param = base64.b64encode(auth_string.encode()).decode()
            //     connection.ehlo()
            //     connection.docmd('AUTH', f'XOAUTH2 {oauth_param}')
            // else:
            //     super()._smtp_login(connection, smtp_user, smtp_password)
            */
            return default;
        }

        public async Task<TEntity> TestSmtpConnectionAsync<TEntity>(IEnumerable<TEntity> entities, object autodetect_max_email_size) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def test_smtp_connection(self, autodetect_max_email_size=False):
            // """Test the connection and if autodetect_max_email_size, set auto-detected max email size.
            // 
            // :param bool autodetect_max_email_size: whether to autodetect the max email size
            // :return (dict): client action to notify the user of the result of the operation (connection test or
            // auto-detection successful depending on the autodetect_max_email_size parameter)
            // 
            // :raises UserError: if the connection fails and if autodetect_max_email_size and
            //     the server doesn't support the auto-detection of email max size
            // """
            // for server in self:
            //     smtp = False
            //     try:
            //         smtp = self.connect(mail_server_id=server.id, allow_archived=True)
            //         # simulate sending an email from current user's address - without sending it!
            //         email_from = server._get_test_email_from()
            //         email_to = server._get_test_email_to()
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

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def unlink(self):
            // res = super(FetchmailServer, self).unlink()
            // self._update_cron()
            // return res
            */
            return default;
        }

        public async Task<TEntity> UpdateCronInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def _update_cron(self):
            // if self.env.context.get('fetchmail_cron_running'):
            //     return
            // try:
            //     # Enabled/Disable cron based on the number of 'done' server of type pop or imap
            //     cron = self.env.ref('mail.ir_cron_mail_gateway_action')
            //     cron.toggle(model=self._name, domain=[('state', '=', 'done'), ('server_type', '!=', 'local')])
            // except ValueError:
            //     pass
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMicrosoftOutlookMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def write(self, values):
            // res = super(FetchmailServer, self).write(values)
            // self._update_cron()
            // return res
            */
            return default;
        }
    }
}