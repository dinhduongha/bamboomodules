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
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("MassMailing", Category = "Marketing", Depends = new[] { "contacts", "mail", "html_builder", "utm", "link_tracker", "social_media", "web_tour", "digest" })]
    public partial class MailingTraceAppService : GenericApplicationService<MailingTrace>, IMailingTraceAppService
    {

        public MailingTraceAppService(IRepository<MailingTrace, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        protected async Task<MailingTrace> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py) ---
            // def _compute_display_name(self):
            // for trace in self:
            //     trace.display_name = f'{trace.trace_type}: {trace.mass_mailing_id.name} ({trace.id})'
            */
            return default;
        }

        protected async Task<MailingTrace> ComputeSmsIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_trace.py) ---
            // def _compute_sms_id(self):
            // self.sms_id = False
            // sms_traces = self.filtered(lambda t: t.trace_type == 'sms' and bool(t.sms_id_int))
            // if not sms_traces:
            //     return
            // existing_sms_ids = self.env['sms.sms'].sudo().search([
            //     ('id', 'in', sms_traces.mapped('sms_id_int')), ('to_delete', '!=', True)
            // ]).ids
            // for sms_trace in sms_traces.filtered(lambda n: n.sms_id_int in set(existing_sms_ids)):
            //     sms_trace.sms_id = sms_trace.sms_id_int
            */
            return default;
        }

        public override async Task<MailingTrace> CreateAsync(MailingTrace entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py) ---
            // def create(self, vals_list):
            // for values in vals_list:
            //     if 'mail_mail_id' in values:
            //         values['mail_mail_id_int'] = values['mail_mail_id']
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_trace.py) ---
            // def create(self, vals_list):
            // for values in vals_list:
            //     if values.get('trace_type') == 'sms' and not values.get('sms_code'):
            //         values['sms_code'] = self._get_random_code()
            // return super().create(vals_list)
            */
            return await base.CreateAsync(entity, fields);
        }

        public override async Task<Dictionary<string, Dictionary<string, object>>> FieldsGetAsync(List<string> fields = null, Dictionary<string, List<string>> attributes = null)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_trace.py) ---
            // def fields_get(self, allfields=None, attributes=None):
            // # As we are adding keys in stable, better be sure no-one is getting crashes
            // # due to missing translations
            // # TODO: remove in master
            // res = super().fields_get(allfields=allfields, attributes=attributes)
            // 
            // existing_selection = res.get('failure_type', {}).get('selection')
            // if existing_selection is None:
            //     return res
            // 
            // updated_stable = {
            //     'twilio_authentication', 'twilio_callback',
            //     'twilio_from_missing', 'twilio_from_to',
            // }
            // need_update = updated_stable - set(dict(self._fields['failure_type'].selection))
            // if need_update:
            //     self.env['ir.model.fields'].invalidate_model(['selection_ids'])
            //     self.env['ir.model.fields.selection']._update_selection(
            //         self._name,
            //         'failure_type',
            //         self._fields['failure_type'].selection,
            //     )
            //     self.env.registry.clear_cache()
            //     return super().fields_get(allfields=allfields, attributes=attributes)
            // 
            // return res
            */
            return await base.FieldsGetAsync(fields, attributes);
        }

        protected async Task<MailingTrace> GetRandomCodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_trace.py) ---
            // def _get_random_code(self):
            // """ Generate a random code for trace. Uniqueness is not really necessary
            // as it serves as obfuscation when unsubscribing. A valid trio
            // code / mailing_id / number will be requested. """
            // return ''.join(random.choice(string.ascii_letters + string.digits) for dummy in range(self.CODE_SIZE))
            */
            return default;
        }

        public async Task<MailingTrace> SetBouncedAsync(Guid id, MailingTraceSetBouncedRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py) ---
            // def set_bounced(self, domain=None, bounce_message=False):
            // traces = self + (self.search(domain) if domain else self.env['mailing.trace'])
            // traces.write({
            //     'failure_reason': bounce_message,
            //     'failure_type': 'mail_bounce',
            //     'trace_status': 'bounce',
            // })
            // return traces
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingTrace> SetCanceledAsync(Guid id, MailingTraceSetCanceledRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py) ---
            // def set_canceled(self, domain=None):
            // traces = self + (self.search(domain) if domain else self.env['mailing.trace'])
            // traces.write({'trace_status': 'cancel'})
            // return traces
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingTrace> SetClickedAsync(Guid id, MailingTraceSetClickedRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py) ---
            // def set_clicked(self, domain=None):
            // traces = self + (self.search(domain) if domain else self.env['mailing.trace'])
            // traces.write({'links_click_datetime': fields.Datetime.now()})
            // return traces
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingTrace> SetFailedAsync(Guid id, MailingTraceSetFailedRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py) ---
            // def set_failed(self, domain=None, failure_type=False):
            // traces = self + (self.search(domain) if domain else self.env['mailing.trace'])
            // traces.write({'trace_status': 'error', 'failure_type': failure_type})
            // return traces
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingTrace> SetOpenedAsync(Guid id, MailingTraceSetOpenedRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py) ---
            // def set_opened(self, domain=None):
            // """ Reply / Open are a bit shared in various processes: reply implies
            // open, click implies open. Let us avoid status override by skipping traces
            // that are not already opened or replied. """
            // traces = self + (self.search(domain) if domain else self.env['mailing.trace'])
            // traces.filtered(lambda t: t.trace_status not in ('open', 'reply')).write({'trace_status': 'open', 'open_datetime': fields.Datetime.now()})
            // return traces
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingTrace> SetRepliedAsync(Guid id, MailingTraceSetRepliedRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py) ---
            // def set_replied(self, domain=None):
            // traces = self + (self.search(domain) if domain else self.env['mailing.trace'])
            // traces.write({'trace_status': 'reply', 'reply_datetime': fields.Datetime.now()})
            // return traces
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingTrace> SetSentAsync(Guid id, MailingTraceSetSentRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py) ---
            // def set_sent(self, domain=None):
            // traces = self + (self.search(domain) if domain else self.env['mailing.trace'])
            // traces.write({'trace_status': 'sent', 'sent_datetime': fields.Datetime.now(), 'failure_type': False})
            // return traces
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingTrace> ViewContactAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_trace.py) ---
            // def action_view_contact(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': self.model,
            //     'target': 'current',
            //     'res_id': self.res_id
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}