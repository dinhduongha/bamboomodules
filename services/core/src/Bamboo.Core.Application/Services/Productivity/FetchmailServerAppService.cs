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
    [Module("Mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public class FetchmailServerAppService : GenericApplicationService<FetchmailServer>, IFetchmailServerAppService
    {
        private readonly IGoogleGmailMixinAppService _googleGmailMixinAppService;
        private readonly IMicrosoftOutlookMixinAppService _microsoftOutlookMixinAppService;
        public FetchmailServerAppService(IRepository<FetchmailServer, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IGoogleGmailMixinAppService googleGmailMixinAppService, IMicrosoftOutlookMixinAppService microsoftOutlookMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _googleGmailMixinAppService = googleGmailMixinAppService;
            _microsoftOutlookMixinAppService = microsoftOutlookMixinAppService;
        }

        public async Task<FetchmailServer> ButtonConfirmLoginAsync(Guid id)
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<FetchmailServer> CheckUseMicrosoftOutlookServiceInternalAsync()
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

        protected async Task<FetchmailServer> ComputeIsMicrosoftOutlookConfiguredInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: fetchmail_server.py) ---
            // def _compute_is_microsoft_outlook_configured(self):
            // outlook_servers = self.filtered(lambda server: server.server_type == 'outlook')
            // (self - outlook_servers).is_microsoft_outlook_configured = False
            // super(FetchmailServer, outlook_servers)._compute_is_microsoft_outlook_configured()
            */
            return default;
        }

        protected async Task<FetchmailServer> ComputeServerTypeInfoInternalAsync()
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
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def _compute_server_type_info(self):
            // for server in self:
            //     if server.server_type == 'local':
            //         server.server_type_info = _('Use a local script to fetch your emails and create new records.')
            //     else:
            //         server.server_type_info = False
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

        public async Task<FetchmailServer> ConnectAsync(Guid id, FetchmailServerConnectRequestDto input)
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<FetchmailServer> FetchMailAsync(Guid id, FetchmailServerFetchMailRequestDto input)
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<FetchmailServer> FetchMailsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def _fetch_mails(self):
            // """ Method called by cron to fetch mails from servers """
            // return self.search([('state', '=', 'done'), ('server_type', '!=', 'local')]).fetch_mail(raise_exception=False)
            */
            return default;
        }

        protected async Task<FetchmailServer> GetConnectionTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: fetchmail_server.py) ---
            // def _get_connection_type(self):
            // """Return which connection must be used for this mail server (IMAP or POP).
            // The Gmail mail server used an IMAP connection.
            // """
            // self.ensure_one()
            // return 'imap' if self.server_type == 'gmail' else super()._get_connection_type()
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def _get_connection_type(self):
            // """Return which connection must be used for this mail server (IMAP or POP).
            // Can be overridden in sub-module to define which connection to use for a specific
            // "server_type" (e.g. Gmail server).
            // """
            // self.ensure_one()
            // return self.server_type
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

        protected async Task<FetchmailServer> ImapLoginInternalAsync(object connection)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: fetchmail_server.py) ---
            // def _imap_login(self, connection):
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
            //     super(FetchmailServer, self)._imap_login(connection)
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def _imap_login(self, connection):
            // """Authenticate the IMAP connection.
            // 
            // Can be overridden in other module for different authentication methods.
            // 
            // :param connection: The IMAP connection to authenticate
            // """
            // self.ensure_one()
            // connection.login(self.user, self.password)
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

        public async Task<FetchmailServer> OnchangeServerTypeAsync(Guid id)
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
            //     self.google_gmail_authorization_code = False
            //     self.google_gmail_refresh_token = False
            //     self.google_gmail_access_token = False
            //     self.google_gmail_access_token_expiration = False
            //     super(FetchmailServer, self).onchange_server_type()
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def onchange_server_type(self):
            //         self.port = 0
            //         if self.server_type == 'pop':
            //             self.port = self.is_ssl and 995 or 110
            //         elif self.server_type == 'imap':
            //             self.port = self.is_ssl and 993 or 143
            // 
            //         conf = {
            //             'dbname': self.env.cr.dbname,
            //             'uid': self.env.uid,
            //             'model': self.object_id.model if self.object_id else 'MODELNAME'
            //         }
            //         self.configuration = """Use the below script with the following command line options with your Mail Transport Agent (MTA)
            // odoo-mailgate.py --host=HOSTNAME --port=PORT -u %(uid)d -p PASSWORD -d %(dbname)s
            // Example configuration for the postfix mta running locally:
            // /etc/postfix/virtual_aliases: @youdomain odoo_mailgate@localhost
            // /etc/aliases:
            // odoo_mailgate: "|/path/to/odoo-mailgate.py --host=localhost -u %(uid)d -p PASSWORD -d %(dbname)s"
            //         """ % conf
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<FetchmailServer> SetDraftAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def set_draft(self):
            // self.write({'state': 'draft'})
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<FetchmailServer> UpdateCronInternalAsync()
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
    }
}