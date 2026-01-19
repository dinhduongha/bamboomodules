using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("BaseModule", Category = "Base")]
    public partial class IrMailServerAppService : GenericApplicationService<IrMailServer>, IIrMailServerAppService
    {
        private readonly IGoogleGmailMixinAppService _googleGmailMixinAppService;
        private readonly IMicrosoftOutlookMixinAppService _microsoftOutlookMixinAppService;
        public IrMailServerAppService(IRepository<IrMailServer, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IGoogleGmailMixinAppService googleGmailMixinAppService, IMicrosoftOutlookMixinAppService microsoftOutlookMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _googleGmailMixinAppService = googleGmailMixinAppService;
            _microsoftOutlookMixinAppService = microsoftOutlookMixinAppService;
        }

        protected async Task<IrMailServer> ActiveUsagesComputeInternalAsync()
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

        protected async Task<IrMailServer> AlterMessageInternalAsync(object message, object smtp_from, object smtp_to_list)
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

        protected async Task<IrMailServer> BuildEmailInternalAsync(object email_from, object email_to, object subject, object body, object email_cc, object email_bcc, object reply_to, object attachments, Guid message_id, object references, Guid object_id, object subtype, object headers, object body_alternative, object subtype_alternative)
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

        protected async Task<IrMailServer> CheckForcedMailServerInternalAsync(object mail_server, object allow_archived, object smtp_from)
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

        protected async Task<IrMailServer> CheckSmtpSslFilesInternalAsync()
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

        protected async Task<IrMailServer> CheckUseGoogleGmailServiceInternalAsync()
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

        protected async Task<IrMailServer> CheckUseMicrosoftOutlookServiceInternalAsync()
        {
            /*
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

        protected async Task<IrMailServer> ComputeSmtpAuthenticationInfoInternalAsync()
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
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py) ---
            // def _compute_smtp_authentication_info(self):
            // outlook_servers = self.filtered(lambda server: server.smtp_authentication == 'outlook')
            // outlook_servers.smtp_authentication_info = _(
            //     'Connect your Outlook account with the OAuth Authentication process.  \n'
            //     'By default, only a user with a matching email address will be able to use this server. '
            //     'To extend its use, you should set a "mail.default.from" system parameter.')
            // super(IrMail_Server, self - outlook_servers)._compute_smtp_authentication_info()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _compute_smtp_authentication_info(self):
            // for server in self:
            //     if server.smtp_authentication == 'login':
            //         server.smtp_authentication_info = _(
            //             'Connect to your server through your usual username and password. \n'
            //             'This is the most basic SMTP authentication process and '
            //             'may not be accepted by all providers. \n')
            //     elif server.smtp_authentication == 'certificate':
            //         server.smtp_authentication_info = _(
            //             'Authenticate by using SSL certificates, belonging to your domain name. \n'
            //             'SSL certificates allow you to authenticate your mail server for the entire domain name.')
            //     elif server.smtp_authentication == 'cli':
            //         server.smtp_authentication_info = _(
            //             'Use the SMTP configuration set in the "Command Line Interface" arguments.')
            //     else:
            //         server.smtp_authentication = False
            */
            return default;
        }

        protected async Task<IrMailServer> ConnectInternalAsync(object host, object port, object user, object password, object encryption, object smtp_from, object ssl_certificate, object ssl_private_key, object smtp_debug, Guid mail_server_id, object allow_archived)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _connect__(self, host=None, port=None, user=None, password=None, encryption=None,  # noqa: PLW3201
            //         smtp_from=None, ssl_certificate=None, ssl_private_key=None, smtp_debug=False, mail_server_id=None,
            //         allow_archived=False):
            // """Returns a new SMTP connection to the given SMTP server.
            //    When running in test mode, this method does nothing and returns `None`.
            // 
            //    :param host: host or IP of SMTP server to connect to, if mail_server_id not passed
            //    :param int port: SMTP port to connect to
            //    :param user: optional username to authenticate with
            //    :param password: optional password to authenticate with
            //    :param str encryption: optional, ``'none'`` | ``'ssl'`` | ``'ssl_strict'`` | ``'starttls'`` | ``'starttls_strict'``.
            //        The 'strict' variants verify the remote server's certificate against the operating system trust store.
            //    :param smtp_from: FROM SMTP envelop, used to find the best mail server
            //    :param ssl_certificate: filename of the SSL certificate used for authentication
            //        Used when no mail server is given and overwrite  the odoo-bin argument "smtp_ssl_certificate"
            //    :param ssl_private_key: filename of the SSL private key used for authentication
            //        Used when no mail server is given and overwrite  the odoo-bin argument "smtp_ssl_private_key"
            //    :param bool smtp_debug: toggle debugging of SMTP sessions (all i/o
            //                       will be output in logs)
            //    :param mail_server_id: ID of specific mail server to use (overrides other parameters)
            //    :param bool allow_archived: by default (False), an exception is raised when calling this method on an
            //        archived record (using mail_server_id param). It can be set to True for testing so that the exception is
            //        no longer raised.
            // """
            // # Do not actually connect while running in test mode
            // if self._disable_send():
            //     return None
            // mail_server = smtp_encryption = None
            // if mail_server_id:
            //     mail_server = self.sudo().browse(mail_server_id)
            //     self._check_forced_mail_server(mail_server, allow_archived, smtp_from)
            // 
            // elif not host:
            //     mail_server, smtp_from = self.sudo()._find_mail_server(smtp_from)
            // 
            // if not mail_server:
            //     mail_server = self.env['ir.mail_server']
            // ssl_context = None
            // 
            // if mail_server and mail_server.smtp_authentication != "cli":
            //     smtp_server = mail_server.smtp_host
            //     smtp_port = mail_server.smtp_port
            //     if mail_server.smtp_authentication == "certificate":
            //         smtp_user = None
            //         smtp_password = None
            //     else:
            //         smtp_user = mail_server.smtp_user
            //         smtp_password = mail_server.smtp_pass
            //     smtp_encryption = mail_server.smtp_encryption
            //     smtp_debug = smtp_debug or mail_server.smtp_debug
            //     from_filter = mail_server.from_filter
            // 
            //     if mail_server.smtp_authentication == "certificate":
            //         try:
            //             ssl_context = PyOpenSSLContext(ssl.PROTOCOL_TLS)
            //             if mail_server.smtp_encryption in ('ssl_strict', 'starttls_strict'):
            //                 ssl_context.set_default_verify_paths()
            //                 ssl_context._ctx.set_verify(
            //                     VERIFY_PEER | VERIFY_FAIL_IF_NO_PEER_CERT,
            //                     functools.partial(_verify_check_hostname_callback, hostname=smtp_server)
            //                 )
            //             else:  # ssl, starttls
            //                 ssl_context.verify_mode = ssl.CERT_NONE
            //             ssl_context._ctx.use_certificate(load_pem_x509_certificate(
            //                 base64.b64decode(mail_server.smtp_ssl_certificate)))
            //             ssl_context._ctx.use_privatekey(load_pem_private_key(
            //                 base64.b64decode(mail_server.smtp_ssl_private_key),
            //                 password=None))
            //             # Check that the private key match the certificate
            //             ssl_context._ctx.check_privatekey()
            //         except SSLCryptoError as e:
            //             raise UserError(_('The private key or the certificate is not a valid file. \n%s', str(e)))
            //         except SSLError as e:
            //             raise UserError(_('Could not load your certificate / private key. \n%s', str(e)))
            //     elif mail_server.smtp_encryption != 'none':
            //         if mail_server.smtp_encryption in ('ssl_strict', 'starttls_strict'):
            //             ssl_context = ssl.create_default_context()
            //             ssl_context.check_hostname = True
            //             ssl_context.verify_mode = ssl.CERT_REQUIRED
            //         else:  # ssl, starttls
            //             ssl_context = ssl.create_default_context()
            //             ssl_context.check_hostname = False
            //             ssl_context.verify_mode = ssl.CERT_NONE
            // 
            // else:
            //     # we were passed individual smtp parameters or nothing and there is no default server
            //     smtp_server = host or tools.config.get('smtp_server')
            //     smtp_port = tools.config.get('smtp_port', 25) if port is None else port
            //     smtp_user = user or tools.config.get('smtp_user')
            //     smtp_password = password or tools.config.get('smtp_password')
            //     if mail_server:
            //         from_filter = mail_server.from_filter
            //     else:
            //         from_filter = self.env['ir.mail_server']._get_default_from_filter()
            // 
            //     smtp_encryption = encryption
            //     if smtp_encryption is None and tools.config.get('smtp_ssl'):
            //         smtp_encryption = 'starttls' # smtp_ssl => STARTTLS as of v7
            //     smtp_ssl_certificate_filename = ssl_certificate or tools.config.get('smtp_ssl_certificate_filename')
            //     smtp_ssl_private_key_filename = ssl_private_key or tools.config.get('smtp_ssl_private_key_filename')
            // 
            //     if smtp_ssl_certificate_filename and smtp_ssl_private_key_filename:
            //         try:
            //             ssl_context = PyOpenSSLContext(ssl.PROTOCOL_TLS)
            //             ssl_context.verify_mode = ssl.CERT_NONE
            //             ssl_context.load_cert_chain(smtp_ssl_certificate_filename, keyfile=smtp_ssl_private_key_filename)
            //             # Check that the private key match the certificate
            //             ssl_context._ctx.check_privatekey()
            //         except SSLCryptoError as e:
            //             raise UserError(_('The private key or the certificate is not a valid file. \n%s', str(e)))
            //         except SSLError as e:
            //             raise UserError(_('Could not load your certificate / private key. \n%s', str(e)))
            // 
            // if not smtp_server:
            //     raise UserError(_(
            //         "Missing SMTP Server\n"
            //         "Please define at least one SMTP server, "
            //         "or provide the SMTP parameters explicitly.",
            //     ))
            // 
            // if smtp_encryption in ('ssl', 'ssl_strict'):
            //     connection = smtplib.SMTP_SSL(smtp_server, smtp_port, timeout=SMTP_TIMEOUT, context=ssl_context)
            // else:
            //     connection = smtplib.SMTP(smtp_server, smtp_port, timeout=SMTP_TIMEOUT)
            // connection.set_debuglevel(smtp_debug)
            // if smtp_encryption in ('starttls', 'starttls_strict'):
            //     # starttls() will perform ehlo() if needed first
            //     # and will discard the previous list of services
            //     # after successfully performing STARTTLS command,
            //     # (as per RFC 3207) so for example any AUTH
            //     # capability that appears only on encrypted channels
            //     # will be correctly detected for next step
            //     connection.starttls(context=ssl_context)
            // 
            // if smtp_user:
            //     # Attempt authentication - will raise if AUTH service not supported
            //     local, at, domain = smtp_user.rpartition('@')
            //     if at:
            //         smtp_user = local + at + idna.encode(domain).decode('ascii')
            //     mail_server._smtp_login__(connection, smtp_user, smtp_password or '')
            // 
            // # Some methods of SMTP don't check whether EHLO/HELO was sent.
            // # Anyway, as it may have been sent by login(), all subsequent usages should consider this command as sent.
            // connection.ehlo_or_helo_if_needed()
            // 
            // # Store the "from_filter" of the mail server / odoo-bin argument to  know if we
            // # need to change the FROM headers or not when we will prepare the mail message
            // connection.from_filter = from_filter
            // connection.smtp_from = smtp_from
            // 
            // return connection
            */
            return default;
        }

        protected async Task<IrMailServer> DisableSendInternalAsync()
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

        protected async Task<IrMailServer> FilterMailServersFallbackInternalAsync(object servers)
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

        protected async Task<IrMailServer> FindMailServerAllowedDomainInternalAsync()
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

        protected async Task<IrMailServer> FindMailServerInternalAsync(object email_from, object mail_servers)
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

        protected async Task<IrMailServer> GetDefaultBounceAddressInternalAsync()
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

        protected async Task<IrMailServer> GetDefaultFromAddressInternalAsync()
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

        protected async Task<IrMailServer> GetDefaultFromFilterInternalAsync()
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

        protected async Task<IrMailServer> GetMaxEmailSizeInternalAsync()
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

        protected async Task<IrMailServer> GetPersonalMailServersLimitInternalAsync()
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

        protected async Task<IrMailServer> GetTestEmailFromInternalAsync()
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

        protected async Task<IrMailServer> GetTestEmailToInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _get_test_email_to(self):
            // return "noreply@odoo.com"
            */
            return default;
        }

        protected async Task<IrMailServer> MatchFromFilterInternalAsync(object email_from, object from_filter)
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

        protected async Task<IrMailServer> OnChangeSmtpUserGmailInternalAsync()
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

        protected async Task<IrMailServer> OnChangeSmtpUserOutlookInternalAsync()
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

        protected async Task<IrMailServer> OnchangeEncryptionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: ir_mail_server.py) ---
            // def _onchange_encryption(self):
            // """Do not change the SMTP configuration if it's a Gmail server
            // (e.g. the port which is already set)"""
            // if self.smtp_authentication != 'gmail':
            //     super()._onchange_encryption()
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py) ---
            // def _onchange_encryption(self):
            // """Do not change the SMTP configuration if it's a Outlook server
            // 
            // (e.g. the port which is already set)"""
            // if self.smtp_authentication != 'outlook':
            //     super()._onchange_encryption()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _onchange_encryption(self):
            // result = {}
            // if self.smtp_encryption == 'ssl':
            //     self.smtp_port = 465
            //     if not 'SMTP_SSL' in smtplib.__all__:
            //         result['warning'] = {
            //             'title': _('Warning'),
            //             'message': _('Your server does not seem to support SSL, you may want to try STARTTLS instead'),
            //         }
            // else:
            //     self.smtp_port = 25
            // return result
            */
            return default;
        }

        protected async Task<IrMailServer> OnchangeSmtpAuthenticationGmailInternalAsync()
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

        protected async Task<IrMailServer> OnchangeSmtpAuthenticationOutlookInternalAsync()
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

        protected async Task<IrMailServer> ParseFromFilterInternalAsync(object from_filter)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _parse_from_filter(self, from_filter):
            // return [part.strip() for part in (from_filter or '').split(',') if part.strip()]
            */
            return default;
        }

        protected async Task<IrMailServer> PrepareEmailMessageInternalAsync(object message, object smtp_session)
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

        protected async Task<IrMailServer> PrepareSmtpToListInternalAsync(object message, object smtp_session)
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

        public async Task<IrMailServer> RetrieveMaxEmailSizeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def action_retrieve_max_email_size(self):
            // self.ensure_one()
            // return self.test_smtp_connection(autodetect_max_email_size=True)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrMailServer> SendEmailAsync(Guid id, IrMailServerSendEmailRequestDto input)
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrMailServer> SmtpLoginInternalAsync(object connection, object smtp_user, object smtp_password)
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
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: ir_mail_server.py) ---
            // def _smtp_login__(self, connection, smtp_user, smtp_password):  # noqa: PLW3201
            // if len(self) == 1 and self.smtp_authentication == 'outlook':
            //     auth_string = self._generate_outlook_oauth2_string(smtp_user)
            //     oauth_param = base64.b64encode(auth_string.encode()).decode()
            //     connection.ehlo()
            //     connection.docmd('AUTH', f'XOAUTH2 {oauth_param}')
            // else:
            //     super()._smtp_login__(connection, smtp_user, smtp_password)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_mail_server.py) ---
            // def _smtp_login__(self, connection, smtp_user, smtp_password):  # noqa: PLW3201
            // """Authenticate the SMTP connection.
            // 
            // Can be overridden in other module for different authentication methods.Can be
            // called on the model itself or on a singleton.
            // 
            // :param connection: The SMTP connection to authenticate
            // :param smtp_user: The user to used for the authentication
            // :param smtp_password: The password to used for the authentication
            // """
            // connection.login(smtp_user, smtp_password)
            */
            return default;
        }

        public async Task<IrMailServer> TestSmtpConnectionAsync(Guid id, IrMailServerTestSmtpConnectionRequestDto input)
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
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}