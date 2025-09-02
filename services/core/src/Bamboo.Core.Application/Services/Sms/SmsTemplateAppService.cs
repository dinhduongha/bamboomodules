using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("Sms", Depends = new[] { "base", "iap_mail", "mail", "phone_validation" })]
    public class SmsTemplateAppService : GenericApplicationService<SmsTemplate>, ISmsTemplateAppService
    {
        private readonly IMailRenderMixinAppService _mailRenderMixinAppService;
        private readonly ITemplateResetMixinAppService _templateResetMixinAppService;
        public SmsTemplateAppService(IRepository<SmsTemplate, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailRenderMixinAppService mailRenderMixinAppService, ITemplateResetMixinAppService templateResetMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailRenderMixinAppService = mailRenderMixinAppService;
            _templateResetMixinAppService = templateResetMixinAppService;
        }

        protected async Task<SmsTemplate> ComputeRenderModelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_template.py) ---
            // def _compute_render_model(self):
            // for template in self:
            //     template.render_model = template.model
            */
            return default;
        }

        public async Task<SmsTemplate> CopyDataAsync(Guid id, SmsTemplateCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_template.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", template.name)) for template, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<SmsTemplate> CreateSidebarActionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_template.py) ---
            // def action_create_sidebar_action(self):
            // ActWindow = self.env['ir.actions.act_window']
            // view = self.env.ref('sms.sms_composer_view_form')
            // 
            // for template in self:
            //     button_name = _('Send SMS (%s)', template.name)
            //     action = ActWindow.create({
            //         'name': button_name,
            //         'type': 'ir.actions.act_window',
            //         'res_model': 'sms.composer',
            //         # Add default_composition_mode to guess to determine if need to use mass or comment composer
            //         'context': "{'default_template_id' : %d, 'sms_composition_mode': 'guess', 'default_res_ids': active_ids, 'default_res_id': active_id}" % (template.id),
            //         'view_mode': 'form',
            //         'view_id': view.id,
            //         'target': 'new',
            //         'binding_model_id': template.model_id.id,
            //     })
            //     template.write({'sidebar_action_id': action.id})
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<SmsTemplate> SearchInternalAsync(object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sms, FILE: sms_template.py) ---
            // def _search(self, domain, *args, **kwargs):
            // """Context-based hack to filter reference field in a m2o search box to emulate a domain the ORM currently does not support.
            // 
            // As we can not specify a domain on a reference field, we added a context
            // key `filter_template_on_event` on the template reference field. If this
            // key is set, we add our domain in the `domain` in the `_search`
            // method to filtrate the SMS templates.
            // """
            // if self.env.context.get('filter_template_on_event'):
            //     domain = expression.AND([[('model', '=', 'event.registration')], domain])
            // return super()._search(domain, *args, **kwargs)
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sms, FILE: sms_template.py) ---
            // def unlink(self):
            // res = super().unlink()
            // domain = ('template_ref', 'in', [f"{template._name},{template.id}" for template in self])
            // self.env['event.mail'].sudo().search([domain]).unlink()
            // self.env['event.type.mail'].sudo().search([domain]).unlink()
            // return res
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_template.py) ---
            // def unlink(self):
            // self.sudo().mapped('sidebar_action_id').unlink()
            // return super(SMSTemplate, self).unlink()
            */
            return await base.UnlinkAsync(ids);
        }

        public async Task<SmsTemplate> UnlinkSidebarActionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: sms_template.py) ---
            // def action_unlink_sidebar_action(self):
            // for template in self:
            //     if template.sidebar_action_id:
            //         template.sidebar_action_id.unlink()
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}