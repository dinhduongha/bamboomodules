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
    [Module("EventBoothSale", Depends = new[] { "event_booth", "event_sale" })]
    public class EventBoothRegistrationAppService : GenericApplicationService<EventBoothRegistration>, IEventBoothRegistrationAppService
    {

        public EventBoothRegistrationAppService(IRepository<EventBoothRegistration, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<EventBoothRegistration> CancelPendingRegistrationsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: event_booth_registration.py) ---
            // def _cancel_pending_registrations(self):
            // body = Markup('<p>%(message)s: <ul>%(booth_names)s</ul></p>') % {
            //     'message': _('Your order has been cancelled because the following booths have been reserved'),
            //     'booth_names': Markup().join(Markup('<li>%s</li>') % booth.display_name for booth in self.event_booth_id)
            // }
            // other_registrations = self.search([
            //     ('event_booth_id', 'in', self.event_booth_id.ids),
            //     ('id', 'not in', self.ids)
            // ])
            // for order in other_registrations.sale_order_line_id.order_id:
            //     order.sudo().message_post(
            //         body=body,
            //         partner_ids=order.user_id.partner_id.ids,
            //     )
            //     order.sudo()._action_cancel()
            // other_registrations.unlink()
            */
            return default;
        }

        protected async Task<EventBoothRegistration> ComputeContactEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: event_booth_registration.py) ---
            // def _compute_contact_email(self):
            // for registration in self:
            //     if not registration.contact_email:
            //         registration.contact_email = registration.partner_id.email or False
            */
            return default;
        }

        protected async Task<EventBoothRegistration> ComputeContactNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: event_booth_registration.py) ---
            // def _compute_contact_name(self):
            // for registration in self:
            //     if not registration.contact_name:
            //         registration.contact_name = registration.partner_id.name or False
            */
            return default;
        }

        protected async Task<EventBoothRegistration> ComputeContactPhoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: event_booth_registration.py) ---
            // def _compute_contact_phone(self):
            // for registration in self:
            //     if not registration.contact_phone:
            //         registration.contact_phone = registration.partner_id.phone or registration.partner_id.mobile or False
            */
            return default;
        }

        public async Task<EventBoothRegistration> ConfirmAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: event_booth_registration.py) ---
            // def action_confirm(self):
            // for registration in self:
            //     values = {
            //         field: registration[field].id if isinstance(registration[field], models.BaseModel) else registration[field]
            //         for field in self._get_fields_for_booth_confirmation()
            //     }
            //     registration.event_booth_id.action_confirm(values)
            // self._cancel_pending_registrations()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<EventBoothRegistration> GetFieldsForBoothConfirmationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: event_booth_registration.py) ---
            // def _get_fields_for_booth_confirmation(self):
            // return ['sale_order_line_id', 'partner_id', 'contact_name', 'contact_email', 'contact_phone']
            --- ODOO METHOD SOURCE (MODULE: website_event_booth_sale_exhibitor, FILE: event_booth_registration.py) ---
            // def _get_fields_for_booth_confirmation(self):
            // return super(EventBoothRegistration, self)._get_fields_for_booth_confirmation() + \
            //        ['sponsor_name', 'sponsor_email', 'sponsor_mobile', 'sponsor_phone', 'sponsor_subtitle',
            //         'sponsor_website_description', 'sponsor_image_512']
            */
            return default;
        }
    }
}