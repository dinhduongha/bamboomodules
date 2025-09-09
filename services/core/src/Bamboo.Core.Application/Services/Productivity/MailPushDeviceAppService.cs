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
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;

namespace Bamboo.Core.Application.Services
{
    [Module("Mail", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public class MailPushDeviceAppService : GenericApplicationService<MailPushDevice>, IMailPushDeviceAppService
    {

        public MailPushDeviceAppService(IRepository<MailPushDevice, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<MailPushDevice> GetWebPushVapidPublicKeyAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_push_device.py) ---
            // def get_web_push_vapid_public_key(self):
            // ir_params_sudo = self.env['ir.config_parameter'].sudo()
            // public_key = 'mail.web_push_vapid_public_key'
            // public_key_value = ir_params_sudo.get_param(public_key)
            // # Regenerate new Keys if public key not present
            // if not public_key_value:
            //     self.sudo().search([]).unlink()  # Reset all devices (ServiceWorker)
            //     private_key_value, public_key_value = generate_vapid_keys()
            //     ir_params_sudo.set_param('mail.web_push_vapid_private_key', private_key_value)
            //     ir_params_sudo.set_param(public_key, public_key_value)
            //     _logger.info("WebPush: missing public key, new VAPID keys generated")
            // return public_key_value
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailPushDevice> RegisterDevicesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_push_device.py) ---
            // def register_devices(self, **kw):
            // sw_vapid_public_key = kw.get('vapid_public_key')
            // valid_sub = self._verify_vapid_public_key(sw_vapid_public_key)
            // if not valid_sub:
            //     raise InvalidVapidError("Invalid VAPID public key")
            // endpoint = kw.get('endpoint')
            // browser_keys = kw.get('keys')
            // if not endpoint or not browser_keys:
            //     return
            // search_endpoint = kw.get('previousEndpoint', endpoint)
            // mail_push_device = self.sudo().search([('endpoint', '=', search_endpoint)])
            // if mail_push_device:
            //     if mail_push_device.partner_id is not self.env.user.partner_id:
            //         mail_push_device.write({
            //             'endpoint': endpoint,
            //             'expiration_time': kw.get('expirationTime'),
            //             'keys': json.dumps(browser_keys),
            //             'partner_id': self.env.user.partner_id,
            //         })
            // else:
            //     self.sudo().create([{
            //         'endpoint': endpoint,
            //         'expiration_time': kw.get('expirationTime'),
            //         'keys': json.dumps(browser_keys),
            //         'partner_id': self.env.user.partner_id.id,
            //     }])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailPushDevice> UnregisterDevicesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_push_device.py) ---
            // def unregister_devices(self, **kw):
            // endpoint = kw.get('endpoint')
            // if not endpoint:
            //     return
            // mail_push_device = self.sudo().search([
            //     ('endpoint', '=', endpoint)
            // ])
            // if mail_push_device:
            //     mail_push_device.unlink()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailPushDevice> VerifyVapidPublicKeyInternalAsync(object sw_public_key)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_push_device.py) ---
            // def _verify_vapid_public_key(self, sw_public_key):
            // ir_params_sudo = self.env['ir.config_parameter'].sudo()
            // db_public_key = ir_params_sudo.get_param('mail.web_push_vapid_public_key')
            // return db_public_key == sw_public_key
            */
            return default;
        }
    }
}