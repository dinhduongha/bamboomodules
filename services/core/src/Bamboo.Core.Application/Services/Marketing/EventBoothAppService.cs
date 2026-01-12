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
    [Module("EventBoothModule", Category = "Marketing", Depends = new[] { "event" })]
    public class EventBoothAppService : GenericApplicationService<EventBooth>, IEventBoothAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public EventBoothAppService(IRepository<EventBooth, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<EventBooth> ActionPostConfirmInternalAsync(object write_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py) ---
            // def _action_post_confirm(self, write_vals):
            // self._post_confirmation_message()
            --- ODOO METHOD SOURCE (MODULE: website_event_booth_exhibitor, FILE: event_booth.py) ---
            // def _action_post_confirm(self, write_vals):
            // for booth in self:
            //     if booth.use_sponsor and booth.partner_id:
            //         booth.sponsor_id = booth._get_or_create_sponsor(write_vals)
            // super(EventBooth, self)._action_post_confirm(write_vals)
            */
            return default;
        }

        protected async Task<EventBooth> ComputeContactEmailInternalAsync()
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

        protected async Task<EventBooth> ComputeContactNameInternalAsync()
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

        protected async Task<EventBooth> ComputeContactPhoneInternalAsync()
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

        protected async Task<EventBooth> ComputeIsAvailableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py) ---
            // def _compute_is_available(self):
            // for booth in self:
            //     booth.is_available = booth.state == 'available'
            */
            return default;
        }

        public async Task<EventBooth> ConfirmAsync(Guid id, EventBoothConfirmRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py) ---
            // def action_confirm(self, additional_values=None):
            // write_vals = dict({'state': 'unavailable'}, **additional_values or {})
            // self.write(write_vals)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<EventBooth> GetBoothMultilineDescriptionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: event_booth.py) ---
            // def _get_booth_multiline_description(self):
            // return '%s : \n%s' % (
            //     self.event_id.display_name,
            //     '\n'.join(['- %s' % booth.name for booth in self])
            // )
            */
            return default;
        }

        protected async Task<EventBooth> GetDefaultBoothCategoryInternalAsync()
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

        protected async Task<EventBooth> GetEventBoothFieldsWhitelistInternalAsync()
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

        protected async Task<EventBooth> GetOrCreateSponsorInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_booth_exhibitor, FILE: event_booth.py) ---
            // def _get_or_create_sponsor(self, vals):
            // self.ensure_one()
            // sponsor_id = self.env['event.sponsor'].sudo().search([
            //     ('partner_id', '=', self.partner_id.id),
            //     ('sponsor_type_id', '=', self.sponsor_type_id.id),
            //     ('exhibitor_type', '=', self.booth_category_id.exhibitor_type),
            //     ('event_id', '=', self.event_id.id),
            // ], limit=1)
            // if not sponsor_id:
            //     values = {
            //         'event_id': self.event_id.id,
            //         'sponsor_type_id': self.sponsor_type_id.id,
            //         'exhibitor_type': self.booth_category_id.exhibitor_type,
            //         'partner_id': self.partner_id.id,
            //         **{key.partition('sponsor_')[2]: value for key, value in vals.items() if key.startswith('sponsor_')},
            //     }
            //     # If confirmed from backend, we don't have _prepare_booth_registration_values
            //     if not values.get('name'):
            //         values['name'] = self.partner_id.name
            //     if self.booth_category_id.exhibitor_type == 'online':
            //         values.update({
            //             'room_name': 'odoo-exhibitor-%s' % self.partner_id.name,
            //         })
            //     sponsor_id = self.env['event.sponsor'].sudo().create(values)
            // return sponsor_id.id
            */
            return default;
        }

        protected async Task<EventBooth> PostConfirmationMessageInternalAsync()
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

        protected async Task<EventBooth> SearchIsAvailableInternalAsync(object @operator, object operand)
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

        public async Task<EventBooth> SetPaidAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: event_booth.py) ---
            // def action_set_paid(self):
            // self.write({'is_paid': True})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<EventBooth> UnlinkExceptLinkedSaleOrderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: event_booth.py) ---
            // def _unlink_except_linked_sale_order(self):
            // booth_with_so = self.sudo().filtered('sale_order_id')
            // if booth_with_so:
            //     raise UserError(_(
            //         'You can\'t delete the following booths as they are linked to sales orders: '
            //         '%(booths)s', booths=', '.join(booth_with_so.mapped('name'))))
            */
            return default;
        }

        public async Task<EventBooth> ViewSaleOrderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth_sale, FILE: event_booth.py) ---
            // def action_view_sale_order(self):
            // self.sale_order_id.ensure_one()
            // action = self.env['ir.actions.actions']._for_xml_id('sale.action_orders')
            // action['views'] = [(False, 'form')]
            // action['res_id'] = self.sale_order_id.id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<EventBooth> ViewSponsorAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_booth_exhibitor, FILE: event_booth.py) ---
            // def action_view_sponsor(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('website_event_exhibitor.event_sponsor_action')
            // action['views'] = [(False, 'form')]
            // action['res_id'] = self.sponsor_id.id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}