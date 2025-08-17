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
    [Module("EventBoothModule", Depends = new[] { "event" })]
    public class EventTypeBoothAppService : GenericApplicationService<EventTypeBooth>, IEventTypeBoothAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public EventTypeBoothAppService(IRepository<EventTypeBooth, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<EventTypeBooth> ActionPostConfirmInternalAsync(object write_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py) ---
            // def _action_post_confirm(self, write_vals):
            // self._post_confirmation_message()
            */
            return default;
        }

        protected async Task<EventTypeBooth> ComputeContactEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py) ---
            // def _compute_contact_email(self):
            // for booth in self:
            //     if not booth.contact_email:
            //         booth.contact_email = booth.partner_id.email or False
            */
            return default;
        }

        protected async Task<EventTypeBooth> ComputeContactNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py) ---
            // def _compute_contact_name(self):
            // for booth in self:
            //     if not booth.contact_name:
            //         booth.contact_name = booth.partner_id.name or False
            */
            return default;
        }

        protected async Task<EventTypeBooth> ComputeContactPhoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py) ---
            // def _compute_contact_phone(self):
            // for booth in self:
            //     if not booth.contact_phone:
            //         booth.contact_phone = booth.partner_id.phone or booth.partner_id.mobile or False
            */
            return default;
        }

        protected async Task<EventTypeBooth> ComputeIsAvailableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py) ---
            // def _compute_is_available(self):
            // for booth in self:
            //     booth.is_available = booth.state == 'available'
            */
            return default;
        }

        public async Task<EventTypeBooth> ConfirmAsync(Guid id, object additional_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py) ---
            // def action_confirm(self, additional_values=None):
            // write_vals = dict({'state': 'unavailable'}, **additional_values or {})
            // self.write(write_vals)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<EventTypeBooth> GetDefaultBoothCategoryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_type_booth.py) ---
            // def _get_default_booth_category(self):
            // """Assign booth category by default if only one exists"""
            // category_id = self.env['event.booth.category'].search([])
            // if category_id and len(category_id) == 1:
            //     return category_id
            */
            return default;
        }

        protected async Task<EventTypeBooth> GetEventBoothFieldsWhitelistInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_type_booth.py) ---
            // def _get_event_booth_fields_whitelist(self):
            // return ['name', 'booth_category_id']
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: event_type_booth.py) ---
            // def _get_event_booth_fields_whitelist(self):
            // res = super(EventTypeBooth, self)._get_event_booth_fields_whitelist()
            // return res + ['product_id', 'price']
            */
            return default;
        }

        protected async Task<EventTypeBooth> PostConfirmationMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py) ---
            // def _post_confirmation_message(self):
            // for booth in self:
            //     booth.event_id.message_post_with_source(
            //         'event_booth.event_booth_booked_template',
            //         render_values={
            //             'booth': booth,
            //         },
            //         subtype_xmlid='event_booth.mt_event_booth_booked',
            //     )
            */
            return default;
        }

        protected async Task<EventTypeBooth> SearchIsAvailableInternalAsync(object @operator, object operand)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py) ---
            // def _search_is_available(self, operator, operand):
            // negative = operator in expression.NEGATIVE_TERM_OPERATORS
            // if (negative and operand) or not operand:
            //     return [('state', '=', 'unavailable')]
            // return [('state', '=', 'available')]
            */
            return default;
        }
    }
}