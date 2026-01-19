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
    public partial class FetchmailServerAppService : GenericApplicationService<FetchmailServer>, IFetchmailServerAppService
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<FetchmailServer> CheckUseGoogleGmailServiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: google_gmail, FILE: fetchmail_server.py) ---
            // def _check_use_google_gmail_service(self):
            // for server in self:
            //     if server.server_type == 'gmail' and not server.is_ssl:
            //         raise UserError(_('SSL is required for server “%s”.', server.name))
            */
            return default;
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

        protected async Task<FetchmailServer> ConnectInternalAsync(object allow_archived)
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

        public async Task<FetchmailServer> FetchMailAsync(Guid id)
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<FetchmailServer> FetchMailInternalAsync(object batch_limit)
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

        protected async Task<FetchmailServer> FetchMailsInternalAsync()
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
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: fetchmail.py) ---
            // def _imap_login__(self, connection):  # noqa: PLW3201
            // """Authenticate the IMAP connection.
            // 
            // Can be overridden in other module for different authentication methods.
            // 
            // :param connection: The IMAP connection to authenticate
            // """
            // self.ensure_one()
            // connection.login(self.user, self.password)
            --- ODOO METHOD SOURCE (MODULE: microsoft_outlook, FILE: fetchmail_server.py) ---
            // def _imap_login__(self, connection):  # noqa: PLW3201
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
            //     super()._imap_login__(connection)
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
            //     self.google_gmail_refresh_token = False
            //     self.google_gmail_access_token = False
            //     self.google_gmail_access_token_expiration = False
            //     super().onchange_server_type()
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
            //     super().onchange_server_type()
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
            //     cron.toggle(model=self._name, domain=MAIL_SERVER_DOMAIN)
            // except ValueError:
            //     pass
            */
            return default;
        }
    }
}