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
    public class PublisherWarrantyContractAppService : GenericApplicationService<PublisherWarrantyContract>, IPublisherWarrantyContractAppService
    {

        public PublisherWarrantyContractAppService(IRepository<PublisherWarrantyContract, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<PublisherWarrantyContract> GetMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: update.py) ---
            // def _get_message(self):
            // Users = self.env['res.users']
            // IrParamSudo = self.env['ir.config_parameter'].sudo()
            // 
            // dbuuid = IrParamSudo.get_param('database.uuid')
            // db_create_date = IrParamSudo.get_param('database.create_date')
            // limit_date = fields.Datetime.now() - datetime.timedelta(15)
            // nbr_users = Users.search_count([('active', '=', True)])
            // nbr_active_users = Users.search_count([("login_date", ">=", limit_date), ('active', '=', True)])
            // nbr_share_users = 0
            // nbr_active_share_users = 0
            // if "share" in Users._fields:
            //     nbr_share_users = Users.search_count([("share", "=", True), ('active', '=', True)])
            //     nbr_active_share_users = Users.search_count([("share", "=", True), ("login_date", ">=", limit_date), ('active', '=', True)])
            // user = self.env.user
            // domain = [('application', '=', True), ('state', 'in', ['installed', 'to upgrade', 'to remove'])]
            // apps = self.env['ir.module.module'].sudo().search_read(domain, ['name'])
            // 
            // enterprise_code = IrParamSudo.get_param('database.enterprise_code')
            // 
            // web_base_url = IrParamSudo.get_param('web.base.url')
            // msg = {
            //     "dbuuid": dbuuid,
            //     "nbr_users": nbr_users,
            //     "nbr_active_users": nbr_active_users,
            //     "nbr_share_users": nbr_share_users,
            //     "nbr_active_share_users": nbr_active_share_users,
            //     "dbname": self._cr.dbname,
            //     "db_create_date": db_create_date,
            //     "version": release.version,
            //     "language": user.lang,
            //     "web_base_url": web_base_url,
            //     "apps": [app['name'] for app in apps],
            //     "enterprise_code": enterprise_code,
            // }
            // if user.partner_id.company_id:
            //     company_id = user.partner_id.company_id
            //     msg.update(company_id.read(["name", "email", "phone"])[0])
            // return msg
            --- ODOO METHOD SOURCE (MODULE: website_mail, FILE: update.py) ---
            // def _get_message(self):
            // msg = super(PublisherWarrantyContract, self)._get_message()
            // msg['website'] = True
            // return msg
            */
            return default;
        }

        protected async Task<PublisherWarrantyContract> GetSysLogsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: update.py) ---
            // def _get_sys_logs(self):
            // """
            // Utility method to send a publisher warranty get logs messages.
            // """
            // msg = self._get_message()
            // arguments = {'arg0': str(msg), "action": "update"}
            // 
            // url = config.get("publisher_warranty_url")
            // 
            // r = requests.post(url, data=arguments, timeout=30)
            // r.raise_for_status()
            // return literal_eval(r.text)
            */
            return default;
        }

        public async Task<PublisherWarrantyContract> UpdateNotificationAsync(Guid id, PublisherWarrantyContractUpdateNotificationRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: update.py) ---
            // def update_notification(self, cron_mode=True):
            // """
            // Send a message to Odoo's publisher warranty server to check the
            // validity of the contracts, get notifications, etc...
            // 
            // @param cron_mode: If true, catch all exceptions (appropriate for usage in a cron).
            // @type cron_mode: boolean
            // """
            // try:
            //     try:
            //         result = self._get_sys_logs()
            //     except Exception:
            //         if cron_mode:   # we don't want to see any stack trace in cron
            //             return False
            //         _logger.debug("Exception while sending a get logs messages", exc_info=1)
            //         raise UserError(_("Error during communication with the publisher warranty server."))
            //     # old behavior based on res.log; now on mail.message, that is not necessarily installed
            //     user = self.env['res.users'].sudo().browse(SUPERUSER_ID)
            //     poster = self.sudo().env.ref('mail.channel_all_employees')
            //     for message in result["messages"]:
            //         try:
            //             poster.message_post(body=message, subtype_xmlid='mail.mt_comment', partner_ids=[user.partner_id.id])
            //         except Exception:
            //             pass
            //     if result.get('enterprise_info'):
            //         # Update expiration date
            //         set_param = self.env['ir.config_parameter'].sudo().set_param
            //         set_param('database.expiration_date', result['enterprise_info'].get('expiration_date'))
            //         set_param('database.expiration_reason', result['enterprise_info'].get('expiration_reason', 'trial'))
            //         set_param('database.enterprise_code', result['enterprise_info'].get('enterprise_code'))
            //         set_param('database.already_linked_subscription_url', result['enterprise_info'].get('database_already_linked_subscription_url'))
            //         set_param('database.already_linked_email', result['enterprise_info'].get('database_already_linked_email'))
            //         set_param('database.already_linked_send_mail_url', result['enterprise_info'].get('database_already_linked_send_mail_url'))
            // 
            // except Exception:
            //     if cron_mode:
            //         return False    # we don't want to see any stack trace in cron
            //     else:
            //         raise
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}