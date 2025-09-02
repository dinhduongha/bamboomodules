using Bamboo.Core.Application.Contracts.DTOs;
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
    [Module("Lunch", Depends = new[] { "mail" })]
    public class LunchOrderAppService : GenericApplicationService<LunchOrder>, ILunchOrderAppService
    {

        public LunchOrderAppService(IRepository<LunchOrder, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<LunchOrder> AddToCartAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def add_to_cart(self):
            // """
            //     This method currently does nothing, we currently need it in order to
            //     be able to reuse this model in place of a wizard
            // """
            // # YTI FIXME: Find a way to drop this.
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<LunchOrder> CancelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def action_cancel(self):
            // self.write({'state': 'cancelled'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<LunchOrder> CheckToppingQuantityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def _check_topping_quantity(self):
            // errors = {
            //     '1_more': _('You should order at least one %s'),
            //     '1': _('You have to order one and only one %s'),
            // }
            // for line in self:
            //     for index in range(1, 4):
            //         availability = line['available_toppings_%s' % index]
            //         quantity = line['topping_quantity_%s' % index]
            //         toppings = line['topping_ids_%s' % index].filtered(lambda x: x.topping_category == index)
            //         label = line['topping_label_%s' % index]
            // 
            //         if availability and quantity != '0_more':
            //             check = bool(len(toppings) == 1 if quantity == '1' else toppings)
            //             if not check:
            //                 raise ValidationError(errors[quantity] % label)
            */
            return default;
        }

        protected async Task<LunchOrder> CheckWalletInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def _check_wallet(self):
            // self.env.flush_all()
            // for line in self:
            //     if self.env['lunch.cashmove'].get_wallet_balance(line.user_id) < 0:
            //         raise ValidationError(_('Your wallet does not contain enough money to order that. To add some money to your wallet, please contact your lunch manager.'))
            */
            return default;
        }

        protected async Task<LunchOrder> ComputeAvailableOnDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def _compute_available_on_date(self):
            // for order in self:
            //     order.available_on_date = order.supplier_id._available_on_date(order.date)
            */
            return default;
        }

        protected async Task<LunchOrder> ComputeAvailableToppingsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def _compute_available_toppings(self):
            // for order in self:
            //     order.available_toppings_1 = bool(order.env['lunch.topping'].search_count([('supplier_id', '=', order.supplier_id.id), ('topping_category', '=', 1)]))
            //     order.available_toppings_2 = bool(order.env['lunch.topping'].search_count([('supplier_id', '=', order.supplier_id.id), ('topping_category', '=', 2)]))
            //     order.available_toppings_3 = bool(order.env['lunch.topping'].search_count([('supplier_id', '=', order.supplier_id.id), ('topping_category', '=', 3)]))
            */
            return default;
        }

        protected async Task<LunchOrder> ComputeDisplayAddButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def _compute_display_add_button(self):
            // new_orders = dict(self.env["lunch.order"]._read_group([
            //     ("date", "in", self.mapped("date")),
            //     ("user_id", "in", self.user_id.ids),
            //     ("state", "=", "new"),
            // ], ['user_id'], ['id:recordset']))
            // for order in self:
            //     user_new_orders = new_orders.get(order.user_id)
            //     price = 0
            //     if user_new_orders:
            //         user_new_orders = user_new_orders.filtered(lambda lunch_order: lunch_order.date == order.date)
            //         price = sum(order.price for order in user_new_orders)
            //     wallet_amount = self.env['lunch.cashmove'].get_wallet_balance(order.user_id, False) - price
            //     order.display_add_button = wallet_amount >= order.price
            */
            return default;
        }

        protected async Task<LunchOrder> ComputeDisplayReorderButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def _compute_display_reorder_button(self):
            // show_button = self.env.context.get('show_reorder_button')
            // for order in self:
            //     order.display_reorder_button = show_button and order.state == 'confirmed' and order.supplier_id.available_today
            */
            return default;
        }

        protected async Task<LunchOrder> ComputeDisplayToppingsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def _compute_display_toppings(self):
            // for line in self:
            //     toppings = line.topping_ids_1 | line.topping_ids_2 | line.topping_ids_3
            //     line.display_toppings = ' + '.join(toppings.mapped('name'))
            */
            return default;
        }

        protected async Task<LunchOrder> ComputeOrderDeadlinePassedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def _compute_order_deadline_passed(self):
            // today = fields.Date.context_today(self)
            // for order in self:
            //     if order.date < today:
            //         order.order_deadline_passed = True
            //     elif order.date == today:
            //         order.order_deadline_passed = order.supplier_id.order_deadline_passed
            //     else:
            //         order.order_deadline_passed = False
            */
            return default;
        }

        protected async Task<LunchOrder> ComputeProductImagesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def _compute_product_images(self):
            // for line in self:
            //     line.image_1920 = line.product_id.image_1920 or line.category_id.image_1920
            //     line.image_128 = line.product_id.image_128 or line.category_id.image_128
            */
            return default;
        }

        protected async Task<LunchOrder> ComputeTotalPriceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def _compute_total_price(self):
            // for line in self:
            //     line.price = line.quantity * (line.product_id.price + sum((line.topping_ids_1 | line.topping_ids_2 | line.topping_ids_3).mapped('price')))
            */
            return default;
        }

        public async Task<LunchOrder> ConfirmAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def action_confirm(self):
            // self.write({'state': 'confirmed'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<LunchOrder> ExtractToppingsInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def _extract_toppings(self, values):
            // """
            //     If called in api.multi then it will pop topping_ids_1,2,3 from values
            // """
            // topping_ids = []
            // 
            // for i in range(1, 4):
            //     topping_field = f'topping_ids_{i}'
            //     topping_values = values.get(topping_field, False)
            // 
            //     if self.ids:
            //         # TODO This is not taking into account all the toppings for each individual order, this is usually not a problem
            //         # since in the interface you usually don't update more than one order at a time but this is a bug nonetheless
            //         topping_ids += self._get_topping_ids(topping_field, values.pop(topping_field)) \
            //             if topping_values else self[:1][topping_field].ids
            //     else:
            //         topping_ids += self._get_topping_ids(topping_field, topping_values) if topping_values else []
            // 
            // return topping_ids
            */
            return default;
        }

        protected async Task<LunchOrder> FindMatchingLinesInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def _find_matching_lines(self, values):
            // default_location_id = self.env.user.last_lunch_location_id and self.env.user.last_lunch_location_id.id or False
            // domain = [
            //     ('user_id', '=', values.get('user_id', self.default_get(['user_id'])['user_id'])),
            //     ('product_id', '=', values.get('product_id', False)),
            //     ('date', '=', values.get('date', fields.Date.today())),
            //     ('note', '=', values.get('note', False)),
            //     ('lunch_location_id', '=', values.get('lunch_location_id', default_location_id)),
            // ]
            // if values.get('state'):
            //     domain = AND([domain, [('state', '=', values['state'])]])
            // toppings = values.get('toppings', [])
            // return self.search(domain).filtered(lambda line: (line.topping_ids_1 | line.topping_ids_2 | line.topping_ids_3).ids == toppings)
            */
            return default;
        }

        protected async Task<LunchOrder> GetToppingIdsInternalAsync(object field, object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def _get_topping_ids(self, field, values):
            // return list(self._fields[field].convert_to_cache(values, self))
            */
            return default;
        }

        public async Task<LunchOrder> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def init(self):
            // self._cr.execute("""CREATE INDEX IF NOT EXISTS lunch_order_user_product_date ON %s (user_id, product_id, date)"""
            //     % self._table)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<LunchOrder> NotifyAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def action_notify(self):
            // self -= self.filtered('notified')
            // if not self:
            //     return
            // notified_users = set()
            // # (company, lang): (subject, body)
            // translate_cache = dict()
            // for order in self:
            //     user = order.user_id
            //     if user in notified_users:
            //         continue
            //     _key = (order.company_id, user.lang)
            //     if _key not in translate_cache:
            //         context = {'lang': user.lang}
            //         translate_cache[_key] = (_('Lunch notification'), order.company_id.with_context(lang=user.lang).lunch_notify_message)
            //         del context
            //     subject, body = translate_cache[_key]
            //     user.partner_id.message_notify(
            //         subject=subject,
            //         body=body,
            //         partner_ids=user.partner_id.ids,
            //         email_layout_xmlid='mail.mail_notification_light',
            //     )
            //     notified_users.add(user)
            // self.write({'notified': True})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<LunchOrder> OrderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def action_order(self):
            // for order in self:
            //     if not order.available_on_date:
            //         raise UserError(_('The vendor related to this order is not available at the selected date.'))
            // if self.filtered(lambda line: not line.product_id.active):
            //     raise ValidationError(_('Product is no longer available.'))
            // self.write({
            //     'state': 'ordered',
            // })
            // self._check_wallet()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<LunchOrder> ReorderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def action_reorder(self):
            // self.ensure_one()
            // if not self.supplier_id.available_today:
            //     raise UserError(_('The vendor related to this order is not available today.'))
            // self.copy({
            //     'date': fields.Date.context_today(self),
            //     'state': 'ordered',
            // })
            // action = self.env['ir.actions.act_window']._for_xml_id('lunch.lunch_order_action')
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<LunchOrder> ResetAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def action_reset(self):
            // self.write({'state': 'ordered'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<LunchOrder> SendAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def action_send(self):
            // self.state = 'sent'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<LunchOrder> UpdateQuantityAsync(Guid id, LunchOrderUpdateQuantityRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: lunch, FILE: lunch_order.py) ---
            // def update_quantity(self, increment):
            // for line in self.filtered(lambda line: line.state not in ['sent', 'confirmed']):
            //     if line.quantity <= -increment:
            //         # TODO: maybe unlink the order?
            //         line.active = False
            //     else:
            //         line.quantity += increment
            // self._check_wallet()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}