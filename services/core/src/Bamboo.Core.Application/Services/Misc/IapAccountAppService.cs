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
    [Module("Iap", Category = "Misc", Depends = new[] { "web", "base_setup" })]
    public class IapAccountAppService : GenericApplicationService<IapAccount>, IIapAccountAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        public IapAccountAppService(IRepository<IapAccount, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<IapAccount> BuyCreditsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: iap, FILE: iap_account.py) ---
            // def action_buy_credits(self):
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': self.env['iap.account'].get_credits_url(
            //         account_token=self.account_token,
            //         service_name=self.service_name,
            //     ),
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IapAccount> GetAccountIdAsync(Guid id, IapAccountGetAccountIdRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: iap, FILE: iap_account.py) ---
            // def get_account_id(self, service_name):
            // return self.get(service_name).id
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IapAccount> GetAccountInfoInternalAsync(Guid account_id, object balance, object information)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: iap, FILE: iap_account.py) ---
            // def _get_account_info(self, account_id, balance, information):
            // return {
            //     'balance': balance,
            //     'warning_threshold': information['warning_threshold'],
            //     'state': information['registered'],
            //     'service_locked': True,  # The account exist on IAP, prevent the edition of the service
            // }
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: iap_account.py) ---
            // def _get_account_info(self, account_id, balance, information):
            // res = super()._get_account_info(account_id, balance, information)
            // if account_id.service_name == 'sms':
            //     res['sender_name'] = information.get('sender_name')
            // return res
            */
            return default;
        }

        protected async Task<IapAccount> GetAccountInformationFromIapInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: iap, FILE: iap_account.py) ---
            // def _get_account_information_from_iap(self):
            // # During testing, we don't want to call the iap server
            // if self.is_running_test_suite():
            //     return
            // route = '/iap/1/get-accounts-information'
            // endpoint = iap_tools.iap_get_endpoint(self.env)
            // url = werkzeug.urls.url_join(endpoint, route)
            // params = {
            //     'iap_accounts': [{
            //         'token': account.account_token,
            //         'service': account.service_id.technical_name,
            //     } for account in self if account.service_id],
            //     'dbuuid': self.env['ir.config_parameter'].sudo().get_param('database.uuid'),
            // }
            // try:
            //     accounts_information = iap_tools.iap_jsonrpc(url=url, params=params)
            // except AccessError as e:
            //     _logger.warning("Fetch of the IAP accounts information has failed: %s", str(e))
            //     return
            // 
            // for token, information in accounts_information.items():
            //     information.pop('link_to_service_page', None)
            //     accounts = self.filtered(lambda acc: secrets.compare_digest(acc.account_token, token))
            // 
            //     for account in accounts:
            //         # Default rounding of 4 decimal places to avoid large decimals
            //         balance_amount = round(information['balance'], None if account.service_id.integer_balance else 4)
            //         balance = f"{balance_amount} {account.service_id.unit_name or ''}"
            // 
            //         account_info = self._get_account_info(account, balance, information)
            //         account.with_context(disable_iap_update=True, tracking_disable=True).write(account_info)
            */
            return default;
        }

        public async Task<IapAccount> GetAsync(Guid id, IapAccountGetRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: iap, FILE: iap_account.py) ---
            // def get(self, service_name, force_create=True):
            // domain = [
            //     ('service_name', '=', service_name),
            //     '|',
            //         ('company_ids', 'in', self.env.companies.ids),
            //         ('company_ids', '=', False)
            // ]
            // accounts = self.search(domain, order='id desc')
            // accounts_without_token = accounts.filtered(lambda acc: not acc.account_token)
            // if accounts_without_token:
            //     with self.pool.cursor() as cr:
            //         # In case of a further error that will rollback the database, we should
            //         # use a different SQL cursor to avoid undo the accounts deletion.
            // 
            //         # Flush the pending operations to avoid a deadlock.
            //         self.env.flush_all()
            //         IapAccount = self.with_env(self.env(cr=cr))
            //         # Need to use sudo because regular users do not have delete right
            //         IapAccount.search(domain + [('account_token', '=', False)]).sudo().unlink()
            //         accounts = accounts - accounts_without_token
            // if not accounts:
            //     service = self.env['iap.service'].search([('technical_name', '=', service_name)], limit=1)
            //     if not service:
            //         raise UserError("No service exists with the provided technical name")
            //     if self.is_running_test_suite():
            //         # During testing, we don't want to commit the creation of a new IAP account to the database
            //         return self.sudo().create({'service_id': service.id})
            // 
            //     with self.pool.cursor() as cr:
            //         # Since the account did not exist yet, we will encounter a NoCreditError,
            //         # which is going to rollback the database and undo the account creation,
            //         # preventing the process to continue any further.
            // 
            //         # Flush the pending operations to avoid a deadlock.
            //         self.env.flush_all()
            //         IapAccount = self.with_env(self.env(cr=cr))
            //         account = IapAccount.search(domain, order='id desc', limit=1)
            //         if not account:
            //             if not force_create:
            //                 return account
            //             account = IapAccount.create({'service_id': service.id})
            //         # fetch 'account_token' into cache with this cursor,
            //         # as self's cursor cannot see this account
            //         account_token = account.account_token
            //     account = self.browse(account.id)
            //     self.env.cache.set(account, IapAccount._fields['account_token'], account_token)
            //     return account
            // accounts_with_company = accounts.filtered(lambda acc: acc.company_ids)
            // if accounts_with_company:
            //     return accounts_with_company[0]
            // return accounts[0]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IapAccount> GetConfigAccountUrlAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: iap, FILE: iap_account.py) ---
            // def get_config_account_url(self):
            // """ Called notably by ajax partner_autocomplete. """
            // account = self.env['iap.account'].get('partner_autocomplete')
            // menu = self.env.ref('iap.iap_account_menu')
            // if not self.env.user.has_group('base.group_no_one'):
            //     return False
            // if account:
            //     url = f"/odoo/action-iap.iap_account_action/{account.id}?menu_id={menu.id}"
            // else:
            //     url = f"/odoo/action-iap.iap_account_action?menu_id={menu.id}"
            // return url
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IapAccount> GetCreditsAsync(Guid id, IapAccountGetCreditsRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: iap, FILE: iap_account.py) ---
            // def get_credits(self, service_name):
            // account = self.get(service_name, force_create=False)
            // credit = 0
            // 
            // if account:
            //     route = '/iap/1/balance'
            //     endpoint = iap_tools.iap_get_endpoint(self.env)
            //     url = werkzeug.urls.url_join(endpoint, route)
            //     params = {
            //         'dbuuid': self.env['ir.config_parameter'].sudo().get_param('database.uuid'),
            //         'account_token': account.account_token,
            //         'service_name': service_name,
            //     }
            //     try:
            //         credit = iap_tools.iap_jsonrpc(url=url, params=params)
            //     except AccessError as e:
            //         _logger.info('Get credit error : %s', str(e))
            //         credit = -1
            // 
            // return credit
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IapAccount> GetCreditsUrlAsync(Guid id, IapAccountGetCreditsUrlRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: iap, FILE: iap_account.py) ---
            // def get_credits_url(self, service_name, base_url='', credit=0, trial=False, account_token=False):
            // """ Called notably by ajax crash manager, buy more widget, partner_autocomplete, sanilmail. """
            // dbuuid = self.env['ir.config_parameter'].sudo().get_param('database.uuid')
            // if not base_url:
            //     endpoint = iap_tools.iap_get_endpoint(self.env)
            //     route = '/iap/1/credit'
            //     base_url = werkzeug.urls.url_join(endpoint, route)
            // if not account_token:
            //     account_token = self.get(service_name).account_token
            // d = {
            //     'dbuuid': dbuuid,
            //     'service_name': service_name,
            //     'account_token': account_token,
            //     'credit': credit,
            // }
            // if trial:
            //     d.update({'trial': trial})
            // return '%s?%s' % (base_url, werkzeug.urls.url_encode(d))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IapAccount> IsRunningTestSuiteAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: iap, FILE: iap_account.py) ---
            // def is_running_test_suite():
            // return hasattr(threading.current_thread(), 'testing') and threading.current_thread().testing
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IapAccount> OpenRegistrationWizardAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: iap_account.py) ---
            // def action_open_registration_wizard(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'target': 'new',
            //     'name': _('Register Account'),
            //     'view_mode': 'form',
            //     'res_model': 'sms.account.phone',
            //     'context': {'default_account_id': self.id},
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IapAccount> OpenSenderNameWizardAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: iap_account.py) ---
            // def action_open_sender_name_wizard(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'target': 'new',
            //     'name': _('Choose your sender name'),
            //     'view_mode': 'form',
            //     'res_model': 'sms.account.sender',
            //     'context': {'default_account_id': self.id},
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IapAccount> SendErrorNotificationInternalAsync(object message, object title)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: iap_mail, FILE: iap_account.py) ---
            // def _send_error_notification(self, message, title=None):
            // self._send_status_notification(message, 'danger', title=title)
            */
            return default;
        }

        protected async Task<IapAccount> SendNoCreditNotificationInternalAsync(object service_name, object title)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: iap_mail, FILE: iap_account.py) ---
            // def _send_no_credit_notification(self, service_name, title):
            // params = {
            //     'title': title,
            //     'type': 'no_credit',
            //     'get_credits_url': self.env['iap.account'].get_credits_url(service_name),
            // }
            // self.env.user._bus_send("iap_notification", params)
            */
            return default;
        }

        protected async Task<IapAccount> SendStatusNotificationInternalAsync(object message, object status, object title)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: iap_mail, FILE: iap_account.py) ---
            // def _send_status_notification(self, message, status, title=None):
            // params = {
            //     'message': message,
            //     'type': status,
            // }
            // if title is not None:
            //     params['title'] = title
            // self.env.user._bus_send("iap_notification", params)
            */
            return default;
        }

        protected async Task<IapAccount> SendSuccessNotificationInternalAsync(object message, object title)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: iap_mail, FILE: iap_account.py) ---
            // def _send_success_notification(self, message, title=None):
            // self._send_status_notification(message, 'success', title=title)
            */
            return default;
        }

        public async Task<IapAccount> ValidateWarningAlertsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: iap, FILE: iap_account.py) ---
            // def validate_warning_alerts(self):
            // for account in self:
            //     if account.warning_threshold < 0:
            //         raise UserError(_("Please set a positive email alert threshold."))
            //     users_with_no_email = [user.name for user in self.warning_user_ids if not user.email]
            //     if users_with_no_email:
            //         raise UserError(_(
            //             "One of the email alert recipients doesn't have an email address set. Users: %s",
            //             ",".join(users_with_no_email),
            //         ))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IapAccount> WebReadAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: iap, FILE: iap_account.py) ---
            // def web_read(self, *args, **kwargs):
            // if not self.env.context.get('disable_iap_fetch'):
            //     self._get_account_information_from_iap()
            // return super().web_read(*args, **kwargs)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IapAccount> WebSaveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: iap, FILE: iap_account.py) ---
            // def web_save(self, *args, **kwargs):
            // return super(IapAccount, self.with_context(disable_iap_fetch=True)).web_save(*args, **kwargs)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}