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
    [Module("MassMailing", Depends = new[] { "contacts", "mail", "utm", "link_tracker", "web_editor", "social_media", "web_tour", "digest" })]
    public class MailingTraceAppService : GenericApplicationService<MailingTrace>, IMailingTraceAppService
    {

        public MailingTraceAppService(IRepository<MailingTrace, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
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
            // def create(self, values_list):
            // for values in values_list:
            //     if 'mail_mail_id' in values:
            //         values['mail_mail_id_int'] = values['mail_mail_id']
            // return super(MailingTrace, self).create(values_list)
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_trace.py) ---
            // def create(self, values_list):
            // for values in values_list:
            //     if values.get('trace_type') == 'sms' and not values.get('sms_code'):
            //         values['sms_code'] = self._get_random_code()
            // return super(MailingTrace, self).create(values_list)
            */
            return await base.CreateAsync(entity, fields);
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

        public async Task<MailingTrace> SetBouncedAsync(Guid id, object domain, object bounce_message)
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

        public async Task<MailingTrace> SetCanceledAsync(Guid id, object domain)
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

        public async Task<MailingTrace> SetClickedAsync(Guid id, object domain)
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

        public async Task<MailingTrace> SetFailedAsync(Guid id, object domain, object failure_type)
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

        public async Task<MailingTrace> SetOpenedAsync(Guid id, object domain)
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

        public async Task<MailingTrace> SetRepliedAsync(Guid id, object domain)
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

        public async Task<MailingTrace> SetSentAsync(Guid id, object domain)
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